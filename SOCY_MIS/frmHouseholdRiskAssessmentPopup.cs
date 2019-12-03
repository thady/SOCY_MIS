using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCY_MIS
{
    public partial class frmHouseholdRiskAssessmentPopup : Form
    {
        frmHouseholdRiskAssessmentMain frmNew = new frmHouseholdRiskAssessmentMain();
        public frmHouseholdRiskAssessmentPopup()
        {
            InitializeComponent();
        }

        private void frmHouseholdRiskAssessmentPopup_Load(object sender, EventArgs e)
        {
            LoadControl(frmNew);
        }

        private void LoadControl(Control ctlUC)
        {
            try
            {
                #region Load Control
                ctlUC.Width = this.Width - 10;
                ctlUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                           | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
                ctlUC.Location = new Point(0, 0);
                this.Controls.Add(ctlUC);
                #endregion Load Control
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void CloseParent()
        {
            this.Close();
        }
    }
}
