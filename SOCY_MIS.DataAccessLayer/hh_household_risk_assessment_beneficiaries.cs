using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public class hh_household_risk_assessment_beneficiaries
    {
        #region varibales
        public static string ras_id = string.Empty;
        public static string rasm_id = string.Empty;
        public static string hh_member_id = string.Empty;
        public static string hh_member_code = string.Empty;
        public static string current_hiv_status_id = string.Empty;
        public static string is_on_art = string.Empty;
        public static string screen_hospital_last_six_months = string.Empty;
        public static string screen_either_parents_deceased = string.Empty;
        public static string screen_either_siblings_deceased = string.Empty;
        public static string screen_poor_health_last_three_months = string.Empty;
        public static string screen_adult_child_with_hiv_or_tb = string.Empty;
        public static string screen_below_relative_grade = string.Empty;
        public static string child_eligible_for_test_refferal = string.Empty;
        public static string care_giver_accepted_to_test_child = string.Empty;
        public static string test_result = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        public static string yn_accidental_exposure = string.Empty; 
        public static string yn_drug_abuse = string.Empty;
        #endregion varibales

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection


        //return hh member code
        public static DataTable Return_hhm_details(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;

            string SQL = @"  SELECT (H.hh_code + '/' + HHM.hhm_number) AS hhm_code,HHM.hhm_year_of_birth,G.gnd_name
                            FROM hh_household_member HHM
                            LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                            LEFT JOIN lst_gender G ON HHM.gnd_id = G.gnd_id
                            WHERE HHM.hhm_id = '{0}'";
            try
            {
                string strConn = dbCon.ToString();
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

        //save risk assement register member details
        #region save hh member risk assessment details
        public static void save_update_hhm_risk_assessment_details_member(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"INSERT INTO[dbo].[hh_household_risk_assessment_beneficiaries]
                       ([ras_id],[rasm_id],[hh_member_id],[hh_member_code],[current_hiv_status_id],[is_on_art],[screen_hospital_last_six_months]
                       ,[screen_either_parents_deceased],[screen_either_siblings_deceased],[screen_poor_health_last_three_months] ,[screen_adult_child_with_hiv_or_tb]
                       ,[screen_below_relative_grade],[child_eligible_for_test_refferal],[care_giver_accepted_to_test_child],[test_result],[usr_id_create],[usr_id_update],
		               [usr_date_create],[usr_date_update],[ofc_id],[district_id],[yn_accidental_exposure],[yn_drug_abuse])
                        VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')";

            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[hh_household_risk_assessment_beneficiaries]
                              SET [hh_member_id] = '{1}' ,[hh_member_code] = '{2}'
                              ,[current_hiv_status_id] = '{3}',[is_on_art] = '{4}'
                              ,[screen_hospital_last_six_months] = '{5}',[screen_either_parents_deceased] = '{6}'
                              ,[screen_either_siblings_deceased] = '{7}',[screen_poor_health_last_three_months] = '{8}'
                              ,[screen_adult_child_with_hiv_or_tb] = '{9}',[screen_below_relative_grade] = '{10}'
                              ,[child_eligible_for_test_refferal] = '{11}' ,[care_giver_accepted_to_test_child] = '{12}'
                              ,[test_result] = '{13}',[usr_id_update] = '{14}',[usr_date_update] = GETDATE(),
                               [yn_accidental_exposure] = '{15}',[yn_drug_abuse] = '{16}'
                         WHERE [rasm_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ras_id, rasm_id, hh_member_id, hh_member_code, current_hiv_status_id, is_on_art, screen_hospital_last_six_months,
                        screen_either_parents_deceased, screen_either_siblings_deceased, screen_poor_health_last_three_months, screen_adult_child_with_hiv_or_tb,
                        screen_below_relative_grade, child_eligible_for_test_refferal, care_giver_accepted_to_test_child, test_result, usr_id_create, usr_id_update,
                        usr_date_create, usr_date_update, ofc_id, district_id, yn_accidental_exposure, yn_drug_abuse);
                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, rasm_id, hh_member_id, hh_member_code, current_hiv_status_id, is_on_art, screen_hospital_last_six_months, screen_either_parents_deceased,
                        screen_either_siblings_deceased, screen_poor_health_last_three_months, screen_adult_child_with_hiv_or_tb, screen_below_relative_grade,
                        child_eligible_for_test_refferal, care_giver_accepted_to_test_child, test_result, usr_id_update, yn_accidental_exposure, yn_drug_abuse);

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
                    else if (action == "update")
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

        #endregion save hh member risk assessment details

        #region HH Member Risk assessment details
        public static DataTable Return_hhm_ras_details(string hhm_id, string ras_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;

            string SQL = @"SELECT [ras_id],[rasm_id],[hh_member_id] ,[hh_member_code] ,[current_hiv_status_id]
                          ,[is_on_art],[screen_hospital_last_six_months],[screen_either_parents_deceased] ,[screen_either_siblings_deceased]
                          ,[screen_poor_health_last_three_months],[screen_adult_child_with_hiv_or_tb],[screen_below_relative_grade],[child_eligible_for_test_refferal]
                          ,[care_giver_accepted_to_test_child],[test_result],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update]
                          ,[ofc_id],[district_id],[yn_accidental_exposure],[yn_drug_abuse]
                         FROM [dbo].[hh_household_risk_assessment_beneficiaries]
                         WHERE [hh_member_id] = '{0}' AND [ras_id] = '{1}' ";
            try
            {
                string strConn = dbCon.ToString();
                SQL = string.Format(SQL, hhm_id, ras_id);

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

        #endregion HH Member Risk assessment details

        #region List of members assessed by assessment ID
        public static DataTable Return_hhm_ras_member_list(string ras_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;

            string SQL = @"SELECT (H.hhm_first_name + ' ' + H.hhm_last_name) AS hhm_name,HHM.hh_member_id
                          FROM hh_household_risk_assessment_beneficiaries HHM
                          LEFT JOIN hh_household_member H ON HHM.hh_member_id = H.hhm_id
                          WHERE ras_id = '{0}'";
            try
            {
                string strConn = dbCon.ToString();
                SQL = string.Format(SQL, ras_id);

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

        #endregion List of members assessed by assessment ID

    }
}
