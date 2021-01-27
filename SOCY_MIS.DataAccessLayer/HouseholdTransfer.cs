using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public static class HouseholdTransfer
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string hh_tr_id = string.Empty;
        public static string hh_id = string.Empty;
        public static string hh_code = string.Empty;
        public static string ip_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string caregiver_hhm_id = string.Empty;
        public static string hhm_female_children_count = string.Empty;
        public static string hhm_male_children_count = string.Empty;
        public static string hhm_female_adult_count = string.Empty;
        public static string hhm_male_adult_count = string.Empty;
        public static string yn_health_child_hiv_screen = string.Empty;
        public static string yn_health_child_hiv_screen_comment = string.Empty;
        public static string yn_health_child_hiv_test_reffered = string.Empty;
        public static string yn_health_child_hiv_test_reffered_comment = string.Empty;
        public static string yn_health_child_known_hiv_status = string.Empty;
        public static string yn_health_child_known_hiv_status_comment = string.Empty;
        public static string yn_health_child_receive_arv = string.Empty;
        public static string yn_health_child_receive_arv_comment = string.Empty;
        public static string yn_health_child_receive_vl_test = string.Empty;
        public static string yn_health_child_receive_vl_test_comment = string.Empty;
        public static string yn_health_child_vl_suppress = string.Empty;
        public static string yn_health_child_vl_suppress_comment = string.Empty;
        public static string yn_mother_attend_hiv_clinic = string.Empty;
        public static string yn_mother_attend_hiv_clinic_comment = string.Empty;
        public static string yn_caregiver_hiv_screen = string.Empty;
        public static string yn_caregiver_hiv_screen_comment = string.Empty;
        public static string yn_caregiver_on_art = string.Empty;
        public static string yn_caregiver_on_art_comment = string.Empty;
        public static string yn_caregiver_receive_vl_test = string.Empty;
        public static string yn_caregiver_receive_vl_test_comment = string.Empty;
        public static string yn_child_undernourished = string.Empty;
        public static string yn_child_undernourished_comment = string.Empty;
        public static string yn_caregiver_attend_parenting_program = string.Empty;
        public static string yn_caregiver_attend_parenting_program_comment = string.Empty;
        public static string yn_adolescent_risk_avoidance_enrolled = string.Empty;
        public static string yn_adolescent_risk_avoidance_enrolled_comment = string.Empty;
        public static string yn_caregiver_in_silc = string.Empty;
        public static string yn_caregiver_in_silc_comment = string.Empty;
        public static string yn_IGA_support = string.Empty;
        public static string yn_IGA_support_comment = string.Empty;
        public static string yn_financial_literacy = string.Empty;
        public static string yn_financial_literacy_comment = string.Empty;
        public static string yn_apprenticeship = string.Empty;
        public static string yn_apprenticeship_comment = string.Empty;
        public static string yn_startup_toolkit = string.Empty;
        public static string yn_startup_toolkit_comment = string.Empty;
        public static string yn_hh_cater_basic_need = string.Empty;
        public static string yn_hh_cater_basic_need_comment = string.Empty;
        public static string yn_violence = string.Empty;
        public static string yn_violence_comment = string.Empty;
        public static string yn_refferal_child_protection = string.Empty;
        public static string yn_refferal_child_protection_comment = string.Empty;
        public static string yn_case_ongoing = string.Empty;
        public static string yn_case_ongoing_comment = string.Empty;
        public static string yn_birth_certificate = string.Empty;
        public static string yn_birth_certificate_comment = string.Empty;
        public static string yn_sinovuyo_training = string.Empty;
        public static string yn_sinovuyo_training_comment = string.Empty;
        public static string yn_vhild_hiv_violence_prevention_curriculum = string.Empty;
        public static string yn_vhild_hiv_violence_prevention_curriculum_comment = string.Empty;
        public static string yn_edu_enrolled = string.Empty;
        public static string yn_edu_enrolled_comment = string.Empty;
        public static string yn_edu_attending_regularly = string.Empty;
        public static string yn_edu_attending_regularly_comment = string.Empty;
        public static string yn_adolesent_du_enrolled_with_edu_subsidy = string.Empty;
        public static string yn_adolesent_du_enrolled_with_edu_subsidy_comment = string.Empty;
        public static string yn_child_edu_nira_registered = string.Empty;
        public static string yn_child_edu_nira_registered_comment = string.Empty;
        public static string yn_18_20yrs_in_school = string.Empty;
        public static string yn_18_20yrs_in_school_comment = string.Empty;
        public static string swk_id = string.Empty;
        public static DateTime date = DateTime.Now;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string issue_id = string.Empty;
        public static string issue_desc = string.Empty;
        public static string issue_action_desc = string.Empty;
        public static string issue_followup_info = string.Empty;
        #endregion


        #region save
        public static void save(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[hh_household_transfer] VALUES
            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}',
            '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}', '{42}', '{43}', '{44}', '{45}', '{46}',
            '{47}', '{48}', '{49}', '{50}', '{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', '{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}',
            '{71}', '{72}', '{73}', '{74}', '{75}', '{76}', '{77}', '{78}')";

            strSQL = string.Format(strSQL, hh_tr_id, hh_id, hh_code, ip_id, cso_id, wrd_id, caregiver_hhm_id, hhm_female_children_count, hhm_male_children_count, hhm_female_adult_count, hhm_male_adult_count
           , yn_health_child_hiv_screen, yn_health_child_hiv_screen_comment, yn_health_child_hiv_test_reffered, yn_health_child_hiv_test_reffered_comment, yn_health_child_known_hiv_status
           , yn_health_child_known_hiv_status_comment, yn_health_child_receive_arv, yn_health_child_receive_arv_comment, yn_health_child_receive_vl_test, yn_health_child_receive_vl_test_comment
           , yn_health_child_vl_suppress, yn_health_child_vl_suppress_comment, yn_mother_attend_hiv_clinic, yn_mother_attend_hiv_clinic_comment, yn_caregiver_hiv_screen, yn_caregiver_hiv_screen_comment
           , yn_caregiver_on_art, yn_caregiver_on_art_comment, yn_caregiver_receive_vl_test, yn_caregiver_receive_vl_test_comment, yn_child_undernourished, yn_child_undernourished_comment, yn_caregiver_attend_parenting_program
           , yn_caregiver_attend_parenting_program_comment, yn_adolescent_risk_avoidance_enrolled, yn_adolescent_risk_avoidance_enrolled_comment, yn_caregiver_in_silc, yn_caregiver_in_silc_comment, yn_IGA_support
           , yn_IGA_support_comment, yn_financial_literacy, yn_financial_literacy_comment, yn_apprenticeship, yn_apprenticeship_comment, yn_startup_toolkit, yn_startup_toolkit_comment, yn_hh_cater_basic_need
           , yn_hh_cater_basic_need_comment, yn_violence, yn_violence_comment, yn_refferal_child_protection, yn_refferal_child_protection_comment, yn_case_ongoing, yn_case_ongoing_comment, yn_birth_certificate
           , yn_birth_certificate_comment, yn_sinovuyo_training, yn_sinovuyo_training_comment, yn_vhild_hiv_violence_prevention_curriculum, yn_vhild_hiv_violence_prevention_curriculum_comment, yn_edu_enrolled
           , yn_edu_enrolled_comment, yn_edu_attending_regularly, yn_edu_attending_regularly_comment, yn_adolesent_du_enrolled_with_edu_subsidy, yn_adolesent_du_enrolled_with_edu_subsidy_comment, yn_child_edu_nira_registered
           , yn_child_edu_nira_registered_comment, yn_18_20yrs_in_school, yn_18_20yrs_in_school_comment, swk_id, date, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
                strSQL = @"UPDATE [dbo].[hh_household_transfer]
                SET [hh_id] = '{1}'
                ,[hh_code] ='{2}'
                ,[ip_id] = '{3}'
                ,[cso_id] = '{4}'
                ,[wrd_id] = '{5}'
                ,[caregiver_hhm_id] = '{6}'
                ,[hhm_female_children_count] = '{7}'
                ,[hhm_male_children_count] = '{8}'
                ,[hhm_female_adult_count] = '{9}'
                ,[hhm_male_adult_count] = '{10}'
                ,[yn_health_child_hiv_screen] = '{11}'
                ,[yn_health_child_hiv_screen_comment] = '{12}'
                ,[yn_health_child_hiv_test_reffered] = '{13}'
                ,[yn_health_child_hiv_test_reffered_comment] = '{14}'
                ,[yn_health_child_known_hiv_status] = '{15}'
                ,[yn_health_child_known_hiv_status_comment] = '{16}'
                ,[yn_health_child_receive_arv] = '{17}'
                ,[yn_health_child_receive_arv_comment] = '{18}'
                ,[yn_health_child_receive_vl_test] = '{19}'
                ,[yn_health_child_receive_vl_test_comment] = '{20}'
                ,[yn_health_child_vl_suppress] = '{21}'
                ,[yn_health_child_vl_suppress_comment] = '{22}'
                ,[yn_mother_attend_hiv_clinic] = '{23}'
                ,[yn_mother_attend_hiv_clinic_comment] = '{24}'
                ,[yn_caregiver_hiv_screen] = '{25}'
                ,[yn_caregiver_hiv_screen_comment] = '{26}'
                ,[yn_caregiver_on_art] = '{27}'
                ,[yn_caregiver_on_art_comment] = '{28}'
                ,[yn_caregiver_receive_vl_test] = '{29}'
                ,[yn_caregiver_receive_vl_test_comment] = '{30}'
                ,[yn_child_undernourished] = '{31}'
                ,[yn_child_undernourished_comment] = '{32}'
                ,[yn_caregiver_attend_parenting_program] = '{33}'
                ,[yn_caregiver_attend_parenting_program_comment] = '{34}'
                ,[yn_adolescent_risk_avoidance_enrolled] = '{35}'
                ,[yn_adolescent_risk_avoidance_enrolled_comment] = '{36}'
                ,[yn_caregiver_in_silc] = '{37}'
                ,[yn_caregiver_in_silc_comment] = '{38}'
                ,[yn_IGA_support] = '{39}'
                ,[yn_IGA_support_comment] = '{40}'
                ,[yn_financial_literacy] = '{41}'
                ,[yn_financial_literacy_comment] = '{42}'
                ,[yn_apprenticeship] = '{43}'
                ,[yn_apprenticeship_comment] = '{44}'
                ,[yn_startup_toolkit] = '{45}'
                ,[yn_startup_toolkit_comment] = '{46}'
                ,[yn_hh_cater_basic_need] = '{47}'
                ,[yn_hh_cater_basic_need_comment] = '{48}'
                ,[yn_violence] = '{49}'
                ,[yn_violence_comment] = '{50}'
                ,[yn_refferal_child_protection] = '{51}'
                ,[yn_refferal_child_protection_comment] = '{52}'
                ,[yn_case_ongoing] = '{53}'
                ,[yn_case_ongoing_comment] = '{54}'
                ,[yn_birth_certificate] = '{55}'
                ,[yn_birth_certificate_comment] ='{56}'
                ,[yn_sinovuyo_training] = '{57}'
                ,[yn_sinovuyo_training_comment] = '{58}'
                ,[yn_vhild_hiv_violence_prevention_curriculum] = '{59}'
                ,[yn_vhild_hiv_violence_prevention_curriculum_comment] = '{60}'
                ,[yn_edu_enrolled] = '{61}'
                ,[yn_edu_enrolled_comment] = '{62}'
                ,[yn_edu_attending_regularly] = '{63}'
                ,[yn_edu_attending_regularly_comment] = '{64}'
                ,[yn_adolesent_du_enrolled_with_edu_subsidy] = '{65}'
                ,[yn_adolesent_du_enrolled_with_edu_subsidy_comment] = '{66}'
                ,[yn_child_edu_nira_registered] = '{67}'
                ,[yn_child_edu_nira_registered_comment] = '{68}'
                ,[yn_18_20yrs_in_school] = '{69}'
                ,[yn_18_20yrs_in_school_comment] = '{70}'
                ,[swk_id] = '{71}'
                ,[date] = '{72}'
                ,[usr_id_update] = '{73}'
                ,[usr_date_update] = '{74}'
                WHERE hh_tr_id = '{0}'";

            strSQL = string.Format(strSQL, hh_tr_id, hh_id, hh_code, ip_id, cso_id, wrd_id, caregiver_hhm_id, hhm_female_children_count, hhm_male_children_count, hhm_female_adult_count, hhm_male_adult_count
           , yn_health_child_hiv_screen, yn_health_child_hiv_screen_comment, yn_health_child_hiv_test_reffered, yn_health_child_hiv_test_reffered_comment, yn_health_child_known_hiv_status
           , yn_health_child_known_hiv_status_comment, yn_health_child_receive_arv, yn_health_child_receive_arv_comment, yn_health_child_receive_vl_test, yn_health_child_receive_vl_test_comment
           , yn_health_child_vl_suppress, yn_health_child_vl_suppress_comment, yn_mother_attend_hiv_clinic, yn_mother_attend_hiv_clinic_comment, yn_caregiver_hiv_screen, yn_caregiver_hiv_screen_comment
           , yn_caregiver_on_art, yn_caregiver_on_art_comment, yn_caregiver_receive_vl_test, yn_caregiver_receive_vl_test_comment, yn_child_undernourished, yn_child_undernourished_comment, yn_caregiver_attend_parenting_program
           , yn_caregiver_attend_parenting_program_comment, yn_adolescent_risk_avoidance_enrolled, yn_adolescent_risk_avoidance_enrolled_comment, yn_caregiver_in_silc, yn_caregiver_in_silc_comment, yn_IGA_support
           , yn_IGA_support_comment, yn_financial_literacy, yn_financial_literacy_comment, yn_apprenticeship, yn_apprenticeship_comment, yn_startup_toolkit, yn_startup_toolkit_comment, yn_hh_cater_basic_need
           , yn_hh_cater_basic_need_comment, yn_violence, yn_violence_comment, yn_refferal_child_protection, yn_refferal_child_protection_comment, yn_case_ongoing, yn_case_ongoing_comment, yn_birth_certificate
           , yn_birth_certificate_comment, yn_sinovuyo_training, yn_sinovuyo_training_comment, yn_vhild_hiv_violence_prevention_curriculum, yn_vhild_hiv_violence_prevention_curriculum_comment, yn_edu_enrolled
           , yn_edu_enrolled_comment, yn_edu_attending_regularly, yn_edu_attending_regularly_comment, yn_adolesent_du_enrolled_with_edu_subsidy, yn_adolesent_du_enrolled_with_edu_subsidy_comment, yn_child_edu_nira_registered
           , yn_child_edu_nira_registered_comment, yn_18_20yrs_in_school, yn_18_20yrs_in_school_comment, swk_id, date, usr_id_update, usr_date_update);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void saveHouseholdIssue(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[hh_household_transfer_issue] VALUES
            ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";

            strSQL = string.Format(strSQL, issue_id,hh_tr_id,issue_desc,issue_action_desc,issue_followup_info,usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void updateHouseholdIssue(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[hh_household_transfer_issue]
                       SET [issue_desc] ='{1}'
                          ,[issue_action_desc] = '{2}'
                          ,[issue_followup_info] = '{3}'
                          ,[usr_id_update] = '{4}'
                          ,[usr_date_update] = '{5}'
                     WHERE issue_id = '{0}'";

            strSQL = string.Format(strSQL, issue_id, issue_desc, issue_action_desc, issue_followup_info, usr_id_update, usr_date_update);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }
        #endregion


        public static DataTable LoadHouseholds(string wrd_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT H.hh_id, H.hh_code FROM hh_household H
                                INNER JOIN lst_ward W ON H.wrd_id = W.wrd_sid
                                INNER JOIN lst_sub_county S ON W.sct_id = S.sct_id
                                INNER JOIN lst_district D ON S.dst_id = D.dst_id
                                WHERE W.wrd_id = '{0}'
                                ORDER BY H.hh_code ASC";
                SQL = string.Format(SQL, wrd_id);

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

        public static DataTable Return_household_member_by_age_grp(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"SELECT G.gnd_name,  (YEAR(GETDATE()) -  H.hhm_year_of_birth) AS age,hh.hh_village FROM hh_household_member H 
            LEFT JOIN lst_gender G ON H.gnd_id = G.gnd_id 
            INNER JOIN hh_household hh ON H.hh_id = hh.hh_id
            WHERE H.hhm_year_of_birth <> '*' 
            AND H.hhm_year_of_birth <> '-1' 
            AND H.hh_id = '{0}' ";
            try
            {
                SQL = string.Format(SQL, hh_id);

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

        public static DataTable LoadRecordDetails(string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dt.*,dst.dst_id,sct.sct_id FROM hh_household_transfer dt
                INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id
                INNER JOIN lst_ward W ON hh.wrd_id = W.wrd_id
                INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                WHERE dt.hh_tr_id = '{0}'";

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

        public static DataTable LoadRecordListing(string dst_id, string sct_id, string wrd_id,string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dt.hh_tr_id, prt.prt_name,cso.cso_other, dst.dst_name,sct.sct_name,W.wrd_name,hh.hh_village,hh.hh_code,dt.date FROM hh_household_transfer dt
                INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id
                INNER JOIN lst_ward W ON hh.wrd_id = W.wrd_id
                INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                INNER JOIN lst_partner prt ON dt.ip_id = prt.prt_id
                INNER JOIN lst_cso cso ON dt.cso_id = cso.cso_id
                WHERE (@sct_id = '' OR @sct_id = '-1' OR sct.sct_id =  @sct_id  )
                AND (@dst_id = '' OR @dst_id = '-1' OR dst.dst_id = @dst_id  )
                AND (@wrd_id = '' OR @wrd_id = '-1' OR dt.wrd_id = @wrd_id)
                AND (@hh_code = '' OR hh.hh_code LIKE '%' + @hh_code + '%')";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@wrd_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@wrd_id"].Value = wrd_id;

                    cmd.Parameters.Add("@hh_code", SqlDbType.NVarChar, 50);
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


        public static DataTable LoadHouseholdIssueListing(string hh_hh_tr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT [issue_id] ,[issue_desc] ,[issue_action_desc] ,[issue_followup_info] FROM hh_household_transfer_issue
                        WHERE [hh_tr_id] = '{0}'";
                SQL = string.Format(SQL, hh_hh_tr_id);

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
