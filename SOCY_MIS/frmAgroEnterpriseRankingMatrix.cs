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
    public partial class frmAgroEnterpriseRankingMatrix : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmAgroEnterpriseRankingMatrixSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmAgroEnterpriseRankingMatrixSearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmAgroEnterpriseRankingMatrix()
        {
            InitializeComponent();
        }

        private void frmAgroEnterpriseRankingMatrix_Load(object sender, EventArgs e)
        {
            SetToolHeadings();

            LoadAgroEnterpriseCrops(cboCrop_one);
            LoadAgroEnterpriseCrops(cboCrop_two);
            LoadAgroEnterpriseCrops(cboCrop_three);
            LoadAgroEnterpriseCrops(cboCrop_four);
            LoadAgroEnterpriseCrops(cboCrop_five);

            ReturnRankingParams();

            Return_lookups();

            LoadDisplay(AgroEnterpriseRankingMatrix.agro_ent_id);
        }

        protected void LoadAgroEnterpriseCrops(ComboBox cbo)
        {
            dt = AgroEnterpriseRankingMatrix.Return_AgroEnterpriseCrops();
            if (dt.Rows.Count > 0)
            {
                DataRow dstemptyRow = dt.NewRow();
                dstemptyRow["crop_sid"] = "-1";
                dstemptyRow["crop_name"] = "Select one";
                dt.Rows.InsertAt(dstemptyRow, 0);

                cbo.DataSource = dt;
                cbo.DisplayMember = "crop_name";
                cbo.ValueMember = "crop_sid";
            }
        }

        protected void SetToolHeadings()
        {
            switch (AgroEnterpriseRankingMatrix.type) {
                case "crop":
                    lblHeaderMain.Text = "Agro-Enterprise Ranking and Selection Tool";
                    lblHeaderCrops.Text = "Select five crops below";
                    lblcrop1.Text = "Crop 1";
                    lblcrop2.Text = "Crop 2";
                    lblcrop3.Text = "Crop 3";
                    lblcrop4.Text = "Crop 4";
                    lblcrop5.Text = "Crop 5";
                    break;
                case "cottage":
                    lblHeaderMain.Text = "Enterprise selection tool for cottage industry training";
                    lblHeaderCrops.Text = "Select five cottages below";
                    lblcrop1.Text = "Cottage 1";
                    lblcrop2.Text = "Cottage 2";
                    lblcrop3.Text = "Cottage 3";
                    lblcrop4.Text = "Cottage 4";
                    lblcrop5.Text = "Cottage 5";
                    break;
            }
        }

        protected void ReturnRankingParams()
        {
            dt = AgroEnterpriseRankingMatrix.Return_AgroEnterpriseRankingMatrixParameters();
            if (dt.Rows.Count > 0)
            {
                DataColumn asp_id = new DataColumn("asp_id", typeof(string));
                DataColumn asp_name = new DataColumn("asp_name", typeof(string));
                DataColumn crop_one = new DataColumn("crop_one", typeof(string));
                DataColumn crop_two = new DataColumn("crop_two", typeof(string));
                DataColumn crop_three = new DataColumn("crop_three", typeof(string));
                DataColumn crop_four = new DataColumn("crop_four", typeof(string));
                DataColumn crop_five = new DataColumn("crop_five", typeof(string));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dtRow = dt.Rows[i];
                    this.gdvAgroParent.Rows.Add(dtRow["asp_id"].ToString(), dtRow["asp_name"].ToString(), "", "", "", "", "");
                }

                // gdvAgroParent.DataSource = dt;
                gdvAgroParent.Columns["asp_id"].Visible = false;
                gdvAgroParent.Columns["asp_name"].HeaderText = "Scoring Parameter";

                switch (AgroEnterpriseRankingMatrix.type) {
                    case "crop":
                        gdvAgroParent.Columns["crop_one"].HeaderText = "Crop 1";
                        gdvAgroParent.Columns["crop_two"].HeaderText = "Crop 2";
                        gdvAgroParent.Columns["crop_three"].HeaderText = "Crop 3";
                        gdvAgroParent.Columns["crop_four"].HeaderText = "Crop 4";
                        gdvAgroParent.Columns["crop_five"].HeaderText = "Crop 5";
                        break;
                    case "cottage":
                        gdvAgroParent.Columns["crop_one"].HeaderText = "Cottage 1";
                        gdvAgroParent.Columns["crop_two"].HeaderText = "Cottage 2";
                        gdvAgroParent.Columns["crop_three"].HeaderText = "Cottage 3";
                        gdvAgroParent.Columns["crop_four"].HeaderText = "Cottage 4";
                        gdvAgroParent.Columns["crop_five"].HeaderText = "Cottage 5";
                        break;
                }
                

                #region Add score row
                this.gdvAgroParent.Rows.Add("", "TOTAL SCORES", "", "", "", "", "");
                this.gdvAgroParent.Rows.Add("", "RANKS", "", "", "", "", "");

                switch (AgroEnterpriseRankingMatrix.type)
                {
                    case "crop":
                        gdvAgroParent.Rows[8].ReadOnly = true;
                        gdvAgroParent.Rows[9].ReadOnly = true;

                        gdvAgroParent.Rows[8].DefaultCellStyle.BackColor = Color.Black;
                        gdvAgroParent.Rows[8].DefaultCellStyle.ForeColor = Color.White;
                        gdvAgroParent.Rows[9].DefaultCellStyle.BackColor = Color.Black;
                        gdvAgroParent.Rows[9].DefaultCellStyle.ForeColor = Color.White;
                        gdvAgroParent.Rows[8].DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
                        gdvAgroParent.Rows[9].DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
                        break;
                    case "cottage":
                        gdvAgroParent.Rows[6].ReadOnly = true;
                        gdvAgroParent.Rows[7].ReadOnly = true;

                        gdvAgroParent.Rows[6].DefaultCellStyle.BackColor = Color.Black;
                        gdvAgroParent.Rows[6].DefaultCellStyle.ForeColor = Color.White;
                        gdvAgroParent.Rows[7].DefaultCellStyle.BackColor = Color.Black;
                        gdvAgroParent.Rows[7].DefaultCellStyle.ForeColor = Color.White;
                        gdvAgroParent.Rows[6].DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
                        gdvAgroParent.Rows[7].DefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);
                        break;
                }
               
                #endregion

                gdvAgroParent.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvAgroParent.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvAgroParent.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvAgroParent.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvAgroParent.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvAgroParent.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvAgroParent.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvAgroParent.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvAgroParent.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvAgroParent.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }
        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
            AgroEnterpriseRankingMatrix.agro_ent_id = string.Empty;
            AgroEnterpriseRankingMatrix.agro_entm_id = string.Empty;
        }

        private void lblback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void cboCrop_one_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCrop_four_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCrop_three_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCrop_five_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCrop_two_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected Boolean ValidateCrop(ComboBox cbo)
        {
            bool isValid = false;
            if (cbo.SelectedValue.ToString() != "-1" && cbo.Name == "cboCrop_one")
            {
                if (cbo.SelectedValue.ToString() != cboCrop_two.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_three.SelectedValue.ToString()
                    && cbo.SelectedValue.ToString() != cboCrop_four.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_five.SelectedValue.ToString())
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (cbo.SelectedValue.ToString() != "-1" && cbo.Name == "cboCrop_two")
            {
                if (cbo.SelectedValue.ToString() != cboCrop_one.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_three.SelectedValue.ToString()
                   && cbo.SelectedValue.ToString() != cboCrop_four.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_five.SelectedValue.ToString())
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (cbo.SelectedValue.ToString() != "-1" && cbo.Name == "cboCrop_three")
            {
                if (cbo.SelectedValue.ToString() != cboCrop_one.SelectedValue.ToString() && cboCrop_one.SelectedValue.ToString() != cboCrop_two.SelectedValue.ToString()
                  && cbo.SelectedValue.ToString() != cboCrop_four.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_five.SelectedValue.ToString())
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (cbo.SelectedValue.ToString() != "-1" && cbo.Name == "cboCrop_four")
            {
                if (cbo.SelectedValue.ToString() != cboCrop_one.SelectedValue.ToString() && cboCrop_one.SelectedValue.ToString() != cboCrop_two.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_three.SelectedValue.ToString()
                   && cbo.SelectedValue.ToString() != cboCrop_five.SelectedValue.ToString())
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else if (cbo.SelectedValue.ToString() != "-1" && cbo.Name == "cboCrop_five")
            {
                if (cbo.SelectedValue.ToString() != cboCrop_one.SelectedValue.ToString() && cboCrop_one.SelectedValue.ToString() != cboCrop_two.SelectedValue.ToString() && cbo.SelectedValue.ToString() != cboCrop_three.SelectedValue.ToString()
                  && cbo.SelectedValue.ToString() != cboCrop_four.SelectedValue.ToString())
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private void btnmsaveMember_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                if (ValidateInput())
                {
                    CalculateCropScore("one");
                    CalculateCropScore("two");
                    CalculateCropScore("three");
                    CalculateCropScore("four");
                    CalculateCropScore("five");

                    RankCropScores();

                    Save();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Missing required values!All fields marked(*) are required!.All 5 crops are required!.All crop scores are required!", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void cboCrop_one_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ValidateCrop(cboCrop_one) == true)
            {
                if (gdvAgroParent.Rows.Count > 0)
                {
                    if (cboCrop_one.SelectedValue.ToString() != "-1")
                    {
                        gdvAgroParent.Columns["crop_one"].HeaderText = AgroEnterpriseRankingMatrix.Return_AgroCropName(Convert.ToInt32(cboCrop_one.SelectedValue.ToString()));
                    }
                    else
                    {
                        gdvAgroParent.Columns["crop_one"].HeaderText = "Crop 1";
                    }

                }
            }
            else
            {
                MessageBox.Show("Crop already selected for ranking", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gdvAgroParent.Columns["crop_one"].HeaderText = "Crop 1";

            }

        }

        private void cboCrop_two_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ValidateCrop(cboCrop_two) == true)
            {
                if (gdvAgroParent.Rows.Count > 0)
                {
                    if (gdvAgroParent.Rows.Count > 0)
                    {
                        if (cboCrop_two.SelectedValue.ToString() != "-1")
                        {
                            gdvAgroParent.Columns["crop_two"].HeaderText = AgroEnterpriseRankingMatrix.Return_AgroCropName(Convert.ToInt32(cboCrop_two.SelectedValue.ToString()));
                        }
                        else
                        {
                            gdvAgroParent.Columns["crop_two"].HeaderText = "Crop 2";
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Crop already selected for ranking", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gdvAgroParent.Columns["crop_two"].HeaderText = "Crop 2";
            }
        }

        private void cboCrop_three_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ValidateCrop(cboCrop_three) == true)
            {
                if (gdvAgroParent.Rows.Count > 0)
                {
                    if (cboCrop_three.SelectedValue.ToString() != "-1")
                    {
                        gdvAgroParent.Columns["crop_three"].HeaderText = AgroEnterpriseRankingMatrix.Return_AgroCropName(Convert.ToInt32(cboCrop_three.SelectedValue.ToString()));
                    }
                    else
                    {
                        gdvAgroParent.Columns["crop_three"].HeaderText = "Crop 3";
                    }

                }
            }
            else
            {
                MessageBox.Show("Crop already selected for ranking", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gdvAgroParent.Columns["crop_three"].HeaderText = "Crop 3";
            }
        }

        private void cboCrop_four_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ValidateCrop(cboCrop_four) == true)
            {
                if (gdvAgroParent.Rows.Count > 0)
                {
                    if (cboCrop_four.SelectedValue.ToString() != "-1")
                    {
                        gdvAgroParent.Columns["crop_four"].HeaderText = AgroEnterpriseRankingMatrix.Return_AgroCropName(Convert.ToInt32(cboCrop_four.SelectedValue.ToString()));
                    }
                    else
                    {
                        gdvAgroParent.Columns["crop_four"].HeaderText = "Crop 4";
                    }

                }
            }
            else
            {
                MessageBox.Show("Crop already selected for ranking", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gdvAgroParent.Columns["crop_four"].HeaderText = "Crop 4";
            }
        }

        private void cboCrop_five_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ValidateCrop(cboCrop_five) == true)
            {
                if (gdvAgroParent.Rows.Count > 0)
                {
                    if (cboCrop_five.SelectedValue.ToString() != "-1")
                    {
                        gdvAgroParent.Columns["crop_five"].HeaderText = AgroEnterpriseRankingMatrix.Return_AgroCropName(Convert.ToInt32(cboCrop_five.SelectedValue.ToString()));
                    }
                    else
                    {
                        gdvAgroParent.Columns["crop_five"].HeaderText = "Crop 5";
                    }

                }
            }
            else
            {
                MessageBox.Show("Crop already selected for ranking", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gdvAgroParent.Columns["crop_five"].HeaderText = "Crop 5";
            }
        }

        protected void Return_lookups()
        {
            #region districts
            dt = benYouthTrainingInventory.Return_lookups("district", string.Empty, string.Empty, string.Empty); //reused

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
            #region IP
            dt = benYouthTrainingInventory.Return_lookups("IP", string.Empty, string.Empty, string.Empty);

            DataRow ipemptyRow = dt.NewRow();
            ipemptyRow["prt_id"] = "-1";
            ipemptyRow["prt_name"] = "Select IP";
            dt.Rows.InsertAt(ipemptyRow, 0);

            cboIP.DataSource = dt;
            cboIP.DisplayMember = "prt_name";
            cboIP.ValueMember = "prt_id";
            #endregion IP

            #region subcounty
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

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

            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty);

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
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region CSO
            dt = benYouthTrainingInventory.Return_lookups("CSO", cboIP.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow csoemptyRow = dt.NewRow();
            csoemptyRow["cso_id"] = "-1";
            csoemptyRow["cso_other"] = "Select CSO";
            dt.Rows.InsertAt(csoemptyRow, 0);

            cboCso.DataSource = dt;
            cboCso.DisplayMember = "cso_other";
            cboCso.ValueMember = "cso_id";
            #endregion CSO
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

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

            cboParish.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParish.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion Load Parishes
            
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

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHCode.SelectedValue.ToString() != "-1")
            {
                dt = AgroEnterpriseRankingMatrix.Return_HHYouthMembers(cboHHCode.SelectedValue.ToString(), AgroEnterpriseRankingMatrix.type);

                DataRow hhCode_emptyRow = dt.NewRow();
                hhCode_emptyRow["hhm_id"] = "-1";
                hhCode_emptyRow["hhm_name"] = "select Youth";
                dt.Rows.InsertAt(hhCode_emptyRow, 0);

                cboHHMemberName.DataSource = dt;

                cboHHMemberName.DisplayMember = "hhm_name";
                cboHHMemberName.ValueMember = "hhm_id";
            }
            else
            {
                dt = AgroEnterpriseRankingMatrix.Return_HHYouthMembers(cboHHCode.SelectedValue.ToString(), AgroEnterpriseRankingMatrix.type);

                DataRow hhCode_emptyRow = dt.NewRow();
                hhCode_emptyRow["hhm_id"] = "-1";
                hhCode_emptyRow["hhm_name"] = "select Youth";
                dt.Rows.InsertAt(hhCode_emptyRow, 0);

                cboHHMemberName.DataSource = dt;

                cboHHMemberName.DisplayMember = "hhm_name";
                cboHHMemberName.ValueMember = "hhm_id";
            }

        }

        protected void ReturnHHMData(string hhm_id)
        {
            dt = silcCommunityTrainingRegister.Return_lookups("hhm_details_communityTrainingRegister", hhm_id, string.Empty, string.Empty,string.Empty);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txtMemberCode.Text = dtRow["hhm_name"].ToString() != string.Empty ? dtRow["hhm_name"].ToString() : "";
                cboSex.SelectedValue = dtRow["gnd_id"].ToString() != string.Empty ? dtRow["gnd_id"].ToString() : "-1";
                txtMemberCode.Text = dtRow["hhm_number"].ToString() != string.Empty ? dtRow["hhm_number"].ToString() : "";

                #region Age
                int BirthYear = Convert.ToInt32(dtRow["hhm_year_of_birth"].ToString());
                if (BirthYear != -1)
                {
                    txtAge.Text = (DateTime.Now.Year - BirthYear).ToString();
                }
                else
                {
                    txtAge.Text = string.Empty;
                }
                #endregion Age
            }
        }

        private void cboHHMemberName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnHHMData(cboHHMemberName.SelectedValue.ToString());
        }

        #region Save
        protected void Save()
        {
            #region set variables
            AgroEnterpriseRankingMatrix.prt_id = cboIP.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.cso_id = cboCso.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.wrd_id = cboParish.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.date = dtDate.Value;
            AgroEnterpriseRankingMatrix.hhm_id = cboHHMemberName.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.fa_name = txtFieldAgentName.Text;
            AgroEnterpriseRankingMatrix.usr_id_create = SystemConstants.user_id;
            AgroEnterpriseRankingMatrix.usr_id_update = SystemConstants.user_id;
            AgroEnterpriseRankingMatrix.usr_date_create = DateTime.Today;
            AgroEnterpriseRankingMatrix.usr_date_update = DateTime.Today;
            AgroEnterpriseRankingMatrix.ofc_id = SystemConstants.ofc_id;
            AgroEnterpriseRankingMatrix.district_id = SystemConstants.Return_office_district();


            #region Ranking Variables
            #region Crop one
            AgroEnterpriseRankingMatrix.crop_1_id = cboCrop_one.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.crop_1_param1_score = Convert.ToInt32(gdvAgroParent.Rows[0].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param2_score = Convert.ToInt32(gdvAgroParent.Rows[1].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param3_score = Convert.ToInt32(gdvAgroParent.Rows[2].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param4_score = Convert.ToInt32(gdvAgroParent.Rows[3].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param5_score = Convert.ToInt32(gdvAgroParent.Rows[4].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param6_score = Convert.ToInt32(gdvAgroParent.Rows[5].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param7_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_one"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_1_param8_score = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_one"].Value.ToString());

            switch (AgroEnterpriseRankingMatrix.type) {
                case "crop":
                    AgroEnterpriseRankingMatrix.crop_1_total_score = Convert.ToInt32(gdvAgroParent.Rows[8].Cells["crop_one"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_1_rank = Convert.ToInt32(gdvAgroParent.Rows[9].Cells["crop_one"].Value.ToString());
                    break;
                case "cottage":
                    AgroEnterpriseRankingMatrix.crop_1_total_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_one"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_1_rank = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_one"].Value.ToString());
                    break;
            }
           
            #endregion Crop one

            #region Crop two
            AgroEnterpriseRankingMatrix.crop_2_id = cboCrop_two.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.crop_2_param1_score = Convert.ToInt32(gdvAgroParent.Rows[0].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param2_score = Convert.ToInt32(gdvAgroParent.Rows[1].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param3_score = Convert.ToInt32(gdvAgroParent.Rows[2].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param4_score = Convert.ToInt32(gdvAgroParent.Rows[3].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param5_score = Convert.ToInt32(gdvAgroParent.Rows[4].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param6_score = Convert.ToInt32(gdvAgroParent.Rows[5].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param7_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_two"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_2_param8_score = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_two"].Value.ToString());

            switch (AgroEnterpriseRankingMatrix.type)
            {
                case "crop":
                    AgroEnterpriseRankingMatrix.crop_2_total_score = Convert.ToInt32(gdvAgroParent.Rows[8].Cells["crop_two"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_2_rank = Convert.ToInt32(gdvAgroParent.Rows[9].Cells["crop_two"].Value.ToString());
                    break;
                case "cottage":
                    AgroEnterpriseRankingMatrix.crop_2_total_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_two"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_2_rank = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_two"].Value.ToString());
                    break;
            }
           

            #endregion Crop two

            #region Crop three
            AgroEnterpriseRankingMatrix.crop3_id = cboCrop_three.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.crop_3_param1_score = Convert.ToInt32(gdvAgroParent.Rows[0].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param2_score = Convert.ToInt32(gdvAgroParent.Rows[1].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param3_score = Convert.ToInt32(gdvAgroParent.Rows[2].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param4_score = Convert.ToInt32(gdvAgroParent.Rows[3].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param5_score = Convert.ToInt32(gdvAgroParent.Rows[4].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param6_score = Convert.ToInt32(gdvAgroParent.Rows[5].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param7_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_three"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_3_param8_score = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_three"].Value.ToString());

            switch (AgroEnterpriseRankingMatrix.type)
            {
                case "crop":
                    AgroEnterpriseRankingMatrix.crop_3_total_score = Convert.ToInt32(gdvAgroParent.Rows[8].Cells["crop_three"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_3_rank = Convert.ToInt32(gdvAgroParent.Rows[9].Cells["crop_three"].Value.ToString());
                    break;
                case "cottage":
                    AgroEnterpriseRankingMatrix.crop_3_total_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_three"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_3_rank = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_three"].Value.ToString());
                    break;
            }
            

            #endregion Crop three

            #region Crop four
            AgroEnterpriseRankingMatrix.crop_4_id = cboCrop_four.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.crop_4_param1_score = Convert.ToInt32(gdvAgroParent.Rows[0].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param2_score = Convert.ToInt32(gdvAgroParent.Rows[1].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param3_score = Convert.ToInt32(gdvAgroParent.Rows[2].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param4_score = Convert.ToInt32(gdvAgroParent.Rows[3].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param5_score = Convert.ToInt32(gdvAgroParent.Rows[4].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param6_score = Convert.ToInt32(gdvAgroParent.Rows[5].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param7_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_four"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_4_param8_score = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_four"].Value.ToString());
            switch (AgroEnterpriseRankingMatrix.type)
            {
                case "crop":
                    AgroEnterpriseRankingMatrix.crop_4_total_score = Convert.ToInt32(gdvAgroParent.Rows[8].Cells["crop_four"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_4_rank = Convert.ToInt32(gdvAgroParent.Rows[9].Cells["crop_four"].Value.ToString());
                    break;
                case "cottage":
                    AgroEnterpriseRankingMatrix.crop_4_total_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_four"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_4_rank = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_four"].Value.ToString());
                    break;
            }

            #endregion Crop four

            #region Crop five
            AgroEnterpriseRankingMatrix.crop_5_id = cboCrop_five.SelectedValue.ToString();
            AgroEnterpriseRankingMatrix.crop_5_param1_score = Convert.ToInt32(gdvAgroParent.Rows[0].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param2_score = Convert.ToInt32(gdvAgroParent.Rows[1].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param3_score = Convert.ToInt32(gdvAgroParent.Rows[2].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param4_score = Convert.ToInt32(gdvAgroParent.Rows[3].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param5_score = Convert.ToInt32(gdvAgroParent.Rows[4].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param6_score = Convert.ToInt32(gdvAgroParent.Rows[5].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param7_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_five"].Value.ToString());
            AgroEnterpriseRankingMatrix.crop_5_param8_score = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_five"].Value.ToString());
            switch (AgroEnterpriseRankingMatrix.type)
            {
                case "crop":
                    AgroEnterpriseRankingMatrix.crop_5_total_score = Convert.ToInt32(gdvAgroParent.Rows[8].Cells["crop_five"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_5_rank = Convert.ToInt32(gdvAgroParent.Rows[9].Cells["crop_five"].Value.ToString());
                    break;
                case "cottage":
                    AgroEnterpriseRankingMatrix.crop_5_total_score = Convert.ToInt32(gdvAgroParent.Rows[6].Cells["crop_five"].Value.ToString());
                    AgroEnterpriseRankingMatrix.crop_5_rank = Convert.ToInt32(gdvAgroParent.Rows[7].Cells["crop_five"].Value.ToString());
                    break;
            }
            
            #endregion Crop five

            #endregion  Ranking Variables

            #endregion set variables

            #region Save Data

            if (AgroEnterpriseRankingMatrix.agro_ent_id == string.Empty)
            {
                if (AgroEnterpriseRankingMatrix.type == "crop")
                {
                    AgroEnterpriseRankingMatrix.agro_ent_id = Guid.NewGuid().ToString();
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_details("insert");

                    AgroEnterpriseRankingMatrix.agro_entm_id = Guid.NewGuid().ToString();
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_scoring_details("insert");
                    MessageBox.Show("Success!", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (AgroEnterpriseRankingMatrix.type == "cottage")
                {
                    AgroEnterpriseRankingMatrix.agro_ent_id = "cottage-" + Guid.NewGuid().ToString();
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_details("insert");

                    AgroEnterpriseRankingMatrix.agro_entm_id = Guid.NewGuid().ToString();
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_scoring_details("insert");
                    MessageBox.Show("Success!", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (AgroEnterpriseRankingMatrix.agro_entm_id == string.Empty)
                {
                   
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_details("update");
                    AgroEnterpriseRankingMatrix.agro_entm_id = Guid.NewGuid().ToString();
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_scoring_details("insert");
                    MessageBox.Show("Success!", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_details("update");
                    AgroEnterpriseRankingMatrix.save_update_ben_agro_enterprise_ranking_matrix_scoring_details("update");
                    MessageBox.Show("Success!", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
            #endregion Save Data
        }
        #endregion Save

        protected void RankCropScores()
        {
            switch (AgroEnterpriseRankingMatrix.type) {
                case "crop":
                    var data = new List<int> { gdvAgroParent.Rows[8].Cells[2].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[8].Cells[2].Value.ToString()) : 0
                , gdvAgroParent.Rows[8].Cells[3].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[8].Cells[3].Value.ToString()) : 0
                , gdvAgroParent.Rows[8].Cells[4].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[8].Cells[4].Value.ToString()) : 0
                , gdvAgroParent.Rows[8].Cells[5].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[8].Cells[5].Value.ToString()) : 0
                , gdvAgroParent.Rows[8].Cells[6].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[8].Cells[6].Value.ToString()) : 0};
                    var rankings = data.OrderByDescending(x => x).GroupBy(x => x)
                                       .SelectMany((g, i) =>
                                           g.Select(e => new { score = e, Rank = i + 1 }))
                                       .ToList();

                    #region Ranking
                    for (int i = 0; i < rankings.Count; i++)
                    {
                        int score = Convert.ToInt32(rankings[i].score);
                        int rank = Convert.ToInt32(rankings[i].Rank);

                        int score_crop_1 = Convert.ToInt32(gdvAgroParent.Rows[8].Cells[2].Value.ToString());
                        int score_crop_2 = Convert.ToInt32(gdvAgroParent.Rows[8].Cells[3].Value.ToString());
                        int score_crop_3 = Convert.ToInt32(gdvAgroParent.Rows[8].Cells[4].Value.ToString());
                        int score_crop_4 = Convert.ToInt32(gdvAgroParent.Rows[8].Cells[5].Value.ToString());
                        int score_crop_5 = Convert.ToInt32(gdvAgroParent.Rows[8].Cells[6].Value.ToString());

                        if (score == score_crop_1)
                        {
                            gdvAgroParent.Rows[9].Cells[2].Value = rank.ToString();
                        }

                        if (score == score_crop_2)
                        {
                            gdvAgroParent.Rows[9].Cells[3].Value = rank.ToString();
                        }

                        if (score == score_crop_3)
                        {
                            gdvAgroParent.Rows[9].Cells[4].Value = rank.ToString();
                        }

                        if (score == score_crop_4)
                        {
                            gdvAgroParent.Rows[9].Cells[5].Value = rank.ToString();
                        }

                        if (score == score_crop_5)
                        {
                            gdvAgroParent.Rows[9].Cells[6].Value = rank.ToString();
                        }
                    }
                    #endregion Ranking
                    break;
                case "cottage":
                    var _data = new List<int> { gdvAgroParent.Rows[6].Cells[2].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[6].Cells[2].Value.ToString()) : 0
                , gdvAgroParent.Rows[6].Cells[3].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[6].Cells[3].Value.ToString()) : 0
                , gdvAgroParent.Rows[6].Cells[4].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[6].Cells[4].Value.ToString()) : 0
                , gdvAgroParent.Rows[6].Cells[5].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[6].Cells[5].Value.ToString()) : 0
                , gdvAgroParent.Rows[6].Cells[6].Value.ToString() != string.Empty? Convert.ToInt32(gdvAgroParent.Rows[6].Cells[6].Value.ToString()) : 0};
                    var _rankings = _data.OrderByDescending(x => x).GroupBy(x => x)
                                       .SelectMany((g, i) =>
                                           g.Select(e => new { score = e, Rank = i + 1 }))
                                       .ToList();

                    #region Ranking
                    for (int i = 0; i < _rankings.Count; i++)
                    {
                        int score = Convert.ToInt32(_rankings[i].score);
                        int rank = Convert.ToInt32(_rankings[i].Rank);

                        int score_crop_1 = Convert.ToInt32(gdvAgroParent.Rows[6].Cells[2].Value.ToString());
                        int score_crop_2 = Convert.ToInt32(gdvAgroParent.Rows[6].Cells[3].Value.ToString());
                        int score_crop_3 = Convert.ToInt32(gdvAgroParent.Rows[6].Cells[4].Value.ToString());
                        int score_crop_4 = Convert.ToInt32(gdvAgroParent.Rows[6].Cells[5].Value.ToString());
                        int score_crop_5 = Convert.ToInt32(gdvAgroParent.Rows[6].Cells[6].Value.ToString());

                        if (score == score_crop_1)
                        {
                            gdvAgroParent.Rows[7].Cells[2].Value = rank.ToString();
                        }

                        if (score == score_crop_2)
                        {
                            gdvAgroParent.Rows[7].Cells[3].Value = rank.ToString();
                        }

                        if (score == score_crop_3)
                        {
                            gdvAgroParent.Rows[7].Cells[4].Value = rank.ToString();
                        }

                        if (score == score_crop_4)
                        {
                            gdvAgroParent.Rows[7].Cells[5].Value = rank.ToString();
                        }

                        if (score == score_crop_5)
                        {
                            gdvAgroParent.Rows[7].Cells[6].Value = rank.ToString();
                        }
                    }
                    #endregion Ranking
                    break;
            }
           
        }

        protected void CalculateCropScore(string crop)
        {
            switch (AgroEnterpriseRankingMatrix.type) {
                case "crop":
                    switch (crop)
                    {
                        case "one":
                            int score_crop_1 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[2].Value.ToString() != string.Empty)
                                {

                                    score_crop_1 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[2].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[8].Cells[2].Value = score_crop_1.ToString();
                            break;
                        case "two":
                            int score_crop_2 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[3].Value.ToString() != string.Empty)
                                {

                                    score_crop_2 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[3].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[8].Cells[3].Value = score_crop_2.ToString();
                            break;
                        case "three":
                            int score_crop_3 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[4].Value.ToString() != string.Empty)
                                {

                                    score_crop_3 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[4].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[8].Cells[4].Value = score_crop_3.ToString();
                            break;
                        case "four":
                            int score_crop_4 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[5].Value.ToString() != string.Empty)
                                {

                                    score_crop_4 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[5].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[8].Cells[5].Value = score_crop_4.ToString();
                            break;
                        case "five":
                            int score_crop_5 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[6].Value.ToString() != string.Empty)
                                {

                                    score_crop_5 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[6].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[8].Cells[6].Value = score_crop_5.ToString();
                            break;
                    }
                    break;
                case "cottage":
                    switch (crop)
                    {
                        case "one":
                            int score_crop_1 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[2].Value.ToString() != string.Empty)
                                {

                                    score_crop_1 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[2].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[6].Cells[2].Value = score_crop_1.ToString();
                            break;
                        case "two":
                            int score_crop_2 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[3].Value.ToString() != string.Empty)
                                {

                                    score_crop_2 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[3].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[6].Cells[3].Value = score_crop_2.ToString();
                            break;
                        case "three":
                            int score_crop_3 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[4].Value.ToString() != string.Empty)
                                {

                                    score_crop_3 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[4].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[6].Cells[4].Value = score_crop_3.ToString();
                            break;
                        case "four":
                            int score_crop_4 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[5].Value.ToString() != string.Empty)
                                {

                                    score_crop_4 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[5].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[6].Cells[5].Value = score_crop_4.ToString();
                            break;
                        case "five":
                            int score_crop_5 = 0;
                            for (int x = 0; x < gdvAgroParent.Rows.Count - 2; x++)
                            {
                                if (gdvAgroParent.Rows[x].Cells[6].Value.ToString() != string.Empty)
                                {

                                    score_crop_5 += Convert.ToInt32(gdvAgroParent.Rows[x].Cells[6].Value.ToString());
                                }
                            }

                            gdvAgroParent.Rows[6].Cells[6].Value = score_crop_5.ToString();
                            break;
                    }
                    break;
            }

            

        }

        private void gdvAgroParent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gdvAgroParent_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvAgroParent.CurrentCell.Value != null)
            {
                string score = gdvAgroParent.CurrentCell.Value.ToString();
                int IntScore;
                if (int.TryParse(score, out IntScore))
                {
                    if (Convert.ToInt32(gdvAgroParent.CurrentCell.Value.ToString()) > 5)
                    {
                        MessageBox.Show("Rank cannot be greater than 5", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gdvAgroParent.CurrentCell.Value = string.Empty;
                    }
                }
            }
        }

        private void gdvAgroParent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gdvAgroParent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (gdvAgroParent.CurrentCell.ColumnIndex == 2) //Allow only numbers in the grid
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (gdvAgroParent.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (gdvAgroParent.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (gdvAgroParent.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (gdvAgroParent.CurrentCell.ColumnIndex == 6)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #region Load display
        protected void LoadDisplay(string agro_ent_id)
        {
            dt = AgroEnterpriseRankingMatrix.LoadDisplay(agro_ent_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                #region Main Header Variables
                cboIP.SelectedValue = dtRow["prt_id"].ToString();
                cboCso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                dtDate.Value = Convert.ToDateTime(dtRow["date"]);
                cboHHCode.SelectedValue = dtRow["hh_id"].ToString();
                cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                txtFieldAgentName.Text = dtRow["fa_name"].ToString();
                AgroEnterpriseRankingMatrix.agro_entm_id = dtRow["agro_entm_id"].ToString();
                #endregion Main Header Variables

                #region Crops
                cboCrop_one.SelectedValue = dtRow["crop_1_id"].ToString();
                cboCrop_one_SelectionChangeCommitted(cboCrop_one, null);

                cboCrop_two.SelectedValue = dtRow["crop_2_id"].ToString();
                cboCrop_two_SelectionChangeCommitted(cboCrop_two, null);

                cboCrop_three.SelectedValue = dtRow["crop3_id"].ToString();
                cboCrop_three_SelectionChangeCommitted(cboCrop_three, null);

                cboCrop_four.SelectedValue = dtRow["crop_4_id"].ToString();
                cboCrop_four_SelectionChangeCommitted(cboCrop_four, null);

                cboCrop_five.SelectedValue = dtRow["crop_5_id"].ToString();
                cboCrop_five_SelectionChangeCommitted(cboCrop_five, null);

                #endregion Crops

                switch (AgroEnterpriseRankingMatrix.type) {
                    case "crop":
                        gdvAgroParent.Rows[0].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param1_score"].ToString()).ToString();

                        gdvAgroParent.Rows[1].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param2_score"].ToString()).ToString();

                        gdvAgroParent.Rows[2].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param3_score"].ToString()).ToString();

                        gdvAgroParent.Rows[3].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param4_score"].ToString()).ToString();

                        gdvAgroParent.Rows[4].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param5_score"].ToString()).ToString();

                        gdvAgroParent.Rows[5].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param6_score"].ToString()).ToString();

                        gdvAgroParent.Rows[6].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param7_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param7_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param7_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param7_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param7_score"].ToString()).ToString();

                        gdvAgroParent.Rows[7].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param8_score"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param8_score"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param8_score"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param8_score"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param8_score"].ToString()).ToString();

                        #region scores and Ranks
                        gdvAgroParent.Rows[8].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[8].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[8].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[8].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[8].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_total_score"].ToString()).ToString();

                        gdvAgroParent.Rows[9].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[9].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[9].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[9].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[9].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_rank"].ToString()).ToString();
                        #endregion
                        break;
                    case "cottage":
                        gdvAgroParent.Rows[0].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param1_score"].ToString()).ToString();
                        gdvAgroParent.Rows[0].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param1_score"].ToString()).ToString();

                        gdvAgroParent.Rows[1].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param2_score"].ToString()).ToString();
                        gdvAgroParent.Rows[1].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param2_score"].ToString()).ToString();

                        gdvAgroParent.Rows[2].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param3_score"].ToString()).ToString();
                        gdvAgroParent.Rows[2].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param3_score"].ToString()).ToString();

                        gdvAgroParent.Rows[3].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param4_score"].ToString()).ToString();
                        gdvAgroParent.Rows[3].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param4_score"].ToString()).ToString();

                        gdvAgroParent.Rows[4].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param5_score"].ToString()).ToString();
                        gdvAgroParent.Rows[4].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param5_score"].ToString()).ToString();

                        gdvAgroParent.Rows[5].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param6_score"].ToString()).ToString();
                        gdvAgroParent.Rows[5].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param6_score"].ToString()).ToString();

                        //gdvAgroParent.Rows[6].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param7_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[6].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param7_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[6].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param7_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[6].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param7_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[6].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param7_score"].ToString()).ToString();

                        //gdvAgroParent.Rows[7].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_param8_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[7].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_param8_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[7].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_param8_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[7].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_param8_score"].ToString()).ToString();
                        //gdvAgroParent.Rows[7].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_param8_score"].ToString()).ToString();

                        #region scores and Ranks
                        gdvAgroParent.Rows[6].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_total_score"].ToString()).ToString();
                        gdvAgroParent.Rows[6].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_total_score"].ToString()).ToString();

                        gdvAgroParent.Rows[7].Cells["crop_one"].Value = Convert.ToInt32(dtRow["crop_1_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_two"].Value = Convert.ToInt32(dtRow["crop_2_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_three"].Value = Convert.ToInt32(dtRow["crop_3_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_four"].Value = Convert.ToInt32(dtRow["crop_4_rank"].ToString()).ToString();
                        gdvAgroParent.Rows[7].Cells["crop_five"].Value = Convert.ToInt32(dtRow["crop_5_rank"].ToString()).ToString();
                        #endregion
                        break;
                }

                

                #region Disable Panels
                tlpDisplay01.Enabled = false;
                tlpDisplay02.Enabled = false;
                panelDisplay01.Enabled = false;
                #endregion Disable Panels

            }
        }
        #endregion Load display

        #region Validate Data
        protected bool ValidateInput()
        {
            bool isValid = false;
            for (int i = 0; i < gdvAgroParent.Rows.Count; i++)
            {
                for (int x = 0; x < gdvAgroParent.Columns.Count; x++)
                {
                    if (gdvAgroParent.Columns[x].Index > 1)
                    {
                        if (gdvAgroParent.Rows[i].Cells[x].Value.ToString() == string.Empty)
                        {
                            isValid = false;
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                }
            }

            #region Validate Main Data
            if (ValidateMainData())
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            #endregion Validate Main Data

            return isValid;
        }

        protected bool ValidateMainData()
        {
            bool isValid = false;
            if (cboIP.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1"
                || cboParish.SelectedValue.ToString() == "-1" || dtDate.Checked == false || cboHHCode.SelectedValue.ToString() == "-1" || cboHHMemberName.SelectedValue.ToString() == "-1"
               || txtFieldAgentName.Text == string.Empty || cboCrop_one.SelectedValue.ToString() == "-1" || cboCrop_two.SelectedValue.ToString() == "-1" || cboCrop_three.SelectedValue.ToString() == "-1"
               || cboCrop_four.SelectedValue.ToString() == "-1" || cboCrop_five.SelectedValue.ToString() == "-1")
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        #endregion Validate Data

        private void btnedit_Click(object sender, EventArgs e)
        {
            #region Enable Panels
            tlpDisplay01.Enabled = true;
            tlpDisplay02.Enabled = true;
            panelDisplay01.Enabled = true;
            #endregion Enable Panels
        }

        protected void Clear()
        {
            cboIP.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue = "-1";
            dtDate.Value = DateTime.Today;
            txtFieldAgentName.Clear();
            cboCrop_five.SelectedValue = "-1";
            cboCrop_four.SelectedValue = "-1";
            cboHHCode.SelectedValue = "-1";
            cboHHMemberName.SelectedValue = "-1";
            txtMemberCode.Clear();
            txtAge.Clear();
            AgroEnterpriseRankingMatrix.agro_ent_id = string.Empty;
            AgroEnterpriseRankingMatrix.agro_entm_id = string.Empty;

            #region Enable Panels
            tlpDisplay01.Enabled = true;
            tlpDisplay02.Enabled = true;
            panelDisplay01.Enabled = true;
            #endregion Enable Panels

            #region Clear grid
            for (int i = 0; i < gdvAgroParent.Rows.Count; i++)
            {
                for (int x = 0; x < gdvAgroParent.Columns.Count; x++)
                {
                    if (gdvAgroParent.Columns[x].Index > 1)
                    {
                        if (gdvAgroParent.Rows[i].Cells[x].Value.ToString() != string.Empty)
                        {
                            gdvAgroParent.Rows[i].Cells[x].Value = "";
                        }
                        else
                        {
                            gdvAgroParent.Rows[i].Cells[x].Value = "";
                        }
                    }
                }
            }
            #endregion Clear grid
        }

        private void btnNewMember_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }
    }
}
