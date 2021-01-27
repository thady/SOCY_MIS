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
    public partial class frmHouseholdTransferTool : UserControl
    {
        #region Variables
        private frmHouseholdTransferSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = new DataTable();
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        private string UsrMessage = string.Empty;
        #endregion Variables

        #region Property
        public frmHouseholdTransferSearch FormCallingSearch
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
        #endregion Property

        public frmHouseholdTransferTool()
        {
            InitializeComponent();
        }

        private void frmHouseholdTransferTool_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadRecordDetails(HouseholdTransfer.hh_tr_id);
        }

        protected void Return_lookups()
        {
            #region districts
            dt = silcCommunityTrainingRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty, string.Empty); //reused

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["dst_id"] = "-1";
            dstemptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion districts

            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";

            cboSubCounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCounty.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion subcounty

            #region IP
            dt = silcCommunityTrainingRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow IPemptyRow = dt.NewRow();
            IPemptyRow["prt_id"] = "-1";
            IPemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(IPemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";

            cboIP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboIP.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion IP

            #region CSO
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow CsoemptyRow = dt.NewRow();
            CsoemptyRow["cso_id"] = "-1";
            CsoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(CsoemptyRow, 0);

            cbocso.DataSource = dt;
            cbocso.DisplayMember = "cso_other";
            cbocso.ValueMember = "cso_id";

            cbocso.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocso.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion CSO
        }

        protected void ReturnSocialWorkers()
        {
            #region Social Workers
            dt = benEducationSubsidy.Return_SocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString(), "SW");  //reused
            DataRow emptyRow = dt.NewRow();
            emptyRow["swk_id"] = "-1";
            emptyRow["swk_name"] = "Select Social Worker";
            dt.Rows.InsertAt(emptyRow, 0);

            cboSocialWorker.DataSource = dt;
            cboSocialWorker.ValueMember = "swk_id";
            cboSocialWorker.DisplayMember = "swk_name";

            cboSocialWorker.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSocialWorker.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion  Social Workers
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                save();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields,save failed", "save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";

            cboSubCounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCounty.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion subcounty

            ReturnSocialWorkers();
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region CSO
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow CsoemptyRow = dt.NewRow();
            CsoemptyRow["cso_id"] = "-1";
            CsoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(CsoemptyRow, 0);

            cbocso.DataSource = dt;
            cbocso.DisplayMember = "cso_other";
            cbocso.ValueMember = "cso_id";

            cbocso.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbocso.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion CSO
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Parish
            dt = silcCommunityTrainingRegister.Return_lookups("parishCovid19", string.Empty, string.Empty, cboSubCounty.SelectedValue.ToString(), string.Empty);

            DataRow emptyRow = dt.NewRow();
            emptyRow["wrd_id"] = "-1";
            emptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(emptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Parish
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Households
            dt = HouseholdTransfer.LoadHouseholds(cboParish.SelectedValue.ToString());

            //dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode_by_parish", string.Empty, string.Empty, string.Empty, cboParish.SelectedValue.ToString());
            int x = dt.Rows.Count;
            DataRow hhmemptyRow = dt.NewRow();
            hhmemptyRow["hh_id"] = "-1";
            hhmemptyRow["hh_code"] = "Select HH Code";
            dt.Rows.InsertAt(hhmemptyRow, 0);

            cboHouseholdList.DataSource = dt;
            cboHouseholdList.DisplayMember = "hh_code";
            cboHouseholdList.ValueMember = "hh_id";

            //cboHouseholdList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboHouseholdList.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Households
        }

        private void cboHouseholdCode_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboHouseholdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Household_members
            dt = silcCommunityTrainingRegister.Return_lookups("hhm_hh_transfer_tool", cboHouseholdList.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select one";
            dt.Rows.InsertAt(emptyRow, 0);

            cboCaregiver.DataSource = dt;
            cboCaregiver.DisplayMember = "hhm_name";
            cboCaregiver.ValueMember = "hhm_id";

            cboCaregiver.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCaregiver.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Household_members

            get_hh_member_ages(cboHouseholdList.SelectedValue.ToString());
        }

        protected void get_hh_member_ages(string hh_id)
        {
            DataTable dt = HouseholdTransfer.Return_household_member_by_age_grp(hh_id);

            DataRow[] dtRowMaleLessThanSeventeen = dt.Select("age > 0 AND age <= 17 AND gnd_name ='Male'");
            int countMaleLessThanSeventeen = dtRowMaleLessThanSeventeen.Count();
            txtmaleChildCount.Text = countMaleLessThanSeventeen.ToString();

            DataRow[] dtRowFemaleLessThanSeventeen = dt.Select("age > 0 AND age <= 17 AND gnd_name ='Female'");
            int countFemaleLessThanSeventeen = dtRowFemaleLessThanSeventeen.Count();
            txtFemaleChildCount.Text = countFemaleLessThanSeventeen.ToString();

            DataRow[] dtRowmaleboveseventeen = dt.Select("age >= 18 AND gnd_name ='Male'");
            int countmaleboveseventeen = dtRowmaleboveseventeen.Count();
            txtmaleAdultCount.Text = countmaleboveseventeen.ToString();

            DataRow[] dtRowFemaleboveseventeen = dt.Select("age >= 18 AND gnd_name ='Female'");
            int countFemaleboveseventeen = dtRowFemaleboveseventeen.Count();
            txtFemaleAdultCount.Text = countFemaleboveseventeen.ToString();

            //DataRow dtRow = dt.Rows[0];
            //txtVillage.Text = dtRow["hh_village"].ToString();
        }

        #region save
        protected void save()
        {
            #region Variables
            HouseholdTransfer.hh_id = cboHouseholdList.SelectedValue.ToString();
            HouseholdTransfer.hh_code = cboHouseholdList.Text;
            HouseholdTransfer.ip_id = cboIP.SelectedValue.ToString();
            HouseholdTransfer.cso_id = cbocso.SelectedValue.ToString();
            HouseholdTransfer.wrd_id = cboParish.SelectedValue.ToString();
            HouseholdTransfer.caregiver_hhm_id = cboCaregiver.SelectedValue.ToString();
            HouseholdTransfer.hhm_female_children_count = txtFemaleChildCount.Value.ToString();
            HouseholdTransfer.hhm_male_children_count = txtmaleChildCount.Value.ToString();
            HouseholdTransfer.hhm_female_adult_count = txtFemaleAdultCount.Value.ToString();
            HouseholdTransfer.hhm_male_adult_count = txtmaleAdultCount.Value.ToString();
            HouseholdTransfer.yn_health_child_hiv_screen = utilControls.RadioButtonGetSelection(rbtnyn_health_child_hiv_screenYes, rbtnyn_health_child_hiv_screenNo);
            HouseholdTransfer.yn_health_child_hiv_screen_comment = txt_yn_health_child_hiv_screen.Text;
            HouseholdTransfer.yn_health_child_hiv_test_reffered = utilControls.RadioButtonGetSelection(rbtnyn_health_child_hiv_test_refferedYes, rbtnyn_health_child_hiv_test_refferedNo);
            HouseholdTransfer.yn_health_child_hiv_test_reffered_comment = txt_yn_health_child_hiv_test_reffered.Text;
            HouseholdTransfer.yn_health_child_known_hiv_status = utilControls.RadioButtonGetSelection(rbtnyn_health_child_known_hiv_statusYes, rbtnyn_health_child_known_hiv_statusNo);
            HouseholdTransfer.yn_health_child_known_hiv_status_comment = txt_yn_health_child_known_hiv_status.Text;
            HouseholdTransfer.yn_health_child_receive_arv = utilControls.RadioButtonGetSelection(rbtnyn_health_child_receive_arvYes, rbtnyn_health_child_receive_arvNo, rbtnyn_health_child_receive_arvNA);
            HouseholdTransfer.yn_health_child_receive_arv_comment = txt_yn_health_child_receive_arv.Text;
            HouseholdTransfer.yn_health_child_receive_vl_test = utilControls.RadioButtonGetSelection(rbtnyn_health_child_receive_vl_testYes, rbtnyn_health_child_receive_vl_testNo);
            HouseholdTransfer.yn_health_child_receive_vl_test_comment = txt_yn_health_child_receive_vl_test.Text;
            HouseholdTransfer.yn_health_child_vl_suppress = utilControls.RadioButtonGetSelection(rbtnyn_health_child_vl_suppressYes, rbtnyn_health_child_vl_suppressNo);
            HouseholdTransfer.yn_health_child_vl_suppress_comment = txt_yn_health_child_vl_suppress.Text;
            HouseholdTransfer.yn_mother_attend_hiv_clinic = utilControls.RadioButtonGetSelection(rbtnyn_mother_attend_hiv_clinicYes, rbtnyn_mother_attend_hiv_clinicNo);
            HouseholdTransfer.yn_mother_attend_hiv_clinic_comment = txt_yn_mother_attend_hiv_clinic.Text;
            HouseholdTransfer.yn_caregiver_hiv_screen = utilControls.RadioButtonGetSelection(rbtnyn_caregiver_hiv_screenYes, rbtnyn_caregiver_hiv_screenNo);
            HouseholdTransfer.yn_caregiver_hiv_screen_comment = txt_yn_caregiver_hiv_screen.Text;
            HouseholdTransfer.yn_caregiver_on_art = utilControls.RadioButtonGetSelection(rbtnyn_caregiver_on_artYes, rbtnyn_caregiver_on_artNo);
            HouseholdTransfer.yn_caregiver_on_art_comment = txt_yn_caregiver_on_art.Text;
            HouseholdTransfer.yn_caregiver_receive_vl_test = utilControls.RadioButtonGetSelection(rbtnyn_caregiver_receive_vl_testYes, rbtnyn_caregiver_receive_vl_testNo);
            HouseholdTransfer.yn_caregiver_receive_vl_test_comment = txt_yn_caregiver_receive_vl_test.Text;
            HouseholdTransfer.yn_child_undernourished = utilControls.RadioButtonGetSelection(rbtnyn_child_undernourishedYes, rbtnyn_child_undernourishedNo);
            HouseholdTransfer.yn_child_undernourished_comment = txt_yn_child_undernourished.Text;
            HouseholdTransfer.yn_caregiver_attend_parenting_program = utilControls.RadioButtonGetSelection(rbtnyn_caregiver_attend_parenting_programYes, rbtnyn_caregiver_attend_parenting_programNo);
            HouseholdTransfer.yn_caregiver_attend_parenting_program_comment = txt_yn_caregiver_attend_parenting_program.Text;
            HouseholdTransfer.yn_adolescent_risk_avoidance_enrolled = utilControls.RadioButtonGetSelection(rbtnyn_adolescent_risk_avoidance_enrolledYes, rbtnyn_adolescent_risk_avoidance_enrolledNo, rbtnyn_adolescent_risk_avoidance_enrolledNA);
            HouseholdTransfer.yn_adolescent_risk_avoidance_enrolled_comment = txt_yn_adolescent_risk_avoidance_enrolled.Text;
            HouseholdTransfer.yn_caregiver_in_silc = utilControls.RadioButtonGetSelection(rbtnyn_caregiver_in_silcYes, rbtnyn_caregiver_in_silcNo);
            HouseholdTransfer.yn_caregiver_in_silc_comment = txt_yn_caregiver_in_silc.Text;
            HouseholdTransfer.yn_IGA_support = utilControls.RadioButtonGetSelection(rbtnyn_IGA_supportYes, rbtnyn_IGA_supportNo);
            HouseholdTransfer.yn_IGA_support_comment = txt_yn_IGA_support.Text;
            HouseholdTransfer.yn_financial_literacy = utilControls.RadioButtonGetSelection(rbtnyn_financial_literacyYes, rbtnyn_financial_literacyNo);
            HouseholdTransfer.yn_financial_literacy_comment = txt_yn_financial_literacy.Text;
            HouseholdTransfer.yn_apprenticeship = utilControls.RadioButtonGetSelection(rbtnyn_apprenticeshipYes, rbtnyn_apprenticeshipNo, rbtnyn_apprenticeshipNA);
            HouseholdTransfer.yn_apprenticeship_comment = txt_yn_apprenticeship.Text;
            HouseholdTransfer.yn_startup_toolkit = utilControls.RadioButtonGetSelection(rbtnyn_startup_toolkitYes, rbtnyn_startup_toolkitNo);
            HouseholdTransfer.yn_startup_toolkit_comment = txt_yn_startup_toolkit.Text;
            HouseholdTransfer.yn_hh_cater_basic_need = utilControls.RadioButtonGetSelection(rbtnyn_hh_cater_basic_needYes, rbtnyn_hh_cater_basic_needNo);
            HouseholdTransfer.yn_hh_cater_basic_need_comment = txt_yn_hh_cater_basic_need.Text;
            HouseholdTransfer.yn_violence = utilControls.RadioButtonGetSelection(rbtnyn_violenceYes, rbtnyn_violenceNo);
            HouseholdTransfer.yn_violence_comment = txt_yn_violence.Text;
            HouseholdTransfer.yn_refferal_child_protection = utilControls.RadioButtonGetSelection(rbtnyn_refferal_child_protectionYes, rbtnyn_refferal_child_protectionNo);
            HouseholdTransfer.yn_refferal_child_protection_comment = txt_yn_refferal_child_protection.Text;
            HouseholdTransfer.yn_case_ongoing = utilControls.RadioButtonGetSelection(rbtnyn_case_ongoingYes, rbtnyn_case_ongoingNo);
            HouseholdTransfer.yn_case_ongoing_comment = txt_yn_case_ongoing.Text;
            HouseholdTransfer.yn_birth_certificate = utilControls.RadioButtonGetSelection(rbtnyn_birth_certificateYes, rbtnyn_birth_certificateNo);
            HouseholdTransfer.yn_birth_certificate_comment = txt_yn_birth_certificate.Text;
            HouseholdTransfer.yn_sinovuyo_training = utilControls.RadioButtonGetSelection(rbtnyn_sinovuyo_trainingYes, rbtnyn_sinovuyo_trainingNo);
            HouseholdTransfer.yn_sinovuyo_training_comment = txt_yn_sinovuyo_training.Text;
            HouseholdTransfer.yn_vhild_hiv_violence_prevention_curriculum = utilControls.RadioButtonGetSelection(rbtnyn_vhild_hiv_violence_prevention_curriculumYes, rbtnyn_vhild_hiv_violence_prevention_curriculumNo);
            HouseholdTransfer.yn_vhild_hiv_violence_prevention_curriculum_comment = txt_yn_vhild_hiv_violence_prevention_curriculum.Text;
            HouseholdTransfer.yn_edu_enrolled = utilControls.RadioButtonGetSelection(rbtnyn_edu_enrolledYes, rbtnyn_edu_enrolledNo);
            HouseholdTransfer.yn_edu_enrolled_comment = txt_yn_edu_enrolled.Text;
            HouseholdTransfer.yn_edu_attending_regularly = utilControls.RadioButtonGetSelection(rbtnyn_edu_attending_regularlyYes, rbtnyn_edu_attending_regularlyNo);
            HouseholdTransfer.yn_edu_attending_regularly_comment = txt_yn_edu_attending_regularly.Text;
            HouseholdTransfer.yn_adolesent_du_enrolled_with_edu_subsidy = utilControls.RadioButtonGetSelection(rbtnyn_adolesent_du_enrolled_with_edu_subsidyYes, rbtnyn_adolesent_du_enrolled_with_edu_subsidyNo);
            HouseholdTransfer.yn_adolesent_du_enrolled_with_edu_subsidy_comment = txt_yn_adolesent_du_enrolled_with_edu_subsidy.Text;
            HouseholdTransfer.yn_child_edu_nira_registered = utilControls.RadioButtonGetSelection(rbtnyn_child_edu_nira_registeredYes, rbtnyn_child_edu_nira_registeredNo);
            HouseholdTransfer.yn_child_edu_nira_registered_comment = txt_yn_child_edu_nira_registered.Text;
            HouseholdTransfer.yn_18_20yrs_in_school = utilControls.RadioButtonGetSelection(rbtnyn_18_20yrs_in_schoolYes, rbtnyn_18_20yrs_in_schoolNo);
            HouseholdTransfer.yn_18_20yrs_in_school_comment = txt_yn_18_20yrs_in_school.Text;
            HouseholdTransfer.swk_id = cboSocialWorker.SelectedValue.ToString();
            HouseholdTransfer.date = dtDate.Value;
            HouseholdTransfer.usr_id_create = SystemConstants.user_id;
            HouseholdTransfer.usr_id_update = SystemConstants.user_id;
            HouseholdTransfer.usr_date_create = DateTime.Now;
            HouseholdTransfer.usr_date_update = DateTime.Now;
            HouseholdTransfer.ofc_id = SystemConstants.ofc_id;
            HouseholdTransfer.district_id = SystemConstants.Return_office_district();
            #endregion

            if(lblid.Text == "--")
            {
                HouseholdTransfer.hh_tr_id = Guid.NewGuid().ToString();
                lblid.Text = HouseholdTransfer.hh_tr_id;
                HouseholdTransfer.save(dbCon);
                MessageBox.Show("Successfull saved", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HouseholdTransfer.hh_tr_id = lblid.Text;
                HouseholdTransfer.update(dbCon);
                MessageBox.Show("Successfull updated", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        protected void LoadRecordDetails(string id)
        {
            dt = HouseholdTransfer.LoadRecordDetails(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboIP.SelectedValue = dtRow["ip_id"].ToString();
                cbocso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                cboHouseholdList.SelectedValue = dtRow["hh_id"].ToString();
                cboCaregiver.SelectedValue = dtRow["caregiver_hhm_id"].ToString();
                txtFemaleChildCount.Value = Convert.ToInt32(dtRow["hhm_female_children_count"].ToString());
                txtmaleChildCount.Value = Convert.ToInt32(dtRow["hhm_male_children_count"].ToString());
                txtFemaleAdultCount.Value = Convert.ToInt32(dtRow["hhm_female_adult_count"].ToString());
                txtmaleAdultCount.Value = Convert.ToInt32(dtRow["hhm_male_adult_count"].ToString());
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_hiv_screenYes, rbtnyn_health_child_hiv_screenNo, dtRow["yn_health_child_hiv_screen"].ToString());
                txt_yn_health_child_hiv_screen.Text = dtRow["yn_health_child_hiv_screen_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_hiv_test_refferedYes, rbtnyn_health_child_hiv_test_refferedNo, dtRow["yn_health_child_hiv_test_reffered"].ToString());
                txt_yn_health_child_hiv_test_reffered.Text = dtRow["yn_health_child_hiv_test_reffered_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_known_hiv_statusYes, rbtnyn_health_child_known_hiv_statusNo, dtRow["yn_health_child_known_hiv_status"].ToString());
                txt_yn_health_child_known_hiv_status.Text = dtRow["yn_health_child_known_hiv_status_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_receive_arvYes, rbtnyn_health_child_receive_arvNo, rbtnyn_health_child_receive_arvNA, dtRow["yn_health_child_receive_arv"].ToString());
                txt_yn_health_child_receive_arv.Text = dtRow["yn_health_child_receive_arv_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_receive_vl_testYes, rbtnyn_health_child_receive_vl_testNo, dtRow["yn_health_child_receive_vl_test"].ToString());
                txt_yn_health_child_receive_vl_test.Text = dtRow["yn_health_child_receive_vl_test_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_health_child_vl_suppressYes, rbtnyn_health_child_vl_suppressNo, dtRow["yn_health_child_vl_suppress"].ToString());
                txt_yn_health_child_vl_suppress.Text = dtRow["yn_health_child_vl_suppress_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_mother_attend_hiv_clinicYes, rbtnyn_mother_attend_hiv_clinicNo, dtRow["yn_mother_attend_hiv_clinic"].ToString());
                txt_yn_mother_attend_hiv_clinic.Text = dtRow["yn_mother_attend_hiv_clinic_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_caregiver_hiv_screenYes, rbtnyn_caregiver_hiv_screenNo, dtRow["yn_caregiver_hiv_screen"].ToString());
                txt_yn_caregiver_hiv_screen.Text = dtRow["yn_caregiver_hiv_screen_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_caregiver_on_artYes, rbtnyn_caregiver_on_artNo, dtRow["yn_caregiver_on_art"].ToString());
                txt_yn_caregiver_on_art.Text = dtRow["yn_caregiver_on_art_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_caregiver_receive_vl_testYes, rbtnyn_caregiver_receive_vl_testNo, dtRow["yn_caregiver_receive_vl_test"].ToString());
                txt_yn_caregiver_receive_vl_test.Text = dtRow["yn_caregiver_receive_vl_test_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_child_undernourishedYes, rbtnyn_child_undernourishedNo, dtRow["yn_child_undernourished"].ToString());
                txt_yn_child_undernourished.Text = dtRow["yn_child_undernourished_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_caregiver_attend_parenting_programYes, rbtnyn_caregiver_attend_parenting_programNo, dtRow["yn_caregiver_attend_parenting_program"].ToString());
                txt_yn_caregiver_attend_parenting_program.Text = dtRow["yn_caregiver_attend_parenting_program_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_adolescent_risk_avoidance_enrolledYes, rbtnyn_adolescent_risk_avoidance_enrolledNo, rbtnyn_adolescent_risk_avoidance_enrolledNA, dtRow["yn_adolescent_risk_avoidance_enrolled"].ToString());
                txt_yn_adolescent_risk_avoidance_enrolled.Text = dtRow["yn_adolescent_risk_avoidance_enrolled_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_caregiver_in_silcYes, rbtnyn_caregiver_in_silcNo, dtRow["yn_caregiver_in_silc"].ToString());
                txt_yn_caregiver_in_silc.Text = dtRow["yn_caregiver_in_silc_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_IGA_supportYes, rbtnyn_IGA_supportNo, dtRow["yn_IGA_support"].ToString());
                txt_yn_IGA_support.Text = dtRow["yn_IGA_support_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_financial_literacyYes, rbtnyn_financial_literacyNo, dtRow["yn_financial_literacy"].ToString());
                txt_yn_financial_literacy.Text = dtRow["yn_financial_literacy_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_apprenticeshipYes, rbtnyn_apprenticeshipNo, rbtnyn_apprenticeshipNA, dtRow["yn_apprenticeship"].ToString());
                txt_yn_apprenticeship.Text = dtRow["yn_apprenticeship_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_startup_toolkitYes, rbtnyn_startup_toolkitNo, dtRow["yn_startup_toolkit"].ToString());
                txt_yn_startup_toolkit.Text = dtRow["yn_startup_toolkit_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_hh_cater_basic_needYes, rbtnyn_hh_cater_basic_needNo, dtRow["yn_hh_cater_basic_need"].ToString());
                txt_yn_hh_cater_basic_need.Text = dtRow["yn_hh_cater_basic_need_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_violenceYes, rbtnyn_violenceNo, dtRow["yn_violence"].ToString());
                txt_yn_violence.Text = dtRow["yn_violence_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_refferal_child_protectionYes, rbtnyn_refferal_child_protectionNo, dtRow["yn_refferal_child_protection"].ToString());
                txt_yn_refferal_child_protection.Text = dtRow["yn_refferal_child_protection_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_case_ongoingYes, rbtnyn_case_ongoingNo, dtRow["yn_case_ongoing"].ToString());
                txt_yn_case_ongoing.Text = dtRow["yn_case_ongoing_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_birth_certificateYes, rbtnyn_birth_certificateNo, dtRow["yn_birth_certificate"].ToString());
                txt_yn_birth_certificate.Text = dtRow["yn_birth_certificate_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_sinovuyo_trainingYes, rbtnyn_sinovuyo_trainingNo, dtRow["yn_sinovuyo_training"].ToString());
                txt_yn_sinovuyo_training.Text = dtRow["yn_sinovuyo_training_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_vhild_hiv_violence_prevention_curriculumYes, rbtnyn_vhild_hiv_violence_prevention_curriculumNo, dtRow["yn_vhild_hiv_violence_prevention_curriculum"].ToString());
                txt_yn_vhild_hiv_violence_prevention_curriculum.Text = dtRow["yn_vhild_hiv_violence_prevention_curriculum_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_edu_enrolledYes, rbtnyn_edu_enrolledNo, dtRow["yn_edu_enrolled"].ToString());
                txt_yn_edu_enrolled.Text = dtRow["yn_edu_enrolled_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_edu_attending_regularlyYes, rbtnyn_edu_attending_regularlyNo, dtRow["yn_edu_attending_regularly"].ToString());
                txt_yn_edu_attending_regularly.Text = dtRow["yn_edu_attending_regularly_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_adolesent_du_enrolled_with_edu_subsidyYes, rbtnyn_adolesent_du_enrolled_with_edu_subsidyNo, dtRow["yn_adolesent_du_enrolled_with_edu_subsidy"].ToString());
                txt_yn_adolesent_du_enrolled_with_edu_subsidy.Text = dtRow["yn_adolesent_du_enrolled_with_edu_subsidy_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_child_edu_nira_registeredYes, rbtnyn_child_edu_nira_registeredNo, dtRow["yn_child_edu_nira_registered"].ToString());
                txt_yn_child_edu_nira_registered.Text = dtRow["yn_child_edu_nira_registered_comment"].ToString();
                utilControls.RadioButtonSetSelection(rbtnyn_18_20yrs_in_schoolYes, rbtnyn_18_20yrs_in_schoolNo, dtRow["yn_18_20yrs_in_school"].ToString());
                txt_yn_18_20yrs_in_school.Text = dtRow["yn_18_20yrs_in_school_comment"].ToString();
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["date"]);
                lblid.Text = id;
            }
        }

        protected void Clear()
        {
            cboHouseholdList.SelectedValue = "-1";
            cboIP.SelectedValue = "-1";
            cbocso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            cboCaregiver.SelectedValue = "-1";
            txtFemaleChildCount.Value = 0;
            txtmaleChildCount.Value = 0;
            txtFemaleAdultCount.Value = 0;
            txtmaleAdultCount.Value = 0;
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_hiv_screenYes, rbtnyn_health_child_hiv_screenNo, string.Empty);
            txt_yn_health_child_hiv_screen.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_hiv_test_refferedYes, rbtnyn_health_child_hiv_test_refferedNo, string.Empty);
            txt_yn_health_child_hiv_test_reffered.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_known_hiv_statusYes, rbtnyn_health_child_known_hiv_statusNo, string.Empty);
            txt_yn_health_child_known_hiv_status.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_receive_arvYes, rbtnyn_health_child_receive_arvNo, rbtnyn_health_child_receive_arvNA, string.Empty);
            txt_yn_health_child_receive_arv.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_receive_vl_testYes, rbtnyn_health_child_receive_vl_testNo, string.Empty);
            txt_yn_health_child_receive_vl_test.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_health_child_vl_suppressYes, rbtnyn_health_child_vl_suppressNo, string.Empty);
            txt_yn_health_child_vl_suppress.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_mother_attend_hiv_clinicYes, rbtnyn_mother_attend_hiv_clinicNo, string.Empty);
            txt_yn_mother_attend_hiv_clinic.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_caregiver_hiv_screenYes, rbtnyn_caregiver_hiv_screenNo, string.Empty);
            txt_yn_caregiver_hiv_screen.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_caregiver_on_artYes, rbtnyn_caregiver_on_artNo, string.Empty);
            txt_yn_caregiver_on_art.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_caregiver_receive_vl_testYes, rbtnyn_caregiver_receive_vl_testNo, string.Empty);
            txt_yn_caregiver_receive_vl_test.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_child_undernourishedYes, rbtnyn_child_undernourishedNo, string.Empty);
            txt_yn_child_undernourished.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_caregiver_attend_parenting_programYes, rbtnyn_caregiver_attend_parenting_programNo, string.Empty);
            txt_yn_caregiver_attend_parenting_program.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_adolescent_risk_avoidance_enrolledYes, rbtnyn_adolescent_risk_avoidance_enrolledNo, rbtnyn_adolescent_risk_avoidance_enrolledNA, string.Empty);
            txt_yn_adolescent_risk_avoidance_enrolled.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_caregiver_in_silcYes, rbtnyn_caregiver_in_silcNo, string.Empty);
            txt_yn_caregiver_in_silc.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_IGA_supportYes, rbtnyn_IGA_supportNo, string.Empty);
            txt_yn_IGA_support.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_financial_literacyYes, rbtnyn_financial_literacyNo, string.Empty);
            txt_yn_financial_literacy.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_apprenticeshipYes, rbtnyn_apprenticeshipNo, rbtnyn_apprenticeshipNA, string.Empty);
            txt_yn_apprenticeship.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_startup_toolkitYes, rbtnyn_startup_toolkitNo, string.Empty);
            txt_yn_startup_toolkit.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_hh_cater_basic_needYes, rbtnyn_hh_cater_basic_needNo, string.Empty);
            txt_yn_hh_cater_basic_need.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_violenceYes, rbtnyn_violenceNo, string.Empty);
            txt_yn_violence.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_refferal_child_protectionYes, rbtnyn_refferal_child_protectionNo, string.Empty);
            txt_yn_refferal_child_protection.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_case_ongoingYes, rbtnyn_case_ongoingNo, string.Empty);
            txt_yn_case_ongoing.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_birth_certificateYes, rbtnyn_birth_certificateNo, string.Empty);
            txt_yn_birth_certificate.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_sinovuyo_trainingYes, rbtnyn_sinovuyo_trainingNo, string.Empty);
            txt_yn_sinovuyo_training.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_vhild_hiv_violence_prevention_curriculumYes, rbtnyn_vhild_hiv_violence_prevention_curriculumNo, string.Empty);
            txt_yn_vhild_hiv_violence_prevention_curriculum.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_edu_enrolledYes, rbtnyn_edu_enrolledNo, string.Empty);
            txt_yn_edu_enrolled.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_edu_attending_regularlyYes, rbtnyn_edu_attending_regularlyNo, string.Empty);
            txt_yn_edu_attending_regularly.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_adolesent_du_enrolled_with_edu_subsidyYes, rbtnyn_adolesent_du_enrolled_with_edu_subsidyNo, string.Empty);
            txt_yn_adolesent_du_enrolled_with_edu_subsidy.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_child_edu_nira_registeredYes, rbtnyn_child_edu_nira_registeredNo, string.Empty);
            txt_yn_child_edu_nira_registered.Clear();
            utilControls.RadioButtonSetSelection(rbtnyn_18_20yrs_in_schoolYes, rbtnyn_18_20yrs_in_schoolNo, string.Empty);
            txt_yn_18_20yrs_in_school.Clear();
            cboSocialWorker.SelectedValue = "-1";
            dtDate.Value = DateTime.Today;
            lblid.Text = "--";
        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if(cboIP.SelectedValue.ToString() == "-1" || cbocso.SelectedValue.ToString() == "-1" || cboParish.SelectedValue.ToString() == "-1" || cboHouseholdList.SelectedValue.ToString() == "-1" || 
                cboCaregiver.SelectedValue.ToString() == "-1" || cboSocialWorker.SelectedValue.ToString() == "-1" || dtDate.Checked == false)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        private void lnkNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void btnRecordIssues_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "--")
            {
                MessageBox.Show("Please save or select an existing record first to register household issues", "Register Household Issues", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                frmHouseholdTransferIssuesRegister hhTransfer = new frmHouseholdTransferIssuesRegister();
                hhTransfer.ShowDialog();
            }
        }
    }
}
