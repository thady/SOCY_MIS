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
    public partial class frmSILC : UserControl
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
        public frmSILC()
        {
            InitializeComponent();
        }

        private void frmSILC_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                SetPermissions();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void llblSILCGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmSILCGroupSearch frmNew = new frmSILCGroupSearch();
            frmNew.FormMaster = FormMaster;
            frmNew.FormParent = this;
            LoadControl(frmNew, this.Name);
            #endregion
        }

        private void llblSILCGroupRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Set Selected
            frmSILCLinkageRegisterSearch frmNew = new frmSILCLinkageRegisterSearch();
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
                llblSILCGroupRegister.Visible = dalUsr.HasPermission(FormMaster.UserId, utilConstants.cPMViewSILCGroupFinancialRegister, dbCon);
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