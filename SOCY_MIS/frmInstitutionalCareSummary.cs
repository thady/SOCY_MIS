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
    public partial class frmInstitutionalCareSummary : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmInstitutionalCareSummarySearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        #endregion Variables

        #region Property
        public frmInstitutionalCareSummarySearch FormCalling
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
        public frmInstitutionalCareSummary()
        {
            InitializeComponent();
        }

        private void frmInstitutionalCareSummary_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
                SetLineControls(false);
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmInstitutionalCareSummary_Paint(object sender, PaintEventArgs e)
        {
            cbCGGender.SelectionLength = 0;
            cbChildGender.SelectionLength = 0;
            cbDistrictMain.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbInstitution.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
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
            SaveLine();
        }

        private void cbDistrictMain_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrictMain.SelectedIndex == 0)
                LoadListInstitution("", "");
            else
                LoadListInstitution(cbDistrictMain.SelectedValue.ToString(), "");
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", "", "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "", cbWard.SelectedValue.ToString());
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
                    cbDistrictMain.SelectedIndex = 0;
                    cbFinancialYear.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;
                    LoadListsArea("", "", "");
                    SetLineControls(false);
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

                nudCGAge.Value = 0;
                nudChildAge.Value = 0;

                txtCGName.Text = string.Empty;
                txtChildName.Text = string.Empty;
                txtTelNo.Text = string.Empty;
                txtVillage.Text = string.Empty;
                btnLineSave.Enabled = pblnManage;

                LoadListsLine("", "", "");
                LoadListsArea("", "", "");
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
                prtInstitutionalCareSummaryLine dalDel = null;
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
                                    dalDel = new prtInstitutionalCareSummaryLine();
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
                prtInstitutionalCareSummary dalICS = null;
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
                        dalICS = new prtInstitutionalCareSummary(ObjectId, dbCon);
                        dtpDate.Value = dalICS.ics_date;
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalICS.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalICS.ofc_id));
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalICS.dst_id, dalICS.fy_id, dalICS.qy_id, dbCon);
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
                prtInstitutionalCareSummaryLine dalICSL = null;
                #endregion Variables

                #region Load Display Line
                dalICSL = new prtInstitutionalCareSummaryLine(strId, dbCon);

                lblId.Text = strId;
                nudCGAge.Value = dalICSL.icsl_caregiver_age;
                nudChildAge.Value = dalICSL.icsl_child_age;
                txtCGName.Text = dalICSL.icsl_caregiver_name;
                txtChildName.Text = dalICSL.icsl_child_name;
                txtTelNo.Text = dalICSL.icsl_contact_tel;
                txtVillage.Text = dalICSL.icsl_contact_village;
                btnLineSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalICSL.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalICSL.ofc_id));

                LoadListsArea("", "", dalICSL.wrd_id, dbCon);
                LoadListsLine(dalICSL.gnd_id_caregiver, dalICSL.gnd_id_child, dalICSL.ins_id, dbCon);
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
                prtInstitutionalCareSummary dalICS = new prtInstitutionalCareSummary();
                #endregion Variables

                #region Load Display Lines
                dt = dalICS.GetLines(ObjectId, dbCon);
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

                dt = uLT.GetData("lst_district", true, strDstId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrictMain, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDstId.Length != 0)
                    cbDistrictMain.SelectedValue = strDstId;
                else
                    cbDistrictMain.SelectedIndex = 0;
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", "", "", dbCon);
                LoadListsLine("", "", "", dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                if(!FormParent.FormMaster.NoDatabase)
                    utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbDistrict, cbSubCounty, cbWard, FormParent.FormMaster.LanguageId, dbCon);

                if (cbSubCounty.SelectedIndex == 0 && cbDistrict.SelectedIndex == 0)
                    lblWardVal.Visible = false;
                else
                    lblWardVal.Visible = true;
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListInstitution(string strDstId, string strInsId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListInstitution(strDstId, strInsId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListInstitution(string strDstId, string strInsId, DataAccessLayer.DBConnection dbCon)
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
                if (strDstId.Length == 0 && cbDistrictMain.SelectedIndex != 0)
                    strDstId = cbDistrictMain.SelectedValue.ToString();
                uLT = new utilListTable();
                dt = uLT.GetDataByParent("lst_institution", strDstId, true, strInsId, false, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbInstitution, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strInsId.Length != 0)
                    cbInstitution.SelectedValue = strInsId;
                else
                    cbInstitution.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void LoadListsLine(string strGndIdCG, string strGndIdChild, string strInsId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strGndIdCG, strGndIdChild, strInsId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strGndIdCG, string strGndIdChild, string strInsId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_gender", true, strGndIdCG, false, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbCGGender, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_gender", true, strGndIdChild, false, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbChildGender, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_institution", true, strInsId, false, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbInstitution, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strGndIdCG.Length != 0)
                    cbCGGender.SelectedValue = strGndIdCG;
                else
                    cbCGGender.SelectedIndex = 0;
                if (strGndIdChild.Length != 0)
                    cbChildGender.SelectedValue = strGndIdChild;
                else
                    cbChildGender.SelectedIndex = 0;
                if (strInsId.Length != 0)
                    cbInstitution.SelectedValue = strInsId;
                else
                    cbInstitution.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListInstitution("", strInsId);
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
                prtInstitutionalCareSummary dalICS = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalICS = new prtInstitutionalCareSummary();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalICS.ics_id = ObjectId;
                            dalICS.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalICS.Load(ObjectId, dbCon);

                        dalICS.ics_date = dtpDate.Value;
                        dalICS.dst_id = cbDistrictMain.SelectedValue.ToString();
                        dalICS.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalICS.qy_id = cbQuarter.SelectedValue.ToString();
                        dalICS.usr_id_update = FormParent.FormMaster.UserId;

                        dalICS.Save(dbCon);

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
                prtInstitutionalCareSummaryLine dalICSL = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalICSL = new prtInstitutionalCareSummaryLine();

                        if (lblId.Text.Length == 0 || lblId.Text.Trim().Equals("-"))
                        {
                            dalICSL.icsl_id = Guid.NewGuid().ToString();
                            dalICSL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalICSL.Load(lblId.Text, dbCon);

                        dalICSL.icsl_caregiver_age = Convert.ToInt32(nudCGAge.Value);
                        dalICSL.icsl_child_age = Convert.ToInt32(nudChildAge.Value);

                        dalICSL.icsl_caregiver_name = txtCGName.Text.Trim();
                        dalICSL.icsl_child_name = txtChildName.Text.Trim();
                        dalICSL.icsl_contact_tel = txtTelNo.Text.Trim();
                        dalICSL.icsl_contact_village = txtVillage.Text.Trim();

                        dalICSL.gnd_id_caregiver = cbCGGender.SelectedValue.ToString();
                        dalICSL.gnd_id_child = cbChildGender.SelectedValue.ToString();
                        dalICSL.ins_id = cbInstitution.SelectedValue.ToString();
                        dalICSL.wrd_id = cbWard.SelectedValue.ToString();

                        dalICSL.ics_id = ObjectId;
                        dalICSL.usr_id_update = FormParent.FormMaster.UserId;

                        dalICSL.Save(dbCon);

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
            if (cbDistrictMain.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 || cbQuarter.SelectedIndex == 0)
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
            if (txtChildName.Text.Trim().Length == 0 || cbInstitution.SelectedIndex == 0 || cbChildGender.SelectedIndex == 0 ||
                ((cbDistrict.SelectedIndex != 0 || cbSubCounty.SelectedIndex != 0) && cbWard.SelectedIndex == 0))
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageInstitutionalCareSummary, dbCon);
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
