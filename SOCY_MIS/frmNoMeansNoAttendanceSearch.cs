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
    public partial class frmNoMeansNoAttendanceSearch : UserControl
    {
        public frmNoMeansNoAttendanceSearch()
        {
            InitializeComponent();
        }

        private void frmNoMeansNoAttendanceSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadDisplayList();
        }

        #region Variables
        DataTable dt = null;
        private frmNoMeansNoMain frmPrt = null;
        #endregion Variables

        #region # Property
        public frmNoMeansNoMain FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        private void lblNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            NoMeansNoWorldWide.roster_id = string.Empty;
            frmNoMeansNoAttendance frmNew = new frmNoMeansNoAttendance();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        protected void LoadDisplayList()
        {
            dt = NoMeansNoWorldWide.LoadNMNAttendance();

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["roster_id"].Visible = false;

            gdvParticipantList.Columns["dst_name"].HeaderText = "District";
            gdvParticipantList.Columns["sct_name"].HeaderText = "Sub County";
            gdvParticipantList.Columns["wrd_name"].HeaderText = "Parish";
            gdvParticipantList.Columns["int_type"].HeaderText = "Intervention Type";
            gdvParticipantList.Columns["start_date"].HeaderText = "Start Date";
            gdvParticipantList.Columns["end_date"].HeaderText = "End Date";
            gdvParticipantList.Columns["cso_name"].HeaderText = "Implementing Partner/CSO";
            gdvParticipantList.Columns["delivery_method"].HeaderText = "Delivery Method";

            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvParticipantList.RowsDefaultCellStyle.BackColor = Color.LightGray;
            gdvParticipantList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // Set the row and column header styles.
            gdvParticipantList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdvParticipantList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gdvParticipantList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn c in gdvParticipantList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
        }

        protected void Search()
        {
            dt = NoMeansNoWorldWide.SearchNMNAttendance(cboDistrict.SelectedValue.ToString() != "-1"?cboDistrict.SelectedValue.ToString():string.Empty
                ,cboSubCounty.SelectedValue.ToString() != "-1"?cboSubCounty.SelectedValue.ToString():string.Empty
                ,cboParish.SelectedValue.ToString() != "-1"?cboParish.SelectedValue.ToString():string.Empty
                ,cboTrainingType.Text);

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["roster_id"].Visible = false;

            gdvParticipantList.Columns["dst_name"].HeaderText = "District";
            gdvParticipantList.Columns["sct_name"].HeaderText = "Sub County";
            gdvParticipantList.Columns["wrd_name"].HeaderText = "Parish";
            gdvParticipantList.Columns["int_type"].HeaderText = "Intervention Type";
            gdvParticipantList.Columns["start_date"].HeaderText = "Start Date";
            gdvParticipantList.Columns["end_date"].HeaderText = "End Date";
            gdvParticipantList.Columns["cso_name"].HeaderText = "Implementing Partner/CSO";
            gdvParticipantList.Columns["delivery_method"].HeaderText = "Delivery Method";

            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvParticipantList.RowsDefaultCellStyle.BackColor = Color.LightGray;
            gdvParticipantList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // Set the row and column header styles.
            gdvParticipantList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdvParticipantList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gdvParticipantList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn c in gdvParticipantList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
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

        private void gdvParticipantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Set Selected
            string id = gdvParticipantList.CurrentRow.Cells[0].Value.ToString();
            NoMeansNoWorldWide.roster_id = id;
            frmNoMeansNoAttendance frmNew = new frmNoMeansNoAttendance();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion Set Selected
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
            #endregion Load Parishes
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
