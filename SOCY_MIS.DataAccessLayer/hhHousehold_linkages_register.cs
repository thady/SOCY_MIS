using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PSAUtils;
using PSAUtilsWin32;
using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public class hhHousehold_linkages_register
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region table variables
        public static string hhm_linkages_record_guid = string.Empty;
        public static string partner_id = string.Empty;
        public static string hhm_district_id = string.Empty;
        public static string subcounty_id = string.Empty;
        public static string parish_id = string.Empty;
        public static string village = string.Empty;
        public static string hhm_id = string.Empty;
        public static string service_provider_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        public static string user_id = string.Empty;

        //linkages services provided
        public static string lsp_id = string.Empty;
        //linkages services required
        public static string lsr_id = string.Empty;
        #endregion table variables
        public static DataTable Return_household_details(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT H.hh_code,H.wrd_id,H.hh_village,W.wrd_name,S.sct_name,D.dst_name,c.cso_id,P.prt_name FROM hh_household H " +
            "LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_id " +
            "LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id " +
            "LEFT JOIN lst_district D ON S.dst_id = D.dst_id " +
            "LEFT JOIN hh_ovc_identification_prioritization U ON H.hh_id = U.hh_id " +
            "LEFT JOIN lst_cso C ON U.cso_id = C.cso_id " +
            "LEFT JOIN lst_partner P ON C.prt_id = P.prt_id " +
            "WHERE H.hh_id = '"+ hh_id +"'";
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

        //return lookups
        public static DataTable Return_lookups(string lookup_type)
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
                        SQL = "SELECT sct_id,sct_name FROM lst_sub_county";
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
                        SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso";
                        break;
                    case "CSOHAT":
                        SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso WHERE prt_id = '{0}'";
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

        //house hold member details
        public static DataTable Return_household_member_details(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = " SELECT M.hhm_number,M.hhm_first_name,M.hhm_last_name,G.gnd_name,M.hhm_year_of_birth, (H.hh_code + '/'+ M.hhm_number) AS hhm_code," +
               " M.hhm_id,(M.hhm_first_name + ' ' + M.hhm_last_name + '-' + M.hhm_number) AS Name  FROM hh_household_member M " +
              "LEFT JOIN lst_gender G ON M.gnd_id = G.gnd_id " +
              "LEFT JOIN  hh_household H ON M.hh_id = H.hh_id " +
              "WHERE M.hh_id = '"+ hh_id +"'" +
              "ORDER BY M.hhm_number";
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

        //save or update linkages tracking details 
        public static void save_update_hhm_linkages_details(string action)
        {
            string Query = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = "INSERT INTO [dbo].[hh_household_linkages_tracking]([hhm_linkages_record_guid],[partner_id] " +
                                ",[hhm_district_id],[subcounty_id] ,[parish_id] ,[village],[hhm_id],[service_provider_id] " +
                                ",[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',GETDATE(),GETDATE(),'{10}',{11})";
                      
            }
            else if (action == "update")
            {
                //update
                Query = "UPDATE [dbo].[hh_household_linkages_tracking] SET [partner_id] = '{1}'," +
                        "[hhm_district_id] = '{2}',[subcounty_id] = '{3}',[parish_id] = '{4}',[village] = '{5}',[hhm_id] = '{6}'," +
                        "[service_provider_id] = '{7}',[usr_id_update] = '{8}',[usr_date_update] = GETDATE()" +
                        "WHERE [hhm_linkages_record_guid] = '{0}'";
            }
                string SQL = string.Empty;
                try
                {
                if (action == "insert")
                {
                    SQL = string.Format(Query, hhm_linkages_record_guid, partner_id, hhm_district_id, subcounty_id, parish_id, village, hhm_id,
                        service_provider_id, usr_id_create, usr_id_update, ofc_id,district_id);
                }
                else if (action == "update") {
                    SQL = string.Format(Query, hhm_linkages_record_guid, partner_id, hhm_district_id, subcounty_id, parish_id, village, hhm_id,
                        service_provider_id, usr_id_update);
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

        #region save_hh_linkages_services_provided
        public static void save_hh_linkages_services_provided(string service_type)
        {

            string Query = string.Empty;

            if (service_type == "provided")
            {
                //insert services provided
              
                Query = "IF NOT EXISTS (SELECT [lsp_id] FROM [dbo].[hh_household_linkages_services_provided] WHERE [lsp_id] = '{0}' AND [hhm_linkages_record_guid] = '{1}') " +
                        "BEGIN " +
                            "INSERT INTO [dbo].[hh_household_linkages_services_provided]" +
                           "([record_guid],[lsp_id] ,[hhm_linkages_record_guid],[usr_id_create] ,[usr_date_create] ,[ofc_id],[district_id]) " +
                           " VALUES('{0}','{1}','{2}','{3}',GETDATE(),'{4}','{5}') " +
                        "END";
            }
            else if (service_type == "required")
            {
                //insert services required
                Query = "IF NOT EXISTS(SELECT [lsr_id] FROM [dbo].[hh_household_linkages_services_required] WHERE [lsr_id] = '{1}' AND [hhm_linkages_record_guid] = '{0}') " +
                        "BEGIN " +
                            "INSERT INTO [dbo].[hh_household_linkages_services_required]" +
                           "([record_guid],[hhm_linkages_record_guid],[lsr_id] ,[usr_id_create],[usr_id_update],[usr_date_create]" +
                           ",[usr_date_update] ,[ofc_id],[district_id]) " +
                           "VALUES('{0}','{1}','{2}','{3}','{4}',GETDATE(),GETDATE(),'{5}','{6}') " +
                           "END";
            }
            string SQL = string.Empty;
            try
            {
                if (service_type == "provided")
                {
                    string record_guid = Guid.NewGuid().ToString();
                    SQL = string.Format(Query, record_guid, lsp_id, hhm_linkages_record_guid,usr_id_create, ofc_id, district_id);
                }
                else if (service_type == "required")
                {
                    string record_guid = Guid.NewGuid().ToString();
                    SQL = string.Format(Query, record_guid, hhm_linkages_record_guid,lsr_id,usr_id_create,usr_id_update,ofc_id,district_id);
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
        #endregion save_hh_linkages_services_provided

        #region return HHM linkages tracking data
        public static DataTable Return_hhm_linkages_tracking_details(string hhm_id,string return_type) 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            if (return_type == "main_header")
            {
                SQL = "SELECT [hhm_linkages_record_guid], [usr_id_create] ,[usr_id_update], ofc_id,service_provider_id " +
              " FROM[dbo].[hh_household_linkages_tracking] WHERE [hhm_id] = '{0}'";
            }
            else if (return_type == "services_provided")
            {
                SQL = "SELECT P.[lsp_id] ,P.[hhm_linkages_record_guid],S.[service_name] " +
                      "FROM[dbo].[hh_household_linkages_services_provided] P LEFT JOIN lst_linkages_services_provided S ON P.[lsp_id] = S.linkages_service_id " +
                      "WHERE P.[hhm_linkages_record_guid] = '{0}' ";
            }
            else if (return_type == "services_required")
            {
                SQL = "SELECT [hhm_linkages_record_guid] ,[lsr_id],S.[service_name] " +
                    "FROM[dbo].[hh_household_linkages_services_required] R LEFT JOIN lst_linkages_services_required S ON R.[lsr_id] = S.linkages_service_offered_id " +
                    "WHERE R.[hhm_linkages_record_guid] = '{0}'";
            }
            try
            {
                if (return_type == "main_header") { SQL = string.Format(SQL, hhm_id);}
                else if (return_type == "services_provided") { SQL = string.Format(SQL, hhm_linkages_record_guid);}
                else if (return_type == "services_required") { SQL = string.Format(SQL, hhm_linkages_record_guid);}

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
        #endregion return HHM linkages tracking data

    }
}
