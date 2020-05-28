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
    public partial class frmCovid19DataCollectionSearch : UserControl
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

        public frmCovid19DataCollectionSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadList("Search");
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            #region Set Selected
            benCovid19DataCollection.cdc_id = string.Empty;
            frmCovid19DataCollection frmNew = new frmCovid19DataCollection();
            frmNew.FormCallingSearch = this;
            frmNew.FormParent = FormParent;
            frmNew.FormMaster = FormParent.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        #region Lookups
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
        #endregion

        protected void LoadList(string action)
        {
            switch (action)
            {
                case "Load":
                    dt = benCovid19DataCollection.LoadList();
                    break;
                case "Search":
                    dt = benCovid19DataCollection.Search(cboDistrict.SelectedValue.ToString() != "-1" ? cboDistrict.SelectedValue.ToString() : string.Empty
                        , cboSubCounty.SelectedValue.ToString() != "-1" ? cboSubCounty.SelectedValue.ToString() : string.Empty,
                        cboReportMonth.Text != string.Empty ? cboReportMonth.Text : string.Empty);
                    break;
            }
           
            gdvList.DataSource = dt;

            gdvList.Columns["cdc_id"].Visible = false;

            gdvList.Columns["dst_name"].HeaderText = "District";
            gdvList.Columns["sct_name"].HeaderText = "Sub County";
            gdvList.Columns["wrd_name"].HeaderText = "Parish";
            gdvList.Columns["report_month"].HeaderText = "Reporting Month";
            gdvList.Columns["week_name"].HeaderText = "Reporting Week";
            gdvList.Columns["swk_name"].HeaderText = "Social Worker Name";
            gdvList.Columns["psw_name"].HeaderText = "Para Social Worker Name";

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

        private void frmCovid19DataCollectionSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadList("Load");
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

        private void gdvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dt.Rows.Count > 0)
            {
                #region Set Selected
                benCovid19DataCollection.cdc_id = gdvList.CurrentRow.Cells[0].Value.ToString();
                frmCovid19DataCollection frmNew = new frmCovid19DataCollection();
                frmNew.FormCallingSearch = this;
                frmNew.FormParent = FormParent;
                frmNew.FormMaster = FormParent.FormMaster;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }
    }
}
