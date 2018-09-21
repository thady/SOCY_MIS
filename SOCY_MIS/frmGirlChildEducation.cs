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
    public partial class frmGirlChildEducation : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmGirlChildEducationSearch frmCll = null;
        private frmResultArea01 frmPrt = null;
        #endregion Variables

        #region Property
        public frmGirlChildEducationSearch FormCalling
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
        public frmGirlChildEducation()
        {
            InitializeComponent();
        }

        private void frmGirlChildEducation_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
                btnChildCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnChildSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmGirlChildEducation_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbEducationLevel.SelectionLength = 0;
            cbFinancialSupport.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbQuarter.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
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

        private void btnChildCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnChildDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnChildSave_Click(object sender, EventArgs e)
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

        private void cbCgvHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCgvHHMember.SelectedIndex == 0)
                ClearCaregiver();
            else
                LoadDisplayMember("", cbCgvHHMember.SelectedValue.ToString());
        }

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                ClearHousehold();
            else
                LoadDisplayHousehold(cbHHCode.SelectedValue.ToString());
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedIndex == 0)
                ClearMember();
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString(), "");
        }

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", cbCSO.SelectedValue.ToString());
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), cbCSO.SelectedValue.ToString());
        }

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", "");
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "");
        }

        private void cbPartner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPartner.SelectedIndex == 0)
                LoadListsOrganization("", "");
            else
                LoadListsOrganization(cbPartner.SelectedValue.ToString(), "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsArea("", cbSubCounty.SelectedValue.ToString());
            else
                LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString());
        }

        private void dgvChild_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvChild.SelectedCells.Count != 0)
                {
                    strID = dgvChild.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvChild_CellDoubleClick", exc);
            }
        }

        private void dgvChild_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvChild.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvChild.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvChild_RowPostPaint", exc);
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

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbCSO.SelectedIndex = 0;
                    cbDistrict.SelectedIndex = 0;
                    cbPartner.SelectedIndex = 0;
                    cbQuarter.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbSocialWorker.SelectedIndex = 0;
                    txtContactDetails.Text = string.Empty;
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

        private void ClearHousehold()
        {
            try
            {
                #region Clear
                cbHHCode.SelectedIndex = 0;
                lblVillageDisplay.Text = string.Empty;
                lblWardDisplay.Text = string.Empty;

                LoadListsMember("", "", "");
                ClearCaregiver();
                ClearMember();
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearHousehold", exc);
            }
        }

        private void ClearLine()
        {
            try
            {
                #region Clear
                lblGercId.Text = string.Empty;
                cbEducationLevel.SelectedIndex = 0;
                cbFinancialSupport.SelectedIndex = 0;
                txtSupportInstitution.Text = string.Empty;

                ClearHousehold();
                btnChildSave.Enabled = pblnManage;
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearLine", exc);
            }
        }

        private void ClearCaregiver()
        {
            try
            {
                #region Clear Member
                if (cbCgvHHMember.Items.Count != 0)
                    cbCgvHHMember.SelectedIndex = 0;
                lblCgvGenderDisplay.Text = "-";
                lblCgvYearOfBirthDisplay.Text = "-";
                #endregion Clear Member
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearCaregiver", exc);
            }
        }

        private void ClearMember()
        {
            try
            {
                #region Clear Member
                if(cbHHMember.Items.Count != 0)
                    cbHHMember.SelectedIndex = 0;
                lblHHGenderDisplay.Text = "-";
                lblHHYearOfBirthDisplay.Text = "-";
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
                benGirlEducationRegisterChild dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvChild.RowCount != 0)
                {
                    while (intCounter < dgvChild.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvChild.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new benGirlEducationRegisterChild();
                                    for (int intCount = 0; intCount < dgvChild.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvChild.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvChild.Rows[intCount].Cells["gclID"].Value.ToString();
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "DeleteLine", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                benGirlEducationRegister dalGER = null;
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
                        dalGER = new benGirlEducationRegister(ObjectId, dbCon);
                        txtContactDetails.Text = dalGER.ger_contact_details;
                        #endregion Load Display

                        LoadLists(dalGER.cso_id, dalGER.fy_id, dalGER.qy_id, dalGER.sct_id, dalGER.swk_id, dbCon);
                        LoadListsHousehold(dalGER.sct_id);
                        LoadDisplayLines(dbCon);
                        SetControls(true);
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalGER.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalGER.ofc_id));
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

        private void LoadDisplayHousehold(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayHousehold(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayHousehold(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHousehold dalHh = new hhHousehold();
                DataRow dr = null;
                DataTable dt = null;
                #endregion Variables

                #region Load Display Line
                dt = dalHh.GetHousehold(strId, FormParent.FormMaster.LanguageId, dbCon);
                dr = dt.Rows[0];

                lblVillageDisplay.Text = dr["hh_village"].ToString();
                lblWardDisplay.Text = dr["wrd_name"].ToString();
                LoadListsMember(strId, "", "", dbCon);
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayHousehold", exc);
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
                benGirlEducationRegisterChild dalGERC = null;
                #endregion Variables

                #region Load Display Line
                dalGERC = new benGirlEducationRegisterChild(strId, dbCon);
                cbHHMember.SelectedValue = dalGERC.hhm_id;
                LoadDisplayMember(dalGERC.hhm_id, dalGERC.hhm_id_caregiver, dbCon);

                lblGercId.Text = strId;
                txtSupportInstitution.Text = dalGERC.gerc_support_institution;

                LoadListsLine(dalGERC.edu_id, dalGERC.fst_id, dbCon);
                btnChildSave.Enabled = (pblnManage && FormParent.FormMaster.OfficeId.Equals(dalGERC.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalGERC.ofc_id));
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
                benGirlEducationRegister dalGER = new benGirlEducationRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalGER.GetLines(ObjectId, dbCon);
                dgvChild.AutoGenerateColumns = false;
                dgvChild.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
            }
        }

        private void LoadDisplayMember(string strId, string strIdCaregiver)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayMember(strId, strIdCaregiver, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayMember(string strId, string strIdCaregiver, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHouseholdMember dalHhm = new hhHouseholdMember();
                DataRow dr = null;
                DataTable dt = null;
                #endregion Variables

                #region Load Display Line
                if (strId.Length != 0)
                {
                    dt = dalHhm.GetMember(strId, FormParent.FormMaster.LanguageId, dbCon);
                    dr = dt.Rows[0];

                    if (!cbHHCode.SelectedValue.ToString().Equals(dr["hh_id"].ToString()))
                        cbHHCode.SelectedValue = dr["hh_id"].ToString();

                    if (cbHHMember.SelectedValue == null || !cbHHMember.SelectedValue.ToString().Equals(strId))
                        LoadListsMember(dr["hh_id"].ToString(), strId, strIdCaregiver, dbCon);

                    cbHHMember.SelectedValue = strId;

                    if (dr["gnd_name"].ToString().Equals(utilConstants.cDFEmptyListValue))
                        lblHHGenderDisplay.Text = "-";
                    else
                        lblHHGenderDisplay.Text = dr["gnd_name"].ToString();

                    if (dr["hhm_year_of_birth"].ToString().Equals(utilConstants.cDFEmptyListValue))
                        lblHHYearOfBirthDisplay.Text = "-";
                    else
                        lblHHYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
                }
                #endregion Load Display Line

                #region Load Display Line Caregiver
                if (strIdCaregiver.Length != 0)
                {
                    dt = dalHhm.GetMember(strIdCaregiver, FormParent.FormMaster.LanguageId, dbCon);
                    dr = dt.Rows[0];
                    cbCgvHHMember.SelectedValue = strIdCaregiver;

                    if (dr["gnd_name"].ToString().Equals(utilConstants.cDFEmptyListValue))
                        lblCgvGenderDisplay.Text = "-";
                    else
                        lblCgvGenderDisplay.Text = dr["gnd_name"].ToString();

                    if (dr["hhm_year_of_birth"].ToString().Equals(utilConstants.cDFEmptyListValue))
                        lblCgvYearOfBirthDisplay.Text = "-";
                    else
                        lblCgvYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
                }
                #endregion Load Display Line Caregiver
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

                LoadListsArea("", strSctId, dbCon);
                LoadListsOrganization("", strCsoId, dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                utilSM.LoadListsArea(strDstId, strSctId, cbDistrict, cbSubCounty, FormParent.FormMaster.LanguageId, dbCon);
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

                cbCgvHHMember.SelectedIndex = -1;
                cbHHMember.SelectedIndex = -1;
                cbCgvHHMember.Enabled = false;
                cbHHMember.Enabled = false;
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsHousehold", exc);
            }
        }

        private void LoadListsLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine("", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strEduId, string strFstId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_education_level", true, strEduId, false, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbEducationLevel, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_financial_support_type", true, strFstId, false, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialSupport, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strEduId.Length != 0)
                    cbEducationLevel.SelectedValue = strEduId;
                else
                    cbEducationLevel.SelectedIndex = 0;
                if (strFstId.Length != 0)
                    cbFinancialSupport.SelectedValue = strFstId;
                else
                    cbFinancialSupport.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void LoadListsMember(string strHhId, string strHhmId, string strHhmIdCaregiver)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMember(strHhId, strHhmId, strHhmIdCaregiver, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMember(string strHhId, string strHhmId, string strHhmIdCaregiver, DataAccessLayer.DBConnection dbCon)
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
                utilControls.ComboBoxFill(cbCgvHHMember, dt, "hhm_id", "hhm_name");
                if (strHhmIdCaregiver.Length == 0)
                {
                    strHhmIdCaregiver = dalHHM.GetMemberCaregiver(strHhId, dbCon);
                    if (strHhmIdCaregiver.Equals(utilConstants.cDFEmptyListValue))
                        strHhmIdCaregiver = string.Empty;
                    else
                        LoadDisplayMember("", strHhmIdCaregiver, dbCon);
                }

                cbCgvHHMember.Enabled = true;

                dt = dalHHM.GetListForForm(strHhId, strHhmId, "ben_girl_education_register_child", "ger", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                cbHHMember.Enabled = true;
                #endregion Load Lists

                #region Set List Selection
                if (strHhmIdCaregiver.Length != 0)
                    cbCgvHHMember.SelectedValue = strHhmIdCaregiver;
                else
                    cbCgvHHMember.SelectedIndex = 0;
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
                benGirlEducationRegister dalGER = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalGER = new benGirlEducationRegister();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalGER.ger_id = ObjectId;
                            dalGER.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalGER.Load(ObjectId, dbCon);

                        dalGER.ger_contact_details = txtContactDetails.Text.Trim();

                        dalGER.cso_id = cbCSO.SelectedValue.ToString();
                        dalGER.fy_id = cbQuarter.SelectedValue.ToString();
                        dalGER.qy_id = cbQuarter.SelectedValue.ToString();
                        lblSctId.Text = cbSubCounty.SelectedValue.ToString();
                        dalGER.sct_id = cbSubCounty.SelectedValue.ToString();
                        dalGER.swk_id = cbSocialWorker.SelectedValue.ToString();
                        dalGER.usr_id_update = FormParent.FormMaster.UserId;

                        dalGER.Save(dbCon);

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

        private void SaveLine()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benGirlEducationRegisterChild dalGERC = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalGERC = new benGirlEducationRegisterChild();

                        if (lblGercId.Text.Length == 0 || lblGercId.Text.Trim().Equals("-"))
                        {
                            dalGERC.gerc_id = Guid.NewGuid().ToString();
                            dalGERC.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalGERC.Load(lblGercId.Text, dbCon);

                        dalGERC.gerc_support_institution = txtSupportInstitution.Text.Trim();
                        dalGERC.edu_id = cbEducationLevel.SelectedValue.ToString();
                        dalGERC.fst_id = cbFinancialSupport.SelectedValue.ToString();

                        dalGERC.hhm_id = cbHHMember.SelectedValue.ToString();
                        dalGERC.hhm_id_caregiver = cbCgvHHMember.SelectedValue.ToString();
                        dalGERC.ger_id = ObjectId;
                        dalGERC.usr_id_update = FormParent.FormMaster.UserId;

                        dalGERC.Save(dbCon);

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

        private void SetControls(bool blnEnabled)
        {
            btnChildCancel.Enabled = blnEnabled;
            btnDelete.Enabled = blnEnabled;
            btnChildSave.Enabled = blnEnabled;

            cbHHCode.Enabled = blnEnabled;
            cbHHMember.Enabled = blnEnabled;
            cbCgvHHMember.Enabled = blnEnabled;
            if (!blnEnabled)
            {
                cbHHCode.SelectedIndex = -1;
                ClearCaregiver();
                ClearMember();
            }
            else
            {
                LoadListsHousehold(cbSubCounty.SelectedValue.ToString());
                LoadListsLine();
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
            if (cbCSO.SelectedIndex == 0 || 
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
            if (cbHHCode.SelectedIndex == 0 || cbHHMember.SelectedIndex == 0 || cbCgvHHMember.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageGirlChildEducation, dbCon);
                btnDelete.Visible = pblnManage;
                btnChildSave.Visible = pblnManage;
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
