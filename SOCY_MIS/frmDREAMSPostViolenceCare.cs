using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSPostViolenceCare : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDREAMSPostViolenceCareSearch frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmDREAMSPostViolenceCareSearch FormCalling
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
        public frmDREAMSPostViolenceCare()
        {
            InitializeComponent();
        }

        private void frmDREAMSPostViolenceCare_Load(object sender, EventArgs e)
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

        private void frmDREAMSPostViolenceCare_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbDmIdNo.SelectionLength = 0;
            cbDmName.SelectionLength = 0;
            cbFacility.SelectionLength = 0;
            cbGBV.SelectionLength = 0;
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
                LoadListsArea("", "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", cbSubCounty.SelectedValue.ToString());
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString());
        }

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

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control methods

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
                cbFacility.SelectedIndex = 0;
                dtpDateCaptured.Value = DateTime.Now;
                LoadListsArea("", "");
            }
            else
                LoadDisplay();
        }

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblDpvclId.Text = string.Empty;

                cbGBV.SelectedIndex = 0;
                txtReferredFrom.Text = string.Empty;
                utilControls.CheckedListClear(clbDreamsServiceOther);
                utilControls.CheckedListClear(clbPVCServices);
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
                drmPostViolenceCareLine dalDel = null;
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
                                    dalDel = new drmPostViolenceCareLine();
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
                drmPostViolenceCare dalDvc = null;
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
                        dalDvc = new drmPostViolenceCare(ObjectId, dbCon);

                        LoadDisplayLines(dbCon);
                        LoadLists(dalDvc.flt_id, "", dalDvc.sct_id, dbCon);
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadListsLine("", new string[0], new string[0], dbCon);
                        LoadListsMembers("", dbCon);
                        SetLineControls(true);
                        btnSave.Enabled = pblnManage && FormMaster.OfficeId.Equals(dalDvc.ofc_id);
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

        private void LoadDisplayLine(string strDpvclId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLine(strDpvclId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLine(string strDpvclId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmPostViolenceCareLine dalDpvcl = null;
                #endregion Variables

                #region Load Display
                if (strDpvclId.Length == 0)
                {
                    ClearLine();
                }
                else
                {
                    dalDpvcl = new drmPostViolenceCareLine(strDpvclId, dbCon);
                    lblDpvclId.Text = strDpvclId;
                    dtpDpvcDate.Value = dalDpvcl.dpvcl_date;
                    txtReferredFrom.Text = dalDpvcl.dpvcl_referred_from;

                    LoadListsLine(dalDpvcl.gbv_id, dalDpvcl.dreams_service_other, dalDpvcl.pvc_service, dbCon);
                    LoadListsMembers(dalDpvcl.dm_id, dbCon);
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
                drmPostViolenceCare dalDpvc = null;

                DataTable dt = null;
                #endregion Variables

                #region Load Records
                dalDpvc = new drmPostViolenceCare();
                dt = dalDpvc.GetLines(ObjectId, dbCon);
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
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayMember(strDmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayMember(string strDmId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            drmMember dalDM = null;
            DataTable dt = null;

            DateTime dtDoB = DateTime.Now;
            int intAge = 0;
            #endregion Variables

            #region Load Display
            if (strDmId.Length == 0 || strDmId.Equals(utilConstants.cDFEmptyListValue))
            {
                cbDmIdNo.SelectedIndex = 0;
                cbDmName.SelectedIndex = 0;
                lblAgeDisplay.Text = "-";
            }
            else
            {
                cbDmIdNo.SelectedValue = strDmId;
                cbDmName.SelectedValue = strDmId;
                dalDM = new drmMember();
                dt = dalDM.GetMember(strDmId, dbCon);
                if (utilCollections.HasRows(dt))
                    dtDoB = Convert.ToDateTime(dt.Rows[0]["dm_dob"]);

                intAge = dtpDpvcDate.Value.Year - dtDoB.Year;
                if (dtDoB > dtpDpvcDate.Value.AddYears(-intAge))
                    intAge--;
                lblAgeDisplay.Text = intAge.ToString();
            }
            #endregion Load Display
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

        private void LoadLists(string strFltId, string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_facility", true, strFltId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFacility, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strFltId.Length != 0)
                    cbFacility.SelectedValue = strFltId;
                else
                    cbFacility.SelectedIndex = 0;
                #endregion Set List Selection
                LoadListsArea(strDstId, strSctId);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strDstId, string strSctId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strDstId, strSctId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }
        
        private void LoadListsArea(string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsArea(strDstId, strSctId, "", cbDistrict, cbSubCounty, null, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListsLine(string strGbvId, string[] strDsoId, string[] strPvcsId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strGbvId, strDsoId, strPvcsId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strGbvId, string[] strDsoId, string[] strPvcsId, DataAccessLayer.DBConnection dbCon)
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
                dt = uLT.GetData("lst_gbv_type", true, strGbvId, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGBV, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_dreams_service_other", true, strDsoId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbDreamsServiceOther, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_pvc_service", true, strPvcsId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbPVCServices, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strGbvId.Length != 0)
                    cbGBV.SelectedValue = strGbvId;
                else
                    cbGBV.SelectedIndex = 0;

                utilControls.CheckedListCheck(clbDreamsServiceOther, strDsoId, "lt_id");
                utilControls.CheckedListCheck(clbPVCServices, strPvcsId, "lt_id");
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
                LoadDisplayMember(strDmId, dbCon);
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
                drmPostViolenceCare dalDpvc = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDpvc = new drmPostViolenceCare();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalDpvc.dpvc_id = ObjectId;
                            dalDpvc.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDpvc.Load(ObjectId, dbCon);

                        dalDpvc.flt_id = cbFacility.SelectedValue.ToString();
                        dalDpvc.sct_id = cbSubCounty.SelectedValue.ToString();
                        dalDpvc.usr_id_update = FormMaster.UserId;

                        dalDpvc.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        LoadListsLine("", new string[0], new string[0], dbCon);
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
                drmPostViolenceCareLine dalDpvcl = null;

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
                        dalDpvcl = new drmPostViolenceCareLine();

                        if (lblDpvclId.Text.Length == 0 || lblDpvclId.Text.Trim().Equals("-"))
                        {
                            dalDpvcl.dpvcl_id = Guid.NewGuid().ToString();
                            dalDpvcl.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDpvcl.Load(lblDpvclId.Text, dbCon);

                        dalDpvcl.dpvcl_date = dtpDpvcDate.Value;
                        dalDpvcl.dpvcl_referred_from = txtReferredFrom.Text.Trim();
                        dalDpvcl.dm_id = cbDmIdNo.SelectedValue.ToString();
                        dalDpvcl.gbv_id = cbGBV.SelectedValue.ToString();
                        dalDpvcl.dreams_service_other = utilControls.CheckedListGetSelectedValues(clbDreamsServiceOther, "lt_id");
                        dalDpvcl.pvc_service = utilControls.CheckedListGetSelectedValues(clbPVCServices, "lt_id");


                        dalDpvcl.dpvc_id = ObjectId;
                        dalDpvcl.usr_id_update = FormMaster.UserId;

                        dalDpvcl.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
                    }
                    catch(Exception exc)
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
            if (cbFacility.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageDREAMSPostViolenceCare, dbCon);
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
