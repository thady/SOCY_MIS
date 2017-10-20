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
  public static class SystemConstants
    {

       static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
       static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);

       static SqlConnection conn = null;

        public static DataTable Return_list_of_districts()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT dst_id,dst_name FROM lst_district";
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

        //return list of districts for the district data  download setup screen
        public static DataTable Return_list_of_districts_data_download()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT dst_id,dst_name FROM lst_district";
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

        //return office district
        public static string Return_office_district()
        {
            DataTable dt = new DataTable();
            string district_id = String.Empty;
            SqlDataAdapter Adapt;
            string SQL = "SELECT district_id FROM um_office";
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

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        district_id = !dtRow.IsNull("district_id") ? Convert.ToInt32(dtRow["district_id"].ToString()).ToString() : "-999";
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

            return district_id;
        }

        //save districts for download
        public static void Save_update_district_for_data_download(int district_id,bool active)
        {
           string Query = "IF NOT EXISTS(SELECT dst_id FROM um_office_district_download_mapping WHERE dst_id = '{0}')" +
                "BEGIN " +
                "INSERT INTO um_office_district_download_mapping(dst_id,download_active) " +
                "VALUES('{0}','{1}') " +
                "END ELSE BEGIN " +
                "UPDATE um_office_district_download_mapping SET download_active = '{1}' WHERE dst_id = '{0}' " +
                "END";

            string SQL = string.Empty;
            try
            {
                if (district_id != -1)
                {
                    SQL = string.Format(Query, district_id,active);
                }

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

        //return list of download districts for display
        public static DataTable Return_list_of_districts_data_download_display()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = "SELECT D.dst_name,M.download_active FROM um_office_district_download_mapping M " +
                "LEFT JOIN  lst_district D ON M.dst_id = D.dst_id";
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

        //return list of districts for download
        public static string Return_office_district_for_download()
        {
            DataTable dt = new DataTable();
            string district_download_list = String.Empty;
            SqlDataAdapter Adapt;
            string SQL = "SELECT dst_id FROM um_office_district_download_mapping WHERE download_active = 1";
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

                    district_download_list = string.Join(",", dt.Rows.OfType<DataRow>().Select(r => r[0].ToString()));
                    
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

            return district_download_list;
        }

        //save downloaded office groups
        public static void save_downloaded_office_group(string office_grp_record_guid,string ofc_id,bool active)
        {
            string Query = "IF NOT EXISTS(SELECT ofc_id FROM um_office_group_details WHERE ofc_id = '{1}')" +
                 "BEGIN " +
                 "INSERT INTO um_office_group_details(office_grp_record_guid,ofc_id,active) " +
                 "VALUES('{0}','{1}','{2}') " +
                 "END ELSE BEGIN " +
                 "UPDATE um_office_group_details SET active = '{2}' WHERE ofc_id = '{1}' " +
                 "END";

            string SQL = string.Empty;
            try
            {
                SQL = string.Format(Query, office_grp_record_guid,ofc_id, active);
              
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

        //enable edit/save rights for office if offices belong to the same office group

        public static bool Validate_Office_group_access(string login_office_id, string data_owner_office_id)
        {
            DataTable dt;
            string district_download_list = String.Empty;
            SqlDataAdapter Adapt;
            bool is_same_office_group = false;
            string SQL = string.Empty;
            int countGroups = 0;
            SqlCommand SQLCMD;
            DataRow dtRow_ofc_group = null;
            string ofc_group_id_logged_in_office = string.Empty;
            string ofc_group_id_data_owner_office = string.Empty;

            SQL = "SELECT COUNT(office_grp_record_guid) FROM um_office_group_details";

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
                    countGroups = (int)cmd.ExecuteScalar();

                    if (countGroups > 0)
                    {
                        //get the office group id of the data owner(creater) office if it exists
                        if (conn.State == ConnectionState.Open) { conn.Close(); }
                        SQL = "SELECT office_grp_record_guid FROM um_office_group_details WHERE ofc_id = '" + data_owner_office_id + "' AND active = 1";
                        SQLCMD = new SqlCommand(SQL, conn);

                        if (conn.State == ConnectionState.Closed) { conn.Open(); }

                        Adapt = new SqlDataAdapter(SQLCMD);
                        dt = new DataTable();
                        Adapt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dtRow_ofc_group = dt.Rows[0];
                            ofc_group_id_data_owner_office = (string)dtRow_ofc_group["office_grp_record_guid"];
                        }
                        else { ofc_group_id_data_owner_office = string.Empty; }

                        //get the office group id of the office which is currently logged into this db if it exists
                        if (conn.State == ConnectionState.Open) { conn.Close(); }
                        SQL = "SELECT office_grp_record_guid FROM um_office_group_details WHERE ofc_id = '" + login_office_id + "' AND active = 1";
                        SQLCMD = new SqlCommand(SQL, conn);

                        if (conn.State == ConnectionState.Closed) { conn.Open(); }

                        Adapt = new SqlDataAdapter(SQLCMD);
                        dt = new DataTable();
                        Adapt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dtRow_ofc_group = dt.Rows[0];
                            ofc_group_id_logged_in_office = (string)dtRow_ofc_group["office_grp_record_guid"];
                        }
                        else { ofc_group_id_logged_in_office = string.Empty; }

                        //check if the two office_group_ids match
                        if (ofc_group_id_data_owner_office.Equals(ofc_group_id_logged_in_office))
                        {
                            is_same_office_group = true;
                        }
                        else { is_same_office_group = false; }

                        SQLCMD.Parameters.Clear();
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

            return is_same_office_group;
        }
    }
}
