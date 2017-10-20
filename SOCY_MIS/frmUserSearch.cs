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
    public partial class frmUserSearch : UserControl
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
        public frmUserSearch()
        {
            InitializeComponent();
        }

        private void frmUserSearch_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSearch.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                LoadLists();
            }
        }
        #endregion Form Methods

        #region Control Metods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmUser frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvUser.SelectedCells.Count != 0)
                {
                    strID = dgvUser.SelectedCells[0].OwningRow.Cells["gclUserID"].Value.ToString();

                    frmNew = new frmUser();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvUser", exc);
            }
        }

        private void llblNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                frmUser frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                frmNew = new frmUser();
                frmNew.FormCalling = this;
                frmNew.FormParent = FormParent;
                FormParent.LoadControl(frmNew, this.Name);
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblNewUser", exc);
            }
        }
        #endregion Control Metods

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
                    LoadLists(cbUser.SelectedValue.ToString(), dbCon);
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
                cbUser.SelectedIndex = 0;
                txtEmail.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                dgvUser.AutoGenerateColumns = false;
                dgvUser.DataSource = new DataTable();
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

        private void LoadLists(string strUsrId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                umUser dalUsr = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalUsr = new umUser();
                dt = dalUsr.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "usr_id", "usr_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbUser, dt, "usr_id", "usr_name");
                #endregion Load Lists

                #region Set Value
                if (strUsrId.Length != 0)
                    cbUser.SelectedValue = strUsrId;
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
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                umUser dalUsr = new umUser();

                DataTable dt = new DataTable();
                int intArrayLength = 0;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbUser.SelectedIndex != 0)
                        intArrayLength++;
                    if (txtFirstName.Text.Trim().Length != 0)
                        intArrayLength++;
                    if (txtLastName.Text.Trim().Length != 0)
                        intArrayLength++;
                    if (txtEmail.Text.Trim().Length != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    if (cbUser.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "usr_id";
                        arrFilter[intArrayLength, 1] = cbUser.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (txtFirstName.Text.Trim().Length != 0)
                    {
                        arrFilter[intArrayLength, 0] = "usr_first_name";
                        arrFilter[intArrayLength, 1] = txtFirstName.Text.Trim();
                        intArrayLength++;
                    }

                    if (txtLastName.Text.Trim().Length != 0)
                    {
                        arrFilter[intArrayLength, 0] = "usr_last_name";
                        arrFilter[intArrayLength, 1] = txtLastName.Text.Trim();
                        intArrayLength++;
                    }

                    if (txtEmail.Text.Trim().Length != 0)
                    {
                        arrFilter[intArrayLength, 0] = "usr_email";
                        arrFilter[intArrayLength, 1] = txtEmail.Text.Trim();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalUsr.GetByCriteria(arrFilter, intArrayLength, dbCon);
                    pblnSearched = true;
                    #endregion Search
                }
                finally
                {
                    dbCon.Dispose();
                }

                #region Load Datagrid
                dgvUser.AutoGenerateColumns = false;
                dgvUser.DataSource = dt;
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
