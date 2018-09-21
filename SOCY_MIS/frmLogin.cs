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
    public partial class frmLogin : Form
    {
        #region Variables
        private bool pblnNoDatabase = false;
        private bool pblnNotConnected = false;
        #endregion Variables

        #region Properties
        public bool NoDatabase
        {
            get { return pblnNoDatabase; }
            set { pblnNoDatabase = value; }
        }

        public bool NotConnected
        {
            get { return pblnNotConnected; }
            set { pblnNotConnected = value; }
        }
        #endregion Properties

        #region Form Methods
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                #region For Testing
                NoDatabase = Convert.ToBoolean(ConfigurationManager.AppSettings[utilConstants.cACKNoDatabase].ToString());
                #endregion For Testing

                #region Variables
                FormCollection fcOpen = null;
                frmDBConnection frmDBC = null;
                #endregion Variables

                #region Version
                lblVersionNumber.Text = ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString();
                #endregion Version

                if (!NoDatabase)
                {
                    #region Check Database Connection
                    if (!DBConnection.CanConnect(utilConstants.cACKConnection))
                    {
                        NotConnected = true;
                        fcOpen = Application.OpenForms;
                        frmDBC = (frmDBConnection)fcOpen["frmDBConnection"];
                        if (frmDBC == null)
                            frmDBC = new frmDBConnection();
                        frmDBC.FormCalling = this;
                        frmDBC.ShowDialog();
                    }
                    else
                    {
                        if (!DBAlteration.TableExists(utilConstants.cADTableCheck))
                        {
                            DBAlteration.CreateTables();
                        }
                    }
                    #endregion Check Database Connection
                }
            }
            catch(Exception exc)
            {
                ShowMessage(utilConstants.cPTError, "Load", exc);
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            #region Clear
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            #endregion Clear
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (NoDatabase)
                LoginNoConnection();
            else
                Login();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (NoDatabase)
                    LoginNoConnection();
                else
                    Login();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (NoDatabase)
                    LoginNoConnection();
                else
                    Login();
            }
        }
        #endregion Control Methods

        #region Public Methods
        public void ShowMessage(int intPopUpType, string strMessage)
        {
            ShowMessage(intPopUpType, strMessage, "", null);
        }

        public void ShowMessage(int intPopUpType, string strMethod, Exception exc)
        {
            ShowMessage(intPopUpType, exc.Message, strMethod, exc);
        }

        public void ShowMessage(int intPopUpType, string strMessage, string strMethod, Exception exc)
        {
            #region Variables
            FormCollection fcOpen = null;
            frmPopUp frmPU = null;
            #endregion Variables

            #region Show Form
            fcOpen = Application.OpenForms;
            frmPU = (frmPopUp)fcOpen["frmPopUp"];
            if (frmPU == null)
                frmPU = new frmPopUp();

            frmPU.PopUpType = intPopUpType;
            frmPU.Message = strMessage;
            if (exc != null)
            {
                frmPU.ErrorForm = this.Name;
                frmPU.ErrorMethod = strMethod;
                frmPU.ErrorOccurred = exc;
                frmPU.ErrorSave = !NotConnected;
            }
            frmPU.ShowDialog();
            #endregion Show Form
        }
        #endregion Public Methods

        #region Private Methods
        private void Login()
        {
            #region Variables
            FormCollection fcOpen = null;
            Master frmMST = null;

            DBConnection dbCon = null;
            umUser dalUser = null;
            string strMessage = ValidateInput();
            #endregion Variables

            try
            {
                #region Login
                if (strMessage.Length == 0)
                {
                    dbCon = new DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalUser = new umUser();
                        strMessage = dalUser.LogIn(txtUserName.Text.Trim(), txtPassword.Text.Trim(), "EN", dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }

                    if (strMessage.Length == 0)
                    {

                        fcOpen = Application.OpenForms;
                        frmMST = (Master)fcOpen["Master"];
                        if (frmMST == null)
                            frmMST = new Master();

                        txtPassword.Text = string.Empty;
                        txtUserName.Text = string.Empty;

                        frmMST.LanguageId = dalUser.lng_id;
                        frmMST.UserId = dalUser.usr_id;
                        frmMST.Show();
                        this.Hide();

                        
                    }
                    else
                    {
                        ShowMessage(utilConstants.cPTWarning, strMessage);
                    }
                }
                else
                {
                    ShowMessage(utilConstants.cPTWarning, strMessage);
                }
                #endregion Login
            }
            catch (Exception exc)
            {
                
                ShowMessage(utilConstants.cPTError, "LogIn", exc);
            }
        }

        private void LoginNoConnection()
        {
            #region Variables
            FormCollection fcOpen = null;
            Master frmMST = null;
            #endregion Variables

            #region Login
            fcOpen = Application.OpenForms;
            frmMST = (Master)fcOpen["Master"];
            if (frmMST == null)
                frmMST = new Master();

            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;

            frmMST.NoDatabase = NoDatabase;
            frmMST.LanguageId = utilConstants.cDFLngId;
            frmMST.UserId = "";
            frmMST.Show();
            this.Hide();
            #endregion Login
        }

        private string ValidateInput()
        {
            #region Variables
            DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtUserName.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Get Messages
            if (strMessage.Length != 0)
            {
                strMessage = strMessage.Substring(1);
                dbCon = new DBConnection(utilConstants.cACKConnection);

                try
                {
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = "EN";
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            #endregion Get Messages

            return strMessage;
        }
        #endregion Private Methods
    }
}
