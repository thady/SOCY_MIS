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
    public partial class frmHouseholdHomeVisit : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdHomeVisitMain frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHouseholdHomeVisitMain FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHouseholdHomeVisit()
        {
            InitializeComponent();
        }

        private void frmHouseholdHomeVisit_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadHousehold(HouseholdId);
            LoadDisplay();
        }

        private void frmHouseholdHomeVisit_Paint(object sender, PaintEventArgs e)
        {
            cbAverageMeals.SelectionLength = 0;
            cbHomeVisitHouseholdStatus.SelectionLength = 0;
            cbHomeVisitor.SelectionLength = 0;
            cbHomeVisitorTitle.SelectionLength = 0;
            cbHomeVisitReason.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ObjectId.Length == 0)
                Clear();
            else
                LoadDisplay();
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

        private void cbHomeVisitor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHomeVisitor.SelectedIndex != 0)
                LoadHomeVisitor(cbHomeVisitor.SelectedValue.ToString());
        }

        private void cbSocialWorker_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSocialWorker.SelectedIndex != 0)
                LoadHomeVisitor(cbSocialWorker.SelectedValue.ToString());
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.Back();
        }

        private void Clear()
        {
            #region Clear
            cbHHMember.SelectedIndex = 0;

            dtpDateOfVisit.Value = DateTime.Now;
            dtpNextVisitDate.Value = DateTime.Now;
            nudHouseholdIncome.Value = 0;

            txtComments.Text = string.Empty;
            txtHomeVisitorTel.Text = string.Empty;
            txtNextSteps.Text = string.Empty;
            txtSocialWorkerCode.Text = string.Empty;

            LoadLists();
            #endregion Clear
        }

        private void ClearHousehold()
        {
            try
            {
                #region Clear
                if (HouseholdId.Length == 0)
                {
                    #region Clear
                    lblDistrictDisplay.Text = string.Empty;
                    lblSubCountyDisplay.Text = string.Empty;
                    lblVillageDisplay.Text = string.Empty;
                    lblWard.Text = string.Empty;
                    cbHHMember.SelectedIndex = -1;
                    cbHHMember.Enabled = false;
                    #endregion Clear
                }
                else
                {
                    LoadHousehold(HouseholdId);
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearHousehold", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdHomeVisit dalHHV = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        Clear();
                    }
                    else
                    {
                        #region Visit
                        dalHHV = new hhHouseholdHomeVisit();
                        dalHHV.Load(ObjectId, dbCon);

                        cbHHMember.SelectedValue = dalHHV.hhm_id;
                        dtpDateOfVisit.Value = dalHHV.hhv_date;
                        dtpNextVisitDate.Value = dalHHV.hhv_date_next_visit;
                        nudHouseholdIncome.Value = dalHHV.hhv_household_income;
                        txtSocialWorkerCode.Text = dalHHV.hhv_swk_code;
                        txtComments.Text = dalHHV.hhv_comments;
                        txtNextSteps.Text = dalHHV.hhv_next_steps;
                        txtHomeVisitorTel.Text = dalHHV.hhv_visitor_tel;

                        //btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHHV.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHHV.ofc_id));
                        #endregion Visit

                        LoadLists(dalHHV.am_id,dalHHV.hvhs_id, dalHHV.hvr_id, dalHHV.swk_id, dalHHV.swk_id_visitor, dalHHV.hnr_id_visitor, dbCon);
                    }
                    #endregion Load Data
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadHomeVisitor(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHomeVisitor(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHomeVisitor(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            swmSocialWorker dalSwk = null;
            #endregion Vaiables

            #region Load Values
            if (cbHomeVisitor.SelectedIndex == 0)
                cbHomeVisitor.SelectedValue = strId;

            if (cbHomeVisitorTitle.SelectedIndex == 0 || txtHomeVisitorTel.Text.Trim().Length == 0)
            {
                dalSwk = new swmSocialWorker(strId, dbCon);
                if (cbHomeVisitorTitle.SelectedIndex == 0)
                    cbHomeVisitorTitle.SelectedValue = dalSwk.hnr_id;
                if (txtHomeVisitorTel.Text.Trim().Length == 0)
                    txtHomeVisitorTel.Text = dalSwk.swk_phone;
            }
            #endregion Load Values
        }

        private void LoadHousehold(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHousehold(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHousehold(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHousehold dalHH = null;
            hhHouseholdMember dalHHM = null;
            utilLanguageTranslation utilLT = null;

            DataTable dt = null;
            string strEmptySingleSelect = string.Empty;
            #endregion Variables

            try
            {
                #region Household
                dalHH = new hhHousehold();
                if (strId.Length != 0)
                {
                    dt = dalHH.GetHousehold(strId, FormMaster.LanguageId, dbCon);
                    if (utilCollections.HasRows(dt))
                    {
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                        lblSubCountyDisplay.Text = dt.Rows[0]["sct_name"].ToString();
                        lblVillageDisplay.Text =  dt.Rows[0]["hh_village"].ToString().ToUpper();
                        lblWardDisplay.Text = dt.Rows[0]["wrd_name"].ToString();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                        dalHHM = new hhHouseholdMember();
                        dt = dalHHM.GetList(strId, dbCon);
                        dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                        utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                    }
                    else
                    {
                        ClearHousehold();
                    }
                }
                else
                {
                    ClearHousehold();
                }
                #endregion Household
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHousehold", exc);
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
                LoadLists("", "", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strAmID, string strHvhsID, string strHvrID, string strSwkID, string strSwkIDVisitor, string strHnrIDVisitor, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                hhHousehold dalHh = null;
                swmSocialWorker dalSwk = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                pblnLoading = true;
                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_average_meals", true, strAmID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbAverageMeals, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_home_visit_household_status", true, strHvhsID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitHouseholdStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_home_visit_reason", true, strHvrID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitReason, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_honorific", true, strHnrIDVisitor, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitorTitle, dt, "lt_id", "lt_name");

                #region Social Worker
                dalHh = new hhHousehold(HouseholdId, dbCon);

                if (strSwkID.Length == 0 || strSwkID.Equals(utilConstants.cDFEmptyListValue))
                    strSwkID = dalHh.swk_id;

                dalSwk = new swmSocialWorker();
                if (strSwkID.Length == 0)
                    dt = dalSwk.GetList("", "", dalHh.dst_id, dbCon);
                else
                    dt = dalSwk.GetList(strSwkID, "", dalHh.dst_id, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");

                if (strSwkIDVisitor.Length == 0)
                    strSwkIDVisitor = strSwkID;

                if (strSwkIDVisitor.Length == 0)
                    dt = dalSwk.GetList("", "", dalHh.dst_id, dbCon);
                else
                    dt = dalSwk.GetList(strSwkIDVisitor, "", dalHh.dst_id, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitor, dt, "swk_id", "swk_name");
                #endregion Social Worker
                #endregion Load Lists

                #region Set List Selection
                if (strAmID.Length != 0)
                    cbAverageMeals.SelectedValue = strAmID;
                else
                    cbAverageMeals.SelectedIndex = 0;
                if (strHvhsID.Length != 0)
                    cbHomeVisitHouseholdStatus.SelectedValue = strHvhsID;
                else
                    cbHomeVisitHouseholdStatus.SelectedIndex = 0;
                if (strHvrID.Length != 0)
                    cbHomeVisitReason.SelectedValue = strHvrID;
                else
                    cbHomeVisitReason.SelectedIndex = 0;
                if (strHnrIDVisitor.Length != 0)
                    cbHomeVisitorTitle.SelectedValue = strHnrIDVisitor;
                else
                    cbHomeVisitorTitle.SelectedIndex = 0;

                if (strSwkID.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkID;
                else
                    cbSocialWorker.SelectedIndex = 0;
                if (strSwkIDVisitor.Length != 0)
                    cbHomeVisitor.SelectedValue = strSwkIDVisitor;
                else
                    cbHomeVisitor.SelectedIndex = 0;
                #endregion Set List Selection
                pblnLoading = false;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhHouseholdHomeVisit dalHHV = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Home Visit
                        dalHHV = new hhHouseholdHomeVisit();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalHHV.hhv_id = ObjectId;
                            dalHHV.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHHV.Load(ObjectId, dbCon);

                        dalHHV.hhv_date = dtpDateOfVisit.Value;
                        dalHHV.hhv_date_next_visit = dtpNextVisitDate.Value;
                        dalHHV.hhv_household_income = Convert.ToInt32(nudHouseholdIncome.Value);
                        dalHHV.hhv_comments = txtComments.Text.Trim();
                        dalHHV.hhv_next_steps = txtNextSteps.Text.Trim();
                        dalHHV.hhv_swk_code = txtSocialWorkerCode.Text.Trim();
                        dalHHV.hhv_visitor_tel = txtHomeVisitorTel.Text.Trim();
                        dalHHV.am_id = cbAverageMeals.SelectedValue.ToString();
                        dalHHV.hvhs_id = cbHomeVisitHouseholdStatus.SelectedValue.ToString();
                        dalHHV.hvr_id = cbHomeVisitReason.SelectedValue.ToString();
                        dalHHV.hh_id = HouseholdId;
                        dalHHV.hhm_id = cbHHMember.SelectedValue.ToString();
                        dalHHV.hnr_id_visitor = cbHomeVisitorTitle.SelectedValue.ToString();
                        dalHHV.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalHHV.swk_id_visitor = cbHomeVisitor.SelectedValue.ToString();
                        dalHHV.usr_id_update = FormMaster.UserId;

                        dalHHV.Save(dbCon, cbHomeVisitHouseholdStatus.SelectedValue.ToString(), HouseholdId);

                        if (FormCalling.ObjectId.Length == 0)
                        {
                            FormCalling.ObjectId = ObjectId;
                            FormCalling.MembersTab(true);
                        }
                        #endregion Home Visit

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                //FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
                throw (exc);
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
            if (cbHHMember.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else if (cbSocialWorker.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else if (cbHomeVisitReason.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else if (cbHomeVisitHouseholdStatus.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else if (cbHomeVisitor.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else if (dtpDateOfVisit.Value.Date >= DateTime.Today)
                strMessage = "Home Visit date cannot be greater or equal to current date";
            #endregion Required Fields

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormMaster.LanguageId;
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHomeVisits, dbCon);
                btnSave.Visible = pblnManage;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
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
