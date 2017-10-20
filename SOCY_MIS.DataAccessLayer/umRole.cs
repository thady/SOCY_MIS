using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class umRole
    {
        #region Variables
        #region Public
        public string rl_id = string.Empty;
        public string rl_name = string.Empty;
        public int rl_active = utilConstants.cDFActive;
        public string usr_id_update = string.Empty;

        public string[] role_permission = "".Split(utilConstants.cDFSplitChar);
        #endregion Public

        #region Private
        private int rl_order = 1;
        private string rlt_id = utilConstants.cDFEmptyListValue;
        #endregion Private
        #endregion Variables
        
        #region Constractor Methods
        public umRole()
        {
            Default();
        }

        public umRole(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public Methods
        public bool CheckNameInUse(string strID, string strName, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(rl_id) FROM um_role WHERE LOWER(rl_name) = '{1}' " +
                "AND NOT rl_id IN (SELECT rl_id FROM um_role WHERE LOWER(rl_name) = '{1}' AND rl_id = '{0}') ", strID, strName);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM um_role_permission WHERE rl_id = '{0}' " + 
                "DELETE FROM um_user_role WHERE rl_id = '{0}' " +
                "DELETE FROM um_role WHERE rl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
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
                dt = GetRole(strId, dbCon);
                Load(dt);
                PermissionsLoad(strId, dbCon);
            }
            #endregion Set User
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables
            
            #region Save
            dt = GetRole(rl_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
            {
                rl_order = NextOrder(dbCon);
                Insert(dbCon);
            }
            PermissionsUpdate(dbCon);
            #endregion Save
        }
        #endregion Public Methdos

        #region Private Methods
        private void Default()
        {
            #region Default
            rl_id = string.Empty;
            rl_name = string.Empty;
            rl_order = 1;
            rl_active = utilConstants.cDFActive;
            rlt_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            role_permission = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO um_role " +
                "(rl_id, rl_name, " +
                "rl_order, rl_active, " +
                "rlt_id, usr_id_create, usr_id_update, " + 
                "usr_date_create, usr_date_update) " +
                "VALUES ('{0}', '{1}', " +
                "{2}, {3}, " +
                "'{4}', '{5}', '{5}', " +
                "GETDATE(), GETDATE()) ";
            strSQL = string.Format(strSQL, rl_id, utilFormatting.StringForSQL(rl_name),
                rl_order, rl_active,
                rlt_id, usr_id_update);

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
                rl_id = dr["rl_id"].ToString();
                rl_name = dr["rl_name"].ToString();
                rl_order = Convert.ToInt32(dr["rl_order"]);
                rl_active = Convert.ToInt32(dr["rl_active"]);
                rlt_id = dr["rlt_id"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
            }
            #endregion
        }

        private int NextOrder(DBConnection dbCon)
        {
            #region Variables
            int intOrder = 1;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MAX(rl_order), 0) + 1 FROM um_role ";
            intOrder = Convert.ToInt32(dbCon.ExecuteScalar(strSQL));
            #endregion SQL

            return intOrder;
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE um_role " +
                " SET rl_name = '{1}', " +
                "rl_order = {2}, rl_active = {3}, " +
                "rlt_id = '{4}', usr_id_update = '{5}', " + 
                "usr_date_update = GETDATE() " +
                "WHERE rl_id = '{0}' ";
            strSQL = string.Format(strSQL, rl_id, utilFormatting.StringForSQL(rl_name),
                rl_order, rl_active,
                rlt_id, usr_id_update);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private Methods
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
                    case "rl_id":
                        strWHERE = strWHERE + string.Format("AND rl.rl_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "rl_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(rl.rl_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT rl.* FROM um_role rl " + strWHERE;
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetRoleList(DBConnection dbCon)
        {
            return GetRoleListPrivate("", dbCon);
        }

        public DataTable GetRoleList(string strId, DBConnection dbCon)
        {
            return GetRoleListPrivate(strId, dbCon);
        }
        #endregion Public Methods

        #region Private Methods
        private DataTable GetRole(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT rl.* FROM um_role rl WHERE rl.rl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetRoleListPrivate(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT rl.* FROM um_role rl "; 
            if(strId.Length != 0)
                strSQL = strSQL + "SELECT rl.* FROM um_role rl " +
                    "WHERE rl.rl_id = '{0}' ";
            strSQL = strSQL + "ORDER BY rl.rl_order ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private Methods
        #endregion Get Methods

        #region Permissions
        private DataTable PermissionsGet(string strRlId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM um_role_permission " +
            "WHERE rl_id = '{0}' ";
            strSQL = string.Format(strSQL, strRlId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void PermissionsLoad(string strRlId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = PermissionsGet(strRlId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["prm_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["prm_id"].ToString();
            }

            role_permission = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void PermissionsUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (role_permission.Length != 0)
            {
                strInsert = "INSERT INTO um_role_permission (rlpr_id, rl_id, prm_id, usr_id_create, usr_date_create) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE() WHERE NOT '{1}' IN " +
                    "(SELECT prm_id FROM um_role_permission WHERE rl_id = '{0}') ";
                for (int intCount = 0; intCount < role_permission.Length; intCount++)
                {
                    if (role_permission[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", role_permission[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", role_permission[intCount]);
                        strSQL = strSQL + string.Format(strInsert, rl_id, role_permission[intCount], usr_id_update);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM um_role_permission WHERE rl_id = '{0}' AND NOT prm_id IN ({1}) ";
            strSQL = string.Format(strSQL, rl_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services
    }
}