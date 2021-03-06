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
    public partial class frmHome : UserControl
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
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            if (!FormMaster.NoDatabase)
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;

                string strMessage = string.Empty;
                #endregion Variables

                #region Get Messages
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormMaster.LanguageId;
                    strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDMessageServer, dbCon.dbCon);
                    lblMessageServer.Text = strMessage;

                    strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDMessageWelcome, dbCon.dbCon);
                    if (strMessage.Length != 0)
                        lblMessageWelcome.Text = strMessage;

                    static_variables.district_id = SystemConstants.Return_office_district();
                    //check if the user has updated the office district
                    if (static_variables.district_id == string.Empty || static_variables.district_id == "-999")
                    {
                        MessageBox.Show("Please make sure you update the office district before entering any more data", "Update office district", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        frmOffice frmNew = new frmOffice();
                        frmNew.Show();

                    }

                    MessageBox.Show("Always upload your data everyday after data entry!Your computer's date and time should always be up to date", "Data Entry & Upload", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Get Messages
            }
        }
        #endregion Form Methods
    }
}
