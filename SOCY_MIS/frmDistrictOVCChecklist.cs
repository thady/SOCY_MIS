using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDistrictOVCChecklist : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDistrictOVCChecklistSearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        #endregion Variables

        #region Property
        public frmDistrictOVCChecklistSearch FormCalling
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

        #region Form Methods
        public frmDistrictOVCChecklist()
        {
            InitializeComponent();
        }

        private void frmDistrictOVCChecklist_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmDistrictOVCChecklist_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        #region Display Controls
        private void lblSubCountyPercentDisplay_TextChanged(object sender, EventArgs e)
        {
            DisplayQn10();
        }

        private void nudCSOReport_ValueChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void nudCSOTotal_ValueChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void nudlSubCountyReviewed_ValueChanged(object sender, EventArgs e)
        {
            DisplayQn09();
        }

        private void nudSubCountyTotal_ValueChanged(object sender, EventArgs e)
        {
            DisplayQn09();
        }

        private void rbtnDOVCCActionsTakenYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void rbtnDOVCCMinutesAvailableYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void rbtnDOVCCMinutesYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn10();
        }

        private void rbtnMeetingsHeldYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn10();
        }

        private void rbtnMembershipConstitutedYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn10();
        }

        private void rbtnOVCMISDistrictYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void rbtnQn11No_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void rbtnQn11Yes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn12();
        }

        private void rbtnSupervisionReportsYes_CheckedChanged(object sender, EventArgs e)
        {
            DisplayQn10();
        }
        #endregion Display Controls
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbDistrict.SelectedIndex = 0;
                    cbFinancialYear.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;

                    nudCSOReport.Value = 0;
                    nudCSOTotal.Value = 0;
                    nudSubCountyReviewed.Value = 0;
                    nudSubCountyTotal.Value = 0;

                    rbtnDOVCCActionsTakenNo.Checked = false;
                    rbtnDOVCCActionsTakenYes.Checked = false;
                    rbtnDOVCCMinutesAvailableNo.Checked = false;
                    rbtnDOVCCMinutesAvailableYes.Checked = false;
                    rbtnDOVCCMinutesNo.Checked = false;
                    rbtnDOVCCMinutesYes.Checked = false;
                    rbtnMeetingsHeldNo.Checked = false;
                    rbtnMeetingsHeldYes.Checked = false;
                    rbtnMembershipConstitutedNo.Checked = false;
                    rbtnMembershipConstitutedYes.Checked = false;
                    rbtnOVCMISDistrictNo.Checked = false;
                    rbtnOVCMISDistrictYes.Checked = false;
                    rbtnSupervisionReportsNo.Checked = false;
                    rbtnSupervisionReportsYes.Checked = false;
                    #endregion Clear
                }
                else
                {
                    LoadDisplay();
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                prtDistrictOVCChecklist dalDOC = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalDOC = new prtDistrictOVCChecklist(ObjectId, dbCon);
                        dtpDate.Value = dalDOC.doc_date;

                        nudCSOReport.Value = dalDOC.doc_cso_report;
                        nudCSOTotal.Value = dalDOC.doc_cso_total;
                        nudSubCountyReviewed.Value = dalDOC.doc_sub_county_reviewed;
                        nudSubCountyTotal.Value = dalDOC.doc_sub_county_total;

                        utilControls.RadioButtonSetSelection(rbtnDOVCCActionsTakenYes, rbtnDOVCCActionsTakenNo, dalDOC.yn_id_dovcc_actions_taken);
                        utilControls.RadioButtonSetSelection(rbtnDOVCCMinutesAvailableYes, rbtnDOVCCMinutesAvailableNo, dalDOC.yn_id_dovcc_minutes_available);
                        utilControls.RadioButtonSetSelection(rbtnDOVCCMinutesYes, rbtnDOVCCMinutesNo, dalDOC.yn_id_dovcc_minutes);
                        utilControls.RadioButtonSetSelection(rbtnMeetingsHeldYes, rbtnMeetingsHeldNo, dalDOC.yn_id_meetings_held);
                        utilControls.RadioButtonSetSelection(rbtnMembershipConstitutedYes, rbtnMembershipConstitutedNo, dalDOC.yn_id_membership_constituted);
                        utilControls.RadioButtonSetSelection(rbtnOVCMISDistrictYes, rbtnOVCMISDistrictNo, dalDOC.yn_id_ovcmis_district);
                        utilControls.RadioButtonSetSelection(rbtnSupervisionReportsYes, rbtnSupervisionReportsNo, dalDOC.yn_id_supervision_reports);

                        LoadLists(dalDOC.dst_id, dalDOC.fy_id, dalDOC.qy_id, dbCon);
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalDOC.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalDOC.ofc_id));
                        #endregion Load Display
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strDstId, string strFyId, string strQyId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_district", true, strDstId, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                prtDistrictOVCChecklist dalDOC = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDOC = new prtDistrictOVCChecklist();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalDOC.doc_id = ObjectId;
                            dalDOC.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalDOC.Load(ObjectId, dbCon);

                        dalDOC.doc_date = dtpDate.Value;
                        dalDOC.dst_id = cbDistrict.SelectedValue.ToString();
                        dalDOC.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalDOC.qy_id = cbQuarter.SelectedValue.ToString();
                        dalDOC.usr_id_update = FormParent.FormMaster.UserId;

                        dalDOC.doc_cso_report = Convert.ToInt32(nudCSOReport.Value);
                        dalDOC.doc_cso_total = Convert.ToInt32(nudCSOTotal.Value);
                        dalDOC.doc_sub_county_reviewed = Convert.ToInt32(nudSubCountyReviewed.Value);
                        dalDOC.doc_sub_county_total = Convert.ToInt32(nudSubCountyTotal.Value);

                        dalDOC.yn_id_dovcc_actions_taken = utilControls.RadioButtonGetSelection(rbtnDOVCCActionsTakenYes, rbtnDOVCCActionsTakenNo);
                        dalDOC.yn_id_dovcc_minutes_available = utilControls.RadioButtonGetSelection(rbtnDOVCCMinutesAvailableYes, rbtnDOVCCMinutesAvailableNo);
                        dalDOC.yn_id_dovcc_minutes = utilControls.RadioButtonGetSelection(rbtnDOVCCMinutesYes, rbtnDOVCCMinutesNo);
                        dalDOC.yn_id_meetings_held = utilControls.RadioButtonGetSelection(rbtnMeetingsHeldYes, rbtnMeetingsHeldNo);
                        dalDOC.yn_id_membership_constituted = utilControls.RadioButtonGetSelection(rbtnMembershipConstitutedYes, rbtnMembershipConstitutedNo);
                        dalDOC.yn_id_ovcmis_district = utilControls.RadioButtonGetSelection(rbtnOVCMISDistrictYes, rbtnOVCMISDistrictNo);
                        dalDOC.yn_id_supervision_reports = utilControls.RadioButtonGetSelection(rbtnSupervisionReportsYes, rbtnSupervisionReportsNo);

                        dalDOC.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbDistrict.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 || cbQuarter.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Number Validation
            if (nudCSOReport.Value > nudCSOTotal.Value)
                strMessage = strMessage + "," + utilConstants.cMIDValidateCSOOutOf;
            if (nudSubCountyReviewed.Value > nudSubCountyTotal.Value)
                strMessage = strMessage + "," + utilConstants.cMIDValidateMinutesReviewed;
            #endregion Number Validation

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormParent.FormMaster.LanguageId;
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            #endregion Get Messages

            return strMessage;
        }

        #region Display Settings
        private void DisplayQn09()
        {
            if (nudSubCountyTotal.Value > 0)
                lblSubCountyPercentDisplay.Text = Convert.ToInt32(nudSubCountyReviewed.Value * 100 / nudSubCountyTotal.Value).ToString();
            else
                lblSubCountyPercentDisplay.Text = "-";
        }

        private void DisplayQn10()
        {
            if (rbtnDOVCCMinutesYes.Checked && rbtnMeetingsHeldYes.Checked && rbtnMembershipConstitutedYes.Checked && rbtnSupervisionReportsYes.Checked &&
                utilFormatting.IsDecimal(lblSubCountyPercentDisplay.Text) && Convert.ToDecimal(lblSubCountyPercentDisplay.Text.Trim()) >= 80)
            {
                rbtnQn10No.Checked = false;
                rbtnQn10Yes.Checked = true;
                rbtnQn11No.Checked = false;
                rbtnQn11Yes.Checked = true;
            }
            else
            {
                rbtnQn10No.Checked = true;
                rbtnQn10Yes.Checked = false;
                rbtnQn11No.Checked = true;
                rbtnQn11Yes.Checked = false;
            }
        }

        private void DisplayQn12()
        {
            if (rbtnDOVCCActionsTakenYes.Checked && rbtnDOVCCMinutesAvailableYes.Checked && rbtnOVCMISDistrictYes.Checked && rbtnQn11Yes.Checked &&
                nudCSOTotal.Value > 0 && (nudCSOReport.Value * 100 / nudCSOTotal.Value) >= 80)
            {
                rbtnQn12No.Checked = false;
                rbtnQn12Yes.Checked = true;
            }
            else
            {
                rbtnQn12No.Checked = true;
                rbtnQn12Yes.Checked = false;
            }
        }
        #endregion Display Settings
        #endregion Private Methods

        #region Permissions
        private void SetPermissions()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            umUser dalUsr = new umUser();
            #endregion Variables

            #region Set Permissions
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageDistrictOVCCoordinationOVCDataUsageChecklist, dbCon);
                btnSave.Visible = pblnManage;
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Set Permissions
        }
        #endregion Permissions
    }
}