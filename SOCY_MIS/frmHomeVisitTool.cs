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
    public partial class frmHomeVisitTool : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private frmHomeVisitToolSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmHomeVisitToolSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHomeVisitTool()
        {
            InitializeComponent();
        }

        private void frmHomeVisitTool_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadHousehold(HouseholdId);
                LoadDisplay();
            }
        }

        private void frmHomeVisitTool_Paint(object sender, PaintEventArgs e)
        {
            cbGirlEducationLevel.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methdos
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ObjectId.Length == 0)
                Clear();
            else
                LoadDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Set Household
            if (!pblnLoading)
            {
                if (cbHHCode.SelectedIndex == 0)
                {
                    ClearHousehold();
                }
                else
                {
                    LoadHousehold(cbHHCode.SelectedValue.ToString());
                }
            }
            #endregion Set Household
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnGirlEducationSupportYes_CheckedChanged(object sender, EventArgs e)
        {
            #region Set If Yes
            nudGirlAge.Enabled = rbtnGirlEducationSupportYes.Checked;
            cbGirlEducationLevel.Enabled = rbtnGirlEducationSupportYes.Checked;
            txtGirlEducationType.Enabled = rbtnGirlEducationSupportYes.Checked;
            txtGirlName.Enabled = rbtnGirlEducationSupportYes.Checked;

            if (!rbtnGirlEducationSupportYes.Checked)
            {
                nudGirlAge.Value = 0;
                if(cbGirlEducationLevel.Items.Count != 0)
                    cbGirlEducationLevel.SelectedIndex = 0;
                txtGirlEducationType.Text = string.Empty;
                txtGirlName.Text = string.Empty;
            }
            #endregion Set If Yes
        }

        private void rbtnPreviousVisitYes_CheckedChanged(object sender, EventArgs e)
        {
            #region Set If Yes
            dtpPreviousVisitDate.Enabled = rbtnPreviousVisitYes.Checked;
            txtPreviousVisitPurpose.Enabled = rbtnPreviousVisitYes.Checked;
            txtPreviousVisitServices.Enabled = rbtnPreviousVisitYes.Checked;
            clbPreviousServices.Enabled = rbtnPreviousVisitYes.Checked;

            if (!rbtnPreviousVisitYes.Checked)
            {
                txtPreviousVisitPurpose.Text = string.Empty;
                txtPreviousVisitServices.Text = string.Empty;
                utilControls.CheckedListClear(clbPreviousServices);
            }
            #endregion Set If Yes
        }

        private void rbtnReferralYes_CheckedChanged(object sender, EventArgs e)
        {
            #region Set If Yes
            rbtnReferralCompletedNo.Enabled = rbtnReferralYes.Checked;
            rbtnReferralCompletedYes.Enabled = rbtnReferralYes.Checked;

            if (!rbtnReferralYes.Checked)
            {
                rbtnReferralCompletedNo.Checked = false;
                rbtnReferralCompletedYes.Checked = false;
            }
            #endregion Set If Yes
        }
        #endregion Control Methdods

        #region Private Methods
        private void Back()
        {
            if (FormCalling != null)
            {
                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormParent != null)
            {
                FormCallingSearch.BackDisplay();
                FormParent.LoadControl(FormCallingSearch, this.Name);
            }
        }

        private void Clear()
        {
            ClearHousehold();
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    txtActions.Text = string.Empty;
                    txtFindings.Text = string.Empty;
                    txtGirlEducationType.Text = string.Empty;
                    txtGirlName.Text = string.Empty;
                    txtNextSteps.Text = string.Empty;
                    txtPreviousVisitPurpose.Text = string.Empty;
                    txtPreviousVisitServices.Text = string.Empty;

                    rbtnConsumptionProgramNo.Checked = false;
                    rbtnConsumptionProgramYes.Checked = false;
                    rbtnGirlEducationSupportNo.Checked = false;
                    rbtnGirlEducationSupportYes.Checked = false;
                    rbtnImprovementPlanNo.Checked = false;
                    rbtnImprovementPlanYes.Checked = true;
                    rbtnPreviousVisitNo.Checked = false;
                    rbtnPreviousVisitYes.Checked = false;
                    rbtnReferralCompletedNo.Checked = false;
                    rbtnReferralCompletedYes.Checked = false;
                    rbtnReferralNo.Checked = false;
                    rbtnReferralYes.Checked = false;

                    if (cbGirlEducationLevel.Items.Count != 0)
                        cbGirlEducationLevel.SelectedIndex = 0;
                    utilControls.CheckedListClear(clbServices);
                    utilControls.CheckedListClear(clbPreviousServices);
                    #endregion Clear
                }
                else
                {
                    LoadDisplay();
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void ClearHousehold()
        {
            try
            {
                #region Clear
                if (HouseholdId.Length == 0)
                {
                    #region Clear
                    lblDistrictDisplay.Text = string.Empty;
                    lblSubCountyDisplay.Text = string.Empty;
                    lblVillageDisplay.Text = string.Empty;
                    lblWard.Text = string.Empty;
                    cbHHMember.SelectedIndex = -1;
                    cbHHMember.Enabled = false;
                    #endregion Clear
                }
                else
                {
                    LoadHousehold(HouseholdId);
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearHousehold", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHomeVisit dalHV = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        if (HouseholdId.Length == 0)
                            LoadLists("", "", "", "".Split(utilConstants.cDFSplitChar), "".Split(utilConstants.cDFSplitChar), dbCon);
                        else
                            LoadLists("", HouseholdId, "", "".Split(utilConstants.cDFSplitChar), "".Split(utilConstants.cDFSplitChar), dbCon);
                    }
                    else
                    {
                        #region Assessment
                        dalHV = new hhHomeVisit();

                        if (ObjectId.Length != 0)
                        {
                            dalHV.Load(ObjectId, dbCon);
                            txtActions.Text = dalHV.hv_actions;
                            dtpVisitDate.Value = dalHV.hv_date;
                            txtFindings.Text = dalHV.hv_findings;
                            nudGirlAge.Value = dalHV.hv_girl_age;
                            txtGirlEducationType.Text = dalHV.hv_girl_education_type;
                            txtGirlName.Text = dalHV.hv_girl_name;
                            txtNextSteps.Text = dalHV.hv_next_steps;
                            nudNumOfChildren.Value = dalHV.hv_number_of_children;
                            dtpPreviousVisitDate.Value = dalHV.hv_previous_visit_date;
                            txtPreviousVisitPurpose.Text = dalHV.hv_previous_visit_purpose;
                            txtPreviousVisitServices.Text = dalHV.hv_previous_visit_service;
                            utilControls.RadioButtonSetSelection(rbtnConsumptionProgramYes, rbtnConsumptionProgramNo, dalHV.yn_id_consumption_program);
                            utilControls.RadioButtonSetSelection(rbtnGirlEducationSupportYes, rbtnGirlEducationSupportNo, dalHV.yn_id_girl_education_support);
                            utilControls.RadioButtonSetSelection(rbtnImprovementPlanYes, rbtnImprovementPlanNo, dalHV.yn_id_improvement_plan);
                            utilControls.RadioButtonSetSelection(rbtnPreviousVisitYes, rbtnPreviousVisitNo, dalHV.yn_id_previous_visit);
                            utilControls.RadioButtonSetSelection(rbtnReferralYes, rbtnReferralNo, dalHV.yn_id_referral);
                            utilControls.RadioButtonSetSelection(rbtnReferralCompletedYes, rbtnReferralCompletedNo, dalHV.yn_id_referral_completed);
                            HouseholdId = dalHV.hh_id;
                            cbHHMember.SelectedValue = dalHV.hhm_id;
                            btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHV.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHV.ofc_id));
                        }
                        #endregion Assessment

                        LoadLists(dalHV.edu_id, dalHV.hh_id, dalHV.swk_id, dalHV.home_visit_service, dalHV.home_visit_service_previous, dbCon);
                    }
                    #endregion Load Data
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadHousehold(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHousehold(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }
        
        private void LoadHousehold(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHousehold dalHH = null;
            hhHouseholdMember dalHHM = null;
            utilLanguageTranslation utilLT = null;

            DataTable dt = null;
            string strEmptySingleSelect = string.Empty;
            #endregion Variables

            try
            {
                #region Household
                dalHH = new hhHousehold();
                if (strId.Length != 0)
                {
                    dt = dalHH.GetHousehold(strId, FormMaster.LanguageId, dbCon);
                    if (utilCollections.HasRows(dt))
                    {
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                        lblSubCountyDisplay.Text = dt.Rows[0]["sct_name"].ToString();
                        lblVillageDisplay.Text = dt.Rows[0]["hh_village"].ToString();
                        lblWardDisplay.Text = dt.Rows[0]["wrd_name"].ToString();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                        dalHHM = new hhHouseholdMember();
                        dt = dalHHM.GetList(strId, dbCon);
                        dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                        utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                        cbHHMember.SelectedValue = dalHHM.GetMemberCaregiver(strId, dbCon);
                        cbHHMember.Enabled = true;
                    }
                    else
                    {
                        ClearHousehold();
                    }
                }
                else
                {
                    ClearHousehold();
                }
                #endregion Household
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHousehold", exc);
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
                LoadLists("", "", "", "".Split(utilConstants.cDFSplitChar), "".Split(utilConstants.cDFSplitChar), dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strEduId, string strHhId, string strSwkid, string[] strShvId, string[] strShvpId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                hhHousehold dalHh = null;
                swmSocialWorker dalSwk = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                pblnLoading = true;
                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_education_level", true, strEduId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGirlEducationLevel, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_service_home_visit", true, strShvId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbServices, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_service_home_visit_previous", true, strShvId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbPreviousServices, dt, "lt_id", "lt_name");

                dalHh = new hhHousehold();
                if (HouseholdId.Length != 0)
                    dalHh.Load(strHhId, dbCon);

                dt = dalHh.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                
                dalSwk = new swmSocialWorker();
                if (dalHh.swk_id.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(dalHh.swk_id, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strEduId.Length != 0)
                    cbGirlEducationLevel.SelectedValue = strEduId;
                else
                    cbGirlEducationLevel.SelectedIndex = 0;
                if (HouseholdId.Length != 0)
                {
                    cbHHCode.SelectedValue = HouseholdId;
                    SetHouseholdControls(false);
                }
                else
                {
                    cbHHCode.SelectedIndex = 0;
                    SetHouseholdControls(true);
                }
                if (strSwkid.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkid;
                else if (dalHh.swk_id.Length != 0)
                    cbSocialWorker.SelectedValue = dalHh.swk_id;
                else
                    cbSocialWorker.SelectedIndex = 0;

                utilControls.CheckedListCheck(clbServices, strShvId, "lt_id");
                utilControls.CheckedListCheck(clbPreviousServices, strShvpId, "lt_id");
                #endregion Set List Selection
                pblnLoading = false;
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
                hhHomeVisit dalHV = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Home Visit
                        try
                        {
                            dbCon.TransactionBegin();
                            dalHV = new hhHomeVisit();

                            if (ObjectId.Length == 0)
                            {
                                ObjectId = Guid.NewGuid().ToString();
                                dalHV.hv_id = ObjectId;
                                dalHV.ofc_id = FormMaster.OfficeId;
                            }
                            else
                                dalHV.Load(ObjectId, dbCon);

                            dalHV.hh_id = cbHHCode.SelectedValue.ToString();
                            dalHV.hhm_id = cbHHMember.SelectedValue.ToString();

                            dalHV.hv_actions = txtActions.Text.Trim();
                            dalHV.hv_date = dtpVisitDate.Value;
                            dalHV.hv_findings = txtFindings.Text.Trim();
                            dalHV.hv_girl_age = Convert.ToInt32(nudGirlAge.Value);
                            dalHV.hv_girl_education_type = txtGirlEducationType.Text.Trim();
                            dalHV.hv_girl_name = txtGirlName.Text.Trim();
                            dalHV.hv_next_steps = txtNextSteps.Text.Trim();
                            dalHV.hv_number_of_children = Convert.ToInt32(nudNumOfChildren.Value);
                            dalHV.hv_previous_visit_date = dtpPreviousVisitDate.Value;
                            dalHV.hv_previous_visit_purpose = txtPreviousVisitPurpose.Text.Trim();
                            dalHV.hv_previous_visit_service = txtPreviousVisitServices.Text.Trim();
                            dalHV.edu_id = cbGirlEducationLevel.SelectedValue.ToString();
                            dalHV.swk_id = cbSocialWorker.SelectedValue.ToString();
                            dalHV.yn_id_consumption_program = utilControls.RadioButtonGetSelection(rbtnConsumptionProgramYes, rbtnConsumptionProgramNo);
                            dalHV.yn_id_girl_education_support = utilControls.RadioButtonGetSelection(rbtnGirlEducationSupportYes, rbtnGirlEducationSupportNo);
                            dalHV.yn_id_improvement_plan = utilControls.RadioButtonGetSelection(rbtnImprovementPlanYes, rbtnImprovementPlanNo);
                            dalHV.yn_id_previous_visit = utilControls.RadioButtonGetSelection(rbtnPreviousVisitYes, rbtnPreviousVisitNo);
                            dalHV.yn_id_referral = utilControls.RadioButtonGetSelection(rbtnReferralYes, rbtnReferralNo);
                            dalHV.yn_id_referral_completed = utilControls.RadioButtonGetSelection(rbtnReferralCompletedYes, rbtnReferralCompletedNo);
                            dalHV.usr_id_update = FormMaster.UserId;
                            dalHV.home_visit_service = utilControls.CheckedListGetSelectedValues(clbServices, "lt_id");
                            dalHV.home_visit_service_previous = utilControls.CheckedListGetSelectedValues(clbPreviousServices, "lt_id");
                            dalHV.district_id = static_variables.district_id;

                            dalHV.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }
                        #endregion Home Visit

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetHouseholdControls(false);
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

        private void SetHouseholdControls(bool blnEnabled)
        {
            #region Set Controls
            cbHHCode.Enabled = blnEnabled;
            #endregion Set Controls
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
            if (cbHHCode.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHomeVisits, dbCon);
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
    }
}
