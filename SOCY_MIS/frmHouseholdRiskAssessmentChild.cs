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
    public partial class frmHouseholdRiskAssessmentChild : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdRiskAssessmentMain frmCll = null;
        public frmHouseholdRiskAssessmentPopup frmPopup = new frmHouseholdRiskAssessmentPopup();
        private Master frmMST = null;
        int Age = 0;
        DataTable dt = null;
        string errorMessage = string.Empty;
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

        public frmHouseholdRiskAssessmentChild()
        {
            InitializeComponent();
        }

        private void frmHouseholdRiskAssessmentChild_Load(object sender, EventArgs e)
        {
            LoadCriterialList();
            LoadMembers();
            cboCriteria_SelectedIndexChanged(cboCriteria, null);
            if (ObjectId != string.Empty)
            {
                LoadDisplayLine(ObjectId);
            }
        }

        protected void LoadCriterialList()
        {
            dt = hhHouseholdRiskAssessment.ReturnCriteriaList();

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["cr_id"] = "-1";
            sctemptyRow["cr_name"] = "Select one";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboCriteria.DataSource = dt;
            cboCriteria.DisplayMember = "cr_name";
            cboCriteria.ValueMember = "cr_id";
        }

        protected void LoadMembers()
        {
            if (SystemConstants.isRiskAssessmentPopup == false)
            {
                btnsave.Text = "Save";

                dt = hhHouseholdRiskAssessment.ReturnMembers("child", hhHouseholdRiskAssessment.ra_id, HouseholdId);
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
                dt = hhHouseholdRiskAssessment.ReturnMembers("child", hhHouseholdRiskAssessment.ra_id, SystemConstants.HouseholdId);
                DataRow sctemptyRow = dt.NewRow();
                sctemptyRow["hhm_id"] = "-1";
                sctemptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(sctemptyRow, 0);

                cboHouseholdMember.DataSource = dt;
                cboHouseholdMember.DisplayMember = "hhm_name";
                cboHouseholdMember.ValueMember = "hhm_id";
            }

            #region LoadNMNMembers
            dt = hhHouseholdRiskAssessment.LoadNMNMemberList();

            DataRow sctemptyRowNMN = dt.NewRow();
            sctemptyRowNMN["hhm_id"] = "-1";
            sctemptyRowNMN["hhm_name"] = "Select one";
            dt.Rows.InsertAt(sctemptyRowNMN, 0);

            cboNMNList.DataSource = dt;
            cboNMNList.DisplayMember = "hhm_name";
            cboNMNList.ValueMember = "hhm_id";

            cboNMNList.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboNMNList.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion

        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        protected void Back()
        {
            FormCalling.Back();
        }

        public void EnableDisableNMNLists(bool isNMNRecord)
        {
            if (isNMNRecord == true)
            {
                cboHouseholdMember.SelectedValue = "-1";
                cboHouseholdMember.Enabled = false;
                cboNMNList.Enabled = true;
            }
            else
            {
                cboHouseholdMember.Enabled = true;
                cboNMNList.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            if(cboNMNList.Enabled == true)
            {
                hhHouseholdRiskAssessment.hhm_name = cboNMNList.Text;
            }
            else
            {
                hhHouseholdRiskAssessment.hhm_name = cboHouseholdMember.Text;
            }

            hhHouseholdRiskAssessment.ra_criteria_id = cboCriteria.SelectedValue.ToString();
            hhHouseholdRiskAssessment.yn_mother_hiv_pos = utilControls.RadioButtonGetSelection(rbtn_yn_mother_hiv_pos_Yes, rbtn_yn_mother_hiv_pos_No);
            hhHouseholdRiskAssessment.yn_lost_bio_parent = utilControls.RadioButtonGetSelection(rbtn_yn_lost_bio_parent_Yes, rbtn_yn_lost_bio_parent_No);
            hhHouseholdRiskAssessment.yn_malnourished = utilControls.RadioButtonGetSelection(rbtn_yn_malnourished_Yes, rbtn_yn_malnourished_No);
            hhHouseholdRiskAssessment.yn_skin_problem = utilControls.RadioButtonGetSelection(rbtn_yn_skin_problem_Yes, rbtn_yn_skin_problem_No);
            hhHouseholdRiskAssessment.yn_hospitalized = utilControls.RadioButtonGetSelection(rbtn_yn_hospitalized_Yes, rbtn_yn_hospitalized_No);
            hhHouseholdRiskAssessment.yn_sexual_violence_exposed = utilControls.RadioButtonGetSelection(rbtn_yn_sexual_violence_exposed_Yes, rbtn_yn_sexual_violence_exposed_No);
            hhHouseholdRiskAssessment.yn_acc_exposure_sharp_injury = utilControls.RadioButtonGetSelection(rbtn_yn_acc_exposure_sharp_injury_Yes, rbtn_yn_acc_exposure_sharp_injury_Yes);
            hhHouseholdRiskAssessment.yn_drug_abuse = utilControls.RadioButtonGetSelection(rbtn_yn_drug_abuse_Yes, rbtn_yn_drug_abuse_No);
            hhHouseholdRiskAssessment.yn_hhm_at_risk = utilControls.RadioButtonGetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No);
            
            if (rbtn_yn_hmm_test_TR.Checked) { hhHouseholdRiskAssessment.yn_hmm_test = rbtn_yn_hmm_test_TR.Text; }
            else if (rbtn_yn_hmm_test_TNR.Checked) { hhHouseholdRiskAssessment.yn_hmm_test = rbtn_yn_hmm_test_TNR.Text; }

            hhHouseholdRiskAssessment.yn_hhm_accept_test = utilControls.RadioButtonGetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA);
            hhHouseholdRiskAssessment.yn_referal = utilControls.RadioButtonGetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA);
            hhHouseholdRiskAssessment.yn_referal_completed = utilControls.RadioButtonGetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA);

            #region HIV status
            if (test_result_pos.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTPositive; }
            else if (test_result_neg.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTNegative; }
            else if (test_result_unknown.Checked) { hhHouseholdRiskAssessment.test_result = utilConstants.cHSTUnKnown; }
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

                if (cboNMNList.Enabled == true)
                {
                    hhHouseholdRiskAssessment.hhm_id = cboNMNList.SelectedValue.ToString();
                }
                else
                {
                    hhHouseholdRiskAssessment.hhm_id = cboHouseholdMember.SelectedValue.ToString();
                }

                hhHouseholdRiskAssessment.ram_id = Guid.NewGuid().ToString();
                hhHouseholdRiskAssessment.save_hh_household_risk_assessment_member_child("save");
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

                hhHouseholdRiskAssessment.save_hh_household_risk_assessment_member_child("update");
                MessageBox.Show("update successful", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                LoadMembers();
                LoadDisplayLine(hhHouseholdRiskAssessment.ra_id);
            }

            #endregion set variables
        }
        #endregion save


        protected bool ValidateInput()
        {
            bool isValid = false;

            if (hhHouseholdRiskAssessment.ram_id == string.Empty)
            {
                if (rbtnNoMeansNoYes.Checked)
                {
                    if (cboNMNList.SelectedValue.ToString() == "-1" || cboCriteria.SelectedValue.ToString() == "-1" || (!rbtn_yn_mother_hiv_pos_Yes.Checked & !rbtn_yn_mother_hiv_pos_No.Checked) ||
              (!rbtn_yn_lost_bio_parent_Yes.Checked & !rbtn_yn_lost_bio_parent_No.Checked) ||
              (!rbtn_yn_malnourished_Yes.Checked & !rbtn_yn_malnourished_No.Checked) ||
              (!rbtn_yn_skin_problem_Yes.Checked & !rbtn_yn_skin_problem_No.Checked) ||
              (!rbtn_yn_hospitalized_Yes.Checked & !rbtn_yn_hospitalized_No.Checked) ||
              (!rbtn_yn_sexual_violence_exposed_Yes.Checked & !rbtn_yn_sexual_violence_exposed_No.Checked) ||
              (!rbtn_yn_acc_exposure_sharp_injury_Yes.Checked & !rbtn_yn_acc_exposure_sharp_injury_No.Checked) ||
              (!rbtn_yn_drug_abuse_Yes.Checked & !rbtn_yn_drug_abuse_No.Checked) ||
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
                    if (cboHouseholdMember.SelectedValue.ToString() == "-1" || cboCriteria.SelectedValue.ToString() == "-1" || (!rbtn_yn_mother_hiv_pos_Yes.Checked & !rbtn_yn_mother_hiv_pos_No.Checked) ||
              (!rbtn_yn_lost_bio_parent_Yes.Checked & !rbtn_yn_lost_bio_parent_No.Checked) ||
              (!rbtn_yn_malnourished_Yes.Checked & !rbtn_yn_malnourished_No.Checked) ||
              (!rbtn_yn_skin_problem_Yes.Checked & !rbtn_yn_skin_problem_No.Checked) ||
              (!rbtn_yn_hospitalized_Yes.Checked & !rbtn_yn_hospitalized_No.Checked) ||
              (!rbtn_yn_sexual_violence_exposed_Yes.Checked & !rbtn_yn_sexual_violence_exposed_No.Checked) ||
              (!rbtn_yn_acc_exposure_sharp_injury_Yes.Checked & !rbtn_yn_acc_exposure_sharp_injury_No.Checked) ||
              (!rbtn_yn_drug_abuse_Yes.Checked & !rbtn_yn_drug_abuse_No.Checked) ||
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

               
            }
            else
            {
                if (rbtnNoMeansNoYes.Checked)
                {
                    if (cboCriteria.SelectedValue.ToString() == "-1" || (!rbtn_yn_mother_hiv_pos_Yes.Checked & !rbtn_yn_mother_hiv_pos_No.Checked) ||
            (!rbtn_yn_lost_bio_parent_Yes.Checked & !rbtn_yn_lost_bio_parent_No.Checked) ||
            (!rbtn_yn_malnourished_Yes.Checked & !rbtn_yn_malnourished_No.Checked) ||
            (!rbtn_yn_skin_problem_Yes.Checked & !rbtn_yn_skin_problem_No.Checked) ||
            (!rbtn_yn_hospitalized_Yes.Checked & !rbtn_yn_hospitalized_No.Checked) ||
            (!rbtn_yn_sexual_violence_exposed_Yes.Checked & !rbtn_yn_sexual_violence_exposed_No.Checked) ||
            (!rbtn_yn_acc_exposure_sharp_injury_Yes.Checked & !rbtn_yn_acc_exposure_sharp_injury_No.Checked) ||
            (!rbtn_yn_drug_abuse_Yes.Checked & !rbtn_yn_drug_abuse_No.Checked) ||
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
                    if (cboCriteria.SelectedValue.ToString() == "-1" || (!rbtn_yn_mother_hiv_pos_Yes.Checked & !rbtn_yn_mother_hiv_pos_No.Checked) ||
            (!rbtn_yn_lost_bio_parent_Yes.Checked & !rbtn_yn_lost_bio_parent_No.Checked) ||
            (!rbtn_yn_malnourished_Yes.Checked & !rbtn_yn_malnourished_No.Checked) ||
            (!rbtn_yn_skin_problem_Yes.Checked & !rbtn_yn_skin_problem_No.Checked) ||
            (!rbtn_yn_hospitalized_Yes.Checked & !rbtn_yn_hospitalized_No.Checked) ||
            (!rbtn_yn_sexual_violence_exposed_Yes.Checked & !rbtn_yn_sexual_violence_exposed_No.Checked) ||
            (!rbtn_yn_acc_exposure_sharp_injury_Yes.Checked & !rbtn_yn_acc_exposure_sharp_injury_No.Checked) ||
            (!rbtn_yn_drug_abuse_Yes.Checked & !rbtn_yn_drug_abuse_No.Checked) ||
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
             
            }
           

            return isValid;
        }

        protected void AutoCheckRisk()
        {
            if (rbtn_yn_mother_hiv_pos_Yes.Checked || rbtn_yn_lost_bio_parent_Yes.Checked || rbtn_yn_malnourished_Yes.Checked || rbtn_yn_skin_problem_Yes.Checked || rbtn_yn_hospitalized_Yes.Checked ||
                rbtn_yn_sexual_violence_exposed_Yes.Checked || rbtn_yn_acc_exposure_sharp_injury_Yes.Checked || rbtn_yn_drug_abuse_Yes.Checked)
            {
                rbtn_yn_hhm_at_risk_Yes.Checked = true;
            }
            else
            {
                rbtn_yn_hhm_at_risk_No.Checked = true;
            }
        }


        protected void LoadDisplay(string ram_id)
        {
            dt = hhHouseholdRiskAssessment.LoadRATDetails(ram_id, "child");
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboHouseholdMember.Text = dtRow["hhm_name"].ToString();
                cboCriteria.SelectedValue = dtRow["ra_criteria_id"].ToString();
                hhHouseholdRiskAssessment.hhm_id = dtRow["hhm_id"].ToString();
                hhHouseholdRiskAssessment.ram_id = dtRow["ram_id"].ToString();

                utilControls.RadioButtonSetSelection(rbtn_yn_mother_hiv_pos_Yes, rbtn_yn_mother_hiv_pos_No, dtRow["yn_mother_hiv_pos"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_lost_bio_parent_Yes, rbtn_yn_lost_bio_parent_No, dtRow["yn_lost_bio_parent"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_malnourished_Yes, rbtn_yn_malnourished_No, dtRow["yn_malnourished"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_skin_problem_Yes, rbtn_yn_skin_problem_No, dtRow["yn_skin_problem"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_hospitalized_Yes, rbtn_yn_hospitalized_No, dtRow["yn_hospitalized"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_exposed_Yes, rbtn_yn_sexual_violence_exposed_No, dtRow["yn_sexual_violence_exposed"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_acc_exposure_sharp_injury_Yes, rbtn_yn_acc_exposure_sharp_injury_Yes, dtRow["yn_acc_exposure_sharp_injury"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_drug_abuse_Yes, rbtn_yn_drug_abuse_No, dtRow["yn_drug_abuse"].ToString());
                //utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, dtRow["yn_hhm_at_risk"].ToString());

                if (dtRow["yn_hmm_test"].ToString() == "TR") { rbtn_yn_hmm_test_TR.Checked = true; }
                else if (dtRow["yn_hmm_test"].ToString() == "TNR") { rbtn_yn_hmm_test_TNR.Checked = true; }

                utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, dtRow["yn_hhm_accept_test"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, dtRow["yn_referal"].ToString());
                utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, dtRow["yn_referal_completed"].ToString());

                #region HIV status
                if (dtRow["test_result"].ToString() == utilConstants.cHSTPositive) { test_result_pos.Checked = true; }
                else if (dtRow["test_result"].ToString() == utilConstants.cHSTNegative) { test_result_neg.Checked = true; }
                else if (dtRow["test_result"].ToString() == utilConstants.cHSTUnKnown) { test_result_unknown.Checked = true; }
                #endregion HIV status
            }
        }

        protected void LoadDisplayLine(string ra_id)
        {
            dt = hhHouseholdRiskAssessment.ReturnDisplayLine(ra_id, "child");
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

        protected void Clear()
        {
            cboHouseholdMember.SelectedValue = "-1";
            cboCriteria.SelectedValue = "-1";

            utilControls.RadioButtonSetSelection(rbtn_yn_mother_hiv_pos_Yes, rbtn_yn_mother_hiv_pos_No,string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_lost_bio_parent_Yes, rbtn_yn_lost_bio_parent_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_malnourished_Yes, rbtn_yn_malnourished_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_skin_problem_Yes, rbtn_yn_skin_problem_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hospitalized_Yes, rbtn_yn_hospitalized_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_exposed_Yes, rbtn_yn_sexual_violence_exposed_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_acc_exposure_sharp_injury_Yes, rbtn_yn_acc_exposure_sharp_injury_Yes, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_drug_abuse_Yes, rbtn_yn_drug_abuse_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);

            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);
            rbtn_yn_hmm_test_TR.Checked = false;
            rbtn_yn_hmm_test_TNR.Checked = false;
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, string.Empty);
            test_result_pos.Checked = false;
            test_result_neg.Checked = false;
            test_result_unknown.Checked = false;

            hhHouseholdRiskAssessment.ram_id = string.Empty;
        }

        protected void ClearPanel()
        {
            utilControls.RadioButtonSetSelection(rbtn_yn_mother_hiv_pos_Yes, rbtn_yn_mother_hiv_pos_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_lost_bio_parent_Yes, rbtn_yn_lost_bio_parent_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_malnourished_Yes, rbtn_yn_malnourished_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_skin_problem_Yes, rbtn_yn_skin_problem_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hospitalized_Yes, rbtn_yn_hospitalized_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_sexual_violence_exposed_Yes, rbtn_yn_sexual_violence_exposed_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_acc_exposure_sharp_injury_Yes, rbtn_yn_acc_exposure_sharp_injury_Yes, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_drug_abuse_Yes, rbtn_yn_drug_abuse_No, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);

            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_at_risk_Yes, rbtn_yn_hhm_at_risk_No, string.Empty);
            rbtn_yn_hmm_test_TR.Checked = false;
            rbtn_yn_hmm_test_TNR.Checked = false;
            utilControls.RadioButtonSetSelection(rbtn_yn_hhm_accept_test_Yes, rbtn_yn_hhm_accept_test_No, rbtn_yn_hhm_accept_test_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_Yes, rbtn_yn_referal_No, rbtn_yn_referal_NA, string.Empty);
            utilControls.RadioButtonSetSelection(rbtn_yn_referal_completed_Yes, rbtn_yn_referal_completed_No, rbtn_yn_referal_completed_NA, string.Empty);
            test_result_pos.Checked = false;
            test_result_neg.Checked = false;
            test_result_unknown.Checked = false;

            hhHouseholdRiskAssessment.ram_id = string.Empty;
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

        private void rbtn_yn_mother_hiv_pos_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_mother_hiv_pos_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_lost_bio_parent_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_lost_bio_parent_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_malnourished_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_malnourished_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_skin_problem_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_skin_problem_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hospitalized_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_hospitalized_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sexual_violence_exposed_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_sexual_violence_exposed_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_acc_exposure_sharp_injury_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_acc_exposure_sharp_injury_No_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_drug_abuse_Yes_CheckedChanged(object sender, EventArgs e)
        {
            AutoCheckRisk();
        }

        private void rbtn_yn_drug_abuse_No_CheckedChanged(object sender, EventArgs e)
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
            rbtn_yn_hmm_test_TR_CheckedChanged(rbtn_yn_hmm_test_TR, null);
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void rbtnNoMeansNoYes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnNoMeansNoYes.Checked == true)
            {
                cboHouseholdMember.Enabled = false;
                cboHouseholdMember.SelectedValue = "-1";
                cboNMNList.Enabled = true;
            }
            else
            {
                cboHouseholdMember.Enabled = true;
                cboNMNList.Enabled = false;
                cboNMNList.SelectedValue = "-1";
            }
        }

        private void rbtnNoMeansNoNo_CheckedChanged(object sender, EventArgs e)
        {
            rbtnNoMeansNoYes_CheckedChanged(rbtnNoMeansNoYes,null);
        }
    }
}
