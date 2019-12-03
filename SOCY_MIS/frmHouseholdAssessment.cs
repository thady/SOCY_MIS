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
    public partial class frmHouseholdAssessment : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdAssessmentMain frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHouseholdAssessmentMain FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
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
        public frmHouseholdAssessment()
        {
            InitializeComponent();
        }

        private void frmHouseholdAssessment_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadHHServicesReceived();
                LoadDisplay();
                LoadPartners();
            }
        }

        private void frmHouseholdAssessment_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbIncomeContributor.SelectionLength = 0;
            cbIncomeSource.SelectionLength = 0;
            cbHouseholdMember.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
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
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.Back();
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbDistrict.SelectedIndex = 0;
                    cbIncomeContributor.SelectedIndex = 0;
                    cbIncomeSource.SelectedIndex = 0;
                    cbHouseholdMember.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbWard.SelectedIndex = 0;

                    dtpDateOfInterview.Value = DateTime.Now;

                    cboDailyMeals.Text = string.Empty;

                    rbtnChildSeparationNo.Checked = false;
                    rbtnChildSeparationYes.Checked = false;
                    rbtnDisagreementNever.Checked = false;
                    rbtnDisagreementOften.Checked = false;
                    rbtnDisagreementSometimes.Checked = false;
                    rbtnExpensesFoodNo.Checked = false;
                    rbtnExpensesFoodNotAlways.Checked = false;
                    rbtnExpensesFoodYes.Checked = false;
                    rbtnExpensesHealthNo.Checked = false;
                    rbtnExpensesHealthNotAlways.Checked = false;
                    rbtnExpensesHealthYes.Checked = false;
                    rbtnExpensesSchoolNo.Checked = false;
                    rbtnExpensesSchoolNotAlways.Checked = false;
                    rbtnExpensesSchoolYes.Checked = false;
                    rbtnFinancialSavingsNo.Checked = false;
                    rbtnFinancialSavingsYes.Checked = false;
                    rbtnFoodBodyBuildingNo.Checked = false;
                    rbtnFoodBodyBuildingYes.Checked = false;
                    rbtnFoodEnergyNo.Checked = false;
                    rbtnFoodEnergyYes.Checked = false;
                    rbtnFoodProtectiveNo.Checked = false;
                    rbtnFoodProtectiveYes.Checked = false;
                    rbtnLatrineAccessNo.Checked = false;
                    rbtnLatrineAccessOwned.Checked = false;
                    rbtnLatrineAccessShared.Checked = false;
                    rbtnAssetsMost.Checked = false;
                    rbtnAssetsNone.Checked = false;
                    rbtnAssetsSome.Checked = false;
                    rbtnWaterAccessNo.Checked = false;
                    rbtnWaterAccessYes.Checked = false;

                    txtComments.Text = "";
                    txtHoueholdCode.Text = "";
                    txtVillage.Text = "";
                    txtMemberCount.Clear();

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

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHousehold dalHH = null;
                hhHouseholdMember dalHHM = null;
                hhHouseholdAssessment dalHHA = null;

                DataTable dt = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Household
                    dalHH = new hhHousehold();
                    if (HouseholdId.Length != 0)
                    {
                        dalHH.Load(HouseholdId, dbCon);
                        txtHoueholdCode.Text = dalHH.hh_code;
                        txtVillage.Text = dalHH.hh_village;
                        SetHouseholdControls(false);

                        dalHHM = new hhHouseholdMember();
                        dt = dalHHM.GetList(HouseholdId, dbCon);
                        utilControls.ComboBoxFill(cbHouseholdMember, dt, "hhm_id", "hhm_name");
                        cbHouseholdMember.SelectedValue = dalHHM.GetMemberPrime(HouseholdId, dbCon);
                    }
                    else
                    {
                        SetHouseholdControls(true);
                    }
                    #endregion Household

                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        LoadLists("", "", dalHH.swk_id, dalHH.wrd_id, dbCon);
                    }
                    else
                    {
                        #region Assessment
                        dalHHA = new hhHouseholdAssessment();

                        if (ObjectId.Length != 0)
                        {
                            dalHHA.Load(ObjectId, dbCon);
                            txtComments.Text = dalHHA.hha_comments;
                            dtpDateOfInterview.Value = dalHHA.hha_date;
                            cbHouseholdMember.SelectedValue = dalHHA.hhm_id;
                            cboDailyMeals.Text = dalHHA.hha_num_of_meals.ToString();

                            utilControls.RadioButtonSetSelection(rbtnDisagreementOften, rbtnDisagreementNever, rbtnDisagreementSometimes, dalHHA.osn_id_disagreement);
                            utilControls.RadioButtonSetSelection(rbtnChildSeparationYes, rbtnChildSeparationNo, dalHHA.yn_id_child_separation);
                            utilControls.RadioButtonSetSelection(rbtnFinancialSavingsYes, rbtnFinancialSavingsNo, dalHHA.yn_id_financial_savings);
                            utilControls.RadioButtonSetSelection(rbtnFoodBodyBuildingYes, rbtnFoodBodyBuildingNo, dalHHA.yn_id_food_body_building);
                            utilControls.RadioButtonSetSelection(rbtnFoodEnergyYes, rbtnFoodEnergyNo, dalHHA.yn_id_food_energy);
                            utilControls.RadioButtonSetSelection(rbtnFoodProtectiveYes, rbtnFoodProtectiveNo, dalHHA.yn_id_food_protective);
                            utilControls.RadioButtonSetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo, dalHHA.yn_id_water);
                            utilControls.RadioButtonSetSelection(rbtnExpensesFoodYes, rbtnExpensesFoodNo, rbtnExpensesFoodNotAlways, dalHHA.ynna_id_expenses_food);
                            utilControls.RadioButtonSetSelection(rbtnExpensesHealthYes, rbtnExpensesHealthNo, rbtnExpensesHealthNotAlways, dalHHA.ynna_id_expenses_health);
                            utilControls.RadioButtonSetSelection(rbtnExpensesSchoolYes, rbtnExpensesSchoolNo, rbtnExpensesSchoolNotAlways, dalHHA.ynna_id_expenses_school);
                            utilControls.RadioButtonSetSelection(rbtnAssetsMost, rbtnAssetsNone, rbtnAssetsSome, dalHHA.ynns_id_assets);
                            utilControls.RadioButtonSetSelection(rbtnLatrineAccessOwned, rbtnLatrineAccessNo, rbtnLatrineAccessShared, dalHHA.yns_id_latrine);

                            txtSocialWorkerPhone.Text = dalHHA.swk_phone;
                            txtCaregiverPhone.Text = dalHHA.caregiver_phone;
                            txtHHMMale_above_18yrs.Text = dalHHA._18_years_male;
                            txtHHMFemale_above_18yrs.Text = dalHHA._18_years_female;
                            txtHHMMale_below_18yrs.Text = dalHHA.below_18_male;
                            txtHHMFemale_below_18yrs.Text = dalHHA.below_18_female;
                            txtTotalHHMale.Text = dalHHA.total_hhm_male;
                            cboHHfoodSource.Text = dalHHA.hh_food_source;
                            cboChildNotSchool.Text = dalHHA.total_hh_children_not_go_to_school;
                            cboactionChildAbuse.Text = dalHHA.hh_child_abuse_action;
                            txtTotalHHFemale.Text = dalHHA.total_hhm_female;
                            cboPositiveChildOnTreatment.Text = dalHHA.yn_eligible_child_on_treatment;
                            cbohhWithoutFood.Text = dalHHA.hhm_go_hungry_past_month;
                            cboShelter.Text = dalHHA.hh_stable_shelter;
                            txtMemberCount.Text = dalHHA.member_count;
                            SystemConstants.HATMemberCount = dalHHA.member_count;
                            utilControls.RadioButtonSetSelection(rdnChildHeadedHHYes, rdnChildHeadedHHNo, dalHHA.yn_child_headed);
                            utilControls.RadioButtonSetSelection(rdnHHHDisabledYes, rdnHHHDisabledNo, dalHHA.yn_hh_disabled);
                            utilControls.RadioButtonSetSelection(rdnHHMSickYes, rdnHHMSickNo, dalHHA.yn_hhm_sick);
                            utilControls.RadioButtonSetSelection(rdnFormalEmploymentYes, rdnFormalEmploymentNo, dalHHA.yn_hhm_employed);
                            utilControls.RadioButtonSetSelection(rdnHHPayExpenseYes, rdnHHPayExpenseNo, dalHHA.yn_pay_unexpected_expense);
                            utilControls.RadioButtonSetSelection(rdnTransportYes, rdnTransportNo, dalHHA.yn_function_tp_means);
                            utilControls.RadioButtonSetSelection(rdnHHMVocationalYes, rdnHHMVocationalNo, dalHHA.yn_hhm_vocational_skills);
                            utilControls.RadioButtonSetSelection(rdnDomesticAnimalsYes, rdnDomesticAnimalsNo, dalHHA.yn_domestic_animals);
                            utilControls.RadioButtonSetSelection(rdnHHLandYes, rdnHHLandNo, dalHHA.yn_hh_access_to_land);
                            utilControls.RadioButtonSetSelection(rdnKnowHIVStatusYes, rdnKnowHIVStatusNo, dalHHA.yn_caregiver_knows_hiv_status);
                            utilControls.RadioButtonSetSelection(rdnChildTestedYes, rdnChildTestedNo, dalHHA.yn_children_tested);
                            utilControls.RadioButtonSetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo, dalHHA.yn_hh_access_water);
                            utilControls.RadioButtonSetSelection(rdnMNetYes, rdnMNetNo, dalHHA.yn_hhm_mosquito_net);
                            utilControls.RadioButtonSetSelection(rdnPublicFacilityYes, rdnPublicFacilityNo, dalHHA.yn_hh_access_public_health_facility);
                            utilControls.RadioButtonSetSelection(rdnCleanCompoundYes, rdnCleanCompoundNo, dalHHA.yn_ob_clean_compound);
                            utilControls.RadioButtonSetSelection(rdnDryRackYes, rdnDryRackNo, dalHHA.yn_ob_drying_rack);
                            utilControls.RadioButtonSetSelection(rdngarbagePitYes, rdngarbagePitNo, dalHHA.yn_ob_garbage_pit);
                            utilControls.RadioButtonSetSelection(rndAnimalHouseYes, rndAnimalHouseNo, dalHHA.yn_ob_animal_house);
                            utilControls.RadioButtonSetSelection(rdnChildInSchoolYes, rdnChildInSchoolNo, rdnChildInSchoolNA, dalHHA.ynna_children_go_to_school);
                            utilControls.RadioButtonSetSelection(rdnSadYes, rdnSadNo, dalHHA.yn_children_sad_unhappy);
                            utilControls.RadioButtonSetSelection(rdnPgysicalAbuseYes, rdnPgysicalAbuseNo, dalHHA.yn_cp_repeated_abuse);
                            utilControls.RadioButtonSetSelection(rdnChildlaborYes, rdnChildlaborNo, dalHHA.yn_cp_child_labour);
                            utilControls.RadioButtonSetSelection(rdnSexuallyAbusedYes, rdnSexuallyAbusedNo, dalHHA.yn_cp_sexually_abused);
                            utilControls.RadioButtonSetSelection(rdnStigmatisedYes, rdnStigmatisedNo, dalHHA.yn_cp_stigmatised);

                            utilControls.RadioButtonSetSelection(rdnCoflictLawYes, rdnCoflictLawNo, dalHHA.yn_cp_conflict_with_law);
                            utilControls.RadioButtonSetSelection(rdnWithheldMealYes, rdnWithheldMealNo, dalHHA.yn_cp_withheld_meal);
                            utilControls.RadioButtonSetSelection(rdnAbusiveLanguageYes, rdnAbusiveLanguageNo, dalHHA.yn_cp_abusive_language);

                            #region Household based services
                            if (dalHHA.hhs_id_visit_from_volunteer != "-1" && dalHHA.hhs_id_visit_from_volunteer != string.Empty) { chklistHHServicesReceived.SetItemCheckState(0, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(0, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_financial_support != "-1" && dalHHA.hhs_id_visit_from_volunteer != string.Empty) { chklistHHServicesReceived.SetItemCheckState(1, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(1, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_parenting_counsiling != "-1" && dalHHA.hhs_id_parenting_counsiling != string.Empty) { chklistHHServicesReceived.SetItemCheckState(2, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(2, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_early_child_dev != "-1" && dalHHA.hhs_id_early_child_dev != string.Empty) { chklistHHServicesReceived.SetItemCheckState(3, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(3, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_health_hygiene != "-1" && dalHHA.hhs_id_health_hygiene != string.Empty) { chklistHHServicesReceived.SetItemCheckState(4, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(4, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_hiv_gbv_prevention != "-1" && dalHHA.hhs_id_hiv_gbv_prevention != string.Empty) { chklistHHServicesReceived.SetItemCheckState(5, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(5, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_nutrition_counsiling != "-1" && dalHHA.hhs_id_nutrition_counsiling != string.Empty) { chklistHHServicesReceived.SetItemCheckState(6, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(6, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_pre_post_partum != "-1" && dalHHA.hhs_id_pre_post_partum != string.Empty) { chklistHHServicesReceived.SetItemCheckState(7, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(7, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_hiv_testing != "-1" && dalHHA.hhs_id_hiv_testing != string.Empty) { chklistHHServicesReceived.SetItemCheckState(8, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(8, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_couples_counsiling != "-1" && dalHHA.hhs_id_hiv_testing != string.Empty) { chklistHHServicesReceived.SetItemCheckState(9, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(9, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_birth_certificate != "-1" && dalHHA.hhs_id_birth_certificate != string.Empty) { chklistHHServicesReceived.SetItemCheckState(10, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(10, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_child_protection != "-1" && dalHHA.hhs_id_child_protection != string.Empty) { chklistHHServicesReceived.SetItemCheckState(11, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(11, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_psychosocial != "-1" && dalHHA.hhs_id_psychosocial != string.Empty) { chklistHHServicesReceived.SetItemCheckState(12, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(12, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_food_security != "-1" && dalHHA.hhs_id_food_security != string.Empty) { chklistHHServicesReceived.SetItemCheckState(13, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(13, CheckState.Unchecked); }
                            if (dalHHA.hhs_id_none != "-1" && dalHHA.hhs_id_none != string.Empty) { chklistHHServicesReceived.SetItemCheckState(14, CheckState.Checked); } else { chklistHHServicesReceived.SetItemCheckState(14, CheckState.Unchecked); }
                            #endregion

                            #region Community based services
                            if (dalHHA.hhcs_id_savings_groups != "-1" && dalHHA.hhcs_id_savings_groups != string.Empty) { chklistCommunityServices.SetItemCheckState(0, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(0, CheckState.Unchecked); }
                            if(dalHHA.hhcs_id_parenting_program != "-1" && dalHHA.hhcs_id_parenting_program != string.Empty) { chklistCommunityServices.SetItemCheckState(1, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(1, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_govt_sage_program != "-1" && dalHHA.hhcs_id_govt_sage_program != string.Empty) { chklistCommunityServices.SetItemCheckState(2, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(2, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_other_cash_transfer != "-1" && dalHHA.hhcs_id_other_cash_transfer != string.Empty) { chklistCommunityServices.SetItemCheckState(3, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(3, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_voluntary_hiv_testing != "-1" && dalHHA.hhcs_id_voluntary_hiv_testing != string.Empty) { chklistCommunityServices.SetItemCheckState(4, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(4, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_food_security_nutrition != "-1" && dalHHA.hhcs_id_food_security_nutrition != string.Empty) { chklistCommunityServices.SetItemCheckState(5, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(5, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_skills_employ_training != "-1" && dalHHA.hhcs_id_skills_employ_training != string.Empty) { chklistCommunityServices.SetItemCheckState(6, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(6, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_entrepreneurship_training != "-1" && dalHHA.hhcs_id_entrepreneurship_training != string.Empty) { chklistCommunityServices.SetItemCheckState(7, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(7, CheckState.Unchecked); }
                            if (dalHHA.hhcs_id_none != "-1" && dalHHA.hhcs_id_none != string.Empty) { chklistCommunityServices.SetItemCheckState(8, CheckState.Checked); } else { chklistCommunityServices.SetItemCheckState(8, CheckState.Unchecked); }
                            #endregion

                           // btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHHA.ofc_id) || utilConstants.cDFImportOffice.Equals(dalHHA.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHHA.ofc_id));
                        }
                        #endregion Assessment

                        LoadLists(dalHHA.icc_id, dalHHA.ics_id, dalHH.swk_id, dalHH.wrd_id, dbCon);
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

        private void LoadLists(string strIccId, string strIcsId, string strSwkId, string strWrdId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_income_contributor", true, strIccId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbIncomeContributor, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_income_source", true, strIcsId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbIncomeSource, dt, "lt_id", "lt_name");

                dalSwk = new swmSocialWorker();
                if (ObjectId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strIccId.Length != 0)
                    cbIncomeContributor.SelectedValue = strIccId;
                else
                    cbIncomeContributor.SelectedIndex = 0;
                if (strIcsId.Length != 0)
                    cbIncomeSource.SelectedValue = strIcsId;
                else
                    cbIncomeSource.SelectedIndex = 0;
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
                hhHouseholdAssessment dalHHA = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        #region Household
                        if (HouseholdId.Length == 0)
                        {
                            dalHH = new hhHousehold();
                            HouseholdId = Guid.NewGuid().ToString();
                            dalHH.hh_id = HouseholdId;

                            dalHH.hh_code = txtHoueholdCode.Text.Trim();
                            dalHH.hh_village = txtVillage.Text.Trim();
                            dalHH.hhs_id = utilConstants.cDFActive.ToString();
                            dalHH.swk_id = cbSocialWorker.SelectedValue.ToString();
                            
                            dalHH.wrd_id = cbWard.SelectedValue.ToString();
                            dalHH.usr_id_update = FormMaster.UserId;
                            dalHH.ofc_id = FormMaster.OfficeId;
                            dalHH.Save(dbCon);
                        }
                        #endregion Household

                        #region Household Assessment
                        dalHHA = new hhHouseholdAssessment();

                        if (ObjectId.Length == 0)
                        {
                            if (FormCalling.ObjectId.Length != 0)
                                ObjectId = FormCalling.ObjectId;
                            else
                                ObjectId = Guid.NewGuid().ToString();
                            dalHHA.hha_id = ObjectId;
                            dalHHA.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHHA.Load(ObjectId, dbCon);

                        dalHHA.hha_comments = txtComments.Text.Trim();
                        dalHHA.hha_date = dtpDateOfInterview.Value;
                        dalHHA.hha_num_of_meals = cboDailyMeals.Text;
                        dalHHA.hh_id = HouseholdId;
                        dalHHA.hhm_id = cbHouseholdMember.SelectedValue.ToString();
                        dalHHA.icc_id = cbIncomeContributor.SelectedValue.ToString();
                        dalHHA.ics_id = cbIncomeSource.SelectedValue.ToString();
                        dalHHA.osn_id_disagreement = utilControls.RadioButtonGetSelection(rbtnDisagreementOften, rbtnDisagreementNever, rbtnDisagreementSometimes);
                        dalHHA.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalHHA.yn_id_child_separation = utilControls.RadioButtonGetSelection(rbtnChildSeparationYes, rbtnChildSeparationNo);
                        dalHHA.yn_id_financial_savings = utilControls.RadioButtonGetSelection(rbtnFinancialSavingsYes, rbtnFinancialSavingsNo);
                        dalHHA.yn_id_food_body_building = utilControls.RadioButtonGetSelection(rbtnFoodBodyBuildingYes, rbtnFoodBodyBuildingNo);
                        dalHHA.yn_id_food_energy = utilControls.RadioButtonGetSelection(rbtnFoodEnergyYes, rbtnFoodEnergyNo);
                        dalHHA.yn_id_food_protective = utilControls.RadioButtonGetSelection(rbtnFoodProtectiveYes, rbtnFoodProtectiveNo);
                        dalHHA.yn_id_water = utilControls.RadioButtonGetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo);
                        dalHHA.ynna_id_expenses_food = utilControls.RadioButtonGetSelection(rbtnExpensesFoodYes, rbtnExpensesFoodNo, rbtnExpensesFoodNotAlways);
                        dalHHA.ynna_id_expenses_health = utilControls.RadioButtonGetSelection(rbtnExpensesHealthYes, rbtnExpensesHealthNo, rbtnExpensesHealthNotAlways);
                        dalHHA.ynna_id_expenses_school = utilControls.RadioButtonGetSelection(rbtnExpensesSchoolYes, rbtnExpensesSchoolNo, rbtnExpensesSchoolNotAlways);
                        dalHHA.ynns_id_assets = utilControls.RadioButtonGetSelection(rbtnAssetsMost, rbtnAssetsNone, rbtnAssetsSome);
                        dalHHA.yns_id_latrine = utilControls.RadioButtonGetSelection(rbtnLatrineAccessOwned, rbtnLatrineAccessNo, rbtnLatrineAccessShared);
                        dalHHA.usr_id_update = FormMaster.UserId;
                        dalHHA.district_id = static_variables.district_id;

                        //new HAT Variables
                        dalHHA.member_count = txtMemberCount.Text;
                        SystemConstants.HATMemberCount = txtMemberCount.Text;
                        dalHHA.swk_phone = txtSocialWorkerPhone.Text;
                        dalHHA.caregiver_phone = txtCaregiverPhone.Text;
                        dalHHA._18_years_male = txtHHMMale_above_18yrs.Text;
                        dalHHA._18_years_female = txtHHMFemale_above_18yrs.Text;
                        dalHHA.below_18_male = txtHHMMale_below_18yrs.Text;
                        dalHHA.below_18_female = txtHHMFemale_below_18yrs.Text;
                        dalHHA.total_hhm_male = txtTotalHHMale.Text;
                        dalHHA.total_hhm_female = txtTotalHHFemale.Text;
                        dalHHA.yn_child_headed = utilControls.RadioButtonGetSelection(rdnChildHeadedHHYes, rdnChildHeadedHHNo);
                        dalHHA.yn_hh_disabled = utilControls.RadioButtonGetSelection(rdnHHHDisabledYes, rdnHHHDisabledNo);
                        dalHHA.yn_hhm_sick = utilControls.RadioButtonGetSelection(rdnHHMSickYes, rdnHHMSickNo);
                        dalHHA.yn_hhm_employed = utilControls.RadioButtonGetSelection(rdnFormalEmploymentYes, rdnFormalEmploymentNo);
                        dalHHA.yn_pay_unexpected_expense = utilControls.RadioButtonGetSelection(rdnHHPayExpenseYes, rdnHHPayExpenseNo);
                        dalHHA.yn_function_tp_means = utilControls.RadioButtonGetSelection(rdnTransportYes, rdnTransportNo);
                        dalHHA.yn_hhm_vocational_skills = utilControls.RadioButtonGetSelection(rdnHHMVocationalYes, rdnHHMVocationalNo);
                        dalHHA.yn_domestic_animals = utilControls.RadioButtonGetSelection(rdnDomesticAnimalsYes, rdnDomesticAnimalsNo);
                        dalHHA.yn_hh_access_to_land = utilControls.RadioButtonGetSelection(rdnHHLandYes, rdnHHLandNo);
                        dalHHA.hh_food_source = cboHHfoodSource.Text;
                        dalHHA.yn_caregiver_knows_hiv_status = utilControls.RadioButtonGetSelection(rdnKnowHIVStatusYes, rdnKnowHIVStatusNo);
                        dalHHA.yn_children_tested = utilControls.RadioButtonGetSelection(rdnChildTestedYes, rdnChildTestedNo);
                        dalHHA.yn_eligible_child_on_treatment = cboPositiveChildOnTreatment.Text;
                        dalHHA.yn_hh_access_water = utilControls.RadioButtonGetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo);
                        dalHHA.yn_hhm_mosquito_net = utilControls.RadioButtonGetSelection(rdnMNetYes, rdnMNetNo);
                        dalHHA.yn_hh_access_public_health_facility = utilControls.RadioButtonGetSelection(rdnPublicFacilityYes, rdnPublicFacilityNo);
                        dalHHA.yn_ob_clean_compound = utilControls.RadioButtonGetSelection(rdnCleanCompoundYes, rdnCleanCompoundNo);
                        dalHHA.yn_ob_drying_rack = utilControls.RadioButtonGetSelection(rdnDryRackYes, rdnDryRackNo);
                        dalHHA.yn_ob_garbage_pit = utilControls.RadioButtonGetSelection(rdngarbagePitYes, rdngarbagePitNo);
                        dalHHA.yn_ob_animal_house = utilControls.RadioButtonGetSelection(rndAnimalHouseYes, rndAnimalHouseNo);
                        dalHHA.yn_ob_washing_facility = utilControls.RadioButtonGetSelection(rdnWashYes, rdnWashNo);
                        dalHHA.hh_stable_shelter = cboShelter.Text;
                        dalHHA.ynna_children_go_to_school = utilControls.RadioButtonGetSelection(rdnChildInSchoolYes, rdnChildInSchoolNo, rdnChildInSchoolNA);
                        dalHHA.total_hh_children_not_go_to_school = cboChildNotSchool.Text;
                        dalHHA.yn_children_sad_unhappy = utilControls.RadioButtonGetSelection(rdnSadYes, rdnSadNo);
                        dalHHA.yn_cp_repeated_abuse = utilControls.RadioButtonGetSelection(rdnPgysicalAbuseYes, rdnPgysicalAbuseNo);
                        dalHHA.yn_cp_child_labour = utilControls.RadioButtonGetSelection(rdnChildlaborYes, rdnChildlaborNo);
                        dalHHA.yn_cp_sexually_abused = utilControls.RadioButtonGetSelection(rdnSexuallyAbusedYes, rdnSexuallyAbusedNo);
                        dalHHA.yn_cp_stigmatised = utilControls.RadioButtonGetSelection(rdnStigmatisedYes, rdnStigmatisedNo);

                        dalHHA.yn_cp_conflict_with_law = utilControls.RadioButtonGetSelection(rdnCoflictLawYes, rdnCoflictLawNo);
                        dalHHA.yn_cp_withheld_meal = utilControls.RadioButtonGetSelection(rdnWithheldMealYes, rdnWithheldMealNo);
                        dalHHA.yn_cp_abusive_language = utilControls.RadioButtonGetSelection(rdnAbusiveLanguageYes, rdnAbusiveLanguageNo);

                        dalHHA.hhm_go_hungry_past_month = cbohhWithoutFood.Text;
                        #region Household based Services

                        if (chklistHHServicesReceived.GetItemCheckState(0) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[0]).Row;
                            //dalHHA.hhs_id_visit_from_volunteer = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();
                            dalHHA.hhs_id_visit_from_volunteer = "1";
                        }
                        else
                            dalHHA.hhs_id_visit_from_volunteer = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(1) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[1]).Row;
                            //dalHHA.hhs_id_financial_support = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();
                            dalHHA.hhs_id_financial_support = "2";
                        }
                        else
                            dalHHA.hhs_id_financial_support = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(2) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[2]).Row;
                            //dalHHA.hhs_id_parenting_counsiling = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();
                            dalHHA.hhs_id_parenting_counsiling = "3";
                        }
                        else
                            dalHHA.hhs_id_parenting_counsiling = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(3) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[3]).Row;
                            //dalHHA.hhs_id_early_child_dev = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();
                            dalHHA.hhs_id_early_child_dev = "4";
                        }
                        else
                            dalHHA.hhs_id_early_child_dev = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(4) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[4]).Row;
                            //dalHHA.hhs_id_health_hygiene = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_health_hygiene = "5";
                        }
                        else
                            dalHHA.hhs_id_health_hygiene = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(5) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[5]).Row;
                            //dalHHA.hhs_id_hiv_gbv_prevention = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_hiv_gbv_prevention = "6";
                        }
                        else
                            dalHHA.hhs_id_hiv_gbv_prevention = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(6) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[6]).Row;
                            //dalHHA.hhs_id_nutrition_counsiling = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_nutrition_counsiling = "7";
                        }
                        else
                            dalHHA.hhs_id_nutrition_counsiling = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(7) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[7]).Row;
                            //dalHHA.hhs_id_pre_post_partum = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_pre_post_partum = "8";
                        }
                        else
                            dalHHA.hhs_id_pre_post_partum = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(8) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[8]).Row;
                            //dalHHA.hhs_id_hiv_testing = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_hiv_testing = "9";
                        }
                        else
                            dalHHA.hhs_id_hiv_testing = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(9) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[9]).Row;
                            //dalHHA.hhs_id_couples_counsiling = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_couples_counsiling = "10";
                        }
                        else
                            dalHHA.hhs_id_couples_counsiling = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(10) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[10]).Row;
                            //dalHHA.hhs_id_birth_certificate = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_birth_certificate = "11";
                        }
                        else
                            dalHHA.hhs_id_birth_certificate = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(11) == CheckState.Checked)
                        {
                            //DataRow dtRow = ((DataRowView)this.chklistHHServicesReceived.CheckedItems[11]).Row;
                            //dalHHA.hhs_id_child_protection = (dtRow[this.chklistHHServicesReceived.ValueMember]).ToString();

                            dalHHA.hhs_id_child_protection = "12";
                        }
                        else
                            dalHHA.hhs_id_child_protection = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(12) == CheckState.Checked)
                        {

                            dalHHA.hhs_id_psychosocial = "13";
                        }
                        else
                            dalHHA.hhs_id_psychosocial = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(13) == CheckState.Checked)
                        {

                            dalHHA.hhs_id_food_security = "14";
                        }
                        else
                            dalHHA.hhs_id_food_security = "-1";

                        if (chklistHHServicesReceived.GetItemCheckState(14) == CheckState.Checked)
                        {
                            dalHHA.hhs_id_none = "15";
                        }
                        else
                            dalHHA.hhs_id_none = "-1";
                        #endregion Household based Services

                        #region Community based services
                        if (chklistCommunityServices.GetItemCheckState(0) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[0]).Row;
                            //dalHHA.hhcs_id_savings_groups = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                            dalHHA.hhcs_id_savings_groups = "16";
                        }
                        else
                            dalHHA.hhcs_id_savings_groups = "-1";

                        if (chklistCommunityServices.GetItemCheckState(1) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[1]).Row;
                            //dalHHA.hhcs_id_parenting_program = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                            dalHHA.hhcs_id_parenting_program = "17";
                        }
                        else
                            dalHHA.hhcs_id_parenting_program = "-1";

                        if (chklistCommunityServices.GetItemCheckState(2) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[2]).Row;
                            //dalHHA.hhcs_id_govt_sage_program = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                            dalHHA.hhcs_id_govt_sage_program = "18";
                        }
                        else
                            dalHHA.hhcs_id_govt_sage_program = "-1";

                        if (chklistCommunityServices.GetItemCheckState(3) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[3]).Row;
                            //dalHHA.hhcs_id_other_cash_transfer = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                            dalHHA.hhcs_id_other_cash_transfer = "19";
                        }
                        else
                            dalHHA.hhcs_id_other_cash_transfer = "-1";


                        if (chklistCommunityServices.GetItemCheckState(4) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[4]).Row;
                            //dalHHA.hhcs_id_voluntary_hiv_testing = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                            dalHHA.hhcs_id_voluntary_hiv_testing = "20";
                        }
                        else
                            dalHHA.hhcs_id_voluntary_hiv_testing = "-1";

                        if (chklistCommunityServices.GetItemCheckState(5) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[5]).Row;
                            //dalHHA.hhcs_id_food_security_nutrition = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();

                            dalHHA.hhcs_id_food_security_nutrition = "21";
                        }
                        else
                            dalHHA.hhcs_id_food_security_nutrition = "-1";

                        if (chklistCommunityServices.GetItemCheckState(6) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[6]).Row;
                            //dalHHA.hhcs_id_skills_employ_training = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();

                            dalHHA.hhcs_id_skills_employ_training = "22";
                        }
                        else
                            dalHHA.hhcs_id_skills_employ_training = "-1";

                        if (chklistCommunityServices.GetItemCheckState(7) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[7]).Row;
                            //dalHHA.hhcs_id_entrepreneurship_training = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();

                            dalHHA.hhcs_id_entrepreneurship_training = "23";
                        }
                        else
                            dalHHA.hhcs_id_entrepreneurship_training = "-1";


                        //if (chklistCommunityServices.GetItemCheckState(8) == CheckState.Checked)
                        //{
                        //    dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[8]).Row;
                        //    dalHHA.hhcs_id_other = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();
                        //}
                        //else
                        //    dalHHA.hhcs_id_other = "-1";

                        if (chklistCommunityServices.GetItemCheckState(8) == CheckState.Checked)
                        {
                            //dtRow = ((DataRowView)this.chklistCommunityServices.CheckedItems[8]).Row;
                            //dalHHA.hhcs_id_none = (dtRow[this.chklistCommunityServices.ValueMember]).ToString();

                            dalHHA.hhcs_id_none = "24";
                        }
                        else
                            dalHHA.hhcs_id_none = "-1";

                        #endregion Community based services

                        dalHHA.hhcs_id_other = "-1";
                        dalHHA.hhs_id_other = "-1";
                        dalHHA.hh_child_abuse_action = cboactionChildAbuse.Text;

                        dalHHA.Save(dbCon);
                        #endregion Household Assessment

                        dbCon.TransactionCommit();

                        if (FormCalling.ObjectId.Length == 0)
                        {
                            FormCalling.ObjectId = ObjectId;
                            FormCalling.MembersTab(true);
                        }

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetHouseholdControls(false);
                    }
                    catch (Exception exc)
                    {
                        dbCon.TransactionRollback();
                        throw exc;
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
            cbDistrict.Enabled = blnEnabled;
            cbSubCounty.Enabled = blnEnabled;
            cbWard.Enabled = blnEnabled;
            txtHoueholdCode.Enabled = blnEnabled;
            txtVillage.Enabled = blnEnabled;
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
            if (txtHoueholdCode.Text.Trim().Length == 0 || txtVillage.Text.Trim().Length == 0 ||
                cbDistrict.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0 || cbWard.SelectedIndex == 0 ||
                cbHouseholdMember.SelectedIndex == -1 || txtMemberCount.Text == string.Empty)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHouseholdAssessment, dbCon);
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

        protected void LoadHHServicesReceived()
        {
            DataTable dt = null;
            dt = hhHouseholdAssessment.Return_HHServicesReceived("HHService");
            if (dt.Rows.Count > 0)
            {
                chklistHHServicesReceived.DataSource = dt;
                chklistHHServicesReceived.DisplayMember = "hhs_name";
                chklistHHServicesReceived.ValueMember = "hhs_id";
            }

            dt = hhHouseholdAssessment.Return_HHServicesReceived("Community");
            if (dt.Rows.Count > 0)
            {
                chklistCommunityServices.DataSource = dt;
                chklistCommunityServices.DisplayMember = "hhs_name";
                chklistCommunityServices.ValueMember = "hhs_id";
            }
        }

        protected void LoadPartners()
        {
            //reused code to fetch partner lists
            DataTable dt = hhHouseholdAssessment.Return_Lookups("IP",string.Empty);

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["prt_id"] = "-1";
            dstemptyRow["prt_name"] = "Select Partner";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboip.DataSource = dt;
            cboip.DisplayMember = "prt_name";
            cboip.ValueMember = "prt_id";
        }

        private void cboip_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = hhHouseholdAssessment.Return_Lookups("CSOHAT", cboip.SelectedValue.ToString());

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["cso_id"] = "-1";
            dstemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboCSO.DataSource = dt;
            cboCSO.DisplayMember = "cso_other";
            cboCSO.ValueMember = "cso_id";
        }

        private void cbHouseholdMember_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = hhHouseholdAssessment.Return_Lookups("SocialWorkerPhone", cbSocialWorker.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txtSocialWorkerPhone.Text = dtRow["swk_phone"].ToString();
            }
            else
            {
                txtSocialWorkerPhone.Text = string.Empty;
            }
        }

        private void txtHHMMale_above_18yrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHHMMale_below_18yrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHHMFemale_above_18yrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHHMFemale_below_18yrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        protected void CalculateTotalHHM(string gender)
        {
            int countOne = 0;
            int countTwo = 0;
            int total = 0;
            switch (gender) {
                case "Male":
                    if (txtHHMMale_above_18yrs.Text != string.Empty)
                    {
                        countOne = Convert.ToInt32(txtHHMMale_above_18yrs.Text);
                    }

                    if (txtHHMMale_below_18yrs.Text != string.Empty)
                    {
                        countTwo = Convert.ToInt32(txtHHMMale_below_18yrs.Text);
                    }

                    total = countOne + countTwo;
                    txtTotalHHMale.Text = total == 0 ? "0" : total.ToString();
                    break;
                case "Female":
                    if (txtHHMFemale_above_18yrs.Text != string.Empty)
                    {
                        countOne = Convert.ToInt32(txtHHMFemale_above_18yrs.Text);
                    }

                    if (txtHHMFemale_below_18yrs.Text != string.Empty)
                    {
                        countTwo = Convert.ToInt32(txtHHMFemale_below_18yrs.Text);
                    }

                    total = countOne + countTwo;
                    txtTotalHHFemale.Text = total == 0 ? "0" : total.ToString();
                    break;
            }
        }

        private void txtHHMMale_above_18yrs_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalHHM("Male");
        }

        private void txtHHMMale_below_18yrs_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalHHM("Male");
        }

        private void txtHHMFemale_above_18yrs_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalHHM("Female");
        }

        private void txtHHMFemale_below_18yrs_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalHHM("Female");
        }

        private void txtMemberCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPopup_Click(object sender, EventArgs e)
        {
            frm_BeneficairyIndexRegister frmNew = new frm_BeneficairyIndexRegister();
            frmNew.ShowDialog();
        }
    }
}
