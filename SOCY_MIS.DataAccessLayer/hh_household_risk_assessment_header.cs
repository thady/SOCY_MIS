using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public static class hh_household_risk_assessment_header
    {
        public static string ras_id = string.Empty;
        public static string _ras_id = string.Empty;
        public static string hh_code = string.Empty;
        public static string hh_id = string.Empty;
        public static string interviewed_member_id = string.Empty;
        public static DateTime date_of_visit = DateTime.Now;
        public static string usr_id_create = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region save risk assessment
        public static string save_update_hhm_risk_assessment_details(string action)
        {
            string Query = string.Empty;
          

            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ras_id nvarchar(150)) INSERT INTO [dbo].[hh_household_risk_assessment_header]
           ([ras_id] ,[hh_code],[hh_id],[interviewed_member_id] ,[date_of_visit] ,[usr_id_create],[usr_id_update] 
           ,[usr_date_create] ,[usr_date_update],[ofc_id] ,[district_id]) OUTPUT INSERTED.[ras_id] INTO @tempTable
           VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')
            SELECT ras_id FROM @tempTable";

            }
            else if (action == "update")
            {
                //update
                Query = "UPDATE [dbo].[hh_household_risk_assessment_header]" +
                       "SET [interviewed_member_id] = '{1}',[date_of_visit] = '{2},[usr_id_update] = '{3}'  " +
                          "[usr_date_update] = '{4}'" +
                          " WHERE [ras_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ras_id, hh_code, hh_id, interviewed_member_id, date_of_visit, usr_id_create, usr_id_update,
                        usr_date_create, usr_date_update, ofc_id, district_id);
                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ras_id, interviewed_member_id, date_of_visit, usr_id_update, usr_date_update);
                        
                }
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (action == "insert")
                    {
                        ras_id = (string)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }
                   else
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
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
            if (action == "insert")
            {
                return ras_id;
            }
            else {
                return string.Empty;
            }
        }
        #endregion save risk assessment

        #region Risk assessment lists
        public static DataTable Return_risk_assessments_by_hh_id(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;

            string SQL = @"SELECT [date_of_visit],[hh_code],HHM.hhm_first_name + ' ' + HHM.hhm_last_name AS [hhm_name],H.ras_id,H.ofc_id
                          FROM [dbo].[hh_household_risk_assessment_header] H 
                          LEFT JOIN hh_household_member HHM ON H.interviewed_member_id = HHM.hhm_id
                          WHERE H.hh_id ='{0}' ";
            try
            {
                string strConn = dbCon.ToString();
                SQL = string.Format(SQL, hh_id);

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    Adapt = new SqlDataAdapter(cmd);
                    Adapt.Fill(dt);

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

            return dt;
        }

        public static DataTable Return_RAS_details(string ras_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;

            string SQL = @"SELECT [date_of_visit],[hh_code],HHM.hhm_first_name + ' ' + HHM.hhm_last_name AS [hhm_name],H.ras_id,H.ofc_id
                          FROM [dbo].[hh_household_risk_assessment_header] H 
                          LEFT JOIN hh_household_member HHM ON H.interviewed_member_id = HHM.hhm_id
                          WHERE H.ras_id ='{0}' ";
            try
            {
                string strConn = dbCon.ToString();
                SQL = string.Format(SQL, ras_id);

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    Adapt = new SqlDataAdapter(cmd);
                    Adapt.Fill(dt);

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

            return dt;
        }
        #endregion Risk assessment lists
    }
}
