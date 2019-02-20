using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class GBV_screeningTool
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string gbv_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string gbv_screen_officer = string.Empty;
        public static DateTime gbv_screen_date = DateTime.Today;
        public static string hh_tel = string.Empty;
        public static string yn_sexual_rape = string.Empty;
        public static string yn_sexual_defilement = string.Empty;
        public static string yn_sexual_attempt_defilement = string.Empty;
        public static string yn_sexual_harrassment = string.Empty;
        public static string yn_phy_threat = string.Empty;
        public static string yn_phy_assault = string.Empty;
        public static string yn_phy_deprived_food = string.Empty;
        public static string yn_phy_child_labor = string.Empty;
        public static string yn_phy_sleepout = string.Empty;
        public static string yn_econ_not_spend = string.Empty;
        public static string yn_econ_denied_edu_support = string.Empty;
        public static string yn_econ_denial_resources = string.Empty;
        public static string yn_econ_disposed_shelter = string.Empty;
        public static string yn_emo_verbal_abuse = string.Empty;
        public static string yn_econ_non_verbal_abuse = string.Empty;
        public static string yn_up_know_to_seek_help = string.Empty;
        public static string yn_up_seek_help = string.Empty;
        public static string help_source = string.Empty;
        public static string gbv_case_status = string.Empty;
        public static string yn_satisfied_outcome = string.Empty;
        public static string yn_other_emer_support = string.Empty;
        public static string yn_other_nutrition = string.Empty;
        public static string yn_hiv_testing = string.Empty;
        public static string yn_pep = string.Empty;
        public static string yn_counselling = string.Empty;
        public static string yn_shelter = string.Empty;
        public static string yn_reffered = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        #endregion Variables

        #region save
        public static void save(string action)
        {
            string SQL = string.Empty;
            switch (action)
            {
                #region insert
                case "insert":
                    SQL = @"INSERT INTO [dbo].[ben_gbv_screening]
                               ([gbv_id],[wrd_id],[hhm_id],[gbv_screen_officer],[gbv_screen_date],[hh_tel],[yn_sexual_rape],[yn_sexual_defilement],[yn_sexual_attempt_defilement],[yn_sexual_harrassment]
                               ,[yn_phy_threat] ,[yn_phy_assault],[yn_phy_deprived_food] ,[yn_phy_child_labor],[yn_phy_sleepout],[yn_econ_not_spend],[yn_econ_denied_edu_support],[yn_econ_denial_resources]
                               ,[yn_econ_disposed_shelter],[yn_emo_verbal_abuse],[yn_econ_non_verbal_abuse],[yn_up_know_to_seek_help],[yn_up_seek_help] ,[help_source],[gbv_case_status] ,[yn_satisfied_outcome]
                               ,[yn_other_emer_support],[yn_other_nutrition],[yn_hiv_testing],[yn_pep],[yn_counselling] ,[yn_shelter],[yn_reffered],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update]
                               ,[ofc_id],[district_id])
                         VALUES  ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}' ,'{9}','{10}','{11}' ,'{12}','{13}','{14}' ,'{15}' ,'{16}' ,'{17}','{18}','{19}','{20}','{21}' ,'{22}' ,'{23}' ,'{24}'
                               ,'{25}' ,'{26}' ,'{27}' ,'{28}' ,'{29}','{30}' ,'{31}' ,'{32}','{33}' ,'{34}',GETDATE() ,GETDATE(),'{35}' ,'{36}')";
                    SQL = string.Format(SQL, gbv_id, wrd_id, hhm_id, gbv_screen_officer, gbv_screen_date, hh_tel, yn_sexual_rape, yn_sexual_defilement, yn_sexual_attempt_defilement, yn_sexual_harrassment
                                       , yn_phy_threat, yn_phy_assault, yn_phy_deprived_food, yn_phy_child_labor, yn_phy_sleepout, yn_econ_not_spend, yn_econ_denied_edu_support, yn_econ_denial_resources
                                       , yn_econ_disposed_shelter, yn_emo_verbal_abuse, yn_econ_non_verbal_abuse, yn_up_know_to_seek_help, yn_up_seek_help, help_source, gbv_case_status, yn_satisfied_outcome
                                       , yn_other_emer_support, yn_other_nutrition, yn_hiv_testing, yn_pep, yn_counselling, yn_shelter, yn_reffered, usr_id_create, usr_id_update, ofc_id, district_id);

                    break;
                #endregion


                #region update
                case "update":
                    SQL = @"UPDATE [dbo].[ben_gbv_screening]
                           SET [hhm_id] = '{1}'
                              ,[gbv_screen_officer] = '{2}'
                              ,[gbv_screen_date] = '{3}'
                              ,[hh_tel] = '{4}'
                              ,[yn_sexual_rape] = '{5}'
                              ,[yn_sexual_defilement] = '{6}'
                              ,[yn_sexual_attempt_defilement] = '{7}'
                              ,[yn_sexual_harrassment] = '{8}'
                              ,[yn_phy_threat] = '{9}'
                              ,[yn_phy_assault] = '{10}'
                              ,[yn_phy_deprived_food] = '{11}'
                              ,[yn_phy_child_labor] = '{12}'
                              ,[yn_phy_sleepout] = '{13}'
                              ,[yn_econ_not_spend] = '{14}'
                              ,[yn_econ_denied_edu_support] = '{15}'
                              ,[yn_econ_denial_resources] = '{16}'
                              ,[yn_econ_disposed_shelter] = '{17}'
                              ,[yn_emo_verbal_abuse] = '{18}'
                              ,[yn_econ_non_verbal_abuse] = '{19}'
                              ,[yn_up_know_to_seek_help] = '{20}'
                              ,[yn_up_seek_help] = '{21}'
                              ,[help_source] = '{22}'
                              ,[gbv_case_status] = '{23}'
                              ,[yn_satisfied_outcome] = '{24}'
                              ,[yn_other_emer_support] = '{25}'
                              ,[yn_other_nutrition] = '{26}'
                              ,[yn_hiv_testing] = '{27}'
                              ,[yn_pep] = '{28}'
                              ,[yn_counselling] = '{29}'
                              ,[yn_shelter] = '{30}'
                              ,[yn_reffered] = '{31}'
                              ,[usr_id_update] = '{32}'
                              ,[usr_date_update] = GETDATE()
                         WHERE [gbv_id] = '{0}'";

                    SQL = string.Format(SQL, gbv_id,hhm_id, gbv_screen_officer, gbv_screen_date, hh_tel, yn_sexual_rape, yn_sexual_defilement, yn_sexual_attempt_defilement, yn_sexual_harrassment
                                       , yn_phy_threat, yn_phy_assault, yn_phy_deprived_food, yn_phy_child_labor, yn_phy_sleepout, yn_econ_not_spend, yn_econ_denied_edu_support, yn_econ_denial_resources
                                       , yn_econ_disposed_shelter, yn_emo_verbal_abuse, yn_econ_non_verbal_abuse, yn_up_know_to_seek_help, yn_up_seek_help, help_source, gbv_case_status, yn_satisfied_outcome
                                       , yn_other_emer_support, yn_other_nutrition, yn_hiv_testing, yn_pep, yn_counselling, yn_shelter, yn_reffered, usr_id_update);
                    break;
                    #endregion


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

                    cmd.ExecuteNonQuery();

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
        #endregion save

        public static DataTable ReturnHHDetails(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT H.hh_id,W.wrd_id,sct.sct_id,dst.dst_id,H.hh_village,I.cso_id,prt.prt_id FROM hh_household H
                        LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_id
                        LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        LEFT JOIN hh_ovc_identification_prioritization I ON H.hh_id = I.hh_id
                        LEFT JOIN lst_cso cso ON I.cso_id = cso.cso_id
                        LEFT JOIN lst_partner prt ON cso.prt_id = prt.prt_id
                        WHERE H.hh_id = '{0}'";

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

        public static DataTable ReturnLists(string Table,string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (Table)
                {
                    case "lst_gbv_service":
                        SQL = @"SELECT [gbv_sr_id] ,[gbv_sr_name] FROM lst_gbv_service";
                        break;
                    case "lst_gbv_service_status":
                        SQL = @"SELECT [gbv_st_id] ,[gbv_st_name] FROM lst_gbv_service_status";
                        break;
                    case "hhm":
                        SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id
                                FROM hh_household_member WHERE hh_id = '{0}'";
                        SQL = string.Format(SQL,id);
                        break;
                       
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

        public static DataTable LoadDisplay(string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = "SELECT* FROM ben_gbv_screening WHERE gbv_id = '{0}'";
                SQL = string.Format(SQL,id);

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
