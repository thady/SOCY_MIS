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
    public partial class frmUser : UserControl
    {
        #region Variables
        private string strId = string.Empty;
        private frmAdmin frmPrt = null;
        private frmUserSearch frmCll = null;
        #endregion Variables

        #region Property
        public frmUserSearch FormCalling
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
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
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

        private void chkPasswordChange_CheckedChanged(object sender, EventArgs e)
        {
            SetPasswordDisplay(chkPasswordChange.Checked);
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblRole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                FormCollection fcOpen = null;
                frmUserRole frmUR = null;
                #endregion Variables

                #region Show Form
                fcOpen = Application.OpenForms;
                frmUR = (frmUserRole)fcOpen["frmUserRole"];
                if (frmUR == null)
                    frmUR = new frmUserRole();
                frmUR.FormMaster = FormParent.FormMaster;
                frmUR.ObjectId = ObjectId;
                frmUR.ShowDialog();
                #endregion Show Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblRole", exc);
            }
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
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtPhone.Text = string.Empty;
                    txtSkype.Text = string.Empty;
                    txtPosition.Text = string.Empty;
                    cbTitle.SelectedIndex = 0;
                }
                else
                {
                    LoadDisplay();
                }
                SetPasswordDisplay(false);
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

                umUser dalUsr = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length == 0)
                {
                    LoadLists();
                    chkPasswordChange.Checked = true;
                    SetPasswordDisplay(chkPasswordChange.Checked);
                    chkPasswordChange.Enabled = false;
                    llblRole.Visible = false;
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalUsr = new umUser(ObjectId, dbCon);

                        chkActive.Checked = Convert.ToBoolean(dalUsr.usr_active);
                        txtFirstName.Text = dalUsr.usr_first_name;
                        txtLastName.Text = dalUsr.usr_last_name;
                        txtEmail.Text = dalUsr.usr_email;
                        txtPhone.Text = dalUsr.usr_phone;
                        txtSkype.Text = dalUsr.usr_skype;
                        txtPosition.Text = dalUsr.usr_position;
                        SetPasswordDisplay(false);

                        LoadLists(dalUsr.hnr_id, dalUsr.lng_id, dbCon);
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
                LoadLists("", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strHnrId, string strLngID, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_honorific", true, strHnrId, false, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbTitle, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lt_language", true, strLngID, true, "", dbCon.dbCon);
                utilControls.ComboBoxFill(cbLanguage, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strHnrId.Length != 0)
                    cbTitle.SelectedValue = strHnrId;
                else
                    cbTitle.SelectedIndex = 0;
                if (strLngID.Length != 0)
                    cbLanguage.SelectedValue = strLngID;
                else
                    cbLanguage.SelectedIndex = 0;
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
                umUser dalUsr = null;
                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalUsr = new umUser();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalUsr.usr_id = ObjectId;
                            dalUsr.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalUsr.Load(ObjectId, dbCon);

                        dalUsr.usr_first_name = txtFirstName.Text.Trim();
                        dalUsr.usr_last_name = txtLastName.Text.Trim();
                        dalUsr.usr_email = txtEmail.Text.Trim();
                        dalUsr.usr_phone = txtPhone.Text.Trim();
                        dalUsr.usr_skype = txtSkype.Text.Trim();
                        dalUsr.usr_position = txtPosition.Text.Trim();
                        dalUsr.usr_active = Convert.ToInt32(chkActive.Checked);
                        dalUsr.hnr_id = cbTitle.SelectedValue.ToString();
                        dalUsr.lng_id = cbLanguage.SelectedValue.ToString();
                        dalUsr.usr_id_update = FormParent.FormMaster.UserId;
                        dalUsr.ofc_id = FormParent.FormMaster.OfficeId;

                        if (chkPasswordChange.Checked)
                            dalUsr.usr_password = txtPassword.Text.Trim();

                        dalUsr.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        llblRole.Visible = true;
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

        private void SetPasswordDisplay(bool blnChangePassword)
        {
            #region Set Display
            if (blnChangePassword)
            {
                txtPassword.Text = string.Empty;
                txtPasswordConfirm.Text = string.Empty;
            }
            else
            {
                txtPassword.Text = "12345678";
                txtPasswordConfirm.Text = "12345678";
            }

            lblPasswordVal.Visible = blnChangePassword;
            lblPasswordConfirmVal.Visible = blnChangePassword;
            txtPassword.Enabled = blnChangePassword;
            txtPasswordConfirm.Enabled = blnChangePassword;
            #endregion Set Display
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            umUser dalUsr = null;

            string[] arrMessage = null;
            string strEmail = string.Empty;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtEmail.Text.Trim().Length == 0 || txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else
                if (chkPasswordChange.Checked && (txtPassword.Text.Trim().Length == 0 || txtPasswordConfirm.Text.Trim().Length == 0))
                    strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Password Validation
            if (chkPasswordChange.Checked && !txtPassword.Text.Trim().Equals(txtPasswordConfirm.Text.Trim()))
                strMessage = strMessage + "," + utilConstants.cMIDPasswordConfirmMatch;
            #endregion Password Validation

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Email Check
                strEmail = txtEmail.Text.Trim();
                if (strEmail.Length != 0)
                {
                    if (!utilFormatting.IsValidEmail(strEmail))
                        strMessage = strMessage + "," + utilConstants.cMIDEmailFormatInvalid;
                    else
                    {
                        dalUsr = new umUser();
                        if (dalUsr.CheckEmailInUse(ObjectId, strEmail, dbCon))
                            strMessage = strMessage + "," + utilConstants.cMIDEmailAddressInUse;
                    }
                }
                #endregion Email Check

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

        private void tplButton01_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
