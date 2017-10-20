using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSPostViolenceCareSearch : UserControl
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
        public frmDREAMSPostViolenceCareSearch()
        {
            InitializeComponent();
        }

        private void frmDREAMSPostViolenceCareSearch_Load(object sender, EventArgs e)
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

        private void frmDREAMSPostViolenceCareSearch_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFacility.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
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

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmDREAMSPostViolenceCare frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmDREAMSPostViolenceCare();
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
            frmDREAMSPostViolenceCare frmNew = new frmDREAMSPostViolenceCare();
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
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (cbDistrict.SelectedIndex != 0)
                        strDstId = cbDistrict.SelectedValue.ToString();
                    if (cbSubCounty.SelectedIndex != 0)
                        strSctId = cbSubCounty.SelectedValue.ToString();
                    LoadLists(cbFacility.SelectedValue.ToString(), strDstId, strSctId, dbCon);
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
                drmPostViolenceCare dalDpvc = null;
                #endregion Variables

                #region Clear
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Dates
                    dalDpvc = new drmPostViolenceCare();
                    dt = dalDpvc.GetDateRange(dbCon);
                    dtpCaptureDateFrom.Value = Convert.ToDateTime(dt.Rows[0]["usr_date_create_from"]);
                    dtpCaptureDateTo.Value = Convert.ToDateTime(dt.Rows[0]["usr_date_create_to"]);
                    #endregion Set Dates

                    cbDistrict.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    LoadListsArea("", "", dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }

                cbFacility.SelectedIndex = 0;
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
                drmPostViolenceCare dalDel = null;
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
                                    dalDel = new drmPostViolenceCare();
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
                LoadLists("", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
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
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_facility", true, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFacility, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set Value
                if (strFltId.Length != 0)
                    cbFacility.SelectedValue = strFltId;
                else
                    cbFacility.SelectedIndex = 0;
                #endregion Set Value

                LoadListsArea(strDstId, strSctId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                utilSM.LoadListsArea(strDstId, strSctId, "", cbDistrict, cbSubCounty, null, FormParent.FormMaster.LanguageId, dbCon);
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
                drmPostViolenceCare dalDpvc = new drmPostViolenceCare();

                DataTable dt = new DataTable();
                int intArrayLength = 2;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbFacility.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbDistrict.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbSubCounty.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    arrFilter[intArrayLength, 0] = "usr_date_create_from";
                    arrFilter[intArrayLength, 1] = dtpCaptureDateFrom.Value.ToString("dd MMM yyyy");
                    intArrayLength++;
                    arrFilter[intArrayLength, 0] = "usr_date_create_to";
                    arrFilter[intArrayLength, 1] = dtpCaptureDateTo.Value.ToString("dd MMM yyyy");
                    intArrayLength++;

                    if (cbFacility.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "flt_id";
                        arrFilter[intArrayLength, 1] = cbFacility.SelectedValue.ToString();
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
                    #endregion Search Criteria

                    dt = dalDpvc.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
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
