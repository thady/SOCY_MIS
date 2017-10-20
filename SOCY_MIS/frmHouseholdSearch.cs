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
    public partial class frmHouseholdSearch : UserControl
    {
        #region Variables
        private Master frmMST = null;
        private bool pblnLoading = false;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHouseholdSearch()
        {
            InitializeComponent();
        }

        private void frmHouseholdSearch_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                LoadLists();
            }
        }

        private void frmHouseholdSearch_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
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
            if (FormMaster.NoDatabase)
            {
                #region Set Selected
                frmHousehold frmNew = new frmHousehold();
                frmNew.FormCalling = this;
                frmNew.FormMaster = FormMaster;
                FormMaster.LoadControl(frmNew, this.Name, false);
                #endregion
            }
            else
            {
                Search(false);
            }
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", "", "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
            }
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
            }
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                    LoadListsArea("", "", cbWard.SelectedValue.ToString());
            }
        }

        private void dgvHousehold_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmHousehold frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvHousehold.SelectedCells.Count != 0)
                {
                    strID = dgvHousehold.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmHousehold();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormMaster = FormMaster;
                    FormMaster.LoadControl(frmNew, this.Name, false);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvHousehold", exc);
            }
        }

        private void llblNewHousehold_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmOVCIdentificationPrioritization frmNew = new frmOVCIdentificationPrioritization();
            frmNew.FormCallingNew = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
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
                    LoadLists(strDstId, strSctId, strWrdId, dbCon);
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
                #region Clear
                txtHHCode.Text = string.Empty;
                cbDistrict.SelectedIndex = 0;
                cbSubCounty.SelectedIndex = 0;
                cbWard.SelectedIndex = 0;
                LoadListsArea("", "", "");

                dgvHousehold.AutoGenerateColumns = false;
                dgvHousehold.DataSource = new DataTable();
                pblnSearched = false;
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
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

        private void LoadLists(string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                LoadListsArea(strDstId, strSctId, strWrdId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbDistrict, cbSubCounty, cbWard, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Search(bool blnBack)
        {
            try
            {
                if (FormMaster.NoDatabase)
                {
                    if (!blnBack)
                    {
                        #region Set Selected
                        frmSocialWorker frmNew = new frmSocialWorker();
                        frmNew.FormMaster = FormMaster;
                        FormMaster.LoadControl(frmNew, this.Name, false);
                        #endregion
                    }
                }
                else
                {
                    #region Variables
                    DataAccessLayer.DBConnection dbCon = null;
                    hhHousehold dalHH = new hhHousehold();

                    DataTable dt = new DataTable();
                    int intArrayLength = 0;
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
                        if (txtHHCode.Text.Trim().Length != 0)
                            intArrayLength++;

                        arrFilter = new string[intArrayLength, 2];
                        intArrayLength = 0;

                        if (txtHHCode.Text.Trim().Length != 0)
                        {
                            arrFilter[intArrayLength, 0] = "hh_code";
                            arrFilter[intArrayLength, 1] = txtHHCode.Text.Trim();
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

                        dt = dalHH.GetByCriteria(arrFilter, intArrayLength, FormMaster.LanguageId, dbCon);
                        pblnSearched = true;
                        #endregion Search
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }

                    #region Load Datagrid
                    dgvHousehold.AutoGenerateColumns = false;
                    dgvHousehold.DataSource = dt;
                    #endregion
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
            }
        }
        #endregion Private Methods
    }
}
