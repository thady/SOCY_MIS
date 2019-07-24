using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public static class hhgraduation_assessment
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string gat_id = string.Empty;
        public static string _gat_id = string.Empty;
        public static string hh_id = string.Empty;
        public static string swk_id = string.Empty;
        public static string hhm_head_id = string.Empty;
        public static DateTime gat_date = DateTime.Now;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #region BenchMark01
        public static string gat_b_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string yn_hiv_status = string.Empty;
        #endregion BenchMark01

        #region BenchMark02
        public static string yn_supressed = string.Empty;
        public static string yn_adhering = string.Empty;
        public static string yn_attend_art_appointment = string.Empty;
        #endregion BenchMark02

        #endregion Variables

        public static string ReturnSocialWorkerPhone(string swk_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = "SELECT swk_phone FROM swm_social_worker WHERE swk_id = '{0}'";
            strSQL = string.Format(strSQL, swk_id);
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
                        swk_phone = dtRow["swk_phone"].ToString();
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

            return swk_phone;
        }


        public static DataTable LoadHouseholdMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = "SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id FROM hh_household_member WHERE hh_id = '{0}' ORDER BY hhm_number ASC";
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


        public static DataTable LoadHouseholdMembersBenchMark01(string hh_id,string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name) + '-' + hhm_number AS hhm_name, hhm_id, hhm_number FROM hh_household_member WHERE hh_id = '{0}'
                                ),
                                CteHouseholdMembersGatJoin AS(
                                SELECT hhm.hhm_name, hhm.hhm_id, dt.hhm_id AS _hhm_id, hhm_number FROM CteHouseholdMembers hhm
                                LEFT JOIN hh_graduation_assessment_benchmark01 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

                                )
                                select hhm_name, hhm_id from CteHouseholdMembersGatJoin WHERE _hhm_id IS NULL ORDER BY hhm_number";
            strSQL = string.Format(strSQL, hh_id,gat_id);
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


        public static DataTable LoadHouseholdMembersBenchMark02(string hh_id, string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (hst_id_new = '1' OR hst_id = '1') AND hh_id ='{0}'
                                ),
                                CteHouseholdMembersGatJoin AS(
                                SELECT hhm.hhm_name,hhm.hhm_id,dt.hhm_id AS _hhm_id,hhm_number FROM CteHouseholdMembers hhm
                                LEFT JOIN hh_graduation_assessment_benchmark02 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

                                )
                                select hhm_name,hhm_id from CteHouseholdMembersGatJoin WHERE _hhm_id IS NULL ORDER BY hhm_number";
            strSQL = string.Format(strSQL, hh_id, gat_id);
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


        public static DataTable LoadHouseholdMembersBenchMark03(string hh_id, string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >=10 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id ='{0}'
                                ),
                                CteHouseholdMembersGatJoin AS(
                                SELECT hhm.hhm_name,hhm.hhm_id,dt.hhm_id AS _hhm_id,hhm_number FROM CteHouseholdMembers hhm
                                LEFT JOIN hh_graduation_assessment_benchmark03 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

                                )
                                select hhm_name,hhm_id from CteHouseholdMembersGatJoin WHERE _hhm_id IS NULL ORDER BY hhm_number";
            strSQL = string.Format(strSQL, hh_id, gat_id);
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



        #region Save
        public static void save_hh_graduation_assessment(string _gat_id)
        {
            string strSQL = string.Empty;

            if (_gat_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment]
                            ([gat_id],[hh_id],[swk_id],[hhm_head_id],[gat_date],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                            VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')";
                strSQL = string.Format(strSQL, gat_id, hh_id, swk_id, hhm_head_id, gat_date, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment]
                           SET [swk_id] = '{1}'
                              ,[hhm_head_id] = '{2}'
                              ,[gat_date] = '{3}'
                              ,[usr_id_update] = '{4}'
                              ,[usr_date_update] = '{5}'
                         WHERE [gat_id] = '{0}'";
                strSQL = string.Format(strSQL, _gat_id,swk_id,hhm_head_id,gat_date,usr_id_update,usr_date_update);
            }
           
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

        public static void saveBenchMark01(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark01]([gat_b_id],[gat_id] ,[hhm_id],[yn_hiv_status],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update] ,[ofc_id] ,[district_id])
                         VALUES ('{0}','{1}','{2}' ,'{3}' ,'{4}' ,'{5}','{6}' ,'{7}','{8}','{9}')";
                strSQL = string.Format(strSQL, gat_b_id,gat_id, hhm_id, yn_hiv_status,usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark01]
                           SET [yn_hiv_status] = '{1}'
                              ,[usr_id_update] = '{2}'
                              ,[usr_date_update] = '{3}'
                         WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, _gat_b_id, yn_hiv_status,usr_id_update, usr_date_update);
            }

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

        public static void saveBenchMark02(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark02]
                               ([gat_b_id],[gat_id],[hhm_id],[yn_supressed] ,[yn_adhering] ,[yn_attend_art_appointment],[usr_id_create] ,[usr_id_update]
                               ,[usr_date_create] ,[usr_date_update],[ofc_id],[district_id])
                         VALUES ('{0}','{1}' ,'{2}','{3}' ,'{4}' ,'{5}' ,'{6}','{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, hhm_id, yn_supressed, yn_adhering, yn_attend_art_appointment, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark02]
                           SET [yn_supressed] = '{1}'
                              ,[yn_adhering] = '{2}'
                              ,[yn_attend_art_appointment] = '{3}'
                              ,[usr_id_update] = '{4}'
                              ,[usr_date_update] = '{5}'
                         WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, _gat_b_id, yn_supressed, yn_adhering, yn_attend_art_appointment, usr_id_update, usr_date_update);
            }

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
        #endregion Save
    }
}
