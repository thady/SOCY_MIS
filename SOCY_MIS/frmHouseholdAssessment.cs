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
    public partial class frmHouseholdAssessment : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdAssessmentMain frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHouseholdAssessmentMain FormCalling
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
        public frmHouseholdAssessment()
        {
            InitializeComponent();
        }

        private void frmHouseholdAssessment_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmHouseholdAssessment_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbIncomeContributor.SelectionLength = 0;
            cbIncomeSource.SelectionLength = 0;
            cbHouseholdMember.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
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

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", "", "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
            }
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
            }
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                    LoadListsArea("", "", cbWard.SelectedValue.ToString());
            }
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
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbDistrict.SelectedIndex = 0;
                    cbIncomeContributor.SelectedIndex = 0;
                    cbIncomeSource.SelectedIndex = 0;
                    cbHouseholdMember.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbWard.SelectedIndex = 0;

                    dtpDateOfInterview.Value = DateTime.Now;

                    nudNumOfMeals.Value = 0;

                    rbtnChildSeparationNo.Checked = false;
                    rbtnChildSeparationYes.Checked = false;
                    rbtnDisagreementNever.Checked = false;
                    rbtnDisagreementOften.Checked = false;
                    rbtnDisagreementSometimes.Checked = false;
                    rbtnExpensesFoodNo.Checked = false;
                    rbtnExpensesFoodNotAlways.Checked = false;
                    rbtnExpensesFoodYes.Checked = false;
                    rbtnExpensesHealthNo.Checked = false;
                    rbtnExpensesHealthNotAlways.Checked = false;
                    rbtnExpensesHealthYes.Checked = false;
                    rbtnExpensesSchoolNo.Checked = false;
                    rbtnExpensesSchoolNotAlways.Checked = false;
                    rbtnExpensesSchoolYes.Checked = false;
                    rbtnFinancialSavingsNo.Checked = false;
                    rbtnFinancialSavingsYes.Checked = false;
                    rbtnFoodBodyBuildingNo.Checked = false;
                    rbtnFoodBodyBuildingYes.Checked = false;
                    rbtnFoodEnergyNo.Checked = false;
                    rbtnFoodEnergyYes.Checked = false;
                    rbtnFoodProtectiveNo.Checked = false;
                    rbtnFoodProtectiveYes.Checked = false;
                    rbtnLatrineAccessNo.Checked = false;
                    rbtnLatrineAccessOwned.Checked = false;
                    rbtnLatrineAccessShared.Checked = false;
                    rbtnAssetsMost.Checked = false;
                    rbtnAssetsNone.Checked = false;
                    rbtnAssetsSome.Checked = false;
                    rbtnWaterAccessNo.Checked = false;
                    rbtnWaterAccessYes.Checked = false;

                    txtComments.Text = "";
                    txtHoueholdCode.Text = "";
                    txtVillage.Text = "";
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHousehold dalHH = null;
                hhHouseholdMember dalHHM = null;
                hhHouseholdAssessment dalHHA = null;

                DataTable dt = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Household
                    dalHH = new hhHousehold();
                    if (HouseholdId.Length != 0)
                    {
                        dalHH.Load(HouseholdId, dbCon);
                        txtHoueholdCode.Text = dalHH.hh_code;
                        txtVillage.Text = dalHH.hh_village;
                        SetHouseholdControls(false);

                        dalHHM = new hhHouseholdMember();
                        dt = dalHHM.GetList(HouseholdId, dbCon);
                        utilControls.ComboBoxFill(cbHouseholdMember, dt, "hhm_id", "hhm_name");
                        cbHouseholdMember.SelectedValue = dalHHM.GetMemberPrime(HouseholdId, dbCon);
                    }
                    else
                    {
                        SetHouseholdControls(true);
                    }
                    #endregion Household

                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        LoadLists("", "", dalHH.swk_id, dalHH.wrd_id, dbCon);
                    }
                    else
                    {
                        #region Assessment
                        dalHHA = new hhHouseholdAssessment();

                        if (ObjectId.Length != 0)
                        {
                            dalHHA.Load(ObjectId, dbCon);
                            txtComments.Text = dalHHA.hha_comments;
                            dtpDateOfInterview.Value = dalHHA.hha_date;
                            cbHouseholdMember.SelectedValue = dalHHA.hhm_id;
                            nudNumOfMeals.Value = dalHHA.hha_num_of_meals;

                            utilControls.RadioButtonSetSelection(rbtnDisagreementOften, rbtnDisagreementNever, rbtnDisagreementSometimes, dalHHA.osn_id_disagreement);
                            utilControls.RadioButtonSetSelection(rbtnChildSeparationYes, rbtnChildSeparationNo, dalHHA.yn_id_child_separation);
                            utilControls.RadioButtonSetSelection(rbtnFinancialSavingsYes, rbtnFinancialSavingsNo, dalHHA.yn_id_financial_savings);
                            utilControls.RadioButtonSetSelection(rbtnFoodBodyBuildingYes, rbtnFoodBodyBuildingNo, dalHHA.yn_id_food_body_building);
                            utilControls.RadioButtonSetSelection(rbtnFoodEnergyYes, rbtnFoodEnergyNo, dalHHA.yn_id_food_energy);
                            utilControls.RadioButtonSetSelection(rbtnFoodProtectiveYes, rbtnFoodProtectiveNo, dalHHA.yn_id_food_protective);
                            utilControls.RadioButtonSetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo, dalHHA.yn_id_water);
                            utilControls.RadioButtonSetSelection(rbtnExpensesFoodYes, rbtnExpensesFoodNo, rbtnExpensesFoodNotAlways, dalHHA.ynna_id_expenses_food);
                            utilControls.RadioButtonSetSelection(rbtnExpensesHealthYes, rbtnExpensesHealthNo, rbtnExpensesHealthNotAlways, dalHHA.ynna_id_expenses_health);
                            utilControls.RadioButtonSetSelection(rbtnExpensesSchoolYes, rbtnExpensesSchoolNo, rbtnExpensesSchoolNotAlways, dalHHA.ynna_id_expenses_school);
                            utilControls.RadioButtonSetSelection(rbtnAssetsMost, rbtnAssetsNone, rbtnAssetsSome, dalHHA.ynns_id_assets);
                            utilControls.RadioButtonSetSelection(rbtnLatrineAccessOwned, rbtnLatrineAccessNo, rbtnLatrineAccessShared, dalHHA.yns_id_latrine);
                            btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHHA.ofc_id) || utilConstants.cDFImportOffice.Equals(dalHHA.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHHA.ofc_id));
                        }
                        #endregion Assessment

                        LoadLists(dalHHA.icc_id, dalHHA.ics_id, dalHH.swk_id, dalHH.wrd_id, dbCon);
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

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strIccId, string strIcsId, string strSwkId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                swmSocialWorker dalSwk = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_income_contributor", true, strIccId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbIncomeContributor, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_income_source", true, strIcsId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbIncomeSource, dt, "lt_id", "lt_name");

                dalSwk = new swmSocialWorker();
                if (ObjectId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strIccId.Length != 0)
                    cbIncomeContributor.SelectedValue = strIccId;
                else
                    cbIncomeContributor.SelectedIndex = 0;
                if (strIcsId.Length != 0)
                    cbIncomeSource.SelectedValue = strIcsId;
                else
                    cbIncomeSource.SelectedIndex = 0;
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", "", strWrdId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strDstId, string strSctId, string strWrdId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strDstId, strSctId, strWrdId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbDistrict, cbSubCounty, cbWard, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHH = null;
                hhHouseholdAssessment dalHHA = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        #region Household
                        if (HouseholdId.Length == 0)
                        {
                            dalHH = new hhHousehold();
                            HouseholdId = Guid.NewGuid().ToString();
                            dalHH.hh_id = HouseholdId;

                            dalHH.hh_code = txtHoueholdCode.Text.Trim();
                            dalHH.hh_village = txtVillage.Text.Trim();
                            dalHH.hhs_id = utilConstants.cDFActive.ToString();
                            dalHH.swk_id = cbSocialWorker.SelectedValue.ToString();
                            
                            dalHH.wrd_id = cbWard.SelectedValue.ToString();
                            dalHH.usr_id_update = FormMaster.UserId;
                            dalHH.ofc_id = FormMaster.OfficeId;
                            dalHH.Save(dbCon);
                        }
                        #endregion Household

                        #region Household Assessment
                        dalHHA = new hhHouseholdAssessment();

                        if (ObjectId.Length == 0)
                        {
                            if (FormCalling.ObjectId.Length != 0)
                                ObjectId = FormCalling.ObjectId;
                            else
                                ObjectId = Guid.NewGuid().ToString();
                            dalHHA.hha_id = ObjectId;
                            dalHHA.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHHA.Load(ObjectId, dbCon);

                        dalHHA.hha_comments = txtComments.Text.Trim();
                        dalHHA.hha_date = dtpDateOfInterview.Value;
                        dalHHA.hha_num_of_meals = Convert.ToInt32(nudNumOfMeals.Value);
                        dalHHA.hh_id = HouseholdId;
                        dalHHA.hhm_id = cbHouseholdMember.SelectedValue.ToString();
                        dalHHA.icc_id = cbIncomeContributor.SelectedValue.ToString();
                        dalHHA.ics_id = cbIncomeSource.SelectedValue.ToString();
                        dalHHA.osn_id_disagreement = utilControls.RadioButtonGetSelection(rbtnDisagreementOften, rbtnDisagreementNever, rbtnDisagreementSometimes);
                        dalHHA.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalHHA.yn_id_child_separation = utilControls.RadioButtonGetSelection(rbtnChildSeparationYes, rbtnChildSeparationNo);
                        dalHHA.yn_id_financial_savings = utilControls.RadioButtonGetSelection(rbtnFinancialSavingsYes, rbtnFinancialSavingsNo);
                        dalHHA.yn_id_food_body_building = utilControls.RadioButtonGetSelection(rbtnFoodBodyBuildingYes, rbtnFoodBodyBuildingNo);
                        dalHHA.yn_id_food_energy = utilControls.RadioButtonGetSelection(rbtnFoodEnergyYes, rbtnFoodEnergyNo);
                        dalHHA.yn_id_food_protective = utilControls.RadioButtonGetSelection(rbtnFoodProtectiveYes, rbtnFoodProtectiveNo);
                        dalHHA.yn_id_water = utilControls.RadioButtonGetSelection(rbtnWaterAccessYes, rbtnWaterAccessNo);
                        dalHHA.ynna_id_expenses_food = utilControls.RadioButtonGetSelection(rbtnExpensesFoodYes, rbtnExpensesFoodNo, rbtnExpensesFoodNotAlways);
                        dalHHA.ynna_id_expenses_health = utilControls.RadioButtonGetSelection(rbtnExpensesHealthYes, rbtnExpensesHealthNo, rbtnExpensesHealthNotAlways);
                        dalHHA.ynna_id_expenses_school = utilControls.RadioButtonGetSelection(rbtnExpensesSchoolYes, rbtnExpensesSchoolNo, rbtnExpensesSchoolNotAlways);
                        dalHHA.ynns_id_assets = utilControls.RadioButtonGetSelection(rbtnAssetsMost, rbtnAssetsNone, rbtnAssetsSome);
                        dalHHA.yns_id_latrine = utilControls.RadioButtonGetSelection(rbtnLatrineAccessOwned, rbtnLatrineAccessNo, rbtnLatrineAccessShared);
                        dalHHA.usr_id_update = FormMaster.UserId;
                        dalHHA.district_id = static_variables.district_id;

                        dalHHA.Save(dbCon);
                        #endregion Household Assessment

                        dbCon.TransactionCommit();

                        if (FormCalling.ObjectId.Length == 0)
                        {
                            FormCalling.ObjectId = ObjectId;
                            FormCalling.MembersTab(true);
                        }

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetHouseholdControls(false);
                    }
                    catch (Exception exc)
                    {
                        dbCon.TransactionRollback();
                        throw exc;
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SetHouseholdControls(bool blnEnabled)
        {
            #region Set Controls
            cbDistrict.Enabled = blnEnabled;
            cbSubCounty.Enabled = blnEnabled;
            cbWard.Enabled = blnEnabled;
            txtHoueholdCode.Enabled = blnEnabled;
            txtVillage.Enabled = blnEnabled;
            #endregion Set Controls
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
            if (txtHoueholdCode.Text.Trim().Length == 0 || txtVillage.Text.Trim().Length == 0 ||
                cbDistrict.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0 || cbWard.SelectedIndex == 0 ||
                cbHouseholdMember.SelectedIndex == -1)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHouseholdAssessment, dbCon);
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
