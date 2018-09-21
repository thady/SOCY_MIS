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
    public partial class frmEducationSubsidyMain : UserControl
    {
        public frmEducationSubsidyMain()
        {
            InitializeComponent();
        }

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

        private void frmEducationSubsidyMain_Load(object sender, EventArgs e)
        {

        }

        private void llblEducationSubsidy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmEducationSubsidySearch frmNew = new frmEducationSubsidySearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

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

        private void lnlbenreadiness_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            #region Set Selected
            benSchoolReadinessTool.edsr_id = string.Empty;
            frmBenSchoolReadinessToolMain frmNew = new frmBenSchoolReadinessToolMain();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }
    }
}
