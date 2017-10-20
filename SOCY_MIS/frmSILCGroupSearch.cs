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
    public partial class frmSILCGroupSearch : UserControl
    {
        #region Variables
        private Master frmMST = null;
        private frmSILC frmPrt = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmSILC FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmSILCGroupSearch()
        {
            InitializeComponent();
        }

        private void frmSILCGroupSearch_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSearch.Enabled = !FormMaster.NoDatabase;
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
            Search();
        }

        private void dgvGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmSILCGroup frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvGroup.SelectedCells.Count != 0)
                {
                    strID = dgvGroup.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmSILCGroup();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormMaster = FormMaster;
                    frmNew.FormParent = FormParent;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvGroup", exc);
            }
        }

        private void llblNewGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmSILCGroup frmNew = new frmSILCGroup();
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            frmNew.FormParent = FormParent;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }
        #endregion Control Methods

        #region Public Methods
        public void BackDisplay()
        {
            if (!FormMaster.NoDatabase)
            {
                if (pblnSearched)
                    Search();
            }
        }
        #endregion Public Methods

        #region Private Methods
        private void Clear()
        {
            txtSILCGroup.Text = string.Empty;
        }

        private void Search()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcGroup dalSG = new silcGroup();

                DataTable dt = new DataTable();
                int intArrayLength = 0;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (txtSILCGroup.Text.Trim().Length != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    if (txtSILCGroup.Text.Trim().Length != 0)
                    {
                        arrFilter[intArrayLength, 0] = "sg_name";
                        arrFilter[intArrayLength, 1] = txtSILCGroup.Text.Trim();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalSG.GetByCriteria(arrFilter, intArrayLength, FormMaster.LanguageId, dbCon);
                    pblnSearched = true;
                    #endregion Search
                }
                finally
                {
                    dbCon.Dispose();
                }

                #region Load Datagrid
                dgvGroup.AutoGenerateColumns = false;
                dgvGroup.DataSource = dt;
                #endregion
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Search", exc);
            }
        }
        #endregion Private Methods
    }
}
