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
    public partial class frmActivityTraining : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private int pintParticipantX = 24;
        private int pintParticipantY = 53;
        private string strId = string.Empty;
        private frmActivityTrainingSearch frmCll = null;
        private frmResultArea01 frmPrt = null;
        #endregion Variables

        #region Property
        public frmActivityTrainingSearch FormCalling
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
        public frmActivityTraining()
        {
            InitializeComponent();
        }

        private void frmActivityTraining_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnParticipantCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnParticipantDelete.Enabled = !FormParent.FormMaster.NoDatabase;
                btnParticipantSave.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
                LoadListsLine("", "", "");
                LoadListsMember("", "", "", "");
            }
        }

        private void frmActivityTraining_Paint(object sender, PaintEventArgs e)
        {
            cbCSO.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbGender.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbTrainingType.SelectionLength = 0;
            cbYearOfBirth.SelectionLength = 0;
        }
        #endregion

        #region Control Methdods
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

        private void btnParticipantCancel_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btnParticipantDelete_Click(object sender, EventArgs e)
        {
            DeleteLine();
        }

        private void btnParticipantSave_Click(object sender, EventArgs e)
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
                LoadListsLine("", "", "");
            else
                LoadListsLine(cbDistrict.SelectedValue.ToString(), "", "");
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDistrict.SelectedIndex == 0)
                LoadListsLine("", cbSubCounty.SelectedValue.ToString(), "");
            else
                LoadListsLine(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
        }

        private void cbCSO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCSO.SelectedIndex == 0)
                SetCSO("");
            else
                SetCSO(cbCSO.SelectedValue.ToString());
        }

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                LoadListsMember("", "", "", "");
            else
                LoadListsMember("", cbHHCode.SelectedValue.ToString(), "", "");
            ClearMember();
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedIndex == 0)
                ClearMember();
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void cbTrainingType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTrainingType.SelectedIndex == 0)
                SetSession(0, "");
            else
                SetSession(0, cbTrainingType.SelectedValue.ToString());
        }

        private void dgvParticipant_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvParticipant.SelectedCells.Count != 0)
                {
                    strID = dgvParticipant.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvParticipant_CellDoubleClick", exc);
            }
        }

        private void dgvParticipant_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvParticipant.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormParent.FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvParticipant.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvParticipant_RowPostPaint", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnParticipantTypeHousehold_CheckedChanged(object sender, EventArgs e)
        {
            SetParticipants();
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
                    SetCSO("");
                    cbTrainingType.SelectedIndex = 0;
                    SetSession(0, "");

                    dtpTrainingFrom.Value = DateTime.Now;
                    dtpTrainingTo.Value = DateTime.Now;
                    nudSession.Value = 1;
                    nudTrainingDays.Value = 1;

                    txtActivity.Text = string.Empty;
                    txtContactNumber.Text = string.Empty;
                    txtCoordinatedBy.Text = string.Empty;
                    txtTrainingFor.Text = string.Empty;
                    txtTrainingPoint.Text = string.Empty;
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

        private void ClearLine()
        {
            try
            {
                #region Clear Line
                lblAtpId.Text = string.Empty;

                cbHHCode.SelectedIndex = 0;
                ClearMember();
                LoadListsMember("", "", "", "");

                nudDaysAttended.Value = 1;
                txtName.Text = string.Empty;
                btnParticipantSave.Enabled = pblnManage;
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
                lblHHGenderDisplay.Text = "-";
                lblHHYearOfBirthDisplay.Text = "-";
                lblHHMCodeDisplay.Text = "-";
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
                benActivityTrainingParticipant dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvParticipant.RowCount != 0)
                {
                    while (intCounter < dgvParticipant.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvParticipant.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new benActivityTrainingParticipant();
                                    for (int intCount = 0; intCount < dgvParticipant.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvParticipant.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvParticipant.Rows[intCount].Cells["gclID"].Value.ToString();
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
                benActivityTraining dalAT = null;
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
                        dalAT = new benActivityTraining(ObjectId, dbCon);

                        dtpTrainingFrom.Value = dalAT.at_date_begin;
                        dtpTrainingTo.Value = dalAT.at_date_end;
                        nudTrainingDays.Value = dalAT.at_days;
                        txtActivity.Text = dalAT.at_activity;
                        txtContactNumber.Text = dalAT.at_coordinator_tel;
                        txtCoordinatedBy.Text = dalAT.at_coordinator;
                        txtTrainingFor.Text = dalAT.at_training_for;
                        txtTrainingPoint.Text = dalAT.at_training_point;
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalAT.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalAT.ofc_id));
                        #endregion Load Display

                        LoadDisplayLines(dbCon);
                        LoadLists(dalAT.cso_id, dalAT.at_session, dalAT.ttp_id, dbCon);
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
                benActivityTrainingParticipant dalATP = null;
                string strGndId = string.Empty;
                string strHhId = string.Empty;
                string strHhmId = string.Empty;
                string strYoBId = string.Empty;
                #endregion Variables

                #region Load Display Line
                dalATP = new benActivityTrainingParticipant(strId, dbCon);

                lblAtpId.Text = strId;
                nudDaysAttended.Value = dalATP.atp_days;

                if (dalATP.hhm_id.Equals(utilConstants.cDFEmptyListValue) || dalATP.hhm_id.Length == 0)
                {
                    rbtnParticipantTypeExternal.Checked = true;
                    ClearMember();

                    strGndId = dalATP.gnd_id;
                    strYoBId = dalATP.atp_year_of_birth;
                    txtName.Text = dalATP.atp_name;
                }
                else
                {
                    rbtnParticipantTypeHousehold.Checked = true;
                    LoadDisplayMember(dalATP.hhm_id, dbCon);

                    cbGender.SelectedIndex = 0;
                    cbYearOfBirth.SelectedIndex = 0;
                    txtName.Text = string.Empty;

                    strHhId = dalATP.hh_id;
                    strHhmId = dalATP.hhm_id;
                }
                LoadListsMember(strGndId, strHhId, strHhmId, strYoBId, dbCon);
                btnParticipantSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalATP.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalATP.ofc_id));
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
                benActivityTraining dalAT = new benActivityTraining();
                #endregion Variables

                #region Load Display Lines
                dt = dalAT.GetLines(ObjectId, FormParent.FormMaster.LanguageId, dbCon);

                dgvParticipant.AutoGenerateColumns = false;
                dgvParticipant.DataSource = dt;
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

                if (!cbHHCode.SelectedValue.ToString().Equals(dr["hh_id"].ToString()))
                {
                    LoadListsLine("", dr["sct_id"].ToString(), dr["hh_id"].ToString(), dbCon);
                    LoadListsMember("", dr["hh_id"].ToString(), strId, "", dbCon);
                }
                cbHHMember.SelectedValue = strId;
                lblHHGenderDisplay.Text = dr["gnd_name"].ToString();
                lblHHYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
                lblHHMCodeDisplay.Text = dr["hhm_code"].ToString();
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
                LoadLists("", 0, "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strCsoId, int intSsn, string strTtpId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_cso", true, strCsoId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbCSO, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_training_type", true, strTtpId, true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbTrainingType, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strCsoId.Length != 0)
                    cbCSO.SelectedValue = strCsoId;
                else
                    cbCSO.SelectedIndex = 0;
                SetCSO(strCsoId, dbCon);
                if (strTtpId.Length != 0)
                    cbTrainingType.SelectedValue = strTtpId;
                else
                    cbTrainingType.SelectedIndex = 0;
                SetSession(intSsn, strTtpId, dbCon);
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsLine(string strDstId, string strSctId, string strHhId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsLine(strDstId, strSctId, strHhId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(string strDstId, string strSctId, string strHhId, DataAccessLayer.DBConnection dbCon)
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

        private void LoadListsMember(string strGndId, string strHhId, string strHhmId, string strYoBId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMember(strGndId, strHhId, strHhmId, strYoBId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMember(string strGndId, string strHhId, string strHhmId, string strYoBId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                hhHouseholdMember dalHhm = null;

                DataRow dr = null;
                DataTable dt = null;
                DataTable dtYear = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_gender", true, strGndId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGender, dt, "lt_id", "lt_name");

                dalHhm = new hhHouseholdMember();
                dt = dalHhm.GetListForForm(strHhId, strHhmId, "ben_activity_training_participant", "at", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");

                #region Year Of Birth
                dtYear = new DataTable();
                dtYear.Columns.Add("lt_id");
                dtYear.Columns.Add("lt_name");

                for (int intCount = DateTime.Now.Year; intCount > 1900; intCount--)
                {
                    dr = dtYear.NewRow();
                    dr["lt_id"] = intCount.ToString();
                    dr["lt_name"] = intCount.ToString();
                    dtYear.Rows.Add(dr);
                }
                dtYear.AcceptChanges();

                dtYear = utilCollections.AddEmptyItemFront(dtYear, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbYearOfBirth, dtYear, "lt_id", "lt_name");
                #endregion Year Of Birth
                #endregion Load Lists

                #region Set List Selection
                if (strGndId.Length != 0)
                    cbGender.SelectedValue = strGndId;
                else
                    cbGender.SelectedIndex = 0;
                if (strHhmId.Length != 0)
                    cbHHMember.SelectedValue = strHhmId;
                else
                    cbHHMember.SelectedIndex = 0;
                if (strYoBId.Length != 0)
                    cbYearOfBirth.SelectedValue = strYoBId;
                else
                    cbYearOfBirth.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                benActivityTraining dalAT = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        try
                        {
                            dbCon.TransactionBegin();
                            dalAT = new benActivityTraining();

                            if (ObjectId.Length == 0)
                            {
                                ObjectId = Guid.NewGuid().ToString();
                                dalAT.at_id = ObjectId;
                                dalAT.ofc_id = FormParent.FormMaster.OfficeId;
                            }
                            else
                                dalAT.Load(ObjectId, dbCon);

                            dalAT.at_activity = txtActivity.Text.Trim();
                            dalAT.at_coordinator = txtCoordinatedBy.Text.Trim();
                            dalAT.at_coordinator_tel = txtContactNumber.Text.Trim();
                            dalAT.at_training_for = txtTrainingFor.Text.Trim();
                            dalAT.at_training_point = txtTrainingPoint.Text.Trim();

                            dalAT.at_days = Convert.ToInt32(nudTrainingDays.Value);
                            dalAT.at_date_begin = dtpTrainingFrom.Value;
                            dalAT.at_date_end = dtpTrainingTo.Value;
                            if(nudSession.Visible)
                            dalAT.at_session = Convert.ToInt32(nudSession.Value);
                            else
                                dalAT.at_session = 0;

                            dalAT.cso_id = cbCSO.SelectedValue.ToString();
                            dalAT.ttp_id = cbTrainingType.SelectedValue.ToString();

                            dalAT.usr_id_update = FormParent.FormMaster.UserId;

                            dalAT.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }

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
                benActivityTrainingParticipant dalATP = null;

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
                        dalATP = new benActivityTrainingParticipant();

                        if (lblAtpId.Text.Length == 0 || lblAtpId.Text.Trim().Equals("-"))
                        {
                            dalATP.atp_id = Guid.NewGuid().ToString();
                            dalATP.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalATP.Load(lblAtpId.Text, dbCon);

                        dalATP.atp_days = Convert.ToInt32(nudDaysAttended.Value);

                        if (rbtnParticipantTypeExternal.Checked)
                        {
                            dalATP.mtp_id = utilConstants.cMTExternal;
                            dalATP.atp_name = txtName.Text.Trim();
                            dalATP.atp_year_of_birth = cbYearOfBirth.SelectedValue.ToString();
                            dalATP.gnd_id = cbGender.SelectedValue.ToString();
                            dalATP.hhm_id = utilConstants.cDFEmptyListValue;
                        }
                        else
                        {
                            dalATP.mtp_id = utilConstants.cMTHousehold;
                            dalATP.atp_name = string.Empty;
                            dalATP.atp_year_of_birth = utilConstants.cDFEmptyListValue;
                            dalATP.gnd_id = utilConstants.cDFEmptyListValue;
                            dalATP.hhm_id = cbHHMember.SelectedValue.ToString();
                        }

                        dalATP.at_id = ObjectId;
                        dalATP.usr_id_update = FormParent.FormMaster.UserId;
                        dalATP.district_id = static_variables.district_id;

                        dalATP.Save(dbCon);

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
            btnParticipantCancel.Enabled = blnEnabled;
            btnParticipantDelete.Enabled = blnEnabled;
            btnParticipantSave.Enabled = blnEnabled;
            if (blnEnabled)
                nudDaysAttended.Maximum = nudTrainingDays.Value;
        }

        private void SetParticipants()
        {
            if (rbtnParticipantTypeExternal.Checked)
            {
                tlpParticipantExternal.Visible = true;
                tlpParticipantHousehold.Visible = false;
                tlpParticipantHouseholdDetails.Visible = false;
            }
            else if (rbtnParticipantTypeHousehold.Checked)
            {
                tlpParticipantExternal.Visible = false;
                tlpParticipantHousehold.Visible = true;
                tlpParticipantHouseholdDetails.Visible = true;
            }

            tlpParticipantExternal.Location = new Point(pintParticipantX, pintParticipantY);
            tlpParticipantHousehold.Location = new Point(pintParticipantX, pintParticipantY);
        }

        private void SetCSO(string strCsoId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                #endregion Variables

                #region Set Code
                if (strCsoId.Length == 0)
                {
                    lblCSOCodeDisplay.Text = "-";
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        SetCSO(strCsoId,  dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Set Code
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetCSO", exc);
            }
        }

        private void SetCSO(string strCsoId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            utilListTable uLT = null;
            #endregion Variables

            if (strCsoId.Length == 0)
            {
                lblCSOCodeDisplay.Text = "-";
            }
            else
            {
                uLT = new utilListTable();
                lblCSOCodeDisplay.Text = uLT.GetOther("lst_cso", strCsoId, dbCon.dbCon);
            }
        }

        private void SetSession(int intSsnNum, string strTtnId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                #endregion Variables

                #region Set Code
                if (strTtnId.Length == 0)
                {
                    SetSession(0, 0, false);
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        SetSession(intSsnNum, strTtnId, dbCon);
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Set Code
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetSession", exc);
            }
        }

        private void SetSession(int intSsnNum, string strTtnId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                string strSsnMax = "0";
                utilListTable uLT = null;
                #endregion Variables

                #region Set Code
                if (strTtnId.Length == 0)
                {
                    SetSession(0, 0, false);
                }
                else
                {
                    uLT = new utilListTable();
                    strSsnMax = uLT.GetOther("lst_training_type", cbTrainingType.SelectedValue.ToString(), dbCon.dbCon);

                    if (strSsnMax.Length != 0 && utilFormatting.IsInt(strSsnMax) && Convert.ToInt32(strSsnMax.Trim()) > 0)
                        SetSession(intSsnNum, Convert.ToInt32(strSsnMax.Trim()), true);
                    else
                        SetSession(0, 0, false);
                }
                #endregion Set Code
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetSession", exc);
            }
        }

        private void SetSession(int intSsn, int intMax, bool blnVisible)
        {
            if (intSsn != 0 && blnVisible)
                nudSession.Value = intSsn;
            if (intMax != 0 && blnVisible)
                nudSession.Maximum = intMax;
            nudSession.Visible = blnVisible;
            lblSession.Visible = blnVisible;
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
            if (cbCSO.SelectedIndex == 0 || cbCSO.SelectedIndex == 0 || 
                txtCoordinatedBy.Text.Trim().Length == 0 || txtTrainingFor.Text.Trim().Length == 0 || txtActivity.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Date Range
            if (dtpTrainingFrom.Value > dtpTrainingTo.Value.AddMinutes(1))
                strMessage = strMessage + "," + utilConstants.cMIDInvalidDateRange;
            #endregion Date Range

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

            bool blnRequired = false;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (rbtnParticipantTypeExternal.Checked && txtName.Text.Trim().Length == 0 && cbGender.SelectedIndex == 0)
                blnRequired = true;
            else if (rbtnParticipantTypeHousehold.Checked && cbHHMember.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageActivityTraining, dbCon);
                btnParticipantDelete.Visible = pblnManage;
                btnParticipantSave.Visible = pblnManage;
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
