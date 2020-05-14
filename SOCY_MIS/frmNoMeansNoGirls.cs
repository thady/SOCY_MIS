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
    public partial class frmNoMeansNoGirls : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmNoMeansNoMain frmPrt = null;
        frmNoMeansNoSearch frmCommRegister = null;
        Master frmMST = null;
        string strMessage = string.Empty;
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        #endregion Variables
        public frmNoMeansNoSearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        #region # Property
        public frmNoMeansNoMain FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        public frmNoMeansNoGirls()
        {
            InitializeComponent();
        }

        private void frmNoMeansNoGirls_Load(object sender, EventArgs e)
        {
            LoadNMNDetails(NoMeansNoWorldWide.record_id);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void cboDirectBen_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboDirectBen.Text == "Yes")
            {
                LoadHouseholdList();
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("hh_id", typeof(string));
                dt.Columns.Add("hh_code", typeof(string));

                DataRow dstemptyRow = dt.NewRow();
                dstemptyRow["hh_id"] = "-1";
                dstemptyRow["hh_code"] = "Select one";
                dt.Rows.InsertAt(dstemptyRow, 0);

                cboHouseholdCode.DataSource = dt;
                cboHouseholdCode.DisplayMember = "hh_code";
                cboHouseholdCode.ValueMember = "hh_id";

                cboHouseholdCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboHouseholdCode.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        protected void LoadHouseholdList()
        {
            dt = NoMeansNoWorldWide.LoadHouseholdList();

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["hh_id"] = "-1";
            dstemptyRow["hh_code"] = "Select one";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboHouseholdCode.DataSource = dt;
            cboHouseholdCode.DisplayMember = "hh_code";
            cboHouseholdCode.ValueMember = "hh_id";

            cboHouseholdCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboHouseholdCode.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        protected void LoadHouseholdMembers(string hh_id)
        {
            dt = NoMeansNoWorldWide.LoadHouseholdMembersGirls(hh_id);

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["hhm_id"] = "-1";
            dstemptyRow["hhm_name"] = "Select one";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboBeneficiaryName.DataSource = dt;
            cboBeneficiaryName.DisplayMember = "hhm_name";
            cboBeneficiaryName.ValueMember = "hhm_id";
        }

        private void cboHouseholdCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHouseholdMembers(cboHouseholdCode.SelectedValue.ToString());
        }

        private void cboBeneficiaryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtSOCYBenCode.Text = NoMeansNoWorldWide.LoadMemberCode(cboBeneficiaryName.SelectedValue.ToString());
            //txtAge.Text = NoMeansNoWorldWide.LoadBeneficiaryAge(cboBeneficiaryName.SelectedValue.ToString());
        }


        #region    save
        protected void save()
        {
            #region SetVariables
            NoMeansNoWorldWide.yn_direct_ben = cboDirectBen.Text;
            NoMeansNoWorldWide.hh_id = cboHouseholdCode.SelectedValue.ToString();
            NoMeansNoWorldWide.hhm_id = cboBeneficiaryName.SelectedValue.ToString();
            NoMeansNoWorldWide.hhm_code = txtSOCYBenCode.Text;
            NoMeansNoWorldWide.date = dtDate.Value;
            NoMeansNoWorldWide.pre_post = cboPrePost.Text;
            NoMeansNoWorldWide.grp_name = txtgroupname.Text;
            NoMeansNoWorldWide.instructor_name = txtInstructorname.Text;
            NoMeansNoWorldWide.age = txtAge.Text;

            NoMeansNoWorldWide.cant_escape_attacker = cbosafety.Text;
            NoMeansNoWorldWide.can_defend_myself_act_crazy = cboActCrazy.Text;
            NoMeansNoWorldWide.intimidation_not_assault = cboassault.Text;
            NoMeansNoWorldWide.can_fight_dirty = cboFightDirty.Text;
            NoMeansNoWorldWide.report_rape_to_adult = cboReportRapeCase.Text;
            NoMeansNoWorldWide.prepared_to_deffend_myself = cboselfDefence.Text;
            NoMeansNoWorldWide.worth_defending = cboWorthDefending.Text;
            NoMeansNoWorldWide.can_strike_first = cboStrikeFirst.Text;
            NoMeansNoWorldWide.know_assertive = cboAssertive.Text;
            NoMeansNoWorldWide.voice_weapon_to_assault = cboVoiceWeapon.Text;
            NoMeansNoWorldWide.use_self_defence_skills = cboDefendFromKnownPerson.Text;
            NoMeansNoWorldWide.main_safety_goal = cboSafettGoal.Text;
            NoMeansNoWorldWide.girl_attack_response = cboReportAction.Text;
            NoMeansNoWorldWide.attack_girl_fault_desc = cboAttackGirlsFaultDesc.Text;
            NoMeansNoWorldWide.self_defence_desc = cboSelfDefenceDesc.Text;
            NoMeansNoWorldWide.girl_response_if_eyes_covered = cboGirlActionEyesCovered.Text;

            NoMeansNoWorldWide.usr_id_create = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_id_update = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_date_create = DateTime.Now;
            NoMeansNoWorldWide.usr_date_update = DateTime.Now;
            NoMeansNoWorldWide.ofc_id = SystemConstants.ofc_id;
            NoMeansNoWorldWide.district_id = SystemConstants.Return_office_district();
            #endregion SetVariables

            if (lblid.Text == "--")
            {
                NoMeansNoWorldWide.record_id = Guid.NewGuid().ToString();
                if (ValidateInput())
                {
                    if (cboPrePost.Text == "Post")
                    {
                        if (NoMeansNoWorldWide.ValidatePostSurveyGirls(txtNMNID.Text) > 0) //check if there is pre survey entered for this beneficiary
                        {
                            //save post here

                            NoMeansNoWorldWide.nmn_id_pre = txtNMNID.Text;
                            NoMeansNoWorldWide.saveNMNGirls(dbCon);
                            MessageBox.Show("Success,NMN ID is " + txtNMNID.Text, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();

                        }
                        else
                        {
                            MessageBox.Show("NMN Unique code not found or this beneficiary does not have a pre survey entered,save failed" + txtNMNID.Text, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //save pre here
                        NoMeansNoWorldWide.nmn_id_pre = string.Empty;
                        txtNMNID.Text = NoMeansNoWorldWide.saveNMNGirls(dbCon);
                        MessageBox.Show("Success,NMN ID is " + txtNMNID.Text, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }

                }
                else
                {
                    MessageBox.Show("All values are required,save failed", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                if (ValidateInput())
                {
                    NoMeansNoWorldWide.record_id = lblid.Text;
                    NoMeansNoWorldWide.updateNMNGirls(dbCon);
                    MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("All values are required,save failed", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


        }
        #endregion save

        protected bool ValidateInput()
        {
            bool isValid = false;
            if (!dtDate.Checked || cboPrePost.Text == string.Empty || txtgroupname.Text == string.Empty || txtInstructorname.Text == string.Empty ||
                cboDirectBen.Text == string.Empty || cboHouseholdCode.Text == string.Empty || cboBeneficiaryName.Text == string.Empty || txtAge.Text == string.Empty ||
                cbosafety.Text == string.Empty || cboActCrazy.Text == string.Empty || cboassault.Text == string.Empty || cboFightDirty.Text == string.Empty || cboReportRapeCase.Text == string.Empty ||
                cboselfDefence.Text == string.Empty || cboWorthDefending.Text == string.Empty || cboStrikeFirst.Text == string.Empty || cboAssertive.Text == string.Empty || cboVoiceWeapon.Text == string.Empty ||
                cboDefendFromKnownPerson.Text == string.Empty || cboSafettGoal.Text == string.Empty || cboReportAction.Text == string.Empty || cboAttackGirlsFaultDesc.Text == string.Empty || cboSelfDefenceDesc.Text == string.Empty ||
                cboGirlActionEyesCovered.Text == string.Empty || (cboDirectBen.Text == "Yes" & txtSOCYBenCode.Text == string.Empty))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected void Clear()
        {
            NoMeansNoWorldWide.record_id = string.Empty;
            NoMeansNoWorldWide.nmn_id = string.Empty;
            NoMeansNoWorldWide.yn_direct_ben = string.Empty;
            cboDirectBen.Text = string.Empty;
            NoMeansNoWorldWide.hh_id = string.Empty;
            cboHouseholdCode.SelectedValue = "-1";
            NoMeansNoWorldWide.hhm_id = string.Empty;
            NoMeansNoWorldWide.hhm_code = string.Empty;
            txtSOCYBenCode.Clear();
            NoMeansNoWorldWide.date = DateTime.Now;
            dtDate.Value = DateTime.Now;
            dtDate.Checked = false;
            NoMeansNoWorldWide.pre_post = string.Empty;
            cboPrePost.Text = string.Empty;
            NoMeansNoWorldWide.grp_name = string.Empty;
            txtgroupname.Clear();
            NoMeansNoWorldWide.instructor_name = string.Empty;
            txtInstructorname.Clear();
            NoMeansNoWorldWide.age = string.Empty;
            txtAge.Clear();

            NoMeansNoWorldWide.cant_escape_attacker = string.Empty;
            cbosafety.Text = string.Empty;
            NoMeansNoWorldWide.can_defend_myself_act_crazy = string.Empty;
            cboActCrazy.Text = string.Empty;
            NoMeansNoWorldWide.intimidation_not_assault = string.Empty;
            cboassault.Text = string.Empty;
            NoMeansNoWorldWide.can_fight_dirty = string.Empty;
            cboFightDirty.Text = string.Empty;
            NoMeansNoWorldWide.report_rape_to_adult = string.Empty;
            cboReportRapeCase.Text = string.Empty;
            NoMeansNoWorldWide.prepared_to_deffend_myself = string.Empty;
            cboselfDefence.Text = string.Empty;
            NoMeansNoWorldWide.worth_defending = string.Empty;
            cboWorthDefending.Text = string.Empty;
            NoMeansNoWorldWide.can_strike_first = string.Empty;
            cboStrikeFirst.Text = string.Empty;
            NoMeansNoWorldWide.know_assertive = string.Empty;
            cboAssertive.Text = string.Empty;
            NoMeansNoWorldWide.voice_weapon_to_assault = string.Empty;
            cboVoiceWeapon.Text = string.Empty;
            NoMeansNoWorldWide.use_self_defence_skills = string.Empty;
            cboDefendFromKnownPerson.Text = string.Empty;
            NoMeansNoWorldWide.main_safety_goal = string.Empty;
            cboSafettGoal.Text = string.Empty;
            NoMeansNoWorldWide.girl_attack_response = string.Empty;
            cboReportAction.Text = string.Empty;
            NoMeansNoWorldWide.attack_girl_fault_desc = string.Empty;
            cboAttackGirlsFaultDesc.Text = string.Empty;
            NoMeansNoWorldWide.self_defence_desc = string.Empty;
            cboSelfDefenceDesc.Text = string.Empty;
            NoMeansNoWorldWide.girl_response_if_eyes_covered = string.Empty;
            cboGirlActionEyesCovered.Text = string.Empty;

            lblid.Text = "--";
        }


        protected void LoadNMNDetails(string record_id)
        {
            dt = NoMeansNoWorldWide.LoadNMNGirlsDetails(record_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                txtNMNID.Text = dtRow["nmn_id"].ToString();
                cboDirectBen.Text = dtRow["yn_direct_ben"].ToString();
                cboHouseholdCode.SelectedValue = dtRow["hh_id"].ToString();
                cboBeneficiaryName.SelectedValue = dtRow["hhm_id"].ToString();
                txtSOCYBenCode.Text = dtRow["hhm_code"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["date"].ToString());
                cboPrePost.Text = dtRow["pre_post"].ToString();
                txtgroupname.Text = dtRow["grp_name"].ToString();
                txtInstructorname.Text = dtRow["instructor_name"].ToString();
                txtAge.Text = dtRow["age"].ToString();

                cbosafety.Text = dtRow["cant_escape_attacker"].ToString();
                cboActCrazy.Text = dtRow["can_defend_myself_act_crazy"].ToString();
                cboassault.Text = dtRow["intimidation_not_assault"].ToString();
                cboFightDirty.Text = dtRow["can_fight_dirty"].ToString();
                cboReportRapeCase.Text = dtRow["report_rape_to_adult"].ToString();
                cboselfDefence.Text = dtRow["prepared_to_deffend_myself"].ToString();
                cboWorthDefending.Text = dtRow["worth_defending"].ToString();
                cboStrikeFirst.Text = dtRow["can_strike_first"].ToString();

                cboAssertive.Text = dtRow["know_assertive"].ToString();
                cboVoiceWeapon.Text = dtRow["voice_weapon_to_assault"].ToString();
                cboDefendFromKnownPerson.Text = dtRow["use_self_defence_skills"].ToString();
                cboSafettGoal.Text = dtRow["main_safety_goal"].ToString();
                cboReportAction.Text = dtRow["girl_attack_response"].ToString();
                cboAttackGirlsFaultDesc.Text = dtRow["attack_girl_fault_desc"].ToString();
                cboSelfDefenceDesc.Text = dtRow["self_defence_desc"].ToString();
                cboGirlActionEyesCovered.Text = dtRow["girl_response_if_eyes_covered"].ToString();

                lblid.Text = NoMeansNoWorldWide.record_id;
            }
            else
            {
                Clear();
            }
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboBeneficiaryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSOCYBenCode.Text = NoMeansNoWorldWide.LoadMemberCode(cboBeneficiaryName.SelectedValue.ToString());
            txtAge.Text = NoMeansNoWorldWide.LoadBeneficiaryAge(cboBeneficiaryName.SelectedValue.ToString());
        }

        private void cboPrePost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrePost.Text == "Pre")
            {
                txtNMNID.ReadOnly = true;
            }
            else if (cboPrePost.Text == "Post")
            {
                txtNMNID.ReadOnly = false;
            }
            else
            {
                txtNMNID.ReadOnly = true;
            }
        }
    }
}
