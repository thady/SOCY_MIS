using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmViralLoadCommunityIAC : UserControl
    {
        #region Variables
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion

        public frmViralLoadCommunityIAC()
        {
            InitializeComponent();
        }

        private void frmViralLoadCommunityIAC_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadLists();
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


            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

        }

        protected void LoadLists()
        {
            #region  lst_non_supress_health_facility
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_health_facility");
            chkNonsupressHealthFacility.DataSource = dt;
            chkNonsupressHealthFacility.DisplayMember = "nsp_name";
            chkNonsupressHealthFacility.ValueMember = "nsp_id";
            #endregion lst_non_supress_health_facility

            #region  lst_non_supress_household
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_household");
            gdvNonsupressHousehold.DataSource = dt;
            gdvNonsupressHousehold.Columns["nsp_id"].Visible = false;
            gdvNonsupressHousehold.Columns["nsp_name"].HeaderText = "Reason for no suprression at household";

            DataGridViewCheckBoxColumn chk_select_reason = new DataGridViewCheckBoxColumn()
            {
                Name = "column_select",
                HeaderText = "Select Reason",
                FalseValue = 0,
                TrueValue = 1
            };
            this.gdvNonsupressHousehold.Columns.Insert(0, chk_select_reason);
            this.gdvNonsupressHousehold.Columns["column_select"].ReadOnly = false;
            this.gdvNonsupressHousehold.Columns["column_select"].Width = 100;
            this.gdvNonsupressHousehold.DefaultCellStyle.SelectionBackColor = Color.White;
            this.gdvNonsupressHousehold.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.gdvNonsupressHousehold.RowsDefaultCellStyle.BackColor = Color.LightGray;
            this.gdvNonsupressHousehold.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.gdvNonsupressHousehold.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.gdvNonsupressHousehold.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressHousehold.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressHousehold.DefaultCellStyle.SelectionBackColor = Color.Cyan;
            this.gdvNonsupressHousehold.DefaultCellStyle.SelectionForeColor = Color.Black;

            #endregion lst_non_supress_household

            #region  lst_non_supress_household
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_action");
            gdvNonsupressAction.DataSource = dt;
            gdvNonsupressAction.Columns["nspa_id"].Visible = false;
            gdvNonsupressAction.Columns["nspa_name"].HeaderText = "Actions Taken";


          DataGridViewCheckBoxColumn _chk_select_reason = new DataGridViewCheckBoxColumn()
            {
                Name = "column_select",
                HeaderText = "Select Action",
                FalseValue = 0,
                TrueValue = 1
            };

            var gdvCombo = new DataGridViewComboBoxColumn()
            {
                Name = "cboProgress"
            };
            gdvCombo.DataSource = new string[] { "Completed", "Pending", "Ongoing" };
            // dgv.Columns.Add(gdvCombo);

            var gdv_person = new DataGridViewTextBoxColumn()
            {
                Name = "txtperson"
            };

            //this.gdvNonsupressAction.Columns["nspa_name"].Width = 200;
            this.gdvNonsupressAction.Columns.Insert(0, _chk_select_reason);
            this.gdvNonsupressAction.Columns["column_select"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["column_select"].Width = 100;
     
            this.gdvNonsupressAction.Columns["time_line"].Width = 150;
            this.gdvNonsupressAction.Columns["time_line"].HeaderText = "TimeLine";

            this.gdvNonsupressAction.Columns.Insert(4, gdvCombo);
            this.gdvNonsupressAction.Columns["cboProgress"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["cboProgress"].Width = 100;
            this.gdvNonsupressAction.Columns["cboProgress"].HeaderText = "Progress";

            this.gdvNonsupressAction.Columns.Insert(5, gdv_person);
            this.gdvNonsupressAction.Columns["txtperson"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["txtperson"].Width = 100;
            this.gdvNonsupressAction.Columns["txtperson"].HeaderText = "Responsible Person";

            this.gdvNonsupressAction.DefaultCellStyle.SelectionBackColor = Color.White;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.gdvNonsupressAction.RowsDefaultCellStyle.BackColor = Color.LightGray;
            this.gdvNonsupressAction.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.gdvNonsupressAction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.gdvNonsupressAction.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressAction.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionBackColor = Color.Cyan;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionForeColor = Color.Black;

            #endregion lst_non_supress_household
        }
    }
}
