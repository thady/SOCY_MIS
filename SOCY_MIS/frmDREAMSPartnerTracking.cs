using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSPartnerTracking : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private string strDmId = string.Empty;
        private frmDREAMSMember frmCll = null;
        private frmDREAMS frmPrt = null;
        #endregion Variables

        #region Property
        public frmDREAMSMember FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmDREAMS FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string MemberId
        {
            get { return strDmId; }
            set { strDmId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDREAMSPartnerTracking()
        {
            InitializeComponent();
        }

        private void frmValueChainActorRegister_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay(ObjectId);
                LoadDisplayMember();
                LoadDisplayPartners();
            }
        }

        private void frmValueChainActorRegister_Paint(object sender, PaintEventArgs e)
        {
            cbDreamsPartner.SelectionLength = 0;
            cbHIVStatus.SelectionLength = 0;
            cbPartnerType.SelectionLength = 0;
            cbTraced.SelectionLength = 0;
            cbVMMCStatus.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbDreamsPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDisplayPartner(cbDreamsPartner.SelectedValue.ToString());
        }

        private void cbPartnerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetPartnerType();
        }

        private void cbTraced_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTraced();
        }

        private void dgvPartner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvPartner.SelectedCells.Count != 0)
                {
                    strID = dgvPartner.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplay(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvPartner_CellDoubleClick", exc);
            }
        }

        private void dgvPartner_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvPartner.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvPartner.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvPartner_RowPostPaint", exc);
            }
        }

        private void llblbackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
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
                ObjectId = string.Empty;
                lblDpId.Text = string.Empty;
                lblDptId.Text = string.Empty;
                cbHIVStatus.SelectedIndex = 0;
                cbPartnerType.SelectedIndex = 0;
                cbTraced.SelectedIndex = 0;
                cbVMMCStatus.SelectedIndex = 0;
                dtpAsAtDate.Value = DateTime.Now;
                txtAddress.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPartnerTypeOther.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtServicesReceived.Text = string.Empty;
                utilControls.CheckedListClear(clbServices);
                btnSave.Enabled = pblnManage;
                LoadListsPartner("");
                SetControls();
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        #region Delete
        private void Delete()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmPartnerTracking dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                bool blnDelObj = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strDpId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvPartner.RowCount != 0)
                {
                    while (intCounter < dgvPartner.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvPartner.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new drmPartnerTracking();
                                    for (int intCount = 0; intCount < dgvPartner.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvPartner.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            if (strId.Equals(ObjectId))
                                                blnDelObj = true;
                                            strId = dgvPartner.Rows[intCount].Cells["gclID"].Value.ToString();
                                            strDpId = dgvPartner.Rows[intCount].Cells["gclDpId"].Value.ToString();
                                            dalDel.Delete(strId, strDpId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    if (blnDelObj)
                                        ObjectId = string.Empty;
                                    Clear();
                                    LoadDisplayPartners(dbCon);
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Delete", exc);
            }
        }
        #endregion Delete

        #region Load Display
        private void LoadDisplay(string strDptId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;

                drmPartnerTracking dalDpt = null;
                #endregion Variables

                #region Load Data
                lblDptId.Text = strDptId;
                if (strDptId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDpt = new drmPartnerTracking(strDptId, dbCon);

                        lblDpId.Text = dalDpt.dp_id;

                        dtpAsAtDate.Value = dalDpt.dpt_date;
                        txtAddress.Text = dalDpt.dpt_address;
                        txtPartnerTypeOther.Text = dalDpt.dpt_dptp_other;
                        txtPhone.Text = dalDpt.dpt_phone;
                        txtServicesReceived.Text = dalDpt.dpt_service;

                        LoadLists(dalDpt.dp_id, dalDpt.dptp_id, dalDpt.hst_id, dalDpt.yn_id_traced, dalDpt.ynd_id_vmmc, dalDpt.dreams_service, dbCon);
                        LoadDisplayPartners(dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }

                SetControls();
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayMember()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            drmMember dalDm = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                dalDm = new drmMember(MemberId, dbCon);
                lblDreamsIdDisplay.Text = dalDm.dm_id_no;
                lblDreamsMemberDisplay.Text = dalDm.dm_first_name + " " + dalDm.dm_last_name;
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayPartner(string strDpId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayPartner(strDpId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayPartner(string strDpId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmPartner dalDP = null;
                #endregion Variables

                #region Load Data
                if (strDpId.Length == 0 || strDpId.Equals(utilConstants.cDFEmptyListValue))
                {
                    lblDpId.Text = string.Empty;
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                }
                else
                {
                    dalDP = new drmPartner(strDpId, dbCon);
                    lblDpId.Text = strDpId;
                    txtFirstName.Text = dalDP.dp_first_name;
                    txtLastName.Text = dalDP.dp_last_name;
                }
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayPartner", exc);
            }
        }

        private void LoadDisplayPartners()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayPartners(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayPartners(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                DataTable dt = null;
                drmPartnerTracking dalDpt = new drmPartnerTracking();
                #endregion Variables

                #region Load Display Lines
                dt = dalDpt.GetList(MemberId, dbCon);
                dgvPartner.AutoGenerateColumns = false;
                dgvPartner.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayPartners", exc);
            }
        }
        #endregion Load Display

        #region Load Lists
        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", "", new string[0], dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strDpId, string strDptptId, string strHstId, string strYnIdTraced, string strYndIdVMMC, string[] strDsrvId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_dreams_service", true, strDsrvId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbServices, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_dreams_partner_type", true, strDptptId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartnerType, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_hiv_status", true, strHstId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHIVStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdTraced, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbTraced, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no_dont_know", true, strYndIdVMMC, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbVMMCStatus, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDptptId.Length != 0)
                    cbPartnerType.SelectedValue = strDptptId;
                else
                    cbPartnerType.SelectedIndex = 0;
                if (strHstId.Length != 0)
                    cbHIVStatus.SelectedValue = strHstId;
                else
                    cbHIVStatus.SelectedIndex = 0;
                if (strYnIdTraced.Length != 0)
                    cbTraced.SelectedValue = strYnIdTraced;
                else
                    cbTraced.SelectedIndex = 0;
                if (strYndIdVMMC.Length != 0)
                    cbVMMCStatus.SelectedValue = strYndIdVMMC;
                else
                    cbVMMCStatus.SelectedIndex = 0;

                utilControls.CheckedListCheck(clbServices, strDsrvId, "lt_id");
                #endregion Set List Selection
                LoadListsPartner(strDpId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsPartner(string strDpId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsPartner(strDpId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }        
        }

        private void LoadListsPartner(string strDpId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmPartner dalDP = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListNewRecord, dbCon.dbCon);
                #region Load Lists

                dalDP = new drmPartner();

                dt = dalDP.GetList(MemberId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "dp_id", "dp_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDreamsPartner, dt, "dp_id", "dp_name");
                #endregion Load Lists

                #region Set List Selection
                if(strDpId.Length == 0)
                    cbDreamsPartner.SelectedIndex = 0;
                else
                    cbDreamsPartner.SelectedValue = strDpId;
                #endregion Set List Selection

                LoadDisplayPartner(cbDreamsPartner.SelectedValue.ToString(), dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsPartner", exc);
            }
        }
        #endregion Load Lists

        #region Save
        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmPartner dalDP = null;
                drmPartnerTracking dalDpt = null;

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
                        dalDP = new drmPartner();

                        if (lblDpId.Text.Length == 0 || lblDpId.Text.Trim().Equals("-"))
                        {
                            dalDP.dp_id = Guid.NewGuid().ToString();
                            dalDP.dm_id = MemberId;
                            dalDP.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalDP.Load(lblDpId.Text, dbCon);

                        dalDP.dp_first_name = txtFirstName.Text.Trim();
                        dalDP.dp_last_name = txtLastName.Text.Trim();
                        dalDP.usr_id_update = FormParent.FormMaster.UserId;

                        dalDpt = new drmPartnerTracking();
                        if (lblDptId.Text.Length == 0 || lblDptId.Text.Trim().Equals("-"))
                        {
                            dalDpt.dpt_id = Guid.NewGuid().ToString();
                            dalDpt.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalDpt.Load(lblDptId.Text, dbCon);

                        dalDpt.dpt_date = dtpAsAtDate.Value;
                        dalDpt.dpt_dptp_other = txtPartnerTypeOther.Text.Trim();
                        dalDpt.dpt_phone = txtPhone.Text.Trim();
                        dalDpt.dpt_address = txtAddress.Text.Trim();
                        dalDpt.dpt_service = txtServicesReceived.Text.Trim();
                        dalDpt.dp_id = dalDP.dp_id;
                        dalDpt.dptp_id = cbPartnerType.SelectedValue.ToString();
                        dalDpt.hst_id = cbHIVStatus.SelectedValue.ToString();
                        dalDpt.yn_id_traced = cbTraced.SelectedValue.ToString();
                        dalDpt.ynd_id_vmmc = cbVMMCStatus.SelectedValue.ToString();
                        dalDpt.usr_id_update = FormParent.FormMaster.UserId;

                        dalDpt.dreams_service = utilControls.CheckedListGetSelectedValues(clbServices, "lt_id");

                        dalDP.Save(dbCon);
                        dalDpt.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        Clear();
                        LoadDisplayPartners(dbCon);
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

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }
        #endregion Save

        #region Set Controls
        private void SetControls()
        {
            SetPartnerType();
            SetTraced();
        }

        private void SetPartnerType()
        {
            if (cbPartnerType.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
            {
                lblPartnerTypeOther.Visible = true;
                txtPartnerTypeOther.Visible = true;
            }
            else if (lblPartnerTypeOther.Visible)
            {
                lblPartnerTypeOther.Visible = false;
                txtPartnerTypeOther.Visible = false;
                txtPartnerTypeOther.Text = string.Empty;
            }
        }

        private void SetTraced()
        {
            if (cbTraced.SelectedValue.ToString().Equals(utilConstants.cDFListValueYes))
            {
                clbServices.Enabled = true;
            }
            else if (clbServices.Enabled)
            {
                clbServices.Enabled = false;
                utilControls.CheckedListClear(clbServices);
            }
        }
        #endregion Set Controls

        #region Validation
        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0)
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
        #endregion Validation
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageDREAMSPartnerTracking, dbCon);
                btnDelete.Visible = pblnManage;
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
