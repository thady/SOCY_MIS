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
    public partial class frmServiceRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmServiceRegisterSearch frmCll = null;
        private frmResultArea01 frmPrt01 = null;
        private frmResultArea03 frmPrt03 = null;
        private frmSILC frmPrtSILC = null;
        #endregion Variables

        #region Property
        public frmServiceRegisterSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmResultArea01 FormParent01
        {
            get { return frmPrt01; }
            set { frmPrt01 = value; }
        }

        public frmResultArea03 FormParent03
        {
            get { return frmPrt03; }
            set { frmPrt03 = value; }
        }

        public frmSILC FormParentSILC
        {
            get { return frmPrtSILC; }
            set { frmPrtSILC = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmServiceRegister()
        {
            InitializeComponent();
        }

        private void frmServiceRegister_Load(object sender, EventArgs e)
        {
            if (FormCalling.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormCalling.FormMaster.NoDatabase;
                btnSave.Enabled = !FormCalling.FormMaster.NoDatabase;
                btnServiceCancel.Enabled = !FormCalling.FormMaster.NoDatabase;
                btnServiceDelete.Enabled = !FormCalling.FormMaster.NoDatabase;
                btnServiceSave.Enabled = !FormCalling.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmServiceRegister_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
            cbRegion.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
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

        private void btnServiceCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnServiceDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnServiceSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                SaveLine();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", cbCSO.SelectedValue.ToString());
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsArea("", cbDistrict.SelectedValue.ToString(), "", false);
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsHousehold(cbSubCounty.SelectedValue.ToString());
        }

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
            {
                ClearMember(false);
            }
            else
            {
                LoadListsMember(cbHHCode.SelectedValue.ToString(), "");
                ClearMember(true);
            }
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedIndex == 0)
                ClearMember(true);
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void cbPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", "");
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), "");
        }

        private void cbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbRegion.SelectedIndex == 0)
                LoadListsArea("", "", "", false);
            else
                LoadListsArea("", "", cbRegion.SelectedValue.ToString(), false);
        }

        private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvServices.SelectedCells.Count != 0)
                {
                    strID = dgvServices.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvServices_CellDoubleClick", exc);
            }
        }

        private void dgvServices_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvServices.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormCalling.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvServices.Rows[e.RowIndex].Cells["gclDelete"];
                    chkDel = clDel as DataGridViewCheckBoxCell;
                    chkDel.Value = false;
                    chkDel.FlatStyle = FlatStyle.Flat;
                    chkDel.Style.ForeColor = Color.DarkGray;
                    clDel.ReadOnly = true;
                }
                #endregion
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvServices_RowPostPaint", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnEcoStrengthOtherYes_CheckedChanged(object sender, EventArgs e)
        {
            txtEcoStrengthOther.Enabled = rbtnEcoStrengthOtherYes.Checked;
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();

            if (FormParent01 != null)
                FormParent01.LoadControl(FormCalling, this.Name);
            else if (FormParent03 != null)
                FormParent03.LoadControl(FormCalling, this.Name);
            else if (FormParentSILC != null)
                FormParentSILC.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbCSO.SelectedIndex = 0;
                    cbDistrict.SelectedIndex = 0;
                    cbFinancialYear.SelectedIndex = 0;
                    cbPartner.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    cbRegion.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;

                    txtContactInfo.Text = string.Empty;
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
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblSvrlId.Text = string.Empty;

                cbHHCode.SelectedIndex = 0;

                txtEcoStrengthOther.Text = string.Empty;

                rbtnAgricaltureAdvisoryNo.Checked = false;
                rbtnAgricaltureAdvisoryYes.Checked = false;
                rbtnApprenticeSkillsNo.Checked = false;
                rbtnApprenticeSkillsYes.Checked = false;
                rbtnBasicCareNo.Checked = false;
                rbtnBasicCareYes.Checked = false;
                rbtnBirthRegistrationNo.Checked = false;
                rbtnBirthRegistrationYes.Checked = false;
                rbtnCaseHandledNo.Checked = false;
                rbtnCaseHandledYes.Checked = false;
                rbtnEcoStrengthOtherNo.Checked = false;
                rbtnEcoStrengthOtherYes.Checked = false;
                rbtnNewlyEnrolledNo.Checked = false;
                rbtnNewlyEnrolledYes.Checked = false;
                rbtnParentingNo.Checked = false;
                rbtnParentingYes.Checked = false;
                rbtnPsychSupportNo.Checked = false;
                rbtnPsychSupportYes.Checked = false;
                rbtnReintegratedNo.Checked = false;
                rbtnReintegratedYes.Checked = false;
                rbtnSILCInterventionNo.Checked = false;
                rbtnSILCInterventionYes.Checked = false;
                btnServiceSave.Enabled = pblnManage;

                LoadListsLine();
                ClearMember(false);
                #endregion Clear Line
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void ClearMember(bool blnEnabled)
        {
            try
            {
                #region Clear Member
                cbHHMember.Enabled = blnEnabled;
                if (cbHHMember.Items.Count == 0)
                    cbHHMember.SelectedIndex = -1;
                else
                    cbHHMember.SelectedIndex = 0;
                lblGenderDisplay.Text = "-";
                lblHIVStatusDisplay.Text = "-";
                lblSubCountyDisplay.Text = "-";
                lblVillageDisplay.Text = "-";
                lblWardDisplay.Text = "-";
                lblYearOfBirthDisplay.Text = "-";
                #endregion Clear Member
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearMember", exc);
            }
        }

        private void DeleteLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benServiceRegisterLine dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvServices.RowCount != 0)
                {
                    while (intCounter < dgvServices.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvServices.Rows[intCounter].Cells["gclDelete"].Value))
                            blnFound = true;
                        intCounter++;
                    }

                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormCalling.FormMaster.LanguageId;

                        if (blnFound)
                        {
                            strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDDeleteRecordsConformation, dbCon.dbCon);
                            strTitle = utilLT.GetMessageTranslation(utilConstants.cMIDDeleteConformation, dbCon.dbCon);
                            dlrResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo);

                            if (dlrResult == DialogResult.Yes)
                            {
                                try
                                {
                                    dbCon.TransactionBegin();
                                    dalDel = new benServiceRegisterLine();
                                    for (int intCount = 0; intCount < dgvServices.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvServices.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvServices.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    ClearLine();
                                    LoadDisplayLines(dbCon);
                                }
                                catch (Exception exc)
                                {
                                    dbCon.TransactionRollback();
                                    throw exc;
                                }
                            }
                        }
                        else
                        {
                            strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDDeleteCheckRecords, dbCon.dbCon);
                            strTitle = utilLT.GetMessageTranslation(utilConstants.cMIDDeleteCancelled, dbCon.dbCon);
                            FormCalling.FormMaster.ShowMessage(utilConstants.cPTWarning, strMessage);
                        }
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benServiceRegister dalSR = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadLists();
                    SetLineControls(false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalSR = new benServiceRegister(ObjectId, dbCon);
                        txtContactInfo.Text = dalSR.svr_contact_details;
                        btnSave.Enabled = pblnManage && (FormCalling.FormMaster.OfficeId.Equals(dalSR.ofc_id) || SystemConstants.Validate_Office_group_access(FormCalling.FormMaster.OfficeId, dalSR.ofc_id));
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalSR.cso_id, dalSR.dst_id, dalSR.fy_id, dalSR.qy_id, dalSR.swk_id, dbCon);
                        LoadListsHousehold("-1");
                        SetLineControls(true);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayLine(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLine(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLine(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                benServiceRegisterLine dalSRL = null;
                #endregion Variables

                #region Load Display Line
                dalSRL = new benServiceRegisterLine(strId, dbCon);
                cbHHMember.SelectedValue = dalSRL.hhm_id;
                LoadDisplayMember(dalSRL.hhm_id, dbCon);

                lblSvrlId.Text = strId;
                txtEcoStrengthOther.Text = dalSRL.svrl_eco_strength_other;
                utilControls.RadioButtonSetSelection(rbtnAgricaltureAdvisoryYes, rbtnAgricaltureAdvisoryNo, dalSRL.yn_id_agricalture_advisory);
                utilControls.RadioButtonSetSelection(rbtnApprenticeSkillsYes, rbtnApprenticeSkillsNo, dalSRL.yn_id_apprentice_skills);
                utilControls.RadioButtonSetSelection(rbtnBasicCareYes, rbtnBasicCareNo, dalSRL.yn_id_basic_care);
                utilControls.RadioButtonSetSelection(rbtnBirthRegistrationYes, rbtnBirthRegistrationNo, dalSRL.yn_id_birth_registration);
                utilControls.RadioButtonSetSelection(rbtnCaseHandledYes, rbtnCaseHandledNo, dalSRL.yn_id_case_handled);
                utilControls.RadioButtonSetSelection(rbtnEcoStrengthOtherYes, rbtnEcoStrengthOtherNo, dalSRL.yn_id_eco_strength_other);
                utilControls.RadioButtonSetSelection(rbtnNewlyEnrolledYes, rbtnNewlyEnrolledNo, dalSRL.yn_id_newly_enrolled);
                utilControls.RadioButtonSetSelection(rbtnParentingYes, rbtnParentingNo, dalSRL.yn_id_parenting);
                utilControls.RadioButtonSetSelection(rbtnPsychSupportYes, rbtnPsychSupportNo, dalSRL.yn_id_psych_support);
                utilControls.RadioButtonSetSelection(rbtnReintegratedYes, rbtnReintegratedNo, dalSRL.yn_id_reintegrated);
                utilControls.RadioButtonSetSelection(rbtnSILCInterventionYes, rbtnSILCInterventionNo, dalSRL.yn_id_silc_intervention);

                btnServiceSave.Enabled = pblnManage && (FormCalling.FormMaster.OfficeId.Equals(dalSRL.ofc_id) || SystemConstants.Validate_Office_group_access(FormCalling.FormMaster.OfficeId, dalSRL.ofc_id));

                LoadListsLine(dalSRL.social_economic, dbCon);
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
            }        
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                benServiceRegister dalSR = new benServiceRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalSR.GetLines(ObjectId, dbCon);
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
            }
        }

        private void LoadDisplayMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayMember(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayMember(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHouseholdMember dalHhm = new hhHouseholdMember();
                DataRow dr = null;
                DataTable dt = null;
                #endregion Variables

                #region Load Display Line
                dt = dalHhm.GetMember(strId, FormCalling.FormMaster.LanguageId, dbCon);
                dr = dt.Rows[0];

                cbSubCounty.SelectedValue = dr["sct_id"].ToString();
                LoadListsHousehold(dr["sct_id"].ToString(), dbCon);

                if (!cbHHCode.SelectedValue.ToString().Equals(dr["hh_id"].ToString()))
                    cbHHCode.SelectedValue = dr["hh_id"].ToString();

                if (cbHHMember.SelectedValue == null || !cbHHMember.SelectedValue.ToString().Equals(strId))
                    LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);

                lblGenderDisplay.Text = dr["gnd_name"].ToString();
                lblHIVStatusDisplay.Text = dr["hst_name"].ToString();
                lblSubCountyDisplay.Text = dr["sct_name"].ToString();
                lblVillageDisplay.Text = dr["hh_village"].ToString();
                lblWardDisplay.Text = dr["wrd_name"].ToString();
                if (dr["hhm_year_of_birth"].ToString().Equals(utilConstants.cDFEmptyListValue))
                    lblYearOfBirthDisplay.Text = "";
                else
                    lblYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayMember", exc);
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
                LoadLists("", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strCsoId, string strDstId, string strFyId, string strQyId, string strSwkId, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");               

                dalSwk = new swmSocialWorker();
                if (strSwkId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", strDstId, "", false);
                LoadListsOrganization("", strCsoId);
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strSctId, string strDstId, string strRgnId, bool blnAllowSaveLine)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strSctId, strDstId, strRgnId, blnAllowSaveLine, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strSctId, string strDstId, string strRgnId, bool blnAllowSaveLine, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                utilSOCY_MIS utilSM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Get Partner and Region
                if (strRgnId.Length == 0 && strDstId.Length != 0)
                {
                    utilSM = new utilSOCY_MIS();
                    dt = utilSM.GetParentRegion(strDstId, "", dbCon);
                }

                if (utilCollections.HasRows(dt))
                    strRgnId = dt.Rows[0]["rgn_id"].ToString();
                #endregion Get Partner and Region

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_region", true, strRgnId, false, FormCalling.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRegion, dt, "lt_id", "lt_name");

                dt = uLT.GetDataByParent("lst_district", strRgnId, true, strDstId, false, FormCalling.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");

                dt = uLT.GetDataByParent("lst_sub_county", strDstId, true, strSctId, false, FormCalling.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSubCounty, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strSctId.Length != 0)
                    cbSubCounty.SelectedValue = strSctId;
                else
                    cbSubCounty.SelectedIndex = 0;
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                if (strRgnId.Length != 0)
                    cbRegion.SelectedValue = strRgnId;
                else
                    cbRegion.SelectedIndex = 0;
                #endregion Set List Selection

                SetLineControls(blnAllowSaveLine);
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListsHousehold(string strSctId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsHousehold(strSctId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsHousehold(string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHH = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHH = new hhHousehold();
                dt = dalHH.GetListBySubCountyAndForm(strSctId, "ben_service_register_line", "svr", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                #endregion Load Lists

                cbHHMember.SelectedIndex = -1;
                cbHHMember.Enabled = false;
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsHousehold", exc);
            }
        }

        private void LoadListsLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine("".Split(utilConstants.cDFSplitChar), dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string[] strSecId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilListTable uLT = null;

                DataTable dt = null;
                #endregion Variables
                
                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_social_economic", true, strSecId, true, FormCalling.FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbSocialEconomic, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                utilControls.CheckedListCheck(clbSocialEconomic, strSecId, "lt_id");
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsMember(string strHhId, string strHhmId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMember(strHhId, strHhmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMember(string strHhId, string strHhmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHouseholdMember dalHHM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetListForForm(strHhId, strHhmId, "ben_service_register_line", "svr", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                cbHHMember.Enabled = true;
                #endregion Load Lists

                #region Set List Selection
                if (strHhmId.Length != 0)
                    cbHHMember.SelectedValue = strHhmId;
                else
                    cbHHMember.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void LoadListsOrganization(string strPrtId, string strCsoId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsOrganization(strPrtId, strCsoId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsOrganization(string strPrtId, string strCsoId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsOrganization(strPrtId, strCsoId, cbPartner, cbCSO, FormCalling.FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsOrganization", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benServiceRegister dalSR = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSR = new benServiceRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalSR.svr_id = ObjectId;
                            dalSR.ofc_id = FormCalling.FormMaster.OfficeId;
                        }
                        else
                            dalSR.Load(ObjectId, dbCon);

                        dalSR.svr_contact_details = txtContactInfo.Text.Trim();

                        dalSR.cso_id = cbCSO.SelectedValue.ToString();
                        dalSR.dst_id = cbDistrict.SelectedValue.ToString();
                        dalSR.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalSR.qy_id = cbQuarter.SelectedValue.ToString();
                        dalSR.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalSR.usr_id_update = FormCalling.FormMaster.UserId;

                        dalSR.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormCalling.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetLineControls(true);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormCalling.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benServiceRegisterLine dalSRL = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        try
                        {
                            dbCon.TransactionBegin();
                            dalSRL = new benServiceRegisterLine();

                            if (lblSvrlId.Text.Length == 0 || lblSvrlId.Text.Trim().Equals("-"))
                            {
                                dalSRL.svrl_id = Guid.NewGuid().ToString();
                                dalSRL.ofc_id = FormCalling.FormMaster.OfficeId;
                            }
                            else
                                dalSRL.Load(lblSvrlId.Text, dbCon);

                            dalSRL.hhm_id = cbHHMember.SelectedValue.ToString();
                            dalSRL.svrl_eco_strength_other = txtEcoStrengthOther.Text.Trim();
                            dalSRL.yn_id_agricalture_advisory = utilControls.RadioButtonGetSelection(rbtnAgricaltureAdvisoryYes, rbtnAgricaltureAdvisoryNo);
                            dalSRL.yn_id_apprentice_skills = utilControls.RadioButtonGetSelection(rbtnApprenticeSkillsYes, rbtnApprenticeSkillsNo);
                            dalSRL.yn_id_basic_care = utilControls.RadioButtonGetSelection(rbtnBasicCareYes, rbtnBasicCareNo);
                            dalSRL.yn_id_birth_registration = utilControls.RadioButtonGetSelection(rbtnBirthRegistrationYes, rbtnBirthRegistrationNo);
                            dalSRL.yn_id_case_handled = utilControls.RadioButtonGetSelection(rbtnCaseHandledYes, rbtnCaseHandledNo);
                            dalSRL.yn_id_eco_strength_other = utilControls.RadioButtonGetSelection(rbtnEcoStrengthOtherYes, rbtnEcoStrengthOtherNo);
                            dalSRL.yn_id_newly_enrolled = utilControls.RadioButtonGetSelection(rbtnNewlyEnrolledYes, rbtnNewlyEnrolledNo);
                            dalSRL.yn_id_parenting = utilControls.RadioButtonGetSelection(rbtnParentingYes, rbtnParentingNo);
                            dalSRL.yn_id_psych_support = utilControls.RadioButtonGetSelection(rbtnPsychSupportYes, rbtnPsychSupportNo);
                            dalSRL.yn_id_reintegrated = utilControls.RadioButtonGetSelection(rbtnReintegratedYes, rbtnReintegratedNo);
                            dalSRL.yn_id_silc_intervention = utilControls.RadioButtonGetSelection(rbtnSILCInterventionYes, rbtnSILCInterventionNo);
                            dalSRL.svr_id = ObjectId;
                            dalSRL.usr_id_update = FormCalling.FormMaster.UserId;
                            dalSRL.social_economic = utilControls.CheckedListGetSelectedValues(clbSocialEconomic, "lt_id");

                            dalSRL.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormCalling.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormCalling.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
        }

        private void SetLineControls(bool blnEnabled)
        {
            btnServiceCancel.Enabled = blnEnabled;
            btnServiceDelete.Enabled = blnEnabled;
            btnServiceSave.Enabled = blnEnabled;

            cbHHCode.Enabled = blnEnabled;
            cbHHMember.Enabled = blnEnabled;
            cbSubCounty.Enabled = blnEnabled;
            if (!blnEnabled)
            {
                cbHHCode.SelectedIndex = -1;
                cbHHMember.SelectedIndex = -1;
                ClearMember(blnEnabled);
            }
            else
            {
                LoadListsLine();
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
            if (cbCSO.SelectedIndex == 0 || cbDistrict.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 ||
                cbQuarter.SelectedIndex == 0)
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
                    utilLT.Language = FormCalling.FormMaster.LanguageId;
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

        private string ValidateInputLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbHHCode.SelectedIndex <= 0 || cbHHMember.SelectedIndex <= 0)
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
                    utilLT.Language = FormCalling.FormMaster.LanguageId;
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
        #endregion Private

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
                pblnManage = dalUsr.HasPermission(FormCalling.FormMaster.UserId, utilConstants.cPMManageServiceRegister, dbCon);
                btnServiceDelete.Visible = pblnManage;
                btnServiceSave.Visible = pblnManage;
                btnSave.Visible = pblnManage;
            }
            catch (Exception exc)
            {
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
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
