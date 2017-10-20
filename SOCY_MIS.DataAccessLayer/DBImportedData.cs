using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class DBImportedData
    {
        #region Variables
        private static string pstrFolder = @"C:\Users\Ryan\Documents\Visual Studio 2012\Projects_NEW\SOCY\SOCY_MIS\SOCY_MIS\ImportedData";
        private static string pstrFolderOrig = @"C:\Users\Ryan\Documents\Visual Studio 2012\Projects_NEW\SOCY\SOCY_MIS\SOCY_MIS\ImportedData\Orig";
        private static string pstrHAFile = "ImportedHouseholdAssessment";
        private static string pstrHAMFile = "ImportedHouseholdAssessmentMember";
        private static string pstrHHFile = "ImportedHousehold";
        private static string pstrHHMFile = "ImportedHouseholdMember";
        private static string pstrOIPFile = "ImportedOVCIdentification";
        private static string pstrSWKFile = "ImportedSocialWorker";

        private const string pstrHAId = "1";
        private const string pstrHAMId = "2";
        private const string pstrHHId = "3";
        private const string pstrHHMId = "4";
        private const string pstrOIPId = "5";
        private const string pstrSWKId = "6";
        #endregion Variables

        #region Public Methods
        public static void ImportData(Control ctlDisplay, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            DataRow dr = null;
            DataTable dt = null;

            bool blnFound = false;
            string strDstSct = "";
            string strFileEncrypt = "";
            string strFolder = Application.StartupPath + "\\" + ConfigurationManager.AppSettings[utilConstants.cACKImportDataFolder].ToString();
            string strSQL = "";
            #endregion Variables

            dt = GetImportData("", true, dbCon);

            if (utilCollections.HasRows(dt))
            {
                #region Import Data
                try
                {
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        dbCon.TransactionBegin();

                        strDstSct = dr["dst_id"].ToString();
                        if (dr["sct_id"].ToString().Length != 0)
                            strDstSct = strDstSct + "_" + dr["sct_id"].ToString();

                        //Should run regardless if there is data or not. Queries excludes records already there
                        blnFound = false;
                        switch (dr["ifl_id"].ToString())
                        {
                            case pstrHAId:
                                //blnFound = CheckHouseholdAssessment(dr["dst_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrHAFile + strDstSct + @".txt";
                                break;
                            case pstrHAMId:
                                //blnFound = CheckHouseholdAssessmentMember(dr["dst_id"].ToString(), dr["sct_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrHAMFile + strDstSct + @".txt";
                                break;
                            case pstrHHId:
                                //blnFound = CheckHousehold(dr["dst_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrHHFile + strDstSct + @".txt";
                                break;
                            case pstrHHMId:
                                //blnFound = CheckHouseholdMember(dr["dst_id"].ToString(), dr["sct_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrHHMFile + strDstSct + @".txt";
                                break;
                            case pstrOIPId:
                                //blnFound = CheckOVCIdentification(dr["dst_id"].ToString(), dr["sct_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrOIPFile + strDstSct + @".txt";
                                break;
                            case pstrSWKId:
                                //blnFound = CheckSocialWorker(dr["dst_id"].ToString(), dbCon);
                                strFileEncrypt = strFolder + @"\" + pstrSWKFile + strDstSct + @".txt";
                                break;
                        }

                        ctlDisplay.Text = intCount.ToString() + " of " + dt.Rows.Count.ToString();
                        ctlDisplay.Update();

                        if (File.Exists(strFileEncrypt))
                        {
                            if (!blnFound)
                            {
                                strSQL = DBImportedData.DecryptFile(strFileEncrypt);
                                dbCon.ExecuteNonQuery(strSQL);
                            }
                            SetProcessed(dr["impd_id"].ToString(), dbCon);
                        }
                        dbCon.TransactionCommit();
                    }
                }
                catch (Exception exc)
                {
                    dbCon.TransactionRollback();
                    throw exc;
                }
                #endregion Import Data
            }
        }

        public static void EncriptFiles()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            DataTable dt = null;

            string strDstSct = "";
            string strHAFileEncrypt = "";
            string strHAFileOrig = "";
            string strHAMFileEncrypt = "";
            string strHAMFileOrig = "";
            string strHHFileEncrypt = "";
            string strHHFileOrig = "";
            string strHHMFileEncrypt = "";
            string strHHMFileOrig = "";
            string strOIPFileEncrypt = "";
            string strOIPFileOrig = "";
            string strSWKFileEncrypt = "";
            string strSWKFileOrig = "";
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                dt = GetImportData("", false, dbCon);

                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    strDstSct = dt.Rows[intCount]["dst_id"].ToString();
                    if (dt.Rows[intCount]["sct_id"].ToString().Length != 0)
                        strDstSct = strDstSct + "_" + dt.Rows[intCount]["sct_id"].ToString();

                    strHAFileEncrypt = pstrFolder + @"\" + pstrHAFile + strDstSct + @".txt";
                    strHAFileOrig = pstrFolderOrig + @"\" + pstrHAFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strHAFileEncrypt) && File.Exists(strHAFileOrig))
                        EncryptFile(strHAFileOrig, strHAFileEncrypt);

                    strHAMFileEncrypt = pstrFolder + @"\" + pstrHAMFile + strDstSct + @".txt";
                    strHAMFileOrig = pstrFolderOrig + @"\" + pstrHAMFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strHAMFileEncrypt) && File.Exists(strHAMFileOrig))
                        EncryptFile(strHAMFileOrig, strHAMFileEncrypt);

                    strHHFileEncrypt = pstrFolder + @"\" + pstrHHFile + strDstSct + @".txt";
                    strHHFileOrig = pstrFolderOrig + @"\" + pstrHHFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strHHFileEncrypt) && File.Exists(strHHFileOrig))
                        EncryptFile(strHHFileOrig, strHHFileEncrypt);

                    strHHMFileEncrypt = pstrFolder + @"\" + pstrHHMFile + strDstSct + @".txt";
                    strHHMFileOrig = pstrFolderOrig + @"\" + pstrHHMFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strHHMFileEncrypt) && File.Exists(strHHMFileOrig))
                        EncryptFile(strHHMFileOrig, strHHMFileEncrypt);

                    strOIPFileEncrypt = pstrFolder + @"\" + pstrOIPFile + strDstSct + @".txt";
                    strOIPFileOrig = pstrFolderOrig + @"\" + pstrOIPFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strOIPFileEncrypt) && File.Exists(strOIPFileOrig))
                        EncryptFile(strOIPFileOrig, strOIPFileEncrypt);

                    strSWKFileEncrypt = pstrFolder + @"\" + pstrSWKFile + strDstSct + @".txt";
                    strSWKFileOrig = pstrFolderOrig + @"\" + pstrSWKFile + @"Orig" + strDstSct + @".txt";
                    if (!File.Exists(strSWKFileEncrypt) && File.Exists(strSWKFileOrig))
                        EncryptFile(strSWKFileOrig, strSWKFileEncrypt);
                }
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        public static DataTable GetImportData(string strDstId, bool blnUnProcessedOnly, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
                "FROM um_import_data " +
                "WHERE 1=1 ";
            if (strDstId.Length != 0)
                strSQL = strSQL + string.Format("AND dst_id = '{0}' ", strDstId);
            if (blnUnProcessedOnly)
                strSQL = strSQL + "AND impd_processed = 0 ";
            strSQL = strSQL + "ORDER BY dst_id, sct_id ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public Methods

        #region Encryption
        private static void EncryptFile(string inputFile, string outputFile)
        {
            string password = @"SOCY2017";
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            string cryptFile = outputFile;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);


            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }

        public static string DecryptFile(string inputFile)
        {
            string password = @"SOCY2017";

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);

            StreamReader reader = new StreamReader(cs);

            string data = reader.ReadToEnd();

            reader.Close();
            cs.Close();
            fsCrypt.Close();

            return data;
        }
        #endregion Encryption

        #region Private Methods
        #region Check Methods
        private static bool CheckHouseholdAssessment(string strDstId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dt.hha_id) " +
                "FROM hh_household_assessment dt " +
                "INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id " +
                "LEFT JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND sct.dst_id = '{1}' ", utilConstants.cDFImportOffice, strDstId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        private static bool CheckHouseholdAssessmentMember(string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dt.ham_id) " +
                "FROM hh_household_assessment_member dt " +
                "INNER JOIN hh_household_assessment ha ON dt.hha_id = ha.hha_id " +
                "INNER JOIN hh_household hh ON ha.hh_id = hh.hh_id " +
                "LEFT JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND sct.dst_id = '{1}' AND sct.sct_id = '{2}' ", utilConstants.cDFImportOffice, strDstId, strSctId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        private static bool CheckHousehold(string strDstId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dt.hh_id) " +
                "FROM hh_household dt " +
                "LEFT JOIN lst_ward wrd ON dt.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND sct.dst_id = '{1}' ", utilConstants.cDFImportOffice, strDstId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        private static bool CheckHouseholdMember(string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dt.hhm_id) " +
                "FROM hh_household_member dt " +
                "INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id " +
                "LEFT JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND sct.dst_id = '{1}' AND sct.sct_id = '{2}' ", utilConstants.cDFImportOffice, strDstId, strSctId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        private static bool CheckOVCIdentification(string strDstId, string strSctId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dt.oip_id) " +
                "FROM hh_ovc_identification_prioritization dt " +
                "INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id " +
                "LEFT JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND sct.dst_id = '{1}' AND sct.sct_id = '{2}' ", utilConstants.cDFImportOffice, strDstId, strSctId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        private static bool CheckSocialWorker(string strDstId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(DISTINCT dt.swk_id) " +
                "FROM swm_social_worker dt " +
                "LEFT JOIN lst_ward wrd ON dt.wrd_id = wrd.wrd_id " +
                "LEFT JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dt.ofc_id = '{0}' AND ISNULL(sct.dst_id, '0') = '{1}' ", utilConstants.cDFImportOffice, strDstId);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }
        #endregion Check Methods

        #region Function Methods
        private static void SetProcessed(string strImpdId, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE um_import_data " +
                "SET impd_processed = 1, usr_date_update = GETDATE() " +
                "WHERE impd_id = '{0}' ";
            strSQL = string.Format(strSQL, strImpdId);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Function Methods

        #region Get Methods
        private static DataTable GetImportDistricts(DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dst_id " +
                "FROM um_import_data " +
                "ORDER BY dst_id ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Get Methods
        #endregion Private Methods
    }
}
