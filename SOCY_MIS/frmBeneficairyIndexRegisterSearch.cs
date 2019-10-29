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
    public partial class frmBeneficairyIndexRegisterSearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private frmHouseholdSearch frmCllNew = null;
        private frmOVCIdentificationPrioritizationSearch frmCllSearch = null;
        private frmResultArea02 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmHouseholdSearch FormCallingNew
        {
            get { return frmCllNew; }
            set { frmCllNew = value; }
        }

        public frmOVCIdentificationPrioritizationSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        public frmBeneficairyIndexRegisterSearch()
        {
            InitializeComponent();
        }

        private void frmBeneficairyIndexRegisterSearch_Load(object sender, EventArgs e)
        {
            LoadIndexCategory();
            Return_lookups();
            LoadList();
        }

        private void llblNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmBeneficairyIndexRegister frmNew = new frmBeneficairyIndexRegister();
            frmNew.FormCallingNew = this; 
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            if (FormCalling != null)
            {
                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormCallingNew != null)
            {
                FormCallingNew.BackDisplay();
                FormMaster.LoadControl(FormCallingNew, this.Name, false);
            }
            else if (FormCallingSearch != null)
            {
                FormCallingSearch.BackDisplay();
                FormParent.LoadControl(FormCallingSearch, this.Name);
            }
        }

        protected void LoadList()
        {
            dt = benIndexRegistration.LoadList();

            gdvList.DataSource = dt;
            gdvList.Columns["ibr_id"].Visible = false;

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

        protected void Return_lookups()
        {
            //districts
            DataTable dt = hhHousehold_linkages_register.Return_lookups("district");
            DataRow dtNewRow_dst = dt.NewRow();
            dtNewRow_dst["dst_name"] = "select one";
            dtNewRow_dst["dst_id"] = "-1";
            dt.Rows.InsertAt(dtNewRow_dst, 0);
            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            //subcounty
            DataTable dt_sct = hhHousehold_linkages_register.Return_lookups("subcounty");
            DataRow dtNewRow = dt_sct.NewRow();
            dtNewRow["sct_name"] = "select one";
            dtNewRow["sct_id"] = "-1";
            dt_sct.Rows.InsertAt(dtNewRow, 0);
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            cboSubCounty.DataSource = dt_sct;

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");

            DataRow dtNewRow_parish = dt.NewRow();
            dtNewRow_parish["wrd_name"] = "select one";
            dtNewRow_parish["wrd_id"] = "-1";
            dt.Rows.InsertAt(dtNewRow_parish, 0);
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";
            cboParish.DataSource = dt;
        }

        protected void LoadIndexCategory()
        {
            dt = benIndexRegistration.ReturnIndexCategory();
            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["cat_id"] = "-1";
            sctemptyRow["cat_name"] = "Select category";
            dt.Rows.InsertAt(sctemptyRow, 0);
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "cat_name";
            cboCategory.ValueMember = "cat_id";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void Search()
        {
            dt = benIndexRegistration.Search(cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboParish.SelectedValue.ToString(), cboEntryPoint.Text, cboCategory.SelectedValue.ToString(), txtname.Text);

            gdvList.DataSource = dt;
            gdvList.Columns["ibr_id"].Visible = false;

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
            if (gdvList.Rows.Count > 0)
            {
                string id = gdvList.CurrentRow.Cells[0].Value.ToString();

                #region Set Selected
                frmBeneficairyIndexRegister frmNew = new frmBeneficairyIndexRegister();
                frmNew.FormCallingNew = this;
                frmNew.FormMaster = FormMaster;
                frmNew.ObjectId = id;
                FormMaster.LoadControl(frmNew, this.Name, false);
                #endregion
            }
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
    }
}
