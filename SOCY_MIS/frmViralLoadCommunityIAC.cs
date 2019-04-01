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
    public partial class frmViralLoadCommunityIAC : UserControl
    {
        #region Variables
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        DataTable dt = null;
        DateTimePicker oDateTimePicker;
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

        public frmViralLoadCommunityIAC()
        {
            InitializeComponent();
        }

        private void frmViralLoadCommunityIAC_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadLists();
            LoadHHDisplay();
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
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


            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

        }

        protected void LoadSocialWOrkers(string dst_id,string Type)
        {
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnSocialWorkers(dst_id,Type);
            switch (Type)
            {
                case "socialWorker":
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dstemptyRow = dt.NewRow();
                        dstemptyRow["swk_id"] = "-1";
                        dstemptyRow["swk_name"] = "Select Social Worker";
                        dt.Rows.InsertAt(dstemptyRow, 0);

                        cboSocialWorker.DisplayMember = "swk_name";
                        cboSocialWorker.ValueMember = "swk_id";
                        cboSocialWorker.DataSource = dt;
                    }
                    break;
                case "Linkage":
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dstemptyRow = dt.NewRow();
                        dstemptyRow["lc_id"] = "-1";
                        dstemptyRow["lc_name"] = "Select Linkage coorditor";
                        dt.Rows.InsertAt(dstemptyRow, 0);

                        cboLinkagesOfficer.DisplayMember = "lc_name";
                        cboLinkagesOfficer.ValueMember = "lc_id";
                        cboLinkagesOfficer.DataSource = dt;
                    }
                    break;
            }
           
        }

        protected void LoadHHDisplay()
        {
            if (HouseholdId != string.Empty)
            {
                dt = GBV_screeningTool.ReturnHHDetails(HouseholdId); //reused from GBV tool
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboHHCode.SelectedValue = HouseholdId;
                    txtVillage.Text = dtRow["hh_village"].ToString();
                    LoadSocialWOrkers(dtRow["dst_id"].ToString(), "socialWorker");
                    LoadSocialWOrkers(dtRow["dst_id"].ToString(), "Linkage");
                }
            }
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

            cboHHCode.SelectedValue = HouseholdId;
            #endregion HH Codes
        }

        protected void LoadLists()
        {
            #region  lst_non_supress_health_facility
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_health_facility");
            chkNonsupressHealthFacility.DataSource = dt;
            chkNonsupressHealthFacility.DisplayMember = "nsp_name";
            chkNonsupressHealthFacility.ValueMember = "nsp_id";
            #endregion lst_non_supress_health_facility

            #region  lst_non_supress_household
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_household");

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["nsp_id"] = "-1";
            dstemptyRow["nsp_name"] = "Select reason";
            dt.Rows.InsertAt(dstemptyRow, 0);
            cboNonsupressHousehold.DataSource = dt;

            cboNonsupressHousehold.DisplayMember = "nsp_name";
            cboNonsupressHousehold.ValueMember = "nsp_id";

            #endregion lst_non_supress_household

            #region  lst_non_supress_household_action
            dt = benOvcNonSuppressionAdherenceCounselling.ReturnLists("lst_non_supress_action");
            gdvNonsupressAction.DataSource = dt;
            gdvNonsupressAction.Columns["nspa_id"].Visible = false;
            gdvNonsupressAction.Columns["nspa_name"].HeaderText = "Actions Taken";
            gdvNonsupressAction.Columns["nspa_name"].ReadOnly = true;

            gdvNonsupressAction.Columns["nspa_name"].Width = 200;


            DataGridViewCheckBoxColumn _chk_select_reason = new DataGridViewCheckBoxColumn()
            {
                Name = "column_select",
                HeaderText = "Select Action",
                FalseValue = 0,
                TrueValue = 1
            };

            var gdvCombo = new DataGridViewComboBoxColumn()
            {
                Name = "cboProgress"
            };
            gdvCombo.DataSource = new string[] { "Completed", "Pending", "Ongoing" };
           
            var gdv_person = new DataGridViewTextBoxColumn()
            {
                Name = "txtperson"
            };


            this.gdvNonsupressAction.Columns.Insert(0, _chk_select_reason);
            this.gdvNonsupressAction.Columns["column_select"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["column_select"].Width = 35;
     
            this.gdvNonsupressAction.Columns["time_line"].Width = 150;
            this.gdvNonsupressAction.Columns["time_line"].HeaderText = "TimeLine";

            this.gdvNonsupressAction.Columns.Insert(4, gdvCombo);
            this.gdvNonsupressAction.Columns["cboProgress"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["cboProgress"].Width = 150;
            this.gdvNonsupressAction.Columns["cboProgress"].HeaderText = "Progress";

            this.gdvNonsupressAction.Columns.Insert(5, gdv_person);
            this.gdvNonsupressAction.Columns["txtperson"].ReadOnly = false;
            this.gdvNonsupressAction.Columns["txtperson"].Width = 150;
            this.gdvNonsupressAction.Columns["txtperson"].HeaderText = "Responsible Person";

            this.gdvNonsupressAction.DefaultCellStyle.SelectionBackColor = Color.White;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.gdvNonsupressAction.RowsDefaultCellStyle.BackColor = Color.LightGray;
            this.gdvNonsupressAction.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            this.gdvNonsupressAction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.gdvNonsupressAction.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressAction.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionBackColor = Color.Cyan;
            this.gdvNonsupressAction.DefaultCellStyle.SelectionForeColor = Color.Black;

            #endregion lst_non_supress_household_action
        }

        private void btnsaveLine_Click(object sender, EventArgs e)
        {

        }

        private void gdvNonsupressAction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
           
            if (e.ColumnIndex == 5)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                gdvNonsupressAction.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = gdvNonsupressAction.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            gdvNonsupressAction.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblguid.Text = "2533912d-b82f-461f-8254-44161431cddb";
            save();
        }

        protected void save()
        {
           
            benOvcNonSuppressionAdherenceCounselling.hhm_id = cboHHMemberName.SelectedValue.ToString();
            benOvcNonSuppressionAdherenceCounselling.health_fac_name = txtHealthFacility.Text;
            benOvcNonSuppressionAdherenceCounselling.art_number = txtARTNumber.Text;
            benOvcNonSuppressionAdherenceCounselling.visit_date = dtDate.Value.Date;
            benOvcNonSuppressionAdherenceCounselling.swk_id = cboSocialWorker.SelectedValue.ToString();
            benOvcNonSuppressionAdherenceCounselling.lnk_id = cboLinkagesOfficer.SelectedValue.ToString();
            benOvcNonSuppressionAdherenceCounselling.visit_name = cboVisit.Text;
            benOvcNonSuppressionAdherenceCounselling.yn_ben_supress = utilControls.RadioButtonGetSelection(rdnsupressYes, rdnsupressNo);
            benOvcNonSuppressionAdherenceCounselling.usr_id_create = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_id_update = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_date_create = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.usr_date_update = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.ofc_id = SystemConstants.ofc_id;
            benOvcNonSuppressionAdherenceCounselling.district_id = SystemConstants.Return_office_district();


            if (lblguid.Text == "guid")
            {
                benOvcNonSuppressionAdherenceCounselling.iac_id = Guid.NewGuid().ToString();
                lblguid.Text = benOvcNonSuppressionAdherenceCounselling.iac_id;
                benOvcNonSuppressionAdherenceCounselling.save_ben_adherence_counselling("insert");
                MessageBox.Show("Success", "SOCY MIS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                benOvcNonSuppressionAdherenceCounselling.iac_id = lblguid.Text;
                benOvcNonSuppressionAdherenceCounselling.save_ben_adherence_counselling("update");
                
                MessageBox.Show("Success", "SOCY MIS Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        protected void save_ben_non_supress_reason_health_facility(string nspfac_id)
        {
            //SQL = string.Format(SQL, iacr_id, iac_id, nspfac_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            benOvcNonSuppressionAdherenceCounselling.iacr_id = Guid.NewGuid().ToString();
            benOvcNonSuppressionAdherenceCounselling.iac_id = lblguid.Text;
            benOvcNonSuppressionAdherenceCounselling.nspfac_id = nspfac_id;
            benOvcNonSuppressionAdherenceCounselling.usr_id_create = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_id_update = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_date_create = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.usr_date_update = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.ofc_id = SystemConstants.ofc_id;
            benOvcNonSuppressionAdherenceCounselling.district_id = SystemConstants.Return_office_district();

            benOvcNonSuppressionAdherenceCounselling.save_ben_non_supress_reason_health_facility();
        }


        protected void save_ben_adherence_counselling_non_supress_health_household()
        {
            //SQL = string.Format(SQL, iacr_id, iac_id, nsphh_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            benOvcNonSuppressionAdherenceCounselling.iacr_id = Guid.NewGuid().ToString();
            benOvcNonSuppressionAdherenceCounselling.iac_id = lblguid.Text;
            benOvcNonSuppressionAdherenceCounselling.nsphh_id = cboNonsupressHousehold.SelectedValue.ToString();
            benOvcNonSuppressionAdherenceCounselling.usr_id_create = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_id_update = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_date_create = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.usr_date_update = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.ofc_id = SystemConstants.ofc_id;
            benOvcNonSuppressionAdherenceCounselling.district_id = SystemConstants.Return_office_district();

            benOvcNonSuppressionAdherenceCounselling.save_ben_adherence_counselling_non_supress_health_household();

        }

        protected void save_ben_adherence_counselling_non_supress_household_action(string iacr_id,string nsp_action_id,DateTime nsp_action_timeline,string nsp_action_progress,string nsp_action_person_responsible)
        {
         
            benOvcNonSuppressionAdherenceCounselling.iacrs_id = Guid.NewGuid().ToString();
            benOvcNonSuppressionAdherenceCounselling.iac_id = lblguid.Text;
            benOvcNonSuppressionAdherenceCounselling.iacr_id = iacr_id;
            benOvcNonSuppressionAdherenceCounselling.nsp_action_id = nsp_action_id;
            benOvcNonSuppressionAdherenceCounselling.nsp_action_timeline = nsp_action_timeline;
            benOvcNonSuppressionAdherenceCounselling.nsp_action_progress = nsp_action_progress;
            benOvcNonSuppressionAdherenceCounselling.nsp_action_person_responsible = nsp_action_person_responsible;

            benOvcNonSuppressionAdherenceCounselling.usr_id_create = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_id_update = SystemConstants.user_id;
            benOvcNonSuppressionAdherenceCounselling.usr_date_create = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.usr_date_update = DateTime.Today;
            benOvcNonSuppressionAdherenceCounselling.ofc_id = SystemConstants.ofc_id;
            benOvcNonSuppressionAdherenceCounselling.district_id = SystemConstants.Return_office_district();

            benOvcNonSuppressionAdherenceCounselling.save_ben_adherence_counselling_non_supress_household_action();
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

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        private void cboHHCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHHCode.SelectedIndex != -1)
            {
                #region hhm

                dt = GBV_screeningTool.ReturnLists("hhm", HouseholdId);  //reused from GBV tool
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

        protected void ReturnHHMDetails(string hhm_id)
        {
            dt = benSchoolReadinessTool.ReturnHHMDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                //cbosex.SelectedValue = dtRow["gnd_id"].ToString();
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
    }
}
