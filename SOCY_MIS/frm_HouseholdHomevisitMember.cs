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
        int Age = 0;
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

            LoadHomevisitMembers();
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
                string hst_id = dtRow["hst_id"].ToString();

                Age = DateTime.Now.Year - Convert.ToInt32(dtRow["hhm_year_of_birth"].ToString());

                SetServicesByAgeGroup(Age);

                #region set hiv status
                if (hst_id == utilConstants.cHSTPositive )
                {
                    rbtnHHPHivPos.Checked = true;
                    pnlHHPHiv.Enabled = false;
                }
                else
                {
                    rbtnHHPHivPos.Checked = false;
                    rbtnHHPHivNeg.Checked = false;
                    rbtnHHPHivUnknown.Checked = false;
                    rbtnHHPHivTNR.Checked = false;
                    pnlHHPHiv.Enabled = true;
                }
                #endregion
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

        #region Validations
        protected void SetServicesByAgeGroup(int Age)
        {
            #region stable
            if (Age < 18)
            {
                rbtnESSilcYes.Checked = false;
                rbtnESSilcNo.Checked = false;
                rbtnESSilcNA.Checked = true;

                rbtnLendingGroupYes.Checked = false;
                rbtnLendingGroupNo.Checked = false;
                rbtnLendingGroupNA.Checked = true;

                rbtnCaregiverGroupYes.Checked = false;
                rbtnCaregiverGroupNo.Checked = false;
                rbtnCaregiverGroupNA.Checked = true;

                rbtnEdufundYes.Checked = false;
                rbtnEdufundNo.Checked = false;
                rbtnEdufundNA.Checked = true;

                pnlESSilc.Enabled = false;
                pnlOtherSavingGroup.Enabled = false;
                pnlEduFund.Enabled = false;
                pnlCaregiverServices.Enabled = false;
            }
            else
            {
                rbtnESSilcYes.Checked = false;
                rbtnESSilcNo.Checked = false;
                rbtnESSilcNA.Checked = false;

                rbtnLendingGroupYes.Checked = false;
                rbtnLendingGroupNo.Checked = false;
                rbtnLendingGroupNA.Checked = false;

                rbtnCaregiverGroupYes.Checked = false;
                rbtnCaregiverGroupNo.Checked = false;
                rbtnCaregiverGroupNA.Checked = false;

                rbtnEdufundYes.Checked = false;
                rbtnEdufundNo.Checked = false;
                rbtnEdufundNA.Checked = false;

                pnlESSilc.Enabled = true;
                pnlOtherSavingGroup.Enabled = true;
                pnlEduFund.Enabled = true;
                pnlCaregiverServices.Enabled = true;

                rbtnEdufundNA.Enabled = false;
                rbtnCaregiverGroupNA.Enabled = false;
                rbtnLendingGroupNA.Enabled = false;
                rbtnESSilcNA.Enabled = false;
            }

            if (Age < 65)
            {
                rbtnSAGEYes.Checked = false;
                rbtnSAGENo.Checked = false;
                rbtnSAGENA.Checked = true;

                pnlSAGE.Enabled = false;
            }
            else
            {
                rbtnSAGEYes.Checked = false;
                rbtnSAGENo.Checked = false;
                rbtnSAGENA.Checked = false;

                pnlSAGE.Enabled = true;
                rbtnSAGENA.Enabled = false;
            }

            if (Age < 15 || Age > 24)
            {
                rbtnApprenticeshipYes.Checked = false;
                rbtnApprenticeshipNo.Checked = false;
                rbtnApprenticeshipNA.Checked = true;

                pnlApprenticeship.Enabled = false;
            }
            else
            {
                rbtnApprenticeshipYes.Checked = false;
                rbtnApprenticeshipNo.Checked = false;
                rbtnApprenticeshipNA.Checked = false;

                pnlApprenticeship.Enabled = true;
                rbtnApprenticeshipNA.Enabled = false;
            }

            if (Age < 15)
            {
                rbtnCottageYes.Checked = false;
                rbtnCottageNo.Checked = false;
                rbtnCottageNA.Checked = true;

                rbtnAggroYes.Checked = false;
                rbtnAggroNo.Checked = false;
                rbtnAggroNA.Checked = true;

                pnlCottage.Enabled = false;
                pnlAggro.Enabled = false;

            }
            else
            {
                rbtnCottageYes.Checked = false;
                rbtnCottageNo.Checked = false;
                rbtnCottageNA.Checked = false;

                rbtnAggroYes.Checked = false;
                rbtnAggroNo.Checked = false;
                rbtnAggroNA.Checked = false;

                pnlCottage.Enabled = true;
                pnlCottage.Enabled = true;
                rbtnCottageNA.Enabled = false;
                rbtnAggroNA.Enabled = false;
            }

            if (Age < 15 || Age > 18)
            {
                rbtnAflateenYes.Checked = false;
                rbtnAflateenNo.Checked = false;
                rbtnAflateenNA.Checked = true;

                pnlAflateen.Enabled = false;
            }
            else
            {
                rbtnAflateenYes.Checked = false;
                rbtnAflateenNo.Checked = false;
                rbtnAflateenNA.Checked = false;

                pnlAflateen.Enabled = true;
                rbtnAflateenNA.Enabled = false;
            }
            #endregion stable

            #region Schooled
            if (Age < 6 || Age > 20)
            {
                rbtnOvcEduEnrolledYes.Checked = false;
                rbtnOvcEduEnrolledNo.Checked = false;
                rbtnOvcEduEnrolledNA.Checked = true;

                rbtnAssReEnrollmentYes.Checked = false;
                rbtnAssReEnrollmentNo.Checked = false;
                rbtnAssReEnrollmentNA.Checked = true;

                rbtnRegularAttendschoolYes.Checked = false;
                rbtnRegularAttendschoolNo.Checked = false;
                rbtnRegularAttendschoolNA.Checked = true;

                rbtnUniformYes.Checked = false;
                rbtnUniformNo.Checked = false;
                rbtnUniformNA.Checked = true;

                rbtnEduSubsidyYes.Checked = false;
                rbtnEduSubsidyNo.Checked = false;
                rbtnEduSubsidyNA.Checked = true;

                rbtnProgressedYes.Checked = false;
                rbtnProgressedNo.Checked = false;
                rbtnProgressedNA.Checked = true;

                pnlEnrolledInSchool.Enabled = false;
                pnlEnrollmentAssistance.Enabled = false;
                pnlRegularlyAttendSchool.Enabled = false;
                pnlSchoolUniform.Enabled = false;
                pnlEduSubsidy.Enabled = false;
                pnlSchoolProgress.Enabled = false;
            }
            else
            {
                rbtnOvcEduEnrolledYes.Checked = false;
                rbtnOvcEduEnrolledNo.Checked = false;
                rbtnOvcEduEnrolledNA.Checked = false;

                rbtnAssReEnrollmentYes.Checked = false;
                rbtnAssReEnrollmentNo.Checked = false;
                rbtnAssReEnrollmentNA.Checked = false;

                rbtnRegularAttendschoolYes.Checked = false;
                rbtnRegularAttendschoolNo.Checked = false;
                rbtnRegularAttendschoolNA.Checked = false;

                rbtnUniformYes.Checked = false;
                rbtnUniformNo.Checked = false;
                rbtnUniformNA.Checked = false;

                rbtnEduSubsidyYes.Checked = false;
                rbtnEduSubsidyNo.Checked = false;
                rbtnEduSubsidyNA.Checked = false;

                rbtnProgressedYes.Checked = false;
                rbtnProgressedNo.Checked = false;
                rbtnProgressedNA.Checked = false;

                pnlEnrolledInSchool.Enabled = true;
                pnlEnrollmentAssistance.Enabled = true;
                pnlRegularlyAttendSchool.Enabled = true;
                pnlSchoolUniform.Enabled = true;
                pnlEduSubsidy.Enabled = true;
                pnlSchoolProgress.Enabled = true;

                rbtnOvcEduEnrolledNA.Enabled = false;
                rbtnAssReEnrollmentNA.Enabled = false;
                rbtnRegularAttendschoolNA.Enabled = false;
                rbtnUniformNA.Enabled = false;
                rbtnEduSubsidyNA.Enabled = false;
                rbtnProgressedNA.Enabled = false;
            }
            #endregion Schooled

            #region Healthy
            if (Age > 17)
            {
                rbtnHIVLiteracyYes.Checked = false;
                rbtnHIVLiteracyNo.Checked = false;
                rbtnHIVLiteracyNA.Checked = true;

                pnlHIVLiteracy.Enabled = false;
            }
            else
            {
                rbtnHIVLiteracyYes.Checked = false;
                rbtnHIVLiteracyNo.Checked = false;
                rbtnHIVLiteracyNA.Checked = false;

                pnlHIVLiteracy.Enabled = true;
                rbtnHIVLiteracyNA.Enabled = false;
            }

            if (Age < 10 || Age > 17)
            {
                rbtnHIVPreventionSupportYes.Checked = false;
                rbtnHIVPreventionSupportNo.Checked = false;
                rbtnHIVPreventionSupportNA.Checked = true;

                pnlHIVPreventionSupport.Enabled = false;
            }
            else
            {
                rbtnHIVPreventionSupportYes.Checked = false;
                rbtnHIVPreventionSupportNo.Checked = false;
                rbtnHIVPreventionSupportNA.Checked = false;

                pnlHIVPreventionSupport.Enabled = true;
                rbtnHIVPreventionSupportNA.Enabled = false;
            }

            if (Age > 5)
            {
                cboNutritionAssResult.Enabled = false;
                rbtninnitiateImmunizaRefferalYes.Checked = false;
                rbtninnitiateImmunizaRefferalNo.Checked = false;
                rbtninnitiateImmunizaRefferalNA.Checked = true;
                cboNutritionAssResult.Text = "NA";

                pnlImmunization.Enabled = false;
            }
            else
            {
                cboNutritionAssResult.Enabled = true;
                cboNutritionAssResult.Text = string.Empty;

                rbtninnitiateImmunizaRefferalYes.Checked = false;
                rbtninnitiateImmunizaRefferalNo.Checked = false;
                rbtninnitiateImmunizaRefferalNA.Checked = false;

                pnlImmunization.Enabled = true;
                rbtninnitiateImmunizaRefferalNA.Enabled = false;
            }

            if (Age < 10)
            {
                rbtnTBscreenYes.Checked = false;
                rbtnTBscreenNo.Checked = false;
                rbtnTBscreenNA.Checked = true;

                rbtnInnitiateTBReferalYes.Checked = false;
                rbtnInnitiateTBReferalNo.Checked = false;
                rbtnInnitiateTBReferalNA.Checked = true;

                rbtnCompleteTBReferalYes.Checked = false;
                rbtnCompleteTBReferalNo.Checked = false;
                rbtnCompleteTBReferalNA.Checked = true;

                pnlTBscreen.Enabled = false;
                pnlTBInnitiateReferal.Enabled = false;
                pnlTBCompletedReferal.Enabled = false;

            }
            else
            {
                rbtnTBscreenYes.Checked = false;
                rbtnTBscreenNo.Checked = false;
                rbtnTBscreenNA.Checked = false;

                rbtnInnitiateTBReferalYes.Checked = false;
                rbtnInnitiateTBReferalNo.Checked = false;
                rbtnInnitiateTBReferalNA.Checked = false;

                rbtnCompleteTBReferalYes.Checked = false;
                rbtnCompleteTBReferalNo.Checked = false;
                rbtnCompleteTBReferalNA.Checked = false;

                pnlTBscreen.Enabled = true;
                pnlTBInnitiateReferal.Enabled = true;
                pnlTBCompletedReferal.Enabled = true;

                rbtnTBscreenNA.Enabled = false;
                rbtnInnitiateTBReferalNA.Enabled = false;
                rbtnCompleteTBReferalNA.Enabled = false;
            }

            if (Age >= 18 && lblGenderDisplay.Text == "Female")
            {
                rbtnInnitiatePMTCTReferalNA.Enabled = false;
                rbtnInnitiatePMTCTReferalNA.Checked = false;
                rbtnCompletedPMTCTReferalNA.Checked = false;
                rbtnCompletedPMTCTReferalNA.Enabled = false;

                pnlPerinatalInitiateReferal.Enabled = true;
                pnlPerinatalCompleteReferal.Enabled = true;
            }
            else
            {
                rbtnInnitiatePMTCTReferalYes.Checked = false;
                rbtnInnitiatePMTCTReferalNo.Checked = false;
                rbtnInnitiatePMTCTReferalNA.Checked = true;

                rbtnCompletedPMTCTReferalYes.Checked = false;
                rbtnCompletedPMTCTReferalNo.Checked = false;
                rbtnCompletedPMTCTReferalNA.Checked = true;

                pnlPerinatalInitiateReferal.Enabled = false;
                pnlPerinatalCompleteReferal.Enabled = false;
            }

            #endregion Healthy

            #region Safe
            if (Age > 17)
            {
                rbtnInnitiatePostViolenceReferalYes.Checked = false;
                rbtnInnitiatePostViolenceReferalNo.Checked = false;
                rbtnInnitiatePostViolenceReferalNA.Checked = true;

                rbtnCompletedPostViolenceReferalYes.Checked = false;
                rbtnCompletedPostViolenceReferalNo.Checked = false;
                rbtnCompletedPostViolenceReferalNA.Checked = true;

                rbtnBirthCertificateYes.Checked = false;
                rbtnBirthCertificateNo.Checked = false;

                rbtnInniateBirthRegReferalYes.Checked = false;
                rbtnInniateBirthRegReferalNo.Checked = false;
                rbtnInniateBirthRegReferalNA.Checked = true;

                rbtnCompleteBirthRegReferalYes.Checked = false;
                rbtnCompleteBirthRegReferalNo.Checked = false;
                rbtnCompleteBirthRegReferalNA.Checked = true;

                rbtnFamilygrpDiscusionYes.Checked = false;
                rbtnFamilygrpDiscusionNo.Checked = false;
                rbtnFamilygrpDiscusionNA.Checked = true;

                rbtnReportchildAbuseYes.Checked = false;
                rbtnReportchildAbuseNo.Checked = false;
                rbtnReportchildAbuseNA.Checked = true;

                rdnSessionCDOYes.Checked = false;
                rdnSessionCDONo.Checked = false;
                rdnSessionCDONA.Checked = true;

                pnlPostViolenceInnitiateReferal.Enabled = false;
                pnlPostViolenceCompletedReferal.Enabled = false;
                pnlBirthCertificate.Enabled = false;
                pnlBirthRegInnitiateReferal.Enabled = false;
                pnlBirthRegCompleteReferal.Enabled = false;
                pnlFamilyGroupDiscussion.Enabled = false;
                pnlReportChildAbuse.Enabled = false;
                pnlSessionCDO.Enabled = false;
            }
            else
            {
                rbtnInnitiatePostViolenceReferalYes.Checked = false;
                rbtnInnitiatePostViolenceReferalNo.Checked = false;
                rbtnInnitiatePostViolenceReferalNA.Checked = false;

                rbtnCompletedPostViolenceReferalYes.Checked = false;
                rbtnCompletedPostViolenceReferalNo.Checked = false;
                rbtnCompletedPostViolenceReferalNA.Checked = false;

                rbtnBirthCertificateYes.Checked = false;
                rbtnBirthCertificateNo.Checked = false;

                rbtnInniateBirthRegReferalYes.Checked = false;
                rbtnInniateBirthRegReferalNo.Checked = false;
                rbtnInniateBirthRegReferalNA.Checked = false;

                rbtnCompleteBirthRegReferalYes.Checked = false;
                rbtnCompleteBirthRegReferalNo.Checked = false;
                rbtnCompleteBirthRegReferalNA.Checked = false;

                rbtnFamilygrpDiscusionYes.Checked = false;
                rbtnFamilygrpDiscusionNo.Checked = false;
                rbtnFamilygrpDiscusionNA.Checked = false;

                rbtnReportchildAbuseYes.Checked = false;
                rbtnReportchildAbuseNo.Checked = false;
                rbtnReportchildAbuseNA.Checked = false;

                rdnSessionCDOYes.Checked = false;
                rdnSessionCDONo.Checked = false;
                rdnSessionCDONA.Checked = false;

                pnlPostViolenceInnitiateReferal.Enabled = true;
                pnlPostViolenceCompletedReferal.Enabled = true;
                pnlBirthCertificate.Enabled = true;
                pnlBirthRegInnitiateReferal.Enabled = true;
                pnlBirthRegCompleteReferal.Enabled = true;
                pnlFamilyGroupDiscussion.Enabled = true;
                pnlReportChildAbuse.Enabled = true;
                pnlSessionCDO.Enabled = true;

                //rbtnInnitiatePostViolenceReferalNA.Enabled = false;
                //rbtnCompletedPostViolenceReferalNA.Enabled = false;
                //rbtnInniateBirthRegReferalNA.Enabled = false;
                //rbtnCompleteBirthRegReferalNA.Enabled = false;
                //rbtnFamilygrpDiscusionNA.Enabled = false;
                //rbtnReportchildAbuseNA.Enabled = false;
                //rdnSessionCDONA.Enabled = false;
            }
            #endregion Safe
        }
        #endregion Validations


        #region save
        protected void save()
        {
            DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);

            #region set variables
            hhHouseholdHomeVisit_v2.hhvm_id = Guid.NewGuid().ToString();
            hhHouseholdHomeVisit_v2.hhv_id = SystemConstants.object_id;
            hhHouseholdHomeVisit_v2.hhm_id = cbHHMember.SelectedValue.ToString();
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
            hhHouseholdHomeVisit_v2. ynna_ovc_has_birth_certificate = utilControls.RadioButtonGetSelection(rbtnBirthCertificateYes, rbtnBirthCertificateNo);
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
            LoadMembers();
            LoadHomevisitMembers();

            Clear();
            #endregion save
        }
        #endregion save

        protected void Clear()
        {
            hhHouseholdHomeVisit_v2.hhvm_id = string.Empty;
            hhHouseholdHomeVisit_v2.hhv_id = string.Empty;
            hhHouseholdHomeVisit_v2.hhm_id = string.Empty;
            cbHHMember.SelectedValue = "-1";
            hhHouseholdHomeVisit_v2.hhm_name = string.Empty;
            hhHouseholdHomeVisit_v2.hmm_age = string.Empty;
            lblYearOfBirthDisplay.Text = "Age";
            hhHouseholdHomeVisit_v2.gnd_name = string.Empty;
            lblGenderDisplay.Text = "Sex:";
            hhHouseholdHomeVisit_v2.yn_id_hhm_active = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnMemberActiveYes, rbtnMemberActiveNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_id_SILC = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnESSilcYes, rbtnESSilcNo, rbtnESSilcNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_id_other_saving_grp = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnLendingGroupYes, rbtnLendingGroupNo, rbtnLendingGroupNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_caregiver_services = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCaregiverGroupYes, rbtnCaregiverGroupNo, rbtnCaregiverGroupNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_contributes_edu_fund = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnEdufundYes, rbtnEdufundNo, rbtnEdufundNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_SAGE = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnSAGEYes, rbtnSAGENo, rbtnSAGENA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_stb_receive_social_grant = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnFoodBankYes, rbtnFoodBankNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_apprenticeship = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnApprenticeshipYes, rbtnApprenticeshipNo, rbtnApprenticeshipNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_cottage = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCottageYes, rbtnCottageNo, rbtnCottageNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_agro_enterprise = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAggroYes, rbtnAggroNo, rbtnAggroNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_aflateen = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAflateenYes, rbtnAflateenNo, rbtnAflateenNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_sch_ovc_edu_enrolled = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnOvcEduEnrolledYes, rbtnOvcEduEnrolledNo, rbtnOvcEduEnrolledNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_re_enrollment_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAssReEnrollmentYes, rbtnAssReEnrollmentNo, rbtnAssReEnrollmentNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_attend_school_regularly = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnRegularAttendschoolYes, rbtnRegularAttendschoolNo, rbtnRegularAttendschoolNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_receive_school_uniform = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnUniformYes, rbtnUniformNo, rbtnUniformNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_receive_edu_subsidy = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnEduSubsidyYes, rbtnEduSubsidyNo, rbtnEduSubsidyNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_progressed_to_another_class = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnProgressedYes, rbtnProgressedNo, rbtnProgressedNA, string.Empty);
            hhHouseholdHomeVisit_v2.hst_id = string.Empty;
            rbtnHHPHivPos.Checked = false;
            rbtnHHPHivNeg.Checked = false;
            rbtnHHPHivUnknown.Checked = false;
            rbtnHHPHivTNR.Checked = false;
            hhHouseholdHomeVisit_v2.ynna_on_art = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnARTYes, rbtnARTNo, rbtnARTNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_follow_art_prescription = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnPillsYes, rbtnPillsNo, rbtnPillsNA, string.Empty);
            cboAherenceLevel.Text = string.Empty;
            hhHouseholdHomeVisit_v2.adherence_level = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_hiv_literacy = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHIVLiteracyYes, rbtnHIVLiteracyNo, rbtnHIVLiteracyNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_counselling = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnDisclosuresupportYes, rbtnDisclosuresupportNo, rbtnDisclosuresupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_adherence_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAdherencesupportYes, rbtnAdherencesupportNo, rbtnAdherencesupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_prevention_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHIVPreventionSupportYes, rbtnHIVPreventionSupportNo, rbtnHIVPreventionSupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_wash_messages = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnWashYes, rbtnWashNo, rbtnWashNA, string.Empty);
            cboNutritionAssResult.Text = string.Empty;
            hhHouseholdHomeVisit_v2.nutrition_assessment_result = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHstRefferalInitiateYes, rbtnHstRefferalInitiateNo, string.Empty);
            hhHouseholdHomeVisit_v2.yn_initiate_hts_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedHtsRefferalYes, rbtnCompletedHtsRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.yn_complete_hts_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInniateARTRefferalYes, rbtnInniateARTRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_art_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteARTRefferalYes, rbtnCompleteARTRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_art_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtninnitiateImmunizaRefferalYes, rbtninnitiateImmunizaRefferalNo, rbtninnitiateImmunizaRefferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_immunize_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteImmunizaRefferalYes, rbtnCompleteImmunizaRefferalNo, rbtnCompleteImmunizaRefferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_immunize_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnTBscreenYes, rbtnTBscreenNo, rbtnTBscreenNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_tb_screen = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInnitiateTBReferalYes, rbtnInnitiateTBReferalNo, rbtnInnitiateTBReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_tb_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteTBReferalYes, rbtnCompleteTBReferalNo, rbtnCompleteTBReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_tb_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInnitiatePMTCTReferalYes, rbtnInnitiatePMTCTReferalNo, rbtnInnitiatePMTCTReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_perinatal_care_refferal = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_complete_perinatal_care_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedPMTCTReferalYes, rbtnCompletedPMTCTReferalNo, rbtnCompletedPMTCTReferalNA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtnInnitiatePostViolenceReferalYes, rbtnInnitiatePostViolenceReferalNo, rbtnInnitiatePostViolenceReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_post_violence_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedPostViolenceReferalYes, rbtnCompletedPostViolenceReferalNo, rbtnCompletedPostViolenceReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_post_violence_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnBirthCertificateYes, rbtnBirthCertificateNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_ovc_has_birth_certificate = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInniateBirthRegReferalYes, rbtnInniateBirthRegReferalNo, rbtnInniateBirthRegReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_birth_reg_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteBirthRegReferalYes, rbtnCompleteBirthRegReferalNo, rbtnCompleteBirthRegReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_birth_reg_refferal = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_pss_family_group_discussion = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnFamilygrpDiscusionYes, rbtnFamilygrpDiscusionNo, rbtnFamilygrpDiscusionNA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtnReportchildAbuseYes, rbtnReportchildAbuseNo, rbtnReportchildAbuseNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_reported_to_police = string.Empty;
            utilControls.RadioButtonSetSelection(rdnSessionCDOYes, rdnSessionCDONo, rdnSessionCDONA, string.Empty);

            pnlESSilc.Enabled = true;
            pnlOtherSavingGroup.Enabled = true;
            pnlEduFund.Enabled = true;
            pnlCaregiverServices.Enabled = true;
            pnlSAGE.Enabled = true;
            rbtnSAGENA.Enabled = true;
            pnlApprenticeship.Enabled = true;
            rbtnApprenticeshipNA.Enabled = true;
            pnlCottage.Enabled = true;
            pnlCottage.Enabled = true;
            rbtnCottageNA.Enabled = true;
            rbtnAggroNA.Enabled = true;
            pnlAflateen.Enabled = true;
            rbtnAflateenNA.Enabled = true;
            pnlEnrolledInSchool.Enabled = true;
            pnlEnrollmentAssistance.Enabled = true;
            pnlRegularlyAttendSchool.Enabled = true;
            pnlSchoolUniform.Enabled = true;
            pnlEduSubsidy.Enabled = true;
            pnlSchoolProgress.Enabled = true;
            pnlHIVLiteracy.Enabled = true;
            pnlHIVPreventionSupport.Enabled = true;
            pnlImmunization.Enabled = true;
            pnlTBscreen.Enabled = true;
            pnlTBInnitiateReferal.Enabled = true;
            pnlTBCompletedReferal.Enabled = true;
            pnlPerinatalInitiateReferal.Enabled = true;
            pnlPerinatalCompleteReferal.Enabled = true;
            pnlPostViolenceInnitiateReferal.Enabled = true;
            pnlPostViolenceCompletedReferal.Enabled = true;
            pnlBirthCertificate.Enabled = true;
            pnlBirthRegInnitiateReferal.Enabled = true;
            pnlBirthRegCompleteReferal.Enabled = true;
            pnlFamilyGroupDiscussion.Enabled = true;
            pnlReportChildAbuse.Enabled = true;
            pnlSessionCDO.Enabled = true;
            cboNutritionAssResult.Enabled = true;

            rbtnEdufundNA.Enabled = true;
            rbtnCaregiverGroupNA.Enabled = true;
            rbtnLendingGroupNA.Enabled = true;
            rbtnESSilcNA.Enabled = true;
            rbtnSAGENA.Enabled = true;
            rbtnApprenticeshipNA.Enabled = true;
            rbtnCottageNA.Enabled = true;
            rbtnAflateenNA.Enabled = true;
            rbtnOvcEduEnrolledNA.Enabled = true;
            rbtnAssReEnrollmentNA.Enabled = true;
            rbtnRegularAttendschoolNA.Enabled = true;
            rbtnUniformNA.Enabled = true;
            rbtnEduSubsidyNA.Enabled = true;
            rbtnProgressedNA.Enabled = true;
            rbtnHIVLiteracyNA.Enabled = true;
            rbtnHIVPreventionSupportNA.Enabled = true;
            rbtninnitiateImmunizaRefferalNA.Enabled = true;
            rbtnTBscreenNA.Enabled = true;
            rbtnInnitiateTBReferalNA.Enabled = true;
            rbtnCompleteTBReferalNA.Enabled = true;
            rbtnCompletedPMTCTReferalNA.Enabled = true;
            rbtnInnitiatePMTCTReferalNA.Enabled = true;
            rbtnInnitiatePostViolenceReferalNA.Enabled = true;
            rbtnCompletedPostViolenceReferalNA.Enabled = true;
            rbtnInniateBirthRegReferalNA.Enabled = true;
            rbtnCompleteBirthRegReferalNA.Enabled = true;
            rbtnFamilygrpDiscusionNA.Enabled = true;
            rbtnReportchildAbuseNA.Enabled = true;
            rdnSessionCDONA.Enabled = true;
        }

        protected void LoadHomevisitMembers()
        {
            dt = hhHouseholdHomeVisit_v2.LoadHomeVisitMembers(SystemConstants.object_id);
            if (dt.Rows.Count > 0)
            {
                dgvMembers.DataSource = dt;
                dgvMembers.Columns["hhm_number"].HeaderText = "Member Number";
                dgvMembers.Columns["hhm_first_name"].HeaderText = "First Name";
                dgvMembers.Columns["hhm_last_name"].HeaderText = "Last Name";
                dgvMembers.Columns["gnd_name"].HeaderText = "Sex";
                dgvMembers.Columns["hhm_year_of_birth"].HeaderText = "Year of Birth";
                dgvMembers.Columns["hhvm_id"].Visible = !Visible;

                dgvMembers.DefaultCellStyle.SelectionBackColor = Color.White;
                dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvMembers.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvMembers.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                dgvMembers.DefaultCellStyle.SelectionBackColor = Color.White;
                dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;

                dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                dgvMembers.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in dgvMembers.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

            
        protected void LoadHouseholdHomevisitMemberDisplay(string hhvm_id)
        {
            dt = hhHouseholdHomeVisit_v2.LoadHomeVisitMemberDetails(hhvm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

            }
        }



        protected void ClearInactiveMember()
        {
            hhHouseholdHomeVisit_v2.ynna_stb_id_SILC = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnESSilcYes, rbtnESSilcNo, rbtnESSilcNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_id_other_saving_grp = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnLendingGroupYes, rbtnLendingGroupNo, rbtnLendingGroupNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_caregiver_services = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCaregiverGroupYes, rbtnCaregiverGroupNo, rbtnCaregiverGroupNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_contributes_edu_fund = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnEdufundYes, rbtnEdufundNo, rbtnEdufundNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_SAGE = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnSAGEYes, rbtnSAGENo, rbtnSAGENA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_stb_receive_social_grant = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnFoodBankYes, rbtnFoodBankNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_apprenticeship = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnApprenticeshipYes, rbtnApprenticeshipNo, rbtnApprenticeshipNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_cottage = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCottageYes, rbtnCottageNo, rbtnCottageNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_agro_enterprise = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAggroYes, rbtnAggroNo, rbtnAggroNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_aflateen = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAflateenYes, rbtnAflateenNo, rbtnAflateenNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_stb_sch_ovc_edu_enrolled = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnOvcEduEnrolledYes, rbtnOvcEduEnrolledNo, rbtnOvcEduEnrolledNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_re_enrollment_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAssReEnrollmentYes, rbtnAssReEnrollmentNo, rbtnAssReEnrollmentNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_attend_school_regularly = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnRegularAttendschoolYes, rbtnRegularAttendschoolNo, rbtnRegularAttendschoolNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_receive_school_uniform = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnUniformYes, rbtnUniformNo, rbtnUniformNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_sch_ovc_receive_edu_subsidy = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnEduSubsidyYes, rbtnEduSubsidyNo, rbtnEduSubsidyNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_progressed_to_another_class = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnProgressedYes, rbtnProgressedNo, rbtnProgressedNA, string.Empty);
            hhHouseholdHomeVisit_v2.hst_id = string.Empty;
            rbtnHHPHivPos.Checked = false;
            rbtnHHPHivNeg.Checked = false;
            rbtnHHPHivUnknown.Checked = false;
            rbtnHHPHivTNR.Checked = false;
            hhHouseholdHomeVisit_v2.ynna_on_art = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnARTYes, rbtnARTNo, rbtnARTNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_follow_art_prescription = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnPillsYes, rbtnPillsNo, rbtnPillsNA, string.Empty);
            cboAherenceLevel.Text = string.Empty;
            hhHouseholdHomeVisit_v2.adherence_level = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_hiv_literacy = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHIVLiteracyYes, rbtnHIVLiteracyNo, rbtnHIVLiteracyNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_counselling = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnDisclosuresupportYes, rbtnDisclosuresupportNo, rbtnDisclosuresupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_adherence_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnAdherencesupportYes, rbtnAdherencesupportNo, rbtnAdherencesupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_hiv_prevention_support = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHIVPreventionSupportYes, rbtnHIVPreventionSupportNo, rbtnHIVPreventionSupportNA, string.Empty);
            hhHouseholdHomeVisit_v2.yn_wash_messages = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnWashYes, rbtnWashNo, rbtnWashNA, string.Empty);
            cboNutritionAssResult.Text = string.Empty;
            hhHouseholdHomeVisit_v2.nutrition_assessment_result = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnHstRefferalInitiateYes, rbtnHstRefferalInitiateNo, string.Empty);
            hhHouseholdHomeVisit_v2.yn_initiate_hts_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedHtsRefferalYes, rbtnCompletedHtsRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.yn_complete_hts_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInniateARTRefferalYes, rbtnInniateARTRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_art_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteARTRefferalYes, rbtnCompleteARTRefferalNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_art_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtninnitiateImmunizaRefferalYes, rbtninnitiateImmunizaRefferalNo, rbtninnitiateImmunizaRefferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_immunize_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteImmunizaRefferalYes, rbtnCompleteImmunizaRefferalNo, rbtnCompleteImmunizaRefferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_immunize_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnTBscreenYes, rbtnTBscreenNo, rbtnTBscreenNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_tb_screen = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInnitiateTBReferalYes, rbtnInnitiateTBReferalNo, rbtnInnitiateTBReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_tb_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteTBReferalYes, rbtnCompleteTBReferalNo, rbtnCompleteTBReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_tb_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInnitiatePMTCTReferalYes, rbtnInnitiatePMTCTReferalNo, rbtnInnitiatePMTCTReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_perinatal_care_refferal = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_complete_perinatal_care_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedPMTCTReferalYes, rbtnCompletedPMTCTReferalNo, rbtnCompletedPMTCTReferalNA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtnInnitiatePostViolenceReferalYes, rbtnInnitiatePostViolenceReferalNo, rbtnInnitiatePostViolenceReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_post_violence_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompletedPostViolenceReferalYes, rbtnCompletedPostViolenceReferalNo, rbtnCompletedPostViolenceReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_post_violence_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnBirthCertificateYes, rbtnBirthCertificateNo, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_ovc_has_birth_certificate = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnInniateBirthRegReferalYes, rbtnInniateBirthRegReferalNo, rbtnInniateBirthRegReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_initiate_birth_reg_refferal = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnCompleteBirthRegReferalYes, rbtnCompleteBirthRegReferalNo, rbtnCompleteBirthRegReferalNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_complete_birth_reg_refferal = string.Empty;
            hhHouseholdHomeVisit_v2.ynna_pss_family_group_discussion = string.Empty;
            utilControls.RadioButtonSetSelection(rbtnFamilygrpDiscusionYes, rbtnFamilygrpDiscusionNo, rbtnFamilygrpDiscusionNA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtnReportchildAbuseYes, rbtnReportchildAbuseNo, rbtnReportchildAbuseNA, string.Empty);
            hhHouseholdHomeVisit_v2.ynna_reported_to_police = string.Empty;
            utilControls.RadioButtonSetSelection(rdnSessionCDOYes, rdnSessionCDONo, rdnSessionCDONA, string.Empty);

            pnlESSilc.Enabled = true;
            pnlOtherSavingGroup.Enabled = true;
            pnlEduFund.Enabled = true;
            pnlCaregiverServices.Enabled = true;
            pnlSAGE.Enabled = true;
            rbtnSAGENA.Enabled = true;
            pnlApprenticeship.Enabled = true;
            rbtnApprenticeshipNA.Enabled = true;
            pnlCottage.Enabled = true;
            pnlCottage.Enabled = true;
            rbtnCottageNA.Enabled = true;
            rbtnAggroNA.Enabled = true;
            pnlAflateen.Enabled = true;
            rbtnAflateenNA.Enabled = true;
            pnlEnrolledInSchool.Enabled = true;
            pnlEnrollmentAssistance.Enabled = true;
            pnlRegularlyAttendSchool.Enabled = true;
            pnlSchoolUniform.Enabled = true;
            pnlEduSubsidy.Enabled = true;
            pnlSchoolProgress.Enabled = true;
            pnlHIVLiteracy.Enabled = true;
            pnlHIVPreventionSupport.Enabled = true;
            pnlImmunization.Enabled = true;
            pnlTBscreen.Enabled = true;
            pnlTBInnitiateReferal.Enabled = true;
            pnlTBCompletedReferal.Enabled = true;
            pnlPerinatalInitiateReferal.Enabled = true;
            pnlPerinatalCompleteReferal.Enabled = true;
            pnlPostViolenceInnitiateReferal.Enabled = true;
            pnlPostViolenceCompletedReferal.Enabled = true;
            pnlBirthCertificate.Enabled = true;
            pnlBirthRegInnitiateReferal.Enabled = true;
            pnlBirthRegCompleteReferal.Enabled = true;
            pnlFamilyGroupDiscussion.Enabled = true;
            pnlReportChildAbuse.Enabled = true;
            pnlSessionCDO.Enabled = true;
            cboNutritionAssResult.Enabled = true;

            rbtnEdufundNA.Enabled = true;
            rbtnCaregiverGroupNA.Enabled = true;
            rbtnLendingGroupNA.Enabled = true;
            rbtnESSilcNA.Enabled = true;
            rbtnSAGENA.Enabled = true;
            rbtnApprenticeshipNA.Enabled = true;
            rbtnCottageNA.Enabled = true;
            rbtnAflateenNA.Enabled = true;
            rbtnOvcEduEnrolledNA.Enabled = true;
            rbtnAssReEnrollmentNA.Enabled = true;
            rbtnRegularAttendschoolNA.Enabled = true;
            rbtnUniformNA.Enabled = true;
            rbtnEduSubsidyNA.Enabled = true;
            rbtnProgressedNA.Enabled = true;
            rbtnHIVLiteracyNA.Enabled = true;
            rbtnHIVPreventionSupportNA.Enabled = true;
            rbtninnitiateImmunizaRefferalNA.Enabled = true;
            rbtnTBscreenNA.Enabled = true;
            rbtnInnitiateTBReferalNA.Enabled = true;
            rbtnCompleteTBReferalNA.Enabled = true;
            rbtnCompletedPMTCTReferalNA.Enabled = true;
            rbtnInnitiatePMTCTReferalNA.Enabled = true;
            rbtnInnitiatePostViolenceReferalNA.Enabled = true;
            rbtnCompletedPostViolenceReferalNA.Enabled = true;
            rbtnInniateBirthRegReferalNA.Enabled = true;
            rbtnCompleteBirthRegReferalNA.Enabled = true;
            rbtnFamilygrpDiscusionNA.Enabled = true;
            rbtnReportchildAbuseNA.Enabled = true;
            rdnSessionCDONA.Enabled = true;

            tlpDisplay02.Enabled = false;
            tlpDisplay03.Enabled = false;
            tlpDisplay04.Enabled = false;
            tlpDisplay05.Enabled = false;
        }

        private void rbtnHHPHivPos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHHPHivPos.Checked == true)
            {
                pnlART.Enabled = true;
                rbtnARTNA.Checked = false;
                rbtnARTNA.Enabled = false;
                lblART.ForeColor = Color.Red;
            }
            else
            {
                pnlART.Enabled = false;
                rbtnARTNA.Checked = true;
                lblART.ForeColor = Color.Black;
            }
        }

        private void rbtnARTYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnARTYes.Checked == true)
            {
                rbtnPillsNA.Enabled = false;
                rbtnPillsNA.Checked = false;
                pnlPills.Enabled = true;

                cboAherenceLevel.Enabled = true;
                cboAherenceLevel.Text = string.Empty;

                lblPills.ForeColor = Color.Red;
                lblAdherence.ForeColor = Color.Red;
            }
            else
            {
                rbtnPillsNA.Enabled = false;
                rbtnPillsNA.Checked = true;
                pnlPills.Enabled = false;

                cboAherenceLevel.Enabled = false;
                cboAherenceLevel.Text = string.Empty;

                lblPills.ForeColor = Color.Black;
                lblAdherence.ForeColor = Color.Black;
            }
        }

        private void rbtnMemberActiveYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMemberActiveYes.Checked == false)
            {
                ClearInactiveMember();
            }
            else
            {
                tlpDisplay02.Enabled = true;
                tlpDisplay03.Enabled = true;
                tlpDisplay04.Enabled = true;
                tlpDisplay05.Enabled = true;

                SetServicesByAgeGroup(Age);
            }
        }

        private void rbtnBirthCertificateYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBirthCertificateYes.Checked == true)
            {
                pnlBirthRegInnitiateReferal.Enabled = false;
                rbtnInniateBirthRegReferalNA.Checked = true;

                pnlBirthRegCompleteReferal.Enabled = false;
                rbtnCompleteBirthRegReferalNA.Checked = true;
            }
            else
            {
                pnlBirthRegInnitiateReferal.Enabled = true;
                rbtnInniateBirthRegReferalNA.Checked = false;

                pnlBirthRegCompleteReferal.Enabled = true;
                rbtnCompleteBirthRegReferalNA.Checked = false;
            }
        }
    }
}
