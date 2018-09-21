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
    public partial class frmEducationSubsidy : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmEducationSubsidyMain frmPrt = null;
        frmEducationSubsidySearch frmCommRegister = null;
        Master frmMST = null;
        string strMessage = string.Empty;
        #endregion Variables

        #region # Property
        public frmEducationSubsidyMain FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmEducationSubsidy()
        {
            InitializeComponent();
        }

        public frmEducationSubsidySearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        private void frmEducationSubsidy_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadApprenticeshipList();

            #region Assessment Details
            returnHHMembers(benEducationSubsidy.ed_sub_id, cboHHCode.SelectedValue.ToString(), "NewAssessment");

            ReturnAssessmentDetails(benEducationSubsidy.ed_sub_id);
            // ReturnAssessmentMemberDetails("5e059a9b-e130-4a7b-a95f-68e39ac836a3");
            #endregion Assessment Details

            #region Assessment Members
            ReturnAssessmentMemberList(benEducationSubsidy.ed_sub_id);
            #endregion Assessment Members
        }

        protected void Return_lookups()
        {
            #region districts
            dt = silcCommunityTrainingRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty,string.Empty); //reused

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
            dt = silcCommunityTrainingRegister.Return_lookups("IP", string.Empty, string.Empty, string.Empty,string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";
            #endregion IP

            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion subcounty

            #region CSO
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO

            #region Gender
            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty,string.Empty);

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

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

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
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty,string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion Load SubCountys

           // returnHHCodesByLocation();
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

            Return_paraSocialWorkers();
        }

        protected void returnHHMembers(string ed_sub_id,string hh_id,string AssessmentType)
        {
            #region HH Children

            switch (AssessmentType)
            {
                case "Existing":
                    dt = benEducationSubsidy.ReturnHHAssessmentChildren(ed_sub_id, hh_id, AssessmentType);

                    DataRow hhCode_emptyRow = dt.NewRow();
                    hhCode_emptyRow["hhm_id"] = "-1";
                    hhCode_emptyRow["hhm_name"] = "Select Child";
                    dt.Rows.InsertAt(hhCode_emptyRow, 0);

                    cboHHMember.DataSource = dt;

                    cboHHMember.DisplayMember = "hhm_name";
                    cboHHMember.ValueMember = "hhm_id";
                    break;
                case "NewAssessment":
                    dt = benEducationSubsidy.ReturnHHAssessmentChildren(ed_sub_id, hh_id, AssessmentType);

                    DataRow _emptyRow = dt.NewRow();
                    _emptyRow["hhm_id"] = "-1";
                    _emptyRow["hhm_name"] = "Select Child";
                    dt.Rows.InsertAt(_emptyRow, 0);

                    cboHHMember.DataSource = dt;

                    cboHHMember.DisplayMember = "hhm_name";
                    cboHHMember.ValueMember = "hhm_id";

                    #region HH Caregiver
                    dt = silcCommunityTrainingRegister.Return_lookups("EducationSubsidyMembers", hh_id, string.Empty, string.Empty,string.Empty); //reused
                    DataRow emptyRow = dt.NewRow();
                    emptyRow["hhm_id"] = "-1";
                    emptyRow["hhm_name"] = "Select Caregiver";
                    dt.Rows.InsertAt(emptyRow, 0);

                    cboCaregiverName.DataSource = dt;

                    cboCaregiverName.DisplayMember = "hhm_name";
                    cboCaregiverName.ValueMember = "hhm_id";

                    #endregion  HH Caregiver
                    break;
            }

            #endregion HH Children

           
        }



        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHCode.SelectedIndex != -1)
            {
                if (benEducationSubsidy.ed_sub_id != string.Empty)
                {
                    returnHHMembers(benEducationSubsidy.ed_sub_id, cboHHCode.SelectedValue.ToString(), "NewAssessment");
                }
                else
                {
                    returnHHMembers(string.Empty, cboHHCode.SelectedValue.ToString(), "NewAssessment");
                }

                #region Village
                txtvillage.Text = benEducationSubsidy.ReturnHHVillage(cboHHCode.SelectedValue.ToString());
                #endregion Village
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                saveAssessment();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void saveAssessment()
        {
            if (Validate("parent"))
            {
                #region Save
                if (benEducationSubsidy.ed_sub_id == string.Empty)
                {
                    if (benEducationSubsidy.HouseholdAssessmentExists(cboHHCode.SelectedValue.ToString()))
                    {
                        strMessage = "There is already an existing assessment for this household,please use the search screen to edit";
                        MessageBox.Show(strMessage, "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        benEducationSubsidy.ed_sub_id = Guid.NewGuid().ToString();

                        benEducationSubsidy.prt_id = cboIP.SelectedValue.ToString();
                        benEducationSubsidy.cso_id = cboCso.SelectedValue.ToString();
                        benEducationSubsidy.dst_id = cboDistrict.SelectedValue.ToString();
                        benEducationSubsidy.sct_id = cboSubCounty.SelectedValue.ToString();
                        benEducationSubsidy.wrd_id = cboParish.SelectedValue.ToString();
                        benEducationSubsidy.village = txtvillage.Text;
                        benEducationSubsidy.assessment_date = dtAssessmentDate.Value.Date;
                        benEducationSubsidy.hhm_id_caregiver = cboCaregiverName.SelectedValue.ToString();
                        benEducationSubsidy.caregiver_phone = txtCaregiverPhone.Text;
                        benEducationSubsidy.hh_id = cboHHCode.SelectedValue.ToString();
                        benEducationSubsidy.usr_id_create = SystemConstants.user_id;
                        benEducationSubsidy.usr_id_update = SystemConstants.user_id;
                        benEducationSubsidy.usr_date_create = DateTime.Today;
                        benEducationSubsidy.usr_date_update = DateTime.Today;
                        benEducationSubsidy.ofc_id = SystemConstants.ofc_id;
                        benEducationSubsidy.district_id = SystemConstants.Return_office_district();

                        benEducationSubsidy.ed_sub_id = benEducationSubsidy.save_update_EducationSubsidyAssessment("insert");
                        MessageBox.Show("Success!!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    benEducationSubsidy.prt_id = cboIP.SelectedValue.ToString();
                    benEducationSubsidy.cso_id = cboCso.SelectedValue.ToString();
                    benEducationSubsidy.dst_id = cboDistrict.SelectedValue.ToString();
                    benEducationSubsidy.sct_id = cboSubCounty.SelectedValue.ToString();
                    benEducationSubsidy.wrd_id = cboParish.SelectedValue.ToString();
                    benEducationSubsidy.village = txtvillage.Text;
                    benEducationSubsidy.assessment_date = dtAssessmentDate.Value.Date;
                    benEducationSubsidy.hhm_id_caregiver = cboCaregiverName.SelectedValue.ToString();
                    benEducationSubsidy.caregiver_phone = txtCaregiverPhone.Text;
                    benEducationSubsidy.hh_id = cboHHCode.SelectedValue.ToString();
                    benEducationSubsidy.usr_id_create = SystemConstants.user_id;
                    benEducationSubsidy.usr_id_update = SystemConstants.user_id;
                    benEducationSubsidy.usr_date_create = DateTime.Today;
                    benEducationSubsidy.usr_date_update = DateTime.Today;
                    benEducationSubsidy.ofc_id = SystemConstants.ofc_id;
                    benEducationSubsidy.district_id = SystemConstants.Return_office_district();

                    benEducationSubsidy.ed_sub_id = benEducationSubsidy.save_update_EducationSubsidyAssessment("update");
                    MessageBox.Show("Success!!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #endregion Save


            }
            else
            {
                MessageBox.Show(strMessage, "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected void saveAssessmentMembers()
        {
            if (benEducationSubsidy.ed_sub_id == string.Empty)
            {
                MessageBox.Show("Select or create an assessment to save child details","SOCY MIS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (Validate("child"))
                {
                    if (ValidateSchoolResponse())
                    {
                        if (benEducationSubsidy.ed_subm_id == string.Empty)
                        {
                            benEducationSubsidy.ed_subm_id = Guid.NewGuid().ToString();
                            benEducationSubsidy.hhm_id = cboHHMember.SelectedValue.ToString();

                            benEducationSubsidy.last_class_completed = cboClassCompleted.Text;
                            benEducationSubsidy.prev_school = txtPrevschool.Text;
                            benEducationSubsidy.drop_out_year = cboYearDropOut.Text;
                            benEducationSubsidy.dropout_reason = txtDropoutReason.Text;
                            benEducationSubsidy.yn_id_willing_to_study = utilControls.RadioButtonGetSelection(rbtnGoBackToSchoolYes, rbtnGoBackToSchoolNo);
                            benEducationSubsidy.enrollment_class = cboEnrollmentClass.Text;
                            benEducationSubsidy.ttps_id = cboApprenticeshipName.SelectedValue.ToString();
                            benEducationSubsidy.preffered_school = txtprefferedSchool.Text;
                            benEducationSubsidy.caregiver_contribution = txtCaregiverContribution.Text;
                            benEducationSubsidy.yn_id_hh_head_in_silc_grp = utilControls.RadioButtonGetSelection(rbtnHHHeadInSILCYes, rbtnHHHeadInSILCNo);
                            benEducationSubsidy.yn_id_caregiver_commit_sch_attendance = utilControls.RadioButtonGetSelection(rbtnRegularAttendanceYes, rbtnRegularAttendanceNo);
                            benEducationSubsidy.yn_id_caregiver_commit_pta_meeting = utilControls.RadioButtonGetSelection(rbtnPTAYes, rbtnPTANo);
                            benEducationSubsidy.yn_id_caregiver_commit_acad_performance = utilControls.RadioButtonGetSelection(rbtnMonitorPerfomanceYes, rbtnMonitorPerfomanceNo);
                            benEducationSubsidy.yn_id_caregiver_commit_project_interventions = txtInterestInSILC.Text;
                            benEducationSubsidy.yn_id_caregiver_commit_contribute_fee = utilControls.RadioButtonGetSelection(rbtnContributeFeeYes, rbtnContributeFeeNo);
                            benEducationSubsidy.yn_id_caregiver_commit_keep_child_in_sch = utilControls.RadioButtonGetSelection(rbtnKeepChildInSchoolYes, rbtnKeepChildInSchoolNo);
                            benEducationSubsidy.swk_id = cboSocialWorker.SelectedValue.ToString();
                            benEducationSubsidy.swk_phone = txtSocialWorkerPhone.Text;
                            benEducationSubsidy.psw_id = cboParaSocialWorker.SelectedValue.ToString();
                            benEducationSubsidy.psw_phone = txtParaSocialWorkerPhone.Text;
                            benEducationSubsidy.usr_id_create = SystemConstants.user_id;
                            benEducationSubsidy.usr_id_update = SystemConstants.user_id;
                            benEducationSubsidy.usr_date_create = DateTime.Today;
                            benEducationSubsidy.usr_date_update = DateTime.Today;
                            benEducationSubsidy.ofc_id = SystemConstants.ofc_id;
                            benEducationSubsidy.district_id = SystemConstants.Return_office_district();

                            benEducationSubsidy.save_update_EducationSubsidyAssessmentMember("insert");
                            MessageBox.Show("Success!!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #region Assessment Members
                            ReturnAssessmentMemberList(benEducationSubsidy.ed_sub_id);
                            #endregion Assessment Members
                        }
                        else
                        {
                            benEducationSubsidy.hhm_id = cboHHMember.SelectedValue.ToString();

                            benEducationSubsidy.last_class_completed = cboClassCompleted.Text;
                            benEducationSubsidy.prev_school = txtPrevschool.Text;
                            benEducationSubsidy.drop_out_year = cboYearDropOut.Text;
                            benEducationSubsidy.dropout_reason = txtDropoutReason.Text;
                            benEducationSubsidy.yn_id_willing_to_study = utilControls.RadioButtonGetSelection(rbtnGoBackToSchoolYes, rbtnGoBackToSchoolNo);
                            benEducationSubsidy.enrollment_class = cboEnrollmentClass.Text;
                            benEducationSubsidy.ttps_id = cboApprenticeshipName.SelectedValue.ToString();
                            benEducationSubsidy.preffered_school = txtprefferedSchool.Text;
                            benEducationSubsidy.caregiver_contribution = txtCaregiverContribution.Text;
                            benEducationSubsidy.yn_id_hh_head_in_silc_grp = utilControls.RadioButtonGetSelection(rbtnHHHeadInSILCYes, rbtnHHHeadInSILCNo);
                            benEducationSubsidy.yn_id_caregiver_commit_sch_attendance = utilControls.RadioButtonGetSelection(rbtnRegularAttendanceYes, rbtnRegularAttendanceNo);
                            benEducationSubsidy.yn_id_caregiver_commit_pta_meeting = utilControls.RadioButtonGetSelection(rbtnPTAYes, rbtnPTANo);
                            benEducationSubsidy.yn_id_caregiver_commit_acad_performance = utilControls.RadioButtonGetSelection(rbtnMonitorPerfomanceYes, rbtnMonitorPerfomanceNo);
                            benEducationSubsidy.yn_id_caregiver_commit_project_interventions = txtInterestInSILC.Text;
                            benEducationSubsidy.yn_id_caregiver_commit_contribute_fee = utilControls.RadioButtonGetSelection(rbtnContributeFeeYes, rbtnContributeFeeNo);
                            benEducationSubsidy.yn_id_caregiver_commit_keep_child_in_sch = utilControls.RadioButtonGetSelection(rbtnKeepChildInSchoolYes, rbtnKeepChildInSchoolNo);
                            benEducationSubsidy.swk_id = cboSocialWorker.SelectedValue.ToString();
                            benEducationSubsidy.swk_phone = txtSocialWorkerPhone.Text;
                            benEducationSubsidy.psw_id = cboParaSocialWorker.SelectedValue.ToString();
                            benEducationSubsidy.psw_phone = txtParaSocialWorkerPhone.Text;
                            benEducationSubsidy.usr_id_create = SystemConstants.user_id;
                            benEducationSubsidy.usr_id_update = SystemConstants.user_id;
                            benEducationSubsidy.usr_date_create = DateTime.Today;
                            benEducationSubsidy.usr_date_update = DateTime.Today;
                            benEducationSubsidy.ofc_id = SystemConstants.ofc_id;
                            benEducationSubsidy.district_id = SystemConstants.Return_office_district();

                            benEducationSubsidy.save_update_EducationSubsidyAssessmentMember("update");
                            MessageBox.Show("Success!!", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #region Assessment Members
                            ReturnAssessmentMemberList(benEducationSubsidy.ed_sub_id);
                            #endregion Assessment Members
                        }
                    }
                    else
                    {
                        MessageBox.Show(strMessage, "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(strMessage, "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        protected bool Validate(string name)
        {
            bool IsValid = false;

            if (name == "parent")
            {
                if (cboIP.SelectedIndex == -1 || cboCso.SelectedIndex == -1 || cboDistrict.SelectedIndex == -1 || cboSubCounty.SelectedIndex == -1 || cboParish.SelectedIndex == -1 ||
                txtvillage.Text == string.Empty || dtAssessmentDate.Checked == false || cboHHCode.SelectedIndex == -1 || cboCaregiverName.SelectedValue.ToString() == string.Empty)
                {
                    IsValid = false;
                    strMessage = "Missing required fields";
                }
                else
                    IsValid = true;
            }
            else if(name == "child")
            {
                if (cboHHMember.SelectedIndex == -1 || cboSex.SelectedIndex == -1 || txtYOB.Text == string.Empty || cboClassCompleted.Text == string.Empty || txtPrevschool.Text == string.Empty ||
                    cboYearDropOut.Text == string.Empty || txtDropoutReason.Text == string.Empty || (rbtnGoBackToSchoolYes.Checked == false && rbtnGoBackToSchoolNo.Checked == false) ||
                    (rbtnHHHeadInSILCYes.Checked == false && rbtnHHHeadInSILCNo.Checked == false))
                {
                    IsValid = false;
                    strMessage = "Missing required fields";
                }
                else
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }

        protected bool ValidateSchoolResponse()
        {
            bool isValid = false;
            if (rbtnGoBackToSchoolYes.Checked == true)
            {
                if (cboEnrollmentClass.Text == string.Empty || txtprefferedSchool.Text == string.Empty || txtCaregiverContribution.Text == string.Empty || (rbtnRegularAttendanceYes.Checked == false && rbtnRegularAttendanceNo.Checked == false) ||
                    (rbtnPTAYes.Checked == false && rbtnPTANo.Checked == false) || (rbtnMonitorPerfomanceYes.Checked == false && rbtnMonitorPerfomanceNo.Checked == false) || (rbtnContributeFeeYes.Checked == false && rbtnContributeFeeNo.Checked == false) ||
                    (rbtnKeepChildInSchoolYes.Checked == false && rbtnKeepChildInSchoolNo.Checked == false) || cboSocialWorker.SelectedValue.ToString() == "-1" || cboParaSocialWorker.SelectedValue.ToString() == "-1")
                {
                    isValid = false;
                    strMessage = "Child willing to go to school,all school  related responses are required";
                }
                else
                    isValid = true;
            }
            else if (rbtnGoBackToSchoolNo.Checked == true)
            {
                if (cboApprenticeshipName.SelectedValue.ToString() == "-1")
                {
                    isValid = false;
                    strMessage = "Child willing to go for apprenticeship,all apprenticeship  related responses are required";
                }
                else
                    isValid = true;
            }

            return isValid;
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

        private void cboSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSocialWorker.SelectedIndex != -1)
            {
                txtSocialWorkerPhone.Text = benEducationSubsidy.Return_SocialWorkerPhone(cboSocialWorker.SelectedValue.ToString());
            }
            else
            {
                txtSocialWorkerPhone.Text = string.Empty;
            }
        }

        private void cboParaSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParaSocialWorker.SelectedIndex != -1)
            {
                txtParaSocialWorkerPhone.Text = benEducationSubsidy.Return_SocialWorkerPhone(cboParaSocialWorker.SelectedValue.ToString());
            }
            else
            {
                txtParaSocialWorkerPhone.Text = string.Empty;
            }
        }


        private void btnsaveMembers_Click_1(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                saveAssessmentMembers();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void LoadApprenticeshipList()
        {
            #region Training Type
            dt = benEducationSubsidy.ReturnApprenticeshipTrainings();
            DataRow ttp_emptyRow = dt.NewRow();
            ttp_emptyRow["ttps_id"] = "-1";
            ttp_emptyRow["ttps_name"] = "Select session";
            dt.Rows.InsertAt(ttp_emptyRow, 0);

            cboApprenticeshipName.DataSource = dt;
            cboApprenticeshipName.DisplayMember = "ttps_name";
            cboApprenticeshipName.ValueMember = "ttps_id";
            #endregion Training Type
        }

        protected void ReturnAssessmentDetails(string ed_sub_id)
        {
            if (ed_sub_id != string.Empty)
            {
               dt = benEducationSubsidy.ReturnAssessmentDetails(ed_sub_id);
                if (dt.Rows.Count > 0)
                {

                    cboIP.SelectedValue = benEducationSubsidy.prt_id;
                    cboCso.SelectedValue = benEducationSubsidy.cso_id;
                    cboDistrict.SelectedValue = benEducationSubsidy.dst_id;
                    cboSubCounty.SelectedValue = benEducationSubsidy.sct_id;
                    cboParish.SelectedValue = benEducationSubsidy.wrd_id;
                    txtvillage.Text = benEducationSubsidy.village;
                    dtAssessmentDate.Value = benEducationSubsidy.assessment_date;
                    cboHHCode.SelectedValue = benEducationSubsidy.hh_id;
                    cboCaregiverName.SelectedValue = benEducationSubsidy.hhm_id_caregiver;
                    txtCaregiverPhone.Text = benEducationSubsidy.caregiver_phone;

                    tlpDisplay01.Enabled = false;
                }
            }
        }

        protected void ReturnAssessmentMemberDetails(string ed_subm_id)
        {
            if (ed_subm_id != string.Empty)
            {
                dt = benEducationSubsidy.ReturnAssessmentMemberDetails(ed_subm_id);
                if (dt.Rows.Count > 0)
                {
                    cboHHMember.SelectedValue = benEducationSubsidy.hhm_id;
                    cboClassCompleted.Text = benEducationSubsidy.last_class_completed;
                    txtPrevschool.Text = benEducationSubsidy.prev_school;
                    cboYearDropOut.Text = benEducationSubsidy.drop_out_year;
                    txtDropoutReason.Text = benEducationSubsidy.dropout_reason;
                    txtYOB.Text = benEducationSubsidy.YOB;
                    cboSex.SelectedValue = benEducationSubsidy.gnd_id;

                    utilControls.RadioButtonSetSelection(rbtnGoBackToSchoolYes, rbtnGoBackToSchoolNo, benEducationSubsidy.yn_id_willing_to_study);

                    cboEnrollmentClass.Text = benEducationSubsidy.enrollment_class;
                    cboApprenticeshipName.SelectedValue = benEducationSubsidy.ttps_id;
                    txtprefferedSchool.Text = benEducationSubsidy.preffered_school;
                    txtCaregiverContribution.Text = benEducationSubsidy.caregiver_contribution;

                    utilControls.RadioButtonSetSelection(rbtnHHHeadInSILCYes, rbtnHHHeadInSILCNo, benEducationSubsidy.yn_id_hh_head_in_silc_grp);
                    utilControls.RadioButtonSetSelection(rbtnRegularAttendanceYes, rbtnRegularAttendanceNo, benEducationSubsidy.yn_id_caregiver_commit_sch_attendance);
                    utilControls.RadioButtonSetSelection(rbtnPTAYes, rbtnPTANo, benEducationSubsidy.yn_id_caregiver_commit_pta_meeting);
                    utilControls.RadioButtonSetSelection(rbtnMonitorPerfomanceYes, rbtnMonitorPerfomanceNo, benEducationSubsidy.yn_id_caregiver_commit_acad_performance);

                    txtInterestInSILC.Text = benEducationSubsidy.yn_id_caregiver_commit_project_interventions;
                    utilControls.RadioButtonSetSelection(rbtnContributeFeeYes, rbtnContributeFeeNo, benEducationSubsidy.yn_id_caregiver_commit_contribute_fee);
                    utilControls.RadioButtonSetSelection(rbtnKeepChildInSchoolYes, rbtnKeepChildInSchoolNo, benEducationSubsidy.yn_id_caregiver_commit_keep_child_in_sch);

                    cboSocialWorker.SelectedValue = benEducationSubsidy.swk_id;
                    txtSocialWorkerPhone.Text = benEducationSubsidy.swk_phone;
                    cboParaSocialWorker.SelectedValue = benEducationSubsidy.psw_id;
                    txtParaSocialWorkerPhone.Text = benEducationSubsidy.psw_phone;

                    tlpDisplay02.Enabled = false;
                    tlpDisplay03.Enabled = false;
                    tlpDisplay04.Enabled = false;
                }
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            tlpDisplay02.Enabled = true;
            tlpDisplay03.Enabled = true;
            tlpDisplay04.Enabled = true;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tlpDisplay01.Enabled = true;
        }

        protected void ReturnAssessmentMemberList(string ed_sub_id)
        {
            dt = benEducationSubsidy.ReturnAssessmentMemberList(ed_sub_id);
            if (dt.Rows.Count > 0)
            {
                gdvHHChildren.DataSource = dt;

                gdvHHChildren.Columns["hhm_name"].HeaderText = "Name of Child";
                gdvHHChildren.Columns["ed_subm_id"].Visible = false;
                gdvHHChildren.Columns["hhm_id"].Visible = false;

                gdvHHChildren.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvHHChildren.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvHHChildren.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvHHChildren.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvHHChildren.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvHHChildren.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvHHChildren.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvHHChildren.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvHHChildren.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvHHChildren.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        private void gdvHHChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvHHChildren.Rows.Count > 0)
            {
                
                string ed_subm_id = gdvHHChildren.CurrentRow.Cells[1].Value.ToString();
                ReturnAssessmentMemberDetails(ed_subm_id);
            }
        }

        protected void Clear(string ClearType)
        {
            switch (ClearType) {
                case "Parent":
                    benEducationSubsidy.ed_sub_id = string.Empty;
                    cboIP.SelectedValue = "-1";
                    cboDistrict.SelectedValue = "-1";
                    dtAssessmentDate.Value = DateTime.Today;
                    dtAssessmentDate.Checked = false;
                    txtvillage.Clear();
                    txtCaregiverPhone.Clear();

                    benEducationSubsidy.ed_subm_id = string.Empty;
                    cboHHMember.SelectedValue = "-1";
                    cboClassCompleted.Text = string.Empty;
                    txtPrevschool.Text = "";
                    cboYearDropOut.Text = string.Empty;
                    txtDropoutReason.Text = string.Empty;
                    rbtnGoBackToSchoolYes.Checked = false;
                    rbtnGoBackToSchoolNo.Checked = false;
                    cboEnrollmentClass.Text = "";
                    cboApprenticeshipName.SelectedValue = "-1";
                    txtprefferedSchool.Text = "";
                    txtCaregiverContribution.Text = "";
                    rbtnHHHeadInSILCYes.Checked = false;
                    rbtnHHHeadInSILCNo.Checked = false;
                    rbtnRegularAttendanceYes.Checked = false;
                    rbtnRegularAttendanceNo.Checked = false;
                    rbtnPTAYes.Checked = false;
                    rbtnPTANo.Checked = false;
                    rbtnMonitorPerfomanceYes.Checked = false;
                    rbtnMonitorPerfomanceNo.Checked = false;
                    txtInterestInSILC.Text = "";
                    rbtnContributeFeeYes.Checked = false;
                    rbtnContributeFeeNo.Checked = false;
                    rbtnKeepChildInSchoolYes.Checked = false;
                    rbtnKeepChildInSchoolNo.Checked = false;
                    cboSocialWorker.SelectedValue = "-1";
                    txtSocialWorkerPhone.Text = "";
                    cboParaSocialWorker.SelectedValue = "-1";
                    txtParaSocialWorkerPhone.Text = "";
                    txtYOB.Clear();

                    tlpDisplay01.Enabled = true;
                    tlpDisplay03.Enabled = true;
                    tlpDisplay02.Enabled = true;
                    tlpDisplay04.Enabled = true;
                    break;
                case "child":
                    benEducationSubsidy.ed_subm_id = string.Empty;
                    cboHHMember.SelectedValue = "-1";
                    cboClassCompleted.Text = string.Empty;
                    txtPrevschool.Text = "";
                    cboYearDropOut.Text = string.Empty;
                    txtDropoutReason.Text = string.Empty;
                    rbtnGoBackToSchoolYes.Checked = false;
                    rbtnGoBackToSchoolNo.Checked = false;
                    cboEnrollmentClass.Text = "";
                    cboApprenticeshipName.SelectedValue = "-1";
                    txtprefferedSchool.Text = "";
                    txtCaregiverContribution.Text = "";
                    rbtnHHHeadInSILCYes.Checked = false;
                    rbtnHHHeadInSILCNo.Checked = false;
                    rbtnRegularAttendanceYes.Checked = false;
                    rbtnRegularAttendanceNo.Checked = false;
                    rbtnPTAYes.Checked = false;
                    rbtnPTANo.Checked = false;
                    rbtnMonitorPerfomanceYes.Checked = false;
                    rbtnMonitorPerfomanceNo.Checked = false;
                    txtInterestInSILC.Text = "";
                    rbtnContributeFeeYes.Checked = false;
                    rbtnContributeFeeNo.Checked = false;
                    rbtnKeepChildInSchoolYes.Checked = false;
                    rbtnKeepChildInSchoolNo.Checked = false;
                    cboSocialWorker.SelectedValue = "-1";
                    txtSocialWorkerPhone.Text = "";
                    cboParaSocialWorker.SelectedValue = "-1";
                    txtParaSocialWorkerPhone.Text = "";
                    txtYOB.Clear();
                    cboSex.SelectedValue = "-1";

                    tlpDisplay03.Enabled = true;
                    tlpDisplay04.Enabled = true;
                    tlpDisplay02.Enabled = true;
                    break;
                case "childSelection":
                    benEducationSubsidy.ed_subm_id = string.Empty;
               
                    cboClassCompleted.Text = string.Empty;
                    txtPrevschool.Text = "";
                    cboYearDropOut.Text = string.Empty;
                    txtDropoutReason.Text = string.Empty;
                    rbtnGoBackToSchoolYes.Checked = false;
                    rbtnGoBackToSchoolNo.Checked = false;
                    cboEnrollmentClass.Text = "";
                    cboApprenticeshipName.SelectedValue = "-1";
                    txtprefferedSchool.Text = "";
                    txtCaregiverContribution.Text = "";
                    rbtnHHHeadInSILCYes.Checked = false;
                    rbtnHHHeadInSILCNo.Checked = false;
                    rbtnRegularAttendanceYes.Checked = false;
                    rbtnRegularAttendanceNo.Checked = false;
                    rbtnPTAYes.Checked = false;
                    rbtnPTANo.Checked = false;
                    rbtnMonitorPerfomanceYes.Checked = false;
                    rbtnMonitorPerfomanceNo.Checked = false;
                    txtInterestInSILC.Text = "";
                    rbtnContributeFeeYes.Checked = false;
                    rbtnContributeFeeNo.Checked = false;
                    rbtnKeepChildInSchoolYes.Checked = false;
                    rbtnKeepChildInSchoolNo.Checked = false;
                    cboSocialWorker.SelectedValue = "-1";
                    txtSocialWorkerPhone.Text = "";
                    cboParaSocialWorker.SelectedValue = "-1";
                    txtParaSocialWorkerPhone.Text = "";
                    

                    tlpDisplay03.Enabled = true;
                    tlpDisplay04.Enabled = true;
                    tlpDisplay02.Enabled = true;
                    break;
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Clear("Parent");
        }

        private void cboIP_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void btnNewMember_Click(object sender, EventArgs e)
        {
            Clear("child");
        }

        private void cboHHMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cboHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboHHMember.SelectedValue.ToString() != "-1")
            {
                dt = benEducationSubsidy.ReturnChildSex_YOB(cboHHMember.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    txtYOB.Text = dtRow["hhm_year_of_birth"].ToString();
                    cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                }

                #region Assessment Details if already assessed
                string hhm_id = string.Empty;
                string ed_subm_id = string.Empty;
                if (gdvHHChildren.Rows.Count > 0)
                {
                    for (int i = 0; i < gdvHHChildren.Rows.Count; i++)
                    {
                        hhm_id = gdvHHChildren.Rows[i].Cells[2].Value.ToString();
                        if (hhm_id.Equals(cboHHMember.SelectedValue.ToString()))
                        {
                            ed_subm_id = gdvHHChildren.Rows[i].Cells[1].Value.ToString();
                            ReturnAssessmentMemberDetails(ed_subm_id);
                        }
                        else
                        {
                            Clear("childSelection");
                        }
                    }
                }
                #endregion Assessment Details if already assessed
            }
        }


        private void llnback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("Parent");
            Back();
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear("Parent");
            Back();
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

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }
    }
}
