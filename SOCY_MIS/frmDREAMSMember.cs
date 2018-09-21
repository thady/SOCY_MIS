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
    public partial class frmDREAMSMember : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmDREAMSMemberSearch frmCll = null;
        private Master frmMST = null;

        private int pintMemberX = 9;
        private int pintMemberY = 55;
        #endregion Variables

        #region Property
        public frmDREAMSMemberSearch FormCalling
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
        public frmDREAMSMember()
        {
            InitializeComponent();
        }

        private void frmDREAMSMember_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmDREAMSMember_Paint(object sender, PaintEventArgs e)
        {
            cbEntryType.SelectionLength = 0;
            cbRecordType.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbWard.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDisplay();
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

        private void cbRecordType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbRecordType.SelectedIndex == 0)
                LoadDisplayRecords("");
            else
                LoadDisplayRecords(cbRecordType.SelectedValue.ToString());
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsArea(lblDstId.Text, cbSubCounty.SelectedValue.ToString(), "");
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                LoadListsArea(lblDstId.Text, "", cbWard.SelectedValue.ToString());
        }

        private void dgvRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmDREAMSHTC frmDhr = null;
                frmDREAMSPartnerTracking frmDpt = null;
                frmDREAMSSINOVUYOMissedSessions frmDsms = null;
                frmDREAMSSteppingStonesMissedSessions frmDssms = null;

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
                        case utilConstants.cDRTHTCRegister:
                            frmDhr = new frmDREAMSHTC();
                            frmDhr.FormCalling = this;
                            frmDhr.FormParent = frmCll.FormParent;
                            frmDhr.ObjectId = strID;
                            frmDhr.MemberId = ObjectId;
                            frmCll.FormParent.LoadControl(frmDhr, this.Name);
                            break;
                        case utilConstants.cDRTPartnerTracking:
                            frmDpt = new frmDREAMSPartnerTracking();
                            frmDpt.FormCalling = this;
                            frmDpt.FormParent = frmCll.FormParent;
                            frmDpt.ObjectId = strID;
                            frmDpt.MemberId = ObjectId;
                            frmCll.FormParent.LoadControl(frmDpt, this.Name);
                            break;
                        case utilConstants.cDRTSINOVUYOMissedSessions:
                            frmDsms = new frmDREAMSSINOVUYOMissedSessions();
                            frmDsms.FormCalling = this;
                            frmDsms.FormParent = frmCll.FormParent;
                            frmDsms.ObjectId = strID;
                            frmDsms.MemberId = ObjectId;
                            frmCll.FormParent.LoadControl(frmDsms, this.Name);
                            break;
                        case utilConstants.cDRTSteppingStonesMissedSessions:
                            frmDssms = new frmDREAMSSteppingStonesMissedSessions();
                            frmDssms.FormCalling = this;
                            frmDssms.FormParent = frmCll.FormParent;
                            frmDssms.ObjectId = strID;
                            frmDssms.MemberId = ObjectId;
                            frmCll.FormParent.LoadControl(frmDssms, this.Name);
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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SetAgeAtRegistration();
        }

        private void dtpDoB_ValueChanged(object sender, EventArgs e)
        {
            SetAgeAtRegistration();
        }

        private void llblBackTop_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void llblHTCRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSHTC frmNew = new frmDREAMSHTC();
            frmNew.FormCalling = this;
            frmNew.FormParent = frmCll.FormParent;
            frmNew.MemberId = ObjectId;
            frmCll.FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblPartnerTracking_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSPartnerTracking frmNew = new frmDREAMSPartnerTracking();
            frmNew.FormCalling = this;
            frmNew.FormParent = frmCll.FormParent;
            frmNew.MemberId = ObjectId;
            frmCll.FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSINOVUYOMissedSessions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSSINOVUYOMissedSessions frmNew = new frmDREAMSSINOVUYOMissedSessions();
            frmNew.FormCalling = this;
            frmNew.FormParent = frmCll.FormParent;
            frmNew.MemberId = ObjectId;
            frmCll.FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSteppingStonesMissedSessions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSSteppingStonesMissedSessions frmNew = new frmDREAMSSteppingStonesMissedSessions();
            frmNew.FormCalling = this;
            frmNew.FormParent = frmCll.FormParent;
            frmNew.MemberId = ObjectId;
            frmCll.FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Control methods

        #region Public Methods
        public void BackDisplay()
        {
            if (cbRecordType.SelectedIndex == 0)
                LoadDisplayRecords("");
            else
                LoadDisplayRecords(cbRecordType.SelectedValue.ToString());
        }
        #endregion Public Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormCalling.FormParent.LoadControl(FormCalling, this.Name);
        }

        private void LoadDisplay()
        {            
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                drmMember dalDM = null;
                hhHousehold dalHH = null;
                hhHouseholdMember dalHHM = null;
                utilSOCY_MIS utilSM = null;

                string strWrdId = string.Empty;
                #endregion Variables

                #region Load Data
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Load Display
                    dalDM = new drmMember(ObjectId, dbCon);
                    utilSM = new utilSOCY_MIS();

                    switch (dalDM.mtp_id)
                    {
                        case utilConstants.cMTExternal:
                            txtFirstName.Text = dalDM.dm_first_name;
                            txtLastName.Text = dalDM.dm_last_name;
                            txtVillage.Text = dalDM.dm_village;

                            strWrdId = dalDM.wrd_id;
                            break;
                        case utilConstants.cMTHousehold:
                            dalHHM = new hhHouseholdMember(dalDM.hhm_id, dbCon);
                            dalHH = new hhHousehold(dalHHM.hh_id, dbCon);

                            lblHHCodeDisplay.Text = dalHH.hh_code;
                            lblHHMemberDisplay.Text = dalHHM.hhm_first_name + " " + dalHHM.hhm_last_name;
                            txtVillage.Text = dalHH.hh_village;
                            strWrdId = dalHH.wrd_id;
                            break;
                    }

                    chkActive.Checked = Convert.ToBoolean(dalDM.dm_active);
                    dtpDate.Value = dalDM.dm_registration;
                    dtpDoB.Value = dalDM.dm_dob;
                    lblMtpId.Text = dalDM.mtp_id;
                    lblMemberTypeDisplay.Text = utilSM.GetListItemValue(dalDM.mtp_id, "lst_member_type", "mtp", FormMaster.LanguageId, dbCon);
                    txtDreamsId.Text = dalDM.dm_id_no;
                    txtPhone.Text = dalDM.dm_phone;
                    txtStatusReason.Text = dalDM.dm_status_reason;

                    LoadDisplayRecords("", dbCon);
                    LoadLists(dalDM.etp_id, strWrdId, dbCon);
                    SetControls();
                    btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalDM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalDM.ofc_id));
                    #endregion Load Display                
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

        private void LoadDisplayRecords(string strDrtId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplayRecords(strDrtId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplayRecords(string strDrtId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                drmMember dalDM = null;

                DataTable dt = null;
                #endregion Variables

                #region Load Records
                dalDM = new drmMember();
                dt = dalDM.GetRecords(ObjectId, strDrtId, FormMaster.LanguageId, dbCon);
                dgvRecords.AutoGenerateColumns = false;
                dgvRecords.DataSource = dt;
                #endregion Load Records
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayRecords", exc);
            }
        }

        private void LoadLists(string strEtpId, string strWrdId, DataAccessLayer.DBConnection dbCon)
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

                dt = uLT.GetData("lst_dreams_record_type", true, "", FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRecordType, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strEtpId.Length != 0)
                    cbEntryType.SelectedValue = strEtpId;
                else
                    cbEntryType.SelectedIndex = 0;
                #endregion Set List Selection
                LoadListsArea(lblDstId.Text, "", strWrdId, dbCon);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMemberDisplay", exc);
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
                DataTable dt = null;
                #endregion Variables

                utilSM.LoadListsArea(strDstId, strSctId, strWrdId, null, cbSubCounty, cbWard, FormMaster.LanguageId, dbCon);

                if (strDstId.Length == 0 || strDstId.Equals("-"))
                {
                    if (strWrdId.Length != 0 && !strWrdId.Equals(utilConstants.cDFEmptyListValue))
                    {
                        dt = utilSM.GetWardParentsWithNames(strWrdId, FormMaster.LanguageId, dbCon);
                        lblDstId.Text = dt.Rows[0]["dst_id"].ToString();
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                    }
                    else if (strSctId.Length != 0 && !strSctId.Equals(utilConstants.cDFEmptyListValue))
                    {
                        dt = utilSM.GetSubCountyParentsWithNames(strSctId, FormMaster.LanguageId, dbCon);
                        lblDstId.Text = dt.Rows[0]["dst_id"].ToString();
                        lblDistrictDisplay.Text = dt.Rows[0]["dst_name"].ToString();
                    }
                    else
                    {
                        lblDstId.Text = "";
                        lblDistrictDisplay.Text = "";
                    }
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                drmMember dalDM = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                string strDmId = string.Empty;
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalDM = new drmMember(ObjectId, dbCon);

                        switch (lblMtpId.Text)
                        {
                            case utilConstants.cMTExternal:
                                dalDM.dm_first_name = txtFirstName.Text.Trim();
                                dalDM.dm_last_name = txtLastName.Text.Trim();
                                dalDM.dm_village = txtVillage.Text.Trim();
                                dalDM.wrd_id = cbWard.SelectedValue.ToString();
                                break;
                            case utilConstants.cMTHousehold:
                                break;
                        }

                        dalDM.dm_active = Convert.ToInt32(chkActive.Checked);
                        dalDM.dm_status_reason = txtStatusReason.Text;

                        dalDM.dm_id_no = txtDreamsId.Text.Trim();
                        dalDM.dm_dob = dtpDoB.Value;
                        dalDM.dm_registration = dtpDate.Value;
                        dalDM.etp_id = cbEntryType.SelectedValue.ToString();
                        dalDM.dm_phone = txtPhone.Text.Trim();
                        dalDM.usr_id_update = FormMaster.UserId;
                        dalDM.Save(dbCon);

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

        private void SetControls()
        {
            switch (lblMtpId.Text)
            {
                case utilConstants.cMTExternal:
                    cbSubCounty.Enabled = true;
                    cbWard.Enabled = true;
                    txtVillage.Enabled = true;
                    tlpMemberExisting.Visible = true;
                    tlpMemberHousehold.Visible = false;
                    break;
                case utilConstants.cMTHousehold:
                    cbSubCounty.Enabled = false;
                    cbWard.Enabled = false;
                    txtVillage.Enabled = false;
                    tlpMemberExisting.Visible = false;
                    tlpMemberHousehold.Visible = true;
                    break;
            }
            tlpMemberExisting.Location = new Point(pintMemberX, pintMemberY);
            tlpMemberHousehold.Location = new Point(pintMemberX, pintMemberY);
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            drmMember dalDM = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbWard.SelectedIndex == 0 || txtDreamsId.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            else
            {
                switch (lblMtpId.Text)
                {
                    case utilConstants.cMTExternal:
                    if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0)
                        strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
                        break;
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
                    if (dalDM.CheckIDNoInUse(ObjectId, txtDreamsId.Text.Trim(), dbCon))
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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageDREAMSMembers, dbCon);
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
