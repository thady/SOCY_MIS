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
    public partial class frmGBV_screeningTool : UserControl
    {
        #region Variables
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private string strgbv_id = string.Empty;
        private frmHousehold frmCll = null;
        private frmHousehold frmPrt = null;
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

        public frmGBV_screeningTool()
        {
            InitializeComponent();
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public frmHousehold FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        private void frmGBV_screeningTool_Load(object sender, EventArgs e)
        {
            Return_lookups();
           
            LoadHHDisplay();
            LoadSocialWorkers();

            if (GBV_screeningTool._gbv_id != string.Empty)
            {
                strgbv_id = GBV_screeningTool._gbv_id;
                LoadDisplay(strgbv_id);
            }
            else
            {
                strgbv_id = string.Empty;
            }

        }


        protected void save(string id)
        {
            if (id == string.Empty)
            {
                #region setVariables
                GBV_screeningTool.gbv_id = Guid.NewGuid().ToString();
                GBV_screeningTool.wrd_id = cboParish.SelectedValue.ToString();
                GBV_screeningTool.hhm_id = cboHHMemberName.SelectedValue.ToString();
                GBV_screeningTool.gbv_screen_officer = cboSocialWorker.SelectedValue.ToString();
                GBV_screeningTool.gbv_screen_date = dtscreenDate.Value;
                GBV_screeningTool.hh_tel = txtPhone.Text;
                GBV_screeningTool.yn_sexual_rape = utilControls.RadioButtonGetSelection(rdnyn_sexual_rapeYes, rdnyn_sexual_rapeNo);
                GBV_screeningTool.yn_sexual_defilement = utilControls.RadioButtonGetSelection(rdnyn_sexual_defilementYes, rdnyn_sexual_defilementNo);
                GBV_screeningTool.yn_sexual_attempt_defilement = utilControls.RadioButtonGetSelection(rdnyn_sexual_attempt_defilementYes, rndyn_sexual_attempt_defilementNo);
                GBV_screeningTool.yn_sexual_harrassment = utilControls.RadioButtonGetSelection(rdnyn_sexual_harrassmentYes, rdnyn_sexual_harrassmentNo);
                GBV_screeningTool.yn_phy_threat = utilControls.RadioButtonGetSelection(rdnyn_phy_threatYes, rdnyn_phy_threatNo);
                GBV_screeningTool.yn_phy_assault = utilControls.RadioButtonGetSelection(rdnyn_phy_assaultYes, rdnyn_phy_assaultNo);
                GBV_screeningTool.yn_phy_deprived_food = utilControls.RadioButtonGetSelection(rdnyn_phy_deprived_foodYes, rdnyn_phy_deprived_foodNo);
                GBV_screeningTool.yn_phy_child_labor = utilControls.RadioButtonGetSelection(rdnyn_phy_child_laborYes, rdnyn_phy_child_laborNo);
                GBV_screeningTool.yn_phy_sleepout = utilControls.RadioButtonGetSelection(rdnyn_phy_sleepoutYes, rdnyn_phy_sleepoutNo);
                GBV_screeningTool.yn_econ_not_spend = utilControls.RadioButtonGetSelection(rdnyn_econ_not_spendYes, rdnyn_econ_not_spendNo);
                GBV_screeningTool.yn_econ_denied_edu_support = utilControls.RadioButtonGetSelection(rdnyn_econ_denied_edu_supportYes, rdnyn_econ_denied_edu_supportNo);
                GBV_screeningTool.yn_econ_denial_resources = utilControls.RadioButtonGetSelection(rdnyn_econ_denial_resourcesYes, rdnyn_econ_denial_resourcesNo);
                GBV_screeningTool.yn_econ_disposed_shelter = utilControls.RadioButtonGetSelection(rdnyn_econ_disposed_shelterYes, rdnyn_econ_disposed_shelterNo);
                GBV_screeningTool.yn_emo_verbal_abuse = utilControls.RadioButtonGetSelection(rdnyn_emo_verbal_abuseYes, rdnyn_emo_verbal_abuseNo);
                GBV_screeningTool.yn_econ_non_verbal_abuse = utilControls.RadioButtonGetSelection(rdnyn_econ_non_verbal_abuseYes, rdnyn_econ_non_verbal_abuseNo);
                GBV_screeningTool.yn_up_know_to_seek_help = utilControls.RadioButtonGetSelection(rdnyn_up_know_to_seek_helpYes, rdnyn_up_know_to_seek_helpNo);
                GBV_screeningTool.yn_up_seek_help = utilControls.RadioButtonGetSelection(rdnyn_up_seek_helpYes, rdnyn_up_seek_helpNo);
                GBV_screeningTool.help_source = cboHelpsource.SelectedValue.ToString();
                GBV_screeningTool.gbv_case_status = cbostatus.SelectedValue.ToString();
                GBV_screeningTool.yn_satisfied_outcome = utilControls.RadioButtonGetSelection(rdnyn_satisfied_outcomeYes, rdnyn_satisfied_outcomeNo);
                GBV_screeningTool.yn_other_emer_support = utilControls.RadioButtonGetSelection(rdnyn_other_emer_supportYes, rdnyn_other_emer_supportNo);
                GBV_screeningTool.yn_other_nutrition = utilControls.RadioButtonGetSelection(rdnyn_other_nutritionYes, rdnyn_other_nutritionNo);
                GBV_screeningTool.yn_hiv_testing = utilControls.RadioButtonGetSelection(rdnyn_hiv_testingYes, rdnyn_hiv_testingNo);
                GBV_screeningTool.yn_pep = utilControls.RadioButtonGetSelection(rdnyn_pepYes, rdnyn_pepNo);
                GBV_screeningTool.yn_counselling = utilControls.RadioButtonGetSelection(rdnyn_counsellingYes, rdnyn_counsellingNo);
                GBV_screeningTool.yn_shelter = utilControls.RadioButtonGetSelection(rdnyn_shelterYes, rdnyn_shelterNo);
                GBV_screeningTool.yn_reffered = utilControls.RadioButtonGetSelection(rdnyn_refferedYes, rdnyn_refferedNo);
                GBV_screeningTool.usr_id_create = SystemConstants.user_id;
                GBV_screeningTool.usr_id_update = SystemConstants.user_id;
                GBV_screeningTool.usr_date_create = DateTime.Today;
                GBV_screeningTool.usr_date_update = DateTime.Today;
                GBV_screeningTool.ofc_id = SystemConstants.ofc_id;
                GBV_screeningTool.district_id = SystemConstants.Return_office_district();
                #endregion
                GBV_screeningTool.save("insert");
                MessageBox.Show("Successfully created record", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                #region setVariables
                GBV_screeningTool.gbv_id = strgbv_id;
                GBV_screeningTool.hhm_id = cboHHMemberName.SelectedValue.ToString();
                GBV_screeningTool.gbv_screen_officer = cboSocialWorker.SelectedValue.ToString();
                GBV_screeningTool.gbv_screen_date = dtscreenDate.Value.Date;
                GBV_screeningTool.hh_tel = txtPhone.Text;
                GBV_screeningTool.yn_sexual_rape = utilControls.RadioButtonGetSelection(rdnyn_sexual_rapeYes, rdnyn_sexual_rapeNo);
                GBV_screeningTool.yn_sexual_defilement = utilControls.RadioButtonGetSelection(rdnyn_sexual_defilementYes, rdnyn_sexual_defilementNo);
                GBV_screeningTool.yn_sexual_attempt_defilement = utilControls.RadioButtonGetSelection(rdnyn_sexual_attempt_defilementYes, rndyn_sexual_attempt_defilementNo);
                GBV_screeningTool.yn_sexual_harrassment = utilControls.RadioButtonGetSelection(rdnyn_sexual_harrassmentYes, rdnyn_sexual_harrassmentNo);
                GBV_screeningTool.yn_phy_threat = utilControls.RadioButtonGetSelection(rdnyn_phy_threatYes, rdnyn_phy_threatNo);
                GBV_screeningTool.yn_phy_assault = utilControls.RadioButtonGetSelection(rdnyn_phy_assaultYes, rdnyn_phy_assaultNo);
                GBV_screeningTool.yn_phy_deprived_food = utilControls.RadioButtonGetSelection(rdnyn_phy_deprived_foodYes, rdnyn_phy_deprived_foodNo);
                GBV_screeningTool.yn_phy_child_labor = utilControls.RadioButtonGetSelection(rdnyn_phy_child_laborYes, rdnyn_phy_child_laborNo);
                GBV_screeningTool.yn_phy_sleepout = utilControls.RadioButtonGetSelection(rdnyn_phy_sleepoutYes, rdnyn_phy_sleepoutNo);
                GBV_screeningTool.yn_econ_not_spend = utilControls.RadioButtonGetSelection(rdnyn_econ_not_spendYes, rdnyn_econ_not_spendNo);
                GBV_screeningTool.yn_econ_denied_edu_support = utilControls.RadioButtonGetSelection(rdnyn_econ_denied_edu_supportYes, rdnyn_econ_denied_edu_supportNo);
                GBV_screeningTool.yn_econ_denial_resources = utilControls.RadioButtonGetSelection(rdnyn_econ_denial_resourcesYes, rdnyn_econ_denial_resourcesNo);
                GBV_screeningTool.yn_econ_disposed_shelter = utilControls.RadioButtonGetSelection(rdnyn_econ_disposed_shelterYes, rdnyn_econ_disposed_shelterNo);
                GBV_screeningTool.yn_emo_verbal_abuse = utilControls.RadioButtonGetSelection(rdnyn_emo_verbal_abuseYes, rdnyn_emo_verbal_abuseNo);
                GBV_screeningTool.yn_econ_non_verbal_abuse = utilControls.RadioButtonGetSelection(rdnyn_econ_non_verbal_abuseYes, rdnyn_econ_non_verbal_abuseNo);
                GBV_screeningTool.yn_up_know_to_seek_help = utilControls.RadioButtonGetSelection(rdnyn_up_know_to_seek_helpYes, rdnyn_up_know_to_seek_helpNo);
                GBV_screeningTool.yn_up_seek_help = utilControls.RadioButtonGetSelection(rdnyn_up_seek_helpYes, rdnyn_up_seek_helpNo);
                GBV_screeningTool.help_source = cboHelpsource.SelectedValue.ToString();
                GBV_screeningTool.gbv_case_status = cbostatus.SelectedValue.ToString();
                GBV_screeningTool.yn_satisfied_outcome = utilControls.RadioButtonGetSelection(rdnyn_satisfied_outcomeYes, rdnyn_satisfied_outcomeNo);
                GBV_screeningTool.yn_other_emer_support = utilControls.RadioButtonGetSelection(rdnyn_other_emer_supportYes, rdnyn_other_emer_supportNo);
                GBV_screeningTool.yn_other_nutrition = utilControls.RadioButtonGetSelection(rdnyn_other_nutritionYes, rdnyn_other_nutritionNo);
                GBV_screeningTool.yn_hiv_testing = utilControls.RadioButtonGetSelection(rdnyn_hiv_testingYes, rdnyn_hiv_testingNo);
                GBV_screeningTool.yn_pep = utilControls.RadioButtonGetSelection(rdnyn_pepYes, rdnyn_pepNo);
                GBV_screeningTool.yn_counselling = utilControls.RadioButtonGetSelection(rdnyn_counsellingYes, rdnyn_counsellingNo);
                GBV_screeningTool.yn_shelter = utilControls.RadioButtonGetSelection(rdnyn_shelterYes, rdnyn_shelterNo);
                GBV_screeningTool.yn_reffered = utilControls.RadioButtonGetSelection(rdnyn_refferedYes, rdnyn_refferedNo);
                GBV_screeningTool.usr_id_create = SystemConstants.user_id;
                GBV_screeningTool.usr_id_update = SystemConstants.user_id;
                GBV_screeningTool.usr_date_create = DateTime.Today;
                GBV_screeningTool.usr_date_update = DateTime.Today;
                GBV_screeningTool.ofc_id = SystemConstants.ofc_id;
                GBV_screeningTool.district_id = SystemConstants.Return_office_district();
                #endregion
                GBV_screeningTool.save("update");
                MessageBox.Show("Successfully updated record", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        protected void LoadDisplay(string id)
        {
            dt = GBV_screeningTool.LoadDisplay(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                #region setDisplay
               

                cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                cboSocialWorker.SelectedValue = dtRow["gbv_screen_officer"].ToString();

                dtscreenDate.Value = Convert.ToDateTime(dtRow["gbv_screen_date"]);
                txtPhone.Text = dtRow["hh_tel"].ToString();
                utilControls.RadioButtonSetSelection(rdnyn_sexual_rapeYes, rdnyn_sexual_rapeNo, dtRow["yn_sexual_rape"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_sexual_defilementYes, rdnyn_sexual_defilementNo, dtRow["yn_sexual_defilement"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_sexual_attempt_defilementYes, rndyn_sexual_attempt_defilementNo, dtRow["yn_sexual_attempt_defilement"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_sexual_harrassmentYes, rdnyn_sexual_harrassmentNo, dtRow["yn_sexual_harrassment"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_phy_threatYes, rdnyn_phy_threatNo, dtRow["yn_phy_threat"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_phy_assaultYes, rdnyn_phy_assaultNo, dtRow["yn_phy_assault"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_phy_deprived_foodYes, rdnyn_phy_deprived_foodNo, dtRow["yn_phy_deprived_food"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_phy_child_laborYes, rdnyn_phy_child_laborNo, dtRow["yn_phy_child_labor"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_phy_sleepoutYes, rdnyn_phy_sleepoutNo, dtRow["yn_phy_sleepout"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_econ_not_spendYes, rdnyn_econ_not_spendNo, dtRow["yn_econ_not_spend"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_econ_denied_edu_supportYes, rdnyn_econ_denied_edu_supportNo, dtRow["yn_econ_denied_edu_support"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_econ_denial_resourcesYes, rdnyn_econ_denial_resourcesNo, dtRow["yn_econ_denial_resources"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_econ_disposed_shelterYes, rdnyn_econ_disposed_shelterNo, dtRow["yn_econ_disposed_shelter"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_emo_verbal_abuseYes, rdnyn_emo_verbal_abuseNo, dtRow["yn_emo_verbal_abuse"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_econ_non_verbal_abuseYes, rdnyn_econ_non_verbal_abuseNo, dtRow["yn_econ_non_verbal_abuse"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_up_know_to_seek_helpYes, rdnyn_up_know_to_seek_helpNo, dtRow["yn_up_know_to_seek_help"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_up_seek_helpYes, rdnyn_up_seek_helpNo, dtRow["yn_up_seek_help"].ToString());
                cboHelpsource.SelectedValue = dtRow["help_source"].ToString();
                cbostatus.SelectedValue = dtRow["gbv_case_status"].ToString();
                utilControls.RadioButtonSetSelection(rdnyn_satisfied_outcomeYes, rdnyn_satisfied_outcomeNo, dtRow["yn_satisfied_outcome"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_other_emer_supportYes, rdnyn_other_emer_supportNo, dtRow["yn_other_emer_support"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_other_nutritionYes, rdnyn_other_nutritionNo, dtRow["yn_other_nutrition"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_hiv_testingYes, rdnyn_hiv_testingNo, dtRow["yn_hiv_testing"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_pepYes, rdnyn_pepNo, dtRow["yn_pep"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_counsellingYes, rdnyn_counsellingNo, dtRow["yn_counselling"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_shelterYes, rdnyn_shelterNo, dtRow["yn_shelter"].ToString());
                utilControls.RadioButtonSetSelection(rdnyn_refferedYes, rdnyn_refferedNo, dtRow["yn_reffered"].ToString());
                
                #endregion
            }
        }

        private void Back()
        {
            if (FormCalling != null)
            {
                //benOvcViralLoad.vl_id = string.Empty;
                //benOvcViralLoad.vlm_id = string.Empty;

                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormParent != null)
            {
                benOvcViralLoad.vl_id = string.Empty;
                benOvcViralLoad.vlm_id = string.Empty;
            }
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

            #region Gender
            dt = silcCommunityTrainingRegister.Return_lookups("gender", string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow gender_emptyRow = dt.NewRow();
            gender_emptyRow["gnd_id"] = "-1";
            gender_emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(gender_emptyRow, 0);

            cbosex.DataSource = dt;
            cbosex.DisplayMember = "gnd_name";
            cbosex.ValueMember = "gnd_id";
            #endregion Gender

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            #region lst_gbv_service
            dt = GBV_screeningTool.ReturnLists("lst_gbv_service",string.Empty);

            DataRow gbv_sr_name_emptyRow = dt.NewRow();
            gbv_sr_name_emptyRow["gbv_sr_id"] = "-1";
            gbv_sr_name_emptyRow["gbv_sr_name"] = "Select one";
            dt.Rows.InsertAt(gbv_sr_name_emptyRow, 0);

            cboHelpsource.DataSource = dt;
            cboHelpsource.DisplayMember = "gbv_sr_name";
            cboHelpsource.ValueMember = "gbv_sr_id";
            #endregion lst_gbv_service

            #region lst_gbv_service_status

            dt = GBV_screeningTool.ReturnLists("lst_gbv_service_status",string.Empty);
            DataRow lst_gbv_service_status_emptyRow = dt.NewRow();
            lst_gbv_service_status_emptyRow["gbv_st_id"] = "-1";
            lst_gbv_service_status_emptyRow["gbv_st_name"] = "Select one";
            dt.Rows.InsertAt(lst_gbv_service_status_emptyRow, 0);

            cbostatus.DataSource = dt;
            cbostatus.DisplayMember = "gbv_st_name";
            cbostatus.ValueMember = "gbv_st_id";
            #endregion lst_gbv_service_status

            #region hhm

            dt = GBV_screeningTool.ReturnLists("hhm",HouseholdId);
            DataRow hhm_emptyRow = dt.NewRow();
            hhm_emptyRow["hhm_id"] = "-1";
            hhm_emptyRow["hhm_name"] = "Select one";
            dt.Rows.InsertAt(hhm_emptyRow, 0);

            cboHHMemberName.DataSource = dt;
            cboHHMemberName.DisplayMember = "hhm_name";
            cboHHMemberName.ValueMember = "hhm_id";
            #endregion hhm_name

        }

        protected void LoadHHDisplay()
        {
            if (HouseholdId != string.Empty)
            {
                dt = GBV_screeningTool.ReturnHHDetails(HouseholdId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboHHCode.SelectedValue = HouseholdId;
                    txtVillage.Text = dtRow["hh_village"].ToString();
                }
            }
        }


        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = benSchoolReadinessTool.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cbosex.SelectedValue = dtRow["gnd_id"].ToString();
                string YOB = dtRow["hhm_year_of_birth"].ToString();
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


        protected void LoadSocialWorkers()
        {
            dt = GBV_screeningTool.LoadSocialWorkers(cboDistrict.SelectedValue.ToString());
            DataRow emptyRow = dt.NewRow();
            emptyRow["swk_id"] = "-1";
            emptyRow["swk_name"] = "Select one";
            dt.Rows.InsertAt(emptyRow, 0);

            cboSocialWorker.DataSource = dt;
            cboSocialWorker.DisplayMember = "swk_name";
            cboSocialWorker.ValueMember = "swk_id";
        }

        protected void Clear()
        {
            GBV_screeningTool._gbv_id = string.Empty;
            strgbv_id = string.Empty;

            cboHHMemberName.SelectedValue = "-1";
            cboSocialWorker.SelectedValue = "-1";
            txtAge.Clear();
            cbosex.SelectedValue = "-1";
            dtscreenDate.Value = DateTime.Today;
            txtPhone.Clear();
            utilControls.RadioButtonSetSelection(rdnyn_sexual_rapeYes, rdnyn_sexual_rapeNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_sexual_defilementYes, rdnyn_sexual_defilementNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_sexual_attempt_defilementYes, rndyn_sexual_attempt_defilementNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_sexual_harrassmentYes, rdnyn_sexual_harrassmentNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_phy_threatYes, rdnyn_phy_threatNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_phy_assaultYes, rdnyn_phy_assaultNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_phy_deprived_foodYes, rdnyn_phy_deprived_foodNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_phy_child_laborYes, rdnyn_phy_child_laborNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_phy_sleepoutYes, rdnyn_phy_sleepoutNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_econ_not_spendYes, rdnyn_econ_not_spendNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_econ_denied_edu_supportYes, rdnyn_econ_denied_edu_supportNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_econ_denial_resourcesYes, rdnyn_econ_denial_resourcesNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_econ_disposed_shelterYes, rdnyn_econ_disposed_shelterNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_emo_verbal_abuseYes, rdnyn_emo_verbal_abuseNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_econ_non_verbal_abuseYes, rdnyn_econ_non_verbal_abuseNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_up_know_to_seek_helpYes, rdnyn_up_know_to_seek_helpNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_up_seek_helpYes, rdnyn_up_seek_helpNo, string.Empty);
            cboHelpsource.SelectedValue = "-1";
            cbostatus.SelectedValue = "-1";
            utilControls.RadioButtonSetSelection(rdnyn_satisfied_outcomeYes, rdnyn_satisfied_outcomeNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_other_emer_supportYes, rdnyn_other_emer_supportNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_other_nutritionYes, rdnyn_other_nutritionNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_hiv_testingYes, rdnyn_hiv_testingNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_pepYes, rdnyn_pepNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_counsellingYes, rdnyn_counsellingNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_shelterYes, rdnyn_shelterNo, string.Empty);
            utilControls.RadioButtonSetSelection(rdnyn_refferedYes, rdnyn_refferedNo, string.Empty);

        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if (cboHHMemberName.SelectedValue.ToString() == "-1" || cbosex.SelectedValue.ToString() == "-1" || txtAge.Text == string.Empty || dtscreenDate.Checked == false || cboSocialWorker.SelectedValue.ToString() == "-1" ||
                (rdnyn_sexual_rapeYes.Checked == false && rdnyn_sexual_rapeNo.Checked == false) ||
                (rdnyn_sexual_defilementYes.Checked == false && rdnyn_sexual_defilementNo.Checked == false) ||
                (rdnyn_sexual_attempt_defilementYes.Checked == false && rndyn_sexual_attempt_defilementNo.Checked == false) ||
                (rdnyn_sexual_harrassmentYes.Checked == false && rdnyn_sexual_harrassmentNo.Checked == false) ||
                (rdnyn_phy_threatYes.Checked == false && rdnyn_phy_threatNo.Checked == false) ||
                (rdnyn_phy_assaultYes.Checked == false && rdnyn_phy_assaultNo.Checked == false) ||
                (rdnyn_phy_deprived_foodYes.Checked == false && rdnyn_phy_deprived_foodNo.Checked == false) ||
                (rdnyn_phy_child_laborYes.Checked == false && rdnyn_phy_child_laborNo.Checked == false) ||
                (rdnyn_phy_sleepoutYes.Checked == false && rdnyn_phy_sleepoutNo.Checked == false) ||
                (rdnyn_econ_not_spendYes.Checked == false && rdnyn_econ_not_spendNo.Checked == false) ||
                (rdnyn_econ_denied_edu_supportYes.Checked == false && rdnyn_econ_denied_edu_supportNo.Checked == false) ||
                (rdnyn_econ_denial_resourcesYes.Checked == false && rdnyn_econ_denial_resourcesNo.Checked == false) ||
                (rdnyn_econ_disposed_shelterYes.Checked == false && rdnyn_econ_disposed_shelterNo.Checked == false) ||
                (rdnyn_emo_verbal_abuseYes.Checked == false && rdnyn_emo_verbal_abuseNo.Checked == false) ||
                (rdnyn_econ_non_verbal_abuseYes.Checked == false && rdnyn_econ_non_verbal_abuseNo.Checked == false) ||
                (rdnyn_up_know_to_seek_helpYes.Checked == false && rdnyn_up_know_to_seek_helpNo.Checked == false) ||
                (rdnyn_up_seek_helpYes.Checked == false && rdnyn_up_seek_helpNo.Checked == false) ||
                (rdnyn_satisfied_outcomeYes.Checked == false && rdnyn_satisfied_outcomeNo.Checked == false) ||
                (rdnyn_other_emer_supportYes.Checked == false && rdnyn_other_emer_supportNo.Checked == false) ||
                (rdnyn_other_nutritionYes.Checked == false && rdnyn_other_nutritionNo.Checked == false) ||
                (rdnyn_hiv_testingYes.Checked == false && rdnyn_hiv_testingNo.Checked == false) ||
                (rdnyn_pepYes.Checked == false && rdnyn_pepNo.Checked == false) ||
                (rdnyn_counsellingYes.Checked == false && rdnyn_counsellingNo.Checked == false) ||
                (rdnyn_shelterYes.Checked == false && rdnyn_shelterNo.Checked == false) ||
                (rdnyn_refferedYes.Checked == false && rdnyn_refferedNo.Checked == false) )
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

               if (rdnyn_up_seek_helpYes.Checked == true )
            {
                if (cboHelpsource.SelectedValue.ToString() == "-1" || cbostatus.SelectedValue.ToString() == "-1")
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
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
                #region hhm

                dt = GBV_screeningTool.ReturnLists("hhm", HouseholdId);
                DataRow hhm_emptyRow = dt.NewRow();
                hhm_emptyRow["hhm_id"] = "-1";
                hhm_emptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(hhm_emptyRow, 0);

                cboHHMemberName.DataSource = dt;
                cboHHMemberName.DisplayMember = "hhm_name";
                cboHHMemberName.ValueMember = "hhm_id";
                #endregion hhm_name
            }
        }

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHMemberName.SelectedIndex != -1)
            {
                ReturnHHMDetails(cboHHMemberName.SelectedValue.ToString());
            }
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == true)
            {
                save(strgbv_id);
            }
            else
            {
                MessageBox.Show("Please input all required fields,save failed","SOCY MIS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void lblNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void rdnyn_up_seek_helpYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnyn_up_seek_helpYes.Checked == true)
            {
                lblHelpsource.ForeColor = Color.Red;
                lblstatus.ForeColor = Color.Red;
                cboHelpsource.Enabled = true;
                cbostatus.Enabled = true;
            }
            else
            {
                cboHelpsource.Enabled = false;
                cbostatus.Enabled = false;
                lblHelpsource.ForeColor = Color.Black;
                lblstatus.ForeColor = Color.Black;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPhone.Text = GBV_screeningTool.LoadSocialWorkerPhone(cboSocialWorker.SelectedValue.ToString());
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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
