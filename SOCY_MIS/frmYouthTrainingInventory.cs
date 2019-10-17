using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmYouthTrainingInventory : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property
        public frmYouthTrainingInventory()
        {
            InitializeComponent();
        }

        private void frmYouthTrainingInventory_Load(object sender, EventArgs e)
        {
            Return_lookups();
            ReturnLists("list");
        }

        protected void Return_lookups()
        {
            #region districts
            dt = benYouthTrainingInventory.Return_lookups("district", string.Empty, string.Empty, string.Empty); //reused

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["dst_id"] = "-1";
            dstemptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;

            #region Search
            dt = benYouthTrainingInventory.Return_lookups("district", string.Empty, string.Empty, string.Empty); //reused

            DataRow dstsearch_emptyRow = dt.NewRow();
            dstsearch_emptyRow["dst_id"] = "-1";
            dstsearch_emptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstsearch_emptyRow, 0);

            cboDistrictSearch.DisplayMember = "dst_name";
            cboDistrictSearch.ValueMember = "dst_id";
            cboDistrictSearch.DataSource = dt;

            cboDistrictSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrictSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Search
            #endregion districts

            #region IP
            dt = benYouthTrainingInventory.Return_lookups("IP", string.Empty, string.Empty, string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";

            #region IP Search
            dt = benYouthTrainingInventory.Return_lookups("IP", string.Empty, string.Empty, string.Empty);

            DataRow ipsearchemptyRow = dt.NewRow();
            ipsearchemptyRow["prt_id"] = "-1";
            ipsearchemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipsearchemptyRow, 0);

            cboIPSearch.DataSource = dt;
            cboIPSearch.DisplayMember = "prt_name";
            cboIPSearch.ValueMember = "prt_id";
            #endregion IP Search
            #endregion IP

            #region subcounty
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";

            cboSubCounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCounty.AutoCompleteSource = AutoCompleteSource.ListItems;

            #region SubCounty Search
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctsearchemptyRow = dt.NewRow();
            sctsearchemptyRow["sct_id"] = "-1";
            sctsearchemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctsearchemptyRow, 0);

            cboSubcountySearch.DataSource = dt;
            cboSubcountySearch.DisplayMember = "sct_name";
            cboSubcountySearch.ValueMember = "sct_id";

            cboSubcountySearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubcountySearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion SubCounty Search
            #endregion subcounty

            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty);

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

            #region Gender
            dt = benYouthTrainingInventory.Return_lookups("gender", string.Empty, string.Empty, string.Empty);

            DataRow gender_emptyRow = dt.NewRow();
            gender_emptyRow["gnd_id"] = "-1";
            gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(gender_emptyRow, 0);

            cbosex.DataSource = dt;
            cbosex.DisplayMember = "gnd_name";
            cbosex.ValueMember = "gnd_id";
            #endregion Gender
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
            #region Load SubCountys
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion Load SubCountys

            //returnHHMemberCodes();
           // returnHHCodesByLocation();
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

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Load Parishes
        }

        private void cboIPSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIPSearch.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCSOSearch.DataSource = dt;
            cboCSOSearch.DisplayMember = "cso_other";
            cboCSOSearch.ValueMember = "cso_id";
            #endregion LoadCSOs
        }

        private void cboDistrictSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load SubCountys
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrictSearch.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubcountySearch.DataSource = dt;
            cboSubcountySearch.DisplayMember = "sct_name";
            cboSubcountySearch.ValueMember = "sct_id";

            cboSubcountySearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubcountySearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Load SubCountys
        }

        private void cboSubcountySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load Parishes
            dt = benYouthTrainingInventory.Return_lookups("parish", cboSubcountySearch.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboParishSearch.DataSource = dt;
            cboParishSearch.DisplayMember = "wrd_name";
            cboParishSearch.ValueMember = "wrd_id";

            cboParishSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParishSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Load Parishes
        }

        protected void returnHHMembers(string hh_id)
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("hhm", hh_id, string.Empty,string.Empty,string.Empty);

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hhm_id"] = "-1";
            hhCode_emptyRow["hhm_code"] = "Member Code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cbohhmcode.DataSource = dt;

            cbohhmcode.DisplayMember = "hhm_code";
            cbohhmcode.ValueMember = "hhm_id";

            cbohhmcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbohhmcode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            #endregion HH Codes
        }

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),cboParish.SelectedValue.ToString());

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHcCode.DataSource = dt;

            cboHHcCode.DisplayMember = "hh_code";
            cboHHcCode.ValueMember = "hh_id";

            #endregion HH Codes
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    save_update_YouthTrainignDetails();
                    ReturnLists("list");
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

        protected void save_update_YouthTrainignDetails()
        {
            #region Set Variables
            benYouthTrainingInventory.prt_id = cboIP.SelectedValue.ToString();
            benYouthTrainingInventory.cso_id = cboCso.SelectedValue.ToString();
            benYouthTrainingInventory.dst_id = cboDistrict.SelectedValue.ToString();
            benYouthTrainingInventory.sct_id = cboSubCounty.SelectedValue.ToString();
            benYouthTrainingInventory.wrd_id = cboParish.SelectedValue.ToString();
            benYouthTrainingInventory.begin_date = dtbeginDate.Value;
            benYouthTrainingInventory.hhm_code = cbohhmcode.Text;
            benYouthTrainingInventory.hhm_name = txtYouthname.Text;
            benYouthTrainingInventory.grp_name = txtgroupname.Text;
            benYouthTrainingInventory.age = txtage.Text;
            benYouthTrainingInventory.gnd_id = cbosex.SelectedValue.ToString();
            benYouthTrainingInventory.training_type = cboTrainingType.Text;
            benYouthTrainingInventory.trainer_name = txtTrainername.Text;
            benYouthTrainingInventory.exp_date_completion = dtExpectedCompletiondate.Value.Date;
            benYouthTrainingInventory.actual_date_completion = dtActualCompletiondate.Value.Date;

            benYouthTrainingInventory.usr_id_create = SystemConstants.user_id;
            benYouthTrainingInventory.usr_id_update = SystemConstants.user_id;
            benYouthTrainingInventory.usr_date_create = DateTime.Today;
            benYouthTrainingInventory.usr_date_update = DateTime.Today;
            benYouthTrainingInventory.ofc_id = SystemConstants.ofc_id;
            benYouthTrainingInventory.district_id = SystemConstants.Return_office_district();


            #endregion Set Variables

            if (lblyti_id.Text == "lblyti_id")
            {
                benYouthTrainingInventory.yti_id = Guid.NewGuid().ToString();
                #region Insert
                lblyti_id.Text = benYouthTrainingInventory.save_update_YouthTrainingInventoryDetails("insert");
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Insert
            }
            else
            {
                benYouthTrainingInventory.yti_id = lblyti_id.Text;
                #region Update
                string lblytii_id = benYouthTrainingInventory.save_update_YouthTrainingInventoryDetails("update");
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Update
            }
        }

        protected bool ValidateInput()
        {
            bool isValidInput = false;
            if (cboIP.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1"
                || cboParish.SelectedValue.ToString() == "-1" || dtbeginDate.Checked == false || cbohhmcode.SelectedValue.ToString() == "-1" || txtYouthname.Text == string.Empty
                || txtage.Text == string.Empty || cbosex.SelectedValue.ToString() == "-1" || cboTrainingType.Text == string.Empty || txtTrainername.Text == string.Empty
                || dtExpectedCompletiondate.Checked == false)
            {
                isValidInput = false;
            }
            else
            {
                isValidInput = true;
            }

            return isValidInput;
        }

        protected void ReturnLists(string action)
        {
            if (action == "list")
            {
                dt = benYouthTrainingInventory.ReturnInventoryList_details("list", string.Empty);
                if (dt.Rows.Count > 0)
                {
                    gdvYouthList.DataSource = dt;

                    gdvYouthList.Columns["yti_id"].Visible = false;
                    gdvYouthList.Columns["dst_name"].HeaderText = "District";
                    gdvYouthList.Columns["sct_name"].HeaderText = "Sub County";
                    gdvYouthList.Columns["wrd_name"].HeaderText = "Parish";
                    gdvYouthList.Columns["prt_name"].HeaderText = "Partner";
                    gdvYouthList.Columns["cso_name"].HeaderText = "CSO";
                    gdvYouthList.Columns["hhm_name"].HeaderText = "Youth Name";

                    gdvYouthList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvYouthList.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvYouthList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    gdvYouthList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    gdvYouthList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    gdvYouthList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    gdvYouthList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    gdvYouthList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvYouthList.DefaultCellStyle.SelectionForeColor = Color.Black;

                }
                else
                {
                    dt = null;
                    gdvYouthList.DataSource = dt;
                }
            }
            else if (action == "search")
            {
                dt = benYouthTrainingInventory.Search(cboDistrictSearch.SelectedValue.ToString(), cboSubcountySearch.SelectedValue.ToString(), cboIPSearch.SelectedValue.ToString(),
                    cboCSOSearch.SelectedValue.ToString(), cboParishSearch.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    gdvYouthList.DataSource = dt;

                    gdvYouthList.Columns["yti_id"].Visible = false;
                    gdvYouthList.Columns["dst_name"].HeaderText = "District";
                    gdvYouthList.Columns["sct_name"].HeaderText = "Sub County";
                    gdvYouthList.Columns["wrd_name"].HeaderText = "Parish";
                    gdvYouthList.Columns["prt_name"].HeaderText = "Partner";
                    gdvYouthList.Columns["cso_name"].HeaderText = "CSO";
                    gdvYouthList.Columns["hhm_name"].HeaderText = "Youth Name";

                    gdvYouthList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvYouthList.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvYouthList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    gdvYouthList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    gdvYouthList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    gdvYouthList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    gdvYouthList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    gdvYouthList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvYouthList.DefaultCellStyle.SelectionForeColor = Color.Black;

                }
                else
                {
                    dt = null;
                    gdvYouthList.DataSource = dt;
                }
            }
           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            ReturnLists("search");
        }

        protected void returnYouthTrainingDetails(string yti_id)
        {
            dt = benYouthTrainingInventory.ReturnInventoryList_details("member_details",yti_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboIP.SelectedValue = dtRow["prt_id"].ToString();
                cboCso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                dtbeginDate.Value = Convert.ToDateTime(dtRow["begin_date"]);
                cbohhmcode.Text = dtRow["hhm_code"].ToString();
                txtYouthname.Text = dtRow["hhm_name"].ToString();
                txtgroupname.Text = dtRow["grp_name"].ToString();
                txtage.Text = dtRow["age"].ToString();
                cbosex.SelectedValue = dtRow["gnd_id"].ToString();
                cboTrainingType.Text = dtRow["training_type"].ToString();
                txtTrainername.Text = dtRow["trainer_name"].ToString();
                dtExpectedCompletiondate.Value = Convert.ToDateTime(dtRow["exp_date_completion"]);
                dtActualCompletiondate.Value = Convert.ToDateTime(dtRow["actual_date_completion"]);
                lblyti_id.Text = dtRow["yti_id"].ToString();

                tlpDisplay02.Enabled = false;
                tlpDisplay01.Enabled = false;

                #region AccessControl
                string ofc_id = dtRow["ofc_id"].ToString();
                btnsave.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                #endregion AccessControl
            }
        }

        private void gdvYouthList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvYouthList.Rows.Count > 0)
            {
                string yti_id = gdvYouthList.CurrentRow.Cells[0].Value.ToString();
                returnYouthTrainingDetails(yti_id);
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void ClearControls()
        {
            cboIP.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            dtbeginDate.Value = DateTime.Today;
            cbohhmcode.Text = string.Empty;
            txtYouthname.Clear();
            txtgroupname.Clear();
            txtage.Clear();
            cbosex.SelectedValue = "-1";
            cboTrainingType.Text = string.Empty;
            txtTrainername.Clear();
            dtExpectedCompletiondate.Value = DateTime.Today;
            dtActualCompletiondate.Value = DateTime.Today;
            lblyti_id.Text = "lblyti_id";
            tlpDisplay02.Enabled = true;
            tlpDisplay01.Enabled = true;
            btnsave.Enabled = true;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tlpDisplay02.Enabled = true;
            tlpDisplay01.Enabled = true;
        }

        private void cboHHcCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHcCode.SelectedIndex != -1)
            {
                returnHHMembers(cboHHcCode.SelectedValue.ToString());
                txtYouthname.Clear();
                cbosex.SelectedValue = "-1";
                txtage.Clear();
            }
        }

        private void cbohhmcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbohhmcode.SelectedIndex != 0)
            {
                ReturnHHMData(cbohhmcode.SelectedValue.ToString());
            }
        }

        protected void ReturnHHMData(string hhm_id)
        {
            dt = silcCommunityTrainingRegister.Return_lookups("hhm_details", hhm_id, string.Empty, string.Empty,string.Empty);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txtYouthname.Text = dtRow["hhm_name"].ToString();
                cbosex.SelectedValue = dtRow["gnd_id"].ToString();

                #region Age
                int BirthYear = Convert.ToInt32(dtRow["hhm_year_of_birth"].ToString());
                if (BirthYear != -1)
                {
                    txtage.Text = (DateTime.Now.Year - BirthYear).ToString();
                }
                else
                {
                    txtage.Text = string.Empty;
                }
                #endregion Age
            }
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            //returnHHMemberCodes();
            returnHHCodesByLocation();
        }
    }
}
