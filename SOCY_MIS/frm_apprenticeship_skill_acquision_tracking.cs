using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;
using PSAUtilsWin32;

namespace SOCY_MIS
{
    public partial class frm_apprenticeship_skill_acquision_tracking : UserControl
    {


        #region Variables
        DataTable dt = null;
        DataTable dtTrades = null;
        private frmResultArea01 frmPrt = null;
        frm_apprenticeship_skill_acquision_tracking_search frmApprenticesearch = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frm_apprenticeship_skill_acquision_tracking_search FormCallingSearch
        {
            get { return frmApprenticesearch; }
            set { frmApprenticesearch = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        public frm_apprenticeship_skill_acquision_tracking()
        {
            InitializeComponent();
        }

        private void frm_apprenticeship_skill_acquision_tracking_Load(object sender, EventArgs e)
        {
            Return_lookups();
            //LoadModules();
            LoadTrades();
            dtTrades = new DataTable();
            dtTrades.Columns.Add("tr_id", typeof(string));
            dtTrades.PrimaryKey = new DataColumn[] { dtTrades.Columns["tr_id"] };

            #region Load Display
            if (benApprenticeshipskillAquisitionTracking.asat_id != string.Empty)
            {
                Display(benApprenticeshipskillAquisitionTracking.asat_id);
            }

            #endregion Load Display
        }

        protected void LoadModules()
        {
            dt = benApprenticeshipskillAquisitionTracking.ReturnApprenticeshipTrades();
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["trd_id"] = "-1";
                emptyRow["trd_name"] = "Select Trade";
                dt.Rows.InsertAt(emptyRow, 0);

                cboModule.DataSource = dt;
                cboModule.DisplayMember = "trd_name";
                cboModule.ValueMember = "trd_id";
            }
        }

        protected void LoadTrades()
        {
            dt = benApprenticeshipskillAquisitionTracking.ReturnApprenticeshipTrades();
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["trd_id"] = "-1";
                emptyRow["trd_name"] = "Select Trade";
                dt.Rows.InsertAt(emptyRow, 0);

                cboTrade.DataSource = dt;
                cboTrade.DisplayMember = "trd_name";
                cboTrade.ValueMember = "trd_id";

                cboModule.DataSource = dt;
                cboModule.DisplayMember = "trd_name";
                cboModule.ValueMember = "trd_id";
            }
        }


        protected void LoadSkills(string trd_id)
        {
            gdvskillRating.Rows.Clear();

            dt = benApprenticeshipskillAquisitionTracking.ReturnApprenticeshipTradeSkill(trd_id);
            if (dt.Rows.Count > 0)
            {
                #region Clear Rows
                gdvskillRating.Rows.Clear();
                #endregion Clear Rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtRow = dt.Rows[i];
                    string trs_name = dtRow["trs_name"].ToString();
                    string trs_id = dtRow["trs_id"].ToString();

                    gdvskillRating.Rows.Add(trs_id, trs_name);

                    gdvskillRating.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvskillRating.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvskillRating.RowsDefaultCellStyle.BackColor = Color.LightGray;
                    gdvskillRating.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                    // Set the row and column header styles.
                    gdvskillRating.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    gdvskillRating.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                    gdvskillRating.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                    // Set the selection background color for all the cells.
                    gdvskillRating.DefaultCellStyle.SelectionBackColor = Color.White;
                    gdvskillRating.DefaultCellStyle.SelectionForeColor = Color.Black;

                    gdvskillRating.ColumnHeadersDefaultCellStyle.BackColor = Color.CadetBlue;
                    gdvskillRating.EnableHeadersVisualStyles = false;

                    foreach (DataGridViewColumn c in gdvskillRating.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                    }

                }
            }
        }

        protected bool SkillExists(string skill_id)
        {
            bool skillExists = false;
            foreach (DataGridViewRow row in gdvskillRating.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(skill_id))
                {
                    skillExists = true;
                }
                else
                {
                    //skillExists = false;

                }
            }

            return skillExists;
        }





        private void gdvskillRating_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (gdvskillRating.Rows.Count == 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == gdvskillRating.Columns["excelent_acquired"].Index)
            {
                DataGridViewCheckBoxCell chkExcellent = gdvskillRating.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkAverage = gdvskillRating.Rows[e.RowIndex].Cells[3] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkNotAcquired = gdvskillRating.Rows[e.RowIndex].Cells[4] as DataGridViewCheckBoxCell;

                if (chkExcellent.Value == chkExcellent.TrueValue)
                {
                    chkAverage.Value = chkAverage.FalseValue;
                    chkNotAcquired.Value = chkNotAcquired.FalseValue;
                }
            }
            else if (e.ColumnIndex == gdvskillRating.Columns["average_acquired"].Index)
            {
                DataGridViewCheckBoxCell chkExcellent = gdvskillRating.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkAverage = gdvskillRating.Rows[e.RowIndex].Cells[3] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkNotAcquired = gdvskillRating.Rows[e.RowIndex].Cells[4] as DataGridViewCheckBoxCell;

                if (chkAverage.Value == chkAverage.TrueValue)
                {
                    chkExcellent.Value = chkExcellent.FalseValue;
                    chkNotAcquired.Value = chkNotAcquired.FalseValue;
                }
            }
            else if (e.ColumnIndex == gdvskillRating.Columns["not_acquired"].Index)
            {
                DataGridViewCheckBoxCell chkExcellent = gdvskillRating.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkAverage = gdvskillRating.Rows[e.RowIndex].Cells[3] as DataGridViewCheckBoxCell;
                DataGridViewCheckBoxCell chkNotAcquired = gdvskillRating.Rows[e.RowIndex].Cells[4] as DataGridViewCheckBoxCell;

                if (chkNotAcquired.Value == chkNotAcquired.TrueValue)
                {
                    chkExcellent.Value = chkExcellent.FalseValue;
                    chkAverage.Value = chkAverage.FalseValue;
                }
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

            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;

            #endregion districts
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

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load SubCountys
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion Load SubCountys

            //returnHHMemberCodes();
            returnHHCodesByLocation();
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

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),cboParish.SelectedValue.ToString());

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hh_code";
            cboHHCode.ValueMember = "hh_id";

            #endregion HH Codes
        }

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            dt = benApprenticeshipskillAquisitionTracking.ReturnApprenticeshipMembers(cboHHCode.SelectedValue.ToString());

            DataRow hhmCode_emptyRow = dt.NewRow();
            hhmCode_emptyRow["hhm_id"] = "-1";
            hhmCode_emptyRow["hhm_name"] = "select household member";
            dt.Rows.InsertAt(hhmCode_emptyRow, 0);

            cboHHMemberName.DataSource = dt;

            cboHHMemberName.DisplayMember = "hhm_name";
            cboHHMemberName.ValueMember = "hhm_id";

        }

        private void cboModule_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSkills(cboModule.SelectedValue.ToString());

        }

        private void cboModule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHMemberName.SelectedValue.ToString() != "-1")
            {
                txtMemberCode.Text = benApprenticeshipskillAquisitionTracking.ReturnHHMemberCode(cboHHMemberName.SelectedValue.ToString());
            }
            else
            {
                txtMemberCode.Clear();
            }
        }

        protected void save()
        {
            #region Set Variables
            benApprenticeshipskillAquisitionTracking.wrd_id = cboParish.SelectedValue.ToString();
            benApprenticeshipskillAquisitionTracking.hhm_id = cboHHMemberName.SelectedValue.ToString();
            benApprenticeshipskillAquisitionTracking.review_date_from = dtReviewDatefrom.Value.Date;
            benApprenticeshipskillAquisitionTracking.review_date_to = dtReviewDateTo.Value.Date;
            benApprenticeshipskillAquisitionTracking.trade_id = cboTrade.SelectedValue.ToString();
            benApprenticeshipskillAquisitionTracking.module_id = cboModule.SelectedValue.ToString();
            benApprenticeshipskillAquisitionTracking.youth_acquire_not_acquire_skill_reason = txtnotAcquireReason.Text;
            benApprenticeshipskillAquisitionTracking.recommended_steps = txtSteps.Text;
            benApprenticeshipskillAquisitionTracking.artisan_name = txtArtisanName.Text;
            benApprenticeshipskillAquisitionTracking.artisan_report_date = dtArtisanReportDate.Value.Date;
            benApprenticeshipskillAquisitionTracking.youth_skills_acquired = txtYouthAcquiredSkills.Text;
            benApprenticeshipskillAquisitionTracking.yn_skill_not_acquired_well = utilControls.RadioButtonGetSelection(rdnSkillNotMasteredYes, rdnSkillNotMasteredNo);
            benApprenticeshipskillAquisitionTracking.skill_not_acquired_well = txtYouthSkillsNotMasteredText.Text;
            benApprenticeshipskillAquisitionTracking.youth_report_date = dtYouthReportDate.Value.Date;
            benApprenticeshipskillAquisitionTracking.skill_not_acquired_well_reason = txtSkillNotMasterReason.Text;
            benApprenticeshipskillAquisitionTracking.dyo_name = txtDYOName.Text;
            benApprenticeshipskillAquisitionTracking.dyo_review_date = dtDYOAppraisalDate.Value.Date;
            benApprenticeshipskillAquisitionTracking.usr_id_create = SystemConstants.user_id;
            benApprenticeshipskillAquisitionTracking.usr_id_update = SystemConstants.user_id;
            benApprenticeshipskillAquisitionTracking.usr_date_create = DateTime.Today;
            benApprenticeshipskillAquisitionTracking.usr_date_update = DateTime.Today;
            benApprenticeshipskillAquisitionTracking.ofc_id = SystemConstants.ofc_id;
            benApprenticeshipskillAquisitionTracking.district_id = SystemConstants.Return_office_district();
            #endregion Set Variables

            if (lblasat_id.Text == "lblasat_id")
            {
                benApprenticeshipskillAquisitionTracking.asat_id = Guid.NewGuid().ToString();
                lblasat_id.Text = benApprenticeshipskillAquisitionTracking.Save("insert");
                save_skill();
                MessageBox.Show("Success", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                benApprenticeshipskillAquisitionTracking.asat_id = benApprenticeshipskillAquisitionTracking.Save("update");
                save_skill();
                MessageBox.Show("Success", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    if (ValidateSkills())
                    {
                        save();
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all required values", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please fill in all required values", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        protected void save_skill()
        {
            #region Variables
            string skr_id = string.Empty;
            string module_id = string.Empty;
            string skill_id = string.Empty;
            string asat_id = string.Empty;
            #endregion Variables
            if (cboModule.SelectedValue.ToString() != "-1" && gdvskillRating.Rows.Count > 0)
            {
                for (int x = 0; x < gdvskillRating.Rows.Count; x++)
                {
                    #region skillRate
                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[2].Value))
                    {
                        benApprenticeshipskillAquisitionTracking.excellent_acquired_skr_id = SystemConstants.ExcellentlyAcquired;
                        benApprenticeshipskillAquisitionTracking.average_acquired_skr_id = string.Empty;
                        benApprenticeshipskillAquisitionTracking.not_acquired_skr_id = string.Empty;
                    }

                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[3].Value))
                    {
                        benApprenticeshipskillAquisitionTracking.average_acquired_skr_id = SystemConstants.AveragelyAcquired;
                        benApprenticeshipskillAquisitionTracking.excellent_acquired_skr_id = string.Empty;
                        benApprenticeshipskillAquisitionTracking.not_acquired_skr_id = string.Empty;
                    }

                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[4].Value))
                    {
                        benApprenticeshipskillAquisitionTracking.not_acquired_skr_id = SystemConstants.NotAcquired;
                        benApprenticeshipskillAquisitionTracking.excellent_acquired_skr_id = string.Empty;
                        benApprenticeshipskillAquisitionTracking.average_acquired_skr_id = string.Empty;
                    }
                    #endregion skillRate

                    module_id = cboModule.SelectedValue.ToString();
                    skill_id = gdvskillRating.Rows[x].Cells[0].Value.ToString();
                    benApprenticeshipskillAquisitionTracking.asat_id = lblasat_id.Text;
                    benApprenticeshipskillAquisitionTracking.module_id = module_id;
                    benApprenticeshipskillAquisitionTracking.skill_id = skill_id;
                    benApprenticeshipskillAquisitionTracking.asatskill_id = Guid.NewGuid().ToString();
                    benApprenticeshipskillAquisitionTracking.usr_id_create = SystemConstants.user_id;
                    benApprenticeshipskillAquisitionTracking.usr_id_update = SystemConstants.user_id;
                    benApprenticeshipskillAquisitionTracking.usr_date_create = DateTime.Today;
                    benApprenticeshipskillAquisitionTracking.usr_date_update = DateTime.Today;
                    benApprenticeshipskillAquisitionTracking.ofc_id = SystemConstants.ofc_id;
                    benApprenticeshipskillAquisitionTracking.district_id = SystemConstants.Return_office_district();

                    benApprenticeshipskillAquisitionTracking.Save_skills();

                    #region resetVariables
                    benApprenticeshipskillAquisitionTracking.skill_id = string.Empty;
                    benApprenticeshipskillAquisitionTracking.excellent_acquired_skr_id = string.Empty;
                    benApprenticeshipskillAquisitionTracking.average_acquired_skr_id = string.Empty;
                    benApprenticeshipskillAquisitionTracking.not_acquired_skr_id = string.Empty;
                    #endregion resetVariables

                }
            }
        }

        #region Display
        protected void Display(string asat_id)
        {
            dt = benApprenticeshipskillAquisitionTracking.Display(asat_id, "DisplayMain");
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["review_date_from"]);
                cboHHCode.SelectedValue = dtRow["hh_id"].ToString();
                cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                dtReviewDatefrom.Value = Convert.ToDateTime(dtRow["review_date_from"]);
                dtReviewDateTo.Value = Convert.ToDateTime(dtRow["review_date_to"]);
                cboTrade.SelectedValue = dtRow["trade_id"].ToString();
                cboModule.SelectedValue = dtRow["module_id"].ToString();
                cboModule_SelectionChangeCommitted(cboModule, null);
                txtnotAcquireReason.Text = dtRow["youth_acquire_not_acquire_skill_reason"].ToString();
                txtSteps.Text = dtRow["recommended_steps"].ToString();
                txtArtisanName.Text = dtRow["artisan_name"].ToString();
                dtArtisanReportDate.Value = Convert.ToDateTime(dtRow["artisan_report_date"]);
                txtYouthAcquiredSkills.Text = dtRow["youth_skills_acquired"].ToString();
                utilControls.RadioButtonSetSelection(rdnSkillNotMasteredYes, rdnSkillNotMasteredNo, dtRow["yn_skill_not_acquired_well"].ToString());
                txtYouthSkillsNotMasteredText.Text = dtRow["skill_not_acquired_well"].ToString();
                txtSkillNotMasterReason.Text = dtRow["skill_not_acquired_well_reason"].ToString();
                dtYouthReportDate.Value = Convert.ToDateTime(dtRow["youth_report_date"]);
                txtDYOName.Text = dtRow["dyo_name"].ToString();
                dtDYOAppraisalDate.Value = Convert.ToDateTime(dtRow["dyo_review_date"]);
                lblasat_id.Text = dtRow["asat_id"].ToString();


                #region set skill rating
                DisplayLine(asat_id);
                #endregion Set skill rating

                tlpDisplay01.Enabled = false;
                tlpDisplay02.Enabled = false;
                tlpDisplay03.Enabled = false;
                gdvskillRating.Enabled = false;
            }
        }

        protected void Clear()
        {
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            dtDate.Value = DateTime.Today;
            dtDate.Checked = false;
            cboHHCode.SelectedValue = "-1";
            cboHHMemberName.SelectedValue = "-1";
            dtReviewDatefrom.Value = DateTime.Today;
            dtReviewDateTo.Value = DateTime.Today;
            dtReviewDateTo.Checked = false;
            dtReviewDatefrom.Checked = false;
            cboTrade.SelectedValue = "-1";
            cboModule.SelectedValue = "-1";

            txtnotAcquireReason.Clear();
            txtSteps.Clear();
            txtArtisanName.Clear();
            dtArtisanReportDate.Value = DateTime.Today;
            dtArtisanReportDate.Checked = false;
            txtYouthAcquiredSkills.Clear();
            rdnSkillNotMasteredYes.Checked = false;
            rdnSkillNotMasteredNo.Checked = false;
            txtYouthSkillsNotMasteredText.Clear();
            txtSkillNotMasterReason.Clear();
            dtYouthReportDate.Value = DateTime.Today;
            dtYouthReportDate.Checked = false;
            txtDYOName.Clear();
            dtDYOAppraisalDate.Value = DateTime.Today;
            dtDYOAppraisalDate.Checked = false;
            lblasat_id.Text = "lblasat_id";
            gdvskillRating.Rows.Clear();
            benApprenticeshipskillAquisitionTracking.asat_id = string.Empty;

            tlpDisplay01.Enabled = true;
            tlpDisplay02.Enabled = true;
            tlpDisplay03.Enabled = true;
            gdvskillRating.Enabled = true;
        }

        protected void DisplayLine(string asat_id)
        {
            #region Variables
            string _excellent_acquired_skr_id = string.Empty;
            string _average_acquired_skr_id = string.Empty;
            string _not_acquired_skr_id = string.Empty;
            string _skill_id = string.Empty;
            string _gdvskill_id = string.Empty;
            DataRow dtRow = null;
            #endregion Variables

            dt = benApprenticeshipskillAquisitionTracking.Display(asat_id, "DisplayLine");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtRow = dt.Rows[i];
                    _skill_id = dtRow["skill_id"].ToString();

                    for (int x = 0; x < gdvskillRating.Rows.Count; x++)
                    {
                        _gdvskill_id = gdvskillRating.Rows[x].Cells["skill_id"].Value.ToString();
                        if (_skill_id.Equals(_gdvskill_id))
                        {
                            _excellent_acquired_skr_id = dtRow["excellent_acquired_skr_id"].ToString();
                            _average_acquired_skr_id = dtRow["average_acquired_skr_id"].ToString();
                            _not_acquired_skr_id = dtRow["not_acquired_skr_id"].ToString();

                            #region Set skill rating
                            if (_excellent_acquired_skr_id != string.Empty)
                            {
                                DataGridViewCheckBoxCell excellent_acquired_skr_id = (DataGridViewCheckBoxCell)gdvskillRating.Rows[x].Cells["excelent_acquired"];
                                excellent_acquired_skr_id.Value = true;
                            }
                            else if (_average_acquired_skr_id != string.Empty)
                            {
                                DataGridViewCheckBoxCell average_acquired_skr_id = (DataGridViewCheckBoxCell)gdvskillRating.Rows[x].Cells["average_acquired"];
                                average_acquired_skr_id.Value = true;
                            }
                            else if (_not_acquired_skr_id != string.Empty)
                            {
                                DataGridViewCheckBoxCell not_acquired_skr_id = (DataGridViewCheckBoxCell)gdvskillRating.Rows[x].Cells["not_acquired"];
                                not_acquired_skr_id.Value = true;
                            }
                            #endregion Set skill rating

                        }
                    }
                }
            }
        }
        #endregion Display

        private void cboTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboModule_SelectionChangeCommitted(cboModule, null);
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            lblasat_id.Text = "lblasat_id";
            benApprenticeshipskillAquisitionTracking.asat_id = string.Empty;
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tlpDisplay01.Enabled = true;
            tlpDisplay02.Enabled = true;
            tlpDisplay03.Enabled = true;
            gdvskillRating.Enabled = true;
        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if (cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" || cboParish.SelectedValue.ToString() == "-1" ||
                dtDate.Checked == false || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMemberName.SelectedValue.ToString() == "-1" || dtReviewDatefrom.Checked == false ||
                dtReviewDateTo.Checked == false || cboTrade.SelectedValue.ToString() == "-1" || cboModule.SelectedValue.ToString() == "-1" || dtArtisanReportDate.Checked == false ||
                dtYouthReportDate.Checked == false || (rdnSkillNotMasteredYes.Checked == false && rdnSkillNotMasteredNo.Checked == false) || dtDYOAppraisalDate.Checked == false)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateSkills()
        {
            bool isValid = false;

            #region Validate skills
            if (gdvskillRating.Rows.Count > 0)
            {
                for (int x = 0; x < gdvskillRating.Rows.Count; x++)
                {
                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[2].Value))
                    {
                        isValid = true;
                        break;

                    }
                    else if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[3].Value))
                    {
                        isValid = true;
                        break;
                    }
                    else if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[4].Value))
                    {
                        isValid = true;
                        break;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            #endregion Validate skills

            return isValid;
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            //returnHHMemberCodes();
            returnHHCodesByLocation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
