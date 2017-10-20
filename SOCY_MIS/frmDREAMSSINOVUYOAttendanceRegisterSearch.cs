using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSSINOVUYOAttendanceRegisterSearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private frmDREAMS frmPrt = null;
        bool pblnSearched = false;
        #endregion Variables

        #region Property
        public frmDREAMS FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDREAMSSINOVUYOAttendanceRegisterSearch()
        {
            InitializeComponent();
        }

        private void frmDREAMSSINOVUYOAttendanceRegisterSearch_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadLists();
                Clear();
            }
        }

        private void frmDREAMSSINOVUYOAttendanceRegisterSearch_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFacilitator.SelectionLength = 0;
            cbGroup.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(false);
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

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmDREAMSSINOVUYOAttendanceRegister frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmDREAMSSINOVUYOAttendanceRegister();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormMaster = FormParent.FormMaster;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister_CellDoubleClick", exc);
            }
        }

        private void dgvRegister_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvRegister.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvRegister.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister_RowPostPaint", exc);
            }
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSSINOVUYOAttendanceRegister frmNew = new frmDREAMSSINOVUYOAttendanceRegister();
            frmNew.FormCalling = this;
            frmNew.FormMaster = frmPrt.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }
        #endregion Control Methods

        #region Public Methods
        public void BackDisplay()
        {
            if (!FormParent.FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                string strDstId = string.Empty;
                string strSctId = string.Empty;
                string strWrdId = string.Empty;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (cbDistrict.SelectedIndex != 0)
                        strDstId = cbDistrict.SelectedValue.ToString();
                    if (cbSubCounty.SelectedIndex != 0)
                        strSctId = cbSubCounty.SelectedValue.ToString();
                    if (cbWard.SelectedIndex != 0)
                        strWrdId = cbWard.SelectedValue.ToString();
                    LoadLists(cbFacilitator.SelectedValue.ToString(), cbGroup.SelectedValue.ToString(), strDstId, strSctId, strWrdId, dbCon);
                    if (pblnSearched)
                        Search(true);
                    #endregion Set Display
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
        }
        #endregion Public Methods

        #region Private Methods
        private void Clear()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                DataTable dt = null;
                drmSinovuyoRegister dalDsr = null;
                #endregion Variables

                #region Clear
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Dates
                    dalDsr = new drmSinovuyoRegister();
                    dt = dalDsr.GetDateRange(dbCon);
                    dtpDateFrom.Value = Convert.ToDateTime(dt.Rows[0]["dsr_date_from"]);
                    dtpDateTo.Value = Convert.ToDateTime(dt.Rows[0]["dsr_date_to"]);
                    #endregion Set Dates

                    cbDistrict.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbWard.SelectedIndex = 0;
                    LoadListsArea("", "", "", dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }

                cbFacilitator.SelectedIndex = 0;
                cbGroup.SelectedIndex = 0;
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = new DataTable();
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void Delete()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmSinovuyoRegister dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvRegister.RowCount != 0)
                {
                    while (intCounter < dgvRegister.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvRegister.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new drmSinovuyoRegister();
                                    for (int intCount = 0; intCount < dgvRegister.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvRegister.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvRegister.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    Search(false);
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

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            #region Load Lists
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
        }

        private void LoadLists(string strFacilitator, string strGroup, string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmSinovuyoRegister dalDsr = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalDsr = new drmSinovuyoRegister();

                dt = dalDsr.GetFacilitator(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "fcl_id", "fcl_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFacilitator, dt, "fcl_id", "fcl_name");

                dt = dalDsr.GetGroup(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "grp_id", "grp_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGroup, dt, "grp_id", "grp_name");
                #endregion Load Lists

                #region Set Value
                if (strFacilitator.Length != 0)
                    cbFacilitator.SelectedValue = strFacilitator;
                else
                    cbFacilitator.SelectedIndex = 0;
                if (strGroup.Length != 0)
                    cbGroup.SelectedValue = strGroup;
                else
                    cbGroup.SelectedIndex = 0;
                #endregion Set Value

                LoadListsArea(strDstId, strSctId, strWrdId, dbCon);
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
                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbDistrict, cbSubCounty, cbWard, FormParent.FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Search(bool blnBack)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmSinovuyoRegister dalDsr = new drmSinovuyoRegister();

                DataTable dt = new DataTable();
                int intArrayLength = 2;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbFacilitator.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbGroup.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbDistrict.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbSubCounty.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbWard.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    arrFilter[intArrayLength, 0] = "dsr_date_from";
                    arrFilter[intArrayLength, 1] = dtpDateFrom.Value.ToString("dd MMM yyyy");
                    intArrayLength++;
                    arrFilter[intArrayLength, 0] = "dsr_date_to";
                    arrFilter[intArrayLength, 1] = dtpDateTo.Value.ToString("dd MMM yyyy");
                    intArrayLength++;

                    if (cbFacilitator.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "dsr_facilitator";
                        arrFilter[intArrayLength, 1] = cbFacilitator.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbGroup.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "dsr_group";
                        arrFilter[intArrayLength, 1] = cbGroup.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbDistrict.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "dst_id";
                        arrFilter[intArrayLength, 1] = cbDistrict.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbSubCounty.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "sct_id";
                        arrFilter[intArrayLength, 1] = cbSubCounty.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbWard.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "wrd_id";
                        arrFilter[intArrayLength, 1] = cbWard.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalDsr.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
                    pblnSearched = true;
                    #endregion Search
                }
                finally
                {
                    dbCon.Dispose();
                }

                #region Load Datagrid
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = dt;
                #endregion
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
            }
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageDREAMSPostViolenceCare, dbCon);
                btnDelete.Visible = pblnManage;
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