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
    public partial class frmYouthSavingsRegisterSearch : UserControl
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
        public frmYouthSavingsRegisterSearch()
        {
            InitializeComponent();
        }

        private void frmYouthSavingsRegisterSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();

            #region Youth savings groups
            ReturnYouthGroupList("list");
            #endregion Youth savings groups
        }

        protected void Return_lookups()
        {
            #region districts
            dt = benYouthSavingsRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty,string.Empty); //reused
            #region Search
            dt = benYouthSavingsRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty,string.Empty); //reused

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
            dt = benYouthSavingsRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty,string.Empty);
            #region IP Search
            dt = benYouthSavingsRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty,string.Empty);

            DataRow ipsearchemptyRow = dt.NewRow();
            ipsearchemptyRow["prt_id"] = "-1";
            ipsearchemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipsearchemptyRow, 0);

            cboIPSearch.DataSource = dt;
            cboIPSearch.DisplayMember = "prt_name";
            cboIPSearch.ValueMember = "prt_id";
            #endregion IP Search
            #endregion IP

            #region SubCounty Search
            dt = benYouthSavingsRegister.Return_lookups("subcounty", cboDistrictSearch.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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
        }

        protected void ReturnYouthGroupList(string action)
        {
            if (action == "list")
            {
                dt = benYouthSavingsRegister.ReturnYouthGroups();
                if (dt != null)
                {
                    gdvGroupsList.DataSource = dt;

                    gdvGroupsList.Columns["ysr_id"].Visible = false;

                    gdvGroupsList.Columns["month"].HeaderText = "Month";
                    gdvGroupsList.Columns["year"].HeaderText = "Year";
                    gdvGroupsList.Columns["ygrp_name"].HeaderText = "Youth savings group name";

                    gdvGroupsList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvGroupsList.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvGroupsList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    gdvGroupsList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    gdvGroupsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    gdvGroupsList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    gdvGroupsList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    gdvGroupsList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvGroupsList.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            else if (action == "search")
            {
                dt = benYouthSavingsRegister.Search(cboDistrictSearch.SelectedValue.ToString(), cboSubcountySearch.SelectedValue.ToString(), cboIPSearch.SelectedValue.ToString(),
                    cboCSOSearch.SelectedValue.ToString(), cboParishSearch.SelectedValue.ToString(), txtgroupnamesearch.Text);
                if (dt != null)
                {
                    gdvGroupsList.DataSource = dt;

                    gdvGroupsList.Columns["ysr_id"].Visible = false;

                    gdvGroupsList.Columns["month"].HeaderText = "Month";
                    gdvGroupsList.Columns["year"].HeaderText = "Year";
                    gdvGroupsList.Columns["ygrp_name"].HeaderText = "Youth savings group name";

                    gdvGroupsList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvGroupsList.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvGroupsList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    gdvGroupsList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    gdvGroupsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    gdvGroupsList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    gdvGroupsList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    gdvGroupsList.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvGroupsList.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            ReturnYouthGroupList("search");
        }

        private void cboIPSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = benYouthSavingsRegister.Return_lookups("CSO", cboIPSearch.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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
            dt = benYouthSavingsRegister.Return_lookups("subcounty", cboDistrictSearch.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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
            dt = benYouthSavingsRegister.Return_lookups("parish", cboSubcountySearch.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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

        private void lnkNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected

            benYouthSavingsRegister.ysr_id = string.Empty;
            frmYouthSavingsRegister frmNew = new frmYouthSavingsRegister();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void gdvGroupsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvGroupsList.Rows.Count > 0)
            {
                benYouthSavingsRegister.ysr_id = gdvGroupsList.CurrentRow.Cells[0].Value.ToString();

                #region Set Selected
                frmYouthSavingsRegister frmNew = new frmYouthSavingsRegister();
                frmNew.FormCallingSearch = this;
                frmNew.FormMaster = FormParent.FormMaster;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }
    }
}
