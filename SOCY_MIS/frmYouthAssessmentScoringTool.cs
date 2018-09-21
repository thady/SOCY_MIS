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
    public partial class frmYouthAssessmentScoringTool : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmYouthAssessmentScoringToolSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public frmYouthAssessmentScoringToolSearch FormCallingSearch
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

        public frmYouthAssessmentScoringTool()
        {
            InitializeComponent();
        }

        private void frmYouthAssessmentScoringTool_Load(object sender, EventArgs e)
        {
            Return_lookups();
            Load_scoring_parameters();

            #region LoadDisplay
            if (benYouthAssessmentScoring.yas_id != string.Empty)
            {
                LoadDisplay(benYouthAssessmentScoring.yas_id);
            }
            #endregion LoadDisplay

        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
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

            cbocso.DataSource = dt;
            cbocso.DisplayMember = "cso_other";
            cbocso.ValueMember = "cso_id";
            #endregion CSO

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

            cbocso.DataSource = dt;
            cbocso.DisplayMember = "cso_other";
            cbocso.ValueMember = "cso_id";
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

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
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

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMDetails(cboHHMemberName.SelectedValue.ToString());
        }

        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = ben_youth_training_completion.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
               
                txtMemberCode.Text = dtRow["hhm_code"].ToString();
            }
        }

        protected void Load_scoring_parameters()
        {
            dt = benYouthAssessmentScoring.Display("ys1_id", string.Empty);

            DataRow ys1_id = dt.NewRow();
            ys1_id["ya_score_id"] = "-1";
            ys1_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys1_id, 0);

            cboTradeChoiceReason.DataSource = dt;
            cboTradeChoiceReason.DisplayMember = "ya_score_name";
            cboTradeChoiceReason.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("ys2_id", string.Empty);

            DataRow ys2_id = dt.NewRow();
            ys2_id["ya_score_id"] = "-1";
            ys2_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys2_id, 0);

            cboTrainerType.DataSource = dt;
            cboTrainerType.DisplayMember = "ya_score_name";
            cboTrainerType.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("ys3_id", string.Empty);

            DataRow ys3_id = dt.NewRow();
            ys3_id["ya_score_id"] = "-1";
            ys3_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys3_id, 0);

            cboDistance.DataSource = dt;
            cboDistance.DisplayMember = "ya_score_name";
            cboDistance.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("ys4_id", string.Empty);

            DataRow ys4_id = dt.NewRow();
            ys4_id["ya_score_id"] = "-1";
            ys4_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys4_id, 0);

            cboFundsSource.DataSource = dt;
            cboFundsSource.DisplayMember = "ya_score_name";
            cboFundsSource.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("ys5_id", string.Empty);

            DataRow ys5_id = dt.NewRow();
            ys5_id["ya_score_id"] = "-1";
            ys5_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys5_id, 0);

            cboYouthIntergrity.DataSource = dt;
            cboYouthIntergrity.DisplayMember = "ya_score_name";
            cboYouthIntergrity.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("ys5_id", string.Empty);

            DataRow ys6_id = dt.NewRow();
            ys6_id["ya_score_id"] = "-1";
            ys6_id["ya_score_name"] = "select one";
            dt.Rows.InsertAt(ys6_id, 0);

            cboYouthEnergy.DataSource = dt;
            cboYouthEnergy.DisplayMember = "ya_score_name";
            cboYouthEnergy.ValueMember = "ya_score_id";

            dt = benYouthAssessmentScoring.Display("TrainingType", string.Empty);

            DataRow ttp_id = dt.NewRow();
            ttp_id["ttp_id"] = "-1";
            ttp_id["ttp_name"] = "select one";
            dt.Rows.InsertAt(ttp_id, 0);

            cboTrainingType.DataSource = dt;
            cboTrainingType.DisplayMember = "ttp_name";
            cboTrainingType.ValueMember = "ttp_id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
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
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTrainingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTrainingType.SelectedValue.ToString())
            {
                case "3":
                    dt = benYouthAssessmentScoring.Display("Crops", cboTrainingType.SelectedValue.ToString());

                    DataRow crop_id = dt.NewRow();
                    crop_id["crop_id"] = "-1";
                    crop_id["crop_name"] = "select one";
                    dt.Rows.InsertAt(crop_id, 0);

                    cboTrade.DataSource = dt;
                    cboTrade.DisplayMember = "crop_name";
                    cboTrade.ValueMember = "crop_id";
                    break;
                case "4":
                    dt = benYouthAssessmentScoring.Display("Trades", cboTrainingType.SelectedValue.ToString());

                    DataRow trade_id = dt.NewRow();
                    trade_id["ttps_id"] = "-1";
                    trade_id["ttps_name"] = "select one";
                    dt.Rows.InsertAt(trade_id, 0);

                    cboTrade.DataSource = dt;
                    cboTrade.DisplayMember = "ttps_name";
                    cboTrade.ValueMember = "ttps_id";
                    break;
            }
           
        }

        private void cboTradeChoiceReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            num1.Value = benYouthAssessmentScoring.ReturnParameterScore(cboTradeChoiceReason.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboTradeChoiceReason.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        private void cboTrainerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            num2.Value = benYouthAssessmentScoring.ReturnParameterScore(cboTrainerType.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboTrainerType.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        private void cboDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            num3.Value = benYouthAssessmentScoring.ReturnParameterScore(cboDistance.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboDistance.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        private void cboFundsSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            num4.Value = benYouthAssessmentScoring.ReturnParameterScore(cboFundsSource.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboFundsSource.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        private void cboYouthIntergrity_SelectedIndexChanged(object sender, EventArgs e)
        {
            num5.Value = benYouthAssessmentScoring.ReturnParameterScore(cboYouthIntergrity.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboYouthIntergrity.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        private void cboYouthEnergy_SelectedIndexChanged(object sender, EventArgs e)
        {
            num6.Value = benYouthAssessmentScoring.ReturnParameterScore(cboYouthEnergy.SelectedValue.ToString()) != 0 ? benYouthAssessmentScoring.ReturnParameterScore(cboYouthEnergy.SelectedValue.ToString()) : 0;
            CalculateTotalScore();
        }

        protected void CalculateTotalScore()
        {
            num_total_score.Value = num1.Value + num2.Value + num3.Value + num4.Value + num5.Value + num6.Value;
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

        #region Save
        protected void save()
        {
            benYouthAssessmentScoring.prt_id = cboprt.SelectedValue.ToString();
            benYouthAssessmentScoring.cso_id = cbocso.SelectedValue.ToString();
            benYouthAssessmentScoring.wrd_id = cboParish.SelectedValue.ToString();
            benYouthAssessmentScoring.dt_ass_date = dtDate.Value;
            benYouthAssessmentScoring.hh_id = cboHHCode.SelectedValue.ToString();
            benYouthAssessmentScoring.hhm_id = cboHHMemberName.SelectedValue.ToString();
            benYouthAssessmentScoring.ttp_id = cboTrainingType.SelectedValue.ToString();
            benYouthAssessmentScoring.ttps_id = cboTrade.SelectedValue.ToString();
            benYouthAssessmentScoring.ys1_id = cboTradeChoiceReason.SelectedValue.ToString();
            benYouthAssessmentScoring.ys2_id = cboTrainerType.SelectedValue.ToString();
            benYouthAssessmentScoring.ys3_id = cboDistance.SelectedValue.ToString();
            benYouthAssessmentScoring.ys4_id = cboFundsSource.SelectedValue.ToString();
            benYouthAssessmentScoring.ys5_id = cboYouthIntergrity.SelectedValue.ToString();
            benYouthAssessmentScoring.ys6_id = cboYouthEnergy.SelectedValue.ToString();
            benYouthAssessmentScoring.total_score = num_total_score.Value.ToString();
            benYouthAssessmentScoring.youth_notes = txtYouthNotes.Text;
            benYouthAssessmentScoring.assessor_name = txtAssessorName.Text;
            benYouthAssessmentScoring.date_assessor_sign = dtAssessorSign.Value;
            benYouthAssessmentScoring.approver_name = txtAssessorName.Text;
            benYouthAssessmentScoring.date_approver_sign = dtApproverSign.Value;
            benYouthAssessmentScoring.usr_id_create = SystemConstants.user_id;
            benYouthAssessmentScoring.usr_id_update = SystemConstants.user_id;
            benYouthAssessmentScoring.usr_date_create = DateTime.Now;
            benYouthAssessmentScoring.usr_date_update = DateTime.Now;
            benYouthAssessmentScoring.ofc_id = SystemConstants.ofc_id;
            benYouthAssessmentScoring.district_id = SystemConstants.Return_office_district();

            if (benYouthAssessmentScoring.yas_id == string.Empty)
            {
                benYouthAssessmentScoring.yas_id = Guid.NewGuid().ToString();
                benYouthAssessmentScoring.save("insert");
                MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                benYouthAssessmentScoring.save("update");
                MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
        }
        #endregion Save

        #region Clear
        protected void Clear()
        {
            cboprt.SelectedValue = "-1";
            cbocso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            //cboParish.SelectedValue = "-1";
            dtDate.Value = DateTime.Now;
            dtDate.Checked = false;
            cboHHCode.SelectedValue = "-1";
            cboHHMemberName.SelectedValue = "-1";
            cboTrainingType.SelectedValue = "-1";
            cboTrade.SelectedValue = "-1";
            cboTradeChoiceReason.SelectedValue = "-1";
            cboTrainerType.SelectedValue = "-1";
            cboDistance.SelectedValue = "-1";
            cboFundsSource.SelectedValue = "-1";
            cboYouthIntergrity.SelectedValue = "-1";
            cboYouthEnergy.SelectedValue = "-1";
            num_total_score.Value = 0;
            txtYouthNotes.Clear();
            txtAssessorName.Clear();
            dtAssessorSign.Value = DateTime.Now;
            dtAssessorSign.Checked = false;
            txtAssessorName.Clear();
            dtApproverSign.Value = DateTime.Now;
            dtApproverSign.Checked = false;
            txtMemberCode.Clear();
           
            txtApproverName.Clear();

            benYouthAssessmentScoring.yas_id = string.Empty;
        }
        #endregion Clear

        protected bool ValidateInput()
        {
            bool isValid = false;
            if (cboprt.SelectedValue.ToString() == "-1" || cbocso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" ||
                cboParish.SelectedValue.ToString() == "-1" || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMemberName.SelectedValue.ToString() == "-1" || cboTrainingType.SelectedValue.ToString() == "-1" ||
                cboTrade.SelectedValue.ToString() == "-1" || cboTradeChoiceReason.SelectedValue.ToString() == "-1" || cboTrainerType.SelectedValue.ToString() == "-1" || cboDistance.SelectedValue.ToString() == "-1" ||
                cboFundsSource.SelectedValue.ToString() == "-1" || cboYouthIntergrity.SelectedValue.ToString() == "-1" || cboYouthEnergy.SelectedValue.ToString() == "-1" ||
                txtApproverName.Text == string.Empty || dtApproverSign.Checked == false || txtAssessorName.Text == string.Empty || dtAssessorSign.Checked == false || dtDate.Checked == false)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        #region LoadDisplay
        protected void LoadDisplay(string id)
        {
            dt = benYouthAssessmentScoring.LoadDisplay(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboprt.SelectedValue = dtRow["prt_id"].ToString();
                cbocso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["dt_ass_date"]);
                cboHHCode.SelectedValue = dtRow["hh_id"].ToString();
                cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                cboTrainingType.SelectedValue = dtRow["ttp_id"].ToString();
                cboTrade.SelectedValue = dtRow["ttps_id"].ToString();
                cboTradeChoiceReason.SelectedValue = dtRow["ys1_id"].ToString();
                cboTrainerType.SelectedValue = dtRow["ys2_id"].ToString();
                cboDistance.SelectedValue = dtRow["ys3_id"].ToString();
                cboFundsSource.SelectedValue = dtRow["ys4_id"].ToString();
                cboYouthIntergrity.SelectedValue = dtRow["ys5_id"].ToString();
                cboYouthEnergy.SelectedValue = dtRow["ys6_id"].ToString();
                num_total_score.Value = Convert.ToInt32(dtRow["total_score"].ToString());
                txtYouthNotes.Text = dtRow["youth_notes"].ToString();
                txtAssessorName.Text = dtRow["assessor_name"].ToString();
                dtAssessorSign.Value = Convert.ToDateTime(dtRow["date_assessor_sign"]);
                txtApproverName.Text = dtRow["approver_name"].ToString();
                dtApproverSign.Value = Convert.ToDateTime(dtRow["date_approver_sign"]);
               

                benYouthAssessmentScoring.yas_id = id;
            }
        }
        #endregion LoadDisplay

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }
    }
}
