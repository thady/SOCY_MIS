﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmHouseholdAssessmentMain : UserControl
    {
        #region Variables
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHousehold frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public frmHousehold FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmHouseholdAssessmentMain()
        {
            InitializeComponent();
        }

        private void frmHouseholdAssessmentMain_Load(object sender, EventArgs e)
        {
            #region Variables
            frmHouseholdAssessment frmNewA = new frmHouseholdAssessment();
            frmHouseholdAssessmentMember frmNewM = new frmHouseholdAssessmentMember();
            #endregion Variables

            #region Load Controls
            frmNewA.HouseholdId = HouseholdId;
            frmNewA.ObjectId = ObjectId;
            frmNewA.FormCalling = this;
            frmNewA.FormMaster = FormMaster;
            LoadControl(frmNewA, this.Name, tpAssessment);

            frmNewM.HouseholdId = HouseholdId;
            frmNewM.ObjectId = ObjectId;
            frmNewM.FormCalling = this;
            frmNewM.FormMaster = FormMaster;
            LoadControl(frmNewM, this.Name, tpMember);

            MembersTab(ObjectId.Length != 0);
            #endregion Load Controls
        }
        #endregion Form Methdos

        #region Public Methods
        public void Back()
        {
            FormCalling.LoadMembers();
            FormCalling.LoadRecords();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }

        public void MembersTab(bool blnEnabled)
        {
            ((Control)tcHouseholdAssessment.TabPages[1]).Enabled = blnEnabled;
        }
        #endregion Public Methods

        #region Private Methods
        private void LoadControl(Control ctlUC, string strCallingForm, TabPage tpContainer)
        {
            try
            {
                #region Load Control
                if (tpContainer.Controls.Count != 0)
                    tpContainer.Controls.RemoveAt(0);
                ctlUC.Width = tpContainer.Width - 10;
                ctlUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                ctlUC.Location = new Point(0, 0);
                tpContainer.Controls.Add(ctlUC);
                #endregion Load Control
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, strCallingForm, "LoadControl", exc);
            }
        }
        #endregion Private Methods

        private void tpAssessment_Click(object sender, EventArgs e)
        {

        }
    }
}
