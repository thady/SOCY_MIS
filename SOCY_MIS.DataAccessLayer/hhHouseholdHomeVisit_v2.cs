using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
   public static class hhHouseholdHomeVisit_v2
    {


        #region Variables
        #region hh_household_home_visit_v_2
        public static string hhv_id = string.Empty;
        public static DateTime hhv_date = DateTime.Now;
        public static DateTime hhv_date_next_visit = DateTime.Now;
        public static string hhv_comments = string.Empty;
        public static string hhv_next_steps = string.Empty;
        public static string ynna_risk_assessment = string.Empty;
        public static string ynna_new_referal = string.Empty;
        public static string ynna_old_referal_followup = string.Empty;
        public static string yn_hip = string.Empty;
        public static string hhv_swk_code = string.Empty;
        public static string hhv_visitor_tel = string.Empty;
        public static string hvhs_id = string.Empty;
        public static string hvr_id = string.Empty;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        public static string hnr_id_visitor = string.Empty;
        public static string swk_id = string.Empty;
        public static string swk_id_visitor = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;

        public static string previous_hiv_status = string.Empty;

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #endregion hh_household_home_visit_v_2

        #region hh_household_home_visit_member_v_2
        public static string hhvm_id = string.Empty;
        public static string hhm_name = string.Empty;
        public static string hmm_age = string.Empty;
        public static string gnd_name = string.Empty;
        public static string yn_id_hhm_active = string.Empty;
        public static string ynna_stb_id_SILC = string.Empty;
        public static string ynna_stb_id_other_saving_grp = string.Empty;
        public static string ynna_stb_caregiver_services = string.Empty;
        public static string ynna_stb_contributes_edu_fund = string.Empty;
        public static string ynna_stb_SAGE = string.Empty;
        public static string yn_stb_receive_social_grant = string.Empty;
        public static string ynna_stb_apprenticeship = string.Empty;
        public static string ynna_stb_cottage = string.Empty;
        public static string ynna_stb_agro_enterprise = string.Empty;
        public static string ynna_stb_aflateen = string.Empty;
        public static string ynna_stb_sch_ovc_edu_enrolled = string.Empty;
        public static string ynna_sch_re_enrollment_support = string.Empty;
        public static string ynna_sch_ovc_attend_school_regularly = string.Empty;
        public static string ynna_sch_ovc_receive_school_uniform = string.Empty;
        public static string ynna_sch_ovc_receive_edu_subsidy = string.Empty;
        public static string ynna_progressed_to_another_class = string.Empty;
        public static string hst_id = string.Empty;
        public static string ynna_on_art = string.Empty;
        public static string ynna_follow_art_prescription = string.Empty;
        public static string adherence_level = string.Empty;
        public static string ynna_hiv_literacy = string.Empty;
        public static string yn_hiv_counselling = string.Empty;
        public static string yn_hiv_adherence_support = string.Empty;
        public static string yn_hiv_prevention_support = string.Empty;
        public static string yn_wash_messages = string.Empty;
        public static string nutrition_assessment_result = string.Empty;
        public static string yn_initiate_hts_refferal = string.Empty;
        public static string yn_complete_hts_refferal = string.Empty;
        public static string ynna_initiate_art_refferal = string.Empty;
        public static string ynna_complete_art_refferal = string.Empty;
        public static string ynna_initiate_immunize_refferal = string.Empty;
        public static string ynna_complete_immunize_refferal = string.Empty;
        public static string ynna_tb_screen = string.Empty;
        public static string ynna_initiate_tb_refferal = string.Empty;
        public static string ynna_complete_tb_refferal = string.Empty;
        public static string hhm_inactive_reason = string.Empty;
        public static string ynna_initiate_perinatal_care_refferal = string.Empty;
        public static string ynna_complete_perinatal_care_refferal = string.Empty;
        public static string ynna_initiate_post_violence_refferal = string.Empty;
        public static string ynna_complete_post_violence_refferal = string.Empty;
        public static string ynna_ovc_has_birth_certificate = string.Empty;
        public static string ynna_initiate_birth_reg_refferal = string.Empty;
        public static string ynna_complete_birth_reg_refferal = string.Empty;
        public static string ynna_pss_family_group_discussion = string.Empty;
        public static string ynna_reported_to_police = string.Empty;
        public static string ynna_violence_evidence_based_intervention = string.Empty;
        public static string hhm_status = string.Empty;
        #endregion hh_household_home_visit_member_v_2
        #endregion Variables


        #region Save
        public static void Insert_home_visit(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[hh_household_home_visit_v_2]
           ([hhv_id],[hhv_date] ,[hhv_date_next_visit],[hhv_comments],[hhv_next_steps],[ynna_risk_assessment],[ynna_new_referal]
           ,[ynna_old_referal_followup],[yn_hip] ,[hhv_swk_code] ,[hhv_visitor_tel] ,[hvhs_id] ,[hvr_id] ,[hh_id],[hhm_id] ,[hnr_id_visitor],[swk_id]
           ,[swk_id_visitor] ,[usr_id_create] ,[usr_id_update],[usr_date_create] ,[usr_date_update],[ofc_id],[district_id])
            VALUES('{0}','{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}','{7}' ,'{8}' ,'{9}' ,'{10}' ,'{11}','{12}','{13}' ,'{14}' ,'{15}','{16}' ,'{17}' ,'{18}' ,'{19}' , GETDATE() ,GETDATE() ,'{20}' ,'{21}')";

            strSQL = string.Format(strSQL, hhv_id,
                hhv_date.ToString("dd MMM yyyy HH:mm:ss"), hhv_date_next_visit.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(hhv_comments), utilFormatting.StringForSQL(hhv_next_steps),
                ynna_risk_assessment, ynna_new_referal, ynna_old_referal_followup, yn_hip,
                utilFormatting.StringForSQL(hhv_swk_code), utilFormatting.StringForSQL(hhv_visitor_tel),
                hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor
                , usr_id_create, usr_id_update, ofc_id, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            update_hh_status(hh_id, hvhs_id);
            #endregion SQL

            if(hvhs_id != "1" && hvhs_id != "2")
            {
                Deactivate_household_members(hh_id);
            }
        }


        public static void Update_home_visit(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[hh_household_home_visit_v_2]
                       SET [hhv_date] = '{1}'
                          ,[hhv_date_next_visit] = '{2}'
                          ,[hhv_comments] = '{3}'
                          ,[hhv_next_steps] = '{4}'
                          ,[ynna_risk_assessment] = '{5}'
                          ,[ynna_new_referal] = '{6}'
                          ,[ynna_old_referal_followup] = '{7}'
                          ,[yn_hip] = '{8}'
                          ,[hhv_swk_code] = '{9}'
                          ,[hhv_visitor_tel] = '{10}'
                          ,[hvhs_id] = '{11}'
                          ,[hvr_id] = '{12}'
                          ,[hh_id] = '{13}'
                          ,[hhm_id] = '{14}'
                          ,[hnr_id_visitor] = '{15}'
                          ,[swk_id] = '{16}'
                          ,[swk_id_visitor] = '{17}'
                          ,[usr_id_update] = '{18}'
                          ,[usr_date_update] = GETDATE()
                          ,[ofc_id] = '{19}'
                          ,[district_id] = '{20}'
                     WHERE  [hhv_id] = '{0}'";


            strSQL = string.Format(strSQL, hhv_id,
                hhv_date.ToString("dd MMM yyyy HH:mm:ss"), hhv_date_next_visit.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(hhv_comments), utilFormatting.StringForSQL(hhv_next_steps),
                ynna_risk_assessment, ynna_new_referal, ynna_old_referal_followup, yn_hip,
                utilFormatting.StringForSQL(hhv_swk_code), utilFormatting.StringForSQL(hhv_visitor_tel),
                hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor
                , usr_id_update, ofc_id, district_id);

            dbCon.ExecuteNonQuery(strSQL);

            update_hh_status(hh_id, hvhs_id);
            #endregion SQL

            if (hvhs_id != "1" && hvhs_id != "2")
            {
                Deactivate_household_members(hh_id);
            }
        }

        

        public static void Insert_home_visit_member(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[hh_household_home_visit_member_v_2]
           ([hhvm_id] ,[hhm_id] ,[hhv_id],[hhm_name],[hmm_age],[gnd_name] ,[yn_id_hhm_active] ,[ynna_stb_id_SILC],[ynna_stb_id_other_saving_grp],[ynna_stb_caregiver_services]
           ,[ynna_stb_contributes_edu_fund] ,[ynna_stb_SAGE] ,[yn_stb_receive_social_grant],[ynna_stb_apprenticeship],[ynna_stb_cottage],[ynna_stb_agro_enterprise]
           ,[ynna_stb_aflateen] ,[ynna_stb_sch_ovc_edu_enrolled] ,[ynna_sch_re_enrollment_support]  ,[ynna_sch_ovc_attend_school_regularly] ,[ynna_sch_ovc_receive_school_uniform]
           ,[ynna_sch_ovc_receive_edu_subsidy],[ynna_progressed_to_another_class] ,[hst_id]  ,[ynna_on_art] ,[ynna_follow_art_prescription] ,[adherence_level] ,[ynna_hiv_literacy]
           ,[yn_hiv_counselling] ,[yn_hiv_adherence_support]  ,[yn_hiv_prevention_support] ,[yn_wash_messages] ,[nutrition_assessment_result],[yn_initiate_hts_refferal],[yn_complete_hts_refferal]
           ,[ynna_initiate_art_refferal] ,[ynna_complete_art_refferal],[ynna_initiate_immunize_refferal] ,[ynna_complete_immunize_refferal] ,[ynna_tb_screen],[ynna_initiate_tb_refferal],[ynna_complete_tb_refferal]
           ,[ynna_initiate_perinatal_care_refferal],[ynna_complete_perinatal_care_refferal],[ynna_initiate_post_violence_refferal] ,[ynna_complete_post_violence_refferal],[ynna_ovc_has_birth_certificate] ,[ynna_initiate_birth_reg_refferal]
           ,[ynna_complete_birth_reg_refferal],[ynna_pss_family_group_discussion],[ynna_reported_to_police],[ynna_violence_evidence_based_intervention],[usr_id_create],[usr_id_update],[usr_date_create]
           ,[usr_date_update],[ofc_id] ,[district_id],hhm_inactive_reason)
        VALUES ('{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}' ,'{16}','{17}'
           ,'{18}' ,'{19}','{20}' ,'{21}' ,'{22}' ,'{23}' ,'{24}' ,'{25}','{26}','{27}','{28}','{29}','{30}','{31}' ,'{32}','{33}'
           ,'{34}','{35}','{36}','{37}' ,'{38}' ,'{39}','{40}' ,'{41}','{42}','{43}' ,'{44}' ,'{45}','{46}' ,'{47}','{48}','{49}'
           ,'{50}' ,'{51}' ,'{52}' ,'{53}' ,GETDATE(),GETDATE(),'{54}','{55}','{56}')";

            strSQL = string.Format(strSQL, hhvm_id, hhm_id, hhv_id, hhm_name, hmm_age, gnd_name, yn_id_hhm_active, ynna_stb_id_SILC, ynna_stb_id_other_saving_grp, ynna_stb_caregiver_services
           , ynna_stb_contributes_edu_fund, ynna_stb_SAGE, yn_stb_receive_social_grant, ynna_stb_apprenticeship, ynna_stb_cottage, ynna_stb_agro_enterprise
           , ynna_stb_aflateen, ynna_stb_sch_ovc_edu_enrolled, ynna_sch_re_enrollment_support, ynna_sch_ovc_attend_school_regularly, ynna_sch_ovc_receive_school_uniform
           , ynna_sch_ovc_receive_edu_subsidy, ynna_progressed_to_another_class, hst_id, ynna_on_art, ynna_follow_art_prescription, adherence_level, ynna_hiv_literacy
           , yn_hiv_counselling, yn_hiv_adherence_support, yn_hiv_prevention_support, yn_wash_messages, nutrition_assessment_result, yn_initiate_hts_refferal, yn_complete_hts_refferal
           , ynna_initiate_art_refferal, ynna_complete_art_refferal, ynna_initiate_immunize_refferal, ynna_complete_immunize_refferal, ynna_tb_screen, ynna_initiate_tb_refferal, ynna_complete_tb_refferal
           , ynna_initiate_perinatal_care_refferal, ynna_complete_perinatal_care_refferal, ynna_initiate_post_violence_refferal, ynna_complete_post_violence_refferal, ynna_ovc_has_birth_certificate, ynna_initiate_birth_reg_refferal
           , ynna_complete_birth_reg_refferal, ynna_pss_family_group_discussion, ynna_reported_to_police, ynna_violence_evidence_based_intervention, usr_id_create, usr_id_update, ofc_id, district_id, hhm_inactive_reason);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }


        public static void update_home_visit_member(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[hh_household_home_visit_member_v_2]
                           SET [hhm_id] = '{1}'
                              ,[hhv_id] = '{2}'
                              ,[hhm_name] = '{3}'
                              ,[hmm_age] = '{4}'
                              ,[yn_id_hhm_active] = '{5}'
                              ,[ynna_stb_id_SILC] = '{6}'
                              ,[ynna_stb_id_other_saving_grp] = '{7}'
                              ,[ynna_stb_caregiver_services] = '{8}'
                              ,[ynna_stb_contributes_edu_fund] = '{9}'
                              ,[ynna_stb_SAGE] = '{10}'
                              ,[yn_stb_receive_social_grant] = '{11}'
                              ,[ynna_stb_apprenticeship] = '{12}'
                              ,[ynna_stb_cottage] = '{13}'
                              ,[ynna_stb_agro_enterprise] = '{14}'
                              ,[ynna_stb_aflateen] = '{15}'
                              ,[ynna_stb_sch_ovc_edu_enrolled] = '{16}'
                              ,[ynna_sch_re_enrollment_support] = '{17}'
                              ,[ynna_sch_ovc_attend_school_regularly] = '{18}'
                              ,[ynna_sch_ovc_receive_school_uniform] = '{19}'
                              ,[ynna_sch_ovc_receive_edu_subsidy] = '{20}'
                              ,[ynna_progressed_to_another_class] = '{21}'
                              ,[hst_id] = '{22}'
                              ,[ynna_on_art] = '{23}'
                              ,[ynna_follow_art_prescription] = '{24}'
                              ,[adherence_level] = '{25}'
                              ,[ynna_hiv_literacy] = '{26}'
                              ,[yn_hiv_counselling] = '{27}'
                              ,[yn_hiv_adherence_support] = '{28}'
                              ,[yn_hiv_prevention_support] = '{29}'
                              ,[yn_wash_messages] = '{30}'
                              ,[nutrition_assessment_result] = '{31}'
                              ,[yn_initiate_hts_refferal] = '{32}'
                              ,[yn_complete_hts_refferal] = '{33}'
                              ,[ynna_initiate_art_refferal] = '{34}'
                              ,[ynna_complete_art_refferal] = '{35}'
                              ,[ynna_initiate_immunize_refferal] = '{36}'
                              ,[ynna_complete_immunize_refferal] = '{37}'
                              ,[ynna_tb_screen] = '{38}'
                              ,[ynna_initiate_tb_refferal] = '{39}'
                              ,[ynna_initiate_perinatal_care_refferal] = '{40}'
                              ,[ynna_complete_perinatal_care_refferal] = '{41}'
                              ,[ynna_initiate_post_violence_refferal] = '{42}'
                              ,[ynna_complete_post_violence_refferal] = '{43}'
                              ,[ynna_ovc_has_birth_certificate] = '{44}'
                              ,[ynna_initiate_birth_reg_refferal] = '{45}'
                              ,[ynna_complete_birth_reg_refferal] = '{46}'
                              ,[ynna_pss_family_group_discussion] = '{47}'
                              ,[ynna_reported_to_police] = '{48}'
                              ,[ynna_violence_evidence_based_intervention] = '{49}'
                              ,[usr_id_update] = '{50}'
                              ,[usr_date_update] = GETDATE()
                              ,[ofc_id] = '{51}'
                              ,[district_id] ='{52}'
                              ,[gnd_name] = '{53}'
                              ,[ynna_complete_tb_refferal] = '{54}'
                              ,hhm_inactive_reason = '{55}'
                         WHERE  [hhvm_id] = '{0}'";

            strSQL = string.Format(strSQL, hhvm_id, hhm_id, hhv_id, hhm_name, hmm_age, yn_id_hhm_active, ynna_stb_id_SILC, ynna_stb_id_other_saving_grp, ynna_stb_caregiver_services
           , ynna_stb_contributes_edu_fund, ynna_stb_SAGE, yn_stb_receive_social_grant, ynna_stb_apprenticeship, ynna_stb_cottage, ynna_stb_agro_enterprise
           , ynna_stb_aflateen, ynna_stb_sch_ovc_edu_enrolled, ynna_sch_re_enrollment_support, ynna_sch_ovc_attend_school_regularly, ynna_sch_ovc_receive_school_uniform
           , ynna_sch_ovc_receive_edu_subsidy, ynna_progressed_to_another_class, hst_id, ynna_on_art, ynna_follow_art_prescription, adherence_level, ynna_hiv_literacy
           , yn_hiv_counselling, yn_hiv_adherence_support, yn_hiv_prevention_support, yn_wash_messages, nutrition_assessment_result, yn_initiate_hts_refferal, yn_complete_hts_refferal
           , ynna_initiate_art_refferal, ynna_complete_art_refferal, ynna_initiate_immunize_refferal, ynna_complete_immunize_refferal, ynna_tb_screen, ynna_initiate_tb_refferal
           , ynna_initiate_perinatal_care_refferal, ynna_complete_perinatal_care_refferal, ynna_initiate_post_violence_refferal, ynna_complete_post_violence_refferal, ynna_ovc_has_birth_certificate, ynna_initiate_birth_reg_refferal
           , ynna_complete_birth_reg_refferal, ynna_pss_family_group_discussion, ynna_reported_to_police, ynna_violence_evidence_based_intervention, usr_id_update, ofc_id, district_id,gnd_name, ynna_complete_tb_refferal, hhm_inactive_reason);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        #endregion Save


        public static void update_member_hiv_status(string hhm_id, string hst_id)
        {
            string crop_name = string.Empty;

            string SQL = "UPDATE hh_household_member SET hst_id_new = '{0}' WHERE hhm_id = '{1}' AND hst_id_new <> '1'";
            SQL = string.Format(SQL, hst_id,hhm_id);
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


        public static void update_hh_status(string hh_id, string hhs_id)
        {
            string crop_name = string.Empty;

            string SQL = "UPDATE hh_household SET hhs_id = '{0}',district_id = '{2}' WHERE hh_id = '{1}'";
            SQL = string.Format(SQL, hhs_id, hh_id, SystemConstants.Return_office_district());
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

        public static void Deactivate_household_members(string hh_id)
        {
            string crop_name = string.Empty;

            string SQL = "UPDATE hh_household_member SET hhm_status = '0' WHERE hh_id = '{0}'";
            SQL = string.Format(SQL, hh_id);
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

        public static void update_member_hmm_status(string hhm_id, string hhm_status)
        {
            string crop_name = string.Empty;

            string SQL = "UPDATE hh_household_member SET hhm_status = '{0}' WHERE hhm_id = '{1}' AND hhm_status <> '0'";
            SQL = string.Format(SQL, hhm_status, hhm_id);
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

        public static DataTable LoadMembers(string hh_id,string hhv_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"With CteA AS (
                        SELECT hhvm.hhm_id AS hhm_id FROM hh_household_home_visit_v_2 hhv 
                        LEFT JOIN hh_household_home_visit_member_v_2 hhvm ON hhv.hhv_id = hhvm.hhv_id
                        WHERE hhv.hh_id = '{0}' AND hhv.hhv_id = '{1}'
                        )
                        SELECT hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,hhm.hhm_id FROM hh_household_member hhm LEFT JOIN  CteA A ON hhm.hhm_id = A.hhm_id
                        WHERE hhm.hh_id =  '{0}'
                        AND A.hhm_id is NULL
                        AND hhm.hhm_status = '1'
                        ORDER BY hhm.hhm_number ASC";
            strSQL = string.Format(strSQL,hh_id,hhv_id);

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

        public static DataTable LoadMemberDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hhm.hhm_year_of_birth,hhm.hhm_number,gnd.gnd_name,hhm.hst_id,hhm.hst_id_new FROM hh_household_member hhm
                      INNER JOIN lst_gender gnd ON hhm.gnd_id = gnd.gnd_id
                       WHERE hhm.hhm_id = '{0}'";

            strSQL = string.Format(strSQL, hhm_id);

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


        public static bool LoadMemberHATBaselineDetails(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;
            bool HasBaselineData = false;

            strSQL = @"SELECT* FROM hh_household_member WHERE (hst_id = '' OR hst_id = '-1') AND hhm_id = '{0}'";

            strSQL = string.Format(strSQL, hhm_id);

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
                        HasBaselineData = false;
                    }
                    else
                    {
                        HasBaselineData = true;
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

            return HasBaselineData;
        }


        public static DataTable LoadHomeVisitMembers(string hhv_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hhm.hhm_number,hhm.hhm_first_name,hhm.hhm_last_name,hhvm.gnd_name,hhm.hhm_year_of_birth,hhvm.hhvm_id
                        FROM hh_household_home_visit_member_v_2 hhvm
                        INNER JOIN hh_household_member hhm ON hhvm.hhm_id = hhm.hhm_id
                        WHERE hhv_id = '{0}'";

            strSQL = string.Format(strSQL, hhv_id);

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


        public static DataTable LoadHomeVisitMemberDetails(string hhvm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT* FROM hh_household_home_visit_member_v_2 WHERE hhvm_id = '{0}'";

            strSQL = string.Format(strSQL, hhvm_id);

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


        public static DataTable LoadHouseholdCode(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @" SELECT hh_code FROM hh_household WHERE hh_id = '{0}'";

            strSQL = string.Format(strSQL, hh_id);

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


        public static DataTable LoadHIVstatus()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT hst_id,hst_name FROM lst_hiv_status";

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

        public static DataTable LoadHomeVisitDisplay(string hhv_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;

            strSQL = @"SELECT* FROM hh_household_home_visit_v_2 WHERE hhv_id = '{0}'";
            strSQL = string.Format(strSQL,hhv_id);
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

        public static string LoadPrevHIVStatus(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string strSQL = string.Empty;
            string hst_id = string.Empty;

            strSQL = @"SELECT hst_id_new FROM hh_household_member WHERE hhm_id = '{0}'";
            strSQL = string.Format(strSQL, hhm_id);
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
                        hst_id = dtRow["hst_id_new"].ToString();

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

            return hst_id;
        }

    }
}
