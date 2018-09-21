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
    public partial class frmSILCSavingsRegister : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private int pintMemberX = 24;
        private int pintMemberY = 59;
        private string strGroupId = string.Empty;
        private string strId = string.Empty;
        private frmSILCGroup frmCllGroup = null;
        private frmSILCSavingsRegisterSearch frmCllSearch = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmSILCSavingsRegisterSearch FormCalling01
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public frmSILCGroup FormCalling02
        {
            get { return frmCllGroup; }
            set { frmCllGroup = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }

        public string SILCGroupId
        {
            get { return strGroupId; }
            set { strGroupId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmSILCSavingsRegister()
        {
            InitializeComponent();
        }

        private void frmSILCSavingsRegister_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
                SetControls(false);
            }
            else
            {
                SetPermissions();
                LoadDisplay();
                LoadListsMember("", "");
            }
        }

        private void frmSILCSavingsRegister_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbExistingMember.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
            cbSilcGroup.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                Save();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnMemberDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                SaveLine();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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

        private void cbSilcGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsLine(cbSilcGroup.SelectedValue.ToString());
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

        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvMember.SelectedCells.Count != 0)
                {
                    strID = dgvMember.SelectedCells[0].OwningRow.Cells["gclId"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMember_CellDoubleClick", exc);
            }
        }

        private void dgvMember_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvMember.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvMember.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMember_RowPostPaint", exc);
            }
        }

        private void rbtnGroupMemberExisting_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers();
        }

        private void rbtnGroupMemberExternal_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers();
        }

        private void rbtnGroupMemberHousehold_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers();
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            if (FormCalling01 != null)
            {
                FormCalling01.BackDisplay();
                FormCalling01.FormParent.LoadControl(FormCalling01, this.Name);
            }
            else if (FormCalling02 != null)
            {
                FormCalling02.BackDisplay();
                FormCalling02.FormParent.LoadControl(FormCalling02, this.Name);
            }
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbCSO.SelectedIndex = 0;
                    cbFinancialYear.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    lblSgId.Text = string.Empty;
                    cbSilcGroup.SelectedIndex = 0;
                    LoadListsArea("", "", "");

                    txtCycleNumber.Text = string.Empty;
                    txtShares.Text = string.Empty;
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblSsrmId.Text = string.Empty;

                cbExistingMember.SelectedIndex = 0;
                txtExternalMember.Text = string.Empty;
                cbHHCode.SelectedIndex = 0;
                LoadListsMember("", "");
                LoadListsExistingMembers(SILCGroupId);

                txtBoughtToday.Text = string.Empty;
                txtBroughtForward.Text = string.Empty;
                txtSharesRedeemed.Text = string.Empty;
                txtSharesTotal.Text = string.Empty; ;
                txtWelfareFund.Text = string.Empty;
                btnMemberSave.Enabled = pblnManage;
                SetMemberControls(true);
                #endregion Clear Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void DeleteLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcSavingsRegisterMember dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvMember.RowCount != 0)
                {
                    while (intCounter < dgvMember.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvMember.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new silcSavingsRegisterMember();
                                    for (int intCount = 0; intCount < dgvMember.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvMember.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvMember.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    ClearLine();
                                    LoadDisplayLines(dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcSavingsRegister dalSSR = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    if (SILCGroupId.Length != 0)
                        LoadLists(SILCGroupId);
                    else
                        LoadLists("");
                    SetControls(false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalSSR = new silcSavingsRegister(ObjectId, dbCon);
                        txtCycleNumber.Text = dalSSR.ssr_cycle_number;
                        txtShares.Text = dalSSR.ssr_share_value.ToString();
                        lblSgId.Text = dalSSR.sg_id;
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSSR.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSSR.ofc_id));
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalSSR.cso_id, dalSSR.fy_id, dalSSR.qy_id, dalSSR.sg_id, dalSSR.wrd_id, dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayLine(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLine(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLine(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                silcSavingsRegisterMember dalSSRM = null;
                #endregion Variables

                #region Load Display Line
                dalSSRM = new silcSavingsRegisterMember(strId, dbCon);

                lblSsrmId.Text = strId;

                LoadListsExistingMembers(SILCGroupId, dalSSRM.sgm_id, dbCon);
                txtExternalMember.Text = string.Empty;
                cbHHCode.SelectedIndex = 0;
                LoadListsMember("", "", dbCon);

                txtBoughtToday.Text = dalSSRM.ssrm_shares_bought_today.ToString();
                txtBroughtForward.Text = dalSSRM.ssrm_shares_brought_forward.ToString();
                txtSharesRedeemed.Text = dalSSRM.ssrm_shares_redeemed.ToString();
                txtSharesTotal.Text = dalSSRM.ssrm_shares_total.ToString();
                txtWelfareFund.Text = dalSSRM.ssrm_welfare_fund;
                btnMemberSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSSRM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSSRM.ofc_id));

                rbtnGroupMemberExisting.Checked = true;
                SetMemberControls(false);
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
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
                dt = dalHhm.GetMember(strId, FormMaster.LanguageId, dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayMember", exc);
            }
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                silcSavingsRegister dalSSR = new silcSavingsRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalSSR.GetLines(ObjectId, FormMaster.LanguageId, dbCon);

                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
            }
        }

        private void LoadLists(string strSgId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", strSgId, "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strCsoId, string strFyId, string strQyId, string strSgId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                silcGroup dalSG = null;

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

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_quarter_year", true, strQyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbQuarter, dt, "lt_id", "lt_name");

                dalSG = new silcGroup();
                dt = dalSG.GetList(dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "sg_id", "sg_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSilcGroup, dt, "sg_id", "sg_name");
                #endregion Load Lists

                #region Set List Selection
                if (strCsoId.Length != 0)
                    cbCSO.SelectedValue = strCsoId;
                else
                    cbCSO.SelectedIndex = 0;
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strQyId.Length != 0)
                    cbQuarter.SelectedValue = strQyId;
                else
                    cbQuarter.SelectedIndex = 0;
                if (strSgId.Length != 0)
                    cbSilcGroup.SelectedValue = strSgId;
                else
                    cbSilcGroup.SelectedIndex = 0;
                #endregion Set List Selection
                LoadListsArea("", "", strWrdId, dbCon);
                LoadListsLine(strSgId, dbCon);
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

        private void LoadListsExistingMembers(string strSgID)
        {
            LoadListsExistingMembers(strSgID, "");
        }

        private void LoadListsExistingMembers(string strSgID, string strSgmId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsExistingMembers(strSgID, strSgmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsExistingMembers(string strSgID, string strSgmId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                silcGroup dalSG = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalSG = new silcGroup();
                dt = dalSG.GetMembersForForm(strSgID, strSgmId, "silc_savings_register_member", "ssr", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "sgm_id", "member_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbExistingMember, dt, "sgm_id", "member_name");
                #endregion Load Lists

                if (strSgmId.Length != 0)
                    cbExistingMember.SelectedValue = strSgmId;
                else
                    cbExistingMember.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsExistingMembers", exc);
            }
        }

        private void LoadListsLine(string strSgID)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strSgID, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strSgID, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHh = new hhHousehold();
                dt = dalHh.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");

                LoadListsExistingMembers(strSgID, "", dbCon);
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHhm = new hhHouseholdMember();
                dt = dalHhm.GetListForForm(strHHId, strHhmId, "silc_group_member", "sg", SILCGroupId, dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcSavingsRegister dalSSR = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSSR = new silcSavingsRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalSSR.ssr_id = ObjectId;
                            dalSSR.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSSR.Load(ObjectId, dbCon);

                        dalSSR.ssr_cycle_number = txtCycleNumber.Text.Trim();

                        if (utilFormatting.IsDecimal(txtShares.Text.Trim()))
                            dalSSR.ssr_share_value = Convert.ToDecimal(txtShares.Text.Trim());
                        else
                            dalSSR.ssr_share_value = 0;

                        dalSSR.cso_id = cbCSO.SelectedValue.ToString();
                        dalSSR.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalSSR.qy_id = cbQuarter.SelectedValue.ToString();
                        lblSgId.Text = cbSilcGroup.SelectedValue.ToString();
                        dalSSR.sg_id = cbSilcGroup.SelectedValue.ToString();
                        dalSSR.wrd_id = cbWard.SelectedValue.ToString();
                        dalSSR.usr_id_update = FormMaster.UserId;

                        dalSSR.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
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

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcSavingsRegisterMember dalSSRM = null;
                silcGroupMember dalSGM = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                string strSgmId = string.Empty;
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        if (!rbtnGroupMemberExisting.Checked)
                        {
                            dalSGM = new silcGroupMember();

                            if (rbtnGroupMemberExternal.Checked)
                            {
                                strSgmId = Guid.NewGuid().ToString();
                                dalSGM.sgm_name = txtExternalMember.Text.Trim();
                                dalSGM.hhm_id = utilConstants.cDFEmptyListValue;
                                dalSGM.mtp_id = utilConstants.cMTExternal;
                            }
                            else if (rbtnGroupMemberHousehold.Checked)
                            {
                                strSgmId = cbHHMember.SelectedValue.ToString();
                                dalSGM.sgm_name = string.Empty;
                                dalSGM.hhm_id = strSgmId;
                                dalSGM.mtp_id = utilConstants.cMTHousehold;
                            }

                            dalSGM.sg_id = lblSgId.Text;
                            dalSGM.sgm_id = strSgmId;
                            dalSGM.ofc_id = FormMaster.OfficeId;
                            dalSGM.usr_id_update = FormMaster.UserId;

                            dalSGM.Save(dbCon);
                        }
                        else
                            strSgmId = cbExistingMember.SelectedValue.ToString();

                        dalSSRM = new silcSavingsRegisterMember();

                        if (lblSsrmId.Text.Length == 0 || lblSsrmId.Text.Trim().Equals("-"))
                        {
                            dalSSRM.ssrm_id = Guid.NewGuid().ToString();
                            dalSSRM.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSSRM.Load(lblSsrmId.Text, dbCon);

                        dalSSRM.ssrm_welfare_fund = txtWelfareFund.Text.Trim();

                        if (utilFormatting.IsDecimal(txtBoughtToday.Text))
                            dalSSRM.ssrm_shares_bought_today = Convert.ToDecimal(txtBoughtToday.Text.Trim());
                        else
                            dalSSRM.ssrm_shares_bought_today = 0;
                        if (utilFormatting.IsDecimal(txtBroughtForward.Text))
                            dalSSRM.ssrm_shares_brought_forward = Convert.ToDecimal(txtBroughtForward.Text.Trim());
                        else
                            dalSSRM.ssrm_shares_brought_forward = 0;
                        if (utilFormatting.IsDecimal(txtSharesRedeemed.Text))
                            dalSSRM.ssrm_shares_redeemed = Convert.ToDecimal(txtSharesRedeemed.Text.Trim());
                        else
                            dalSSRM.ssrm_shares_redeemed = 0;
                        if (utilFormatting.IsDecimal(txtSharesTotal.Text))
                            dalSSRM.ssrm_shares_total = Convert.ToDecimal(txtSharesTotal.Text.Trim());
                        else
                            dalSSRM.ssrm_shares_total = 0;

                        dalSSRM.ssr_id = ObjectId;
                        dalSSRM.sgm_id = strSgmId;
                        dalSSRM.usr_id_update = FormMaster.UserId;

                        dalSSRM.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
                        LoadListsLine(lblSgId.Text, dbCon);
                    }
                    catch (Exception exc)
                    {
                        dbCon.TransactionRollback();
                        throw exc;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
        }

        private void SetControls(bool blnEnabled)
        {
            btnMemberCancel.Enabled = blnEnabled;
            btnMemberDelete.Enabled = blnEnabled;
            btnMemberSave.Enabled = blnEnabled;
        }

        private void SetMemberControls(bool blnEnabled)
        {
            rbtnGroupMemberExisting.Enabled = blnEnabled;
            rbtnGroupMemberExternal.Enabled = blnEnabled;
            rbtnGroupMemberHousehold.Enabled = blnEnabled;
        }

        private void SetMembers()
        {
            if (rbtnGroupMemberExisting.Checked)
            {
                tlpMemberExisting.Visible = true;
                tlpMemberExternal.Visible = false;
                tlpMemberHousehold.Visible = false;
            }
            else if (rbtnGroupMemberExternal.Checked)
            {
                tlpMemberExisting.Visible = false;
                tlpMemberExternal.Visible = true;
                tlpMemberHousehold.Visible = false;
            }
            else if (rbtnGroupMemberHousehold.Checked)
            {
                tlpMemberExisting.Visible = false;
                tlpMemberExternal.Visible = false;
                tlpMemberHousehold.Visible = true;
            }

            tlpMemberExisting.Location = new Point(pintMemberX, pintMemberY);
            tlpMemberExternal.Location = new Point(pintMemberX, pintMemberY);
            tlpMemberHousehold.Location = new Point(pintMemberX, pintMemberY);
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
            if (cbCSO.SelectedIndex == 0 || cbDistrict.SelectedIndex == 0 || cbSubCounty.SelectedIndex == 0 || cbWard.SelectedIndex == 0 ||
                cbFinancialYear.SelectedIndex == 0 || cbQuarter.SelectedIndex == 0 || cbSilcGroup.SelectedIndex == 0)
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
                    utilLT.Language = FormMaster.LanguageId;
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

            bool blnRequired = false;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (rbtnGroupMemberExisting.Checked && cbExistingMember.SelectedIndex == 0)
                blnRequired = true;
            else if (rbtnGroupMemberExternal.Checked && txtExternalMember.Text.Trim().Length == 0)
                blnRequired = true;
            else if (rbtnGroupMemberHousehold.Checked && cbHHMember.SelectedIndex == 0)
                blnRequired = true;

            if (blnRequired)
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
                    utilLT.Language = FormMaster.LanguageId;
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageSILCSavingsRegister, dbCon);
                btnMemberDelete.Visible = pblnManage;
                btnMemberSave.Visible = pblnManage;
                btnSave.Visible = pblnManage;
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
