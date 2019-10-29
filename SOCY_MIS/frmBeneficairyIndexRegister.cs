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
    public partial class frmBeneficairyIndexRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmBeneficairyIndexRegisterSearch frmCll = null;
        private frmBeneficairyIndexRegisterSearch frmCllNew = null;
        private frmOVCIdentificationPrioritizationSearch frmCllSearch = null;
        private frmResultArea02 frmPrt = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frmBeneficairyIndexRegisterSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmBeneficairyIndexRegisterSearch FormCallingNew
        {
            get { return frmCllNew; }
            set { frmCllNew = value; }
        }

        public frmOVCIdentificationPrioritizationSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        public frmBeneficairyIndexRegister()
        {
            InitializeComponent();
        }

        protected void Return_lookups()
        {
            //districts
            DataTable dt = hhHousehold_linkages_register.Return_lookups("district");
            DataRow dtNewRow_dst = dt.NewRow();
            dtNewRow_dst["dst_name"] = "select one";
            dtNewRow_dst["dst_id"] = "-1";
            dt.Rows.InsertAt(dtNewRow_dst, 0);
            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            //subcounty
            DataTable dt_sct = hhHousehold_linkages_register.Return_lookups("subcounty");
            DataRow dtNewRow = dt_sct.NewRow();
            dtNewRow["sct_name"] = "select one";
            dtNewRow["sct_id"] = "-1";
            dt_sct.Rows.InsertAt(dtNewRow, 0);
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            cboSubCounty.DataSource = dt_sct;

            //subcounty of index
            dt = hhHousehold_linkages_register.Return_lookups("subcounty");
            DataRow dtNewRow_index = dt.NewRow();
            dtNewRow_index["sct_name"] = "select one";
            dtNewRow_index["sct_id"] = "-1";
            dt.Rows.InsertAt(dtNewRow_index, 0);
            cboIndexSubCounty.DisplayMember = "sct_name";
            cboIndexSubCounty.ValueMember = "sct_id";
            cboIndexSubCounty.DataSource = dt;

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");

            DataRow dtNewRow_parish = dt.NewRow();
            dtNewRow_parish["wrd_name"] = "select one";
            dtNewRow_parish["wrd_id"] = "-1";
            dt.Rows.InsertAt(dtNewRow_parish, 0);
            cboIndexParish.DisplayMember = "wrd_name";
            cboIndexParish.ValueMember = "wrd_id";
            cboIndexParish.DataSource = dt;
        }

        private void frmBeneficairyIndexRegister_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadIndexCategory();
            LoadGender();

            if (ObjectId != string.Empty)
            {
                lblid.Text = ObjectId;
                LoadRecordDetails(ObjectId);
            }
            else
            {
                Clear();
            }
            
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

            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow _sctemptyRow = dt.NewRow();
            _sctemptyRow["sct_id"] = "-1";
            _sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(_sctemptyRow, 0);

            cboIndexSubCounty.DataSource = dt;
            cboIndexSubCounty.DisplayMember = "sct_name";
            cboIndexSubCounty.ValueMember = "sct_id";

            #endregion Load SubCountys

            LoadSocialWorker(cboDistrict.SelectedValue.ToString());
        }

        private void cboIndexSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load Parishes
            dt = benYouthTrainingInventory.Return_lookups("parish", cboIndexSubCounty.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboIndexParish.DataSource = dt;
            cboIndexParish.DisplayMember = "wrd_name";
            cboIndexParish.ValueMember = "wrd_id";
            #endregion Load Parishes
        }

        protected void LoadIndexCategory()
        {
            dt = benIndexRegistration.ReturnIndexCategory();
            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["cat_id"] = "-1";
            sctemptyRow["cat_name"] = "Select category";
            dt.Rows.InsertAt(sctemptyRow, 0);
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "cat_name";
            cboCategory.ValueMember = "cat_id";
        }

        protected void LoadGender()
        {
            dt = benIndexRegistration.ReturnGender();
            DataRow emptyRow = dt.NewRow();
            emptyRow["gnd_id"] = "-1";
            emptyRow["gnd_name"] = "Select gender";
            dt.Rows.InsertAt(emptyRow, 0);
            cboSex.DataSource = dt;
            cboSex.DisplayMember = "gnd_name";
            cboSex.ValueMember = "gnd_id";
        }

        protected void LoadSocialWorker(string dst_id)
        {
            dt = benIndexRegistration.ReturnSocialWorker(dst_id);
            DataRow emptyRow = dt.NewRow();
            emptyRow["swk_id"] = "-1";
            emptyRow["swk_name"] = "Select one";
            dt.Rows.InsertAt(emptyRow, 0);
            cboSocialWorker.DataSource = dt;
            cboSocialWorker.DisplayMember = "swk_name";
            cboSocialWorker.ValueMember = "swk_id";
        }

        private void cboSocialWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSocialWorkerPhone.Text = hhgraduation_assessment.ReturnSocialWorkerPhone(cboSocialWorker.SelectedValue.ToString()); //reused
        }

        protected void save()
        {
            #region set variables

            benIndexRegistration.dst_id = cboDistrict.SelectedValue.ToString();
            benIndexRegistration.sct_id = cboSubCounty.SelectedValue.ToString();
            benIndexRegistration.ibr_date = dtpDate.Value;
            benIndexRegistration.entry_point = cboEntryPoint.Text;
            benIndexRegistration.other_entry_point = txthealthfacility.Text;
            benIndexRegistration.incharge_name = txtIncharge.Text;
            benIndexRegistration.category_id = cboCategory.SelectedValue.ToString();
            benIndexRegistration.index_name = txtIndexname.Text;
            benIndexRegistration.age = Convert.ToInt32(txtAge.Text);
            benIndexRegistration.gnd_id = cboSex.SelectedValue.ToString();
            benIndexRegistration.unique_id = txtidentifier.Text;
            benIndexRegistration.yn_id_suppress = utilControls.RadioButtonGetSelection(rbtnSupressYes, rbtnSupressNo, rbtnSupressNA);
            benIndexRegistration.art_date = dtArtDate.Value;
            benIndexRegistration.caregiver_name = txtCaregiver.Text;
            benIndexRegistration.index_wrd_id = cboIndexParish.SelectedValue.ToString();
            benIndexRegistration.village = txtIndexVillage.Text;
            benIndexRegistration.chbc_name = txtHealthWorkerName.Text;
            benIndexRegistration.chbc_contact = txtHealthWorkerPhone.Text;
            benIndexRegistration.swk_id = cboSocialWorker.SelectedValue.ToString();
            benIndexRegistration.usr_date_create = DateTime.Now;
            benIndexRegistration.usr_date_update = DateTime.Now;
            benIndexRegistration.usr_id_create = SystemConstants.user_id;
            benIndexRegistration.usr_id_update = SystemConstants.user_id;
            benIndexRegistration.ofc_id = SystemConstants.ofc_id;
            benIndexRegistration.district_id = SystemConstants.Return_office_district();
            #endregion set variables

            if (lblid.Text == "--")
            {
                benIndexRegistration.ibr_id = Guid.NewGuid().ToString();
                benIndexRegistration.save();
                MessageBox.Show("Success", "SOCY MIS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                benIndexRegistration.ibr_id = lblid.Text;
                benIndexRegistration.update();
                MessageBox.Show("Success", "SOCY MIS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }

        }

        protected void Clear()
        {
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            dtpDate.Value = DateTime.Today;
            dtpDate.Checked = false;
            cboEntryPoint.Text = string.Empty;
            txthealthfacility.Clear();
            txtIncharge.Clear();
            cboCategory.SelectedValue = "-1";
            txtIndexname.Clear();
            txtAge.Clear();
            cboSex.SelectedValue = "-1";
            txtidentifier.Clear();
            rbtnSupressYes.Checked = false;
            rbtnSupressNo.Checked = false;
            dtArtDate.Value = DateTime.Today;
            dtArtDate.Checked = false;
            txtCaregiver.Clear();
            cboIndexSubCounty.SelectedValue = "-1";
            cboIndexParish.SelectedValue = "-1";
            txtIndexVillage.Clear();
            txtHealthWorkerName.Clear();
            txtHealthWorkerPhone.Clear();
            cboSocialWorker.SelectedValue = "-1";
            lblid.Text = "--";
            pnlSuppress.Enabled = true;
            rbtnSupressNA.Enabled = true;
        }

        protected void LoadRecordDetails(string ibr_id)
        {
            dt = benIndexRegistration.LoadRecordDetails(ibr_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                dtpDate.Value = Convert.ToDateTime(dtRow["ibr_date"]);
                cboEntryPoint.Text = dtRow["entry_point"].ToString();
                txthealthfacility.Text = dtRow["other_entry_point"].ToString();
                txtIncharge.Text = dtRow["incharge_name"].ToString();
                cboCategory.SelectedValue = dtRow["category_id"].ToString();
                txtIndexname.Text = dtRow["index_name"].ToString();
                txtAge.Text = dtRow["Age"].ToString();
                cboSex.SelectedValue = dtRow["gnd_id"].ToString();
                txtidentifier.Text = dtRow["unique_id"].ToString();
                utilControls.RadioButtonSetSelection(rbtnSupressYes, rbtnSupressNo, rbtnSupressNA, dtRow["yn_id_suppress"].ToString());
                dtArtDate.Value = Convert.ToDateTime(dtRow["art_date"]);
                txtCaregiver.Text = dtRow["caregiver_name"].ToString();
                cboIndexSubCounty.SelectedValue = dtRow["index_sct"].ToString();
                cboIndexParish.SelectedValue = dtRow["index_wrd_id"].ToString();
                txtIndexVillage.Text = dtRow["village"].ToString();
                txtHealthWorkerName.Text = dtRow["chbc_name"].ToString();
                txtHealthWorkerPhone.Text = dtRow["chbc_contact"].ToString();
                cboSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
            }
        }

        protected bool ValidateInput() 
        {
            bool isValid = false;
            if (cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" || dtpDate.Checked == false || cboEntryPoint.Text == string.Empty ||
                txtIncharge.Text == string.Empty || cboCategory.SelectedValue.ToString() == "-1" || txtIndexname.Text == string.Empty || txtAge.Text == string.Empty || cboSex.SelectedValue.ToString() == "-1" || 
                txtidentifier.Text == string.Empty || (!rbtnSupressYes.Checked & !rbtnSupressNo.Checked) || txtCaregiver.Text == string.Empty || cboIndexSubCounty.SelectedValue.ToString() == "-1" || 
                cboIndexParish.SelectedValue.ToString() == "-1" || txtIndexVillage.Text == string.Empty || txtHealthWorkerName.Text == string.Empty || txtHealthWorkerPhone.Text == string.Empty || cboSocialWorker.SelectedValue.ToString() == "-1" ||
                (cboEntryPoint.Text == "Other" & txthealthfacility.Text == String.Empty) || ((cboCategory.SelectedValue.ToString() == benIndexRegistration.HIV_POS_ADULT || cboCategory.SelectedValue.ToString() == benIndexRegistration.HIV_POS_CHILD) 
                && (!rbtnSupressNo.Checked & !rbtnSupressYes.Checked) || !dtArtDate.Checked))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
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
                MessageBox.Show("All values marked with (*) are required,save failed", "SOCY MIS Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboEntryPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntryPoint.Text != string.Empty)
            {
                if (cboEntryPoint.Text == "Other")
                {
                    txthealthfacility.Enabled = true;
                    lblOther.ForeColor = Color.Red;
                }
                else
                {
                    txthealthfacility.Enabled = false;
                    txthealthfacility.Clear();
                    lblOther.ForeColor = Color.Black;
                }
            }
            else
            {
                txthealthfacility.Enabled = false;
                txthealthfacility.Clear();
                lblOther.ForeColor = Color.Black;
            }
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            if (FormCalling != null)
            {
               
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormCallingNew != null)
            {
               
                FormMaster.LoadControl(FormCallingNew, this.Name, false);
            }
            else if (FormCallingSearch != null)
            {
                
                FormParent.LoadControl(FormCallingSearch, this.Name);
            }
        }

        private void llblNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue.ToString() == benIndexRegistration.HIV_POS_CHILD || cboCategory.SelectedValue.ToString() == benIndexRegistration.HIV_POS_ADULT)
            {
                pnlSuppress.Enabled = true;
                rbtnSupressNA.Enabled = false;
                rbtnSupressNA.Checked = false;
                dtArtDate.Enabled = true;
                dtArtDate.Value = DateTime.Today;
            }
            else
            {
                pnlSuppress.Enabled = false;
                rbtnSupressNA.Checked = true;
                dtArtDate.Enabled = false;
                dtArtDate.Value = Convert.ToDateTime( "1900-01-01");
            }
        }
    }
}
