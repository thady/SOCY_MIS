using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public static class prtSubCountyOVCChecklist
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        public static string soc_id = string.Empty;
        public static DateTime soc_date = DateTime.Today;
        public static int soc_cso_report = 0;
        public static int soc_cso_total = 0;
        public static int soc_action_points_implemented = 0;
        public static int soc_action_points_total_identified = 0;
        public static string dst_id = string.Empty;
        public static string fy_id = string.Empty;
        public static string qy_id = string.Empty;
        public static string yn_id_meetings_held = string.Empty;
        public static string yn_id_membership_constituted = string.Empty;
        public static string yn_id_cdo_supervision = string.Empty;
        public static string yn_signed_minutes_available = string.Empty;
        public static string yn_id_sovcc_discussed_minutes_available = string.Empty;
        public static string yn_id_ovcmis_district = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        public static string sct_id = string.Empty;
        public static DateTime? beginDate = null;
        public static DateTime? endDate = null;


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
                    case "quarter":
                        SQL = "SELECT qy_id,qy_name FROM lst_quarter_year";
                        break;
                    case "fy":
                        SQL = "SELECT fy_id,fy_name FROM lst_financial_year";
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

        #region Save
        public static void save_update_SOVCC_CheckList(string action)
        {
            string Query = string.Empty;
            string _ysr_id = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = @"INSERT INTO [dbo].[prt_subcounty_ovc_checklist]([soc_id],[soc_date],[soc_cso_report],[soc_cso_total],[soc_action_points_implemented],[soc_action_points_total_identified]
                       ,[dst_id],[fy_id],[qy_id],[yn_id_meetings_held],[yn_id_membership_constituted],[yn_id_cdo_supervision],[yn_signed_minutes_available],[yn_id_sovcc_discussed_minutes_available]
                       ,[yn_id_ovcmis_district],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id],sct_id)
                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[prt_subcounty_ovc_checklist]
                            SET [soc_date] = '{1}' ,[soc_cso_report] = '{2}',[soc_cso_total] = '{3}',[soc_action_points_implemented] = '{4}',[soc_action_points_total_identified] = '{5}'
                            ,[dst_id] = '{6}',[fy_id] = '{7}',[qy_id] = '{8}',[yn_id_meetings_held] = '{9}',[yn_id_membership_constituted] = '{10}',[yn_id_cdo_supervision] = '{11}'
                            ,[yn_signed_minutes_available] = '{12}',[yn_id_sovcc_discussed_minutes_available] = '{13}',[yn_id_ovcmis_district] = '{14}',[usr_id_update] = '{15}'
                            ,[usr_date_update] = '{16}',sct_id = '{17}'
                          WHERE  [soc_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, soc_id, soc_date, soc_cso_report, soc_cso_total, soc_action_points_implemented, soc_action_points_total_identified, dst_id, fy_id,
                        qy_id, yn_id_meetings_held, yn_id_membership_constituted, yn_id_cdo_supervision, yn_signed_minutes_available, yn_id_sovcc_discussed_minutes_available,
                        yn_id_ovcmis_district, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id,sct_id);


                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, soc_id, soc_date, soc_cso_report, soc_cso_total, soc_action_points_implemented, soc_action_points_total_identified, dst_id, fy_id,
                        qy_id, yn_id_meetings_held, yn_id_membership_constituted, yn_id_cdo_supervision, yn_signed_minutes_available, yn_id_sovcc_discussed_minutes_available,
                        yn_id_ovcmis_district, usr_id_update, usr_date_update,sct_id);

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
        #endregion Save

        public static DataTable LoadSOVCCRecords()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dst.dst_name,Q.qy_name,Y.fy_name,C.soc_date,C.soc_id,C.ofc_id
                    FROM prt_subcounty_ovc_checklist C
                    LEFT JOIN lst_district dst ON C.dst_id = dst.dst_id
                    LEFT JOIN lst_quarter_year Q ON C.qy_id = Q.qy_id
                    LEFT JOIN lst_financial_year Y ON C.fy_id = Y.fy_id";

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

        public static DataTable Search(string dst_id, string qy_id, string fy_id, DateTime? dateFrom, DateTime? dateTo)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @" SELECT dst.dst_name,Q.qy_name,Y.fy_name,C.soc_date,C.soc_id,C.ofc_id
                        FROM prt_subcounty_ovc_checklist C
                        LEFT JOIN lst_district dst ON C.dst_id = dst.dst_id
                        LEFT JOIN lst_quarter_year Q ON C.qy_id = Q.qy_id
                        LEFT JOIN lst_financial_year Y ON C.fy_id = Y.fy_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@qy_id = '-1' OR Q.qy_id = @qy_id)
                        AND (@fy_id = '-1' OR Y.fy_id = @fy_id)
                        AND ((C.soc_date between @dateFrom AND @dateTo) OR(@dateFrom IS NULL AND @dateTo IS NULL))";

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@qy_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@qy_id"].Value = qy_id;

                    cmd.Parameters.Add("@fy_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@fy_id"].Value = fy_id;

                    cmd.Parameters.Add("@dateFrom", SqlDbType.Date);
                    cmd.Parameters["@dateFrom"].Value = dateFrom;

                    cmd.Parameters.Add("@dateTo", SqlDbType.Date);
                    cmd.Parameters["@dateTo"].Value = dateTo;

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

        public static void LoadDisplay(string soc_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = "SELECT* FROM prt_subcounty_ovc_checklist WHERE soc_id = '{0}'";
                SQL = string.Format(SQL,soc_id);

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

                        soc_date = Convert.ToDateTime(dtRow["soc_date"]);
                        soc_cso_report = Convert.ToInt32(dtRow["soc_cso_report"]);
                        soc_cso_total = Convert.ToInt32(dtRow["soc_cso_total"]);
                        soc_action_points_implemented = Convert.ToInt32(dtRow["soc_action_points_implemented"]);
                        soc_action_points_total_identified = Convert.ToInt32(dtRow["soc_action_points_total_identified"]);
                        dst_id = dtRow["dst_id"].ToString();
                        fy_id = dtRow["fy_id"].ToString();
                        qy_id = dtRow["qy_id"].ToString();
                        yn_id_meetings_held = dtRow["yn_id_meetings_held"].ToString();
                        yn_id_membership_constituted = dtRow["yn_id_membership_constituted"].ToString();
                        yn_id_cdo_supervision = dtRow["yn_id_cdo_supervision"].ToString();
                        yn_signed_minutes_available = dtRow["yn_signed_minutes_available"].ToString();
                        yn_id_sovcc_discussed_minutes_available = dtRow["yn_id_sovcc_discussed_minutes_available"].ToString();
                        yn_id_ovcmis_district = dtRow["yn_id_ovcmis_district"].ToString();
                        ofc_id = dtRow["ofc_id"].ToString();
                        sct_id = dtRow["sct_id"].ToString();
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
        }
    }
}