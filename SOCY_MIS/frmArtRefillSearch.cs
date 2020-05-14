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
    public partial class frmArtRefillSearch : UserControl
    {
        #region Variables
        private frmResultArea03 frmPrt = null;
        DataTable dt = new DataTable();
        #endregion Variables

        #region Property
        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmArtRefillSearch()
        {
            InitializeComponent();
        }

        private void frmArtRefillSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadList();
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SOCYARTRefill._artr_id = string.Empty;
            #region Set Selected
            frmARTRefill frmNew = new frmARTRefill();
            frmNew.FormCallingSearch = this;
            frmNew.FormParent = FormParent;
            frmNew.FormMaster = FormParent.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        protected void LoadList()
        {
            dt = SOCYARTRefill.LoadList();
            gdvList.DataSource = dt;

            gdvList.Columns["artr_id"].Visible = false;

            gdvList.Columns["dst_name"].HeaderText = "District";
            gdvList.Columns["sct_name"].HeaderText = "Sub County";
            gdvList.Columns["yn_direct_beneficiary"].HeaderText = "Is this a direct beneficiary";
            gdvList.Columns["hh_code"].HeaderText = "Household Code";
            gdvList.Columns["hhm_name"].HeaderText = "Beneficiary";
            gdvList.Columns["gnd_name"].HeaderText = "Sex";
            gdvList.Columns["hhm_age"].HeaderText = "Age";
            gdvList.Columns["refill_date"].HeaderText = "Date";

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

        protected void SearchList()
        {
            dt = SOCYARTRefill.Search(cboHouseholdCode.SelectedValue.ToString() != "-1" ? cboHouseholdCode.SelectedValue.ToString() : string.Empty
                , txtHouseholdMember.Text, cboDistrict.SelectedValue.ToString() != "-1" ? cboDistrict.SelectedValue.ToString() : string.Empty,
                cboSubCounty.SelectedValue.ToString() != "-1" ? cboSubCounty.SelectedValue.ToString() : string.Empty);
            gdvList.DataSource = dt;

            gdvList.Columns["artr_id"].Visible = false;

            gdvList.Columns["dst_name"].HeaderText = "District";
            gdvList.Columns["sct_name"].HeaderText = "Sub County";
            gdvList.Columns["yn_direct_beneficiary"].HeaderText = "Is this a direct beneficiary";
            gdvList.Columns["hh_code"].HeaderText = "Household Code";
            gdvList.Columns["hhm_name"].HeaderText = "Beneficiary";
            gdvList.Columns["gnd_name"].HeaderText = "Sex";
            gdvList.Columns["hhm_age"].HeaderText = "Age";
            gdvList.Columns["refill_date"].HeaderText = "Date";

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

        private void gdvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gdvList.Rows.Count > 0)
            {
                #region Set Selected
                frmARTRefill frmNew = new frmARTRefill();
                SOCYARTRefill._artr_id = gdvList.CurrentRow.Cells[0].Value.ToString();
                frmNew.FormCallingSearch = this;
                frmNew.FormParent = FormParent;
                frmNew.FormMaster = FormParent.FormMaster;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }

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
            #endregion subcounty
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

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), string.Empty);  //reused

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHouseholdCode.DataSource = dt;

            cboHouseholdCode.DisplayMember = "hh_code";
            cboHouseholdCode.ValueMember = "hh_id";
            #endregion HH Codes
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }
    }
}
