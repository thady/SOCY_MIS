using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
   public  class benSchoolReadinessTool
    {
        #region Variables
        public static string edsr_id = string.Empty;
        public static string ip_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static DateTime edsr_ass_date = DateTime.Now;
        public static string hh_id = string.Empty;
        public static string hhm_id_caregiver = string.Empty;
        public static string hhm_caregiver_phone = string.Empty;
        public static string yn_hh_silc = string.Empty;
        public static string yn_child_in_school = string.Empty;
        public static string hhm_id = string.Empty;
        public static string last_class_completed = string.Empty;
        public static string prev_school_name = string.Empty;
        public static string drop_out_yr = string.Empty;
        public static string child_next_steps = string.Empty;
        public static string current_class = string.Empty;
        public static string child_future_plans = string.Empty;
        public static string current_school_name = string.Empty;
        public static string sw_id = string.Empty;
        public static string psw_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string dst_id = string.Empty;
        #endregion Variables

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        public static DataTable ReturnHHMembers(string hh_id,string returnType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                if (returnType == "hhm_all")
                {
                    SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id
                        FROM hh_household_member WHERE hh_id = '{0}'";
                    SQL = string.Format(SQL, hh_id);
                }
                else if (returnType == "hhm_child_school_age_bracket")
                {
                    SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id
                            FROM hh_household_member WHERE hh_id = '{0}'";

                    SQL = string.Format(SQL, hh_id);
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

        public static void GetDisplay(string edsr_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            DataRow dtRow = null;
            try
            {
                SQL = @"SELECT dt.*,dst.dst_id,sct.sct_id FROM ben_education_subsidy_school_readiness dt
                        LEFT JOIN lst_ward w on dt.wrd_id = w.wrd_id
                        LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                        WHERE dt.edsr_id = '{0}'";

                SQL = string.Format(SQL, edsr_id);

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

                        edsr_id = dtRow["edsr_id"].ToString();
                        ip_id = dtRow["ip_id"].ToString();
                        cso_id = dtRow["cso_id"].ToString();
                        wrd_id = dtRow["wrd_id"].ToString();
                        edsr_ass_date = Convert.ToDateTime(dtRow["edsr_ass_date"]);
                        hh_id = dtRow["hh_id"].ToString();
                        hhm_id_caregiver = dtRow["hhm_id_caregiver"].ToString();
                        hhm_caregiver_phone = dtRow["hhm_caregiver_phone"].ToString();
                        yn_hh_silc = dtRow["yn_hh_silc"].ToString();
                        yn_child_in_school = dtRow["yn_child_in_school"].ToString();
                        hhm_id = dtRow["hhm_id"].ToString();
                        last_class_completed = dtRow["last_class_completed"].ToString();
                        prev_school_name = dtRow["prev_school_name"].ToString();
                        drop_out_yr = dtRow["drop_out_yr"].ToString();
                        child_next_steps = dtRow["child_next_steps"].ToString();
                        current_class = dtRow["current_class"].ToString();
                        child_future_plans = dtRow["child_future_plans"].ToString();
                        current_school_name = dtRow["current_school_name"].ToString();
                        sw_id = dtRow["sw_id"].ToString();
                        psw_id = dtRow["psw_id"].ToString();
                        usr_id_create = dtRow["usr_id_create"].ToString();
                        usr_id_update = dtRow["usr_id_update"].ToString();
                        usr_date_create = Convert.ToDateTime(dtRow["usr_date_create"]);
                        usr_date_update = Convert.ToDateTime(dtRow["usr_date_update"]);
                        ofc_id = dtRow["ofc_id"].ToString();
                        district_id = dtRow["district_id"].ToString();
                        sct_id = dtRow["sct_id"].ToString();
                        dst_id = dtRow["dst_id"].ToString();
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

        public static DataTable ReturnHHMDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT hhm.hhm_year_of_birth,hhm.gnd_id FROM hh_household_member hhm
                        WHERE hhm_id = '{0}'";

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

        public static string ReturnHHVillage(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string hh_village = string.Empty;
            DataRow dtRow = null;
            try
            {

                SQL = @" SELECT hh_village FROM hh_household WHERE hh_id = '{0}'";
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

                    if (dt.Rows.Count > 0)
                    {
                        dtRow = dt.Rows[0];
                        hh_village = dtRow["hh_village"].ToString();
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

            return hh_village;
        }

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

        #region Save
        public static void Save(string action)
        {
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    #region Insert
                    SQL = @"INSERT INTO [dbo].[ben_education_subsidy_school_readiness]
                   ([edsr_id],[ip_id],[cso_id],[wrd_id],[edsr_ass_date],[hh_id],[hhm_id_caregiver],[hhm_caregiver_phone],[yn_hh_silc]
                   ,[yn_child_in_school],[hhm_id],[last_class_completed],[prev_school_name],[drop_out_yr],[child_next_steps]
                   ,[current_class],[child_future_plans],[current_school_name],[sw_id],[psw_id],[usr_id_create],[usr_id_update]
                   ,[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                 VALUES
                   ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'
                   ,'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'
                   ,'{21}','{22}','{23}','{24}','{25}')";

                    SQL = string.Format(SQL, edsr_id,ip_id,cso_id,wrd_id,edsr_ass_date,hh_id,hhm_id_caregiver,hhm_caregiver_phone,yn_hh_silc,yn_child_in_school,
                        hhm_id, last_class_completed,prev_school_name,drop_out_yr,child_next_steps,current_class,child_future_plans,current_school_name,sw_id,psw_id,
                        usr_id_create,usr_id_update,usr_date_create,usr_date_update,ofc_id,district_id);

                    #endregion Insert
                }
                else
                {
                    #region Update
                    SQL = @"UPDATE [dbo].[ben_education_subsidy_school_readiness]
                               SET [ip_id] = '{1}'
                                  ,[cso_id] = '{2}'
                                  ,[wrd_id] = '{3}'
                                  ,[edsr_ass_date] = '{4}'
                                  ,[hh_id] = '{5}'
                                  ,[hhm_id_caregiver] = '{6}'
                                  ,[hhm_caregiver_phone] = '{7}'
                                  ,[yn_hh_silc] = '{8}'
                                  ,[yn_child_in_school] = '{9}'
                                  ,[hhm_id] = '{10}'
                                  ,[last_class_completed] = '{11}'
                                  ,[prev_school_name] = '{12}'
                                  ,[drop_out_yr] = '{13}'
                                  ,[child_next_steps] = '{14}'
                                  ,[current_class] = '{15}'
                                  ,[child_future_plans] = '{16}'
                                  ,[current_school_name] = '{17}'
                                  ,[sw_id] = '{18}'
                                  ,[psw_id] = '{19}'
                                  ,[usr_id_update] = '{20}'
                                  ,[usr_date_update] = '{21}'
                                  ,[district_id] = '{22}'
                             WHERE [edsr_id] = '{0}'";


                    SQL = string.Format(SQL, edsr_id, ip_id, cso_id, wrd_id, edsr_ass_date, hh_id, hhm_id_caregiver, hhm_caregiver_phone, yn_hh_silc, yn_child_in_school,
                        hhm_id, last_class_completed, prev_school_name, drop_out_yr, child_next_steps, current_class, child_future_plans, current_school_name, sw_id, psw_id,
                        usr_id_update, usr_date_update,district_id);
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

        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string wrd_id, string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dst.dst_name,sct.sct_name,w.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS beneficiary_name,R.edsr_ass_date,
                        yn.yn_name AS [In School?],R.edsr_id
                        FROM ben_education_subsidy_school_readiness R
                        LEFT JOIN lst_partner prt ON R.ip_id = prt.prt_id
                        LEFT JOIN lst_cso cso on R.cso_id = cso.cso_id
                        LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                        LEFT JOIN  hh_household H ON R.hh_id = H.hh_id
                        left join lst_ward w on H.wrd_id = w.wrd_id
                        left join lst_sub_county sct on w.sct_id = sct.sct_id
                        left join lst_district dst on sct.dst_id = dst.dst_id
                        LEFT JOIN lst_yes_no yn ON R.yn_child_in_school = yn.yn_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
                        AND (@prt_id = '-1' OR prt.prt_id = @prt_id)
                        AND (@cso_id = '-1' OR cso.cso_id = @cso_id)
                        AND (@wrd_id = '-1' OR w.wrd_id = @wrd_id)
                        AND (@hh_code = '' OR H.hh_code LIKE '%' + @hh_code  + '%')";

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

                    cmd.Parameters.Add("@wrd_id", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@wrd_id"].Value = wrd_id;

                    cmd.Parameters.Add("@hh_code", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@hh_code"].Value = hh_code;

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

        public static DataTable ReturnAssessmentList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT dst.dst_name,sct.sct_name,w.wrd_name,H.hh_code,hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS beneficiary_name,R.edsr_ass_date,
                        yn.yn_name AS [In School?],R.edsr_id
                        FROM ben_education_subsidy_school_readiness R
                        LEFT JOIN lst_partner prt ON R.ip_id = prt.prt_id
                        LEFT JOIN lst_cso cso on R.cso_id = cso.cso_id
                        LEFT JOIN hh_household_member hhm ON R.hhm_id = hhm.hhm_id
                        LEFT JOIN  hh_household H ON R.hh_id = H.hh_id
                        left join lst_ward w on H.wrd_id = w.wrd_id
                        left join lst_sub_county sct on w.sct_id = sct.sct_id
                        left join lst_district dst on sct.dst_id = dst.dst_id
                        LEFT JOIN lst_yes_no yn ON R.yn_child_in_school = yn.yn_id";

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
    }
}
