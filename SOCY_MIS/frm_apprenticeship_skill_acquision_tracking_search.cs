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
    public partial class frm_apprenticeship_skill_acquision_tracking_search : UserControl
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
        public frm_apprenticeship_skill_acquision_tracking_search()
        {
            InitializeComponent();
        }

        private void frm_apprenticeship_skill_acquision_tracking_search_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadDisplay();
        }

        private void lblNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frm_apprenticeship_skill_acquision_tracking frmNew = new frm_apprenticeship_skill_acquision_tracking();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        protected void LoadDisplay()
        {
            dt = benApprenticeshipskillAquisitionTracking.Display(string.Empty, "LoadList");
            if (dt.Rows.Count > 0)
            {
                gdvApprenticeSearch.DataSource = dt;
                gdvApprenticeSearch.Columns["asat_id"].Visible = false;

                gdvApprenticeSearch.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvApprenticeSearch.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvApprenticeSearch.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvApprenticeSearch.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvApprenticeSearch.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvApprenticeSearch.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvApprenticeSearch.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdvApprenticeSearch.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdvApprenticeSearch.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
        }

        private void gdvApprenticeSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvApprenticeSearch.Rows.Count > 0)
            {
                string asat_id = gdvApprenticeSearch.CurrentRow.Cells["asat_id"].Value.ToString();
                benApprenticeshipskillAquisitionTracking.asat_id = asat_id;

                #region Set Selected
                frm_apprenticeship_skill_acquision_tracking frmNew = new frm_apprenticeship_skill_acquision_tracking();
                frmNew.FormCallingSearch = this;
                frmNew.FormMaster = FormParent.FormMaster;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }

        protected void Return_lookups()
        {
            #region districts
            dt = benYouthTrainingInventory.Return_lookups("district", string.Empty, string.Empty, string.Empty); //reused

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["dst_id"] = "-1";
            dstemptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboDistrictSearch.DisplayMember = "dst_name";
            cboDistrictSearch.ValueMember = "dst_id";
            cboDistrictSearch.DataSource = dt;

            cboDistrictSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrictSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion districts

            #region IP
            dt = benYouthTrainingInventory.Return_lookups("IP", string.Empty, string.Empty, string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIPSearch.DataSource = dt;
            cboIPSearch.DisplayMember = "prt_name";
            cboIPSearch.ValueMember = "prt_id";
            #endregion IP

            #region subcounty
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
            #endregion subcounty

            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIPSearch.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCSOSearch.DataSource = dt;
            cboCSOSearch.DisplayMember = "cso_other";
            cboCSOSearch.ValueMember = "cso_id";
            #endregion CSO
        }

        private void cboIPSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIPSearch.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCSOSearch.DataSource = dt;
            cboCSOSearch.DisplayMember = "cso_other";
            cboCSOSearch.ValueMember = "cso_id";
            #endregion CSO
        }

        private void cboDistrictSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
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
            #endregion subcounty
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void Search()
        {
            dt = benApprenticeshipskillAquisitionTracking.Search(cboDistrictSearch.SelectedValue.ToString(), cboSubcountySearch.SelectedValue.ToString(), cboIPSearch.SelectedValue.ToString(), cboCSOSearch.SelectedValue.ToString(), txtYouthnameSearch.Text, txtHHCode.Text);

            if (dt.Rows.Count > 0)
            {
                gdvApprenticeSearch.DataSource = dt;
                gdvApprenticeSearch.Columns["asat_id"].Visible = false;

                gdvApprenticeSearch.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvApprenticeSearch.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvApprenticeSearch.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvApprenticeSearch.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvApprenticeSearch.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvApprenticeSearch.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvApprenticeSearch.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvApprenticeSearch.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdvApprenticeSearch.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdvApprenticeSearch.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
            else
            {
                gdvApprenticeSearch.DataSource = dt;
            }
        }

       
    }
}
