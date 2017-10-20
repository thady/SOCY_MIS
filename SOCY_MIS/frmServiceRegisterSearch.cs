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
    public partial class frmServiceRegisterSearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private frmResultArea01 frmPrt01 = null;
        private frmResultArea03 frmPrt03 = null;
        private frmSILC frmPrtSILC = null;
        private Master frmMST = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmResultArea01 FormParent01
        {
            get { return frmPrt01; }
            set { frmPrt01 = value; }
        }

        public frmResultArea03 FormParent03
        {
            get { return frmPrt03; }
            set { frmPrt03 = value; }
        }

        public frmSILC FormParentSILC
        {
            get { return frmPrtSILC; }
            set { frmPrtSILC = value; }
        }
        #endregion Property

        #region Form Methods
        public frmServiceRegisterSearch()
        {
            InitializeComponent();
        }

        private void frmServiceRegisterSearch_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnDelete.Enabled = !FormMaster.NoDatabase;
                btnSearch.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadLists();
            }
        }

        private void frmServiceRegisterSearch_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
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
                frmServiceRegister frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmServiceRegister();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    if (FormParent01 != null)
                    {
                        frmNew.FormParent01 = FormParent01;
                        FormParent01.LoadControl(frmNew, this.Name);
                    }
                    else if (FormParent03 != null)
                    {
                        frmNew.FormParent03 = FormParent03;
                        FormParent03.LoadControl(frmNew, this.Name);
                    }
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister_CellDoubleClick", exc);
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
                if (!dgvRegister.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormMaster.OfficeId) || !pblnManage)
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister_RowPostPaint", exc);
            }
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmServiceRegister frmNew = new frmServiceRegister();
            frmNew.FormCalling = this;
            if (FormParent01 != null)
            {
                frmNew.FormParent01 = FormParent01;
                FormParent01.LoadControl(frmNew, this.Name);
            }
            else if (FormParent03 != null)
            {
                frmNew.FormParent03 = FormParent03;
                FormParent03.LoadControl(frmNew, this.Name);
            }
            else if (FormParentSILC != null)
            {
                frmNew.FormParentSILC = FormParentSILC;
                FormParentSILC.LoadControl(frmNew, this.Name);
            }
            #endregion
        }
        #endregion Control Methods

        #region Public Methods
        public void BackDisplay()
        {
            if (!FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                string strCsoId = string.Empty;
                string strDstId = string.Empty;
                string strFyId = string.Empty;
                string strPrtId = string.Empty;
                string strQyId = string.Empty;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (cbCSO.SelectedIndex != 0)
                        strCsoId = cbCSO.SelectedValue.ToString();
                    if (cbDistrict.SelectedIndex != 0)
                        strDstId = cbDistrict.SelectedValue.ToString();
                    if (cbFinancialYear.SelectedIndex != 0)
                        strFyId = cbFinancialYear.SelectedValue.ToString();
                    if (cbPartner.SelectedIndex != 0)
                        strPrtId = cbPartner.SelectedValue.ToString();
                    if (cbQuarter.SelectedIndex != 0)
                        strQyId = cbQuarter.SelectedValue.ToString();
                    LoadLists(strCsoId, strDstId, strFyId, strPrtId, strQyId, dbCon);
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
                #region Clear
                cbCSO.SelectedIndex = 0;
                cbDistrict.SelectedIndex = 0;
                cbFinancialYear.SelectedIndex = 0;
                cbPartner.SelectedIndex = 0;
                cbQuarter.SelectedIndex = 0;
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = new DataTable();
                pblnSearched = false;
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void Delete()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benServiceRegister dalDel = null;
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
                                    dalDel = new benServiceRegister();
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Delete", exc);
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

        private void LoadLists(string strCsoId, string strDstId, string strFyId, string strPrtId, string strQyId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_cso", true, strCsoId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbCSO, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_district", true, strDstId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_partner", true, strPrtId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strCsoId.Length != 0)
                    cbCSO.SelectedValue = strCsoId;
                else
                    cbCSO.SelectedIndex = 0;
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strPrtId.Length != 0)
                    cbPartner.SelectedValue = strPrtId;
                else
                    cbPartner.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Search()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benServiceRegister dalSR = new benServiceRegister();

                DataTable dt = new DataTable();
                int intArrayLength = 0;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbCSO.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbDistrict.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbFinancialYear.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbPartner.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbQuarter.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    if (cbCSO.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "cso_id";
                        arrFilter[intArrayLength, 1] = cbCSO.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbDistrict.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "dst_id";
                        arrFilter[intArrayLength, 1] = cbDistrict.SelectedValue.ToString();
                        intArrayLength++;
                    }

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

                    if (cbQuarter.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "qy_id";
                        arrFilter[intArrayLength, 1] = cbQuarter.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalSR.GetByCriteria(arrFilter, intArrayLength, FormMaster.LanguageId, dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageServiceRegister, dbCon);
                btnDelete.Visible = pblnManage;
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
