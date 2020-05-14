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
    public partial class frmCovid19DataCollectionSearch : UserControl
    {
        #region Variables
        private frmResultArea03 frmPrt = null;
        DataTable dt = new DataTable();
        #endregion Variables

        #region Property
        public frmResultArea03 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }
        #endregion Property

        public frmCovid19DataCollectionSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void llblNewRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            #region Set Selected
            frmCovid19DataCollection frmNew = new frmCovid19DataCollection();
            frmNew.FormCallingSearch = this;
            frmNew.FormParent = FormParent;
            frmNew.FormMaster = FormParent.FormMaster;
            FormParent.LoadControl(frmNew, this.Name);
            #endregion
        }
    }
}
