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
    public partial class frmAlternativeCarePanelSummarySearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private frmResultArea02 frmPrt = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmAlternativeCarePanelSummarySearch()
        {
            InitializeComponent();
        }

        private void frmAlternativeCarePanelSummarySearch_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSearch.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadLists();
                Clear();
            }
        }

        private void frmAlternativeCarePanelSummarySearch_Paint(object sender, PaintEventArgs e)
        {
            cbFinancialYear.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
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
            Search();
        }

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmAlternativeCarePanelSummary frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmAlternativeCarePanelSummary();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormParent = FormParent;
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
            frmAlternativeCarePanelSummary frmNew = new frmAlternativeCarePanelSummary();
            frmNew.FormCalling = this;
            frmNew.FormParent = FormParent;
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
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (pblnSearched)
                        Search();
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
                prtAlternativeCarePanel dalACP = null;
                #endregion Variables

                #region Clear
                cbFinancialYear.SelectedIndex = 0;
                cbPartner.SelectedIndex = 0;
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Dates
                    dalACP = new prtAlternativeCarePanel();
                    dt = dalACP.GetDateRange(dbCon);
                    dtpDateBegin.Value = Convert.ToDateTime(dt.Rows[0]["date_begin"]);
                    dtpDateEnd.Value = Convert.ToDateTime(dt.Rows[0]["date_end"]);
                    #endregion Set Dates
                }
                finally
                {
                    dbCon.Dispose();
                }

                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = new DataTable();
                pblnSearched = false;
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
                prtAlternativeCarePanel dalDel = null;
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
                                    dalDel = new prtAlternativeCarePanel();
                                    for (int intCount = 0; intCount < dgvRegister.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvRegister.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvRegister.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    Search();
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
                LoadLists(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
        }

        private void LoadLists(DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_financial_year", true, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_partner", true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Search()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                prtAlternativeCarePanel dalACP = new prtAlternativeCarePanel();

                DataTable dt = new DataTable();
                int intArrayLength = 2;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbFinancialYear.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbPartner.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    arrFilter[intArrayLength, 0] = "date_begin";
                    arrFilter[intArrayLength, 1] = dtpDateBegin.Value.ToString("dd MMM yyyy");
                    intArrayLength++;
                    arrFilter[intArrayLength, 0] = "date_end";
                    arrFilter[intArrayLength, 1] = dtpDateEnd.Value.ToString("dd MMM yyyy");
                    intArrayLength++;

                    if (cbFinancialYear.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "fy_id";
                        arrFilter[intArrayLength, 1] = cbFinancialYear.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbPartner.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "prt_id";
                        arrFilter[intArrayLength, 1] = cbPartner.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalACP.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageAlternativeCarePanelSummary, dbCon);
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
