using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
   public static class hh_household_improvement_plan
    {
        #region OldHip
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

        public static string yn_safe_birth_certificates = string.Empty;
        public static string yn_safe_birth_certificates_action = string.Empty;
        public static string yn_safe_birth_certificates_followup_date = string.Empty;
        public static string yn_safe_birth_certificates_out_come = string.Empty;
        #endregion OldHip

        #region NewHip
        public static DateTime initial_hip_date = DateTime.Now;
        public static string qm_id = string.Empty;
        public static string hip_reason = string.Empty;
        public static string yn_knows_status_of_children = string.Empty;
        public static string yn_knows_status_of_children_action = string.Empty;
        public static string yn_knows_status_of_children_out_come = string.Empty;
        public static string yn_knows_status_of_children_followup_date = string.Empty;
        public static string yn_positive_enrolled_on_art = string.Empty;
        public static string yn_positive_enrolled_on_art_out_come = string.Empty;
        public static string yn_positive_enrolled_on_art_action = string.Empty;
        public static string yn_positive_enrolled_on_art_followup_date = string.Empty;
        public static string yn_positive_supressing = string.Empty;
        public static string yn_positive_supressing_action = string.Empty;
        public static string yn_positive_supressing_out_come = string.Empty;
        public static string yn_positive_supressing_followup_date = string.Empty;
        public static string yn_positive_adhering = string.Empty;
        public static string yn_positive_adhering_action = string.Empty;
        public static string yn_positive_adhering_out_come = string.Empty;
        public static string yn_positive_adhering_followup_date = string.Empty;
        public static string yn_adolescent_hiv_prevention = string.Empty;
        public static string yn_adolescent_hiv_prevention_action = string.Empty;
        public static string yn_adolescent_hiv_prevention_out_come = string.Empty;
        public static string yn_adolescent_hiv_prevention_followup_date = string.Empty;
        public static string yn_child_undernourished = string.Empty;
        public static string yn_child_undernourished_action = string.Empty;
        public static string yn_child_undernourished_out_come = string.Empty;
        public static string yn_child_undernourished_followup_date = string.Empty;
        public static string other_health_issues = string.Empty;
        public static string other_health_issues_action = string.Empty;
        public static string other_health_issues_out_come = string.Empty;
        public static string other_health_issues_action_followup_date = string.Empty;
        public static string yn_no_violence = string.Empty;
        public static string yn_no_violence_action = string.Empty;
        public static string yn_no_violence_out_come = string.Empty;
        public static string yn_no_violence_action_followup_date = string.Empty;
        public static string yn_stable_care_giver = string.Empty;
        public static string yn_stable_care_giver_action = string.Empty;
        public static string yn_stable_care_giver_followup_date = string.Empty;
        public static string yn_stable_care_giver_out_come = string.Empty;
        public static string other_safe_issues = string.Empty;
        public static string other_safe_issues_action = string.Empty;
        public static string other_safe_issues_followup_date = string.Empty;
        public static string other_safe_issues_out_come = string.Empty;
        public static string yn_stable_access_money = string.Empty;
        public static string yn_stable_access_money_action = string.Empty;
        public static string yn_stable_access_money_followup_date = string.Empty;
        public static string yn_stable_access_money_out_come = string.Empty;
        public static string yn_stable_income_source = string.Empty;
        public static string yn_stable_income_source_action = string.Empty;
        public static string yn_stable_income_source_followup_date = string.Empty;
        public static string yn_stable_income_source_out_come = string.Empty;
        public static string other_hes_issues = string.Empty;
        public static string other_hes_issues_action = string.Empty;
        public static string other_hes_issues_followup_date = string.Empty;
        public static string other_hes_issues_out_come = string.Empty;
        public static string yn_ovc_regularly_attend_school = string.Empty;
        public static string yn_ovc_regularly_attend_school_action = string.Empty;
        public static string yn_ovc_regularly_attend_school_followup_date = string.Empty;
        public static string yn_ovc_regularly_attend_school_out_come = string.Empty;
        public static string yn_attained_tech_skill = string.Empty;
        public static string yn_attained_tech_skill_action_plan = string.Empty;
        public static string yn_attained_tech_skill_followup_date = string.Empty;
        public static string yn_attained_tech_skill_out_come = string.Empty;
        public static string other_edu_issues = string.Empty;
        public static string other_edu_issues_action = string.Empty;
        public static string other_edu_issues_followup_date = string.Empty;
        public static string other_edu_issues_out_come = string.Empty;
        public static string hip_out_come_date = string.Empty;
        public static string sw_supervisor_name = string.Empty;
        public static string sw_supervisor_comment = string.Empty;
        #endregion NewHip

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
            string SQL = "SELECT S.swk_id,UPPER(S.swk_first_name + ' ' + S.swk_last_name) AS swk_name FROM swm_social_worker S " +
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



        #region NewHip
        public static void save() 
        {
            string strSQL = string.Empty;

            #region Insert
            strSQL = @"INSERT INTO [dbo].[hh_household_improvement_plan_v2]
                        ([hip_id] ,[hh_code],[hh_id] ,[initial_hip_date],[visit_date] ,[qm_id],[ov_below_seventeen_yrs_male],[ov_below_seventeen_yrs_female],[ov_above_eighteen_yrs_male]
                        ,[ov_above_eighteen_yrs_female] ,[hip_reason],[yn_knows_status_of_children],[yn_knows_status_of_children_action],[yn_knows_status_of_children_out_come] ,[yn_knows_status_of_children_followup_date]
                        ,[yn_positive_enrolled_on_art],[yn_positive_enrolled_on_art_out_come] ,[yn_positive_enrolled_on_art_action],[yn_positive_enrolled_on_art_followup_date] ,[yn_positive_supressing],[yn_positive_supressing_action]
                        ,[yn_positive_supressing_out_come] ,[yn_positive_supressing_followup_date] ,[yn_positive_adhering] ,[yn_positive_adhering_action],[yn_positive_adhering_out_come],[yn_positive_adhering_followup_date]
                        ,[yn_adolescent_hiv_prevention] ,[yn_adolescent_hiv_prevention_action] ,[yn_adolescent_hiv_prevention_out_come],[yn_adolescent_hiv_prevention_followup_date],[yn_child_undernourished] ,[yn_child_undernourished_action]
                        ,[yn_child_undernourished_out_come] ,[yn_child_undernourished_followup_date],[other_health_issues],[other_health_issues_action],[other_health_issues_out_come] ,[other_health_issues_action_followup_date],[yn_no_violence]
                        ,[yn_no_violence_action] ,[yn_no_violence_out_come] ,[yn_no_violence_action_followup_date] ,[yn_stable_care_giver],[yn_stable_care_giver_action] ,[yn_stable_care_giver_followup_date] ,[yn_stable_care_giver_out_come]
                        ,[other_safe_issues] ,[other_safe_issues_action] ,[other_safe_issues_followup_date],[other_safe_issues_out_come] ,[yn_stable_access_money] ,[yn_stable_access_money_action],[yn_stable_access_money_followup_date]
                        ,[yn_stable_access_money_out_come],[yn_stable_income_source] ,[yn_stable_income_source_action] ,[yn_stable_income_source_followup_date] ,[yn_stable_income_source_out_come],[other_hes_issues] ,[other_hes_issues_action]
                        ,[other_hes_issues_followup_date] ,[other_hes_issues_out_come],[yn_ovc_regularly_attend_school] ,[yn_ovc_regularly_attend_school_action],[yn_ovc_regularly_attend_school_followup_date] ,[yn_ovc_regularly_attend_school_out_come]
                        ,[yn_attained_tech_skill] ,[yn_attained_tech_skill_action_plan],[yn_attained_tech_skill_followup_date] ,[yn_attained_tech_skill_out_come],[other_edu_issues],[other_edu_issues_action] ,[other_edu_issues_followup_date]
                        ,[other_edu_issues_out_come] ,[hip_out_come_date] ,[sw_id],[sw_comment] ,[sw_supervisor_name] ,[sw_supervisor_comment] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create],[usr_date_update] ,[ofc_id] ,[district_id],
                        yn_safe_birth_certificates,yn_safe_birth_certificates_action,yn_safe_birth_certificates_followup_date,yn_safe_birth_certificates_out_come)
                    VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}','{6}','{7}','{8}','{9}','{10}' ,'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'
                        ,'{19}' ,'{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}'
                        ,'{38}','{39}','{40}','{41}' ,'{42}','{43}' ,'{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}' ,'{52}','{53}','{54}','{55}','{56}'
                        ,'{57}' ,'{58}' ,'{59}','{60}','{61}' ,'{62}' ,'{63}' ,'{64}' ,'{65}' ,'{66}' ,'{67}','{68}','{69}','{70}' ,'{71}','{72}' ,'{73}' ,'{74}'
                        ,'{75}' ,'{76}'  ,'{77}' ,'{78}' ,'{79}','{80}','{81}' ,'{82}' ,'{83}','{84}','{85}','{86}','{87}','{88}','{89}')";

            strSQL = string.Format(strSQL, hip_id, hh_code, hh_id, initial_hip_date, visit_date, qm_id, ov_below_seventeen_yrs_male, ov_below_seventeen_yrs_female, ov_above_eighteen_yrs_male
                    , ov_above_eighteen_yrs_female, hip_reason, yn_knows_status_of_children, utilFormatting.StringForSQL(yn_knows_status_of_children_action), utilFormatting.StringForSQL(yn_knows_status_of_children_out_come), yn_knows_status_of_children_followup_date
                    , yn_positive_enrolled_on_art, utilFormatting.StringForSQL(yn_positive_enrolled_on_art_out_come), utilFormatting.StringForSQL(yn_positive_enrolled_on_art_action), yn_positive_enrolled_on_art_followup_date, yn_positive_supressing, utilFormatting.StringForSQL(yn_positive_supressing_action)
                    , utilFormatting.StringForSQL(yn_positive_supressing_out_come), yn_positive_supressing_followup_date, yn_positive_adhering, utilFormatting.StringForSQL(yn_positive_adhering_action), utilFormatting.StringForSQL(yn_positive_adhering_out_come), yn_positive_adhering_followup_date
                    , yn_adolescent_hiv_prevention, utilFormatting.StringForSQL(yn_adolescent_hiv_prevention_action), utilFormatting.StringForSQL(yn_adolescent_hiv_prevention_out_come), yn_adolescent_hiv_prevention_followup_date, yn_child_undernourished, utilFormatting.StringForSQL(yn_child_undernourished_action)
                    , utilFormatting.StringForSQL(yn_child_undernourished_out_come), yn_child_undernourished_followup_date, utilFormatting.StringForSQL(other_health_issues), utilFormatting.StringForSQL(other_health_issues_action), utilFormatting.StringForSQL(other_health_issues_out_come), other_health_issues_action_followup_date, yn_no_violence
                    , utilFormatting.StringForSQL(yn_no_violence_action), utilFormatting.StringForSQL(yn_no_violence_out_come), yn_no_violence_action_followup_date, yn_stable_care_giver, utilFormatting.StringForSQL(yn_stable_care_giver_action), yn_stable_care_giver_followup_date, utilFormatting.StringForSQL(yn_stable_care_giver_out_come)
                    , utilFormatting.StringForSQL(other_safe_issues), utilFormatting.StringForSQL(other_safe_issues_action), other_safe_issues_followup_date, utilFormatting.StringForSQL(other_safe_issues_out_come), yn_stable_access_money, utilFormatting.StringForSQL(yn_stable_access_money_action), yn_stable_access_money_followup_date
                    , utilFormatting.StringForSQL(yn_stable_access_money_out_come), yn_stable_income_source, utilFormatting.StringForSQL(yn_stable_income_source_action), yn_stable_income_source_followup_date, utilFormatting.StringForSQL(yn_stable_income_source_out_come), utilFormatting.StringForSQL(other_hes_issues), utilFormatting.StringForSQL(other_hes_issues_action)
                    , other_hes_issues_followup_date, utilFormatting.StringForSQL(other_hes_issues_out_come), yn_ovc_regularly_attend_school, utilFormatting.StringForSQL(yn_ovc_regularly_attend_school_action), yn_ovc_regularly_attend_school_followup_date, utilFormatting.StringForSQL(yn_ovc_regularly_attend_school_out_come)
                    , yn_attained_tech_skill, utilFormatting.StringForSQL(yn_attained_tech_skill_action_plan), yn_attained_tech_skill_followup_date, utilFormatting.StringForSQL(yn_attained_tech_skill_out_come), utilFormatting.StringForSQL(other_edu_issues), utilFormatting.StringForSQL(other_edu_issues_action), other_edu_issues_followup_date
                    , utilFormatting.StringForSQL(other_edu_issues_out_come), hip_out_come_date, sw_id, utilFormatting.StringForSQL(sw_comment), sw_supervisor_name, utilFormatting.StringForSQL(sw_supervisor_comment), usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id,
                    yn_safe_birth_certificates, yn_safe_birth_certificates_action, yn_safe_birth_certificates_followup_date, yn_safe_birth_certificates_out_come);
            #endregion Insert

            try
            {
               
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static void update()
        {
            string strSQL = string.Empty;

            #region Update
            strSQL = @"UPDATE [dbo].[hh_household_improvement_plan_v2]
                   SET [initial_hip_date] = '{1}'
                      ,[visit_date] = '{2}'
                      ,[qm_id] = '{3}'
                      ,[ov_below_seventeen_yrs_male] = '{4}'
                      ,[ov_below_seventeen_yrs_female] = '{5}'
                      ,[ov_above_eighteen_yrs_male] = '{6}'
                      ,[ov_above_eighteen_yrs_female] = '{7}'
                      ,[hip_reason] = '{8}'
                      ,[yn_knows_status_of_children] = '{9}'
                      ,[yn_knows_status_of_children_action] = '{10}'
                      ,[yn_knows_status_of_children_out_come] = '{11}'
                      ,[yn_knows_status_of_children_followup_date] = '{12}'
                      ,[yn_positive_enrolled_on_art] = '{13}'
                      ,[yn_positive_enrolled_on_art_out_come] = '{14}'
                      ,[yn_positive_enrolled_on_art_action] = '{15}'
                      ,[yn_positive_enrolled_on_art_followup_date] = '{16}'
                      ,[yn_positive_supressing] = '{17}'
                      ,[yn_positive_supressing_action] = '{18}'
                      ,[yn_positive_supressing_out_come] = '{19}'
                      ,[yn_positive_supressing_followup_date] = '{20}'
                      ,[yn_positive_adhering] = '{21}'
                      ,[yn_positive_adhering_action] = '{22}'
                      ,[yn_positive_adhering_out_come] = '{23}'
                      ,[yn_positive_adhering_followup_date] = '{24}'
                      ,[yn_adolescent_hiv_prevention] = '{25}'
                      ,[yn_adolescent_hiv_prevention_action] = '{26}'
                      ,[yn_adolescent_hiv_prevention_out_come] = '{27}'
                      ,[yn_adolescent_hiv_prevention_followup_date] = '{28}'
                      ,[yn_child_undernourished] = '{29}'
                      ,[yn_child_undernourished_action] = '{30}'
                      ,[yn_child_undernourished_out_come] = '{31}'
                      ,[yn_child_undernourished_followup_date] = '{32}'
                      ,[other_health_issues] = '{33}'
                      ,[other_health_issues_action] = '{34}'
                      ,[other_health_issues_out_come] = '{35}'
                      ,[other_health_issues_action_followup_date] = '{36}'
                      ,[yn_no_violence] = '{37}'
                      ,[yn_no_violence_action] = '{38}'
                      ,[yn_no_violence_out_come] = '{39}'
                      ,[yn_no_violence_action_followup_date] = '{40}'
                      ,[yn_stable_care_giver] = '{41}'
                      ,[yn_stable_care_giver_action] = '{42}'
                      ,[yn_stable_care_giver_followup_date] = '{43}'
                      ,[yn_stable_care_giver_out_come] = '{44}'
                      ,[other_safe_issues] = '{45}'
                      ,[other_safe_issues_action] = '{46}'
                      ,[other_safe_issues_followup_date] = '{47}'
                      ,[other_safe_issues_out_come] = '{48}'
                      ,[yn_stable_access_money] = '{49}'
                      ,[yn_stable_access_money_action] = '{50}'
                      ,[yn_stable_access_money_followup_date] = '{51}'
                      ,[yn_stable_access_money_out_come] = '{52}'
                      ,[yn_stable_income_source] = '{53}'
                      ,[yn_stable_income_source_action] = '{54}'
                      ,[yn_stable_income_source_followup_date] = '{55}'
                      ,[yn_stable_income_source_out_come] = '{56}'
                      ,[other_hes_issues] = '{57}'
                      ,[other_hes_issues_action] = '{58}'
                      ,[other_hes_issues_followup_date] = '{59}'
                      ,[other_hes_issues_out_come] = '{60}'
                      ,[yn_ovc_regularly_attend_school] = '{61}'
                      ,[yn_ovc_regularly_attend_school_action] = '{62}'
                      ,[yn_ovc_regularly_attend_school_followup_date] = '{63}'
                      ,[yn_ovc_regularly_attend_school_out_come] = '{64}'
                      ,[yn_attained_tech_skill] = '{65}'
                      ,[yn_attained_tech_skill_action_plan] = '{66}'
                      ,[yn_attained_tech_skill_followup_date] = '{67}'
                      ,[yn_attained_tech_skill_out_come] = '{68}'
                      ,[other_edu_issues] = '{69}'
                      ,[other_edu_issues_action] = '{70}'
                      ,[other_edu_issues_followup_date] = '{71}'
                      ,[other_edu_issues_out_come] = '{72}'
                      ,[hip_out_come_date] = '{73}'
                      ,[sw_id] = '{74}'
                      ,[sw_comment] = '{75}'
                      ,[sw_supervisor_name] = '{76}'
                      ,[sw_supervisor_comment] = '{77}'
                      ,[usr_id_create] = '{78}'
                      ,[usr_id_update] = '{79}'
                      ,[usr_date_create] = '{80}'
                      ,[usr_date_update] = '{81}'
                      ,[ofc_id] ='{82}'
                      ,[district_id] = '{83}'
                    ,[yn_safe_birth_certificates] = '{84}'
                    ,[yn_safe_birth_certificates_action] = '{85}'
                    ,[yn_safe_birth_certificates_followup_date] = '{86}'
                    ,[yn_safe_birth_certificates_out_come] = '{87}'
                 WHERE [hip_id] = '{0}'";

            strSQL = string.Format(strSQL,hip_id, initial_hip_date, visit_date, qm_id, ov_below_seventeen_yrs_male, ov_below_seventeen_yrs_female, ov_above_eighteen_yrs_male
                    , ov_above_eighteen_yrs_female, hip_reason, yn_knows_status_of_children, utilFormatting.StringForSQL(yn_knows_status_of_children_action), utilFormatting.StringForSQL(yn_knows_status_of_children_out_come), yn_knows_status_of_children_followup_date
                    , yn_positive_enrolled_on_art, utilFormatting.StringForSQL(yn_positive_enrolled_on_art_out_come), utilFormatting.StringForSQL(yn_positive_enrolled_on_art_action), yn_positive_enrolled_on_art_followup_date, yn_positive_supressing, utilFormatting.StringForSQL(yn_positive_supressing_action)
                    , utilFormatting.StringForSQL(yn_positive_supressing_out_come), yn_positive_supressing_followup_date, yn_positive_adhering, utilFormatting.StringForSQL(yn_positive_adhering_action), utilFormatting.StringForSQL(yn_positive_adhering_out_come), yn_positive_adhering_followup_date
                    , yn_adolescent_hiv_prevention, utilFormatting.StringForSQL(yn_adolescent_hiv_prevention_action), utilFormatting.StringForSQL(yn_adolescent_hiv_prevention_out_come), yn_adolescent_hiv_prevention_followup_date, yn_child_undernourished, utilFormatting.StringForSQL(yn_child_undernourished_action)
                    , utilFormatting.StringForSQL(yn_child_undernourished_out_come), yn_child_undernourished_followup_date, utilFormatting.StringForSQL(other_health_issues), utilFormatting.StringForSQL(other_health_issues_action), utilFormatting.StringForSQL(other_health_issues_out_come), other_health_issues_action_followup_date, yn_no_violence
                    , utilFormatting.StringForSQL(yn_no_violence_action), utilFormatting.StringForSQL(yn_no_violence_out_come), yn_no_violence_action_followup_date, yn_stable_care_giver, utilFormatting.StringForSQL(yn_stable_care_giver_action), yn_stable_care_giver_followup_date, utilFormatting.StringForSQL(yn_stable_care_giver_out_come)
                    , utilFormatting.StringForSQL(other_safe_issues), utilFormatting.StringForSQL(other_safe_issues_action), other_safe_issues_followup_date, utilFormatting.StringForSQL(other_safe_issues_out_come), yn_stable_access_money, utilFormatting.StringForSQL(yn_stable_access_money_action), yn_stable_access_money_followup_date
                    , utilFormatting.StringForSQL(yn_stable_access_money_out_come), yn_stable_income_source, utilFormatting.StringForSQL(yn_stable_income_source_action), yn_stable_income_source_followup_date, utilFormatting.StringForSQL(yn_stable_income_source_out_come), utilFormatting.StringForSQL(other_hes_issues), utilFormatting.StringForSQL(other_hes_issues_action)
                    , other_hes_issues_followup_date, utilFormatting.StringForSQL(other_hes_issues_out_come), yn_ovc_regularly_attend_school, utilFormatting.StringForSQL(yn_ovc_regularly_attend_school_action), yn_ovc_regularly_attend_school_followup_date, utilFormatting.StringForSQL(yn_ovc_regularly_attend_school_out_come)
                    , yn_attained_tech_skill, utilFormatting.StringForSQL(yn_attained_tech_skill_action_plan), yn_attained_tech_skill_followup_date, utilFormatting.StringForSQL(yn_attained_tech_skill_out_come), utilFormatting.StringForSQL(other_edu_issues), utilFormatting.StringForSQL(other_edu_issues_action), other_edu_issues_followup_date
                    , utilFormatting.StringForSQL(other_edu_issues_out_come), hip_out_come_date, sw_id, utilFormatting.StringForSQL(sw_comment), sw_supervisor_name, utilFormatting.StringForSQL(sw_supervisor_comment), usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id,
                    yn_safe_birth_certificates, yn_safe_birth_certificates_action, yn_safe_birth_certificates_followup_date, yn_safe_birth_certificates_out_come);
            #endregion Update

            try
            {

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadDisplay(string hip_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"SELECT* FROM hh_household_improvement_plan_v2 WHERE hip_id = '{0}'";
            SQL = string.Format(SQL, hip_id);

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

        public static DataTable LoadQuarter()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"  SELECT qy_id,qy_name FROM lst_quarter_year";
            SQL = string.Format(SQL, hip_id);

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
        #endregion NewHip
    }
}
