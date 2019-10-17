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
    public partial class frm_HouseholdHomeVisit : UserControl
    {

        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frm_HouseholdHomeVisitMain frmCll = null;
        private Master frmMST = null;
        DataTable dt = null;
        #endregion Variables

        #region Property
        public frm_HouseholdHomeVisitMain FormCalling
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

        public frm_HouseholdHomeVisit()
        {
            InitializeComponent();
        }

        private void frm_HouseholdHomeVisit_Load(object sender, EventArgs e)
        {
            LoadHousehold(HouseholdId);
            LoadDisplay();
            set_home_visit_reason(ObjectId);
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
            hhHouseholdMember dalHHM = null;
            utilLanguageTranslation utilLT = null;

            DataTable dt = null;
            string strEmptySingleSelect = string.Empty;
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
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                        lblSubCountyDisplay.Text = dt.Rows[0]["sct_name"].ToString();
                        lblVillageDisplay.Text = dt.Rows[0]["hh_village"].ToString().ToUpper();
                        lblWardDisplay.Text = dt.Rows[0]["wrd_name"].ToString();
                        lblHouseholdCodeDisplay.Text = dt.Rows[0]["hh_code"].ToString();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                        dalHHM = new hhHouseholdMember();
                        dt = dalHHM.GetList(strId, dbCon);
                        dt = utilCollections.AddEmptyItemFront(dt, "hhm_id", "hhm_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                        utilControls.ComboBoxFill(cbHHMember, dt, "hhm_id", "hhm_name");
                    }
                    else
                    {
                        ClearHousehold();
                    }
                }
                else
                {
                    ClearHousehold();
                }
                #endregion Household
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadHousehold", exc);
            }
        }

        private void ClearHousehold()
        {
            try
            {
                #region Clear
                if (HouseholdId.Length == 0)
                {
                    #region Clear
                    lblDistrictDisplay.Text = string.Empty;
                    lblSubCountyDisplay.Text = string.Empty;
                    lblVillageDisplay.Text = string.Empty;
                    lblWard.Text = string.Empty;
                    cbHHMember.SelectedIndex = -1;
                    cbHHMember.Enabled = false;
                    #endregion Clear
                }
                else
                {
                    LoadHousehold(HouseholdId);
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(DataAccessLayer.utilConstants.cPTError, this.Name, "ClearHousehold", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                hhHouseholdHomeVisit dalHHV = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Data
                    if (ObjectId.Length == 0)
                    {
                        Clear();
                    }
                    else
                    {
                        LoadLists();

                        #region Visit
                        dt = hhHouseholdHomeVisit_v2.LoadHomeVisitDisplay(ObjectId);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dtRow = dt.Rows[0];
                            cbHHMember.SelectedValue = dtRow["hhm_id"].ToString();
                            cbSocialWorker.SelectedValue = dtRow["swk_id"].ToString();
                            cbHomeVisitReason.SelectedValue = dtRow["hvr_id"].ToString();
                            cbHomeVisitHouseholdStatus.SelectedValue = dtRow["hvhs_id"].ToString();
                            dtpDateOfVisit.Value = Convert.ToDateTime(dtRow["hhv_date"].ToString());
                            utilControls.RadioButtonSetSelection(rbtnRiskAssYes, rbtnRiskAssNo, rbtnRiskAssNA, dtRow["ynna_risk_assessment"].ToString());
                            utilControls.RadioButtonSetSelection(rbtnReferalMadeYes, rbtnReferalMadeNo, rbtnReferalMadeNA, dtRow["ynna_new_referal"].ToString());
                            utilControls.RadioButtonSetSelection(rbtnOldReferalYes, rbtnOldReferalNo, rbtnOldReferalNA, dtRow["ynna_old_referal_followup"].ToString());
                            utilControls.RadioButtonSetSelection(rbtnHipYes, rbtnHipNo, dtRow["yn_hip"].ToString());
                            txtComments.Text = dtRow["hhv_comments"].ToString();
                            txtNextSteps.Text = dtRow["hhv_next_steps"].ToString();
                            cbHomeVisitor.SelectedValue = dtRow["swk_id_visitor"].ToString();
                            cbHomeVisitorTitle.SelectedValue = dtRow["hnr_id_visitor"].ToString();
                            txtHomeVisitorTel.Text = dtRow["hhv_visitor_tel"].ToString();
                            dtpNextVisitDate.Value = Convert.ToDateTime(dtRow["hhv_date_next_visit"].ToString());
                            SystemConstants.household_status = dtRow["hvhs_id"].ToString();
                            SystemConstants.object_id = ObjectId;

                            FormCalling.ObjectId = ObjectId;
                            FormCalling.MembersTab(ObjectId);
                        }
                        #endregion Visit


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



        private void LoadLists(string strAmID, string strHvhsID, string strHvrID, string strSwkID, string strSwkIDVisitor, string strHnrIDVisitor, DataAccessLayer.DBConnection dbCon)
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
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                pblnLoading = true;
                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_average_meals", true, strAmID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);


                dt = uLT.GetData("lst_home_visit_household_status", true, strHvhsID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitHouseholdStatus, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_home_visit_reason", true, strHvrID, true, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitReason, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_honorific", true, strHnrIDVisitor, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitorTitle, dt, "lt_id", "lt_name");

                #region Social Worker
                dalHh = new hhHousehold(HouseholdId, dbCon);

                if (strSwkID.Length == 0 || strSwkID.Equals(utilConstants.cDFEmptyListValue))
                    strSwkID = dalHh.swk_id;

                dalSwk = new swmSocialWorker();
                if (strSwkID.Length == 0)
                    dt = dalSwk.GetList("", "", dalHh.dst_id, dbCon);
                else
                    dt = dalSwk.GetList(strSwkID, "", dalHh.dst_id, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");

                if (strSwkIDVisitor.Length == 0)
                    strSwkIDVisitor = strSwkID;

                if (strSwkIDVisitor.Length == 0)
                    dt = dalSwk.GetList("", "", dalHh.dst_id, dbCon);
                else
                    dt = dalSwk.GetList(strSwkIDVisitor, "", dalHh.dst_id, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHomeVisitor, dt, "swk_id", "swk_name");
                #endregion Social Worker
                #endregion Load Lists

                #region Set List Selection

                if (strHvhsID.Length != 0)
                    cbHomeVisitHouseholdStatus.SelectedValue = strHvhsID;
                else
                    cbHomeVisitHouseholdStatus.SelectedIndex = 0;
                if (strHvrID.Length != 0)
                    cbHomeVisitReason.SelectedValue = strHvrID;
                else
                    cbHomeVisitReason.SelectedIndex = 0;
                if (strHnrIDVisitor.Length != 0)
                    cbHomeVisitorTitle.SelectedValue = strHnrIDVisitor;
                else
                    cbHomeVisitorTitle.SelectedIndex = 0;

                if (strSwkID.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkID;
                else
                    cbSocialWorker.SelectedIndex = 0;
                if (strSwkIDVisitor.Length != 0)
                    cbHomeVisitor.SelectedValue = strSwkIDVisitor;
                else
                    cbHomeVisitor.SelectedIndex = 0;
                #endregion Set List Selection
                pblnLoading = false;
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
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
                LoadLists("", "", "", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void Back()
        {
            FormCalling.Back();
        }

        private void Clear()
        {
            #region Clear
            cbHHMember.SelectedIndex = 0;

            dtpDateOfVisit.Value = DateTime.Now;
            dtpNextVisitDate.Value = DateTime.Now;

            txtComments.Text = string.Empty;
            txtHomeVisitorTel.Text = string.Empty;
            txtNextSteps.Text = string.Empty;
            txtSocialWorkerCode.Text = string.Empty;

            LoadLists();
            #endregion Clear
        }

        private void cbSocialWorker_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSocialWorker.SelectedIndex != 0)
                LoadHomeVisitor(cbSocialWorker.SelectedValue.ToString());
        }

        private void cbHomeVisitor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHomeVisitor.SelectedIndex != 0)
                LoadHomeVisitor(cbHomeVisitor.SelectedValue.ToString());
        }

        private void LoadHomeVisitor(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadHomeVisitor(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadHomeVisitor(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            swmSocialWorker dalSwk = null;
            #endregion Vaiables

            #region Load Values
            if (cbHomeVisitor.SelectedIndex == 0)
                cbHomeVisitor.SelectedValue = strId;

            if (cbHomeVisitorTitle.SelectedIndex == 0 || txtHomeVisitorTel.Text.Trim().Length == 0)
            {
                dalSwk = new swmSocialWorker(strId, dbCon);
                if (cbHomeVisitorTitle.SelectedIndex == 0)
                    cbHomeVisitorTitle.SelectedValue = dalSwk.hnr_id;
                if (txtHomeVisitorTel.Text.Trim().Length == 0)
                    txtHomeVisitorTel.Text = dalSwk.swk_phone;
            }
            #endregion Load Values
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                save();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void set_home_visit_reason(string object_id)
        {
            if (object_id.Length == 0)
            {
                SystemConstants._household_status = SystemConstants.Return_household_status(HouseholdId);
                if (SystemConstants._household_status == "2") //household is graduated
                {
                    cbHomeVisitReason.SelectedValue = "4";
                    cbHomeVisitHouseholdStatus.SelectedValue = "2";
                    cbHomeVisitReason.Enabled = false;
                    cbHomeVisitHouseholdStatus.Enabled = false;
                }
                else
                {
                    cbHomeVisitReason.SelectedValue = "-1";
                    cbHomeVisitHouseholdStatus.SelectedValue = "-1";
                    cbHomeVisitReason.Enabled = true;
                    cbHomeVisitHouseholdStatus.Enabled = true;
                }
            }

        }

        protected bool ValidateInput()
        {
            bool isValid = false;

            if (cbHomeVisitHouseholdStatus.SelectedValue.ToString() != "1" && cbHomeVisitHouseholdStatus.SelectedValue.ToString() != "2")
            {
                if ((cbHHMember.SelectedValue.ToString() == "-1" && (cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "1" || cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "2")) || cbSocialWorker.SelectedValue.ToString() == "-1" || cbHomeVisitReason.SelectedValue.ToString() == "-1" ||
               dtpDateOfVisit.Checked == false || cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "-1" || cbHomeVisitor.SelectedValue.ToString() == "-1" || !dtpNextVisitDate.Checked)

                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                if ((cbHHMember.SelectedValue.ToString() == "-1" && (cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "1" || cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "2")) || cbSocialWorker.SelectedValue.ToString() == "-1" || cbHomeVisitReason.SelectedValue.ToString() == "-1" ||
               dtpDateOfVisit.Checked == false || cbHomeVisitHouseholdStatus.SelectedValue.ToString() == "-1" || (!rbtnRiskAssYes.Checked & !rbtnRiskAssNo.Checked & !rbtnRiskAssNA.Checked) ||
               (!rbtnOldReferalYes.Checked & !rbtnOldReferalNo.Checked & !rbtnOldReferalNA.Checked) || (!rbtnReferalMadeYes.Checked & !rbtnReferalMadeNo.Checked & !rbtnReferalMadeNA.Checked) ||
               (!rbtnHipYes.Checked & !rbtnHipNo.Checked) || cbHomeVisitor.SelectedValue.ToString() == "-1" || !dtpNextVisitDate.Checked)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }

               

            return isValid;
        }


        #region save
        private void save()
        {
            DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            #region set variables
           
            hhHouseholdHomeVisit_v2.hhv_date = dtpDateOfVisit.Value;
            hhHouseholdHomeVisit_v2.hhv_date_next_visit = dtpNextVisitDate.Value;
            hhHouseholdHomeVisit_v2.hhv_comments = txtComments.Text;
            hhHouseholdHomeVisit_v2.hhv_next_steps = txtNextSteps.Text;
            hhHouseholdHomeVisit_v2.ynna_risk_assessment = utilControls.RadioButtonGetSelection(rbtnRiskAssYes, rbtnRiskAssNo, rbtnRiskAssNA);
            hhHouseholdHomeVisit_v2.ynna_new_referal = utilControls.RadioButtonGetSelection(rbtnReferalMadeYes, rbtnReferalMadeNo, rbtnReferalMadeNA);
            hhHouseholdHomeVisit_v2.ynna_old_referal_followup = utilControls.RadioButtonGetSelection(rbtnOldReferalYes, rbtnOldReferalNo, rbtnOldReferalNA);
            hhHouseholdHomeVisit_v2.yn_hip = utilControls.RadioButtonGetSelection(rbtnHipYes, rbtnHipNo);
            hhHouseholdHomeVisit_v2.hhv_swk_code = txtSocialWorkerCode.Text;
            hhHouseholdHomeVisit_v2.hhv_visitor_tel = txtHomeVisitorTel.Text;
            hhHouseholdHomeVisit_v2.hvhs_id = cbHomeVisitHouseholdStatus.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.hvr_id = cbHomeVisitReason.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.hh_id = HouseholdId;
            hhHouseholdHomeVisit_v2.hhm_id = cbHHMember.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.hnr_id_visitor = cbHomeVisitorTitle.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.swk_id = cbSocialWorker.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.swk_id_visitor = cbHomeVisitor.SelectedValue.ToString();
            hhHouseholdHomeVisit_v2.usr_id_create = SystemConstants.user_id;
            hhHouseholdHomeVisit_v2.usr_id_update = SystemConstants.user_id;
            hhHouseholdHomeVisit_v2.usr_date_create = DateTime.Now;
            hhHouseholdHomeVisit_v2.usr_date_update = DateTime.Now;
            hhHouseholdHomeVisit_v2.ofc_id = SystemConstants.ofc_id;
            hhHouseholdHomeVisit_v2.district_id = SystemConstants.Return_office_district();

            if (ObjectId == string.Empty)
            {
                hhHouseholdHomeVisit_v2.hhv_id = Guid.NewGuid().ToString();
                ObjectId = hhHouseholdHomeVisit_v2.hhv_id;
                SystemConstants.object_id = ObjectId;
                hhHouseholdHomeVisit_v2.Insert_home_visit(dbCon);
                MessageBox.Show("Success", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SystemConstants.household_status = cbHomeVisitHouseholdStatus.SelectedValue.ToString();
                FormCalling.ObjectId = ObjectId;
                FormCalling.MembersTab(ObjectId);
            }
            else
            {
                hhHouseholdHomeVisit_v2.hhv_id = ObjectId;
                hhHouseholdHomeVisit_v2.Update_home_visit(dbCon);
                MessageBox.Show("Success", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SystemConstants.household_status = cbHomeVisitHouseholdStatus.SelectedValue.ToString();
                FormCalling.ObjectId = ObjectId;
                FormCalling.MembersTab(ObjectId);
            }
           

            #endregion set variables
        }
        #endregion save

        private void llblBackBottom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void cbHomeVisitHouseholdStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHomeVisitHouseholdStatus.SelectedValue.ToString() != "1" && cbHomeVisitHouseholdStatus.SelectedValue.ToString() != "2" && cbHomeVisitHouseholdStatus.SelectedValue.ToString() != "-1") 
            {
                cbHHMember.SelectedValue = "-1";
                cbHHMember.Enabled = false;

                TblDisplay01.Enabled = false;
                rbtnRiskAssYes.Checked = false;
                rbtnRiskAssNo.Checked = false;
                rbtnRiskAssNA.Checked = false;
                rbtnOldReferalYes.Checked = false;
                rbtnOldReferalNo.Checked = false;
                rbtnOldReferalNA.Checked = false;
                rbtnReferalMadeYes.Checked = false;
                rbtnReferalMadeNo.Checked = false;
                rbtnReferalMadeNA.Checked = false;
                rbtnHipYes.Checked = false;
                rbtnHipNo.Checked = false;
                
            }
            else
            {
                cbHHMember.Enabled = true;

                TblDisplay01.Enabled = true;
                rbtnRiskAssYes.Checked = false;
                rbtnRiskAssNo.Checked = false;
                rbtnRiskAssNA.Checked = false;
                rbtnOldReferalYes.Checked = false;
                rbtnOldReferalNo.Checked = false;
                rbtnOldReferalNA.Checked = false;
                rbtnReferalMadeYes.Checked = false;
                rbtnReferalMadeNo.Checked = false;
                rbtnReferalMadeNA.Checked = false;
                rbtnHipYes.Checked = false;
                rbtnHipNo.Checked = false;
            }
        }
    } 
}
