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
    public partial class frmYouthTracer : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmYouthTracerSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public frmYouthTracerSearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        public frmYouthTracer()
        {
            InitializeComponent();
        }

        private void frmYouthTracer_Load(object sender, EventArgs e)
        {
            Return_lookups();
            setDefaults();
            LoadDisplay(benYouthTracer.ytr_id);
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
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

            //cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion districts

            #region IP
            dt = silcCommunityTrainingRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboprt.DataSource = dt;
            cboprt.DisplayMember = "prt_name";
            cboprt.ValueMember = "prt_id";
            #endregion IP

            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion subcounty

            #region CSO
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboprt.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO

            #region Gender
            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow gender_emptyRow = dt.NewRow();
            gender_emptyRow["gnd_id"] = "-1";
            gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(gender_emptyRow, 0);

            cboSex.DataSource = dt;
            cboSex.DisplayMember = "gnd_name";
            cboSex.ValueMember = "gnd_id";
            #endregion Gender

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

        }

        private void cboprt_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboprt.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion LoadCSOs
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load SubCountys
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion Load SubCountys
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load Parishes
            dt = benYouthTrainingInventory.Return_lookups("parish", cboSubCounty.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";
            #endregion Load Parishes  
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboParish.SelectedValue.ToString());  //reused

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hh_code";
            cboHHCode.ValueMember = "hh_id";
            #endregion HH Codes
        }

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = benSchoolReadinessTool.ReturnHHMembers(cboHHCode.SelectedValue.ToString(), "hhm_all"); //reused

            DataRow hhmCode_emptyRow = dt.NewRow();
            hhmCode_emptyRow["hhm_id"] = "-1";
            hhmCode_emptyRow["hhm_name"] = "select member";
            dt.Rows.InsertAt(hhmCode_emptyRow, 0);

            cboHHMemberName.DataSource = dt;

            cboHHMemberName.DisplayMember = "hhm_name";
            cboHHMemberName.ValueMember = "hhm_id";
        }

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMDetails(cboHHMemberName.SelectedValue.ToString());
        }

        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = ben_youth_training_completion.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                string YOB = dtRow["hhm_year_of_birth"].ToString();
                txtMemberCode.Text = dtRow["hhm_code"].ToString();
                #region Age
                if (YOB != string.Empty)
                {
                    DateTime Year = DateTime.Now;
                    int yr = Year.Year;
                    txtAge.Text = (yr - Convert.ToInt32(YOB)).ToString();
                }
                else
                {
                    txtAge.Clear();
                }
                #endregion Age


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                save();
            }
            else
            {
                MessageBox.Show("Missing Required Fields!", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        protected void save()
        {
            #region set Variables
            benYouthTracer.prt_id = cboprt.SelectedValue.ToString();
            benYouthTracer.cso_id = cboCso.SelectedValue.ToString();
            benYouthTracer.wrd_id = cboParish.SelectedValue.ToString();
            benYouthTracer.date = dtDate.Value;
            benYouthTracer.hhm_id = cboHHMemberName.SelectedValue.ToString();
            benYouthTracer.fo_name = txtYFOName.Text;
            benYouthTracer.ttp_received = cboTrainingReceived.Text;
            benYouthTracer.ttp_other = txtTrainingOther.Text;
            benYouthTracer.employment_status = cboEmploymentstatus.Text;
            benYouthTracer.yn_using_acquired_skills = utilControls.RadioButtonGetSelection(rdn_using_acquired_skillsYes, rdn_using_acquired_skillsNo);
            benYouthTracer.yn_using_acquired_skills_no_reason = txt_rdn_using_acquired_skillsNoReason.Text;
            benYouthTracer.yn_market_available = cboMarketAvailable.Text != "select one"?cboMarketAvailable.Text:string.Empty;
            benYouthTracer.average_income = cboAverageIncome.Text != "select one" ? cboAverageIncome.Text : string.Empty;
            benYouthTracer.formal_bussiness_sector = txtEmployed_bussiness.Text;
            benYouthTracer.formal_employment_search_period = txtEmploymentSearchperiod.Text;
            benYouthTracer.formal_current_job_challenges = txtJobChallenges.Text;
            benYouthTracer.self_bussiness_sector = txtSelf_bussiness_sector.Text;
            benYouthTracer.self_source_of_startup_capital = Income_startup_source();
            benYouthTracer.sponsor_name = txt_sponsor_name.Text;
            benYouthTracer.startup_amt = txt_startup_amt.Value.ToString();
            benYouthTracer.bussiness_setup_help_source = cbo_bussiness_help_source.Text != "select one" ? cbo_bussiness_help_source.Text : string.Empty;
            benYouthTracer.bussiness_startup_duration = txt_business_setup_duration.Text;
            benYouthTracer.occupation_before_business_startup = cboOccupation.Text != "select one" ? cboOccupation.Text : string.Empty;
            benYouthTracer.bussiness_problems_faced = txt_bussiness_challenges.Text;
            benYouthTracer.unemployed_reason = cboUnemployReason.Text != "select one" ? cboUnemployReason.Text : string.Empty;
            benYouthTracer.unemployed_reason_other = txt_unemployReasonOther.Text;
            benYouthTracer.unemployment_action = txt_unEmployment_action.Text;
            benYouthTracer.yn_recommend_programme = utilControls.RadioButtonGetSelection(yn_recommend_programmeYes, yn_recommend_programmeNo);
            benYouthTracer.hhm_comments = txt_comments.Text;
            benYouthTracer.usr_id_create = SystemConstants.user_id;
            benYouthTracer.usr_id_update = SystemConstants.user_id;
            benYouthTracer.usr_date_create = DateTime.Now;
            benYouthTracer.usr_date_update = DateTime.Now;
            benYouthTracer.ofc_id = SystemConstants.ofc_id;
            benYouthTracer.district_id = SystemConstants.Return_office_district();
            #endregion

            #region save
            if (benYouthTracer.ytr_id == string.Empty)
            {
                benYouthTracer.ytr_id = Guid.NewGuid().ToString();
                benYouthTracer.save("insert");
                MessageBox.Show("saved!","SOCY MIS Message Centre",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                benYouthTracer.save("update");
                MessageBox.Show("saved!", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            #endregion
        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if (cboprt.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" ||
                cboParish.SelectedValue.ToString() == "-1" || dtDate.Checked == false || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMemberName.SelectedValue.ToString() == "-1" || txtYFOName.Text == string.Empty ||
                cboTrainingReceived.Text == "select one" || (cboTrainingReceived.Text == "Others (Specify)" && txtTrainingOther.Text == string.Empty) || cboEmploymentstatus.Text == "select one" || cboMarketAvailable.Text == "select one"
                || cboAverageIncome.Text == "select one" || ((cboEmploymentstatus.Text == "Employed (formal sector)" || cboEmploymentstatus.Text == "Employed (informal sector") && (txtEmployed_bussiness.Text == string.Empty || txtEmploymentSearchperiod.Text == string.Empty))
                || ((cboEmploymentstatus.Text == "Self-Employed") && (txtSelf_bussiness_sector.Text == string.Empty || (chkFamilySavings.Checked == false && chkGovernment.Checked == false && chkLoan.Checked == false && chkPersonalSavings.Checked == false && chkSponsor.Checked == false)
                || txt_startup_amt.Value == 0 || cbo_bussiness_help_source.Text == "select one" || txt_business_setup_duration.Text == string.Empty || cboOccupation.Text == "select one")) || cboEmploymentstatus.Text == "Unemployed (go to section III)"
                && (cboUnemployReason.Text == "select one" || (cboEmploymentstatus.Text == "other (Specify)" && txt_unemployReasonOther.Text == string.Empty) || (yn_recommend_programmeYes.Checked == false && yn_recommend_programmeNo.Checked == false) ||
                (cboEmploymentstatus.Text != "Unemployed (go to section III)" && (rdn_using_acquired_skillsYes.Checked == false && rdn_using_acquired_skillsNo.Checked == false))))
            {
                isValid = false;
            }
            else
                isValid = true;

            return isValid;
        }

        protected void EnableDisableContainers()
        {
            if (cboEmploymentstatus.Text == "Employed (formal sector)" || cboEmploymentstatus.Text == "Employed (informal sector)")
            {
                tlpDisplay03.Enabled = true;
                tlpDisplay04.Enabled = false;
                tlpDisplay05.Enabled = false;
            }
            else if (cboEmploymentstatus.Text == "Self-Employed")
            {
                tlpDisplay03.Enabled = false;
                tlpDisplay04.Enabled = true;
                tlpDisplay05.Enabled = false;
            }
            else if (cboEmploymentstatus.Text == "Unemployed (go to section III)")
            {
                tlpDisplay03.Enabled = false;
                tlpDisplay04.Enabled = false;
                tlpDisplay05.Enabled = true;
            }
            else
            {
                tlpDisplay03.Enabled = true;
                tlpDisplay04.Enabled = true;
                tlpDisplay05.Enabled = true;
            }
        }

        protected string Income_startup_source()
        {
            string income_source = string.Empty;
            string ArrItem = string.Empty;
            StringBuilder stringb = new StringBuilder();

            string[] ArrIncome_source = new string[5];
            if (chkLoan.Checked == true) { ArrIncome_source[0] = chkLoan.Text; } else { ArrIncome_source[0] = string.Empty; }
            if (chkFamilySavings.Checked == true) { ArrIncome_source[1] = chkFamilySavings.Text; } else { ArrIncome_source[1] = string.Empty; }
            if (chkGovernment.Checked == true) { ArrIncome_source[2] = chkGovernment.Text; } else { ArrIncome_source[2] = string.Empty; }
            if (chkPersonalSavings.Checked == true) { ArrIncome_source[3] = chkPersonalSavings.Text; } else { ArrIncome_source[3] = string.Empty; }
            if (chkSponsor.Checked == true) { ArrIncome_source[4] = chkSponsor.Text; } else { ArrIncome_source[4] = string.Empty; }

            for (int x = 0; x < ArrIncome_source.Length; x++)
            {
                ArrItem = ArrIncome_source[x];
                if (ArrItem != string.Empty)
                {
                    stringb.Append(ArrItem + ",");
                }
            }

            income_source = stringb.ToString();
            if (income_source != string.Empty) { income_source = income_source.Remove(income_source.Length - 1); }
            

            return income_source;

        }

        protected void setDefaults()
        {
            cboTrainingReceived.Text = "select one";
            cboEmploymentstatus.Text = "select one";
            cboMarketAvailable.Text = "select one";
            cboAverageIncome.Text = "select one";
            cbo_bussiness_help_source.Text = "select one";
            cboOccupation.Text = "select one";
            cboUnemployReason.Text = "select one";
        }

        private void cboEmploymentstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmploymentstatus.Text != "select one" )
            {
                EnableDisableContainers();
            }

            if (cboEmploymentstatus.Text != "Unemployed (go to section III)" && cboEmploymentstatus.Text != "select one")
            {
                lblUseAcquiredSkills.ForeColor = Color.Red;
            }
            else { lblUseAcquiredSkills.ForeColor = Color.Black; }
        }

        #region LoadDisplay
        protected void LoadDisplay(string ytr_id)
        {
            if (ytr_id != string.Empty)
            {
                dt = benYouthTracer.LoadDisplay("distinct", ytr_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    benYouthTracer.ytr_id = ytr_id;
                    cboprt.SelectedValue = dtRow["prt_id"].ToString();
                    cboCso.SelectedValue = dtRow["cso_id"].ToString();
                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboCso.SelectedValue = dtRow["cso_id"].ToString();
                    dtDate.Value = Convert.ToDateTime(dtRow["date"]);
                    dtDate.Checked = true;
                    cboHHCode.SelectedValue = dtRow["hh_id"].ToString();
                    cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                    txtYFOName.Text = dtRow["fo_name"].ToString();
                    cboTrainingReceived.Text = dtRow["ttp_received"].ToString();
                    txtTrainingOther.Text = dtRow["ttp_other"].ToString();
                    cboEmploymentstatus.Text = dtRow["employment_status"].ToString();
                    utilControls.RadioButtonSetSelection(rdn_using_acquired_skillsYes, rdn_using_acquired_skillsNo, dtRow["yn_using_acquired_skills"].ToString());
                    txt_rdn_using_acquired_skillsNoReason.Text = dtRow["yn_using_acquired_skills_no_reason"].ToString();
                    cboMarketAvailable.Text = dtRow["yn_market_available"].ToString();
                    cboAverageIncome.Text = dtRow["average_income"].ToString();
                    txtEmployed_bussiness.Text = dtRow["formal_bussiness_sector"].ToString();
                    txtEmploymentSearchperiod.Text = dtRow["formal_employment_search_period"].ToString();
                    txtJobChallenges.Text = dtRow["formal_current_job_challenges"].ToString();
                    txtSelf_bussiness_sector.Text = dtRow["self_bussiness_sector"].ToString();
                    set_startupCapital(dtRow["self_source_of_startup_capital"].ToString());
                    txt_sponsor_name.Text = dtRow["sponsor_name"].ToString();
                    txt_startup_amt.Value = Convert.ToInt32(dtRow["startup_amt"]);
                    cbo_bussiness_help_source.Text = dtRow["bussiness_setup_help_source"].ToString() != string.Empty ? dtRow["bussiness_setup_help_source"].ToString() : "select one";
                    txt_business_setup_duration.Text = dtRow["bussiness_startup_duration"].ToString();
                    cboOccupation.Text = dtRow["occupation_before_business_startup"].ToString() != string.Empty ? dtRow["occupation_before_business_startup"].ToString() : "select one";
                    txt_bussiness_challenges.Text = dtRow["bussiness_problems_faced"].ToString();
                    cboUnemployReason.Text = dtRow["unemployed_reason"].ToString() != string.Empty ? dtRow["unemployed_reason"].ToString() : "select one";
                    txt_unemployReasonOther.Text = dtRow["unemployed_reason_other"].ToString();
                    txt_unEmployment_action.Text = dtRow["unemployment_action"].ToString();
                    utilControls.RadioButtonSetSelection(yn_recommend_programmeYes, yn_recommend_programmeNo, dtRow["yn_recommend_programme"].ToString());
                    txt_comments.Text = dtRow["hhm_comments"].ToString();
                }
            }
        }

        protected void set_startupCapital(string startupList)
        {
            if (startupList.Contains("Loan")) { chkLoan.Checked = true; }
            if (startupList.Contains("Personal saving")) { chkPersonalSavings.Checked = true; }
            if (startupList.Contains("Family Savings")) { chkFamilySavings.Checked = true; }
            if (startupList.Contains("Government")) { chkGovernment.Checked = true; }
            if (startupList.Contains("Sponsor (NGO/project)")) { chkSponsor.Checked = true; }
        }

        protected void Clear()
        {
            benYouthTracer.ytr_id = string.Empty;
            cboprt.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            dtDate.Value = DateTime.Now;
            dtDate.Checked = false;
            cboHHCode.SelectedValue = "-1";
            cboHHMemberName.SelectedValue = "-1";
            txtYFOName.Clear();
            cboTrainingReceived.Text = "select one";
            txtTrainingOther.Clear();
            cboEmploymentstatus.Text = "select one";
            rdn_using_acquired_skillsYes.Checked = false;
            rdn_using_acquired_skillsNo.Checked = false;
            txt_rdn_using_acquired_skillsNoReason.Clear();
            cboMarketAvailable.Text = "select one";
            cboAverageIncome.Text = "select one";
            txtEmployed_bussiness.Clear();
            txtEmploymentSearchperiod.Clear();
            txtJobChallenges.Clear();
            txtSelf_bussiness_sector.Clear();
            chkFamilySavings.Checked = false;
            chkGovernment.Checked = false;
            chkLoan.Checked = false;
            chkPersonalSavings.Checked = false;
            chkSponsor.Checked = false;
            txt_sponsor_name.Clear();
            txt_startup_amt.Value = 0;
            cbo_bussiness_help_source.Text = "select one";
            txt_business_setup_duration.Clear();
            cboOccupation.Text = "select one";
            txt_bussiness_challenges.Clear();
            cboUnemployReason.Text = "select one";
            txt_unemployReasonOther.Clear();
            txt_unEmployment_action.Clear();
            yn_recommend_programmeYes.Checked = false;
            yn_recommend_programmeNo.Checked = false;
            txt_comments.Clear();
            cboHHMemberName.SelectedValue = "-1";
            txtAge.Clear();
            cboSex.SelectedValue = "-1";
            txtMemberCode.Clear();
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboTrainingReceived_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrainingReceived.Text == "Others (Specify)") { lblOtherTraining.ForeColor = Color.Red; txtTrainingOther.Enabled = true; }
            else { lblOtherTraining.ForeColor = Color.Black; txtTrainingOther.Enabled = false; }
        }

        private void rdn_using_acquired_skillsNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdn_using_acquired_skillsNo.Checked == true)
            {
                lblNotUseSkillReason.ForeColor = Color.Red;
                txt_rdn_using_acquired_skillsNoReason.Enabled = true;
            }
            else
            {
                lblNotUseSkillReason.ForeColor = Color.Black;
                txt_rdn_using_acquired_skillsNoReason.Enabled = false;
            }
        }

        private void rdn_using_acquired_skillsYes_CheckedChanged(object sender, EventArgs e)
        {
            rdn_using_acquired_skillsNo_CheckedChanged(rdn_using_acquired_skillsNo, null);
        }

        private void chkSponsor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSponsor.Checked == true) { lblSponsor.ForeColor = Color.Red; txt_sponsor_name.Enabled = true; }
            else { lblSponsor.ForeColor = Color.Black; txt_sponsor_name.Enabled = false; }
        }

        private void cboUnemployReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnemployReason.Text == "other (Specify)") { lblUnemployedOther.ForeColor = Color.Red;txt_unemployReasonOther.Enabled = true; }
            else { lblUnemployedOther.ForeColor = Color.Black; txt_sponsor_name.Enabled = false; }
        }

        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }
    }
}
