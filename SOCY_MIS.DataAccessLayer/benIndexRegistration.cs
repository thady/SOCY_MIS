using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class benIndexRegistration
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region Variables
        public static string ibr_id = string.Empty;
        public static string dst_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hhm_id_caregiver = string.Empty; 
        public static string sct_id = string.Empty;
        public static string index_wrd_id = string.Empty;
        public static DateTime ibr_date = DateTime.Now;
        public static string entry_point = string.Empty;
        public static string incharge_name = string.Empty;
        public static string other_entry_point = string.Empty;
        public static string category_id = string.Empty;
        public static string index_name = string.Empty;
        public static int dob = 0;
        public static int age = 0;
        public static string gnd_id = string.Empty;
        public static string unique_id = string.Empty;
        public static string yn_id_suppress = string.Empty;
        public static DateTime art_date = DateTime.Today;
        public static string caregiver_name = string.Empty;
        public static string village = string.Empty;
        public static string chbc_name = string.Empty;
        public static string chbc_contact = string.Empty;
        public static string swk_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        public static string hh_id = string.Empty;
        #endregion Variables

        #region Constants
        public static string HIV_POS_CHILD = "2";
        public static string HIV_POS_ADULT = "3";
        public static string EXPOSED_INFANT = "1";
        public static string PREGNANT_ADOLESCENT = "4";
        public static string FEMALE_SEXUAL_WORKER = "6";
        #endregion Constants

        public static string ReturnSocialWorkerPhone(string swk_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string swk_phone = string.Empty;

            string strSQL = "SELECT swk_phone FROM swm_social_worker WHERE swk_id = '{0}'";
            strSQL = string.Format(strSQL, swk_id);
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
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        swk_phone = dtRow["swk_phone"].ToString();
                    }
                    else
                    {
                        swk_phone = string.Empty;
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

            return swk_phone;
        }

        public static DataTable ReturnIndexCategory()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT cat_id,cat_name FROM lst_index_beneficiary_category WHERE cat_active = 1";
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

        public static DataTable ReturnGender()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT gnd_id,gnd_name FROM lst_gender";
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

        public static DataTable ReturnSocialWorker(string dst_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                if (dst_id == "15" || dst_id == "23")
                {
                    SQL = @"SELECT swk_id,swk_first_name + ' ' + swk_last_name AS swk_name FROM swm_social_worker dt
                        INNER JOIN lst_ward W ON W.wrd_id = dt.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        WHERE swt_id = 1 AND sws_id = 1 AND (dst.dst_id = '15' OR dst.dst_id = '23')";
                }
                else
                {
                    SQL = @"SELECT swk_id,swk_first_name + ' ' + swk_last_name AS swk_name FROM swm_social_worker dt
                        INNER JOIN lst_ward W ON W.wrd_id = dt.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
                        WHERE swt_id = 1 AND sws_id = 1 AND dst.dst_id = '{0}'";
                }

                SQL = string.Format(SQL,dst_id);

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

        public static void save()
        {

            string strSQL = @"INSERT INTO [dbo].[ben_ovc_index_register]
                            ([ibr_id],[hhm_id],[dst_id] ,[sct_id],[index_wrd_id] ,[ibr_date],[entry_point] ,[incharge_name] ,[other_entry_point],[category_id] ,[index_name] ,[dob]
                            ,[gnd_id],[unique_id],[yn_id_suppress],[art_date] ,[hhm_id_caregiver] ,[village],[chbc_name] ,[chbc_contact],[swk_id],[usr_id_create],[usr_id_update],[usr_date_create]
                            ,[usr_date_update],[ofc_id] ,[district_id])
                            VALUES ('{0}' ,'{1}' ,'{2}','{3}' ,'{4}' ,'{5}','{6}' ,'{7}' ,'{8}' ,'{9}','{10}' ,YEAR(GETDATE()) - '{11}','{12}','{13}','{14}','{15}' ,'{16}'
                            ,'{17}' ,'{18}' ,'{19}' ,'{20}' ,'{21}','{22}' ,'{23}','{24}','{25}','{26}')";

            strSQL = string.Format(strSQL, ibr_id,hhm_id, dst_id, sct_id, index_wrd_id, ibr_date, entry_point, incharge_name, other_entry_point, category_id, index_name, age
                                , gnd_id, unique_id, yn_id_suppress, art_date, hhm_id_caregiver, village, chbc_name, chbc_contact, swk_id, usr_id_create, usr_id_update, usr_date_create
                                , usr_date_update, ofc_id, district_id);
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

        public static void update()
        {

            string strSQL = @"UPDATE [dbo].[ben_ovc_index_register]
                            SET [dst_id] = '{1}',[sct_id] = '{2}',[index_wrd_id] = '{3}' ,[ibr_date] = '{4}'  ,[entry_point] = '{5}' ,[incharge_name] = '{6}' ,[other_entry_point] = '{7}'
                            ,[category_id] = '{8}' ,[index_name] = '{9}' ,[dob] = YEAR(GETDATE()) - '{10}',[gnd_id] = '{11}' ,[unique_id] = '{12}' ,[yn_id_suppress] = '{13}',[art_date] = '{14}'
                            ,[hhm_id_caregiver] = '{15}' ,[village] = '{16}',[chbc_name] = '{17}' ,[chbc_contact] = '{18}' ,[usr_id_update] = '{19}',[usr_date_update] = '{20}',swk_id = '{21}',hhm_id = '{22}'
                            WHERE ibr_id = '{0}'";

            strSQL = string.Format(strSQL, ibr_id, dst_id, sct_id, index_wrd_id, ibr_date, entry_point, incharge_name, other_entry_point, category_id, index_name, dob
                                , gnd_id, unique_id, yn_id_suppress, art_date, caregiver_name, village, chbc_name, chbc_contact, usr_id_update, usr_date_update, swk_id,hhm_id);
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

        public static DataTable LoadList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.ibr_id, dst.dst_name AS District,sct.sct_name AS SubCounty,index_sct.sct_name AS [Index Beneficiary Home Sub County],wrd_index.wrd_name AS [Index Beneficiary Home Parish],dt.entry_point AS [Entry Point],C.cat_name AS Category,dt.index_name AS [Name of Index Beneficiary],gnd.gnd_name AS Sex,(YEAR(GETDATE()) - dt.dob) AS Age
                        FROM ben_ovc_index_register dt
                        INNER JOIN lst_district dst ON dt.dst_id = dst.dst_id
                        INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
                        INNER JOIN lst_ward wrd_index ON dt.index_wrd_id = wrd_index.wrd_id
                        INNER JOIN lst_sub_county index_sct ON wrd_index.sct_id = index_sct.sct_id
                        INNER JOIN lst_index_beneficiary_category C ON dt.category_id = C.cat_id
                        INNER JOIN lst_gender gnd ON dt.gnd_id = gnd.gnd_id";

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

        public static DataTable Search(string dst_id, string sct_id, string wrd_id, string entrypoint, string category,string index_name)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dt.ibr_id, dst.dst_name AS District,sct.sct_name AS SubCounty,index_sct.sct_name AS [Index Beneficiary Home Sub County],wrd_index.wrd_name AS [Index Beneficiary Home Parish],dt.entry_point AS [Entry Point],C.cat_name AS Category,dt.index_name AS [Name of Index Beneficiary],gnd.gnd_name AS Sex,(YEAR(GETDATE()) - dt.dob) AS Age
                        FROM ben_ovc_index_register dt
                        INNER JOIN lst_district dst ON dt.dst_id = dst.dst_id
                        INNER JOIN lst_sub_county sct ON dt.sct_id = sct.sct_id
                        INNER JOIN lst_ward wrd_index ON dt.index_wrd_id = wrd_index.wrd_id
                        INNER JOIN lst_sub_county index_sct ON wrd_index.sct_id = index_sct.sct_id
                        INNER JOIN lst_index_beneficiary_category C ON dt.category_id = C.cat_id
                        INNER JOIN lst_gender gnd ON dt.gnd_id = gnd.gnd_id
                        WHERE (@dst_id = '-1' OR dt.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR index_sct.sct_id = @sct_id)
                        AND (@wrd_id = '-1' OR wrd_index.wrd_id = @wrd_id)
                        AND (@entrypoint = '' OR dt.entry_point = @entrypoint)
                        AND (@category = '-1' OR dt.category_id = @category)
                        AND (@category = '-1' OR dt.category_id = @category)
                        AND (@index_name = '' OR dt.index_name LIKE '%' + @index_name  + '%')";
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@wrd_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@wrd_id"].Value = wrd_id;

                    cmd.Parameters.Add("@entrypoint", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@entrypoint"].Value = entrypoint;

                    cmd.Parameters.Add("@category", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@category"].Value = category;

                    cmd.Parameters.Add("@index_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@index_name"].Value = index_name;

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
        public static DataTable LoadRecordDetails(string ibr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.*,sct.sct_id AS index_sct,(YEAR(GETDATE()) - dt.dob) AS Age FROM ben_ovc_index_register dt
                        INNER JOIN lst_ward W ON dt.index_wrd_id = W.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        WHERE ibr_id = '{0}'";
                SQL = string.Format(SQL, ibr_id);

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

        public static DataTable ReturnHouseholdDetails(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dst.dst_id,sct.sct_id,W.wrd_id,dt.hh_village FROM hh_household dt
                        INNER JOIN lst_ward W on dt.wrd_id = W.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id WHERE dt.hh_id = '{0}'";

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

        public static DataTable ReturnHouseholdIndexMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}'";

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

        public static DataTable ReturnHousehold_10_17_girls(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}' AND YEAR(GETDATE()) - dt.hhm_year_of_birth >=10 AND YEAR(GETDATE()) - dt.hhm_year_of_birth <=20
                        AND dt.gnd_id = '2'";
 
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


        public static DataTable ReturnHousehold_ExposedInfants(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                    WHERE dt.hh_id = '{0}' AND YEAR(GETDATE()) - dt.hhm_year_of_birth < 2";

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

        public static DataTable ReturnHousehold_HIVPOS_Child(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}' AND YEAR(GETDATE()) - dt.hhm_year_of_birth <=17 AND dt.hst_id = '1'";

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

        public static DataTable ReturnHousehold_HIVPOS_Adult(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}' AND YEAR(GETDATE()) - dt.hhm_year_of_birth >17 AND dt.hst_id = '1'";

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

        public static DataTable ReturnHousehold_FSW(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}' AND YEAR(GETDATE()) - dt.hhm_year_of_birth >10 AND dt.gnd_id = '2'";

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
        public static DataTable ReturnCaregiverList(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT dt.hhm_first_name + ' ' + dt.hhm_last_name AS hhm_name,dt.hhm_id FROM hh_household_member dt
                        WHERE dt.hh_id = '{0}'";

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

        public static DataTable ReturnMemberDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT YEAR(GETDATE()) - dt.hhm_year_of_birth AS Age,dt.gnd_id FROM hh_household_member dt
                        WHERE dt.hhm_id = '{0}'";

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

        public static DataTable ReturnIndexBeneficiaryRecord(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT ibr_id FROM ben_ovc_index_register dt
                        INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                        INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                        WHERE hh.hh_id = '{0}'";

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

        public static int ReturnIndexCount(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            int IndexCount = 0;
            try
            {

                SQL = @"SELECT COUNT(ibr_id) FROM ben_ovc_index_register dt
                        INNER JOIN hh_household_member hhm ON dt.hhm_id = hhm.hhm_id
                        INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                        WHERE hh.hh_id = '{0}'";

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
                    IndexCount = Convert.ToInt32(cmd.ExecuteScalar());

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

            return IndexCount;
        }
    }
}
