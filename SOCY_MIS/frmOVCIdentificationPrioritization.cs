using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;
using PSAUtils;

namespace SOCY_MIS
{
    public partial class frmOVCIdentificationPrioritization : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strHHMId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private frmHouseholdSearch frmCllNew = null;
        private frmOVCIdentificationPrioritizationSearch frmCllSearch = null;
        private frmResultArea02 frmPrt = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmHouseholdSearch FormCallingNew
        {
            get { return frmCllNew; }
            set { frmCllNew = value; }
        }

        public frmOVCIdentificationPrioritizationSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
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

        public string HouseholdMemberId
        {
            get { return strHHMId; }
            set { strHHMId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmOVCIdentificationPrioritization()
        {
            InitializeComponent();
        }

        private void frmOVCIdentificationPrioritization_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                ReturnIdentificationSources();
                SetPermissions();
                LoadDisplay();
                
            }
        }

        private void frmOVCIdentificationPrioritization_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbCPMonth.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbHHMGender.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Controls
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

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", cbCSO.SelectedValue.ToString());
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), cbCSO.SelectedValue.ToString());
            SetHouseholdCode();
        }

        private void cbPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", "");
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), "");
            SetHouseholdCode();
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", "", "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
            SetHouseholdCode();
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
            SetHouseholdCode();
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                LoadListsArea("", "", cbWard.SelectedValue.ToString());
            SetHouseholdCode();
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void txtHHTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtSocialWorkerTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }

        #region Set Display
        #region Economic Strengthening
        private void rbtnESChildHeadedYes_CheckedChanged(object sender, EventArgs e)
        {
            SetEconomicStrengthening();
        }

        private void rbtnESEmploymentNo_CheckedChanged(object sender, EventArgs e)
        {
            SetEconomicStrengthening();
        }

        private void rbtnESExpenseNo_CheckedChanged(object sender, EventArgs e)
        {
            SetEconomicStrengthening();
        }

        private void rbtnESDisabilityYes_CheckedChanged(object sender, EventArgs e)
        {
            SetEconomicStrengthening();
        }

        private void SetEconomicStrengthening()
        {
            if (rbtnESChildHeadedYes.Checked || rbtnESEmploymentNo.Checked || rbtnESExpenseNo.Checked || rbtnESDisabilityYes.Checked)
            {
                rbtnESVulnerableNo.Checked = false;
                rbtnESVulnerableYes.Checked = true;
            }
            else
            {
                rbtnESVulnerableNo.Checked = true;
                rbtnESVulnerableYes.Checked = false;
            }
        }
        #endregion Economic Strengthening

        #region Food Support and Nutrition
        private void rbtnFSNMealsNo_CheckedChanged(object sender, EventArgs e)
        {
            SetFoodSupportAndNutrition();
        }

        private void rbtnFSNMalnourishedYes_CheckedChanged(object sender, EventArgs e)
        {
            SetFoodSupportAndNutrition();
        }

        private void SetFoodSupportAndNutrition()
        {
            if (rbtnFSNMealsNo.Checked || rbtnFSNMalnourishedYes.Checked)
            {
                rbtnFSNVulnerableNo.Checked = false;
                rbtnFSNVulnerableYes.Checked = true;
            }
            else
            {
                rbtnFSNVulnerableNo.Checked = true;
                rbtnFSNVulnerableYes.Checked = false;
            }
        }
        #endregion Food Support and Nutrition

        #region Health, Water, Sanitation and Shelter
        private void rbtnHWSSWaterNo_CheckedChanged(object sender, EventArgs e)
        {
            SetHealthWaterSanitationAndShelter();
        }

        private void rbtnHWSSShelterNo_CheckedChanged(object sender, EventArgs e)
        {
            SetHealthWaterSanitationAndShelter();
        }

        private void rbtnHWSSHIVStatusNo_CheckedChanged(object sender, EventArgs e)
        {
            SetHealthWaterSanitationAndShelter();
        }

        private void rbtnHWSSHIVPositiveYes_CheckedChanged(object sender, EventArgs e)
        {
            SetHealthWaterSanitationAndShelter();
        }

        private void SetHealthWaterSanitationAndShelter()
        {
            if (rbtnHWSSWaterNo.Checked || rbtnHWSSShelterNo.Checked || rbtnHWSSHIVStatusNo.Checked || rbtnHWSSHIVPositiveYes.Checked)
            {
                rbtnHWSSVulnerableNo.Checked = false;
                rbtnHWSSVulnerableYes.Checked = true;
            }
            else
            {
                rbtnHWSSVulnerableNo.Checked = true;
                rbtnHWSSVulnerableYes.Checked = false;
            }
        }
        #endregion Health, Water, Sanitation and Shelter

        #region Education
        private void rbtnEDUNotEnrolledYes_CheckedChanged(object sender, EventArgs e)
        {
            SetEducation();
        }

        private void rbtnEDUMissedSchoolYes_CheckedChanged(object sender, EventArgs e)
        {
            SetEducation();
        }

        private void rbtnEDUNotEnrolledNA_CheckedChanged(object sender, EventArgs e)
        {
            SetEducation();
        }

        private void rbtnEDUMissedSchoolNA_CheckedChanged(object sender, EventArgs e)
        {
            SetEducation();
        }

        private void SetEducation()
        {
            if (rbtnEDUNotEnrolledYes.Checked || rbtnEDUMissedSchoolYes.Checked)
            {
                rbtnEDUVulnerableNA.Checked = false;
                rbtnEDUVulnerableNo.Checked = false;
                rbtnEDUVulnerableYes.Checked = true;
            }
            else
            {
                if (rbtnEDUNotEnrolledNA.Checked && rbtnEDUMissedSchoolNA.Checked)
                {
                    rbtnEDUVulnerableNA.Checked = true;
                    rbtnEDUVulnerableNo.Checked = false;
                }
                else
                {
                    rbtnEDUVulnerableNA.Checked = false;
                    rbtnEDUVulnerableNo.Checked = true;
                }
                rbtnEDUVulnerableYes.Checked = false;
            }
        }
        #endregion Education

        #region Psychosocial Support and Basic Care
        private void rbtnPSBCStigmatizedYes_CheckedChanged(object sender, EventArgs e)
        {
            SetPsychosocialSupportAndBasicCare();
        }

        private void SetPsychosocialSupportAndBasicCare()
        {
            if (rbtnPSBCStigmatizedYes.Checked)
            {
                rbtnPSBCVulnerableNo.Checked = false;
                rbtnPSBCVulnerableYes.Checked = true;
            }
            else
            {
                rbtnPSBCVulnerableNo.Checked = true;
                rbtnPSBCVulnerableYes.Checked = false;
            }
        }
        #endregion Psychosocial Support and Basic Care

        #region Child Protection
        #region 14
        private void chkCPAbusePhysical_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection14();
        }

        private void chkCPMarriageTeenParent_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection14();
        }

        private void chkCPPregnancy_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection14();
        }

        private void chkCPNeglected_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection14();
        }

        private void chkCPAbuseSexual_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection14();
        }

        private void SetChildProtection14()
        {
            if (chkCPAbusePhysical.Checked || chkCPMarriageTeenParent.Checked || chkCPPregnancy.Checked || chkCPNeglected.Checked || chkCPAbuseSexual.Checked)
            {
                rbtnCPAbuseNo.Checked = false;
                rbtnCPAbuseYes.Checked = true;
            }
            else
            {
                rbtnCPAbuseNo.Checked = false;
                rbtnCPAbuseYes.Checked = false;
            }
        }
        #endregion 14

        private void rbtnCPAbuseYes_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection();
        }

        private void rbtnCPOrphanYes_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection();
        }

        private void rbtnCPNoBirthRegisterYes_CheckedChanged(object sender, EventArgs e)
        {
            SetChildProtection();
        }

        private void SetChildProtection()
        {
            if (rbtnCPAbuseYes.Checked || rbtnCPOrphanYes.Checked || rbtnCPNoBirthRegisterYes.Checked)
            {
                rbtnCPVulnerableNo.Checked = false;
                rbtnCPVulnerableYes.Checked = true;
            }
            else
            {
                rbtnCPVulnerableNo.Checked = true;
                rbtnCPVulnerableYes.Checked = false;
            }
        }
        #endregion Child Protection
        #endregion Set Display
        #endregion Controls

        #region Private Methods
        private void Back()
        {
            if (FormCalling != null)
            {
                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormCallingNew != null)
            {
                FormCallingNew.BackDisplay();
                FormMaster.LoadControl(FormCallingNew, this.Name, false);
            }
            else if (FormCallingSearch != null)
            {
                FormCallingSearch.BackDisplay();
                FormParent.LoadControl(FormCallingSearch, this.Name);
            }
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbCPMonth.SelectedIndex = 0;
                    cbDistrict.SelectedIndex = 0;
                    cbHHMGender.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbWard.SelectedIndex = 0;

                    dtpDate.Value = DateTime.Now;

                    nud18AboveF.Value = 0;
                    nud18AboveM.Value = 0;
                    nud18BelowF.Value = 0;
                    nud18BelowM.Value = 0;
                    nudHWSSHIVPositiveAdult.Value = 0;
                    nudHWSSHIVPositiveChildren.Value = 0;
                    nudHHMAge.Value = 0;

                    chkChildren.Checked = false;
                    chkCPAbusePhysical.Checked = false;
                    chkCPAbuseSexual.Checked = false;
                    chkCPMarriageTeenParent.Checked = false;
                    chkCPNeglected.Checked = false;
                    chkCPPregnancy.Checked = false;
                    rbtnCPAbuseNo.Checked = false;
                    rbtnCPAbuseYes.Checked = false;
                    rbtnCPNoBirthRegisterNo.Checked = false;
                    rbtnCPNoBirthRegisterYes.Checked = false;
                    rbtnCPOrphanNo.Checked = false;
                    rbtnCPOrphanYes.Checked = false;
                    rbtnCPReferredNo.Checked = false;
                    rbtnCPReferredYes.Checked = false;
                    rbtnCPVulnerableNo.Checked = false;
                    rbtnCPVulnerableYes.Checked = false;
                    rbtnEDUMissedSchoolNA.Checked = false;
                    rbtnEDUMissedSchoolNo.Checked = false;
                    rbtnEDUMissedSchoolYes.Checked = false;
                    rbtnEDUNotEnrolledNA.Checked = false;
                    rbtnEDUNotEnrolledNo.Checked = false;
                    rbtnEDUNotEnrolledYes.Checked = false;
                    rbtnEDUReferredNo.Checked = false;
                    rbtnEDUReferredYes.Checked = false;
                    rbtnEDUVulnerableNA.Checked = false;
                    rbtnEDUVulnerableNo.Checked = false;
                    rbtnEDUVulnerableYes.Checked = false;
                    rbtnESChildHeadedNo.Checked = false;
                    rbtnESChildHeadedYes.Checked = false;
                    rbtnESDisabilityNo.Checked = false;
                    rbtnESDisabilityYes.Checked = false;
                    rbtnESEmploymentNo.Checked = false;
                    rbtnESEmploymentYes.Checked = false;
                    rbtnESExpenseNo.Checked = false;
                    rbtnESExpenseYes.Checked = false;
                    rbtnESReferredNo.Checked = false;
                    rbtnESReferredYes.Checked = false;
                    rbtnESVulnerableNo.Checked = false;
                    rbtnESVulnerableYes.Checked = false;
                    rbtnFSNMealsNo.Checked = false;
                    rbtnFSNMealsYes.Checked = false;
                    rbtnFSNReferredNo.Checked = false;
                    rbtnFSNReferredYes.Checked = false;
                    rbtnFSNVulnerableNo.Checked = false;
                    rbtnFSNVulnerableYes.Checked = false;
                    rbtnHWSSHIVPositiveNo.Checked = false;
                    rbtnHWSSHIVPositiveYes.Checked = false;
                    rbtnHWSSHIVStatusNo.Checked = false;
                    rbtnHWSSHIVStatusYes.Checked = false;
                    rbtnFSNMalnourishedNo.Checked = false;
                    rbtnFSNMalnourishedYes.Checked = false;
                    rbtnHWSSReferredNo.Checked = false;
                    rbtnHWSSReferredYes.Checked = false;
                    rbtnHWSSShelterNo.Checked = false;
                    rbtnHWSSShelterYes.Checked = false;
                    rbtnHWSSVulnerableNo.Checked = false;
                    rbtnHWSSVulnerableYes.Checked = false;
                    rbtnHWSSWaterNo.Checked = false;
                    rbtnHWSSWaterYes.Checked = false;
                    rbtnPSBCReferredNo.Checked = false;
                    rbtnPSBCReferredYes.Checked = false;
                    rbtnPSBCStigmatizedNo.Checked = false;
                    rbtnPSBCStigmatizedYes.Checked = false;
                    rbtnPSBCVulnerableNo.Checked = false;
                    rbtnPSBCVulnerableYes.Checked = false;
                    dtpDate.Checked = false;
                    txtComments.Text = "";
                    txtHHCode.Text = "";
                    txtHHMFirstName.Text = "";
                    txtHHMLastName.Text = "";
                    txtSocialWorkerTel.Text = "";
                    txtHHTel.Text = "";
                    txtVillage.Text = "";
                    cboIdentification_source.SelectedValue = "-1";
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
                hhOVCIdentificationPrioritization dalOIP = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Check Household Code of the Object
                    if (ObjectId.Length != 0)
                    {
                        dalOIP = new hhOVCIdentificationPrioritization();
                        dalOIP.Load(ObjectId, dbCon);

                        if (HouseholdId.Length == 0)
                            HouseholdId = dalOIP.hh_id;
                    }
                    #endregion Check Household Code of the Object

                    #region Household
                    dalHH = new hhHousehold();
                    if (HouseholdId.Length != 0)
                    {
                        dalHH.Load(HouseholdId, dbCon);
                        txtHHCode.Text = dalHH.hh_code;
                        txtHHTel.Text = dalHH.hh_tel;
                        txtVillage.Text = dalHH.hh_village;
                        SetHouseholdControls(false);
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
                        txtHHMFirstName.Enabled = true;
                        txtHHMLastName.Enabled = true;
                        txtHHTel.Enabled = true;
                        nudHHMAge.Enabled = true;
                        cbHHMGender.Enabled = true;
                    }
                    else
                    {
                        #region Assessment
                        txtComments.Text = dalOIP.oip_comments;
                        HouseholdMemberId = dalOIP.hhm_id;
                        txtSocialWorkerTel.Text = dalOIP.oip_interviewer_tel;

                        dtpDate.Value = dalOIP.oip_date;

                        nud18AboveF.Value = dalOIP.oip_18_above_female;
                        nud18AboveM.Value = dalOIP.oip_18_above_male;
                        nud18BelowF.Value = dalOIP.oip_18_below_female;
                        nud18BelowM.Value = dalOIP.oip_18_below_male;
                        nudHWSSHIVPositiveAdult.Value = dalOIP.oip_hiv_adult;
                        nudHWSSHIVPositiveChildren.Value = dalOIP.oip_hiv_children;

                        chkChildren.Checked = (dalOIP.yn_id_children == "1");
                        chkCPAbusePhysical.Checked = (dalOIP.yn_id_cp_abuse_physical == "1");
                        chkCPAbuseSexual.Checked = (dalOIP.yn_id_cp_abuse_sexual == "1");
                        chkCPMarriageTeenParent.Checked = (dalOIP.yn_id_cp_marriage_teen_parent == "1");
                        chkCPNeglected.Checked = (dalOIP.yn_id_cp_neglected == "1");
                        chkCPPregnancy.Checked = (dalOIP.yn_id_cp_pregnancy == "1");
                        cboIdentification_source.SelectedValue = dalOIP.ids_id;

                        utilControls.RadioButtonSetSelection(rbtnCPAbuseYes, rbtnCPAbuseNo, dalOIP.yn_id_cp_abuse);
                        utilControls.RadioButtonSetSelection(rbtnCPNoBirthRegisterYes, rbtnCPNoBirthRegisterNo, dalOIP.yn_id_cp_no_birth_register);
                        utilControls.RadioButtonSetSelection(rbtnCPOrphanYes, rbtnCPOrphanNo, dalOIP.yn_id_cp_orphan);
                        utilControls.RadioButtonSetSelection(rbtnCPReferredYes, rbtnCPReferredNo, dalOIP.yn_id_cp_referred);
                        utilControls.RadioButtonSetSelection(rbtnEDUReferredYes, rbtnEDUReferredNo, dalOIP.yn_id_edu_referred);
                        utilControls.RadioButtonSetSelection(rbtnESChildHeadedYes, rbtnESChildHeadedNo, dalOIP.yn_id_es_child_headed);
                        utilControls.RadioButtonSetSelection(rbtnESDisabilityYes, rbtnESDisabilityNo, dalOIP.yn_id_es_disability);
                        utilControls.RadioButtonSetSelection(rbtnESEmploymentYes, rbtnESEmploymentNo, dalOIP.yn_id_es_employment);
                        utilControls.RadioButtonSetSelection(rbtnESExpenseYes, rbtnESExpenseNo, dalOIP.yn_id_es_expense);
                        utilControls.RadioButtonSetSelection(rbtnESReferredYes, rbtnESReferredNo, dalOIP.yn_id_es_referred);
                        utilControls.RadioButtonSetSelection(rbtnFSNMalnourishedYes, rbtnFSNMalnourishedNo, dalOIP.yn_id_fsn_malnourished);
                        utilControls.RadioButtonSetSelection(rbtnFSNMealsYes, rbtnFSNMealsNo, dalOIP.yn_id_fsn_meals);
                        utilControls.RadioButtonSetSelection(rbtnFSNReferredYes, rbtnFSNReferredNo, dalOIP.yn_id_fsn_referred);
                        utilControls.RadioButtonSetSelection(rbtnHWSSHIVPositiveYes, rbtnHWSSHIVPositiveNo, dalOIP.yn_id_hwss_hiv_positive);
                        utilControls.RadioButtonSetSelection(rbtnHWSSHIVStatusYes, rbtnHWSSHIVStatusNo, dalOIP.yn_id_hwss_hiv_status);
                        utilControls.RadioButtonSetSelection(rbtnHWSSReferredYes, rbtnHWSSReferredNo, dalOIP.yn_id_hwss_referred);
                        utilControls.RadioButtonSetSelection(rbtnHWSSShelterYes, rbtnHWSSShelterNo, dalOIP.yn_id_hwss_shelter);
                        utilControls.RadioButtonSetSelection(rbtnHWSSWaterYes, rbtnHWSSWaterNo, dalOIP.yn_id_hwss_water);
                        utilControls.RadioButtonSetSelection(rbtnPSBCReferredYes, rbtnPSBCReferredNo, dalOIP.yn_id_psbc_referred);
                        utilControls.RadioButtonSetSelection(rbtnPSBCStigmatizedYes, rbtnPSBCStigmatizedNo, dalOIP.yn_id_psbc_stigmatized);

                        utilControls.RadioButtonSetSelection(rbtnEDUMissedSchoolYes, rbtnEDUMissedSchoolNo, rbtnEDUMissedSchoolNA, dalOIP.ynna_id_edu_missed_school);
                        utilControls.RadioButtonSetSelection(rbtnEDUNotEnrolledYes, rbtnEDUNotEnrolledNo, rbtnEDUNotEnrolledNA, dalOIP.ynna_id_edu_not_enrolled);

                        //btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalOIP.ofc_id) || utilConstants.cDFImportOffice.Equals(dalOIP.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalOIP.ofc_id));

                        SetChildProtection();
                        SetChildProtection14();
                        SetEconomicStrengthening();
                        SetEducation();
                        SetFoodSupportAndNutrition();
                        SetHealthWaterSanitationAndShelter();
                        SetPsychosocialSupportAndBasicCare();
                        #endregion Assessment

                        LoadLists(dalOIP.oip_cp_month, dalOIP.cso_id, dalHH.swk_id, dalHH.wrd_id, dbCon);
                        LoadDisplayMember(dalOIP.hhm_id, dbCon);
                        
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

        private void LoadDisplayMember(string strHhmId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHouseholdMember dalHHM = new hhHouseholdMember();
            #endregion Variables

            #region Load Data
            dalHHM.Load(strHhmId, dbCon);

            txtHHMFirstName.Text = dalHHM.hhm_first_name;
            txtHHMLastName.Text = dalHHM.hhm_last_name;
            cbHHMGender.SelectedValue = dalHHM.gnd_id;
            if (dalHHM.hhm_year_of_birth.Equals(utilConstants.cDFEmptyListValue))
                nudHHMAge.Value = 0;
            else
                nudHHMAge.Value = dtpDate.Value.Year - Convert.ToInt32(dalHHM.hhm_year_of_birth);

            txtHHMFirstName.Enabled = false;
            txtHHMLastName.Enabled = false;
            cbHHMGender.Enabled = false;
            nudHHMAge.Enabled = false;
            #endregion Load Data
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

        private void LoadLists(string strCPMonth, string strCsoId, string strSwkId, string strWrdId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_gender", true, "", true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMGender, dt, "lt_id", "lt_name");

                dt = utilSOCY_MIS.GetMonths();
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbCPMonth, dt, "lt_id", "lt_name");

                dalSwk = new swmSocialWorker();
                if (ObjectId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strCPMonth.Length != 0)
                    cbCPMonth.SelectedValue = strCPMonth;
                else
                    cbCPMonth.SelectedIndex = 0;
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", "", strWrdId, dbCon);
                LoadListsOrganization("", strCsoId, dbCon);
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

        private void LoadListsOrganization(string strPrtId, string strCsoId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsOrganization(strPrtId, strCsoId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsOrganization(string strPrtId, string strCsoId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsOrganization(strPrtId, strCsoId, cbPartner, cbCSO, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsOrganization", exc);
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
                hhHouseholdMember dalHHM = null;
                hhOVCIdentificationPrioritization dalOIP = null;

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

                            dalHH.hh_code = txtHHCode.Text.Trim();
                            dalHH.hh_tel = txtHHTel.Text.Trim();
                            dalHH.hh_village = txtVillage.Text.Trim();
                            dalHH.hhs_id = utilConstants.cDFActive.ToString();
                            dalHH.swk_id = cbSocialWorker.SelectedValue.ToString();

                            dalHH.wrd_id = cbWard.SelectedValue.ToString();
                            dalHH.usr_id_update = FormMaster.UserId;
                            dalHH.ofc_id = FormMaster.OfficeId;
                            dalHH.district_id = static_variables.district_id;
                            dalHH.Save(dbCon);

                            dalHHM = new hhHouseholdMember();
                            HouseholdMemberId = Guid.NewGuid().ToString();
                            dalHHM.hhm_id = HouseholdMemberId;
                            dalHHM.hh_id = HouseholdId;
                            dalHHM.hhm_number = dalHHM.NextMemberNumber(HouseholdId, dbCon);

                            dalHHM.hhm_first_name = txtHHMFirstName.Text.Trim();
                            dalHHM.hhm_last_name = txtHHMLastName.Text.Trim();
                            dalHHM.gnd_id = cbHHMGender.SelectedValue.ToString();
                            dalHHM.hhm_year_of_birth = (dtpDate.Value.Year - nudHHMAge.Value).ToString();
                            dalHHM.yn_id_hoh = utilConstants.cDFListValueYes;

                            dalHHM.usr_id_update = FormMaster.UserId;
                            dalHHM.ofc_id = FormMaster.OfficeId;
                            dalHHM.district_id = static_variables.district_id;
                           
                            dalHHM.Save(dbCon);
                        }
                        #endregion Household

                        #region Household Assessment
                        dalOIP = new hhOVCIdentificationPrioritization();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalOIP.oip_id = ObjectId;
                            dalOIP.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalOIP.Load(ObjectId, dbCon);

                        dalOIP.oip_comments = txtComments.Text.Trim();
                        dalOIP.oip_date = dtpDate.Value;
                        dalOIP.oip_interviewer_tel = txtSocialWorkerTel.Text;
                        dalOIP.oip_18_above_female = Convert.ToInt32(nud18AboveF.Value);
                        dalOIP.oip_18_above_male = Convert.ToInt32(nud18AboveM.Value);
                        dalOIP.oip_18_below_female = Convert.ToInt32(nud18BelowF.Value);
                        dalOIP.oip_18_below_male = Convert.ToInt32(nud18BelowM.Value);
                        dalOIP.oip_hiv_adult = Convert.ToInt32(nudHWSSHIVPositiveAdult.Value);
                        dalOIP.oip_hiv_children = Convert.ToInt32(nudHWSSHIVPositiveChildren.Value);
                        dalOIP.cso_id = cbCSO.SelectedValue.ToString();
                        dalOIP.hh_id = HouseholdId;
                        if (HouseholdMemberId.Length != 0)
                            dalOIP.hhm_id = HouseholdMemberId;
                        dalOIP.oip_cp_month = cbCPMonth.SelectedValue.ToString();
                        dalOIP.swk_id = cbSocialWorker.SelectedValue.ToString();

                        dalOIP.yn_id_children = Convert.ToInt32(chkChildren.Checked).ToString();
                        dalOIP.yn_id_cp_abuse_physical = Convert.ToInt32(chkCPAbusePhysical.Checked).ToString();
                        dalOIP.yn_id_cp_abuse_sexual = Convert.ToInt32(chkCPAbuseSexual.Checked).ToString();
                        dalOIP.yn_id_cp_marriage_teen_parent = Convert.ToInt32(chkCPMarriageTeenParent.Checked).ToString();
                        dalOIP.yn_id_cp_neglected = Convert.ToInt32(chkCPNeglected.Checked).ToString();
                        dalOIP.yn_id_cp_pregnancy = Convert.ToInt32(chkCPPregnancy.Checked).ToString();
                        dalOIP.yn_id_cp_abuse = utilControls.RadioButtonGetSelection(rbtnCPAbuseYes, rbtnCPAbuseNo);
                        dalOIP.yn_id_cp_no_birth_register = utilControls.RadioButtonGetSelection(rbtnCPNoBirthRegisterYes, rbtnCPNoBirthRegisterNo);
                        dalOIP.yn_id_cp_orphan = utilControls.RadioButtonGetSelection(rbtnCPOrphanYes, rbtnCPOrphanNo);
                        dalOIP.yn_id_cp_referred = utilControls.RadioButtonGetSelection(rbtnCPReferredYes, rbtnCPReferredNo);
                        dalOIP.yn_id_edu_referred = utilControls.RadioButtonGetSelection(rbtnEDUReferredYes, rbtnEDUReferredNo);
                        dalOIP.yn_id_es_child_headed = utilControls.RadioButtonGetSelection(rbtnESChildHeadedYes, rbtnESChildHeadedNo);
                        dalOIP.yn_id_es_disability = utilControls.RadioButtonGetSelection(rbtnESDisabilityYes, rbtnESDisabilityNo);
                        dalOIP.yn_id_es_employment = utilControls.RadioButtonGetSelection(rbtnESEmploymentYes, rbtnESEmploymentNo);
                        dalOIP.yn_id_es_expense = utilControls.RadioButtonGetSelection(rbtnESExpenseYes, rbtnESExpenseNo);
                        dalOIP.yn_id_es_referred = utilControls.RadioButtonGetSelection(rbtnESReferredYes, rbtnESReferredNo);
                        dalOIP.yn_id_fsn_malnourished = utilControls.RadioButtonGetSelection(rbtnFSNMalnourishedYes, rbtnFSNMalnourishedNo);
                        dalOIP.yn_id_fsn_meals = utilControls.RadioButtonGetSelection(rbtnFSNMealsYes, rbtnFSNMealsNo);
                        dalOIP.yn_id_fsn_referred = utilControls.RadioButtonGetSelection(rbtnFSNReferredYes, rbtnFSNReferredNo);
                        dalOIP.yn_id_hwss_hiv_positive = utilControls.RadioButtonGetSelection(rbtnHWSSHIVPositiveYes, rbtnHWSSHIVPositiveNo);
                        dalOIP.yn_id_hwss_hiv_status = utilControls.RadioButtonGetSelection(rbtnHWSSHIVStatusYes, rbtnHWSSHIVStatusNo);
                        dalOIP.yn_id_hwss_referred = utilControls.RadioButtonGetSelection(rbtnHWSSReferredYes, rbtnHWSSReferredNo);
                        dalOIP.yn_id_hwss_shelter = utilControls.RadioButtonGetSelection(rbtnHWSSShelterYes, rbtnHWSSShelterNo);
                        dalOIP.yn_id_hwss_water = utilControls.RadioButtonGetSelection(rbtnHWSSWaterYes, rbtnHWSSWaterNo);
                        dalOIP.yn_id_psbc_referred = utilControls.RadioButtonGetSelection(rbtnPSBCReferredYes, rbtnPSBCReferredNo);
                        dalOIP.yn_id_psbc_stigmatized = utilControls.RadioButtonGetSelection(rbtnPSBCStigmatizedYes, rbtnPSBCStigmatizedNo);

                        dalOIP.ynna_id_edu_missed_school = utilControls.RadioButtonGetSelection(rbtnEDUMissedSchoolYes, rbtnEDUMissedSchoolNo, rbtnEDUMissedSchoolNA);
                        dalOIP.ynna_id_edu_not_enrolled = utilControls.RadioButtonGetSelection(rbtnEDUNotEnrolledYes, rbtnEDUNotEnrolledNo, rbtnEDUNotEnrolledNA);

                        dalOIP.usr_id_update = FormMaster.UserId;
                        dalOIP.district_id = static_variables.district_id; //edited by tadeo
                        dalOIP.ids_id = cboIdentification_source.SelectedValue.ToString();

                        dalOIP.Save(dbCon);
                        #endregion Household Assessment

                        dbCon.TransactionCommit();

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

        private void SetHouseholdCode()
        {

            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            hhHousehold dalHh = null;
            #endregion Variables

            if (ObjectId.Length == 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                dalHh = new hhHousehold();
                try
                {
                    //txtHHCode.Text = dalHh.NextHouseholdCode(cbPartner.SelectedValue.ToString(), cbCSO.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), dbCon);
                    txtHHCode.Text = dalHh.NextHouseholdCode(cbDistrict.SelectedValue.ToString(), cbCSO.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), dbCon);
                }
                catch (Exception exc)
                {
                    FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetHouseholdCode", exc);
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
        }

        private void SetHouseholdControls(bool blnEnabled)
        {
            #region Set Controls
            cbDistrict.Enabled = blnEnabled;
            cbSubCounty.Enabled = blnEnabled;
            cbWard.Enabled = blnEnabled;
            txtHHCode.Enabled = blnEnabled;
            txtHHTel.Enabled = blnEnabled;
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
            if (txtHHCode.Text.Trim().Length == 0 || txtHHMFirstName.Text.Trim().Length == 0 || txtHHMLastName.Text.Trim().Length == 0 || txtVillage.Text.Trim().Length == 0 ||
                cbDistrict.SelectedIndex == 0 || cbHHMGender.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0 || cbWard.SelectedIndex == 0 ||
                cbPartner.SelectedIndex == 0 || cbCSO.SelectedIndex == 0 || nudHHMAge.Value == 0 || dtpDate.Checked == false || cboIdentification_source.SelectedValue.ToString() == "-1")
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Phone Number
            if (txtHHTel.Text.Replace(" ", "").Trim().Length != 0 && txtHHTel.Text.Replace(" ", "").Trim().Length != utilConstants.cDFPhoneNumberLength)
                strMessage = strMessage + "," + utilConstants.cMIDPhoneNumberLength;
            else if (txtSocialWorkerTel.Text.Replace(" ", "").Trim().Length != 0 && txtSocialWorkerTel.Text.Replace(" ", "").Trim().Length != utilConstants.cDFPhoneNumberLength)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageOVCIdentificationandPrioritization, dbCon);
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

        #region Radio Buttons
        private int intESReferredNo = 0;
        private int intESReferredYes = 0;
        private void rbtnESReferredNo_Click(object sender, EventArgs e)
        {
            intESReferredYes = 0;
            intESReferredNo = UncheckRadioButton((RadioButton)sender, intESReferredNo);
        }

        private void rbtnESReferredYes_Click(object sender, EventArgs e)
        {
            intESReferredNo = 0;
            intESReferredYes = UncheckRadioButton((RadioButton)sender, intESReferredYes);
        }

        private int intFSNReferredNo = 0;
        private int intFSNReferredYes = 0;
        private void rbtnFSNReferredNo_Click(object sender, EventArgs e)
        {
            intFSNReferredYes = 0;
            intFSNReferredNo = UncheckRadioButton((RadioButton)sender, intFSNReferredNo);
        }

        private void rbtnFSNReferredYes_Click(object sender, EventArgs e)
        {
            intFSNReferredNo = 0;
            intFSNReferredYes = UncheckRadioButton((RadioButton)sender, intFSNReferredYes);
        }

        private int intHWSSReferredNo = 0;
        private int intHWSSReferredYes = 0;
        private void rbtnHWSSReferredNo_Click(object sender, EventArgs e)
        {
            intHWSSReferredYes = 0;
            intHWSSReferredNo = UncheckRadioButton((RadioButton)sender, intHWSSReferredNo);
        }

        private void rbtnHWSSReferredYes_Click(object sender, EventArgs e)
        {
            intHWSSReferredNo = 0;
            intHWSSReferredYes = UncheckRadioButton((RadioButton)sender, intHWSSReferredYes);
        }

        private int intEDUReferredNo = 0;
        private int intEDUReferredYes = 0;
        private void rbtnEDUReferredNo_Click(object sender, EventArgs e)
        {
            intEDUReferredYes = 0;
            intEDUReferredNo = UncheckRadioButton((RadioButton)sender, intEDUReferredNo);
        }

        private void rbtnEDUReferredYes_Click(object sender, EventArgs e)
        {
            intEDUReferredNo = 0;
            intEDUReferredYes = UncheckRadioButton((RadioButton)sender, intEDUReferredYes);
        }

        private int intPSBCReferredNo = 0;
        private int intPSBCReferredYes = 0;
        private void rbtnPSBCReferredNo_Click(object sender, EventArgs e)
        {
            intPSBCReferredYes = 0;
            intPSBCReferredNo = UncheckRadioButton((RadioButton)sender, intPSBCReferredNo);
        }

        private void rbtnPSBCReferredYes_Click(object sender, EventArgs e)
        {
            intPSBCReferredNo = 0;
            intPSBCReferredYes = UncheckRadioButton((RadioButton)sender, intPSBCReferredYes);
        }

        private int intCPReferredNo = 0;
        private int intCPReferredYes = 0;
        private void rbtnCPReferredNo_Click(object sender, EventArgs e)
        {
            intCPReferredYes = 0;
            intCPReferredNo = UncheckRadioButton((RadioButton)sender, intCPReferredNo);
        }

        private void rbtnCPReferredYes_Click(object sender, EventArgs e)
        {
            intCPReferredNo = 0;
            intCPReferredYes = UncheckRadioButton((RadioButton)sender, intCPReferredYes);
        }

        private int UncheckRadioButton(RadioButton rbtn, int intCounter)
        {
            if (rbtn.Checked)
            {
                if (intCounter == 0)
                    intCounter = 1;
                else
                {
                    intCounter = 0;
                    rbtn.Checked = false;
                }
            }
            return intCounter;
        }
        #endregion Radio Buttons

        protected void ReturnIdentificationSources()
        {
            DataTable dt = SystemConstants.Return_lst_hh_identification_source();
            if (dt.Rows.Count > 0)
            {
                DataRow csoemptyRow = dt.NewRow();
                csoemptyRow["ids_id"] = "-1";
                csoemptyRow["ids_name"] = "Select one";
                dt.Rows.InsertAt(csoemptyRow, 0);

                cboIdentification_source.DataSource = dt;
                cboIdentification_source.DisplayMember = "ids_name";
                cboIdentification_source.ValueMember = "ids_id";
            }
        }
    }
}