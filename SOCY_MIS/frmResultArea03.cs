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
    public partial class frmResultArea03 : UserControl
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
        public frmResultArea03()
        {
            InitializeComponent();
        }
        #endregion Form Methods

        #region Control Methods
        private void llblHomeVisits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmHomeVisitToolSearch frmNew = new frmHomeVisitToolSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblReferrals_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmReferralSearch frmNew = new frmReferralSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblServiceRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmServiceRegisterSearch frmNew = new frmServiceRegisterSearch();
            frmNew.FormMaster = FormMaster;
            frmNew.FormParent03 = this;
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
    }
}
