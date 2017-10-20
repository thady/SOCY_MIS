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
    public partial class frmRole : UserControl
    {
        #region Variables
        private string strId = string.Empty;
        private frmAdmin frmPrt = null;
        private frmRoleSearch frmCll = null;
        #endregion Variables

        #region Property
        public frmRoleSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmAdmin FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmRole()
        {
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            if (!FormParent.FormMaster.NoDatabase)
                LoadDisplay();
            else
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    chkActive.Checked = true;
                    txtName.Text = string.Empty;
                    utilControls.CheckedListClear(clbPermission);
                }
                else
                {
                    LoadDisplay();
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;

                umRole dalRole = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length != 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalRole = new umRole(ObjectId, dbCon);

                        chkActive.Checked = Convert.ToBoolean(dalRole.rl_active);
                        txtName.Text = dalRole.rl_name;
                        LoadLists(dalRole.role_permission, dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                else
                    LoadLists();
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("".Split(utilConstants.cDFSplitChar), dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string[] strPrmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilListTable uLT = null;

                DataTable dt = null;
                #endregion Variables

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("um_permission", true, strPrmId, true, "", dbCon.dbCon);
                utilControls.CheckedListFill(clbPermission, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                utilControls.CheckedListCheck(clbPermission, strPrmId, "lt_id");
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                umRole dalRole = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        try
                        {
                            dbCon.TransactionBegin();
                            dalRole = new umRole();

                            if (ObjectId.Length == 0)
                            {
                                ObjectId = Guid.NewGuid().ToString();
                                dalRole.rl_id = ObjectId;
                            }
                            else
                                dalRole.Load(ObjectId, dbCon);

                            dalRole.rl_name = txtName.Text.Trim();
                            dalRole.rl_active = Convert.ToInt32(chkActive.Checked);
                            dalRole.usr_id_update = FormParent.FormMaster.UserId;
                            dalRole.role_permission = utilControls.CheckedListGetSelectedValues(clbPermission, "lt_id");
                            dalRole.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        intPopUpType = utilConstants.cPTInfo;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            umRole dalRole = null;

            string[] arrMessage = null;
            string strName = string.Empty;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtName.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Name Check
                strName = txtName.Text.Trim();
                if (strName.Length != 0)
                {
                    dalRole = new umRole();
                    if (dalRole.CheckNameInUse(ObjectId, strName, dbCon))
                        strMessage = strMessage + "," + utilConstants.cMIDRoleNameExists;
                }
                #endregion Name Check

                #region Get Messages
                if (strMessage.Length != 0)
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormParent.FormMaster.LanguageId;
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                #endregion Get Messages
            }
            finally
            {
                dbCon.Dispose();
            }

            return strMessage;
        }
        #endregion Private Methods
    }
}
