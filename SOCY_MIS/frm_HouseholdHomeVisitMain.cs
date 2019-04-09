using System;
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
    public partial class frm_HouseholdHomeVisitMain : UserControl
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

        public frm_HouseholdHomeVisitMain()
        {
            InitializeComponent();
        }

        private void tpHomeVisit_Click(object sender, EventArgs e)
        {

        }

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

        private void frm_HouseholdHomeVisitMain_Load(object sender, EventArgs e)
        {
            #region Variables
            frm_HouseholdHomeVisit frmNewV = new frm_HouseholdHomeVisit();
            frm_HouseholdHomevisitMember frmNewMM = new frm_HouseholdHomevisitMember();
            #endregion Variables

            #region Load Controls
            frmNewV.HouseholdId = HouseholdId;
            frmNewV.ObjectId = ObjectId;
            frmNewV.FormCalling = this;
            frmNewV.FormMaster = FormMaster;
            LoadControl(frmNewV, this.Name, tpHomeVisit);


            frmNewMM.HouseholdId = HouseholdId;
            frmNewMM.ObjectId = ObjectId;
            frmNewMM.FormCalling = this;
            frmNewMM.FormMaster = FormMaster;
            LoadControl(frmNewMM, this.Name, tpMember);

           MembersTab(ObjectId);
            #endregion Load Controls
        }

        public void MembersTab(string object_id)
        {
            if (object_id.Length != 0 && (SystemConstants.household_status == "1" || SystemConstants.household_status == "2"))
            {
                ((Control)tcHomeVisit.TabPages[1]).Enabled = true;
            }
            else
            {
                ((Control)tcHomeVisit.TabPages[1]).Enabled = false;
            }

        }

        public void Back()
        {
            FormCalling.LoadMembers();
            FormCalling.LoadRecords();
            FormMaster.LoadControl(FormCalling, this.Name, false);
        }
    }
}
