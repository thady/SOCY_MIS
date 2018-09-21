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
    public partial class frmSubCountyOVCChecklistSearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private frmResultArea02 frmPrt = null;
        private bool pblnSearched = false;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmSubCountyOVCChecklistSearch()
        {
            InitializeComponent();
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmSubcountyOVCChecklist frmNew = new frmSubcountyOVCChecklist();
            frmNew.FormCalling = this;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        protected void Return_lookups()
        {
            #region district
            dt = prtSubCountyOVCChecklist.Return_lookups("district");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["dst_id"] = "-1";
                ipemptyRow["dst_name"] = "Select district";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbDistrict.DataSource = dt;
                cbDistrict.DisplayMember = "dst_name";
                cbDistrict.ValueMember = "dst_id";

            }
            #endregion district

            #region quarter
            dt = prtSubCountyOVCChecklist.Return_lookups("quarter");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["qy_id"] = "-1";
                ipemptyRow["qy_name"] = "Select quarter";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbQuarter.DataSource = dt;
                cbQuarter.DisplayMember = "qy_name";
                cbQuarter.ValueMember = "qy_id";

            }
            #endregion quarter

            #region FY
            dt = prtSubCountyOVCChecklist.Return_lookups("fy");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["fy_id"] = "-1";
                ipemptyRow["fy_name"] = "Select FY";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbFinancialYear.DataSource = dt;
                cbFinancialYear.DisplayMember = "fy_name";
                cbFinancialYear.ValueMember = "fy_id";

            }
            #endregion FY
        }

        private void frmSubCountyOVCChecklistSearch_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadSOVCCRecords("Load");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSOVCCRecords("search");
        }

        #region Load display
        protected void LoadSOVCCRecords(string action )
        {
            if (action == "Load")
            {
                dt = prtSubCountyOVCChecklist.LoadSOVCCRecords();
                if (dt != null)
                {
                    dgvRegister.DataSource = dt;

                    dgvRegister.Columns["soc_id"].Visible = false;
                    dgvRegister.Columns["ofc_id"].Visible = false;

                    dgvRegister.Columns["dst_name"].HeaderText = "District";
                    dgvRegister.Columns["qy_name"].HeaderText = "Quarter";
                    dgvRegister.Columns["fy_name"].HeaderText = "Financial Year";
                    dgvRegister.Columns["soc_date"].HeaderText = "Date";

                    dgvRegister.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgvRegister.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dgvRegister.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    dgvRegister.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    dgvRegister.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvRegister.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dgvRegister.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    dgvRegister.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgvRegister.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            else if (action == "search")
            {
                #region Dates
                if (dtpDateBegin.Checked == true) { prtSubCountyOVCChecklist.beginDate = dtpDateBegin.Value.Date; }
                else
                {
                    prtSubCountyOVCChecklist.beginDate = null;
                }

                if (dtpDateEnd.Checked == true) { prtSubCountyOVCChecklist.endDate = dtpDateEnd.Value.Date; }
                else
                {
                    prtSubCountyOVCChecklist.endDate = null;
                }
                #endregion Dates

                dt = prtSubCountyOVCChecklist.Search(cbDistrict.SelectedValue.ToString() != "-1" ? cbDistrict.SelectedValue.ToString() : "-1", cbQuarter.SelectedValue.ToString() != "-1" ? cbQuarter.SelectedValue.ToString() : "-1",
                    cbFinancialYear.SelectedValue.ToString() != "-1" ? cbFinancialYear.SelectedValue.ToString() : "-1", prtSubCountyOVCChecklist.beginDate, prtSubCountyOVCChecklist.endDate);
                if (dt != null)
                {
                    dgvRegister.DataSource = dt;

                    dgvRegister.Columns["soc_id"].Visible = false;
                    dgvRegister.Columns["ofc_id"].Visible = false;

                    dgvRegister.Columns["dst_name"].HeaderText = "District";
                    dgvRegister.Columns["qy_name"].HeaderText = "Quarter";
                    dgvRegister.Columns["fy_name"].HeaderText = "Financial Year";
                    dgvRegister.Columns["soc_date"].HeaderText = "Date";

                    dgvRegister.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgvRegister.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dgvRegister.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    dgvRegister.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    dgvRegister.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvRegister.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    dgvRegister.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    dgvRegister.DefaultCellStyle.SelectionBackColor = Color.White;
                    dgvRegister.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
           
            #endregion
        }

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegister.Rows.Count > 0)
            {
                string soc_id = dgvRegister.CurrentRow.Cells["soc_id"].Value.ToString();
                prtSubCountyOVCChecklist.soc_id = soc_id;

                #region Set Selected
                frmSubcountyOVCChecklist frmNew = new frmSubcountyOVCChecklist();
                frmNew.FormCalling = this;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }
    }
}
