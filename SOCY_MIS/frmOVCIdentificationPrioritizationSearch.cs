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
    public partial class frmOVCIdentificationPrioritizationSearch : UserControl
    {
        #region Variables
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
        public frmOVCIdentificationPrioritizationSearch()
        {
            InitializeComponent();
        }

        private void frmOVCIdentificationPrioritizationSearch_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSearch.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                LoadLists();
                Clear();
            }
        }

        private void frmOVCIdentificationPrioritizationSearch_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
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
                frmOVCIdentificationPrioritization frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmOVCIdentificationPrioritization();
                    frmNew.ObjectId = strID;
                    frmNew.FormCallingSearch = this;
                    frmNew.FormMaster = FormParent.FormMaster;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister", exc);
            }
        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmOVCIdentificationPrioritization frmNew = new frmOVCIdentificationPrioritization();
            frmNew.FormCallingSearch = this;
            frmNew.FormMaster = FormParent.FormMaster;
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
                    LoadLists(cbHHCode.SelectedValue.ToString(), strDstId, strSctId, strWrdId, dbCon);
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
                hhOVCIdentificationPrioritization dalOIP = null;
                #endregion Variables

                #region Clear
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Dates
                    dalOIP = new hhOVCIdentificationPrioritization();
                    dt = dalOIP.GetDateRange(dbCon);
                    dtpDateBegin.Value = Convert.ToDateTime(dt.Rows[0]["date_begin"]);
                    dtpDateEnd.Value = Convert.ToDateTime(dt.Rows[0]["date_end"]);
                    #endregion Set Dates
                }
                finally
                {
                    dbCon.Dispose();
                }
                
                cbHHCode.SelectedIndex = 0;
                cbDistrict.SelectedIndex = 0;
                cbSubCounty.SelectedIndex = 0;
                cbWard.SelectedIndex = 0;
                LoadListsArea("", "", "");

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

        private void LoadLists(string strHHId, string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHH = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHH = new hhHousehold();
                dt = dalHH.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                #endregion Load Lists

                #region Set Value
                if (strHHId.Length != 0)
                    cbHHCode.SelectedValue = strHHId;
                else
                    cbHHCode.SelectedIndex = 0;
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

        private void Search()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhOVCIdentificationPrioritization dalOIP = new hhOVCIdentificationPrioritization();

                DataTable dt = new DataTable();
                int intArrayLength = 2;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbDistrict.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbSubCounty.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbWard.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbHHCode.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    arrFilter[intArrayLength, 0] = "date_begin";
                    arrFilter[intArrayLength, 1] = dtpDateBegin.Value.ToString("dd MMM yyyy");
                    intArrayLength++;
                    arrFilter[intArrayLength, 0] = "date_end";
                    arrFilter[intArrayLength, 1] = dtpDateEnd.Value.ToString("dd MMM yyyy");
                    intArrayLength++;

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

                    if (cbHHCode.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "hh_id";
                        arrFilter[intArrayLength, 1] = cbHHCode.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalOIP.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
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

    }
}
