using System;
using System.Data;
using System.Security.Cryptography;

using PSAUtils;
using PSAUtilsWin32;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public class umUser
    {
        #region Variables
        #region Public
        public string usr_id = string.Empty;
        public string usr_password = string.Empty;
        public int usr_password_format = utilConstants.cDFPasswordformat;
        public string usr_first_name = string.Empty;
        public string usr_last_name = string.Empty;
        public string usr_email = string.Empty;
        public string usr_phone = string.Empty;
        public string usr_skype = string.Empty;
        public string usr_position = string.Empty;
        public int usr_active = utilConstants.cDFActive;
        public string hnr_id = string.Empty;
        public string lng_id = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;

        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        #endregion Public

        #region Private
        private string usr_password_salt = string.Empty;
        public string usr_password_old = string.Empty;
        #endregion Private
        #endregion Variables

        #region Constractor Methods
        public umUser()
        {
            Default();
        }

        public umUser(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        /// <summary>
        /// Checks if the specified Email address is already in the database
        /// </summary>
        /// <param name="strID">User ID to be excluded from check</param>
        /// <param name="strEmail">Email address to be checked</param>
        /// <returns>Returns boolean based on a record being found</returns>
        public bool CheckEmailInUse(string strID, string strEmail, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(usr_id) FROM um_user WHERE LOWER(usr_email) = '{1}' " +
                "AND NOT usr_id IN (SELECT usr_id FROM um_user WHERE LOWER(usr_email) = '{1}' AND usr_id = '{0}') ", strID, strEmail);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public bool HasPermission(string strID, string strPrmId, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT SUM(the_count) FROM ( " +
                "SELECT COUNT(usr_id) AS the_count " +
                "FROM um_user_role url " +
                "INNER JOIN um_role_permission rlpr ON url.rl_id = rlpr.rl_id " +
                "WHERE url.usr_id = '{0}' AND rlpr.prm_id = '{1}' " +
                "UNION " +
                "SELECT COUNT(usr_id) AS the_count " +
                "FROM um_user_role url " +
                "WHERE url.usr_id = '{0}' AND url.rl_id = '{2}') temp ", strID, strPrmId, utilConstants.cDFAdminRole);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set User
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetUser(strId, dbCon);
                Load(dt);
            }
            #endregion Set User
        }

        public void LoadByEmail(string strEmail, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set User
            if (strEmail.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetByEmail(strEmail, dbCon);
                Load(dt);
            }
            #endregion
        }

        /// <summary>
        /// Validates specified email and password against the values in the database
        /// </summary>
        /// <param name="strEmail">Email of User to be logged in</param>
        /// <param name="strPassword">Password of User to be logged in</param>
        /// <param name="strLngID">Language Message must be returned in</param>
        /// <param name="dbCon">Database connection that must be used</param>
        /// <returns>Returns string based on log in result, blank is successful</returns>
        public string LogIn(string strEmail, string strPassword, string strLngID, DBConnection dbCon)
        {
            #region Variables
            utilLanguageTranslation utilLT = new utilLanguageTranslation();
            string strMessage = string.Empty;
            #endregion Variables

            #region LogIn
            utilLT.Language = strLngID;
            LoadByEmail(strEmail, dbCon);

            if (usr_id.Length != 0)
            {
                if (usr_active == utilConstants.cDFActive)
                {
                    switch (usr_password_format)
                    {
                        case 1:
                            strPassword = utilEncryption.HashText(strPassword, usr_password_salt);
                            break;
                        default:
                            strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDPasswordFormatInvalid, dbCon.dbCon);
                            break;
                    }

                    if (strPassword.Equals(usr_password))
                    {
                        strMessage = "";
                    }
                    else
                    {
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDPasswordIncorrect, dbCon.dbCon);
                    }
                }
                else
                {
                    strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDAccountInactive, dbCon.dbCon);
                }
            }
            else
            {
                strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDEmailAddressInvalid, dbCon.dbCon);
            }
            #endregion LogIn

            return strMessage;
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables
            
            #region Password
            if (!usr_password.Equals(usr_password_old))
            {
                switch (usr_password_format)
                {
                    case 1:
                        usr_password = utilEncryption.HashText(usr_password, usr_password_salt);
                        break;
                }
            }
            #endregion Password

            #region Save
            dt = GetUser(usr_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }

        public void SaveRole(string[] arrRoleId, DBConnection dbCon)
        {
            #region Variables
            string strIds = string.Empty;
            string strSQL = string.Empty;
            string strSQLDelete = string.Empty;
            string strSQLInsert = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region SQL
            #region IDs List
            for (int intCount = 0; intCount < arrRoleId.Length; intCount++)
            {
                if (arrRoleId[intCount].Trim().Length != 0)
                {
                    if (strSQLSelect.Length != 0)
                        strSQLSelect = strSQLSelect + "UNION ";
                    strSQLSelect = strSQLSelect + "SELECT '" + Guid.NewGuid().ToString() + "' AS url_id, '" + arrRoleId[intCount] + "' AS rl_id ";

                    if (strIds.Length != 0)
                        strIds = strIds + ", ";
                    strIds = strIds + "'" + arrRoleId[intCount] + "'";
                }
            }
            #endregion IDs List

            #region Delete
            strSQLDelete = "DELETE FROM um_user_role WHERE usr_id = '{0}' ";
            if (strIds.Length != 0)
                strSQLDelete = strSQLDelete + "AND NOT rl_id IN ({1}) ";

            strSQL = strSQL + strSQLDelete;
            #endregion Delete

            #region Insert
            if (strSQLSelect.Length != 0)
            {
                strSQLInsert = "INSERT INTO  um_user_role (url_id, rl_id, usr_id, usr_id_create, usr_date_create) " +
                    "SELECT url_id, rl_id, '{0}', '{2}', GETDATE() FROM (" + strSQLSelect + " ) temp " + 
                    "WHERE NOT rl_id IN (SELECT DISTINCT rl_id FROM um_user_role WHERE usr_id = '{0}' AND rl_id IN ({1})) ";
                strSQL = strSQL + strSQLInsert;
            }
            #endregion Insert

            strSQL = string.Format(strSQL, usr_id, strIds, usr_id_update);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            usr_id = string.Empty;
            usr_password = string.Empty;
            usr_password_old = string.Empty;
            usr_password_format = utilConstants.cDFPasswordformat;
            usr_password_salt = utilEncryption.HashGenerateSalt();
            usr_first_name = string.Empty;
            usr_last_name = string.Empty;
            usr_email = string.Empty;
            usr_phone = string.Empty;
            usr_skype = string.Empty;
            usr_position = string.Empty;
            usr_active = utilConstants.cDFActive;
            hnr_id = utilConstants.cDFEmptyListValue;
            lng_id = utilConstants.cDFLngId;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO um_user " +
                "(usr_id, usr_password, usr_password_format, usr_password_salt, " +
                "usr_first_name, usr_last_name, usr_email, usr_phone, usr_skype, usr_position, usr_active, " +
                "hnr_id, lng_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id) " +
                "VALUES ('{0}', '{1}', {2}, '{3}', " +
                "'{4}', '{5}', " +
                "'{6}', '{7}', '{8}', " +
                "'{9}', {10}, " +
                "'{11}', '{12}', '{13}', '{13}', " +
                "GETDATE(), GETDATE(), '{14}') ";
            strSQL = string.Format(strSQL, usr_id, utilFormatting.StringForSQL(usr_password), usr_password_format, usr_password_salt,
                utilFormatting.StringForSQL(usr_first_name), utilFormatting.StringForSQL(usr_last_name),
                utilFormatting.StringForSQL(usr_email), usr_phone, utilFormatting.StringForSQL(usr_skype),
                utilFormatting.StringForSQL(usr_position), Convert.ToInt32(usr_active),
                hnr_id, lng_id, usr_id_update, ofc_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        private void Load(DataTable dt)
        {
            #region Variables
            DataRow dr = null;
            #endregion Variables

            #region Set User
            if (!utilCollections.HasRows(dt))
            {
                Default();
            }
            else
            {
                dr = dt.Rows[0];
                usr_id = dr["usr_id"].ToString();
                usr_password = dr["usr_password"].ToString();
                usr_password_old = dr["usr_password"].ToString();
                usr_password_format = Convert.ToInt32(dr["usr_password_format"]);
                usr_password_salt = dr["usr_password_salt"].ToString();
                usr_first_name = dr["usr_first_name"].ToString();
                usr_last_name = dr["usr_last_name"].ToString();
                usr_email = dr["usr_email"].ToString();
                usr_phone = dr["usr_phone"].ToString();
                usr_skype = dr["usr_skype"].ToString();
                usr_position = dr["usr_position"].ToString();
                usr_active = Convert.ToInt32(dr["usr_active"]);
                hnr_id = dr["hnr_id"].ToString();
                lng_id = dr["lng_id"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
            }
            #endregion
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE um_user " +
                "SET usr_password = '{1}', usr_password_format = {2}, usr_password_salt = '{3}', " +
                "usr_first_name = '{4}', usr_last_name = '{5}', " +
                "usr_email = '{6}', usr_phone = '{7}', usr_skype = '{8}', " +
                "usr_position = '{9}', usr_active = {10}, " +
                "hnr_id = '{11}', lng_id = '{12}', usr_id_update = '{13}', " +
                "usr_date_update = GETDATE(), ofc_id = '{14}' " +
                "WHERE usr_id = '{0}' ";
            strSQL = string.Format(strSQL, usr_id, utilFormatting.StringForSQL(usr_password), usr_password_format, usr_password_salt,
                utilFormatting.StringForSQL(usr_first_name), utilFormatting.StringForSQL(usr_last_name),
                utilFormatting.StringForSQL(usr_email), usr_phone, utilFormatting.StringForSQL(usr_skype),
                utilFormatting.StringForSQL(usr_position), Convert.ToInt32(usr_active),
                hnr_id, lng_id, usr_id_update, ofc_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public Methods
        public DataTable GetByCriteria(string[,] arrFilter, int intArrayLength, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strWHERE = "WHERE 1=1 ";
            #endregion Variables

            #region SQL
            #region WHERE
            for (int intCount = 0; intCount < intArrayLength; intCount++)
            {
                switch (arrFilter[intCount, 0])
                {
                    case "usr_id":
                        strWHERE = strWHERE + string.Format("AND usr.usr_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_first_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(usr.usr_first_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_last_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(usr.usr_last_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_email":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(usr.usr_email))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT usr.* FROM um_user usr " + strWHERE;
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetList(DBConnection dbCon)
        {
            return GetListPrivate("", dbCon);
        }

        public DataTable GetList(string strId, DBConnection dbCon)
        {
            return GetListPrivate(strId, dbCon);
        }

        public DataTable GetUserRoles(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT url.* FROM um_user_role url WHERE url.usr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public Methods

        #region Private Methods
        private DataTable GetUser(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT usr.*,ofc.district_id FROM um_user usr LEFT JOIN um_office ofc ON usr.ofc_id = ofc.ofc_id WHERE usr.usr_id = '{0}'";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        //edited by tadeo
        private DataTable GetUser_details(string strId, SqlConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            SqlDataAdapter Adapt; ;
            SqlCommand cmd;
            #endregion Variables

            #region SQL
            strSQL = "SELECT usr.*,ofc.district_id FROM um_user usr LEFT JOIN um_office ofc ON usr.ofc_id = ofc.ofc_id WHERE usr.usr_id = '"+ strId +"'";
            cmd = new SqlCommand(strSQL);
            cmd.Connection = dbCon;
            Adapt = new SqlDataAdapter(cmd);
            Adapt.Fill(dt);

            #endregion SQL

            return dt;
        }

        private DataTable GetByEmail(string strEmail, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * FROM um_user WHERE usr_email = '{0}' ";
            strSQL = string.Format(strSQL, utilFormatting.StringForSQL(strEmail.ToLower()));
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetListPrivate(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT usr.usr_id, usr.usr_first_name + ' ' + usr.usr_last_name AS usr_name, usr.usr_email, usr.usr_phone " +
                "FROM um_user usr ";
            if (strId.Length != 0)
            {
                strSQL = strSQL + "UNION " +
                "SELECT usr.usr_id, usr.usr_first_name + ' ' + usr.usr_last_name AS usr_name, usr.usr_email, usr.usr_phone " +
                "FROM um_user usr " +
                "WHERE usr.usr_id = '{0}' ";
            }
            strSQL = strSQL + "ORDER BY usr_name ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private Methods
        #endregion Get Methods
    }
}