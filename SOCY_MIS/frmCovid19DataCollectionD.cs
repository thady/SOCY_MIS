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

        }
    }
}
