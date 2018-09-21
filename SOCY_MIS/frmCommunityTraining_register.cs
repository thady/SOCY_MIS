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
    public partial class frmCommunityTraining_register : UserControl
    {
        #region Variables
        DataTable dt = null;
        private frmResultArea01 frmPrt = null;
        frmCommunityTraining_registerSearch frmCommRegister = null;
        Master frmMST = null;
        #endregion Variables

        #region # Property
        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmCommunityTraining_register()
        {
            InitializeComponent();
        }

        public frmCommunityTraining_registerSearch FormCallingSearch
        {
            get { return frmCommRegister; }
            set { frmCommRegister = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        private void frmCommunityTraining_register_Load(object sender, EventArgs e)
        {
            Return_lookups();

            LoadTrainingDetails(silcCommunityTrainingRegister.ctr_id);
        }

        private void TrainingCalender_MouseDown(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = TrainingCalender.HitTest(e.Location);
            if (info.HitArea == MonthCalendar.HitArea.Date)
            {
                if (TrainingCalender.BoldedDates.Contains(info.Time))
                    TrainingCalender.RemoveBoldedDate(info.Time);
                else
                    TrainingCalender.AddBoldedDate(info.Time);
                TrainingCalender.UpdateBoldedDates();
            }
        }

        private void TrainingCalender_DateChanged(object sender, DateRangeEventArgs e)
        {
            string selectedDate = TrainingCalender.SelectionRange.Start.ToShortDateString();
            if (Convert.ToDateTime(selectedDate) < dtTrainingFrom.Value.Date || Convert.ToDateTime(selectedDate) > dtTrainingTo.Value.Date)
            {
                MessageBox.Show("Participant attendance date must be in range of activity date", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lstDates.Items.Contains(selectedDate))
                {
                    lstDates.Items.Remove(selectedDate);
                }
                else
                {
                    lstDates.Items.Add(selectedDate);
                }
            }
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

            cboDistrict.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDistrict.AutoCompleteSource = AutoCompleteSource.ListItems;
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

            cboGender.DataSource = dt;
            cboGender.DisplayMember = "gnd_name";
            cboGender.ValueMember = "gnd_id";
            #endregion Gender

            #region Training Type
            dt = silcCommunityTrainingRegister.Return_lookups("TrainingType", string.Empty);
            DataRow ttp_emptyRow = dt.NewRow();
            ttp_emptyRow["ttp_id"] = "-1";
            ttp_emptyRow["ttp_name"] = "Select Training";
            dt.Rows.InsertAt(ttp_emptyRow, 0);

            cboTrainingType.DataSource = dt;
            cboTrainingType.DisplayMember = "ttp_name";
            cboTrainingType.ValueMember = "ttp_id";
            #endregion Training Type

            #region Training Type session
            dt = silcCommunityTrainingRegister.Return_lookups("TrainingTypeSession", cboTrainingType.SelectedValue.ToString());
            DataRow ttps_emptyRow = dt.NewRow();
            ttps_emptyRow["ttps_id"] = "-1";
            ttps_emptyRow["ttps_name"] = "Select session";
            dt.Rows.InsertAt(ttps_emptyRow, 0);

            cboTrainigSession.DataSource = dt;
            cboTrainigSession.DisplayMember = "ttps_name";
            cboTrainigSession.ValueMember = "ttps_id";
            #endregion Training Type
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

            returnHHCodesByLocation();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                save_update_Training_details();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void save_update_Training_details()
        {
            if (InputIsValid("ctr"))
            {
                if (dtTrainingFrom.Value.Date == DateTime.Today && dtTrainingTo.Value.Date == DateTime.Today)
                {
                    DialogResult dialogResult = MessageBox.Show("Start and end date for this activity seem to be set to today's date,are you sure to save this activity as for Today's date?", "SOCY MIS Message Centre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        #region Save
                        if (lblctr_id.Text == "lblctr_id")
                        {
                            silcCommunityTrainingRegister.ctr_id = Guid.NewGuid().ToString();
                            silcCommunityTrainingRegister.prt_id = cboIP.SelectedValue.ToString();
                            silcCommunityTrainingRegister.cso_id = cboCso.SelectedValue.ToString();
                            silcCommunityTrainingRegister.dst_id = cboDistrict.SelectedValue.ToString();
                            silcCommunityTrainingRegister.sct_id = cboSubCounty.SelectedValue.ToString();
                            silcCommunityTrainingRegister.tr_name = cboTrainingType.SelectedValue.ToString();
                            silcCommunityTrainingRegister.module_name = cboTrainigSession.SelectedValue.ToString();
                            silcCommunityTrainingRegister.tr_total_days = txtsessionDays.Text;
                            silcCommunityTrainingRegister.tr_date_from = dtTrainingFrom.Value;
                            silcCommunityTrainingRegister.tr_date_to = dtTrainingTo.Value;
                            silcCommunityTrainingRegister.module_desc = txtsessiondesc.Text;
                            silcCommunityTrainingRegister.tr_venue = txtVenue.Text;
                            silcCommunityTrainingRegister.trainer_type = cboTrainerType.Text;
                            silcCommunityTrainingRegister.artisan_name = txtArtisan.Text;
                            silcCommunityTrainingRegister.facilitator_trainer_name = txtFacilitatorName.Text;
                            silcCommunityTrainingRegister.usr_id_create = SystemConstants.user_id;
                            silcCommunityTrainingRegister.usr_id_update = SystemConstants.user_id;
                            silcCommunityTrainingRegister.usr_date_create = DateTime.Now;
                            silcCommunityTrainingRegister.usr_date_update = DateTime.Now;
                            silcCommunityTrainingRegister.ofc_id = SystemConstants.ofc_id;
                            silcCommunityTrainingRegister.district_id = SystemConstants.Return_office_district();

                            lblctr_id.Text = silcCommunityTrainingRegister.save_update_Training_details("insert");
                            MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            silcCommunityTrainingRegister.ctr_id = lblctr_id.Text;
                            silcCommunityTrainingRegister.prt_id = cboIP.SelectedValue.ToString();
                            silcCommunityTrainingRegister.cso_id = cboCso.SelectedValue.ToString();
                            silcCommunityTrainingRegister.dst_id = cboDistrict.SelectedValue.ToString();
                            silcCommunityTrainingRegister.sct_id = cboSubCounty.SelectedValue.ToString();
                            silcCommunityTrainingRegister.tr_name = cboTrainingType.SelectedValue.ToString();
                            silcCommunityTrainingRegister.module_name = cboTrainigSession.SelectedValue.ToString();
                            silcCommunityTrainingRegister.tr_total_days = txtsessionDays.Text;
                            silcCommunityTrainingRegister.tr_date_from = dtTrainingFrom.Value;
                            silcCommunityTrainingRegister.tr_date_to = dtTrainingTo.Value;
                            silcCommunityTrainingRegister.module_desc = txtsessiondesc.Text;
                            silcCommunityTrainingRegister.tr_venue = txtVenue.Text;
                            silcCommunityTrainingRegister.trainer_type = cboTrainerType.Text;
                            silcCommunityTrainingRegister.artisan_name = txtArtisan.Text;
                            silcCommunityTrainingRegister.facilitator_trainer_name = txtFacilitatorName.Text;
                            silcCommunityTrainingRegister.usr_id_update = SystemConstants.user_id;
                            silcCommunityTrainingRegister.usr_date_update = DateTime.Now;

                            string update_record = silcCommunityTrainingRegister.save_update_Training_details("update");
                            MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion Save
                    }
                    else
                    {
                        //dont do anything
                    }
                }
                else
                {
                    #region Save
                    if (lblctr_id.Text == "lblctr_id")
                    {
                        silcCommunityTrainingRegister.ctr_id = Guid.NewGuid().ToString();
                        silcCommunityTrainingRegister.prt_id = cboIP.SelectedValue.ToString();
                        silcCommunityTrainingRegister.cso_id = cboCso.SelectedValue.ToString();
                        silcCommunityTrainingRegister.dst_id = cboDistrict.SelectedValue.ToString();
                        silcCommunityTrainingRegister.sct_id = cboSubCounty.SelectedValue.ToString();
                        silcCommunityTrainingRegister.tr_name = cboTrainingType.SelectedValue.ToString();
                        silcCommunityTrainingRegister.module_name = cboTrainigSession.SelectedValue.ToString();
                        silcCommunityTrainingRegister.tr_total_days = txtsessionDays.Text;
                        silcCommunityTrainingRegister.tr_date_from = dtTrainingFrom.Value.Date;
                        silcCommunityTrainingRegister.tr_date_to = dtTrainingTo.Value.Date;
                        silcCommunityTrainingRegister.module_desc = txtsessiondesc.Text;
                        silcCommunityTrainingRegister.tr_venue = txtVenue.Text;
                        silcCommunityTrainingRegister.trainer_type = cboTrainerType.Text;
                        silcCommunityTrainingRegister.artisan_name = txtArtisan.Text;
                        silcCommunityTrainingRegister.facilitator_trainer_name = txtFacilitatorName.Text;
                        silcCommunityTrainingRegister.usr_id_create = SystemConstants.user_id;
                        silcCommunityTrainingRegister.usr_id_update = SystemConstants.user_id;
                        silcCommunityTrainingRegister.usr_date_create = DateTime.Today;
                        silcCommunityTrainingRegister.usr_date_update = DateTime.Today;
                        silcCommunityTrainingRegister.ofc_id = SystemConstants.ofc_id;
                        silcCommunityTrainingRegister.district_id = SystemConstants.Return_office_district();

                        lblctr_id.Text = silcCommunityTrainingRegister.save_update_Training_details("insert");
                        MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        silcCommunityTrainingRegister.ctr_id = lblctr_id.Text;
                        silcCommunityTrainingRegister.prt_id = cboIP.SelectedValue.ToString();
                        silcCommunityTrainingRegister.cso_id = cboCso.SelectedValue.ToString();
                        silcCommunityTrainingRegister.dst_id = cboDistrict.SelectedValue.ToString();
                        silcCommunityTrainingRegister.sct_id = cboSubCounty.SelectedValue.ToString();
                        silcCommunityTrainingRegister.tr_name = cboTrainingType.SelectedValue.ToString();
                        silcCommunityTrainingRegister.module_name = cboTrainigSession.SelectedValue.ToString();
                        silcCommunityTrainingRegister.tr_total_days = txtsessionDays.Text;
                        silcCommunityTrainingRegister.tr_date_from = dtTrainingFrom.Value.Date;
                        silcCommunityTrainingRegister.tr_date_to = dtTrainingTo.Value.Date;
                        silcCommunityTrainingRegister.module_desc = txtsessiondesc.Text;
                        silcCommunityTrainingRegister.tr_venue = txtVenue.Text;
                        silcCommunityTrainingRegister.trainer_type = cboTrainerType.Text;
                        silcCommunityTrainingRegister.artisan_name = txtArtisan.Text;
                        silcCommunityTrainingRegister.facilitator_trainer_name = txtFacilitatorName.Text;
                        silcCommunityTrainingRegister.usr_id_update = SystemConstants.user_id;
                        silcCommunityTrainingRegister.usr_date_update = DateTime.Today;

                        string update_record = silcCommunityTrainingRegister.save_update_Training_details("update");
                        MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion Save
                }
            }
            else
            {
                MessageBox.Show("Fields marked with (*) are required", "SOCY MIS Message centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected bool InputIsValid(string dataType)
        {
            bool isValid = false;

            if (dataType == "ctr")
            {
                if (cboIP.SelectedValue.ToString() == "-1" || cboCso.SelectedValue.ToString() == "-1" || cboDistrict.SelectedValue.ToString() == "-1" || cboSubCounty.SelectedValue.ToString() == "-1"
                || cboTrainingType.SelectedValue.ToString() == "-1" || cboTrainigSession.SelectedValue.ToString() == "-1" || dtTrainingFrom.Checked == false || dtTrainingTo.Checked == false || txtsessionDays.Text == string.Empty
                || txtsessiondesc.Text == string.Empty || txtVenue.Text == string.Empty || cboTrainerType.Text == string.Empty)
                {
                    isValid = false;
                }
                else if (txtArtisan.Text == string.Empty && txtFacilitatorName.Text == string.Empty) { isValid = false; }
                else if (cboTrainerType.Text == "Artisan" && txtArtisan.Text == string.Empty) { isValid = false; }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                if ((rdnDirectBen.Checked == false && rdnIndirectBen.Checked == false) || (rdnDirectBen.Checked == true && cboHHCode.Text == string.Empty) || txtMemberName.Text == string.Empty
                    || cboGender.SelectedValue.ToString() == "-1" || txtAge.Text == string.Empty || lstDates.Items.Count == 0 || lblctr_id.Text == "lblctr_id")
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

        private void dtTrainingFrom_ValueChanged(object sender, EventArgs e)
        {
            //if (dtTrainingFrom.Value.Date > dtTrainingTo.Value.Date)
            //{
            //    MessageBox.Show("End date cannot be less than start date!", "SOCY MIS Message centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dtTrainingTo.Value = DateTime.Today;
            //}
            //else if (dtTrainingTo.Value.Date > dtTrainingFrom.Value.Date)
            //{
            //    TimeSpan TotalDays = dtTrainingTo.Value.Date - dtTrainingFrom.Value.Date;
            //    //txtsessionDays.Text = TotalDays.TotalDays.ToString();
            //    //txtsessionDays.Text = (dtTrainingTo.Value.Date - dtTrainingFrom.Value.Date).TotalDays.ToString();

            //    int Days = Convert.ToInt32(TotalDays.TotalDays);
            //    Days = Days + 1;
            //    txtsessionDays.Text = Days.ToString();
            //}

            ////set to 1 day if start and end dates are the same
            //if (dtTrainingFrom.Value == dtTrainingTo.Value) { txtsessionDays.Text = "1"; }
        }

        private void dtTrainingTo_ValueChanged(object sender, EventArgs e)
        {
            //if (dtTrainingFrom.Value.Date > dtTrainingTo.Value.Date)
            //{
            //    MessageBox.Show("End date cannot be less than start date!", "SOCY MIS Message centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dtTrainingTo.Value = DateTime.Today;
            //}
            //else if (dtTrainingTo.Value.Date > dtTrainingFrom.Value.Date)
            //{
            //    TimeSpan TotalDays = dtTrainingTo.Value.Date - dtTrainingFrom.Value.Date;
            //    //txtsessionDays.Text = TotalDays.TotalDays.ToString();
            //    //txtsessionDays.Text = (dtTrainingTo.Value.Date - dtTrainingFrom.Value.Date).TotalDays.ToString();

            //    int Days = Convert.ToInt32(TotalDays.TotalDays);
            //    Days = Days + 1;
            //    txtsessionDays.Text = Days.ToString();
            //}

            ////set to 1 day if start and end dates are the same
            //if (dtTrainingFrom.Value == dtTrainingTo.Value) { txtsessionDays.Text = "1"; }
        }

        private void cboTrainerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArtisan.Enabled = cboTrainerType.Text == "Artisan" ? true : false;
            txtFacilitatorName.Enabled = cboTrainerType.Text != "Artisan" ? true : false;
        }

        private void btnsaveP_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                save_update_TrainingParticipants();
                returnTrainingParticipants(lblctr_id.Text);
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void save_update_TrainingParticipants()
        {
            if (InputIsValid("ctrm"))
            {
                if (lblctr_id.Text == "lblctr_id")
                {
                    MessageBox.Show("");
                }
                if (lblctrm_id.Text == "lblctrm_id")
                {
                    #region Save
                    silcCommunityTrainingRegisterMember.ctrm_id = Guid.NewGuid().ToString();
                    silcCommunityTrainingRegisterMember.ctr_id = lblctr_id.Text;

                    #region BeneficiaryType
                    if (rdnDirectBen.Checked == true) { silcCommunityTrainingRegisterMember.ben_type = "Direct Beneficiary"; }
                    else if (rdnIndirectBen.Checked == true) { silcCommunityTrainingRegisterMember.ben_type = "Indirect Beneficiary"; }
                    #endregion BeneficiaryType

                    silcCommunityTrainingRegisterMember.hhm_code = cboHHCode.Text;
                    silcCommunityTrainingRegisterMember.parcipant_name = txtMemberName.Text;
                    silcCommunityTrainingRegisterMember.gnd_id = cboGender.SelectedValue.ToString();
                    silcCommunityTrainingRegisterMember.age = txtAge.Text;
                    silcCommunityTrainingRegisterMember.usr_id_create = SystemConstants.user_id;
                    silcCommunityTrainingRegisterMember.usr_id_update = SystemConstants.user_id;
                    silcCommunityTrainingRegisterMember.usr_date_create = DateTime.Today;
                    silcCommunityTrainingRegisterMember.usr_date_update = DateTime.Today;
                    silcCommunityTrainingRegisterMember.ofc_id = SystemConstants.ofc_id;
                    silcCommunityTrainingRegisterMember.district_id = SystemConstants.Return_office_district();

                    string ctrmid = silcCommunityTrainingRegisterMember.save_update_Participant_details("insert");

                    #region insert Attendance Dates
                    for (int i = 0; i < lstDates.Items.Count; i++)
                    {
                        DateTime attendance_date = Convert.ToDateTime(lstDates.Items[i].ToString());
                        silcCommunityTrainingRegisterMember.ctrmD_id = Guid.NewGuid().ToString();
                        silcCommunityTrainingRegisterMember.date = attendance_date;
                        silcCommunityTrainingRegisterMember.ofc_id = SystemConstants.ofc_id;
                        silcCommunityTrainingRegisterMember.district_id = SystemConstants.Return_office_district();

                        silcCommunityTrainingRegisterMember.save_update_Participant_attendance_dates("insert");

                    }
                    #endregion insert Attendance Dates

                    #region Participants List
                    returnTrainingParticipants(lblctr_id.Text);
                    #endregion Participants List

                    MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion Save
                }
                else
                {
                    #region Update
                    silcCommunityTrainingRegisterMember.ctrm_id = lblctrm_id.Text;
                    silcCommunityTrainingRegisterMember.ctr_id = lblctr_id.Text;

                    #region BeneficiaryType
                    if (rdnDirectBen.Checked == true) { silcCommunityTrainingRegisterMember.ben_type = "Direct Beneficiary"; }
                    else if (rdnIndirectBen.Checked == true) { silcCommunityTrainingRegisterMember.ben_type = "Indirect Beneficiary"; }
                    #endregion BeneficiaryType

                    silcCommunityTrainingRegisterMember.hhm_code = cboHHCode.Text;
                    silcCommunityTrainingRegisterMember.parcipant_name = txtMemberName.Text;
                    silcCommunityTrainingRegisterMember.gnd_id = cboGender.SelectedValue.ToString();
                    silcCommunityTrainingRegisterMember.age = txtAge.Text;
                    silcCommunityTrainingRegisterMember.usr_id_update = SystemConstants.user_id;
                    silcCommunityTrainingRegisterMember.usr_date_update = DateTime.Today;

                    silcCommunityTrainingRegisterMember.save_update_Participant_details("update");

                    #region insert Attendance Dates
                    for (int i = 0; i < lstDates.Items.Count; i++)
                    {
                        DateTime attendance_date = Convert.ToDateTime(lstDates.Items[i].ToString());
                        silcCommunityTrainingRegisterMember.ctrmD_id = Guid.NewGuid().ToString();
                        silcCommunityTrainingRegisterMember.date = attendance_date;
                        silcCommunityTrainingRegisterMember.ofc_id = SystemConstants.ofc_id;
                        silcCommunityTrainingRegisterMember.district_id = SystemConstants.Return_office_district();

                        silcCommunityTrainingRegisterMember.save_update_Participant_attendance_dates("update");

                    }
                    #endregion insert Attendance Dates

                    #region Participants List
                    returnTrainingParticipants(lblctr_id.Text);
                    #endregion Participants List

                    MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion Update
                }
            }
            else
            {
                MessageBox.Show("You either have missing values or you haven't yet saved a training,save failed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rdnDirectBen_CheckedChanged(object sender, EventArgs e)
        {
            cboHHCode.Enabled = rdnDirectBen.Checked == true ? true : false;

            if (rdnDirectBen.Checked == true)
            {
                txtMemberName.ReadOnly = true;
                cboGender.Enabled = false;
                txtAge.ReadOnly = true;
            }
            else
            {
                txtMemberName.ReadOnly = false;
                cboGender.Enabled = true;
                txtAge.ReadOnly = false;
                txtMemberName.Clear();
                cboGender.SelectedValue = "-1";
                txtAge.Clear();
            }
            

            //#region HH Codes
            //dt = silcCommunityTrainingRegister.Return_lookups("hh_codes", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString());

            //DataRow hhCode_emptyRow = dt.NewRow();
            //hhCode_emptyRow["hh_id"] = "-1";
            //hhCode_emptyRow["hh_code"] = "";
            //dt.Rows.InsertAt(hhCode_emptyRow, 0);

            //cboHHCode.DataSource = dt;

            //cboHHCode.DisplayMember = "hh_code";
            //cboHHCode.ValueMember = "hh_id";

            //cboHHCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboHHCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //#endregion HH Codes
        }

        protected void returnTrainingDetails(string ctr_id)
        {
            DataTable dt = silcCommunityTrainingRegister.Return_lookups("TrainingDetails", ctr_id, string.Empty, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                lblctr_id.Text = dtRow["ctr_id"].ToString();
                cboIP.SelectedValue = dtRow["prt_id"].ToString();
                cboCso.SelectedValue = dtRow["cso_id"].ToString();
                cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                cboTrainingType.SelectedValue = dtRow["tr_name"].ToString();
                cboTrainigSession.SelectedValue = dtRow["module_name"].ToString();
                dtTrainingFrom.Value = Convert.ToDateTime(dtRow["tr_date_from"]);
                dtTrainingTo.Value = Convert.ToDateTime(dtRow["tr_date_to"]);
                txtsessionDays.Text = dtRow["tr_total_days"].ToString();
                txtsessiondesc.Text = dtRow["module_desc"].ToString();
                txtVenue.Text = dtRow["tr_venue"].ToString();
                cboTrainerType.Text = dtRow["trainer_type"].ToString();
                txtArtisan.Text = dtRow["artisan_name"].ToString();
                txtFacilitatorName.Text = dtRow["facilitator_trainer_name"].ToString();

                #region Training Participants
                returnTrainingParticipants(ctr_id);
                #endregion Training Participants

                tlpDisplay01.Enabled = false;

                #region AccessControl
                string ofc_id = dtRow["ofc_id"].ToString();
                btnsave.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                btnsaveP.Enabled = (ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, ofc_id));
                #endregion AccessControl
            }
        }

        protected void LoadTrainingDetails(string ctr_id )
        {
            if (ctr_id != string.Empty)
            {
                returnTrainingDetails(ctr_id);
            }
        }

        protected void returnTrainingParticipants(string ctr_id)
        {
            DataTable dt = silcCommunityTrainingRegister.Return_lookups("TrainingParticipants", ctr_id, string.Empty, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
            {
                gdvParticipants.DataSource = dt;

                gdvParticipants.Columns["ctrm_id"].Visible = false;
                gdvParticipants.Columns["ben_type"].Visible = false;
                gdvParticipants.Columns["hhm_code"].Visible = false;
                gdvParticipants.Columns["gnd_id"].Visible = false;
                gdvParticipants.Columns["age"].Visible = false;

                gdvParticipants.Columns["parcipant_name"].HeaderText = "Participant Name";

                gdvParticipants.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvParticipants.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdvParticipants.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdvParticipants.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdvParticipants.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdvParticipants.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdvParticipants.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdvParticipants.DefaultCellStyle.SelectionBackColor = Color.White;
                gdvParticipants.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdvParticipants.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }

            }
        }

        protected void returnParticipantAttendanceDates(string ctrm_id)
        {
            string dt_attendance_date = string.Empty;
            DataRow dtRow = null;
            List<DateTime> lst_dates = new List<DateTime>();
            DataTable dt = silcCommunityTrainingRegister.Return_lookups("AttendanceDates", ctrm_id, string.Empty, string.Empty, string.Empty);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtRow = dt.Rows[i];
                    dt_attendance_date = Convert.ToDateTime(dtRow["date"]).ToShortDateString();
                    lst_dates.Add(Convert.ToDateTime(dt_attendance_date));
                    lstDates.Items.Add(dt_attendance_date);
                }

                TrainingCalender.BoldedDates = lst_dates.ToArray();
            }
        }

        private void gdvParticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvParticipants.Rows.Count > 0)
            {
                string ctrm_id = gdvParticipants.CurrentRow.Cells[0].Value.ToString();

                lstDates.Items.Clear();
                returnParticipantAttendanceDates(ctrm_id);

                #region Ben Type
                string ben_type = gdvParticipants.CurrentRow.Cells[1].Value.ToString();
                if (ben_type == "Direct Beneficiary")
                {
                    rdnDirectBen.Checked = true;
                }
                else
                    rdnIndirectBen.Checked = true;
                #endregion Ben Type

                cboHHCode.Text = gdvParticipants.CurrentRow.Cells[2].Value.ToString();
                txtMemberName.Text = gdvParticipants.CurrentRow.Cells[3].Value.ToString();
                cboGender.SelectedValue = gdvParticipants.CurrentRow.Cells[4].Value.ToString();
                txtAge.Text = gdvParticipants.CurrentRow.Cells[5].Value.ToString();
                lblctrm_id.Text = ctrm_id;
                tlpDisplay02.Enabled = false;
                panel01.Enabled = false;
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            NewTraining();
        }

        protected void NewTraining()
        {
            lblctr_id.Text = "lblctr_id";
            cboIP.SelectedValue = "-1";
            cboCso.SelectedValue = "-1";
            cboDistrict.SelectedValue = "-1";
            cboSubCounty.SelectedValue = "-1";
            cboTrainingType.SelectedValue = "-1";
            cboTrainigSession.SelectedValue = "-1";
            dtTrainingFrom.Value = DateTime.Today;
            dtTrainingTo.Value = DateTime.Today;
            txtsessionDays.Clear();
            txtsessiondesc.Clear();
            txtVenue.Clear();
            cboTrainerType.Text = string.Empty;
            txtArtisan.Clear();
            txtFacilitatorName.Text = string.Empty;

            tlpDisplay01.Enabled = true;

            NewParticipant();
        }

        protected void NewParticipant()
        {
            rdnDirectBen.Checked = false;
            rdnIndirectBen.Checked = false;
            cboHHCode.Text = string.Empty;
            txtMemberName.Clear();
            cboGender.SelectedValue = "-1";
            txtAge.Clear();
            lblctrm_id.Text = "lblctrm_id";
            lstDates.Items.Clear();
            TrainingCalender.RemoveAllBoldedDates();
            TrainingCalender.UpdateBoldedDates();
            tlpDisplay02.Enabled = true;
            panel01.Enabled = true;
        }

        private void lnlback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            FormParent.LoadControl(FormCallingSearch, this.Name);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            tlpDisplay01.Enabled = true;
        }

        private void btneditP_Click(object sender, EventArgs e)
        {
            tlpDisplay02.Enabled = true;
            panel01.Enabled = true;
        }

        private void cboTrainingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Training Type
            dt = silcCommunityTrainingRegister.Return_lookups("TrainingTypeSession", cboTrainingType.SelectedValue.ToString());
            DataRow ttp_emptyRow = dt.NewRow();
            ttp_emptyRow["ttps_id"] = "-1";
            ttp_emptyRow["ttps_name"] = "Select session";
            dt.Rows.InsertAt(ttp_emptyRow, 0);

            cboTrainigSession.DataSource = dt;
            cboTrainigSession.DisplayMember = "ttps_name";
            cboTrainigSession.ValueMember = "ttps_id";
            #endregion Training Type

        }

        private void btnNewP_Click(object sender, EventArgs e)
        {
            NewParticipant();
        }

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(),cboParish.SelectedValue.ToString());

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHcCode.DataSource = dt;

            cboHHcCode.DisplayMember = "hh_code";
            cboHHcCode.ValueMember = "hh_id";

            #endregion HH Codes
        }

        protected void returnHHMembers(string hh_id)
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("hhm_codes_communityTrainingRegister", hh_id, string.Empty, string.Empty,string.Empty);

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hhm_id"] = "-1";
            hhCode_emptyRow["hhm_code"] = "Member Code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hhm_code";
            cboHHCode.ValueMember = "hhm_id";

            cboHHCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboHHCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
        }

        private void cboHHcCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHMembers(cboHHcCode.SelectedValue.ToString());
        }

        protected void ReturnHHMData(string hhm_id)
        {
            dt = silcCommunityTrainingRegister.Return_lookups("hhm_details_communityTrainingRegister", hhm_id, string.Empty, string.Empty,string.Empty);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                txtMemberName.Text = dtRow["hhm_name"].ToString();
                cboGender.SelectedValue = dtRow["gnd_id"].ToString();

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

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHCode.SelectedIndex != 0)
            {
                ReturnHHMData(cboHHCode.SelectedValue.ToString());
            }
        }

        private void rdnIndirectBen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnIndirectBen.Checked == true)
            {
                cboHHcCode.Enabled = false;
                cboHHCode.Enabled = false;
                cboHHcCode.SelectedValue = "-1";
                cboHHCode.SelectedValue = "-1";
            }
            else
            {
                cboHHcCode.Enabled = true;
                cboHHCode.Enabled = true;
            }
        }

        private void txtsessionDays_KeyPress(object sender, KeyPressEventArgs e)
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
