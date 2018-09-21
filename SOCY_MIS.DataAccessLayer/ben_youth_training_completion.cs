using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public static class ben_youth_training_completion
    {

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        public static string ytc_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime date = DateTime.Now;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hhm_tel = string.Empty;
        public static string yfo_name = string.Empty;
        public static string y_adress = string.Empty;
        public static string skills_learnt = string.Empty;
        public static string skills_more_training = string.Empty;
        public static string yn_id_graduate = string.Empty;
        public static string yn_id_graduate_no_reason = string.Empty;
        public static string artisan_rating = string.Empty;
        public static string yn_id_fam_support = string.Empty;
        public static string yn_id_fam_support_yes_how = string.Empty;
        public static string yn_id_fam_support_no_reason = string.Empty;
        public static string yn_id_training_challenges = string.Empty;
        public static string yn_id_training_challenges_yes_list = string.Empty;
        public static string yn_id_earn_money = string.Empty;
        public static string yn_id_earn_money_yes_weekly_amt = string.Empty;
        public static string plan_after_training = string.Empty;
        public static string youth_rate_attendance = string.Empty;
        public static string youth_rate_commitment = string.Empty;
        public static string youth_rate_participation = string.Empty;
        public static string youth_rate_comprehension = string.Empty;
        public static string module_id = string.Empty;
        public static string yn_id_retain_youth = string.Empty;
        public static string yn_id_retain_youth_no_recommend = string.Empty;
        public static string yn_id_open_own_biz = string.Empty;

        public static string ytc_skill_id = string.Empty;
        public static string skill_id = string.Empty;
        public static string excellent_acquired_skr_id = string.Empty;
        public static string average_acquired_skr_id = string.Empty;
        public static string not_acquired_skr_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #region Save
        public static void Save(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"INSERT INTO [dbo].[ben_youth_training_completion] 
                           ([ytc_id],[prt_id],[cso_id],[wrd_id],[date],[hh_id],[hhm_id],[hhm_tel],[yfo_name],[y_adress],[skills_learnt],[skills_more_training]
                           ,[yn_id_graduate],[yn_id_graduate_no_reason],[artisan_rating],[yn_id_fam_support],[yn_id_fam_support_yes_how],[yn_id_fam_support_no_reason],[yn_id_training_challenges]
                           ,[yn_id_training_challenges_yes_list],[yn_id_earn_money],[yn_id_earn_money_yes_weekly_amt],[plan_after_training],[youth_rate_attendance]
                           ,[youth_rate_commitment],[youth_rate_participation],[youth_rate_comprehension],[module_id],[yn_id_retain_youth],[yn_id_retain_youth_no_recommend]
                           ,[yn_id_open_own_biz],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                     VALUES
                           ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
                           ,'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}'
                           ,'{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}')";

                    SQL = string.Format(SQL, ytc_id, prt_id, cso_id, wrd_id, date, hh_id, hhm_id, hhm_tel, yfo_name, y_adress, skills_learnt, skills_more_training, yn_id_graduate,
                        yn_id_graduate_no_reason, artisan_rating, yn_id_fam_support, yn_id_fam_support_yes_how, yn_id_fam_support_no_reason, yn_id_training_challenges, yn_id_training_challenges_yes_list, yn_id_earn_money,
                        yn_id_earn_money_yes_weekly_amt, plan_after_training, youth_rate_attendance, youth_rate_commitment, youth_rate_participation, youth_rate_comprehension, module_id, yn_id_retain_youth, yn_id_retain_youth_no_recommend,
                        yn_id_open_own_biz, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
                    #endregion Insert

                }
                else
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_youth_training_completion]
                           SET [prt_id] = '{1}'
                              ,[cso_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[date] = '{4}'
                              ,[hh_id] = '{5}'
                              ,[hhm_id] = '{6}'
                              ,[hhm_tel] = '{7}'
                              ,[yfo_name] = '{8}'
                              ,[y_adress] = '{9}'
                              ,[skills_learnt] = '{10}'
                              ,[skills_more_training] = '{11}'
                              ,[yn_id_graduate] = '{12}'
                              ,[yn_id_graduate_no_reason] = '{13}'
                              ,[artisan_rating] = '{14}'
                              ,[yn_id_fam_support] = '{15}'
                              ,[yn_id_fam_support_yes_how] = '{16}'
                              ,[yn_id_fam_support_no_reason] = '{17}'
                              ,[yn_id_training_challenges] = '{18}'
                              ,[yn_id_training_challenges_yes_list] = '{19}'
                              ,[yn_id_earn_money] = '{20}'
                              ,[yn_id_earn_money_yes_weekly_amt] = '{21}'
                              ,[plan_after_training] = '{22}'
                              ,[youth_rate_attendance] = '{23}'
                              ,[youth_rate_commitment] = '{24}'
                              ,[youth_rate_participation] = '{25}'
                              ,[youth_rate_comprehension] = '{26}'
                              ,[module_id] = '{27}'
                              ,[yn_id_retain_youth] = '{28}'
                              ,[yn_id_retain_youth_no_recommend] = '{29}'
                              ,[yn_id_open_own_biz] = '{30}'
                              ,[usr_date_update] = '{31}'
                              ,[usr_id_update] = '{32}'
                         WHERE [ytc_id] = '{0}'";


                    SQL = string.Format(SQL, ytc_id, prt_id, cso_id, wrd_id, date, hh_id, hhm_id, hhm_tel, yfo_name, y_adress, skills_learnt, skills_more_training, yn_id_graduate,
                         yn_id_graduate_no_reason, artisan_rating, yn_id_fam_support, yn_id_fam_support_yes_how, yn_id_fam_support_no_reason, yn_id_training_challenges, yn_id_training_challenges_yes_list, yn_id_earn_money,
                         yn_id_earn_money_yes_weekly_amt, plan_after_training, youth_rate_attendance, youth_rate_commitment, youth_rate_participation, youth_rate_comprehension, module_id, yn_id_retain_youth, yn_id_retain_youth_no_recommend,
                         yn_id_open_own_biz, usr_date_update, usr_id_update);
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

        public static string Save_skills()
        {

            #region Variables
            string Outasat_id = string.Empty;
            string SQL = string.Empty;
            #endregion  Variables

            SQL = @"IF NOT EXISTS(SELECT* FROM ben_youth_training_completion_skill_acquisition_tracking WHERE ytc_id = '{1}' AND module_id = '{2}' AND skill_id = '{3}')
                    BEGIN
	                    INSERT INTO [dbo].[ben_youth_training_completion_skill_acquisition_tracking]
                               ([ytc_skill_id],[ytc_id],[module_id],[skill_id],[excellent_acquired_skr_id],[average_acquired_skr_id],[not_acquired_skr_id],[usr_id_create],[usr_id_update]
                               ,[usr_date_create],[usr_date_update],[ofc_id],[district_id])
		                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
                    END ELSE BEGIN
	                    UPDATE [dbo].[ben_youth_training_completion_skill_acquisition_tracking]
                        SET [excellent_acquired_skr_id] = '{4}',[average_acquired_skr_id] = '{5}',[not_acquired_skr_id] = '{6}' WHERE [ytc_id] = '{1}' AND [module_id] = '{2}' AND [skill_id] = '{3}'
                    END";

            SQL = string.Format(SQL, ytc_skill_id, ytc_id, module_id, skill_id, excellent_acquired_skr_id, average_acquired_skr_id, not_acquired_skr_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
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

                    if (excellent_acquired_skr_id != string.Empty || average_acquired_skr_id != string.Empty || not_acquired_skr_id != string.Empty)
                    {
                        cmd.ExecuteNonQuery();
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

            return Outasat_id;
        }
        #endregion Save

        #region Display
        public static DataTable Display(string yct_id, string record_type)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (record_type)
            {

                case "DisplayMain":
                    SQL = @"SELECT T.*,dst.dst_id,sct.sct_id,H.hh_id FROM ben_youth_training_completion T
                            LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                            LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                            WHERE T.ytc_id = '{0}'";
                    SQL = string.Format(SQL, yct_id);
                    break;
                case "DisplayLine":
                    SQL = @"SELECT skill_id,excellent_acquired_skr_id,average_acquired_skr_id,not_acquired_skr_id
                             FROM ben_youth_training_completion_skill_acquisition_tracking T WHERE ytc_id = '{0}'";
                    SQL = string.Format(SQL, yct_id);
                    break;

                case "LoadList":
                    SQL = @"SELECT T.ytc_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                            FROM ben_youth_training_completion T
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
        #endregion Display

        #region Search
        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string youth_name, string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT T.ytc_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                        FROM ben_youth_training_completion T
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

        public static DataTable ReturnHHMDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT hhm.hhm_year_of_birth,hhm.gnd_id,hh.hh_code + '-' + hhm.hhm_number AS hhm_code FROM hh_household_member hhm
                        LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                        WHERE hhm_id = '{0}'";

                SQL = string.Format(SQL, hhm_id);

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

            
