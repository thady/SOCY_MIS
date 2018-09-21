using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSSteppingStonesAttendanceRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDREAMSSteppingStonesAttendanceRegisterSearch frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmDREAMSSteppingStonesAttendanceRegisterSearch FormCalling
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
        public frmDREAMSSteppingStonesAttendanceRegister()
        {
            InitializeComponent();
        }

        private void frmDREAMSSteppingStonesAttendanceRegister_Load(object sender, EventArgs e)
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

        private void frmDREAMSSteppingStonesAttendanceRegister_Paint(object sender, PaintEventArgs e)
        {
            #region Selection Length
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
                lblDssrlId.Text = string.Empty;

                chkm1.Checked = false;
                chkm2.Checked = false;
                chkm3.Checked = false;
                chksA.Checked = false;
                chksB.Checked = false;
                chksC.Checked = false;
                chksD.Checked = false;
                chksE.Checked = false;
                chksF.Checked = false;
                chksG.Checked = false;
                chksH.Checked = false;
                chksI.Checked = false;
                chksJ.Checked = false;
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
                drmSteppingStonesRegisterLine dalDel = null;
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
                                    dalDel = new drmSteppingStonesRegisterLine();
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
                drmSteppingStonesRegister dalDssr = null;
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
                        dalDssr = new drmSteppingStonesRegister(ObjectId, dbCon);
                        dtpDateCaptured.Value = dalDssr.dssr_date;
                        txtFacilitator.Text = dalDssr.dssr_facilitator;
                        txtGroup.Text = dalDssr.dssr_group;
                        txtVillage.Text = dalDssr.dssr_village;
                        LoadDisplayLines(dbCon);
                        LoadListsArea("", "", dalDssr.wrd_id, dbCon);
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadListsMembers("", dbCon);
                        SetLineControls(true);
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDssr.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDssr.ofc_id));
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

        private void LoadDisplayLine(string strdssrlId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLine(strdssrlId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLine(string strdssrlId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmSteppingStonesRegisterLine dalDssrl = null;
                #endregion Variables

                #region Load Display
                if (strdssrlId.Length == 0)
                {
                    ClearLine();
                }
                else
                {
                    dalDssrl = new drmSteppingStonesRegisterLine(strdssrlId, dbCon);
                    lblDssrlId.Text = strdssrlId;
                    txtContact.Text = dalDssrl.dssrl_contact;
                    chkm1.Checked = dalDssrl.yn_id_m1.Equals(utilConstants.cDFListValueYes);
                    chkm2.Checked = dalDssrl.yn_id_m2.Equals(utilConstants.cDFListValueYes);
                    chkm3.Checked = dalDssrl.yn_id_m3.Equals(utilConstants.cDFListValueYes);
                    chksA.Checked = dalDssrl.yn_id_sa.Equals(utilConstants.cDFListValueYes);
                    chksB.Checked = dalDssrl.yn_id_sb.Equals(utilConstants.cDFListValueYes);
                    chksC.Checked = dalDssrl.yn_id_sc.Equals(utilConstants.cDFListValueYes);
                    chksD.Checked = dalDssrl.yn_id_sd.Equals(utilConstants.cDFListValueYes);
                    chksE.Checked = dalDssrl.yn_id_se.Equals(utilConstants.cDFListValueYes);
                    chksF.Checked = dalDssrl.yn_id_sf.Equals(utilConstants.cDFListValueYes);
                    chksG.Checked = dalDssrl.yn_id_sg.Equals(utilConstants.cDFListValueYes);
                    chksH.Checked = dalDssrl.yn_id_sh.Equals(utilConstants.cDFListValueYes);
                    chksI.Checked = dalDssrl.yn_id_si.Equals(utilConstants.cDFListValueYes);
                    chksJ.Checked = dalDssrl.yn_id_sj.Equals(utilConstants.cDFListValueYes);
                    LoadListsMembers(dalDssrl.dm_id, dbCon);
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
                drmSteppingStonesRegister dalDssr = null;

                DataTable dt = null;
                #endregion Variables

                #region Load Records
                dalDssr = new drmSteppingStonesRegister();
                dt = dalDssr.GetLines(ObjectId, dbCon);
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
                drmSteppingStonesRegister dalDssr = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDssr = new drmSteppingStonesRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalDssr.dssr_id = ObjectId;
                            dalDssr.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDssr.Load(ObjectId, dbCon);

                        dalDssr.dssr_facilitator = txtFacilitator.Text.Trim();
                        dalDssr.dssr_group = txtGroup.Text.Trim();
                        dalDssr.dssr_village = txtVillage.Text.Trim();
                        dalDssr.dssr_date = dtpDateCaptured.Value;
                        dalDssr.wrd_id = cbWard.SelectedValue.ToString();
                        dalDssr.usr_id_update = FormMaster.UserId;

                        dalDssr.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
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
                drmSteppingStonesRegisterLine dalDssrl = null;

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
                        dalDssrl = new drmSteppingStonesRegisterLine();

                        if (lblDssrlId.Text.Length == 0 || lblDssrlId.Text.Trim().Equals("-"))
                        {
                            dalDssrl.dssrl_id = Guid.NewGuid().ToString();
                            dalDssrl.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDssrl.Load(lblDssrlId.Text, dbCon);

                        dalDssrl.dssrl_contact = txtContact.Text.Trim();
                        dalDssrl.dm_id = cbDmIdNo.SelectedValue.ToString();
                        dalDssrl.yn_id_m1 = chkm1.Checked?utilConstants.cDFListValueYes:utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_m2 = chkm2.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_m3 = chkm3.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sa = chksA.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sb = chksB.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sc = chksC.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sd = chksD.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_se = chksE.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sf = chksF.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sg = chksG.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sh = chksH.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_si = chksI.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;
                        dalDssrl.yn_id_sj = chksJ.Checked ? utilConstants.cDFListValueYes : utilConstants.cDFListValueNo;

                        dalDssrl.dssr_id = ObjectId;
                        dalDssrl.usr_id_update = FormMaster.UserId;

                        dalDssrl.Save(dbCon);
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageDREAMSSteppingStonesAttendacneRegister, dbCon);
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