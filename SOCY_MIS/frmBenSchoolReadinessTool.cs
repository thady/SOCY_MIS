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
    public partial class frmBenSchoolReadinessTool : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmEducationSubsidyMain frmPrt = null;
        frmBenSchoolReadinessToolMain frmCommRegister = null;
        Master frmMST = null;
        string strMessage = string.Empty;
        #endregion Variables

        public frmBenSchoolReadinessTool()
        {
            InitializeComponent();
        }

        private void frmBenSchoolReadinessTool_Load(object sender, EventArgs e)
        {
            Return_lookups();

            #region Load Display
            if (benSchoolReadinessTool.edsr_id != string.Empty)
            {
                LoadDisplay(benSchoolReadinessTool.edsr_id);
            }

            #endregion Load Display
        }

        public frmBenSchoolReadinessToolMain FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        #region # Property
        public frmEducationSubsidyMain FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property


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

            #region Gender
            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow gender_emptyRow = dt.NewRow();
            gender_emptyRow["gnd_id"] = "-1";
            gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(gender_emptyRow, 0);

            cboSexInSchool.DataSource = dt;
            cboSexInSchool.DisplayMember = "gnd_name";
            cboSexInSchool.ValueMember = "gnd_id";

            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow _gender_emptyRow = dt.NewRow();
            _gender_emptyRow["gnd_id"] = "-1";
            _gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(_gender_emptyRow, 0);

            cbosexOutSchool.DataSource = dt;
            cbosexOutSchool.DisplayMember = "gnd_name";
            cbosexOutSchool.ValueMember = "gnd_id";
            #endregion Gender

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

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
            #endregion Load SubCountys

            Return_paraSocialWorkers();
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

        protected void Return_paraSocialWorkers()
        {
            #region Para Social Workers
            dt = benEducationSubsidy.Return_SocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString(), "PSW");  //reused
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["swk_id"] = "-1";
                emptyRow["swk_name"] = "Select Social Worker";
                dt.Rows.InsertAt(emptyRow, 0);

                cboParaSocialWorker.DataSource = dt;
                cboParaSocialWorker.ValueMember = "swk_id";
                cboParaSocialWorker.DisplayMember = "swk_name";
            }
            else
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["swk_id"] = "-1";
                emptyRow["swk_name"] = "Select Social Worker";
                dt.Rows.InsertAt(emptyRow, 0);

                cboParaSocialWorker.DataSource = dt;
                cboParaSocialWorker.ValueMember = "swk_id";
                cboParaSocialWorker.DisplayMember = "swk_name";
            }
            #endregion Para Social Workers

            #region Social Workers
            dt = benEducationSubsidy.Return_SocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString(), "SW");  //reused
            if (dt.Rows.Count > 0)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["swk_id"] = "-1";
                emptyRow["swk_name"] = "Select Social Worker";
                dt.Rows.InsertAt(emptyRow, 0);

                cboSocialWorker.DataSource = dt;
                cboSocialWorker.ValueMember = "swk_id";
                cboSocialWorker.DisplayMember = "swk_name";
            }
            else
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["swk_id"] = "-1";
                emptyRow["swk_name"] = "Select Social Worker";
                dt.Rows.InsertAt(emptyRow, 0);

                cboSocialWorker.DataSource = dt;
                cboSocialWorker.ValueMember = "swk_id";
                cboSocialWorker.DisplayMember = "swk_name";


            }
            #endregion  Social Workers

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
            if (cboHHCode.SelectedIndex != -1)
            {
                dt = benSchoolReadinessTool.ReturnHHMembers(cboHHCode.SelectedValue.ToString(), "hhm_all");

                DataRow hhmCode_emptyRow = dt.NewRow();
                hhmCode_emptyRow["hhm_id"] = "-1";
                hhmCode_emptyRow["hhm_name"] = "select member";
                dt.Rows.InsertAt(hhmCode_emptyRow, 0);

                cboCaregiverName.DataSource = dt;

                cboCaregiverName.DisplayMember = "hhm_name";
                cboCaregiverName.ValueMember = "hhm_id";

                dt = benSchoolReadinessTool.ReturnHHMembers(cboHHCode.SelectedValue.ToString(), "hhm_child_school_age_bracket");

                DataRow hhmOutCode_emptyRow = dt.NewRow();
                hhmOutCode_emptyRow["hhm_id"] = "-1";
                hhmOutCode_emptyRow["hhm_name"] = "select member";
                dt.Rows.InsertAt(hhmOutCode_emptyRow, 0);

                cbonameOutschool.DataSource = dt;

                cbonameOutschool.DisplayMember = "hhm_name";
                cbonameOutschool.ValueMember = "hhm_id";


                dt = benSchoolReadinessTool.ReturnHHMembers(cboHHCode.SelectedValue.ToString(), "hhm_child_school_age_bracket");

                DataRow hhmInCode_emptyRow = dt.NewRow();
                hhmInCode_emptyRow["hhm_id"] = "-1";
                hhmInCode_emptyRow["hhm_name"] = "select member";
                dt.Rows.InsertAt(hhmInCode_emptyRow, 0);

                cboNameInschool.DataSource = dt;

                cboNameInschool.DisplayMember = "hhm_name";
                cboNameInschool.ValueMember = "hhm_id";
            }

            #region HH Village
            txtvillage.Text = benSchoolReadinessTool.ReturnHHVillage(cboHHCode.SelectedValue.ToString());
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidatePrimaryInput())
                {
                    if (ValidateSecondaryInout())
                    {
                        save();
                    }
                    else
                    {
                        MessageBox.Show(strMessage, "SOCY MIS Message center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(strMessage, "SOCY MIS Message center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        protected void save()
        {
            benSchoolReadinessTool.ip_id = cboIP.SelectedValue.ToString();
            benSchoolReadinessTool.cso_id = cboCso.SelectedValue.ToString();
            benSchoolReadinessTool.wrd_id = cboParish.SelectedValue.ToString();
            benSchoolReadinessTool.edsr_ass_date = dtAssessmentDate.Value;
            benSchoolReadinessTool.hh_id = cboHHCode.SelectedValue.ToString();
            benSchoolReadinessTool.hhm_id_caregiver = cboCaregiverName.SelectedValue.ToString();
            benSchoolReadinessTool.hhm_caregiver_phone = txtCaregiverPhone.Text;
            benSchoolReadinessTool.yn_hh_silc = utilControls.RadioButtonGetSelection(rdnSILCYes, rdnSILCNo);
            benSchoolReadinessTool.yn_child_in_school = utilControls.RadioButtonGetSelection(rdnInschoolYes, rdnInschoolNo);

            if (cbonameOutschool.SelectedValue.ToString() != "-1")
            {
                benSchoolReadinessTool.hhm_id = cbonameOutschool.SelectedValue.ToString();
            }

            if (cboNameInschool.SelectedValue.ToString() != "-1")
            {
                benSchoolReadinessTool.hhm_id = cboNameInschool.SelectedValue.ToString();
            }
            
            benSchoolReadinessTool.last_class_completed = cboClassCompleted.Text;
            benSchoolReadinessTool.prev_school_name = txtPrevSchool.Text;
            benSchoolReadinessTool.drop_out_yr = cboYearDropOut.Text;
            benSchoolReadinessTool.child_next_steps = cboChildNextSteps.Text;
            benSchoolReadinessTool.current_class = cboClassInSchool.Text;
            benSchoolReadinessTool.child_future_plans = txtfuturePlansInSchool.Text;
            benSchoolReadinessTool.current_school_name = txtSchoolNameInSchool.Text;
            benSchoolReadinessTool.sw_id = cboSocialWorker.SelectedValue.ToString();
            benSchoolReadinessTool.psw_id = cboParaSocialWorker.SelectedValue.ToString();
            benSchoolReadinessTool.usr_id_create = SystemConstants.user_id;
            benSchoolReadinessTool.usr_id_update = SystemConstants.user_id;
            benSchoolReadinessTool.usr_date_create = DateTime.Now;
            benSchoolReadinessTool.usr_date_update = DateTime.Now;
            benSchoolReadinessTool.ofc_id = SystemConstants.ofc_id;
            benSchoolReadinessTool.district_id = SystemConstants.Return_office_district();

            if (benSchoolReadinessTool.edsr_id == string.Empty)
            {
                benSchoolReadinessTool.edsr_id = Guid.NewGuid().ToString();
                benSchoolReadinessTool.Save("insert");
                MessageBox.Show("Success","SOCY MIS Message Center",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                benSchoolReadinessTool.Save("update");
                MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
        }

        private void rdnInschoolYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnInschoolYes.Checked == true)
            {
                tlpDisplay02.Enabled = false;
                tlpDisplay03.Enabled = true;
            }
            else if(rdnInschoolNo.Checked == true)
            {
                tlpDisplay02.Enabled = true;
                tlpDisplay03.Enabled = false;
            }
        }

        protected bool ValidatePrimaryInput()
        {
            bool isValid = false;

            if (cboIP.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" ||
                cboSubCounty.SelectedValue.ToString() == "-1" || cboParish.SelectedValue.ToString() == "-1" || txtvillage.Text == string.Empty ||
               dtAssessmentDate.Checked == false || cboHHCode.SelectedValue.ToString() == "-1" || cboCaregiverName.SelectedValue.ToString() == "-1" ||
               (rdnSILCYes.Checked == false && rdnSILCNo.Checked == false) || (rdnInschoolYes.Checked == false && rdnInschoolNo.Checked == false)
               || cboSocialWorker.SelectedValue.ToString() == "-1" || cboParaSocialWorker.SelectedValue.ToString() == "-1")
            {
                isValid = false;
                strMessage = "Please fill in all required fields";
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateSecondaryInout()
        {
            bool isValid = false;

            if (rdnInschoolYes.Checked == true)
            {
                if (cboNameInschool.SelectedValue.ToString() == "-1" || cboSexInSchool.SelectedValue.ToString() == "-1" || txtYOBInschool.Text == string.Empty ||
                    cboClassInSchool.Text == string.Empty || txtSchoolNameInSchool.Text == string.Empty)
                {
                    isValid = false;
                    strMessage = "Please fill in all missing details for the in school section";
                }
                else
                {
                    isValid = true;
                }
            }
            else if (rdnInschoolNo.Checked == true)
            {
                if (cbonameOutschool.SelectedValue.ToString() == "-1" || cbosexOutSchool.SelectedValue.ToString() == "-1" || txtYOBOutschool.Text == string.Empty ||
                    cboClassCompleted.Text == string.Empty || txtPrevSchool.Text == string.Empty || cboYearDropOut.Text == string.Empty || cboChildNextSteps.Text == string.Empty)
                {
                    isValid = false;
                    strMessage = "Please fill in all missing details for the out of school section";
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        protected void ReturnHHMDetails(string hhm_id,ComboBox cb,TextBox txt)
        {
            dt = benSchoolReadinessTool.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cb.SelectedValue = dtRow["gnd_id"].ToString();
                txt.Text = dtRow["hhm_year_of_birth"].ToString();
            }
        }

        private void cbonameOutschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbonameOutschool.SelectedValue.ToString() != "-1")
            {
                ReturnHHMDetails(cbonameOutschool.SelectedValue.ToString(), cbosexOutSchool, txtYOBOutschool);
            }
        }

        private void cboNameInschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNameInschool.SelectedValue.ToString() != "-1")
            {
                ReturnHHMDetails(cboNameInschool.SelectedValue.ToString(), cboSexInSchool, txtYOBInschool);
            }
        }

        private void cboSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSocialWorker.SelectedValue.ToString() != "-1")
            {
                txtSocialWorkerPhone.Text = benSchoolReadinessTool.ReturnSWPhone(cboSocialWorker.SelectedValue.ToString());
            }
            else
            {
                txtSocialWorkerPhone.Clear();
            }
        }

        private void cboParaSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParaSocialWorker.SelectedValue.ToString() != "-1")
            {
                txtParaSocialWorkerPhone.Text = benSchoolReadinessTool.ReturnSWPhone(cboParaSocialWorker.SelectedValue.ToString());
            }
            else
            {
                txtParaSocialWorkerPhone.Clear();
            }
        }

        protected void LoadDisplay(string edsr_id)
        {
            if (edsr_id != string.Empty)
            {
                benSchoolReadinessTool.GetDisplay(edsr_id);

                cboIP.SelectedValue = benSchoolReadinessTool.ip_id;
                cboCso.SelectedValue = benSchoolReadinessTool.cso_id;
                cboDistrict.SelectedValue = benSchoolReadinessTool.dst_id;
                cboSubCounty.SelectedValue = benSchoolReadinessTool.sct_id;
                cboParish.SelectedValue = benSchoolReadinessTool.wrd_id;
                dtAssessmentDate.Value = benSchoolReadinessTool.edsr_ass_date;
                cboHHCode.SelectedValue = benSchoolReadinessTool.hh_id;
                cboCaregiverName.SelectedValue = benSchoolReadinessTool.hhm_id_caregiver;
                txtCaregiverPhone.Text = benSchoolReadinessTool.hhm_caregiver_phone;
                utilControls.RadioButtonSetSelection(rdnSILCYes, rdnSILCNo, benSchoolReadinessTool.yn_hh_silc);
                utilControls.RadioButtonSetSelection(rdnInschoolYes, rdnInschoolNo, benSchoolReadinessTool.yn_child_in_school);

                if (rdnInschoolYes.Checked == true)
                {
                    cboNameInschool.SelectedValue = benSchoolReadinessTool.hhm_id;
                    cboClassInSchool.Text = benSchoolReadinessTool.current_class;
                    txtfuturePlansInSchool.Text = benSchoolReadinessTool.child_future_plans;
                    txtSchoolNameInSchool.Text = benSchoolReadinessTool.current_school_name;
                    cboSocialWorker.SelectedValue = benSchoolReadinessTool.sw_id;
                    cboParaSocialWorker.SelectedValue = benSchoolReadinessTool.psw_id;
                    SystemConstants.ofc_id = benSchoolReadinessTool.ofc_id;

                    cbonameOutschool.SelectedValue = "-1";
                    cboClassCompleted.Text = string.Empty;
                    txtPrevSchool.Text = string.Empty;
                    cboYearDropOut.Text = string.Empty;
                    cboChildNextSteps.Text = string.Empty;
                }
                else
                {
                    cbonameOutschool.SelectedValue = benSchoolReadinessTool.hhm_id;
                    cboClassCompleted.Text = benSchoolReadinessTool.last_class_completed;
                    txtPrevSchool.Text = benSchoolReadinessTool.prev_school_name;
                    cboYearDropOut.Text = benSchoolReadinessTool.drop_out_yr;
                    cboChildNextSteps.Text = benSchoolReadinessTool.child_next_steps;
                
                    cboSocialWorker.SelectedValue = benSchoolReadinessTool.sw_id;
                    cboParaSocialWorker.SelectedValue = benSchoolReadinessTool.psw_id;
                    SystemConstants.ofc_id = benSchoolReadinessTool.ofc_id;

                    cboNameInschool.SelectedValue = "-1";
                    cboClassInSchool.Text = string.Empty;
                    txtfuturePlansInSchool.Text = string.Empty;
                    txtSchoolNameInSchool.Text = string.Empty;
                }
                
            }
        }

        protected void Clear()
        {
            benSchoolReadinessTool.edsr_id = string.Empty;
            cboIP.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            dtAssessmentDate.Value = DateTime.Now;
            dtAssessmentDate.Checked = false;
            cboHHCode.SelectedValue = "-1";
            cboCaregiverName.SelectedValue = "-1";
            txtCaregiverPhone.Clear();
            rdnSILCYes.Checked = false;
            rdnSILCNo.Checked = false;
            rdnInschoolYes.Checked = false;
            rdnInschoolNo.Checked = false;
            cboNameInschool.SelectedValue = "-1";
            cboClassInSchool.Text = string.Empty;
            txtfuturePlansInSchool.Clear();
            txtSchoolNameInSchool.Clear();
            cboSocialWorker.SelectedValue = "-1";
            cboParaSocialWorker.SelectedValue = "-1";
            cbonameOutschool.SelectedValue = "-1";
            cboClassCompleted.Text = string.Empty;
            txtPrevSchool.Clear();
            cboYearDropOut.Text = string.Empty;
            cboChildNextSteps.Text = string.Empty;
            cboSexInSchool.SelectedValue = "-1";
            cbosexOutSchool.SelectedValue = "-1";
            txtYOBInschool.Clear();
            

            tlpDisplay02.Enabled = true;
            tlpDisplay03.Enabled = true;

        }

        private void rdnInschoolNo_CheckedChanged(object sender, EventArgs e)
        {
            rdnInschoolYes_CheckedChanged(rdnInschoolYes, null);
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtCaregiverPhone_KeyPress(object sender, KeyPressEventArgs e)
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
