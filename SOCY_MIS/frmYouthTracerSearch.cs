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
    public partial class frmYouthTracerSearch : UserControl
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
        public frmYouthTracerSearch()
        {
            InitializeComponent();
        }

        private void frmYouthTracerSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadDisplay();
        }

        private void lnlAssessment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            benYouthTracer.ytr_id = string.Empty;
            frmYouthTracer frmNew = new frmYouthTracer();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
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
            #endregion CSO
        }

        protected void LoadDisplay()
        {
            dt = benYouthTracer.LoadDisplay("list",string.Empty);
            if (dt.Rows.Count > 0)
            {
                gdvYouthList.DataSource = dt;
                gdvYouthList.Columns["ytr_id"].Visible = false;

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

                gdvYouthList.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdvYouthList.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdvYouthList.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            #endregion subcounty
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

        #region Search
        protected void Search()
        {
            dt = benYouthTracer.Search(cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboIP.SelectedValue.ToString(), cboCso.SelectedValue.ToString(), txtYouthName.Text, txtHHCode.Text);

            if (dt.Rows.Count > 0)
            {
                gdvYouthList.DataSource = dt;
                gdvYouthList.Columns["ytr_id"].Visible = false;

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

                gdvYouthList.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                gdvYouthList.EnableHeadersVisualStyles = false;

                foreach (DataGridViewColumn c in gdvYouthList.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
            else
            {
                gdvYouthList.DataSource = dt;
            }
        }
        #endregion Search

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void gdvYouthList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gdvYouthList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvYouthList.Rows.Count > 0)
            {

                #region Set Selected
                benYouthTracer.ytr_id = gdvYouthList.CurrentRow.Cells[0].Value.ToString();
                frmYouthTracer frmNew = new frmYouthTracer();
                frmNew.FormCallingSearch = this;
                frmNew.FormMaster = FormParent.FormMaster;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }
    }
}
