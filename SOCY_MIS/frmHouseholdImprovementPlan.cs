using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;
using PSAUtils;
using PSAUtilsWin32;

namespace SOCY_MIS
{
    public partial class frmHouseholdImprovementPlan : UserControl
    {
        DataTable dt = null;
        private frmHousehold frmCll = null;
        private Master frmMST = null;

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
        public frmHouseholdImprovementPlan()
        {
            InitializeComponent();
        }

        private void frmHouseholdImprovementPlan_Load(object sender, EventArgs e)
        {
            Return_lookups();
            display_hh_details();
            Return_household_members();
            get_hh_member_ages();
            Return_paraSocialWorkers();
            ReturnHipList(SystemConstants.hh_record_guid);

            UncheckDates();

            #region Hip details
            if (hh_household_improvement_plan.hip_id_display != string.Empty)
            {
                Return_HipDetails(hh_household_improvement_plan.hip_id_display);
                lblhipID.Text = hh_household_improvement_plan.hip_id_display;
            }
            #endregion Hip details
        }

        protected void UncheckDates()
        {
            //uncheck datetime pickers
            dtHealth.Checked = false;
            dtSafety.Checked = false;
            dtStable.Checked = false;
            dtSchooled.Checked = false;
            dtTimeVisistDate.Checked = false;
        }

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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                save_update_hh_hip_details();
               
                ReturnHipList(SystemConstants.hh_record_guid);
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #region Save HIP Details
        protected void save_update_hh_hip_details()
        {
            if (ValidateIput() == false)
            {
                MessageBox.Show("Please input all required values", "SOCY Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (lblhipID.Text == "lblhipID")
                {
                    //const string FMT = "O";

                    #region hipID
                    hh_household_improvement_plan.hip_id = Guid.NewGuid().ToString();
                    #endregion hipID

                    hh_household_improvement_plan.hh_code = txtHHCode.Text;
                    hh_household_improvement_plan.hh_id = SystemConstants.hh_record_guid;
                    hh_household_improvement_plan.visit_date = dtTimeVisistDate.Value.Date;
                    hh_household_improvement_plan.ov_below_seventeen_yrs_male = Convert.ToInt32(txtmalebelowseventeen.Text);
                    hh_household_improvement_plan.ov_below_seventeen_yrs_female = Convert.ToInt32(txtFemalebelowseventeen.Text);
                    hh_household_improvement_plan.ov_above_eighteen_yrs_male = Convert.ToInt32(txtmaleboveseventeen.Text);
                    hh_household_improvement_plan.ov_above_eighteen_yrs_female = Convert.ToInt32(txtFemaleboveseventeen.Text);
                    hh_household_improvement_plan.health_knows_status_of_children = utilControls.RadioButtonGetSelection(rbtnStatusYes, rbtnStatusNo);

                    //set ART to NA if all hh members are negative
                    if (hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 1) == 0 && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 3) == 0)
                    {
                        rdnArtNA.Checked = true;
                    }

                    hh_household_improvement_plan.health_enrolled_on_art = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo, rdnArtNA);

                    #region Healthy
                    hh_household_improvement_plan.health_enrolled_on_art = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo);
                    hh_household_improvement_plan.health_action_plan = txtActionPlanHealth.Text;
                    hh_household_improvement_plan.health_follow_up_date = dtHealth.Checked == true ? dtHealth.Value.Date.ToString("MM/dd/yyyy") : string.Empty;

                    #region health status
                    if (rbtnStatusYes.Checked == true && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 1) == 0)
                    {
                        hh_household_improvement_plan.household_is_healthy = "1";
                    }
                    else if (rbtnStatusYes.Checked == false && rbtnStatusNo.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_healthy = "2";
                    }
                    else if (rbtnStatusYes.Checked == true && (hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 1) > 0 || hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 3) > 0) && rdnArtYes.Checked == false)
                    {
                        hh_household_improvement_plan.household_is_healthy = "2";
                    }
                    else if (rbtnStatusYes.Checked == true && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 1) > 0 && rdnArtYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_healthy = "1";
                    }
                    #endregion health status
                    #endregion Healthy

                    #region Safe
                    hh_household_improvement_plan.safe_has_birth_certificates = utilControls.RadioButtonGetSelection(rdnbirthcertYes, rdnbirthcertNo);
                    hh_household_improvement_plan.safe_no_child_abuse = utilControls.RadioButtonGetSelection(rdnchildAbuseYes, rdnchildAbuseNo);
                    hh_household_improvement_plan.safe_action_plan = txtActionPlanSafety.Text;
                    hh_household_improvement_plan.safe_follow_up_date = dtSafety.Checked == true ? dtSafety.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Safety Status
                    if (rdnbirthcertYes.Checked == true && rdnchildAbuseYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_safe = "1";
                    }
                    else
                    {
                        hh_household_improvement_plan.household_is_safe = "2";
                    }
                    #endregion Safety Status
                    #endregion Safe

                    #region Stable
                    hh_household_improvement_plan.stable_source_of_income = utilControls.RadioButtonGetSelection(rdnIncomeYes, rdnIncomeNo);
                    hh_household_improvement_plan.stable_financial_services = utilControls.RadioButtonGetSelection(rdnFinancialYes, rdnFinancialNo);
                    hh_household_improvement_plan.stable_two_or_more_meals = utilControls.RadioButtonGetSelection(rdnMealsYes, rdnMealsNo);
                    hh_household_improvement_plan.stable_action_plan = txtActionPlanStable.Text;
                    hh_household_improvement_plan.stable_follow_up_date = dtStable.Checked == true ? dtStable.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Stable status
                    if (rdnIncomeYes.Checked == true && rdnFinancialYes.Checked == true && rdnMealsYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_stable = "1";
                    }
                    else { hh_household_improvement_plan.household_is_stable = "2"; }
                    #endregion Stable status

                    #endregion Stable

                    #region Schooled
                    //hh_household_improvement_plan.schooled_all_attending_school = utilControls.RadioButtonGetSelection(rdnAttendingSchoolYes, rdnAttendingSchoolNo);
                    hh_household_improvement_plan.schooled_all_attending_school = utilControls.RadioButtonGetSelection(rdnAttendingSchoolYes, rdnAttendingSchoolNo, rdnAttendingSchoolNA);
                    hh_household_improvement_plan.schooled_attained_techinical_skill = utilControls.RadioButtonGetSelection(rdnTechnicalYes, rdnTechnicalNo, rdnTechnicalNA);
                    hh_household_improvement_plan.schooled_attained_techinical_skill = utilControls.RadioButtonGetSelection(rdnTechnicalYes, rdnTechnicalNo);
                    hh_household_improvement_plan.schooled_others = string.Empty;//capture others for schooled
                    hh_household_improvement_plan.schooled_action_plan = txtActionPlanSchooled.Text;
                    hh_household_improvement_plan.schooled_follow_up_date = dtSchooled.Checked == true ? dtSchooled.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Schooled Status
                    if (rdnAttendingSchoolYes.Checked == true && rdnTechnicalNA.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_schooled = "1";
                    }
                    else if (rdnAttendingSchoolYes.Checked == true && rdnTechnicalYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_schooled = "1";
                    }
                    else if (rdnAttendingSchoolNo.Checked == true && rdnTechnicalYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_schooled = "1";
                    }
                    else if (rdnAttendingSchoolNo.Checked == true && rdnTechnicalYes.Checked == false)
                    {
                        hh_household_improvement_plan.household_is_schooled = "2";
                    }
                    #endregion Schooled Status

                    #endregion Schooled

                    hh_household_improvement_plan.sw_id = cboSocialWorker.SelectedValue.ToString();
                    hh_household_improvement_plan.sw_comment = txtSocialWorkerComment.Text;
                    hh_household_improvement_plan.usr_id_create = SystemConstants.user_id;
                    hh_household_improvement_plan.usr_id_update = SystemConstants.user_id;
                    hh_household_improvement_plan.usr_date_create = DateTime.Today;
                    hh_household_improvement_plan.usr_date_update = DateTime.Today;
                    hh_household_improvement_plan.ofc_id = SystemConstants.ofc_id;
                    hh_household_improvement_plan.district_id = SystemConstants.Return_office_district();

                    //save
                    hh_household_improvement_plan.save_update_hh_hip_details("insert");
                    MessageBox.Show("Success");
                    ClearControls();
                }
                else
                {

                    hh_household_improvement_plan.hip_id = lblhipID.Text;

                    hh_household_improvement_plan.hh_code = txtHHCode.Text;
                    hh_household_improvement_plan.hh_id = SystemConstants.hh_record_guid;
                    hh_household_improvement_plan.visit_date = dtTimeVisistDate.Value.Date;
                    hh_household_improvement_plan.ov_below_seventeen_yrs_male = Convert.ToInt32(txtmalebelowseventeen.Text);
                    hh_household_improvement_plan.ov_below_seventeen_yrs_female = Convert.ToInt32(txtFemalebelowseventeen.Text);
                    hh_household_improvement_plan.ov_above_eighteen_yrs_male = Convert.ToInt32(txtmaleboveseventeen.Text);
                    hh_household_improvement_plan.ov_above_eighteen_yrs_female = Convert.ToInt32(txtFemaleboveseventeen.Text);

                    #region Healthy
                    hh_household_improvement_plan.health_enrolled_on_art = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo);
                    hh_household_improvement_plan.health_action_plan = txtActionPlanHealth.Text;
                    hh_household_improvement_plan.health_follow_up_date = dtHealth.Checked == true ? dtHealth.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region health status
                    if (rbtnStatusYes.Checked == true && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 2) == 0)
                    {
                        hh_household_improvement_plan.household_is_healthy = "1";
                        hh_household_improvement_plan.health_knows_status_of_children = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo, rdnArtNA);
                    }
                    else if (rbtnStatusYes.Checked == false && rbtnStatusNo.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_healthy = "2";
                        hh_household_improvement_plan.health_knows_status_of_children = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo, rdnArtNA);
                    }
                    else if (rbtnStatusYes.Checked == true && (hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 2) > 0 || hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 3) > 0) && rdnArtYes.Checked == false)
                    {
                        hh_household_improvement_plan.household_is_healthy = "2";
                        hh_household_improvement_plan.health_knows_status_of_children = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo, rdnArtNA);
                    }
                    else if (rbtnStatusYes.Checked == true && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 2) > 0 && rdnArtYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_healthy = "1";
                        hh_household_improvement_plan.health_knows_status_of_children = utilControls.RadioButtonGetSelection(rdnArtYes, rdnArtNo, rdnArtNA);
                    }
                    #endregion health status
                    #endregion Healthy

                    #region Safe
                    hh_household_improvement_plan.safe_has_birth_certificates = utilControls.RadioButtonGetSelection(rdnbirthcertYes, rdnbirthcertNo);
                    hh_household_improvement_plan.safe_no_child_abuse = utilControls.RadioButtonGetSelection(rdnchildAbuseYes, rdnchildAbuseNo);
                    hh_household_improvement_plan.safe_action_plan = txtActionPlanSafety.Text;
                    hh_household_improvement_plan.safe_follow_up_date = dtSafety.Checked == true ? dtSafety.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Safety Status
                    if (rdnbirthcertYes.Checked == true && rdnchildAbuseNo.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_safe = "1";
                    }
                    else
                    {
                        hh_household_improvement_plan.household_is_safe = "2";
                    }
                    #endregion Safety Status
                    #endregion Safe

                    #region Stable
                    hh_household_improvement_plan.stable_source_of_income = utilControls.RadioButtonGetSelection(rdnIncomeYes, rdnIncomeNo);
                    hh_household_improvement_plan.stable_financial_services = utilControls.RadioButtonGetSelection(rdnFinancialYes, rdnFinancialNo);
                    hh_household_improvement_plan.stable_two_or_more_meals = utilControls.RadioButtonGetSelection(rdnMealsYes, rdnMealsNo);
                    hh_household_improvement_plan.stable_action_plan = txtActionPlanStable.Text;
                    hh_household_improvement_plan.stable_follow_up_date = dtStable.Checked == true ? dtStable.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Stable status
                    if (rdnIncomeYes.Checked == true && rdnFinancialYes.Checked == true && rdnMealsYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_stable = "1";
                    }
                    else { hh_household_improvement_plan.household_is_stable = "2"; }
                    #endregion Stable status

                    #endregion Stable

                    #region Schooled
                    hh_household_improvement_plan.schooled_all_attending_school = utilControls.RadioButtonGetSelection(rdnAttendingSchoolYes, rdnAttendingSchoolNo, rdnAttendingSchoolNA);
                    hh_household_improvement_plan.schooled_attained_techinical_skill = utilControls.RadioButtonGetSelection(rdnTechnicalYes, rdnTechnicalNo, rdnTechnicalNA);
                    hh_household_improvement_plan.schooled_others = string.Empty;//capture others for schooled
                    hh_household_improvement_plan.schooled_action_plan = txtActionPlanSchooled.Text;
                    hh_household_improvement_plan.schooled_follow_up_date = dtSchooled.Checked == true ? dtSchooled.Value.Date.ToString("MM / dd / yyyy") : string.Empty;

                    #region Schooled Status
                    if (rdnAttendingSchoolYes.Checked == true && rdnTechnicalNA.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_schooled = "1";
                    }
                    else if (rdnAttendingSchoolNo.Checked == true && rdnTechnicalYes.Checked == true)
                    {
                        hh_household_improvement_plan.household_is_schooled = "1";
                    }
                    else if (rdnAttendingSchoolNo.Checked == true && rdnTechnicalYes.Checked == false)
                    {
                        hh_household_improvement_plan.household_is_schooled = "2";
                    }
                    #endregion Schooled Status

                    #endregion Schooled
                    hh_household_improvement_plan.sw_id = cboSocialWorker.SelectedValue.ToString();
                    hh_household_improvement_plan.sw_comment = txtSocialWorkerComment.Text;
                    hh_household_improvement_plan.usr_id_update = SystemConstants.user_id;
                    hh_household_improvement_plan.usr_date_update = DateTime.Today;

                    //save
                    hh_household_improvement_plan.save_update_hh_hip_details("update");
                    MessageBox.Show("Success");

                }
            }

        }

        protected void TriggerHealthRequiredValues()
        {
            if (rbtnStatusYes.Checked == true && rdnArtNo.Checked == true)
            {
                lblHealthActionPlan.ForeColor = Color.Red;
                lblHealthFollowupdate.ForeColor = Color.Red;
            }
            else if (rbtnStatusNo.Checked == true)
            {
                lblHealthActionPlan.ForeColor = Color.Red;
                lblHealthFollowupdate.ForeColor = Color.Red;
            }
            else
            {
                lblHealthActionPlan.ForeColor = Color.Black;
                lblHealthFollowupdate.ForeColor = Color.Black;
            }
        }

        protected void TriggerSafetyRequiredValues()
        {
            if (rdnbirthcertYes.Checked == true && rdnchildAbuseNo.Checked == true)
            {
                lblSafeActionPlan.ForeColor = Color.Red;
                lblSafetyFollowupdate.ForeColor = Color.Red;
            }
            else if (rdnbirthcertNo.Checked == true || rdnchildAbuseNo.Checked == true)
            {
                lblSafeActionPlan.ForeColor = Color.Red;
                lblSafetyFollowupdate.ForeColor = Color.Red;
            }
            else
            {
                lblSafeActionPlan.ForeColor = Color.Black;
                lblSafetyFollowupdate.ForeColor = Color.Black;
            }
        }

        protected void TriggerStableRequiredValues()
        {
            if (rdnIncomeYes.Checked == false || rdnFinancialYes.Checked == false || rdnMealsYes.Checked == false)
            {
                lblStableActionPlan.ForeColor = Color.Red;
                lblStableFollowupdate.ForeColor = Color.Red;
            }
            else
            {
                lblStableActionPlan.ForeColor = Color.Black;
                lblStableFollowupdate.ForeColor = Color.Black;
            }
        }

        protected void TriggerSchooledRequiredValues()
        {
            if (rdnAttendingSchoolYes.Checked == true && rdnTechnicalNo.Checked == true)
            {
                lblSchooledActionPlan.ForeColor = Color.Red;
                lblSchooledFollowupdate.ForeColor = Color.Red;
            }
            else if (rdnAttendingSchoolNo.Checked == true)
            {
                lblSchooledActionPlan.ForeColor = Color.Red;
                lblSchooledFollowupdate.ForeColor = Color.Red;
            }
            else
            {
                lblSchooledActionPlan.ForeColor = Color.Black;
                lblSchooledFollowupdate.ForeColor = Color.Black;
            }
        }

        protected bool ValidateIput()
        {
            bool ArgsValid = false;

            if ((rbtnStatusYes.Checked == false && rbtnStatusNo.Checked == false) || (rdnArtYes.Checked == false && rdnArtNo.Checked == false && rdnArtNA.Checked == false)
                || (rdnbirthcertYes.Checked == false && rdnbirthcertNo.Checked == false) || (rdnchildAbuseYes.Checked == false && rdnchildAbuseNo.Checked == false) ||
                (rdnIncomeYes.Checked == false && rdnIncomeNo.Checked == false) || (rdnFinancialYes.Checked == false && rdnFinancialNo.Checked == false) ||
                (rdnMealsYes.Checked == false && rdnMealsNo.Checked == false) || (rdnAttendingSchoolYes.Checked == false && rdnAttendingSchoolNo.Checked == false && rdnAttendingSchoolNA.Checked == false) ||
                (rdnTechnicalYes.Checked == false && rdnTechnicalNo.Checked == false && rdnTechnicalNA.Checked == false)
                || ((lblHealthActionPlan.ForeColor == Color.Red && txtActionPlanHealth.Text == string.Empty) || (lblHealthFollowupdate.ForeColor == Color.Red && dtHealth.Checked == false) || (lblSafeActionPlan.ForeColor == Color.Red && txtActionPlanSafety.Text == string.Empty) ||
                (lblSafetyFollowupdate.ForeColor == Color.Red && dtSafety.Checked == false) || (lblStableActionPlan.ForeColor == Color.Red && txtActionPlanStable.Text == string.Empty) || (lblStableFollowupdate.ForeColor == Color.Red && dtStable.Checked == false) ||
                (lblSchooledActionPlan.ForeColor == Color.Red && txtActionPlanSchooled.Text == string.Empty) || (lblSchooledFollowupdate.ForeColor == Color.Red && dtSchooled.Checked == false) || cboSocialWorker.SelectedValue.ToString() == "-1" || dtTimeVisistDate.Checked == false))
            {
                ArgsValid = false;
            }
            else
            {
                ArgsValid = true;
            }

            return ArgsValid;
        }

        #endregion Save HIP Details

        private void rbtnStatusYes_CheckedChanged(object sender, EventArgs e)
        {
            if (hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 1) == 0 && hh_household_improvement_plan.Return_hhm_hiv_status_from_hhassessment(SystemConstants.hh_record_guid, 3) == 0)
            {
                rdnArtNA.Checked = true;
            }

            TriggerHealthRequiredValues();
        }

        #region Health Triggers
        private void rbtnStatusNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerHealthRequiredValues();
        }

        private void rdnArtYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerHealthRequiredValues();
        }

        private void rdnArtNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerHealthRequiredValues();
        }

        #endregion Health Triggers

        private void rdnbirthcertYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSafetyRequiredValues();
        }

        private void rdnbirthcertNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSafetyRequiredValues();
        }

        private void rdnchildAbuseYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSafetyRequiredValues();
        }

        private void rdnchildAbuseNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSafetyRequiredValues();
        }

        private void rdnIncomeYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnIncomeNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnFinancialYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnFinancialNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnMealsYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnMealsNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerStableRequiredValues();
        }

        private void rdnAttendingSchoolYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSchooledRequiredValues();
        }

        private void rdnAttendingSchoolNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSchooledRequiredValues();
        }

        private void rdnTechnicalYes_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSchooledRequiredValues();
        }

        private void rdnTechnicalNo_CheckedChanged(object sender, EventArgs e)
        {
            TriggerSchooledRequiredValues();
        }

        #region Hip List
        protected void ReturnHipList(string hh_id)
        {
            DataTable dt = hh_household_improvement_plan.Return_HHHipList(hh_id);
            if (dt.Rows.Count > 0)
            {
                gdv_hh_hip_details.DataSource = dt;

                gdv_hh_hip_details.Columns["hh_code"].HeaderText = "Household Code";
                gdv_hh_hip_details.Columns["visit_date"].HeaderText = "Visist Date";

                gdv_hh_hip_details.Columns["hip_id"].Visible = false;


                gdv_hh_hip_details.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_hh_hip_details.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_hh_hip_details.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_hh_hip_details.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_hh_hip_details.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_hh_hip_details.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_hh_hip_details.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_hh_hip_details.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_hh_hip_details.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_hh_hip_details.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdv_hh_hip_details.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdv_hh_hip_details.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        #endregion Hip List

        #region Hip Details
        protected void Return_HipDetails(string hip_id)
        {
            DataTable dt = hh_household_improvement_plan.Return_HipDetails(hip_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                #region Radio Buttons
                utilControls.RadioButtonSetSelection(rbtnStatusYes, rbtnStatusNo, dtRow["health_knows_status_of_children"].ToString());
                utilControls.RadioButtonSetSelection(rdnArtYes, rdnArtNo, rdnArtNA, dtRow["health_enrolled_on_art"].ToString());
                utilControls.RadioButtonSetSelection(rdnbirthcertYes, rdnbirthcertNo, dtRow["safe_has_birth_certificates"].ToString());
                utilControls.RadioButtonSetSelection(rdnchildAbuseYes, rdnchildAbuseNo, dtRow["safe_no_child_abuse"].ToString());
                utilControls.RadioButtonSetSelection(rdnIncomeYes, rdnIncomeNo, dtRow["stable_source_of_income"].ToString());
                utilControls.RadioButtonSetSelection(rdnFinancialYes, rdnFinancialNo, dtRow["stable_financial_services"].ToString());
                utilControls.RadioButtonSetSelection(rdnMealsYes, rdnMealsNo, dtRow["stable_two_or_more_meals"].ToString());
                utilControls.RadioButtonSetSelection(rdnAttendingSchoolYes, rdnAttendingSchoolNo, rdnAttendingSchoolNA, dtRow["schooled_all_attending_school"].ToString());
                utilControls.RadioButtonSetSelection(rdnTechnicalYes, rdnTechnicalNo, rdnTechnicalNA, dtRow["schooled_attained_techinical_skill"].ToString());

                #endregion  Radio Buttons

                #region Texboxes
                txtActionPlanHealth.Text = dtRow["health_action_plan"].ToString();
                txtActionPlanSafety.Text = dtRow["safe_action_plan"].ToString();
                txtActionPlanStable.Text = dtRow["stable_action_plan"].ToString();
                txtActionPlanSchooled.Text = dtRow["schooled_action_plan"].ToString();
                txtSocialWorkerComment.Text = dtRow["sw_comment"].ToString();
                #endregion Textboxes

                #region Dates
                if (dtRow["health_follow_up_date"].ToString() != string.Empty)
                {
                    dtHealth.Value = Convert.ToDateTime(dtRow["health_follow_up_date"].ToString());
                    dtHealth.Checked = true;
                }

                if (dtRow["safe_follow_up_date"].ToString() != string.Empty)
                {
                    dtSafety.Value = Convert.ToDateTime(dtRow["safe_follow_up_date"].ToString());
                    dtSafety.Checked = true;
                }

                if (dtRow["stable_follow_up_date"].ToString() != string.Empty)
                {
                    dtStable.Value = Convert.ToDateTime(dtRow["stable_follow_up_date"].ToString());
                    dtStable.Checked = true;
                }

                if (dtRow["schooled_follow_up_date"].ToString() != string.Empty)
                {
                    dtSchooled.Value = Convert.ToDateTime(dtRow["schooled_follow_up_date"].ToString());
                    dtSchooled.Checked = true;
                }

                dtTimeVisistDate.Value = Convert.ToDateTime(dtRow["visit_date"]);

                #endregion Dates

                #region AccessControl
                string ofc_id = dtRow["ofc_id"].ToString();
                //btnsave.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                panelMain.Enabled = false;
                #endregion AccessControl

                #region Combos
                cboSocialWorker.SelectedValue = dtRow["sw_id"].ToString();
                #endregion Combos

            }
        }
        #endregion Hip Details

        private void gdv_hh_hip_details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv_hh_hip_details.Rows.Count != 0)
            {
                string hip_id = gdv_hh_hip_details.CurrentRow.Cells[0].Value.ToString();
                Return_HipDetails(hip_id);
                lblhipID.Text = hip_id;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            panelMain.Enabled = true;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void ClearControls()
        {
            #region Radio buttons
            rbtnStatusYes.Checked = false;
            rbtnStatusNo.Checked = false;
            rdnArtYes.Checked = false;
            rdnArtNo.Checked = false;
            rdnArtNA.Checked = false;
            rdnbirthcertYes.Checked = false;
            rdnbirthcertNo.Checked = false;
            rdnchildAbuseYes.Checked = false;
            rdnchildAbuseNo.Checked = false;
            rdnIncomeYes.Checked = false;
            rdnIncomeNo.Checked = false;
            rdnFinancialYes.Checked = false;
            rdnFinancialNo.Checked = false;
            rdnMealsYes.Checked = false;
            rdnMealsNo.Checked = false;
            rdnAttendingSchoolYes.Checked = false;
            rdnAttendingSchoolNo.Checked = false;
            rdnTechnicalYes.Checked = false;
            rdnTechnicalNo.Checked = false;
            rdnTechnicalNA.Checked = false;
            rdnAttendingSchoolNA.Checked = false;
            #endregion Radio buttons

            #region Labels
            lblHealthActionPlan.ForeColor = Color.Black;
            lblHealthFollowupdate.ForeColor = Color.Black;
            lblSafeActionPlan.ForeColor = Color.Black;
            lblSafetyFollowupdate.ForeColor = Color.Black;
            lblStableActionPlan.ForeColor = Color.Black;
            lblStableFollowupdate.ForeColor = Color.Black;
            lblSchooledActionPlan.ForeColor = Color.Black;
            lblSchooledFollowupdate.ForeColor = Color.Black;
            #endregion Labels

            #region Textboxes
            txtActionPlanHealth.Clear();
            txtActionPlanSafety.Clear();
            txtActionPlanStable.Clear();
            txtActionPlanSchooled.Clear();
            txtSocialWorkerComment.Clear();
            #endregion Textboxes

            #region Dates
            dtHealth.Value = DateTime.Today;
            dtSafety.Value = DateTime.Today;
            dtStable.Value = DateTime.Today;
            dtSchooled.Value = DateTime.Today;
            dtTimeVisistDate.Value = DateTime.Today;
            dtHealth.Checked = false;
            dtSafety.Checked = false;
            dtStable.Checked = false;
            dtSchooled.Checked = false;
            dtTimeVisistDate.Checked = false;
            #endregion Dates

            #region Combos
            cboSocialWorker.SelectedValue = "-1";
            #endregion Combos

            #region Panels
            panelMain.Enabled = true;
            #endregion Panels

            hh_household_improvement_plan.hip_id_display = string.Empty;

        }

        private void Back()
        {
            hh_household_improvement_plan.hip_id_display = string.Empty;
            FormCalling.LoadDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
    }
}
