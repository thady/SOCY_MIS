using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmDataTransfer : UserControl
    {
        #region Variables
        private frmAdmin frmCll = null;
        private Master frmMST = null;
        private string strOstId = string.Empty;
        #endregion Variables

        #region Property
        public frmAdmin FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        private string OfficeStatus
        {
            get { return strOstId; }
            set { strOstId = value; }
        }
        #endregion Property

        #region Form Methods
        public frmDataTransfer()
        {
            InitializeComponent();
        }

        private void frmDataTransfer_Load(object sender, EventArgs e)
        {
            if (FormMaster.NoDatabase)
            {
                btnDataTransfer.Enabled = !FormMaster.NoDatabase;
            }
            else
            {
                OnlineCheck();
                LoadDisplay();
                ImportData();
            }
        }
        #endregion Form Methods

        #region Control Methods
        private void btnDataTransfer_Click(object sender, EventArgs e)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = new utilLanguageTranslation();

            DialogResult drResult = new DialogResult();
            string strMessage = string.Empty;
            string strTitle = string.Empty;
            #endregion Variables

            btnDataTransfer.Enabled = false;
            btnDataTransfer.Update();
            lblProcessing.Visible = true;
            lblProcessing.Text = "Processing";
            lblProcessing.Update();
            lblConnectionRestart.Visible = false;
            lblConnectionRestart.Text = "";
            lblConnectionRestart.Update();

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                #region Transfer Data
                utilLT.Language = FormMaster.LanguageId;
                strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSyncMessage, dbCon.dbCon);
                strTitle = utilLT.GetMessageTranslation(utilConstants.cMIDSyncTitle, dbCon.dbCon);
                drResult = MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult.Equals(DialogResult.Yes))
                {
                    SyncData(dbCon);
                }
                #endregion Transfer Data
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "OnlineCheck", exc);
            }
            finally
            {
                dbCon.Dispose();
            }
            btnDataTransfer.Enabled = OfficeStatus.Equals(utilConstants.cOSTValidated);
            lblProcessing.Visible = false;
        }
        #endregion Control Methods

        #region Function Methods
        private DataTable ConvertXMLToDataTable(string strXML, string strKey)
        {
            #region Variables
            DataSet ds = new DataSet();
            StringReader sr = null;
            #endregion Variables

            #region Convert to DataTable
            if (strKey.Length != 0)
                strXML = utilEncryption.StringDecryption(strXML, strKey);
            sr = new StringReader(strXML);
            ds.ReadXml(sr);
            #endregion Convert to DataTable

            return ds.Tables[0];
        }
        #endregion Function Methods

        #region Private Methods
        private void ImportData()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                umOffice dalOfc = null;

                DataTable dt = null;
                DialogResult dlrResult;
                bool blnEnable = btnDataTransfer.Enabled;
                #endregion Varaibles

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    dalOfc = new umOffice(dbCon);
                    if (dalOfc.ost_id.Equals(utilConstants.cOSTValidated))
                    {
                        dt = DBImportedData.GetImportData("", true, dbCon);
                        if (utilCollections.HasRows(dt))
                        {
                            #region Message
                            dlrResult = MessageBox.Show("IMPORTANT: Process will runs again with version 3.2, even if it has already ran. \n" +
                            "Prior to downloading data from the server, initial Household data must first be inserted. \n" +
                            "This can take up to an hour. \n" +
                            "Continue?", "Import Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            #endregion Message

                            if (dlrResult == DialogResult.Yes)
                            {
                                #region Import Data
                                btnDataTransfer.Enabled = false;
                                lblProcessing.Visible = true;
                                DBImportedData.ImportData(lblProcessing, dbCon);
                                btnDataTransfer.Enabled = blnEnable;
                                lblProcessing.Text = "Processing";
                                lblProcessing.Visible = false;
                                #endregion Import Data
                            }
                            else
                                btnDataTransfer.Enabled = false;
                        }
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "ImportData", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilSOCY_MIS utilSM = new utilSOCY_MIS();

                umOffice dalOfc = null;
                umUser dalUsr = null;
                #endregion Variables

                #region Load Office
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    dalOfc = new umOffice(dbCon);
                    dalUsr = new umUser(dalOfc.usr_id_contact, dbCon);

                    lblEmailDisplay.Text = dalOfc.ofc_email;
                    lblNameDisplay.Text = dalOfc.ofc_name;
                    lblOfficeStatusDisplay.Text = utilSM.GetListItemValue(dalOfc.ost_id, "lst_office_status", "ost", FormMaster.LanguageId, dbCon);
                    lblPhoneDisplay.Text = dalOfc.ofc_phone;
                    txtAddress.Text = dalOfc.ofc_address;

                    lblFirstNameDisplay.Text = dalUsr.usr_first_name;
                    lblLastNameDisplay.Text = dalUsr.usr_last_name;

                    if (dalOfc.ost_id.Equals(utilConstants.cOSTRejected))
                        btnDataTransfer.Enabled = false;
                }
                finally
                {
                    dbCon.Dispose();
                }
                #endregion Check if Office Info Exists
            }
            catch (Exception exc)
            {
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void OnlineCheck()
        {
            try
            {
                #region Variables
                SOCY_WS.SOCY_WS wsSM = new SOCY_WS.SOCY_WS();
                DataAccessLayer.DBConnection dbCon = null;
                utilSOCY_MIS utilSM = null;

                umOffice dalOfc = null;
                bool blnOnline = false;
                string strOlsId = string.Empty;
                string strResult = string.Empty;
                #endregion Variables

                #region Online Check
                try
                {
                    blnOnline = wsSM.OnlineCheck();
                }
                catch(Exception exc)
                {
                    blnOnline = false;
                }

                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    if (blnOnline)
                    {
                        strOlsId = utilConstants.cOLSOnline;
                        dalOfc = new umOffice(dbCon);

                        #region Message Check
                        strResult = wsSM.OnlineMessageCheck(dalOfc.ofc_id, dalOfc.ofc_app_version);
                        if (strResult.Length != 0)
                        {
                            tlpMessage.Visible = true;
                            txtMessage.Text = strResult;
                        }
                        #endregion Message Check

                        #region Status Check
                        strResult = wsSM.OfficeStatus(dalOfc.ofc_id);
                        if (strResult.Length != 0 && !(dalOfc.ost_id.Equals(strResult)) && !(strResult.Equals(utilConstants.cDFEmptyListValue)))
                        {
                            dalOfc.ost_id = strResult;
                            dalOfc.UpdateStatus(dbCon);
                        }
                        OfficeStatus = dalOfc.ost_id;
                        #endregion Status Check
                    }
                    else
                    {
                        strOlsId = utilConstants.cOLSOffline;
                    }

                    #region Set Online Status
                    utilSM = new utilSOCY_MIS();
                    lblConnectionStatusDisplay.Text = utilSM.GetListItemValue(strOlsId, "lst_online_status", "ols", FormMaster.LanguageId, dbCon);
                    btnDataTransfer.Enabled = blnOnline;
                    #endregion Set Online Status
                }
                finally
                {
                    dbCon.Dispose();
                    wsSM.Dispose();
                }
                #endregion Online Check
            }
            catch (Exception exc)
            {
                btnDataTransfer.Enabled = false;
                FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "OnlineCheck", exc);
            }
        }
        #endregion Private Methods

        #region Transfer Data
        private void SyncData(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            SOCY_WS.SOCY_WS wsSM = null;
            wsDataTransfer dalDT = new wsDataTransfer();
            utilLanguageTranslation utilLT = null;

            StringBuilder sb = null;
            StringWriter sw = new StringWriter();
            DataTable dt = null;
            DataTable dtTables = null;

            bool blnResult = true;
            int intRecord = 0;
            int intRestart = 0;
            int intTotal = 0;
            string[] arrTable = null;
            string strCntId = string.Empty;
            string strId = string.Empty;
            string strImpSid = string.Empty;
            string strOfcId = string.Empty;
            string strKey = string.Empty;
            string strMessage = string.Empty;
            string strSsnId = string.Empty;
            string strTable = string.Empty;
            string strTableKey = string.Empty;
            string strTitle = string.Empty;
            string strTrgAction = string.Empty;
            string strXML = string.Empty;
            string strXMLContact = string.Empty;
            string strXMLOffice = string.Empty;
            #endregion Variables

            #region Get Office Data
            dt = dalDT.GetData("um_office", dbCon);
            dt.TableName = "um_office";
            strCntId = dt.Rows[0]["usr_id_contact"].ToString();
            strOfcId = dt.Rows[0]["ofc_id"].ToString();
            strKey = strOfcId.Substring(0, utilConstants.cADSessionKeyLength);
            dt.WriteXml(sw);
            strXMLOffice = sw.ToString();
            sb = sw.GetStringBuilder();
            sb.Remove(0, sb.Length);
            strXMLOffice = utilEncryption.StringEncryption(strXMLOffice, strKey);
            #endregion Get Office Data

            #region Get Contact Data
            dt = dalDT.GetData("um_user", "usr_id", strCntId, dbCon);
            dt.TableName = "um_user";
            dt.WriteXml(sw);
            strXMLContact = sw.ToString();
            sb = sw.GetStringBuilder();
            sb.Remove(0, sb.Length);
            strXMLContact = utilEncryption.StringEncryption(strXMLContact, strKey);
            #endregion get Contact Data

            #region Office Validation
            wsSM = new SOCY_WS.SOCY_WS();
            wsSM.Timeout = -1; //set time out to infinity
            try
            {
                strSsnId = wsSM.OfficeValidation(strOfcId, strXMLOffice, strXMLContact);
            }
            finally
            {
                wsSM.Dispose();
            }
            #endregion Office Validation

            if (strSsnId.Length != 0)
            {
                blnResult = true;
                strKey = strSsnId.Substring(0, utilConstants.cADSessionKeyLength);

                #region Upload Tables
                dtTables = dalDT.GetData("lst_sync_upload", dbCon);
                if (utilCollections.HasRows(dtTables))
                {
                    wsSM = new SOCY_WS.SOCY_WS();
                    wsSM.Timeout = -1;
                    try
                    {
                        intTotal = dalDT.GetUploadTotal(dtTables, "sul_name", dbCon);  //total number of records to be uploaded in all the upload tables
                        intRecord = 0;
                        for (int intCount = 0; intCount < dtTables.Rows.Count && blnResult; intCount++)
                        {
                            strTable = dtTables.Rows[intCount]["sul_name"].ToString(); //upload table name
                           
                            strTableKey = dtTables.Rows[intCount]["sul_key"].ToString(); //primary key column in the table
                            dt = dalDT.GetDataTop01(strTable, strTableKey, dbCon);  //get the top record in the table
                            while (utilCollections.HasRows(dt) && blnResult) //check if row exists 
                            {
                                dt.TableName = strTable; //set the table name
                               
                                strId = dt.Rows[0][strTableKey].ToString();  //primary key column of the record
                                dt.WriteXml(sw);
                                strXML = sw.ToString();
                                sb = sw.GetStringBuilder();
                                sb.Remove(0, sb.Length);
                                strXML = utilEncryption.StringEncryption(strXML, strKey);

                                try
                                {
                                    blnResult = wsSM.ProcessRecord(strSsnId, strXML);
                                   
                                }
                                catch (System.Net.WebException exc)
                                {
                                    if (exc.Message.Equals("The underlying connection was closed: An unexpected error occurred on a receive."))
                                    {
                                        wsSM = new SOCY_WS.SOCY_WS();
                                        wsSM.Timeout = -1;
                                        blnResult = wsSM.ProcessRecord(strSsnId, strXML);
                                        intRestart++;
                                        lblConnectionRestart.Visible = true;
                                        lblConnectionRestart.Text = "Connection Restarted: " + intRestart.ToString();
                                        lblConnectionRestart.Update();
                                    }
                                    else
                                        throw exc;
                                }

                                if (blnResult)
                                {
                                    dalDT.Delete(strTable, strTableKey, strId, dbCon);
                                    dt = dalDT.GetDataTop01(strTable, strTableKey, dbCon);
                                }
                                lblProcessing.Text = string.Format("Processing: Uploading {0} of {1}", intRecord++, intTotal);
                                lblProcessing.Update();
                            }
                        }
                    }
                    finally
                    {
                        wsSM.Dispose();
                    }
                }
                #endregion Upload Tables

                //#region Download Data
                ////check if user has set the district download list
                //if (SystemConstants.Return_office_district_for_download() != string.Empty)
                //{

                //    wsSM = new SOCY_WS.SOCY_WS();
                //    wsSM.Timeout = -1; //set timeout for the web service to infinity
                //    try
                //    {
                //        intTotal = wsSM.DownloadTotal(FormMaster.OfficeId, SystemConstants.Return_office_district_for_download());

                //        //MessageBox.Show(intTotal.ToString());
                //        //intTotal = wsSM.ReturnOfficeDownloadTotal(FormMaster.OfficeId, SystemConstants.Return_office_district_for_download()); 
                //        intRecord = 0;
                //        strXML = wsSM.DownloadData(strSsnId, "", "", "", SystemConstants.Return_office_district_for_download()); //contains list of districts for download
                //        while (strXML.Length != 0)
                //        {
                //            dt = ConvertXMLToDataTable(strXML, strKey);
                //            strTable = dt.TableName;
                //            arrTable = strTable.Split(new[] { utilConstants.cDFDownloadDelimiter }, StringSplitOptions.None);
                //            strImpSid = arrTable[0];
                //            strTable = arrTable[1];
                //            strTrgAction = arrTable[2];

                //            if (strTrgAction.Equals(utilConstants.cTAInsert))
                //                strId = dalDT.ProcessDownload(strTable, dt, dbCon);
                //            else
                //                strId = dalDT.ProcessDownloadDelete(strTable, dt, dbCon);
                //            intRecord = intRecord + dt.Rows.Count;
                //            lblProcessing.Text = string.Format("Processing: Download {0} of {1}" + " (Download Total Might be inacurate due to incoming uploads)", intRecord, intTotal);
                //            lblProcessing.Update();

                //            try
                //            {
                //                strXML = wsSM.DownloadData(strSsnId, strImpSid, strTable, strId, SystemConstants.Return_office_district_for_download()); //contains list of districts for download
                //            }
                //            catch (System.Net.WebException exc)
                //            {
                //                if (exc.Message.Equals("The underlying connection was closed: An unexpected error occurred on a receive."))
                //                {
                //                    wsSM = new SOCY_WS.SOCY_WS();
                //                    wsSM.Timeout = -1; //set timeout for the web service to infinity
                //                    strXML = wsSM.DownloadData(strSsnId, strImpSid, strTable, strId, SystemConstants.Return_office_district_for_download()); //contains list of districts for download
                //                    intRestart++;
                //                    lblConnectionRestart.Visible = true;
                //                    lblConnectionRestart.Text = "Connection Restarted: " + intRestart.ToString();
                //                    lblConnectionRestart.Update();
                //                }
                //                else
                //                    throw exc;
                //            }
                //        }
                //    }
                //    finally
                //    {
                //        wsSM.Dispose();
                //    }

                //}
                //else if (static_variables.district_id == string.Empty)
                //{
                //    MessageBox.Show("Please set the district name of this office before beginning download", "Download data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else if (SystemConstants.Return_office_district_for_download() == string.Empty)
                //{
                //    MessageBox.Show("No district download list set yet,data download failed!!", "Download data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //#endregion Download Data

                //download dist

                #region Display Message
                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSyncComplete, dbCon.dbCon);
                strTitle = utilLT.GetMessageTranslation(utilConstants.cMIDSyncTitle, dbCon.dbCon);
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Display Message
            }
            else
            {
                #region Display Message
                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormMaster.LanguageId;
                strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSyncComplete, dbCon.dbCon);
                strTitle = utilLT.GetMessageTranslation(utilConstants.cMIDSyncTitle, dbCon.dbCon);
                MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #endregion Display Message
            }
        }

        
        #endregion Transfer Data

        #region Encrypt Import Files
        private void btnImportFiles_Click(object sender, EventArgs e)
        {
            DBImportedData.EncriptFiles();
            MessageBox.Show("Done", "Import Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion Encrypt Import Files
    }
}
