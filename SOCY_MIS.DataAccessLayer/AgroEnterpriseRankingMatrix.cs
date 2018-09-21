using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public static class AgroEnterpriseRankingMatrix
    {

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        
        #endregion dbconnection

        #region Variables
        public static string agro_ent_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime date = DateTime.Today;
        public static string hhm_id = string.Empty;
        public static string fa_name = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #region ben_agro_enterprise_ranking_matrix_crop_ranking
        public static string agro_entm_id = string.Empty;
        public static string crop_1_id = string.Empty;
        public static int crop_1_param1_score = 0;
        public static int crop_1_param2_score = 0;
        public static int crop_1_param3_score = 0;
        public static int crop_1_param4_score = 0;
        public static int crop_1_param5_score = 0;
        public static int crop_1_param6_score = 0;
        public static int crop_1_param7_score = 0;
        public static int crop_1_param8_score = 0;
        public static int crop_1_total_score = 0;
        public static int crop_1_rank = 0;
        public static string crop_2_id = string.Empty;
        public static int crop_2_param1_score = 0;
        public static int crop_2_param2_score = 0;
        public static int crop_2_param3_score = 0;
        public static int crop_2_param4_score = 0;
        public static int crop_2_param5_score = 0;
        public static int crop_2_param6_score = 0;
        public static int crop_2_param7_score = 0;
        public static int crop_2_param8_score = 0;
        public static int crop_2_total_score = 0;
        public static int crop_2_rank = 0;
        public static string crop3_id = string.Empty;
        public static int crop_3_param1_score = 0;
        public static int crop_3_param2_score = 0;
        public static int crop_3_param3_score = 0;
        public static int crop_3_param4_score = 0;
        public static int crop_3_param5_score = 0;
        public static int crop_3_param6_score = 0;
        public static int crop_3_param7_score = 0;
        public static int crop_3_param8_score = 0;
        public static int crop_3_total_score = 0;
        public static int crop_3_rank = 0;
        public static string crop_4_id = string.Empty;
        public static int crop_4_param1_score = 0;
        public static int crop_4_param2_score = 0;
        public static int crop_4_param3_score = 0;
        public static int crop_4_param4_score = 0;
        public static int crop_4_param5_score = 0;
        public static int crop_4_param6_score = 0;
        public static int crop_4_param7_score = 0;
        public static int crop_4_param8_score = 0;
        public static int crop_4_total_score = 0;
        public static int crop_4_rank = 0;
        public static string crop_5_id = string.Empty;
        public static int crop_5_param1_score = 0;
        public static int crop_5_param2_score = 0;
        public static int crop_5_param3_score = 0;
        public static int crop_5_param4_score = 0;
        public static int crop_5_param5_score = 0;
        public static int crop_5_param6_score = 0;
        public static int crop_5_param7_score = 0;
        public static int crop_5_param8_score = 0;
        public static int crop_5_total_score = 0;
        public static int crop_5_rank = 0;
        public static string type = string.Empty;
        #endregion ben_agro_enterprise_ranking_matrix_crop_ranking

        #endregion Variables
        public static DataTable Return_AgroEnterpriseCrops()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (type)
            {
                case "crop":
                    SQL = " SELECT crop_sid,crop_name FROM [lst_agro_scoring_crops] WHERE type_id = '1'";
                    break;
                case "cottage":
                    SQL = " SELECT crop_sid,crop_name FROM [lst_agro_scoring_crops] WHERE type_id = '2'";
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

        public static string Return_AgroCropName(int crop_sid)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string crop_name = string.Empty;

            string SQL = " SELECT crop_name FROM [lst_agro_scoring_crops] WHERE crop_sid = {0}";
            SQL = string.Format(SQL,crop_sid);
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
                        crop_name = dtRow["crop_name"].ToString();
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

            return crop_name;
        }

        public static DataTable Return_AgroEnterpriseRankingMatrixParameters()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            switch (type) {
                case "crop":
                    SQL = "SELECT asp_id,asp_name FROM lst_agro_scoring_parameter";
                    break;
                case "cottage":
                    SQL = " SELECT asp_id,asp_name FROM lst_agro_scoring_parameter where asp_id <> '3' AND asp_id <> '8'";
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

        public static DataTable Return_HHYouthMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"SELECT hhm_id,(hhm_first_name + ' ' + hhm_last_name) AS hhm_name FROM hh_household_member
                             WHERE hh_id = '{0}'
                             AND YEAR(GETDATE()) - CONVERT(INT,  hhm_year_of_birth) >=15 
                             AND YEAR(GETDATE()) - CONVERT(INT,  hhm_year_of_birth) <=24";
            SQL = string.Format(SQL, hh_id);
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

        public static string save_update_ben_agro_enterprise_ranking_matrix_details(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (agro_ent_id nvarchar(150)) INSERT INTO [dbo].[ben_agro_enterprise_ranking_matrix]
           ([agro_ent_id] ,[prt_id],[cso_id],[wrd_id],[date],[hhm_id]
           ,[fa_name],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) OUTPUT INSERTED.[agro_ent_id] INTO @tempTable
           VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
            SELECT agro_ent_id FROM @tempTable";

            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_agro_enterprise_ranking_matrix]
                           SET [prt_id] = '{1}'
                              ,[cso_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[date] = '{4}'
                              ,[hhm_id] = '{5}'
                              ,[fa_name] = '{6}'
                              ,[usr_id_update] = '{7}'
                              ,[usr_date_update] = '{8}'
                         WHERE [agro_ent_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query,agro_ent_id,prt_id,cso_id,wrd_id,date,hhm_id,fa_name, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query,agro_ent_id,prt_id,cso_id,wrd_id,date,hhm_id,fa_name, usr_id_update, usr_date_update);

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
                        agro_ent_id = (string)cmd.ExecuteScalar();
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
                return agro_ent_id;
            }
            else
            {
                return string.Empty;
            }
        }

        public static void save_update_ben_agro_enterprise_ranking_matrix_scoring_details(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"INSERT INTO [dbo].[ben_agro_enterprise_ranking_matrix_crop_ranking]
           ([agro_entm_id],[agro_ent_id],[crop_1_id],[crop_1_param1_score],[crop_1_param2_score],[crop_1_param3_score],[crop_1_param4_score],[crop_1_param5_score]
           ,[crop_1_param6_score],[crop_1_param7_score],[crop_1_param8_score],[crop_1_total_score],[crop_1_rank]
           ,[crop_2_id],[crop_2_param1_score],[crop_2_param2_score],[crop_2_param3_score],[crop_2_param4_score],[crop_2_param5_score],[crop_2_param6_score]
           ,[crop_2_param7_score],[crop_2_param8_score],[crop_2_total_score],[crop_2_rank]
           ,[crop3_id],[crop_3_param1_score],[crop_3_param2_score],[crop_3_param3_score],[crop_3_param4_score],[crop_3_param5_score],[crop_3_param6_score],[crop_3_param7_score]
           ,[crop_3_param8_score],[crop_3_total_score],[crop_3_rank]
           ,[crop_4_id],[crop_4_param1_score],[crop_4_param2_score],[crop_4_param3_score],[crop_4_param4_score],[crop_4_param5_score],[crop_4_param6_score],[crop_4_param7_score]
           ,[crop_4_param8_score],[crop_4_total_score],[crop_4_rank]
		   ,[crop_5_id],[crop_5_param1_score],[crop_5_param2_score],[crop_5_param3_score],[crop_5_param4_score],[crop_5_param5_score],[crop_5_param6_score],[crop_5_param7_score]
           ,[crop_5_param8_score],[crop_5_total_score],[crop_5_rank],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
           VALUES('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},'{13}',{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}',{25},{26},{27},{28},{29},{30},{31},
                    {32},{33},{34},'{35}',{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},'{46}',{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},'{57}','{58}','{59}','{60}','{61}','{62}')";

            }
            else if (action == "update")
            {
                //update
                #region Update
                Query = @"UPDATE [dbo].[ben_agro_enterprise_ranking_matrix_crop_ranking]
                           SET [crop_1_id] = '{1}'
                              ,[crop_1_param1_score] = {2}
                              ,[crop_1_param2_score] = {3}
                              ,[crop_1_param3_score] = {4}
                              ,[crop_1_param4_score] = {5}
                              ,[crop_1_param5_score] = {6}
                              ,[crop_1_param6_score] = {7}
                              ,[crop_1_param7_score] = {8}
                              ,[crop_1_param8_score] = {9}
                              ,[crop_1_total_score] = {10}
                              ,[crop_1_rank] = {11}
                              ,[crop_2_id] = '{12}'
                              ,[crop_2_param1_score] = {13}
                              ,[crop_2_param2_score] = {14}
                              ,[crop_2_param3_score] = {15}
                              ,[crop_2_param4_score] = {16}
                              ,[crop_2_param5_score] = {17}
                              ,[crop_2_param6_score] = {18}
                              ,[crop_2_param7_score] = {19}
                              ,[crop_2_param8_score] = {20}
                              ,[crop_2_total_score] = {21}
                              ,[crop_2_rank] ={22}
                              ,[crop3_id] = '{23}'
                              ,[crop_3_param1_score] = {24}
                              ,[crop_3_param2_score] = {25}
                              ,[crop_3_param3_score] = {26}
                              ,[crop_3_param4_score] = {27}
                              ,[crop_3_param5_score] = {28}
                              ,[crop_3_param6_score] = {29}
                              ,[crop_3_param7_score] = {30}
                              ,[crop_3_param8_score] = {31}
                              ,[crop_3_total_score] = {32}
                              ,[crop_3_rank] = {33}
                              ,[crop_4_id] = '{34}'
                              ,[crop_4_param1_score] = {35}
                              ,[crop_4_param2_score] = {36}
                              ,[crop_4_param3_score] = {37}
                              ,[crop_4_param4_score] = {38}
                              ,[crop_4_param5_score] = {39}
                              ,[crop_4_param6_score] = {40}
                              ,[crop_4_param7_score] = {41}
                              ,[crop_4_param8_score] = {42}
                              ,[crop_4_total_score] = {43}
                              ,[crop_4_rank] = {44}
                              ,[crop_5_id] = '{45}'
                              ,[crop_5_param1_score] = {46}
                              ,[crop_5_param2_score] ={47}
                              ,[crop_5_param3_score] = {48}
                              ,[crop_5_param4_score] = {49}
                              ,[crop_5_param5_score] = {50}
                              ,[crop_5_param6_score] = {51}
                              ,[crop_5_param7_score] = {52}
                              ,[crop_5_param8_score] = {53}
                              ,[crop_5_total_score] = {54}
                              ,[crop_5_rank] = {55}
                              ,[usr_id_update] = '{56}'
                               ,[usr_date_update] = '{57}'
                         WHERE [agro_entm_id] = '{0}'";
                #endregion Update 

            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, agro_entm_id, agro_ent_id, crop_1_id, crop_1_param1_score, crop_1_param2_score, crop_1_param3_score, crop_1_param4_score, crop_1_param5_score, crop_1_param6_score, crop_1_param7_score,
                    crop_1_param8_score, crop_1_total_score, crop_1_rank, crop_2_id, crop_2_param1_score, crop_2_param2_score, crop_2_param3_score, crop_2_param4_score, crop_2_param5_score, crop_2_param6_score,
                    crop_2_param7_score, crop_2_param8_score, crop_2_total_score, crop_2_rank, crop3_id, crop_3_param1_score, crop_3_param2_score, crop_3_param3_score, crop_3_param4_score, crop_3_param5_score,
                    crop_3_param6_score, crop_3_param7_score, crop_3_param8_score, crop_3_total_score, crop_3_rank, crop_4_id, crop_4_param1_score, crop_4_param2_score, crop_4_param3_score, crop_4_param4_score,
                    crop_4_param5_score, crop_4_param6_score, crop_4_param7_score, crop_4_param8_score, crop_4_total_score, crop_4_rank, crop_5_id, crop_5_param1_score, crop_5_param2_score, crop_5_param3_score,
                    crop_5_param4_score, crop_5_param5_score, crop_5_param6_score, crop_5_param7_score, crop_5_param8_score, crop_5_total_score, crop_5_rank, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, agro_entm_id,crop_1_id, crop_1_param1_score, crop_1_param2_score, crop_1_param3_score, crop_1_param4_score, crop_1_param5_score, crop_1_param6_score, crop_1_param7_score,
                    crop_1_param8_score, crop_1_total_score, crop_1_rank, crop_2_id, crop_2_param1_score, crop_2_param2_score, crop_2_param3_score, crop_2_param4_score, crop_2_param5_score, crop_2_param6_score,
                    crop_2_param7_score, crop_2_param8_score, crop_2_total_score, crop_2_rank, crop3_id, crop_3_param1_score, crop_3_param2_score, crop_3_param3_score, crop_3_param4_score, crop_3_param5_score,
                    crop_3_param6_score, crop_3_param7_score, crop_3_param8_score, crop_3_total_score, crop_3_rank, crop_4_id, crop_4_param1_score, crop_4_param2_score, crop_4_param3_score, crop_4_param4_score,
                    crop_4_param5_score, crop_4_param6_score, crop_4_param7_score, crop_4_param8_score, crop_4_total_score, crop_4_rank, crop_5_id, crop_5_param1_score, crop_5_param2_score, crop_5_param3_score,
                    crop_5_param4_score, crop_5_param5_score, crop_5_param6_score, crop_5_param7_score, crop_5_param8_score, crop_5_total_score, crop_5_rank, usr_id_update, usr_date_update);

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
                        cmd.ExecuteNonQuery();
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
        }

        #region Load display
        public static DataTable LoadDisplay(string agro_ent_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"SELECT M.*,R.*,sct.sct_id,dst.dst_id,H.hh_id FROM ben_agro_enterprise_ranking_matrix M
                        LEFT JOIN ben_agro_enterprise_ranking_matrix_crop_ranking R ON M.agro_ent_id = R.agro_ent_id
                        LEFT JOIN hh_household_member hhm ON M.hhm_id = hhm.hhm_id
                        LEFT JOIN lst_ward W ON M.wrd_id = W.wrd_id
                        LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE M.agro_ent_id = '{0}'";

            SQL = string.Format(SQL, agro_ent_id);
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
        #endregion Load display

        #region Load Lists
        public static DataTable LoadAgroEnterpriseList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            switch (type)
            {
                case "crop":
                        SQL = @"SELECT R.agro_ent_id, dst.dst_name,sct.sct_name,W.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,R.date FROM ben_agro_enterprise_ranking_matrix R
                            LEFT JOIN lst_ward W ON R.wrd_id = W.wrd_id
                            LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                            WHERE R.agro_ent_id NOT LIKE '%cottage%'";
                    break;
                case "cottage":
                    SQL = @"SELECT R.agro_ent_id, dst.dst_name,sct.sct_name,W.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,R.date FROM ben_agro_enterprise_ranking_matrix R
                            LEFT JOIN lst_ward W ON R.wrd_id = W.wrd_id
                            LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                            WHERE R.agro_ent_id LIKE '%cottage%'";
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
        #endregion Load Lists

        #region Search
        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string youth_name,string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (type)
                {
                    case "crop":
                        SQL = @"SELECT R.agro_ent_id, dst.dst_name,sct.sct_name,W.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,R.date FROM ben_agro_enterprise_ranking_matrix R
                        LEFT JOIN lst_ward W ON R.wrd_id = W.wrd_id
                        LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
                        AND (@prt_id = '-1' OR R.prt_id = @prt_id)
                        AND (@cso_id = '-1' OR R.cso_id = @cso_id)
                        AND ((@youth_name = '' OR hhm.hhm_first_name LIKE '%' + @youth_name  + '%') OR (@youth_name = '' OR hhm.hhm_last_name LIKE '%' + @youth_name  + '%') )
                        AND (@hh_code = '' OR H.hh_code LIKE '%' + @hh_code  + '%')
                        AND R.agro_ent_id NOT LIKE '%cottage%'";
                        break;
                    case "cottage":
                        SQL = @"SELECT R.agro_ent_id, dst.dst_name,sct.sct_name,W.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,R.date FROM ben_agro_enterprise_ranking_matrix R
                        LEFT JOIN lst_ward W ON R.wrd_id = W.wrd_id
                        LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
                        AND (@prt_id = '-1' OR R.prt_id = @prt_id)
                        AND (@cso_id = '-1' OR R.cso_id = @cso_id)
                        AND ((@youth_name = '' OR hhm.hhm_first_name LIKE '%' + @youth_name  + '%') OR (@youth_name = '' OR hhm.hhm_last_name LIKE '%' + @youth_name  + '%') )
                        AND (@hh_code = '' OR H.hh_code LIKE '%' + @hh_code  + '%')
                        AND R.agro_ent_id LIKE '%cottage%'";
                        break;

                }
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
