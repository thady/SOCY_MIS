using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
  public static  class benApprenticeshipskillAquisitionTracking
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region Variables
        public static string asat_id = string.Empty;
        
        public static DateTime review_date_from = DateTime.Today;
        public static DateTime review_date_to = DateTime.Today;
        public static string wrd_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string trade_id = string.Empty;
        public static string module_id = string.Empty;
        public static string youth_acquire_not_acquire_skill_reason = string.Empty;
        public static string recommended_steps = string.Empty;
        public static string artisan_name = string.Empty;
        public static DateTime artisan_report_date = DateTime.Today;
        public static string youth_skills_acquired = string.Empty;
        public static string yn_skill_not_acquired_well = string.Empty;
        public static string skill_not_acquired_well = string.Empty;
        public static string skill_not_acquired_well_reason = string.Empty;
        public static DateTime youth_report_date = DateTime.Today;
        public static string dyo_name = string.Empty;
        public static DateTime dyo_review_date = DateTime.Today;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Today;
        public static DateTime usr_date_update = DateTime.Today;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string asatskill_id = string.Empty;
        public static string excellent_acquired_skr_id = string.Empty;
        public static string average_acquired_skr_id = string.Empty;
        public static string not_acquired_skr_id = string.Empty;
        public static string skill_id = string.Empty;

        #endregion Variables
        public static DataTable ReturnApprenticeshipTrades()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = @"SELECT trd_name,trd_id FROM lst_apprenticeship_trade
                        ORDER BY trd_name ASC";
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

        public static DataTable ReturnApprenticeshipTradeSkills(DataTable TradeList)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            DataRow dtRow;
            string SQL = @"SELECT* FROM lst_apprenticeship_trade_skills
                            WHERE";
            if (TradeList.Rows.Count > 0)
            {
                dtRow = TradeList.Rows[0];
                SQL += " trd_id = " + dtRow["tr_id"].ToString() + "";
                if (TradeList.Rows.Count > 1)
                {
                    for (int i = 1; i < TradeList.Rows.Count; i++)
                    {
                        dtRow = TradeList.Rows[i];
                        SQL += " OR trd_id = "+ dtRow["tr_id"].ToString() +"";
                    }
                }  
            }
            //SQL = string.Format(SQL,tradeList);
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
                    if (TradeList.Rows.Count > 0)
                    {
                        Adapt = new SqlDataAdapter(cmd);
                        Adapt.Fill(dt);
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

            return dt;
        }

        public static DataTable ReturnApprenticeshipTradeSkill(string trd_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            DataRow dtRow;
            string SQL = @"SELECT S.trs_id,S.trs_name FROM lst_apprenticeship_trade_skills S
                            LEFT JOIN lst_apprenticeship_trade T ON S.trd_id = T.trd_id
                            WHERE T.trd_id = '{0}'
                            ORDER BY T.trd_name,S.trs_name ASC";
            SQL = string.Format(SQL, trd_id);
           
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

        public static string ReturnHHMemberCode(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            DataRow dtRow = null;
            string hhmCode = string.Empty;
           
            string SQL = @"SELECT H.hh_code + '/' + hhm.hhm_number AS hhm_code FROM hh_household_member hhm
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE hhm.hhm_id = '{0}'";
            SQL = string.Format(SQL, hhm_id);

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
                        dtRow = dt.Rows[0];
                        hhmCode = dtRow["hhm_code"].ToString();
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

            return hhmCode;
        }

        public static DataTable ReturnApprenticeshipMembers(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            DataRow dtRow;
            string SQL = @"SELECT HHM.hhm_id,(HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name   FROM hh_household_member HHM
                            LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                            WHERE YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) >= 15 AND YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) <= 24
                            AND H.hh_id = '{0}'";
            SQL = string.Format(SQL,hh_id);

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

        #region Save
        public static string Save(string action)
        {
            #region Variables
            string Outasat_id = string.Empty;
            string SQL = string.Empty;
            #endregion  Variables
            switch (action)
            {
                case "insert":
                  
                    SQL = @"DECLARE @tempTable TABLE (asat_id nvarchar(100)) INSERT INTO [dbo].[ben_apprenticeship_skill_acquisition_tracking]
                                   ([asat_id],[review_date_from],[review_date_to],[wrd_id],[hhm_id],[trade_id],[module_id],[youth_acquire_not_acquire_skill_reason]
                                   ,[recommended_steps],[artisan_name],[artisan_report_date],[youth_skills_acquired],[yn_skill_not_acquired_well],[skill_not_acquired_well],[skill_not_acquired_well_reason],
                                   [youth_report_date],[dyo_name],[dyo_review_date],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) OUTPUT INSERTED.asat_id INTO @tempTable
                             VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'
                                   ,'{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}') SELECT asat_id FROM @tempTable";
                    SQL = string.Format(SQL, asat_id, review_date_from, review_date_to, wrd_id, hhm_id, trade_id, module_id, youth_acquire_not_acquire_skill_reason, recommended_steps,
                        artisan_name, artisan_report_date, youth_skills_acquired, yn_skill_not_acquired_well, skill_not_acquired_well, skill_not_acquired_well_reason, youth_report_date, dyo_name, dyo_review_date, usr_id_create,
                        usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                    break;

                case "update":
                    SQL = @"UPDATE [dbo].[ben_apprenticeship_skill_acquisition_tracking]
                           SET [review_date_from] = '{1}',[review_date_to] =  '{2}',[wrd_id] =  '{3}',[hhm_id] =  '{4}'
                              ,[trade_id] =  '{5}',[module_id] =  '{6}',[youth_acquire_not_acquire_skill_reason] =  '{7}'
                              ,[recommended_steps] =  '{8}',[artisan_name] =  '{9}',[artisan_report_date] =  '{10}'
                              ,[youth_skills_acquired] =  '{11}',[yn_skill_not_acquired_well] =  '{12}',[skill_not_acquired_well] =  '{13}'
                              ,[skill_not_acquired_well_reason] =  '{14}',[youth_report_date] =  '{15}',[dyo_name] =  '{16}',[dyo_review_date] =  '{17}'
                              ,[usr_id_create] =  '{18}',[usr_id_update] =  '{19}',[usr_date_create] =  '{20}',[usr_date_update] =  '{21}',[ofc_id] =  '{22}'
                              ,[district_id] =  '{23}'
                         WHERE[asat_id] = '{0}'";
                    SQL = string.Format(SQL, asat_id, review_date_from, review_date_to, wrd_id, hhm_id, trade_id, module_id, youth_acquire_not_acquire_skill_reason, recommended_steps,
                       artisan_name, artisan_report_date, youth_skills_acquired, yn_skill_not_acquired_well, skill_not_acquired_well, skill_not_acquired_well_reason, youth_report_date, dyo_name, dyo_review_date, usr_id_create,
                       usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
                    break;
            }
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

                    switch (action) {
                        case "insert":
                            Outasat_id = (string)cmd.ExecuteScalar();
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
            if (action == "insert")
            {
                return Outasat_id;
            }
            else
            {
                return string.Empty;
            }
           
        }


        public static string Save_skills()
        {
            
        #region Variables
        string Outasat_id = string.Empty;
            string SQL = string.Empty;
            #endregion  Variables

            SQL = @"IF NOT EXISTS(SELECT* FROM ben_apprenticeship_skill_acquisition_tracking_skill WHERE asat_id = '{1}' AND module_id = '{2}' AND skill_id = '{3}')
                    BEGIN
	                    INSERT INTO [dbo].[ben_apprenticeship_skill_acquisition_tracking_skill]
                               ([asatskill_id],[asat_id],[module_id],[skill_id],[excellent_acquired_skr_id],[average_acquired_skr_id],[not_acquired_skr_id],[usr_id_create],[usr_id_update]
                               ,[usr_date_create],[usr_date_update],[ofc_id],[district_id])
		                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')
                    END ELSE BEGIN
	                    UPDATE [dbo].[ben_apprenticeship_skill_acquisition_tracking_skill]
                        SET [excellent_acquired_skr_id] = '{4}',[average_acquired_skr_id] = '{5}',[not_acquired_skr_id] = '{6}' WHERE [asat_id] = '{1}' AND [module_id] = '{2}' AND [skill_id] = '{3}'
                    END";

            SQL = string.Format(SQL,asatskill_id,asat_id,module_id,skill_id,excellent_acquired_skr_id,average_acquired_skr_id,not_acquired_skr_id,usr_id_create,usr_id_update,usr_date_create,usr_date_update,ofc_id,district_id);
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

                    if (excellent_acquired_skr_id != string.Empty || average_acquired_skr_id != string.Empty || not_acquired_skr_id != string.Empty)
                    {
                        cmd.ExecuteNonQuery();
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

            return Outasat_id;
        }
        #endregion Save

        #region Display
        public static DataTable Display(string asat_id,string record_type)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (record_type)
            {
                
                case "DisplayMain":
                    SQL = @"SELECT T.*,dst.dst_id,sct.sct_id,H.hh_id FROM ben_apprenticeship_skill_acquisition_tracking T
                            LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                            LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                            WHERE T.asat_id = '{0}'";
                    SQL = string.Format(SQL, asat_id);
                    break;
                case "DisplayLine":
                     SQL = @"SELECT skill_id,excellent_acquired_skr_id,average_acquired_skr_id,not_acquired_skr_id
                             FROM ben_apprenticeship_skill_acquisition_tracking_skill T WHERE asat_id = '{0}'";
                    SQL = string.Format(SQL, asat_id);
                    break;

                case "LoadList":
                    SQL = @"SELECT T.asat_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Apprentice Name]
                            FROM ben_apprenticeship_skill_acquisition_tracking T
                            LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                            LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                            LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                            LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                            LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id";
                    break;
            }
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
        #endregion Display


        #region Search
        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string youth_name, string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT T.asat_id, dst.dst_name AS District,sct.sct_name AS [Sub County],W.wrd_name AS [Parish],H.hh_code AS [Household Code],hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS [Apprentice Name]
                        FROM ben_apprenticeship_skill_acquisition_tracking T
                        LEFT JOIN lst_ward w on T.wrd_id = w.wrd_id
                        LEFT JOIN lst_sub_county sct on w.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst on sct.dst_id = dst.dst_id
                        LEFT JOIN hh_household_member hhm on T.hhm_id = hhm.hhm_id
                        LEFT JOIN hh_household H ON hhm.hh_id = H.hh_id
                        WHERE (@dst_id = '-1' OR dst.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR sct.sct_id = @sct_id)
                        AND ((@youth_name = '' OR hhm.hhm_first_name LIKE '%' + @youth_name  + '%') OR (@youth_name = '' OR hhm.hhm_last_name LIKE '%' + @youth_name  + '%') )
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

                    cmd.Parameters.Add("@youth_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@youth_name"].Value = youth_name;

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
        #endregion Search


    }
}
