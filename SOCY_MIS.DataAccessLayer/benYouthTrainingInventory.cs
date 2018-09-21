using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class benYouthTrainingInventory
    {
        #region Variables
        public static string yti_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string dst_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime begin_date = DateTime.Today;
        public static string hhm_code = string.Empty;
        public static string hhm_name = string.Empty;
        public static string grp_name = string.Empty;
        public static string age = string.Empty;
        public static string gnd_id = string.Empty;
        public static string training_type = string.Empty;
        public static string trainer_name = string.Empty;
        public static DateTime exp_date_completion = DateTime.Today;
        public static DateTime actual_date_completion = DateTime.Today;
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

        public static DataTable Return_lookups(string lookup_type, string id, string dst_id, string sct_id)
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
                        }
                        else
                        {
                            SQL = "SELECT sct_id,sct_name FROM lst_sub_county";
                        }
                        break;
                    case "parish":
                        SQL = "SELECT wrd_id,wrd_name FROM lst_ward WHERE sct_id = '"+ id +"'";
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
                        SQL = @"SELECT H.hh_code + '-' + HHM.hhm_number AS hh_code,H.hh_id FROM hh_household H
                                LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_sid
                                LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                                LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                                LEFT JOIN hh_household_member HHM ON H.hh_id = HHM.hh_id
                                WHERE D.dst_id = '{0}'
                                AND S.sct_id = '{1}'";
                        SQL = string.Format(SQL, dst_id, sct_id);
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

        public static string save_update_YouthTrainingInventoryDetails(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (yti_id nvarchar(150))INSERT INTO [dbo].[ben_youth_training_inventory]
           ([yti_id] ,[prt_id],[cso_id] ,[dst_id],[sct_id],[wrd_id] ,[begin_date],[hhm_code],[hhm_name]
           ,[grp_name] ,[age],[gnd_id],[training_type],[trainer_name],[exp_date_completion],[actual_date_completion]
           ,[usr_id_create] ,[usr_id_update],[usr_date_create] ,[usr_date_update],[ofc_id] ,[district_id])  OUTPUT INSERTED.[yti_id] INTO @tempTable
           VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')
           SELECT yti_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_youth_training_inventory]
                       SET [prt_id] = '{1}' ,[cso_id] = '{2}',[dst_id] = '{3}' ,[sct_id] = '{4}'
                          ,[wrd_id] = '{5}',[begin_date] = '{6}',[hhm_code] = '{7}',[hhm_name] = '{8}'
                          ,[grp_name] = '{9}',[age] = '{10}',[gnd_id] = '{11}',[training_type] = '{12}' ,[trainer_name] = '{13}'
                          ,[exp_date_completion] = '{14}',[actual_date_completion] = '{15}',[usr_id_update] = '{16}',[usr_date_update] = '{17}'
                     WHERE yti_id = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, yti_id, prt_id, cso_id, dst_id, sct_id, wrd_id, begin_date, hhm_code, hhm_name, grp_name, age, gnd_id, training_type,
                        trainer_name,exp_date_completion,actual_date_completion,usr_id_create,usr_id_update,usr_date_create,usr_date_update,ofc_id,district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, yti_id, prt_id, cso_id, dst_id, sct_id, wrd_id, begin_date, hhm_code,hhm_name,grp_name,age,gnd_id,training_type,trainer_name,
                        exp_date_completion,actual_date_completion,usr_id_update,usr_date_update);

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
                        yti_id = (string)cmd.ExecuteScalar();
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
                return yti_id;
            }
            else
            {
                return string.Empty;
            }
        }

        #region ReturnInventoryList
        public static DataTable ReturnInventoryList_details(string lookup_type, string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (lookup_type)
                {
                    case "list":
                        SQL = @"SELECT Y.yti_id,D.dst_name,S.sct_name,W.wrd_name,p.prt_name,C.cso_name,Y.hhm_name
                                FROM ben_youth_training_inventory Y
                                LEFT JOIN lst_ward W ON Y.wrd_id = W.wrd_id
                                LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                                LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                                LEFT JOIN lst_partner P ON Y.prt_id = P.prt_id
                                LEFT JOIN lst_cso C ON Y.cso_id = C.cso_id";
                        break;
                    case "member_details":
                        SQL = "SELECT* FROM ben_youth_training_inventory WHERE yti_id = '{0}'";
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
        #endregion ReturnInventoryList

        #region Search
        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string wrd_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @" SELECT Y.yti_id,D.dst_name,S.sct_name,W.wrd_name,p.prt_name,C.cso_name,Y.hhm_name
                         FROM ben_youth_training_inventory Y
                         LEFT JOIN lst_ward W ON Y.wrd_id = W.wrd_id
                         LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                         LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                         LEFT JOIN lst_partner P ON Y.prt_id = P.prt_id
                         LEFT JOIN lst_cso C ON Y.cso_id = C.cso_id
                         WHERE (@dst_id = '-1' OR Y.dst_id = @dst_id )
                         AND (@sct_id = '-1' OR Y.sct_id = @sct_id)
                         AND (@prt_id = '-1' OR Y.prt_id = @prt_id)
                         AND (@cso_id = '-1' OR Y.cso_id = @cso_id)
                         AND (@wrd_id = '-1' OR Y.wrd_id =  @wrd_id)
                        ";
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@prt_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@prt_id"].Value = prt_id;

                    cmd.Parameters.Add("@cso_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@cso_id"].Value = cso_id;

                    cmd.Parameters.Add("@wrd_id", SqlDbType.NVarChar, 20);
                    cmd.Parameters["@wrd_id"].Value = wrd_id;

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
        #endregion Search
    }
}
