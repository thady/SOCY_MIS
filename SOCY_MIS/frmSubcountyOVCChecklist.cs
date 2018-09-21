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
    public partial class frmSubcountyOVCChecklist : UserControl
    {

        #region Variables
        private string strId = string.Empty;
        private frmSubCountyOVCChecklistSearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        DataTable dt = null;
        string strMessage = string.Empty;
        #endregion Variables

        #region Property
        public frmSubCountyOVCChecklistSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property
        public frmSubcountyOVCChecklist()
        {
            InitializeComponent();
        }

        private void frmSubcountyOVCChecklist_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadDisplay(prtSubCountyOVCChecklist.soc_id);
        }

        protected void Return_lookups()
        {
            #region district
            dt = prtSubCountyOVCChecklist.Return_lookups("district");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["dst_id"] = "-1";
                ipemptyRow["dst_name"] = "Select district";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbDistrict.DataSource = dt;
                cbDistrict.DisplayMember = "dst_name";
                cbDistrict.ValueMember = "dst_id";

            }
            #endregion district

            #region subcounty
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cbDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cbosubcounty.DataSource = dt;
            cbosubcounty.DisplayMember = "sct_name";
            cbosubcounty.ValueMember = "sct_id";

            cbosubcounty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbosubcounty.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion subcounty

            #region quarter
            dt = prtSubCountyOVCChecklist.Return_lookups("quarter");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["qy_id"] = "-1";
                ipemptyRow["qy_name"] = "Select quarter";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbQuarter.DataSource = dt;
                cbQuarter.DisplayMember = "qy_name";
                cbQuarter.ValueMember = "qy_id";

            }
            #endregion quarter

            #region FY
            dt = prtSubCountyOVCChecklist.Return_lookups("fy");
            if (dt.Rows.Count > 0)
            {
                DataRow ipemptyRow = dt.NewRow();
                ipemptyRow["fy_id"] = "-1";
                ipemptyRow["fy_name"] = "Select FY";
                dt.Rows.InsertAt(ipemptyRow, 0);

                cbFinancialYear.DataSource = dt;
                cbFinancialYear.DisplayMember = "fy_name";
                cbFinancialYear.ValueMember = "fy_id";

            }
            #endregion FY
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                Save();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Back()
        {
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
            Back();
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clear();
            Back();
        }

        #region Save
        protected void Save()
        {
            if (ValidateIput())
            {
                #region Set Variables
                prtSubCountyOVCChecklist.dst_id = cbDistrict.SelectedValue.ToString();
                prtSubCountyOVCChecklist.fy_id = cbFinancialYear.SelectedValue.ToString();
                prtSubCountyOVCChecklist.qy_id = cbQuarter.SelectedValue.ToString();
                prtSubCountyOVCChecklist.soc_date = dtpDate.Value.Date;

                prtSubCountyOVCChecklist.yn_id_meetings_held = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnMeetingsHeldYes, rbtnMeetingsHeldNo);
                prtSubCountyOVCChecklist.yn_id_membership_constituted = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnMembershipConstitutedYes, rbtnMembershipConstitutedNo);
                prtSubCountyOVCChecklist.yn_id_cdo_supervision = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnSupervisionReportsYes, rbtnSupervisionReportsNo);
                prtSubCountyOVCChecklist.yn_signed_minutes_available = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnSOVCCMinutesYes, rbtnSOVCCMinutesNo);
                prtSubCountyOVCChecklist.yn_id_sovcc_discussed_minutes_available = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnSOVCCMinutesAvailableYes, rbtnSOVCCMinutesAvailableNo);
                prtSubCountyOVCChecklist.yn_id_ovcmis_district = PSAUtilsWin32.utilControls.RadioButtonGetSelection(rbtnOVCMISSubcountyYes, rbtnOVCMISSubcountyNo);

                prtSubCountyOVCChecklist.soc_cso_report = Convert.ToInt32(nudCSOReport.Value);
                prtSubCountyOVCChecklist.soc_cso_total = Convert.ToInt32(nudCSOTotal.Value);
                prtSubCountyOVCChecklist.soc_action_points_implemented = Convert.ToInt32(nudActionPointsImplemented.Value);
                prtSubCountyOVCChecklist.soc_action_points_total_identified = Convert.ToInt32(nudActionPointsTotal.Value);
                prtSubCountyOVCChecklist.usr_id_create = SystemConstants.user_id;
                prtSubCountyOVCChecklist.usr_id_update = SystemConstants.user_id;
                prtSubCountyOVCChecklist.usr_date_create = DateTime.Today;
                prtSubCountyOVCChecklist.usr_date_update = DateTime.Today;
                prtSubCountyOVCChecklist.ofc_id = SystemConstants.ofc_id;
                prtSubCountyOVCChecklist.district_id = SystemConstants.Return_office_district();
                prtSubCountyOVCChecklist.sct_id = cbosubcounty.SelectedValue.ToString();
                #endregion Set Variables

                if (prtSubCountyOVCChecklist.soc_id == string.Empty)
                {
                    prtSubCountyOVCChecklist.soc_id = Guid.NewGuid().ToString();

                    prtSubCountyOVCChecklist.save_update_SOVCC_CheckList("insert");
                    MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    prtSubCountyOVCChecklist.save_update_SOVCC_CheckList("update");
                    MessageBox.Show("Success", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(strMessage, "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           

            #endregion Save
        }

        protected Boolean ValidateIput()
        {
            bool isValid = false;
            if (cbDistrict.SelectedValue.ToString() == "-1" || cbFinancialYear.SelectedValue.ToString() == "-1" || cbFinancialYear.SelectedValue.ToString() == "-1" || dtpDate.Checked == false)
            {
                isValid = false;
                strMessage = "Missing required values";
            }
            else
                isValid = true;

            return isValid;
        }

        #region Load Display
        protected void LoadDisplay(string soc_id)
        {
            if (soc_id != string.Empty)
            {
                prtSubCountyOVCChecklist.LoadDisplay(soc_id);

                cbDistrict.SelectedValue = prtSubCountyOVCChecklist.dst_id;
                cbosubcounty.SelectedValue = prtSubCountyOVCChecklist.sct_id;
                cbQuarter.SelectedValue = prtSubCountyOVCChecklist.qy_id;
                cbFinancialYear.SelectedValue = prtSubCountyOVCChecklist.fy_id;
                dtpDate.Value = prtSubCountyOVCChecklist.soc_date;
                nudCSOTotal.Value = prtSubCountyOVCChecklist.soc_cso_total;
                nudCSOReport.Value = prtSubCountyOVCChecklist.soc_cso_report;
                nudActionPointsTotal.Value = prtSubCountyOVCChecklist.soc_action_points_total_identified;
                nudActionPointsImplemented.Value = prtSubCountyOVCChecklist.soc_action_points_implemented;

                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnMeetingsHeldYes, rbtnMeetingsHeldNo, prtSubCountyOVCChecklist.yn_id_meetings_held);
                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnMembershipConstitutedYes, rbtnMembershipConstitutedNo, prtSubCountyOVCChecklist.yn_id_membership_constituted);
                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnSupervisionReportsYes, rbtnSupervisionReportsNo, prtSubCountyOVCChecklist.yn_id_cdo_supervision);
                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnSOVCCMinutesYes, rbtnSOVCCMinutesNo, prtSubCountyOVCChecklist.yn_signed_minutes_available);
                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnSOVCCMinutesAvailableYes, rbtnSOVCCMinutesAvailableNo, prtSubCountyOVCChecklist.yn_id_sovcc_discussed_minutes_available);
                PSAUtilsWin32.utilControls.RadioButtonSetSelection(rbtnOVCMISSubcountyYes, rbtnOVCMISSubcountyNo, prtSubCountyOVCChecklist.yn_id_ovcmis_district);

                #region AccessControl
                btnSave.Enabled = (prtSubCountyOVCChecklist.ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, prtSubCountyOVCChecklist.ofc_id));
                btnCancel.Enabled = (prtSubCountyOVCChecklist.ofc_id.Equals(SystemConstants.ofc_id) || SystemConstants.Validate_Office_group_access(SystemConstants.ofc_id, prtSubCountyOVCChecklist.ofc_id));
                #endregion AccessControl
            }
        }
        #endregion Load Display

        #region Clear
        protected void Clear()
        {
            cbDistrict.SelectedValue = "-1";
            cbosubcounty.SelectedValue = "-1";
            cbQuarter.SelectedValue = "-1";
            cbFinancialYear.SelectedValue = "-1";
            dtpDate.Value = DateTime.Today;
            nudCSOTotal.Value = 0;
            nudCSOReport.Value = 0;
            nudActionPointsTotal.Value = 0;
            nudActionPointsImplemented.Value = 0;
            rbtnMeetingsHeldYes.Checked = false;
            rbtnMeetingsHeldNo.Checked = false;
            rbtnMembershipConstitutedYes.Checked = false;
            rbtnMembershipConstitutedNo.Checked = false;
            rbtnSupervisionReportsYes.Checked = false;
            rbtnSupervisionReportsNo.Checked = false;
            rbtnSOVCCMinutesYes.Checked = false;
            rbtnSOVCCMinutesNo.Checked = false;
            rbtnSOVCCMinutesAvailableYes.Checked = false;
            rbtnSOVCCMinutesAvailableNo.Checked = false;
            rbtnOVCMISSubcountyYes.Checked = false;
            rbtnOVCMISSubcountyNo.Checked = false;

            #region Clear Static Variables
            prtSubCountyOVCChecklist.soc_id = string.Empty;
            prtSubCountyOVCChecklist.dst_id = string.Empty;
            prtSubCountyOVCChecklist.qy_id = string.Empty;
            prtSubCountyOVCChecklist.fy_id = string.Empty;
            prtSubCountyOVCChecklist.soc_date = DateTime.Today;
            prtSubCountyOVCChecklist.soc_cso_report = 0;
            prtSubCountyOVCChecklist.soc_cso_total = 0;
            prtSubCountyOVCChecklist.soc_action_points_implemented = 0;
            prtSubCountyOVCChecklist.soc_action_points_total_identified = 0;

            prtSubCountyOVCChecklist.yn_id_meetings_held = string.Empty;
            prtSubCountyOVCChecklist.yn_id_membership_constituted = string.Empty;
            prtSubCountyOVCChecklist.yn_id_cdo_supervision = string.Empty;
            prtSubCountyOVCChecklist.yn_signed_minutes_available = string.Empty;
            prtSubCountyOVCChecklist.yn_id_sovcc_discussed_minutes_available = string.Empty;
            prtSubCountyOVCChecklist.yn_id_ovcmis_district = string.Empty;

            #endregion  Clear Static Variables
        }
        #endregion Clear

        private void cbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load SubCountys
            dt = benYouthTrainingInventory.Return_lookups("subcounty", cbDistrict.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cbosubcounty.DataSource = dt;
            cbosubcounty.DisplayMember = "sct_name";
            cbosubcounty.ValueMember = "sct_id";
            #endregion Load SubCountys
        }
    }
}
