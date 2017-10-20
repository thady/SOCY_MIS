using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SOCY_MIS.DataAccessLayer
{
    /// <summary>
    /// Wrapper class of PSAUtils.DBConnection
    /// </summary>
    public class DBConnection
    {
        #region Class Variables
        public PSAUtils.DBConnection dbCon = null;
        public static string ConnectionString = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";
        #endregion Class Variables

        #region Class Methods
        public DBConnection(string strDatabase)
        {
            #region Variables
            string strFile = Application.StartupPath + "\\" + ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString();
            FileInfo flCon = new FileInfo(strFile);
            
            DataSet ds = null;
            DataRow dr = null;
            string strConnection = "";
            #endregion Variables

            #region Create Connection
            if(flCon.Exists)
            {
                ds = PSAUtilsWin32.utilXMLAccess.XMLReadSchema(ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString());
                dr = ds.Tables[0].Rows[0];
                strConnection = string.Format(ConnectionString, dr["ServerName"].ToString(), dr["DatabaseName"].ToString(), dr["UserName"].ToString(), dr["Password"].ToString());
            }
            else
                strConnection = ConfigurationManager.AppSettings[strDatabase].ToString();

            dbCon = new PSAUtils.DBConnection(strConnection, strDatabase);
            #endregion Create Connection
        }

        //added by thadeous...return sql db connection as a string
        public string SQLDBConnection(string strDatabase) 
        {
            #region Variables
            string strFile = Application.StartupPath + "\\" + ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString();
            FileInfo flCon = new FileInfo(strFile);

            DataSet ds = null;
            DataRow dr = null;
            string strConnection = "";
            #endregion Variables

            #region Create Connection
            if (flCon.Exists)
            {
                ds = PSAUtilsWin32.utilXMLAccess.XMLReadSchema(ConfigurationManager.AppSettings[utilConstants.cACKConnectionFile].ToString());
                dr = ds.Tables[0].Rows[0];
                strConnection = string.Format(ConnectionString, dr["ServerName"].ToString(), dr["DatabaseName"].ToString(), dr["UserName"].ToString(), dr["Password"].ToString());
            }
            else
                strConnection = ConfigurationManager.AppSettings[strDatabase].ToString();

            //dbCon = new PSAUtils.DBConnection(strConnection, strDatabase);

            return strConnection;
            #endregion Create Connection
        }

        public void Dispose()
        {
            dbCon.Dispose();
        }

        public void TransactionBegin()
        {
            dbCon.TransactionBegin();
        }

        public void TransactionCommit()
        {
            dbCon.TransactionCommit();
        }

        public void TransactionRollback()
        {
            dbCon.TransactionRollback();
        }
        #endregion Class Methods

        #region Database Functions
        public static bool CanConnect(string strDatabase)
        {
            #region Variables
            DBConnection dbCon = null;
            bool blnResult = true;
            #endregion Variables

            #region Connect
            try           
            {
                dbCon = new DBConnection(utilConstants.cACKConnection);
            }
            catch
            {
                blnResult = false;
            }
            #endregion Connect

            return blnResult;
        }

        public void DatabaseBackup(string strPath, string strFileName)
        {
            dbCon.DatabaseBackup(strPath, strFileName);
        }

        public static bool TestConnectionString(string strConnection)
        {
            #region Variables
            PSAUtils.DBConnection dbCon = null;
            bool blnResult = true;
            string strDatabase = "Test";
            #endregion Variables

            #region Connect
            try
            {
                #region Create Connection
                dbCon = new PSAUtils.DBConnection(strConnection, strDatabase);
                #endregion Create Connection
            }
            catch
            {
                blnResult = false;
            }
            #endregion

            return blnResult;
        }
        #endregion Database Functions

        #region SQL Method
        public int ExecuteNonQuery(string strSQL)
        {
            return dbCon.ExecuteNonQuery(strSQL);
        }

        public DataTable ExecuteQueryDataTable(string strSQL)
        {
            return dbCon.ExecuteQueryDataTable(strSQL);
        }

        public DataSet ExecuteQueryDataSet(string strSQL)
        {
            return dbCon.ExecuteQueryDataSet(strSQL);
        }

        public string ExecuteScalar(string strSQL)
        {
            return dbCon.ExecuteScalar(strSQL);
        }
        #endregion SQL Method
    }
}