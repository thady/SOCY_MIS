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
    public partial class frmHouseholdAssessmentMember : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdAssessmentMain frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHouseholdAssessmentMain FormCalling
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
        public frmHouseholdAssessmentMember()
        {
            InitializeComponent();
        }

        private void frmHouseholdAssessmentMember_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadHousehold();
                LoadDisplay("");
                //ShowIndexUpdateLink();

                LoadAdditionSchoolInfoPopup();
            }
        }

        private void frmHouseholdAssessmentMember_Paint(object sender, PaintEventArgs e)
        {
            #region UnHighlight Comboboxes
            cbART.SelectionLength = 0;
            cbBirthRegistration.SelectionLength = 0;
            cbDisability.SelectionLength = 0;
            cbDisabilityType.SelectionLength = 0;
            cbEducation.SelectionLength = 0;
            cbGender.SelectionLength = 0;
            cbGivenBirth.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbHIVStatus.SelectionLength = 0;
            cbImmunize.SelectionLength = 0;
            cbMaritalStatus.SelectionLength = 0;
            cbPregnant.SelectionLength = 0;
            cbProfession.SelectionLength = 0;
            cbProtection.SelectionLength = 0;
            cbSchool.SelectionLength = 0;
            cbYearOfBirth.SelectionLength = 0;
            cbAttainedVocationalSkill.SelectionLength = 0;
            #endregion UnHighlight Comboboxes
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

        private void cbDisability_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbDisability.SelectedValue.ToString().Equals(utilConstants.cDFListValueYes))
            {
                cbDisabilityType.Enabled = true;
            }
            else
            {
                cbDisabilityType.Enabled = false;
                cbDisabilityType.SelectedIndex = 0;
            }
        }

        private void cbGender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbGender.SelectedValue.ToString().Equals(utilConstants.cGNDMale))
            {
                cbGivenBirth.Enabled = true;
                cbPregnant.Enabled = true;
            }
            else
            {
                cbGivenBirth.Enabled = false;
                cbGivenBirth.SelectedIndex = 0;
                cbPregnant.Enabled = false;
                cbPregnant.SelectedIndex = 0;
            }
        }

        private void cbHIVStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbHIVStatus.SelectedValue.ToString().Equals(utilConstants.cHSTNegative) && !cbHIVStatus.SelectedValue.ToString().Equals(utilConstants.cHSTUnKnown) && !cbHIVStatus.SelectedValue.ToString().Equals(utilConstants.cHSTUnDisclosed))
            {
                cbART.Enabled = true;
            }
            else
            {
                cbART.Enabled = false;
                cbART.SelectedIndex = 0;
                //cbART.SelectedValue = 2;
            }
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.SelectedIndex == 0)
                Clear();
            else
                LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Variables
            string strID = string.Empty;
            #endregion

            #region Load Display
            if (dgvMembers.SelectedCells.Count != 0)
            {
                strID = dgvMembers.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                LoadDisplay(strID);
            }
            #endregion Load Display
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnMemberTypeExisting_CheckedChanged(object sender, EventArgs e)
        {
            #region Set Display
            Clear();
            #endregion Set Display
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.Back();
        }

        private void Clear()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                Clear(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void Clear(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHouseholdMember dalHHM = null;
            #endregion Variables

            #region Clear
            lblHAMId.Text = "-";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;

            cbART.SelectedIndex = 0;
            cbBirthRegistration.SelectedIndex = 0;
            cbDisability.SelectedIndex = 0;
            cbDisabilityType.SelectedIndex = 0;
            cbEducation.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;
            cbGivenBirth.SelectedIndex = 0;
            cbHIVStatus.SelectedIndex = 0;
            cbImmunize.SelectedIndex = 0;
            cbMaritalStatus.SelectedIndex = 0;
            cbPregnant.SelectedIndex = 0;
            cbProfession.SelectedIndex = 0;
            cbProtection.SelectedIndex = 0;
            cbSchool.SelectedIndex = 0;
            cbYearOfBirth.SelectedIndex = 0;
            cbAttainedVocationalSkill.SelectedIndex = 0;

            cbART.Enabled = true;
            cbGivenBirth.Enabled = true;
            cbPregnant.Enabled = true;
            cbDisabilityType.Enabled = false;

            chkCaregiver.Checked = false;
            chkHeadOfHousehold.Checked = false;

            dalHHM = new hhHouseholdMember();
            #region Next Number
            lblMemberNumberDisplay.Text = dalHHM.NextMemberNumber(HouseholdId, dbCon);
            #endregion Next Number

            SetMemberControls(rbtnMemberTypeExisting.Checked, false);
            btnSave.Enabled = pblnManage;
            #endregion Clear
        }

        private void LoadDisplay(string strId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdMember dalHHM = null;
                hhHouseholdAssessmentMember dalHAM = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    LoadMembers(dbCon);
                    if (strId.Length == 0)
                    {
                        LoadLists();
                        Clear();
                    }
                    else
                    {
                        #region Household Member
                        dalHAM = new hhHouseholdAssessmentMember();
                        dalHHM = new hhHouseholdMember();

                        dalHAM.Load(strId, dbCon);
                        dalHHM.Load(dalHAM.hhm_id, dbCon);
                        lblHAMId.Text = strId;
                        lblMemberNumberDisplay.Text = dalHHM.hhm_number;
                        txtFirstName.Text = dalHAM.ham_first_name;
                        txtLastName.Text = dalHAM.ham_last_name;
                        cbAttainedVocationalSkill.SelectedValue = dalHAM.yn_attained_vocational_skill;
                        chkCaregiver.Checked = (dalHAM.yn_id_caregiver == "1");
                        chkHeadOfHousehold.Checked = (dalHAM.yn_id_hoh == "1");

                        cbART.Enabled = !dalHAM.hst_id.Equals(utilConstants.cHSTNegative);
                        cbDisabilityType.Enabled = dalHAM.yn_id_disability.Equals(utilConstants.cDFListValueYes);
                        cbGivenBirth.Enabled = !dalHAM.gnd_id.Equals(utilConstants.cGNDMale);
                        cbPregnant.Enabled = !dalHAM.gnd_id.Equals(utilConstants.cGNDMale);
                        //btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalHAM.ofc_id) || utilConstants.cDFImportOffice.Equals(dalHAM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalHAM.ofc_id));
                        #endregion Household Member

                        LoadListsMember(dalHHM.hh_id, dalHAM.hhm_id, dbCon);
                        SetMemberControls(false, true);

                        LoadLists(dalHAM.ham_year_of_birth, dalHAM.dtp_id, dalHAM.edu_id, dalHAM.gnd_id, dalHAM.hst_id, dalHAM.mst_id, dalHAM.prf_id, dalHAM.prt_id,
                            dalHAM.yn_id_art, dalHAM.yn_id_birth_registration, dalHAM.yn_id_disability, dalHAM.yn_id_given_birth,
                            dalHAM.yn_id_immun, dalHAM.yn_id_pregnant, dalHAM.yn_id_school, dalHAM.yn_attained_vocational_skill, dbCon);
                    }
                    #endregion Load Data
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayMember(string strHhmId)
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdMember dalHHM = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    #region Household Member
                    dalHHM = new hhHouseholdMember();

                    dalHHM.Load(strHhmId, dbCon);
                    lblMemberNumberDisplay.Text = dalHHM.hhm_number;
                    txtFirstName.Text = dalHHM.hhm_first_name;
                    txtLastName.Text = dalHHM.hhm_last_name;

                    chkCaregiver.Checked = (dalHHM.yn_id_caregiver == "1");
                    chkHeadOfHousehold.Checked = (dalHHM.yn_id_hoh == "1");

                    cbART.Enabled = !dalHHM.hst_id.Equals(utilConstants.cHSTNegative);
                    cbDisabilityType.Enabled = dalHHM.yn_id_disability.Equals(utilConstants.cDFListValueYes);
                    cbGivenBirth.Enabled = !dalHHM.gnd_id.Equals(utilConstants.cGNDMale);
                    cbPregnant.Enabled = !dalHHM.gnd_id.Equals(utilConstants.cGNDMale);
                    #endregion Household Member

                    LoadLists(dalHHM.hhm_year_of_birth, dalHHM.dtp_id, dalHHM.edu_id, dalHHM.gnd_id, dalHHM.hst_id, dalHHM.mst_id, dalHHM.prf_id, dalHHM.prt_id,
                        dalHHM.yn_id_art, dalHHM.yn_id_birth_registration, dalHHM.yn_id_disability, dalHHM.yn_id_given_birth,
                        dalHHM.yn_id_immun, dalHHM.yn_id_pregnant, dalHHM.yn_id_school, dalHHM.yn_attained_vocational_skill, dbCon);
                    #endregion Load Data
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadHousehold()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHousehold dalHH = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    if (HouseholdId.Length != 0)
                    {
                        dalHH = new hhHousehold(HouseholdId, dbCon);
                        lblHouseholdCodeDisplay.Text = dalHH.hh_code;
                        LoadListsMember(HouseholdId, "", dbCon);
                    }
                    #endregion Load Data
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHousehold", exc);
            }
        }

        private void LoadMembers()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadMembers(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadMembers(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHouseholdAssessmentMember dalHAM = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Load Datagrid
                dalHAM = new hhHouseholdAssessmentMember();
                dt = dalHAM.GetMembers(ObjectId, FormMaster.LanguageId, dbCon);
                dgvMembers.AutoGenerateColumns = false;
                dgvMembers.DataSource = dt;
                #endregion Load Datagrid
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadMembers", exc);
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
                LoadLists("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strYoB, string strDtpId, string strEduId, string strGndId,
            string strHstId, string strMstId, string strPrfId, string strPrt_id,
            string strYnIdArt, string strYnIdBirthRegistration, string strYnIdDisability,
            string strYnIdGivenBirth, string strYnIdImmun, string strYnIdPregnant,
            string strYnIdSchool, string strYnVocationalSkill, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;

                DataRow dr = null;
                DataTable dt = null;
                DataTable dtYear = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_disability_type", true, strDtpId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDisabilityType, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_education_level", true, strEduId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbEducation, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_gender", true, strGndId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGender, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_hiv_status", true, strHstId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHIVStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_marital_status", true, strMstId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbMaritalStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_profession", true, strPrfId, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbProfession, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_protection", true, strPrt_id, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbProtection, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdArt, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbART, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdBirthRegistration, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbBirthRegistration, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdDisability, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDisability, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdGivenBirth, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGivenBirth, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdGivenBirth, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbAttainedVocationalSkill, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdImmun, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbImmunize, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdPregnant, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPregnant, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdSchool, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSchool, dt, "lt_id", "lt_name");

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
                if (strDtpId.Length != 0)
                    cbDisabilityType.SelectedValue = strDtpId;
                else
                    cbDisabilityType.SelectedIndex = 0;
                if (strEduId.Length != 0)
                    cbEducation.SelectedValue = strEduId;
                else
                    cbEducation.SelectedIndex = 0;
                if (strGndId.Length != 0)
                    cbGender.SelectedValue = strGndId;
                else
                    cbGender.SelectedIndex = 0;
                if (strHstId.Length != 0)
                    cbHIVStatus.SelectedValue = strHstId;
                else
                    cbHIVStatus.SelectedIndex = 0;
                if (strMstId.Length != 0)
                    cbMaritalStatus.SelectedValue = strMstId;
                else
                    cbMaritalStatus.SelectedIndex = 0;
                if (strPrfId.Length != 0)
                    cbProfession.SelectedValue = strPrfId;
                else
                    cbProfession.SelectedIndex = 0;
                if (strPrt_id.Length != 0)
                    cbProtection.SelectedValue = strPrt_id;
                else
                    cbProtection.SelectedIndex = 0;
                if (strYnIdArt.Length != 0)
                    cbART.SelectedValue = strYnIdArt;
                else
                    cbART.SelectedIndex = 0;
                if (strYnIdBirthRegistration.Length != 0)
                    cbBirthRegistration.SelectedValue = strYnIdBirthRegistration;
                else
                    cbBirthRegistration.SelectedIndex = 0;
                if (strYnIdDisability.Length != 0)
                    cbDisability.SelectedValue = strYnIdDisability;
                else
                    cbDisability.SelectedIndex = 0;
                if (strYnIdGivenBirth.Length != 0)
                    cbGivenBirth.SelectedValue = strYnIdGivenBirth;
                else
                    cbGivenBirth.SelectedIndex = 0;
                if (strYnIdImmun.Length != 0)
                    cbImmunize.SelectedValue = strYnIdImmun;
                else
                    cbImmunize.SelectedIndex = 0;
                if (strYnIdPregnant.Length != 0)
                    cbPregnant.SelectedValue = strYnIdPregnant;
                else
                    cbPregnant.SelectedIndex = 0;
                if (strYnIdSchool.Length != 0)
                    cbSchool.SelectedValue = strYnIdSchool;
                else
                    cbSchool.SelectedIndex = 0;

                if (strYnVocationalSkill.Length != 0)
                    cbAttainedVocationalSkill.SelectedValue = strYnVocationalSkill;
                else
                    cbAttainedVocationalSkill.SelectedIndex = 0;

                if (strYoB.Length != 0)
                    cbYearOfBirth.SelectedValue = strYoB;
                else
                    cbYearOfBirth.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                utilLT.Language = FormCalling.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetListForForm(strHhId, strHhmId, "hh_household_assessment_member", "hha", ObjectId, dbCon);
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
                FormCalling.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void SetMemberControls(bool blnExisting, bool blnAssessment)
        {
            cbHHMember.Enabled = blnExisting;
            lblHHMemberVal.Visible = blnExisting;
            if (!blnAssessment)
                cbHHMember.SelectedIndex = 0;
            lblMemberType.Visible = !blnAssessment;
            pnlMemberType.Visible = !blnAssessment;
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhHouseholdAssessment dalHHA = null;
                hhHouseholdAssessmentMember dalHAM = null;
                hhHouseholdMember dalHHM = null;

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
                        #region Household Assessment
                        dalHHA = new hhHouseholdAssessment();

                        if (FormCalling.ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalHHA.hha_id = ObjectId;
                            dalHHA.hh_id = HouseholdId;
                            dalHHA.ofc_id = FormMaster.OfficeId;
                            dalHHA.usr_id_update = FormMaster.UserId;
                            dalHHA.Save(dbCon);
                        }
                        else
                            ObjectId = FormCalling.ObjectId;
                        #endregion Household Assessment

                        #region Household Member
                        if (cbHHMember.SelectedIndex == 0 && rbtnMemberTypeNew.Checked)
                        {
                            dalHHM = new hhHouseholdMember();
                            dalHHM.hhm_id = Guid.NewGuid().ToString();
                            dalHHM.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHHM = new hhHouseholdMember(cbHHMember.SelectedValue.ToString(), dbCon);

                        dalHHM.hhm_first_name = txtFirstName.Text.Trim();
                        dalHHM.hhm_last_name = txtLastName.Text.Trim();
                        dalHHM.hhm_number = lblMemberNumberDisplay.Text;
                        dalHHM.hhm_year_of_birth = cbYearOfBirth.SelectedValue.ToString();

                        dalHHM.hh_id = HouseholdId;
                        dalHHM.dtp_id = cbDisabilityType.SelectedValue.ToString();
                        dalHHM.edu_id = cbEducation.SelectedValue.ToString();
                        dalHHM.gnd_id = cbGender.SelectedValue.ToString();
                        dalHHM.hst_id = cbHIVStatus.SelectedValue.ToString();
                        dalHHM.mst_id = cbMaritalStatus.SelectedValue.ToString();
                        dalHHM.prf_id = cbProfession.SelectedValue.ToString();
                        dalHHM.prt_id = cbProtection.SelectedValue.ToString();
                        dalHHM.yn_id_art = cbART.SelectedValue.ToString();
                        dalHHM.yn_id_birth_registration = cbBirthRegistration.SelectedValue.ToString();
                        dalHHM.yn_id_caregiver = Convert.ToInt32(chkCaregiver.Checked).ToString();
                        dalHHM.yn_id_disability = cbDisability.SelectedValue.ToString();
                        dalHHM.yn_id_given_birth = cbGivenBirth.SelectedValue.ToString();
                        dalHHM.yn_id_hoh = Convert.ToInt32(chkHeadOfHousehold.Checked).ToString();
                        dalHHM.yn_id_immun = cbImmunize.SelectedValue.ToString();
                        dalHHM.yn_id_pregnant = cbPregnant.SelectedValue.ToString();
                        dalHHM.yn_id_school = cbSchool.SelectedValue.ToString();
                        dalHHM.usr_id_update = FormMaster.UserId;
                        if (rbtnActive.Checked)
                        {
                            dalHHM.hhm_status = utilConstants.cDFActive.ToString();
                        }
                        else
                        {
                            dalHHM.hhm_status = utilConstants.cDFInActives.ToString();
                        }

                        dalHHM.Save(dbCon);
                        //return current count of members after saving

                        #endregion Household Member

                        #region Household Assessment Member
                        if (lblHAMId.Text.Length == 0 || lblHAMId.Text.Equals("-"))
                        {
                            dalHAM = new hhHouseholdAssessmentMember();
                            dalHAM.ham_id = Guid.NewGuid().ToString();
                            dalHAM.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalHAM = new hhHouseholdAssessmentMember(lblHAMId.Text, dbCon);

                        dalHAM.ham_first_name = txtFirstName.Text.Trim();
                        dalHAM.ham_last_name = txtLastName.Text.Trim();
                        dalHAM.ham_year_of_birth = cbYearOfBirth.SelectedValue.ToString();

                        dalHAM.hha_id = ObjectId;
                        dalHAM.hhm_id = dalHHM.hhm_id;
                        dalHAM.dtp_id = cbDisabilityType.SelectedValue.ToString();
                        dalHAM.edu_id = cbEducation.SelectedValue.ToString();
                        dalHAM.gnd_id = cbGender.SelectedValue.ToString();
                        dalHAM.hst_id = cbHIVStatus.SelectedValue.ToString();
                        dalHAM.mst_id = cbMaritalStatus.SelectedValue.ToString();
                        dalHAM.prf_id = cbProfession.SelectedValue.ToString();
                        dalHAM.prt_id = cbProtection.SelectedValue.ToString();
                        dalHAM.yn_id_art = cbART.SelectedValue.ToString();
                        dalHAM.yn_id_birth_registration = cbBirthRegistration.SelectedValue.ToString();
                        dalHAM.yn_id_caregiver = Convert.ToInt32(chkCaregiver.Checked).ToString();
                        dalHAM.yn_id_disability = cbDisability.SelectedValue.ToString();
                        dalHAM.yn_id_given_birth = cbGivenBirth.SelectedValue.ToString();
                        dalHAM.yn_id_hoh = Convert.ToInt32(chkHeadOfHousehold.Checked).ToString();
                        dalHAM.yn_id_immun = cbImmunize.SelectedValue.ToString();
                        dalHAM.yn_id_pregnant = cbPregnant.SelectedValue.ToString();
                        dalHAM.yn_id_school = cbSchool.SelectedValue.ToString();
                        dalHAM.usr_id_update = FormMaster.UserId;
                        dalHAM.yn_attained_vocational_skill = cbAttainedVocationalSkill.SelectedValue.ToString();
                        dalHAM.district_id = SystemConstants.Return_office_district();

                        dalHAM.Save(dbCon);
                        #endregion Household Assessment Member

                        dbCon.TransactionCommit();
                        Clear();
                        LoadListsMember(HouseholdId, "", dbCon);
                        LoadMembers(dbCon);

                        //Toggle visibility of update link for index beneficiary
                        //ShowIndexUpdateLink();

                        //Check if there is school going child in household
                        LoadAdditionSchoolInfoPopup();

                        //Load index registration tool
                        LoadIndexBeneficiairyPopup(dalHHA);

                        if (FormCalling.ObjectId.Length == 0)
                            FormCalling.ObjectId = ObjectId;

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        protected void LoadIndexBeneficiairyPopup(hhHouseholdAssessment dalHHA)
        {
            if (dalHHA.CountHouseholdMemberCount(HouseholdId) == Convert.ToInt32(SystemConstants.HATMemberCount) & benIndexRegistration.ReturnIndexCount(HouseholdId) == 0)
            {
                benIndexRegistration.hh_id = HouseholdId;
                frm_BeneficairyIndexRegister frmNew = new frm_BeneficairyIndexRegister();
                frmNew.ShowDialog();
            }
        }

        protected void LoadAdditionSchoolInfoPopup()
        {
            DataTable dt = benAdolescentSchoolAssessment.LoadMembers(HouseholdId);
            if (dt.Rows.Count > 0)
            {
                btnAdolescentData.Visible = true;
            }
            else
                btnAdolescentData.Visible = false;
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
            if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0 ||
                cbGender.SelectedIndex == 0 || cbYearOfBirth.SelectedIndex == 0 ||
                (cbHHMember.SelectedIndex == 0 && lblHHMemberVal.Visible) || cbDisability.SelectedIndex == 0 || (cbDisability.Text == "Yes" && cbDisabilityType.SelectedIndex == 0)
                || (cbDisabilityType.SelectedIndex != 0 && (cbDisability.SelectedIndex == 0 || cbDisability.Text == "No")) || cbHIVStatus.SelectedIndex == 0 || cbProfession.SelectedIndex == 0 || cbSchool.SelectedIndex == 0
                || cbProtection.SelectedIndex == 0 || cbMaritalStatus.SelectedIndex == 0 || cbEducation.SelectedIndex == 0 || (cbGender.Text == "Female" && cbGivenBirth.SelectedIndex == 0) || (cbHIVStatus.Text == "Positive" && cbART.SelectedIndex == 0) || (!rbtnActive.Checked & !rbtnInactive.Checked))
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageHouseholdAssessment, dbCon);
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

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGender.Text == "Female") { lblGivenBirth.ForeColor = Color.Red; }
            else { lblGivenBirth.ForeColor = Color.Black; }
        }

        private void cbDisability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDisability.Text == "Yes") { lblDisabilityType.ForeColor = Color.Red; }
            else { lblDisabilityType.ForeColor = Color.Black; }
        }

        private void cbHIVStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHIVStatus.Text == "Positive") { lblART.ForeColor = Color.Red; }
            else { lblART.ForeColor = Color.Black; }
        }

        private void btnPopup_Click(object sender, EventArgs e)
        {
            frm_BeneficairyIndexRegister frmNew = new frm_BeneficairyIndexRegister();
            frmNew.ShowDialog();
        }

        private void lnkIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            benIndexRegistration.hh_id = HouseholdId;
            frm_BeneficairyIndexRegister frmNew = new frm_BeneficairyIndexRegister();
            frmNew.ShowDialog();
        }

        protected void ShowIndexUpdateLink()
        {
            if (benIndexRegistration.ReturnIndexCount(HouseholdId) > 0)
            {
                lnkIndex.Visible = true;
            }
            else
            {
                lnkIndex.Visible = false;
            }
        }

        private void frmHouseholdAssessmentMember_MouseEnter(object sender, EventArgs e)
        {
            //ShowIndexUpdateLink();
        }

        private void tlpDisplay01_MouseEnter(object sender, EventArgs e)
        {
            //ShowIndexUpdateLink();
        }

        private void btnAdolescentData_Click(object sender, EventArgs e)
        {
            benAdolescentSchoolAssessment.hh_id = HouseholdId;
            frmBeneficiaryschoolAssessment frmNew = new frmBeneficiaryschoolAssessment();
            frmNew.ShowDialog();
        }
    }
}