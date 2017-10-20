using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benApprenticeshipRegisterLine
    {
        #region Variables
        #region Public
        public string aprl_id = string.Empty;
        public string aprl_enterprise = string.Empty;
        public DateTime aprl_date_begin = DateTime.Now;
        public DateTime aprl_date_complete = DateTime.Now;
        public string apr_id = string.Empty;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string apt_id = utilConstants.cDFEmptyListValue;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benApprenticeshipRegisterLine()
        {
            Default();
        }

        public benApprenticeshipRegisterLine(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM ben_apprenticeship_register_line WHERE aprl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void DeleteAll(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    Delete(dt.Rows[intCount]["aprl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records
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
                dt = GetLine(strId, dbCon);
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
            dt = GetLine(aprl_id, dbCon);
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
            aprl_id = string.Empty;
            aprl_enterprise = string.Empty;
            aprl_date_begin = DateTime.Now;
            aprl_date_complete = DateTime.Now;
            apr_id = string.Empty;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            apt_id = utilConstants.cDFEmptyListValue;
            cso_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_apprenticeship_register_line " +
                "(aprl_id, aprl_enterprise, " +
                "aprl_date_begin, aprl_date_complete, " +
                "apr_id, apt_id, cso_id, hhm_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', " +
                "'{4}', '{5}', '{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, aprl_id, utilFormatting.StringForSQL(aprl_enterprise),
                aprl_date_begin.ToString("dd MMM yyyy HH:mm:ss"), aprl_date_complete.ToString("dd MMM yyyy HH:mm:ss"),
                apr_id, apt_id, cso_id, hhm_id,
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
                aprl_id = dr["aprl_id"].ToString();
                aprl_enterprise = dr["aprl_enterprise"].ToString();
                aprl_date_begin = Convert.ToDateTime(dr["aprl_date_begin"]);
                aprl_date_complete = Convert.ToDateTime(dr["aprl_date_complete"]);
                apr_id = dr["apr_id"].ToString();
                apt_id = dr["apt_id"].ToString();
                cso_id = dr["cso_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
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
            strSQL = "UPDATE ben_apprenticeship_register_line " +
                "SET aprl_enterprise = '{1}', " +
                "aprl_date_begin = '{2}', aprl_date_complete = '{3}', " +
                "apr_id = '{4}', apt_id = '{5}', cso_id = '{6}', hhm_id = '{7}', " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE aprl_id = '{0}' ";
            strSQL = string.Format(strSQL, aprl_id, utilFormatting.StringForSQL(aprl_enterprise),
                aprl_date_begin.ToString("dd MMM yyyy HH:mm:ss"), aprl_date_complete.ToString("dd MMM yyyy HH:mm:ss"),
                apr_id, apt_id, cso_id, hhm_id, 
                usr_id_update, district_id);

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
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hh_id":
                        strWHERE = strWHERE + string.Format("AND hhm.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hhm_id":
                        strWHERE = strWHERE + string.Format("AND aprl.hhm_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "cso_id":
                        strWHERE = strWHERE + string.Format("AND aprl.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_date_create_begin":
                        strWHERE = strWHERE + string.Format("AND aprl.usr_date_create >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_date_create_end":
                        strWHERE = strWHERE + string.Format("AND aprl.usr_date_create <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT apr_id, RTRIM(LTRIM(CONVERT(CHAR(15), MIN(usr_date_create), 106))) AS the_date_display, " +
                "MIN(usr_date_create) AS the_date, " +
                "COUNT(aprl_id) AS num_records " +
                "FROM ben_apprenticeship_register_line " +
                "WHERE apr_id IN ( " +
                "SELECT aprl.apr_id " +
                "FROM ben_apprenticeship_register_line aprl " +
                "INNER JOIN hh_household_member hhm ON aprl.hhm_id = hhm.hhm_id " +
                "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                strWHERE +
                ") " +
                "GROUP BY apr_id " +
                "ORDER BY the_date DESC ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDateRange(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MIN(usr_date_create), GETDATE()) AS usr_date_create_begin, " +
                "ISNULL(MAX(usr_date_create), GETDATE()) AS usr_date_create_end " +
                "FROM ben_apprenticeship_register_line ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT aprl.aprl_id, aprl.ofc_id, hh.hh_code, hhm.hhm_number, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name " +
            "FROM ben_apprenticeship_register_line aprl " +
            "INNER JOIN hh_household_member hhm ON aprl.hhm_id = hhm.hhm_id " +
            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
            "WHERE aprl.apr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetLine(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT aprl.*, hhm.hh_id " +
            "FROM ben_apprenticeship_register_line aprl " +
            "INNER JOIN hh_household_member hhm ON aprl.hhm_id = hhm.hhm_id " +
            "WHERE aprl.aprl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
