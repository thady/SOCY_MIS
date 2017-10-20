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
    public partial class frmReferral : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private frmReferralSearch frmCllSearch = null;
        private frmResultArea03 frmPrt = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmReferralSearch FormCallingSearch
        {
            get { return frmCllSearch; }
            set { frmCllSearch = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
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
        public frmReferral()
        {
            InitializeComponent();
        }

        private void frmReferral_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadHousehold(HouseholdId);
                LoadDisplay();
            }
        }

        private void frmReferral_Paint(object sender, PaintEventArgs e)
        {
            cbRAPrtCso.SelectionLength = 0;
            cbChildGuardianDistrict.SelectionLength = 0;
            cbChildGuardianSubCounty.SelectionLength = 0;
            cbChildGuardianWard.SelectionLength = 0;
            cbChildHHMember.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methdos
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ObjectId.Length == 0)
                Clear();
            else
                LoadDisplay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbChildHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbChildHHMember.SelectedIndex == 0)
                    LoadHouseholdMember("");
                else
                    LoadHouseholdMember(cbChildHHMember.SelectedValue.ToString());
            }
        }

        private void cbChildGuardianDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbChildGuardianDistrict.SelectedIndex == 0)
                    LoadListsArea("", "", "");
                else
                    LoadListsArea(cbChildGuardianDistrict.SelectedValue.ToString(), "", "");
            }
        }

        private void cbChildGuardianSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbChildGuardianDistrict.SelectedIndex == 0)
                    LoadListsArea("", cbChildGuardianSubCounty.SelectedValue.ToString(), "");
                else
                    LoadListsArea(cbChildGuardianDistrict.SelectedValue.ToString(), cbChildGuardianSubCounty.SelectedValue.ToString(), "");
            }
        }

        private void cbChildGuardianWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbChildGuardianWard.SelectedIndex != 0 && cbChildGuardianSubCounty.SelectedIndex == 0)
                    LoadListsArea("", "", cbChildGuardianWard.SelectedValue.ToString());
            }
        }

        private void dtpRADate_Leave(object sender, EventArgs e)
        {
            LoadListsHouseholdMember(HouseholdId, cbChildHHMember.SelectedValue.ToString());

        }

        private void dtpRADate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }
        
        #region Textboxes
        private void txtARName_Leave(object sender, EventArgs e)
        {
            if (txtFeedbackAgency.Text.Trim().Length == 0)
                txtFeedbackAgency.Text = txtARName.Text;
        }

        private void txtARLocation_Leave(object sender, EventArgs e)
        {
            if (txtFeedbackLocation.Text.Trim().Length == 0)
                txtFeedbackLocation.Text = txtARLocation.Text;
        }

        private void txtARContactName_Leave(object sender, EventArgs e)
        {
            if (txtFeedbackPerson.Text.Trim().Length == 0)
                txtFeedbackPerson.Text = txtARContactName.Text;
        }

        private void txtARContactTel_Leave(object sender, EventArgs e)
        {
            if (txtFeedbackTel.Text.Trim().Length == 0)
                txtFeedbackTel.Text = txtARContactTel.Text;
        }

        private void txtARContactEmail_Leave(object sender, EventArgs e)
        {
            if (txtFeedbackEmail.Text.Trim().Length == 0)
                txtFeedbackEmail.Text = txtARContactEmail.Text;
        }
        #endregion Textboxes
        #endregion Control Methdods

        #region Private Methods
        private void Back()
        {
            if (FormCalling != null)
            {
                FormCalling.LoadRecords();
                FormMaster.LoadControl(FormCalling, this.Name, false);
            }
            else if (FormParent != null)
            {
                FormCallingSearch.BackDisplay();
                FormParent.LoadControl(FormCallingSearch, this.Name);
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
                    txtARContactEmail.Text = string.Empty;
                    txtARContactName.Text = string.Empty;
                    txtARContactTel.Text = string.Empty;
                    txtARLocation.Text = string.Empty;
                    txtARName.Text = string.Empty;
                    txtChildAccompanyEmail.Text = string.Empty;
                    txtChildAccompanyName.Text = string.Empty;
                    txtChildAccompanyRelationship.Text = string.Empty;
                    txtChildAccompanyTel.Text = string.Empty;
                    txtChildCaseNature.Text = string.Empty;
                    txtChildCaseNo.Text = string.Empty;
                    txtChildGuardianName.Text = string.Empty;
                    txtChildGuardianTel.Text = string.Empty;
                    txtChildGuardianVillage.Text = string.Empty;
                    txtChildOther.Text = string.Empty;
                    txtChildPerpetrator.Text = string.Empty;
                    txtChildPerpetratorRelationship.Text = string.Empty;
                    txtFeedbackAgency.Text = string.Empty;
                    txtFeedbackCaseNo.Text = string.Empty;
                    txtFeedbackEmail.Text = string.Empty;
                    txtFeedbackIDNo.Text = string.Empty;
                    txtFeedbackLocation.Text = string.Empty;
                    txtFeedbackOther.Text = string.Empty;
                    txtFeedbackPerson.Text = string.Empty;
                    txtFeedbackPersonTitle.Text = string.Empty;
                    txtFeedbackServices.Text = string.Empty;
                    txtFeedbackTel.Text = string.Empty;
                    txtRAEmail.Text = string.Empty;
                    txtRALocation.Text = string.Empty;
                    txtRAPersonEmail.Text = string.Empty;
                    txtRAPersonName.Text = string.Empty;
                    txtRAPersonTel.Text = string.Empty;
                    txtRAPersonTitle.Text = string.Empty;
                    txtRATel.Text = string.Empty;
                    txtSerialNo.Text = string.Empty;
                    txtServiceBefore.Text = string.Empty;
                    txtServiceDiscussionOutcome.Text = string.Empty;
                    txtServiceReason.Text = string.Empty;
                    
                    rbtnChildHelplineNo.Checked = false;
                    rbtnChildHelplineYes.Checked = false;
                    rbtnServiceDiscussionNo.Checked = false;
                    rbtnServiceDiscussionYes.Checked = false;

                    dtpChildDateOccured.Value = DateTime.Now;
                    dtpFeedbackDate.Value = DateTime.Now;
                    dtpRADate.Value = DateTime.Now;

                    utilControls.CheckedListClear(clbServicesProvided);
                    utilControls.CheckedListClear(clbServicesReferred);

                    cbChildHHMember.SelectedIndex = 0;
                    cbRAPrtCso.SelectedIndex = 0;
                    LoadHouseholdMember("");
                    LoadListsArea("", "", "");
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

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhReferral dalRFR = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        LoadLists(HouseholdId, "", "", "".Split(utilConstants.cDFSplitChar), "".Split(utilConstants.cDFSplitChar), "", dbCon);
                    }
                    else
                    {
                        #region Assessment
                        dalRFR = new hhReferral();

                        if (ObjectId.Length != 0)
                        {
                            dalRFR.Load(ObjectId, dbCon); 
                            txtARContactEmail.Text = dalRFR.rfr_ar_contact_email;
                            txtARContactName.Text = dalRFR.rfr_ar_contact_name;
                            txtARContactTel.Text = dalRFR.rfr_ar_contact_tel;
                            txtARLocation.Text = dalRFR.rfr_ar_location;
                            txtARName.Text = dalRFR.rfr_ar_name;
                            txtChildAccompanyEmail.Text = dalRFR.rfr_cd_accompany_email;
                            txtChildAccompanyName.Text = dalRFR.rfr_cd_accompany_name;
                            txtChildAccompanyRelationship.Text = dalRFR.rfr_cd_accompany_relationship;
                            txtChildAccompanyTel.Text = dalRFR.rfr_cd_accompany_tel;
                            txtChildCaseNature.Text = dalRFR.rfr_cd_nature;
                            txtChildCaseNo.Text = dalRFR.rfr_cd_case_no;
                            txtChildGuardianName.Text = dalRFR.rfr_cd_guardian_name;
                            txtChildGuardianTel.Text = dalRFR.rfr_cd_guardian_tel;
                            txtChildGuardianVillage.Text = dalRFR.rfr_cd_guardian_village;
                            txtChildOther.Text = dalRFR.rfr_cd_other;
                            txtChildPerpetrator.Text = dalRFR.rfr_cd_perpetrator;
                            txtChildPerpetratorRelationship.Text = dalRFR.rfr_cd_perpetrator_relationship;
                            txtFeedbackAgency.Text = dalRFR.rfr_fb_agency_name;
                            txtFeedbackCaseNo.Text = dalRFR.rfr_fb_case_no;
                            txtFeedbackEmail.Text = dalRFR.rfr_fb_email;
                            txtFeedbackIDNo.Text = dalRFR.rfr_fb_id_no;
                            txtFeedbackLocation.Text = dalRFR.rfr_fb_location;
                            txtFeedbackOther.Text = dalRFR.rfr_fb_other;
                            txtFeedbackPerson.Text = dalRFR.rfr_fb_person_name;
                            txtFeedbackPersonTitle.Text = dalRFR.rfr_fb_person_title;
                            txtFeedbackServices.Text = dalRFR.rfr_fb_service;
                            txtFeedbackTel.Text = dalRFR.rfr_fb_tel;
                            txtRAEmail.Text = dalRFR.rfr_ra_email;
                            txtRALocation.Text = dalRFR.rfr_ra_location;
                            txtRAPersonEmail.Text = dalRFR.rfr_ra_person_email;
                            txtRAPersonName.Text = dalRFR.rfr_ra_person_name;
                            txtRAPersonTel.Text = dalRFR.rfr_ra_person_tel;
                            txtRAPersonTitle.Text = dalRFR.rfr_ra_person_title;
                            txtRATel.Text = dalRFR.rfr_ra_tel;
                            txtSerialNo.Text = dalRFR.rfr_serial_no;
                            txtServiceBefore.Text = dalRFR.rfr_service_before;
                            txtServiceDiscussionOutcome.Text = dalRFR.rfr_service_discussion;
                            txtServiceReason.Text = dalRFR.rfr_service_referral;

                            utilControls.RadioButtonSetSelection(rbtnChildHelplineYes, rbtnChildHelplineNo, dalRFR.yn_id_helpline);
                            utilControls.RadioButtonSetSelection(rbtnServiceDiscussionYes, rbtnServiceDiscussionNo, dalRFR.yn_id_discussion);

                            btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalRFR.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalRFR.ofc_id));

                            dtpChildDateOccured.Value = dalRFR.rfr_cd_date_occured;
                            dtpFeedbackDate.Value = dalRFR.rfr_fb_date;
                            dtpRADate.Value = dalRFR.rfr_ra_date;
                        }
                        #endregion Assessment

                        LoadLists(HouseholdId, dalRFR.hhm_id, dalRFR.prt_cso_id_ra, dalRFR.service_provided, dalRFR.service_referred, dalRFR.wrd_id_guardian, dbCon);
                        LoadHouseholdMember(dalRFR.hhm_id, dbCon);
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

        private void LoadHousehold(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHousehold(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }
        
        private void LoadHousehold(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHousehold dalHH = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Household
                dalHH = new hhHousehold();
                if (strId.Length != 0)
                {
                    dt = dalHH.GetHousehold(strId, FormMaster.LanguageId, dbCon);
                    if (utilCollections.HasRows(dt))
                    {
                        lblChildHHCodeDisplay.Text = dt.Rows[0]["hh_code"].ToString();
                        lblChildDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                        lblChildSubCountyDisplay.Text = dt.Rows[0]["sct_name"].ToString();
                        lblChildVillageDisplay.Text = dt.Rows[0]["hh_village"].ToString();
                        lblChildWardDisplay.Text = dt.Rows[0]["wrd_name"].ToString();
                    }
                }
                #endregion Household
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHousehold", exc);
            }
        }

        private void LoadHouseholdMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

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
            #region Variables
            hhHouseholdMember dalHHM = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Household Member
                dalHHM = new hhHouseholdMember();
                if (strId.Length != 0)
                {
                    dt = dalHHM.GetMember(strId, FormMaster.LanguageId, dbCon);
                    if (utilCollections.HasRows(dt))
                    {
                        lblChildGenderDisplay.Text = dt.Rows[0]["gnd_name"].ToString();
                        lblChildIDNoDisplay.Text = dt.Rows[0]["hh_code"].ToString() + "/" + dt.Rows[0]["hhm_number"].ToString();
                        if (dt.Rows[0]["hhm_year_of_birth"].ToString().Equals(utilConstants.cDFEmptyListValue))
                            lblChildAgeDisplay.Text = "-";
                        else
                            lblChildAgeDisplay.Text = (DateTime.Now.Year - Convert.ToInt32(dt.Rows[0]["hhm_year_of_birth"])).ToString();
                    }
                }
                else
                {
                    lblChildGenderDisplay.Text = "-";
                    lblChildAgeDisplay.Text = "-";
                    lblChildIDNoDisplay.Text = "-";
                }
                #endregion Household Member
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHouseholdMember", exc);
            }
        }

        private void LoadLists(string strHHId, string strHHMId, string strPrtCsoId, string[] strSvpId, string[] strSvrId, string strWrdId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists(strHHId, strHHMId, strPrtCsoId, strSvpId, strSvrId, strWrdId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strHhId, string strHhmId, string strPrtCsoId, string[] strSvpId, string[] strSvrId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                utilSOCY_MIS utilSM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                pblnLoading = true;
                #region Load Lists
                utilSM = new utilSOCY_MIS();

                dt = utilSM.GetListParentCSO(true, strPrtCsoId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRAPrtCso, dt, "lt_id", "lt_name");

                uLT = new utilListTable();

                dt = uLT.GetData("lst_service_provided", true, strSvpId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbServicesProvided, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_service_referred", true, strSvrId, true, FormMaster.LanguageId, dbCon.dbCon);
                utilControls.CheckedListFill(clbServicesReferred, dt, "lt_id", "lt_name");             
                #endregion Load Lists

                #region Set List Selection
                if (strPrtCsoId.Length != 0)
                    cbRAPrtCso.SelectedValue = strPrtCsoId;
                else
                    cbRAPrtCso.SelectedIndex = 0;

                utilControls.CheckedListCheck(clbServicesProvided, strSvpId, "lt_id");
                utilControls.CheckedListCheck(clbServicesReferred, strSvrId, "lt_id");
                #endregion Set List Selection

                LoadListsHouseholdMember(strHhId, strHhmId, dbCon);
                LoadListsArea("", "", strWrdId, dbCon);
                pblnLoading = false;
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
                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, cbChildGuardianDistrict, cbChildGuardianSubCounty, cbChildGuardianWard, FormMaster.LanguageId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void LoadListsHouseholdMember(string strHhId, string strHhmId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsHouseholdMember(strHhId, strHhmId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsHouseholdMember(string strHhId, string strHhmId, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetListUnderAge(strHhId, strHhmId, 18, dtpRADate.Value, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbChildHHMember, dt, "hhm_id", "hhm_name");
                #endregion Load Lists

                #region Set List Selection
                if (strHhmId.Length != 0)
                    cbChildHHMember.SelectedValue = strHhmId;
                else
                    cbChildHHMember.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsHouseholdMember", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                hhReferral dalRFR = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Home Visit
                        dbCon.TransactionBegin();
                        try
                        {
                            dalRFR = new hhReferral();

                            if (ObjectId.Length == 0)
                            {
                                ObjectId = Guid.NewGuid().ToString();
                                dalRFR.rfr_id = ObjectId;
                                dalRFR.ofc_id = FormMaster.OfficeId;
                            }
                            else
                                dalRFR.Load(ObjectId, dbCon);

                            dalRFR.rfr_ar_contact_email = txtARContactEmail.Text;
                            dalRFR.rfr_ar_contact_name = txtARContactName.Text;
                            dalRFR.rfr_ar_contact_tel = txtARContactTel.Text;
                            dalRFR.rfr_ar_location = txtARLocation.Text;
                            dalRFR.rfr_ar_name = txtARName.Text;
                            dalRFR.rfr_cd_accompany_email = txtChildAccompanyEmail.Text;
                            dalRFR.rfr_cd_accompany_name = txtChildAccompanyName.Text;
                            dalRFR.rfr_cd_accompany_relationship = txtChildAccompanyRelationship.Text;
                            dalRFR.rfr_cd_accompany_tel = txtChildAccompanyTel.Text;
                            dalRFR.rfr_cd_nature = txtChildCaseNature.Text;
                            dalRFR.rfr_cd_case_no = txtChildCaseNo.Text;
                            dalRFR.rfr_cd_guardian_name = txtChildGuardianName.Text;
                            dalRFR.rfr_cd_guardian_tel = txtChildGuardianTel.Text;
                            dalRFR.rfr_cd_guardian_village = txtChildGuardianVillage.Text;
                            dalRFR.rfr_cd_other = txtChildOther.Text;
                            dalRFR.rfr_cd_perpetrator = txtChildPerpetrator.Text;
                            dalRFR.rfr_cd_perpetrator_relationship = txtChildPerpetratorRelationship.Text;
                            dalRFR.rfr_fb_agency_name = txtFeedbackAgency.Text;
                            dalRFR.rfr_fb_case_no = txtFeedbackCaseNo.Text;
                            dalRFR.rfr_fb_email = txtFeedbackEmail.Text;
                            dalRFR.rfr_fb_id_no = txtFeedbackIDNo.Text;
                            dalRFR.rfr_fb_location = txtFeedbackLocation.Text;
                            dalRFR.rfr_fb_other = txtFeedbackOther.Text;
                            dalRFR.rfr_fb_person_name = txtFeedbackPerson.Text;
                            dalRFR.rfr_fb_person_title = txtFeedbackPersonTitle.Text;
                            dalRFR.rfr_fb_service = txtFeedbackServices.Text;
                            dalRFR.rfr_fb_tel = txtFeedbackTel.Text;
                            dalRFR.rfr_ra_email = txtRAEmail.Text;
                            dalRFR.rfr_ra_location = txtRALocation.Text;
                            dalRFR.rfr_ra_person_email = txtRAPersonEmail.Text;
                            dalRFR.rfr_ra_person_name = txtRAPersonName.Text;
                            dalRFR.rfr_ra_person_tel = txtRAPersonTel.Text;
                            dalRFR.rfr_ra_person_title = txtRAPersonTitle.Text;
                            dalRFR.rfr_ra_tel = txtRATel.Text;
                            dalRFR.rfr_serial_no = txtSerialNo.Text;
                            dalRFR.rfr_service_before = txtServiceBefore.Text;
                            dalRFR.rfr_service_discussion = txtServiceDiscussionOutcome.Text;
                            dalRFR.rfr_service_referral = txtServiceReason.Text;

                            dalRFR.yn_id_helpline = utilControls.RadioButtonGetSelection(rbtnChildHelplineYes, rbtnChildHelplineNo);
                            dalRFR.yn_id_discussion = utilControls.RadioButtonGetSelection(rbtnServiceDiscussionYes, rbtnServiceDiscussionNo);

                            dalRFR.rfr_cd_date_occured = dtpChildDateOccured.Value;
                            dalRFR.rfr_fb_date = dtpFeedbackDate.Value;
                            dalRFR.rfr_ra_date = dtpRADate.Value;

                            dalRFR.prt_cso_id_ra = cbRAPrtCso.SelectedValue.ToString();
                            dalRFR.wrd_id_guardian = cbChildGuardianWard.SelectedValue.ToString();
                            dalRFR.hhm_id = cbChildHHMember.SelectedValue.ToString();

                            dalRFR.usr_id_update = FormMaster.UserId;
                            dalRFR.service_provided = utilControls.CheckedListGetSelectedValues(clbServicesProvided, "lt_id");
                            dalRFR.service_referred = utilControls.CheckedListGetSelectedValues(clbServicesReferred, "lt_id");

                            //district id
                            dalRFR.district_id = static_variables.district_id;

                            dalRFR.Save(dbCon);
                            dbCon.TransactionCommit();
                        }
                        catch (Exception exc)
                        {
                            dbCon.TransactionRollback();
                            throw exc;
                        }
                        #endregion Home Visit

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
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

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtSerialNo.Text.Trim().Length == 0 || cbRAPrtCso.SelectedIndex == 0 || cbChildHHMember.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageReferrals, dbCon);
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