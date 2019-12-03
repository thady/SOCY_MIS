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
    public partial class frmHouseholdRiskAssessmentAdult : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdRiskAssessmentMain frmCll = null;
        private Master frmMST = null;
        int Age = 0;
        DataTable dt = null;
        string errorMessage = string.Empty;
        public frmHouseholdRiskAssessmentPopup frmPopup = new frmHouseholdRiskAssessmentPopup();
        #endregion Variables

        #region Property
        public frmHouseholdRiskAssessmentMain FormCalling
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

        public frmHouseholdRiskAssessmentAdult()
        {
            InitializeComponent();
        }

        private void frmHouseholdRiskAssessmentAdult_Load(object sender, EventArgs e)
        {
            LoadCriterialList();
            LoadMembers();

            if (ObjectId != string.Empty)
            {
                LoadDisplayLine(ObjectId);
            }
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        protected void LoadCriterialList()
        {
            dt = hhHouseholdRiskAssessment.ReturnCriteriaListAdults();

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["cr_id"] = "-1";
            sctemptyRow["cr_name"] = "Select one";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboCriteria.DataSource = dt;
            cboCriteria.DisplayMember = "cr_name";
            cboCriteria.ValueMember = "cr_id";
        }

        protected void Back()
        {
            FormCalling.Back();
        }

        protected void LoadMembers()
        {
            if (SystemConstants.isRiskAssessmentPopup == false)
            {
                btnsave.Text = "Save";
                dt = hhHouseholdRiskAssessment.ReturnMembers("adult", hhHouseholdRiskAssessment.ra_id, HouseholdId);

                DataRow sctemptyRow = dt.NewRow();
                sctemptyRow["hhm_id"] = "-1";
                sctemptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(sctemptyRow, 0);

                cboHouseholdMember.DataSource = dt;
                cboHouseholdMember.DisplayMember = "hhm_name";
                cboHouseholdMember.ValueMember = "hhm_id";
            }
            else
            {
                btnsave.Text = "Save and Close";
                lblBack.Visible = false;
                dt = hhHouseholdRiskAssessment.ReturnMembers("adult", hhHouseholdRiskAssessment.ra_id, SystemConstants.HouseholdId);

                DataRow sctemptyRow = dt.NewRow();
                sctemptyRow["hhm_id"] = "-1";
                sctemptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(sctemptyRow, 0);

                cboHouseholdMember.DataSource = dt;
                cboHouseholdMember.DisplayMember = "hhm_name";
                cboHouseholdMember.ValueMember = "hhm_id";
            }
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (ValidateInput())
            {
                if (SystemConstants.isRiskAssessmentPopup == true)
                {
                    save();

                    Application.OpenForms
                    .OfType<Form>()
                    .Where(form => String.Equals(form.Name, "frmHouseholdRiskAssessmentPopup"))
                    .ToList()
                    .ForEach(form => form.Close());
                }
                else
                {
                    save();
                }
                
            }
            else
            {
                MessageBox.Show("Please fill in all required values,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region save
        protected void save()
        {
            #region set variables

            //hhHouseholdRiskAssessment.ra_id = ObjectId;
            hhHouseholdRiskAssessment.hhm_name = cboHouseholdMember.Text;

            hhHouseholdRiskAssessment.ra_criteria_id = cboCriteria.SelectedValue.ToString();
            hhHouseholdRiskAssessment.yn_hiv_test = utilControls.RadioButtonGetSelection(rbtn_yn_hiv_test_Yes, rbtn_yn_hiv_test_No);
            hhHouseholdRiskAssessment.yn_unprotected_sex = utilControls.RadioButtonGetSelection(rbtn_yn_unprotected_sex_Yes, rbtn_yn_unprotected_sex_No);
            hhHouseholdRiskAssessment.yn_sex_worker = utilControls.RadioButtonGetSelection(rbtn_yn_sex_worker_Yes, rbtn_yn_sex_worker_No);
            hhHouseholdRiskAssessment.yn_lost_sexual_partner = utilControls.RadioButtonGetSelection(rbtn_yn_lost_sexual_partner_Yes, rbtn_yn_lost_sexual_partner_No);
            hhHouseholdRiskAssessment.yn_tb_disease = utilControls.RadioButtonGetSelection(rbtn_yn_tb_disease_Yes, rbtn_yn_tb_disease_No);
            hhHouseholdRiskAssessment.yn_sexual_violence = utilControls.RadioButtonGetSelection(rbtn_yn_sexual_violence_Yes, rbtn_yn_sexual_violence_No);
            hhHouseholdRiskAssessment.yn_sickly = utilControls.RadioButtonGetSelection(rbtn_yn_sickly_Yes, rbtn_yn_sickly_No);
            hhHouseholdRiskAssessment.yn_pregnant_not_tested = utilControls.RadioButtonGetSelection(rbtn_yn_pregnant_not_tested_Yes, rbtn_yn_pregnant_not_tested_No);
            hhHouseholdRiskAssessment.yn_breast_feeding_not_tested = utilControls.RadioButtonGetSelection(rbtn_yn_breast_feeding_not_tested_Yes, rbtn_yn_breast_feeding_not_tested_No);
            hhHouseholdRiskAssessment.yn_hiv_neg_discodant_not_tested = utilControls.RadioButtonGetSelection(rbtn_yn_hiv_neg_discodant_not_tested_Yes, rbtn_yn_hiv_neg_discodant_not_tested_No);
            hhHouseholdRiskAssessment.yn_sti = utilControls.RadioButtonGetSelection(rbtn_yn_sti_Yes, rbtn_yn_sti_No);
            hhHouseholdRiskAssessment.yn_hepatitis_b = utilControls.RadioButtonGetSelection(rbtn_yn_hepatitis_b_Yes, rbtn_yn_hepatitis_b_No);
            hhHouseholdRiskAssessment.yn_male_female_not_tested = utilControls.RadioButtonGetSelection(rbtn_yn_male_female_not_tested_Yes, rbtn_yn_male_female_not_tested_No);
            hhHouseholdRiskAssessment.yn_hhm_at_risk = utilControls.RadioButtonGetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No);

            if (rbtn_yn_hmm_test_TR.Checked) { hhHouseholdRiskAssessment.yn_hmm_test = rbtn_yn_hmm_test_TR.Text; }
            else if (rbtn_yn_hmm_test_TNR.Checked) { hhHouseholdRiskAssessment.yn_hmm_test = rbtn_yn_hmm_test_TNR.Text; }

            hhHouseholdRiskAssessment.yn_hhm_accept_test = utilControls.RadioButtonGetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA);
            hhHouseholdRiskAssessment.yn_referal = utilControls.RadioButtonGetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA);
            hhHouseholdRiskAssessment.yn_referal_completed = utilControls.RadioButtonGetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA);

            #region HIV status
            if (rbtn_test_result_pos.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTPositive; }
            else if (rbtn_test_result_neg.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTNegative; }
            else if (rbtn_test_result_unknown.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTUnKnown; }
            else { hhHouseholdRiskAssessment.test_result = string.Empty; }
            #endregion HIV status

            hhHouseholdRiskAssessment.usr_id_create = SystemConstants.user_id;
            hhHouseholdRiskAssessment.usr_id_update = SystemConstants.user_id;
            hhHouseholdRiskAssessment.usr_date_create = DateTime.Today;
            hhHouseholdRiskAssessment.usr_date_update = DateTime.Today;
            hhHouseholdRiskAssessment.ofc_id = SystemConstants.ofc_id;
            hhHouseholdRiskAssessment.district_id = SystemConstants.Return_office_district();

            if (hhHouseholdRiskAssessment.ram_id == string.Empty)
            {
                #region member details
                dt = hhHouseholdRiskAssessment.ReturnMembers(cboHouseholdMember.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];
                    hhHouseholdRiskAssessment.gnd_age = dtRow["Age"].ToString();
                    hhHouseholdRiskAssessment.gnd_name = dtRow["gnd_name"].ToString();
                }
                #endregion member details

                hhHouseholdRiskAssessment.hhm_id = cboHouseholdMember.SelectedValue.ToString();
                hhHouseholdRiskAssessment.ram_id = Guid.NewGuid().ToString();
                hhHouseholdRiskAssessment.save_hh_household_risk_assessment_member_adult("save");
                MessageBox.Show("save successful", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                LoadDisplayLine(hhHouseholdRiskAssessment.ra_id);
                Clear();
            }
            else
            {
                #region member details
                dt = hhHouseholdRiskAssessment.ReturnMembers(hhHouseholdRiskAssessment.hhm_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];
                    hhHouseholdRiskAssessment.gnd_age = dtRow["Age"].ToString();
                    hhHouseholdRiskAssessment.gnd_name = dtRow["gnd_name"].ToString();
                }
                #endregion member details

                hhHouseholdRiskAssessment.save_hh_household_risk_assessment_member_adult("update");
                MessageBox.Show("update successful", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembers();
                LoadDisplayLine(hhHouseholdRiskAssessment.ra_id);
                Clear();
            }

            #endregion set variables
        }
        #endregion save

        protected void LoadDisplay(string ram_id)
        {
            dt = hhHouseholdRiskAssessment.LoadRATDetails(ram_id, "adult");
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboHouseholdMember.Text = dtRow["hhm_name"].ToString();
                cboCriteria.SelectedValue = dtRow["ra_criteria_id"].ToString();
                hhHouseholdRiskAssessment.hhm_id = dtRow["hhm_id"].ToString();
                hhHouseholdRiskAssessment.ram_id = dtRow["ram_id"].ToString();

                utilControls.RadioButtonSetSelection(rbtn_yn_hiv_test_Yes, rbtn_yn_hiv_test_No, dtRow["yn_hiv_test"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_unprotected_sex_Yes, rbtn_yn_unprotected_sex_No, dtRow["yn_unprotected_sex"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_sex_worker_Yes, rbtn_yn_sex_worker_No, dtRow["yn_sex_worker"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_lost_sexual_partner_Yes, rbtn_yn_lost_sexual_partner_No, dtRow["yn_lost_sexual_partner"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_tb_disease_Yes, rbtn_yn_tb_disease_No, dtRow["yn_tb_disease"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_Yes, rbtn_yn_sexual_violence_No, dtRow["yn_sexual_violence"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_sickly_Yes, rbtn_yn_sickly_No, dtRow["yn_sickly"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_pregnant_not_tested_Yes, rbtn_yn_pregnant_not_tested_No, dtRow["yn_pregnant_not_tested"].ToString());

                utilControls.RadioButtonSetSelection(rbtn_yn_breast_feeding_not_tested_Yes, rbtn_yn_breast_feeding_not_tested_No, dtRow["yn_breast_feeding_not_tested"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_hiv_neg_discodant_not_tested_Yes, rbtn_yn_hiv_neg_discodant_not_tested_No, dtRow["yn_hiv_neg_discodant_not_tested"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_sti_Yes, rbtn_yn_sti_No, dtRow["yn_sti"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_hepatitis_b_Yes, rbtn_yn_hepatitis_b_No, dtRow["yn_hepatitis_b"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_male_female_not_tested_Yes, rbtn_yn_male_female_not_tested_No, dtRow["yn_male_female_not_tested"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, dtRow["yn_hhm_at_risk"].ToString());

                if (dtRow["yn_hmm_test"].ToString() == "TR") { rbtn_yn_hmm_test_TR.Checked = true; }
                else if (dtRow["yn_hmm_test"].ToString() == "TNR") { rbtn_yn_hmm_test_TNR.Checked = true; }

                utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, dtRow["yn_hhm_accept_test"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, dtRow["yn_referal"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, dtRow["yn_referal_completed"].ToString());

                #region HIV status
                if (dtRow["test_result"].ToString() == utilConstants.cHSTPositive) { rbtn_test_result_pos.Checked = true; }
                else if (dtRow["test_result"].ToString() == utilConstants.cHSTNegative) { rbtn_test_result_neg.Checked = true; }
                else if (dtRow["test_result"].ToString() == utilConstants.cHSTUnKnown) { rbtn_test_result_unknown.Checked = true; }
                #endregion HIV status
            }
        }

        protected void Clear()
        {
            cboHouseholdMember.SelectedValue = "-1";
            cboCriteria.SelectedValue = "-1";
            utilControls.RadioButtonSetSelection(rbtn_yn_hiv_test_Yes, rbtn_yn_hiv_test_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_unprotected_sex_Yes, rbtn_yn_unprotected_sex_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sex_worker_Yes, rbtn_yn_sex_worker_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_lost_sexual_partner_Yes, rbtn_yn_lost_sexual_partner_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_tb_disease_Yes, rbtn_yn_tb_disease_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_Yes, rbtn_yn_sexual_violence_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sickly_Yes, rbtn_yn_sickly_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_pregnant_not_tested_Yes, rbtn_yn_pregnant_not_tested_No, string.Empty);

            utilControls.RadioButtonSetSelection(rbtn_yn_breast_feeding_not_tested_Yes, rbtn_yn_breast_feeding_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hiv_neg_discodant_not_tested_Yes, rbtn_yn_hiv_neg_discodant_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sti_Yes, rbtn_yn_sti_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hepatitis_b_Yes, rbtn_yn_hepatitis_b_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_male_female_not_tested_Yes, rbtn_yn_male_female_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);
            rbtn_yn_hmm_test_TR.Checked = false;
            rbtn_yn_hmm_test_TNR.Checked = false;
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, string.Empty);
            rbtn_test_result_pos.Checked = false;
            rbtn_test_result_neg.Checked = false;
            rbtn_test_result_unknown.Checked = false;
            hhHouseholdRiskAssessment.ram_id = string.Empty;
        }

        protected void ClearPanel()
        {
            utilControls.RadioButtonSetSelection(rbtn_yn_hiv_test_Yes, rbtn_yn_hiv_test_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_unprotected_sex_Yes, rbtn_yn_unprotected_sex_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sex_worker_Yes, rbtn_yn_sex_worker_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_lost_sexual_partner_Yes, rbtn_yn_lost_sexual_partner_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_tb_disease_Yes, rbtn_yn_tb_disease_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_Yes, rbtn_yn_sexual_violence_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sickly_Yes, rbtn_yn_sickly_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_pregnant_not_tested_Yes, rbtn_yn_pregnant_not_tested_No, string.Empty);

            utilControls.RadioButtonSetSelection(rbtn_yn_breast_feeding_not_tested_Yes, rbtn_yn_breast_feeding_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hiv_neg_discodant_not_tested_Yes, rbtn_yn_hiv_neg_discodant_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sti_Yes, rbtn_yn_sti_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hepatitis_b_Yes, rbtn_yn_hepatitis_b_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_male_female_not_tested_Yes, rbtn_yn_male_female_not_tested_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);
            rbtn_yn_hmm_test_TR.Checked = false;
            rbtn_yn_hmm_test_TNR.Checked = false;
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, string.Empty);
            rbtn_test_result_pos.Checked = false;
            rbtn_test_result_neg.Checked = false;
            rbtn_test_result_unknown.Checked = false;
            hhHouseholdRiskAssessment.ram_id = string.Empty;
        }

        protected void LoadDisplayLine(string ra_id)
        {
            dt = hhHouseholdRiskAssessment.ReturnDisplayLine(ra_id, "adult");
            if (dt.Rows.Count > 0)
            {
                gdv_members.DataSource = dt;
                gdv_members.Columns["ram_id"].Visible = false;

                gdv_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_members.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_members.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_members.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_members.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_members.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_members.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdv_members.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdv_members.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        private void gdv_members_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();

            if (gdv_members.Rows.Count > 0)
            {
                string ram_id = gdv_members.CurrentRow.Cells[0].Value.ToString();
                LoadDisplay(ram_id);
            }
        }

        private void cboCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriteria.SelectedValue.ToString() == "-1")
            {
                tlpDisplay03.Enabled = false;
                ClearPanel();
            }
            else
            {
                tlpDisplay03.Enabled = true;
            }
        }


        protected bool ValidateInput()
        {
            bool isValid = false;

            if (hhHouseholdRiskAssessment.ram_id == string.Empty)
            {
                if (cboHouseholdMember.SelectedValue.ToString() == "-1" || cboCriteria.SelectedValue.ToString() == "-1" ||
                (!rbtn_yn_hiv_test_Yes.Checked & !rbtn_yn_hiv_test_No.Checked) ||
                (!rbtn_yn_unprotected_sex_Yes.Checked & !rbtn_yn_unprotected_sex_No.Checked) ||
                (!rbtn_yn_sex_worker_Yes.Checked & !rbtn_yn_sex_worker_No.Checked) ||
                (!rbtn_yn_lost_sexual_partner_Yes.Checked & !rbtn_yn_lost_sexual_partner_No.Checked) ||
                (!rbtn_yn_tb_disease_Yes.Checked & !rbtn_yn_tb_disease_No.Checked) ||
                (!rbtn_yn_sexual_violence_Yes.Checked & !rbtn_yn_sexual_violence_No.Checked) ||
                (!rbtn_yn_sickly_Yes.Checked & !rbtn_yn_sickly_No.Checked) ||
                (!rbtn_yn_pregnant_not_tested_Yes.Checked & !rbtn_yn_pregnant_not_tested_No.Checked) ||
                (!rbtn_yn_breast_feeding_not_tested_Yes.Checked & !rbtn_yn_breast_feeding_not_tested_No.Checked) ||
                (!rbtn_yn_hiv_neg_discodant_not_tested_Yes.Checked & !rbtn_yn_hiv_neg_discodant_not_tested_No.Checked) ||
                (!rbtn_yn_sti_Yes.Checked & !rbtn_yn_sti_No.Checked) ||
                (!rbtn_yn_hepatitis_b_Yes.Checked & !rbtn_yn_hepatitis_b_No.Checked) ||
                (!rbtn_yn_male_female_not_tested_Yes.Checked & !rbtn_yn_male_female_not_tested_No.Checked) ||
                (!rbtn_yn_hhm_at_risk_Yes.Checked & !rbtn_yn_hhm_at_risk_No.Checked) ||
               (!rbtn_yn_hmm_test_TR.Checked & !rbtn_yn_hmm_test_TNR.Checked) ||
               (!rbtn_yn_hhm_accept_test_Yes.Checked & !rbtn_yn_hhm_accept_test_No.Checked & !rbtn_yn_hhm_accept_test_NA.Checked) ||
               (!rbtn_yn_referal_Yes.Checked & !rbtn_yn_referal_No.Checked & !rbtn_yn_referal_NA.Checked) ||
               (!rbtn_yn_referal_completed_Yes.Checked & !rbtn_yn_referal_completed_No.Checked & !rbtn_yn_referal_completed_NA.Checked))

                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                if (cboCriteria.SelectedValue.ToString() == "-1" ||
                (!rbtn_yn_hiv_test_Yes.Checked & !rbtn_yn_hiv_test_No.Checked) ||
                (!rbtn_yn_unprotected_sex_Yes.Checked & !rbtn_yn_unprotected_sex_No.Checked) ||
                (!rbtn_yn_sex_worker_Yes.Checked & !rbtn_yn_sex_worker_No.Checked) ||
                (!rbtn_yn_lost_sexual_partner_Yes.Checked & !rbtn_yn_lost_sexual_partner_No.Checked) ||
                (!rbtn_yn_tb_disease_Yes.Checked & !rbtn_yn_tb_disease_No.Checked) ||
                (!rbtn_yn_sexual_violence_Yes.Checked & !rbtn_yn_sexual_violence_No.Checked) ||
                (!rbtn_yn_sickly_Yes.Checked & !rbtn_yn_sickly_No.Checked) ||
                (!rbtn_yn_pregnant_not_tested_Yes.Checked & !rbtn_yn_pregnant_not_tested_No.Checked) ||
                (!rbtn_yn_breast_feeding_not_tested_Yes.Checked & !rbtn_yn_breast_feeding_not_tested_No.Checked) ||
                (!rbtn_yn_hiv_neg_discodant_not_tested_Yes.Checked & !rbtn_yn_hiv_neg_discodant_not_tested_No.Checked) ||
                (!rbtn_yn_sti_Yes.Checked & !rbtn_yn_sti_No.Checked) ||
                (!rbtn_yn_hepatitis_b_Yes.Checked & !rbtn_yn_hepatitis_b_No.Checked) ||
                (!rbtn_yn_male_female_not_tested_Yes.Checked & !rbtn_yn_male_female_not_tested_No.Checked) ||
                (!rbtn_yn_hhm_at_risk_Yes.Checked & !rbtn_yn_hhm_at_risk_No.Checked) ||
               (!rbtn_yn_hmm_test_TR.Checked & !rbtn_yn_hmm_test_TNR.Checked) ||
               (!rbtn_yn_hhm_accept_test_Yes.Checked & !rbtn_yn_hhm_accept_test_No.Checked & !rbtn_yn_hhm_accept_test_NA.Checked) ||
               (!rbtn_yn_referal_Yes.Checked & !rbtn_yn_referal_No.Checked & !rbtn_yn_referal_NA.Checked) ||
               (!rbtn_yn_referal_completed_Yes.Checked & !rbtn_yn_referal_completed_No.Checked & !rbtn_yn_referal_completed_NA.Checked))
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        protected void AutoCheckRisk()
        {
            if (rbtn_yn_hiv_test_Yes.Checked || rbtn_yn_unprotected_sex_Yes.Checked || rbtn_yn_sex_worker_Yes.Checked || rbtn_yn_lost_sexual_partner_Yes.Checked ||
                rbtn_yn_tb_disease_Yes.Checked || rbtn_yn_sexual_violence_Yes.Checked || rbtn_yn_sickly_Yes.Checked || rbtn_yn_pregnant_not_tested_Yes.Checked ||
                rbtn_yn_breast_feeding_not_tested_Yes.Checked || rbtn_yn_hiv_neg_discodant_not_tested_Yes.Checked || rbtn_yn_sti_Yes.Checked || rbtn_yn_hepatitis_b_Yes.Checked ||
                rbtn_yn_male_female_not_tested_Yes.Checked)
            {
                rbtn_yn_hhm_at_risk_Yes.Checked = true;
            }
            else
            {
                rbtn_yn_hhm_at_risk_No.Checked = true;
            }
        }

        private void rbtn_yn_hiv_test_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hiv_test_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_unprotected_sex_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_unprotected_sex_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sex_worker_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sex_worker_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_lost_sexual_partner_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_lost_sexual_partner_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_tb_disease_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_tb_disease_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sexual_violence_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sexual_violence_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sickly_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sickly_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_pregnant_not_tested_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_pregnant_not_tested_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_breast_feeding_not_tested_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_breast_feeding_not_tested_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hiv_neg_discodant_not_tested_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hiv_neg_discodant_not_tested_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sti_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sti_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hepatitis_b_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hepatitis_b_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_male_female_not_tested_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_male_female_not_tested_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hmm_test_TR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_yn_hmm_test_TR.Checked)
            {
                rbtn_yn_hhm_accept_test_Yes.Enabled = true;
                rbtn_yn_hhm_accept_test_No.Enabled = true;
                rbtn_yn_referal_Yes.Enabled = true;
                rbtn_yn_referal_No.Enabled = true;
                rbtn_yn_referal_completed_Yes.Enabled = true;
                rbtn_yn_referal_completed_No.Enabled = true;

                rbtn_yn_hhm_accept_test_NA.Checked = false;
                rbtn_yn_hhm_accept_test_NA.Enabled = false;
                rbtn_yn_referal_NA.Checked = false;
                rbtn_yn_referal_NA.Enabled = false;
                rbtn_yn_referal_completed_NA.Checked = false;
                rbtn_yn_referal_completed_NA.Enabled = false;
            }
            else
            {
                rbtn_yn_hhm_accept_test_Yes.Enabled = false;
                rbtn_yn_hhm_accept_test_No.Enabled = false;
                rbtn_yn_referal_Yes.Enabled = false;
                rbtn_yn_referal_No.Enabled = false;
                rbtn_yn_referal_completed_Yes.Enabled = false;
                rbtn_yn_referal_completed_No.Enabled = false;

                rbtn_yn_hhm_accept_test_NA.Checked = true;
                rbtn_yn_hhm_accept_test_NA.Enabled = true;
                rbtn_yn_referal_NA.Checked = true;
                rbtn_yn_referal_NA.Enabled = true;
                rbtn_yn_referal_completed_NA.Checked = true;
                rbtn_yn_referal_completed_NA.Enabled = true;
            }
        }

        private void rbtn_yn_hmm_test_TNR_CheckedChanged(object sender, EventArgs e)
        {
            rbtn_yn_hmm_test_TR_CheckedChanged(rbtn_yn_hmm_test_TR,null);
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }
    }
}
