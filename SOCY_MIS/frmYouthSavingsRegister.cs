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
    public partial class frmYouthSavingsRegister : UserControl
    {


        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmYouthSavingsRegisterSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public frmYouthSavingsRegisterSearch FormCallingSearch
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
        public frmYouthSavingsRegister()
        {
            InitializeComponent();
        }

        private void frmYouthSavingsRegister_Load(object sender, EventArgs e)
        {
            Return_lookups();
            ReturnYouthGroupDetails();
        }

        protected void Return_lookups()
        {
            #region districts
            dt = benYouthSavingsRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty,string.Empty); //reused

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

            #region IP
            dt = benYouthSavingsRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty,string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";

            #endregion IP

            #region subcounty
            dt = benYouthSavingsRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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

            #region CSO
            dt = benYouthSavingsRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";

            #region CSO Search

            #endregion CSO Search
            #endregion CSO

        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty);

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
            #region Sub County
            dt = benYouthSavingsRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";

            cboSubCounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCounty.AutoCompleteSource = AutoCompleteSource.ListItems;

            returnHHMemberCodes();

            #endregion Sub County
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region Load Parishes
            dt = benYouthSavingsRegister.Return_lookups("parish", cboSubCounty.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;

            #endregion Load Parishes
        }

        protected void returnHHMemberCodes()
        {
            #region HH Codes
            dt = benYouthSavingsRegister.Return_lookups("hh_codes", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),cboParish.SelectedValue.ToString());

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "Select HH Code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hh_code";
            cboHHCode.ValueMember = "hh_id";

            cboHHCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboHHCode.AutoCompleteSource = AutoCompleteSource.CustomSource;


            #endregion HH Codes
        }

        private void cboIPSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDistrictSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSubcountySearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    save_update_YouthSavingsRegister();
                }
                else
                {
                    MessageBox.Show("Missing required values", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        protected bool ValidateInput()
        {
            bool isValidInput = false;
            if (cboIP.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1"
                || cboParish.SelectedValue.ToString() == "-1" || txtVillage.Text == string.Empty || cboMonth.Text == string.Empty || cboYear.Text == string.Empty
                || txtYouthgroup_name.Text == string.Empty || txtchairperson_name.Text == string.Empty || txtPhone.Text == string.Empty)
            {
                isValidInput = false;
            }
            else
            {
                isValidInput = true;
            }

            return isValidInput;
        }


        protected void save_update_YouthSavingsRegister()
        {
            benYouthSavingsRegister.prt_id = cboIP.SelectedValue.ToString();
            benYouthSavingsRegister.cso_id = cboCso.SelectedValue.ToString();
            benYouthSavingsRegister.dst_id = cboDistrict.SelectedValue.ToString();
            benYouthSavingsRegister.sct_id = cboSubCounty.SelectedValue.ToString();
            benYouthSavingsRegister.wrd_id = cboParish.SelectedValue.ToString();
            benYouthSavingsRegister.village = txtVillage.Text;
            benYouthSavingsRegister.month = cboMonth.Text;
            benYouthSavingsRegister.year = cboYear.Text;
            benYouthSavingsRegister.ygrp_name = txtYouthgroup_name.Text;
            benYouthSavingsRegister.ygrp_chairperson_name = txtchairperson_name.Text;
            benYouthSavingsRegister.ygrp_chairperson_name_phone = txtPhone.Text;
            benYouthSavingsRegister.youth_field_assisstant_name = cboTrainerType.Text;

            benYouthSavingsRegister.usr_id_create = SystemConstants.user_id;
            benYouthSavingsRegister.usr_id_update = SystemConstants.user_id;
            benYouthSavingsRegister.usr_date_create = DateTime.Now;
            benYouthSavingsRegister.usr_date_update = DateTime.Now;
            benYouthSavingsRegister.ofc_id = SystemConstants.ofc_id;
            benYouthSavingsRegister.district_id = SystemConstants.Return_office_district();

            if (lblysr_id.Text == "lblysr_id")
            {
                benYouthSavingsRegister.ysr_id = Guid.NewGuid().ToString();
                #region Insert
                lblysr_id.Text = benYouthSavingsRegister.save_update_YouthSavingsRegister("insert");
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Insert
            }
            else
            {
                benYouthSavingsRegister.ysr_id = lblysr_id.Text;
                #region Update
                string lblysri_id = benYouthSavingsRegister.save_update_YouthSavingsRegister("update");
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Update
            }
        }

        private void txtamountsaved_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtamountborrowed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnmsaveMember_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateMemberDetails())
                {
                    save_update_YouthSavingsRegisterMember();
                    ReturnGroupMembers(benYouthSavingsRegister.ysr_id);
                }
                else
                {
                    MessageBox.Show("Missing required values", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        protected void save_update_YouthSavingsRegisterMember()
        {
            benYouthSavingsRegister.hhm_code = cboHHCode.Text;

            #region hhm_name
            if (rdnDirectYes.Checked == true) { benYouthSavingsRegister.hhm_name = cboHHMember.Text; }
            else if (rdnDirectNo.Checked == true) { benYouthSavingsRegister.hhm_name = txtYouthName.Text; }
            #endregion hhm_name

            benYouthSavingsRegister.hhm_id = cboHHMember.SelectedValue.ToString();
            benYouthSavingsRegister.yn_direct_beneficiary = utilControls.RadioButtonGetSelection(rdnDirectYes, rdnDirectNo);
            benYouthSavingsRegister.total_savings = txtamountsaved.Text;
            benYouthSavingsRegister.amout_borrowed = txtamountborrowed.Text;
            benYouthSavingsRegister.loan_purpose = cboLoanPurpose.Text;
            benYouthSavingsRegister.loan_purpose_other = txtLoanPurposeOther.Text;
            benYouthSavingsRegister.ysr_id = lblysr_id.Text;  //refactor to pick real id

            benYouthSavingsRegister.usr_id_create = SystemConstants.user_id;
            benYouthSavingsRegister.usr_id_update = SystemConstants.user_id;
            benYouthSavingsRegister.usr_date_create = DateTime.Today;
            benYouthSavingsRegister.usr_date_update = DateTime.Today;
            benYouthSavingsRegister.ofc_id = SystemConstants.ofc_id;
            benYouthSavingsRegister.district_id = SystemConstants.Return_office_district();

            if (ysrm_id.Text == "ysrm_id")
            {
                benYouthSavingsRegister.ysrm_id = Guid.NewGuid().ToString();

                #region Insert
                ysrm_id.Text = benYouthSavingsRegister.save_update_YouthSavingsRegisterMember("insert");

                benYouthSavingsRegister.ysrms_id = Guid.NewGuid().ToString();
                lblysrms_id.Text = benYouthSavingsRegister.save_update_YouthSavingsRegisterMemberAmount("insert");
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Insert
            }
            else
            {
                benYouthSavingsRegister.ysrm_id = ysrm_id.Text;
                #region Update
                string emptystr = benYouthSavingsRegister.save_update_YouthSavingsRegisterMember("update");
                #region save or update member savings
                if (lblysrms_id.Text == "lblysrms_id")
                {
                    benYouthSavingsRegister.ysrms_id = Guid.NewGuid().ToString();
                    lblysrms_id.Text = benYouthSavingsRegister.save_update_YouthSavingsRegisterMemberAmount("insert");
                }
                else
                {
                    benYouthSavingsRegister.ysrms_id = lblysrms_id.Text;
                    string emptystre = benYouthSavingsRegister.save_update_YouthSavingsRegisterMemberAmount("update");
                }
                #endregion save or update member savings
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Update
            }
        }

        protected bool ValidateMemberDetails()
        {
            bool isValidinput = false;
            if (rdnDirectYes.Checked == true || rdnDirectNo.Checked == true)
            {
                if (rdnDirectYes.Checked == true)
                {
                    if (cboHHMember.SelectedValue.ToString() == "-1" || cboHHCode.Text == string.Empty || txtamountsaved.Text == string.Empty || txtamountborrowed.Text == string.Empty
                    || cboLoanPurpose.Text == string.Empty || (rdnDirectYes.Checked == false && rdnDirectNo.Checked == false) || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMember.SelectedValue.ToString() == "-1")
                    {
                        isValidinput = false;
                    }
                    else
                    {
                        isValidinput = true;
                    }
                }
                else if (rdnDirectNo.Checked == true)
                {
                    if (txtamountsaved.Text == string.Empty || txtamountborrowed.Text == string.Empty
                   || cboLoanPurpose.Text == string.Empty || (rdnDirectYes.Checked == false && rdnDirectNo.Checked == false) || txtYouthName.Text == string.Empty)
                    {
                        isValidinput = false;
                    }
                    else
                    {
                        isValidinput = true;
                    }
                }
            }
            else
            {
                isValidinput = false;

            }
            return isValidinput;
        }



        private void gdvGroupsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnYouthGroupDetails();
        }

        protected void ReturnYouthGroupDetails()
        {
            DataRow dtRow;
            dt = benYouthSavingsRegister.ReturnYouthGroupDetails(benYouthSavingsRegister.ysr_id, "group_details");
            if (dt.Rows.Count > 0)
            {
                dtRow = dt.Rows[0];

                #region Fill Controls
                cboIP.SelectedValue = dtRow["prt_id"].ToString();
                cboCso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                txtVillage.Text = dtRow["village"].ToString();
                cboMonth.Text = dtRow["month"].ToString();
                cboYear.Text = dtRow["year"].ToString();
                txtYouthgroup_name.Text = dtRow["ygrp_name"].ToString();
                txtchairperson_name.Text = dtRow["ygrp_chairperson_name"].ToString();
                txtPhone.Text = dtRow["ygrp_chairperson_name_phone"].ToString();
                cboTrainerType.Text = dtRow["youth_field_assisstant_name"].ToString();
                lblysr_id.Text = benYouthSavingsRegister.ysr_id;
                tlpDisplay01.Enabled = false;

                ReturnGroupMembers(benYouthSavingsRegister.ysr_id);

                #region AccessControl
                string ofc_id = dtRow["ofc_id"].ToString();
                btnsave.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                btnmsaveMember.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                btnNewMember.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                #endregion AccessControl
                #endregion Fill Controls
            }
        }

        protected void ReturnGroupMembers(string ysr_id)
        {
            dt = benYouthSavingsRegister.ReturnYouthGroupDetails(ysr_id, "group_members");
            if (dt.Rows.Count > 0)
            {
                gdvSavingsList.DataSource = dt;

                gdvSavingsList.Columns["ysrms_id"].Visible = false;
                gdvSavingsList.Columns["ysrm_id"].Visible = false;
                gdvSavingsList.Columns["hhm_id"].Visible = false;
                gdvSavingsList.Columns["yn_direct_beneficiary"].Visible = false;

                gdvSavingsList.Columns["hhm_code"].HeaderText = "Household Code";
                gdvSavingsList.Columns["hhm_name"].HeaderText = "Group Member Name";
                gdvSavingsList.Columns["total_savings"].HeaderText = "Total Savings";
                gdvSavingsList.Columns["amout_borrowed"].HeaderText = "Amount Borrowed";
                gdvSavingsList.Columns["loan_purpose"].HeaderText = "Loan Purpose";

                gdvSavingsList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvSavingsList.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvSavingsList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvSavingsList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvSavingsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvSavingsList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvSavingsList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvSavingsList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvSavingsList.DefaultCellStyle.SelectionForeColor = Color.Black;

            }
            else
            {
                gdvSavingsList.DataSource = dt;
            }
        }

        protected void ReturnGroupMemberSavings(string ysrm_id)
        {
            dt = benYouthSavingsRegister.ReturnYouthGroupDetails(ysrm_id, "member_savings");
            if (dt != null)
            {
                gdvSavingsList.DataSource = dt;

                gdvSavingsList.Columns["ysrms_id"].Visible = false;
                //gdvSavingsList.Columns["hhm_id"].Visible = false;
                //gdvSavingsList.Columns["yn_direct_beneficiary"].Visible = false;
                gdvSavingsList.Columns["hhm_code"].HeaderText = "Household Code";

                gdvSavingsList.Columns["hhm_name"].HeaderText = "Group Member Name";
                gdvSavingsList.Columns["total_savings"].HeaderText = "Total Savings";
                gdvSavingsList.Columns["amout_borrowed"].HeaderText = "Amount Borrowed";
                gdvSavingsList.Columns["loan_purpose"].HeaderText = "Loan Purpose";
                gdvSavingsList.Columns["loan_purpose_other"].HeaderText = "Other Loan Purpose";

                gdvSavingsList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvSavingsList.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvSavingsList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvSavingsList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvSavingsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvSavingsList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvSavingsList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvSavingsList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvSavingsList.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void cboYouthGroupMembersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboYouthGroupMembersList.SelectedIndex != -1)
            //{
            //    ReturnGroupMemberSavings(cboYouthGroupMembersList.SelectedValue.ToString());
            //    ysrm_id.Text = cboYouthGroupMembersList.SelectedValue.ToString();
            //}
        }

        private void gdvSavingsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvSavingsList.Rows.Count > 0)
            {
                txtYouthName.Text = gdvSavingsList.CurrentRow.Cells[2].Value.ToString();
                txtamountsaved.Text = gdvSavingsList.CurrentRow.Cells[3].Value.ToString();
                txtamountborrowed.Text = gdvSavingsList.CurrentRow.Cells[4].Value.ToString();
                cboLoanPurpose.Text = gdvSavingsList.CurrentRow.Cells[5].Value.ToString();
                txtLoanPurposeOther.Text = gdvSavingsList.CurrentRow.Cells[6].Value.ToString();
                cboHHCode.Text = gdvSavingsList.CurrentRow.Cells[1].Value.ToString();
                cboHHMember.SelectedValue = gdvSavingsList.CurrentRow.Cells[7].Value.ToString();
                utilControls.RadioButtonSetSelection(rdnDirectYes, rdnDirectNo, gdvSavingsList.CurrentRow.Cells[8].Value.ToString());
                ysrm_id.Text = gdvSavingsList.CurrentRow.Cells[9].Value.ToString();
                lblysrms_id.Text = gdvSavingsList.CurrentRow.Cells[0].Value.ToString();

                tlpDisplay02.Enabled = false;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //ReturnYouthGroupList("search");
        }

        protected void ClearContent(string action)
        {
            if (action == "clear_all")
            {
                cboIP.SelectedValue = "-1";
                cboCso.SelectedValue = "-1";
                cboDistrict.SelectedValue = "-1";
                cboSubCounty.SelectedValue = "-1";
                cboParish.SelectedValue = "-1";
                txtVillage.Clear();
                cboMonth.Text = string.Empty;
                cboYear.Text = string.Empty;
                txtYouthgroup_name.Clear();
                txtchairperson_name.Clear();
                txtPhone.Clear();
                cboTrainerType.Text = string.Empty;
                lblysr_id.Text = "lblysr_id";

                cboHHMember.SelectedValue = "-1";
                txtamountsaved.Clear();
                txtamountborrowed.Clear();
                cboLoanPurpose.Text = string.Empty;
                txtLoanPurposeOther.Clear();
                cboHHCode.SelectedValue = "-1";
                cboHHMember.SelectedValue = "-1";
                txtYouthName.Clear();
                lblysrms_id.Text = "lblysrms_id";
                ysrm_id.Text = "ysrm_id";
                rdnDirectYes.Checked = false;
                rdnDirectNo.Checked = false;
                cboHHCode.Enabled = true;
                cboHHMember.Enabled = true;
                txtYouthName.ReadOnly = false;

                tlpDisplay02.Enabled = true;
                tlpDisplay01.Enabled = true;
                btnNewMember.Enabled = true;
                btnsave.Enabled = true;
            }
            else if (action == "clear_member")
            {
                cboHHMember.SelectedValue = "-1";
                txtamountsaved.Clear();
                txtamountborrowed.Clear();
                cboLoanPurpose.Text = string.Empty;
                txtLoanPurposeOther.Clear();
                cboHHCode.SelectedValue = "-1";
                cboHHMember.SelectedValue = "-1";
                txtYouthName.Clear();
                rdnDirectYes.Checked = false;
                rdnDirectNo.Checked = false;
                cboHHCode.Enabled = true;
                cboHHMember.Enabled = true;
                txtYouthName.ReadOnly = false;

                lblysrms_id.Text = "lblysrms_id";
                ysrm_id.Text = "ysrm_id";

                tlpDisplay02.Enabled = true;

                #region Clear group members
                dt = null;
                gdvSavingsList.DataSource = dt;
                #endregion  Clear group members
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            ClearContent("clear_all");
        }

        private void btnNewMember_Click(object sender, EventArgs e)
        {
            ClearContent("clear_member");
        }

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = benYouthSavingsRegister.ReturnYouthGroupDetails(cboHHCode.SelectedValue.ToString(), "Youth");


            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hhm_id"] = "-1";
            hhCode_emptyRow["hhm_name"] = "Select HH Member";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHMember.DataSource = dt;
            cboHHMember.DisplayMember = "hhm_name";
            cboHHMember.ValueMember = "hhm_id";
        }

        private void btneditMember_Click(object sender, EventArgs e)
        {
            tlpDisplay02.Enabled = true;
        }

        private void rdnDirectYes_CheckedChanged(object sender, EventArgs e)
        {
            if(rdnDirectYes.Checked == true)
            {
                cboHHCode.Enabled = true;
                cboHHMember.Enabled = true;
                txtYouthName.ReadOnly = true;
            }
            else
            {
                cboHHCode.Enabled = false;
                cboHHMember.Enabled = false;
                txtYouthName.ReadOnly = false;
            }
        }

        private void rdnDirectNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnDirectNo.Checked == true)
            {
                cboHHMember.Enabled = false;
                cboHHCode.SelectedValue = "-1";
                cboHHMember.SelectedValue = "-1";
                txtYouthName.ReadOnly = false;
            }
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHMemberCodes();
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tlpDisplay01.Enabled = true;
        }
    }
}
