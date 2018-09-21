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
    public partial class frmYouthTrainingCompletion : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmYouthTrainingCompletionSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public frmYouthTrainingCompletionSearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        public frmYouthTrainingCompletion()
        {
            InitializeComponent();
        }

        private void frmYouthTrainingCompletion_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadTrades();
            LoadDisplay(ben_youth_training_completion.ytc_id);
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

            cboprt.DataSource = dt;
            cboprt.DisplayMember = "prt_name";
            cboprt.ValueMember = "prt_id";
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
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboprt.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO

            #region Gender
            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow gender_emptyRow = dt.NewRow();
            gender_emptyRow["gnd_id"] = "-1";
            gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(gender_emptyRow, 0);

            cboSex.DataSource = dt;
            cboSex.DisplayMember = "gnd_name";
            cboSex.ValueMember = "gnd_id";
            #endregion Gender

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

        }

        private void cboprt_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboprt.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

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
            #endregion Load SubCountys
        }

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboParish.SelectedValue.ToString());  //reused

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hh_code";
            cboHHCode.ValueMember = "hh_id";
            #endregion HH Codes
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = benSchoolReadinessTool.ReturnHHMembers(cboHHCode.SelectedValue.ToString(), "hhm_all"); //reused

            DataRow hhmCode_emptyRow = dt.NewRow();
            hhmCode_emptyRow["hhm_id"] = "-1";
            hhmCode_emptyRow["hhm_name"] = "select member";
            dt.Rows.InsertAt(hhmCode_emptyRow, 0);

            cboHHMemberName.DataSource = dt;

            cboHHMemberName.DisplayMember = "hhm_name";
            cboHHMemberName.ValueMember = "hhm_id";
        }

        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = ben_youth_training_completion.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                string YOB = dtRow["hhm_year_of_birth"].ToString();
                txtMemberCode.Text = dtRow["hhm_code"].ToString();
                #region Age
                if (YOB != string.Empty)
                {
                    DateTime Year = DateTime.Now;
                    int yr = Year.Year;
                    txtAge.Text = (yr - Convert.ToInt32(YOB)).ToString();
                }
                else
                {
                    txtAge.Clear();
                }
                #endregion Age


            }
        }

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMDetails(cboHHMemberName.SelectedValue.ToString());
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

        private void cboTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSkills(cboTrade.SelectedValue.ToString());
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

        #region Save

        protected void save()
        {
            ben_youth_training_completion.prt_id = cboprt.SelectedValue.ToString();
            ben_youth_training_completion.cso_id = cboCso.SelectedValue.ToString();
            ben_youth_training_completion.wrd_id = cboParish.SelectedValue.ToString();
            ben_youth_training_completion.date = dtDate.Value;
            ben_youth_training_completion.hh_id = cboHHCode.SelectedValue.ToString();
            ben_youth_training_completion.hhm_id = cboHHMemberName.SelectedValue.ToString();
            ben_youth_training_completion.hhm_tel = txtPhone.Text;
            ben_youth_training_completion.yfo_name = txtYFOName.Text;
            ben_youth_training_completion.y_adress = txtAdress.Text;
            ben_youth_training_completion.skills_learnt = txtPracticalSkillsLearnt.Text;
            ben_youth_training_completion.skills_more_training = txtSkillsMissing.Text;
            ben_youth_training_completion.yn_id_graduate = utilControls.RadioButtonGetSelection(rdnGradReadyYes, rdnGradReadyNo);
            ben_youth_training_completion.yn_id_graduate_no_reason = txtrdnGradReadyNoReason.Text;
            ben_youth_training_completion.artisan_rating = cboArtisanRating.Text;
            ben_youth_training_completion.yn_id_fam_support = utilControls.RadioButtonGetSelection(rdnFamilySupportYes, rdnFamilySupportNo);
            ben_youth_training_completion.yn_id_fam_support_yes_how = txtrdnFamilySupportYes.Text;
            ben_youth_training_completion.yn_id_fam_support_no_reason = txtrdnFamilySupportNoReason.Text;
            ben_youth_training_completion.yn_id_training_challenges = utilControls.RadioButtonGetSelection(rdnChallengesYes, rdnChallengesNo);
            ben_youth_training_completion.yn_id_training_challenges_yes_list = txtrdbChallengesYesMention.Text;
            ben_youth_training_completion.yn_id_earn_money = utilControls.RadioButtonGetSelection(rdnEarnYes, rdnEarnNo);
            ben_youth_training_completion.yn_id_earn_money_yes_weekly_amt = txtrdnEarnYesAmount.Text;
            ben_youth_training_completion.plan_after_training = txtPlanAfterTraining.Text;
            ben_youth_training_completion.youth_rate_attendance = num1.Value.ToString();
            ben_youth_training_completion.youth_rate_commitment = num2.Value.ToString();
            ben_youth_training_completion.youth_rate_participation = num3.Value.ToString();
            ben_youth_training_completion.youth_rate_comprehension = num4.Value.ToString();
            ben_youth_training_completion.module_id = cboTrade.SelectedValue.ToString();
            ben_youth_training_completion.yn_id_retain_youth = utilControls.RadioButtonGetSelection(rdnRetainYouthYes, rdnRetainYouthNo);
            ben_youth_training_completion.yn_id_retain_youth_no_recommend = txtrdnRetainYouthNoRecommend.Text;
            ben_youth_training_completion.yn_id_open_own_biz = utilControls.RadioButtonGetSelection(rdnOwnbusinessYes, rdnOwnbusinessNo);
            ben_youth_training_completion.usr_id_create = SystemConstants.user_id;
            ben_youth_training_completion.usr_id_update = SystemConstants.user_id;
            ben_youth_training_completion.usr_date_create = DateTime.Now;
            ben_youth_training_completion.usr_date_update = DateTime.Now;
            ben_youth_training_completion.ofc_id = SystemConstants.ofc_id;
            ben_youth_training_completion.district_id = SystemConstants.Return_office_district();

            if (ben_youth_training_completion.ytc_id == string.Empty)
            {
                ben_youth_training_completion.ytc_id = Guid.NewGuid().ToString();
                ben_youth_training_completion.Save("insert");
                save_skill();
                MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ben_youth_training_completion.Save("update");
                save_skill();
                MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cboTrade.SelectedValue.ToString() != "-1" && gdvskillRating.Rows.Count > 0)
            {
                for (int x = 0; x < gdvskillRating.Rows.Count; x++)
                {
                    #region skillRate
                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[2].Value))
                    {
                        ben_youth_training_completion.excellent_acquired_skr_id = SystemConstants.ExcellentlyAcquired;
                        ben_youth_training_completion.average_acquired_skr_id = string.Empty;
                        ben_youth_training_completion.not_acquired_skr_id = string.Empty;
                    }

                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[3].Value))
                    {
                        ben_youth_training_completion.average_acquired_skr_id = SystemConstants.AveragelyAcquired;
                        ben_youth_training_completion.excellent_acquired_skr_id = string.Empty;
                        ben_youth_training_completion.not_acquired_skr_id = string.Empty;
                    }

                    if (Convert.ToBoolean(gdvskillRating.Rows[x].Cells[4].Value))
                    {
                        ben_youth_training_completion.not_acquired_skr_id = SystemConstants.NotAcquired;
                        ben_youth_training_completion.excellent_acquired_skr_id = string.Empty;
                        ben_youth_training_completion.average_acquired_skr_id = string.Empty;
                    }
                    #endregion skillRate

                    module_id = cboTrade.SelectedValue.ToString();
                    skill_id = gdvskillRating.Rows[x].Cells[0].Value.ToString();
                    ben_youth_training_completion.module_id = module_id;
                    ben_youth_training_completion.skill_id = skill_id;
                    ben_youth_training_completion.ytc_skill_id = Guid.NewGuid().ToString();
                    ben_youth_training_completion.usr_id_create = SystemConstants.user_id;
                    ben_youth_training_completion.usr_id_update = SystemConstants.user_id;
                    ben_youth_training_completion.usr_date_create = DateTime.Today;
                    ben_youth_training_completion.usr_date_update = DateTime.Today;
                    ben_youth_training_completion.ofc_id = SystemConstants.ofc_id;
                    ben_youth_training_completion.district_id = SystemConstants.Return_office_district();

                    ben_youth_training_completion.Save_skills();

                    #region resetVariables
                    ben_youth_training_completion.skill_id = string.Empty;
                    ben_youth_training_completion.excellent_acquired_skr_id = string.Empty;
                    ben_youth_training_completion.average_acquired_skr_id = string.Empty;
                    ben_youth_training_completion.not_acquired_skr_id = string.Empty;
                    #endregion resetVariables

                }
            }
        }
        #endregion Save

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    if (ValidateSkills())
                    {
                        save();
                        Clear();
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

        #region Display
        protected void LoadDisplay(string yct_id)
        {
            if (yct_id != string.Empty)
            {
                dt = ben_youth_training_completion.Display(yct_id, "DisplayMain");
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboprt.SelectedValue = dtRow["prt_id"].ToString();
                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboCso.SelectedValue = dtRow["cso_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    dtDate.Value = Convert.ToDateTime(dtRow["date"]);
                    cboHHCode.SelectedValue = dtRow["hh_id"].ToString();
                    cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                    txtPhone.Text = dtRow["hhm_tel"].ToString();
                    txtYFOName.Text = dtRow["yfo_name"].ToString();
                    txtAdress.Text = dtRow["y_adress"].ToString();
                    txtPracticalSkillsLearnt.Text = dtRow["skills_learnt"].ToString();
                    txtSkillsMissing.Text = dtRow["skills_more_training"].ToString();
                    utilControls.RadioButtonSetSelection(rdnGradReadyYes, rdnGradReadyNo, dtRow["yn_id_graduate"].ToString());
                    txtrdnGradReadyNoReason.Text = dtRow["yn_id_graduate_no_reason"].ToString();
                    cboArtisanRating.Text = dtRow["artisan_rating"].ToString();
                    utilControls.RadioButtonSetSelection(rdnFamilySupportYes, rdnFamilySupportNo, dtRow["yn_id_fam_support"].ToString());
                    txtrdnFamilySupportYes.Text = dtRow["yn_id_fam_support_yes_how"].ToString();
                    txtrdnFamilySupportNoReason.Text = dtRow["yn_id_fam_support_no_reason"].ToString();
                    utilControls.RadioButtonSetSelection(rdnChallengesYes, rdnChallengesNo, dtRow["yn_id_training_challenges"].ToString());
                    txtrdbChallengesYesMention.Text = dtRow["yn_id_training_challenges_yes_list"].ToString();
                    utilControls.RadioButtonSetSelection(rdnEarnYes, rdnEarnNo, dtRow["yn_id_earn_money"].ToString());
                    txtrdnEarnYesAmount.Text = dtRow["yn_id_earn_money_yes_weekly_amt"].ToString();
                    txtPlanAfterTraining.Text = dtRow["plan_after_training"].ToString();
                    num1.Value = Convert.ToInt32(dtRow["youth_rate_attendance"].ToString());
                    num2.Value = Convert.ToInt32(dtRow["youth_rate_commitment"].ToString());
                    num3.Value = Convert.ToInt32(dtRow["youth_rate_participation"].ToString());
                    num4.Value = Convert.ToInt32(dtRow["youth_rate_comprehension"].ToString());
                    cboTrade.SelectedValue = dtRow["module_id"].ToString();
                    utilControls.RadioButtonSetSelection(rdnRetainYouthYes, rdnRetainYouthNo, dtRow["yn_id_retain_youth"].ToString());
                    txtrdnRetainYouthNoRecommend.Text = dtRow["yn_id_retain_youth_no_recommend"].ToString();
                    utilControls.RadioButtonSetSelection(rdnOwnbusinessYes, rdnOwnbusinessNo, dtRow["yn_id_open_own_biz"].ToString());

                    ben_youth_training_completion.ytc_id = yct_id;

                    #region set skill rating
                    DisplayLine(yct_id);
                    #endregion Set skill rating
                }
            }
        }

        protected void DisplayLine(string yct_id)
        {
            #region Variables
            string _excellent_acquired_skr_id = string.Empty;
            string _average_acquired_skr_id = string.Empty;
            string _not_acquired_skr_id = string.Empty;
            string _skill_id = string.Empty;
            string _gdvskill_id = string.Empty;
            DataRow dtRow = null;
            #endregion Variables

            dt = ben_youth_training_completion.Display(yct_id, "DisplayLine");

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

        #region Clear
        protected void Clear()
        {
            cboprt.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            dtDate.Value = DateTime.Now;
            cboHHCode.SelectedValue = "-1";
            cboHHMemberName.SelectedValue = "-1";
            txtPhone.Clear();
            txtYFOName.Clear();
            txtAdress.Clear();
            txtPracticalSkillsLearnt.Clear();
            txtSkillsMissing.Clear();
            rdnGradReadyYes.Checked = false;
            rdnGradReadyNo.Checked = false;
            txtrdnGradReadyNoReason.Clear();
            cboArtisanRating.Text = string.Empty;
            txtrdnFamilySupportYes.Clear();
            rdnFamilySupportYes.Checked = false;
            rdnFamilySupportNo.Checked = false;
            txtrdnFamilySupportNoReason.Clear();
            rdnChallengesYes.Checked = false;
            rdnChallengesNo.Checked = false;
            txtrdbChallengesYesMention.Clear();
            rdnEarnYes.Checked = false;
            rdnEarnNo.Checked = false;
            txtrdnEarnYesAmount.Clear();
            txtPlanAfterTraining.Clear();
            num1.Value = 1;
            num2.Value = 1;
            num3.Value = 1;
            num4.Value = 1;
            cboTrade.SelectedValue = "-1";
            rdnRetainYouthYes.Checked = false;
            rdnRetainYouthNo.Checked = false;
            txtrdnRetainYouthNoRecommend.Clear();
            rdnOwnbusinessYes.Checked = false;
            rdnOwnbusinessNo.Checked = false;
            txtAge.Clear();
            cboSex.SelectedValue = "-1";
            txtMemberCode.Clear();
            ben_youth_training_completion.ytc_id = string.Empty;
            gdvskillRating.Rows.Clear();
        }
        #endregion Clear

        #region Validate
        protected bool ValidateInput()
        {
            bool isValid = false;

            if (cboprt.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboParish.SelectedValue.ToString() == "-1" || 
                cboSubCounty.SelectedValue.ToString() == "-1" || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMemberName.SelectedValue.ToString() == "-1" || dtDate.Checked == false || 
               txtYFOName.Text == string.Empty || (rdnGradReadyYes.Checked == false && rdnGradReadyNo.Checked == false) || (rdnFamilySupportYes.Checked == false && rdnFamilySupportNo.Checked == false) || 
               (rdnChallengesYes.Checked == false && rdnChallengesNo.Checked == false) || (rdnEarnYes.Checked == false && rdnEarnNo.Checked == false) || (rdnRetainYouthYes.Checked == false && rdnRetainYouthNo.Checked == false) || 
               (rdnOwnbusinessYes.Checked == false && rdnOwnbusinessNo.Checked == false) || cboTrade.SelectedValue.ToString() == "-1" || num1.Value == 0 || num2.Value == 0 || num3.Value == 0 || num4.Value == 0



               || (rdnGradReadyNo.Checked == true && txtrdnGradReadyNoReason.Text == string.Empty) || (rdnFamilySupportYes.Checked == true && txtrdnFamilySupportYes.Text == string.Empty) || (rdnFamilySupportNo.Checked == true &&
               txtrdnFamilySupportNoReason.Text == string.Empty) || (rdnChallengesYes.Checked == true && txtrdbChallengesYesMention.Text == string.Empty) || (rdnEarnYes.Checked == true && txtrdnEarnYesAmount.Text == string.Empty))
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
        #endregion Validate

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            lblasat_id.Text = "lblasat_id";
            ben_youth_training_completion.ytc_id = string.Empty;
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rdnGradReadyNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnGradReadyNo.Checked == true)
            {
                txtrdnGradReadyNoReason.ReadOnly = false;
                lblgradNo.ForeColor = Color.Red;
            }
            else
            {
                txtrdnGradReadyNoReason.ReadOnly = true;
                lblgradNo.ForeColor = Color.Black;
            }
        }

        private void rdnGradReadyYes_CheckedChanged(object sender, EventArgs e)
        {
            rdnGradReadyNo_CheckedChanged(rdnGradReadyNo, null);
        }

        private void rdnFamilySupportYes_Click(object sender, EventArgs e)
        {

        }

        private void rdnFamilySupportYes_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFamilySupport();
        }

        protected void ValidateFamilySupport()
        {
            if (rdnFamilySupportYes.Checked == true)
            {
                txtrdnFamilySupportYes.ReadOnly = false;
                txtrdnFamilySupportNoReason.ReadOnly = true;
                lblFamilySupportYes.ForeColor = Color.Red;
                lblFamilySupportNo.ForeColor = Color.Black;
            }
            else
            {
                txtrdnFamilySupportYes.ReadOnly = true;
                txtrdnFamilySupportNoReason.ReadOnly = false;
                lblFamilySupportYes.ForeColor = Color.Black;
                lblFamilySupportNo.ForeColor = Color.Red;
            }
        }

        private void rdnFamilySupportNo_CheckedChanged(object sender, EventArgs e)
        {
            ValidateFamilySupport();
        }

        private void rdnChallengesYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnChallengesYes.Checked == true)
            {
                txtrdbChallengesYesMention.ReadOnly = false;
                lblChallenges.ForeColor = Color.Red;
            }
            else
            {
                txtrdbChallengesYesMention.ReadOnly = true;
                lblChallenges.ForeColor = Color.Black;
            }
        }

        private void rdnChallengesNo_CheckedChanged(object sender, EventArgs e)
        {
            rdnChallengesYes_CheckedChanged(rdnChallengesYes, null);
        }

        private void rdnEarnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnEarnYes.Checked == true)
            {
                lblIncomeAmt.ForeColor = Color.Red;
                txtrdnEarnYesAmount.ReadOnly = false;
            }
            else
            {
                lblIncomeAmt.ForeColor = Color.Black;
                txtrdnEarnYesAmount.ReadOnly = true;
            }
        }

        private void rdnEarnNo_CheckedChanged(object sender, EventArgs e)
        {
            rdnEarnYes_CheckedChanged(rdnEarnYes, null);
        }

        private void rdnRetainYouthYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnRetainYouthYes.Checked == true)
            {
                txtrdnRetainYouthNoRecommend.ReadOnly = true;
                lblRetain.ForeColor = Color.Black;
            }
            else
            {
                txtrdnRetainYouthNoRecommend.ReadOnly = false;
                lblRetain.ForeColor = Color.Red;
            }
        }

        private void rdnRetainYouthNo_CheckedChanged(object sender, EventArgs e)
        {
            rdnRetainYouthYes_CheckedChanged(rdnRetainYouthYes, null);
        }

        private void txtrdnEarnYesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
