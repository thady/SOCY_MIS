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
    public partial class frmApprenticeship : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmApprenticeshipSearch frmCll = null;
        private frmResultArea01 frmPrt = null;
        #endregion Variables

        #region Property
        public frmApprenticeshipSearch FormCalling
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
        public frmApprenticeship()
        {
            InitializeComponent();
        }

        private void frmApprenticeship_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmApprenticeship_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbApprenticeshipPartner.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsHousehold("", "", "");
            else
                LoadListsHousehold(cbDistrict.SelectedValue.ToString(), "", "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsHousehold("", cbSubCounty.SelectedValue.ToString(), "");
            else
                LoadListsHousehold(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
        }

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                LoadListsMember("", "");
            else
                LoadListsMember(cbHHCode.SelectedValue.ToString(), lblHhmId.Text);
            ClearMember();
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedIndex == 0)
                ClearMember();
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void dgvApprentice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvApprentice.SelectedCells.Count != 0)
                {
                    strID = dgvApprentice.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvApprentice_CellDoubleClick", exc);
            }
        }

        private void dgvApprentice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvApprentice.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvApprentice.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvApprentice_RowPostPaint", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblAprlId.Text = string.Empty;
                lblHhmId.Text = string.Empty;

                cbHHCode.SelectedIndex = 0;
                cbApprenticeshipPartner.SelectedIndex = 0;

                txtEnterprise.Text = string.Empty;

                dtpDateBegin.Value = DateTime.Now;
                dtpDateComplete.Value = DateTime.Now;

                LoadListsLine("", "");
                LoadListsMember("", lblHhmId.Text);
                ClearMember();
                btnSave.Enabled = pblnManage;
                #endregion Clear Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void ClearMember()
        {
            try
            {
                #region Clear Member
                cbHHMember.SelectedIndex = 0;
                lblGenderDisplay.Text = "-";
                lblYearOfBirthDisplay.Text = "-";
                #endregion Clear Member
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearMember", exc);
            }
        }

        private void DeleteLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benApprenticeshipRegisterLine dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvApprentice.RowCount != 0)
                {
                    while (intCounter < dgvApprentice.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvApprentice.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new benApprenticeshipRegisterLine();
                                    for (int intCount = 0; intCount < dgvApprentice.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvApprentice.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvApprentice.Rows[intCount].Cells["gclID"].Value.ToString();
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

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    LoadDisplayLines(dbCon);
                    LoadLists(dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
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
                benApprenticeshipRegisterLine dalARL = null;
                #endregion Variables

                #region Load Display Line
                dalARL = new benApprenticeshipRegisterLine(strId, dbCon);
                cbHHMember.SelectedValue = dalARL.hhm_id;
                LoadDisplayMember(dalARL.hhm_id, dbCon);
                LoadListsLine(dalARL.apt_id, dalARL.cso_id);

                lblAprlId.Text = strId;
                txtEnterprise.Text = dalARL.aprl_enterprise;
                dtpDateBegin.Value = dalARL.aprl_date_begin;
                dtpDateComplete.Value = dalARL.aprl_date_complete;
                btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalARL.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalARL.ofc_id)) ;
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
            }
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                benApprenticeshipRegisterLine dalARL = new benApprenticeshipRegisterLine();
                #endregion Variables

                #region Load Display Lines
                dt = dalARL.GetLines(ObjectId, dbCon);
                dgvApprentice.AutoGenerateColumns = false;
                dgvApprentice.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
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

                lblHhmId.Text = strId;


                if (!cbHHCode.SelectedValue.ToString().Equals(dr["hh_id"].ToString()))
                {
                    LoadListsHousehold("", dr["sct_id"].ToString(), dr["hh_id"].ToString(), dbCon);
                    LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);
                }
                cbHHCode.SelectedValue = dr["hh_id"].ToString();
                LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);

                cbHHMember.SelectedValue = strId;
                if (dr["gnd_name"].ToString().Equals(utilConstants.cDFEmptyListValue))
                    lblGenderDisplay.Text = "-";
                else
                lblGenderDisplay.Text = dr["gnd_name"].ToString();
                if (dr["hhm_year_of_birth"].ToString().Equals(utilConstants.cDFEmptyListValue))
                    lblYearOfBirthDisplay.Text = "-";
                else
                    lblYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
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
                LoadLists(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(DataAccessLayer.DBConnection dbCon)
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

                LoadListsLine("", "", dbCon);
                LoadListsHousehold("", "", "", dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsLine(string strAptId, string strCsoId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strAptId, strCsoId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strAptId, string strCsoId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_apprenticeship_partner", true, strAptId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbApprenticeshipPartner, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_cso", true, strCsoId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbCSO, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strAptId.Length != 0)
                    cbApprenticeshipPartner.SelectedValue = strAptId;
                else
                    cbApprenticeshipPartner.SelectedIndex = 0;
                if (strCsoId.Length != 0)
                    cbCSO.SelectedValue = strCsoId;
                else
                    cbCSO.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void LoadListsArea(string strDstId, string strSctId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea(strDstId, strSctId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilSOCY_MIS utilSM = new utilSOCY_MIS();
                #endregion Variables

                utilSM.LoadListsArea(strDstId, strSctId, "", cbDistrict, cbSubCounty, null, FormParent.FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListsHousehold(string strDstId, string strSctId, string strHhId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsHousehold(strDstId, strSctId, strHhId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsHousehold(string strDstId, string strSctId, string strHhId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilSOCY_MIS utilSM = null;
                hhHousehold dalHh = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                LoadListsArea(strDstId, strSctId, dbCon);

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHh = new hhHousehold();
                if (strSctId.Length == 0)
                    strSctId = "BLANK";
                dt = dalHh.GetListBySubCounty(strSctId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                
                utilSM = new utilSOCY_MIS();
                dt = utilSM.BlankDataTable("hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                #endregion Load Lists

                #region Set List Selection
                if (strHhId.Length == 0)
                    cbHHCode.SelectedIndex = 0;
                else
                    cbHHCode.SelectedValue = strHhId;
                #endregion Set List Selection
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
                dt = dalHhm.GetListForForm(strHHId, strHhmId, "ben_apprenticeship_register_line", "apr", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benApprenticeshipRegisterLine dalARL = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalARL = new benApprenticeshipRegisterLine();
                        if(ObjectId.Length == 0)
                            ObjectId = Guid.NewGuid().ToString();

                        if (lblAprlId.Text.Length == 0 || lblAprlId.Text.Trim().Equals("-"))
                        {
                            dalARL.aprl_id = Guid.NewGuid().ToString();
                            dalARL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalARL.Load(lblAprlId.Text, dbCon);

                        dalARL.hhm_id = cbHHMember.SelectedValue.ToString();
                        dalARL.aprl_enterprise = txtEnterprise.Text.Trim();
                        dalARL.aprl_date_begin = dtpDateBegin.Value;
                        dalARL.aprl_date_complete = dtpDateComplete.Value;
                        dalARL.apr_id = ObjectId;
                        dalARL.apt_id = cbApprenticeshipPartner.SelectedValue.ToString();
                        dalARL.cso_id = cbCSO.SelectedValue.ToString();
                        dalARL.hhm_id = cbHHMember.SelectedValue.ToString();
                        dalARL.usr_id_update = FormParent.FormMaster.UserId;

                        dalARL.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearLine();
                        LoadDisplayLines(dbCon);
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
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
            if (cbHHMember.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageApprentishipRegister, dbCon);
                btnDelete.Visible = pblnManage;
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
