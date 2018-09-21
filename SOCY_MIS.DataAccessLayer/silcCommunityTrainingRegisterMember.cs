using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class silcCommunityTrainingRegisterMember
    {
        #region Variables
        public static string ctrm_id = string.Empty;
        public static string ctr_id = string.Empty;
        public static string ben_type = string.Empty;
        public static string hhm_code = string.Empty;
        public static string parcipant_name = string.Empty;
        public static string gnd_id = string.Empty;
        public static string age = string.Empty;
        public static DateTime date = DateTime.Today;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string ctrmD_id = string.Empty;
        

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #endregion Variables

        #region Save Partcipant
        public static string save_update_Participant_details(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ctr_id nvarchar(150))INSERT INTO [dbo].[silc_community_training_register_member]
           ([ctrm_id],[ctr_id],[ben_type] ,[hhm_code],[parcipant_name],[gnd_id],[age] ,[usr_id_create]
           ,[usr_id_update] ,[usr_date_create] ,[usr_date_update],[ofc_id],[district_id])  OUTPUT INSERTED.[ctrm_id] INTO @tempTable
           VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
           SELECT ctr_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[silc_community_training_register_member]
                           SET [ben_type] = '{1}',[hhm_code] = '{2}'
                              ,[parcipant_name] = '{3}' ,[gnd_id] = '{4}',[age] = '{5}'
                              ,[usr_id_update] = '{6}',[usr_date_update] = '{7}'
                         WHERE [ctrm_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ctrm_id, ctr_id, ben_type, hhm_code, parcipant_name, gnd_id, age, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ctrm_id,ben_type, hhm_code, parcipant_name, gnd_id, age, usr_id_update, usr_date_update);

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
                        ctr_id = (string)cmd.ExecuteScalar();
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
                return ctr_id;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string save_update_Participant_attendance_dates(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"IF NOT EXISTS (SELECT ctrm_id,date FROM silc_community_training_register_member_attendance_dates
                          WHERE ctrm_id = '{0}' AND date = '{1}')
	                        BEGIN
	                        INSERT INTO silc_community_training_register_member_attendance_dates(ctrmD_id,ctrm_id,date,ofc_id,district_id)
	                        VALUES('{0}','{1}','{2}','{3}','{4}')
                        END";
            }
            else if (action == "update")
            {
                Query = @"IF NOT EXISTS (SELECT ctrm_id,date FROM silc_community_training_register_member_attendance_dates
                          WHERE ctrm_id = '{0}' AND date = '{1}')
	                        BEGIN
	                        INSERT INTO silc_community_training_register_member_attendance_dates(ctrmD_id,ctrm_id,date,ofc_id,district_id)
	                        VALUES('{0}','{1}','{2}','{3}','{4}')
                        END";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query,ctrmD_id,ctrm_id,date,ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ctrmD_id, ctrm_id, date, ofc_id, district_id);

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
                        ctr_id = (string)cmd.ExecuteScalar();
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
                return ctr_id;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion Save Participant
    }
}
