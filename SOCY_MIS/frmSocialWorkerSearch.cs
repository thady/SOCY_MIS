using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;
using PSAUtils;

namespace SOCY_MIS
{
    public partial class frmSocialWorkerSearch : UserControl
    {
        #region Variables
        bool pblnLoading = false;
        private Master frmMST = null;
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
        public frmSocialWorkerSearch()
        {
            InitializeComponent();
        }

        private void frmSocialWorkerSearch_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSearch.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                LoadLists();
            }
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
                frmSocialWorker frmNew = new frmSocialWorker();
                frmNew.FormCalling = this;
                frmNew.FormMaster = FormMaster;
                FormMaster.LoadControl(frmNew, this.Name, false);
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

        private void dgvSocialWorker_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmParaSocialWorkercs frmPSW = null;
                frmSocialWorker frmSW = null;
                string strID = string.Empty;
                string strType = string.Empty;
                #endregion

                #region Display Form
                if (dgvSocialWorker.SelectedCells.Count != 0)
                {
                    strID = dgvSocialWorker.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    strType = dgvSocialWorker.SelectedCells[0].OwningRow.Cells["gclType"].Value.ToString();

                    switch (strType)
                    {
                        case utilConstants.cSWTParaSocialWorker:
                            frmPSW = new frmParaSocialWorkercs();
                            frmPSW.ObjectId = strID;
                            frmPSW.FormCalling = this;
                            frmPSW.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmPSW, this.Name, false);
                            break;
                        case utilConstants.cSWTSocialWorker:
                            frmSW = new frmSocialWorker();
                            frmSW.ObjectId = strID;
                            frmSW.FormCalling = this;
                            frmSW.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmSW, this.Name, false);
                            break;
                    }
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvSocialWorker", exc);
            }
        }

        private void llblNewParaSocialWorker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                frmParaSocialWorkercs frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                frmNew = new frmParaSocialWorkercs();
                frmNew.FormCalling = this;
                frmNew.FormMaster = FormMaster;
                FormMaster.LoadControl(frmNew, this.Name, false);
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblNewParaSocialWorker", exc);
            }
        }

        private void llblNewSocialWorker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                frmSocialWorker frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                frmNew = new frmSocialWorker();
                frmNew.FormCalling = this;
                frmNew.FormMaster = FormMaster;
                FormMaster.LoadControl(frmNew, this.Name, false);
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblNewSocialWorker", exc);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Control Methdos

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
                    LoadLists(cbSocialWorker.SelectedValue.ToString(), cbSocialWorkerType.SelectedValue.ToString(), strDstId, strSctId, strWrdId, dbCon);
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
                cbDistrict.SelectedIndex = 0;
                cbSubCounty.SelectedIndex = 0;
                cbWard.SelectedIndex = 0;
                cbSocialWorker.SelectedIndex = 0;
                cbSocialWorkerType.SelectedIndex = 0;
                txtPhone.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                dgvSocialWorker.AutoGenerateColumns = false;
                dgvSocialWorker.DataSource = new DataTable();
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
            #region Variables
            DialogResult dlrResult;
            bool blnFound = false;
            int intCounter = 0;
            string strID = string.Empty;
            #endregion

            #region Delete checked records
            if (dgvSocialWorker.RowCount != 0)
            {
                while (intCounter < dgvSocialWorker.RowCount && !blnFound)
                {
                    if (Convert.ToBoolean(dgvSocialWorker.Rows[intCounter].Cells["gclDelete"].Value))
                        blnFound = true;
                    intCounter++;
                }

                if (blnFound)
                {
                    dlrResult = MessageBox.Show("Are you sure you want to delete the checked Subgrantees?", "Subgrantee Delete", MessageBoxButtons.YesNo);

                    if (dlrResult == DialogResult.Yes)
                    {
                        for (int intCount = 0; intCount < dgvSocialWorker.RowCount; intCount++)
                        {
                            if (Convert.ToBoolean(dgvSocialWorker.Rows[intCount].Cells["gclDelete"].Value))
                            {
                                strID = dgvSocialWorker.Rows[intCount].Cells["gclID"].Value.ToString();
                                //balSG = new balSubGrantee();
                                //balSG.FlagDelete(strID, UserID);
                            }
                        }
                        Search(false);
                    }
                }
                else
                    MessageBox.Show("Please check the Subgrantee(s) you wish to delete.", "Subgrantee Delete Canceled", MessageBoxButtons.OK);
            }
            #endregion
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

        private void LoadLists(string strSwkId, string strSwtId, string strDstId, string strSctId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                swmSocialWorker dalSW = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalSW = new swmSocialWorker();
                dt = dalSW.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");

                uLT = new utilListTable();
                dt = uLT.GetData("lst_social_worker_type", true, strSwtId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorkerType, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set Value
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                if (strSwtId.Length != 0)
                    cbSocialWorkerType.SelectedValue = strSwtId;
                else
                    cbSocialWorkerType.SelectedIndex = 0;
                #endregion Set Value

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
                    swmSocialWorker dalSwk = new swmSocialWorker();

                    DataTable dt = new DataTable();
                    int intArrayLength = 0;
                    string[,] arrFilter = null;
                    #endregion

                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Search
                        #region Search Criteria
                        if (cbSocialWorker.SelectedIndex != 0)
                            intArrayLength++;
                        if (cbDistrict.SelectedIndex != 0)
                            intArrayLength++;
                        if (cbSubCounty.SelectedIndex != 0)
                            intArrayLength++;
                        if (cbWard.SelectedIndex != 0)
                            intArrayLength++;
                        if (cbSocialWorkerType.SelectedIndex != 0)
                            intArrayLength++;
                        if (txtFirstName.Text.Trim().Length != 0)
                            intArrayLength++;
                        if (txtLastName.Text.Trim().Length != 0)
                            intArrayLength++;
                        if (txtPhone.Text.Trim().Length != 0)
                            intArrayLength++;

                        arrFilter = new string[intArrayLength, 2];
                        intArrayLength = 0;

                        if (cbSocialWorker.SelectedIndex != 0)
                        {
                            arrFilter[intArrayLength, 0] = "swk_id";
                            arrFilter[intArrayLength, 1] = cbSocialWorker.SelectedValue.ToString();
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

                        if (cbSocialWorkerType.SelectedIndex != 0)
                        {
                            arrFilter[intArrayLength, 0] = "swt_id";
                            arrFilter[intArrayLength, 1] = cbSocialWorkerType.SelectedValue.ToString();
                            intArrayLength++;
                        }

                        if (txtFirstName.Text.Trim().Length != 0)
                        {
                            arrFilter[intArrayLength, 0] = "swk_first_name";
                            arrFilter[intArrayLength, 1] = txtFirstName.Text.Trim();
                            intArrayLength++;
                        }

                        if (txtLastName.Text.Trim().Length != 0)
                        {
                            arrFilter[intArrayLength, 0] = "swk_last_name";
                            arrFilter[intArrayLength, 1] = txtLastName.Text.Trim();
                            intArrayLength++;
                        }

                        if (txtPhone.Text.Trim().Length != 0)
                        {
                            arrFilter[intArrayLength, 0] = "swk_phone";
                            arrFilter[intArrayLength, 1] = txtPhone.Text.Trim();
                            intArrayLength++;
                        }
                        #endregion Search Criteria

                        dt = dalSwk.GetByCriteria(arrFilter, intArrayLength, dbCon);
                        pblnSearched = true;
                        #endregion Search
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }

                    #region Load Datagrid
                    dgvSocialWorker.AutoGenerateColumns = false;
                    dgvSocialWorker.DataSource = dt;
                    #endregion Load Datagrid
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
            }
        }
        #endregion Private Methdos
    }
}
