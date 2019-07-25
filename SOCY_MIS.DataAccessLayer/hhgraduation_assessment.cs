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

        #region BenchMark03
        public static string yn_hiv_risk_knowledge = string.Empty;
        public static string yn_hiv_prevention = string.Empty;
        #endregion BenchMark03

        #region BenchMark04
        public static string yn_muac_normal = string.Empty;
        public static string yn_edema_free = string.Empty;
        #endregion BenchMark04

        #region BenchMark05
        public static string yn_pay_fees = string.Empty;
        public static string yn_pay_fees_no_pepfar_grant = string.Empty;
        public static string yn_pay_fees_no_sell_asset = string.Empty;
        public static string yn_pay_medical_costs = string.Empty;
        public static string yn_pay_medical_costs_no_pepfar_grant = string.Empty;
        public static string yn_pay_medical_costs_no_sell_asset = string.Empty;
        #endregion BenchMark05

        #region BenchMark06
        public static string yn_kicked = string.Empty; 
        public static string yn_child_kicked = string.Empty;
        public static string yn_child_violence = string.Empty;
        #endregion BenchMark06

        #region BenchMark07
        public static string yn_stable_caregiver = string.Empty;
        #endregion BenchMark07

        #region BenchMark08
        public static string yn_children_enrolled_in_school = string.Empty;
        public static string yn_atte_school_regualarly = string.Empty;
        public static string yn_progress_next_level = string.Empty;
        #endregion BenchMark08


        #region FinalBenchMark
        public static string yn_met_benchmark01 = string.Empty;
        public static string yn_met_benchmark02 = string.Empty;
        public static string yn_met_benchmark03 = string.Empty;
        public static string yn_met_benchmark04 = string.Empty;
        public static string yn_met_benchmark05 = string.Empty;
        public static string yn_met_benchmark06 = string.Empty;
        public static string yn_met_benchmark07 = string.Empty;
        public static string yn_met_benchmark08 = string.Empty;
        #endregion FinalBenchMark

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


        public static DataTable LoadHouseholdMembersBenchMark04(string hh_id, string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) < 5 AND hh_id ='{0}'
                                ),
                                CteHouseholdMembersGatJoin AS(
                                SELECT hhm.hhm_name,hhm.hhm_id,dt.hhm_id AS _hhm_id,hhm_number FROM CteHouseholdMembers hhm
                                LEFT JOIN hh_graduation_assessment_benchmark04 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

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


        public static DataTable LoadHouseholdMembersBenchMark05(string hh_id, string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                            SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 15 AND  hh_id ='{0}'
                            ),
                            CteHouseholdMembersGatJoin AS(
                            SELECT hhm.hhm_name,hhm.hhm_id,dt.hhm_id AS _hhm_id,hhm_number FROM CteHouseholdMembers hhm
                            LEFT JOIN hh_graduation_assessment_benchmark05 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

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


        public static DataTable LoadHouseholdMembersBenchMark06(string hh_id, string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @";With CteHouseholdMembers AS(
                            SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 12 AND  hh_id ='{0}'
                            ),
                            CteHouseholdMembersGatJoin AS(
                            SELECT hhm.hhm_name,hhm.hhm_id,dt.hhm_id AS _hhm_id,hhm_number FROM CteHouseholdMembers hhm
                            LEFT JOIN hh_graduation_assessment_benchmark06 dt ON hhm.hhm_id = dt.hhm_id AND dt.gat_id = '{1}'

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


        public static int LoadHouseholdMemberAge(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            int age = 0;

            string strSQL = @"SELECT (YEAR(GETDATE()) - hhm_year_of_birth) AS hhm_age FROM hh_household_member WHERE  hhm_id ='{0}'";

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
                        age = Convert.ToInt32(dtRow["hhm_age"].ToString());
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


        public static int ValidateBenchMarks(string gat_id,string bencharmark)
        {
            int count = 0;
            string strSQL = string.Empty;

            switch (bencharmark)
            {
                case "01":
                     strSQL = @"SELECT COUNT(*) FROM hh_graduation_assessment_benchmark01
                                WHERE yn_hiv_status = 0 AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL,gat_id);
                    break;
                case "02":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark02
                                WHERE yn_supressed = '0' AND (yn_adhering = '0' OR yn_attend_art_appointment = '0') AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;

                case "03":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark03
                                WHERE (yn_hiv_risk_knowledge = '0' OR yn_hiv_prevention = '0') AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "04":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark04
                                WHERE (yn_muac_normal = '0' OR yn_edema_free = '0') AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "05":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark05
                            WHERE (yn_pay_fees = 0 OR yn_pay_fees_no_pepfar_grant = 0 OR yn_pay_fees_no_sell_asset = 0 OR yn_pay_medical_costs = 0 OR 
                            yn_pay_medical_costs_no_pepfar_grant = 0 OR yn_pay_medical_costs_no_sell_asset = 0) AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "06":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark06
                                WHERE (yn_child_kicked = 1 OR yn_kicked = 1 OR yn_child_violence = 1) AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "07":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark07
                                WHERE yn_stable_caregiver = 0  AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "08":
                    strSQL = @"SELECT COUNT(*)  FROM hh_graduation_assessment_benchmark08
                                WHERE (yn_children_enrolled_in_school = 0  OR yn_atte_school_regualarly = 0 OR yn_atte_school_regualarly = 0) AND gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id);
                    break;
            }
            

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

                    count = Convert.ToInt32(cmd.ExecuteScalar());

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


        public static int CheckNumberPositiveInHousehold(string hh_id)
        {
            int count = 0;
            string strSQL = string.Empty;

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (hst_id = '1' OR hst_id_new = '1') AND hh_id = '{0}'";

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

                    count = Convert.ToInt32(cmd.ExecuteScalar());

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


        public static int CheckNumber10To17(string hh_id)
        {
            int count = 0;
            string strSQL = string.Empty;

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >=10 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id = '{0}'";

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

                    count = Convert.ToInt32(cmd.ExecuteScalar());

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


        public static int CheckNumberUnder5Years(string hh_id)
        {
            int count = 0;
            string strSQL = string.Empty;

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) < 5 AND hh_id = '{0}'";

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

                    count = Convert.ToInt32(cmd.ExecuteScalar());

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

        public static int CheckNumberSchoolAge(string hh_id)
        {
            int count = 0;
            string strSQL = string.Empty;

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 6 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id = '{0}'";

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

                    count = Convert.ToInt32(cmd.ExecuteScalar());

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


        public static void saveBenchMark03(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark03]
                            ([gat_b_id],[gat_id] ,[hhm_id],[yn_hiv_risk_knowledge] ,[yn_hiv_prevention],[usr_id_create] ,[usr_id_update],[usr_date_create]
                            ,[usr_date_update] ,[ofc_id] ,[district_id])
                            VALUES ('{0}'  ,'{1}' ,'{2}' ,'{3}' ,'{4}','{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, hhm_id, yn_hiv_risk_knowledge, yn_hiv_prevention,usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark03]
                               SET [yn_hiv_risk_knowledge] = '{1}'
                                  ,[yn_hiv_prevention] = '{2}'
                                  ,[usr_id_update] = '{3}'
                                  ,[usr_date_update] = '{4}'
                             WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, _gat_b_id, yn_hiv_risk_knowledge, yn_hiv_prevention, usr_id_update, usr_date_update);
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


        public static void saveBenchMark04(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark04]
                               ([gat_b_id],[gat_id] ,[hhm_id] ,[yn_muac_normal],[yn_edema_free] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update]
                               ,[ofc_id],[district_id])
                         VALUES ('{0}' ,'{1}','{2}' ,'{3}' ,'{4}','{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, hhm_id, yn_muac_normal, yn_edema_free, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark04]
                               SET [yn_muac_normal] = '{1}'
                                  ,[yn_edema_free] = '{2}'
                                  ,[usr_id_update] = '{3}'
                                  ,[usr_date_update] = '{4}'
                             WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, _gat_b_id, yn_muac_normal, yn_edema_free, usr_id_update, usr_date_update);
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


        public static void saveBenchMark05(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark05]
                            ([gat_b_id] ,[gat_id] ,[hhm_id],[yn_pay_fees] ,[yn_pay_fees_no_pepfar_grant] ,[yn_pay_fees_no_sell_asset],[yn_pay_medical_costs],[yn_pay_medical_costs_no_pepfar_grant],[yn_pay_medical_costs_no_sell_asset]
                            ,[usr_id_create],[usr_id_update],[usr_date_create] ,[usr_date_update] ,[ofc_id] ,[district_id])
                            VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}','{7}' ,'{8}' ,'{9}' ,'{10}','{11}','{12}' ,'{13}','{14}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, hhm_id, yn_pay_fees, yn_pay_fees_no_pepfar_grant, yn_pay_fees_no_sell_asset, yn_pay_medical_costs, yn_pay_medical_costs_no_pepfar_grant, yn_pay_medical_costs_no_sell_asset, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark05]
                           SET [yn_pay_fees] = '{1}'
                              ,[yn_pay_fees_no_pepfar_grant] =  '{2}'
                              ,[yn_pay_fees_no_sell_asset] =  '{3}'
                              ,[yn_pay_medical_costs] =  '{4}'
                              ,[yn_pay_medical_costs_no_pepfar_grant] =  '{5}'
                              ,[yn_pay_medical_costs_no_sell_asset] = '{6}'
                              ,[usr_id_update] =  '{7}'
                              ,[usr_date_update] =  '{8}'
                         WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, gat_b_id,yn_pay_fees, yn_pay_fees_no_pepfar_grant, yn_pay_fees_no_sell_asset, yn_pay_medical_costs, yn_pay_medical_costs_no_pepfar_grant, yn_pay_medical_costs_no_sell_asset, usr_id_update, usr_date_update);
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


        public static void saveBenchMark06(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark06]
	                        ([gat_b_id],[gat_id],[hhm_id],[yn_kicked],[yn_child_kicked],[yn_child_violence],[usr_id_create],[usr_id_update]
	                        ,[usr_date_create] ,[usr_date_update] ,[ofc_id] ,[district_id])
                        VALUES ('{0}' ,'{1}' ,'{2}','{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}','{8}','{9}','{10}' ,'{11}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, hhm_id, yn_kicked, yn_child_kicked, yn_child_violence,usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark06]
                           SET [yn_kicked] = '{1}'
                              ,[yn_child_kicked] = '{2}'
                              ,[yn_child_violence] = '{3}'
                              ,[usr_id_update] = '{4}'
                              ,[usr_date_update] = ''
                         WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, gat_b_id, yn_pay_fees, yn_pay_fees_no_pepfar_grant, yn_pay_fees_no_sell_asset, yn_pay_medical_costs, yn_pay_medical_costs_no_pepfar_grant, yn_pay_medical_costs_no_sell_asset, usr_id_update, usr_date_update);
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


        public static void saveBenchMark07(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark07]
                               ([gat_b_id] ,[gat_id] ,[yn_stable_caregiver],[usr_id_create],[usr_id_update],[usr_date_create] ,[usr_date_update],[ofc_id] ,[district_id])
                         VALUES ('{0}' ,'{1}','{2}','{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}','{8}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, yn_stable_caregiver, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark07]
                               SET [yn_stable_caregiver] = '{1}'
                                  ,[usr_id_update] = '{2}'
                                  ,[usr_date_update] = '{3}'
                             WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, gat_b_id, yn_stable_caregiver, usr_id_update, usr_date_update);
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



        public static void saveBenchMark08(string _gat_b_id)
        {
            string strSQL = string.Empty;

            if (_gat_b_id == string.Empty)
            {
                strSQL = @"INSERT INTO [dbo].[hh_graduation_assessment_benchmark08]
                               ([gat_b_id] ,[gat_id] ,[yn_children_enrolled_in_school] ,[yn_atte_school_regualarly] ,[yn_progress_next_level] ,[usr_id_create],[usr_id_update] ,[usr_date_create] ,[usr_date_update]
                               ,[ofc_id],[district_id])
                         VALUES ('{0}' ,'{1}' ,'{2}','{3}' ,'{4}' ,'{5}','{6}' ,'{7}' ,'{8}','{9}' ,'{10}')";
                strSQL = string.Format(strSQL, gat_b_id, gat_id, yn_children_enrolled_in_school, yn_atte_school_regualarly, yn_progress_next_level, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else
            {
                strSQL = @"UPDATE [dbo].[hh_graduation_assessment_benchmark08]
                           SET [yn_children_enrolled_in_school] = '{1}'
                              ,[yn_atte_school_regualarly] = '{2}'
                              ,[yn_progress_next_level] = '{3}'
                              ,[usr_id_update] ='{4}'
                              ,[usr_date_update] = '{5}'
                         WHERE [gat_b_id] = '{0}'";
                strSQL = string.Format(strSQL, gat_b_id, yn_children_enrolled_in_school, yn_atte_school_regualarly, yn_progress_next_level, usr_id_update, usr_date_update);
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


        public static void saveFinalBenchMark(string gat_id,string benchmark)
        {
            string strSQL = string.Empty;

            switch (benchmark)
            {
                case "01":
                    strSQL = @"IF NOT EXISTS(SELECT* FROM [dbo].[hh_graduation_assessment_final] WHERE gat_id = '{0}')
	                            BEGIN
	                            INSERT INTO [dbo].[hh_graduation_assessment_final]
	                            ([gat_id]  ,[yn_met_benchmark01] ,[yn_met_benchmark02] ,[yn_met_benchmark03] ,[yn_met_benchmark04] ,[yn_met_benchmark05],[yn_met_benchmark06]
	                            ,[yn_met_benchmark07] ,[yn_met_benchmark08] ,[usr_id_create]  ,[usr_id_update] ,[usr_date_create] ,[usr_date_update],[ofc_id],[district_id])
	                            VALUES  ('{0}'  ,'{1}' ,'{2}'  ,'{3}'  ,'{4}' ,'{5}' ,'{6}','{7}' ,'{8}','{9}','{10}' ,'{11}' ,'{12}' ,'{13}','{14}')
                            END ELSE BEGIN
                            UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark01 = '{1}',yn_met_benchmark02 = '{2}',yn_met_benchmark03 = '{3}',yn_met_benchmark04 = '{4}',
                            yn_met_benchmark05= '{5}',yn_met_benchmark06 = '{6}',yn_met_benchmark07 = '{7}',yn_met_benchmark08 = '{8}'
                            WHERE gat_id = '{0}'
                            END";
                    strSQL = string.Format(strSQL,gat_id, yn_met_benchmark01, yn_met_benchmark02, yn_met_benchmark03, yn_met_benchmark04, yn_met_benchmark05, yn_met_benchmark06, yn_met_benchmark07, yn_met_benchmark08,
                        usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
                    break;
                case "02":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark02 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark02);
                    break;
                case "03":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark03 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark03);
                    break;

                case "04":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark04 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark04);
                    break;
                case "05":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark05 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark05);
                    break;
                case "06":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark06 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark06);
                    break;
                case "07":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark07 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark07);
                    break;
                case "08":
                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark08 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark08);
                    break;
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
