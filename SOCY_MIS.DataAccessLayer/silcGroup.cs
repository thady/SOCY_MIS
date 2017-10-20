using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcGroup
    {
        #region Variables
        #region Public
        public string sg_id = string.Empty;
        public string sg_name = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcGroup()
        {
            Default();
        }

        public silcGroup(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public bool CheckNameInUse(string strId, string strName, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT ISNULL(COUNT(sg_id), 0) FROM silc_group WHERE REPLACE(LOWER(sg_name), ' ', '') = '{1}' " +
                "AND NOT sg_id IN (SELECT sg_id FROM silc_group WHERE REPLACE(LOWER(sg_name), ' ', '') = '{1}' AND sg_id = '{0}') ", strId, strName.ToLower().Replace(" ", ""));
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
            strSQL = "DELETE FROM  WHERE at_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Data
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetGroup(strId, dbCon);
                Load(dt);
            }
            #endregion Set Data
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetGroup(sg_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            sg_id = string.Empty;
            sg_name = string.Empty;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO silc_group " +
                "(sg_id, sg_name, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " + 
                "'{2}', '{2}', GETDATE(), GETDATE(), '{3}','{4}') ";
            strSQL = string.Format(strSQL, sg_id, utilFormatting.StringForSQL(sg_name),
                usr_id_update, ofc_id,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        private void Load(DataTable dt)
        {
            #region Variables
            DataRow dr = null;
            #endregion Variables

            if (!utilCollections.HasRows(dt))
            {
                Default();
            }
            else
            {
                #region Load Values
                dr = dt.Rows[0];
                sg_id = dr["sg_id"].ToString();
                sg_name = dr["sg_name"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE silc_group " +
                "SET sg_name = '{1}', " +
                "usr_id_update = '{2}', usr_date_update = GETDATE(),district_id = '{3}' " +
                "WHERE sg_id = '{0}' ";
            strSQL = string.Format(strSQL, sg_id, utilFormatting.StringForSQL(sg_name),
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetByCriteria(string[,] arrFilter, int intArrayLength, string strLngId, DBConnection dbCon)
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
                    case "sg_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(sg.sg_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT sg.* " +
                "FROM silc_group sg " +
                strWHERE +
                "ORDER BY sg_name ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetList(DBConnection dbCon)
        {
            return GetList("", "", "", "", "", dbCon);
        }

        public DataTable GetList(string strSgId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region SQL
            strSQLSelect = "SELECT sg.sg_id, sg.sg_name FROM silc_group sg ";
            strSQL = strSQLSelect;
            if (strFormTable.Length != 0)
                strSQL = strSQL + string.Format("WHERE NOT sg.sg_id IN (SELECT {3} FROM {0} {1} WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId, strMemberField);
            if (strSgId.Length != 0)
                strSQL = strSQL + "UNION " + strSQLSelect + string.Format("WHERE sg.sg_id = '{0}' ", strSgId);
            strSQL = strSQL + "ORDER BY sg_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembers(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT sgm.sgm_id, ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, sgm.sgm_name) AS member_name, mtp.mtp_id, mtp.mtp_name " +
                "FROM  silc_group_member sgm " +
                "INNER JOIN lst_member_type mtp ON sgm.mtp_id = mtp.mtp_id AND mtp.lng_id = '{1}' " +
			    "LEFT JOIN hh_household_member hhm ON sgm.hhm_id = hhm.hhm_id " +
                "WHERE sgm.sg_id = '{0}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembersForForm(string strSgId, string strSgmId, string strFormTable, string strFormPrefix, string strObjId, DBConnection dbCon)
        {
            return GetMembersForForm(strSgId, strSgmId, strFormTable, strFormPrefix, strObjId, "sgm_id", dbCon);
        }

        public DataTable GetMembersForForm(string strSgId, string strSgmId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region SQL
            strSQLSelect = string.Format("SELECT sgm.sgm_id, ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, sgm.sgm_name) AS member_name " +
                "FROM  silc_group_member sgm " +
                "LEFT JOIN hh_household_member hhm ON sgm.hhm_id = hhm.hhm_id " +
                "WHERE sgm.sg_id = '{0}' ", strSgId);
            strSQL = strSQLSelect + string.Format("AND NOT sgm.sgm_id IN (SELECT {3} FROM {0} {1} WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId, strMemberField);
            if (strSgmId.Length != 0)
                strSQL = strSQL + "UNION " + strSQLSelect + string.Format("AND sgm.sg_id = '{0}' AND sgm.sgm_id = '{1}' ", strSgId, strSgmId);
            strSQL = strSQL + "ORDER BY member_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetSavingsRegisters(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ssr.ssr_id, ISNULL(cso.cso_name, '') AS cso_name, " +
                "ISNULL(qy.qy_name, '') AS qy_name, ISNULL(fy.fy_name, '') AS fy_name, " + 
                "ssr.ssr_cycle_number " +
                "FROM  silc_savings_register ssr " +
                "LEFT JOIN lst_cso cso ON ssr.cso_id = cso.cso_id " +
                "LEFT JOIN lst_financial_year fy ON ssr.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON ssr.qy_id = qy.qy_id " +
                "WHERE ssr.sg_id = '{0}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetGroup(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT sg.* " +
            "FROM silc_group sg " +
            "WHERE sg.sg_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}