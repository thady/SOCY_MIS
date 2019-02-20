using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benOvcNonSuppressionAdherenceCounselling
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection


        #region Variables

        #region ben_adherence_counselling
        static string iac_id = string.Empty;
        static string hhm_id = string.Empty;
        static string health_fac_name = string.Empty;
        static string art_number = string.Empty;
        static DateTime visit_date = DateTime.Today;
        static string swk_id = string.Empty;
        static string lnk_id = string.Empty;
        static string visit_name = string.Empty;
        static string yn_ben_supress = string.Empty;
        static string usr_id_create = string.Empty;
        static string usr_id_update = string.Empty;
        static DateTime usr_date_create = DateTime.Today;
        static DateTime usr_date_update = DateTime.Today;
        static string ofc_id = string.Empty;
        static string district_id = string.Empty;
        #endregion ben_adherence_counselling

        #region ben_adherence_counselling_non_supress_health_facility
        static string iacr_id = string.Empty;
        static string nsph_id = string.Empty;
        #endregion ben_adherence_counselling_non_supress_health_facility

        #region ben_adherence_counselling_non_supress_household
        static string iacrs_id = string.Empty;
        static string nsp_household_id = string.Empty;
        static string nsp_action_id = string.Empty;
        static string nsp_action_timeline = string.Empty;
        static string nsp_action_progress = string.Empty;
        static string nsp_action_person_responsible = string.Empty;
        #endregion ben_adherence_counselling_non_supress_household



        #endregion

        public static DataTable ReturnLists(string Table)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (Table)
            {
                case "lst_non_supress_health_facility":
                    SQL = "SELECT [nsp_id],[nsp_name] FROM lst_non_supress_health_facility";
                    break;
                case "lst_non_supress_household":
                    SQL = "SELECT [nsp_id],[nsp_name] FROM lst_non_supress_household";
                    break;
                case "lst_non_supress_action":
                    SQL = "SELECT [nspa_id],[nspa_name],GETDATE() AS time_line FROM lst_non_supress_action";
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


        public static void save_ben_adherence_counselling(string action)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (action)
            {
                case "insert":
                    SQL = @"INSERT INTO [dbo].[ben_adherence_counselling]
                           ([iac_id],[hhm_id],[health_fac_name],[art_number],[visit_date],[swk_id],[lnk_id],[visit_name],[yn_ben_supress]
                           ,[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                     VALUES('{0}','{1}','{2}' ,'{3}','{4}','{5}','{6}','{7}','{8}','{9}' ,'{10}','{11}','{12}','{13}','{14}')";
                    SQL = string.Format(SQL, iac_id, hhm_id, health_fac_name, art_number, visit_date, swk_id, lnk_id, visit_name, yn_ben_supress, usr_id_create,
                        usr_id_update, usr_date_create, usr_date_update);
                    break;
                case "update":
                    SQL = @"UPDATE [dbo].[ben_adherence_counselling]
                           SET [health_fac_name] = '{1}'
                              ,[art_number] = '{2}'
                              ,[visit_date] = '{3}'
                              ,[swk_id] = '{4}'
                              ,[lnk_id] = '{5}'
                              ,[visit_name] = '{6}'
                              ,[yn_ben_supress] = '{7}'
                              ,[usr_id_create] = '{8}'
                              ,[usr_id_update] = '{9}'
                              ,[usr_date_create] = '{10}'
                              ,[usr_date_update] = '{11}'
                              ,[ofc_id] = '{12}'
                              ,[district_id] = '{13}'
                         WHERE [iac_id] ='{0}'";
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
        }
    }
}
