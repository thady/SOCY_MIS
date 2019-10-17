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
    public partial class frmOVC_Viral_load : UserControl
    {
        #region Variables
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        public  string strMessage = string.Empty;
        private frmHousehold frmCll = null;
        private frmReferralSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmReferralSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        public frmOVC_Viral_load()
        {
            InitializeComponent();
        }

        private void frmOVC_Viral_load_Load(object sender, EventArgs e)
        {
            Return_lookups();

            LoadHHDisplay();

            if (benOvcViralLoad._vl_id != string.Empty)
            {
                LoadMainDisplay(benOvcViralLoad._vl_id);
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

            cbosex.DataSource = dt;
            cbosex.DisplayMember = "gnd_name";
            cbosex.ValueMember = "gnd_id";
            #endregion Gender

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

        }

        private void Back()
        {
            if (FormCalling != null)
            {
                benOvcViralLoad.vl_id = string.Empty;
                benOvcViralLoad.vlm_id = string.Empty;

                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormParent != null)
            {
                benOvcViralLoad.vl_id = string.Empty;
                benOvcViralLoad.vlm_id = string.Empty;

                FormCallingSearch.BackDisplay();
                FormParent.LoadControl(FormCallingSearch, this.Name);
            }
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedIndex != -1?cboIP.SelectedValue.ToString() : string.Empty, string.Empty, string.Empty, string.Empty);

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

            #region Load Linkages Coordinator
            dt = benOvcViralLoad.LoadLinkangesCoordinator(cboDistrict.SelectedValue.ToString());

            DataRow LCemptyRow = dt.NewRow();
            LCemptyRow["lc_id"] = "-1";
            LCemptyRow["lc_name"] = "Select one";
            dt.Rows.InsertAt(LCemptyRow, 0);

            cboLinkagesCordinator.DataSource = dt;
            cboLinkagesCordinator.DisplayMember = "lc_name";
            cboLinkagesCordinator.ValueMember = "lc_id";
            #endregion Load Linkages Coordinator

            Return_paraSocialWorkers();
        }

        protected void Return_paraSocialWorkers()
        {
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
                dt = benOvcViralLoad.ReturnHHMembers(cboHHCode.SelectedValue.ToString());

                DataRow hhmCode_emptyRow = dt.NewRow();
                hhmCode_emptyRow["hhm_id"] = "-1";
                hhmCode_emptyRow["hhm_name"] = "select member";
                dt.Rows.InsertAt(hhmCode_emptyRow, 0);

                cboovc_name.DataSource = dt;

                cboovc_name.DisplayMember = "hhm_name";
                cboovc_name.ValueMember = "hhm_id";
            }

            #region HH Village
            txtvillage.Text = benSchoolReadinessTool.ReturnHHVillage(cboHHCode.SelectedValue.ToString()); //reused
            #endregion
        }

        protected void LoadHHDisplay()
        {
            if (HouseholdId != string.Empty)
            {
                dt = benOvcViralLoad.ReturnHHDetails(HouseholdId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboIP.SelectedValue = dtRow["prt_id"].ToString();
                    cboCso.SelectedValue = dtRow["cso_id"].ToString();
                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboHHCode.SelectedValue = HouseholdId;
                    txtvillage.Text = dtRow["hh_village"].ToString();
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
                txtYOB.Text = dtRow["hhm_year_of_birth"].ToString();
                #region Age
                if (txtYOB.Text != string.Empty)
                {
                    DateTime Year = DateTime.Now;
                    int yr = Year.Year;
                    txtAge.Text = (yr - Convert.ToInt32(txtYOB.Text)).ToString();
                }
                else
                {
                    txtAge.Clear();
                }
                #endregion Age

              
            }
        }

        private void cboovc_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMDetails(cboovc_name.SelectedValue.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    if (ValidateQuarters())
                    {

                        save();
                        MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(strMessage, "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(strMessage, "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        protected void save()
        {
            #region Set Variables
            benOvcViralLoad.prt_id = cboIP.SelectedValue.ToString();
            benOvcViralLoad.cso_id = cboCso.SelectedValue.ToString();
            benOvcViralLoad.wrd_id = cboParish.SelectedValue.ToString();
            benOvcViralLoad.hh_id = cboHHCode.SelectedValue.ToString();
            benOvcViralLoad.qrt_start_date = dtQuarterstartDate.Value;
            benOvcViralLoad.qrt_end_date = dtQuarterEndDate.Value;
            benOvcViralLoad.linc_id = cboLinkagesCordinator.SelectedValue.ToString();
            benOvcViralLoad.sw_id = cboSocialWorker.SelectedValue.ToString();
            benOvcViralLoad.usr_id_create = SystemConstants.user_id;
            benOvcViralLoad.usr_id_update = SystemConstants.user_id;
            benOvcViralLoad.usr_date_create = DateTime.Now;
            benOvcViralLoad.usr_date_update = DateTime.Now;
            benOvcViralLoad.ofc_id = SystemConstants.ofc_id;
            benOvcViralLoad.district_id = SystemConstants.Return_office_district();


            benOvcViralLoad.hhm_id = cboovc_name.SelectedValue.ToString();
            benOvcViralLoad.hef_name = txtHealthFacility.Text;
            benOvcViralLoad.art_number = txtARTNumber.Text;
            benOvcViralLoad.vl_eligible = utilControls.RadioButtonGetSelection(rdnVLYes, rdnVLNo);
            benOvcViralLoad.vl_done = utilControls.RadioButtonGetSelection(rdnVLDoneYes, rdnVLDoneNo);

            benOvcViralLoad.vl_date = dtVLDone.Checked == true ? dtVLDone.Value : Convert.ToDateTime("2000-01-01");
            benOvcViralLoad.vl_nextdate = dtVLNext.Value;
            benOvcViralLoad.suppressed = utilControls.RadioButtonGetSelection(rdnSuppresedYes, rdnSuppresedNo);

            if (benOvcViralLoad._vl_id == string.Empty)
            {
                benOvcViralLoad.vl_id = Guid.NewGuid().ToString();
                benOvcViralLoad.vlm_id = Guid.NewGuid().ToString();

                benOvcViralLoad._vl_id = benOvcViralLoad.save("insert");
                benOvcViralLoad.save_member("insert");
            }
            else
            {
                benOvcViralLoad.vl_id = benOvcViralLoad._vl_id;
                benOvcViralLoad.save("update");

                if (benOvcViralLoad.vlm_id == string.Empty)
                {
                    benOvcViralLoad.vlm_id = Guid.NewGuid().ToString();
                    benOvcViralLoad.save_member("insert");
                }
                else
                {
                    benOvcViralLoad.save_member("update");
                }
            }
            #endregion
        }

        protected bool ValidateQuarters()
        {
            bool isValid = false;

            if ((dtQuarterstartDate.Value.Month != 1 || dtQuarterstartDate.Value.Month != 4 || dtQuarterstartDate.Value.Month != 7 || dtQuarterstartDate.Value.Month != 10) &&
                (dtQuarterstartDate.Value.Day != 1) && (dtQuarterEndDate.Value.Month != 3 || dtQuarterEndDate.Value.Month != 6 || dtQuarterEndDate.Value.Month != 9 || dtQuarterEndDate.Value.Month != 12)
                && (dtQuarterEndDate.Value.Day != 31 || dtQuarterEndDate.Value.Day != 30))
            {
                isValid = false;
                strMessage = "Please fill in valid Quarter date ranges";
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if (dtQuarterstartDate.Checked == false || dtQuarterEndDate.Checked == false || cboLinkagesCordinator.SelectedValue.ToString() == "-1" || txtLC_contact.Text == string.Empty || cboovc_name.SelectedValue.ToString() == "-1"
                || txtHealthFacility.Text == string.Empty || txtARTNumber.Text == string.Empty || (rdnVLYes.Checked == false && rdnVLNo.Checked == false) || (rdnVLDoneYes.Checked == false && rdnVLDoneNo.Checked == false) || (rdnSuppresedYes.Checked == false && rdnSuppresedNo.Checked == false) ||
               dtVLNext.Checked == false || cboSocialWorker.SelectedValue.ToString() == "-1")
            {
                isValid = false;
                strMessage = "Fill in all required values";
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }

        #region LoadDisplay
        protected void LoadMainDisplay(string vl_id)
        {
            dt = benOvcViralLoad.LoadMainDisplay(vl_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                dtQuarterstartDate.Value = Convert.ToDateTime(dtRow["qrt_start_date"]);
                dtQuarterEndDate.Value = Convert.ToDateTime(dtRow["qrt_end_date"]);
                cboLinkagesCordinator.SelectedValue = dtRow["linc_id"].ToString();
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();

                LoadMembersList(vl_id);
            }
        }

        protected void LoadMembersList(string vl_id)
        {
            dt = benOvcViralLoad.LoadMembersList(vl_id);
            if (dt.Rows.Count > 0)
            {
                gdvMembers.DataSource = dt;

                gdvMembers.Columns["vlm_id"].Visible = false;

                gdvMembers.Columns["hhm_first_name"].HeaderText = "First Name";
                gdvMembers.Columns["hhm_last_name"].HeaderText = "Last Name";
                gdvMembers.Columns["hhm_year_of_birth"].HeaderText = "Year of Birth";

                gdvMembers.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvMembers.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvMembers.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvMembers.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvMembers.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        protected void LoadMemberDisplay(string vlm_id)
        {
            dt = benOvcViralLoad.LoadMemberDisplay(vlm_id);
            if (dt != null)
            {
                DataRow dtRow = dt.Rows[0];

                cboovc_name.SelectedValue = dtRow["hhm_id"].ToString();
                txtHealthFacility.Text = dtRow["hef_name"].ToString();
                txtARTNumber.Text = dtRow["art_number"].ToString();
                utilControls.RadioButtonSetSelection(rdnVLYes, rdnVLNo, dtRow["vl_eligible"].ToString());
                utilControls.RadioButtonSetSelection(rdnVLDoneYes, rdnVLDoneNo, dtRow["vl_done"].ToString());
                string vl_date = dtRow["vl_date"].ToString();

                if (vl_date != string.Empty) { dtVLDone.Value = Convert.ToDateTime(dtRow["vl_date"]); }
                else { dtVLDone.Value = DateTime.Now;}

                dtVLNext.Value = Convert.ToDateTime(dtRow["vl_nextdate"]);
                utilControls.RadioButtonSetSelection(rdnSuppresedYes, rdnSuppresedNo, dtRow["suppressed"].ToString());
                benOvcViralLoad.vlm_id = vlm_id;
            }
        }
        #endregion

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

        private void gdvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvMembers.Rows.Count > 0)
            {
                LoadMemberDisplay(gdvMembers.CurrentRow.Cells[0].Value.ToString());
            }
        }

        protected void Clear()
        {
            dtQuarterstartDate.Value = DateTime.Now;
            dtQuarterEndDate.Value = DateTime.Now;
            cboLinkagesCordinator.SelectedValue = "-1";
            txtLC_contact.Clear();
            cboovc_name.SelectedValue = "-1";
            txtHealthFacility.Clear();
            txtARTNumber.Clear();
            rdnVLYes.Checked = false;
            rdnVLNo.Checked = false;
            rdnVLDoneYes.Checked = false;
            rdnVLDoneNo.Checked = false;
            rdnSuppresedYes.Checked = false;
            rdnSuppresedNo.Checked = false;
            dtVLDone.Checked = false;
            dtVLNext.Checked = false;
            dtVLDone.Value = DateTime.Today;
            dtVLNext.Value = DateTime.Today;
            cboSocialWorker.SelectedValue = "-1";
            txtSocialWorkerPhone.Clear();
            benOvcViralLoad._vl_id = string.Empty;
            benOvcViralLoad.vl_id = string.Empty;
            benOvcViralLoad.vlm_id = string.Empty;
            benOvcViralLoad.prt_id = string.Empty;
            benOvcViralLoad.cso_id = string.Empty;
            benOvcViralLoad.wrd_id = string.Empty;
            benOvcViralLoad.hh_id = string.Empty;
            benOvcViralLoad.qrt_start_date = DateTime.Now;
            benOvcViralLoad.qrt_end_date = DateTime.Now;
            benOvcViralLoad.linc_id = string.Empty;
            benOvcViralLoad.sw_id = string.Empty;
            benOvcViralLoad.hhm_id = string.Empty;
            benOvcViralLoad.hef_name = string.Empty;
            benOvcViralLoad.art_number = string.Empty;
            benOvcViralLoad.vl_eligible = string.Empty;
            benOvcViralLoad.vl_done = string.Empty;
            benOvcViralLoad.vl_date = DateTime.Today;
            benOvcViralLoad.vl_nextdate = DateTime.Now;
            benOvcViralLoad.suppressed = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboLinkagesCordinator_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLC_contact.Text = benOvcViralLoad.LoadLinkangesCoordinatorPhone(cboLinkagesCordinator.SelectedValue.ToString());
        }
    }
}
