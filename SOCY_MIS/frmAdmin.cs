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
    public partial class frmAdmin : UserControl
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
        public frmAdmin()
        {
            InitializeComponent();
        }
        #endregion Form Methods

        #region Control Methods
        private void llblDataTransfer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDataTransfer frmNew = new frmDataTransfer();
            frmNew.FormCalling = this;
            frmNew.FormMaster = this.FormMaster;
            LoadControl(frmNew, this.Name);
        }

        private void llblDCConnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                #region Variables
                FormCollection fcOpen = null;
                frmDBConnection frmDBC = null;
                #endregion Variables

                #region Show Form
                fcOpen = Application.OpenForms;
                frmDBC = (frmDBConnection)fcOpen["frmDBConnection"];
                if (frmDBC == null)
                    frmDBC = new frmDBConnection();
                frmDBC.Connected = true;
                frmDBC.FormMaster = FormMaster;
                frmDBC.ShowDialog();
                #endregion Show Form
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "llblDCConnect", exc);
            }
        }

        private void llblOfficeManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmOffice frmNew = new frmOffice();
            frmNew.FormMaster = this.FormMaster;
            LoadControl(frmNew, this.Name);
        }

        private void llblRoleManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRoleSearch frmNew = new frmRoleSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
        }

        private void llblUserManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserSearch frmNew = new frmUserSearch();
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
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

        public void SetControls(bool blnEnabled)
        {
            llblDataTransfer.Enabled = blnEnabled;
            llblDCConnect.Enabled = blnEnabled;
            llblOfficeManagement.Enabled = blnEnabled;
            llblRoleManagement.Enabled = blnEnabled;
            llblUserManagement.Enabled = blnEnabled;
        }
        #endregion Public Methods

        private void llbdistrict_download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_um_office_district_download district_down = new frm_um_office_district_download();
            district_down.ShowDialog();
        }
    }
}
