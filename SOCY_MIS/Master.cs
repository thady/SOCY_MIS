using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class Master : Form
    {
        #region Variabels
        private bool pblnLoggingOut = false;
        private string pstrLngId = utilConstants.cDFLngId;
        private string pstrOfcId = string.Empty;
        private string pstrUsrId = string.Empty;

        private bool pblnNoDatabase = false;
        #endregion Variabels

        #region Properties
        public bool LoggingOut
        {
            get { return pblnLoggingOut; }
            set { pblnLoggingOut = value; }
        }

        public string LanguageId
        {
            get { return pstrLngId; }
            set { pstrLngId = value; }
        }

        public string OfficeId
        {
            get { return pstrOfcId; }
            set { pstrOfcId = value; }
        }

        public string UserId
        {
            get { return pstrUsrId; }
            set { pstrUsrId = value; }
        }

        public bool NoDatabase
        {
            get { return pblnNoDatabase; }
            set { pblnNoDatabase = value; }
        }
        #endregion Properties

        #region Form Methods
        public Master()
        {
            InitializeComponent();
        }

        private void Master_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region Variables
            FormCollection fcOpen = Application.OpenForms;
            frmLogin frmLI = (frmLogin)fcOpen["frmLogin"];
            #endregion

            if (frmLI != null && !LoggingOut)
                frmLI.Close();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            #region Version
            lblVersionNumber.Text = ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString();
            #endregion Version

            if(!NoDatabase)
                LoadInitialForm();
        }
        #endregion Form Methods

        #region Control Methods
        private void llblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogOut();
        }
        private void miAdmin_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmAdmin frmNew = new frmAdmin();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }

        private void miDREAMS_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmDREAMS frmNew = new frmDREAMS();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }

        private void miHome_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmHome frmNew = new frmHome();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, false);
            #endregion Set Selected
        }

        private void miHousehold_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmHouseholdSearch frmNew = new frmHouseholdSearch();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, false);
            #endregion Set Selected
        }

        private void miResultArea01_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmResultArea01 frmNew = new frmResultArea01();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }

        private void miResultArea02_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmResultArea02 frmNew = new frmResultArea02();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }

        private void miResultArea03_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmResultArea03 frmNew = new frmResultArea03();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }

        private void miSILC_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmSILC frmNew = new frmSILC();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, false);
            #endregion Set Selected
        }

        private void miSocialWorker_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmSocialWorkerSearch frmNew = new frmSocialWorkerSearch();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, false);
            #endregion Set Selected
        }
        #endregion Control Methods

        #region Public Methods
        public void LoadControl(Control ctlUC, string strCallingForm, bool blnParentForm)
        {
            try
            {
                #region Load Control
                if (pnlPlaceHolder.Controls.Count != 0)
                    pnlPlaceHolder.Controls.RemoveAt(0);
                ctlUC.Width = pnlPlaceHolder.Width - 10;
                if (blnParentForm)
                {
                    ctlUC.Height = pnlPlaceHolder.Height - 10;
                    ctlUC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                }
                else
                    ctlUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                ctlUC.Location = new Point(0, 0);
                pnlPlaceHolder.Controls.Add(ctlUC);
                #endregion Load Control
            }
            catch (Exception exc)
            {
                ShowMessage(utilConstants.cPTError, strCallingForm, "LoadControl", exc);
            }
        }

        public void LoadMenu(bool blnActive)
        {
            pnlMenu.Visible = blnActive;
        }

        public void LogOut()
        {
            #region Variables
            FormCollection fcOpen = Application.OpenForms;
            frmLogin frmLI = (frmLogin)fcOpen["frmLogin"];
            #endregion

            if (frmLI != null)
                frmLI.Show();
            LoggingOut = true;
            this.Close();
        }

        public void SetControls(bool blnEnabled)
        {
            llblLogOut.Enabled = blnEnabled;
            mnMain.Enabled = blnEnabled;
        }

        public void ShowMessage(int intPopUpType, string strMessage)
        {
            ShowMessage(intPopUpType, strMessage, "", "", null);
        }

        public void ShowMessage(int intPopUpType, string strForm, string strMethod, Exception exc)
        {
            ShowMessage(intPopUpType, exc.Message, strForm, strMethod, exc);
        }

        public void ShowMessage(int intPopUpType, string strMessage, string strForm, string strMethod, Exception exc)
        {
            #region Variables
            FormCollection fcOpen = null;
            frmPopUp frmPU = null;
            #endregion Variables

            #region Show Form
            fcOpen = Application.OpenForms;
            frmPU = (frmPopUp)fcOpen["frmPopUp"];
            if (frmPU == null)
                frmPU = new frmPopUp();

            frmPU.PopUpType = intPopUpType;
            frmPU.Message = strMessage;
            if (exc != null)
            {
                frmPU.ErrorForm = strForm;
                frmPU.ErrorMethod = strMethod;
                frmPU.ErrorOccurred = exc;
                frmPU.ErrorOffice = OfficeId;
                frmPU.ErrorUser = UserId;
            }
            frmPU.ShowDialog();
            #endregion Show Form
        }
        #endregion Public Methods

        #region Private Methods
        private void LoadInitialForm()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                frmHome frmHm = null;
                frmOffice frmOfc = null;
                umOffice dalOffice = null;
                #endregion Variables

                #region Check if Office Info Exists
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    dalOffice = new umOffice(dbCon);
                    OfficeId = dalOffice.ofc_id;
                    if (dalOffice.ofc_id.Length == 0)
                    {
                        LoadMenu(false);
                        frmOfc = new frmOffice();
                        frmOfc.FormMaster = this;
                        LoadControl(frmOfc, this.Name, false);
                    }
                    else
                    {
                        DBAlteration.VersionControl(ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString(), UserId);
                        LoadMenu(true);
                        frmHm = new frmHome();
                        frmHm.FormMaster = this;
                        LoadControl(frmHm, this.Name, false);

                        SetPermissions(dbCon);
                        hhHousehold_linkages_register.user_id = UserId; //line added by thadeous
                        hhHousehold_linkages_register.ofc_id = dalOffice.ofc_id;
                        SystemConstants.ofc_id = dalOffice.ofc_id;
                        SystemConstants.user_id = UserId;
                        static_variables.district_id = SystemConstants.Return_office_district();
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Check if Office Info Exists
            }
            catch (Exception exc)
            {
                
                ShowMessage(utilConstants.cPTError, this.Name, "LoadInitialForm", exc);
            }
        }
        #endregion Private Methods

        #region Permissions
        private void SetPermissions(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            umUser dalUsr = new umUser();
            #endregion Variables

            #region Set Permissions
            try
            {
                miAdmin.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMAdministrator, dbCon);
                miDREAMS.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewDREAMS, dbCon);
                miHousehold.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewHouseholds, dbCon);
                miResultArea01.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewResultArea01, dbCon);
                miResultArea02.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewResultArea02, dbCon);
                miSILC.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewSILC, dbCon);
                miSocialWorker.Visible = dalUsr.HasPermission(UserId, utilConstants.cPMViewSocialWorkers, dbCon);
            }
            catch (Exception exc)
            {
                ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
            }
            #endregion Set Permissions
        }
        #endregion Permissions

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void miEducationSubsidy_Click(object sender, EventArgs e)
        {
            #region Set Selected
            frmEducationSubsidyMain frmNew = new frmEducationSubsidyMain();
            frmNew.FormMaster = this;
            LoadControl(frmNew, this.Name, true);
            #endregion Set Selected
        }
    }
}
