using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSSINOVUYOMissedSessions : UserControl
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
        public frmDREAMSSINOVUYOMissedSessions()
        {
            InitializeComponent();
        }

        private void frmDREAMSSINOVUYOMissedSessions_Load(object sender, EventArgs e)
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
                LoadDisplaySessions();
            }
        }

        private void frmDREAMSSINOVUYOMissedSessions_Paint(object sender, PaintEventArgs e)
        {
            cbAction.SelectionLength = 0;
            cbFollowUp.SelectionLength = 0;
            cbFollowUpMethod.SelectionLength = 0;
            cbFollowUpReason.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        #region Buttons
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
        #endregion Buttons

        #region ComboBox
        private void cbAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbAction.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtActionOther);
            else
                SetOther(false, txtActionOther);
        }

        private void cbFollowUp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetControls();
        }

        private void cbFollowUpMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbFollowUpMethod.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtFollowUpMethodOther);
            else
                SetOther(false, txtFollowUpMethodOther);
        }

        private void cbFollowUpReason_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbFollowUpReason.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtFollowUpReasonOther);
            else
                SetOther(false, txtFollowUpReasonOther);
        }
        #endregion ComboBox

        private void dgvSession_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvSession.SelectedCells.Count != 0)
                {
                    strID = dgvSession.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplay(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvSession_CellDoubleClick", exc);
            }
        }

        private void dgvSession_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvSession.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvSession.Rows[e.RowIndex].Cells["gclDelete"];
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

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblbackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                ObjectId = string.Empty;
                lblDsmsId.Text = string.Empty;
                dtpSessionDate.Value = DateTime.Now;
                dtpFollowUpDate.Value = DateTime.Now;
                txtActionOther.Text = string.Empty;
                txtContact.Text = string.Empty;
                txtFollowUpMethodOther.Text = string.Empty;
                txtFollowUpReasonOther.Text = string.Empty;
                LoadLists();                
                btnSave.Enabled = pblnManage;
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
                drmSinovuyoMissedSession dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                bool blnDelObj = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvSession.RowCount != 0)
                {
                    while (intCounter < dgvSession.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvSession.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new drmSinovuyoMissedSession();
                                    for (int intCount = 0; intCount < dgvSession.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvSession.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            if (strId.Equals(ObjectId))
                                                blnDelObj = true;
                                            strId = dgvSession.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    if (blnDelObj)
                                        ObjectId = string.Empty;
                                    Clear();
                                    LoadDisplaySessions(dbCon);
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
        private void LoadDisplay(string strDsmsId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;

                drmSinovuyoMissedSession dalDsms = null;
                #endregion Variables

                #region Load Data
                lblDsmsId.Text = strDsmsId;
                if (strDsmsId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDsms = new drmSinovuyoMissedSession(strDsmsId, dbCon);

                        lblDsmsId.Text = dalDsms.dsms_id;

                        dtpSessionDate.Value = dalDsms.dsms_date;
                        dtpFollowUpDate.Value = dalDsms.dsms_date_followup;

                        txtActionOther.Text = dalDsms.dsms_action_other;
                        txtContact.Text = dalDsms.dsms_contact;
                        txtFollowUpMethodOther.Text = dalDsms.dsms_followup_method_other;
                        txtFollowUpReasonOther.Text = dalDsms.dsms_followup_other;

                        LoadLists(dalDsms.dsa_id, dalDsms.dsf_id, dalDsms.dsfm_id, dalDsms.yn_id_followup, dbCon);
                        LoadDisplaySessions(dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
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

        private void LoadDisplaySessions()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplaySessions(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplaySessions(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                DataTable dt = null;
                drmSinovuyoMissedSession dalDsms = new drmSinovuyoMissedSession();
                #endregion Variables

                #region Load Display Lines
                dt = dalDsms.GetList(MemberId, dbCon);
                dgvSession.AutoGenerateColumns = false;
                dgvSession.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplaySessions", exc);
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
                LoadLists("", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strDsaId, string strDsfId, string strDsfmId, string strYnIdFollowUp, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_dreams_session_action", true, strDsaId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbAction, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_dreams_session_followup", true, strDsfId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFollowUpReason, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_dreams_session_followup_method", true, strDsfmId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFollowUpMethod, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdFollowUp, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFollowUp, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDsaId.Length != 0)
                    cbAction.SelectedValue = strDsaId;
                else
                    cbAction.SelectedIndex = 0;
                if (strDsfId.Length != 0)
                    cbFollowUpReason.SelectedValue = strDsfId;
                else
                    cbFollowUpReason.SelectedIndex = 0;
                if (strDsfmId.Length != 0)
                    cbFollowUpMethod.SelectedValue = strDsfmId;
                else
                    cbFollowUpMethod.SelectedIndex = 0;
                if (strYnIdFollowUp.Length != 0)
                    cbFollowUp.SelectedValue = strYnIdFollowUp;
                else
                    cbFollowUp.SelectedIndex = 0;
                #endregion Set List Selection

                SetControls();
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                drmSinovuyoMissedSession dalDsms = null;

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
                        dalDsms = new drmSinovuyoMissedSession();
                        if (lblDsmsId.Text.Length == 0 || lblDsmsId.Text.Trim().Equals("-"))
                        {
                            dalDsms.dsms_id = Guid.NewGuid().ToString();
                            dalDsms.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalDsms.Load(lblDsmsId.Text, dbCon);

                        dalDsms.dsms_date = dtpSessionDate.Value;
                        dalDsms.dsms_date_followup = dtpFollowUpDate.Value;
                        dalDsms.dsms_action_other = txtActionOther.Text.Trim();
                        dalDsms.dsms_contact = txtContact.Text.Trim();
                        dalDsms.dsms_followup_method_other = txtFollowUpMethodOther.Text.Trim();
                        dalDsms.dsms_followup_other = txtFollowUpReasonOther.Text.Trim();
                        dalDsms.dm_id = MemberId;
                        dalDsms.dsa_id = cbAction.SelectedValue.ToString();
                        dalDsms.dsf_id = cbFollowUpReason.SelectedValue.ToString();
                        dalDsms.dsfm_id = cbFollowUpMethod.SelectedValue.ToString();
                        dalDsms.yn_id_followup = cbFollowUp.SelectedValue.ToString();
                        dalDsms.usr_id_update = FormParent.FormMaster.UserId;

                        dalDsms.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        Clear();
                        LoadDisplaySessions(dbCon);
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
            #region Variables
            bool blnEnabled = false;
            #endregion Variables

            #region Set Controls
            if (cbFollowUp.SelectedValue.ToString().Equals(utilConstants.cDFListValueYes))
                blnEnabled = true;

            cbAction.Enabled = blnEnabled;
            cbFollowUpMethod.Enabled = blnEnabled;
            cbFollowUpReason.Enabled = blnEnabled;
            dtpFollowUpDate.Enabled = blnEnabled;

            if (cbAction.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtActionOther);
            else
                SetOther(false, txtActionOther);

            if (cbFollowUpMethod.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtFollowUpMethodOther);
            else
                SetOther(false, txtFollowUpMethodOther);

            if (cbFollowUpReason.SelectedValue.ToString().Equals(utilConstants.cDFListValueOther))
                SetOther(true, txtFollowUpReasonOther);
            else
                SetOther(false, txtFollowUpReasonOther);
            #endregion Set Controls
        }

        private void SetOther(bool blnEnable, RichTextBox txtOther)
        {
            if (txtOther.Enabled && !blnEnable)
            {
                txtOther.Enabled = blnEnable;
                txtOther.Text = string.Empty;
            }
            else if (!txtOther.Enabled && blnEnable)
            {
                txtOther.Enabled = blnEnable;
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageDREAMSSINOVUYOMissedSession, dbCon);
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