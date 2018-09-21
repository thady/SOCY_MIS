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
    public partial class frmAlternativeCarePanelSummary : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmAlternativeCarePanelSummarySearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        #endregion Variables

        #region Property
        public frmAlternativeCarePanelSummarySearch FormCalling
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
        public frmAlternativeCarePanelSummary()
        {
            InitializeComponent();
        }

        private void frmAlternativeCarePanelSummary_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
                btnLineCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnLineDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnLineSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmAlternativeCarePanelSummary_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbRegion.SelectionLength = 0;
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

        private void btnLineCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnLineDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnLineSave_Click(object sender, EventArgs e)
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

        private void dgvLine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvLine.SelectedCells.Count != 0)
                {
                    strID = dgvLine.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvLine_CellDoubleClick", exc);
            }
        }

        private void dgvLine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvLine.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvLine.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvLine_RowPostPaint", exc);
            }
        }

        private void cbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsLine("", cbRegion.SelectedValue.ToString());
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnPanelEstablishedYes_CheckedChanged(object sender, EventArgs e)
        {
            rbtnPanelFunctionalNo.Enabled = rbtnPanelEstablishedYes.Checked;
            rbtnPanelFunctionalYes.Enabled = rbtnPanelEstablishedYes.Checked;
            if (!rbtnPanelEstablishedYes.Checked)
            {
                rbtnPanelFunctionalNo.Checked = false;
                rbtnPanelFunctionalYes.Checked = false;
            }
        }

        private void rbtnPanelFunctionalYes_CheckedChanged(object sender, EventArgs e)
        {
            txtSupportExtended.Enabled = rbtnPanelFunctionalYes.Enabled;
        }
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
                    cbFinancialYear.SelectedIndex = 0;
                    cbPartner.SelectedIndex = 0;
                    cbRegion.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;
                    LoadListsLine("", cbRegion.SelectedValue.ToString());
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

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblId.Text = string.Empty;

                rbtnPanelEstablishedNo.Checked = false;
                rbtnPanelEstablishedYes.Checked = false;
                rbtnPanelFunctionalNo.Checked = false;
                rbtnPanelFunctionalYes.Checked = false;
                txtSupportExtended.Text = string.Empty;

                LoadListsLine("", cbRegion.SelectedValue.ToString());
                btnLineSave.Enabled = pblnManage;
                #endregion Clear Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void DeleteLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                prtAlternativeCarePanelDistrict dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvLine.RowCount != 0)
                {
                    while (intCounter < dgvLine.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvLine.Rows[intCounter].Cells["gclDelete"].Value))
                            blnFound = true;
                        intCounter++;
                    }

                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;

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
                                    dalDel = new prtAlternativeCarePanelDistrict();
                                    for (int intCount = 0; intCount < dgvLine.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvLine.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvLine.Rows[intCount].Cells["gclID"].Value.ToString();
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
                            FormParent.FormMaster.ShowMessage(utilConstants.cPTWarning, strMessage);
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                prtAlternativeCarePanel dalACP = null;
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
                        dalACP = new prtAlternativeCarePanel(ObjectId, dbCon);
                        dtpDate.Value = dalACP.acp_date;
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalACP.fy_id, dalACP.prt_id, dalACP.rgn_id, dbCon);
                        SetLineControls(true);
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalACP.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalACP.ofc_id));
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
                prtAlternativeCarePanelDistrict dalACPD = null;
                #endregion Variables

                #region Load Display Line
                dalACPD = new prtAlternativeCarePanelDistrict(strId, dbCon);

                lblId.Text = strId;
                txtSupportExtended.Text = dalACPD.acpd_support_extended;

                utilControls.RadioButtonSetSelection(rbtnPanelEstablishedYes, rbtnPanelEstablishedNo, dalACPD.yn_id_established);
                utilControls.RadioButtonSetSelection(rbtnPanelFunctionalYes, rbtnPanelFunctionalNo, dalACPD.yn_id_functional);
                LoadListsLine(dalACPD.dst_id, cbRegion.SelectedValue.ToString(), dbCon);
                btnLineSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalACPD.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalACPD.ofc_id));
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
            }        
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                prtAlternativeCarePanel dalACP = new prtAlternativeCarePanel();
                #endregion Variables

                #region Load Display Lines
                dt = dalACP.GetLines(ObjectId, FormParent.FormMaster.LanguageId, dbCon);
                dgvLine.AutoGenerateColumns = false;
                dgvLine.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
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

        private void LoadLists(string strFyId, string strPrtId, string strRgnId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_partner", true, strPrtId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_region", true, strRgnId, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRegion, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strPrtId.Length != 0)
                    cbPartner.SelectedValue = strPrtId;
                else
                    cbPartner.SelectedIndex = 0;
                if (strRgnId.Length != 0)
                    cbRegion.SelectedValue = strRgnId;
                else
                    cbRegion.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsLine("", cbRegion.SelectedValue.ToString(), dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsLine(string strDstId, string strRgnId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strDstId, strRgnId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strDstId, string strRgnId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilSOCY_MIS utilSM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                utilSM = new utilSOCY_MIS();

                dt = utilSM.GetDistrictForForm(strRgnId, strDstId, "prt_alternative_care_panel_district", "acp", ObjectId, "dst_id", FormParent.FormMaster.LanguageId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                prtAlternativeCarePanel dalACP = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalACP = new prtAlternativeCarePanel();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalACP.acp_id = ObjectId;
                            dalACP.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalACP.Load(ObjectId, dbCon);

                        dalACP.acp_date = dtpDate.Value;
                        dalACP.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalACP.prt_id = cbPartner.SelectedValue.ToString();
                        dalACP.rgn_id = cbRegion.SelectedValue.ToString();
                        dalACP.usr_id_update = FormParent.FormMaster.UserId;

                        dalACP.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
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

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                prtAlternativeCarePanelDistrict dalACPD = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalACPD = new prtAlternativeCarePanelDistrict();

                        if (lblId.Text.Length == 0 || lblId.Text.Trim().Equals("-"))
                        {
                            dalACPD.acpd_id = Guid.NewGuid().ToString();
                            dalACPD.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalACPD.Load(lblId.Text, dbCon);

                        dalACPD.dst_id = cbDistrict.SelectedValue.ToString();
                        dalACPD.acpd_support_extended = txtSupportExtended.Text.Trim();
                        dalACPD.yn_id_established = utilControls.RadioButtonGetSelection(rbtnPanelEstablishedYes, rbtnPanelEstablishedNo);
                        dalACPD.yn_id_functional = utilControls.RadioButtonGetSelection(rbtnPanelFunctionalYes, rbtnPanelFunctionalNo);


                        dalACPD.acp_id = ObjectId;
                        dalACPD.usr_id_update = FormParent.FormMaster.UserId;

                        dalACPD.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
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

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
        }

        private void SetLineControls(bool blnEnabled)
        {
            btnLineCancel.Enabled = blnEnabled;
            btnLineDelete.Enabled = blnEnabled;
            btnLineSave.Enabled = blnEnabled;
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
            if (cbFinancialYear.SelectedIndex == 0 || cbPartner.SelectedIndex == 0 || cbRegion.SelectedIndex == 0)
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

        private string ValidateInputLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbDistrict.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageAlternativeCarePanelSummary, dbCon);
                btnLineDelete.Visible = pblnManage;
                btnLineSave.Visible = pblnManage;
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

