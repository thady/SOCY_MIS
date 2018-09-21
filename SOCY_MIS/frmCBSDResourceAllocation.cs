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
    public partial class frmCBSDResourceAllocation : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmCBSDResourceAllocationSearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        #endregion Variables

        #region Property
        public frmCBSDResourceAllocationSearch FormCalling
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
        public frmCBSDResourceAllocation()
        {
            InitializeComponent();
        }

        private void frmCBSDResourceAllocation_Load(object sender, EventArgs e)
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

        private void frmCBSDResourceAllocation_Paint(object sender, PaintEventArgs e)
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

        private void cbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsLine("", cbRegion.SelectedValue.ToString());
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

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void txtCBSDBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtCBSDBudget_TextChanged(object sender, EventArgs e)
        {
            ShowPercentage();
        }

        private void txtCBSDRealization_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtCBSDRealization_TextChanged(object sender, EventArgs e)
        {
            ShowPercentage();
        }

        private void txtDistrictGrantBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtProbationRealization_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtProbationRealization_TextChanged(object sender, EventArgs e)
        {
            ShowPercentage();
        }

        private void txtProbationShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtProbationShare_TextChanged(object sender, EventArgs e)
        {
            ShowPercentage();
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

                txtCBSDBudget.Text = "0";
                txtCBSDRealization.Text = "0";
                txtDistrictGrantBudget.Text = "0";
                txtProbationRealization.Text = "0";
                txtProbationShare.Text = "0";

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
                prtCBSDResourceAllocationDistrict dalDel = null;
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
                                    dalDel = new prtCBSDResourceAllocationDistrict();
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
                prtCBSDResourceAllocation dalCRA = null;
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
                        dalCRA = new prtCBSDResourceAllocation(ObjectId, dbCon);
                        dtpDate.Value = dalCRA.cra_date;
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalCRA.fy_id, dalCRA.prt_id, dalCRA.rgn_id, dbCon);
                        SetLineControls(true);
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalCRA.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalCRA.ofc_id));
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
                prtCBSDResourceAllocationDistrict dalCRAD = null;
                #endregion Variables

                #region Load Display Line
                dalCRAD = new prtCBSDResourceAllocationDistrict(strId, dbCon);

                lblId.Text = strId;
                txtCBSDBudget.Text = dalCRAD.crad_cbsd_budget.ToString();
                txtCBSDRealization.Text = dalCRAD.crad_cbsd_realization.ToString();
                txtDistrictGrantBudget.Text = dalCRAD.crad_district_grant_budget.ToString();
                txtProbationRealization.Text = dalCRAD.crad_probation_realization.ToString();
                txtProbationShare.Text = dalCRAD.crad_probation_share.ToString();
                txtPartnerFunding.Text = dalCRAD.crad_partner_funding.ToString();

                LoadListsLine(dalCRAD.dst_id, cbRegion.SelectedValue.ToString(), dbCon);
                btnLineSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalCRAD.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalCRAD.ofc_id));
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
                prtCBSDResourceAllocation dalCRA = new prtCBSDResourceAllocation();
                #endregion Variables

                #region Load Display Lines
                dt = dalCRA.GetLines(ObjectId, FormParent.FormMaster.LanguageId, dbCon);
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

                dt = utilSM.GetDistrictForForm(strRgnId, strDstId, "prt_cbsd_resource_allocation_district", "cra", ObjectId, "dst_id", FormParent.FormMaster.LanguageId, dbCon);
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
                prtCBSDResourceAllocation dalCRA = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalCRA = new prtCBSDResourceAllocation();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalCRA.cra_id = ObjectId;
                            dalCRA.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCRA.Load(ObjectId, dbCon);

                        dalCRA.cra_date = dtpDate.Value;
                        dalCRA.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalCRA.prt_id = cbPartner.SelectedValue.ToString();
                        dalCRA.rgn_id = cbRegion.SelectedValue.ToString();
                        dalCRA.usr_id_update = FormParent.FormMaster.UserId;

                        dalCRA.Save(dbCon);

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
                prtCBSDResourceAllocationDistrict dalCRAD = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalCRAD = new prtCBSDResourceAllocationDistrict();

                        if (lblId.Text.Length == 0 || lblId.Text.Trim().Equals("-"))
                        {
                            dalCRAD.crad_id = Guid.NewGuid().ToString();
                            dalCRAD.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCRAD.Load(lblId.Text, dbCon);

                        dalCRAD.dst_id = cbDistrict.SelectedValue.ToString();

                        if (utilFormatting.IsDecimal(txtCBSDBudget.Text.Trim()))
                            dalCRAD.crad_cbsd_budget = Convert.ToDecimal(txtCBSDBudget.Text.Trim());
                        else
                            dalCRAD.crad_cbsd_budget = 0;                        
                        if (utilFormatting.IsDecimal(txtCBSDRealization.Text.Trim()))
                            dalCRAD.crad_cbsd_realization = Convert.ToDecimal(txtCBSDRealization.Text.Trim());
                        else
                            dalCRAD.crad_cbsd_realization = 0;                        
                        if (utilFormatting.IsDecimal(txtDistrictGrantBudget.Text.Trim()))
                            dalCRAD.crad_district_grant_budget = Convert.ToDecimal(txtDistrictGrantBudget.Text.Trim());
                        else
                            dalCRAD.crad_district_grant_budget = 0;
                        if (utilFormatting.IsDecimal(txtProbationRealization.Text.Trim()))
                            dalCRAD.crad_probation_realization = Convert.ToDecimal(txtProbationRealization.Text.Trim());
                        else
                            dalCRAD.crad_probation_realization = 0;
                        if (utilFormatting.IsDecimal(txtProbationShare.Text.Trim()))
                            dalCRAD.crad_probation_share = Convert.ToDecimal(txtProbationShare.Text.Trim());
                        else
                            dalCRAD.crad_probation_share = 0;
                        if (utilFormatting.IsDecimal(txtPartnerFunding.Text.Trim()))
                            dalCRAD.crad_partner_funding = Convert.ToDecimal(txtPartnerFunding.Text.Trim());
                        else
                            dalCRAD.crad_partner_funding = 0;

                        dalCRAD.cra_id = ObjectId;
                        dalCRAD.usr_id_update = FormParent.FormMaster.UserId;

                        dalCRAD.Save(dbCon);

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

        private void ShowPercentage()
        {
            if (utilFormatting.IsDouble(txtCBSDBudget.Text) && utilFormatting.IsDouble(txtProbationShare.Text))
            {
                if (Convert.ToDouble(txtCBSDBudget.Text) != 0)
                    lblPercBudgetDisplay.Text = Convert.ToInt32(Convert.ToDouble(txtProbationShare.Text) * 100.0 / Convert.ToDouble(txtCBSDBudget.Text)).ToString();
            }
            else
                lblPercBudgetDisplay.Text = "-";

            if (utilFormatting.IsDouble(txtCBSDRealization.Text) && utilFormatting.IsDouble(txtProbationRealization.Text))
            {
                if (Convert.ToDouble(txtCBSDRealization.Text) != 0)
                    lblPercRealizationDisplay.Text = Convert.ToInt32(Convert.ToDouble(txtProbationRealization.Text) * 100.0 / Convert.ToDouble(txtCBSDRealization.Text)).ToString();
            }
            else
                lblPercRealizationDisplay.Text = "-";
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

            decimal dcmCBSDBudget = 0;
            decimal dcmCBSDProbation = 0;
            decimal dcmCBSDRealization = 0;
            decimal dcmProbationRealization = 0;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbDistrict.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Budget Validation
            if (utilFormatting.IsDecimal(txtCBSDBudget.Text.Trim()))
                dcmCBSDBudget = Convert.ToDecimal(txtCBSDBudget.Text.Trim());
            if (utilFormatting.IsDecimal(txtProbationShare.Text.Trim()))
                dcmCBSDProbation = Convert.ToDecimal(txtProbationShare.Text.Trim());
            if (utilFormatting.IsDecimal(txtCBSDRealization.Text.Trim()))
                dcmCBSDRealization = Convert.ToDecimal(txtCBSDRealization.Text.Trim());
            if (utilFormatting.IsDecimal(txtProbationRealization.Text.Trim()))
                dcmProbationRealization = Convert.ToDecimal(txtProbationRealization.Text.Trim());

            if (dcmCBSDRealization > dcmCBSDBudget)
                strMessage = strMessage + "," + utilConstants.cMIDValidateCBSDAnnualRealization;
            if (dcmCBSDProbation > dcmCBSDBudget)
                strMessage = strMessage + "," + utilConstants.cMIDValidateCBSDBudgetProbation;
            if (dcmProbationRealization > dcmCBSDProbation)
                strMessage = strMessage + "," + utilConstants.cMIDValidateProbationAnnualRealization;
            #endregion Budget Validation

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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageCBSDResourceAllocation, dbCon);
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

