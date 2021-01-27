using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmHouseholdTransferIssuesRegister : Form
    {
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        DataTable dt = new DataTable();
        public frmHouseholdTransferIssuesRegister()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                save();
            }
            else
            {
                MessageBox.Show("Issue name and action are required", "save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        protected void save()
        {
            #region Variables
            HouseholdTransfer.issue_desc = txtissuename.Text;
            HouseholdTransfer.issue_action_desc = txtissueaction.Text;
            HouseholdTransfer.issue_followup_info = txtissuefollowup.Text;
            HouseholdTransfer.usr_id_create = SystemConstants.user_id;
            HouseholdTransfer.usr_id_update = SystemConstants.user_id;
            HouseholdTransfer.usr_date_create = DateTime.Now;
            HouseholdTransfer.usr_date_update = DateTime.Now;
            HouseholdTransfer.ofc_id = SystemConstants.ofc_id;
            HouseholdTransfer.district_id = SystemConstants.Return_office_district();
            #endregion

            if(lblid.Text == "--")
            {
                HouseholdTransfer.issue_id = Guid.NewGuid().ToString();
                lblid.Text = HouseholdTransfer.issue_id;
                HouseholdTransfer.saveHouseholdIssue(dbCon);
                MessageBox.Show("Successfull saved household issue", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIssueListing(HouseholdTransfer.hh_tr_id);
            }
            else
            {
                HouseholdTransfer.issue_id = lblid.Text;
                HouseholdTransfer.updateHouseholdIssue(dbCon);
                MessageBox.Show("Successfull updated household issue", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIssueListing(HouseholdTransfer.hh_tr_id);
            }
        }

        protected void LoadIssueListing(string hh_tr_id)
        {
            dt = HouseholdTransfer.LoadHouseholdIssueListing(hh_tr_id);

            gdvList.DataSource = dt;

            gdvList.Columns["issue_id"].Visible = false;
            gdvList.Columns["issue_action_desc"].Visible = false;
            gdvList.Columns["issue_followup_info"].Visible = false;

            gdvList.Columns["issue_desc"].HeaderText = "Issue Description";

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

        private void frmHouseholdTransferIssuesRegister_Load(object sender, EventArgs e)
        {
            LoadIssueListing(HouseholdTransfer. hh_tr_id);
        }

        private void gdvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dt.Rows.Count > 0)
            {
                txtissuename.Text = gdvList.CurrentRow.Cells[1].Value.ToString();
                txtissueaction.Text = gdvList.CurrentRow.Cells[2].Value.ToString();
                txtissuefollowup.Text = gdvList.CurrentRow.Cells[3].Value.ToString();
                lblid.Text = gdvList.CurrentRow.Cells[0].Value.ToString();
            }
        }

        protected void Clear()
        {
            txtissuename.Clear();
            txtissueaction.Clear();
            txtissuefollowup.Clear();
            lblid.Text = "--";
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected bool ValidateInput()
        {
            bool isValid = false;
            if(txtissuename.Text == string.Empty || txtissueaction.Text == string.Empty)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
