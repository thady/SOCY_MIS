using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
   public static class hhHouseholdRiskAssessment
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection

        #region hh_household_risk_assessment
        public static DateTime scr_date = DateTime.Now;
        public static string hh_id = string.Empty;
        public static string hhm_id = string.Empty;
        #endregion hh_household_risk_assessment

        #region  hh_household_risk_assessment_member_child   
        public static string ram_id = string.Empty;
        public static string ra_id = string.Empty;
        public static string hhm_name = string.Empty;
        public static string gnd_name = string.Empty;
        public static string gnd_age = string.Empty;
        public static string ra_criteria_id = string.Empty;
        public static string yn_mother_hiv_pos = string.Empty;
        public static string yn_lost_bio_parent = string.Empty;
        public static string yn_malnourished = string.Empty;
        public static string yn_skin_problem = string.Empty;
        public static string yn_hospitalized = string.Empty;
        public static string yn_sexual_violence_exposed = string.Empty;
        public static string yn_acc_exposure_sharp_injury = string.Empty;
        public static string yn_drug_abuse = string.Empty;
        public static string yn_hhm_at_risk = string.Empty;
        public static string yn_hmm_test = string.Empty;
        public static string yn_hhm_accept_test = string.Empty;
        public static string yn_referal = string.Empty;
        public static string yn_referal_completed = string.Empty;
        public static string test_result = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion hh_household_risk_assessment_member_child

        #region hh_household_risk_assessment_member_adult
        public static string yn_hiv_test = string.Empty;
        public static string yn_unprotected_sex = string.Empty;
        public static string yn_sex_worker = string.Empty;
        public static string yn_lost_sexual_partner = string.Empty;
        public static string yn_tb_disease = string.Empty;
        public static string yn_sexual_violence = string.Empty;
        public static string yn_sickly = string.Empty;
        public static string yn_pregnant_not_tested = string.Empty;
        public static string yn_breast_feeding_not_tested = string.Empty;
        public static string yn_hiv_neg_discodant_not_tested = string.Empty;
        public static string yn_sti = string.Empty;
        public static string yn_hepatitis_b = string.Empty;
        public static string yn_male_female_not_tested = string.Empty;
        #endregion hh_household_risk_assessment_member_adult

        public static DataTable ReturnHHDetails(string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT hh.hh_id,W.wrd_id,sct.sct_id,dst.dst_id,hh.hh_code,hh.hh_village FROM hh_household hh
                        INNER JOIN lst_ward W ON hh.wrd_id = W.wrd_id
                        INNER JOIN lst_sub_county sct ON W.sct_id = sct.sct_id
                        INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id
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

        public static DataTable ReturnCriteriaList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT cr_id,cr_name FROM lst_risk_assessment_criteria";

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

        public static DataTable ReturnCriteriaListAdults()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT cr_id,cr_name FROM lst_risk_assessment_criteria WHERE cr_id <> '3'";

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

        public static DataTable ReturnMembers(string ageCategory,string ra_id,string hh_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                if (ageCategory == "child")
                {
                    SQL = @"With CteA AS (
                            SELECT hhm.hhm_id AS hhm_id FROM hh_household_risk_assessment rat 
	                            LEFT JOIN hh_household_risk_assessment_member_child hhm ON rat.ra_id = hhm.ra_id
	                            WHERE rat.ra_id = '{0}' AND rat.hh_id = '{1}'
                            )
                            SELECT hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,hhm.hhm_id FROM hh_household_member hhm LEFT JOIN  CteA A ON hhm.hhm_id = A.hhm_id
                            WHERE hhm.hh_id =  '{1}'
                            AND A.hhm_id is NULL
                            AND (YEAR(GETDATE()) - hhm.hhm_year_of_birth) < 18
                            ORDER BY hhm.hhm_first_name + ' ' + hhm.hhm_last_name ASC";

                    SQL = string.Format(SQL, ra_id, hh_id);
                }
                else if(ageCategory == "adult")
                {
                    SQL = @"With CteA AS (
                            SELECT hhm.hhm_id AS hhm_id FROM hh_household_risk_assessment rat 
	                            LEFT JOIN hh_household_risk_assessment_member_adult hhm ON rat.ra_id = hhm.ra_id
	                            WHERE rat.ra_id = '{0}' AND rat.hh_id = '{1}'
                            )
                            SELECT hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name,hhm.hhm_id FROM hh_household_member hhm LEFT JOIN  CteA A ON hhm.hhm_id = A.hhm_id
                            WHERE hhm.hh_id =  '{1}'
                            AND A.hhm_id is NULL
                            AND (YEAR(GETDATE()) - hhm.hhm_year_of_birth) > 17
                            ORDER BY hhm.hhm_first_name + ' ' + hhm.hhm_last_name ASC";

                    SQL = string.Format(SQL,ra_id, hh_id);
                }
               
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

        public static DataTable ReturnMembers(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {

                SQL = @"SELECT gnd.gnd_name,(YEAR(GETDATE()) - hhm.hhm_year_of_birth) AS Age FROM hh_household_member hhm
                        INNER JOIN lst_gender gnd ON hhm.gnd_id = gnd.gnd_id
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


        public static DataTable ReturnDisplayLine(string ra_id,string returnType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (returnType)
                {
                    case "adult":
                        SQL = @" SELECT ram_id, hhm_name AS [Member Name],gnd_name AS Gender,gnd_age AS Age FROM hh_household_risk_assessment_member_adult
                        WHERE ra_id = '{0}'";

                        SQL = string.Format(SQL, ra_id);
                        break;
                    case "child":
                        SQL = @" SELECT ram_id, hhm_name AS [Member Name],gnd_name AS Gender,gnd_age AS Age FROM hh_household_risk_assessment_member_child
                        WHERE ra_id = '{0}'";

                        SQL = string.Format(SQL, ra_id);
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


        public static DataTable LoadRATDetails(string id,string returnType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                if (returnType == "main")
                {
                    SQL = @"SELECT* FROM hh_household_risk_assessment WHERE ra_id = '{0}'";
                    SQL = string.Format(SQL, id);
                }
                else if (returnType == "adult")
                {
                    SQL = @"SELECT* FROM hh_household_risk_assessment_member_adult WHERE ram_id = '{0}'";
                    SQL = string.Format(SQL, id);
                }
                else if (returnType == "child")
                {
                    SQL = @"SELECT* FROM hh_household_risk_assessment_member_child WHERE ram_id = '{0}'";
                    SQL = string.Format(SQL, id);
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

        #region save
        public static void save_hh_household_risk_assessment(string action)
        {
            string strSQL = string.Empty;

            #region save
            if (action == "insert")
            {
                strSQL = @"INSERT INTO [dbo].[hh_household_risk_assessment]([ra_id],[hh_id],[scr_date],[hhm_id],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                        VALUES ('{0}','{1}','{2}' ,'{3}','{4}','{5}' ,'{6}' ,'{7}','{8}','{9}')";

                strSQL = string.Format(strSQL, ra_id, hh_id, scr_date, hhm_id, usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);
            }
            else if (action == "update")
            {
                strSQL = @"UPDATE [dbo].[hh_household_risk_assessment]
                           SET [scr_date] = '{1}'
                              ,[hhm_id] = '{2}'
                              ,[usr_id_update] ='{3}'
                              ,[usr_date_update] = '{4}'
                         WHERE [ra_id] = '{0}'";

                strSQL = string.Format(strSQL, ra_id,scr_date, hhm_id, usr_id_update, usr_date_update);
            }
            #endregion save

            try
            {

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


        public static void save_hh_household_risk_assessment_member_adult(string action)
        {
            string strSQL = string.Empty;

            #region save
            if (action == "save")
            {
                strSQL = @"INSERT INTO [dbo].[hh_household_risk_assessment_member_adult]
                           ([ram_id] ,[ra_id],[hhm_id],[hhm_name],[gnd_name],[gnd_age],[ra_criteria_id] ,[yn_hiv_test],[yn_unprotected_sex],[yn_sex_worker] ,[yn_lost_sexual_partner]
                           ,[yn_tb_disease],[yn_sexual_violence],[yn_sickly],[yn_pregnant_not_tested],[yn_breast_feeding_not_tested] ,[yn_hiv_neg_discodant_not_tested],[yn_sti] ,[yn_hepatitis_b]
                           ,[yn_male_female_not_tested] ,[yn_hhm_at_risk],[yn_hmm_test],[yn_hhm_accept_test],[yn_referal],[yn_referal_completed] ,[test_result],[usr_id_create],[usr_id_update]
                           ,[usr_date_create],[usr_date_update],[ofc_id] ,[district_id])
                     VALUES('{0}' ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}'
                           ,'{16}' ,'{17}' ,'{18}' ,'{19}' ,'{20}','{21}' ,'{22}' ,'{23}' ,'{24}' ,'{25}' ,'{26}' ,'{27}','{28}'
                           ,'{29}','{30}','{31}')";

                strSQL = string.Format(strSQL, ram_id, ra_id, hhm_id, hhm_name, gnd_name, gnd_age, ra_criteria_id, yn_hiv_test, yn_unprotected_sex, yn_sex_worker, yn_lost_sexual_partner
                                       , yn_tb_disease, yn_sexual_violence, yn_sickly, yn_pregnant_not_tested, yn_breast_feeding_not_tested, yn_hiv_neg_discodant_not_tested, yn_sti, yn_hepatitis_b
                                       , yn_male_female_not_tested, yn_hhm_at_risk, yn_hmm_test, yn_hhm_accept_test, yn_referal, yn_referal_completed, test_result, usr_id_create, usr_id_update
                                       , usr_date_create, usr_date_update, ofc_id, district_id);

            }
            else if (action == "update")
            {
                strSQL = @"UPDATE [dbo].[hh_household_risk_assessment_member_adult]
                           SET [hhm_id] = '{1}'
                              ,[hhm_name] = '{2}'
                              ,[gnd_name] = '{3}'
                              ,[gnd_age] = '{4}'
                              ,[ra_criteria_id] = '{5}'
                              ,[yn_hiv_test] = '{6}'
                              ,[yn_unprotected_sex] = '{7}'
                              ,[yn_sex_worker] = '{8}'
                              ,[yn_lost_sexual_partner] = '{9}'
                              ,[yn_tb_disease] = '{10}'
                              ,[yn_sexual_violence] = '{11}'
                              ,[yn_sickly] = '{12}'
                              ,[yn_pregnant_not_tested] = '{13}'
                              ,[yn_breast_feeding_not_tested] = '{14}'
                              ,[yn_hiv_neg_discodant_not_tested] = '{15}'
                              ,[yn_sti] = '{16}'
                              ,[yn_hepatitis_b] = '{17}'
                              ,[yn_male_female_not_tested] = '{18}'
                              ,[yn_hhm_at_risk] = '{19}'
                              ,[yn_hmm_test] = '{20}'
                              ,[yn_hhm_accept_test] = '{21}'
                              ,[yn_referal] = '{22}'
                              ,[yn_referal_completed] = '{23}'
                              ,[test_result] ='{24}'
                              ,[usr_id_update] = '{25}'
                              ,[usr_date_update] = '{26}'
                         WHERE [ram_id] = '{0}'";

                strSQL = string.Format(strSQL, ram_id,hhm_id, hhm_name, gnd_name, gnd_age, ra_criteria_id, yn_hiv_test, yn_unprotected_sex, yn_sex_worker, yn_lost_sexual_partner
                                       , yn_tb_disease, yn_sexual_violence, yn_sickly, yn_pregnant_not_tested, yn_breast_feeding_not_tested, yn_hiv_neg_discodant_not_tested, yn_sti, yn_hepatitis_b
                                       , yn_male_female_not_tested, yn_hhm_at_risk, yn_hmm_test, yn_hhm_accept_test, yn_referal, yn_referal_completed, test_result, usr_id_update, usr_date_update);

            }
            #endregion save

            try
            {
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

        public static void save_hh_household_risk_assessment_member_child(string action)
        {
            string strSQL = string.Empty;

            #region save
            if (action == "save")
            {
                strSQL = @"INSERT INTO [dbo].[hh_household_risk_assessment_member_child]
                           ([ram_id] ,[ra_id],[hhm_id] ,[hhm_name],[gnd_name] ,[gnd_age] ,[ra_criteria_id],[yn_mother_hiv_pos] ,[yn_lost_bio_parent] ,[yn_malnourished]
                           ,[yn_skin_problem],[yn_hospitalized] ,[yn_sexual_violence_exposed],[yn_acc_exposure_sharp_injury],[yn_drug_abuse],[yn_hhm_at_risk],[yn_hmm_test]
                           ,[yn_hhm_accept_test] ,[yn_referal] ,[yn_referal_completed] ,[test_result] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update]
                           ,[ofc_id],[district_id])
                     VALUES('{0}' ,'{1}','{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}','{8}' ,'{9}','{10}','{11}' ,'{12}','{13}' ,'{14}' ,'{15}','{16}'
                           ,'{17}' ,'{18}' ,'{19}','{20}' ,'{21}' ,'{22}','{23}' ,'{24}','{25}' ,'{26}')";

                strSQL = string.Format(strSQL, ram_id, ra_id, hhm_id, hhm_name, gnd_name, gnd_age, ra_criteria_id, yn_mother_hiv_pos, yn_lost_bio_parent, yn_malnourished
                                       , yn_skin_problem, yn_hospitalized, yn_sexual_violence_exposed, yn_acc_exposure_sharp_injury, yn_drug_abuse, yn_hhm_at_risk, yn_hmm_test
                                       , yn_hhm_accept_test, yn_referal, yn_referal_completed, test_result, usr_id_create, usr_id_update, usr_date_create, usr_date_update
                                       , ofc_id, district_id);


            }
            else if (action == "update")
            {
                strSQL = @"UPDATE [dbo].[hh_household_risk_assessment_member_child]
                           SET [hhm_id] = '{1}'
                              ,[hhm_name] = '{2}'
                              ,[gnd_name] = '{3}'
                              ,[gnd_age] = '{4}'
                              ,[ra_criteria_id] ='{5}'
                              ,[yn_mother_hiv_pos] = '{6}'
                              ,[yn_lost_bio_parent] = '{7}'
                              ,[yn_malnourished] = '{8}'
                              ,[yn_skin_problem] = '{9}'
                              ,[yn_hospitalized] = '{10}'
                              ,[yn_sexual_violence_exposed] = '{11}'
                              ,[yn_acc_exposure_sharp_injury] = '{12}'
                              ,[yn_drug_abuse] = '{13}'
                              ,[yn_hhm_at_risk] = '{14}'
                              ,[yn_hmm_test] = '{15}'
                              ,[yn_hhm_accept_test] = '{16}'
                              ,[yn_referal] = '{17}'
                              ,[yn_referal_completed] = '{18}'
                              ,[test_result] = '{19}'
                              ,[usr_id_update] = '{20}'
                              ,[usr_date_update] = '{21}'
                         WHERE [ram_id] = '{0}'";

                strSQL = string.Format(strSQL, ram_id,hhm_id, hhm_name, gnd_name, gnd_age, ra_criteria_id, yn_mother_hiv_pos, yn_lost_bio_parent, yn_malnourished
                                      , yn_skin_problem, yn_hospitalized, yn_sexual_violence_exposed, yn_acc_exposure_sharp_injury, yn_drug_abuse, yn_hhm_at_risk, yn_hmm_test
                                      , yn_hhm_accept_test, yn_referal, yn_referal_completed, test_result, usr_id_update, usr_date_update);

            }
            #endregion save

            try
            {
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
        #endregion save
    }
}
