using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmHome : UserControl
    {
        #region Variables
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;

                string strMessage = string.Empty;
                #endregion Variables

                #region Get Messages
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormMaster.LanguageId;
                    strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDMessageServer, dbCon.dbCon);
                    lblMessageServer.Text = strMessage;

                    strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDMessageWelcome, dbCon.dbCon);
                    if (strMessage.Length != 0)
                        lblMessageWelcome.Text = strMessage;
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Get Messages
            }
        }
        #endregion Form Methods
    }
}
