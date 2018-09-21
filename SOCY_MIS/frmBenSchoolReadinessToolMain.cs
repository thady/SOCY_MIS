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
    public partial class frmBenSchoolReadinessToolMain : UserControl
    {
        public frmBenSchoolReadinessToolMain()
        {
            InitializeComponent();
        }

        #region Variables
        DataTable dt = null;
        private frmEducationSubsidyMain frmPrt = null;
        #endregion Variables 

        #region # Property
        public frmEducationSubsidyMain FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property 

        private void frmBenSchoolReadinessToolMain_Load(object sender, EventArgs e)
        {
            Return_lookups();
            ReturnAssessmentList();
        }

        private void lnlAssessment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            benSchoolReadinessTool.edsr_id = string.Empty;
            frmBenSchoolReadinessTool frmNew = new frmBenSchoolReadinessTool();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search();
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

            //cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion districts

            #region IP
            dt = silcCommunityTrainingRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";
            #endregion IP

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

            #region CSO
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO

            #region Parish
            dt = hhHousehold_linkages_register.Return_lookups("parish");

            DataRow emptyParish = dt.NewRow();
            emptyParish["wrd_id"] = "-1";
            emptyParish["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(emptyParish, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            #endregion Parish

        } 

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

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
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion
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

        protected void ReturnAssessmentList()
        {
            dt = benSchoolReadinessTool.ReturnAssessmentList();
            if (dt.Rows.Count > 0)
            {
                gdvTrainingList.DataSource = dt;

                gdvTrainingList.Columns["edsr_id"].Visible = false;

                gdvTrainingList.Columns["dst_name"].HeaderText = "District";
                gdvTrainingList.Columns["sct_name"].HeaderText = "Sub County";
                gdvTrainingList.Columns["wrd_name"].HeaderText = "Parish";
                gdvTrainingList.Columns["hh_code"].HeaderText = "HH Code";
                gdvTrainingList.Columns["edsr_ass_date"].HeaderText = "Assessment Date";
                gdvTrainingList.Columns["beneficiary_name"].HeaderText = "Name";

                gdvTrainingList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvTrainingList.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvTrainingList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvTrainingList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvTrainingList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvTrainingList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvTrainingList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvTrainingList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvTrainingList.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvTrainingList.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        protected void Search()
        {
            dt = benSchoolReadinessTool.Search(cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),
            cboIP.SelectedValue.ToString(), cboCso.SelectedValue.ToString(), cboParish.SelectedValue.ToString(), txtHHCode.Text);

            if (dt.Rows.Count > 0)
            {
                gdvTrainingList.DataSource = dt;

                gdvTrainingList.Columns["edsr_id"].Visible = false;

                gdvTrainingList.Columns["dst_name"].HeaderText = "District";
                gdvTrainingList.Columns["sct_name"].HeaderText = "Sub County";
                gdvTrainingList.Columns["wrd_name"].HeaderText = "Parish";
                gdvTrainingList.Columns["hh_code"].HeaderText = "HH Code";
                gdvTrainingList.Columns["edsr_ass_date"].HeaderText = "Assessment Date";
                gdvTrainingList.Columns["beneficiary_name"].HeaderText = "Name";

                gdvTrainingList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvTrainingList.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvTrainingList.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvTrainingList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvTrainingList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvTrainingList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvTrainingList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvTrainingList.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvTrainingList.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvTrainingList.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
            else
            {
                gdvTrainingList.DataSource = dt;
            }
        }

        private void gdvTrainingList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvTrainingList.Rows.Count > 0)
            {
                string edsr_id = gdvTrainingList.CurrentRow.Cells["edsr_id"].Value.ToString();
                benSchoolReadinessTool.edsr_id = edsr_id;

                #region Set Selected
                frmBenSchoolReadinessTool frmNew = new frmBenSchoolReadinessTool();
                frmNew.FormCallingSearch = this;
                frmNew.FormMaster = FormParent.FormMaster;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion
            }
        }
    }
}
