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

            string strSQL = "SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id FROM hh_household_member WHERE hh_id = '{0}' AND hhm_status = '1' ORDER BY hhm_number ASC";
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
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name) + '-' + hhm_number AS hhm_name, hhm_id, hhm_number FROM hh_household_member WHERE hh_id = '{0}' AND hhm_status = '1'
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
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (hst_id_new = '1' OR hst_id = '1') AND hh_id ='{0}' AND hhm_status = '1'
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
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >=10 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id ='{0}' AND hhm_status = '1'
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
                                SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) < 5 AND hh_id ='{0}' AND hhm_status = '1'
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
                            SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 15 AND  hh_id ='{0}' AND hhm_status = '1'
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
                            SELECT UPPER(hhm_first_name + ' ' + hhm_last_name ) + '-' + hhm_number AS hhm_name,hhm_id,hhm_number FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 12 AND  hh_id ='{0}' AND hhm_status = '1'
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



        public static DataTable LoadMemberLists(string gat_id,string benchMark)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            switch (benchMark)
            {
                case "01":
                    strSQL = @"SELECT gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,yn.yn_name AS known_hiv_status FROM [dbo].[hh_graduation_assessment_benchmark01] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                INNER JOIN lst_yes_no yn ON dt.yn_hiv_status = yn.yn_id
                                WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "02":
                    strSQL = @"SELECT gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,ISNULL(yn_sup.ynna_name,'') AS suppressing,ISNULL(yn_adher.ynna_name,'') AS Adhere,ISNULL(yn_app.ynna_name,'') AS Appointment FROM [dbo].[hh_graduation_assessment_benchmark02] dt
                            INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                            LEFT JOIN lst_yes_no_not_applicable yn_sup ON dt.yn_supressed = yn_sup.ynna_id
                            LEFT JOIN lst_yes_no_not_applicable yn_adher ON dt.yn_adhering = yn_adher.ynna_id
                            LEFT JOIN lst_yes_no_not_applicable yn_app ON dt.yn_attend_art_appointment = yn_app.ynna_id
                            WHERE dt.gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "03":
                    strSQL = @"SELECT gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,yn_risk.ynna_name AS yn_risk,yn_prev.ynna_name AS yn_prev  FROM [dbo].[hh_graduation_assessment_benchmark03] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                INNER JOIN lst_yes_no_not_applicable yn_risk ON dt.yn_hiv_risk_knowledge = yn_risk.ynna_id
                                INNER JOIN lst_yes_no_not_applicable yn_prev ON dt.yn_hiv_prevention = yn_prev.ynna_id
                                WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "04":
                    strSQL = @"SELECT gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,yn_muac.ynna_name AS yn_muac,yn_edema.ynna_name AS yn_edema FROM [dbo].[hh_graduation_assessment_benchmark04] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                INNER JOIN lst_yes_no_not_applicable yn_muac ON dt.yn_muac_normal = yn_muac.ynna_id
                                INNER JOIN lst_yes_no_not_applicable yn_edema ON dt.yn_edema_free = yn_edema.ynna_id
                                WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "05":
                    strSQL = @"SELECT gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,yn_pay_fees.ynna_name AS yn_pay_fees,ISNULL(yn_pay_fees_no_pepfar_grant.ynna_name,'Not Applicable') AS yn_pay_fees_no_pepfar_grant,
                                ISNULL(yn_pay_fees_no_sell_asset.ynna_name,'Not Applicable') AS yn_pay_fees_no_sell_asset,yn_pay_medical_costs.ynna_name AS yn_pay_medical_costs,ISNULL(yn_pay_medical_costs_no_pepfar_grant.ynna_name,'Not Applicable') AS yn_pay_medical_costs_no_pepfar_grant,
                                ISNULL(yn_pay_medical_costs_no_sell_asset.ynna_name,'Not Applicable') AS yn_pay_medical_costs_no_sell_asset
                                FROM [dbo].[hh_graduation_assessment_benchmark05] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                INNER JOIN lst_yes_no_not_applicable yn_pay_fees ON dt.yn_pay_fees = yn_pay_fees.ynna_id
                                LEFT JOIN lst_yes_no_not_applicable yn_pay_fees_no_pepfar_grant ON dt.yn_pay_fees_no_pepfar_grant = yn_pay_fees_no_pepfar_grant.ynna_id
                                LEFT JOIN lst_yes_no_not_applicable yn_pay_fees_no_sell_asset ON dt.yn_pay_fees_no_sell_asset = yn_pay_fees_no_sell_asset.ynna_id
                                INNER JOIN lst_yes_no_not_applicable yn_pay_medical_costs ON dt.yn_pay_medical_costs = yn_pay_medical_costs.ynna_id
                                LEFT JOIN lst_yes_no_not_applicable  yn_pay_medical_costs_no_pepfar_grant ON dt.yn_pay_medical_costs_no_pepfar_grant = yn_pay_medical_costs_no_pepfar_grant.ynna_id
                                LEFT JOIN lst_yes_no_not_applicable yn_pay_medical_costs_no_sell_asset ON dt.yn_pay_medical_costs_no_sell_asset = yn_pay_medical_costs_no_sell_asset.ynna_id
                                WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "06":
                    strSQL = @"SELECT  gat_b_id,gat_id,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,ISNULL(yn_kicked.ynna_name,'') AS yn_kicked,ISNULL(yn_child_kicked.ynna_name,'') AS yn_child_kicked,ISNULL(yn_child_violence.ynna_name,'') AS yn_child_violence
                            FROM [dbo].[hh_graduation_assessment_benchmark06] dt
                            INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                            LEFT JOIN lst_yes_no_not_applicable yn_kicked ON dt.yn_kicked = yn_kicked.ynna_id
                            LEFT JOIN lst_yes_no_not_applicable yn_child_kicked ON dt.yn_child_kicked = yn_child_kicked.ynna_id
                            LEFT JOIN lst_yes_no_not_applicable yn_child_violence ON dt.yn_child_violence = yn_child_violence.ynna_id
                            WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "07":
                    strSQL = @"SELECT  gat_b_id,gat_id,yn_stable_caregiver.ynna_name AS yn_stable_caregiver FROM [dbo].[hh_graduation_assessment_benchmark07] dt
                            INNER JOIN lst_yes_no_not_applicable yn_stable_caregiver ON dt.yn_stable_caregiver = yn_stable_caregiver.ynna_id
                            WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
                    break;
                case "08":
                    strSQL = @"SELECT gat_b_id,gat_id,yn_children_enrolled_in_school.ynna_name AS yn_children_enrolled_in_school,yn_atte_school_regualarly.ynna_name AS yn_atte_school_regualarly,yn_progress_next_level.ynna_name AS yn_progress_next_level
                                FROM [dbo].[hh_graduation_assessment_benchmark08] dt
                                INNER JOIN lst_yes_no_not_applicable yn_children_enrolled_in_school ON dt.yn_children_enrolled_in_school = yn_children_enrolled_in_school.ynna_id
                                INNER JOIN lst_yes_no_not_applicable yn_atte_school_regualarly ON dt.yn_atte_school_regualarly = yn_atte_school_regualarly.ynna_id
                                INNER JOIN lst_yes_no_not_applicable yn_progress_next_level ON dt.yn_progress_next_level = yn_progress_next_level.ynna_id
                                WHERE gat_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_id);
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


        public static DataTable LoadRecordDetails(string gat_b_id,string benchMark)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            switch (benchMark)
            {
                case "01":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark01] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "02":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark02] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "03":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark03] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "04":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark04] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "05":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark05] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "06":
                    strSQL = @"SELECT dt.*, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM [dbo].[hh_graduation_assessment_benchmark06] dt
                                INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                                WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "07":
                    strSQL = @"SELECT* FROM [dbo].[hh_graduation_assessment_benchmark07] WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
                    break;
                case "08":
                    strSQL = @"SELECT* FROM [dbo].[hh_graduation_assessment_benchmark08] WHERE gat_b_id = '{0}'";

                    strSQL = string.Format(strSQL, gat_b_id);
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

        public static DataTable LoadHouseholdBenchMarks(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @"SELECT* FROM hh_graduation_assessment_final WHERE gat_id = '{0}'";
            strSQL = string.Format(strSQL, gat_id);
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

        public static DataTable LoadGATDetails(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = @"SELECT* FROM hh_graduation_assessment WHERE gat_id = '{0}'";
            strSQL = string.Format(strSQL, gat_id);
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


        public static string LoadBenchMark7ID(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string str_id = string.Empty;

            string strSQL = @"SELECT gat_b_id FROM [dbo].[hh_graduation_assessment_benchmark07] WHERE gat_id = '{0}'";

            strSQL = string.Format(strSQL, gat_id);
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
                        str_id = dtRow["gat_b_id"].ToString();
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

            return str_id;
        }



        public static string LoadGatFinalID(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string str_id = string.Empty;

            string strSQL = @"  SELECT gat_id FROM hh_graduation_assessment_final WHERE gat_id = '{0}'";

            strSQL = string.Format(strSQL, gat_id);
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
                        str_id = dtRow["gat_id"].ToString();
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

            return str_id;
        }


        public static string LoadBenchMark8ID(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string str_id = string.Empty;

            string strSQL = @"SELECT gat_b_id FROM [dbo].[hh_graduation_assessment_benchmark08] WHERE gat_id = '{0}'";

            strSQL = string.Format(strSQL, gat_id);
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
                        str_id = dtRow["gat_b_id"].ToString();
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

            return str_id;
        }

        public static string LoadBenchMark5ID(string gat_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string str_id = string.Empty;

            string strSQL = @"SELECT gat_b_id FROM [dbo].[hh_graduation_assessment_benchmark05] WHERE gat_id = '{0}'";

            strSQL = string.Format(strSQL, gat_id);
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
                        str_id = dtRow["gat_b_id"].ToString();
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

            return str_id;
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
                                WHERE (yn_children_enrolled_in_school = 0  OR yn_atte_school_regualarly = 0 OR yn_progress_next_level = 0) AND gat_id = '{0}'";
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

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (hst_id = '1' OR hst_id_new = '1') AND hh_id = '{0}' AND hhm_status = '1'";

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

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >=10 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id = '{0}' AND hhm_status = '1'";

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

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) < 5 AND hh_id = '{0}' AND hhm_status = '1'";

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

            strSQL = "SELECT COUNT(*) FROM hh_household_member WHERE (YEAR(GETDATE()) - hhm_year_of_birth) >= 6 AND (YEAR(GETDATE()) - hhm_year_of_birth) <= 17 AND hh_id = '{0}' AND hhm_status = '1'";

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
            string strSQLDelete = string.Empty;

            switch (benchmark)
            {
                case "01":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete,gat_id);
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
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark02 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark02);
                    break;
                case "03":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark03 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark03);
                    break;

                case "04":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark04 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark04);
                    break;
                case "05":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark05 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark05);
                    break;
                case "06":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark06 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark06);
                    break;
                case "07":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark07 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark07);
                    break;
                case "08":
                    strSQLDelete = "DELETE FROM hh_graduation_assessment_final_upload WHERE gat_id = '{0}' ";
                    strSQLDelete = string.Format(strSQLDelete, gat_id);

                    strSQL = @"UPDATE [dbo].[hh_graduation_assessment_final] SET yn_met_benchmark08 = '{1}'
                                WHERE gat_id = '{0}'";
                    strSQL = string.Format(strSQL, gat_id, yn_met_benchmark08);
                    break;
            }

            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(strSQLDelete, conn))
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

        public static string Check_if_prev_benchmark_saved(string gat_id,string benchMark)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string str_id = string.Empty;

            string strSQL = @"SELECT* FROM hh_graduation_assessment_final WHERE gat_id = '{0}'";

            strSQL = string.Format(strSQL, gat_id);
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
                        switch (benchMark)
                        {
                            case "yn_met_benchmark02":
                                str_id = dtRow["yn_met_benchmark01"].ToString();
                                break;
                            case "yn_met_benchmark03":
                                str_id = dtRow["yn_met_benchmark02"].ToString();
                                break;
                            case "yn_met_benchmark04":
                                str_id = dtRow["yn_met_benchmark03"].ToString();
                                break;
                            case "yn_met_benchmark05":
                                str_id = dtRow["yn_met_benchmark04"].ToString();
                                break;
                            case "yn_met_benchmark06":
                                str_id = dtRow["yn_met_benchmark05"].ToString();
                                break;
                            case "yn_met_benchmark07":
                                str_id = dtRow["yn_met_benchmark06"].ToString();
                                break;
                            case "yn_met_benchmark08":
                                str_id = dtRow["yn_met_benchmark07"].ToString();
                                break;
                        }
                        
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

            return str_id;
        }

    }
}
