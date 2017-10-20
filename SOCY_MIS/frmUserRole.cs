using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmUserRole : Form
    {
        #region Variables
        private string strId = string.Empty;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmUserRole()
        {
            InitializeComponent();
        }

        private void frmUserRole_Load(object sender, EventArgs e)
        {
            #region Version
            lblVersionNumber.Text = ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString();
            #endregion Version

            if (FormMaster != null && FormMaster.NoDatabase)
            {
                btnClose.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                LoadDisplay();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion Control Methods

        #region Private Methods
        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;

                umUser dalUsr = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length != 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalUsr = new umUser(ObjectId, dbCon);

                        lblUserName.Text = (dalUsr.usr_first_name + " " + dalUsr.usr_last_name).Trim();
                        LoadLists(dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }
        private void LoadLists(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                umRole dalRL = null;
                umUser dalUsr = null;

                DataTable dt01 = null;
                DataTable dt02 = null;
                #endregion Variables


                #region Load Lists
                dalRL = new umRole();
                dalUsr = new umUser();

                dt01 = dalRL.GetRoleList(dbCon);
                dt02 = dalUsr.GetUserRoles(ObjectId, dbCon);
                utilControls.CheckedListFill(clbRole, dt01, "rl_id", "rl_name");
                utilControls.CheckedListCheck(clbRole, dt02, "rl_id", "rl_id");
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                umUser dalUsr = null;

                int intPopUpType = utilConstants.cPTWarning;
                string[] arrRoleId = null;
                string strMessage = string.Empty;
                #endregion Variables

                #region Save
                if (ObjectId.Length != 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalUsr = new umUser(ObjectId, dbCon);
                        arrRoleId = utilControls.CheckedListGetSelectedValues(clbRole, "rl_id");
                        dalUsr.usr_id_update = FormMaster.UserId;
                        dalUsr.SaveRole(arrRoleId, dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTWarning;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }
        #endregion Private Methods
    }
}
