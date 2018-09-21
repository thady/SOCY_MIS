using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;
using PSAUtils;
using PSAUtilsWin32;

namespace SOCY_MIS
{
    public partial class frm_hh_household_risk_assessment_register : Form
    {
        DataTable dt = null;
        public frm_hh_household_risk_assessment_register()
        {
            InitializeComponent();
        }

        private void frm_hh_household_risk_assessment_register_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Return_lookups();
            display_hh_details();
            Return_household_members();
            Return_HH_ras_visits();
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

        protected void Return_household_members()
        {
            dt = hhHousehold_linkages_register.Return_household_member_details(SystemConstants.hh_record_guid);
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["hhm_id"] = "-1";
                emptyRow["Name"] = "select household member";
                dt.Rows.InsertAt(emptyRow, 0);

                cboPersonInterviewed.DataSource = dt;
                cboPersonInterviewed.ValueMember = "hhm_id";
                cboPersonInterviewed.DisplayMember = "Name";
            }

            dt = hhHousehold_linkages_register.Return_household_member_details(SystemConstants.hh_record_guid);
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["hhm_id"] = "-1";
                emptyRow["Name"] = "select household member";
                dt.Rows.InsertAt(emptyRow, 0);

                cboBeneficiaryName.DataSource = dt;
                cboBeneficiaryName.ValueMember = "hhm_id";
                cboBeneficiaryName.DisplayMember = "Name";
            }
        }

        //get household risk assessment visits
        protected void Return_HH_ras_visits()
        {
            DataTable dt = hh_household_risk_assessment_header.Return_risk_assessments_by_hh_id(SystemConstants.hh_record_guid);
            if (dt.Rows.Count > 0)
            {
                gdv_ras_header.DataSource = dt;

                gdv_ras_header.Columns["date_of_visit"].HeaderText = "Date of Visit";
                gdv_ras_header.Columns["hh_code"].HeaderText = "Household Code";
                gdv_ras_header.Columns["hhm_name"].HeaderText = "HH Member Interviewed";

                gdv_ras_header.Columns["ras_id"].Visible = false;
                gdv_ras_header.Columns["ofc_id"].Visible = false;

                gdv_ras_header.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_ras_header.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_ras_header.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_ras_header.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_ras_header.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_ras_header.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_ras_header.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_ras_header.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_ras_header.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_ras_header.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdv_ras_header.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdv_ras_header.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_update_ras_record();
        }

        protected void save_update_ras_record()
        {
            if (dtTimeVisistDate.Checked = false || cboPersonInterviewed.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Fields marked with (*) are required", "SOCY MIS Message centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblras_id.Text == "lblras_id")
                {

                    hh_household_risk_assessment_header.ras_id = Guid.NewGuid().ToString();
                    hh_household_risk_assessment_header.hh_code = txtHHCode.Text;
                    hh_household_risk_assessment_header.hh_id = SystemConstants.hh_record_guid;
                    hh_household_risk_assessment_header.interviewed_member_id = cboPersonInterviewed.SelectedValue.ToString();
                    hh_household_risk_assessment_header.date_of_visit = dtTimeVisistDate.Value.Date;
                    hh_household_risk_assessment_header.usr_id_create = hhHousehold_linkages_register.user_id; //reused
                    hh_household_risk_assessment_header.usr_date_create = DateTime.Today;
                    hh_household_risk_assessment_header.usr_id_update = hhHousehold_linkages_register.user_id; //reused
                    hh_household_risk_assessment_header.ofc_id = SystemConstants.ofc_id;
                    hh_household_risk_assessment_header.district_id = SystemConstants.Return_office_district();

                    lblras_id.Text = hh_household_risk_assessment_header.save_update_hhm_risk_assessment_details("insert");
                    MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    hh_household_risk_assessment_header.ras_id = lblras_id.Text;
                    hh_household_risk_assessment_header.interviewed_member_id = cboPersonInterviewed.SelectedValue.ToString();
                    hh_household_risk_assessment_header.date_of_visit = dtTimeVisistDate.Value.Date;
                    hh_household_risk_assessment_header.usr_id_update = hhHousehold_linkages_register.user_id; //reused
                    hh_household_risk_assessment_header.usr_date_update = DateTime.Today;

                    string update_record = hh_household_risk_assessment_header.save_update_hhm_risk_assessment_details("update");
                    MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnsave_members_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                save_update_rasm_record();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cboBeneficiaryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            return_beneficiary_code(cboBeneficiaryName.SelectedValue.ToString());

            #region hhm ras details

            Return_hhm_ras_details(cboBeneficiaryName.SelectedValue.ToString(), lblras_id.Text);

            #endregion hhm ras details
        }

        //return hh member ras details
        protected void Return_hhm_ras_details(string hhm_id, string ras_id)
        {
            DataTable dt = hh_household_risk_assessment_beneficiaries.Return_hhm_ras_details(hhm_id, ras_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                #region HIV Status
                string hiv_status = dtRow["current_hiv_status_id"].ToString();
                switch (hiv_status)
                {
                    case "1":
                        rbtnHIVstatusNEG.Checked = false;
                        rbtnHIVstatusPos.Checked = true;
                        rbtnHIVstatusUnknown.Checked = false;
                        break;
                    case "2":
                        rbtnHIVstatusNEG.Checked = true;
                        rbtnHIVstatusPos.Checked = false;
                        rbtnHIVstatusUnknown.Checked = false;
                        break;
                    case "3":
                        rbtnHIVstatusNEG.Checked = false;
                        rbtnHIVstatusPos.Checked = false;
                        rbtnHIVstatusUnknown.Checked = true;
                        break;
                    default:
                        rbtnHIVstatusNEG.Checked = false;
                        rbtnHIVstatusPos.Checked = false;
                        rbtnHIVstatusPos.Checked = false;
                        break;
                }
                #endregion HIV Status

                #region HIV Status Test result
                string hiv_statusTestResult = dtRow["test_result"].ToString();
                switch (hiv_statusTestResult)
                {
                    case "1":
                        rbtnTestResultNegative.Checked = false;
                        rbtnTestResultPositive.Checked = true;
                        rbtnTestResultNotDisclosed.Checked = false;
                        break;
                    case "2":
                        rbtnTestResultNegative.Checked = true;
                        rbtnTestResultPositive.Checked = false;
                        rbtnTestResultNotDisclosed.Checked = false;
                        break;
                    case "4":
                        rbtnTestResultNegative.Checked = false;
                        rbtnTestResultPositive.Checked = false;
                        rbtnTestResultNotDisclosed.Checked = true;
                        break;
                    default:
                        rbtnTestResultNegative.Checked = false;
                        rbtnTestResultPositive.Checked = false;
                        rbtnTestResultNotDisclosed.Checked = false;
                        break;
                }
                #endregion HIV Status Test result

                utilControls.RadioButtonSetSelection(rbtnArtYes, rbtnArtNo, dtRow["is_on_art"].ToString());
                utilControls.RadioButtonSetSelection(rbtnHospitalYes, rbtnHospitalNo, dtRow["screen_hospital_last_six_months"].ToString());
                utilControls.RadioButtonSetSelection(rbtnParentsDeceasedYes, rbtnParentsDeceasedNo, dtRow["screen_either_parents_deceased"].ToString());
                utilControls.RadioButtonSetSelection(rbtnSiblingsDeceasedYes, rbtnSiblingsDeceasedNo, dtRow["screen_either_siblings_deceased"].ToString());
                utilControls.RadioButtonSetSelection(rbtnPoorHealthYes, rbtnPoorHealthNo, dtRow["screen_poor_health_last_three_months"].ToString());
                utilControls.RadioButtonSetSelection(rbtnAdultOrChildwithHIVorTBYes, rbtnAdultOrChildwithHIVorTBNo, dtRow["screen_adult_child_with_hiv_or_tb"].ToString());
                utilControls.RadioButtonSetSelection(rbtnBelowExpectedGradeYes, rbtnBelowExpectedGradeNo, dtRow["screen_below_relative_grade"].ToString());
                utilControls.RadioButtonSetSelection(rbtnChildEligibleForTestYes, rbtnChildEligibleForTestNo, rbtnChildEligibleForTestNA, dtRow["child_eligible_for_test_refferal"].ToString());
                utilControls.RadioButtonSetSelection(rbtnCaregiverAcceptedChildTestYes, rbtnCaregiverAcceptedChildTestNo, rbtnCaregiverAcceptedChildTestNA, dtRow["care_giver_accepted_to_test_child"].ToString());

                lblrasm_id.Text = dtRow["rasm_id"].ToString();
            }
            else
            {
                reset_defaults();
            }
        }

        #region Reset defaults
        protected void reset_defaults()
        {
            rbtnHIVstatusPos.Checked = false;
            rbtnHIVstatusNEG.Checked = false;
            rbtnHIVstatusUnknown.Checked = false;
            rbtnArtYes.Checked = false;
            rbtnArtNo.Checked = false;
            rbtnHospitalYes.Checked = false;
            rbtnHospitalNo.Checked = false;
            rbtnParentsDeceasedYes.Checked = false;
            rbtnParentsDeceasedNo.Checked = false;
            rbtnSiblingsDeceasedYes.Checked = false;
            rbtnSiblingsDeceasedNo.Checked = false;
            rbtnPoorHealthYes.Checked = false;
            rbtnPoorHealthNo.Checked = false;
            rbtnAdultOrChildwithHIVorTBYes.Checked = false;
            rbtnAdultOrChildwithHIVorTBNo.Checked = false;
            rbtnBelowExpectedGradeYes.Checked = false;
            rbtnBelowExpectedGradeNo.Checked = false;
            rbtnChildEligibleForTestYes.Checked = false;
            rbtnChildEligibleForTestNo.Checked = false;
            rbtnChildEligibleForTestNA.Checked = false;
            rbtnCaregiverAcceptedChildTestYes.Checked = false;
            rbtnCaregiverAcceptedChildTestNo.Checked = false;
            rbtnCaregiverAcceptedChildTestNA.Checked = false;
            rbtnTestResultPositive.Checked = false;
            rbtnTestResultNegative.Checked = false;
            rbtnTestResultNotDisclosed.Checked = false;
            panelArt.Enabled = true;
            tlpDisplay03.Enabled = true;
            tlpDisplay04.Enabled = true;
            lblrasm_id.Text = "lblrasm_id";
            lblArt.ForeColor = Color.Black;
            panelArt.ForeColor = Color.Black;
        }

        #endregion Reset defaults

        protected void return_beneficiary_code(string hhm_id)
        {
            DataTable dt = hh_household_risk_assessment_beneficiaries.Return_hhm_details(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txt_beneficiary_code.Text = dtRow["hhm_code"].ToString() != string.Empty ? dtRow["hhm_code"].ToString() : string.Empty;

                #region birth year
                int birth_year = dtRow["hhm_year_of_birth"] != DBNull.Value ? Convert.ToInt32(dtRow["hhm_year_of_birth"]) : -1;
                if (birth_year.ToString() != string.Empty && birth_year != -1)
                {
                    int age = (DateTime.Today.Year) - birth_year;
                    txtBeneficiaryAge.Text = age.ToString();
                }
                else { txtBeneficiaryAge.Text = string.Empty; }
                #endregion birth year

                #region gender
                string gender = dtRow["gnd_name"].ToString();
                if (gender == "Male") { rbtngenderMale.Checked = true; }
                else if(gender == "Female") { rbtngenderFemale.Checked = true; }
                #endregion gender


            }
        }

        #region save risk assessment member details
        protected void save_update_rasm_record()
        {
            if (lblras_id.Text == "lblras_id")
            {
                MessageBox.Show("Please select a household risk assessment record to save details for this member", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboBeneficiaryName.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Household member is required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rbtnHIVstatusPos.Checked == false && rbtnHIVstatusNEG.Checked == false && rbtnHIVstatusUnknown.Checked == false)
            {
                MessageBox.Show("HIV status is required", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lblrasm_id.Text == "lblrasm_id")
                {
                    hh_household_risk_assessment_beneficiaries.ras_id = lblras_id.Text;
                    hh_household_risk_assessment_beneficiaries.rasm_id = Guid.NewGuid().ToString();
                    hh_household_risk_assessment_beneficiaries.hh_member_id = cboBeneficiaryName.SelectedValue.ToString();
                    hh_household_risk_assessment_beneficiaries.hh_member_code = txt_beneficiary_code.Text;

                    #region HIV Status
                    if (rbtnHIVstatusPos.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTPositive;
                    else if (rbtnHIVstatusNEG.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTNegative;
                    else if (rbtnHIVstatusUnknown.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTUnKnown;
                    else
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cDFEmptyListValue;
                    #endregion HIV Status

                    #region HIV Status Test Result
                    if (rbtnTestResultPositive.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTPositive;
                    else if (rbtnTestResultNegative.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTNegative;
                    else if (rbtnTestResultNotDisclosed.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTUnDisclosed;
                    else
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cDFEmptyListValue;
                    #endregion HIV Status Test Result

                    hh_household_risk_assessment_beneficiaries.is_on_art = utilControls.RadioButtonGetSelection(rbtnArtYes, rbtnArtNo);
                    hh_household_risk_assessment_beneficiaries.screen_hospital_last_six_months = utilControls.RadioButtonGetSelection(rbtnHospitalYes, rbtnHospitalNo);
                    hh_household_risk_assessment_beneficiaries.screen_either_parents_deceased = utilControls.RadioButtonGetSelection(rbtnParentsDeceasedYes, rbtnParentsDeceasedNo);
                    hh_household_risk_assessment_beneficiaries.screen_either_siblings_deceased = utilControls.RadioButtonGetSelection(rbtnSiblingsDeceasedYes, rbtnSiblingsDeceasedNo);
                    hh_household_risk_assessment_beneficiaries.screen_poor_health_last_three_months = utilControls.RadioButtonGetSelection(rbtnPoorHealthYes, rbtnPoorHealthNo);
                    hh_household_risk_assessment_beneficiaries.screen_adult_child_with_hiv_or_tb = utilControls.RadioButtonGetSelection(rbtnAdultOrChildwithHIVorTBYes, rbtnAdultOrChildwithHIVorTBNo);
                    hh_household_risk_assessment_beneficiaries.screen_below_relative_grade = utilControls.RadioButtonGetSelection(rbtnBelowExpectedGradeYes, rbtnBelowExpectedGradeNo);
                    hh_household_risk_assessment_beneficiaries.child_eligible_for_test_refferal = utilControls.RadioButtonGetSelection(rbtnChildEligibleForTestYes, rbtnChildEligibleForTestNo, rbtnChildEligibleForTestNA);
                    hh_household_risk_assessment_beneficiaries.care_giver_accepted_to_test_child = utilControls.RadioButtonGetSelection(rbtnCaregiverAcceptedChildTestYes, rbtnCaregiverAcceptedChildTestNo, rbtnCaregiverAcceptedChildTestNA);
                    hh_household_risk_assessment_beneficiaries.usr_id_create = SystemConstants.user_id;
                    hh_household_risk_assessment_beneficiaries.usr_id_update = SystemConstants.user_id;
                    hh_household_risk_assessment_beneficiaries.usr_date_create = DateTime.Today;
                    hh_household_risk_assessment_beneficiaries.usr_date_update = DateTime.Today;
                    hh_household_risk_assessment_beneficiaries.ofc_id = SystemConstants.ofc_id;
                    hh_household_risk_assessment_beneficiaries.district_id = SystemConstants.Return_office_district();

                    hh_household_risk_assessment_beneficiaries.save_update_hhm_risk_assessment_details_member("insert");
                    MessageBox.Show("Successfully created record", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    hh_household_risk_assessment_beneficiaries.rasm_id = lblrasm_id.Text;
                    hh_household_risk_assessment_beneficiaries.hh_member_id = cboBeneficiaryName.SelectedValue.ToString();
                    hh_household_risk_assessment_beneficiaries.hh_member_code = txt_beneficiary_code.Text;

                    #region HIV Status
                    if (rbtnHIVstatusPos.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTPositive;
                    else if (rbtnHIVstatusNEG.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTNegative;
                    else if (rbtnHIVstatusUnknown.Checked)
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cHSTUnKnown;
                    else
                        hh_household_risk_assessment_beneficiaries.current_hiv_status_id = utilConstants.cDFEmptyListValue;
                    #endregion HIV Status

                    #region HIV Status Test Result
                    if (rbtnTestResultPositive.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTPositive;
                    else if (rbtnTestResultNegative.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTNegative;
                    else if (rbtnTestResultNotDisclosed.Checked)
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cHSTUnDisclosed;
                    else
                        hh_household_risk_assessment_beneficiaries.test_result = utilConstants.cDFEmptyListValue;
                    #endregion HIV Status Test Result

                    hh_household_risk_assessment_beneficiaries.is_on_art = utilControls.RadioButtonGetSelection(rbtnArtYes, rbtnArtNo);
                    hh_household_risk_assessment_beneficiaries.screen_hospital_last_six_months = utilControls.RadioButtonGetSelection(rbtnHospitalYes, rbtnHospitalNo);
                    hh_household_risk_assessment_beneficiaries.screen_either_parents_deceased = utilControls.RadioButtonGetSelection(rbtnParentsDeceasedYes, rbtnParentsDeceasedNo);
                    hh_household_risk_assessment_beneficiaries.screen_either_siblings_deceased = utilControls.RadioButtonGetSelection(rbtnSiblingsDeceasedYes, rbtnSiblingsDeceasedNo);
                    hh_household_risk_assessment_beneficiaries.screen_poor_health_last_three_months = utilControls.RadioButtonGetSelection(rbtnPoorHealthYes, rbtnPoorHealthNo);
                    hh_household_risk_assessment_beneficiaries.screen_adult_child_with_hiv_or_tb = utilControls.RadioButtonGetSelection(rbtnAdultOrChildwithHIVorTBYes, rbtnAdultOrChildwithHIVorTBNo);
                    hh_household_risk_assessment_beneficiaries.screen_below_relative_grade = utilControls.RadioButtonGetSelection(rbtnBelowExpectedGradeYes, rbtnBelowExpectedGradeNo);
                    hh_household_risk_assessment_beneficiaries.child_eligible_for_test_refferal = utilControls.RadioButtonGetSelection(rbtnChildEligibleForTestYes, rbtnChildEligibleForTestNo, rbtnChildEligibleForTestNA);
                    hh_household_risk_assessment_beneficiaries.care_giver_accepted_to_test_child = utilControls.RadioButtonGetSelection(rbtnCaregiverAcceptedChildTestYes, rbtnCaregiverAcceptedChildTestNo, rbtnCaregiverAcceptedChildTestNA);
                    hh_household_risk_assessment_beneficiaries.usr_id_update = SystemConstants.user_id;

                    hh_household_risk_assessment_beneficiaries.save_update_hhm_risk_assessment_details_member("update");
                    MessageBox.Show("Successfully updated record", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
        #endregion save risk assessment member details

        private void gdv_ras_header_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv_ras_header.Rows.Count > 0)
            {
                dtTimeVisistDate.Value = Convert.ToDateTime(gdv_ras_header.CurrentRow.Cells[0].Value.ToString());
                lblras_id.Text = gdv_ras_header.CurrentRow.Cells[3].Value.ToString();
                cboPersonInterviewed.Text = gdv_ras_header.CurrentRow.Cells[2].Value.ToString();
                string ofc_id = gdv_ras_header.CurrentRow.Cells[4].Value.ToString();

                cboPersonInterviewed.Enabled = false;
                dtTimeVisistDate.Enabled = false;
                btnsave.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                btnsave_members.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));

                return_assessment_members(gdv_ras_header.CurrentRow.Cells[3].Value.ToString());

            }
        }


        #region assessment member list
        protected void return_assessment_members(string ras_id)
        {
            DataTable dt = hh_household_risk_assessment_beneficiaries.Return_hhm_ras_member_list(ras_id);
            if (dt.Rows.Count > 0)
            {
                gdv_ras_members.DataSource = dt;

                gdv_ras_members.Columns["hh_member_id"].Visible = false;
                gdv_ras_members.Columns["hhm_name"].HeaderText = "Household Member Name";

                gdv_ras_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_ras_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_ras_members.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_ras_members.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_ras_members.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_ras_members.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_ras_members.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_ras_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_ras_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_ras_members.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdv_ras_members.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdv_ras_members.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }
        #endregion assessment member list


        #region control Enabling
        protected void AlterControlEnable_Disable(RadioButton radHIVPOS,RadioButton radHIVNEG,RadioButton radHIVUnknown)
        {
            if (radHIVPOS.Checked == true)
            {
                panelArt.Enabled = true;
                lblArt.ForeColor = Color.Red;
                panelArt.ForeColor = Color.Red;

                tlpDisplay03.Enabled = false;
                tlpDisplay04.Enabled = false;

                tlpDisplay03.ForeColor = Color.Black;
                tlpDisplay04.ForeColor = Color.Black;

                lblrequire01.Visible = false;
                lblrequire01.ForeColor = Color.Red;
                lblrequire02.Visible = false;
                lblrequire02.ForeColor = Color.Red;
                lblrequire03.Visible = false;
                lblrequire03.ForeColor = Color.Red;
                lblrequire04.Visible = false;
                lblrequire04.ForeColor = Color.Red;
                lblrequire05.Visible = false;
                lblrequire05.ForeColor = Color.Red;
                lblrequire06.Visible = false;
                lblrequire06.ForeColor = Color.Red;
                lblrequire07.Visible = false;
                lblrequire07.ForeColor = Color.Red;
                lblrequire08.Visible = false;
                lblrequire08.ForeColor = Color.Red;
                lblrequire09.Visible = false;
                lblrequire09.ForeColor = Color.Red;
            }
            else if (radHIVNEG.Checked == true)
            {
                panelArt.Enabled = false;
                lblArt.ForeColor = Color.Black;
                panelArt.ForeColor = Color.Black;
                tlpDisplay03.Enabled = false;
                tlpDisplay04.Enabled = false;

                tlpDisplay03.ForeColor = Color.Black;
                tlpDisplay04.ForeColor = Color.Black;

                rbtnHospitalYes.Checked = false;
                rbtnHospitalNo.Checked = false;
                rbtnParentsDeceasedYes.Checked = false;
                rbtnParentsDeceasedNo.Checked = false;
                rbtnSiblingsDeceasedYes.Checked = false;
                rbtnSiblingsDeceasedNo.Checked = false;
                rbtnPoorHealthYes.Checked = false;
                rbtnPoorHealthNo.Checked = false;
                rbtnAdultOrChildwithHIVorTBYes.Checked = false;
                rbtnAdultOrChildwithHIVorTBNo.Checked = false;
                rbtnBelowExpectedGradeYes.Checked = false;
                rbtnBelowExpectedGradeNo.Checked = false;
                rbtnChildEligibleForTestYes.Checked = false;
                rbtnChildEligibleForTestNo.Checked = false;
                rbtnChildEligibleForTestNA.Checked = false;
                rbtnCaregiverAcceptedChildTestYes.Checked = false;
                rbtnCaregiverAcceptedChildTestNo.Checked = false;
                rbtnCaregiverAcceptedChildTestNA.Checked = false;
                rbtnTestResultPositive.Checked = false;
                rbtnTestResultNegative.Checked = false;
                rbtnTestResultNotDisclosed.Checked = false;

                lblrequire01.Visible = false;
                lblrequire01.ForeColor = Color.Red;
                lblrequire02.Visible = false;
                lblrequire02.ForeColor = Color.Red;
                lblrequire03.Visible = false;
                lblrequire03.ForeColor = Color.Red;
                lblrequire04.Visible = false;
                lblrequire04.ForeColor = Color.Red;
                lblrequire05.Visible = false;
                lblrequire05.ForeColor = Color.Red;
                lblrequire06.Visible = false;
                lblrequire06.ForeColor = Color.Red;
                lblrequire07.Visible = false;
                lblrequire07.ForeColor = Color.Red;
                lblrequire08.Visible = false;
                lblrequire08.ForeColor = Color.Red;
                lblrequire09.Visible = false;
                lblrequire09.ForeColor = Color.Red;
            }
            else if (radHIVUnknown.Checked == true)
            {
                panelArt.Enabled = false;
                lblArt.ForeColor = Color.Black;
                panelArt.ForeColor = Color.Black;

                tlpDisplay03.Enabled = true;
                tlpDisplay04.Enabled = true;
                tlpDisplay03.ForeColor = Color.Green;
                tlpDisplay04.ForeColor = Color.Green;

                lblrequire01.Visible = true;
                lblrequire01.ForeColor = Color.Red;
                lblrequire02.Visible = true;
                lblrequire02.ForeColor = Color.Red;
                lblrequire03.Visible = true;
                lblrequire03.ForeColor = Color.Red;
                lblrequire04.Visible = true;
                lblrequire04.ForeColor = Color.Red;
                lblrequire05.Visible = true;
                lblrequire05.ForeColor = Color.Red;
                lblrequire06.Visible = true;
                lblrequire06.ForeColor = Color.Red;
                lblrequire07.Visible = true;
                lblrequire07.ForeColor = Color.Red;
                lblrequire08.Visible = true;
                lblrequire08.ForeColor = Color.Red;
                lblrequire09.Visible = true;
                lblrequire09.ForeColor = Color.Red;
            }
        }

        #endregion control Enabling

        private void rbtnHIVstatusPos_CheckedChanged(object sender, EventArgs e)
        {
            AlterControlEnable_Disable(rbtnHIVstatusPos, rbtnHIVstatusNEG, rbtnHIVstatusUnknown);
            rbtnChildEligibleForTestNA.Checked = true;
        }

        private void rbtnHIVstatusNEG_CheckedChanged(object sender, EventArgs e)
        {
            AlterControlEnable_Disable(rbtnHIVstatusPos, rbtnHIVstatusNEG, rbtnHIVstatusUnknown);
            rbtnChildEligibleForTestNA.Checked = true;
        }

        private void rbtnHIVstatusUnknown_CheckedChanged(object sender, EventArgs e)
        {
            AlterControlEnable_Disable(rbtnHIVstatusPos, rbtnHIVstatusNEG, rbtnHIVstatusUnknown);
            rbtnChildEligibleForTestNA.Checked = true;
            rbtnChildEligibleForTestNA.ForeColor = Color.Red;
            rbtnChildEligibleForTestYes.ForeColor = Color.Black;
            rbtnChildEligibleForTestNo.ForeColor = Color.Black;
        }

        protected void set_child_test_eligibilityYes(RadioButton rad01,RadioButton rad02,RadioButton rad03,RadioButton rad04,RadioButton rad05,RadioButton rad06)
        {
            if (rad01.Checked == true || rad02.Checked == true || rad03.Checked == true || rad04.Checked == true || rad05.Checked == true || rad06.Checked == true)
            {
                rbtnChildEligibleForTestYes.Checked = true;
                rbtnChildEligibleForTestYes.ForeColor = Color.Red;
                rbtnChildEligibleForTestNo.ForeColor = Color.Black;
                rbtnChildEligibleForTestNA.ForeColor = Color.Black;
            }
        }

        protected void set_child_test_eligibilityNo(RadioButton rad01, RadioButton rad02, RadioButton rad03, RadioButton rad04, RadioButton rad05, RadioButton rad06)
        {
            if (rad01.Checked == true && rad02.Checked == true && rad03.Checked == true && rad04.Checked == true && rad05.Checked == true && rad06.Checked == true)
            {
                rbtnChildEligibleForTestNo.Checked = true;
                rbtnChildEligibleForTestNo.ForeColor = Color.Red;
                rbtnChildEligibleForTestYes.ForeColor = Color.Black;
                rbtnChildEligibleForTestNA.ForeColor = Color.Black;
            }
        }

        private void rbtnHospitalYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnSiblingsDeceasedYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnAdultOrChildwithHIVorTBYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnParentsDeceasedYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnPoorHealthYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnBelowExpectedGradeYes_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityYes(rbtnHospitalYes, rbtnSiblingsDeceasedYes, rbtnAdultOrChildwithHIVorTBYes, rbtnParentsDeceasedYes, rbtnPoorHealthYes, rbtnBelowExpectedGradeYes);
        }

        private void rbtnHospitalNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void rbtnSiblingsDeceasedNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void rbtnAdultOrChildwithHIVorTBNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void rbtnParentsDeceasedNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void rbtnPoorHealthNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void rbtnBelowExpectedGradeNo_CheckedChanged(object sender, EventArgs e)
        {
            set_child_test_eligibilityNo(rbtnHospitalNo, rbtnSiblingsDeceasedNo, rbtnAdultOrChildwithHIVorTBNo, rbtnParentsDeceasedNo, rbtnPoorHealthNo, rbtnBelowExpectedGradeNo);
        }

        private void bntnew_Click(object sender, EventArgs e)
        {
            reset_defaults();
            cboPersonInterviewed.Text = "select household member";
            cboBeneficiaryName.SelectedValue = "-1";
            txtBeneficiaryAge.Text = string.Empty;
            txt_beneficiary_code.Text = string.Empty;
            rbtngenderMale.Checked = false;
            rbtngenderFemale.Checked = false;
            dtTimeVisistDate.Value = DateTime.Today;
            lblras_id.Text = "lblras_id";
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            cboPersonInterviewed.Enabled = true;
            dtTimeVisistDate.Enabled = true;
        }

        private void gdv_ras_members_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv_ras_members.Rows.Count > 0)
            {
                string hhm_id = gdv_ras_members.CurrentRow.Cells[1].Value.ToString();
                return_beneficiary_code(hhm_id);
                Return_hhm_ras_details(hhm_id, lblras_id.Text);
            }
        }
    }
}
