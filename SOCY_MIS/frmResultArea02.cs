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
    public partial class frmResultArea02 : UserControl
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
        public frmResultArea02()
        {
            InitializeComponent();
        }

        private void frmResultArea02_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                SetPermissions();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void llblAlternativeCare_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmAlternativeCarePanelSummarySearch frmNew = new frmAlternativeCarePanelSummarySearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblCBSDResourceAllocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmCBSDResourceAllocationSearch frmNew = new frmCBSDResourceAllocationSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblCBSDStaffAppraisalTracking_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmCBSDStaffAppraisalTrackingSearch frmNew = new frmCBSDStaffAppraisalTrackingSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblInstitutionalCareSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmInstitutionalCareSummarySearch frmNew = new frmInstitutionalCareSummarySearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblOVCChecklist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmDistrictOVCChecklistSearch frmNew = new frmDistrictOVCChecklistSearch();
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
                llblAlternativeCare.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewAlternativeCarePanelSummary, dbCon);
                llblCBSDResourceAllocation.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewCBSDResourceAllocation, dbCon);
                llblCBSDStaffAppraisalTracking.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewCBSDStaffandAppraisalTracking, dbCon);
                llblInstitutionalCareSummary.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewInstitutionalCareSummary, dbCon);
                llblOVCChecklist.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewDistrictOVCCoordinationOVCDataUsageChecklist, dbCon);
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
