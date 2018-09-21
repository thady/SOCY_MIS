using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public static class benYouthTracer
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string ytr_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime date = DateTime.Now;
        public static string hhm_id = string.Empty;
        public static string fo_name = string.Empty;
        public static string ttp_received = string.Empty;
        public static string ttp_other = string.Empty;
        public static string employment_status = string.Empty;
        public static string yn_using_acquired_skills = string.Empty;
        public static string yn_using_acquired_skills_no_reason = string.Empty;
        public static string yn_market_available = string.Empty;
        public static string average_income = string.Empty;
        public static string formal_bussiness_sector = string.Empty;
        public static string formal_employment_search_period = string.Empty;
        public static string formal_current_job_challenges = string.Empty;
        public static string self_bussiness_sector = string.Empty;
        public static string self_source_of_startup_capital = string.Empty;
        public static string sponsor_name = string.Empty;
        public static string startup_amt = string.Empty;
        public static string bussiness_setup_help_source = string.Empty;
        public static string bussiness_startup_duration = string.Empty;
        public static string occupation_before_business_startup = string.Empty;
        public static string bussiness_problems_faced = string.Empty;
        public static string unemployed_reason = string.Empty;
        public static string unemployed_reason_other = string.Empty;
        public static string unemployment_action = string.Empty;
        public static string yn_recommend_programme = string.Empty;
        public static string hhm_comments = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion

        #region Save
        public static void save(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"INSERT INTO [dbo].[ben_youth_tracer]
                               ([ytr_id],[prt_id],[cso_id],[wrd_id],[date],[hhm_id],[fo_name],[ttp_received],[ttp_other],[employment_status],[yn_using_acquired_skills]
                               ,[yn_using_acquired_skills_no_reason],[yn_market_available],[average_income],[formal_bussiness_sector],[formal_employment_search_period],[formal_current_job_challenges]
                               ,[self_bussiness_sector],[self_source_of_startup_capital],[sponsor_name],[startup_amt],[bussiness_setup_help_source],[bussiness_startup_duration],[occupation_before_business_startup]
                               ,[bussiness_problems_faced],[unemployed_reason],[unemployed_reason_other],[unemployment_action],[yn_recommend_programme] ,[hhm_comments],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id]
                               ,[district_id])
                         VALUES
                               ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
                               ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}'
                               ,'{30}','{31}' ,'{32}','{33}','{34}','{35}')";

                    SQL = string.Format(SQL, ytr_id, prt_id, cso_id, wrd_id, date, hhm_id, fo_name, ttp_received, ttp_other, employment_status, yn_using_acquired_skills, yn_using_acquired_skills_no_reason, yn_market_available,
                        average_income, formal_bussiness_sector, formal_employment_search_period, formal_current_job_challenges,
                        self_bussiness_sector, self_source_of_startup_capital, sponsor_name,startup_amt,bussiness_setup_help_source,bussiness_startup_duration,occupation_before_business_startup,bussiness_problems_faced,
                        unemployed_reason, unemployed_reason_other, unemployment_action,yn_recommend_programme,hhm_comments, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                    #endregion Insert

                }
                else
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_youth_tracer]
                           SET [prt_id] = '{1}'
                              ,[cso_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[date] = '{4}'
                              ,[hhm_id] = '{5}'
                              ,[fo_name] = '{6}'
                              ,[ttp_received] = '{7}'
                              ,[ttp_other] = '{8}'
                              ,[employment_status] = '{9}'
                              ,[yn_using_acquired_skills] = '{10}'
                              ,[yn_using_acquired_skills_no_reason] = '{11}'
                              ,[yn_market_available] = '{12}'
                              ,[average_income] = '{13}'
                              ,[formal_bussiness_sector] = '{14}'
                              ,[formal_employment_search_period] = '{15}'
                              ,[formal_current_job_challenges] = '{16}'
                              ,[self_bussiness_sector] = '{17}'
                              ,[self_source_of_startup_capital] = '{18}'
                              ,[sponsor_name] = '{19}'
                              ,[startup_amt] = '{20}'
                              ,[bussiness_setup_help_source] = '{21}'
                              ,[bussiness_startup_duration] = '{22}'
                              ,[occupation_before_business_startup] = '{23}'
                              ,[bussiness_problems_faced] = '{24}'
                              ,[unemployed_reason] = '{25}'
                               ,[unemployed_reason_other] = '{26}'
                              ,[unemployment_action] = '{27}'
                              ,[yn_recommend_programme] = '{28}'
                              ,[hhm_comments] = '{29}'
                              ,[usr_id_update] = '{30}'
                              ,[usr_date_update] = '{31}'
                         WHERE [ytr_id] = '{0}'";


                    SQL = string.Format(SQL, ytr_id, prt_id, cso_id, wrd_id, date, hhm_id, fo_name, ttp_received, ttp_other, employment_status, yn_using_acquired_skills, yn_using_acquired_skills_no_reason, yn_market_available,
                        average_income, formal_bussiness_sector, formal_employment_search_period, formal_current_job_challenges,
                        self_bussiness_sector, self_source_of_startup_capital, sponsor_name, startup_amt, bussiness_setup_help_source, bussiness_startup_duration, occupation_before_business_startup, bussiness_problems_faced,
                        unemployed_reason, unemployed_reason_other, unemployment_action, yn_recommend_programme, hhm_comments,usr_id_update, usr_date_update);
                    #endregion Update

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

                    cmd.CommandTimeout = 3600;
                    cmd.CommandType = CommandType.Text;
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

        #endregion Save

        #region Display
        public static DataTable LoadDisplay(string DisplayType,string ytr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            switch (DisplayType)
            {
                case "distinct":
                    SQL = @"SELECT dt.*,hh.hh_id,dst.dst_id,sct.sct_id,W.wrd_id FROM ben_youth_tracer dt
                            INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                            INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                            INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                            INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                            INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                            WHERE dt.ytr_id = '{0}'";

                    SQL = string.Format(SQL, ytr_id);
                    break;
                case "list":
                    SQL = @"SELECT T.ytr_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                            FROM ben_youth_tracer T
                            LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                            LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id";
                    break;
            }

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
        #endregion

        #region Search
        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string youth_name, string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT T.ytr_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                        FROM ben_youth_tracer T
                        LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                        LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        LEFT JOIN lst_partner prt ON T.prt_id = prt.prt_id
                        LEFT JOIN lst_cso cso ON T.cso_id = cso.cso_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
                        AND (@prt_id = '-1' OR prt.prt_id = @prt_id)
                        AND (@cso_id = '-1' OR cso.cso_id = @cso_id)
                        AND ((@youth_name = '' OR hhm.hhm_first_name LIKE '%' + @youth_name  + '%') OR (@youth_name = '' OR hhm.hhm_last_name LIKE '%' + @youth_name  + '%') )
                        AND (@hh_code = '' OR H.hh_code LIKE '%' + @hh_code  + '%')";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@prt_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@prt_id"].Value = prt_id;

                    cmd.Parameters.Add("@cso_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@cso_id"].Value = cso_id;

                    cmd.Parameters.Add("@youth_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@youth_name"].Value = youth_name;

                    cmd.Parameters.Add("@hh_code", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@hh_code"].Value = hh_code;

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
        #endregion Search


    }
}
