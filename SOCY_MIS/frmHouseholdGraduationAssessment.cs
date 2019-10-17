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
    public partial class frmHouseholdGraduationAssessment : UserControl
    {

        #region Variables
        DataTable dt = null;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        string str_id = string.Empty;
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
        public frmHouseholdGraduationAssessment()
        {
            InitializeComponent();
        }

        private void frmHouseholdGraduationAssessment_Load(object sender, EventArgs e)
        {
            Return_lookups();
            display_hh_details();
            Return_paraSocialWorkers();
            LoadHouseholdMembers();

            lblID.Text = ObjectId != string.Empty ? ObjectId : "lblID";
            str_id = ObjectId;
            hhgraduation_assessment.gat_id = ObjectId;

            lblgatfinal02.Text = hhgraduation_assessment.LoadGatFinalID(str_id) !=string.Empty? hhgraduation_assessment.LoadGatFinalID(str_id):"--";
            lblgatfinal03.Text = hhgraduation_assessment.LoadGatFinalID(str_id) != string.Empty ? hhgraduation_assessment.LoadGatFinalID(str_id) : "--";
            lblgatfinal04.Text = hhgraduation_assessment.LoadGatFinalID(str_id) != string.Empty ? hhgraduation_assessment.LoadGatFinalID(str_id) : "--";
            lblgatfinal08.Text = hhgraduation_assessment.LoadGatFinalID(str_id) != string.Empty ? hhgraduation_assessment.LoadGatFinalID(str_id) : "--";

            LoadMemberLists(str_id, "01", gdv01);
            LoadMemberLists(str_id, "02", gdv02);
            LoadMemberLists(str_id, "03", gdv03);
            LoadMemberLists(str_id, "04", gdv04);
            LoadMemberLists(str_id, "05", gdv05);
            LoadMemberLists(str_id, "06", gdv06);
            LoadMemberLists(str_id, "07", gdv07);
            LoadMemberLists(str_id, "08", gdv08);

            LoadHouseholdBenchMarks(str_id);//load benchamrks final 
            LoadGatDetails(str_id);

            ValidateBenchMarks();

            if (str_id != string.Empty)
            {
                CheckNumberPositiveInHousehold();
                CheckNumber10To17();
                CheckNumberUnder5Years();
                CheckNumberSchoolAge();

                LoadHouseholdMembersBenchMark01(str_id);
                LoadHouseholdMembersBenchMark02(str_id);
                LoadHouseholdMembersBenchMark03(str_id);
                LoadHouseholdMembersBenchMark04(str_id);
                LoadHouseholdMembersBenchMark05(str_id);
                LoadHouseholdMembersBenchMark06(str_id);
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

        protected void LoadHouseholdBenchMarks(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdBenchMarks(gat_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                utilControls.RadioButtonSetSelection(rbtn_BenchMark01Yes, rbtn_BenchMark01No, dtRow["yn_met_benchmark01"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark02Yes, rbtn_BenchMark02No, rbtn_BenchMark02NA, dtRow["yn_met_benchmark02"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark03Yes, rbtn_BenchMark03No, rbtn_BenchMark03NA, dtRow["yn_met_benchmark03"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark04Yes, rbtn_BenchMark04No, rbtn_BenchMark04NA, dtRow["yn_met_benchmark04"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark05Yes, rbtn_BenchMark05No, dtRow["yn_met_benchmark05"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark06Yes, rbtn_BenchMark06No, dtRow["yn_met_benchmark06"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark07Yes, rbtn_BenchMark07No, dtRow["yn_met_benchmark07"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_BenchMark08Yes, rbtn_BenchMark08No, rbtn_BenchMark08NA, dtRow["yn_met_benchmark08"].ToString());

                //#region disbable save buttons for NA benchmarks
                //if (rbtn_BenchMark02NA.Checked)
                //{
                //    btnSaveBenchMark02.Enabled = false;
                //}
                //else
                //{
                //    btnSaveBenchMark02.Enabled = true;
                //}

                //if (rbtn_BenchMark03NA.Checked)
                //{
                //    btnSaveBenchMark03.Enabled = false;
                //}
                //else
                //{
                //    btnSaveBenchMark03.Enabled = true;
                //}

                //if (rbtn_BenchMark04NA.Checked)
                //{
                //    btnSaveBenchMark04.Enabled = false;
                //}
                //else
                //{
                //    btnSaveBenchMark04.Enabled = true;
                //}

                //if (rbtn_BenchMark08NA.Checked)
                //{
                //    btnSaveBenchMark08.Enabled = false;
                //}
                //else
                //{
                //    btnSaveBenchMark08.Enabled = true;
                //}
                //#endregion

                LoadRecordDetails(hhgraduation_assessment.LoadBenchMark7ID(gat_id), "07");
                LoadRecordDetails(hhgraduation_assessment.LoadBenchMark8ID(gat_id), "08");
                LoadRecordDetails(hhgraduation_assessment.LoadBenchMark5ID(gat_id), "05");
            }
        }

        protected void LoadGatDetails(string gat_id)
        {
            dt = hhgraduation_assessment.LoadGATDetails(gat_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                dtGatDate.Value = Convert.ToDateTime(dtRow["gat_date"]);
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
                cboCaregiver.SelectedValue = dtRow["hhm_head_id"].ToString();
            }
        }

        protected void LoadMemberLists(string gat_id, string benchMark, DataGridView gdvname)
        {
            switch (benchMark)
            {
                case "01":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["known_hiv_status"].HeaderText = "Known HIV Status";
                    break;
                case "02":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["suppressing"].HeaderText = "Beneficiary Virally Suppressing?";
                    gdvname.Columns["Adhere"].HeaderText = "Beneficiary Taking ART Pills as prescribed?";
                    gdvname.Columns["Appointment"].HeaderText = "Beneficiary regularly attending ART Appointments ?";
                    break;
                case "03":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["yn_risk"].HeaderText = "Adolescent Identified atleast two HIV Risks?";
                    gdvname.Columns["yn_prev"].HeaderText = "Adolescent Identified atleast one HIV Prevention strategy?";
                    break;
                case "04":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["yn_muac"].HeaderText = "Is the child’s MUAC more than 12.5 cm?";
                    gdvname.Columns["yn_edema"].HeaderText = "Is the child free of any signs of bipedal edema?";
                    break;
                case "05":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["yn_pay_fees"].HeaderText = "Able to pay fees?";
                    gdvname.Columns["yn_pay_fees_no_pepfar_grant"].HeaderText = "Able to pay fees without PEPFAR Grant?";
                    gdvname.Columns["yn_pay_fees_no_sell_asset"].HeaderText = "Able to pay fees without sell of productive Asset?";
                    gdvname.Columns["yn_pay_medical_costs"].HeaderText = "Able to pay medical costs?";
                    gdvname.Columns["yn_pay_medical_costs_no_pepfar_grant"].HeaderText = "Able to pay medical costs without PEPFAR Grant?";
                    gdvname.Columns["yn_pay_medical_costs_no_sell_asset"].HeaderText = "Able to pay medical costs without sell of productive Asset?";
                    break;
                case "06":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["hhm_name"].HeaderText = "Beneficiary Name";
                    gdvname.Columns["yn_kicked"].HeaderText = "Have you been punched, kicked, or beaten?";
                    gdvname.Columns["yn_child_kicked"].HeaderText = "Are you aware of any child in your household being punched, kicked, or beaten by an adult?";
                    gdvname.Columns["yn_child_violence"].HeaderText = "Have you or any children in your household experienced any other type of violence or abuse?";
                    break;
                case "07":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["yn_stable_caregiver"].HeaderText = "Under the care of a stable adult caregiver?";
                    break;
                case "08":
                    dt = hhgraduation_assessment.LoadMemberLists(gat_id, benchMark);
                    gdvname.DataSource = dt;

                    gdvname.Columns["gat_b_id"].Visible = false;
                    gdvname.Columns["gat_id"].Visible = false;

                    gdvname.Columns["yn_children_enrolled_in_school"].HeaderText = "All children enrolled in school?";
                    gdvname.Columns["yn_atte_school_regualarly"].HeaderText = "All children attending school regularly?";
                    gdvname.Columns["yn_progress_next_level"].HeaderText = "All children progressed to next level in school year?";
                    break;

            }

            #region Gridview styling
            gdvname.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvname.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvname.RowsDefaultCellStyle.BackColor = Color.LightGray;
            gdvname.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // Set the row and column header styles.
            gdvname.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdvname.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gdvname.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            gdvname.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvname.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvname.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
            gdvname.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn c in gdvname.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
            #endregion
        }


        protected void LoadRecordDetails(string gat_b_id, string benchMark)
        {
            DataRow dtRow;
            switch (benchMark)
            {
                case "01":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_01.Text = dtRow["hhm_name"].ToString();
                        utilControls.RadioButtonSetSelection(rbtn_yn_hiv_statusYes, rbtn_yn_hiv_statusNo, dtRow["yn_hiv_status"].ToString());
                        lblID01.Text = gat_b_id;
                    }
                    break;
                case "02":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_02.Text = dtRow["hhm_name"].ToString();
                        utilControls.RadioButtonSetSelection(yn_supressYes, yn_supressNo, dtRow["yn_supressed"].ToString());
                        utilControls.RadioButtonSetSelection(yn_prescribedYes, yn_prescribedNo, dtRow["yn_adhering"].ToString());
                        utilControls.RadioButtonSetSelection(yn_appointmentYes, yn_appointmentNo, dtRow["yn_attend_art_appointment"].ToString());
                        lblID02.Text = gat_b_id;
                    }
                    break;
                case "03":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_03.Text = dtRow["hhm_name"].ToString();
                        utilControls.RadioButtonSetSelection(yn_risks_identifiedYes, yn_risks_identifiedNo, dtRow["yn_hiv_risk_knowledge"].ToString());
                        utilControls.RadioButtonSetSelection(yn_hiv_preventionYes, yn_hiv_preventionNo, dtRow["yn_hiv_prevention"].ToString());
                        lblID03.Text = gat_b_id;
                    }
                    break;
                case "04":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_04.Text = dtRow["hhm_name"].ToString();
                        utilControls.RadioButtonSetSelection(yn_muac_normalYes, yn_muac_normalNo, dtRow["yn_muac_normal"].ToString());
                        utilControls.RadioButtonSetSelection(yn_edema_freeYes, yn_edema_freeNo, dtRow["yn_edema_free"].ToString());
                        lblID04.Text = gat_b_id;
                    }
                    break;
                case "05":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_05.Text = dtRow["hhm_name"].ToString();
                        cbo_hhm_05.SelectedValue = dtRow["hhm_id"].ToString();
                        cbo_hhm_05.Enabled = false;
                        utilControls.RadioButtonSetSelection(yn_pay_feesYes, yn_pay_feesNo, dtRow["yn_pay_fees"].ToString());
                        utilControls.RadioButtonSetSelection(yn_pay_fees_no_grantYes, yn_pay_fees_no_grantNo, dtRow["yn_pay_fees_no_pepfar_grant"].ToString());
                        utilControls.RadioButtonSetSelection(yn_pay_fees_no_sell_assetYes, yn_pay_fees_no_sell_assetNo, dtRow["yn_pay_fees_no_sell_asset"].ToString());
                        utilControls.RadioButtonSetSelection(yn_pay_medical_feesYes, yn_pay_medical_feesNo, dtRow["yn_pay_medical_costs"].ToString());
                        utilControls.RadioButtonSetSelection(yn_pay_medical_fees_no_grantYes, yn_pay_medical_fees_no_grantNo, dtRow["yn_pay_medical_costs_no_pepfar_grant"].ToString());
                        utilControls.RadioButtonSetSelection(yn_pay_medical_fees_no_sell_assetYes, yn_pay_medical_fees_no_sell_assetNo, dtRow["yn_pay_medical_costs_no_sell_asset"].ToString());
                        lblID05.Text = gat_b_id;
                    }
                    break;
                case "06":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        cbo_hhm_06.Text = dtRow["hhm_name"].ToString();
                        utilControls.RadioButtonSetSelection(yn_adult_kickedYes, yn_adult_kickedNo, dtRow["yn_kicked"].ToString());
                        utilControls.RadioButtonSetSelection(yn_child_abuse_awareYes, yn_child_abuse_awareNo, dtRow["yn_child_kicked"].ToString());
                        utilControls.RadioButtonSetSelection(yn_child_violenceYes, yn_child_violenceNo, dtRow["yn_child_violence"].ToString());
                        lblID06.Text = gat_b_id;
                    }
                    break;
                case "07":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        utilControls.RadioButtonSetSelection(yn_stableCaregiverYes, yn_stableCaregiverNo, dtRow["yn_stable_caregiver"].ToString());
                        lblID07.Text = gat_b_id;
                    }
                    break;
                case "08":
                    dt = hhgraduation_assessment.LoadRecordDetails(gat_b_id, benchMark);
                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        utilControls.RadioButtonSetSelection(yn_edu_enrolledYes, yn_edu_enrolledNo, dtRow["yn_children_enrolled_in_school"].ToString());
                        utilControls.RadioButtonSetSelection(yn_edu_attend_tegularlayYes, yn_edu_attend_tegularlayNo, dtRow["yn_atte_school_regualarly"].ToString());
                        utilControls.RadioButtonSetSelection(yn_edu_progressYes, yn_edu_progressNo, dtRow["yn_progress_next_level"].ToString());
                        lblID07.Text = gat_b_id;
                    }
                    break;
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

        protected void LoadHouseholdMembers()
        {
            dt = hhgraduation_assessment.LoadHouseholdMembers(HouseholdId);
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["hhm_id"] = "-1";
                emptyRow["hhm_name"] = "Select One";
                dt.Rows.InsertAt(emptyRow, 0);

                cboCaregiver.DataSource = dt;
                cboCaregiver.ValueMember = "hhm_id";
                cboCaregiver.DisplayMember = "hhm_name";
            }
        }


        protected void LoadHouseholdMembersBenchMark01(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark01(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_01.DataSource = dt;
            cbo_hhm_01.ValueMember = "hhm_id";
            cbo_hhm_01.DisplayMember = "hhm_name";
        }


        protected void LoadHouseholdMembersBenchMark02(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark02(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_02.DataSource = dt;
            cbo_hhm_02.ValueMember = "hhm_id";
            cbo_hhm_02.DisplayMember = "hhm_name";
        }


        protected void CheckNumberPositiveInHousehold()
        {
            int count = hhgraduation_assessment.CheckNumberPositiveInHousehold(HouseholdId);
            if (count == 0)
            {
                rbtn_BenchMark02NA.Checked = true;
                cbo_hhm_02.Enabled = false;
                lblMessage02.Visible = true;
            }
            else
            {
                rbtn_BenchMark02NA.Checked = false;
                cbo_hhm_02.Enabled = true;
                lblMessage02.Visible = false;
            }
        }

        protected void CheckNumber10To17()
        {
            int count = hhgraduation_assessment.CheckNumber10To17(HouseholdId);
            if (count == 0)
            {
                rbtn_BenchMark03NA.Checked = true;
                lblMessage03.Visible = true;
                cbo_hhm_03.Enabled = false;
            }
            else
            {
                rbtn_BenchMark03NA.Checked = false;
                cbo_hhm_03.Enabled = true;
                lblMessage02.Visible = false;
            }
        }

        protected void CheckNumberUnder5Years()
        {
            int count = hhgraduation_assessment.CheckNumberUnder5Years(HouseholdId);
            if (count == 0)
            {
                rbtn_BenchMark04NA.Checked = true;
                cbo_hhm_04.Enabled = false;
            }
            else
            {
                rbtn_BenchMark04NA.Checked = false;
                cbo_hhm_04.Enabled = true;
            }
        }

        protected void CheckNumberSchoolAge()
        {
            int count = hhgraduation_assessment.CheckNumberSchoolAge(HouseholdId);
            if (count == 0)
            {
                rbtn_BenchMark08NA.Checked = true;
                lblMessage08.Visible = true;
            }
            else
            {
                rbtn_BenchMark08NA.Checked = false;
                lblMessage08.Visible = false;
            }
        }

        private void Back()
        {
            hhgraduation_assessment.gat_id = string.Empty;
            FormCalling.LoadDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }


        protected void LoadHouseholdMembersBenchMark03(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark03(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_03.DataSource = dt;
            cbo_hhm_03.ValueMember = "hhm_id";
            cbo_hhm_03.DisplayMember = "hhm_name";
        }

        protected void LoadHouseholdMembersBenchMark04(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark04(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_04.DataSource = dt;
            cbo_hhm_04.ValueMember = "hhm_id";
            cbo_hhm_04.DisplayMember = "hhm_name";
        }


        protected void LoadHouseholdMembersBenchMark05(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark05(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_05.DataSource = dt;
            cbo_hhm_05.ValueMember = "hhm_id";
            cbo_hhm_05.DisplayMember = "hhm_name";
        }

        protected void LoadHouseholdMembersBenchMark06(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark06(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select One";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_06.DataSource = dt;
            cbo_hhm_06.ValueMember = "hhm_id";
            cbo_hhm_06.DisplayMember = "hhm_name";
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
                cboIP.Text = dtRow["prt_name"].ToString();
                txtVilage.Text = dtRow["hh_village"].ToString();
                txtHHCode.Text = dtRow["hh_code"].ToString();
            }
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboSocialWorker_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSocialWorkerPhone.Text = hhgraduation_assessment.ReturnSocialWorkerPhone(cboSocialWorker.SelectedValue.ToString());
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }

        #region save

        #region Basic
        protected void save()
        {
            if (ValidateInput())
            {
                if (lblID.Text == "lblID")
                {
                    hhgraduation_assessment.gat_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hh_id = HouseholdId;
                    hhgraduation_assessment.swk_id = cboSocialWorker.SelectedValue.ToString();
                    hhgraduation_assessment.hhm_head_id = cboCaregiver.SelectedValue.ToString();
                    hhgraduation_assessment.gat_date = dtGatDate.Value;
                    hhgraduation_assessment.usr_id_create = SystemConstants.user_id;
                    hhgraduation_assessment.usr_id_update = SystemConstants.user_id;
                    hhgraduation_assessment.usr_date_create = DateTime.Today;
                    hhgraduation_assessment.usr_date_update = DateTime.Today;
                    hhgraduation_assessment.ofc_id = SystemConstants.ofc_id;
                    hhgraduation_assessment.district_id = SystemConstants.Return_office_district();

                    hhgraduation_assessment.save_hh_graduation_assessment(string.Empty);
                    lblID.Text = hhgraduation_assessment.gat_id;
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark05(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark06(hhgraduation_assessment.gat_id);
                    CheckNumberPositiveInHousehold();
                    CheckNumber10To17();
                    CheckNumberUnder5Years();
                    CheckNumberSchoolAge();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_id = lblID.Text;
                    hhgraduation_assessment.hh_id = HouseholdId;
                    hhgraduation_assessment.swk_id = cboSocialWorker.SelectedValue.ToString();
                    hhgraduation_assessment.hhm_head_id = cboCaregiver.SelectedValue.ToString();
                    hhgraduation_assessment.gat_date = dtGatDate.Value.Date;
                    hhgraduation_assessment.usr_id_create = SystemConstants.user_id;
                    hhgraduation_assessment.usr_id_update = SystemConstants.user_id;
                    hhgraduation_assessment.usr_date_create = DateTime.Today;
                    hhgraduation_assessment.usr_date_update = DateTime.Today;
                    hhgraduation_assessment.ofc_id = SystemConstants.ofc_id;
                    hhgraduation_assessment.district_id = SystemConstants.Return_office_district();

                    hhgraduation_assessment.save_hh_graduation_assessment(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark05(hhgraduation_assessment.gat_id);
                    LoadHouseholdMembersBenchMark06(hhgraduation_assessment.gat_id);
                    CheckNumberPositiveInHousehold();
                    CheckNumber10To17();
                    CheckNumberUnder5Years();
                    CheckNumberSchoolAge();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Fill in all required values,save failed!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion

        #region BenchMark01
        protected void saveBenchMark01()
        {
            if (ValidateInputBenchMark01())
            {
                if (lblID01.Text == "lblID01")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_01.SelectedValue.ToString();
                    hhgraduation_assessment.yn_hiv_status = utilControls.RadioButtonGetSelection(rbtn_yn_hiv_statusYes, rbtn_yn_hiv_statusNo);

                    hhgraduation_assessment.saveBenchMark01(string.Empty);

                    #region BenchMarkMet
                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "01");
                    if (count == 0)
                    {
                        rbtn_BenchMark01Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark01No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark01 = utilControls.RadioButtonGetSelection(rbtn_BenchMark01Yes, rbtn_BenchMark01No);
                    if(hhgraduation_assessment.CheckNumberPositiveInHousehold(HouseholdId) == 0)
                    {
                        hhgraduation_assessment.yn_met_benchmark02 = "2"; //not applicable
                    }

                    if (hhgraduation_assessment.CheckNumber10To17(HouseholdId) == 0)
                    {
                        hhgraduation_assessment.yn_met_benchmark03 = "2";
                    }

                    if (hhgraduation_assessment.CheckNumberUnder5Years(HouseholdId) == 0)
                    {
                        hhgraduation_assessment.yn_met_benchmark04 = "2";
                    }

                    if (hhgraduation_assessment.CheckNumberSchoolAge(HouseholdId) == 0)
                    {
                        hhgraduation_assessment.yn_met_benchmark08 = "2";
                    }

                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "01");
                    #endregion SaveFinalBenchMarkPassFail

                    //lblID01.Text = hhgraduation_assessment.gat_b_id;
                    
                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID01.Text;
                    hhgraduation_assessment.yn_hiv_status = utilControls.RadioButtonGetSelection(rbtn_yn_hiv_statusYes, rbtn_yn_hiv_statusNo);

                    hhgraduation_assessment.saveBenchMark01(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet
                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "01");
                    if (count == 0)
                    {
                        rbtn_BenchMark01Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark01No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark01 = utilControls.RadioButtonGetSelection(rbtn_BenchMark01Yes, rbtn_BenchMark01No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "01");
                    #endregion SaveFinalBenchMarkPassFail

                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion BenchMark01


        #region BenchMark02
        protected void saveBenchMark02()
        {
            if (ValidateInputBenchMark02())
            {
                if (lblID02.Text == "lblID02")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_02.SelectedValue.ToString();
                    hhgraduation_assessment.yn_supressed = utilControls.RadioButtonGetSelection(yn_supressYes, yn_supressNo);
                    hhgraduation_assessment.yn_adhering = utilControls.RadioButtonGetSelection(yn_prescribedYes, yn_prescribedNo);
                    hhgraduation_assessment.yn_attend_art_appointment = utilControls.RadioButtonGetSelection(yn_appointmentYes, yn_appointmentNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberPositiveInHousehold(HouseholdId) == 0)
                    {
                        rbtn_BenchMark02NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark02 = utilControls.RadioButtonGetSelection(rbtn_BenchMark02Yes, rbtn_BenchMark02No, rbtn_BenchMark02NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "02");
                        lblgatfinal02.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark02(string.Empty);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "02");
                        if (count == 0)
                        {
                            rbtn_BenchMark02Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark02No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark02 = utilControls.RadioButtonGetSelection(rbtn_BenchMark02Yes, rbtn_BenchMark02No, rbtn_BenchMark02NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "02");
                        lblgatfinal02.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID02.Text;
                    //hhgraduation_assessment.hhm_id = cbo_hhm_02.SelectedValue.ToString();
                    hhgraduation_assessment.yn_supressed = utilControls.RadioButtonGetSelection(yn_supressYes, yn_supressNo);
                    hhgraduation_assessment.yn_adhering = utilControls.RadioButtonGetSelection(yn_prescribedYes, yn_prescribedNo);
                    hhgraduation_assessment.yn_attend_art_appointment = utilControls.RadioButtonGetSelection(yn_appointmentYes, yn_appointmentNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberPositiveInHousehold(HouseholdId) == 0)
                    {
                        rbtn_BenchMark02NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark02 = utilControls.RadioButtonGetSelection(rbtn_BenchMark02Yes, rbtn_BenchMark02No, rbtn_BenchMark02NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "02");
                        lblgatfinal02.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark02(hhgraduation_assessment.gat_b_id);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "02");
                        if (count == 0)
                        {
                            rbtn_BenchMark02Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark02No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark02 = utilControls.RadioButtonGetSelection(rbtn_BenchMark02Yes, rbtn_BenchMark02No, rbtn_BenchMark02NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "02");
                        lblgatfinal02.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        protected void saveBenchMark03()
        {
            if (ValidateInputBenchMark03())
            {
                if (lblID03.Text == "lblID03")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_03.SelectedValue.ToString();
                    hhgraduation_assessment.yn_hiv_risk_knowledge = utilControls.RadioButtonGetSelection(yn_risks_identifiedYes, yn_risks_identifiedNo);
                    hhgraduation_assessment.yn_hiv_prevention = utilControls.RadioButtonGetSelection(yn_hiv_preventionYes, yn_hiv_preventionNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumber10To17(HouseholdId) == 0)
                    {
                        rbtn_BenchMark02NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark03 = utilControls.RadioButtonGetSelection(rbtn_BenchMark03Yes, rbtn_BenchMark03No, rbtn_BenchMark03NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "03");
                        lblgatfinal03.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark03(string.Empty);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "03");
                        if (count == 0)
                        {
                            rbtn_BenchMark03Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark03No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark03 = utilControls.RadioButtonGetSelection(rbtn_BenchMark03Yes, rbtn_BenchMark03No, rbtn_BenchMark03NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "03");
                        lblgatfinal03.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID03.Text;
                    //hhgraduation_assessment.hhm_id = cbo_hhm_03.SelectedValue.ToString();
                    hhgraduation_assessment.yn_hiv_risk_knowledge = utilControls.RadioButtonGetSelection(yn_risks_identifiedYes, yn_risks_identifiedNo);
                    hhgraduation_assessment.yn_hiv_prevention = utilControls.RadioButtonGetSelection(yn_hiv_preventionYes, yn_hiv_preventionNo);
                    hhgraduation_assessment.saveBenchMark03(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumber10To17(HouseholdId) == 0)
                    {
                        rbtn_BenchMark02NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark03 = utilControls.RadioButtonGetSelection(rbtn_BenchMark03Yes, rbtn_BenchMark03No, rbtn_BenchMark03NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "03");
                        lblgatfinal03.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "03");
                        if (count == 0)
                        {
                            rbtn_BenchMark03Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark03No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark03 = utilControls.RadioButtonGetSelection(rbtn_BenchMark03Yes, rbtn_BenchMark03No, rbtn_BenchMark03NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "03");
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        protected void saveBenchMark04()
        {
            if (ValidateInputBenchMark04())
            {
                if (lblID04.Text == "lblID04" )
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_04.SelectedValue.ToString();

                    hhgraduation_assessment.yn_muac_normal = utilControls.RadioButtonGetSelection(yn_muac_normalYes, yn_muac_normalNo);
                    hhgraduation_assessment.yn_edema_free = utilControls.RadioButtonGetSelection(yn_edema_freeYes, yn_edema_freeNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberUnder5Years(HouseholdId) == 0)
                    {
                        rbtn_BenchMark04NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark04 = utilControls.RadioButtonGetSelection(rbtn_BenchMark04Yes, rbtn_BenchMark04No, rbtn_BenchMark04NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "04");
                        lblgatfinal04.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark04(string.Empty);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "04");
                        if (count == 0)
                        {
                            rbtn_BenchMark04Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark04No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark04 = utilControls.RadioButtonGetSelection(rbtn_BenchMark04Yes, rbtn_BenchMark04No, rbtn_BenchMark04NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "04");
                        lblgatfinal04.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID04.Text;
                    //hhgraduation_assessment.hhm_id = cbo_hhm_04.SelectedValue.ToString();

                    hhgraduation_assessment.yn_muac_normal = utilControls.RadioButtonGetSelection(yn_muac_normalYes, yn_muac_normalNo);
                    hhgraduation_assessment.yn_edema_free = utilControls.RadioButtonGetSelection(yn_edema_freeYes, yn_edema_freeNo);
                    hhgraduation_assessment.saveBenchMark04(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberUnder5Years(HouseholdId) == 0)
                    {
                        rbtn_BenchMark04NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark04 = utilControls.RadioButtonGetSelection(rbtn_BenchMark04Yes, rbtn_BenchMark04No, rbtn_BenchMark04NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "04");
                        lblgatfinal04.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "04");
                        if (count == 0)
                        {
                            rbtn_BenchMark04Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark04No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark04 = utilControls.RadioButtonGetSelection(rbtn_BenchMark04Yes, rbtn_BenchMark04No, rbtn_BenchMark04NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "04");
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        protected void saveBenchMark05()
        {
            if (ValidateInputBenchMark05())
            {
                if (lblID05.Text == "lblID05")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_05.SelectedValue.ToString();

                    hhgraduation_assessment.yn_pay_fees = utilControls.RadioButtonGetSelection(yn_pay_feesYes, yn_pay_feesNo, yn_pay_feesNA);
                    hhgraduation_assessment.yn_pay_fees_no_pepfar_grant = utilControls.RadioButtonGetSelection(yn_pay_fees_no_grantYes, yn_pay_fees_no_grantNo);
                    hhgraduation_assessment.yn_pay_fees_no_sell_asset = utilControls.RadioButtonGetSelection(yn_pay_fees_no_sell_assetYes, yn_pay_fees_no_sell_assetNo);
                    hhgraduation_assessment.yn_pay_medical_costs = utilControls.RadioButtonGetSelection(yn_pay_medical_feesYes, yn_pay_medical_feesNo, yn_pay_medical_feesNA);
                    hhgraduation_assessment.yn_pay_medical_costs_no_pepfar_grant = utilControls.RadioButtonGetSelection(yn_pay_medical_fees_no_grantYes, yn_pay_medical_fees_no_grantNo);
                    hhgraduation_assessment.yn_pay_medical_costs_no_sell_asset = utilControls.RadioButtonGetSelection(yn_pay_medical_fees_no_sell_assetYes, yn_pay_medical_fees_no_sell_assetNo);

                    hhgraduation_assessment.saveBenchMark05(string.Empty);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "05");
                    if (count == 0)
                    {
                        rbtn_BenchMark05Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark05No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark05 = utilControls.RadioButtonGetSelection(rbtn_BenchMark05Yes, rbtn_BenchMark05No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "05");
                    #endregion SaveFinalBenchMarkPassFail


                    lblID05.Text = hhgraduation_assessment.gat_b_id;
                   
                    LoadHouseholdMembersBenchMark05(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID05.Text;
                    // hhgraduation_assessment.hhm_id = cbo_hhm_05.SelectedValue.ToString();

                    hhgraduation_assessment.yn_pay_fees = utilControls.RadioButtonGetSelection(yn_pay_feesYes, yn_pay_feesNo, yn_pay_feesNA);
                    hhgraduation_assessment.yn_pay_fees_no_pepfar_grant = utilControls.RadioButtonGetSelection(yn_pay_fees_no_grantYes, yn_pay_fees_no_grantNo);
                    hhgraduation_assessment.yn_pay_fees_no_sell_asset = utilControls.RadioButtonGetSelection(yn_pay_fees_no_sell_assetYes, yn_pay_fees_no_sell_assetNo);
                    hhgraduation_assessment.yn_pay_medical_costs = utilControls.RadioButtonGetSelection(yn_pay_medical_feesYes, yn_pay_medical_feesNo, yn_pay_medical_feesNA);
                    hhgraduation_assessment.yn_pay_medical_costs_no_pepfar_grant = utilControls.RadioButtonGetSelection(yn_pay_medical_fees_no_grantYes, yn_pay_medical_fees_no_grantNo);
                    hhgraduation_assessment.yn_pay_medical_costs_no_sell_asset = utilControls.RadioButtonGetSelection(yn_pay_medical_fees_no_sell_assetYes, yn_pay_medical_fees_no_sell_assetNo);

                    hhgraduation_assessment.saveBenchMark05(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "05");
                    if (count == 0)
                    {
                        rbtn_BenchMark05Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark05No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark05 = utilControls.RadioButtonGetSelection(rbtn_BenchMark05Yes, rbtn_BenchMark05No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "05");
                    #endregion SaveFinalBenchMarkPassFail

                    
                    LoadHouseholdMembersBenchMark05(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        protected void saveBenchMark06()
        {
            if (ValidateInputBenchMark06())
            {
                if (lblID06.Text == "lblID06")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                    hhgraduation_assessment.hhm_id = cbo_hhm_06.SelectedValue.ToString();

                    hhgraduation_assessment.yn_kicked = utilControls.RadioButtonGetSelection(yn_adult_kickedYes, yn_adult_kickedNo);
                    hhgraduation_assessment.yn_child_kicked = utilControls.RadioButtonGetSelection(yn_child_abuse_awareYes, yn_child_abuse_awareNo);
                    hhgraduation_assessment.yn_child_violence = utilControls.RadioButtonGetSelection(yn_child_violenceYes, yn_child_violenceNo);

                    hhgraduation_assessment.saveBenchMark06(string.Empty);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "06");
                    if (count == 0)
                    {
                        rbtn_BenchMark06Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark06No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark06 = utilControls.RadioButtonGetSelection(rbtn_BenchMark06Yes, rbtn_BenchMark06No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "06");
                    #endregion SaveFinalBenchMarkPassFail

                   
                    LoadHouseholdMembersBenchMark06(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID06.Text;
                    //hhgraduation_assessment.hhm_id = cbo_hhm_06.SelectedValue.ToString();

                    hhgraduation_assessment.yn_kicked = utilControls.RadioButtonGetSelection(yn_adult_kickedYes, yn_adult_kickedNo);
                    hhgraduation_assessment.yn_child_kicked = utilControls.RadioButtonGetSelection(yn_child_abuse_awareYes, yn_child_abuse_awareNo);
                    hhgraduation_assessment.yn_child_violence = utilControls.RadioButtonGetSelection(yn_child_violenceYes, yn_child_violenceNo);

                    hhgraduation_assessment.saveBenchMark06(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "06");
                    if (count == 0)
                    {
                        rbtn_BenchMark06Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark06No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark06 = utilControls.RadioButtonGetSelection(rbtn_BenchMark06Yes, rbtn_BenchMark06No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "06");
                    #endregion SaveFinalBenchMarkPassFail

                    LoadHouseholdMembersBenchMark06(hhgraduation_assessment.gat_id);
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        protected void saveBenchMark07()
        {
            if (ValidateInputBenchMark07())
            {
                if (lblID07.Text == "lblID07")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();

                    hhgraduation_assessment.yn_stable_caregiver = utilControls.RadioButtonGetSelection(yn_stableCaregiverYes, yn_stableCaregiverNo);

                    hhgraduation_assessment.saveBenchMark07(string.Empty);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "07");
                    if (count == 0)
                    {
                        rbtn_BenchMark07Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark07No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark07 = utilControls.RadioButtonGetSelection(rbtn_BenchMark07Yes, rbtn_BenchMark07No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "07");
                    #endregion SaveFinalBenchMarkPassFail

                    lblID07.Text = hhgraduation_assessment.gat_b_id;
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID07.Text;
                    hhgraduation_assessment.yn_stable_caregiver = utilControls.RadioButtonGetSelection(yn_stableCaregiverYes, yn_stableCaregiverNo);

                    hhgraduation_assessment.saveBenchMark07(hhgraduation_assessment.gat_b_id);

                    #region BenchMarkMet

                    int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "07");
                    if (count == 0)
                    {
                        rbtn_BenchMark07Yes.Checked = true;
                    }
                    else
                    {
                        rbtn_BenchMark07No.Checked = true;
                    }
                    #endregion

                    #region SaveFinalBenchMarkPassFail
                    hhgraduation_assessment.yn_met_benchmark07 = utilControls.RadioButtonGetSelection(rbtn_BenchMark07Yes, rbtn_BenchMark07No);
                    hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "07");
                    #endregion SaveFinalBenchMarkPassFail


                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        protected void saveBenchMark08()
        {
            if (ValidateInputBenchMark08())
            {
                if (lblID08.Text == "lblID08")
                {
                    hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();

                    hhgraduation_assessment.yn_children_enrolled_in_school = utilControls.RadioButtonGetSelection(yn_edu_enrolledYes, yn_edu_enrolledNo);
                    hhgraduation_assessment.yn_atte_school_regualarly = utilControls.RadioButtonGetSelection(yn_edu_attend_tegularlayYes, yn_edu_attend_tegularlayNo);
                    hhgraduation_assessment.yn_progress_next_level = utilControls.RadioButtonGetSelection(yn_edu_progressYes, yn_edu_progressNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberSchoolAge(HouseholdId) == 0)
                    {
                        rbtn_BenchMark08NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark08 = utilControls.RadioButtonGetSelection(rbtn_BenchMark08Yes, rbtn_BenchMark08No, rbtn_BenchMark08NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "08");
                        lblgatfinal08.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark08(string.Empty);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "08");
                        if (count == 0)
                        {
                            rbtn_BenchMark08Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark08No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark08 = utilControls.RadioButtonGetSelection(rbtn_BenchMark08Yes, rbtn_BenchMark08No, rbtn_BenchMark08NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "08");
                        lblgatfinal08.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    lblID08.Text = hhgraduation_assessment.gat_b_id;
                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID08.Text;

                    hhgraduation_assessment.yn_children_enrolled_in_school = utilControls.RadioButtonGetSelection(yn_edu_enrolledYes, yn_edu_enrolledNo);
                    hhgraduation_assessment.yn_atte_school_regualarly = utilControls.RadioButtonGetSelection(yn_edu_attend_tegularlayYes, yn_edu_attend_tegularlayNo);
                    hhgraduation_assessment.yn_progress_next_level = utilControls.RadioButtonGetSelection(yn_edu_progressYes, yn_edu_progressNo);

                    #region BenchMarkMet
                    if (hhgraduation_assessment.CheckNumberSchoolAge(HouseholdId) == 0)
                    {
                        rbtn_BenchMark08NA.Checked = true;

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark08 = utilControls.RadioButtonGetSelection(rbtn_BenchMark08Yes, rbtn_BenchMark08No, rbtn_BenchMark08NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "08");
                        lblgatfinal08.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    else
                    {
                        hhgraduation_assessment.saveBenchMark08(hhgraduation_assessment.gat_b_id);

                        int count = hhgraduation_assessment.ValidateBenchMarks(hhgraduation_assessment.gat_id, "08");
                        if (count == 0)
                        {
                            rbtn_BenchMark08Yes.Checked = true;
                        }
                        else
                        {
                            rbtn_BenchMark08No.Checked = true;
                        }

                        #region SaveFinalBenchMarkPassFail
                        hhgraduation_assessment.yn_met_benchmark08 = utilControls.RadioButtonGetSelection(rbtn_BenchMark08Yes, rbtn_BenchMark08No, rbtn_BenchMark08NA);
                        hhgraduation_assessment.saveFinalBenchMark(hhgraduation_assessment.gat_id, "08");
                        lblgatfinal08.Text = hhgraduation_assessment.LoadGatFinalID(hhgraduation_assessment.gat_id);
                        #endregion SaveFinalBenchMarkPassFail
                    }
                    #endregion

                    ValidateBenchMarks();
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion BenchMark01

        protected bool ValidateInput()
        {
            bool isValid = false;
            if (!dtGatDate.Checked || cboSocialWorker.SelectedValue.ToString() == "-1" || cboCaregiver.SelectedValue.ToString() == "-1")
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark01()
        {
            bool isValid = false;
            if (cbo_hhm_01.Text == "Select One" || cbo_hhm_01.Text == string.Empty || (!rbtn_yn_hiv_statusYes.Checked & !rbtn_yn_hiv_statusNo.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark02()
        {
            bool isValid = false;
            if ((cbo_hhm_02.Text == "Select One" || cbo_hhm_02.Text == string.Empty) & hhgraduation_assessment.LoadHouseholdMembersBenchMark02(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                (!yn_supressYes.Checked & !yn_supressNo.Checked) & (!yn_prescribedYes.Checked & !yn_prescribedNo.Checked) & (!yn_appointmentYes.Checked & !yn_appointmentNo.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }


        protected bool ValidateInputBenchMark03()
        {
            bool isValid = false;

            if ((cbo_hhm_03.Text == "Select One" || cbo_hhm_03.Text == string.Empty) & hhgraduation_assessment.LoadHouseholdMembersBenchMark03(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                ((!yn_risks_identifiedYes.Checked & !yn_risks_identifiedNo.Checked) || (!yn_hiv_preventionYes.Checked & !yn_hiv_preventionNo.Checked)))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark04()
        {
            bool isValid = false;

            if ((cbo_hhm_04.Text == "Select One" || cbo_hhm_04.Text == string.Empty) & (hhgraduation_assessment.LoadHouseholdMembersBenchMark04(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                ((!yn_muac_normalYes.Checked & !yn_muac_normalNo.Checked) || (!yn_edema_freeYes.Checked & !yn_edema_freeNo.Checked))))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark05()
        {
            bool isValid = false;

            if ((cbo_hhm_05.Text == "Select One" || cbo_hhm_05.Text == string.Empty) & hhgraduation_assessment.LoadHouseholdMembersBenchMark05(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                (!yn_pay_feesYes.Checked & !yn_pay_feesNo.Checked & !yn_pay_feesNA.Checked) || (!yn_pay_fees_no_grantYes.Checked & !yn_pay_fees_no_grantNo.Checked & !yn_pay_feesNA.Checked) || (!yn_pay_fees_no_sell_assetYes.Checked & !yn_pay_fees_no_sell_assetNo.Checked & !yn_pay_feesNA.Checked) || 
                (!yn_pay_medical_feesYes.Checked & !yn_pay_medical_feesNo.Checked & !yn_pay_medical_feesNA.Checked) || (!yn_pay_medical_fees_no_grantYes.Checked & !yn_pay_medical_fees_no_grantNo.Checked & !yn_pay_medical_feesNA.Checked) || (!yn_pay_medical_fees_no_sell_assetYes.Checked & !yn_pay_medical_fees_no_sell_assetNo.Checked & !yn_pay_medical_feesNA.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark06()
        {
            bool isValid = false;

            if ((cbo_hhm_06.Text == "Select One" || cbo_hhm_06.Text == string.Empty) & hhgraduation_assessment.LoadHouseholdMembersBenchMark06(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                panel01.Enabled == true & panel02.Enabled ==true &  (!yn_adult_kickedYes.Checked & !yn_adult_kickedNo.Checked) || (!yn_child_abuse_awareYes.Checked & !yn_child_abuse_awareNo.Checked))
            {
                isValid = false;
            }
            else if ((cbo_hhm_06.Text == "Select One" || cbo_hhm_06.Text == string.Empty) & hhgraduation_assessment.LoadHouseholdMembersBenchMark06(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
               panel03.Enabled == true & (!yn_adult_kickedYes.Checked & !yn_adult_kickedNo.Checked) || (!yn_child_abuse_awareYes.Checked & !yn_child_abuse_awareNo.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark07()
        {
            bool isValid = false;

            if (!yn_stableCaregiverYes.Checked & !yn_stableCaregiverNo.Checked)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInputBenchMark08()
        {
            bool isValid = false;

            if ((!yn_edu_enrolledYes.Checked & !yn_edu_enrolledNo.Checked) || (!yn_edu_attend_tegularlayYes.Checked & !yn_edu_attend_tegularlayNo.Checked) || (!yn_edu_progressYes.Checked & !yn_edu_progressNo.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
        #endregion save

        #region BenchMarkValidations
        protected void ValidateBenchMarks()
        {
            if (lblID.Text == "lblID")
            {
                btnSaveBenchMark01.Enabled = false;
                btnCancelBenchMark01.Enabled = false;
            }
            else
            {
                btnSaveBenchMark01.Enabled = true;
                btnCancelBenchMark01.Enabled = true;
            }

            if (gdv01.Rows.Count == 0) //made this to allow saving benchamark02 without completing all members on benchmark01
            {
                btnSaveBenchMark02.Enabled = false;
                btnCancelBenchMark02.Enabled = false;
            }
            else
            {
                btnSaveBenchMark02.Enabled = true;
                btnCancelBenchMark02.Enabled = true;
            }

            if (gdv02.Rows.Count == 0 && rbtn_BenchMark02NA.Checked == false && lblgatfinal02.Text == "--")
            {
                btnSaveBenchMark03.Enabled = false;
                btnCancelBenchMark03.Enabled = false;
            }
            else
            {
                btnSaveBenchMark03.Enabled = true;
                btnCancelBenchMark03.Enabled = true;
            }


            if (gdv03.Rows.Count == 0 && rbtn_BenchMark03NA.Checked == false && lblgatfinal03.Text == "--")
            {
                btnSaveBenchMark04.Enabled = false;
                btnCancelBenchMark04.Enabled = false;
            }
            else
            {
                btnSaveBenchMark04.Enabled = true;
                btnCancelBenchMark04.Enabled = true;
            }

            if (hhgraduation_assessment.LoadHouseholdMembersBenchMark04(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 || lblID.Text == "lblID")
            {
                btnSaveBenchMark05.Enabled = false;
                btnCancelBenchMark05.Enabled = false;
            }
            else
            {
                btnSaveBenchMark05.Enabled = true;
                btnCancelBenchMark05.Enabled = true;
            }

            if (gdv05.Rows.Count == 0)
            {
                btnSaveBenchMark06.Enabled = false;
                btnCancelBenchMark06.Enabled = false;
            }
            else
            {
                btnSaveBenchMark06.Enabled = true;
                btnCancelBenchMark06.Enabled = true;
                btnSaveBenchMark05.Enabled = false;
            }

            if (gdv06.Rows.Count == 0)
            {
                btnSaveBenchMark07.Enabled = false;
                btnCancelBenchMark07.Enabled = false;
            }
            else
            {
                btnSaveBenchMark07.Enabled = true;
                btnCancelBenchMark07.Enabled = true;
            }

            if (lblID07.Text == "lblID07")
            {
                btnSaveBenchMark08.Enabled = false;
                btnCancelBenchMark08.Enabled = false;
            }
            else
            {
                btnSaveBenchMark08.Enabled = true;
                btnCancelBenchMark08.Enabled = true;
            }
        }
        #endregion BenchMarkValidations

        protected void ValidateBenchMark06Questions(string hhm_id)
        {
            int age = hhgraduation_assessment.LoadHouseholdMemberAge(hhm_id);
            if (age > 17)
            {
                panel01.Enabled = true;
                panel02.Enabled = true;
                panel03.Enabled = false;
            }

            if (age >= 12 && age <= 17)
            {
                panel01.Enabled = false;
                panel02.Enabled = false;
                panel03.Enabled = true;
            }
        }

        private void btnSaveBenchMark01_Click(object sender, EventArgs e)
        {
            saveBenchMark01();
            LoadMemberLists(hhgraduation_assessment.gat_id, "01", gdv01);
            ValidateBenchMarks();
        }

        private void btnSaveBenchMark02_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark02") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark01 first before saving to benchmark02,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark02();
                LoadMemberLists(hhgraduation_assessment.gat_id, "02", gdv02);
                ValidateBenchMarks();
            }
        }

        private void btnSaveBenchMark03_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark03") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark02 first before saving to benchmark03,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark03();
                LoadMemberLists(hhgraduation_assessment.gat_id, "03", gdv03);
                ValidateBenchMarks();
            }
                
        }

        private void btnSaveBenchMark04_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark04") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark03 first before saving to benchmark04,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark04();
                LoadMemberLists(hhgraduation_assessment.gat_id, "04", gdv04);
                ValidateBenchMarks();
            }  
        }

        private void btnSaveBenchMark05_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark05") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark04 first before saving to benchmark05,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark05();
                LoadMemberLists(hhgraduation_assessment.gat_id, "05", gdv05);
                ValidateBenchMarks();
            }
           
        }

        private void btnSaveBenchMark06_Click(object sender, EventArgs e)
        {
            if (gdv05.Rows.Count == 0)
            {
                MessageBox.Show("Please save BenchMark05 first before saving to benchmark06,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark06();
                LoadMemberLists(hhgraduation_assessment.gat_id, "06", gdv06);
                ValidateBenchMarks();
            } 
        }

        private void btnSaveBenchMark07_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark07") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark06 first before saving to benchmark07,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark07();
                LoadMemberLists(hhgraduation_assessment.gat_id, "07", gdv07);
                ValidateBenchMarks();
            }
        }

        private void btnSaveBenchMark08_Click(object sender, EventArgs e)
        {
            if (hhgraduation_assessment.Check_if_prev_benchmark_saved(hhgraduation_assessment.gat_id, "yn_met_benchmark08") == string.Empty)
            {
                MessageBox.Show("Please save BenchMark07 first before saving to benchmark08,save failed", "SOCYMIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveBenchMark08();
                LoadMemberLists(hhgraduation_assessment.gat_id, "08", gdv08);
                ValidateBenchMarks();
            } 
        }

        private void cbo_hhm_06_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValidateBenchMark06Questions(cbo_hhm_06.SelectedValue.ToString());
        }

        private void gdv01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv01.Rows.Count > 0)
            {
                string gat_b_id = gdv01.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "01");
            }
        }

        private void gdv03_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv03.Rows.Count > 0)
            {
                string gat_b_id = gdv03.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "03");
            }
        }

        private void gdv02_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv02.Rows.Count > 0)
            {
                string gat_b_id = gdv02.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "02");
            }
        }

        private void gdv04_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv04.Rows.Count > 0)
            {
                string gat_b_id = gdv04.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "04");
            }
        }

        private void gdv05_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv05.Rows.Count > 0)
            {
                string gat_b_id = gdv05.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "05");
            }
        }

        private void gdv06_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv06.Rows.Count > 0)
            {
                string gat_b_id = gdv06.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "06");
            }
        }

        private void gdv07_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv07.Rows.Count > 0)
            {
                string gat_b_id = gdv07.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "07");
            }
        }

        private void gdv08_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv08.Rows.Count > 0)
            {
                string gat_b_id = gdv08.CurrentRow.Cells[0].Value.ToString();
                LoadRecordDetails(gat_b_id, "08");
            }
        }

        private void yn_supressYes_CheckedChanged(object sender, EventArgs e)
        {
            if (yn_supressYes.Checked)
            {
                panelART.Enabled = false;
                panelAppointment.Enabled = false;
                yn_prescribedYes.Checked = false;
                yn_prescribedNo.Checked = false;
                yn_appointmentYes.Checked = false;
                yn_appointmentNo.Checked = false;
            }
            else
            {
                panelART.Enabled = true;
                panelAppointment.Enabled = true;
                yn_prescribedYes.Checked = false;
                yn_prescribedNo.Checked = false;
                yn_appointmentYes.Checked = false;
                yn_appointmentNo.Checked = false;
            }
        }

        private void yn_supressNo_CheckedChanged(object sender, EventArgs e)
        {
            yn_supressYes_CheckedChanged(yn_supressYes, null);
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void yn_pay_feesNA_CheckedChanged(object sender, EventArgs e)
        {
            if (yn_pay_feesNA.Checked)
            {
                panel052.Enabled = false;
                panel053.Enabled = false;
                yn_pay_fees_no_grantYes.Checked = false;
                yn_pay_fees_no_grantNo.Checked = false;
                yn_pay_fees_no_sell_assetYes.Checked = false;
                yn_pay_fees_no_sell_assetNo.Checked = false;
            }
            else
            {
                yn_pay_fees_no_grantYes.Checked = false;
                yn_pay_fees_no_grantNo.Checked = false;
                yn_pay_fees_no_sell_assetYes.Checked = false;
                yn_pay_fees_no_sell_assetNo.Checked = false;
                panel052.Enabled = true;
                panel053.Enabled = true;
            }
        }

        private void yn_pay_feesNo_CheckedChanged(object sender, EventArgs e)
        {
            yn_pay_feesNA_CheckedChanged(yn_pay_feesNA,null);
        }

        private void yn_pay_feesYes_CheckedChanged(object sender, EventArgs e)
        {
            yn_pay_feesNA_CheckedChanged(yn_pay_feesNA, null);
        }

        private void yn_pay_fees_no_grantNo_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void yn_pay_fees_no_grantYes_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void yn_pay_fees_no_sell_assetNo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void yn_pay_fees_no_sell_assetYes_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void yn_pay_medical_feesNA_CheckedChanged(object sender, EventArgs e)
        {
            if (yn_pay_medical_feesNA.Checked)
            {
                yn_pay_medical_fees_no_sell_assetYes.Checked = false;
                yn_pay_medical_fees_no_sell_assetNo.Checked = false;
                yn_pay_medical_fees_no_grantYes.Checked = false;
                yn_pay_medical_fees_no_grantNo.Checked = false;
                panel055.Enabled = false;
                panel056.Enabled = false;
            }
            else
            {
                yn_pay_medical_fees_no_sell_assetYes.Checked = false;
                yn_pay_medical_fees_no_sell_assetNo.Checked = false;
                yn_pay_medical_fees_no_grantYes.Checked = false;
                yn_pay_medical_fees_no_grantNo.Checked = false;
                panel055.Enabled = true;
                panel056.Enabled = true;
            }
        }

        private void yn_pay_medical_fees_no_grantNo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void yn_pay_medical_fees_no_grantYes_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void yn_pay_medical_fees_no_sell_assetNo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void yn_pay_medical_fees_no_sell_assetYes_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void yn_pay_medical_feesNo_CheckedChanged(object sender, EventArgs e)
        {
            yn_pay_medical_feesNA_CheckedChanged(yn_pay_medical_feesNA, null);
        }

        private void yn_pay_medical_feesYes_CheckedChanged(object sender, EventArgs e)
        {
            yn_pay_medical_feesNA_CheckedChanged(yn_pay_medical_feesNA, null);
        }
    }
}
