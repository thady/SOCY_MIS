using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public static class NoMeansNoWorldWide
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion

        #region Globals
        public static string NMNBoys = "1";
        public static string NMNGirls = "2";
        public static string NMNToolType = string.Empty;
        #endregion Globals

        #region Variables_Boys
        public static string record_id = string.Empty;
        public static string nmn_id = string.Empty;
        public static string nmn_id_pre = string.Empty;
        public static string yn_direct_ben = string.Empty;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hhm_code = string.Empty;
        public static DateTime date = DateTime.Now;
        public static string pre_post = string.Empty;
        public static string grp_name = string.Empty;
        public static string instructor_name = string.Empty;
        public static string age = string.Empty;
        public static string lead_with_heart = string.Empty;
        public static string desc_life_worth_living = string.Empty;
        public static string cycle_of_force = string.Empty;
        public static string tell_at_stake = string.Empty;
        public static string men_not_emortion = string.Empty;
        public static string report_rape = string.Empty;
        public static string feel_courageous = string.Empty;
        public static string intervene_conflit = string.Empty;
        public static string rape_sex_consent = string.Empty;
        public static string boys_ready_want_sex = string.Empty;
        public static string men_women_equal = string.Empty;
        public static string strength_source = string.Empty;
        public static string adolescent_desc = string.Empty;
        public static string moment_truth = string.Empty;
        public static string consent_desc = string.Empty;
        public static string violence_desc = string.Empty;
        public static string boy_attack_response = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion Variables_Boys

        #region Variables_Girls
        public static string cant_escape_attacker = string.Empty;
        public static string can_defend_myself_act_crazy = string.Empty;
        public static string intimidation_not_assault = string.Empty;
        public static string can_fight_dirty = string.Empty;
        public static string report_rape_to_adult = string.Empty;
        public static string prepared_to_deffend_myself = string.Empty;
        public static string worth_defending = string.Empty;
        public static string can_strike_first = string.Empty;
        public static string know_assertive = string.Empty;
        public static string voice_weapon_to_assault = string.Empty;
        public static string use_self_defence_skills = string.Empty;
        public static string main_safety_goal = string.Empty;
        public static string girl_attack_response = string.Empty;
        public static string attack_girl_fault_desc = string.Empty;
        public static string self_defence_desc = string.Empty;
        public static string girl_response_if_eyes_covered = string.Empty;
        #endregion Variables_Girls

        #region Attendance
        public static string roster_id = string.Empty;
        public static string int_type = string.Empty;
        public static DateTime start_date = DateTime.Today;
        public static DateTime end_date = DateTime.Today;
        public static string sup_name = string.Empty;
        public static string imp_partner = string.Empty;
        public static string dst_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string venue = string.Empty;
        public static string instructor_names = string.Empty;
        public static string delivery_method = string.Empty;
        public static DateTime class1_tr_date = DateTime.Today;
        public static string class1_tr_hrs = string.Empty;
        public static DateTime class2_tr_date = DateTime.Today;
        public static string class2_tr_hrs = string.Empty;
        public static DateTime class3_tr_date = DateTime.Today;
        public static string class3_tr_hrs = string.Empty;
        public static DateTime class4_tr_date = DateTime.Today;
        public static string class4_tr_hrs = string.Empty;
        public static DateTime class5_tr_date = DateTime.Today;
        public static string class5_tr_hrs = string.Empty;
        public static DateTime class6_tr_date = DateTime.Today;
        public static string class6_tr_hrs = string.Empty;
        public static DateTime class7_tr_date = DateTime.Today;
        public static string class7_tr_hrs = string.Empty;

        public static string roster_member_id = string.Empty;
        //public static string roster_id = string.Empty;
        //public static string yn_direct_ben = string.Empty;
        //public static string hhm_id = string.Empty;
        //public static string nmn_id = string.Empty;
        public static string first_name = string.Empty;
        public static string last_name = string.Empty;
        //public static string age = string.Empty;
        public static string class1_attended = string.Empty;
        public static string class2_attended = string.Empty;
        public static string class3_attended = string.Empty;
        public static string class4_attended = string.Empty;
        public static string class5_attended = string.Empty;
        public static string class6_attended = string.Empty;
        public static string class7_attended = string.Empty;
        public static string graduated = string.Empty;
        #endregion Attendance

        #region Boys
        public static string saveNMNBoys(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"DECLARE @tempTable TABLE (nmn_id Varchar(50)) INSERT INTO [dbo].[ben_NoMeansNo_pre_post_Boys]
           ([record_id],[nmn_id_pre],[yn_direct_ben] ,[hh_id],[hhm_id] ,[hhm_code] ,[date],[pre_post],[grp_name],[instructor_name] ,[age] ,[lead_with_heart] ,[desc_life_worth_living]
           ,[cycle_of_force] ,[tell_at_stake]  ,[men_not_emortion] ,[report_rape] ,[feel_courageous]  ,[intervene_conflit] ,[rape_sex_consent],[boys_ready_want_sex]
           ,[men_women_equal] ,[strength_source] ,[adolescent_desc] ,[moment_truth] ,[consent_desc] ,[violence_desc] ,[boy_attack_response] ,[usr_id_create] ,[usr_id_update]
           ,[usr_date_create] ,[usr_date_update]  ,[ofc_id],[district_id]) OUTPUT INSERTED.nmn_id INTO @tempTable
             VALUES('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}','{5}','{6}','{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}' ,'{12}'  ,'{13}' ,'{14}' ,'{15}'  ,'{16}' ,'{17}','{18}'
                   ,'{19}' ,'{20}' ,'{21}' ,'{22}' ,'{23}' ,'{24}' ,'{25}' ,'{26}' ,'{27}' ,'{28}' ,'{29}'  ,'{30}','{31}','{32}','{33}')
            SELECT nmn_id FROM @tempTable";

            strSQL = string.Format(strSQL, record_id,nmn_id_pre, yn_direct_ben,hh_id, hhm_id, hhm_code, date.ToString("dd MMM yyyy HH:mm:ss"), pre_post, grp_name, instructor_name, age, lead_with_heart, desc_life_worth_living
           , cycle_of_force, tell_at_stake, men_not_emortion, report_rape, feel_courageous, intervene_conflit, rape_sex_consent, boys_ready_want_sex
           , men_women_equal, strength_source, adolescent_desc, moment_truth, consent_desc, violence_desc, boy_attack_response, usr_id_create, usr_id_update
           , usr_date_create, usr_date_update, ofc_id, district_id);

            string insertedNMNID =  dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return insertedNMNID;
        }

        public static void updateNMNBoys(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_NoMeansNo_pre_post_Boys]
                       SET [nmn_id] = '{1}'
                          ,[hhm_id] = '{2}'
                          ,[hhm_code] = '{3}'
                          ,[date] = '{4}'
                          ,[pre_post] = '{5}'
                          ,[grp_name] = '{6}'
                          ,[instructor_name] = '{7}'
                          ,[age] = '{8}'
                          ,[lead_with_heart] = '{9}'
                          ,[desc_life_worth_living] = '{10}'
                          ,[cycle_of_force] = '{11}'
                          ,[tell_at_stake] = '{12}'
                          ,[men_not_emortion] = '{13}'
                          ,[report_rape] = '{14}'
                          ,[feel_courageous] = '{15}'
                          ,[intervene_conflit] = '{16}'
                          ,[rape_sex_consent] = '{17}'
                          ,[boys_ready_want_sex] = '{18}'
                          ,[men_women_equal] = '{19}'
                          ,[strength_source] = '{20}'
                          ,[adolescent_desc] = '{21}'
                          ,[moment_truth] = '{22}'
                          ,[consent_desc] = '{23}'
                          ,[violence_desc] = '{24}'
                          ,[boy_attack_response] = '{25}'
                          ,[usr_id_update] ='{26}'
                          ,[usr_date_update] = '{27}'
                          ,yn_direct_ben = '{28}'
                          ,hh_id = '{29}'
                     WHERE [record_id] = '{0}'";

            strSQL = string.Format(strSQL, record_id, nmn_id, hhm_id, hhm_code, date.ToString("dd MMM yyyy HH:mm:ss"), pre_post, grp_name, instructor_name, age, lead_with_heart, desc_life_worth_living
           , cycle_of_force, tell_at_stake, men_not_emortion, report_rape, feel_courageous, intervene_conflit, rape_sex_consent, boys_ready_want_sex
           , men_women_equal, strength_source, adolescent_desc, moment_truth, consent_desc, violence_desc, boy_attack_response, usr_id_update
           , usr_date_update, yn_direct_ben,hh_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public static DataTable LoadHouseholdList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hh_code,hh_id FROM hh_household ORDER BY hh_code ASC";

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadHouseholdListAttendance(string sct_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hh_code,hh_id FROM hh_household dt
                        INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        WHERE sct.sct_id = '{0}'
                        ORDER BY hh_code ASC";
            strSQL = string.Format(strSQL,sct_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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


        public static DataTable LoadHouseholdMembersBoys(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id FROM hh_household_member WHERE hh_id = '{0}' AND (YEAR(GETDATE()) - hhm_year_of_birth >=10 AND YEAR(GETDATE()) - hhm_year_of_birth <=13) AND gnd_id = 'm26e435b-1478-4978-aad5-58c3677a1f70'";
            strSQL = string.Format(strSQL, hh_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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


        public static string LoadMemberCode(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;
            string hhm_code = string.Empty;

            strSQL = @"SELECT hh_code + '-' + dt.hhm_number AS hhm_code,dt.hhm_first_name,dt.hhm_last_name  FROM hh_household_member dt
                        INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id
                        WHERE dt.hhm_id = '{0}'";

            strSQL = string.Format(strSQL, hhm_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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
                        hhm_code = dtRow["hhm_code"].ToString();
                    }
                    else
                    {
                        hhm_code = string.Empty;
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

            return hhm_code;
        }

        public static DataTable LoadMemberDetails(string hhm_id) 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;
            string hhm_code = string.Empty;

            strSQL = @"SELECT hh_code + '-' + dt.hhm_number AS hhm_code,dt.hhm_first_name,dt.hhm_last_name  FROM hh_household_member dt
                        INNER JOIN hh_household hh ON dt.hh_id = hh.hh_id
                        WHERE dt.hhm_id = '{0}'";

            strSQL = string.Format(strSQL, hhm_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadNMNRecordListBoys()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT record_id, nmn_id,yn_direct_ben,hhm_code,date,pre_post,grp_name,instructor_name,age FROM ben_NoMeansNo_pre_post_Boys";
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable SearchNMNRecordListBoys(string hhm_code,string nmn_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT record_id, nmn_id,yn_direct_ben,hhm_code,date,pre_post,grp_name,instructor_name,age FROM ben_NoMeansNo_pre_post_Boys
                        WHERE (@hhm_code = '' OR hhm_code LIKE '%' + @hhm_code + '%'  )
                        AND ((@nmn_id = '' OR nmn_id LIKE '%' + @nmn_id + '%' )
                        OR (@nmn_id = '' OR nmn_id_pre LIKE '%' + @nmn_id + '%' ))";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@hhm_code", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@hhm_code"].Value = hhm_code;

                    cmd.Parameters.Add("@nmn_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@nmn_id"].Value = nmn_id;

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


        public static DataTable LoadNMNBoysDetails(string record_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT* FROM ben_NoMeansNo_pre_post_Boys WHERE record_id = '{0}'";
            strSQL = string.Format(strSQL, record_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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


        public static string LoadBeneficiaryAge(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;
            string age = string.Empty;

            strSQL = @"SELECT YEAR(GETDATE()) - hhm_year_of_birth AS Age FROM hh_household_member WHERE hhm_id = '{0}'";
            strSQL = string.Format(strSQL, hhm_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    Adapt = new SqlDataAdapter(cmd);
                    Adapt.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        age = Convert.ToInt32(dtRow["Age"]).ToString();
                    }
                    else
                    {
                        age = string.Empty;
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

            return age;
        }


        public static int ValidatePostSurveyBoys(string nmn_id)
        {
            string strSQL = string.Empty;
            int count = 0;

            strSQL = @"SELECT count(*) AS MemberCount FROM ben_NoMeansNo_pre_post_Boys WHERE nmn_id = '{0}' AND pre_post = 'Pre'";
            strSQL = string.Format(strSQL, nmn_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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
        #endregion Boys
        #region Girls

        public static DataTable LoadHouseholdMembersGirls(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id FROM hh_household_member WHERE hh_id = '{0}' AND (YEAR(GETDATE()) - hhm_year_of_birth >=10 AND YEAR(GETDATE()) - hhm_year_of_birth <=17) AND gnd_id = 'f05d3f3c-9aac-4f12-b0cd-1c4ae9294da3'";
            strSQL = string.Format(strSQL, hh_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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
        public static string saveNMNGirls(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"DECLARE @tempTable TABLE (nmn_id Varchar(50)) INSERT INTO [dbo].[ben_NoMeansNo_pre_post_Girls]
                        ([record_id],[nmn_id_pre],[yn_direct_ben],[hh_id],[hhm_id],[hhm_code]  ,[date] ,[pre_post] ,[grp_name],[instructor_name],[age],[cant_escape_attacker]
                        ,[can_defend_myself_act_crazy],[intimidation_not_assault],[can_fight_dirty],[report_rape_to_adult] ,[prepared_to_deffend_myself] ,[worth_defending]
                        ,[can_strike_first] ,[know_assertive] ,[voice_weapon_to_assault] ,[use_self_defence_skills] ,[main_safety_goal] ,[girl_attack_response]  ,[attack_girl_fault_desc]
                        ,[self_defence_desc] ,[girl_response_if_eyes_covered] ,[usr_id_create],[usr_id_update] ,[usr_date_create]  ,[usr_date_update],[ofc_id] ,[district_id]) OUTPUT INSERTED.nmn_id INTO @tempTable
                    VALUES('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}','{5}','{6}','{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}' ,'{12}'  ,'{13}' ,'{14}' ,'{15}'  ,'{16}' ,'{17}','{18}'
                                ,'{19}' ,'{20}' ,'{21}' ,'{22}' ,'{23}' ,'{24}' ,'{25}' ,'{26}' ,'{27}' ,'{28}' ,'{29}'  ,'{30}','{31}','{32}')
                    SELECT nmn_id FROM @tempTable";

            strSQL = string.Format(strSQL, record_id, nmn_id_pre, yn_direct_ben, hh_id, hhm_id, hhm_code, date, pre_post, grp_name, instructor_name, age, cant_escape_attacker
            , can_defend_myself_act_crazy, intimidation_not_assault, can_fight_dirty, report_rape_to_adult, prepared_to_deffend_myself, worth_defending
            , can_strike_first, know_assertive, voice_weapon_to_assault, use_self_defence_skills, main_safety_goal, girl_attack_response, attack_girl_fault_desc
            , self_defence_desc, girl_response_if_eyes_covered, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

           string insertedNMNID =  dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return insertedNMNID;
        }

        public static void updateNMNGirls(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_NoMeansNo_pre_post_Girls]
                       SET [nmn_id] = '{1}'
                          ,[yn_direct_ben] = '{2}'
                          ,[hh_id] = '{3}'
                          ,[hhm_id] = '{4}'
                          ,[hhm_code] = '{5}'
                          ,[date] = '{6}'
                          ,[pre_post] = '{7}'
                          ,[grp_name] = '{8}'
                          ,[instructor_name] = '{9}'
                          ,[age] = '{10}'
                          ,[cant_escape_attacker] = '{11}'
                          ,[can_defend_myself_act_crazy] = '{12}'
                          ,[intimidation_not_assault] = '{13}'
                          ,[can_fight_dirty] = '{14}'
                          ,[report_rape_to_adult] = '{15}'
                          ,[prepared_to_deffend_myself] = '{16}'
                          ,[worth_defending] = '{17}'
                          ,[can_strike_first] = '{18}'
                          ,[know_assertive] = '{19}'
                          ,[voice_weapon_to_assault] = '{20}'
                          ,[use_self_defence_skills] = '{21}'
                          ,[main_safety_goal] = '{22}'
                          ,[girl_attack_response] = '{23}'
                          ,[attack_girl_fault_desc] = '{24}'
                          ,[self_defence_desc] = '{25}'
                          ,[girl_response_if_eyes_covered] = '{26}'
                          ,[usr_id_update] = '{27}'
                          ,[usr_date_update] = '{28}'
                     WHERE  [record_id] = '{0}'";

            strSQL = string.Format(strSQL, record_id, nmn_id, yn_direct_ben, hh_id, hhm_id, hhm_code, date, pre_post, grp_name, instructor_name, age, cant_escape_attacker
            , can_defend_myself_act_crazy, intimidation_not_assault, can_fight_dirty, report_rape_to_adult, prepared_to_deffend_myself, worth_defending
            , can_strike_first, know_assertive, voice_weapon_to_assault, use_self_defence_skills, main_safety_goal, girl_attack_response, attack_girl_fault_desc
            , self_defence_desc, girl_response_if_eyes_covered, usr_id_update,usr_date_update);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public static DataTable LoadNMNRecordListGirls()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT record_id, nmn_id,yn_direct_ben,hhm_code,date,pre_post,grp_name,instructor_name,age FROM ben_NoMeansNo_pre_post_Girls";
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable SearchNMNRecordListGirls(string hhm_code, string nmn_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT record_id, nmn_id,yn_direct_ben,hhm_code,date,pre_post,grp_name,instructor_name,age FROM ben_NoMeansNo_pre_post_Girls
                        WHERE (@hhm_code = '' OR hhm_code LIKE '%' + @hhm_code + '%'  )
                        AND ((@nmn_id = '' OR nmn_id LIKE '%' + @nmn_id + '%' )
                         OR (@nmn_id = '' OR nmn_id_pre LIKE '%' + @nmn_id + '%' ))";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@hhm_code", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@hhm_code"].Value = hhm_code;

                    cmd.Parameters.Add("@nmn_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@nmn_id"].Value = nmn_id;

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


        public static DataTable LoadNMNGirlsDetails(string record_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT* FROM ben_NoMeansNo_pre_post_Girls WHERE record_id = '{0}'";
            strSQL = string.Format(strSQL, record_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static int ValidatePostSurveyGirls(string nmn_id)
        {
            string strSQL = string.Empty;
            int count = 0;

            strSQL = @"SELECT count(*) AS MemberCount FROM ben_NoMeansNo_pre_post_Girls WHERE nmn_id = '{0}' AND pre_post = 'Pre'";
            strSQL = string.Format(strSQL, nmn_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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
        #endregion Girls

        #region Attendance
        public static string saveNMNAttendaceRegister(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"DECLARE @tempTable TABLE (roster_id Varchar(50)) INSERT INTO [dbo].[ben_NoMeansNo_participant_attendance]
           ([roster_id],[int_type] ,[start_date] ,[end_date] ,[sup_name] ,[imp_partner] ,[dst_id] ,[sct_id] ,[wrd_id] ,[venue],[instructor_names],[delivery_method]
           ,[class1_tr_date] ,[class1_tr_hrs] ,[class2_tr_date] ,[class2_tr_hrs] ,[class3_tr_date] ,[class3_tr_hrs] ,[class4_tr_date] ,[class4_tr_hrs] ,[class5_tr_date]
           ,[class5_tr_hrs] ,[class6_tr_date] ,[class6_tr_hrs],[class7_tr_date] ,[class7_tr_hrs] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update] ,[ofc_id]
           ,[district_id],grp_name) OUTPUT INSERTED.roster_id INTO @tempTable
        VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}',
			'{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}')
            SELECT roster_id FROM @tempTable";

            strSQL = string.Format(strSQL, roster_id, int_type, start_date.ToString("dd MMM yyyy HH:mm:ss"), end_date.ToString("dd MMM yyyy HH:mm:ss"), sup_name, imp_partner, dst_id, sct_id, wrd_id, venue, instructor_names, delivery_method
           , class1_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class1_tr_hrs, class2_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class2_tr_hrs, class3_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class3_tr_hrs, class4_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class4_tr_hrs, class5_tr_date.ToString("dd MMM yyyy HH:mm:ss")
           , class5_tr_hrs, class6_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class6_tr_hrs, class7_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class7_tr_hrs, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id
           , district_id,grp_name);

            string insertedRecordID = dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return insertedRecordID;
        }

        public static void updateNMNAttendaceRegister(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_NoMeansNo_participant_attendance]
                       SET [int_type] = '{1}'
                          ,[start_date] = '{2}'
                          ,[end_date] = '{3}'
                          ,[sup_name] = '{4}'
                          ,[imp_partner] = '{5}'
                          ,[dst_id] = '{6}'
                          ,[sct_id] = '{7}'
                          ,[wrd_id] = '{8}'
                          ,[venue] = '{9}'
                          ,[instructor_names] = '{10}'
                          ,[delivery_method] = '{11}'
                          ,[class1_tr_date] = '{12}'
                          ,[class1_tr_hrs] = '{13}'
                          ,[class2_tr_date] = '{14}'
                          ,[class2_tr_hrs] = '{15}'
                          ,[class3_tr_date] = '{16}'
                          ,[class3_tr_hrs] = '{17}'
                          ,[class4_tr_date] = '{18}'
                          ,[class4_tr_hrs] = '{19}'
                          ,[class5_tr_date] = '{20}'
                          ,[class5_tr_hrs] = '{21}'
                          ,[class6_tr_date] = '{22}'
                          ,[class6_tr_hrs] = '{23}'
                          ,[class7_tr_date] = '{24}'
                          ,[class7_tr_hrs] = '{25}'
                          ,[usr_id_update] = '{26}'
                          ,[usr_date_update] = '{27}'
                          ,grp_name = '{28}'
                     WHERE [roster_id] = '{0}'";

            strSQL = string.Format(strSQL, roster_id, int_type, start_date.ToString("dd MMM yyyy HH:mm:ss"), end_date.ToString("dd MMM yyyy HH:mm:ss"), sup_name, imp_partner, dst_id, sct_id, wrd_id, venue, instructor_names, delivery_method
           , class1_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class1_tr_hrs, class2_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class2_tr_hrs, class3_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class3_tr_hrs, class4_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class4_tr_hrs, class5_tr_date.ToString("dd MMM yyyy HH:mm:ss")
           , class5_tr_hrs, class6_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class6_tr_hrs, class7_tr_date.ToString("dd MMM yyyy HH:mm:ss"), class7_tr_hrs, usr_id_update, usr_date_update,grp_name);
         

            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static string saveNMNAttendaceRegisterMember(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[ben_NoMeansNo_participant_attendance_member]
                           ([roster_member_id] ,[roster_id],[yn_direct_ben] ,[hhm_id] ,[nmn_id] ,[first_name],[last_name] ,[age] ,[class1_attended] ,[class2_attended]
                           ,[class3_attended] ,[class4_attended],[class5_attended] ,[class6_attended] ,[class7_attended] ,[graduated] ,[usr_id_create] ,[usr_id_update]
                           ,[usr_date_create] ,[usr_date_update] ,[ofc_id] ,[district_id])
                     VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')";

            strSQL = string.Format(strSQL, roster_member_id, roster_id, yn_direct_ben, hhm_id, nmn_id, first_name, last_name, age, class1_attended, class2_attended
                           , class3_attended, class4_attended, class5_attended, class6_attended, class7_attended, graduated, usr_id_create, usr_id_update
                           , usr_date_create, usr_date_update, ofc_id, district_id);

            string insertedRecordID = dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return insertedRecordID;
        }

        public static void updateNMNAttendaceRegisterMember(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_NoMeansNo_participant_attendance_member] 
                        SET [yn_direct_ben] = '{1}'
                        ,[hhm_id] = '{2}'
                        ,[nmn_id] = '{3}'
                        ,[first_name] = '{4}'
                        ,[last_name] = '{5}'
                        ,[age] = '{6}'
                        ,[class1_attended] = '{7}'
                        ,[class2_attended] = '{8}'
                        ,[class3_attended] = '{9}'
                        ,[class4_attended] = '{10}'
                        ,[class5_attended] = '{11}'
                        ,[class6_attended] = '{12}'
                        ,[class7_attended] = '{13}'
                        ,[graduated] = '{14}'
                        ,[usr_id_update] = '{15}'
                        ,[usr_date_update] = '{16}'
                    WHERE [roster_member_id] = '{0}'";

            strSQL = string.Format(strSQL, roster_member_id, yn_direct_ben, hhm_id, nmn_id, first_name, last_name, age, class1_attended, class2_attended
                           , class3_attended, class4_attended, class5_attended, class6_attended, class7_attended, graduated, usr_id_update , usr_date_update);

            dbCon.ExecuteScalar(strSQL);
            #endregion SQL

        }

        public static DataTable LoadNMNAttendance()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT dt.roster_id, dst.dst_name,sct.sct_name,W.wrd_name,dt.int_type,dt.start_date,dt.end_date,dt.imp_partner AS  cso_name,dt.delivery_method FROM ben_NoMeansNo_participant_attendance dt
                        INNER JOIN lst_district dst ON dt.dst_id = dst.dst_id
                        INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
                        INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id";
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable SearchNMNAttendance(string dst_id,string sct_id,string wrd_id,string int_type)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                    SQL = @"SELECT dt.roster_id, dst.dst_name,sct.sct_name,W.wrd_name,dt.int_type,dt.start_date,dt.end_date,dt.imp_partner AS  cso_name,dt.delivery_method FROM ben_NoMeansNo_participant_attendance dt
                    INNER JOIN lst_district dst ON dt.dst_id = dst.dst_id
                    INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
                    INNER JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                    WHERE (@dst_id IS NULL OR @dst_id = '' OR dst.dst_id = @dst_id)
                    AND (@sct_id IS NULL OR @sct_id = '' OR sct.sct_id = @sct_id)
                    AND (@wrd_id IS NULL OR @wrd_id = '' OR W.wrd_id = @wrd_id)
                    AND (@int_type IS NULL OR @int_type = '' OR int_type = @int_type)";

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

                    cmd.Parameters.Add("@int_type", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@int_type"].Value = int_type;

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

        public static DataTable LoadNMNAttendanceDetails(string roster_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT* FROM ben_NoMeansNo_participant_attendance WHERE roster_id = '{0}'";
            strSQL = string.Format(strSQL, roster_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadNMNAttendanceParticipant(string roster_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT dt.roster_member_id, dt.yn_direct_ben,dt.nmn_id,dt.first_name,dt.last_name,dt.age,dt.class1_attended,dt.class2_attended,dt.class3_attended,
                    dt.class4_attended,dt.class5_attended,dt.class6_attended,dt.class7_attended,dt.graduated
                    FROM ben_NoMeansNo_participant_attendance_member dt
                    LEFT JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                    WHERE dt.roster_id = '{0}'";
            strSQL = string.Format(strSQL, roster_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadNMNAttendanceParticipantDetails(string roster_member_id) 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT dt.*,ISNULL(hh.hh_id,'-1') AS hh_id FROM ben_NoMeansNo_participant_attendance_member dt
                        LEFT JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household hh ON hhm.hh_id = hhm.hhm_id
                        WHERE dt.roster_member_id = '{0}'";

            strSQL = string.Format(strSQL, roster_member_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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

        public static DataTable LoadHouseholdMemberAttendance(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id FROM hh_household_member WHERE hh_id = '{0}' AND (YEAR(GETDATE()) - hhm_year_of_birth >=10 AND YEAR(GETDATE()) - hhm_year_of_birth <=18)";
            strSQL = string.Format(strSQL, hh_id);

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
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
        #endregion Attendance
    }
}
