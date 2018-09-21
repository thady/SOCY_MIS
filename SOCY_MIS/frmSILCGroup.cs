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
    public partial class frmSILCGroup : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmSILCGroupSearch frmCll = null;
        private frmSILC frmPrt = null;
        private Master frmMST = null;
        private int pintMemberPanelX = 6;
        private int pintMemberPanelY = 59;
        #endregion Variables

        #region Property
        public frmSILCGroupSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public frmSILC FormParent
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
        public frmSILCGroup()
        {
            InitializeComponent();
        }

        private void frmSILCGroup_Load(object sender, EventArgs e)
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
                LoadLists();
                LoadListsMember("", "");
            }
        }

        private void frmSILCGroup_Paint(object sender, PaintEventArgs e)
        {
            cbHHCode.SelectionLength = 0;
            cbHHMember.SelectionLength = 0;
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

        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            ClearSILCMember();
        }

        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                SaveMember();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cbHHCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbHHCode.SelectedIndex == 0)
                LoadListsMember("", "");
            else
                LoadListsMember(cbHHCode.SelectedValue.ToString(), "");
        }

        private void cbHHMember_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDisplayMember(cbHHMember.SelectedValue.ToString());
        }

        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvMember.SelectedCells.Count != 0)
                {
                    strID = dgvMember.SelectedCells[0].OwningRow.Cells["gclMemId"].Value.ToString();
                    LoadDisplaySILCMember(strID);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvMember", exc);
            }
        }

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Variables
                frmSILCSavingsRegister frmNew = null;
                string strID = string.Empty;
                #endregion

                #region Display Form
                if (dgvRegister.SelectedCells.Count != 0)
                {
                    strID = dgvRegister.SelectedCells[0].OwningRow.Cells["gclRegId"].Value.ToString();

                    frmNew = new frmSILCSavingsRegister();
                    frmNew.ObjectId = strID;
                    frmNew.SILCGroupId = ObjectId;
                    frmNew.FormCalling02 = this;
                    frmNew.FormMaster = FormMaster;
                    FormParent.LoadControl(frmNew, this.Name);
                }
                #endregion Display Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "dgvRegister", exc);
            }
        }

        private void llblSILCSavingsRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmSILCSavingsRegister frmNew = new frmSILCSavingsRegister();
            frmNew.SILCGroupId = ObjectId;
            frmNew.FormCalling02 = this;
            frmNew.FormMaster = FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        private void rbtnGroupMemberHousehold_CheckedChanged(object sender, EventArgs e)
        {
            SetMemberPanel(rbtnGroupMemberHousehold.Checked);
        }
        #endregion Control Methods

        #region Public Methods
        public void BackDisplay()
        {
            if (!FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Set Display
                    if (ObjectId.Length != 0)
                    {
                        LoadDisplayMembers(ObjectId, dbCon);
                        LoadDisplayRegisters(ObjectId, dbCon);
                    }
                    #endregion Set Display
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
            FormCalling.FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    txtSILCGroup.Text = string.Empty;
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

        private void ClearSILCMember()
        {
            try
            {
                #region Clear
                lblSgmId.Text = string.Empty;
                cbHHCode.SelectedIndex = 0;
                cbHHMember.SelectedIndex = 0;
                chkActive.Checked = true;
                txtExternalMemberName.Text = string.Empty;
                txtStatusReason.Text = string.Empty;
                btnMemberSave.Enabled = pblnManage;
                LoadListsMember("", "");
                SetHouseholdControls(true);
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ClearSILCMember", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                silcGroup dalSG = null;
                #endregion Variables

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    if (ObjectId.Length != 0)
                    {
                        dalSG = new silcGroup(ObjectId, dbCon);
                        txtSILCGroup.Text = dalSG.sg_name;
                        btnSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSG.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSG.ofc_id));
                        LoadDisplayMembers(ObjectId, dbCon);
                        LoadDisplayRegisters(ObjectId, dbCon);
                        SetControls(true); 
                    }
                    else
                    {
                        SetControls(false);
                    }
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
                dt = dalHhm.GetMember(strId, FormMaster.LanguageId, dbCon);
                dr = dt.Rows[0];

                cbHHCode.SelectedValue = dr["hh_id"].ToString();
                LoadListsMember(dr["hh_id"].ToString(), strId, dbCon);
                cbHHMember.SelectedValue = strId;
                #endregion Load Display Line
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayMember", exc);
            }
        }

        private void LoadDisplayMembers(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            silcGroup dalSG = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Load Datagrid
                dalSG = new silcGroup();
                dt = dalSG.GetMembers(ObjectId, FormMaster.LanguageId, dbCon);
                dgvMember.AutoGenerateColumns = false;
                dgvMember.DataSource = dt;
                #endregion Load Datagrid
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayMembers", exc);
            }
        }

        private void LoadDisplayRegisters(string strId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            silcGroup dalSG = null;
            DataTable dt = null;
            #endregion Variables

            try
            {
                #region Load Datagrid
                dalSG = new silcGroup();
                dt = dalSG.GetSavingsRegisters(ObjectId, FormMaster.LanguageId, dbCon);
                dgvRegister.AutoGenerateColumns = false;
                dgvRegister.DataSource = dt;
                #endregion Load Datagrid
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplayRegisters", exc);
            }
        }

        private void LoadDisplaySILCMember(string strId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadDisplaySILCMember(strId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadDisplaySILCMember(string strId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                silcGroupMember dalSGM = new silcGroupMember();
                #endregion Variables

                #region Load Display Line
                dalSGM.Load(strId, dbCon);

                lblSgmId.Text = dalSGM.sgm_id;
                chkActive.Checked = Convert.ToBoolean(dalSGM.sgm_active);
                txtStatusReason.Text = dalSGM.sgm_status_reason;
                btnMemberSave.Enabled = pblnManage && (FormMaster.OfficeId.Equals(dalSGM.ofc_id) || SystemConstants.Validate_Office_group_access(FormMaster.OfficeId, dalSGM.ofc_id));

                switch (dalSGM.mtp_id)
                {
                    case utilConstants.cMTExternal:
                        rbtnGroupMemberExternal.Checked = true;
                        txtExternalMemberName.Text = dalSGM.sgm_name;
                        break;
                    case utilConstants.cMTHousehold:
                        rbtnGroupMemberHousehold.Checked = true;
                        LoadDisplayMember(dalSGM.hhm_id, dbCon);
                        break;
                }
                #endregion Load Display Line
                SetHouseholdControls(false);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplaySILCMember", exc);
            }
        }

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            #region Load Lists
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Load Lists
        }

        private void LoadLists(string strHhId, string strPrtId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                hhHousehold dalHh = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHh = new hhHousehold();
                dt = dalHh.GetList(dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "hh_id", "hh_code", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbHHCode, dt, "hh_id", "hh_code");
                #endregion Load Lists

                #region Set List Selection
                if (strHhId.Length != 0)
                    cbHHCode.SelectedValue = strHhId;
                else
                    cbHHCode.SelectedIndex = 0;
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
                hhHouseholdMember dalHhm = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                dalHhm = new hhHouseholdMember();
                dt = dalHhm.GetListForForm(strHhId, strHhmId, "silc_group_member", "sg", ObjectId, dbCon);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsMember", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcGroup dalSG = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSG = new silcGroup();
                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalSG.sg_id = ObjectId;
                            dalSG.ofc_id = FormMaster.OfficeId;
                        }
                        else
                        {
                            dalSG.Load(ObjectId, dbCon);
                        }

                        dalSG.sg_name = txtSILCGroup.Text.Trim();
                        dalSG.usr_id_update = FormMaster.UserId;
                        dalSG.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
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

                FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SaveMember()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                silcGroupMember dalSGM = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInputMember();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dalSGM = new silcGroupMember();

                        if (lblSgmId.Text.Length == 0 || lblSgmId.Text.Trim().Equals("-"))
                        {
                            dalSGM.sgm_id = Guid.NewGuid().ToString();
                            dalSGM.ofc_id = FormMaster.OfficeId;
                        }
                        else
                            dalSGM.Load(lblSgmId.Text, dbCon);

                        if (rbtnGroupMemberHousehold.Checked)
                        {
                            dalSGM.hhm_id = cbHHMember.SelectedValue.ToString();
                            dalSGM.sgm_id = dalSGM.hhm_id;
                            dalSGM.sgm_name = string.Empty;
                            dalSGM.mtp_id = utilConstants.cMTHousehold;
                        }
                        else
                        {
                            dalSGM.hhm_id = utilConstants.cDFEmptyListValue;
                            dalSGM.sgm_name = txtExternalMemberName.Text.Trim();
                            dalSGM.mtp_id = utilConstants.cMTExternal;
                        }

                        dalSGM.sgm_active = Convert.ToInt32(chkActive.Checked);
                        dalSGM.sgm_status_reason = txtStatusReason.Text;
                        dalSGM.sg_id = ObjectId;
                        dalSGM.usr_id_update = FormMaster.UserId;
                        dalSGM.Save(dbCon);

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                        ClearSILCMember();
                        LoadDisplayMembers(ObjectId, dbCon);
                        SetHouseholdControls(true);
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
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SaveMember", exc);
            }
        }

        private void SetControls(bool blnEnabled)
        {
            btnMemberCancel.Enabled = blnEnabled;
            btnMemberSave.Enabled = blnEnabled;
            if (!FormMaster.NoDatabase)
                llblSILCSavingsRegister.Enabled = blnEnabled;
        }

        private void SetHouseholdControls(bool blnEnabled)
        {
            rbtnGroupMemberExternal.Enabled = blnEnabled;
            rbtnGroupMemberHousehold.Enabled = blnEnabled;
            cbHHCode.Enabled = blnEnabled;
            cbHHMember.Enabled = blnEnabled;
        }

        private void SetMemberPanel(bool blnHouseholdMember)
        {
            tplMemberExternal.Visible = !blnHouseholdMember;
            tplMemberHousehold.Visible = blnHouseholdMember;
            tplMemberExternal.Location = new Point(pintMemberPanelX, pintMemberPanelY);
            tplMemberHousehold.Location = new Point(pintMemberPanelX, pintMemberPanelY);
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            silcGroup dalSILC = null;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields 
            if (txtSILCGroup.Text.Trim().Length == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    #region Name in Use
                    if (txtSILCGroup.Text.Trim().Length != 0)
                    {
                        dalSILC = new silcGroup();
                        if (dalSILC.CheckNameInUse(ObjectId, txtSILCGroup.Text.Trim(), dbCon))
                            strMessage = strMessage + "," + utilConstants.cMIDNameIsUse;
                    }
                    #endregion Name in Use

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
            #endregion Get Messages
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }

            return strMessage;
        }

        private string ValidateInputMember()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            bool blnRequired = false;
            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (rbtnGroupMemberExternal.Checked && txtExternalMemberName.Text.Trim().Length == 0)
                blnRequired = true;
            else if (rbtnGroupMemberHousehold.Checked && cbHHMember.SelectedIndex == 0)
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
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageSILCGroup, dbCon);
                btnMemberSave.Visible = pblnManage;
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
