using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class hh_household_improvement_plan
    {
        public static string hip_id = string.Empty;
        public static string hip_id_display = string.Empty;
        public static string hh_code = string.Empty;
        public static string hh_id = string.Empty;
        public static DateTime visit_date = DateTime.Today;
        public static int ov_below_seventeen_yrs_male = 0;
        public static int ov_below_seventeen_yrs_female = 0;
        public static int ov_above_eighteen_yrs_male = 0;
        public static int ov_above_eighteen_yrs_female = 0;
        public static string health_knows_status_of_children = string.Empty;
        public static string health_enrolled_on_art = string.Empty;
        public static string health_action_plan = string.Empty;
        public static string health_follow_up_date = string.Empty;
        public static string household_is_healthy = string.Empty;
        public static string safe_has_birth_certificates = string.Empty;
        public static string safe_no_child_abuse = string.Empty;
        public static string safe_action_plan = string.Empty;
        public static string safe_follow_up_date = string.Empty;
        public static string household_is_safe = string.Empty;
        public static string stable_source_of_income = string.Empty;
        public static string stable_financial_services = string.Empty;
        public static string stable_two_or_more_meals = string.Empty;
        public static string stable_action_plan = string.Empty;
        public static string stable_follow_up_date = string.Empty;
        public static string household_is_stable = string.Empty;
        public static string schooled_all_attending_school = string.Empty;
        public static string schooled_attained_techinical_skill = string.Empty;
        public static string schooled_others = string.Empty;
        public static string schooled_action_plan = string.Empty;
        public static string schooled_follow_up_date = string.Empty;
        public static string household_is_schooled = string.Empty;
        public static string sw_id = string.Empty;
        public static string sw_comment = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        //household members
        public static DataTable Return_household_member_ages(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = " SELECT G.gnd_name,  (YEAR(GETDATE()) -  H.hhm_year_of_birth) AS age FROM hh_household_member H " +
                        "LEFT JOIN lst_gender G ON H.gnd_id = G.gnd_id " +
                        "WHERE H.hhm_year_of_birth <> '*' " +
                        "AND H.hhm_year_of_birth <> '-1' " +
                         "AND H.hh_id = '"+ hh_id +"'  ";
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

        //return head of household
        public static string Return_household_head(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string hhm_id = string.Empty;
            string SQL = " SELECT hhm_id FROM hh_household_member " +
                            "WHERE yn_id_hoh = 1 " +
                            "AND hh_id = '" + hh_id + "'";
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
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        hhm_id = dtRow["hhm_id"].ToString();
                    }

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

            return hhm_id;
        }

        //return para social workers
        public static DataTable Return_ParasocialWorkerList(int dst_id,string sct_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT S.swk_id,S.swk_first_name + ' ' + S.swk_last_name AS swk_name FROM swm_social_worker S " +
                        "LEFT JOIN lst_ward W ON S.wrd_id = W.wrd_id " +
                        "LEFT JOIN lst_sub_county SB ON W.sct_id = SB.sct_id " +
                        "LEFT JOIN lst_district D ON SB.dst_id = D.dst_id " +
                        "WHERE S.swt_id = 1 " +
                        "AND D.dst_id = '" + dst_id + "'";
                           
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

        #region save HIP Details

        public static int Return_hhm_hiv_status_from_hhassessment(string hh_id,int hst_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            int count = 0;
            string SQL = " SELECT COUNT(M.hst_id) FROM hh_household_assessment_member M " + 
                            "LEFT JOIN hh_household_assessment H ON M.hha_id = H.hha_id " + 
                            "WHERE hst_id = '"+ hst_id +"' " + 
                            "AND H.hh_id = '"+ hh_id +"' ";
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
                    count = (int)cmd.ExecuteScalar();

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

            return count;
        }
        public static void save_update_hh_hip_details(string action)
        {
            string Query = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = @"INSERT INTO [dbo].[hh_household_improvement_plan]([hip_id],[hh_code],[hh_id],[visit_date] ,[ov_below_seventeen_yrs_male],[ov_below_seventeen_yrs_female]
           ,[ov_above_eighteen_yrs_male],[ov_above_eighteen_yrs_female],[health_knows_status_of_children] ,[health_enrolled_on_art],[health_action_plan]
           ,[health_follow_up_date],[household_is_healthy],[safe_has_birth_certificates],[safe_no_child_abuse],[safe_action_plan],[safe_follow_up_date]
           ,[household_is_safe],[stable_source_of_income],[stable_financial_services],[stable_two_or_more_meals],[stable_action_plan],[stable_follow_up_date]
           ,[household_is_stable],[schooled_all_attending_school],[schooled_attained_techinical_skill],[schooled_others],[schooled_action_plan],[schooled_follow_up_date]
           ,[household_is_schooled],[sw_id],[sw_comment],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])

            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}',
                    '{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}')";



            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[hh_household_improvement_plan]
                   SET [hh_code] = '{1}',[hh_id] = '{2}',[visit_date] = '{3}',[ov_below_seventeen_yrs_male] = '{4}',[ov_below_seventeen_yrs_female] = '{5}'
                      ,[ov_above_eighteen_yrs_male] = '{6}',[ov_above_eighteen_yrs_female] = '{7}',[health_knows_status_of_children] = '{8}',[health_enrolled_on_art] = '{9}'
                      ,[health_action_plan] = '{10}',[health_follow_up_date] = '{11}',[household_is_healthy] = '{12}',[safe_has_birth_certificates] = '{13}',[safe_no_child_abuse] = '{14}'
                      ,[safe_action_plan] = '{15}',[safe_follow_up_date] = '{16}',[household_is_safe] = '{17}',[stable_source_of_income] = '{18}',[stable_financial_services] = '{19}'
                      ,[stable_two_or_more_meals] = '{20}',[stable_action_plan] = '{21}' ,[stable_follow_up_date] = '{22}' ,[household_is_stable] = '{23}',[schooled_all_attending_school] = '{24}'
                      ,[schooled_attained_techinical_skill] = '{25}',[schooled_others] = '{26}' ,[schooled_action_plan] = '{27}',[schooled_follow_up_date] ='{28}'
	                  ,[household_is_schooled] = '{29}',[sw_id] = '{30}',[sw_comment] ='{31}',[usr_id_update] = '{32}',[usr_date_update] = '{33}'
                 WHERE hip_id =  '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, hip_id, hh_code, hh_id, visit_date, ov_below_seventeen_yrs_male, ov_below_seventeen_yrs_female, ov_above_eighteen_yrs_male,
                        ov_above_eighteen_yrs_female, health_knows_status_of_children, health_enrolled_on_art, health_action_plan, health_follow_up_date, household_is_healthy,
                        safe_has_birth_certificates, safe_no_child_abuse, safe_action_plan, safe_follow_up_date, household_is_safe, stable_source_of_income, stable_financial_services,
                        stable_two_or_more_meals, stable_action_plan, stable_follow_up_date, household_is_stable, schooled_all_attending_school, schooled_attained_techinical_skill,
                        schooled_others, schooled_action_plan, schooled_follow_up_date, household_is_schooled, sw_id, sw_comment, usr_id_create, usr_id_update, usr_date_create,
                        usr_date_update, ofc_id, district_id);
                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, hip_id, hh_code, hh_id, visit_date, ov_below_seventeen_yrs_male, ov_below_seventeen_yrs_female, ov_above_eighteen_yrs_male,
                        ov_above_eighteen_yrs_female, health_knows_status_of_children, health_enrolled_on_art, health_action_plan, health_follow_up_date, household_is_healthy,
                        safe_has_birth_certificates, safe_no_child_abuse, safe_action_plan, safe_follow_up_date, household_is_safe, stable_source_of_income, stable_financial_services,
                        stable_two_or_more_meals, stable_action_plan, stable_follow_up_date, household_is_stable, schooled_all_attending_school, schooled_attained_techinical_skill,
                        schooled_others, schooled_action_plan, schooled_follow_up_date, household_is_schooled, sw_id, sw_comment, usr_id_update,
                        usr_date_update);
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
        #endregion save HIP Details

        #region HH Hip List
        public static DataTable Return_HHHipList(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT hip_id, hh_code,visit_date FROM hh_household_improvement_plan WHERE hh_id = '" + hh_id +"'";

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
        #endregion HH Hip List

        #region Hip details
        public static DataTable Return_HipDetails(string hip_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT* FROM hh_household_improvement_plan WHERE hip_id = '" + hip_id + "'";

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
        #endregion Hip details
    }
}
