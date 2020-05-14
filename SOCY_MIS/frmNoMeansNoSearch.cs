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
    public partial class frmNoMeansNoSearch : UserControl
    {
        public frmNoMeansNoSearch()
        {
            InitializeComponent();
        }

        private void frmNoMeansNoSearch_Load(object sender, EventArgs e)
        {
            LoadDisplay();
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
            switch (NoMeansNoWorldWide.NMNToolType)
            {
                case "1":
                    NoMeansNoWorldWide.record_id = string.Empty;
                    #region Set Selected
                    frmNoMeansNoBoys frmNew = new frmNoMeansNoBoys();
                    frmNew.FormCallingSearch = this;
                    frmNew.FormMaster = FormParent.FormMaster;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                    #endregion
                    break;
                case "2":
                    NoMeansNoWorldWide.record_id = string.Empty;
                    #region Set Selected
                    frmNoMeansNoGirls frmNewGirl = new frmNoMeansNoGirls();
                    frmNewGirl.FormCallingSearch = this;
                    frmNewGirl.FormMaster = FormParent.FormMaster;
                    frmNewGirl.FormParent = FormParent;
                    FormParent.LoadControl(frmNewGirl, this.Name);
                    #endregion
                    break;
            }
            
        }

        protected void LoadRecordListBoys()
        {
            dt = NoMeansNoWorldWide.LoadNMNRecordListBoys();

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["record_id"].Visible = false;

            gdvParticipantList.Columns["nmn_id"].HeaderText = "NMN Unique Identifier";
            gdvParticipantList.Columns["yn_direct_ben"].HeaderText = "SOCY Beneficiary?";
            gdvParticipantList.Columns["hhm_code"].HeaderText = "SOCY Beneficiary Code";
            gdvParticipantList.Columns["age"].HeaderText = "Participant Age";
            gdvParticipantList.Columns["date"].HeaderText = "Date of survey";
            gdvParticipantList.Columns["pre_post"].HeaderText = "Pre or Post survey?";
            gdvParticipantList.Columns["grp_name"].HeaderText = "Partcipant Group Name";
            gdvParticipantList.Columns["instructor_name"].HeaderText = "Group Instructor's Name";

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


        protected void SearchRecordListBoys(string hh_code, string nmn_id)
        {
            dt = NoMeansNoWorldWide.SearchNMNRecordListBoys(hh_code,nmn_id);

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["record_id"].Visible = false;

            gdvParticipantList.Columns["nmn_id"].HeaderText = "NMN Unique Identifier";
            gdvParticipantList.Columns["hhm_code"].HeaderText = "SOCY Beneficiary Code";
            gdvParticipantList.Columns["age"].HeaderText = "Participant Age";
            gdvParticipantList.Columns["date"].HeaderText = "Date of survey";
            gdvParticipantList.Columns["pre_post"].HeaderText = "Pre or Post survey?";
            gdvParticipantList.Columns["grp_name"].HeaderText = "Partcipant Group Name";
            gdvParticipantList.Columns["instructor_name"].HeaderText = "Group Instructor's Name";

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


        protected void LoadRecordListGirls()
        {
            dt = NoMeansNoWorldWide.LoadNMNRecordListGirls();

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["record_id"].Visible = false;

            gdvParticipantList.Columns["nmn_id"].HeaderText = "NMN Unique Identifier";
            gdvParticipantList.Columns["yn_direct_ben"].HeaderText = "SOCY Beneficiary?";
            gdvParticipantList.Columns["hhm_code"].HeaderText = "SOCY Beneficiary Code";
            gdvParticipantList.Columns["age"].HeaderText = "Participant Age";
            gdvParticipantList.Columns["date"].HeaderText = "Date of survey";
            gdvParticipantList.Columns["pre_post"].HeaderText = "Pre or Post survey?";
            gdvParticipantList.Columns["grp_name"].HeaderText = "Partcipant Group Name";
            gdvParticipantList.Columns["instructor_name"].HeaderText = "Group Instructor's Name";

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


        protected void SearchRecordListGirls(string hh_code, string nmn_id)
        {
            dt = NoMeansNoWorldWide.SearchNMNRecordListGirls(hh_code, nmn_id);

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["record_id"].Visible = false;

            gdvParticipantList.Columns["nmn_id"].HeaderText = "NMN Unique Identifier";
            gdvParticipantList.Columns["hhm_code"].HeaderText = "SOCY Beneficiary Code";
            gdvParticipantList.Columns["age"].HeaderText = "Participant Age";
            gdvParticipantList.Columns["date"].HeaderText = "Date of survey";
            gdvParticipantList.Columns["pre_post"].HeaderText = "Pre or Post survey?";
            gdvParticipantList.Columns["grp_name"].HeaderText = "Partcipant Group Name";
            gdvParticipantList.Columns["instructor_name"].HeaderText = "Group Instructor's Name";

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

        protected void LoadDisplay()
        {
            switch (NoMeansNoWorldWide.NMNToolType)
            {
                case "1":
                        LoadRecordListBoys();
                        lblHeader.Text = "Sources of Strength Pre / Post Test";
                    break;
                case "2":
                    LoadRecordListGirls(); 
                    lblHeader.Text = "Girls Empowerment Self Defense Pre / Post Test";
                    break;
            }
            
        }

        private void gdvParticipantList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void gdvParticipantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvParticipantList.Rows.Count > 0)
            {
                NoMeansNoWorldWide.record_id = gdvParticipantList.CurrentRow.Cells[0].Value.ToString();

                if (NoMeansNoWorldWide.NMNToolType == NoMeansNoWorldWide.NMNBoys)
                {
                    #region Set Selected
                    frmNoMeansNoBoys frmNew = new frmNoMeansNoBoys();
                    frmNew.FormCallingSearch = this;
                    frmNew.FormMaster = FormParent.FormMaster;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                    #endregion
                }
                else
                {
                    #region Set Selected
                    frmNoMeansNoGirls frmNew = new frmNoMeansNoGirls();
                    frmNew.FormCallingSearch = this;
                    frmNew.FormMaster = FormParent.FormMaster;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                    #endregion
                }

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            switch (NoMeansNoWorldWide.NMNToolType)
            {
                case "1":
                    SearchRecordListBoys(txtHHCode.Text, txtNMNID.Text);
                    break;
                case "2":
                    SearchRecordListGirls(txtHHCode.Text, txtNMNID.Text);
                    break;
            }
        }
    }
}
