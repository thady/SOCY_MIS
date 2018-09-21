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
    public partial class frmDREAMSRegistration : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDREAMSRegistrationSearch frmCll = null;
        private Master frmMST = null;

        private int pintMemberX = 24;
        private int pintMemberY = 111;
        #endregion Variables

        #region Property
        public frmDREAMSRegistrationSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
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
        #endregion Property

        #region Form Methods
        public frmDREAMSRegistration()
        {
            InitializeComponent();
        }

        private void frmDREAMSRegistration_Load(object sender, EventArgs e)
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
            }
        }

        private void frmDREAMSRegistration_Paint(object sender, PaintEventArgs e)
        {
            cbDisability.SelectionLength = 0;
            cbDistrict.SelectionLength = 0;
            cbEducationStatus.SelectionLength = 0;
            cbEntryType.SelectionLength = 0;
            cbFacility.SelectionLength = 0;
            cbGivenBirth.SelectionLength = 0;
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
            cbMarried.SelectionLength = 0;
            cbMember.SelectionLength = 0;
            cbParentalStatus.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbPregnant.SelectionLength = 0;
            cbSEROStatus.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbTS.SelectionLength = 0;
            cbVisit.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Controls
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

        private void btnVisitCancel_Click(object sender, EventArgs e)
        {
            ClearVisit();
        }

        private void btnVisitSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                SaveVisit();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                LoadListsHouseholdMember("");
            else
                LoadListsHouseholdMember(cbHHCode.SelectedValue.ToString());
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHMember.Items.Count == 0 || cbHHMember.SelectedIndex == 0)
                ClearHouseholdMember();
            else
                LoadDisplayHouseholdMember(cbHHMember.SelectedValue.ToString());
        }

        private void cbMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbMember.Items.Count == 0 || cbMember.SelectedIndex == 0)
                ClearMember();
            else
                LoadDisplayMember(cbMember.SelectedValue.ToString());
        }

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
                    LoadDisplayLine(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister", exc);
            }
        }

        private void dgvVisit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvVisit.SelectedCells.Count != 0)
                {
                    strID = dgvVisit.SelectedCells[0].OwningRow.Cells["gclDemvId"].Value.ToString();
                    LoadDisplayVisit(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvVisit", exc);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SetAgeAtRegistration();
        }

        private void dtpDoB_ValueChanged(object sender, EventArgs e)
        {
            SetAgeAtRegistration();
        }

        private void llblBackMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackVisit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        #region Radio Buttons
        private void rbtnMemberExisting_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers(true);
        }

        private void rbtnMemberExternal_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers(true);
        }

        private void rbtnMemberHousehold_CheckedChanged(object sender, EventArgs e)
        {
            SetMembers(true);
        }
        #endregion Radio Buttons

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Controls

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormCalling.FormParent.LoadControl(FormCalling, this.Name);
        }

        #region Clear
        private void Clear()
        {
            #region Clear
            if (ObjectId.Length != 0)
            {
                LoadDisplay();
            }
            else
            {
                cbDistrict.SelectedIndex = 0;
                cbFacility.SelectedIndex = 0;
            }
            #endregion Clear
        }

        private void ClearHouseholdMember()
        {
            #region Clear
            cbHHCode.SelectedIndex = 0;
            cbHHMember.SelectedIndex = 0;
            cbHHMember.Enabled = false;
            cbEntryType.SelectedIndex = 0;
            cbSubCounty.SelectedIndex = 0;
            cbWard.SelectedIndex = 0;
            cbWard.Enabled = false;
            dtpDate.Value = DateTime.Now;
            dtpDoB.Value = DateTime.Now;
            lblAgeAtRegistrationDisplay.Text = "0";
            txtDreamsId.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtVillage.Text = string.Empty;
            #endregion Clear
        }

        private void ClearLine()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            #region Clear
            dtpDate.Value = DateTime.Now;
            dtpDoB.Value = DateTime.Now;
            lblAgeAtRegistrationDisplay.Text = string.Empty;
            lblDemId.Text = string.Empty;
            txtDreamsId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSNumber.Text = string.Empty;
            txtVillage.Text = string.Empty;
            utilControls.CheckedListClear(clbSocialEconomic);

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMembers("", dbCon);
                LoadListsMemberDisplay("", "", dbCon);
                LoadListsLine(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            ClearVisit();
            SetControlsVisit(false);
            SetMembers(true);
            btnMemberSave.Enabled = pblnManage;
            #endregion Clear
        }

        private void ClearMember()
        {
            #region Clear
            cbMember.SelectedIndex = 0;
            cbEntryType.SelectedIndex = 0;
            cbSubCounty.SelectedIndex = 0;
            cbWard.SelectedIndex = 0;
            cbWard.Enabled = false;
            dtpDate.Value = DateTime.Now;
            dtpDoB.Value = DateTime.Now;
            lblAgeAtRegistrationDisplay.Text = "0";
            txtDreamsId.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtVillage.Text = string.Empty;
            #endregion Clear
        }

        private void ClearVisit()
        {
            #region Clear
            chkANC.Checked = false;
            chkART.Checked = false;
            chkCMNC.Checked = false;
            chkCondomPromotion.Checked = false;
            chkContraceptiveMix.Checked = false;
            chkHIVTesting.Checked = false;
            chkParentingProgram.Checked = false;
            chkPostViolenceCare.Checked = false;
            chkSchoolBasedPrevention.Checked = false;
            chkSocioEconomic.Checked = false;
            chkVMMC.Checked = false;
            lblDemvId.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtReferral.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            LoadListsVisit();
            LoadDisplayVisits();
            btnVisitSave.Enabled = pblnManage;
            #endregion Clear
        }
        #endregion Clear

        #region Load Display
        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmEnrollment dalDE = null;
                #endregion Variables

                #region Load Data
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    if (ObjectId.Length == 0)
                    {
                        LoadLists("", "", dbCon);
                        SetControls(false);
                        SetControlsVisit(false);
                    }
                    else
                    {
                        #region Load Data
                        dalDE = new drmEnrollment(ObjectId, dbCon);
                        #endregion Load Data

                        LoadDisplayLines(dbCon);
                        LoadLists(dalDE.dst_id, dalDE.flt_id, dbCon);
                        SetControls(true);
                        SetControlsVisit(false);
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDE.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDE.ofc_id));
                    }
                    LoadListsLine(dbCon);
                    LoadListsMemberDisplay("", "", dbCon);
                    LoadListsMembers("", dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Load Data
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadDisplayHouseholdMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayHouseholdMember(strId, "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayHouseholdMember(string strId, string strEtpId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHousehold dalHH = null;
            hhHouseholdMember dalHHM = null;
            #endregion Variables

            #region Load Display
            dalHHM = new hhHouseholdMember(strId, dbCon);
            dalHH = new hhHousehold(dalHHM.hh_id, dbCon);
            if (dalHHM.hhm_year_of_birth.Length == 4)
                dtpDoB.Value = Convert.ToDateTime(dalHHM.hhm_year_of_birth + "/01/01");
            else
                dtpDoB.Value = DateTime.Now;
            txtVillage.Text = dalHH.hh_village;

            LoadListsMemberDisplay(strEtpId, dalHH.wrd_id, dbCon);
            #endregion Load Display
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
                drmEnrollmentMember dalDEM = null;
                #endregion Variables

                #region Load Display Line
                dalDEM = new drmEnrollmentMember(strId, dbCon);
                rbtnMemberExisting.Checked = true;
                SetMembers(false);
                SetControlsVisit(true);
                LoadDisplayMember(dalDEM.dm_id, dbCon);
                lblDemId.Text = strId;

                LoadListsLine(dalDEM.est_id, dalDEM.pst_id, dalDEM.sst_id, dalDEM.yn_id_disability, dalDEM.yn_id_given_birth, dalDEM.yn_id_married,
                    dalDEM.yn_id_partner, dalDEM.yn_id_pregnant, dalDEM.yn_id_ts, dalDEM.segment, dbCon);
                ClearVisit();
                btnMemberSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDEM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDEM.ofc_id));
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLine", exc);
            }
        }

        private void LoadDisplayLines(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                drmEnrollment dalDE = new drmEnrollment();
                #endregion Variables

                #region Load Display Lines
                dt = dalDE.GetLines(ObjectId, dbCon);
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = dt;
                lblTotalNumber.Text = dt.Rows.Count.ToString();
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayLines", exc);
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
            #region Variables
            drmMember dalDM = null;
            #endregion Variables

            #region Load Display
            dalDM = new drmMember(strId, dbCon);

            LoadListsMembers(strId, dbCon);
            switch (dalDM.mtp_id)
            {
                case utilConstants.cMTExternal:
                    txtVillage.Text = dalDM.dm_village;
                    LoadListsMemberDisplay(dalDM.etp_id, dalDM.wrd_id, dbCon);
                    break;
                case utilConstants.cMTHousehold:
                    LoadDisplayHouseholdMember(dalDM.hhm_id, dalDM.etp_id, dbCon);
                    break;
            }

            dtpDate.Value = dalDM.dm_registration;
            dtpDoB.Value = dalDM.dm_dob;
            txtDreamsId.Text = dalDM.dm_id_no;
            txtPhone.Text = dalDM.dm_phone;
            #endregion Load Display
        }

        private void LoadDisplayVisit(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayVisit(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayVisit(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmEnrollmentMemberVisit dalDEMV = null;
                #endregion Variables

                #region Load Display Line
                dalDEMV = new drmEnrollmentMemberVisit(strId, dbCon);

                lblDemvId.Text = strId;
                txtComment.Text = dalDEMV.demv_comment;
                txtReferral.Text = dalDEMV.demv_referral;
                dtpVisitDate.Value = dalDEMV.demv_date;

                chkANC.Checked = (dalDEMV.yn_id_anc == "1");
                chkART.Checked = (dalDEMV.yn_id_art == "1");
                chkCMNC.Checked = (dalDEMV.yn_id_cmnc == "1");
                chkCondomPromotion.Checked = (dalDEMV.yn_id_condom_promotion == "1");
                chkContraceptiveMix.Checked = (dalDEMV.yn_id_contraceptive_mix == "1");
                chkHIVTesting.Checked = (dalDEMV.yn_id_hiv_testing == "1");
                chkParentingProgram.Checked = (dalDEMV.yn_id_parenting_program == "1");
                chkPostViolenceCare.Checked = (dalDEMV.yn_id_post_violence_care == "1");
                chkSchoolBasedPrevention.Checked = (dalDEMV.yn_id_school_based_prevention == "1");
                chkSocioEconomic.Checked = (dalDEMV.yn_id_social_economic == "1");
                chkVMMC.Checked = (dalDEMV.yn_id_vmmc == "1");

                LoadListsVisit(lblDemId.Text, dalDEMV.vst_id, dbCon);
                btnVisitSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDEMV.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDEMV.ofc_id));
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayVisit", exc);
            }
        }

        private void LoadDisplayVisits()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayVisits(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayVisits(DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region variables
                DataTable dt = null;
                drmEnrollmentMember dalDEM = new drmEnrollmentMember();
                #endregion Variables

                #region Load Display Lines
                dt = dalDEM.GetLines(lblDemId.Text, FormMaster.LanguageId, dbCon);
                dgvVisit.AutoGenerateColumns = false;
                dgvVisit.DataSource = dt;
                #endregion Load Display Lines
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayVisits", exc);
            }
        }
        #endregion Load Dislay

        #region Load Lists
        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_district", true, strDstId, FormMaster.LanguageId, dbCon.dbCon);
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

        private void LoadListsHouseholdMember(string strHhId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsHouseholdMember(strHhId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsHouseholdMember(string strHHId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmMember dalDM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalDM = new drmMember();
                dt = dalDM.GetHouseholdMembers(strHHId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");

                if (strHHId.Length == 0)
                {
                    cbHHMember.SelectedIndex = 0;
                    cbHHMember.Enabled = false;
                }
                else
                {
                    cbHHMember.Enabled = true;
                }
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsHouseholdMember", exc);
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
                LoadListsLine("", "", "", "", "", "", "", "", "", "".Split(utilConstants.cDFSplitChar), dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsLine(DataAccessLayer.DBConnection dbCon)
        {
            LoadListsLine("", "", "", "", "", "", "", "", "", "".Split(utilConstants.cDFSplitChar), dbCon);
        }

        private void LoadListsLine(string strEstId, string strPstId, string strSstId,
            string strYnIdDisability, string strYnIdGivenBirth, string strYnIdMarried, string strYnIdPartner, string strYnIdPregnant, string strYnIdTS,
            string[] strSgmId,
            DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_education_status", true, strEstId, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbEducationStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_parental_status", true, strPstId, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbParentalStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_sero_status", true, strSstId, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSEROStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdDisability, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDisability, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdGivenBirth, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbGivenBirth, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdMarried, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbMarried, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdPartner, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdPregnant, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPregnant, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_yes_no", true, strYnIdTS, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbTS, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_segment", true, strSgmId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbSocialEconomic, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strEstId.Length != 0)
                    cbEducationStatus.SelectedValue = strEstId;
                else
                    cbEducationStatus.SelectedIndex = 0;
                if (strPstId.Length != 0)
                    cbParentalStatus.SelectedValue = strPstId;
                else
                    cbParentalStatus.SelectedIndex = 0;
                if (strSstId.Length != 0)
                    cbSEROStatus.SelectedValue = strSstId;
                else
                    cbSEROStatus.SelectedIndex = 0;
                if (strYnIdDisability.Length != 0)
                    cbDisability.SelectedValue = strYnIdDisability;
                else
                    cbDisability.SelectedIndex = 0;
                if (strYnIdGivenBirth.Length != 0)
                    cbGivenBirth.SelectedValue = strYnIdGivenBirth;
                else
                    cbGivenBirth.SelectedIndex = 0;
                if (strYnIdMarried.Length != 0)
                    cbMarried.SelectedValue = strYnIdMarried;
                else
                    cbMarried.SelectedIndex = 0;
                if (strYnIdPartner.Length != 0)
                    cbPartner.SelectedValue = strYnIdPartner;
                else
                    cbPartner.SelectedIndex = 0;
                if (strYnIdPregnant.Length != 0)
                    cbPregnant.SelectedValue = strYnIdPregnant;
                else
                    cbPregnant.SelectedIndex = 0;
                if (strYnIdTS.Length != 0)
                    cbTS.SelectedValue = strYnIdTS;
                else
                    cbTS.SelectedIndex = 0;

                utilControls.CheckedListCheck(clbSocialEconomic, strSgmId, "lt_id");
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsLine", exc);
            }
        }

        private void LoadListsMemberDisplay(string strEtpId, string strWrdId, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_entry_type", true, strEtpId, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbEntryType, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strEtpId.Length != 0)
                    cbEntryType.SelectedValue = strEtpId;
                else
                    cbEntryType.SelectedIndex = 0;
                #endregion Set List Selection
                LoadListsArea(cbDistrict.SelectedValue.ToString(), "", strWrdId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMemberDisplay", exc);
            }
        }

        private void LoadListsMembers(string strDemID)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsMembers(strDemID, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsMembers(string strDmID, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmMember dalDM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalDM = new drmMember();

                if (cbDistrict.Items.Count != 0 && cbDistrict.SelectedIndex != 0)
                    dt = dalDM.GetHouseholds(cbDistrict.SelectedValue.ToString(), dbCon);
                else
                    dt = null;
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");

                if (cbDistrict.Items.Count != 0 && cbDistrict.SelectedIndex != 0)
                    dt = dalDM.GetMembersForForm(cbDistrict.SelectedValue.ToString(), strDmID, "drm_enrollment_member", "de", ObjectId, dbCon);
                else
                    dt = null;
                dt = utilCollections.AddEmptyItemFront(dt, "dm_id", "member_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbMember, dt, "dm_id", "member_name");
                #endregion Load Lists

                if (strDmID.Length != 0)
                    cbMember.SelectedValue = strDmID;
                else
                    cbMember.SelectedIndex = 0;
                cbHHMember.Enabled = false;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMembers", exc);
            }
        }

        private void LoadListsVisit()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsVisit(lblDemId.Text, "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsVisit(string strDemId, string strVstId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                drmEnrollmentMemberVisit dalDEMV = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalDEMV = new drmEnrollmentMemberVisit();
                dt = dalDEMV.GetList(strDemId, strVstId, FormMaster.LanguageId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "vst_id", "vst_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbVisit, dt, "vst_id", "vst_name");
                #endregion Load Lists

                #region Set List Selection
                if (strVstId.Length != 0)
                    cbVisit.SelectedValue = strVstId;
                else
                    cbVisit.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }
        #endregion Load Lists

        #region Save
        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmEnrollment dalDE = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDE = new drmEnrollment();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalDE.de_id = ObjectId;
                            dalDE.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDE.Load(ObjectId, dbCon);

                        dalDE.dst_id = cbDistrict.SelectedValue.ToString();
                        dalDE.flt_id = cbFacility.SelectedValue.ToString();
                        dalDE.usr_id_update = FormMaster.UserId;

                        dalDE.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        SetControls(true);
                        ClearLine();
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
                drmEnrollmentMember dalDEM = null;
                drmMember dalDM = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputLine();
                string strDmId = string.Empty;
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDEM = new drmEnrollmentMember();
                        dbCon.TransactionBegin();
                        try
                        {
                            #region Member
                            dalDM = new drmMember();
                            if (!rbtnMemberExisting.Checked)
                            {
                                dalDM.dm_id = Guid.NewGuid().ToString();

                                if (rbtnMemberExternal.Checked)
                                {
                                    dalDM.dm_first_name = txtFirstName.Text.Trim();
                                    dalDM.dm_last_name = txtLastName.Text.Trim();
                                    dalDM.dm_village = txtVillage.Text.Trim();
                                    dalDM.wrd_id = cbWard.SelectedValue.ToString();
                                    dalDM.mtp_id = utilConstants.cMTExternal;
                                }
                                else if (rbtnMemberHousehold.Checked)
                                {
                                    dalDM.hhm_id = cbHHMember.SelectedValue.ToString();
                                    dalDM.mtp_id = utilConstants.cMTHousehold;
                                }

                                dalDM.dm_active = utilConstants.cDFActive;
                                dalDM.dm_id_no = txtDreamsId.Text.Trim();
                                dalDM.dm_dob = dtpDoB.Value;
                                dalDM.dm_registration = dtpDate.Value;
                                dalDM.etp_id = cbEntryType.SelectedValue.ToString();
                                dalDM.ofc_id = FormMaster.OfficeId;
                            }
                            else
                                dalDM = new drmMember(cbMember.SelectedValue.ToString(), dbCon);
                            dalDM.dm_phone = txtPhone.Text.Trim();
                            dalDM.usr_id_update = FormMaster.UserId;
                            dalDM.Save(dbCon);
                            #endregion Member

                            if (lblDemId.Text.Length == 0 || lblDemId.Text.Trim().Equals("-"))
                            {
                                dalDEM.dem_id = Guid.NewGuid().ToString();
                                dalDEM.ofc_id = FormMaster.OfficeId;
                            }
                            else
                                dalDEM.Load(lblDemId.Text, dbCon);

                            dalDEM.dem_sn = txtSNumber.Text.Trim();
                            dalDEM.de_id = ObjectId;
                            dalDEM.dm_id = dalDM.dm_id;

                            dalDEM.est_id = cbEducationStatus.SelectedValue.ToString();
                            dalDEM.pst_id = cbParentalStatus.SelectedValue.ToString();
                            dalDEM.sst_id = cbSEROStatus.SelectedValue.ToString();
                            dalDEM.yn_id_disability = cbDisability.SelectedValue.ToString();
                            dalDEM.yn_id_given_birth = cbGivenBirth.SelectedValue.ToString();
                            dalDEM.yn_id_married = cbMarried.SelectedValue.ToString();
                            dalDEM.yn_id_partner = cbPartner.SelectedValue.ToString();
                            dalDEM.yn_id_pregnant = cbPregnant.SelectedValue.ToString();
                            dalDEM.yn_id_ts = cbTS.SelectedValue.ToString();

                            dalDEM.segment = utilControls.CheckedListGetSelectedValues(clbSocialEconomic, "lt_id");

                            dalDEM.usr_id_update = FormMaster.UserId;

                            dalDEM.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
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

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveLine", exc);
            }
        }

        private void SaveVisit()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmEnrollmentMemberVisit dalDEMV = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputVisit();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDEMV = new drmEnrollmentMemberVisit();

                        if (lblDemvId.Text.Length == 0 || lblDemvId.Text.Trim().Equals("-"))
                        {
                            dalDEMV.demv_id = Guid.NewGuid().ToString();
                            dalDEMV.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalDEMV.Load(lblDemvId.Text, dbCon);

                        dalDEMV.vst_id = cbVisit.SelectedValue.ToString();
                        dalDEMV.demv_comment = txtComment.Text.Trim();
                        dalDEMV.demv_referral = txtReferral.Text.Trim();
                        dalDEMV.demv_date = dtpVisitDate.Value;

                        dalDEMV.yn_id_anc = Convert.ToInt32(chkANC.Checked).ToString();
                        dalDEMV.yn_id_art = Convert.ToInt32(chkART.Checked).ToString();
                        dalDEMV.yn_id_cmnc = Convert.ToInt32(chkCMNC.Checked).ToString();
                        dalDEMV.yn_id_condom_promotion = Convert.ToInt32(chkCondomPromotion.Checked).ToString();
                        dalDEMV.yn_id_contraceptive_mix = Convert.ToInt32(chkContraceptiveMix.Checked).ToString();
                        dalDEMV.yn_id_hiv_testing = Convert.ToInt32(chkHIVTesting.Checked).ToString();
                        dalDEMV.yn_id_parenting_program = Convert.ToInt32(chkParentingProgram.Checked).ToString();
                        dalDEMV.yn_id_post_violence_care = Convert.ToInt32(chkPostViolenceCare.Checked).ToString();
                        dalDEMV.yn_id_school_based_prevention = Convert.ToInt32(chkSchoolBasedPrevention.Checked).ToString();
                        dalDEMV.yn_id_social_economic = Convert.ToInt32(chkSocioEconomic.Checked).ToString();
                        dalDEMV.yn_id_vmmc = Convert.ToInt32(chkVMMC.Checked).ToString();

                        dalDEMV.dem_id = lblDemId.Text;
                        dalDEMV.usr_id_update = FormMaster.UserId;

                        dalDEMV.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;

                        ClearVisit();
                        LoadDisplayVisits(dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveVisit", exc);
            }
        }
        #endregion Save

        #region Set Display
        private void SetAgeAtRegistration()
        {
            #region Variables
            int intAge = 0;
            #endregion Variables

            #region Set Age
            intAge = dtpDate.Value.Year - dtpDoB.Value.Year;
            if (dtpDoB.Value.AddHours(-23) > dtpDate.Value.AddYears(-intAge))
                intAge--;
            lblAgeAtRegistrationDisplay.Text = intAge.ToString();
            #endregion Set Age
        }

        private void SetControls(bool blnEnabled)
        {
            btnMemberCancel.Enabled = blnEnabled;
            btnMemberSave.Enabled = blnEnabled;
            cbSubCounty.Enabled = blnEnabled;
            cbWard.Enabled = blnEnabled;
            rbtnMemberExisting.Enabled = blnEnabled;
            rbtnMemberExternal.Enabled = blnEnabled;
            rbtnMemberHousehold.Enabled = blnEnabled;
            if (!blnEnabled)
            {
                rbtnMemberExisting.Checked = true;
                if (cbMember.Items.Count != 0)
                    cbMember.SelectedIndex = 0;
                if (cbSubCounty.Items.Count != 0)
                    cbSubCounty.SelectedIndex = 0;
                if (cbWard.Items.Count != 0)
                    cbWard.SelectedIndex = 0;
            }
        }

        private void SetControlsVisit(bool blnEnabled)
        {
            btnVisitCancel.Enabled = blnEnabled;
            btnVisitSave.Enabled = blnEnabled;
            cbVisit.Enabled = blnEnabled;
            if (!blnEnabled)
            {
                if (cbVisit.Items.Count != 0)
                    cbVisit.SelectedIndex = 0;
            }
        }

        private void SetMembers(bool blnEnabled)
        {
            if (rbtnMemberExisting.Checked)
            {
                tlpMemberExisting.Visible = true;
                tlpMemberExternal.Visible = false;
                tlpMemberHousehold.Visible = false;

                cbEntryType.Enabled = false;
                cbSubCounty.Enabled = false;
                cbWard.Enabled = false;
                dtpDate.Enabled = false;
                dtpDoB.Enabled = false;
                txtDreamsId.Enabled = false;
                txtVillage.Enabled = false;
                rbtnMemberExternal.Enabled = blnEnabled;
                rbtnMemberHousehold.Enabled = blnEnabled;
            }
            else if (rbtnMemberExternal.Checked)
            {
                tlpMemberExisting.Visible = false;
                tlpMemberExternal.Visible = true;
                tlpMemberHousehold.Visible = false;

                cbEntryType.Enabled = true;
                cbSubCounty.Enabled = true;
                cbWard.Enabled = true;
                dtpDate.Enabled = true;
                dtpDoB.Enabled = true;
                txtDreamsId.Enabled = true;
                txtVillage.Enabled = true;
            }
            else if (rbtnMemberHousehold.Checked)
            {
                tlpMemberExisting.Visible = false;
                tlpMemberExternal.Visible = false;
                tlpMemberHousehold.Visible = true;

                cbEntryType.Enabled = true;
                cbSubCounty.Enabled = false;
                cbWard.Enabled = false;
                dtpDate.Enabled = true;
                dtpDoB.Enabled = true;
                txtDreamsId.Enabled = true;
                txtVillage.Enabled = false;
            }
            if(cbHHCode.Items.Count != 0)
                cbHHCode.SelectedIndex = 0;
            if (cbHHMember.Items.Count != 0)
                cbHHMember.SelectedIndex = 0;
            if (cbMember.Items.Count != 0)
                cbMember.SelectedIndex = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            cbEntryType.SelectedIndex = 0;
            cbSubCounty.SelectedIndex = 0;
            cbWard.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            dtpDoB.Value = DateTime.Now;
            txtDreamsId.Text = string.Empty;
            txtVillage.Text = string.Empty;

            tlpMemberExisting.Location = new Point(pintMemberX, pintMemberY);
            tlpMemberExternal.Location = new Point(pintMemberX, pintMemberY);
            tlpMemberHousehold.Location = new Point(pintMemberX, pintMemberY);
        }
        #endregion Set Display

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
            if (cbDistrict.SelectedIndex == 0)
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
            drmMember dalDM = null;

            string strDmId = string.Empty;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbWard.SelectedIndex == 0 || txtDreamsId.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else
            {
                if (rbtnMemberExisting.Checked)
                {
                    if (cbMember.SelectedIndex == 0)
                        strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
                }
                else if (rbtnMemberExternal.Checked)
                {
                    if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0)
                        strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
                }
                else if (rbtnMemberHousehold.Checked)
                {
                    if (cbHHMember.SelectedIndex == 0)
                        strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
                }
            }
            #endregion Required Fields

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region DREAMS ID Check
                if (txtDreamsId.Text.Trim().Length != 0)
                {
                    dalDM = new drmMember();
                    if (rbtnMemberExisting.Checked)
                        strDmId = cbMember.SelectedValue.ToString();
                    if (dalDM.CheckIDNoInUse(strDmId, txtDreamsId.Text.Trim(), dbCon))
                        strMessage = strMessage + "," + utilConstants.cMIDDREAMSIdInUse;
                }
                #endregion DREAMS ID Check

                #region Get Messages
                if (strMessage.Length != 0)
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
                #endregion Get Messages
            }
            finally
            {
                dbCon.Dispose();
            }

            return strMessage;
        }

        private string ValidateInputVisit()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbVisit.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageDREAMSEnrolmentRegister, dbCon);
                btnSave.Visible = pblnManage;
                btnMemberSave.Visible = pblnManage;
                btnVisitSave.Visible = pblnManage;
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
