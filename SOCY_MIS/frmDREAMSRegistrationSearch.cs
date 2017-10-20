using System;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSRegistrationSearch : UserControl
    {
        #region Variables
        private frmDREAMS frmPrt = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public frmDREAMS FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDREAMSRegistrationSearch()
        {
            InitializeComponent();
        }

        private void frmDREAMSRegistrationSearch_Load(object sender, EventArgs e)
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

        private void frmDREAMSRegistrationSearch_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFacility.SelectionLength = 0;
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

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmDREAMSRegistration frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmDREAMSRegistration();
                    frmNew.ObjectId = strID;
                    frmNew.FormCalling = this;
                    frmNew.FormMaster = FormParent.FormMaster;
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
            frmDREAMSRegistration frmNew = new frmDREAMSRegistration();
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormParent.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }
        #region Combo Boxes
        #endregion Combo Boxes
        #endregion Control Methods

        #region Public Methods
        public void BackDisplay()
        {
            if (!FormParent.FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                string strDstId = string.Empty;
                string strFltId = string.Empty;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (cbDistrict.SelectedIndex != 0)
                        strDstId = cbDistrict.SelectedValue.ToString();
                    if (cbFacility.SelectedIndex != 0)
                        strFltId = cbFacility.SelectedValue.ToString();
                    LoadLists(strDstId, strFltId, dbCon);
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
                cbDistrict.SelectedIndex = 0;
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

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            #region Load Lists
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
        }

        private void LoadLists(string strDstId, string strFltId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_district", true, strDstId, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_facility", true, strFltId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFacility, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                if (strFltId.Length != 0)
                    cbFacility.SelectedValue = strFltId;
                else
                    cbFacility.SelectedIndex = 0;
                #endregion Set List Selection
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
                drmEnrollment dalDE = new drmEnrollment();

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
                    if (cbFacility.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    if (cbDistrict.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "dst_id";
                        arrFilter[intArrayLength, 1] = cbDistrict.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbFacility.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "flt_id";
                        arrFilter[intArrayLength, 1] = cbFacility.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalDE.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
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
