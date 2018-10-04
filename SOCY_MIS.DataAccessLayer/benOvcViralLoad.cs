using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public static class benOvcViralLoad
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        #region Variables
        public static string vl_id = string.Empty;
        public static string _vl_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string hh_id = string.Empty;
        public static DateTime qrt_start_date = DateTime.Now;
        public static DateTime qrt_end_date = DateTime.Now;
        public static string linc_id = string.Empty;
        public static string sw_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string vlm_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hef_name = string.Empty;
        public static string art_number = string.Empty;
        public static string vl_eligible = string.Empty;
        public static string vl_done = string.Empty;
        public static string vl_date = string.Empty;
        public static DateTime vl_nextdate = DateTime.Now;
        public static string suppressed = string.Empty;



        #endregion Variables
        public static DataTable ReturnHHMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                //SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id
                //        FROM hh_household_member WHERE hh_id = '{0}'
                //        AND hst_id = '1'";

                SQL = @"SELECT DISTINCT(hhm.hhm_id) AS hhm_id, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM hh_household_home_visit_member hvm
                        INNER JOIN hh_household_member hhm ON hvm.hhm_id = hhm.hhm_id
                        INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id
                        WHERE hh.hh_id = '{0}'
                        AND hvm.hst_id = '1'";

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

        #region Save
        public static string save(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"DECLARE @tempTable TABLE (vl_id nvarchar(150))
                            INSERT INTO [dbo].[ben_ovc_viral_load]
                           ([vl_id],[prt_id],[cso_id],[wrd_id],[hh_id],[qrt_start_date],[qrt_end_date],[linc_id]
                           ,[sw_id],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id]
                           ,[district_id]) OUTPUT INSERTED.vl_id INTO @tempTable
                     VALUES ('{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')
                     SELECT vl_id FROM @tempTable";

                    SQL = string.Format(SQL,vl_id,prt_id,cso_id,wrd_id,hh_id,qrt_start_date,qrt_end_date,linc_id,sw_id,usr_id_create,usr_id_update,usr_date_create,usr_date_update,ofc_id,district_id);

                    #endregion Insert
                }
                else if(action == "update")
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_ovc_viral_load]
                           SET [prt_id] = '{1}'
                              ,[cso_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[hh_id] = '{4}'
                              ,[qrt_start_date] = '{5}'
                              ,[qrt_end_date] = '{6}'
                              ,[linc_id] = '{7}'
                              ,[sw_id] = '{8}'
                              ,[usr_id_update] = '{9}'
                              ,[usr_date_update] = '{10}'
                              ,[district_id] = '{11}'
                         WHERE  [vl_id] = '{0}'";


                    SQL = string.Format(SQL, vl_id,prt_id,cso_id,wrd_id,hh_id,qrt_start_date,qrt_end_date,linc_id,sw_id,usr_id_update,usr_date_update,district_id);
                    #endregion Update
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

                    cmd.CommandTimeout = 3600;
                    cmd.CommandType = CommandType.Text;
                    switch (action)
                    {
                        case "insert":
                            _vl_id = cmd.ExecuteScalar().ToString();
                            break;
                        case "update":
                            cmd.ExecuteNonQuery();
                            break;
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

            return _vl_id;
        }

        public static void save_member(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"INSERT INTO [dbo].[ben_ovc_viral_load_member]
                           ([vlm_id],[vl_id],[hhm_id],[hef_name],[art_number],[vl_eligible],[vl_done],[vl_date],[vl_nextdate]
                           ,[suppressed],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                     VALUES
                           ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')";

                    SQL = string.Format(SQL,vlm_id,vl_id,hhm_id,hef_name,art_number,vl_eligible,vl_done,vl_date,vl_nextdate,suppressed,usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                    #endregion Insert
                }
                else if (action == "update")
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_ovc_viral_load_member]
                           SET [hhm_id] = '{1}'
                              ,[hef_name] = '{2}'
                              ,[art_number] = '{3}'
                              ,[vl_eligible] = '{4}'
                              ,[vl_done] = '{5}'
                              ,[vl_date] = '{6}'
                              ,[vl_nextdate] = '{7}'
                              ,[suppressed] = '{8}'
                              ,[usr_id_update] = '{9}'
                              ,[usr_date_update] = '{10}'
                              ,[district_id] = '{11}'
                         WHERE [vlm_id] = '{0}'";


                    SQL = string.Format(SQL,vlm_id,hhm_id,hef_name,art_number,vl_eligible,vl_done,vl_date,vl_nextdate,suppressed,usr_id_update, usr_date_update, district_id);
                    #endregion Update
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

                    cmd.CommandTimeout = 3600;
                    cmd.CommandType = CommandType.Text;
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
        #endregion Save

        #region LoadDisplay
        public static DataTable LoadMainDisplay(string vl_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT V.vl_id, V.qrt_start_date,V.qrt_end_date,V.linc_id,swm.swk_id
                        FROM ben_ovc_viral_load V
                        LEFT JOIN swm_social_worker swm ON V.sw_id = swm.swk_id
                        WHERE V.vl_id = '{0}'";

                SQL = string.Format(SQL, vl_id);
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

        public static DataTable LoadMembersList(string vl_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT M.vlm_id,hhm.hhm_first_name,hhm.hhm_last_name,hhm.hhm_year_of_birth FROM ben_ovc_viral_load_member M
                        LEFT JOIN hh_household_member hhm ON M.hhm_id = hhm.hhm_id
                        WHERE M.vl_id = '{0}'";

                SQL = string.Format(SQL, vl_id);
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

        public static DataTable LoadMemberDisplay(string vlm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT M.vlm_id,M.hhm_id,M.hef_name,M.art_number,M.vl_eligible,M.vl_done,M.vl_date,M.vl_nextdate,M.suppressed
                        FROM ben_ovc_viral_load_member M WHERE vlm_id = '{0}'";

                SQL = string.Format(SQL, vlm_id);
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

        public static DataTable LoadLinkangesCoordinator(string dst_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT lc_name,lc_id FROM lst_linkages_coordinator
                        WHERE dst_id = '{0}'";

                SQL = string.Format(SQL, dst_id);
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

        public static string LoadLinkangesCoordinatorPhone(string lc_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string lc_phone = string.Empty;
            try
            {

                SQL = @"SELECT lc_phone FROM lst_linkages_coordinator
                        WHERE lc_id = '{0}'";

                SQL = string.Format(SQL, lc_id);
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
                        lc_phone = dtRow["lc_phone"].ToString();
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

            return lc_phone;
        }
        #endregion LoadDisplay

        #region SW Phones
        public static string ReturnSWPhone(string sw_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string sw_phone = string.Empty;
            DataRow dtRow = null;
            try
            {

                SQL = @"SELECT swk_phone FROM swm_social_worker WHERE swk_id ='{0}'";
                SQL = string.Format(SQL, sw_id);

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
                        dtRow = dt.Rows[0];
                        sw_phone = dtRow["swk_phone"].ToString();
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

            return sw_phone;
        }
        #endregion
    }
}
