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
    public partial class frmResultArea01 : UserControl
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
        public frmResultArea01()
        {
            InitializeComponent();
        }

        private void frmResultArea01_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                SetPermissions();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void llblActivityTraining_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmActivityTrainingSearch frmNew = new frmActivityTrainingSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblApprenticeship_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmApprenticeshipSearch frmNew = new frmApprenticeshipSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblGirlChildEducation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmGirlChildEducationSearch frmNew = new frmGirlChildEducationSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblServiceRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmServiceRegisterSearch frmNew = new frmServiceRegisterSearch();
            frmNew.FormMaster = FormMaster;
            frmNew.FormParent01 = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblValueChainActorsRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmValueChainActorRegisterSearch frmNew = new frmValueChainActorRegisterSearch();
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
                llblActivityTraining.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewActivityTraining, dbCon);
                llblApprenticeship.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewApprentishipRegister, dbCon);
                llblGirlChildEducation.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewGildChildEducation, dbCon);
                llblServiceRegistration.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewServiceRegister, dbCon);
                llblValueChainActorsRegistration.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewValueChainActorRegistration, dbCon);
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

        private void llblCommunityTrainingRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
            #region Set Selected
            frmCommunityTraining_registerSearch frmNew = new frmCommunityTraining_registerSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblYouthTrainingInventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmYouthTrainingInventory frmNew = new frmYouthTrainingInventory();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblYouthRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmYouthSavingsRegisterSearch frmNew = new frmYouthSavingsRegisterSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSILCGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //#region Set Selected
            //frmSILCGroupSearch frmNew = new frmSILCGroupSearch();
            //frmNew.FormParent = this;
            //LoadControl(frmNew, this.Name);
            //#endregion
        }

        private void llblAgroEnterprise_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            AgroEnterpriseRankingMatrix.type = "crop";
            frmAgroEnterpriseRankingMatrixSearch frmNew = new frmAgroEnterpriseRankingMatrixSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblCommunityTrainingRegisterSILC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmCommunityTraining_registerSearch frmNew = new frmCommunityTraining_registerSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSILCGroup_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //#region Set Selected
            //frmSILCGroupSearch frmNew = new frmSILCGroupSearch();
            //frmNew.FormParent = this;
            //LoadControl(frmNew, this.Name);
            //#endregion
        }

        private void llblYouthskillAquisition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frm_apprenticeship_skill_acquision_tracking_search frmNew = new frm_apprenticeship_skill_acquision_tracking_search();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblCottageEnterprize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            AgroEnterpriseRankingMatrix.type = "cottage";
            frmAgroEnterpriseRankingMatrixSearch frmNew = new frmAgroEnterpriseRankingMatrixSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblYouthTrainingCompletion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmYouthTrainingCompletionSearch frmNew = new frmYouthTrainingCompletionSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblYouthAssessmentScoringSheet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmYouthAssessmentScoringToolSearch frmNew = new frmYouthAssessmentScoringToolSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblYouthTracer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmYouthTracerSearch frmNew = new frmYouthTracerSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }
    }
}
