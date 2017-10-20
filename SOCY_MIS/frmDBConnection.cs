using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDBConnection : Form
    {
        #region Variabels
        private bool pblnDBChanged = false;
        private bool pblnConnect = false;
        private frmLogin frmCll = null;
        private Master frmMST = null;
        #endregion Variables

        #region Property
        public bool Connected
        {
            get { return pblnConnect; }
            set { pblnConnect = value; }
        }

        private bool DBChanged
        {
            get { return pblnDBChanged; }
            set { pblnDBChanged = value; }
        }

        public frmLogin FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDBConnection()
        {
            InitializeComponent();
        }

        private void frmDBConnection_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region Variables
            FormCollection fcOpen = Application.OpenForms;
            frmLogin frmLI = (frmLogin)fcOpen["frmLogin"];
            #endregion

            if (frmLI != null && !Connected)
                frmLI.Close();
            else if (FormMaster != null && DBChanged)
                FormMaster.LogOut();
        }

        private void frmDBConnection_Load(object sender, EventArgs e)
        {
            #region Version
            lblVersionNumber.Text = ConfigurationManager.AppSettings[utilConstants.cACKVersion].ToString();
            #endregion Version
            LoadDisplay();

            if (FormMaster != null && FormMaster.NoDatabase)
            {
                btnClose.Enabled = !FormMaster.NoDatabase;
                btnSave.Enabled = !FormMaster.NoDatabase;
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion Control Methods

        #region Private Methods
        private void LoadDisplay()
        {
            try
            {
                #region Variables
                string strFile = Application.StartupPath + "\\" + ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString();
                FileInfo flCon = new FileInfo(strFile);

                #region App Config
                int intCon = 0;
                int intCatalogStart = 0;
                int intCatalogEnd = 0;
                int intDataSourceStart = 0;
                int intDataSourceEnd = 0;
                int intPasswordStart = 0;
                int intPasswordEnd = 0;
                int intUserIdStart = 0;
                int intUserIdEnd = 0;
                string strCon = string.Empty;
                string strCatalog = ";Initial Catalog=";
                string strDataSource = "Data Source=";
                string strPassword = ";Password=";
                string strUserId = ";User Id=";
                #endregion App Config

                #region XML File
                DataSet ds = null;
                DataRow dr = null;
                #endregion XML File
                #endregion Variables

                #region Display
                if (flCon.Exists)
                {
                    #region XML File
                    ds = PSAUtilsWin32.utilXMLAccess.XMLReadSchema(ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString());
                    dr = ds.Tables[0].Rows[0];
                    lblCCDServerCurrent.Text = dr["ServerName"].ToString();
                    lblCCDDatabaseNameCurrent.Text = dr["DatabaseName"].ToString();
                    lblCCDUserNameCurrent.Text = dr["UserName"].ToString();
                    lblCCDPasswordCurrent.Text = dr["Password"].ToString();
                    #endregion XML File
                }
                else
                {
                    #region App Config
                    strCon = ConfigurationManager.AppSettings[utilConstants.cACKConnection].ToString();
                    intCon = strCon.Length;
                    intCatalogStart = strCon.IndexOf(strCatalog);
                    intCatalogEnd = intCatalogStart + strCatalog.Length;
                    intDataSourceStart = strCon.IndexOf(strDataSource);
                    intDataSourceEnd = intDataSourceStart + strDataSource.Length;
                    intPasswordStart = strCon.IndexOf(strPassword);
                    intPasswordEnd = intPasswordStart + strPassword.Length;
                    intUserIdStart = strCon.IndexOf(strUserId);
                    intUserIdEnd = intUserIdStart + strUserId.Length;

                    lblCCDServerCurrent.Text = strCon.Substring(intDataSourceEnd, intCatalogStart - intDataSourceEnd);
                    lblCCDDatabaseNameCurrent.Text = strCon.Substring(intCatalogEnd, intUserIdStart - intCatalogEnd);
                    lblCCDUserNameCurrent.Text = strCon.Substring(intUserIdEnd, intPasswordStart - intUserIdEnd);
                    lblCCDPasswordCurrent.Text = strCon.Substring(intPasswordEnd, intCon - intPasswordEnd - 1);
                    #endregion App Config
                }
                this.ActiveControl = txtServerName;
                #endregion Display

            }
            catch (Exception exc)
            {
                if (FormMaster != null)
                    FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
                else
                    if (FormCalling != null)
                        FormCalling.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataRow dr = null;
                DataSet ds = null;
                DataTable dt = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strDatabase = string.Empty;
                string strPassword = string.Empty;
                string strServer = string.Empty;
                string strUserId = string.Empty;

                string strMessage = ValidateInput();
                #endregion Variables

                #region Get Values
                DBChanged = false;
                if (txtDatabaseName.Text.Trim().Length == 0)
                    strDatabase = lblCCDDatabaseNameCurrent.Text;
                else
                {
                    strDatabase = txtDatabaseName.Text.Trim();
                    DBChanged = true;
                }

                if (txtPassword.Text.Trim().Length == 0)
                    strPassword = lblCCDPasswordCurrent.Text;
                else
                    strPassword = txtPassword.Text.Trim();

                if (txtServerName.Text.Trim().Length == 0)
                    strServer = lblCCDServerCurrent.Text;
                else
                {
                    strServer = txtServerName.Text.Trim();
                    DBChanged = true;
                }

                if (txtUserName.Text.Trim().Length == 0)
                    strUserId = lblCCDUserNameCurrent.Text;
                else
                    strUserId = txtUserName.Text.Trim();
                #endregion Get Values

                if (strMessage.Length == 0)
                {
                    if (DBConnection.TestConnectionString(string.Format(DBConnection.ConnectionString, strServer, strDatabase, strUserId, strPassword)))
                    {
                        #region Write to XML
                        ds = new DataSet();
                        dt = new DataTable("DBConnection");
                        dt.Columns.Add(new DataColumn("ServerName"));
                        dt.Columns.Add(new DataColumn("DatabaseName"));
                        dt.Columns.Add(new DataColumn("UserName"));
                        dt.Columns.Add(new DataColumn("Password"));
                        dt.AcceptChanges();
                        dr = dt.NewRow();
                        dr["ServerName"] = strServer;
                        dr["DatabaseName"] = strDatabase;
                        dr["UserName"] = strUserId;
                        dr["Password"] = strPassword;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                        ds.Tables.Add(dt);
                        ds.AcceptChanges();

                        PSAUtilsWin32.utilXMLAccess.XMLWriteSchema(ds, ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString());
                        #endregion Write to XML

                        if (!DBAlteration.TableExists(utilConstants.cADTableCheck))
                        {
                            DBAlteration.CreateTables();
                        }

                        Connected = true;
                        this.Close();
                    }
                    else
                    {
                        #region Get Messages
                        strMessage = "Database Connection Failed. Please ensure that the connection details are correct.";
                        intPopUpType = utilConstants.cPTError;
                        #endregion Get Messages
                    }
                }

                if (strMessage.Length != 0)
                {
                    if (FormMaster != null)
                        FormMaster.ShowMessage(intPopUpType, strMessage);
                    else
                        if (FormCalling != null)
                            FormCalling.ShowMessage(intPopUpType, strMessage);
                }

            }
            catch (Exception exc)
            {
                if (FormMaster != null)
                    FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
                else
                    if (FormCalling != null)
                        FormCalling.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private string ValidateInput()
        {
            #region Variables
            string strMessage = string.Empty;
            #endregion Variables

            #region Password Validation
            if (txtPassword.Text.Trim().Length != 0 && !txtPassword.Text.Trim().Equals(txtPasswordConfirm.Text.Trim()))
                strMessage = "The Confirm New Password must match the New Password entry.";
            #endregion Password Validation

            return strMessage;
        }
        #endregion Private Methods
    }
}
