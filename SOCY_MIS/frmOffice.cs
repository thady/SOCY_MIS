using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmOffice : UserControl
    {
        #region Variables
        private Master frmMST = null;
        private DataTable pdtUser = null;
        private umOffice pdalOfc = null;

        private bool pblnNew = true;
        private int pintYOffset = 10;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        #region Form Methods
        public frmOffice()
        {
            InitializeComponent();
        }

        private void frmOffice_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                load_districts();
                LoadOffice();
            }
            else
            {
                btnCancel.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserDetails(cbUser.SelectedValue.ToString());
        }
        #endregion Control Methods

        #region Private Methods
        private void Clear()
        {
            #region Clear
            if (pblnNew)
            {
                cbTitle.SelectedIndex = 0;
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
            }
            else
            {
                SetOffice();
            }
            #endregion Clear
        }

        private void LoadLists(DataAccessLayer.DBConnection dbCon)
        {
            LoadLists("", dbCon);
        }

        private void LoadLists(string strUsrId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                umUser dalUsr = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                if (pblnNew)
                {
                    uLT = new utilListTable();

                    dt = uLT.GetData("lst_honorific", true, "", false, FormMaster.LanguageId, dbCon.dbCon);
                    dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                    utilControls.ComboBoxFill(cbTitle, dt, "lt_id", "lt_name");
                }
                else
                {
                    dalUsr = new umUser();
                    dt = dalUsr.GetList(strUsrId, dbCon);
                    utilControls.ComboBoxFill(cbUser, dt, "usr_id", "usr_name");
                    //get office district
                    string district_id = SystemConstants.Return_office_district();
                    if (district_id != String.Empty && district_id != "-999")
                    {
                        cbo_district.SelectedValue = district_id;
                        //cbo_district.Enabled = false;
                    }
                    else { cbo_district.SelectedValue = "-999"; }
                    
                    pdtUser = dt.Copy();
                }
                #endregion Load Lists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadOffice()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                umOffice dalOfc = null;
                #endregion Variables

                #region Load Office
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    dalOfc = new umOffice(dbCon);
                    if (dalOfc.ofc_id.Length == 0)
                    {
                        pblnNew = true;
                        gbNewContact.Location = new Point(gbNewContact.Location.X, gbOffice.Location.Y + gbOffice.Height + pintYOffset);
                        gbNewContact.Visible = true;
                        gbCurrentContact.Visible = false;
                        LoadLists(dbCon);
                    }
                    else
                    {
                        pblnNew = false;
                        pdalOfc = dalOfc;
                        gbCurrentContact.Location = new Point(gbCurrentContact.Location.X, gbOffice.Location.Y + gbOffice.Height + pintYOffset);
                        gbCurrentContact.Visible = true;
                        gbNewContact.Visible = false;
                        LoadLists(pdalOfc.usr_id_contact, dbCon);
                        SetOffice();
                    }
                    this.ActiveControl = txtName;
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Check if Office Info Exists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadOffice", exc);
            }
        }

        private void LoadUserDetails(string strUsrId)
        {
            try
            {
                #region Variables
                bool blnFound = false;
                int intCount = 0;
                #endregion Variables

                #region Load Display
                lblCCEmailDisplay.Text = "";
                lblCCPhoneDisplay.Text = "";
                if (utilCollections.HasRows(pdtUser))
                {
                    while (!blnFound && intCount < pdtUser.Rows.Count)
                    {
                        if (pdtUser.Rows[intCount]["usr_id"].ToString().Equals(strUsrId))
                        {
                            lblCCEmailDisplay.Text = pdtUser.Rows[intCount]["usr_email"].ToString();
                            lblCCPhoneDisplay.Text = pdtUser.Rows[intCount]["usr_phone"].ToString();
                            blnFound = true;
                        }
                        intCount++;
                    }
                }
                #endregion Load Display
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadUserDetails", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                frmHome frmNew = null;
                umOffice dalOfc = null;
                umUser dalUser = null;

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
                        if (pblnNew)
                        {
                            dalOfc = new umOffice();
                            dalUser = new umUser();

                            dalOfc.ofc_id = Guid.NewGuid().ToString();
                            dalUser.usr_id = Guid.NewGuid().ToString();

                            dalUser.usr_first_name = txtFirstName.Text;
                            dalUser.usr_last_name = txtLastName.Text;
                            dalUser.usr_email = txtEmail.Text;
                            dalUser.usr_phone = txtPhone.Text;
                            dalUser.hnr_id = cbTitle.SelectedValue.ToString();
                            dalUser.ofc_id = dalOfc.ofc_id;
                            dalUser.Save(dbCon);

                            dalOfc.ofc_name = txtName.Text;
                            dalOfc.ofc_phone = txtPhone.Text;
                            dalOfc.ofc_email = txtEmail.Text;
                            dalOfc.ofc_address = txtAddress.Text;
                            dalOfc.ost_id = utilConstants.cOSTWaitingValidation;
                            dalOfc.usr_id_contact = dalUser.usr_id;
                            static_variables.district_id = cbo_district.SelectedValue.ToString();
                            dalOfc.Save(dbCon);
                            FormMaster.OfficeId = dalOfc.ofc_id;

                        }
                        else
                        {
                            pdalOfc.ofc_name = txtName.Text;
                            pdalOfc.ofc_phone = txtPhone.Text;
                            pdalOfc.ofc_email = txtEmail.Text;
                            pdalOfc.ofc_address = txtAddress.Text;
                            pdalOfc.usr_id_contact = cbUser.SelectedValue.ToString();
                            static_variables.district_id = cbo_district.SelectedValue.ToString();
                            pdalOfc.usr_id_update = FormMaster.UserId;
                            pdalOfc.Save(dbCon);
                        }
                        dbCon.TransactionCommit();
                        DBAlteration.VersionControl(ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString(), FormMaster.UserId);

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

                if (pblnNew && intPopUpType == utilConstants.cPTInfo)
                {
                    FormMaster.LoadMenu(true);
                    frmNew = new frmHome();
                    frmNew.FormMaster = FormMaster;
                    FormMaster.LoadControl(frmNew, this.Name, false);
                }
                else
                {
                    FormMaster.ShowMessage(intPopUpType, strMessage);
                }
            }
            catch (Exception exc)
            {
                throw exc;
                //FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SetOffice()
        {
            try
            {
                #region Set Fields
                txtName.Text = pdalOfc.ofc_name;
                txtPhone.Text = pdalOfc.ofc_phone;
                txtEmail.Text = pdalOfc.ofc_email;
                txtAddress.Text = pdalOfc.ofc_address;
                cbUser.SelectedValue = pdalOfc.usr_id_contact;
                #endregion Set Fields
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetOffice", exc);
            }
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;
            string[] arrMessage = null;
            string strEmail = string.Empty;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (txtName.Text.Trim().Length == 0 || 
                txtEmail.Text.Trim().Length == 0 || 
                (txtFirstName.Text.Trim().Length == 0 && txtFirstName.Visible) ||
                (txtLastName.Text.Trim().Length == 0 && txtLastName.Visible) || cbo_district.Text == "select district") 
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields
            
            #region Email Check
            strEmail = txtEmail.Text.Trim();
            if (strEmail.Length != 0)
            {
                if (!utilFormatting.IsValidEmail(strEmail))
                    strMessage = strMessage + "," + utilConstants.cMIDEmailFormatInvalid;
            }
            #endregion Email Check

            #region Get Messages
            if (strMessage.Length != 0)
            {
                strMessage = strMessage.Substring(1);
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);

                try
                {
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

        //edited by Tadeo
        #region load districts lookups
        protected void load_districts()
        {

            DataTable dt = SystemConstants.Return_list_of_districts();
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.NewRow();
                dtRow["dst_id"] = -999;
                dtRow["dst_name"] = "select district";

                dt.Rows.InsertAt(dtRow, 0);
                cbo_district.DataSource = dt;
                cbo_district.ValueMember = "dst_id";
                cbo_district.DisplayMember = "dst_name";
            }
            
        }
        #endregion load districts lookups

    }
}
