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
    public partial class frmSILCLinkageRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmSILCGroupSearch frmCllGS = null;
        private frmSILCLinkageRegisterSearch frmCllLS = null;
        private Master frmMST = null;
        private int pintGroupX = 24;
        private int pintGroupY = 59;
        #endregion Variables

        #region Property
        public frmSILCGroupSearch FormCalling02
        {
            get { return frmCllGS; }
            set { frmCllGS = value; }
        }

        public frmSILCLinkageRegisterSearch FormCalling01
        {
            get { return frmCllLS; }
            set { frmCllLS = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmSILCLinkageRegister()
        {
            InitializeComponent();
        }

        private void frmSILCLinkageRegister_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
                btnGroupCancel.Enabled = !FormMaster.NoDatabase;
                btnGroupDelete.Enabled = !FormMaster.NoDatabase;
                btnGroupSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                btnGroupDelete.Enabled = false;
                LoadDisplay();
            }
        }

        private void frmSILCLinkageRegister_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbGroup.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
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

        private void btnGroupCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            SaveLine();
        }

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", cbCSO.SelectedValue.ToString());
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), cbCSO.SelectedValue.ToString());
        }

        private void cbPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", "");
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), "");
        }

        private void dgvGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvGroups.SelectedCells.Count != 0)
                {
                    strID = dgvGroups.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvGroups_CellDoubleClick", exc);
            }
        }

        private void dgvGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvGroups.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvGroups.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvGroups_RowPostPaint", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnGroupTypeExisting_CheckedChanged(object sender, EventArgs e)
        {
            SetGroupType(rbtnGroupTypeExisting.Checked);
        }

        private void rbtnLinkedInstitutionNo_CheckedChanged(object sender, EventArgs e)
        {
            SetBorrowing();
        }

        private void rbtnLinkedInstitutionYes_CheckedChanged(object sender, EventArgs e)
        {
            SetBorrowing();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Control Methods
        
        #region Private Methods
        private void Back()
        {
            if (FormCalling01 != null)
            {
                FormCalling01.BackDisplay();
                FormCalling01.FormParent.LoadControl(FormCalling01, this.Name);
            }
            else if (FormCalling02 != null)
                FormCalling02.FormParent.LoadControl(FormCalling02, this.Name);
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
                    cbFinancialYear.SelectedIndex = 0;
                    cbPartner.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;

                    txtContactDetails.Text = string.Empty;
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

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblSfrgId.Text = string.Empty;

                cbGroup.SelectedIndex = 0;
                nudMemberFemale.Value = 0;
                nudMemberMale.Value = 0;
                rbtnBorrowingInstitutionNo.Checked = false;
                rbtnBorrowingInstitutionYes.Checked = false;
                rbtnLinkedInstitutionNo.Checked = false;
                rbtnLinkedInstitutionYes.Checked = false;
                txtAmount.Text = string.Empty;
                txtGroupNew.Text = string.Empty;
                btnGroupSave.Enabled = pblnManage;
                #endregion Clear Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void DeleteLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcFinancialRegisterGroup dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvGroups.RowCount != 0)
                {
                    while (intCounter < dgvGroups.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvGroups.Rows[intCounter].Cells["gclDelete"].Value))
                            blnFound = true;
                        intCounter++;
                    }

                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;

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
                                    dalDel = new silcFinancialRegisterGroup();
                                    for (int intCount = 0; intCount < dgvGroups.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvGroups.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvGroups.Rows[intCount].Cells["gclID"].Value.ToString();
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
                            FormMaster.ShowMessage(utilConstants.cPTWarning, strMessage);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcFinancialRegister dalSFR = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadLists();
                    LoadListsLine("");
                    SetLineControls(false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalSFR = new silcFinancialRegister(ObjectId, dbCon);
                        txtContactDetails.Text = dalSFR.sfr_contact_details;
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSFR.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSFR.ofc_id));
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalSFR.cso_id, dalSFR.fy_id, dalSFR.qy_id, dalSFR.swk_id, dbCon);
                        LoadListsLine("", dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
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
                silcFinancialRegisterGroup dalSFRG = null;
                #endregion Variables

                #region Load Display Line
                dalSFRG = new silcFinancialRegisterGroup(strId, dbCon);

                lblSfrgId.Text = strId;
                LoadListsLine(dalSFRG.sg_id, dbCon);

                nudMemberFemale.Value = dalSFRG.sfrg_members_female;
                nudMemberMale.Value = dalSFRG.sfrg_members_male;
                txtAmount.Text = dalSFRG.sfrg_amount_borrowed.ToString();
                txtGroupNew.Text = string.Empty;
                btnGroupSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSFRG.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSFRG.ofc_id));

                utilControls.RadioButtonSetSelection(rbtnBorrowingInstitutionYes, rbtnBorrowingInstitutionNo, dalSFRG.yn_id_borrowed);
                utilControls.RadioButtonSetSelection(rbtnLinkedInstitutionYes, rbtnLinkedInstitutionNo, dalSFRG.yn_id_linked);

                SetGroupType(true);

                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
            }
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                silcFinancialRegister dalSFR = new silcFinancialRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalSFR.GetLines(ObjectId, dbCon);
                dgvGroups.AutoGenerateColumns = false;
                dgvGroups.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
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

        private void LoadLists(string strCsoId, string strFyId, string strQyId, string strSwkId, DataAccessLayer.DBConnection dbCon)
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

                LoadListsOrganization("", strCsoId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsLine(string strSgId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strSgId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strSgId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                silcGroup dalSG = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalSG = new silcGroup();
                dt = dalSG.GetList(strSgId, "silc_financial_register_group", "sfr", ObjectId, "sg_id", dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "sg_id", "sg_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGroup, dt, "sg_id", "sg_name");

                if(strSgId.Length != 0)
                    cbGroup.SelectedValue = strSgId;
                else
                    cbGroup.SelectedIndex = 0;
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
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
                utilSM.LoadListsOrganization(strPrtId, strCsoId, cbPartner, cbCSO, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsOrganization", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcFinancialRegister dalSFR = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSFR = new silcFinancialRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalSFR.sfr_id = ObjectId;
                            dalSFR.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSFR.Load(ObjectId, dbCon);

                        dalSFR.sfr_contact_details = txtContactDetails.Text.Trim();

                        dalSFR.cso_id = cbCSO.SelectedValue.ToString();
                        dalSFR.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalSFR.qy_id = cbQuarter.SelectedValue.ToString();
                        dalSFR.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalSFR.usr_id_update = FormMaster.UserId;

                        dalSFR.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
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

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcFinancialRegisterGroup dalSFRG = null;
                silcGroup dalSG = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                string strSGId = string.Empty;
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        if (rbtnGroupTypeNew.Checked)
                        {
                            dalSG = new silcGroup();
                            strSGId = Guid.NewGuid().ToString();
                            dalSG.sg_id = strSGId;
                            dalSG.sg_name = txtGroupNew.Text.Trim();
                            dalSG.ofc_id = FormMaster.OfficeId;
                            dalSG.usr_id_update = FormMaster.UserId;
                            dalSG.Save(dbCon);
                        }
                        else
                            strSGId = cbGroup.SelectedValue.ToString();

                        dalSFRG = new silcFinancialRegisterGroup();

                        if (lblSfrgId.Text.Length == 0 || lblSfrgId.Text.Trim().Equals("-"))
                        {
                            dalSFRG.sfrg_id = Guid.NewGuid().ToString();
                            dalSFRG.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSFRG.Load(lblSfrgId.Text, dbCon);

                        dalSFRG.sfrg_members_female = Convert.ToInt32(nudMemberFemale.Value);
                        dalSFRG.sfrg_members_male = Convert.ToInt32(nudMemberMale.Value);

                        if (utilFormatting.IsDecimal(txtAmount.Text))
                            dalSFRG.sfrg_amount_borrowed = Convert.ToDecimal(txtAmount.Text.Trim());
                        else
                            dalSFRG.sfrg_amount_borrowed = 0;

                        dalSFRG.sfr_id = ObjectId;
                        dalSFRG.sg_id = strSGId;
                        dalSFRG.yn_id_borrowed = utilControls.RadioButtonGetSelection(rbtnBorrowingInstitutionYes, rbtnBorrowingInstitutionNo);
                        dalSFRG.yn_id_linked = utilControls.RadioButtonGetSelection(rbtnLinkedInstitutionYes, rbtnLinkedInstitutionNo);
                        dalSFRG.usr_id_update = FormMaster.UserId;

                        dalSFRG.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
                        LoadListsLine("", dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
        }

        private void SetBorrowing()
        {
            if (!rbtnLinkedInstitutionYes.Checked)
            {
                rbtnBorrowingInstitutionNo.Checked = false;
                rbtnBorrowingInstitutionYes.Checked = false;
                txtAmount.Text = "";
            }

            rbtnBorrowingInstitutionNo.Enabled = rbtnLinkedInstitutionYes.Checked;
            rbtnBorrowingInstitutionYes.Enabled = rbtnLinkedInstitutionYes.Checked;
            txtAmount.Enabled = rbtnLinkedInstitutionYes.Checked;
        }

        private void SetGroupType(bool blnExisting)
        {
            tlpGroupExisting.Visible = blnExisting;
            tlpGroupNew.Visible = !blnExisting;
            tlpGroupExisting.Location = new Point(pintGroupX, pintGroupY);
            tlpGroupNew.Location = new Point(pintGroupX, pintGroupY);
        }

        private void SetLineControls(bool blnEnabled)
        {
            btnGroupCancel.Enabled = blnEnabled;
            btnGroupDelete.Enabled = blnEnabled;
            btnGroupSave.Enabled = blnEnabled;
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
            if (cbCSO.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 || cbQuarter.SelectedIndex == 0)
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

        private string ValidateInputLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            bool blnRequired = false;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (rbtnGroupTypeExisting.Checked && cbGroup.SelectedIndex == 0)
                blnRequired = true;
            else if (rbtnGroupTypeNew.Checked && txtGroupNew.Text.Trim().Length == 0)
                blnRequired = true;

            if (blnRequired)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageSILCGroupFinancialRegister, dbCon);
                btnGroupDelete.Visible = pblnManage;
                btnGroupSave.Visible = pblnManage;
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
