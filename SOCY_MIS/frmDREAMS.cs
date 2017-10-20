using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDREAMS : UserControl
    {
        #region Variables
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDREAMS()
        {
            InitializeComponent();
        }

        private void frmDREAMS_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                SetPermissions();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void llblMembers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSMemberSearch frmNew = new frmDREAMSMemberSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblPostViolenceRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSPostViolenceCareSearch frmNew = new frmDREAMSPostViolenceCareSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSRegistrationSearch frmNew = new frmDREAMSRegistrationSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSINOVUYOAttendanceRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSSINOVUYOAttendanceRegisterSearch frmNew = new frmDREAMSSINOVUYOAttendanceRegisterSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSteppingStonesAttendanceRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDREAMSSteppingStonesAttendanceRegisterSearch frmNew = new frmDREAMSSteppingStonesAttendanceRegisterSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }
        #endregion Control Methods

        #region Public Methods
        public void LoadControl(Control ctlUC, string strCallingForm)
        {
            try
            {
                #region Load Form
                if (pnlPlaceHolder.Controls.Count != 0)
                    pnlPlaceHolder.Controls.RemoveAt(0);
                ctlUC.Width = pnlPlaceHolder.Width - 10;
                ctlUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                ctlUC.Location = new Point(0, 0);
                pnlPlaceHolder.Controls.Add(ctlUC);
                #endregion Load Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, strCallingForm, "LoadControl", exc);
            }
        }
        #endregion Public Methods

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
                llblEnrollmentRegistration.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDREAMSEnrolmentRegister, dbCon);
                llblMembers.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDREAMSMembers, dbCon);
                llblPostViolenceRegister.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDREAMSPostViolenceCare, dbCon);
                llblSINOVUYOAttendanceRegister.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDREAMSSINOVUYOAttendacneRegister, dbCon);
                llblSteppingStonesAttendanceRegister.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDREAMSSteppingStonesAttendacneRegister, dbCon);
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