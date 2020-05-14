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
    public partial class frmNoMeansNoAttendance : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmNoMeansNoMain frmPrt = null;
        frmNoMeansNoAttendanceSearch frmCommRegister = null;
        Master frmMST = null;
        string strMessage = string.Empty;
        DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        #endregion Variables

        public frmNoMeansNoAttendance()
        {
            InitializeComponent();
        }

        private void frmNoMeansNoAttendance_Load(object sender, EventArgs e)
        {
            Return_lookups();

            if(NoMeansNoWorldWide.roster_id != string.Empty)
            {
                LoadAttendanceDetails(NoMeansNoWorldWide.roster_id);
            }
        }

        public frmNoMeansNoAttendanceSearch FormCallingSearch
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llnback2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
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

        private void cboDirectBen_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboDirectBen.Text == "Yes")
            {
                LoadHouseholdList(cboSubCounty.SelectedValue.ToString());
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

        protected void LoadHouseholdList(string sct_id)
        {
            dt = NoMeansNoWorldWide.LoadHouseholdListAttendance(sct_id);

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
            dt = NoMeansNoWorldWide.LoadHouseholdMemberAttendance(hh_id);

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

        private void cboBeneficiaryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
           dt  = NoMeansNoWorldWide.LoadMemberDetails(cboBeneficiaryName.SelectedValue.ToString());
            if(dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txtfname.Text = dtRow["hhm_first_name"].ToString();
                txtlname.Text = dtRow["hhm_last_name"].ToString();
            }
           else
            {
                txtfname.Clear();
                txtlname.Clear();
            }

            txtAge.Text = NoMeansNoWorldWide.LoadBeneficiaryAge(cboBeneficiaryName.SelectedValue.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputMain())
            {
                save();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields,save failed", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region saveMain
        protected void save()
        {
            #region Variables
            NoMeansNoWorldWide.int_type = cboIntervention.Text;
            NoMeansNoWorldWide.start_date = dtStartDate.Value;
            NoMeansNoWorldWide.end_date = dtEndDate.Value;
            NoMeansNoWorldWide.sup_name = txtsupervisorname.Text;
            NoMeansNoWorldWide.imp_partner = cboCSO.Text;
            NoMeansNoWorldWide.dst_id = cboDistrict.SelectedValue.ToString();
            NoMeansNoWorldWide.sct_id = cboSubCounty.SelectedValue.ToString();
            NoMeansNoWorldWide.wrd_id = cboParish.SelectedValue.ToString();
            NoMeansNoWorldWide.venue = txtVenue.Text;
            NoMeansNoWorldWide.instructor_names = txtInstructor.Text;
            NoMeansNoWorldWide.delivery_method = cboDeliveryMethod.Text;
            NoMeansNoWorldWide.class1_tr_date = dtTr1.Value;
            NoMeansNoWorldWide.class1_tr_hrs = txtHrs1.Text;
            NoMeansNoWorldWide.class2_tr_date = dtTr2.Value;
            NoMeansNoWorldWide.class2_tr_hrs = txtHrs2.Text;
            NoMeansNoWorldWide.class3_tr_date = dtTr3.Value;
            NoMeansNoWorldWide.class3_tr_hrs = txtHrs3.Text;
            NoMeansNoWorldWide.class4_tr_date = dtTr4.Value;
            NoMeansNoWorldWide.class4_tr_hrs = txtHrs4.Text;
            NoMeansNoWorldWide.class5_tr_date = dtTr5.Value;
            NoMeansNoWorldWide.class5_tr_hrs = txtHrs5.Text;
            NoMeansNoWorldWide.class6_tr_date = dtTr6.Value;
            NoMeansNoWorldWide.class6_tr_hrs = txtHrs6.Text;
            NoMeansNoWorldWide.class7_tr_date = dtTr7.Value;
            NoMeansNoWorldWide.class7_tr_hrs = txtHrs7.Text;
            NoMeansNoWorldWide.usr_id_create = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_id_update = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_date_create = DateTime.Now;
            NoMeansNoWorldWide.usr_date_update = DateTime.Now;
            NoMeansNoWorldWide.ofc_id = SystemConstants.ofc_id;
            NoMeansNoWorldWide.district_id = SystemConstants.Return_office_district();
            #endregion Variables
            if (lblid.Text == "--")
            {
                NoMeansNoWorldWide.roster_id = Guid.NewGuid().ToString();
                lblid.Text = NoMeansNoWorldWide.saveNMNAttendaceRegister(dbCon);
                MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                NoMeansNoWorldWide.roster_id = lblid.Text;
                NoMeansNoWorldWide.updateNMNAttendaceRegister(dbCon);
                MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected bool ValidateInputMain()
        {
            bool isValid = false;

            if (cboIntervention.Text == string.Empty || !dtStartDate.Checked || !dtEndDate.Checked || txtsupervisorname.Text == string.Empty ||
                cboCSO.Text == string.Empty || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1" ||
                cboParish.SelectedValue.ToString() == "-1" || txtVenue.Text == string.Empty || txtInstructor.Text == string.Empty || cboDeliveryMethod.Text == string.Empty ||
                !dtTr1.Checked || !dtTr2.Checked || !dtTr3.Checked || !dtTr4.Checked || !dtTr5.Checked || !dtTr6.Checked || txtHrs1.Text == string.Empty ||
                txtHrs2.Text == string.Empty || txtHrs3.Text == string.Empty || txtHrs4.Text == string.Empty || txtHrs5.Text == string.Empty || txtHrs6.Text == string.Empty)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected bool VaidateMember()
        {
            bool isValid = false;

            if (cboDirectBen.Text == string.Empty || txtfname.Text == string.Empty || txtlname.Text == string.Empty || txtAge.Text == string.Empty || 
                cboClass1.Text == string.Empty || cboClass2.Text == string.Empty || cboClass3.Text == string.Empty || cboClass4.Text == string.Empty || cboClass5.Text == string.Empty ||
                cboClass6.Text == string.Empty || cboGraduated.Text == string.Empty || (cboHouseholdCode.SelectedValue.ToString() != "-1" & cboBeneficiaryName.SelectedValue.ToString() == "-1"))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
        #endregion saveMain

        #region saveMember
        protected void saveMember()
        {
            #region Variables
            NoMeansNoWorldWide.roster_id = lblid.Text;
            NoMeansNoWorldWide.yn_direct_ben = cboDirectBen.Text;
            NoMeansNoWorldWide.hhm_id = cboBeneficiaryName.SelectedValue.ToString();
            NoMeansNoWorldWide.nmn_id = txtNMNID.Text;
            NoMeansNoWorldWide.first_name = txtfname.Text;
            NoMeansNoWorldWide.last_name = txtlname.Text;
            NoMeansNoWorldWide.age = txtAge.Text;
            NoMeansNoWorldWide.class1_attended = cboClass1.Text;
            NoMeansNoWorldWide.class2_attended = cboClass2.Text;
            NoMeansNoWorldWide.class3_attended = cboClass3.Text;
            NoMeansNoWorldWide.class4_attended = cboClass4.Text;
            NoMeansNoWorldWide.class5_attended = cboClass5.Text;
            NoMeansNoWorldWide.class6_attended = cboClass6.Text;
            NoMeansNoWorldWide.class7_attended = cboClass7.Text;
            NoMeansNoWorldWide.graduated = cboGraduated.Text;
            NoMeansNoWorldWide.usr_id_create = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_id_update = SystemConstants.user_id;
            NoMeansNoWorldWide.usr_date_create = DateTime.Now;
            NoMeansNoWorldWide.usr_date_update = DateTime.Now;
            NoMeansNoWorldWide.ofc_id = SystemConstants.ofc_id;
            NoMeansNoWorldWide.district_id = SystemConstants.Return_office_district();
            #endregion Variables

            if (lblidMember.Text == "--")
            {
                NoMeansNoWorldWide.roster_member_id = Guid.NewGuid().ToString();
                NoMeansNoWorldWide.saveNMNAttendaceRegisterMember(dbCon);
                LoadDisplayList(lblid.Text);
                MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearMember();
            }
            else
            {
                NoMeansNoWorldWide.roster_member_id = lblidMember.Text;
                NoMeansNoWorldWide.updateNMNAttendaceRegisterMember(dbCon);
                LoadDisplayList(lblid.Text);
                MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearMember();
            }
        }
        #endregion saveMember

        protected void Clear()
        {
            lblid.Text = "--";
            cboIntervention.Text = string.Empty;
            dtStartDate.Value = DateTime.Now;
            dtStartDate.Checked = false;
            dtEndDate.Value = DateTime.Now;
            dtEndDate.Checked = false;
            txtsupervisorname.Clear();
            cboCSO.Text = string.Empty;
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboParish.SelectedValue =  "-1";
            txtVenue.Clear();
            txtInstructor.Clear();
            cboDeliveryMethod.Text = string.Empty;
            dtTr1.Value = DateTime.Now;
            txtHrs1.Clear();
            dtTr2.Value = DateTime.Now;
            txtHrs2.Clear();
            dtTr3.Value = DateTime.Now;
            txtHrs3.Clear();
            dtTr4.Value = DateTime.Now;
            txtHrs4.Clear();
            dtTr5.Value = DateTime.Now;
            txtHrs5.Clear();
            dtTr6.Value = DateTime.Now;
            txtHrs6.Clear();
            dtTr7.Value = DateTime.Now;
            txtHrs7.Clear();

            dtTr1.Checked = false;
            dtTr2.Checked = false;
            dtTr3.Checked = false;
            dtTr4.Checked = false;
            dtTr5.Checked = false;
            dtTr6.Checked = false;
            dtTr7.Checked = false;
        }

        protected void ClearMember()
        {
            lblidMember.Text = "--";
            cboDirectBen.Text = string.Empty;
            cboHouseholdCode.SelectedValue = "-1";
            cboBeneficiaryName.SelectedValue = "-1";
            txtNMNID.Clear();
            txtfname.Clear();
            txtlname.Clear();
            txtAge.Clear();
            cboClass1.Text = string.Empty;
            cboClass2.Text = string.Empty;
            cboClass3.Text = string.Empty;
            cboClass4.Text = string.Empty;
            cboClass5.Text = string.Empty;
            cboClass6.Text = string.Empty;
            cboClass7.Text = string.Empty;
            cboGraduated.Text = string.Empty;
        }

        protected void LoadAttendanceDetails(string id)
        {
            dt = NoMeansNoWorldWide.LoadNMNAttendanceDetails(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtrow = dt.Rows[0];


                lblid.Text = dtrow["roster_id"].ToString();
                cboIntervention.Text = dtrow["int_type"].ToString();
                dtStartDate.Value = Convert.ToDateTime(dtrow["start_date"]);
                dtEndDate.Value = Convert.ToDateTime(dtrow["end_date"]);
                txtsupervisorname.Text = dtrow["sup_name"].ToString();
                cboCSO.Text = dtrow["imp_partner"].ToString();
                cboDistrict.SelectedValue = dtrow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtrow["sct_id"].ToString();
                cboParish.SelectedValue = dtrow["wrd_id"].ToString();
                txtVenue.Text = dtrow["venue"].ToString();
                txtInstructor.Text = dtrow["instructor_names"].ToString();
                cboDeliveryMethod.Text = dtrow["delivery_method"].ToString();
                dtTr1.Value = Convert.ToDateTime(dtrow["class1_tr_date"]);
                txtHrs1.Text = dtrow["class1_tr_hrs"].ToString();
                dtTr2.Value = Convert.ToDateTime(dtrow["class2_tr_date"]);
                txtHrs2.Text = dtrow["class2_tr_hrs"].ToString();
                dtTr3.Value = Convert.ToDateTime(dtrow["class3_tr_date"]);
                txtHrs3.Text = dtrow["class3_tr_hrs"].ToString();
                dtTr4.Value = Convert.ToDateTime(dtrow["class4_tr_date"]);
                txtHrs4.Text = dtrow["class4_tr_hrs"].ToString();
                dtTr5.Value = Convert.ToDateTime(dtrow["class5_tr_date"]);
                txtHrs5.Text = dtrow["class5_tr_hrs"].ToString();
                dtTr6.Value = Convert.ToDateTime(dtrow["class6_tr_date"]);
                txtHrs6.Text = dtrow["class6_tr_hrs"].ToString();
                dtTr7.Value = Convert.ToDateTime(dtrow["class7_tr_date"]);
                txtHrs7.Text = dtrow["class7_tr_hrs"].ToString();

                LoadDisplayList(dtrow["roster_id"].ToString());
            }
        }

        protected void LoadNMNAttendanceParticipantDetails(string roster_member_id)
        {
            dt = NoMeansNoWorldWide.LoadNMNAttendanceParticipantDetails(roster_member_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];


                lblidMember.Text = dtRow["roster_member_id"].ToString();
                cboDirectBen.Text = dtRow["yn_direct_ben"].ToString();
                cboHouseholdCode.SelectedValue = dtRow["hh_id"].ToString();
                cboBeneficiaryName.SelectedValue = dtRow["hhm_id"].ToString();
                txtNMNID.Text = dtRow["nmn_id"].ToString();
                txtfname.Text = dtRow["first_name"].ToString();
                txtlname.Text = dtRow["last_name"].ToString();
                txtAge.Text = dtRow["age"].ToString();
                cboClass1.Text = dtRow["class1_attended"].ToString();
                cboClass2.Text = dtRow["class2_attended"].ToString();
                cboClass3.Text = dtRow["class3_attended"].ToString();
                cboClass4.Text = dtRow["class4_attended"].ToString();
                cboClass5.Text = dtRow["class5_attended"].ToString();
                cboClass6.Text = dtRow["class6_attended"].ToString();
                cboClass7.Text = dtRow["class7_attended"].ToString();
                cboGraduated.Text = dtRow["graduated"].ToString();
            }
            else
            {

            }
        }

        protected void LoadDisplayList(string roster_id)
        {
            dt = NoMeansNoWorldWide.LoadNMNAttendanceParticipant(roster_id);

            gdvParticipantList.DataSource = dt;

            gdvParticipantList.Columns["roster_member_id"].Visible = false;

            gdvParticipantList.Columns["nmn_id"].HeaderText = "NMN Unique ID";
            gdvParticipantList.Columns["first_name"].HeaderText = "First Name";
            gdvParticipantList.Columns["last_name"].HeaderText = "Last Name";
            gdvParticipantList.Columns["age"].HeaderText = "Age";
            gdvParticipantList.Columns["yn_direct_ben"].HeaderText = "SOCY Beneficiary?";
            gdvParticipantList.Columns["class1_attended"].HeaderText = "Class 1";
            gdvParticipantList.Columns["class2_attended"].HeaderText = "Class 2";
            gdvParticipantList.Columns["class3_attended"].HeaderText = "Class 3";
            gdvParticipantList.Columns["class4_attended"].HeaderText = "Class 4";
            gdvParticipantList.Columns["class5_attended"].HeaderText = "Class 5";
            gdvParticipantList.Columns["class6_attended"].HeaderText = "Class 6";
            gdvParticipantList.Columns["class7_attended"].HeaderText = "Class 7";
            gdvParticipantList.Columns["graduated"].HeaderText = "Graduated";

            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            gdvParticipantList.RowsDefaultCellStyle.BackColor = Color.LightGray;
            gdvParticipantList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            // Set the row and column header styles.
            gdvParticipantList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gdvParticipantList.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            gdvParticipantList.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            // Set the selection background color for all the cells.
            gdvParticipantList.DefaultCellStyle.SelectionBackColor = Color.White;
            gdvParticipantList.DefaultCellStyle.SelectionForeColor = Color.Black;

            foreach (DataGridViewColumn c in gdvParticipantList.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (VaidateMember())
            {
                saveMember();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields,save failed", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gdvParticipantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gdvParticipantList.Rows.Count > 0)
            {
                string id = gdvParticipantList.CurrentRow.Cells[0].Value.ToString();
                LoadNMNAttendanceParticipantDetails(id);
            }
        }

        private void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
            ClearMember();
            LoadDisplayList(string.Empty);
        }

        private void txtHrs1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHrs7_KeyPress(object sender, KeyPressEventArgs e)
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
