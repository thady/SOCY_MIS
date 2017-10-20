using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmValueChainActorRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmValueChainActorRegisterSearch frmCll = null;
        private frmResultArea01 frmPrt = null;
        #endregion Variables

        #region Property
        public frmValueChainActorRegisterSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmResultArea01 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmValueChainActorRegister()
        {
            InitializeComponent();
        }

        private void frmValueChainActorRegister_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
                btnActorCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnActorDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnActorSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmValueChainActorRegister_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbRegion.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnActorCancel_Click(object sender, EventArgs e)
        {
            ClearActor();
        }

        private void btnActorDelete_Click(object sender, EventArgs e)
        {
            DeleteActor();
        }

        private void btnActorSave_Click(object sender, EventArgs e)
        {
            SaveActor();
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
            if (cbHHMember.SelectedIndex == 0)
                ClearMember();
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", cbCSO.SelectedValue.ToString());
        }

        private void cbPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", "");
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), "");
        }

        private void cbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsArea(cbRegion.SelectedValue.ToString(), "", "");
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbRegion.SelectedIndex == 0)
                LoadListsArea("", cbDistrict.SelectedValue.ToString(), "");
            else
                LoadListsArea(cbRegion.SelectedValue.ToString(), cbDistrict.SelectedValue.ToString(), "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", "", cbSubCounty.SelectedValue.ToString());
            else
                LoadListsArea(cbRegion.SelectedValue.ToString(), cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString());
        }

        private void dgvActors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvActors.SelectedCells.Count != 0)
                {
                    strID = dgvActors.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayActor(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvActors_CellDoubleClick", exc);
            }
        }

        private void dgvActors_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvActors.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvActors.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvActors_RowPostPaint", exc);
            }
        }
        
        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        #region Textboxes
        private void txtIDealersPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtIDealersQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtIDealersRevenue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPBuyersPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPBuyersQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPBuyersRevenue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxDecimal(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Textboxes
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbFinancialYear.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;
                    btnSave.Enabled = pblnManage;
                    LoadListsArea("", "", "");
                    LoadListsOrganization("", "");
                    #endregion Clear
                }
                else
                {
                    LoadDisplay();
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void ClearActor()
        {
            try
            {
                #region Clear Actor
                lblVcraId.Text = string.Empty;

                if(cbHHCode.Items.Count != 0)
                    cbHHCode.SelectedIndex = 0;

                txtBDSServices.Text = string.Empty;
                txtCommodity.Text = string.Empty;

                txtIDealersPrice.Text = "0";
                txtIDealersQty.Text = "0";
                txtIDealersRevenue.Text = "0";
                txtPBuyersPrice.Text = "0";
                txtPBuyersQty.Text = "0";
                txtPBuyersRevenue.Text = "0";
                btnActorSave.Enabled = pblnManage;

                LoadListsMember("", "");
                ClearMember();
                #endregion Clear Actor
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearActor", exc);
            }
        }

        private void ClearMember()
        {
            try
            {
                #region Clear Member
                if(cbHHMember.Items.Count != 0)
                    cbHHMember.SelectedIndex = 0;
                lblGenderDisplay.Text = "-";
                lblWardDisplay.Text = "-";
                #endregion Clear Member
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearMember", exc);
            }
        }

        private void DeleteActor()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benValueChainRegisterActor dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvActors.RowCount != 0)
                {
                    while (intCounter < dgvActors.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvActors.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new benValueChainRegisterActor();
                                    for (int intCount = 0; intCount < dgvActors.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvActors.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvActors.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    ClearActor();
                                    LoadDisplayActors(dbCon);
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benValueChainRegister dalSR = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadLists();
                    SetControls(false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalSR = new benValueChainRegister(ObjectId, dbCon);
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalSR.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalSR.ofc_id));
                        #endregion Load Display

                        LoadDisplayActors(dbCon);
                        LoadLists(dalSR.cso_id, dalSR.fy_id, dalSR.qy_id, dalSR.sct_id, dalSR.swk_id, dbCon);
                        SetControls(true);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayActor(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayActor(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayActor(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                benValueChainRegisterActor dalVCRA = null;
                #endregion Variables

                #region Load Display Line
                dalVCRA = new benValueChainRegisterActor(strId, dbCon);
                cbHHMember.SelectedValue = dalVCRA.hhm_id;
                LoadDisplayMember(dalVCRA.hhm_id, dbCon);

                lblVcraId.Text = strId;
                txtBDSServices.Text = dalVCRA.vcra_bds_service;
                txtCommodity.Text = dalVCRA.vcra_commodity;

                txtIDealersPrice.Text = dalVCRA.vcra_id_price.ToString();
                txtIDealersQty.Text = dalVCRA.vcra_id_qty.ToString();
                txtIDealersRevenue.Text = dalVCRA.vcra_id_revenue.ToString();
                txtPBuyersPrice.Text = dalVCRA.vcra_pb_price.ToString();
                txtPBuyersQty.Text = dalVCRA.vcra_pb_qty.ToString();
                txtPBuyersRevenue.Text = dalVCRA.vcra_pb_revenue.ToString();
                btnActorSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalVCRA.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalVCRA.ofc_id));
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayActor", exc);
            }
        }

        private void LoadDisplayActors(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                benValueChainRegister dalVCR = new benValueChainRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalVCR.GetLines(ObjectId, dbCon);
                dgvActors.AutoGenerateColumns = false;
                dgvActors.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayActors", exc);
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
                    cbHHCode.SelectedValue = dr["hh_id"].ToString();

                if (cbHHMember.SelectedValue == null || !cbHHMember.SelectedValue.ToString().Equals(strId))
                    LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);

                lblGenderDisplay.Text = dr["gnd_name"].ToString();
                lblWardDisplay.Text = dr["wrd_name"].ToString();
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

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strCsoId, string strFyId, string strQyId, string strSctId, string strSwkId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                hhHousehold dalHh = null;
                swmSocialWorker dalSwk = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");

                dalHh = new hhHousehold();
                dt = dalHh.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");

                dalSwk = new swmSocialWorker();
                if (strSwkId.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkId, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Load Lists

                #region Set List Selection
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                if (strSwkId.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkId;
                else
                    cbSocialWorker.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea("", "", strSctId, dbCon);
                LoadListsHousehold(strSctId, dbCon);
                LoadListsOrganization("", strCsoId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strRgnId, string strDstId, string strSctId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strRgnId, strDstId, strSctId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strRgnId, string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsArea(strRgnId, strDstId, strSctId, "", cbRegion, cbDistrict, cbSubCounty, null, FormParent.FormMaster.LanguageId, dbCon);
                SetControls(lblSctId.Text.Equals(strSctId));
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListsHousehold(string strDstId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsHousehold(strDstId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsHousehold(string strSctId, DataAccessLayer.DBConnection dbCon)
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
                dt = dalHH.GetListBySubCountyAndForm(strSctId, "ben_girl_education_register_child", "ger", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                #endregion Load Lists

                cbHHMember.SelectedIndex = -1;
                cbHHMember.Enabled = false;
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsHousehold", exc);
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

        private void LoadListsMember(string strHhId, string strHhmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHouseholdMember dalHHM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetList(strHhId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");

                if (strHhmId.Length == 0)
                {
                    strHhmId = dalHHM.GetMemberPrime(strHhId, dbCon);
                    cbHHMember.SelectedValue = strHhmId;
                    if (strHhmId.Equals(utilConstants.cDFEmptyListValue))
                        strHhmId = string.Empty;
                    else
                        LoadDisplayMember(strHhmId, dbCon);
                }
                cbHHMember.Enabled = true;
                #endregion Load Lists

                #region Set List Selection
                if (strHhmId.Length == 0)
                {
                    ClearMember();
                }
                else
                    cbHHMember.SelectedValue = strHhmId;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void LoadListsOrganization(string strPrtId, string strCsoId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsOrganization(strPrtId, strCsoId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsOrganization(string strPrtId, string strCsoId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables
                utilSM.LoadListsOrganization(strPrtId, strCsoId, cbPartner, cbCSO, FormParent.FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsOrganization", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benValueChainRegister dalVCR = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalVCR = new benValueChainRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalVCR.vcr_id = ObjectId;
                            dalVCR.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalVCR.Load(ObjectId, dbCon);

                        dalVCR.cso_id = cbCSO.SelectedValue.ToString();
                        dalVCR.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalVCR.qy_id = cbQuarter.SelectedValue.ToString();
                        lblSctId.Text = cbSubCounty.SelectedValue.ToString();
                        dalVCR.sct_id = cbSubCounty.SelectedValue.ToString();
                        dalVCR.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalVCR.usr_id_update = FormParent.FormMaster.UserId;

                        dalVCR.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetControls(true);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveActor()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benValueChainRegisterActor dalVCRA = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalVCRA = new benValueChainRegisterActor();

                        if (lblVcraId.Text.Length == 0 || lblVcraId.Text.Trim().Equals("-"))
                        {
                            dalVCRA.vcra_id = Guid.NewGuid().ToString();
                            dalVCRA.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalVCRA.Load(lblVcraId.Text, dbCon);

                        dalVCRA.hhm_id = cbHHMember.SelectedValue.ToString();

                        dalVCRA.vcra_bds_service = txtBDSServices.Text.Trim();
                        dalVCRA.vcra_commodity = txtCommodity.Text.Trim();

                        if (utilFormatting.IsDecimal(txtIDealersPrice.Text.Trim()))
                            dalVCRA.vcra_id_price = Convert.ToDecimal(txtIDealersPrice.Text.Trim());
                        else
                            dalVCRA.vcra_id_price = 0;
                        if (utilFormatting.IsDecimal(txtIDealersQty.Text.Trim()))
                            dalVCRA.vcra_id_qty = Convert.ToDecimal(txtIDealersQty.Text.Trim());
                        else
                            dalVCRA.vcra_id_qty = 0;
                        if (utilFormatting.IsDecimal(txtIDealersRevenue.Text.Trim()))
                            dalVCRA.vcra_id_revenue = Convert.ToDecimal(txtIDealersRevenue.Text.Trim());
                        else
                            dalVCRA.vcra_id_revenue = 0;
                        if (utilFormatting.IsDecimal(txtPBuyersPrice.Text.Trim()))
                            dalVCRA.vcra_pb_price = Convert.ToDecimal(txtPBuyersPrice.Text.Trim());
                        else
                            dalVCRA.vcra_pb_price = 0;
                        if (utilFormatting.IsDecimal(txtPBuyersQty.Text.Trim()))
                            dalVCRA.vcra_pb_qty = Convert.ToDecimal(txtPBuyersQty.Text.Trim());
                        else
                            dalVCRA.vcra_pb_qty = 0;
                        if (utilFormatting.IsDecimal(txtPBuyersRevenue.Text.Trim()))
                            dalVCRA.vcra_pb_revenue = Convert.ToDecimal(txtPBuyersRevenue.Text.Trim());
                        else
                            dalVCRA.vcra_pb_revenue = 0;

                        dalVCRA.vcr_id = ObjectId;
                        dalVCRA.usr_id_update = FormParent.FormMaster.UserId;

                        dalVCRA.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearActor();
                        LoadDisplayActors(dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveActor", exc);
            }
        }

        private void SetControls(bool blnEnabled)
        {
            btnActorCancel.Enabled = blnEnabled;
            btnActorDelete.Enabled = blnEnabled;
            btnActorSave.Enabled = blnEnabled;

            cbHHCode.Enabled = blnEnabled;
            cbHHMember.Enabled = blnEnabled;
            if (!blnEnabled)
            {
                cbHHCode.SelectedIndex = -1;
                ClearMember();
            }
            else
            {
                LoadListsHousehold(cbSubCounty.SelectedValue.ToString());
            }
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbCSO.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 || 
                cbQuarter.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormParent.FormMaster.LanguageId;
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            #endregion Get Messages

            return strMessage;
        }

        private string ValidateInputLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbHHCode.SelectedIndex == 0 || cbHHMember.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormParent.FormMaster.LanguageId;
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            #endregion Get Messages

            return strMessage;
        }
        #endregion Private

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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageValueChainActorRegistration, dbCon);
                btnActorDelete.Visible = pblnManage;
                btnActorSave.Visible = pblnManage;
                btnSave.Visible = pblnManage;
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
