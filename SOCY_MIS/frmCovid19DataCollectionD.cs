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
    public partial class frmCovid19DataCollection : UserControl
    {
        #region Variables
        private frmCovid19DataCollectionSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = new DataTable();
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        private string UsrMessage = string.Empty;
        #endregion Variables

        #region Property
        public frmCovid19DataCollectionSearch FormCallingSearch
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

        public frmCovid19DataCollection()
        {
            InitializeComponent();
        }

        private void frmCovid19DataCollection_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadDetails();
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

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
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

            cboSubCounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCounty.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion subcounty

        }

        protected void ReturnSocialWorkers()
        {
            #region Social Workers
            dt = benEducationSubsidy.Return_SocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString(), "SW");  //reused
            DataRow emptyRow = dt.NewRow();
            emptyRow["swk_id"] = "-1";
            emptyRow["swk_name"] = "Select Social Worker";
            dt.Rows.InsertAt(emptyRow, 0);

            cboSocialWorker.DataSource = dt;
            cboSocialWorker.ValueMember = "swk_id";
            cboSocialWorker.DisplayMember = "swk_name";

            cboSocialWorker.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSocialWorker.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion  Social Workers

            #region Social Workers
            dt = benEducationSubsidy.Return_SocialWorkerList(Convert.ToInt32(cboDistrict.SelectedValue.ToString()), cboSubCounty.SelectedValue.ToString(), "PSW");  //reused
            DataRow _emptyRow = dt.NewRow();
            _emptyRow["swk_id"] = "-1";
            _emptyRow["swk_name"] = "Select Social Worker";
            dt.Rows.InsertAt(_emptyRow, 0);

            cboParaSocialWorker.DataSource = dt;
            cboParaSocialWorker.ValueMember = "swk_id";
            cboParaSocialWorker.DisplayMember = "swk_name";

            cboParaSocialWorker.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParaSocialWorker.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion  Social Workers
        }


        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

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

            ReturnSocialWorkers();
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("parishCovid19", string.Empty,string.Empty, cboSubCounty.SelectedValue.ToString(), string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion subcounty
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValdateInput())
            {
                save();
                MessageBox.Show(UsrMessage, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(UsrMessage, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region save
        protected void save()
        {
            #region variables
            benCovid19DataCollection.wrd_id = cboParish.SelectedValue.ToString();
            benCovid19DataCollection.report_month = cboReportMonth.Text;
            benCovid19DataCollection.week_name = cboReportWeek.Text;
            benCovid19DataCollection.swk_id = cboSocialWorker.SelectedValue.ToString();
            benCovid19DataCollection.psw_id = cboParaSocialWorker.SelectedValue.ToString();
            benCovid19DataCollection.total_hh_visited = txtNumberofHouseholds.Value.ToString();
            benCovid19DataCollection.total_hh_hip_reviewed = txtNumberHouseholdsHipReviewed.Value.ToString();
            benCovid19DataCollection.total_ben_served = txtBeneficiaiesserved.Value.ToString();
            benCovid19DataCollection.total_ben_hiv_pos = txtPosCount.Value.ToString();
            benCovid19DataCollection.total_ben_hiv_neg = txtNegCount.Value.ToString();
            benCovid19DataCollection.total_ben_hiv_tnr = txtTNRCount.Value.ToString();
            benCovid19DataCollection.total_ben_hiv_unknown = txtUnknownStatus.Value.ToString();
            benCovid19DataCollection.total_ben_risk_assessed = txtNumberRiskAssesed.Value.ToString();
            benCovid19DataCollection.total_new_referals_made = txtNewReferalCount.Value.ToString();
            benCovid19DataCollection.total_old_referals_followedup = txtReferalFowwedUp.Value.ToString();
            benCovid19DataCollection.total_ben_with_vl = txtBenefiariesVLDone.Value.ToString();
            benCovid19DataCollection.total_ben_not_supress = txtNotSupressing.Value.ToString();
            benCovid19DataCollection.total_emergency_case_found = txtEmergencyCaseCount.Value.ToString();
            benCovid19DataCollection.general_comment = txtComments.Text;
            benCovid19DataCollection.usr_id_create = SystemConstants.user_id;
            benCovid19DataCollection.usr_id_update = SystemConstants.user_id;
            benCovid19DataCollection.usr_date_create = DateTime.Now;
            benCovid19DataCollection.usr_date_update = DateTime.Now;
            benCovid19DataCollection.ofc_id = SystemConstants.ofc_id;
            benCovid19DataCollection.district_id = SystemConstants.Return_office_district();
            #endregion

            if (lblid.Text == "--")
            {
                benCovid19DataCollection.cdc_id = Guid.NewGuid().ToString();
                benCovid19DataCollection.save(dbCon);
                Clear();
            }
            else
            {
                benCovid19DataCollection.cdc_id = lblid.Text;
                benCovid19DataCollection.update(dbCon);
            }
        }
        #endregion

        #region Validate
        protected bool ValdateInput()
        {
            bool isValid = false;
            if(cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" || cboParish.SelectedValue.ToString() == "-1" || 
                cboReportMonth.Text == string.Empty || cboReportWeek.Text == string.Empty || cboSocialWorker.SelectedValue.ToString() == "-1" || 
                cboParaSocialWorker.SelectedValue.ToString() == "-1")
            {
                isValid = false;
                UsrMessage = "Please select all required values";
            }
            else if (txtNumberofHouseholds.Value == 0 & txtNumberHouseholdsHipReviewed.Value == 0 & txtBeneficiaiesserved.Value == 0 & txtPosCount.Value == 0 & txtNegCount.Value == 0 &
                txtTNRCount.Value == 0 & txtUnknownStatus.Value == 0 & txtNumberRiskAssesed.Value == 0 & txtNewReferalCount.Value == 0 & txtReferalFowwedUp.Value == 0 & txtBenefiariesVLDone.Value == 0 &
                txtNotSupressing.Value == 0 & txtEmergencyCaseCount.Value == 0)
            {
                isValid = false;
                UsrMessage = "All tools collected cannot be zero!please indicate atleast one category of tools collected during this period";
            }
            else
            {
                isValid = true;
                UsrMessage = "Success";
            }

            return isValid;
        }
        #endregion

        #region Clear
        protected void Clear()
        {
            benCovid19DataCollection.wrd_id = "-1";
            benCovid19DataCollection.report_month = string.Empty;
            benCovid19DataCollection.week_name = string.Empty;
            benCovid19DataCollection.swk_id = "-1";
            benCovid19DataCollection.psw_id = "-1";
            benCovid19DataCollection.total_hh_visited = string.Empty;
            benCovid19DataCollection.total_hh_hip_reviewed = string.Empty;
            benCovid19DataCollection.total_ben_served = string.Empty;
            benCovid19DataCollection.total_ben_hiv_pos = string.Empty;
            benCovid19DataCollection.total_ben_hiv_neg = string.Empty;
            benCovid19DataCollection.total_ben_hiv_tnr = string.Empty;
            benCovid19DataCollection.total_ben_hiv_unknown = string.Empty;
            benCovid19DataCollection.total_ben_risk_assessed = string.Empty;
            benCovid19DataCollection.total_new_referals_made = string.Empty;
            benCovid19DataCollection.total_old_referals_followedup = string.Empty;
            benCovid19DataCollection.total_ben_with_vl = string.Empty;
            benCovid19DataCollection.total_ben_not_supress = string.Empty;
            benCovid19DataCollection.total_emergency_case_found = string.Empty;
            benCovid19DataCollection.general_comment = string.Empty;
            benCovid19DataCollection.cdc_id = string.Empty;

            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            cboReportMonth.Text = string.Empty;
            cboReportWeek.Text = string.Empty;
            cboSocialWorker.SelectedValue = "-1";
            cboParaSocialWorker.SelectedValue = "-1";
            txtNumberofHouseholds.Value = 0;
            txtNumberHouseholdsHipReviewed.Value = 0;
            txtBeneficiaiesserved.Value = 0;
            txtPosCount.Value = 0;
            txtNegCount.Value = 0;
            txtTNRCount.Value = 0;
            txtUnknownStatus.Value = 0;
            txtNumberRiskAssesed.Value = 0;
            txtNewReferalCount.Value = 0;
            txtReferalFowwedUp.Value = 0;
            txtBenefiariesVLDone.Value = 0;
            txtNotSupressing.Value = 0;
            txtEmergencyCaseCount.Value = 0;
            txtComments.Clear();
            lblid.Text = "--";
        }
        #endregion Clear

        #region LoadDetails
        protected void LoadDetails()
        {
            dt = benCovid19DataCollection.LoadDetails(benCovid19DataCollection.cdc_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                cboReportMonth.Text = dtRow["report_month"].ToString();
                cboReportWeek.Text = dtRow["week_name"].ToString();
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
                cboParaSocialWorker.SelectedValue = dtRow["psw_id"].ToString();
                txtNumberofHouseholds.Value = Convert.ToInt32(dtRow["total_hh_visited"].ToString());
                txtNumberHouseholdsHipReviewed.Value = Convert.ToInt32(dtRow["total_hh_hip_reviewed"].ToString());
                txtBeneficiaiesserved.Value = Convert.ToInt32(dtRow["total_ben_served"].ToString());
                txtPosCount.Value = Convert.ToInt32(dtRow["total_ben_hiv_pos"].ToString());
                txtNegCount.Value = Convert.ToInt32(dtRow["total_ben_hiv_neg"].ToString());
                txtTNRCount.Value = Convert.ToInt32(dtRow["total_ben_hiv_tnr"].ToString());
                txtUnknownStatus.Value = Convert.ToInt32(dtRow["total_ben_hiv_unknown"].ToString());
                txtNumberRiskAssesed.Value = Convert.ToInt32(dtRow["total_ben_risk_assessed"].ToString());
                txtNewReferalCount.Value = Convert.ToInt32(dtRow["total_new_referals_made"].ToString());
                txtReferalFowwedUp.Value = Convert.ToInt32(dtRow["total_old_referals_followedup"].ToString());
                txtBenefiariesVLDone.Value = Convert.ToInt32(dtRow["total_ben_with_vl"].ToString());
                txtNotSupressing.Value = Convert.ToInt32(dtRow["total_ben_not_supress"].ToString());
                Convert.ToInt32(dtRow["total_emergency_case_found"].ToString());
                txtComments.Text = dtRow["general_comment"].ToString();
                lblid.Text = dtRow["cdc_id"].ToString();
            }
            else
            {
                Clear();
            }
        }
        #endregion

        private void lblNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void llnback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);

        }

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
    }
}
