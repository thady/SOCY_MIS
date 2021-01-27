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
    public partial class frmHouseholdTransferSearch : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea03 frmPrt = null;
        #endregion Variables

        #region Property
        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property
        public frmHouseholdTransferSearch()
        {
            InitializeComponent();
        }

        private void frmHouseholdTransferSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadListing(string.Empty, string.Empty, string.Empty,txtHHcode.Text.Trim());
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

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion districts

            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

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
        }

        protected void LoadListing(string dst_id, string sct_id, string wrd_id,string hh_code)
        {
            dt = HouseholdTransfer.LoadRecordListing(dst_id, sct_id, wrd_id,hh_code);

            gdvList.DataSource = dt;

            gdvList.Columns["hh_tr_id"].Visible = false;

            gdvList.Columns["dst_name"].HeaderText = "District";
            gdvList.Columns["sct_name"].HeaderText = "Sub County";
            gdvList.Columns["wrd_name"].HeaderText = "Parish";
            gdvList.Columns["hh_village"].HeaderText = "Village";
            gdvList.Columns["hh_code"].HeaderText = "Household Code";
            gdvList.Columns["date"].HeaderText = "Date";

            gdvList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvList.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvList.RowsDefaultCellStyle.BackColor = Color.LightGray;
            gdvList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // Set the row and column header styles.
            gdvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdvList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gdvList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            gdvList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvList.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn c in gdvList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
        }

        private void lblNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            HouseholdTransfer.hh_tr_id = string.Empty;
            frmHouseholdTransferTool frmNew = new frmHouseholdTransferTool();
            frmNew.FormCallingSearch = this;
            frmNew.FormParent = FormParent;
            frmNew.FormMaster = FormParent.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            LoadListing(cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboParish.SelectedValue.ToString(),txtHHcode.Text.Trim());
        }

        private void gdvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvList.Rows.Count > 0)
            {
                #region Set Selected
                HouseholdTransfer.hh_tr_id = gdvList.CurrentRow.Cells[0].Value.ToString();
                frmHouseholdTransferTool frmNew = new frmHouseholdTransferTool();
                frmNew.FormCallingSearch = this;
                frmNew.FormParent = FormParent;
                frmNew.FormMaster = FormParent.FormMaster;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }

        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

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
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Parish
            dt = silcCommunityTrainingRegister.Return_lookups("parishCovid19", string.Empty, string.Empty, cboSubCounty.SelectedValue.ToString(), string.Empty);

            DataRow emptyRow = dt.NewRow();
            emptyRow["wrd_id"] = "-1";
            emptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(emptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Parish
        }
    }
}

