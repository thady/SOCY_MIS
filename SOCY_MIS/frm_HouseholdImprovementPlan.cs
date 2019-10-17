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
    public partial class frm_HouseholdImprovementPlan : UserControl
    {
        DataTable dt = null;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        string ErrorMessage = string.Empty;

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
        #endregion Property

        public frm_HouseholdImprovementPlan()
        {
            InitializeComponent();
        }

        private void frm_HouseholdImprovementPlan_Load(object sender, EventArgs e)
        {
            Return_lookups();
            display_hh_details();
            Return_household_members();
            get_hh_member_ages();
            Return_paraSocialWorkers();
            ResetDates();
            ShowHideResponseCheckBox();

            #region LoadDisplay
            if (hh_household_improvement_plan.hip_id != string.Empty)
            {
               LoadDisplay(hh_household_improvement_plan.hip_id);
            }
            #endregion LoadDisplay

        }

        private void Back()
        {
           hh_household_improvement_plan.hip_id = string.Empty;
            FormCalling.LoadDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void lnkBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }


        #region PrivateMethods
        protected void display_hh_details()
        {
            DataTable dt = hhHousehold_linkages_register.Return_household_details(SystemConstants.hh_record_guid); //reused
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboCso.Text = dtRow["prt_name"].ToString();
                cboDistrict.Text = dtRow["dst_name"].ToString();
                cboSubCounty.Text = dtRow["sct_name"].ToString();
                cboParish.Text = dtRow["wrd_name"].ToString();
                txtVilage.Text = dtRow["hh_village"].ToString();
                txtHHCode.Text = dtRow["hh_code"].ToString();
            }
        }

        protected void Return_lookups()
        {
            //districts
            dt = hhHousehold_linkages_register.Return_lookups("district");
            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            //IP
            dt = hhHousehold_linkages_register.Return_lookups("IP");
            cboCso.DataSource = dt;
            cboCso.DisplayMember = "prt_name";
            cboCso.ValueMember = "prt_id";

            //subcounty
            dt = hhHousehold_linkages_register.Return_lookups("subcounty");
            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            dt = hh_household_improvement_plan.LoadQuarter();
            if (dt.Rows.Count > 0)
            {
                DataRow dstemptyRow = dt.NewRow();
                dstemptyRow["qy_id"] = "-1";
                dstemptyRow["qy_name"] = "Select Quarter";
                dt.Rows.InsertAt(dstemptyRow, 0);

                cboQuarter.DisplayMember = "qy_name";
                cboQuarter.ValueMember = "qy_id";
                cboQuarter.DataSource = dt;

            }
        }

        protected void get_hh_member_ages()
        {
            DataTable dt = hh_household_improvement_plan.Return_household_member_ages(SystemConstants.hh_record_guid);

            DataRow[] dtRowMaleLessThanSeventeen = dt.Select("age > 0 AND age <= 17 AND gnd_name ='Male'");
            int countMaleLessThanSeventeen = dtRowMaleLessThanSeventeen.Count();
            txtmalebelowseventeen.Text = countMaleLessThanSeventeen.ToString();

            DataRow[] dtRowFemaleLessThanSeventeen = dt.Select("age > 0 AND age <= 17 AND gnd_name ='Female'");
            int countFemaleLessThanSeventeen = dtRowFemaleLessThanSeventeen.Count();
            txtFemalebelowseventeen.Text = countFemaleLessThanSeventeen.ToString();

            DataRow[] dtRowmaleboveseventeen = dt.Select("age >= 18 AND gnd_name ='Male'");
            int countmaleboveseventeen = dtRowmaleboveseventeen.Count();
            txtmaleboveseventeen.Text = countmaleboveseventeen.ToString();

            DataRow[] dtRowFemaleboveseventeen = dt.Select("age >= 18 AND gnd_name ='Female'");
            int countFemaleboveseventeen = dtRowFemaleboveseventeen.Count();
            txtFemaleboveseventeen.Text = countFemaleboveseventeen.ToString();
        }

        protected void Return_household_members()
        {
            dt = hhHousehold_linkages_register.Return_household_member_details(SystemConstants.hh_record_guid); //reused from linkages register
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["hhm_id"] = "-1";
                emptyRow["Name"] = "select household member";
                dt.Rows.InsertAt(emptyRow, 0);

                cboCaregiver.DataSource = dt;
                cboCaregiver.ValueMember = "hhm_id";
                cboCaregiver.DisplayMember = "Name";

                //select caregiver
                cboCaregiver.SelectedValue = hh_household_improvement_plan.Return_household_head(SystemConstants.hh_record_guid);
            }
        }

        protected void Return_paraSocialWorkers()
        {
            dt = hh_household_improvement_plan.Return_ParasocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["swk_id"] = "-1";
                emptyRow["swk_name"] = "Select Social Worker";
                dt.Rows.InsertAt(emptyRow, 0);

                cboSocialWorker.DataSource = dt;
                cboSocialWorker.ValueMember = "swk_id";
                cboSocialWorker.DisplayMember = "swk_name";
            }
        }
        #endregion PrivateMethods

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void save()
        {
            #region setVariables
            hh_household_improvement_plan.hh_code = txtHHCode.Text;
            hh_household_improvement_plan.hh_id = SystemConstants.hh_record_guid;
            hh_household_improvement_plan.initial_hip_date = dtInitialHip.Value.Date;
            hh_household_improvement_plan.visit_date = dtTimeVisistDate.Value;
            hh_household_improvement_plan.qm_id = cboQuarter.SelectedValue.ToString();
            hh_household_improvement_plan.ov_below_seventeen_yrs_male = Convert.ToInt32(txtmalebelowseventeen.Text);
            hh_household_improvement_plan.ov_below_seventeen_yrs_female = Convert.ToInt32(txtFemalebelowseventeen.Text);
            hh_household_improvement_plan.ov_above_eighteen_yrs_male = Convert.ToInt32(txtmaleboveseventeen.Text);
            hh_household_improvement_plan.ov_above_eighteen_yrs_female = Convert.ToInt32(txtFemaleboveseventeen.Text);
            hh_household_improvement_plan.hip_reason = cbovisitReason.Text;
            hh_household_improvement_plan.yn_knows_status_of_children = utilControls.RadioButtonGetSelection(rbtn_yn_knows_status_of_children_Yes, rbtn_yn_knows_status_of_children_No);
            hh_household_improvement_plan.yn_knows_status_of_children_action = txtyn_knows_status_of_children_action.Text;
            hh_household_improvement_plan.yn_knows_status_of_children_out_come = txtyn_knows_status_of_children_out_come.Text;
            hh_household_improvement_plan.yn_knows_status_of_children_followup_date = dtyn_knows_status_of_children_followup_date.Checked == true ? dtyn_knows_status_of_children_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_positive_enrolled_on_art = utilControls.RadioButtonGetSelection(rbtn_yn_positive_enrolled_on_art_Yes, rbtn_yn_positive_enrolled_on_art_No, rbtn_yn_positive_enrolled_on_art_NA);
            hh_household_improvement_plan.yn_positive_enrolled_on_art_out_come = txtyn_positive_enrolled_on_art_out_come.Text;
            hh_household_improvement_plan.yn_positive_enrolled_on_art_action = txtyn_positive_enrolled_on_art_action.Text;
            hh_household_improvement_plan.yn_positive_enrolled_on_art_followup_date = dtyn_positive_enrolled_on_art_followup_date.Checked ? dtyn_positive_enrolled_on_art_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_positive_supressing = utilControls.RadioButtonGetSelection(rbtn_yn_positive_supressing_Yes, rbtn_yn_positive_supressing_No, rbtn_yn_positive_supressing_NA);
            hh_household_improvement_plan.yn_positive_supressing_action = txtyn_positive_supressing_action.Text;
            hh_household_improvement_plan.yn_positive_supressing_out_come = txtyn_positive_supressing_out_come.Text;
            hh_household_improvement_plan.yn_positive_supressing_followup_date = dtyn_positive_supressing_followup_date.Checked ? dtyn_positive_supressing_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_positive_adhering = utilControls.RadioButtonGetSelection(rbtn_yn_positive_adhering_Yes, rbtn_yn_positive_adhering_No, rbtn_yn_positive_adhering_NA);
            hh_household_improvement_plan.yn_positive_adhering_action = txtyn_positive_adhering_action.Text;
            hh_household_improvement_plan.yn_positive_adhering_out_come = txtyn_positive_adhering_out_come.Text;
            hh_household_improvement_plan.yn_positive_adhering_followup_date = dtyn_positive_adhering_followup_date.Checked ? dtyn_positive_adhering_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_adolescent_hiv_prevention = utilControls.RadioButtonGetSelection(rbtn_yn_adolescent_hiv_prevention_Yes, rbtn_yn_adolescent_hiv_prevention_No, rbtn_yn_adolescent_hiv_prevention_NA);
            hh_household_improvement_plan.yn_adolescent_hiv_prevention_action = txtyn_adolescent_hiv_prevention_action.Text;
            hh_household_improvement_plan.yn_adolescent_hiv_prevention_out_come = txtyn_adolescent_hiv_prevention_out_come.Text;
            hh_household_improvement_plan.yn_adolescent_hiv_prevention_followup_date = dtyn_adolescent_hiv_prevention_followup_date.Checked ? dtyn_adolescent_hiv_prevention_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_child_undernourished = utilControls.RadioButtonGetSelection(rbtn_yn_child_undernourished_Yes, rbtn_yn_child_undernourished_No, rbtn_yn_child_undernourished_NA);
            hh_household_improvement_plan.yn_child_undernourished_action = txtyn_child_undernourished_action.Text;
            hh_household_improvement_plan.yn_child_undernourished_out_come = txtyn_child_undernourished_out_come.Text;
            hh_household_improvement_plan.yn_child_undernourished_followup_date = dtyn_child_undernourished_followup_date.Checked ? dtyn_child_undernourished_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.other_health_issues = txtother_health_issues.Text;
            hh_household_improvement_plan.other_health_issues_action = txtother_health_issues_action.Text;
            hh_household_improvement_plan.other_health_issues_out_come = txtother_health_issues_out_come.Text;
            hh_household_improvement_plan.other_health_issues_action_followup_date = dtother_health_issues_action_followup_date.Checked ? dtother_health_issues_action_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_no_violence = utilControls.RadioButtonGetSelection(rbtn_yn_no_violence_Yes, rbtn_yn_no_violence_No);
            hh_household_improvement_plan.yn_no_violence_action = txtyn_no_violence_action.Text;
            hh_household_improvement_plan.yn_no_violence_out_come = txtyn_no_violence_out_come.Text;
            hh_household_improvement_plan.yn_no_violence_action_followup_date = dtyn_no_violence_action_followup_date.Checked ? dtyn_no_violence_action_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_stable_care_giver = utilControls.RadioButtonGetSelection(rbtn_yn_stable_care_giver_Yes, rbtn_yn_stable_care_giver_No);
            hh_household_improvement_plan.yn_stable_care_giver_action = txtyn_stable_care_giver_action.Text;
            hh_household_improvement_plan.yn_stable_care_giver_followup_date = dtyn_stable_care_giver_followup_date.Checked ? dtyn_stable_care_giver_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_stable_care_giver_out_come = txtyn_stable_care_giver_out_come.Text;
            hh_household_improvement_plan.other_safe_issues = txtother_safe_issues.Text;
            hh_household_improvement_plan.other_safe_issues_action = txtother_safe_issues_action.Text;
            hh_household_improvement_plan.other_safe_issues_followup_date = dtother_safe_issues_followup_date.Checked ? dtother_safe_issues_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.other_safe_issues_out_come = txtother_safe_issues_action_out_come.Text;
            hh_household_improvement_plan.yn_stable_access_money = utilControls.RadioButtonGetSelection(yn_stable_access_money_Yes, yn_stable_access_money_No);
            hh_household_improvement_plan.yn_stable_access_money_action = txtyn_stable_access_money_action.Text;
            hh_household_improvement_plan.yn_stable_access_money_followup_date = dtyn_stable_access_money_followup_date.Checked ? dtyn_stable_access_money_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_stable_access_money_out_come = yn_stable_access_money_out_come.Text;
            hh_household_improvement_plan.yn_stable_income_source = utilControls.RadioButtonGetSelection(rbtn_yn_stable_income_source_Yes, rbtn_yn_stable_income_source_No);
            hh_household_improvement_plan.yn_stable_income_source_action = txt_yn_stable_income_source_action.Text;
            hh_household_improvement_plan.yn_stable_income_source_followup_date = dtyn_stable_income_source_followup_date.Checked ? dtyn_stable_income_source_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_stable_income_source_out_come = txtyn_stable_income_source_out_come.Text;
            hh_household_improvement_plan.other_hes_issues = txtother_hes_issues.Text;
            hh_household_improvement_plan.other_hes_issues_action = txtother_hes_issues_action.Text;
            hh_household_improvement_plan.other_hes_issues_followup_date = dtother_hes_issues_followup_date.Checked ? dtother_hes_issues_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.other_hes_issues_out_come = txtother_hes_issues_out_come.Text;
            hh_household_improvement_plan.yn_ovc_regularly_attend_school = utilControls.RadioButtonGetSelection(rbtn_yn_ovc_regularly_attend_school_Yes, rbtn_yn_ovc_regularly_attend_school_No, rbtn_yn_ovc_regularly_attend_school_NA);
            hh_household_improvement_plan.yn_ovc_regularly_attend_school_action = txtyn_ovc_regularly_attend_school_action.Text;
            hh_household_improvement_plan.yn_ovc_regularly_attend_school_followup_date = dtyn_ovc_regularly_attend_school_followup_date.Checked ? dtyn_ovc_regularly_attend_school_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_ovc_regularly_attend_school_out_come = txtyn_ovc_regularly_attend_school_out_come.Text;
            hh_household_improvement_plan.yn_attained_tech_skill = utilControls.RadioButtonGetSelection(rbtn_yn_attained_tech_skill_Yes, rbtn_yn_attained_tech_skill_No, rbtn_yn_attained_tech_skill_NA);
            hh_household_improvement_plan.yn_attained_tech_skill_action_plan = txtyn_attained_tech_skill_action_plan.Text;
            hh_household_improvement_plan.yn_attained_tech_skill_followup_date = dtyn_attained_tech_skill_followup_date.Checked ? dtyn_attained_tech_skill_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_attained_tech_skill_out_come = txtyn_attained_tech_skill_out_come.Text;
            hh_household_improvement_plan.other_edu_issues = txtother_edu_issues.Text;
            hh_household_improvement_plan.other_edu_issues_action = txtother_edu_issues_action.Text;
            hh_household_improvement_plan.other_edu_issues_followup_date = dtother_edu_issues_followup_date.Checked ? dtother_edu_issues_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.other_edu_issues_out_come = txtother_edu_issues_out_come.Text;
            hh_household_improvement_plan.hip_out_come_date = dtOutComeDate.Checked ? dtOutComeDate.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.sw_id = cboSocialWorker.SelectedValue.ToString();
            hh_household_improvement_plan.sw_comment = txtSocialWorkerComment.Text;
            hh_household_improvement_plan.sw_supervisor_name = txtSupervisor.Text;
            hh_household_improvement_plan.sw_supervisor_comment = txtSupervisorComment.Text;
            hh_household_improvement_plan.usr_id_create = SystemConstants.user_id;
            hh_household_improvement_plan.usr_id_update = SystemConstants.user_id;
            hh_household_improvement_plan.usr_date_create = DateTime.Today;
            hh_household_improvement_plan.usr_date_update = DateTime.Today;
            hh_household_improvement_plan.ofc_id = SystemConstants.ofc_id;
            hh_household_improvement_plan.district_id = SystemConstants.Return_office_district();

            hh_household_improvement_plan.yn_safe_birth_certificates = utilControls.RadioButtonGetSelection(rbtn_yn_birth_certificateYes, rbtn_yn_birth_certificateNo, rbtn_yn_birth_certificateNA);
            hh_household_improvement_plan.yn_safe_birth_certificates_action = txt_yn_birth_certificate_action.Text;
            hh_household_improvement_plan.yn_safe_birth_certificates_followup_date = dt_yn_birth_certificates_followup_date.Checked ? dt_yn_birth_certificates_followup_date.Value.Date.ToShortDateString() : string.Empty;
            hh_household_improvement_plan.yn_safe_birth_certificates_out_come = txt_yn_birth_certificate_out_come.Text;
            #endregion setVariables

            #region save
            if (ValidateInput())
            {
                if (hh_household_improvement_plan.hip_id == string.Empty)
                {
                    hh_household_improvement_plan.hip_id = Guid.NewGuid().ToString();
                    hh_household_improvement_plan.save();
                    MessageBox.Show("Successfully saved", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hh_household_improvement_plan.update();
                    MessageBox.Show("Successfully updated", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }     
            }
            else
            {
                MessageBox.Show("All responses highlited in red require both an action plan and followup date,saved failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion save
        }

        protected void LoadDisplay(string hip_id)
        {
            dt = hh_household_improvement_plan.LoadDisplay(hip_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                #region FillControls
                txtHHCode.Text = dtRow["hh_code"].ToString();
                dtInitialHip.Value = Convert.ToDateTime(dtRow["initial_hip_date"].ToString());
                dtTimeVisistDate.Value = Convert.ToDateTime(dtRow["visit_date"].ToString());
                cboQuarter.SelectedValue = dtRow["qm_id"].ToString();///edit and provide values
                cbovisitReason.Text = dtRow["hip_reason"].ToString();
                utilControls.RadioButtonSetSelection(rbtn_yn_knows_status_of_children_Yes, rbtn_yn_knows_status_of_children_No, dtRow["yn_knows_status_of_children"].ToString());
                txtyn_knows_status_of_children_action.Text = dtRow["yn_knows_status_of_children_action"].ToString();
                txtyn_knows_status_of_children_out_come.Text = dtRow["yn_knows_status_of_children_out_come"].ToString();
                dtyn_knows_status_of_children_followup_date.Value = dtRow["yn_knows_status_of_children_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_knows_status_of_children_followup_date"].ToString()): DateTime.Today;
                dtyn_knows_status_of_children_followup_date.Checked = dtRow["yn_knows_status_of_children_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_positive_enrolled_on_art_Yes, rbtn_yn_positive_enrolled_on_art_No, rbtn_yn_positive_enrolled_on_art_NA, dtRow["yn_positive_enrolled_on_art"].ToString());
                txtyn_positive_enrolled_on_art_out_come.Text = dtRow["yn_positive_enrolled_on_art_out_come"].ToString();
                hh_household_improvement_plan.yn_positive_enrolled_on_art_action = txtyn_positive_enrolled_on_art_action.Text = dtRow["yn_positive_enrolled_on_art_action"].ToString();
                dtyn_positive_enrolled_on_art_followup_date.Value = dtRow["yn_positive_enrolled_on_art_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_positive_enrolled_on_art_followup_date"].ToString()) : DateTime.Today;
                dtyn_positive_enrolled_on_art_followup_date.Checked = dtRow["yn_positive_enrolled_on_art_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_positive_supressing_Yes, rbtn_yn_positive_supressing_No, rbtn_yn_positive_supressing_NA, dtRow["yn_positive_supressing"].ToString());
                txtyn_positive_supressing_action.Text = dtRow["yn_positive_supressing_action"].ToString();
                txtyn_positive_supressing_out_come.Text = dtRow["yn_positive_supressing_out_come"].ToString();
                dtyn_positive_supressing_followup_date.Value = dtRow["yn_positive_supressing_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_positive_supressing_followup_date"].ToString()) : DateTime.Today;
                dtyn_positive_supressing_followup_date.Checked = dtRow["yn_positive_supressing_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_positive_adhering_Yes, rbtn_yn_positive_adhering_No, rbtn_yn_positive_adhering_NA, dtRow["yn_positive_adhering"].ToString());
                txtyn_positive_adhering_action.Text = dtRow["yn_positive_adhering_action"].ToString();
                txtyn_positive_adhering_out_come.Text = dtRow["yn_positive_adhering_out_come"].ToString();
                dtyn_positive_adhering_followup_date.Value = dtRow["yn_positive_adhering_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_positive_adhering_followup_date"].ToString()) : DateTime.Today;
                dtyn_positive_adhering_followup_date.Checked = dtRow["yn_positive_adhering_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_adolescent_hiv_prevention_Yes, rbtn_yn_adolescent_hiv_prevention_No, rbtn_yn_adolescent_hiv_prevention_NA, dtRow["yn_adolescent_hiv_prevention"].ToString());
                txtyn_adolescent_hiv_prevention_action.Text = dtRow["yn_adolescent_hiv_prevention_action"].ToString();
                txtyn_adolescent_hiv_prevention_out_come.Text = dtRow["yn_adolescent_hiv_prevention_out_come"].ToString();
                dtyn_adolescent_hiv_prevention_followup_date.Value = dtRow["yn_adolescent_hiv_prevention_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_adolescent_hiv_prevention_followup_date"].ToString()) : DateTime.Today;
                dtyn_adolescent_hiv_prevention_followup_date.Checked = dtRow["yn_adolescent_hiv_prevention_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_child_undernourished_Yes, rbtn_yn_child_undernourished_No, rbtn_yn_child_undernourished_NA, dtRow["yn_child_undernourished"].ToString());
                txtyn_child_undernourished_action.Text = dtRow["yn_child_undernourished_action"].ToString();
                txtyn_child_undernourished_out_come.Text = dtRow["yn_child_undernourished_out_come"].ToString();
                dtyn_child_undernourished_followup_date.Value = dtRow["yn_child_undernourished_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_child_undernourished_followup_date"].ToString()) : DateTime.Today;
                dtyn_child_undernourished_followup_date.Checked = dtRow["yn_child_undernourished_followup_date"].ToString() != string.Empty ? true : false;

                utilControls.RadioButtonSetSelection(rbtn_yn_birth_certificateYes, rbtn_yn_birth_certificateNo, rbtn_yn_birth_certificateNA, dtRow["yn_safe_birth_certificates"].ToString());
                txt_yn_birth_certificate_action.Text = dtRow["yn_safe_birth_certificates_action"].ToString();
                txt_yn_birth_certificate_out_come.Text = dtRow["yn_safe_birth_certificates_out_come"].ToString();
                dt_yn_birth_certificates_followup_date.Value = dtRow["yn_safe_birth_certificates_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_safe_birth_certificates_followup_date"].ToString()) : DateTime.Today;
                dt_yn_birth_certificates_followup_date.Checked = dtRow["yn_safe_birth_certificates_followup_date"].ToString() != string.Empty ? true : false;


                txtother_health_issues.Text = dtRow["other_health_issues"].ToString();
                txtother_health_issues_action.Text = dtRow["other_health_issues_action"].ToString();
                txtother_health_issues_out_come.Text = dtRow["other_health_issues_out_come"].ToString();
                dtother_health_issues_action_followup_date.Value = dtRow["other_health_issues_action_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["other_health_issues_action_followup_date"].ToString()) : DateTime.Today;
                dtother_health_issues_action_followup_date.Checked = dtRow["other_health_issues_action_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_no_violence_Yes, rbtn_yn_no_violence_No, dtRow["yn_no_violence"].ToString());
                txtyn_no_violence_action.Text = dtRow["yn_no_violence_action"].ToString();
                txtyn_no_violence_out_come.Text = dtRow["yn_no_violence_out_come"].ToString();
                dtyn_no_violence_action_followup_date.Value = dtRow["yn_no_violence_action_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_no_violence_action_followup_date"].ToString()) : DateTime.Today;
                dtyn_no_violence_action_followup_date.Checked = dtRow["yn_no_violence_action_followup_date"].ToString() != string.Empty ? true : false;
                utilControls.RadioButtonSetSelection(rbtn_yn_stable_care_giver_Yes, rbtn_yn_stable_care_giver_No, dtRow["yn_stable_care_giver"].ToString());
                txtyn_stable_care_giver_action.Text = dtRow["yn_stable_care_giver_action"].ToString();
                dtyn_stable_care_giver_followup_date.Value = dtRow["yn_stable_care_giver_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_stable_care_giver_followup_date"].ToString()) : DateTime.Today;
                dtyn_stable_care_giver_followup_date.Checked = dtRow["yn_stable_care_giver_followup_date"].ToString() != string.Empty ? true : false;
                txtyn_stable_care_giver_out_come.Text = dtRow["yn_stable_care_giver_out_come"].ToString();
                txtother_safe_issues.Text = dtRow["other_safe_issues"].ToString();
                txtother_safe_issues_action.Text = dtRow["other_safe_issues_action"].ToString();
                dtother_safe_issues_followup_date.Value = dtRow["other_safe_issues_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["other_safe_issues_followup_date"].ToString()) : DateTime.Today;
                dtother_safe_issues_followup_date.Checked = dtRow["other_safe_issues_followup_date"].ToString() != string.Empty ? true : false;
                txtother_safe_issues_action_out_come.Text = dtRow["other_safe_issues_out_come"].ToString();
                utilControls.RadioButtonSetSelection(yn_stable_access_money_Yes, yn_stable_access_money_No, dtRow["yn_stable_access_money"].ToString());
                txtyn_stable_access_money_action.Text = dtRow["yn_stable_access_money_action"].ToString();
                dtyn_stable_access_money_followup_date.Value = dtRow["yn_stable_access_money_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_stable_access_money_followup_date"].ToString()) : DateTime.Today;
                dtyn_stable_access_money_followup_date.Checked = dtRow["yn_stable_access_money_followup_date"].ToString() != string.Empty ? true : false;
                yn_stable_access_money_out_come.Text = dtRow["yn_stable_access_money_out_come"].ToString();
                utilControls.RadioButtonSetSelection(rbtn_yn_stable_income_source_Yes, rbtn_yn_stable_income_source_No, dtRow["yn_stable_income_source"].ToString());
                txt_yn_stable_income_source_action.Text = dtRow["yn_stable_income_source_action"].ToString();
                dtyn_stable_income_source_followup_date.Value = dtRow["yn_stable_income_source_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_stable_income_source_followup_date"].ToString()) : DateTime.Today;
                dtyn_stable_income_source_followup_date.Checked = dtRow["yn_stable_income_source_followup_date"].ToString() != string.Empty ? true : false;
                txtyn_stable_income_source_out_come.Text = dtRow["yn_stable_income_source_out_come"].ToString();
                txtother_hes_issues.Text = dtRow["other_hes_issues"].ToString();
                txtother_hes_issues_action.Text = dtRow["other_hes_issues_action"].ToString();
                dtother_hes_issues_followup_date.Value = dtRow["other_hes_issues_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["other_hes_issues_followup_date"].ToString()) : DateTime.Today;
                dtother_hes_issues_followup_date.Checked = dtRow["other_hes_issues_followup_date"].ToString() != string.Empty ? true : false;
                txtother_hes_issues_out_come.Text = dtRow["other_hes_issues_out_come"].ToString();
                utilControls.RadioButtonSetSelection(rbtn_yn_ovc_regularly_attend_school_Yes, rbtn_yn_ovc_regularly_attend_school_No, rbtn_yn_ovc_regularly_attend_school_NA, dtRow["yn_ovc_regularly_attend_school"].ToString());
                txtyn_ovc_regularly_attend_school_action.Text = dtRow["yn_ovc_regularly_attend_school_action"].ToString();
                dtyn_ovc_regularly_attend_school_followup_date.Value = dtRow["yn_ovc_regularly_attend_school_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_ovc_regularly_attend_school_followup_date"].ToString()) : DateTime.Today;
                dtyn_ovc_regularly_attend_school_followup_date.Checked = dtRow["yn_ovc_regularly_attend_school_followup_date"].ToString() != string.Empty ? true : false;
                txtyn_ovc_regularly_attend_school_out_come.Text = dtRow["yn_ovc_regularly_attend_school_out_come"].ToString();
                utilControls.RadioButtonSetSelection(rbtn_yn_attained_tech_skill_Yes, rbtn_yn_attained_tech_skill_No, rbtn_yn_attained_tech_skill_NA, dtRow["yn_attained_tech_skill"].ToString());
                hh_household_improvement_plan.yn_attained_tech_skill_action_plan = txtyn_attained_tech_skill_action_plan.Text = dtRow["yn_attained_tech_skill_action_plan"].ToString();
                dtyn_attained_tech_skill_followup_date.Value = dtRow["yn_attained_tech_skill_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["yn_attained_tech_skill_followup_date"].ToString()) : DateTime.Today;
                dtyn_attained_tech_skill_followup_date.Checked = dtRow["yn_attained_tech_skill_followup_date"].ToString() != string.Empty ? true : false;
                txtyn_attained_tech_skill_out_come.Text = dtRow["yn_attained_tech_skill_out_come"].ToString();
                txtother_edu_issues.Text = dtRow["other_edu_issues"].ToString();
                txtother_edu_issues_action.Text = dtRow["other_edu_issues_action"].ToString();
                dtother_edu_issues_followup_date.Value = dtRow["other_edu_issues_followup_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["other_edu_issues_followup_date"].ToString()) : DateTime.Today;
                dtother_edu_issues_followup_date.Checked = dtRow["other_edu_issues_followup_date"].ToString() != string.Empty ? true : false;
                txtother_edu_issues_out_come.Text = dtRow["other_edu_issues_out_come"].ToString();
                dtOutComeDate.Value = dtRow["hip_out_come_date"].ToString() != string.Empty ? Convert.ToDateTime(dtRow["hip_out_come_date"].ToString()) : DateTime.Today;
                dtOutComeDate.Checked = dtRow["hip_out_come_date"].ToString() != string.Empty ? true : false;
                cboSocialWorker.SelectedValue = dtRow["sw_id"].ToString();
                txtSocialWorkerComment.Text = dtRow["sw_comment"].ToString();
                txtSupervisor.Text = dtRow["sw_supervisor_name"].ToString();
                txtSupervisorComment.Text = dtRow["sw_supervisor_comment"].ToString();
                #endregion FillControls
            }
        }


        protected bool ValidateInput()
        {
            bool isValid = false;

            if (!rbtn_yn_knows_status_of_children_Yes.Checked & (txtyn_knows_status_of_children_action.Text == string.Empty || !dtyn_knows_status_of_children_followup_date.Checked))
            {
                isValid = false;
            }
            else if (!rbtn_yn_positive_enrolled_on_art_Yes.Checked & !rbtn_yn_positive_enrolled_on_art_NA.Checked & (txtyn_positive_enrolled_on_art_action.Text == string.Empty || !dtyn_positive_enrolled_on_art_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_positive_supressing_Yes.Checked & !rbtn_yn_positive_supressing_NA.Checked & (txtyn_positive_supressing_action.Text == string.Empty || !dtyn_positive_supressing_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_positive_adhering_Yes.Checked & !rbtn_yn_positive_adhering_NA.Checked & (txtyn_positive_adhering_action.Text == string.Empty || !dtyn_positive_adhering_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_adolescent_hiv_prevention_Yes.Checked & !rbtn_yn_adolescent_hiv_prevention_NA.Checked & (txtyn_adolescent_hiv_prevention_action.Text == string.Empty || !dtyn_adolescent_hiv_prevention_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_child_undernourished_Yes.Checked  & !rbtn_yn_child_undernourished_NA.Checked & (txtyn_child_undernourished_action.Text == string.Empty || !dtyn_child_undernourished_followup_date.Checked)) { isValid = false; }
            else if (txtother_health_issues.Text != string.Empty &(txtother_health_issues_action.Text == string.Empty || !dtother_health_issues_action_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_no_violence_Yes.Checked & (txtyn_no_violence_action.Text == string.Empty || !dtyn_no_violence_action_followup_date.Checked)) { isValid = false; }
           /// else if (!rbtn_yn_birth_certificateYes.Checked & !rbtn_yn_birth_certificateNA.Checked & (txt_yn_birth_certificate_action.Text == string.Empty || !dt_yn_birth_certificates_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_stable_care_giver_Yes.Checked & (txtyn_stable_care_giver_action.Text == string.Empty || !dtyn_stable_care_giver_followup_date.Checked)) { isValid = false; }
            else if (txtother_safe_issues.Text != string.Empty & (txtother_safe_issues_action.Text == string.Empty || !dtother_safe_issues_followup_date.Checked)) { isValid = false; }
            else if (!yn_stable_access_money_Yes.Checked & (txtyn_stable_access_money_action.Text == string.Empty || !dtyn_stable_access_money_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_stable_income_source_Yes.Checked & (txt_yn_stable_income_source_action.Text == string.Empty || !dtyn_stable_income_source_followup_date.Checked)) { isValid = false; }
            else if (txtother_hes_issues.Text != string.Empty &(txtother_hes_issues_action.Text == string.Empty || !dtother_hes_issues_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_ovc_regularly_attend_school_Yes.Checked & !rbtn_yn_ovc_regularly_attend_school_NA.Checked & (txtyn_ovc_regularly_attend_school_action.Text == string.Empty || !dtyn_ovc_regularly_attend_school_followup_date.Checked)) { isValid = false; }
            else if (!rbtn_yn_attained_tech_skill_Yes.Checked & !rbtn_yn_attained_tech_skill_NA.Checked & (txtyn_attained_tech_skill_action_plan.Text == string.Empty || !dtyn_attained_tech_skill_followup_date.Checked)) { isValid = false; }
            else if (txtother_edu_issues.Text != string.Empty & (txtother_edu_issues_action.Text == string.Empty || !dtother_edu_issues_followup_date.Checked)) { isValid = false; }
            else if (cboSocialWorker.SelectedValue.ToString() == "-1" || txtSupervisor.Text == string.Empty || cboQuarter.SelectedValue.ToString() == "-1" || !dtInitialHip.Checked || cbovisitReason.Text == string.Empty || !dtTimeVisistDate.Checked || cboCaregiver.SelectedValue.ToString() == "-1") { isValid = false; }
            else if (chkOutCome.Checked & !dtOutComeDate.Checked) { isValid = false; }
            else { isValid = true; }

            return isValid;
        }

        private void rbtn_yn_knows_status_of_children_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if(!rbtn_yn_knows_status_of_children_Yes.Checked == true)
            {
                lblhiv_status.ForeColor = Color.Red;
            }
            else
                lblhiv_status.ForeColor = Color.Black;
        }

        private void rbtn_yn_knows_status_of_children_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_knows_status_of_children_Yes_CheckedChanged(rbtn_yn_knows_status_of_children_Yes,null);
        }

        private void rbtn_yn_positive_enrolled_on_art_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_positive_enrolled_on_art_Yes.Checked == true & !rbtn_yn_positive_enrolled_on_art_NA.Checked == true)
            {
                lblART.ForeColor = Color.Red;
            }
            else
                lblART.ForeColor = Color.Black;
        }

        private void rbtn_yn_positive_supressing_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_positive_supressing_Yes.Checked & !rbtn_yn_positive_supressing_NA.Checked)
            {
                lblsupress.ForeColor = Color.Red;
            }
            else
                lblsupress.ForeColor = Color.Black;
        }

        private void rbtn_yn_positive_enrolled_on_art_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_enrolled_on_art_Yes_CheckedChanged(rbtn_yn_positive_enrolled_on_art_Yes,null);
        }

        private void rbtn_yn_positive_supressing_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_supressing_Yes_CheckedChanged(rbtn_yn_positive_supressing_Yes, null);
        }

        private void rbtn_yn_positive_adhering_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_positive_adhering_Yes.Checked & !rbtn_yn_positive_adhering_NA.Checked)
            {
                lblAdhering.ForeColor = Color.Red;
            }
            else
            {
                lblAdhering.ForeColor = Color.Black;
            }
        }

        private void rbtn_yn_positive_adhering_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_adhering_Yes_CheckedChanged(rbtn_yn_positive_adhering_Yes,null);
        }

        private void rbtn_yn_adolescent_hiv_prevention_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_adolescent_hiv_prevention_Yes.Checked & !rbtn_yn_adolescent_hiv_prevention_NA.Checked)
            {
                lblhivPrevention.ForeColor = Color.Red;
            }
            else
                lblhivPrevention.ForeColor = Color.Black;
        }

        private void rbtn_yn_adolescent_hiv_prevention_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_adolescent_hiv_prevention_Yes_CheckedChanged(rbtn_yn_adolescent_hiv_prevention_Yes, null);
        }

        private void rbtn_yn_adolescent_hiv_prevention_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_adolescent_hiv_prevention_Yes_CheckedChanged(rbtn_yn_adolescent_hiv_prevention_Yes, null);
        }

        private void rbtn_yn_child_undernourished_Yes_Click(object sender, EventArgs e)
        {
            if (!rbtn_yn_child_undernourished_Yes.Checked & !rbtn_yn_child_undernourished_NA.Checked)
            {
                lblUndernourished.ForeColor = Color.Red;
            }
            else
                lblUndernourished.ForeColor = Color.Black;
        }

        private void rbtn_yn_child_undernourished_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_child_undernourished_Yes_Click(rbtn_yn_child_undernourished_Yes, null);
        }

        private void txtother_health_issues_TextChanged(object sender, EventArgs e)
        {
            if (txtother_health_issues.Text != string.Empty)
            {
                lblOtherHealthIssues.ForeColor = Color.Red;
            }
            else
            {
                lblOtherHealthIssues.ForeColor = Color.Black;
            }
        }

        private void rbtn_yn_no_violence_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_no_violence_Yes.Checked)
            {
                lblEmortionalViolence.ForeColor = Color.Red;
            }
            else
                lblEmortionalViolence.ForeColor = Color.Black;
        }

        private void rbtn_yn_no_violence_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_no_violence_Yes_CheckedChanged(rbtn_yn_no_violence_Yes, null);
        }

        private void rbtn_yn_stable_care_giver_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_stable_care_giver_Yes.Checked) { lblstableCaregiver.ForeColor = Color.Red; }
            else
                lblstableCaregiver.ForeColor = Color.Black;
        }

        private void rbtn_yn_stable_care_giver_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_stable_care_giver_Yes_CheckedChanged(rbtn_yn_stable_care_giver_Yes,null);
        }

        private void txtother_safe_issues_TextChanged(object sender, EventArgs e)
        {
            if (txtother_safe_issues.Text != string.Empty)
            {
                lblOtherSafeIssues.ForeColor = Color.Red;
            }
            else
                lblOtherSafeIssues.ForeColor = Color.Black;
        }

        private void yn_stable_access_money_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!yn_stable_access_money_Yes.Checked) { lblAccessMoney.ForeColor = Color.Red; }
            else
                lblAccessMoney.ForeColor = Color.Black;
        }

        private void yn_stable_access_money_No_CheckedChanged(object sender, EventArgs e)
        {
            yn_stable_access_money_Yes_CheckedChanged(yn_stable_access_money_Yes,null);
        }

        private void rbtn_yn_stable_income_source_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_stable_income_source_Yes.Checked)
            {
                lblstableIncomeSource.ForeColor = Color.Red;
            }
            else
                lblstableIncomeSource.ForeColor = Color.Black;
        }

        private void txtother_hes_issues_TextChanged(object sender, EventArgs e)
        {
            if (txtother_hes_issues.Text != string.Empty)
            {
                lblOtherHesIssues.ForeColor = Color.Red;
            }
            else
            lblOtherHesIssues.ForeColor = Color.Black;
        }

        private void rbtn_yn_ovc_regularly_attend_school_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_ovc_regularly_attend_school_Yes.Checked & !rbtn_yn_ovc_regularly_attend_school_NA.Checked)
            {
                lblAttendSchool.ForeColor = Color.Red;
            }
            else
                lblAttendSchool.ForeColor = Color.Black;
        }

        private void rbtn_yn_ovc_regularly_attend_school_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_ovc_regularly_attend_school_Yes_CheckedChanged(rbtn_yn_ovc_regularly_attend_school_Yes, null);
        }

        private void rbtn_yn_ovc_regularly_attend_school_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_ovc_regularly_attend_school_Yes_CheckedChanged(rbtn_yn_ovc_regularly_attend_school_Yes, null);
        }

        private void rbtn_yn_attained_tech_skill_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_yn_attained_tech_skill_Yes.Checked & !rbtn_yn_attained_tech_skill_NA.Checked) { lblTechnicalSkill.ForeColor = Color.Red; }
            else
                lblTechnicalSkill.ForeColor = Color.Black;
        }

        private void rbtn_yn_attained_tech_skill_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_attained_tech_skill_Yes_CheckedChanged(rbtn_yn_attained_tech_skill_Yes, null);
        }

        private void txtother_edu_issues_TextChanged(object sender, EventArgs e)
        {
            if (txtother_edu_issues.Text != string.Empty) { lblOtherEduIssues.ForeColor = Color.Red; }
            else
                lblOtherEduIssues.ForeColor = Color.Black;
        }

        protected void ResetDates()
        {
            dtInitialHip.Checked = false;
            dtTimeVisistDate.Checked = false;
            dtyn_knows_status_of_children_followup_date.Checked = false;
            dtyn_positive_enrolled_on_art_followup_date.Checked = false;
            dtyn_positive_supressing_followup_date.Checked = false;
            dtyn_positive_adhering_followup_date.Checked = false;
            dtyn_adolescent_hiv_prevention_followup_date.Checked = false;
            dtyn_child_undernourished_followup_date.Checked = false;
            dt_yn_birth_certificates_followup_date.Checked = false;
            dtother_health_issues_action_followup_date.Checked = false;
            dtyn_no_violence_action_followup_date.Checked = false;
            dtyn_stable_care_giver_followup_date.Checked = false;
            dtother_safe_issues_followup_date.Checked = false;
            dtyn_stable_access_money_followup_date.Checked = false;
            dtyn_stable_income_source_followup_date.Checked = false;
            dtother_hes_issues_followup_date.Checked = false;
            dtyn_ovc_regularly_attend_school_followup_date.Checked = false;
            dtyn_attained_tech_skill_followup_date.Checked = false;
            dtother_edu_issues_followup_date.Checked = false;
            dtOutComeDate.Checked = false;
        }

        private void chkOutCome_CheckedChanged(object sender, EventArgs e)
        {

            if (chkOutCome.Checked)
            {
                txtyn_knows_status_of_children_out_come.Enabled = true;
                txtyn_positive_enrolled_on_art_out_come.Enabled = true;
                txtyn_positive_supressing_out_come.Enabled = true;
                txtyn_positive_adhering_out_come.Enabled = true;
                txtyn_adolescent_hiv_prevention_out_come.Enabled = true;
                txtyn_child_undernourished_out_come.Enabled = true;
                txtother_health_issues_out_come.Enabled = true;
                txtyn_no_violence_out_come.Enabled = true;
                txtyn_stable_care_giver_out_come.Enabled = true;
                txtother_safe_issues_action_out_come.Enabled = true;
                yn_stable_access_money_out_come.Enabled = true;
                txtyn_stable_income_source_out_come.Enabled = true;
                txtother_hes_issues_out_come.Enabled = true;
                txtyn_ovc_regularly_attend_school_out_come.Enabled = true;
                txtyn_attained_tech_skill_out_come.Enabled = true;
                txtother_edu_issues_out_come.Enabled = true;
                dtOutComeDate.Enabled = true;
                lblOutComeDate.ForeColor = Color.Red;

                #region DisableControls
                panelResponse01.Enabled = false;
                panelResponse02.Enabled = false;
                panelResponse03.Enabled = false;
                panelResponse04.Enabled = false;
                panelResponse05.Enabled = false;
                panelResponse06.Enabled = false;
                panelResponse07.Enabled = false;
                panelResponse08.Enabled = false;
                panelResponse09.Enabled = false;
                panelResponse10.Enabled = false;
                panelResponse11.Enabled = false;
                panelResponse12.Enabled = false;
                panelResponse13.Enabled = false;
                txtother_health_issues.Enabled = false;
                txtother_safe_issues.Enabled = false;
                txtother_hes_issues.Enabled = false;
                txtother_edu_issues.Enabled = false;
                txtyn_knows_status_of_children_action.Enabled = false;
                txtyn_positive_enrolled_on_art_action.Enabled = false;
                txtyn_positive_supressing_action.Enabled = false;
                txtyn_positive_adhering_action.Enabled = false;
                txtyn_adolescent_hiv_prevention_action.Enabled = false;
                txtyn_child_undernourished_action.Enabled = false;
                txtother_health_issues_action.Enabled = false;
                txtyn_no_violence_action.Enabled = false;
                txtyn_stable_care_giver_action.Enabled = false;
                txtother_safe_issues_action.Enabled = false;
                txtyn_stable_access_money_action.Enabled = false;
                txt_yn_stable_income_source_action.Enabled = false;
                txt_yn_birth_certificate_action.Enabled = false;
                txtother_hes_issues_action.Enabled = false;
                txtyn_ovc_regularly_attend_school_action.Enabled = false;
                txtyn_attained_tech_skill_action_plan.Enabled = false;
                txtother_edu_issues_action.Enabled = false;

                dtInitialHip.Enabled = false;
                dtTimeVisistDate.Enabled = false;
                dtyn_knows_status_of_children_followup_date.Enabled = false;
                dtyn_positive_enrolled_on_art_followup_date.Enabled = false;
                dtyn_positive_supressing_followup_date.Enabled = false;
                dtyn_positive_adhering_followup_date.Enabled = false;
                dt_yn_birth_certificates_followup_date.Enabled = false;
                dtyn_adolescent_hiv_prevention_followup_date.Enabled = false;
                dtyn_child_undernourished_followup_date.Enabled = false;
                dtother_health_issues_action_followup_date.Enabled = false;
                dtyn_no_violence_action_followup_date.Enabled = false;
                dtyn_stable_care_giver_followup_date.Enabled = false;
                dtother_safe_issues_followup_date.Enabled = false;
                dtyn_stable_access_money_followup_date.Enabled = false;
                dtyn_stable_income_source_followup_date.Enabled = false;
                dtother_hes_issues_followup_date.Enabled = false;
                dtyn_ovc_regularly_attend_school_followup_date.Enabled = false;
                dtyn_attained_tech_skill_followup_date.Enabled = false;
                dtother_edu_issues_followup_date.Enabled = false;

                #endregion DisableControls




            }
            else
            {
                txtyn_knows_status_of_children_out_come.Enabled = false;
                txtyn_positive_enrolled_on_art_out_come.Enabled = false;
                txtyn_positive_supressing_out_come.Enabled = false;
                txtyn_positive_adhering_out_come.Enabled = false;
                txtyn_adolescent_hiv_prevention_out_come.Enabled = false;
                txtyn_child_undernourished_out_come.Enabled = false;
                txtother_health_issues_out_come.Enabled = false;
                txtyn_no_violence_out_come.Enabled = false;
                txtyn_stable_care_giver_out_come.Enabled = false;
                txtother_safe_issues_action_out_come.Enabled = false;
                yn_stable_access_money_out_come.Enabled = false;
                txtyn_stable_income_source_out_come.Enabled = false;
                txtother_hes_issues_out_come.Enabled = false;
                txtyn_ovc_regularly_attend_school_out_come.Enabled = false;
                txtyn_attained_tech_skill_out_come.Enabled = false;
                txtother_edu_issues_out_come.Enabled = false;
                dtOutComeDate.Enabled = false;
                lblOutComeDate.ForeColor = Color.Black;

                #region EnableControls
                panelResponse01.Enabled = true;
                panelResponse02.Enabled = true;
                panelResponse03.Enabled = true;
                panelResponse04.Enabled = true;
                panelResponse05.Enabled = true;
                panelResponse06.Enabled = true;
                panelResponse07.Enabled = true;
                panelResponse08.Enabled = true;
                panelResponse09.Enabled = true;
                panelResponse10.Enabled = true;
                panelResponse11.Enabled = true;
                panelResponse12.Enabled = true;
                panelResponse13.Enabled = true;
                txtother_health_issues.Enabled = true;
                txtother_safe_issues.Enabled = true;
                txtother_hes_issues.Enabled = true;
                txtother_edu_issues.Enabled = true;
                txtyn_knows_status_of_children_action.Enabled = true;
                txtyn_positive_enrolled_on_art_action.Enabled = true;
                txtyn_positive_supressing_action.Enabled = true;
                txtyn_positive_adhering_action.Enabled = true;
                txtyn_adolescent_hiv_prevention_action.Enabled = true;
                txtyn_child_undernourished_action.Enabled = true;
                txtother_health_issues_action.Enabled = true;
                txtyn_no_violence_action.Enabled = true;
                txtyn_stable_care_giver_action.Enabled = true;
                txtother_safe_issues_action.Enabled = true;
                txtyn_stable_access_money_action.Enabled = true;
                txt_yn_stable_income_source_action.Enabled = true;
                txtother_hes_issues_action.Enabled = true;
                txtyn_ovc_regularly_attend_school_action.Enabled = true;
                txtyn_attained_tech_skill_action_plan.Enabled = true;
                txtother_edu_issues_action.Enabled = true;
                txt_yn_birth_certificate_action.Enabled = true;

                dtInitialHip.Enabled = true;
                dtTimeVisistDate.Enabled = true;
                dtyn_knows_status_of_children_followup_date.Enabled = true;
                dtyn_positive_enrolled_on_art_followup_date.Enabled = true;
                dtyn_positive_supressing_followup_date.Enabled = true;
                dtyn_positive_adhering_followup_date.Enabled = true;
                dtyn_adolescent_hiv_prevention_followup_date.Enabled = true;
                dtyn_child_undernourished_followup_date.Enabled = true;
                dtother_health_issues_action_followup_date.Enabled = true;
                dtyn_no_violence_action_followup_date.Enabled = true;
                dtyn_stable_care_giver_followup_date.Enabled = true;
                dtother_safe_issues_followup_date.Enabled = true;
                dtyn_stable_access_money_followup_date.Enabled = true;
                dtyn_stable_income_source_followup_date.Enabled = true;
                dtother_hes_issues_followup_date.Enabled = true;
                dtyn_ovc_regularly_attend_school_followup_date.Enabled = true;
                dtyn_attained_tech_skill_followup_date.Enabled = true;
                dtother_edu_issues_followup_date.Enabled = true;
                dt_yn_birth_certificates_followup_date.Enabled = true;

                #endregion EnableControls
            }

        }

        protected void ShowHideResponseCheckBox()
        {
            if (hh_household_improvement_plan.hip_id == string.Empty) { chkOutCome.Visible = false; chkOutCome_CheckedChanged(chkOutCome, null); }
            else { chkOutCome.Visible = true;chkOutCome_CheckedChanged(chkOutCome, null);  }
        }

        private void rbtn_yn_attained_tech_skill_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_attained_tech_skill_Yes_CheckedChanged(rbtn_yn_attained_tech_skill_Yes, null);
        }

        private void rbtn_yn_child_undernourished_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_child_undernourished_Yes_Click(rbtn_yn_child_undernourished_Yes, null);
        }

        private void tableLayoutPanel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtn_yn_stable_income_source_No_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_stable_income_source_Yes_CheckedChanged(rbtn_yn_stable_income_source_Yes,null);
        }

        private void rbtn_yn_positive_enrolled_on_art_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_enrolled_on_art_Yes_CheckedChanged(rbtn_yn_positive_enrolled_on_art_Yes, null);
        }

        private void rbtn_yn_positive_supressing_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_supressing_Yes_CheckedChanged(rbtn_yn_positive_supressing_Yes, null);
        }

        private void rbtn_yn_positive_adhering_NA_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_positive_adhering_Yes_CheckedChanged(rbtn_yn_positive_adhering_Yes, null);
        }
    }
}
