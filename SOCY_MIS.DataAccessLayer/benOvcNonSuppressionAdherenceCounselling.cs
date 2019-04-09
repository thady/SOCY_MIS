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
        public static string _iac_id = string.Empty;
        public static string iac_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string health_fac_name = string.Empty;
        public static string art_number = string.Empty;
        public static DateTime visit_date = DateTime.Today;
        public static string swk_id = string.Empty;
        public static string lnk_id = string.Empty;
        public static string visit_name = string.Empty;
        public static string yn_ben_supress = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion ben_adherence_counselling

        #region ben_adherence_counselling_non_supress_health_facility
        public static string iacr_id = string.Empty;
        public static string nsph_id = string.Empty;
        public static string nspfac_id = string.Empty;
        public static string nsphh_id = string.Empty;
        #endregion ben_adherence_counselling_non_supress_health_facility

        #region ben_adherence_counselling_non_supress_household
        public static string iacrs_id = string.Empty;
        public static string nsp_household_id = string.Empty;
        public static string nsp_action_id = string.Empty;
        public static DateTime nsp_action_timeline = DateTime.Today;
        public static string nsp_action_progress = string.Empty;
        public static string nsp_action_person_responsible = string.Empty;
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


        public static DataTable ReturnSocialWorkers(string dst_id,string Type)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (Type)
            {
                case "socialWorker":
                    SQL = @"SELECT swk_first_name + ' ' + swk_last_name AS swk_name,swk_id FROM swm_social_worker swk
                    INNER JOIN lst_ward W ON swk.wrd_id = W.wrd_id
                    INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                    INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                    WHERE dst.dst_id = '{0}' AND swt_id = 1 ";
                    SQL = string.Format(SQL, dst_id);
                    break;
                case "Linkage":
                    SQL = @"SELECT lc_id,lc_name FROM lst_linkages_coordinator
                            WHERE dst_id = '{0}'";
                    SQL = string.Format(SQL, dst_id);
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
                        usr_id_update, usr_date_create, usr_date_update,ofc_id,district_id);
                    break;
                case "update":
                    SQL = @"UPDATE [dbo].[ben_adherence_counselling]
                           SET [hhm_id] = '{1}', [health_fac_name] = '{2}'
                              ,[art_number] = '{3}'
                              ,[visit_date] = '{4}'
                              ,[swk_id] = '{5}'
                              ,[lnk_id] = '{6}'
                              ,[visit_name] = '{7}'
                              ,[yn_ben_supress] = '{8}'
                              ,[usr_id_update] = '{9}'
                              ,[usr_date_update] = '{10}'
                         WHERE [iac_id] ='{0}'";
                    SQL = string.Format(SQL, iac_id, hhm_id, health_fac_name, art_number, visit_date, swk_id, lnk_id, visit_name, yn_ben_supress,
                        usr_id_update, usr_date_update);
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


        public static void save_ben_non_supress_reason_health_facility()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"IF NOT EXISTS (SELECT* FROM ben_adherence_counselling_non_supress_health_facility WHERE nspfac_id = '{2}' AND iac_id = '{1}')
	                BEGIN
	                INSERT INTO [dbo].[ben_adherence_counselling_non_supress_health_facility]
                           ([iacr_id],[iac_id],[nspfac_id],[usr_id_create] ,[usr_id_update] ,[usr_date_create],[usr_date_update] ,[ofc_id],[district_id])
                     VALUES ('{0}','{1}', '{2}' ,'{3}','{4}' ,'{5}','{6}','{7}','{8}')
                END";

            SQL = string.Format(SQL, iacr_id, iac_id, nspfac_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

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


        public static void save_ben_adherence_counselling_non_supress_health_household()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"IF NOT EXISTS(SELECT* FROM ben_adherence_counselling_non_supress_health_household WHERE nsphh_id = '{2}' AND iac_id = '{1}')
	                BEGIN
	                INSERT INTO [dbo].[ben_adherence_counselling_non_supress_health_household]
                           ([iacr_id],[iac_id] ,[nsphh_id],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update] ,[ofc_id],[district_id])
                     VALUES ('{0}' ,'{1}' ,'{2}','{3}','{4}' ,'{5}' ,'{6}','{7}','{8}')
                END";

            SQL = string.Format(SQL, iacr_id, iac_id, nsphh_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

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



        public static void save_ben_adherence_counselling_non_supress_household_action()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"IF NOT EXISTS(SELECT* FROM ben_adherence_counselling_non_supress_household_action WHERE iac_id = '{1}' AND iacr_id = '{2}' AND nsp_action_id = '{3}')
		            BEGIN
			            INSERT INTO [dbo].[ben_adherence_counselling_non_supress_household_action]
                       ([iacrs_id],[iac_id],[iacr_id],[nsp_action_id],[nsp_action_timeline],[nsp_action_progress] ,[nsp_action_person_responsible],[usr_id_create]
                       ,[usr_id_update],[usr_date_create] ,[usr_date_update],[ofc_id] ,[district_id])
                 VALUES ('{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}' ,'{11}','{12}')
	            END ELSE BEGIN
	            UPDATE ben_adherence_counselling_non_supress_household_action SET nsp_action_timeline = '{4}',nsp_action_progress = '{5}',nsp_action_person_responsible = '{6}',
	            usr_id_update = '{8}',usr_date_update = GETDATE() WHERE iac_id = '{1}' AND iacr_id = '{2}' AND nsp_action_id = '{3}'
	            END";

            SQL = string.Format(SQL, iacrs_id, iac_id, iacr_id, nsp_action_id, nsp_action_timeline, nsp_action_progress, nsp_action_person_responsible, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

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

        #region LoadDisplay
        public static DataTable LoadDisplay(string iac_id,string returnType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (returnType)
            {
                case "ben_adherence_counselling":
                    SQL = "SELECT* FROM ben_adherence_counselling WHERE iac_id = '{0}'";
                    SQL = string.Format(SQL, iac_id);
                    break;
                case "ben_adherence_counselling_non_supress_health_facility":
                    SQL = @"SELECT nspfac_id,L.nsp_name FROM ben_adherence_counselling_non_supress_health_facility F
                            INNER JOIN lst_non_supress_health_facility L ON F.nspfac_id = L.nsp_id WHERE iac_id = '{0}'";

                    SQL = string.Format(SQL, iac_id);
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


        public static DataTable LoadDisplayLine(string iac_id, string iacr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            SQL = @"SELECT hh.nsp_name AS [Reason for non suppression],AA.nspa_name AS [Action Taken],A.nsp_action_timeline AS [Agreed Timeline],A.nsp_action_progress AS [Action Progress],A.nsp_action_person_responsible AS [Person Responsible] FROM ben_adherence_counselling_non_supress_household_action A
                    INNER JOIN lst_non_supress_household hh ON A.iacr_id = hh.nsp_id
                    INNER JOIN lst_non_supress_action AA ON A.nsp_action_id = AA.nspa_id
                    WHERE A.iac_id = '{0}' AND iacr_id = '{1}'";

            SQL = string.Format(SQL,iac_id, iacr_id);
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
        #endregion
    }
}
