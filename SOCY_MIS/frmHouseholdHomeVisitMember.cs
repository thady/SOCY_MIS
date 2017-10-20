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
    public partial class frmHouseholdHomeVisitMember : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdHomeVisitMain frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHouseholdHomeVisitMain FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHouseholdHomeVisitMember()
        {
            InitializeComponent();
        }

        private void frmHouseholdHomeVisitMember_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadHousehold();
            LoadDisplay("");
        }

        private void frmHouseholdHomeVisitMember_Paint(object sender, PaintEventArgs e)
        {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadHouseholdMember(cbHHMember.SelectedValue.ToString());
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvMembers.SelectedCells.Count != 0)
                {
                    strID = dgvMembers.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    LoadDisplay(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMembers_CellDoubleClick", exc);
            }
        }

        private void dgvMembers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                #region Variables
                DataGridViewCell clDel = null;
                DataGridViewCheckBoxCell chkDel = null;
                #endregion Variables

                #region Set Delete Cell
                if (!dgvMembers.Rows[e.RowIndex].Cells["gclOfcId"].Value.ToString().Equals(FormMaster.OfficeId) || !pblnManage)
                {
                    clDel = dgvMembers.Rows[e.RowIndex].Cells["gclDelete"];
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMembers_RowPostPaint", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnHHPArtYes_CheckedChanged(object sender, EventArgs e)
        {
            SetHIV(rbtnHHPHivPos.Checked, rbtnHHPArtYes.Checked);
        }

        private void rbtnHHPHivPos_CheckedChanged(object sender, EventArgs e)
        {
            SetHIV(rbtnHHPHivPos.Checked, rbtnHHPArtYes.Checked);
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.Back();
        }

        private void Clear()
        {
            #region Clear
            cbHHMember.Enabled = true;
            lblHHVMId.Text = string.Empty;

            rbtnEduEnrolledNA.Checked = false;
            rbtnEduEnrolledNo.Checked = false;
            rbtnEduEnrolledYes.Checked = false;
            rbtnEduSensitisedNo.Checked = false;
            rbtnEduSensitisedYes.Checked = false;
            rbtnEduSupportNA.Checked = false;
            rbtnEduSupportNo.Checked = false;
            rbtnEduSupportYes.Checked = false;
            rbtnESAflateenNo.Checked = false;
            rbtnESAflateenYes.Checked = false;
            rbtnESAgroNo.Checked = false;
            rbtnESAgroYes.Checked = false;
            rbtnESApprenticeshipNo.Checked = false;
            rbtnESApprenticeshipYes.Checked = false;
            rbtnESSilcNo.Checked = false;
            rbtnESSilcYes.Checked = false;
            rbtnFSNEducationNA.Checked = false;
            rbtnFSNEducationNo.Checked = false;
            rbtnFSNEducationYes.Checked = false;
            rbtnFSNSupportNA.Checked = false;
            rbtnFSNSupportNo.Checked = false;
            rbtnFSNSupportYes.Checked = false;
            rbtnFSNNutritionNo.Checked = false;
            rbtnFSNNutritionYes.Checked = false;
            rbtnFSNReferredNo.Checked = false;
            rbtnHHPHivPos.Checked = false; 
            rbtnFSNReferredYes.Checked = false;
            rbtnFSNWashNo.Checked = false;
            rbtnHHPHivNeg.Checked = false;
            rbtnHHPHivPos.Checked = false;
            rbtnHHPHivUnknown.Checked = false;
            rbtnHHPReferredNA.Checked = false;
            rbtnHHPReferredNo.Checked = false;
            rbtnHHPReferredYes.Checked = false;
            rbtnMemberActiveNo.Checked = false;
            rbtnMemberActiveYes.Checked = false;
            rbtnProBirthCertificateNA.Checked = false;
            rbtnProBirthCertificateNo.Checked = false;
            rbtnProBirthCertificateYes.Checked = false;
            rbtnProBirthRegistrationNA.Checked = false;
            rbtnProBirthRegistrationNo.Checked = false;
            rbtnProBirthRegistrationYes.Checked = false;
            rbtnProChildAbuseNA.Checked = false;
            rbtnProChildAbuseNo.Checked = false;
            rbtnProChildAbuseYes.Checked = false;
            rbtnProChildLabourNA.Checked = false;
            rbtnProChildLabourNo.Checked = false;
            rbtnProChildLabourYes.Checked = false;
            rbtnProReintegratedNA.Checked = false;
            rbtnProReintegratedNo.Checked = false;
            rbtnProReintegratedYes.Checked = false;
            rbtnPSParentingNA.Checked = false;
            rbtnPSParentingNo.Checked = false;
            rbtnPSParentingYes.Checked = false;
            rbtnPSSupportNA.Checked = false;
            rbtnPSSupportNo.Checked = false;
            rbtnPSSupportYes.Checked = false;
            rbtnPSViolenceNA.Checked = false;
            rbtnPSViolenceNo.Checked = false;
            rbtnPSViolenceYes.Checked = false;
            btnSave.Enabled = pblnManage;
            SetHIV(rbtnHHPHivPos.Checked, rbtnHHPArtYes.Checked);
            LoadHouseholdMembers("");
            #endregion Clear
        }

        private void Delete()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdHomeVisitMember dalDel = null;
                utilLanguageTranslation utilLT = null;

                DialogResult dlrResult;
                bool blnFound = false;
                int intCounter = 0;
                string strId = string.Empty;
                string strMessage = string.Empty;
                string strTitle = string.Empty;
                #endregion

                #region Delete checked records
                if (dgvMembers.RowCount != 0)
                {
                    while (intCounter < dgvMembers.RowCount && !blnFound)
                    {
                        if (Convert.ToBoolean(dgvMembers.Rows[intCounter].Cells["gclDelete"].Value))
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
                                    dalDel = new hhHouseholdHomeVisitMember();
                                    for (int intCount = 0; intCount < dgvMembers.RowCount; intCount++)
                                    {
                                        if (Convert.ToBoolean(dgvMembers.Rows[intCount].Cells["gclDelete"].Value))
                                        {
                                            strId = dgvMembers.Rows[intCount].Cells["gclID"].Value.ToString();
                                            dalDel.Delete(strId, dbCon);
                                        }
                                    }
                                    dbCon.TransactionCommit();
                                    Clear();
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Delete", exc);
            }
        }

        private void LoadDisplay(string strId)
        {
            try
            {
                #region Varaibles
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdHomeVisitMember dalHHVM = null;
                #endregion Variables

                #region Load Display
                if (strId.Length == 0)
                {
                    Clear();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        if (ObjectId.Length == 0)
                            ObjectId = FormCalling.ObjectId;
                        dalHHVM = new hhHouseholdHomeVisitMember(strId, dbCon);
                        lblHHVMId.Text = strId;

                        #region HIV Status
                        switch (dalHHVM.hst_id)
                        {
                            case "1":
                                rbtnHHPHivNeg.Checked = false;
                                rbtnHHPHivPos.Checked = true;
                                rbtnHHPHivUnknown.Checked = false;
                                break;
                            case "2":
                                rbtnHHPHivNeg.Checked = true;
                                rbtnHHPHivPos.Checked = false;
                                rbtnHHPHivUnknown.Checked = false;
                                break;
                            case "3":
                                rbtnHHPHivNeg.Checked = false;
                                rbtnHHPHivPos.Checked = false;
                                rbtnHHPHivUnknown.Checked = true;
                                break;
                            default:
                                rbtnHHPHivNeg.Checked = false;
                                rbtnHHPHivPos.Checked = false;
                                rbtnHHPHivUnknown.Checked = false;
                                break;
                        }
                        #endregion HIV Status

                        utilControls.RadioButtonSetSelection(rbtnEduSensitisedYes, rbtnEduSensitisedNo, dalHHVM.yn_id_edu_sensitised);
                        utilControls.RadioButtonSetSelection(rbtnESAflateenYes, rbtnESAflateenNo, dalHHVM.yn_id_es_aflateen);
                        utilControls.RadioButtonSetSelection(rbtnESAgroYes, rbtnESAgroNo, dalHHVM.yn_id_es_agro);
                        utilControls.RadioButtonSetSelection(rbtnESApprenticeshipYes, rbtnESApprenticeshipNo, dalHHVM.yn_id_es_apprenticeship);
                        utilControls.RadioButtonSetSelection(rbtnESSilcYes, rbtnESSilcNo, dalHHVM.yn_id_es_silc);
                        utilControls.RadioButtonSetSelection(rbtnFSNNutritionYes, rbtnFSNNutritionNo, dalHHVM.yn_id_fsn_nutrition);
                        utilControls.RadioButtonSetSelection(rbtnFSNReferredYes, rbtnFSNReferredNo, dalHHVM.yn_id_fsn_referred);
                        utilControls.RadioButtonSetSelection(rbtnFSNWashYes, rbtnFSNWashNo, dalHHVM.yn_id_fsn_wash);
                        utilControls.RadioButtonSetSelection(rbtnMemberActiveYes, rbtnMemberActiveNo, dalHHVM.yn_id_hhm_active);

                        utilControls.RadioButtonSetSelection(rbtnEduEnrolledYes, rbtnEduEnrolledNo, rbtnEduEnrolledNA, dalHHVM.ynna_id_edu_enrolled);
                        utilControls.RadioButtonSetSelection(rbtnEduSupportYes, rbtnEduSupportNo, rbtnEduSupportNA, dalHHVM.ynna_id_edu_support);
                        utilControls.RadioButtonSetSelection(rbtnFSNEducationYes, rbtnFSNEducationNo, rbtnFSNEducationNA, dalHHVM.ynna_id_fsn_education);
                        utilControls.RadioButtonSetSelection(rbtnFSNSupportYes, rbtnFSNSupportNo, rbtnFSNSupportNA, dalHHVM.ynna_id_fsn_support);
                        utilControls.RadioButtonSetSelection(rbtnHHPAdheringYes, rbtnHHPAdheringNo, rbtnHHPAdheringNA, dalHHVM.ynna_id_hhp_adhering);
                        utilControls.RadioButtonSetSelection(rbtnHHPArtYes, rbtnHHPArtNo, rbtnHHPArtNA, dalHHVM.ynna_id_hhp_art);
                        utilControls.RadioButtonSetSelection(rbtnHHPReferredYes, rbtnHHPReferredNo, rbtnHHPReferredNA, dalHHVM.ynna_id_hhp_referred);
                        utilControls.RadioButtonSetSelection(rbtnProBirthCertificateYes, rbtnProBirthCertificateNo, rbtnProBirthCertificateNA, dalHHVM.ynna_id_pro_birth_certificate);
                        utilControls.RadioButtonSetSelection(rbtnProBirthRegistrationYes, rbtnProBirthRegistrationNo, rbtnProBirthRegistrationNA, dalHHVM.ynna_id_pro_birth_registration);
                        utilControls.RadioButtonSetSelection(rbtnProChildAbuseYes, rbtnProChildAbuseNo, rbtnProChildAbuseNA, dalHHVM.ynna_id_pro_child_abuse);
                        utilControls.RadioButtonSetSelection(rbtnProChildLabourYes, rbtnProChildLabourNo, rbtnProChildLabourNA, dalHHVM.ynna_id_pro_child_labour);
                        utilControls.RadioButtonSetSelection(rbtnProReintegratedYes, rbtnProReintegratedNo, rbtnProReintegratedNA, dalHHVM.ynna_id_pro_reintegrated);
                        utilControls.RadioButtonSetSelection(rbtnPSParentingYes, rbtnPSParentingNo, rbtnPSParentingNA, dalHHVM.ynna_id_ps_parenting);
                        utilControls.RadioButtonSetSelection(rbtnPSSupportYes, rbtnPSSupportNo, rbtnPSSupportNA, dalHHVM.ynna_id_ps_support);
                        utilControls.RadioButtonSetSelection(rbtnPSViolenceYes, rbtnPSViolenceNo, rbtnPSViolenceNA, dalHHVM.ynna_id_ps_violence);

                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHHVM.ofc_id) || utilConstants.cDFImportOffice.Equals(dalHHVM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHHVM.ofc_id));

                        LoadHouseholdMembers(dalHHVM.hhm_id, dbCon);
                        cbHHMember.Enabled = false;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Load Display

            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayLines()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayLines(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                hhHouseholdHomeVisit dalHHV = new hhHouseholdHomeVisit();
                #endregion Variables

                #region Load Display Lines
                dt = dalHHV.GetLines(ObjectId, FormMaster.LanguageId, dbCon);

                dgvMembers.AutoGenerateColumns = false;
                dgvMembers.DataSource = dt;
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
            }
        }

        private void LoadHousehold()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            hhHousehold dalHH = null;
            #endregion

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                dalHH = new hhHousehold(HouseholdId, dbCon);
                lblHouseholdCodeDisplay.Text = dalHH.hh_code;
                LoadDisplayLines(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHouseholdMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHouseholdMember(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHouseholdMember(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHouseholdMember dalHHM = null;

                DataRow dr = null;
                DataTable dt = null;
                #endregion Variables

                if (strId.Length == 0 || strId.Equals(utilConstants.cDFEmptyListValue))
                {
                    #region Clear
                    lblGenderDisplay.Text = "-";
                    lblMemberNumberDisplay.Text = "-";
                    lblYearOfBirthDisplay.Text = "-";
                    #endregion Clear
                }
                else
                {
                    #region Load Data
                    dalHHM = new hhHouseholdMember();
                    dt = dalHHM.GetMember(strId, FormMaster.LanguageId, dbCon);
                    dr = dt.Rows[0];

                    lblGenderDisplay.Text = dr["gnd_name"].ToString();
                    lblMemberNumberDisplay.Text = dr["hhm_number"].ToString();
                    lblYearOfBirthDisplay.Text = dr["hhm_year_of_birth"].ToString();
                    #endregion Load Data
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHouseholdMember", exc);
            }
        }

        private void LoadHouseholdMembers(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHouseholdMembers(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHouseholdMembers(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHouseholdMember dalHHM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                #region Load Data
                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetListForForm(HouseholdId, strId, "hh_household_home_visit_member", "hhv", ObjectId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                #endregion Load Lists

                #region Set List Selection
                if (strId.Length != 0)
                    cbHHMember.SelectedValue = strId;
                else
                    cbHHMember.SelectedIndex = 0;
                #endregion Set List Selection

                LoadHouseholdMember(strId, dbCon);
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHouseholdMembers", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhHouseholdHomeVisitMember dalHHVM = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        if(ObjectId.Length == 0)
                            ObjectId = FormCalling.ObjectId;

                        dalHHVM = new hhHouseholdHomeVisitMember();

                        if (lblHHVMId.Text.Length == 0 || lblHHVMId.Text.Trim().Equals("-"))
                        {
                            dalHHVM.hhvm_id = Guid.NewGuid().ToString();
                            dalHHVM.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHHVM.Load(lblHHVMId.Text, dbCon);

                        dalHHVM.hhm_id = cbHHMember.SelectedValue.ToString();
                        dalHHVM.hhv_id = ObjectId;
                        
                        #region HIV Status
                        if (rbtnHHPHivPos.Checked)
                            dalHHVM.hst_id = utilConstants.cHSTPositive;
                        else if (rbtnHHPHivNeg.Checked)
                            dalHHVM.hst_id = utilConstants.cHSTNegative;
                        else if (rbtnHHPHivUnknown.Checked)
                            dalHHVM.hst_id = utilConstants.cHSTUnKnown;
                        else
                            dalHHVM.hst_id = utilConstants.cDFEmptyListValue;
                        #endregion HIS Status

                        dalHHVM.yn_id_edu_sensitised = utilControls.RadioButtonGetSelection(rbtnEduSensitisedYes, rbtnEduSensitisedNo);
                        dalHHVM.yn_id_es_aflateen = utilControls.RadioButtonGetSelection(rbtnESAflateenYes, rbtnESAflateenNo);
                        dalHHVM.yn_id_es_agro = utilControls.RadioButtonGetSelection(rbtnESAgroYes, rbtnESAgroNo);
                        dalHHVM.yn_id_es_apprenticeship = utilControls.RadioButtonGetSelection(rbtnESApprenticeshipYes, rbtnESApprenticeshipNo);
                        dalHHVM.yn_id_es_silc = utilControls.RadioButtonGetSelection(rbtnESSilcYes, rbtnESSilcNo);
                        dalHHVM.yn_id_fsn_nutrition = utilControls.RadioButtonGetSelection(rbtnFSNNutritionYes, rbtnFSNNutritionNo);
                        dalHHVM.yn_id_fsn_referred  = utilControls.RadioButtonGetSelection(rbtnFSNReferredYes, rbtnFSNReferredNo);
                        dalHHVM.yn_id_fsn_wash = utilControls.RadioButtonGetSelection(rbtnFSNWashYes, rbtnFSNWashNo);
                        dalHHVM.yn_id_hhm_active = utilControls.RadioButtonGetSelection(rbtnMemberActiveYes, rbtnMemberActiveNo);

                        dalHHVM.ynna_id_edu_enrolled = utilControls.RadioButtonGetSelection(rbtnEduEnrolledYes, rbtnEduEnrolledNo, rbtnEduEnrolledNA);
                        dalHHVM.ynna_id_edu_support = utilControls.RadioButtonGetSelection(rbtnEduSupportYes, rbtnEduSupportNo, rbtnEduSupportNA);
                        dalHHVM.ynna_id_fsn_education = utilControls.RadioButtonGetSelection(rbtnFSNEducationYes, rbtnFSNEducationNo, rbtnFSNEducationNA);
                        dalHHVM.ynna_id_fsn_support = utilControls.RadioButtonGetSelection(rbtnFSNSupportYes, rbtnFSNSupportNo, rbtnFSNSupportNA);
                        dalHHVM.ynna_id_hhp_adhering = utilControls.RadioButtonGetSelection(rbtnHHPAdheringYes, rbtnHHPAdheringNo, rbtnHHPAdheringNA);
                        dalHHVM.ynna_id_hhp_art = utilControls.RadioButtonGetSelection(rbtnHHPArtYes, rbtnHHPArtNo, rbtnHHPArtNA);
                        dalHHVM.ynna_id_hhp_referred = utilControls.RadioButtonGetSelection(rbtnHHPReferredYes, rbtnHHPReferredNo, rbtnHHPReferredNA);
                        dalHHVM.ynna_id_pro_birth_certificate = utilControls.RadioButtonGetSelection(rbtnProBirthCertificateYes, rbtnProBirthCertificateNo, rbtnProBirthCertificateNA);
                        dalHHVM.ynna_id_pro_birth_registration = utilControls.RadioButtonGetSelection(rbtnProBirthRegistrationYes, rbtnProBirthRegistrationNo, rbtnProBirthRegistrationNA);
                        dalHHVM.ynna_id_pro_child_abuse = utilControls.RadioButtonGetSelection(rbtnProChildAbuseYes, rbtnProChildAbuseNo, rbtnProChildAbuseNA);
                        dalHHVM.ynna_id_pro_child_labour = utilControls.RadioButtonGetSelection(rbtnProChildLabourYes, rbtnProChildLabourNo, rbtnProChildLabourNA);
                        dalHHVM.ynna_id_pro_reintegrated = utilControls.RadioButtonGetSelection(rbtnProReintegratedYes, rbtnProReintegratedNo, rbtnProReintegratedNA);
                        dalHHVM.ynna_id_ps_parenting = utilControls.RadioButtonGetSelection(rbtnPSParentingYes, rbtnPSParentingNo, rbtnPSParentingNA);
                        dalHHVM.ynna_id_ps_support = utilControls.RadioButtonGetSelection(rbtnPSSupportYes, rbtnPSSupportNo, rbtnPSSupportNA);
                        dalHHVM.ynna_id_ps_violence = utilControls.RadioButtonGetSelection(rbtnPSViolenceYes, rbtnPSViolenceNo, rbtnPSViolenceNA);

                        dalHHVM.usr_id_update = FormMaster.UserId;

                        dalHHVM.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        Clear();
                        LoadDisplayLines(dbCon);
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

        private void SetHIV(bool blnHIV, bool blnART)
        {
            #region Set Options
            if (blnHIV)
            {
                pnlHHPArt.Enabled = true;
                if (blnART)
                {
                    pnlHHPAdhering.Enabled = true;
                }
                else
                {
                    pnlHHPAdhering.Enabled = false;
                    rbtnHHPAdheringNA.Checked = true;
                }
            }
            else
            {
                pnlHHPAdhering.Enabled = false;
                pnlHHPArt.Enabled = false;
                rbtnHHPAdheringNA.Checked = true;
                rbtnHHPArtNA.Checked = true;
            }
            #endregion Set Options
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHomeVisits, dbCon);
                btnDelete.Visible = pblnManage;
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
