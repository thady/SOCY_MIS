using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class silcCommunityTrainingRegister
    {
        #region Variables
        public static string ctr_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string dst_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string tr_name = string.Empty;
        public static string module_name = string.Empty;
        public static string tr_total_days = string.Empty;
        public static DateTime tr_date_from = DateTime.Now;
        public static DateTime tr_date_to = DateTime.Now;
        public static string module_desc = string.Empty;
        public static string tr_venue = string.Empty;
        public static string trainer_type = string.Empty;
        public static string artisan_name = string.Empty;
        public static string facilitator_trainer_name = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion Variables

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        public static DataTable Return_lookups(string lookup_type,string id,string dst_id,string sct_id,string wrd_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (lookup_type)
                {
                    case "district":
                        SQL = "SELECT dst_id, dst_name FROM lst_district";
                        break;
                    case "subcounty":
                        if (id != string.Empty)
                        {
                            SQL = "SELECT sct_id,sct_name FROM lst_sub_county WHERE dst_id = '" + id + "'";
                        }else
                        {
                            SQL = "SELECT sct_id,sct_name FROM lst_sub_county";
                        }
                        break;
                    case "parish":
                        SQL = "SELECT wrd_id,wrd_name FROM lst_ward";
                        break;
                    case "IP":
                        SQL = "SELECT prt_id,prt_name FROM lst_partner";
                        break;
                    case "services_provided":
                        SQL = "SELECT linkages_service_id,service_name FROM lst_linkages_services_provided";
                        break;
                    case "services_required":
                        SQL = " SELECT linkages_service_offered_id,service_name FROM lst_linkages_services_required";
                        break;
                    case "CSO":
                        if (id != string.Empty)
                        {
                            SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso WHERE prt_id = '" + id + "'";
                        }
                        else
                        {
                            SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso";
                        }
                        break;
                    case "gender":
                        SQL = "  SELECT gnd_id,gnd_name FROM lst_gender";
                        break;
                    case "hh_codes":
                        SQL = @"SELECT (H.hh_code + '-' + HHM.hhm_number) AS hhm_code,hhm_id  FROM hh_household_member HHM
                                LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                                WHERE H.hh_id = '{0}'
                                AND (YEAR(GETDATE()) - HHM.hhm_year_of_birth) >= 14 AND (YEAR(GETDATE()) - HHM.hhm_year_of_birth) <= 24";
                        SQL = string.Format(SQL, id);
                        break;
                    case "HouseHoldCode":
                        SQL = @"SELECT H.hh_code ,H.hh_id FROM hh_household H
                                LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_sid
                                LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                                LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                                WHERE D.dst_id = '{0}'
                                AND S.sct_id = '{1}'
                                AND W.wrd_id = '{2}'
                                ORDER BY H.hh_code ASC";
                        SQL = string.Format(SQL, dst_id, sct_id,wrd_id); 
                        break;
                    case "TrainingDetails":
                        SQL = @"SELECT [ctr_id],[prt_id],[cso_id],[dst_id],[sct_id],[tr_name]
                                  ,[module_name],[tr_total_days],[tr_date_from] ,[tr_date_to]
                                  ,[module_desc],[tr_venue],[trainer_type],[artisan_name] ,[facilitator_trainer_name],[ofc_id]
                              FROM silc_community_training_register WHERE ctr_id = '{0}'";
                        SQL = string.Format(SQL, id);
                        break;
                    case "TrainingParticipants":
                        SQL = @"SELECT ctrm_id,ben_type,hhm_code,parcipant_name,gnd_id,age
                              FROM silc_community_training_register_member 
                              WHERE ctr_id = '{0}'";
                        SQL = string.Format(SQL, id);
                        break;
                    case "AttendanceDates":
                        SQL = @" SELECT date FROM silc_community_training_register_member_attendance_dates
                                WHERE ctrm_id = '{0}' ORDER BY date ASC";
                        SQL = string.Format(SQL, id);
                        break;
                    case "TrainingList":
                        SQL = @"SELECT R.ctr_id,T.ttp_name,D.dst_name,S.sct_name,P.prt_name,C.cso_name FROM silc_community_training_register R
                                LEFT JOIN lst_partner P ON R.prt_id = P.prt_id
                                LEFT JOIN lst_cso C ON R.cso_id = C.cso_id
                                LEFT JOIN lst_district D ON R.dst_id = D.dst_id
                                LEFT JOIN lst_sub_county S ON R.sct_id = S.sct_id
                                LEFT JOIN lst_es_training_type T ON R.tr_name = T.ttp_id";
                        break;
                    case "hhm_details":
                        SQL = @"SELECT (HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name,G.gnd_id,HHM.hhm_year_of_birth
                            FROM hh_household_member HHM
                            LEFT JOIN lst_gender G ON HHM.gnd_id = G.gnd_id
                            WHERE HHM.hhm_id = '{0}' ";
                        SQL = string.Format(SQL, id);
                        break;
                    case "hhm_details_communityTrainingRegister":
                        SQL = @"SELECT (HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name,G.gnd_id,HHM.hhm_year_of_birth,(H.hh_code + '/' + HHM.hhm_number) AS hhm_number
                            FROM hh_household_member HHM
                            LEFT JOIN lst_gender G ON HHM.gnd_id = G.gnd_id
                            LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                            WHERE HHM.hhm_id = '{0}' ";
                        SQL = string.Format(SQL, id);
                        break;
                    case "hhm_codes_communityTrainingRegister":
                        SQL = @"SELECT (H.hh_code + '-' + HHM.hhm_number) AS hhm_code,hhm_id  FROM hh_household_member HHM
                                LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                                WHERE H.hh_id = '{0}'";
                        SQL = string.Format(SQL, id);
                        break;

                    case "EducationSubsidyMembers":
                        SQL = @"SELECT hhm_id,(HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name   FROM hh_household_member HHM
                                LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                                WHERE H.hh_id = '{0}'";
                        SQL = string.Format(SQL, id);
                        break;
                    case "hhm":
                        SQL = @"SELECT hhm_id, H.hh_code + '-' + hhm.hhm_number AS hhm_code FROM hh_household_member hhm
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                            WHERE H.hh_id = '{0}'";
                        SQL = string.Format(SQL, id);
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

        public static DataTable Return_lookups(string lookup_type, string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (lookup_type)
                {
                    case "TrainingType":
                        SQL = "SELECT ttp_name,ttp_id FROM lst_es_training_type";
                        break;
                    case "TrainingTypeSession":
                        if (id != string.Empty)
                        {
                            SQL = "SELECT ttps_name,ttps_id FROM lst_es_training_type_session WHERE ttp_id = '" + id + "' ";

                        }
                        else
                        {
                            SQL = "SELECT ttps_name,ttps_id FROM lst_es_training_type_session";
                        }
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

        #region Save Training Details
        public static string save_update_Training_details(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ctr_id nvarchar(150)) INSERT INTO [dbo].[silc_community_training_register]
           ([ctr_id],[prt_id],[cso_id],[dst_id],[sct_id],[tr_name],[module_name],[tr_total_days]
           ,[tr_date_from],[tr_date_to],[module_desc],[tr_venue] ,[trainer_type],[artisan_name],[facilitator_trainer_name]
           ,[usr_id_create] ,[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) OUTPUT INSERTED.[ctr_id] INTO @tempTable
           VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')
            SELECT ctr_id FROM @tempTable";

            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[silc_community_training_register]
                       SET [prt_id] ='{1}',[cso_id] = '{2}',[dst_id] = '{3}',[sct_id] = '{4}',[tr_name] = '{5}'
                          ,[module_name] = '{6}' ,[tr_total_days] = '{7}',[tr_date_from] = '{8}' ,[tr_date_to] = '{9}',[module_desc] = '{10}'
                          ,[tr_venue] = '{11}',[trainer_type] = '{12}',[artisan_name] = '{13}' ,[facilitator_trainer_name] = '{14}' ,[usr_id_update] = '{15}'
                          ,[usr_date_update] = '{16}'
                     WHERE ctr_id = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ctr_id, prt_id, cso_id, dst_id, sct_id, tr_name, module_name, tr_total_days, tr_date_from, tr_date_to,module_desc,tr_venue,
                        trainer_type,artisan_name,facilitator_trainer_name,usr_id_create,usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ctr_id, prt_id, cso_id, dst_id, sct_id, tr_name, module_name, tr_total_days, tr_date_from, tr_date_to, module_desc, tr_venue,
                        trainer_type, artisan_name, facilitator_trainer_name, usr_id_update, usr_date_update);

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
        #endregion Save Training Details

        #region Search Training Lists
        public static DataTable SearchTrainingList(string dst_id, string sct_id,string prt_id,string cso_id,string tr_name)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT R.ctr_id,T.ttp_name,D.dst_name,S.sct_name,P.prt_name,C.cso_name FROM silc_community_training_register R
                         LEFT JOIN lst_partner P ON R.prt_id = P.prt_id
                         LEFT JOIN lst_cso C ON R.cso_id = C.cso_id
                         LEFT JOIN lst_district D ON R.dst_id = D.dst_id
                         LEFT JOIN lst_sub_county S ON R.sct_id = S.sct_id
                         LEFT JOIN lst_es_training_type T ON R.tr_name = T.ttp_id
                         WHERE (@dst_id = '-1' OR R.dst_id = @dst_id )
                         AND (@sct_id = '-1' OR R.sct_id = @sct_id)
                         AND (@prt_id = '-1' OR R.prt_id = @prt_id)
                         AND (@cso_id = '-1' OR R.cso_id = @cso_id)
                        AND (@tr_name = '' OR tr_name LIKE '%' + @tr_name  + '%')
                        ";
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar,50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@prt_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@prt_id"].Value = prt_id;

                    cmd.Parameters.Add("@cso_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@cso_id"].Value = cso_id;

                    cmd.Parameters.Add("@tr_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@tr_name"].Value = tr_name;

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
        #endregion Search Traaining Lists
    }
}
