using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class SOCYARTRefill
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string artr_id = string.Empty;
        public static string _artr_id = string.Empty;
        public static string ip_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string sct_id = string.Empty;
        public static DateTime refill_date = DateTime.Now;
        public static string yn_direct_beneficiary = string.Empty;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hhm_name = string.Empty;
        public static string hhm_age = string.Empty;
        public static string gnd_id = string.Empty;
        public static string attached_health_facility = string.Empty;
        public static string art_number = string.Empty;
        public static string period_refill_taken = string.Empty;
        public static string beneficiary_contact = string.Empty;
        public static string swk_id = string.Empty;
        public static string swk_phone = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion

        public static void save(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[ben_art_refill]
            ([artr_id] ,[ip_id] ,[cso_id],[sct_id] ,[refill_date],[yn_direct_beneficiary] ,[hh_id] ,[hhm_id] ,[hhm_name]
            ,[hhm_age] ,[gnd_id] ,[attached_health_facility] ,[art_number] ,[period_refill_taken] ,[beneficiary_contact]
            ,[swk_id] ,[swk_phone] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update] ,[ofc_id] ,[district_id])
            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',
            '{19}','{20}','{21}','{22}')";

            strSQL = string.Format(strSQL, artr_id, ip_id, cso_id, sct_id, refill_date, yn_direct_beneficiary, hh_id, hhm_id, hhm_name
            , hhm_age, gnd_id, attached_health_facility, art_number, period_refill_taken, beneficiary_contact
            , swk_id, swk_phone, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);


            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_art_refill]
               SET [ip_id] = '{1}'
                  ,[cso_id] = '{2}'
                  ,[sct_id] = '{3}'
                  ,[refill_date] = '{4}'
                  ,[yn_direct_beneficiary] = '{5}'
                  ,[hh_id] = '{6}'
                  ,[hhm_id] = '{7}'
                  ,[hhm_name] = '{8}'
                  ,[hhm_age] = '{9}'
                  ,[gnd_id] = '{10}'
                  ,[attached_health_facility] = '{11}'
                  ,[art_number] = '{12}'
                  ,[period_refill_taken] = '{13}'
                  ,[beneficiary_contact] = '{14}'
                  ,[swk_id] = '{15}'
                  ,[swk_phone] = '{16}'
                  ,[usr_id_update] = '{17}'
                  ,[usr_date_update] = '{18}'
             WHERE  [artr_id] = '{0}'";

            strSQL = string.Format(strSQL, artr_id, ip_id, cso_id, sct_id, refill_date, yn_direct_beneficiary, hh_id, hhm_id, hhm_name
            , hhm_age, gnd_id, attached_health_facility, art_number, period_refill_taken, beneficiary_contact
            , swk_id, swk_phone, usr_id_update ,usr_date_update );


            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static DataTable LoadPositiveMmebers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT hhm_id,hhm_first_name + ' ' + hhm_last_name AS hhm_name FROM  hh_household_member WHERE (hst_id = '1' OR hst_id_new = 1) AND hh_id = '{0}'";

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

        public static string LoadSocialWOrkerPhone(string swk_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string Phone = string.Empty;
            try
            {

                SQL = @"SELECT swk_phone FROM swm_social_worker WHERE swk_id = '{0}'";

                SQL = string.Format(SQL, swk_id);
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
                        Phone = dtRow["swk_phone"].ToString();
                    }
                    else
                    {
                        Phone = string.Empty;
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

            return Phone;
        }

        public static DataTable Search(string hh_id, string hhm_name,string dst_id,string sct_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dt.artr_id, dst.dst_name,sct.sct_name,dt.yn_direct_beneficiary,ISNULL(hh.hh_code,'') AS hh_code,dt.hhm_name,gnd.gnd_name,dt.hhm_age,dt.refill_date FROM ben_art_refill dt
                INNER JOIN lst_partner prt ON dt.ip_id = prt.prt_id
                INNER JOIN  lst_cso cso ON dt.cso_id = cso.cso_id
                INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
                INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                LEFT JOIN  hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                INNER JOIN lst_gender gnd ON dt.gnd_id = gnd.gnd_id
                WHERE (@hh_id = '' OR hh.hh_id LIKE '%' + @hh_id + '%'  )
                AND (@hhm_name = '' OR hhm_name LIKE '%' + @hhm_name + '%' )
                AND (@sct_id = '' OR dt.sct_id LIKE '%' + @sct_id + '%' )
                AND (@dst_id = '' OR dst.dst_id LIKE '%' + @dst_id + '%' )";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@hh_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@hh_id"].Value = hh_id;

                    cmd.Parameters.Add("@hhm_name", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@hhm_name"].Value = hhm_name;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

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

        public static DataTable LoadList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT dt.artr_id, dst.dst_name,sct.sct_name,dt.yn_direct_beneficiary,ISNULL(hh.hh_code,'') AS hh_code,dt.hhm_name,gnd.gnd_name,dt.hhm_age,dt.refill_date FROM ben_art_refill dt
            INNER JOIN lst_partner prt ON dt.ip_id = prt.prt_id
            INNER JOIN  lst_cso cso ON dt.cso_id = cso.cso_id
            INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
            INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
            LEFT JOIN  hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
            LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id
            INNER JOIN lst_gender gnd ON dt.gnd_id = gnd.gnd_id";

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


        public static DataTable LoadDetails(string artr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT dt.*,dst.dst_id FROM ben_art_refill dt
            INNER JOIN lst_sub_county sct ON  dt.sct_id = sct.sct_id
            INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
            WHERE artr_id = '{0}'";

            strSQL = string.Format(strSQL, artr_id);
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

    }
}
