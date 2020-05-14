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
    public partial class frmARTRefill : UserControl
    {
        #region Variables
        private frmArtRefillSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = new DataTable();
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        private string UsrMessage = string.Empty;
        #endregion Variables

        #region Property
        public frmArtRefillSearch FormCallingSearch
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
        #endregion Property
        public frmARTRefill()
        {
            InitializeComponent();
        }

        private void frmARTRefill_Load(object sender, EventArgs e)
        {
            Return_lookups();

            LoadDetails(SOCYARTRefill._artr_id);
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

            cboCSO.DataSource = dt;
            cboCSO.DisplayMember = "cso_other";
            cboCSO.ValueMember = "cso_id";
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

        }

        private void Back()
        {
            //FormCallingSearch.BackDisplay();
            FormParent.LoadControl(FormCallingSearch, this.Name);

        }

        private void llnback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region LoadCSOs
            dt = silcCommunityTrainingRegister.Return_lookups("CSO", cboIP.SelectedIndex != -1 ? cboIP.SelectedValue.ToString() : string.Empty, string.Empty, string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCSO.DataSource = dt;
            cboCSO.DisplayMember = "cso_other";
            cboCSO.ValueMember = "cso_id";
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

            ReturnSocialWorkers();
        }

        protected void ReturnSocialWorkers()
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

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),string.Empty);  //reused

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHouseholdCode.DataSource = dt;

            cboHouseholdCode.DisplayMember = "hh_code";
            cboHouseholdCode.ValueMember = "hh_id";
            #endregion HH Codes
        }

        private void cboHouseholdCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = SOCYARTRefill.LoadPositiveMmebers(cboHouseholdCode.SelectedValue.ToString());

            DataRow hhmCode_emptyRow = dt.NewRow();
            hhmCode_emptyRow["hhm_id"] = "-1";
            hhmCode_emptyRow["hhm_name"] = "select member";
            dt.Rows.InsertAt(hhmCode_emptyRow, 0);

            cboBeneficiaryName.DataSource = dt;

            cboBeneficiaryName.DisplayMember = "hhm_name";
            cboBeneficiaryName.ValueMember = "hhm_id";
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = benSchoolReadinessTool.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                string YearOfBirth = dtRow["hhm_year_of_birth"].ToString();

                #region Age
                DateTime Year = DateTime.Now;
                int yr = Year.Year;
                txtAge.Text = (yr - Convert.ToInt32(YearOfBirth)).ToString();
                #endregion Age

                txtbeneficiaryName.Text = cboBeneficiaryName.Text;
            }
            else
            {
                cboSex.SelectedValue = "-1";
                txtAge.Clear();
                txtbeneficiaryName.Clear();
            }
        }

        private void cboBeneficiaryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMDetails(cboBeneficiaryName.SelectedValue.ToString());
        }

        private void cboDirectBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDirectBeneficiary.Text == "Yes")
            {
                cboHouseholdCode.SelectedValue = "-1";
                cboHouseholdCode.Enabled = true;
                cboBeneficiaryName.SelectedValue = "-1";
                cboBeneficiaryName.Enabled = true;
                txtbeneficiaryName.ReadOnly = true;
                txtAge.ReadOnly = true;
                cboSex.Enabled = false;
            }
            else
            {
                cboHouseholdCode.SelectedValue = "-1";
                cboHouseholdCode.Enabled = false;
                cboBeneficiaryName.SelectedValue = "-1";
                cboBeneficiaryName.Enabled = false;
                txtbeneficiaryName.ReadOnly = false;
                txtAge.ReadOnly = false;
                cboSex.Enabled = true;
            }

        }

        #region save
        protected void save()
        {
            #region Variables
            SOCYARTRefill.ip_id = cboIP.SelectedValue.ToString();
            SOCYARTRefill.cso_id = cboCSO.SelectedValue.ToString();
            SOCYARTRefill.sct_id = cboSubCounty.SelectedValue.ToString();
            SOCYARTRefill.refill_date = dtDate.Value;
            SOCYARTRefill.yn_direct_beneficiary = cboDirectBeneficiary.Text;
            SOCYARTRefill.hh_id = cboHouseholdCode.SelectedValue.ToString();
            SOCYARTRefill.hhm_id = cboBeneficiaryName.SelectedValue.ToString();
            SOCYARTRefill.hhm_name = txtbeneficiaryName.Text;
            SOCYARTRefill.hhm_age = txtAge.Text;
            SOCYARTRefill.gnd_id = cboSex.SelectedValue.ToString();
            SOCYARTRefill.attached_health_facility = txtHealthFacilty.Text;
            SOCYARTRefill.art_number = txtARTNumber.Text;
            SOCYARTRefill.period_refill_taken = cboRefillPeriod.Text;
            SOCYARTRefill.beneficiary_contact = txtbeneficiaryContact.Text;
            SOCYARTRefill.swk_id = cboSocialWorker.SelectedValue.ToString();
            SOCYARTRefill.swk_phone = txtSocialWorkerContact.Text;
            SOCYARTRefill.usr_id_create = SystemConstants.user_id;
            SOCYARTRefill.usr_id_update = SystemConstants.user_id;
            SOCYARTRefill.usr_date_create = DateTime.Now;
            SOCYARTRefill.usr_date_update = DateTime.Now;
            SOCYARTRefill.ofc_id = SystemConstants.ofc_id;
            SOCYARTRefill.district_id = SystemConstants.Return_office_district();
            #endregion

            if (lblid.Text == "--")
            {
                SOCYARTRefill.artr_id = Guid.NewGuid().ToString();
                lblid.Text = SOCYARTRefill.artr_id;
                SOCYARTRefill.save(dbCon);
                MessageBox.Show(UsrMessage,"SOCYMIS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                SOCYARTRefill.artr_id = lblid.Text;
                SOCYARTRefill.update(dbCon);
                MessageBox.Show(UsrMessage, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        protected bool ValidateInput()
        {
            bool isValid = false;

            if(cboIP.SelectedValue.ToString() == "-1" || cboCSO.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" || 
                !dtDate.Checked || cboDirectBeneficiary.Text == string.Empty || txtbeneficiaryName.Text == string.Empty || txtAge.Text == string.Empty || cboSex.SelectedValue.ToString() == "-1" || 
                txtHealthFacilty.Text == string.Empty || txtARTNumber.Text == string.Empty || cboRefillPeriod.Text == string.Empty || cboSocialWorker.SelectedValue.ToString() == "-1")
            {
                isValid = false;
                UsrMessage = "Please fill in all required fields marked with(*)";
            }
            else if (cboDirectBeneficiary.Text == "Yes" & (cboHouseholdCode.SelectedValue.ToString() == "-1" || cboBeneficiaryName.SelectedValue.ToString() == "-1"))
            {
                isValid = false;
                UsrMessage = "This is a direct beneficiary,please select the household and beneficiary name from the list";
            }
            else
            {
                isValid = true;
                UsrMessage = "Success";
            }

            return isValid;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                save();
            }
            else
            {
                MessageBox.Show(UsrMessage, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSocialWorkerContact.Text = SOCYARTRefill.LoadSocialWOrkerPhone(cboSocialWorker.SelectedValue.ToString());
        }

        protected void LoadDetails(string id)
        {
            dt = SOCYARTRefill.LoadDetails(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboIP.SelectedValue = dtRow["ip_id"].ToString();
                cboCSO.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["refill_date"].ToString());
                cboDirectBeneficiary.Text = dtRow["yn_direct_beneficiary"].ToString();
                cboHouseholdCode.SelectedValue = dtRow["hh_id"].ToString();
                cboBeneficiaryName.SelectedValue = dtRow["hhm_id"].ToString();
                txtbeneficiaryName.Text = dtRow["hhm_name"].ToString();
                txtAge.Text = dtRow["hhm_age"].ToString();
                cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                txtHealthFacilty.Text = dtRow["attached_health_facility"].ToString();
                txtARTNumber.Text = dtRow["art_number"].ToString();
                cboRefillPeriod.Text = dtRow["period_refill_taken"].ToString();
                txtbeneficiaryContact.Text = dtRow["beneficiary_contact"].ToString();
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
                txtSocialWorkerContact.Text = dtRow["swk_phone"].ToString();
                lblid.Text = id;
            }
            else
            {
                Clear();
            }
        }

        protected void Clear()
        {
            cboIP.SelectedValue = "-1";
            cboCSO.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            dtDate.Value = DateTime.Today;
            cboDirectBeneficiary.Text = string.Empty;
            cboHouseholdCode.SelectedValue = "-1";
            cboBeneficiaryName.SelectedValue = "-1";
            txtbeneficiaryName.Text = string.Empty;
            txtAge.Clear();
            cboSex.SelectedValue = "-1";
            txtHealthFacilty.Clear();
            txtARTNumber.Clear();
            cboRefillPeriod.Text = string.Empty;
            txtbeneficiaryContact.Clear();
            cboSocialWorker.SelectedValue = "-1";
            txtSocialWorkerContact.Clear();
            dtDate.Checked = false;

            lblid.Text = "--";
            cboHouseholdCode.Enabled = true;
            cboBeneficiaryName.Enabled = true;
            txtbeneficiaryName.ReadOnly = false;
            txtAge.ReadOnly = false;
            cboSex.Enabled = true;
        }

        private void lblNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void tplButton01_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
