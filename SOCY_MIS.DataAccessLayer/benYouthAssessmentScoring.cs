using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benYouthAssessmentScoring
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region Variables
        public static string yas_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime dt_ass_date = DateTime.Now;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string ttp_id = string.Empty;
        public static string ttps_id = string.Empty;
        public static string ys1_id = string.Empty;
        public static string ys2_id = string.Empty;
        public static string ys3_id = string.Empty;
        public static string ys4_id = string.Empty;
        public static string ys5_id = string.Empty;
        public static string ys6_id = string.Empty;
        public static string total_score = string.Empty;
        public static string youth_notes = string.Empty;
        public static string assessor_name = string.Empty;
        public static DateTime date_assessor_sign = DateTime.Now;
        public static string approver_name = string.Empty;
        public static DateTime date_approver_sign = DateTime.Now;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #endregion Variables

        public static DataTable Display(string record_type, string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (record_type)
            {

                case "ys1_id":
                    SQL = @"SELECT ya_score_id,ya_score_name,ya_score_order
                            FROM lst_youth_assessment_scoring_parameters 
                            WHERE ya_score_order <= 4";
                    break;
                case "ys2_id":
                    SQL = @"SELECT ya_score_id,ya_score_name,ya_score_order
                            FROM lst_youth_assessment_scoring_parameters 
                            WHERE ya_score_order > 4 AND ya_score_order <=8";
                    break;

                case "ys3_id":
                    SQL = @"SELECT ya_score_id,ya_score_name,ya_score_order
                            FROM lst_youth_assessment_scoring_parameters 
                            WHERE ya_score_order > 8 AND ya_score_order <= 12";
                    break;
                case "ys4_id":
                    SQL = @"SELECT ya_score_id,ya_score_name,ya_score_order
                            FROM lst_youth_assessment_scoring_parameters 
                            WHERE ya_score_order > 12 AND ya_score_order <= 16";
                    break;
                case "ys5_id":
                    SQL = @"SELECT ya_score_id,ya_score_name,ya_score_order
                            FROM lst_youth_assessment_scoring_parameters 
                            WHERE ya_score_order > 16 AND ya_score_order <= 20";
                    break;
                case "TrainingType":
                    SQL = @"SELECT ttp_id,ttp_name FROM lst_es_training_type WHERE ttp_id = '3' OR ttp_id = '4'";
                    break;
                case "Trades":
                    SQL = @"SELECT ttps_id,ttps_name FROM lst_es_training_type_session WHERE ttp_id = '4'";
                    SQL = string.Format(SQL, id);
                    break;
                case "Crops":
                    SQL = @"SELECT crop_id,crop_name FROM lst_agro_scoring_crops WHERE type_id = '1'";
                    SQL = string.Format(SQL, id);
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

        public static int ReturnParameterScore(string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            int score = 0;

            SQL = SQL = @"SELECT ya_score_value
                        FROM lst_youth_assessment_scoring_parameters 
                        WHERE ya_score_id = '{0}'";
            SQL = string.Format(SQL, id);
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
                        score = Convert.ToInt32(dtRow["ya_score_value"].ToString());
                    }
                    else
                    {
                        score = 0;
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

            return score;
        }

        #region Save
        public static void save(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"INSERT INTO [dbo].[ben_youth_assessment_scoring]
                            ([yas_id],[prt_id],[cso_id],[wrd_id],[dt_ass_date],[hh_id],[hhm_id],[ttp_id],[ttps_id],[ys1_id]
                            ,[ys2_id],[ys3_id],[ys4_id],[ys5_id],[ys6_id],[total_score],[youth_notes],[assessor_name],[date_assessor_sign]
                            ,[approver_name],[date_approver_sign],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                        VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}'
                            ,'{16}','{17}','{18}','{19}','{20}' ,'{21}','{22}','{23}','{24}','{25}','{26}')";

                    SQL = string.Format(SQL,yas_id,prt_id,cso_id,wrd_id,dt_ass_date,hh_id,hhm_id,ttp_id,ttps_id,ys1_id,ys2_id,ys3_id,ys4_id,ys5_id,ys6_id,total_score,youth_notes,assessor_name,
                        date_assessor_sign,approver_name,date_approver_sign, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
                    #endregion Insert

                }
                else
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_youth_assessment_scoring]
                           SET [prt_id] = '{1}'
                              ,[cso_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[dt_ass_date] = '{4}'
                              ,[hh_id] = '{5}'
                              ,[hhm_id] = '{6}'
                              ,[ttp_id] = '{7}'
                              ,[ttps_id] = '{8}'
                              ,[ys1_id] = '{9}'
                              ,[ys2_id] = '{10}'
                              ,[ys3_id] = '{11}'
                              ,[ys4_id] = '{12}'
                              ,[ys5_id] = '{13}'
                              ,[ys6_id] = '{14}'
                              ,[total_score] = '{15}'
                              ,[youth_notes] = '{16}'
                              ,[assessor_name] = '{17}'
                              ,[date_assessor_sign] = '{18}'
                              ,[approver_name] = '{19}'
                              ,[date_approver_sign] = '{20}'
                              ,[usr_id_update] = '{21}'
                              ,[usr_date_update] = '{22}'
                         WHERE [yas_id] = '{0}'";


                    SQL = string.Format(SQL, yas_id, prt_id, cso_id, wrd_id, dt_ass_date, hh_id, hhm_id, ttp_id, ttps_id, ys1_id, ys2_id, ys3_id, ys4_id, ys5_id, ys6_id, total_score, youth_notes, assessor_name,
                        date_assessor_sign, approver_name, date_approver_sign, usr_id_update, usr_date_update);
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
        public static DataTable LoadDisplay(string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"SELECT dt.*,dst.dst_id,sct.sct_id FROM ben_youth_assessment_scoring dt
                    LEFT JOIN lst_ward W ON dt.wrd_id = W.wrd_id
                    LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                    LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                    WHERE yas_id = '{0}'";
            SQL = string.Format(SQL, id);

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

        public static DataTable LoadDisplayList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"SELECT T.yas_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],
                    hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                    FROM ben_youth_assessment_scoring T
                    LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                    LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                    LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                    LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                    LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id";
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
                SQL = @"SELECT T.yas_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],
                        hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Youth Name]
                        FROM ben_youth_assessment_scoring T
                        LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                        LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
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
