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
    public partial class frmHousehold : UserControl
    {
        #region Variables
        private string strId = string.Empty;
        private frmHouseholdSearch frmCll = null;
        private Master frmMST = null;
        private bool pblnLoading = false;
        #endregion Variables

        #region Property
        public frmHouseholdSearch FormCalling
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
        public frmHousehold()
        {
            InitializeComponent();
        }

        private void frmHousehold_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                LoadDisplay();
            }
        }

        private void frmHousehold_Paint(object sender, PaintEventArgs e)
        {
            cbRecordType.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void cbRecordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbRecordType.SelectedIndex == 0)
                    LoadRecords("");
                else
                    LoadRecords(cbRecordType.SelectedValue.ToString());
            }
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmHouseholdMembers frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvMembers.SelectedCells.Count != 0)
                {
                    strID = dgvMembers.SelectedCells[0].OwningRow.Cells["gclHhmId"].Value.ToString();

                    frmNew = new frmHouseholdMembers();
                    frmNew.ObjectId = strID;
                    frmNew.HouseholdId = ObjectId;
                    frmNew.FormCalling = this;
                    frmNew.FormMaster = FormMaster;
                    FormMaster.LoadControl(frmNew, this.Name, false);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMembers", exc);
            }
        }

        private void dgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmHomeVisitTool frmHV = null;
                frmHouseholdHomeVisitMain frmHHV = null;
                frmHouseholdAssessmentMain frmHHA = null;
                frmOVCIdentificationPrioritization frmOIP = null;
                frmReferral frmRef = null;
                string strID = string.Empty;
                string strRtpId = string.Empty;
                #endregion

                #region Display Form
                if (dgvRecords.SelectedCells.Count != 0)
                {
                    strID = dgvRecords.SelectedCells[0].OwningRow.Cells["gclID"].Value.ToString();
                    strRtpId = dgvRecords.SelectedCells[0].OwningRow.Cells["gclRtpId"].Value.ToString();

                    switch (strRtpId)
                    {
                        case utilConstants.cRTHomeVisit:
                            frmHHV = new frmHouseholdHomeVisitMain();
                            frmHHV.ObjectId = strID;
                            frmHHV.HouseholdId = ObjectId;
                            frmHHV.FormCalling = this;
                            frmHHV.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmHHV, this.Name, true);
                            break;
                        case utilConstants.cRTHomeVisitArchive:
                            frmHV = new frmHomeVisitTool();
                            frmHV.ObjectId = strID;
                            frmHV.HouseholdId = ObjectId;
                            frmHV.FormCalling = this;
                            frmHV.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmHV, this.Name, false);
                            break;
                        case utilConstants.cRTHouseAssessment:
                            frmHHA = new frmHouseholdAssessmentMain();
                            frmHHA.ObjectId = strID;
                            frmHHA.HouseholdId = ObjectId;
                            frmHHA.FormCalling = this;
                            frmHHA.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmHHA, this.Name, true);
                            break;
                        case utilConstants.cRTOVCIdentificationPrioritization:
                            frmOIP = new frmOVCIdentificationPrioritization();
                            frmOIP.ObjectId = strID;
                            frmOIP.HouseholdId = ObjectId;
                            frmOIP.FormCalling = this;
                            frmOIP.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmOIP, this.Name, false);
                            break;
                        case utilConstants.cRTReferral:
                            frmRef = new frmReferral();
                            frmRef.ObjectId = strID;
                            frmRef.HouseholdId = ObjectId;
                            frmRef.FormCalling = this;
                            frmRef.FormMaster = FormMaster;
                            FormMaster.LoadControl(frmRef, this.Name, false);
                            break;
                        case utilConstants.cRTHIP:
                            #region Set Selected
                            frmHouseholdImprovementPlan frmNew = new frmHouseholdImprovementPlan();
                            frmNew.FormCalling = this;
                            frmNew.FormMaster = FormMaster;
                            hh_household_improvement_plan.hip_id_display = strID;
                            FormMaster.LoadControl(frmNew, this.Name, false);
                            #endregion
                            break;
                        case utilConstants.cRTOVCViralLoad:
                            #region Set Selected
                            frmOVC_Viral_load frmVL = new frmOVC_Viral_load();
                            frmVL.HouseholdId = ObjectId;
                            frmVL.FormCalling = this;
                            frmVL.FormMaster = FormMaster;
                            benOvcViralLoad._vl_id = strID;
                            FormMaster.LoadControl(frmVL, this.Name, false);
                            #endregion
                            break;
                        case utilConstants.cRTRiskAssessment:
                            #region Set Selected
                            frmHouseholdRiskAssessmentRegister frmNewRAS = new frmHouseholdRiskAssessmentRegister();
                            frmNewRAS.FormCalling = this;
                            frmNewRAS.FormMaster = FormMaster;
                            hh_household_risk_assessment_header._ras_id = strID;
                            FormMaster.LoadControl(frmNewRAS, this.Name, false);
                            #endregion
                            break;
                    }
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRecords", exc);
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblHomeVisit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHouseholdHomeVisitMain frmNew = new frmHouseholdHomeVisitMain();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, true);
            #endregion
        }

        private void llblHomeVisitArchive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHomeVisitTool frmNew = new frmHomeVisitTool();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblHouseholdAssessment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHouseholdAssessmentMain frmNew = new frmHouseholdAssessmentMain();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, true);
            #endregion
        }

        private void llblHouseholdDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHouseholdDetails frmNew = new frmHouseholdDetails();
            frmNew.ObjectId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblHouseholdMembers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHouseholdMembers frmNew = new frmHouseholdMembers();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblOVCIdentificationPrioritization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmOVCIdentificationPrioritization frmNew = new frmOVCIdentificationPrioritization();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblReferral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmReferral frmNew = new frmReferral();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }
        #endregion Control methods

        #region Public Methods
        public void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                DataTable dt = null;

                hhHousehold dalHH = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length != 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalHH = new hhHousehold();
                        dt = dalHH.GetHousehold(ObjectId, FormMaster.LanguageId, dbCon);

                        lblCodeDisplay.Text = dt.Rows[0]["hh_code"].ToString();
                        lblSocialWorkerDisplay.Text = dt.Rows[0]["swk_name"].ToString();
                        lblStatusDisplay.Text = dt.Rows[0]["hhs_name"].ToString();
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                        lblSubCountyDisplay.Text = dt.Rows[0]["sct_name"].ToString();
                        lblWardDisplay.Text = dt.Rows[0]["wrd_name"].ToString();
                        lblVillageDisplay.Text = dt.Rows[0]["hh_village"].ToString();

                        LoadLists(dbCon);
                        LoadMembers(dbCon);
                        LoadRecords("");

                        #region Set HH status forecolor
                        if (lblStatusDisplay.Text != "Active")
                        {
                            lblStatusDisplay.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblStatusDisplay.ForeColor = Color.Blue;
                        }
                        #endregion

                        #region DisbaleEntryforinactiveHH
                        if (lblStatusDisplay.Text != "Active" && lblStatusDisplay.Text != "Graduated")
                        {
                            tlpDisplay01.Enabled = false;
                            tlpDisplay02.Enabled = false;
                            gbMembers.Enabled = false;
                            dgvRecords.Enabled = false;
                        }
                        else
                        {
                            tlpDisplay01.Enabled = true;
                            tlpDisplay02.Enabled = true;
                            gbMembers.Enabled = true;
                            dgvRecords.Enabled = true;
                        }
                        #endregion

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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        public void LoadMembers()
        {
            if (!FormMaster.NoDatabase)
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
        }

        public void LoadRecords()
        {
            if (!FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    if (cbRecordType.SelectedIndex == 0)
                        LoadRecords("", dbCon);
                    else
                        LoadRecords(cbRecordType.SelectedValue.ToString(), dbCon);
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
        }
        #endregion Public Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        private void LoadLists(DataAccessLayer.DBConnection dbCon)
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

                pblnLoading = true;
                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_record_type", true, "", true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRecordType, dt, "lt_id", "lt_name");
                cbRecordType.SelectedIndex = 0;
                #endregion Load Lists
                pblnLoading = false;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadMembers(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            hhHouseholdMember dalHHM = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Load Datagrid
                dalHHM = new hhHouseholdMember();
                dt = dalHHM.GetMembers(ObjectId, FormMaster.LanguageId, dbCon);
                dgvMembers.AutoGenerateColumns = false;
                dgvMembers.DataSource = dt;
                #endregion Load Datagrid
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadMembers", exc);
            }
        }

        private void LoadRecords(string strRtpId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadRecords(strRtpId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadRecords(string strRtpId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                hhHousehold dalHH = null;

                DataTable dt = null;
                #endregion Variables
                
                #region Load Records
                dalHH = new hhHousehold();
                dt = dalHH.GetRecords(ObjectId, strRtpId, FormMaster.LanguageId, dbCon);
                dgvRecords.AutoGenerateColumns = false;
                dgvRecords.DataSource = dt;
                #endregion Load Records
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadRecords", exc);
            }
        }

        #endregion Private Methods

        private void llblLinkages_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_linkages_register register = new frm_linkages_register();
            register.ShowDialog();
        }

        private void lbl_risk_assessment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHouseholdRiskAssessmentRegister frmNew = new frmHouseholdRiskAssessmentRegister();
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblHip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frm_hh_household_improvement_plan plan = new frm_hh_household_improvement_plan();
            //plan.ShowDialog();

            #region Set Selected
            frmHouseholdImprovementPlan frmNew = new frmHouseholdImprovementPlan();
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void llblViralLoad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmOVC_Viral_load frmNew = new frmOVC_Viral_load();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void gbDetails_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void lblAdherence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmViralLoadCommunityIAC frmNew = new frmViralLoadCommunityIAC();
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }

        private void lblGBV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmGBV_screeningTool frmNew = new frmGBV_screeningTool();
            frmNew.HouseholdId = ObjectId;
            frmNew.FormCalling = this;
            frmNew.FormMaster = FormMaster;
            FormMaster.LoadControl(frmNew, this.Name, false);
            #endregion
        }
    }
}
