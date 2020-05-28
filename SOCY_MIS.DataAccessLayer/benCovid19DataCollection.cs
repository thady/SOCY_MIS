using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benCovid19DataCollection
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string cdc_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string report_month = string.Empty;
        public static string week_name = string.Empty;
        public static string swk_id = string.Empty;
        public static string psw_id = string.Empty;
        public static string total_hh_visited = string.Empty;
        public static string total_hh_hip_reviewed = string.Empty;
        public static string total_ben_served = string.Empty;
        public static string total_ben_hiv_pos = string.Empty;
        public static string total_ben_hiv_neg = string.Empty;
        public static string total_ben_hiv_tnr = string.Empty;
        public static string total_ben_hiv_unknown = string.Empty;
        public static string total_ben_risk_assessed = string.Empty;
        public static string total_new_referals_made = string.Empty;
        public static string total_old_referals_followedup = string.Empty;
        public static string total_ben_with_vl = string.Empty;
        public static string total_ben_not_supress = string.Empty;
        public static string total_emergency_case_found = string.Empty;
        public static string general_comment = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion

        public static void save(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[ben_covid19_data_collection]
                    ([cdc_id] ,[wrd_id] ,[report_month] ,[week_name],[swk_id],[psw_id] ,[total_hh_visited],[total_hh_hip_reviewed] ,[total_ben_served] ,[total_ben_hiv_pos]
                    ,[total_ben_hiv_neg] ,[total_ben_hiv_tnr] ,[total_ben_hiv_unknown] ,[total_ben_risk_assessed] ,[total_new_referals_made] ,[total_old_referals_followedup]
                    ,[total_ben_with_vl] ,[total_ben_not_supress] ,[total_emergency_case_found] ,[general_comment] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update]
                    ,[ofc_id] ,[district_id])
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')";

            strSQL = string.Format(strSQL, cdc_id, wrd_id, report_month, week_name, swk_id, psw_id, total_hh_visited, total_hh_hip_reviewed, total_ben_served, total_ben_hiv_pos
           , total_ben_hiv_neg, total_ben_hiv_tnr, total_ben_hiv_unknown, total_ben_risk_assessed, total_new_referals_made, total_old_referals_followedup
           , total_ben_with_vl, total_ben_not_supress, total_emergency_case_found, general_comment, usr_id_create, usr_id_update, usr_date_create, usr_date_update
           , ofc_id, district_id);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_covid19_data_collection]
                       SET [wrd_id] =  '{1}'
                          ,[report_month] = '{2}'
                          ,[week_name] = '{3}'
                          ,[swk_id] = '{4}'
                          ,[psw_id] = '{5}'
                          ,[total_hh_visited] = '{6}'
                          ,[total_hh_hip_reviewed] = '{7}'
                          ,[total_ben_served] = '{8}'
                          ,[total_ben_hiv_pos] = '{9}'
                          ,[total_ben_hiv_neg] ='{10}'
                          ,[total_ben_hiv_tnr] = '{11}'
                          ,[total_ben_hiv_unknown] = '{12}'
                          ,[total_ben_risk_assessed] = '{13}'
                          ,[total_new_referals_made] = '{14}'
                          ,[total_old_referals_followedup] = '{15}'
                          ,[total_ben_with_vl] ='{16}'
                          ,[total_ben_not_supress] = '{17}'
                          ,[total_emergency_case_found] = '{18}'
                          ,[general_comment] = '{19}'
                          ,[usr_id_update] = '{20}'
                          ,[usr_date_update] = '{21}'
                     WHERE  [cdc_id] = '{0}'";

            strSQL = string.Format(strSQL, cdc_id, wrd_id, report_month, week_name, swk_id, psw_id, total_hh_visited, total_hh_hip_reviewed, total_ben_served, total_ben_hiv_pos
           , total_ben_hiv_neg, total_ben_hiv_tnr, total_ben_hiv_unknown, total_ben_risk_assessed, total_new_referals_made, total_old_referals_followedup
           , total_ben_with_vl, total_ben_not_supress, total_emergency_case_found, general_comment, usr_id_update, usr_date_update);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static DataTable LoadList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.cdc_id, dst.dst_name,sct.sct_name,W.wrd_name,dt.report_month,dt.week_name,swm.swk_first_name + '' + swm.swk_last_name AS swk_name,psw.swk_first_name + ' ' + psw.swk_last_name AS psw_name FROM ben_covid19_data_collection dt
                INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                INNER JOIN swm_social_worker swm ON dt.swk_id = swm.swk_id
                INNER JOIN swm_social_worker psw ON dt.psw_id = psw.swk_id";

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

        public static DataTable Search(string dst_id, string sct_id,string reportMonth)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dt.cdc_id, dst.dst_name,sct.sct_name,W.wrd_name,dt.report_month,dt.week_name,swm.swk_first_name + '' + swm.swk_last_name AS swk_name,psw.swk_first_name + ' ' + psw.swk_last_name AS psw_name FROM ben_covid19_data_collection dt
                INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                INNER JOIN swm_social_worker swm ON dt.swk_id = swm.swk_id
                INNER JOIN swm_social_worker psw ON dt.psw_id = psw.swk_id
                WHERE (@sct_id = '' OR sct.sct_id =  @sct_id  )
                AND (@dst_id = '' OR dst.dst_id = @dst_id  )
                AND (@report_month = '' OR dt.report_month = @report_month)";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@report_month", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@report_month"].Value = reportMonth;

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

        public static DataTable LoadDetails(string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dst.dst_id,sct.sct_id,dt.* FROM ben_covid19_data_collection dt
                INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                INNER JOIN swm_social_worker swm ON dt.swk_id = swm.swk_id
                INNER JOIN swm_social_worker psw ON dt.psw_id = psw.swk_id
                WHERE dt.cdc_id = '{0}'";

                SQL = string.Format(SQL, id);

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
    }
}
