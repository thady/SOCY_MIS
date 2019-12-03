using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benAdolescentSchoolAssessment
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region Variables
        public static string record_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hh_id = string.Empty;
        public static string yn_hhm_in_school = string.Empty;
        public static string current_class = string.Empty;
        public static string yn_current_school = string.Empty;
        public static string total_days_missed_school_last_term = string.Empty;
        public static string reason_for_missing_sch = string.Empty;
        public static string prev_school_attended = string.Empty;
        public static string class_at_dropout = string.Empty;
        public static string dropout_reason = string.Empty;
        public static string yn_school_or_vocational = string.Empty;
        public static string school_term_start = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion Variables


        public static void save()
        {

                    string strSQL = @"INSERT INTO [dbo].[ben_ovc_school_eligibility_assessment]
                               ([record_id] ,[hhm_id],[yn_hhm_in_school],[yn_current_school],[current_class] ,[total_days_missed_school_last_term],[reason_for_missing_sch],[prev_school_attended],[class_at_dropout] ,[dropout_reason]
                               ,[yn_school_or_vocational] ,[school_term_start] ,[usr_id_create] ,[usr_id_update],[usr_date_create] ,[usr_date_update],[ofc_id],[district_id])
                         VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}'  ,'{10}' ,'{11}' ,'{12}' ,'{13}'  ,'{14}'  ,'{15}','{16}','{17}')";

                    strSQL = string.Format(strSQL, record_id, hhm_id, yn_hhm_in_school, yn_current_school, current_class, total_days_missed_school_last_term, reason_for_missing_sch, prev_school_attended, class_at_dropout, dropout_reason
                                    , yn_school_or_vocational, school_term_start, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
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

            string strSQL = @"UPDATE [dbo].[ben_ovc_school_eligibility_assessment]
                           SET [hhm_id] = '{1}'
                              ,[yn_hhm_in_school] = '{2}'
                              ,[yn_current_school] = '{3}'
                              ,[current_class] = '{4}'
                              ,[total_days_missed_school_last_term] = '{5}'
                              ,[reason_for_missing_sch] = '{6}'
                              ,[prev_school_attended] = '{7}'
                              ,[class_at_dropout] = '{8}'
                              ,[dropout_reason] = '{9}'
                              ,[yn_school_or_vocational] = '{10}'
                              ,[school_term_start] = '{11}'
                              ,[usr_id_update] = '{12}'
                              ,[usr_date_update] = '{13}'
                         WHERE [record_id] = '{0}'";

            strSQL = string.Format(strSQL, record_id, hhm_id, yn_hhm_in_school, yn_current_school,current_class, total_days_missed_school_last_term, reason_for_missing_sch, prev_school_attended, class_at_dropout, dropout_reason
                            , yn_school_or_vocational, school_term_start, usr_id_update, usr_date_update);
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

        public static DataTable LoadDetails(string record_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"  SELECT* FROM ben_ovc_school_eligibility_assessment WHERE record_id = '{0}'";
                SQL = string.Format(SQL,record_id);

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


        public static DataTable LoadMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id FROM hh_household_member
                        WHERE hh_id = '{0}' AND YEAR(GETDATE()) - hhm_year_of_birth >= 10 AND YEAR(GETDATE()) - hhm_year_of_birth <= 17";

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

        public static DataTable LoadEducationLevel()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT edu_id,edu_name FROM lst_education_level WHERE edu_order < 15";

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

        public static DataTable AssessmentDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT record_id FROM ben_ovc_school_eligibility_assessment WHERE hhm_id = '{0}'";
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
