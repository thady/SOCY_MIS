using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AutoUpdaterDotNET;

namespace SOCY_MIS
{
    public partial class frmAutoUpdate : Form
    {
        public frmAutoUpdate()
        {
            InitializeComponent();
        }

        private void frmAutoUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://esocy.crs.org/AppDownload/updater.xml");
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Forced;
            //AutoUpdater.ShowSkipButton = false;
            AutoUpdater.Mandatory = true;
        }
    }
}
