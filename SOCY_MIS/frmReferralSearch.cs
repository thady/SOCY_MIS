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
    public partial class frmReferralSearch : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private frmResultArea03 frmPrt = null;
        private bool pblnSearched = false;
        #endregion Variables

        #region Property
        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        #region Form Methods
        public frmReferralSearch()
        {
            InitializeComponent();
        }

        private void frmReferralSearch_Load(object sender, EventArgs e)
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
                LoadListsMember("", "");
                Clear();
            }
        }

        private void frmReferralSearch_Paint(object sender, PaintEventArgs e)
        {
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
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

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                LoadListsMember("", "");
            else
                LoadListsMember(cbHHCode.SelectedValue.ToString(), "");
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmReferral frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();

                    frmNew = new frmReferral();
                    frmNew.ObjectId = strID;
                    frmNew.FormCallingSearch = this;
                    frmNew.FormParent = FormParent;
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
            frmReferral frmNew = new frmReferral();
            frmNew.FormCallingSearch = this;
            frmNew.FormParent = FormParent;
            frmNew.FormMaster = FormParent.FormMaster;
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
                string strHhId = string.Empty;
                string strHhmId = string.Empty;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (cbHHCode.SelectedIndex != 0)
                        strHhId = cbHHCode.SelectedValue.ToString();
                    if (cbHHMember.SelectedIndex != 0)
                        strHhmId = cbHHMember.SelectedValue.ToString();
                    LoadLists(strHhId, dbCon);
                    LoadListsMember(strHhId, strHhmId, dbCon);
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
                hhReferral dalRFR = null;
                #endregion Variables

                #region Clear
                cbHHCode.SelectedIndex = 0;
                cbHHCode.SelectedIndex = 0;
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    LoadListsMember("", "", dbCon);

                    #region Set Dates
                    dalRFR = new hhReferral();
                    dt = dalRFR.GetDateRange(dbCon);
                    dtpDateFrom.Value = Convert.ToDateTime(dt.Rows[0]["rfr_date_begin"]);
                    dtpDateTo.Value = Convert.ToDateTime(dt.Rows[0]["rfr_date_end"]);
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
                hhReferral dalDel = null;
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
                                    dalDel = new hhReferral();
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

        private void LoadDisplayMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayMember(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayMember(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHouseholdMember dalHhm = new hhHouseholdMember();
                DataRow dr = null;
                DataTable dt = null;
                #endregion Variables

                #region Load Display Line
                dt = dalHhm.GetMember(strId, FormParent.FormMaster.LanguageId, dbCon);
                dr = dt.Rows[0];

                if (!cbHHCode.SelectedValue.ToString().Equals(dr["hh_id"].ToString()))
                {
                    cbHHCode.SelectedValue = dr["hh_id"].ToString();
                    LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);
                }
                cbHHMember.SelectedValue = strId;
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayMember", exc);
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

        private void LoadLists(string strHhId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHh = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHh = new hhHousehold();
                dt = dalHh.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                #endregion Load Lists

                #region Set List Selection
                if (strHhId.Length != 0)
                    cbHHCode.SelectedValue = strHhId;
                else
                    cbHHCode.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsMember(string strHhId, string strHhmId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMember(strHhId, strHhmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMember(string strHHId, string strHhmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHouseholdMember dalHhm = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHhm = new hhHouseholdMember();
                dt = dalHhm.GetList(strHHId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                #endregion Load Lists

                #region Set List Selection
                if (strHhmId.Length != 0)
                    cbHHMember.SelectedValue = strHhmId;
                else
                    cbHHMember.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void Search()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhReferral dalRFR = new hhReferral();

                DataTable dt = new DataTable();
                int intArrayLength = 2;
                string[,] arrFilter = null;
                #endregion

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Search
                    #region Search Criteria
                    if (cbHHCode.SelectedIndex != 0)
                        intArrayLength++;
                    if (cbHHMember.SelectedIndex != 0)
                        intArrayLength++;

                    arrFilter = new string[intArrayLength, 2];
                    intArrayLength = 0;

                    arrFilter[intArrayLength, 0] = "rfr_date_begin";
                    arrFilter[intArrayLength, 1] = dtpDateFrom.Value.ToString("dd MMM yyyy");
                    intArrayLength++;
                    arrFilter[intArrayLength, 0] = "rfr_date_end";
                    arrFilter[intArrayLength, 1] = dtpDateTo.Value.ToString("dd MMM yyyy");
                    intArrayLength++;

                    if (cbHHCode.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "hh_id";
                        arrFilter[intArrayLength, 1] = cbHHCode.SelectedValue.ToString();
                        intArrayLength++;
                    }

                    if (cbHHMember.SelectedIndex != 0)
                    {
                        arrFilter[intArrayLength, 0] = "hhm_id";
                        arrFilter[intArrayLength, 1] = cbHHMember.SelectedValue.ToString();
                        intArrayLength++;
                    }
                    #endregion Search Criteria

                    dt = dalRFR.GetByCriteria(arrFilter, intArrayLength, FormParent.FormMaster.LanguageId, dbCon);
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageReferrals, dbCon);
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
