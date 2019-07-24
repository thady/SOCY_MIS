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
            LoadHouseholdMembers();
            ValidateBenchMarks();
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
                emptyRow["hhm_name"] = "Select Caregiver";
                dt.Rows.InsertAt(emptyRow, 0);

                cboCaregiver.DataSource = dt;
                cboCaregiver.ValueMember = "hhm_id";
                cboCaregiver.DisplayMember = "hhm_name";
            }
        }


        protected void LoadHouseholdMembersBenchMark01(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark01(HouseholdId,gat_id);

                DataRow emptyRow = dt.NewRow();
                emptyRow["hhm_id"] = "-1";
                emptyRow["hhm_name"] = "Select Caregiver";
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
            emptyRow["hhm_name"] = "Select Caregiver";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_02.DataSource = dt;
            cbo_hhm_02.ValueMember = "hhm_id";
            cbo_hhm_02.DisplayMember = "hhm_name";
        }

        protected void LoadHouseholdMembersBenchMark03(string gat_id)
        {
            dt = hhgraduation_assessment.LoadHouseholdMembersBenchMark03(HouseholdId, gat_id);

            DataRow emptyRow = dt.NewRow();
            emptyRow["hhm_id"] = "-1";
            emptyRow["hhm_name"] = "Select Caregiver";
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
            emptyRow["hhm_name"] = "Select Caregiver";
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_hhm_04.DataSource = dt;
            cbo_hhm_04.ValueMember = "hhm_id";
            cbo_hhm_04.DisplayMember = "hhm_name";
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
            Return_paraSocialWorkers();
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
                    hhgraduation_assessment.gat_date = dtGatDate.Value.Date;
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
                    //lblID01.Text = hhgraduation_assessment.gat_b_id;
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID01.Text;
                    hhgraduation_assessment.hhm_id = cbo_hhm_01.SelectedValue.ToString();
                    hhgraduation_assessment.yn_hiv_status = utilControls.RadioButtonGetSelection(rbtn_yn_hiv_statusYes, rbtn_yn_hiv_statusNo);

                    hhgraduation_assessment.saveBenchMark01(hhgraduation_assessment.gat_b_id);
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark01(hhgraduation_assessment.gat_id);
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill in all required values!,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion BenchMark01


        #region BenchMark01
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

                    hhgraduation_assessment.saveBenchMark02(string.Empty);
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
                    MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hhgraduation_assessment.gat_b_id = lblID02.Text;
                    hhgraduation_assessment.hhm_id = cbo_hhm_02.SelectedValue.ToString();
                    hhgraduation_assessment.yn_supressed = utilControls.RadioButtonGetSelection(yn_supressYes, yn_supressNo);
                    hhgraduation_assessment.yn_adhering = utilControls.RadioButtonGetSelection(yn_prescribedYes, yn_prescribedNo);
                    hhgraduation_assessment.yn_attend_art_appointment = utilControls.RadioButtonGetSelection(yn_appointmentYes, yn_appointmentNo);

                    hhgraduation_assessment.saveBenchMark02(hhgraduation_assessment.gat_b_id);
                    ValidateBenchMarks();
                    LoadHouseholdMembersBenchMark02(hhgraduation_assessment.gat_id);
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
            if (lblID03.Text == "lblID03")
            {
                hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                hhgraduation_assessment.hhm_id = cbo_hhm_03.SelectedValue.ToString();
                hhgraduation_assessment.yn_hiv_risk_knowledge = utilControls.RadioButtonGetSelection(yn_risks_identifiedYes, yn_risks_identifiedNo);
                hhgraduation_assessment.yn_hiv_prevention = utilControls.RadioButtonGetSelection(yn_hiv_preventionYes, yn_hiv_preventionNo);
                hhgraduation_assessment.saveBenchMark03(string.Empty);
                ValidateBenchMarks();
                LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                hhgraduation_assessment.gat_b_id = lblID03.Text;
                hhgraduation_assessment.hhm_id = cbo_hhm_03.SelectedValue.ToString();
                hhgraduation_assessment.yn_hiv_risk_knowledge = utilControls.RadioButtonGetSelection(yn_risks_identifiedYes, yn_risks_identifiedNo);
                hhgraduation_assessment.yn_hiv_prevention = utilControls.RadioButtonGetSelection(yn_hiv_preventionYes, yn_hiv_preventionNo);
                hhgraduation_assessment.saveBenchMark03(hhgraduation_assessment.gat_b_id);
                ValidateBenchMarks();
                LoadHouseholdMembersBenchMark03(hhgraduation_assessment.gat_id);
                MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }


        protected void saveBenchMark04()
        {
            if (lblID04.Text == "lblID04")
            {
                hhgraduation_assessment.gat_b_id = Guid.NewGuid().ToString();
                hhgraduation_assessment.hhm_id = cbo_hhm_04.SelectedValue.ToString();

                hhgraduation_assessment.yn_muac_normal = utilControls.RadioButtonGetSelection(yn_muac_normalYes, yn_muac_normalNo);
                hhgraduation_assessment.yn_edema_free = utilControls.RadioButtonGetSelection(yn_edema_freeYes, yn_edema_freeNo);
                hhgraduation_assessment.saveBenchMark04(string.Empty);
                ValidateBenchMarks();
                LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                hhgraduation_assessment.gat_b_id = lblID04.Text;
                hhgraduation_assessment.hhm_id = cbo_hhm_04.SelectedValue.ToString();

                hhgraduation_assessment.yn_muac_normal = utilControls.RadioButtonGetSelection(yn_muac_normalYes, yn_muac_normalNo);
                hhgraduation_assessment.yn_edema_free = utilControls.RadioButtonGetSelection(yn_edema_freeYes, yn_edema_freeNo);
                hhgraduation_assessment.saveBenchMark04(hhgraduation_assessment.gat_b_id);
                ValidateBenchMarks();
                LoadHouseholdMembersBenchMark04(hhgraduation_assessment.gat_id);
                MessageBox.Show("Success!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbo_hhm_01.SelectedValue.ToString() == "-1" || (!rbtn_yn_hiv_statusYes.Checked & !rbtn_yn_hiv_statusNo.Checked))
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
            if (cbo_hhm_02.SelectedValue.ToString() == "-1" &  hhgraduation_assessment.LoadHouseholdMembersBenchMark02(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 &
                (!yn_supressYes.Checked & !yn_supressNo.Checked) || (!yn_prescribedYes.Checked & !yn_prescribedNo.Checked) || (!yn_appointmentYes.Checked & !yn_appointmentNo.Checked))
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

            if (hhgraduation_assessment.LoadHouseholdMembersBenchMark01(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 || lblID.Text == "lblID")
            {
                btnSaveBenchMark02.Enabled = false;
                btnCancelBenchMark02.Enabled = false;
            }
            else
            {
                btnSaveBenchMark02.Enabled = true;
                btnCancelBenchMark02.Enabled = true;
            }

            if (hhgraduation_assessment.LoadHouseholdMembersBenchMark02(HouseholdId, hhgraduation_assessment.gat_id).Rows.Count > 0 || lblID.Text == "lblID")
            {
                btnSaveBenchMark03.Enabled = false;
                btnCancelBenchMark03.Enabled = false;
            }
            else
            {
                btnSaveBenchMark03.Enabled = true;
                btnCancelBenchMark03.Enabled = true;
            }
        }
        #endregion BenchMarkValidations

        private void btnSaveBenchMark01_Click(object sender, EventArgs e)
        {
            saveBenchMark01();
        }

        private void btnSaveBenchMark02_Click(object sender, EventArgs e)
        {
            saveBenchMark02();
        }

        private void btnSaveBenchMark03_Click(object sender, EventArgs e)
        {
            saveBenchMark03();
        }

        private void btnSaveBenchMark04_Click(object sender, EventArgs e)
        {
            saveBenchMark04();
        }
    }
}
