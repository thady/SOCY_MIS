using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace SOCY_MIS.DataAccessLayer
{
    public class benEducationSubsidy
    {
        #region Variables
        public static string ed_sub_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string dst_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string village = string.Empty;
        public static DateTime assessment_date = DateTime.Today;
        public static string hhm_id_caregiver = string.Empty;
        public static string caregiver_phone = string.Empty;
        public static string hh_id = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string ed_subm_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string gnd_id = string.Empty;
        public static string YOB = string.Empty;
        public static string last_class_completed = string.Empty;
        public static string prev_school = string.Empty;
        public static string drop_out_year = string.Empty;
        public static string dropout_reason = string.Empty;
        public static string yn_id_willing_to_study = string.Empty;
        public static string enrollment_class = string.Empty;
        public static string ttps_id = string.Empty;
        public static string preffered_school = string.Empty;
        public static string caregiver_contribution = string.Empty;
        public static string yn_id_hh_head_in_silc_grp = string.Empty;
        public static string yn_id_caregiver_commit_sch_attendance = string.Empty;
        public static string yn_id_caregiver_commit_pta_meeting = string.Empty;
        public static string yn_id_caregiver_commit_acad_performance = string.Empty;
        public static string yn_id_caregiver_commit_project_interventions = string.Empty;
        public static string yn_id_caregiver_commit_contribute_fee = string.Empty;
        public static string yn_id_caregiver_commit_keep_child_in_sch = string.Empty;
        public static string swk_id = string.Empty;
        public static string swk_phone = string.Empty;
        public static string psw_id = string.Empty;
        public static string psw_phone = string.Empty;

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection
        #endregion Variables

        #region Save
        public static string save_update_EducationSubsidyAssessment(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ed_sub_id nvarchar(100)) INSERT INTO [dbo].[ben_education_subsidy_assessment]
                   ([ed_sub_id],[prt_id],[cso_id],[dst_id],[sct_id],[wrd_id],[village],[assessment_date],[hhm_id_caregiver],[caregiver_phone],[hh_id],[usr_id_create]
                   ,[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) OUTPUT inserted.ed_sub_id INTO @tempTable
                 VALUES
                   ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' ,'{8}' ,'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}') SELECT ed_sub_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_education_subsidy_assessment]
                           SET [dst_id] = '{1}'
                               ,[sct_id] = '{2}'
                              ,[wrd_id] = '{3}'
                              ,[prt_id] = '{4}'
                              ,[cso_id] = '{5}'
                              ,[village] = '{6}'
                              ,[assessment_date] = '{7}'
                              ,[hhm_id_caregiver] = '{8}'
                               ,[caregiver_phone] = '{9}'
                              ,[hh_id] = '{10}'
                              ,[usr_id_update] = '{11}'
                              ,[usr_date_update] = '{12}'
                         WHERE ed_sub_id = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query,ed_sub_id,prt_id,cso_id,dst_id,sct_id,wrd_id,village,assessment_date, hhm_id_caregiver, caregiver_phone, hh_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query,ed_sub_id,dst_id,sct_id,wrd_id,prt_id,cso_id,village,assessment_date, hhm_id_caregiver, caregiver_phone, hh_id, usr_id_update, usr_date_update);

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
                        ed_sub_id = (string)cmd.ExecuteScalar();
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
                return ed_sub_id;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string save_update_EducationSubsidyAssessmentMember(string action)
        {
            string Query = string.Empty;


            if (action == "insert")
            {
                //insert
                Query = @"INSERT INTO [dbo].[ben_education_subsidy_assessment_member]
                       ([ed_subm_id],[ed_sub_id],[hhm_id],[last_class_completed],[prev_school],[drop_out_year],[dropout_reason],[yn_id_willing_to_study]
                       ,[enrollment_class],[ttps_id],[preffered_school],[caregiver_contribution],[yn_id_hh_head_in_silc_grp]
                       ,[yn_id_caregiver_commit_sch_attendance],[yn_id_caregiver_commit_pta_meeting],[yn_id_caregiver_commit_acad_performance]
                       ,[yn_id_caregiver_commit_project_interventions],[yn_id_caregiver_commit_contribute_fee],[yn_id_caregiver_commit_keep_child_in_sch]
                       ,[swk_id],[swk_phone],[psw_id],[psw_phone],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                 VALUES
                       ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'
                       ,'{15}','{16}' ,'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}')";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_education_subsidy_assessment_member]
                       SET [hhm_id] = '{1}'
                          ,[last_class_completed] = '{2}'
                          ,[prev_school] = '{3}'
                          ,[drop_out_year] = '{4}'
                          ,[dropout_reason] = '{5}'
                          ,[yn_id_willing_to_study] = '{6}'
                          ,[enrollment_class] = '{7}'
                          ,[ttps_id] = '{8}'
                          ,[preffered_school] = '{9}'
                          ,[caregiver_contribution] = '{10}'
                          ,[yn_id_hh_head_in_silc_grp] = '{11}'
                          ,[yn_id_caregiver_commit_sch_attendance] = '{12}'
                          ,[yn_id_caregiver_commit_pta_meeting] = '{13}'
                          ,[yn_id_caregiver_commit_acad_performance] = '{14}'
                          ,[yn_id_caregiver_commit_project_interventions] = '{15}'
                          ,[yn_id_caregiver_commit_contribute_fee] = '{16}'
                          ,[yn_id_caregiver_commit_keep_child_in_sch] = '{17}'
                          ,[swk_id] = '{18}'
                          ,[swk_phone] = '{19}'
                          ,[psw_id] = '{20}'
                           ,[psw_phone] = '{21}'
                          ,[usr_id_update] = '{22}'
                          ,[usr_date_update] = '{23}'
                     WHERE [ed_subm_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ed_subm_id, ed_sub_id, hhm_id, last_class_completed, prev_school, drop_out_year, dropout_reason, yn_id_willing_to_study, enrollment_class, ttps_id,
                        preffered_school, caregiver_contribution, yn_id_hh_head_in_silc_grp, yn_id_caregiver_commit_sch_attendance, yn_id_caregiver_commit_pta_meeting, yn_id_caregiver_commit_acad_performance,
                        yn_id_caregiver_commit_project_interventions, yn_id_caregiver_commit_contribute_fee, yn_id_caregiver_commit_keep_child_in_sch, swk_id, swk_phone, psw_id, psw_phone, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ed_subm_id, hhm_id, last_class_completed, prev_school, drop_out_year, dropout_reason, yn_id_willing_to_study, enrollment_class, ttps_id, 
                        preffered_school, caregiver_contribution, yn_id_hh_head_in_silc_grp, yn_id_caregiver_commit_sch_attendance, yn_id_caregiver_commit_pta_meeting, yn_id_caregiver_commit_acad_performance, 
                        yn_id_caregiver_commit_project_interventions, yn_id_caregiver_commit_contribute_fee, yn_id_caregiver_commit_keep_child_in_sch, swk_id, swk_phone, psw_id, psw_phone, usr_id_update,usr_date_update);

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
                        ed_sub_id = (string)cmd.ExecuteScalar();
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
                return ed_sub_id;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion Save

        public static DataTable Return_SocialWorkerList(int dst_id, string sct_id,string socialWorkerType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            if (socialWorkerType == "PSW")
            {
                SQL = "SELECT S.swk_id,S.swk_first_name + ' ' + S.swk_last_name AS swk_name FROM swm_social_worker S " +
                        "LEFT JOIN lst_ward W ON S.wrd_id = W.wrd_id " +
                        "LEFT JOIN lst_sub_county SB ON W.sct_id = SB.sct_id " +
                        "LEFT JOIN lst_district D ON SB.dst_id = D.dst_id " +
                        "WHERE S.swt_id = 2 " +
                        "AND D.dst_id = '" + dst_id + "'";
            }
            else
            {
                SQL = "SELECT S.swk_id,S.swk_first_name + ' ' + S.swk_last_name AS swk_name FROM swm_social_worker S " +
                        "LEFT JOIN lst_ward W ON S.wrd_id = W.wrd_id " +
                        "LEFT JOIN lst_sub_county SB ON W.sct_id = SB.sct_id " +
                        "LEFT JOIN lst_district D ON SB.dst_id = D.dst_id " +
                        "WHERE S.swt_id = 1 " +
                        "AND D.dst_id = '" + dst_id + "'";
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

        public static string Return_SocialWorkerPhone(string swk_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string swk_phone = string.Empty;

                SQL = "SELECT swk_phone FROM swm_social_worker WHERE swk_id = '"+ swk_id +"' ";
                        
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

                    if (dt.Rows.Count != 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        swk_phone = dtRow["swk_phone"].ToString();
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

        public static DataTable ReturnApprenticeshipTrainings()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = "SELECT ttps_name,ttps_id FROM lst_es_training_type_session WHERE ttp_id = 4 ";

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

        public static DataTable ReturnAssessmentDetails(string edu_sub_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = "SELECT* FROM ben_education_subsidy_assessment WHERE ed_sub_id = '{0}'";
                SQL = string.Format(SQL, edu_sub_id);

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
                        
                        ed_sub_id = dtRow["ed_sub_id"].ToString();
                        prt_id = dtRow["prt_id"].ToString();
                        cso_id = dtRow["cso_id"].ToString();
                        dst_id = dtRow["dst_id"].ToString();
                        sct_id = dtRow["sct_id"].ToString();
                        wrd_id = dtRow["wrd_id"].ToString();
                        village = dtRow["village"].ToString();
                        assessment_date = Convert.ToDateTime(dtRow["assessment_date"]);
                        hhm_id_caregiver = dtRow["hhm_id_caregiver"].ToString();
                        caregiver_phone = dtRow["caregiver_phone"].ToString();
                        hh_id = dtRow["hh_id"].ToString();

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

        public static DataTable ReturnAssessmentMemberDetails(string edu_subm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT M.*,hhm.hhm_year_of_birth,G.gnd_id FROM ben_education_subsidy_assessment_member M
                    LEFT JOIN hh_household_member hhm ON M.hhm_id = hhm.hhm_id
                    LEFT JOIN lst_gender G ON hhm.gnd_id = G.gnd_id
                    WHERE M.ed_subm_id = '{0}'";
                SQL = string.Format(SQL, edu_subm_id);

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

                        ed_sub_id = dtRow["ed_sub_id"].ToString();
                        ed_subm_id = dtRow["ed_subm_id"].ToString();
                        hhm_id = dtRow["hhm_id"].ToString();
                        gnd_id = dtRow["gnd_id"].ToString();
                        YOB = dtRow["hhm_year_of_birth"].ToString();
                        last_class_completed = dtRow["last_class_completed"].ToString();
                        prev_school = dtRow["prev_school"].ToString();
                        drop_out_year = dtRow["drop_out_year"].ToString();
                        dropout_reason = dtRow["dropout_reason"].ToString();
                        yn_id_willing_to_study = dtRow["yn_id_willing_to_study"].ToString();
                        enrollment_class = dtRow["enrollment_class"].ToString();
                        ttps_id = dtRow["ttps_id"].ToString();
                        preffered_school = dtRow["preffered_school"].ToString();
                        caregiver_contribution = dtRow["caregiver_contribution"].ToString();
                        yn_id_hh_head_in_silc_grp = dtRow["yn_id_hh_head_in_silc_grp"].ToString();
                        yn_id_caregiver_commit_sch_attendance = dtRow["yn_id_caregiver_commit_sch_attendance"].ToString();
                        yn_id_caregiver_commit_pta_meeting = dtRow["yn_id_caregiver_commit_pta_meeting"].ToString();
                        yn_id_caregiver_commit_acad_performance = dtRow["yn_id_caregiver_commit_acad_performance"].ToString();
                        yn_id_caregiver_commit_project_interventions = dtRow["yn_id_caregiver_commit_project_interventions"].ToString();
                        yn_id_caregiver_commit_contribute_fee = dtRow["yn_id_caregiver_commit_contribute_fee"].ToString();
                        yn_id_caregiver_commit_keep_child_in_sch = dtRow["yn_id_caregiver_commit_keep_child_in_sch"].ToString();
                        swk_id = dtRow["swk_id"].ToString();
                        swk_phone = dtRow["swk_phone"].ToString();
                        psw_id = dtRow["psw_id"].ToString();
                        psw_phone = dtRow["psw_phone"].ToString();
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

        public static DataTable ReturnAssessmentList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT H.hh_code,A.assessment_date, dst.dst_name,sct.sct_name,W.wrd_name,A.ed_sub_id
                    FROM ben_education_subsidy_assessment A 
                    LEFT JOIN hh_household H ON A.hh_id = H.hh_id
                    LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_id
                    LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                    LEFT JOIN lst_district dst ON dst.dst_id = sct.dst_id
                    LEFT JOIN hh_ovc_identification_prioritization I ON H.hh_id = I.hh_id
                    LEFT JOIN lst_cso C ON I.cso_id = C.cso_id
                    LEFT JOIN lst_partner prt ON C.prt_id = prt.prt_id ";

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

        public static DataTable ReturnAssessmentList(string dst_id, string sct_id, string prt_id, string cso_id, string wrd_id,string hh_code)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT H.hh_code,A.assessment_date, dst.dst_name,sct.sct_name,W.wrd_name,A.ed_sub_id
                        FROM ben_education_subsidy_assessment A 
                        LEFT JOIN hh_household H ON A.hh_id = H.hh_id
                        LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_id
                        LEFT JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        LEFT JOIN lst_district dst ON dst.dst_id = sct.dst_id
                        LEFT JOIN hh_ovc_identification_prioritization I ON H.hh_id = I.hh_id
                        LEFT JOIN lst_cso C ON I.cso_id = C.cso_id
                        LEFT JOIN lst_partner prt ON C.prt_id = prt.prt_id
                        WHERE (@dst_id = '-1' OR A.dst_id = @dst_id )
                        AND (@sct_id = '-1' OR A.sct_id = @sct_id)
                        AND (@prt_id = '-1' OR A.prt_id = @prt_id)
                        AND (@cso_id = '-1' OR A.cso_id = @cso_id)
                        AND (@wrd_id = '-1' OR A.wrd_id = @wrd_id)
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

        public static DataTable ReturnAssessmentMemberList(string ed_sub_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,M.ed_subm_id,hhm.hhm_id
                    FROM ben_education_subsidy_assessment_member M
                    LEFT JOIN hh_household_member hhm ON M.hhm_id = hhm.hhm_id
                    LEFT JOIN ben_education_subsidy_assessment A ON M.ed_sub_id = A.ed_sub_id
                    WHERE A.ed_sub_id = '{0}' ";

                SQL = string.Format(SQL, ed_sub_id);

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

        public static DataTable ReturnHHAssessmentChildren(string ed_sub_id,string hh_id,string AssessmentType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (AssessmentType) {
                    case "Existing":
                        SQL = @"SELECT HHM.hhm_id,(HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name   FROM hh_household_member HHM
                                LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                                LEFT JOIN ben_education_subsidy_assessment_member M ON HHM.hhm_id = M.hhm_id
                                LEFT JOIN ben_education_subsidy_assessment A ON M.ed_sub_id = A.ed_sub_id
                                WHERE HHM.hhm_id NOT IN(SELECT MM.hhm_id FROM ben_education_subsidy_assessment_member MM WHERE MM.ed_sub_id = '{0}')
                                AND YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) >= 6 AND YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) <= 18 AND HHM.hhm_year_of_birth <> '*'
                                AND HHM.hh_id = '{1}'";

                        SQL = string.Format(SQL, ed_sub_id, hh_id);
                        break;
                    case "NewAssessment":
                        SQL = @"SELECT HHM.hhm_id,(HHM.hhm_first_name + ' ' + HHM.hhm_last_name) AS hhm_name   FROM hh_household_member HHM
                                LEFT JOIN hh_household H ON HHM.hh_id = H.hh_id
                                LEFT JOIN ben_education_subsidy_assessment_member M ON HHM.hhm_id = M.hhm_id
                                LEFT JOIN ben_education_subsidy_assessment A ON M.ed_sub_id = A.ed_sub_id
                                WHERE YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) >= 6 AND YEAR(GETDATE()) - CAST(HHM.hhm_year_of_birth AS INT) <= 18
                                AND H.hh_id = '{0}'";

                        SQL = string.Format(SQL,hh_id);
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

        public static string ReturnHHVillage(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            string hh_village = string.Empty;
            try
            {
               
                SQL = @"SELECT hh_village FROM hh_household WHERE hh_id = '{0}'";

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
                        DataRow dtRow = dt.Rows[0];
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

        public static bool HouseholdAssessmentExists(string hh_id)
        {
            string SQL = string.Empty;
            int count = 0;
            bool HouseholdExist = false;
            try
            {
                SQL = "SELECT COUNT(hh_id) FROM ben_education_subsidy_assessment WHERE hh_id = '{0}'";
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
                    count = (int)cmd.ExecuteScalar();
                    if (count > 0) { HouseholdExist = true; }
                    else
                        HouseholdExist = false;
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

            return HouseholdExist;
        }

        public static DataTable ReturnChildSex_YOB(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @"SELECT hhm.hhm_year_of_birth,G.gnd_id FROM hh_household_member hhm
                        LEFT JOIN lst_gender G ON hhm.gnd_id = G.gnd_id
                        WHERE hhm.hhm_id = '{0}'";

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
    }
}
