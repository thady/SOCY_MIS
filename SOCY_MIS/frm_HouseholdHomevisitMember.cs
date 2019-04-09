using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;
using PSAUtilsWin32;

namespace SOCY_MIS
{
    public partial class frm_HouseholdHomevisitMember : UserControl
    {

        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frm_HouseholdHomeVisitMain frmCll = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frm_HouseholdHomeVisitMain FormCalling
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

        public frm_HouseholdHomevisitMember()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void frm_HouseholdHomevisitMember_Load(object sender, EventArgs e)
        {
            LoadMembers();
            LoadHouseholdCode();
            AherenceLevel();
        }

       protected void LoadMembers()
        {
            dt = hhHouseholdHomeVisit_v2.LoadMembers(HouseholdId, SystemConstants.object_id);

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["hhm_id"] = "-1";
            dstemptyRow["hhm_name"] = "Select one";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cbHHMember.DataSource = dt;
            cbHHMember.DisplayMember = "hhm_name";
            cbHHMember.ValueMember = "hhm_id";
        }

        protected void LoadHouseholdCode()
        {
            dt = hhHouseholdHomeVisit_v2.LoadHouseholdCode(HouseholdId);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                lblHouseholdCodeDisplay.Text = dtRow["hh_code"].ToString();
            }
        }

        protected void LoadMemberDetails(string hhm_id)
        {
            dt = hhHouseholdHomeVisit_v2.LoadMemberDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                lblYearOfBirthDisplay.Text = dtRow["hhm_year_of_birth"].ToString();
                lblGenderDisplay.Text = dtRow["gnd_name"].ToString();
                lblMemberNumberDisplay.Text = dtRow["hhm_number"].ToString();
            }
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedValue.ToString() != "-1")
            {
                LoadMemberDetails(cbHHMember.SelectedValue.ToString());
            }
        }

        #region DropdownFill
         void AherenceLevel()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add(-1, "Select One");
            table.Rows.Add(1, "Good");
            table.Rows.Add(2, "Fair");
            table.Rows.Add(3, "Poor");

            cboAherenceLevel.DataSource = table;
            cboAherenceLevel.DisplayMember = "name";
            cboAherenceLevel.ValueMember = "id";


            DataTable _table = new DataTable();
            _table.Columns.Add("id", typeof(int));
            _table.Columns.Add("name", typeof(string));

            // Here we add five DataRows.
            _table.Rows.Add(-1, "Select One");
            _table.Rows.Add(1, "Green");
            _table.Rows.Add(2, "Yellow");
            _table.Rows.Add(3, "Red");

            cboNutritionAssResult.DataSource = _table;
            cboNutritionAssResult.DisplayMember = "name";
            cboNutritionAssResult.ValueMember = "id";
        }
        #endregion 


        #region save
        protected void save()
        {
            DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);

            #region set variables
            hhHouseholdHomeVisit_v2.hhvm_id = Guid.NewGuid().ToString();
            hhHouseholdHomeVisit_v2.hhv_id = SystemConstants.object_id;
            hhHouseholdHomeVisit_v2.hhm_name = cbHHMember.Text;
            hhHouseholdHomeVisit_v2.hmm_age = (DateTime.Now.Year - Convert.ToInt32(lblYearOfBirthDisplay.Text)).ToString();
            hhHouseholdHomeVisit_v2.gnd_name = lblGenderDisplay.Text;
            hhHouseholdHomeVisit_v2.yn_id_hhm_active = utilControls.RadioButtonGetSelection(rbtnMemberActiveYes, rbtnMemberActiveNo);
            hhHouseholdHomeVisit_v2.ynna_stb_id_SILC = utilControls.RadioButtonGetSelection(rbtnESSilcYes, rbtnESSilcNo, rbtnESSilcNA);
            hhHouseholdHomeVisit_v2.ynna_stb_id_other_saving_grp = utilControls.RadioButtonGetSelection(rbtnLendingGroupYes, rbtnLendingGroupNo, rbtnLendingGroupNA);
            hhHouseholdHomeVisit_v2.ynna_stb_caregiver_services = utilControls.RadioButtonGetSelection(rbtnCaregiverGroupYes, rbtnCaregiverGroupNo, rbtnCaregiverGroupNA);
            hhHouseholdHomeVisit_v2.ynna_stb_contributes_edu_fund = utilControls.RadioButtonGetSelection(rbtnEdufundYes, rbtnEdufundNo, rbtnEdufundNA);
            hhHouseholdHomeVisit_v2.ynna_stb_SAGE = utilControls.RadioButtonGetSelection(rbtnSAGEYes, rbtnSAGENo, rbtnSAGENA);
            hhHouseholdHomeVisit_v2.yn_stb_receive_social_grant = utilControls.RadioButtonGetSelection(rbtnFoodBankYes, rbtnFoodBankNo);
            hhHouseholdHomeVisit_v2. ynna_stb_apprenticeship = utilControls.RadioButtonGetSelection(rbtnApprenticeshipYes, rbtnApprenticeshipNo, rbtnApprenticeshipNA);
            hhHouseholdHomeVisit_v2. ynna_stb_cottage = utilControls.RadioButtonGetSelection(rbtnCottageYes, rbtnCottageNo, rbtnCottageNA);
            hhHouseholdHomeVisit_v2. ynna_stb_agro_enterprise = utilControls.RadioButtonGetSelection(rbtnAggroYes, rbtnAggroNo, rbtnAggroNA);
            hhHouseholdHomeVisit_v2. ynna_stb_aflateen = utilControls.RadioButtonGetSelection(rbtnAflateenYes, rbtnAflateenNo, rbtnAflateenNA);
            hhHouseholdHomeVisit_v2. ynna_stb_sch_ovc_edu_enrolled = utilControls.RadioButtonGetSelection(rbtnOvcEduEnrolledYes, rbtnOvcEduEnrolledNo, rbtnOvcEduEnrolledNA);
            hhHouseholdHomeVisit_v2. ynna_sch_re_enrollment_support = utilControls.RadioButtonGetSelection(rbtnAssReEnrollmentYes, rbtnAssReEnrollmentNo, rbtnAssReEnrollmentNA);
            hhHouseholdHomeVisit_v2. ynna_sch_ovc_attend_school_regularly = utilControls.RadioButtonGetSelection(rbtnRegularAttendschoolYes, rbtnRegularAttendschoolNo, rbtnRegularAttendschoolNA);
            hhHouseholdHomeVisit_v2. ynna_sch_ovc_receive_school_uniform = utilControls.RadioButtonGetSelection(rbtnUniformYes, rbtnUniformNo, rbtnUniformNA);
            hhHouseholdHomeVisit_v2. ynna_sch_ovc_receive_edu_subsidy = utilControls.RadioButtonGetSelection(rbtnEduSubsidyYes, rbtnEduSubsidyNo, rbtnEduSubsidyNA);
            hhHouseholdHomeVisit_v2. ynna_progressed_to_another_class = utilControls.RadioButtonGetSelection(rbtnProgressedYes, rbtnProgressedNo, rbtnProgressedNA);

            #region HIV Status
            if (rbtnHHPHivPos.Checked)
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cHSTPositive;
            else if (rbtnHHPHivNeg.Checked)
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cHSTNegative;
            else if (rbtnHHPHivUnknown.Checked)
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cHSTUnKnown;
            else if (rbtnHHPHivTNR.Checked)
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cHSTNR;
            else if(rbtnHHPHivTNR.Checked)
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cHSTNR;
            else
                hhHouseholdHomeVisit_v2.hst_id = utilConstants.cDFEmptyListValue;
            #endregion HIS Status

            hhHouseholdHomeVisit_v2. ynna_on_art = utilControls.RadioButtonGetSelection(rbtnARTYes, rbtnARTNo, rbtnARTNA);
            hhHouseholdHomeVisit_v2. ynna_follow_art_prescription = utilControls.RadioButtonGetSelection(rbtnPillsYes, rbtnPillsNo, rbtnPillsNA);
            hhHouseholdHomeVisit_v2.adherence_level = cboAherenceLevel.Text;
            hhHouseholdHomeVisit_v2.ynna_hiv_literacy = utilControls.RadioButtonGetSelection(rbtnHIVLiteracyYes, rbtnHIVLiteracyNo, rbtnHIVLiteracyNA);
            hhHouseholdHomeVisit_v2. yn_hiv_counselling = utilControls.RadioButtonGetSelection(rbtnDisclosuresupportYes, rbtnDisclosuresupportNo, rbtnDisclosuresupportNA);
            hhHouseholdHomeVisit_v2. yn_hiv_adherence_support = utilControls.RadioButtonGetSelection(rbtnAdherencesupportYes, rbtnAdherencesupportNo, rbtnAdherencesupportNA);
            hhHouseholdHomeVisit_v2. yn_hiv_prevention_support = utilControls.RadioButtonGetSelection(rbtnHIVPreventionSupportYes, rbtnHIVPreventionSupportNo, rbtnHIVPreventionSupportNA);
            hhHouseholdHomeVisit_v2. yn_wash_messages = utilControls.RadioButtonGetSelection(rbtnWashYes, rbtnWashNo, rbtnWashNA);
            hhHouseholdHomeVisit_v2.nutrition_assessment_result = cboNutritionAssResult.Text;
            hhHouseholdHomeVisit_v2. yn_initiate_hts_refferal =  utilControls.RadioButtonGetSelection(rbtnHstRefferalInitiateYes, rbtnHstRefferalInitiateNo);
            hhHouseholdHomeVisit_v2. yn_complete_hts_refferal = utilControls.RadioButtonGetSelection(rbtnCompletedHtsRefferalYes, rbtnCompletedHtsRefferalNo);
            hhHouseholdHomeVisit_v2. ynna_initiate_art_refferal = utilControls.RadioButtonGetSelection(rbtnInniateARTRefferalYes, rbtnInniateARTRefferalNo);
            hhHouseholdHomeVisit_v2. ynna_complete_art_refferal = utilControls.RadioButtonGetSelection(rbtnCompleteARTRefferalYes, rbtnCompleteARTRefferalNo);
            hhHouseholdHomeVisit_v2. ynna_initiate_immunize_refferal = utilControls.RadioButtonGetSelection(rbtninnitiateImmunizaRefferalYes, rbtninnitiateImmunizaRefferalNo, rbtninnitiateImmunizaRefferalNA);
            hhHouseholdHomeVisit_v2. ynna_complete_immunize_refferal = utilControls.RadioButtonGetSelection(rbtnCompleteImmunizaRefferalYes, rbtnCompleteImmunizaRefferalNo, rbtnCompleteImmunizaRefferalNA);
            hhHouseholdHomeVisit_v2. ynna_tb_screen = utilControls.RadioButtonGetSelection(rbtnTBscreenYes, rbtnTBscreenNo, rbtnTBscreenNA);
            hhHouseholdHomeVisit_v2. ynna_initiate_tb_refferal = utilControls.RadioButtonGetSelection(rbtnInnitiateTBReferalYes, rbtnInnitiateTBReferalNo, rbtnInnitiateTBReferalNA);
            hhHouseholdHomeVisit_v2.ynna_complete_tb_refferal = utilControls.RadioButtonGetSelection(rbtnCompleteTBReferalYes, rbtnCompleteTBReferalNo, rbtnCompleteTBReferalNA);
            hhHouseholdHomeVisit_v2. ynna_initiate_perinatal_care_refferal = utilControls.RadioButtonGetSelection(rbtnInnitiatePMTCTReferalYes, rbtnInnitiatePMTCTReferalNo, rbtnInnitiatePMTCTReferalNA);
            hhHouseholdHomeVisit_v2. ynna_complete_perinatal_care_refferal = utilControls.RadioButtonGetSelection(rbtnCompletedPMTCTReferalYes, rbtnCompletedPMTCTReferalNo, rbtnCompletedPMTCTReferalNA);
            hhHouseholdHomeVisit_v2. ynna_initiate_post_violence_refferal = utilControls.RadioButtonGetSelection(rbtnInnitiatePostViolenceReferalYes, rbtnInnitiatePostViolenceReferalNo, rbtnInnitiatePostViolenceReferalNA);
            hhHouseholdHomeVisit_v2. ynna_complete_post_violence_refferal = utilControls.RadioButtonGetSelection(rbtnCompletedPostViolenceReferalYes, rbtnCompletedPostViolenceReferalNo, rbtnCompletedPostViolenceReferalNA);
            hhHouseholdHomeVisit_v2. ynna_ovc_has_birth_certificate = utilControls.RadioButtonGetSelection(rbtnBirthCertificateYes, rbtnBirthCertificateNo, rbtnBirthCertificateNA);
            hhHouseholdHomeVisit_v2. ynna_initiate_birth_reg_refferal = utilControls.RadioButtonGetSelection(rbtnInniateBirthRegReferalYes, rbtnInniateBirthRegReferalNo, rbtnInniateBirthRegReferalNA);
            hhHouseholdHomeVisit_v2. ynna_complete_birth_reg_refferal = utilControls.RadioButtonGetSelection(rbtnCompleteBirthRegReferalYes, rbtnCompleteBirthRegReferalNo, rbtnCompleteBirthRegReferalNA);
            hhHouseholdHomeVisit_v2. ynna_pss_family_group_discussion = utilControls.RadioButtonGetSelection(rbtnFamilygrpDiscusionYes, rbtnFamilygrpDiscusionNo, rbtnFamilygrpDiscusionNA);
            hhHouseholdHomeVisit_v2. ynna_reported_to_police = utilControls.RadioButtonGetSelection(rbtnReportchildAbuseYes, rbtnReportchildAbuseNo, rbtnReportchildAbuseNA);
            hhHouseholdHomeVisit_v2.ynna_violence_evidence_based_intervention = utilControls.RadioButtonGetSelection(rdnSessionCDOYes, rdnSessionCDONo, rdnSessionCDONA);
            #endregion set variables

            #region save
            hhHouseholdHomeVisit_v2.Insert_home_visit_member(dbCon);
            MessageBox.Show("Sucess","SOCY MIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
            lblguid.Text = hhHouseholdHomeVisit_v2.hhvm_id;
            #endregion save
        }
        #endregion save
    }
}
