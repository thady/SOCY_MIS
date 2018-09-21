using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMSHTC : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private string strDmId = string.Empty;
        private frmDREAMSMember frmCll = null;
        private frmDREAMS frmPrt = null;
        #endregion Variables

        #region Property
        public frmDREAMSMember FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmDREAMS FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string MemberId
        {
            get { return strDmId; }
            set { strDmId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDREAMSHTC()
        {
            InitializeComponent();
        }

        private void frmDREAMSHTC_Load(object sender, EventArgs e)
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
                LoadDisplay(ObjectId);
                LoadDisplayMember();
                LoadDisplayRegisters();
            }
        }
        #endregion Form Methods

        #region Control Methods
        #region Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
        #endregion Buttons

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplay(strID);
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

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblbackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                ObjectId = string.Empty;
                lblDhrId.Text = string.Empty;
                txtResult01.Text = string.Empty;
                dtpResult01.Value = DateTime.Now;
                txtResult02.Text = string.Empty;
                dtpResult02.Value = DateTime.Now;
                txtResult03.Text = string.Empty;
                dtpResult03.Value = DateTime.Now;
                txtResult04.Text = string.Empty;
                dtpResult04.Value = DateTime.Now;
                txtResult05.Text = string.Empty;
                dtpResult05.Value = DateTime.Now;
                btnSave.Enabled = pblnManage;
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        #region Delete
        private void Delete()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmHTCRegister dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                bool blnDelObj = false;
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
                                    dalDel = new drmHTCRegister();
                                    for (int intCount = 0; intCount < dgvRegister.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvRegister.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            if (strId.Equals(ObjectId))
                                                blnDelObj = true;
                                            strId = dgvRegister.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    if (blnDelObj)
                                        ObjectId = string.Empty;
                                    Clear();
                                    LoadDisplayRegisters(dbCon);
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
        #endregion Delete

        #region Load Display
        private void LoadDisplay(string strDssmsId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;

                drmHTCRegister dalDhr = null;
                #endregion Variables

                #region Load Data
                lblDhrId.Text = strDssmsId;
                if (strDssmsId.Length != 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDhr = new drmHTCRegister(strDssmsId, dbCon);

                        lblDhrId.Text = dalDhr.dhr_id;
                        txtResult01.Text = dalDhr.dhr_result_01;
                        dtpResult01.Value = dalDhr.dhr_result_01_date;
                        txtResult02.Text = dalDhr.dhr_result_02;
                        dtpResult02.Value = dalDhr.dhr_result_02_date;
                        txtResult03.Text = dalDhr.dhr_result_03;
                        dtpResult03.Value = dalDhr.dhr_result_03_date;
                        txtResult04.Text = dalDhr.dhr_result_04;
                        dtpResult04.Value = dalDhr.dhr_result_04_date;
                        txtResult05.Text = dalDhr.dhr_result_05;
                        dtpResult05.Value = dalDhr.dhr_result_05_date;

                        LoadDisplayRegisters(dbCon);

                        //line added by tadeo for toggling save button enabled/disabled 
                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalDhr.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalDhr.ofc_id));
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayMember()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            drmMember dalDm = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                dalDm = new drmMember(MemberId, dbCon);
                lblDreamsIdDisplay.Text = dalDm.dm_id_no;
                lblDreamsMemberDisplay.Text = dalDm.dm_first_name + " " + dalDm.dm_last_name;
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayRegisters()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayRegisters(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayRegisters(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                DataTable dt = null;
                drmHTCRegister dalDhr = new drmHTCRegister();
                #endregion Variables

                #region Load Display Lines
                dt = dalDhr.GetList(MemberId, dbCon);
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayRegisters", exc);
            }
        }
        #endregion Load Display

        #region Save
        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmHTCRegister dalDhr = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        dalDhr = new drmHTCRegister();
                        if (lblDhrId.Text.Length == 0 || lblDhrId.Text.Trim().Equals("-"))
                        {
                            dalDhr.dhr_id = Guid.NewGuid().ToString();
                            dalDhr.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalDhr.Load(lblDhrId.Text, dbCon);

                        dalDhr.dhr_result_01 = txtResult01.Text.Trim();
                        dalDhr.dhr_result_01_date = dtpResult01.Value;
                        dalDhr.dhr_result_02 = txtResult02.Text.Trim();
                        dalDhr.dhr_result_02_date = dtpResult02.Value;
                        dalDhr.dhr_result_03 = txtResult03.Text.Trim();
                        dalDhr.dhr_result_03_date = dtpResult03.Value;
                        dalDhr.dhr_result_04 = txtResult04.Text.Trim();
                        dalDhr.dhr_result_04_date = dtpResult04.Value;
                        dalDhr.dhr_result_05 = txtResult05.Text.Trim();
                        dalDhr.dhr_result_05_date = dtpResult05.Value;
                        dalDhr.dm_id = MemberId;
                        dalDhr.usr_id_update = FormParent.FormMaster.UserId;

                        dalDhr.Save(dbCon);
                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        Clear();
                        LoadDisplayRegisters(dbCon);
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

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }
        #endregion Save

        #region Validation
        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
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
        #endregion Validation
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageDREAMSHTCRegister, dbCon);
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