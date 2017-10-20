using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmPopUp : Form
    {
        #region Variables
        private int intErrorHeight = 250;
        private int intErrorWidth = 600;
        private int intMinHeight = 150;
        private int intMinWidth = 300;
        private int intPadHeight = 100;
        private int intPadWidth = 150;
        private int intPadBottom = 70;

        private Exception pexc = null;
        private bool pblnErrorSave = true;
        private int pintPopUpType = utilConstants.cPTInfo;
        private string pstrMessage = string.Empty;
        private string pstrErorForm = string.Empty;
        private string pstrErrorMethod = string.Empty;
        private string pstrErrorOffice = string.Empty;
        private string pstrErrorUser = string.Empty;
        #endregion Variables

        #region Properties
        public string ErrorForm
        {
            get { return pstrErorForm; }
            set { pstrErorForm = value; }
        }

        public string ErrorMethod
        {
            get { return pstrErrorMethod; }
            set { pstrErrorMethod = value; }
        }

        public Exception ErrorOccurred
        {
            get { return pexc; }
            set { pexc = value; }
        }

        public bool ErrorSave
        {
            get { return pblnErrorSave; }
            set { pblnErrorSave = value; }
        }

        public string ErrorOffice
        {
            get { return pstrErrorOffice; }
            set { pstrErrorOffice = value; }
        }

        public string ErrorUser
        {
            get { return pstrErrorUser; }
            set { pstrErrorUser = value; }
        }

        public string Message
        {
            get { return pstrMessage; }
            set { pstrMessage = value; }
        }

        public int PopUpType
        {
            get { return pintPopUpType; }
            set { pintPopUpType = value; }
        }
        #endregion Properties

        #region Form Methods
        public frmPopUp()
        {
            InitializeComponent();
        }
        private void frmPopUp_Load(object sender, EventArgs e)
        {
            if (ErrorOccurred != null)
                SaveError();
            SetDisplay();
        }
        #endregion Form Methods

        #region Control Methods
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblErrorVisibility_Click(object sender, EventArgs e)
        {
            #region Variables
            int intWidth = this.Width;
            #endregion Variables

            #region Set Error Visibility
            if (lblErrorVisibility.Text.Equals("+"))
            {
                lblErrorVisibility.Text = "-";
                txtError.Visible = true;
                if (intErrorWidth > intWidth)
                    intWidth = intErrorWidth;
                this.Size = new Size(intWidth, this.Height + intErrorHeight);
            }
            else
            {
                lblErrorVisibility.Text = "+";
                txtError.Visible = false;
                SetSize();
            }
            #endregion Set Error Visibility
        }
        #endregion Control Methods

        #region Private Methods
        private void SaveError()
        {
            if (ErrorSave)
            {
                #region Variables
                DBConnection dbCon = null;
                ssError dalErr = null;
                #endregion Variables

                #region Save
                dbCon = new DBConnection(utilConstants.cACKConnection);
                try
                {
                    dalErr = new ssError(ErrorForm, ErrorMethod, ErrorOccurred.Message, ErrorOccurred.ToString(), ErrorUser, ErrorOffice);
                    dalErr.Save(dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Save
            }
        }

        private void SetDisplay()
        {
            lblMessage.Text = Message;
            SetError();
            SetImage();
            SetSize();
        }

        private void SetError()
        {
            #region Set Error
            if (ErrorOccurred != null)
            {
                lblErrorDisplay.Visible = true;
                lblErrorVisibility.Visible = true;
                txtError.Text = ErrorOccurred.ToString();
            }
            else
            {
                lblErrorDisplay.Visible = false;
                lblErrorVisibility.Visible = false;
            }
            #endregion Set Error
        }

        private void SetImage()
        {
            #region Variables
            string strFile = utilConstants.cPIInfo;
            string strFolder = ConfigurationManager.AppSettings[utilConstants.cACKImageFolder].ToString();
            string strPath = Application.StartupPath + "\\" + strFolder + "\\";
            #endregion Variables

            #region Set Image
            switch (PopUpType)
            {
                case utilConstants.cPTError:
                    strFile = utilConstants.cPIError;
                    break;
                case utilConstants.cPTInfo:
                    strFile = utilConstants.cPIInfo;
                    break;
                case utilConstants.cPTWarning:
                    strFile = utilConstants.cPIWarning;
                    break;
            }

            pbImage.Image = Image.FromFile(strPath + strFile);
            #endregion Set Image
        }

        private void SetSize()
        {
            #region Variables
            int intHeight = lblMessage.Height + intPadHeight;
            int intWidth = lblMessage.Width + intPadWidth;
            #endregion Variables

            #region Resize
            if (intMinHeight > intHeight)
                intHeight = intMinHeight;

            if (intMinWidth > intWidth)
                intWidth = intMinWidth;

            this.Size = new Size(intWidth, intHeight);

            btnOk.Location = new Point(btnOk.Location.X, intHeight - (intPadBottom + 5));
            lblErrorDisplay.Location = new Point(lblErrorDisplay.Location.X, intHeight - intPadBottom);
            lblErrorVisibility.Location = new Point(lblErrorVisibility.Location.X, intHeight - intPadBottom);
            #endregion Resize
        }
        #endregion Private Methods
    }
}
