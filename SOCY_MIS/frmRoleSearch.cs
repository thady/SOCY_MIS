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
    public partial class frmRoleSearch : UserControl
    {
        #region Variables
        private frmAdmin frmPrt = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public frmAdmin FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmRoleSearch()
        {
            InitializeComponent();
        }

        private void frmRoleSearch_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnDelete.Enabled = !FormParent.FormMaster.NoDatabase;
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
            #region Clear
            txtRoleName.Text = string.Empty;
            cbRole.SelectedIndex = 0;
            #endregion Clear
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmRole frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRole.SelectedCells.Count != 0)
                {
                    strID = dgvRole.SelectedCells[0].OwningRow.Cells["gclRoleID"].Value.ToString();

                    frmNew = new frmRole();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRole", exc);
            }
        }

        private void llblNewRole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                frmRole frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                frmNew = new frmRole();
                frmNew.FormCalling = this;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblNewRole", exc);
            }
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
                    LoadLists(cbRole.SelectedValue.ToString(), dbCon);
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
        #endregion Public Methdos

        #region Private Methods
        private void Clear()
        {
            try
            {
                #region Clear
                cbRole.SelectedIndex = 0;
                txtRoleName.Text = string.Empty;
                dgvRole.AutoGenerateColumns = false;
                dgvRole.DataSource = new DataTable();
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
                umRole dalRole = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvRole.RowCount != 0)
                {
                    while (intCounter < dgvRole.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvRole.Rows[intCounter].Cells["gclDelete"].Value))
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
                                dalRole = new umRole();
                                for (int intCount = 0; intCount < dgvRole.RowCount; intCount++)
                                {
                                    if (Convert.ToBoolean(dgvRole.Rows[intCount].Cells["gclDelete"].Value))
                                    {
                                        strId = dgvRole.Rows[intCount].Cells["gclRoleID"].Value.ToString();
                                        dalRole.Delete(strId, dbCon);
                                    }
                                }
                                Search();
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
                LoadLists("", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
        }

        private void LoadLists(string strRlId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                umRole dalRole = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalRole = new umRole();
                dt = dalRole.GetRoleList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "rl_id", "rl_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRole, dt, "rl_id", "rl_name");
                #endregion Load Lists

                #region Set Value
                if (strRlId.Length != 0)
                    cbRole.SelectedValue = strRlId;
                #endregion Set Value
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void Search()
        {
            Search(false);
        }

        private void Search(bool blnBack)
        {
            try
            {
                if (FormParent.FormMaster.NoDatabase)
                {
                    if (!blnBack)
                    {
                        #region Set Selected
                        frmRole frmNew = new frmRole();
                        frmNew.FormCalling = this;
                        frmNew.FormParent = FormParent;
                        FormParent.LoadControl(frmNew, this.Name);
                        #endregion
                    }
                }
                else
                {
                    #region Variables
                    DataAccessLayer.DBConnection dbCon = null;
                    umRole dalRole = new umRole();

                    DataTable dt = new DataTable();
                    int intArrayLength = 0;
                    string[,] arrFilter = null;
                    #endregion

                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Search
                        #region Search Criteria
                        if (cbRole.SelectedIndex != 0)
                            intArrayLength++;
                        if (txtRoleName.Text.Trim().Length != 0)
                            intArrayLength++;

                        arrFilter = new string[intArrayLength, 2];
                        intArrayLength = 0;

                        if (cbRole.SelectedIndex != 0)
                        {
                            arrFilter[intArrayLength, 0] = "rl_id";
                            arrFilter[intArrayLength, 1] = cbRole.SelectedValue.ToString();
                            intArrayLength++;
                        }

                        if (txtRoleName.Text.Trim().Length != 0)
                        {
                            arrFilter[intArrayLength, 0] = "rl_name";
                            arrFilter[intArrayLength, 1] = txtRoleName.Text.Trim();
                            intArrayLength++;
                        }
                        #endregion Search Criteria

                        dt = dalRole.GetByCriteria(arrFilter, intArrayLength, dbCon);
                        pblnSearched = true;
                        #endregion Search
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }

                    #region Load Datagrid
                    dgvRole.AutoGenerateColumns = false;
                    dgvRole.DataSource = dt;
                    #endregion
                }
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
            }
        }
        #endregion Private Methdos
    }
}
