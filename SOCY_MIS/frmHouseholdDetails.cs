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
    public partial class frmHouseholdDetails : UserControl
    {
        #region Variables
        private bool pblnLoading = false;
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

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
        public frmHouseholdDetails()
        {
            InitializeComponent();
        }

        private void frmHouseholdDetails_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmHouseholdDetails_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbStatusReason.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbStatus.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                Save();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", "", "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
            }
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
            }
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                    LoadListsArea("", "", cbWard.SelectedValue.ToString());
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.LoadDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHousehold dalHH = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Household
                        dalHH = new hhHousehold();

                        dalHH.Load(ObjectId, dbCon);
                        txtHoueholdCode.Text = dalHH.hh_code;
                        txtPhone.Text = dalHH.hh_tel;
                        txtVillage.Text = dalHH.hh_village;
                        txtStatusReasonOther.Text = dalHH.hh_status_reason;
                        //btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHH.ofc_id) || utilConstants.cDFImportOffice.Equals(dalHH.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHH.ofc_id));
                        #endregion Household

                        LoadLists(dalHH.hhs_id, dalHH.hhsr_id, dalHH.swk_id, dalHH.wrd_id, dbCon);
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

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strHhsId, string strHhsrId, string strSwkId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                swmSocialWorker dalSwk = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_household_status", true, strHhsId, false, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.ComboBoxFill(cbStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_household_status_reason", true, strHhsrId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbStatusReason, dt, "lt_id", "lt_name");

                dalSwk = new swmSocialWorker();
                if (ObjectId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strHhsId.Length != 0)
                    cbStatus.SelectedValue = strHhsId;
                else
                    cbStatus.SelectedIndex = 0;
                if (strHhsrId.Length != 0)
                    cbStatusReason.SelectedValue = strHhsrId;
                else
                    cbStatusReason.SelectedIndex = 0;
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", "", strWrdId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strDstId, string strSctId, string strWrdId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strDstId, strSctId, strWrdId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbDistrict, cbSubCounty, cbWard, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHH = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Household
                        dalHH = new hhHousehold(ObjectId, dbCon);

                        dalHH.hh_code = txtHoueholdCode.Text.Trim();
                        dalHH.hh_status_reason = txtStatusReasonOther.Text.Trim();
                        dalHH.hh_tel = txtPhone.Text.Trim();                      
                        dalHH.hh_village = txtVillage.Text.Trim();

                        dalHH.hhs_id = cbStatus.SelectedValue.ToString();
                        dalHH.hhsr_id = cbStatusReason.SelectedValue.ToString();
                        dalHH.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalHH.wrd_id = cbWard.SelectedValue.ToString();
                        dalHH.usr_id_update = FormMaster.UserId;
                        dalHH.district_id = static_variables.district_id;
                        dalHH.Save(dbCon);
                        #endregion Household

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
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

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtHoueholdCode.Text.Trim().Length == 0 || txtVillage.Text.Trim().Length == 0 ||
                cbDistrict.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0 || cbWard.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Phone Number
            if (txtPhone.Text.Replace(" ", "").Trim().Length != 0 && txtPhone.Text.Replace(" ", "").Trim().Length != utilConstants.cDFPhoneNumberLength)
                strMessage = strMessage + "," + utilConstants.cMIDPhoneNumberLength;
            #endregion Phone Number

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormMaster.LanguageId;
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

        #region Permissions
        private void SetPermissions()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            umUser dalUsr = new umUser();
            #endregion Variables

            #region Set Permissions
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHouseholdDetails, dbCon);
                btnSave.Visible = pblnManage;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Set Permissions
        }
        #endregion Permissions

        private void gbTitle_Enter(object sender, EventArgs e)
        {

        }
    }
}
