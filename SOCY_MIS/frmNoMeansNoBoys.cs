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
    public partial class frmNoMeansNoBoys : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmNoMeansNoMain frmPrt = null;
        frmNoMeansNoSearch frmCommRegister = null;
        Master frmMST = null;
        string strMessage = string.Empty;
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        #endregion Variables

        public frmNoMeansNoBoys()
        {
            InitializeComponent();
        }

        private void frmNoMeansNoBoys_Load(object sender, EventArgs e)
        {
            LoadNMNDetails(NoMeansNoWorldWide.record_id);
        }

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

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
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
            NoMeansNoWorldWide.lead_with_heart = cboLeadHeart.Text;
            NoMeansNoWorldWide.desc_life_worth_living = cboWorthLiving.Text;
            NoMeansNoWorldWide.cycle_of_force = cboCycleForce.Text;
            NoMeansNoWorldWide.tell_at_stake = cboStake.Text;
            NoMeansNoWorldWide.men_not_emortion = cboEmortion.Text;
            NoMeansNoWorldWide.report_rape = cboReportRape.Text;
            NoMeansNoWorldWide.feel_courageous = cboCourageous.Text;
            NoMeansNoWorldWide.intervene_conflit = cboConflict.Text;
            NoMeansNoWorldWide.rape_sex_consent = cboSexConsent.Text;
            NoMeansNoWorldWide.boys_ready_want_sex = cboReadySex.Text;
            NoMeansNoWorldWide.men_women_equal = cboMenWomenEqual.Text;
            NoMeansNoWorldWide.strength_source = cboStrengthSource.Text;
            NoMeansNoWorldWide.adolescent_desc = cboAdolescentDesc.Text;
            NoMeansNoWorldWide.moment_truth = cboTruthMoment.Text;
            NoMeansNoWorldWide.consent_desc = cboConsent.Text;
            NoMeansNoWorldWide.violence_desc = cboViolence.Text;
            NoMeansNoWorldWide.boy_attack_response = cboAttackAction.Text;
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
                   if(cboPrePost.Text == "Post")
                    {
                        if(NoMeansNoWorldWide.ValidatePostSurveyBoys(txtNMNID.Text) > 0) //check if there is pre survey entered for this beneficiary
                        {
                            //save post here

                            NoMeansNoWorldWide.nmn_id_pre = txtNMNID.Text;
                            NoMeansNoWorldWide.saveNMNBoys(dbCon);
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
                        txtNMNID.Text = NoMeansNoWorldWide.saveNMNBoys(dbCon);
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
                    NoMeansNoWorldWide.updateNMNBoys(dbCon);
                    MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                }
                else
                {
                    MessageBox.Show("All values are required,save failed", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

          
        }
        #endregion save

        protected void Clear()
        {
            NoMeansNoWorldWide.record_id = string.Empty;
            NoMeansNoWorldWide.nmn_id = string.Empty;
            //txtNMNID.Clear();
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
            NoMeansNoWorldWide.lead_with_heart = string.Empty;
            cboLeadHeart.Text = string.Empty;
            NoMeansNoWorldWide.desc_life_worth_living = string.Empty;
            cboWorthLiving.Text = string.Empty;
            NoMeansNoWorldWide.cycle_of_force = string.Empty;
            cboCycleForce.Text = string.Empty;
            NoMeansNoWorldWide.tell_at_stake = string.Empty;
            cboStake.Text = string.Empty;
            NoMeansNoWorldWide.men_not_emortion = string.Empty;
            cboEmortion.Text = string.Empty;
            NoMeansNoWorldWide.report_rape = string.Empty;
            cboReportRape.Text = string.Empty;
            NoMeansNoWorldWide.feel_courageous = string.Empty;
            cboCourageous.Text = string.Empty;
            NoMeansNoWorldWide.intervene_conflit = string.Empty;
            cboConflict.Text = string.Empty;
            NoMeansNoWorldWide.rape_sex_consent = string.Empty;
            cboSexConsent.Text = string.Empty;
            NoMeansNoWorldWide.boys_ready_want_sex = string.Empty;
            cboReadySex.Text = string.Empty;
            NoMeansNoWorldWide.men_women_equal = string.Empty;
            cboMenWomenEqual.Text = string.Empty;
            NoMeansNoWorldWide.strength_source = string.Empty;
            cboStrengthSource.Text = string.Empty;
            NoMeansNoWorldWide.adolescent_desc = string.Empty;
            cboAdolescentDesc.Text = string.Empty;
            NoMeansNoWorldWide.moment_truth = string.Empty;
            cboTruthMoment.Text = string.Empty;
            NoMeansNoWorldWide.consent_desc = string.Empty;
            cboConsent.Text = string.Empty;
            NoMeansNoWorldWide.violence_desc = string.Empty;
            cboViolence.Text = string.Empty;
            NoMeansNoWorldWide.boy_attack_response = string.Empty;
            cboAttackAction.Text = string.Empty;
            lblid.Text = "--";
        }

        protected bool ValidateInput()
        {
            bool isValid = false;
            if (!dtDate.Checked || cboPrePost.Text == string.Empty || txtgroupname.Text == string.Empty || txtInstructorname.Text == string.Empty ||
                cboDirectBen.Text == string.Empty || cboHouseholdCode.Text == string.Empty || cboBeneficiaryName.Text == string.Empty || txtAge.Text == string.Empty ||
                cboLeadHeart.Text == string.Empty || cboWorthLiving.Text == string.Empty || cboCycleForce.Text == string.Empty || cboStake.Text == string.Empty || cboEmortion.Text == string.Empty ||
                cboReportRape.Text == string.Empty || cboCourageous.Text == string.Empty || cboConflict.Text == string.Empty || cboSexConsent.Text == string.Empty || cboReadySex.Text == string.Empty ||
                cboMenWomenEqual.Text == string.Empty || cboStrengthSource.Text == string.Empty || cboAdolescentDesc.Text == string.Empty || cboTruthMoment.Text == string.Empty || cboConsent.Text == string.Empty ||
                cboViolence.Text == string.Empty || cboAttackAction.Text == string.Empty || (cboDirectBen.Text == "Yes" & txtSOCYBenCode.Text == string.Empty))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        private void cboDirectBen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboDirectBen.Text == "Yes")
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
            dt = NoMeansNoWorldWide.LoadHouseholdMembersBoys(hh_id);

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
            txtSOCYBenCode.Text = NoMeansNoWorldWide.LoadMemberCode(cboBeneficiaryName.SelectedValue.ToString());
            txtAge.Text = NoMeansNoWorldWide.LoadBeneficiaryAge(cboBeneficiaryName.SelectedValue.ToString());
        }

        protected void LoadNMNDetails(string record_id)
        {
            dt = NoMeansNoWorldWide.LoadNMNBoysDetails(record_id);
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
                cboLeadHeart.Text = dtRow["lead_with_heart"].ToString();
                cboWorthLiving.Text = dtRow["desc_life_worth_living"].ToString();
                cboCycleForce.Text = dtRow["cycle_of_force"].ToString();
                cboStake.Text = dtRow["tell_at_stake"].ToString();
                cboEmortion.Text = dtRow["men_not_emortion"].ToString();
                cboReportRape.Text = dtRow["report_rape"].ToString();
                cboCourageous.Text = dtRow["feel_courageous"].ToString();
                cboConflict.Text = dtRow["intervene_conflit"].ToString();
                cboSexConsent.Text = dtRow["rape_sex_consent"].ToString();
                cboReadySex.Text = dtRow["boys_ready_want_sex"].ToString();
                cboMenWomenEqual.Text = dtRow["men_women_equal"].ToString();
                cboStrengthSource.Text = dtRow["strength_source"].ToString();
                cboAdolescentDesc.Text = dtRow["adolescent_desc"].ToString();
                cboTruthMoment.Text = dtRow["moment_truth"].ToString();
                cboConsent.Text = dtRow["consent_desc"].ToString();
                cboViolence.Text = dtRow["violence_desc"].ToString();
                cboAttackAction.Text = dtRow["boy_attack_response"].ToString();
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

        private void cboPrePost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPrePost.Text == "Pre")
            {
                txtNMNID.ReadOnly = true;
            }
            else if(cboPrePost.Text == "Post")
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
