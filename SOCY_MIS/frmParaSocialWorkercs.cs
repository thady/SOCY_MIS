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
    public partial class frmParaSocialWorkercs : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private bool pblnLoading = false;
        private string strId = string.Empty;
        private Master frmMST = null;
        private frmSocialWorkerSearch frmCll = null;
        #endregion Variables

        #region Property
        public frmSocialWorkerSearch FormCalling
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
        public frmParaSocialWorkercs()
        {
            InitializeComponent();
        }

        private void frmParaSocialWorkercs_Load(object sender, EventArgs e)
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

        private void frmParaSocialWorkercs_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbSocialWorker.SelectionLength = 0;
            cbStatus.SelectionLength = 0;
            cbSubCounty.SelectionLength = 0;
            cbTitle.SelectionLength = 0;
            cbWard.SelectionLength = 0;
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

        private void cbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", "", "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), "", "");
            }
        }

        private void cbSubCounty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbDistrict.SelectedIndex == 0)
                    LoadListsArea("", cbSubCounty.SelectedValue.ToString(), "");
                else
                    LoadListsArea(cbDistrict.SelectedValue.ToString(), cbSubCounty.SelectedValue.ToString(), "");
            }
        }

        private void cbWard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!pblnLoading)
            {
                if (cbWard.SelectedIndex != 0 && cbSubCounty.SelectedIndex == 0)
                    LoadListsArea("", "", cbWard.SelectedValue.ToString());
            }
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxIntegerAndSpaces(e.KeyChar, (sender as TextBox).Text);
        }
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtPhone.Text = string.Empty;
                    txtStatusReason.Text = string.Empty;
                    txtVillage.Text = string.Empty;
                    cbDistrict.SelectedIndex = 0;
                    cbSubCounty.SelectedIndex = 0;
                    cbWard.SelectedIndex = 0;
                    cbTitle.SelectedIndex = 0;
                    cbStatus.SelectedValue = utilConstants.cDFStatus;
                    numTarget.Value = 0;
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

                swmSocialWorker dalSwk = null;
                #endregion Variables

                #region Load Data
                if (ObjectId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSwk = new swmSocialWorker(ObjectId, dbCon);

                        txtFirstName.Text = dalSwk.swk_first_name;
                        txtLastName.Text = dalSwk.swk_last_name;
                        txtEmail.Text = dalSwk.swk_email;
                        txtPhone.Text = dalSwk.swk_phone;
                        txtStatusReason.Text = dalSwk.swk_status_reason;
                        txtVillage.Text = dalSwk.swk_village;
                        numTarget.Value = dalSwk.swk_hh_target != string.Empty? Convert.ToInt32(dalSwk.swk_hh_target) : 0;
                        //btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSwk.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSwk.ofc_id));

                        LoadLists(dalSwk.hnr_id, dalSwk.swk_id_manager, dalSwk.sws_id, dalSwk.wrd_id, dbCon);
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

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strHnrId, string strSwkIdManager, string strSwsId, string strWrdId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
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

                dt = uLT.GetData("lst_honorific", true, strHnrId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbTitle, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_social_worker_status", true, strSwsId, false, FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbStatus, dt, "lt_id", "lt_name");

                #region Social Worker
                dalSwk = new swmSocialWorker();
                if (strSwkIdManager.Length == 0)
                    dt = dalSwk.GetList(dbCon);
                else
                    dt = dalSwk.GetList(strSwkIdManager, utilConstants.cSWTSocialWorker, dbCon);

                dt = utilCollections.AddEmptyItemFront(dt, "swk_id", "swk_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSocialWorker, dt, "swk_id", "swk_name");
                #endregion Social Worker
                #endregion Load Lists
                pblnLoading = false;

                #region Set List Selection
                if (strHnrId.Length != 0)
                    cbTitle.SelectedValue = strHnrId;
                else
                    cbTitle.SelectedIndex = 0;
                if (strSwkIdManager.Length != 0)
                    cbSocialWorker.SelectedValue = strSwkIdManager;
                else
                    cbSocialWorker.SelectedIndex = 0;
                if (strSwsId.Length != 0)
                    cbStatus.SelectedValue = strSwsId;
                else
                    cbStatus.SelectedValue = utilConstants.cDFStatus;
                #endregion Set List Selection

                LoadListsArea("", "", strWrdId, dbCon);
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

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                swmSocialWorker dalSwk = null;
                
                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSwk = new swmSocialWorker();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalSwk.swk_id = ObjectId;
                            dalSwk.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSwk.Load(ObjectId, dbCon);

                        dalSwk.swk_first_name = txtFirstName.Text.Trim();
                        dalSwk.swk_last_name = txtLastName.Text.Trim();
                        dalSwk.swk_email = txtEmail.Text.Trim();
                        dalSwk.swk_phone = txtPhone.Text.Trim();
                        dalSwk.swk_status_reason = txtStatusReason.Text.Trim();
                        dalSwk.swk_village = txtVillage.Text.Trim();
                        dalSwk.hnr_id = cbTitle.SelectedValue.ToString();
                        dalSwk.swk_id_manager = cbSocialWorker.SelectedValue.ToString();
                        dalSwk.sws_id = cbStatus.SelectedValue.ToString();
                        dalSwk.swt_id = utilConstants.cSWTParaSocialWorker;
                        dalSwk.wrd_id = cbWard.SelectedValue.ToString();
                        dalSwk.district_id = static_variables.district_id;
                        dalSwk.usr_id_update = FormMaster.UserId;
                        dalSwk.swk_hh_target = numTarget.Value.ToString();

                        dalSwk.Save(dbCon);

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
            swmSocialWorker dalSwk = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtFirstName.Text.Trim().Length == 0 || txtLastName.Text.Trim().Length == 0 || txtPhone.Text.Trim().Length == 0 || cbWard.SelectedIndex == 0 || numTarget.Value == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Phone Number Check
                if (txtPhone.Text.Trim().Length != 0)
                {
                    if (txtPhone.Text.Replace(" ", "").Trim().Length != 0 && txtPhone.Text.Replace(" ", "").Trim().Length != utilConstants.cDFPhoneNumberLength)
                        strMessage = strMessage + "," + utilConstants.cMIDPhoneNumberLength;

                    dalSwk = new swmSocialWorker();
                    if (dalSwk.CheckPhoneNumberInUse(ObjectId, txtPhone.Text.Trim(), dbCon))
                        strMessage = strMessage + "," + utilConstants.cMIDPhoneNumberInUse; 
                }
                #endregion Phone Number Check

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
                pblnManage = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMManageParaSocialWorker, dbCon);
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
