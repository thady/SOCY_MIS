using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdHomeVisit
    {
        #region Variables
        #region Public
        public string hhv_id = string.Empty;

        public DateTime hhv_date = DateTime.Now;
        public DateTime hhv_date_next_visit = DateTime.Now;

        public int hhv_household_income = 0;

        public string hhv_comments = string.Empty;
        public string hhv_next_steps = string.Empty;
        public string hhv_swk_code = string.Empty;
        public string hhv_visitor_tel = string.Empty;

        public string am_id = utilConstants.cDFEmptyListValue;
        public string hvhs_id = utilConstants.cDFEmptyListValue;
        public string hvr_id = utilConstants.cDFEmptyListValue;

        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string hnr_id_visitor = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string swk_id_visitor = utilConstants.cDFEmptyListValue;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhHouseholdHomeVisit()
        {
            Default();
        }

        public hhHouseholdHomeVisit(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_household_home_visit_member WHERE hhv_id = '{0}' " + 
                "DELETE FROM hh_household_home_visit WHERE hhv_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set HomeVisit
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetObject(strId, dbCon);
                Load(dt);
            }
            #endregion Set HomeVisit
        }

        public void Save(DBConnection dbCon, string hh_id, string hhs_id)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(hhv_id, dbCon);
            if (utilCollections.HasRows(dt))
            {
                Update(dbCon);
                update_hh_status(hh_id, hhs_id);
            }
            else
            {
                Insert(dbCon);
                update_hh_status(hh_id, hhs_id);
            }
                
            #endregion Save
        }

        public void update_hh_status(string hh_id,string hhs_id)
        {
            string crop_name = string.Empty;

            string SQL = "UPDATE hh_household SET hhs_id = '{0}',district_id = '{2}' WHERE hh_id = '{1}'";
            SQL = string.Format(SQL, hhs_id, hh_id,SystemConstants.Return_office_district());
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }

            finally
            {
                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }

        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            hhv_id = string.Empty;
            hhv_date = DateTime.Now;
            hhv_date_next_visit = DateTime.Now;
            hhv_household_income = 0;
            hhv_comments = string.Empty;
            hhv_next_steps = string.Empty;
            hhv_swk_code = string.Empty;
            hhv_visitor_tel = string.Empty;
            am_id = utilConstants.cDFEmptyListValue;
            hvhs_id = utilConstants.cDFEmptyListValue;
            hvr_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            hnr_id_visitor = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            swk_id_visitor = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_household_home_visit " +
                "(hhv_id, " +
                "hhv_date, hhv_date_next_visit, " +
                "hhv_household_income, " +
                "hhv_comments, hhv_next_steps, " + 
                "hhv_swk_code, hhv_visitor_tel, " +
                "am_id, hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " + 
                "'{1}', '{2}', " +
                "{3}, " +
                "'{4}', '{5}', " + 
                "'{6}', '{7}', " + 
                "'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', " +
                "'{16}', '{16}', GETDATE(), GETDATE(), '{17}','{18}') ";
            strSQL = string.Format(strSQL, hhv_id, 
                hhv_date.ToString("dd MMM yyyy HH:mm:ss"), hhv_date_next_visit.ToString("dd MMM yyyy HH:mm:ss"),
                hhv_household_income.ToString(),
                utilFormatting.StringForSQL(hhv_comments), utilFormatting.StringForSQL(hhv_next_steps),
                utilFormatting.StringForSQL(hhv_swk_code), utilFormatting.StringForSQL(hhv_visitor_tel),
                am_id, hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor, 
                usr_id_update, ofc_id, district_id);

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
                hhv_id = dr["hhv_id"].ToString();
                hhv_date = Convert.ToDateTime(dr["hhv_date"]);
                hhv_date_next_visit = Convert.ToDateTime(dr["hhv_date_next_visit"]);
                hhv_household_income = Convert.ToInt32(dr["hhv_household_income"]);
                hhv_comments = dr["hhv_comments"].ToString();
                hhv_next_steps = dr["hhv_next_steps"].ToString();
                hhv_swk_code = dr["hhv_swk_code"].ToString();
                hhv_visitor_tel = dr["hhv_visitor_tel"].ToString();
                am_id = dr["am_id"].ToString();
                hvhs_id = dr["hvhs_id"].ToString();
                hvr_id = dr["hvr_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                hnr_id_visitor = dr["hnr_id_visitor"].ToString();
                swk_id = dr["swk_id"].ToString();
                swk_id_visitor = dr["swk_id_visitor"].ToString();
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
            strSQL = "UPDATE hh_household_home_visit " +
                "SET hhv_date = '{1}', hhv_date_next_visit = '{2}',  " +
                "hhv_household_income = {3},  " +
                "hhv_comments = '{4}', hhv_next_steps = '{5}',  " +
                "hhv_swk_code = '{6}', hhv_visitor_tel = '{7}',  " +
                "am_id = '{8}', hvhs_id = '{9}', hvr_id = '{10}', hh_id = '{11}', hhm_id = '{12}', hnr_id_visitor = '{13}', swk_id = '{14}', swk_id_visitor = '{15}', " +
                "usr_id_update = '{16}', usr_date_update = GETDATE(),district_id = '{17}' " +
                "WHERE hhv_id = '{0}' ";
            strSQL = string.Format(strSQL, hhv_id, 
                hhv_date.ToString("dd MMM yyyy HH:mm:ss"), hhv_date_next_visit.ToString("dd MMM yyyy HH:mm:ss"),
                hhv_household_income.ToString(),
                utilFormatting.StringForSQL(hhv_comments), utilFormatting.StringForSQL(hhv_next_steps),
                utilFormatting.StringForSQL(hhv_swk_code), utilFormatting.StringForSQL(hhv_visitor_tel),
                am_id, hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor, 
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
                    case "hh_id":
                        strWHERE = strWHERE + string.Format("AND hhv.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hhv_date_begin":
                        strWHERE = strWHERE + string.Format("AND hhv.hhv_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hhv_date_end":
                        strWHERE = strWHERE + string.Format("AND hhv.hhv_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT hhv.hhv_id, hh.hh_code, " + 
                "RTRIM(LTRIM(CONVERT(CHAR(15), hhv.hhv_date, 106))) AS the_date_display, " +
                "hhv.hhv_date AS the_date " +
                "FROM hh_household_home_visit hhv " +
                "INNER JOIN hh_household hh ON hhv.hh_id = hh.hh_id " +
                strWHERE +
                "ORDER BY hh.hh_code, the_date DESC ";
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
            strSQL = "SELECT ISNULL(MIN(hhv_date), GETDATE()) AS hhv_date_begin, " +
                "ISNULL(MAX(hhv_date), GETDATE()) AS hhv_date_end " +
                "FROM hh_household_home_visit ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhvm.hhvm_id, hhvm.ofc_id, " +
                "hhm.hhm_first_name, hhm.hhm_last_name, ISNULL(hhm.hhm_number, '') AS hhm_number, " +
                "REPLACE(hhm.hhm_year_of_birth, '-1', '') AS year_of_birth, " +
                "REPLACE(gnd.gnd_name, '-1', '') AS gnd_name " +
                "FROM hh_household_home_visit_member hhvm " +
                "LEFT JOIN hh_household_member hhm ON hhvm.hhm_id = hhm.hhm_id " +
                "LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "LEFT JOIN (SELECT gnd_id, gnd_name FROM lst_gender WHERE lng_id = '{1}') gnd ON hhm.gnd_id = gnd.gnd_id " +
                "WHERE hhvm.hhv_id = '{0}' " +
                "ORDER BY hhm_number ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembers(string strHhvId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhvm.*, hhm.hhm_first_name, hhm.hhm_last_name, gnd.gnd_name, REPLACE(hhm.hhm_year_of_birth, '-1', '') AS year_of_birth, hhm.hhm_number " +
                "FROM hh_household_home_visit_member hhvm " +
                "INNER JOIN hh_household_member hhm ON hhvm.hhm_id = hhm.hhm_id " +
                "LEFT JOIN (SELECT * FROM lst_gender WHERE lng_id = '{1}') gnd ON hhm.gnd_id = gnd.gnd_id " +
                "WHERE hhvm.hhv_id = '{0}' ";
            strSQL = string.Format(strSQL, strHhvId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhv.* " +
            "FROM hh_household_home_visit hhv " +
            "WHERE hhv.hhv_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}