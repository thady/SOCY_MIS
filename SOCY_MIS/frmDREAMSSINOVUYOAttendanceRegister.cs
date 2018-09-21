using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;
using PSAUtils;

namespace SOCY_MIS
{
    public partial class frmDREAMSSINOVUYOAttendanceRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDREAMSSINOVUYOAttendanceRegisterSearch frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmDREAMSSINOVUYOAttendanceRegisterSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
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
        public frmDREAMSSINOVUYOAttendanceRegister()
        {
            InitializeComponent();
        }

        private void frmDREAMSSINOVUYOAttendanceRegister_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnLineCancel.Enabled = !FormMaster.NoDatabase;
                btnLineDelete.Enabled = !FormMaster.NoDatabase;
                btnLineSave.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmDREAMSSINOVUYOAttendanceRegister_Paint(object sender, PaintEventArgs e)
        {
            #region Selection Length
            cb01J.SelectionLength = 0;
            cb02J.SelectionLength = 0;
            cb03J.SelectionLength = 0;
            cb04S.SelectionLength = 0;
            cb05S.SelectionLength = 0;
            cb06J.SelectionLength = 0;
            cb07J.SelectionLength = 0;
            cb08S.SelectionLength = 0;
            cb09S.SelectionLength = 0;
            cb10J.SelectionLength = 0;
            cb11J.SelectionLength = 0;
            cb12J.SelectionLength = 0;
            cb13J.SelectionLength = 0;
            cb14J.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbDmIdNo.SelectionLength = 0;
            cbDmName.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
            #endregion Selection Length
        }
        #endregion Form Methods

        #region Control Methods
        #region Buttons
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
        #endregion Buttons

        #region ComboBox
        private void cbDmIdNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDisplayMember(cbDmIdNo.SelectedValue.ToString());
        }

        private void cbDmName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDisplayMember(cbDmName.SelectedValue.ToString());
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
                LoadListsArea("", "", cbWard.SelectedValue.ToString());
        }
        #endregion ComboBox

        #region Data Grid
        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvMember.SelectedCells.Count != 0)
                {
                    strID = dgvMember.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMember_CellDoubleClick", exc);
            }
        }

        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvMember.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvMember.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMember_RowPostPaint", exc);
            }
        }
        #endregion Data Grid

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormCalling.FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            if (ObjectId.Length == 0)
            {
                txtFacilitator.Text = string.Empty;
                txtGroup.Text = string.Empty;
                txtVillage.Text = string.Empty;
                dtpDateCaptured.Value = DateTime.Now;
                LoadListsArea("", "", "");
            }
            else
                LoadDisplay();
        }

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblDsrlId.Text = string.Empty;

                cb01J.SelectedIndex = 0;
                cb02J.SelectedIndex = 0;
                cb03J.SelectedIndex = 0;
                cb04S.SelectedIndex = 0;
                cb05S.SelectedIndex = 0;
                cb06J.SelectedIndex = 0;
                cb07J.SelectedIndex = 0;
                cb08S.SelectedIndex = 0;
                cb09S.SelectedIndex = 0;
                cb10J.SelectedIndex = 0;
                cb11J.SelectedIndex = 0;
                cb12J.SelectedIndex = 0;
                cb13J.SelectedIndex = 0;
                cb14J.SelectedIndex = 0;
                txtContact.Text = string.Empty;

                LoadListsMembers("");
                btnLineSave.Enabled = pblnManage;
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
                drmSinovuyoRegisterLine dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvMember.RowCount != 0)
                {
                    while (intCounter < dgvMember.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvMember.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new drmSinovuyoRegisterLine();
                                    for (int intCount = 0; intCount < dgvMember.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvMember.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvMember.Rows[intCount].Cells["gclID"].Value.ToString();
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
                drmSinovuyoRegister dalDsr = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadListsArea("", "", "");
                    SetLineControls(false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalDsr = new drmSinovuyoRegister(ObjectId, dbCon);
                        dtpDateCaptured.Value = dalDsr.dsr_date;
                        txtFacilitator.Text = dalDsr.dsr_facilitator;
                        txtGroup.Text = dalDsr.dsr_group;
                        txtVillage.Text = dalDsr.dsr_village;
                        LoadDisplayLines(dbCon);
                        LoadListsArea("", "", dalDsr.wrd_id, dbCon);
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadListsLine("", "", "", "", "", "", "", "", "", "", "", "", "", "", dbCon);
                        LoadListsMembers("", dbCon);
                        SetLineControls(true);
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDsr.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDsr.ofc_id));
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

        private void LoadDisplayLine(string strDsrlId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLine(strDsrlId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLine(string strDsrlId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmSinovuyoRegisterLine dalDsrl = null;
                #endregion Variables

                #region Load Display
                if (strDsrlId.Length == 0)
                {
                    ClearLine();
                }
                else
                {
                    dalDsrl = new drmSinovuyoRegisterLine(strDsrlId, dbCon);
                    lblDsrlId.Text = strDsrlId;
                    txtContact.Text = dalDsrl.dsrl_contact;

                    LoadListsLine(dalDsrl.pca_id_01, dalDsrl.pca_id_02, dalDsrl.pca_id_03, dalDsrl.pca_id_04, dalDsrl.pca_id_05,
                        dalDsrl.pca_id_06, dalDsrl.pca_id_07, dalDsrl.pca_id_08, dalDsrl.pca_id_09, dalDsrl.pca_id_10,
                        dalDsrl.pca_id_11, dalDsrl.pca_id_12, dalDsrl.pca_id_13, dalDsrl.pca_id_14, dbCon);
                    LoadListsMembers(dalDsrl.dm_id, dbCon);
                }
                #endregion Load Display
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
                #region Variables
                drmSinovuyoRegister dalDsr = null;

                DataTable dt = null;
                #endregion Variables

                #region Load Records
                dalDsr = new drmSinovuyoRegister();
                dt = dalDsr.GetLines(ObjectId, dbCon);
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dt;
                #endregion Load Records
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
            }
        }

        private void LoadDisplayMember(string strDmId)
        {
            #region Load Display
            if (strDmId.Length == 0 || strDmId.Equals(utilConstants.cDFEmptyListValue))
            {
                cbDmIdNo.SelectedIndex = 0;
                cbDmName.SelectedIndex = 0;
            }
            else
            {
                cbDmIdNo.SelectedValue = strDmId;
                cbDmName.SelectedValue = strDmId;
            }
            #endregion Load Display
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

        private void LoadListsLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine("", "", "", "", "", "", "", "", "", "", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strPcaId01, string strPcaId02, string strPcaId03, string strPcaId04, string strPcaId05,
            string strPcaId06, string strPcaId07, string strPcaId08, string strPcaId09, string strPcaId10,
            string strPcaId11, string strPcaId12, string strPcaId13, string strPcaId14, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();
                dt = uLT.GetData("lst_pca_type", true, "", FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cb01J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb02J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb03J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb04S, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb05S, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb06J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb07J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb08S, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb09S, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb10J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb11J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb12J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb13J, dt.Copy(), "lt_id", "lt_name");
                utilControls.ComboBoxFill(cb14J, dt.Copy(), "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strPcaId01.Length != 0)
                    cb01J.SelectedValue = strPcaId01;
                else
                    cb01J.SelectedIndex = 0;
                if (strPcaId02.Length != 0)
                    cb02J.SelectedValue = strPcaId02;
                else
                    cb02J.SelectedIndex = 0;
                if (strPcaId03.Length != 0)
                    cb03J.SelectedValue = strPcaId03;
                else
                    cb03J.SelectedIndex = 0;
                if (strPcaId04.Length != 0)
                    cb04S.SelectedValue = strPcaId04;
                else
                    cb04S.SelectedIndex = 0;
                if (strPcaId05.Length != 0)
                    cb05S.SelectedValue = strPcaId05;
                else
                    cb05S.SelectedIndex = 0;
                if (strPcaId06.Length != 0)
                    cb06J.SelectedValue = strPcaId06;
                else
                    cb06J.SelectedIndex = 0;
                if (strPcaId07.Length != 0)
                    cb07J.SelectedValue = strPcaId07;
                else
                    cb07J.SelectedIndex = 0;
                if (strPcaId08.Length != 0)
                    cb08S.SelectedValue = strPcaId08;
                else
                    cb08S.SelectedIndex = 0;
                if (strPcaId09.Length != 0)
                    cb09S.SelectedValue = strPcaId09;
                else
                    cb09S.SelectedIndex = 0;
                if (strPcaId10.Length != 0)
                    cb10J.SelectedValue = strPcaId10;
                else
                    cb10J.SelectedIndex = 0;
                if (strPcaId11.Length != 0)
                    cb11J.SelectedValue = strPcaId11;
                else
                    cb11J.SelectedIndex = 0;
                if (strPcaId12.Length != 0)
                    cb12J.SelectedValue = strPcaId12;
                else
                    cb12J.SelectedIndex = 0;
                if (strPcaId13.Length != 0)
                    cb13J.SelectedValue = strPcaId13;
                else
                    cb13J.SelectedIndex = 0;
                if (strPcaId14.Length != 0)
                    cb14J.SelectedValue = strPcaId14;
                else
                    cb14J.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void LoadListsMembers(string strDmId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMembers(strDmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMembers(string strDmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmMember dalDm = null;

                DataTable dtID = null;
                DataTable dtName = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalDm = new drmMember();

                dtID = dalDm.GetMembersForForm(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), strDmId, "drm_post_violence_care_line", "dpvc", ObjectId, "dm_id", dbCon);
                dtName = dtID.Copy();

                dtID = utilCollections.AddEmptyItemFront(dtID, "dm_id", "dm_id_no", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDmIdNo, dtID, "dm_id", "dm_id_no");

                dtName = utilCollections.AddEmptyItemFront(dtName, "dm_id", "member_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDmName, dtName, "dm_id", "member_name");
                #endregion Load Lists

                #region Set List Selection
                LoadDisplayMember(strDmId);
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMembers", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmSinovuyoRegister dalDsr = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDsr = new drmSinovuyoRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalDsr.dsr_id = ObjectId;
                            dalDsr.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDsr.Load(ObjectId, dbCon);

                        dalDsr.dsr_facilitator = txtFacilitator.Text.Trim();
                        dalDsr.dsr_group = txtGroup.Text.Trim();
                        dalDsr.dsr_village = txtVillage.Text.Trim();
                        dalDsr.dsr_date = dtpDateCaptured.Value;
                        dalDsr.wrd_id = cbWard.SelectedValue.ToString();
                        dalDsr.usr_id_update = FormMaster.UserId;

                        dalDsr.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        LoadListsLine("", "", "", "", "", "", "", "", "", "", "", "", "", "", dbCon);
                        ClearLine();
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
                drmSinovuyoRegisterLine dalDsrl = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        dalDsrl = new drmSinovuyoRegisterLine();

                        if (lblDsrlId.Text.Length == 0 || lblDsrlId.Text.Trim().Equals("-"))
                        {
                            dalDsrl.dsrl_id = Guid.NewGuid().ToString();
                            dalDsrl.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDsrl.Load(lblDsrlId.Text, dbCon);

                        dalDsrl.dsrl_contact = txtContact.Text.Trim();
                        dalDsrl.dm_id = cbDmIdNo.SelectedValue.ToString();
                        dalDsrl.pca_id_01 = cb01J.SelectedValue.ToString();
                        dalDsrl.pca_id_02 = cb02J.SelectedValue.ToString();
                        dalDsrl.pca_id_03 = cb03J.SelectedValue.ToString();
                        dalDsrl.pca_id_04 = cb04S.SelectedValue.ToString();
                        dalDsrl.pca_id_05 = cb05S.SelectedValue.ToString();
                        dalDsrl.pca_id_06 = cb06J.SelectedValue.ToString();
                        dalDsrl.pca_id_07 = cb07J.SelectedValue.ToString();
                        dalDsrl.pca_id_08 = cb08S.SelectedValue.ToString();
                        dalDsrl.pca_id_09 = cb09S.SelectedValue.ToString();
                        dalDsrl.pca_id_10 = cb10J.SelectedValue.ToString();
                        dalDsrl.pca_id_11 = cb11J.SelectedValue.ToString();
                        dalDsrl.pca_id_12 = cb12J.SelectedValue.ToString();
                        dalDsrl.pca_id_13 = cb13J.SelectedValue.ToString();
                        dalDsrl.pca_id_14 = cb14J.SelectedValue.ToString();

                        dalDsrl.dsr_id = ObjectId;
                        dalDsrl.usr_id_update = FormMaster.UserId;

                        dalDsrl.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
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
            if (cbWard.SelectedIndex == 0 || txtFacilitator.Text.Trim().Length == 0 || txtGroup.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Get Messages
                if (strMessage.Length != 0)
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
                #endregion Get Messages
            }
            finally
            {
                dbCon.Dispose();
            }

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
            if (cbDmIdNo.SelectedIndex == 0 || cbDmName.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Get Messages
                if (strMessage.Length != 0)
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
                #endregion Get Messages
            }
            finally
            {
                dbCon.Dispose();
            }

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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageDREAMSSINOVUYOAttendacneRegister, dbCon);
                btnLineDelete.Visible = pblnManage;
                btnLineSave.Visible = pblnManage;
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