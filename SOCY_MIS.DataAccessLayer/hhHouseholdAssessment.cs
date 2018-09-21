using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdAssessment
    {
        #region Variables
        #region Public
        public string hha_id = string.Empty;
        public string hha_comments = string.Empty;
        public DateTime hha_date = DateTime.Now;
        public string hha_num_of_meals = string.Empty;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string icc_id = utilConstants.cDFEmptyListValue;
        public string ics_id = utilConstants.cDFEmptyListValue;
        public string osn_id_disagreement = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string yn_id_child_separation = utilConstants.cDFEmptyListValue;
        public string yn_id_financial_savings = utilConstants.cDFEmptyListValue;
        public string yn_id_food_body_building = utilConstants.cDFEmptyListValue;
        public string yn_id_food_energy = utilConstants.cDFEmptyListValue;
        public string yn_id_food_protective = utilConstants.cDFEmptyListValue;
        public string yn_id_water = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_food = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_health = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_school = utilConstants.cDFEmptyListValue;
        public string ynns_id_assets = utilConstants.cDFEmptyListValue;
        public string yns_id_latrine = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;

        //new variables for the new HAT Tool
        public string swk_phone = string.Empty;
        public string caregiver_phone = string.Empty;
        public string _18_years_male = string.Empty;
        public string _18_years_female = string.Empty;
        public string below_18_male = string.Empty;
        public string below_18_female = string.Empty;
        public string total_hhm_male = string.Empty;
        public string total_hhm_female = string.Empty;
        public string yn_child_headed = string.Empty;
        public string yn_hh_disabled = string.Empty;
        public string  yn_hhm_sick = string.Empty;
        public string yn_hhm_employed = string.Empty;
        public string yn_pay_unexpected_expense = string.Empty;
        public string yn_function_tp_means = string.Empty;
        public string yn_hhm_vocational_skills = string.Empty;
        public string yn_domestic_animals = string.Empty;
        public string yn_hh_access_to_land = string.Empty;
        public string hh_food_source = string.Empty;
        public string hhm_go_hungry_past_month = string.Empty;
        public string yn_caregiver_knows_hiv_status = string.Empty;
        public string yn_children_tested = string.Empty;
        public string yn_eligible_child_on_treatment = string.Empty;
        public string yn_hh_access_water = string.Empty;
        public string yn_hhm_mosquito_net = string.Empty;
        public string yn_hh_access_public_health_facility = string.Empty;
        public string yn_ob_clean_compound = string.Empty;
        public string yn_ob_drying_rack = string.Empty;
        public string yn_ob_garbage_pit = string.Empty;
        public string yn_ob_animal_house = string.Empty;
        public string yn_ob_washing_facility = string.Empty;
        public string hh_stable_shelter = string.Empty;
        public string ynna_children_go_to_school = string.Empty;
        public string total_hh_children_not_go_to_school = string.Empty;
        public string yn_children_sad_unhappy = string.Empty;
        public string yn_cp_repeated_abuse = string.Empty;
        public string yn_cp_child_labour = string.Empty;
        public string yn_cp_sexually_abused = string.Empty;
        public string yn_cp_stigmatised = string.Empty;
        public string yn_cp_conflict_with_law = string.Empty;
        public string yn_cp_withheld_meal = string.Empty;
        public string yn_cp_abusive_language = string.Empty;
        public string hhs_id_visit_from_volunteer = string.Empty;
        public string hhs_id_financial_support = string.Empty;
        public string hhs_id_parenting_counsiling = string.Empty;
        public string hhs_id_early_child_dev = string.Empty;
        public string hhs_id_health_hygiene = string.Empty;
        public string hhs_id_hiv_gbv_prevention = string.Empty;
        public string hhs_id_nutrition_counsiling = string.Empty;
        public string hhs_id_pre_post_partum = string.Empty;
        public string hhs_id_hiv_testing = string.Empty;
        public string hhs_id_couples_counsiling = string.Empty;
        public string hhs_id_birth_certificate = string.Empty;
        public string hhs_id_child_protection = string.Empty;
        public string hhs_id_psychosocial = string.Empty;
        public string hhs_id_food_security = string.Empty;
        public string hhs_id_other = string.Empty;
        public string hhs_id_none = string.Empty;
        public string hhcs_id_savings_groups = string.Empty;
        public string hhcs_id_parenting_program = string.Empty;
        public string hhcs_id_govt_sage_program = string.Empty;
        public string hhcs_id_other_cash_transfer = string.Empty;
        public string hhcs_id_voluntary_hiv_testing = string.Empty;
        public string hhcs_id_food_security_nutrition = string.Empty;
        public string hhcs_id_skills_employ_training = string.Empty;
        public string hhcs_id_entrepreneurship_training = string.Empty;
        public string hhcs_id_other = string.Empty;
        public string hhcs_id_none = string.Empty;
        public string hh_child_abuse_action = string.Empty;

        #endregion Public

        #region Private
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        #endregion dbconnection
        #endregion Private
        #endregion Variables
        #region Constractor Methods
        public hhHouseholdAssessment()
        {
            Default();
        }

        public hhHouseholdAssessment(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM hh_household_assessment WHERE hha_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Household Assessment
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetHouseholdAssessment(strId, dbCon);
                Load(dt);
            }
            #endregion Set Household Assessment
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetHouseholdAssessment(hha_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            hha_id = string.Empty;
            hha_comments = string.Empty;
            hha_date = DateTime.Now;
            hha_num_of_meals = string.Empty;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            icc_id = utilConstants.cDFEmptyListValue;
            ics_id = utilConstants.cDFEmptyListValue;
            osn_id_disagreement = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            yn_id_child_separation = utilConstants.cDFEmptyListValue;
            yn_id_financial_savings = utilConstants.cDFEmptyListValue;
            yn_id_food_body_building = utilConstants.cDFEmptyListValue;
            yn_id_food_energy = utilConstants.cDFEmptyListValue;
            yn_id_food_protective = utilConstants.cDFEmptyListValue;
            yn_id_water = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_food = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_health = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_school = utilConstants.cDFEmptyListValue;
            ynns_id_assets = utilConstants.cDFEmptyListValue;
            yns_id_latrine = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO hh_household_assessment( [hha_id],[hha_comments],[hha_date],[hha_num_of_meals],[hh_id],[hhm_id],[icc_id],[ics_id],[osn_id_disagreement],[swk_id],[yn_id_child_separation]
                      ,[yn_id_financial_savings] ,[yn_id_food_body_building],[yn_id_food_energy],[yn_id_food_protective],[yn_id_water],[ynna_id_expenses_food],[ynna_id_expenses_health]
                      ,[ynna_id_expenses_school],[ynns_id_assets],[yns_id_latrine],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]
                      ,[swk_phone],[caregiver_phone] ,[_18_years_male],[_18_years_female],[below_18_male],[below_18_female],[total_hhm_male],[total_hhm_female],[yn_child_headed]
                      ,[yn_hh_disabled],[yn_hhm_sick],[yn_hhm_employed],[yn_pay_unexpected_expense],[yn_function_tp_means],[yn_hhm_vocational_skills],[yn_domestic_animals]
                      ,[yn_hh_access_to_land],[hh_food_source],[hhm_go_hungry_past_month],[yn_caregiver_knows_hiv_status],[yn_children_tested],[yn_eligible_child_on_treatment],[yn_hh_access_water]
                      ,[yn_hhm_mosquito_net],[yn_hh_access_public_health_facility],[yn_ob_clean_compound],[yn_ob_drying_rack],[yn_ob_garbage_pit],[yn_ob_animal_house]
                      ,[yn_ob_washing_facility],[hh_stable_shelter],[ynna_children_go_to_school],[total_hh_children_not_go_to_school],[yn_children_sad_unhappy],[yn_cp_repeated_abuse]
                      ,[yn_cp_child_labour],[yn_cp_sexually_abused],[yn_cp_stigmatised] ,[hhs_id_visit_from_volunteer],[hhs_id_financial_support],[hhs_id_parenting_counsiling]
                      ,[hhs_id_early_child_dev],[hhs_id_health_hygiene],[hhs_id_hiv_gbv_prevention],[hhs_id_nutrition_counsiling],[hhs_id_pre_post_partum],[hhs_id_hiv_testing]
                      ,[hhs_id_couples_counsiling] ,[hhs_id_birth_certificate],[hhs_id_child_protection],[hhs_id_psychosocial],[hhs_id_food_security],[hhs_id_other] ,[hhs_id_none]
                      ,[hhcs_id_savings_groups],[hhcs_id_parenting_program],[hhcs_id_govt_sage_program],[hhcs_id_other_cash_transfer],[hhcs_id_voluntary_hiv_testing],[hhcs_id_food_security_nutrition]
                      ,[hhcs_id_skills_employ_training],[hhcs_id_entrepreneurship_training],[hhcs_id_other],[hhcs_id_none],[hh_child_abuse_action],[yn_cp_conflict_with_law],[yn_cp_withheld_meal],[yn_cp_abusive_language])
                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{21}',
                        GETDATE(),GETDATE(),'{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}',
                        '{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}',
                        '{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}','{88}','{89}','{90}','{91}')";

            strSQL = string.Format(strSQL, hha_id, utilFormatting.StringForSQL(hha_comments), hha_date.ToString("dd MMM yyyy HH:mm:ss"),
                hha_num_of_meals.ToString(),
                hh_id, hhm_id, icc_id, ics_id, osn_id_disagreement, swk_id,
                yn_id_child_separation, yn_id_financial_savings, yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water,
                ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school,
                ynns_id_assets, yns_id_latrine,
                usr_id_update, ofc_id,Convert.ToInt32(district_id), swk_phone, caregiver_phone, _18_years_male, _18_years_female, below_18_male,
                below_18_female, total_hhm_male, total_hhm_female, yn_child_headed, yn_hh_disabled, yn_hhm_sick, yn_hhm_employed, yn_pay_unexpected_expense,
                yn_function_tp_means, yn_hhm_vocational_skills, yn_domestic_animals, yn_hh_access_to_land, hh_food_source, hhm_go_hungry_past_month, yn_caregiver_knows_hiv_status,
                yn_children_tested, yn_eligible_child_on_treatment, yn_hh_access_water, yn_hhm_mosquito_net, yn_hh_access_public_health_facility, yn_ob_clean_compound, 
                yn_ob_drying_rack, yn_ob_garbage_pit, yn_ob_animal_house, yn_ob_washing_facility, hh_stable_shelter, ynna_children_go_to_school, 
                total_hh_children_not_go_to_school, yn_children_sad_unhappy, yn_cp_repeated_abuse, yn_cp_child_labour, yn_cp_sexually_abused, yn_cp_stigmatised,
                hhs_id_visit_from_volunteer, hhs_id_financial_support, hhs_id_parenting_counsiling, hhs_id_early_child_dev, hhs_id_health_hygiene, hhs_id_hiv_gbv_prevention, 
                hhs_id_nutrition_counsiling, hhs_id_pre_post_partum, hhs_id_hiv_testing, hhs_id_couples_counsiling, hhs_id_birth_certificate, hhs_id_child_protection,
                hhs_id_psychosocial, hhs_id_food_security, hhs_id_other, hhs_id_none, hhcs_id_savings_groups, hhcs_id_parenting_program, hhcs_id_govt_sage_program,
                hhcs_id_other_cash_transfer, hhcs_id_voluntary_hiv_testing, hhcs_id_food_security_nutrition, hhcs_id_skills_employ_training, hhcs_id_entrepreneurship_training,
                hhcs_id_other, hhcs_id_none, hh_child_abuse_action, yn_cp_conflict_with_law, yn_cp_withheld_meal, yn_cp_abusive_language);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        private void Load(DataTable dt)
        {
            #region Variables
            DataRow dr = null;
            #endregion Variables

            if (!utilCollections.HasRows(dt))
            {
                Default();
            }
            else
            {
                #region Load Values
                dr = dt.Rows[0];
                hha_id = dr["hha_id"].ToString();
                hha_comments = dr["hha_comments"].ToString();
                hha_date = Convert.ToDateTime(dr["hha_date"]);
                hha_num_of_meals = dr["hha_num_of_meals"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                icc_id = dr["icc_id"].ToString();
                ics_id = dr["ics_id"].ToString();
                osn_id_disagreement = dr["osn_id_disagreement"].ToString();
                swk_id = dr["swk_id"].ToString();
                yn_id_child_separation = dr["yn_id_child_separation"].ToString();
                yn_id_financial_savings = dr["yn_id_financial_savings"].ToString();
                yn_id_food_body_building = dr["yn_id_food_body_building"].ToString();
                yn_id_food_energy = dr["yn_id_food_energy"].ToString();
                yn_id_food_protective = dr["yn_id_food_protective"].ToString();
                yn_id_water = dr["yn_id_water"].ToString();
                ynna_id_expenses_food = dr["ynna_id_expenses_food"].ToString();
                ynna_id_expenses_health = dr["ynna_id_expenses_health"].ToString();
                ynna_id_expenses_school = dr["ynna_id_expenses_school"].ToString();
                ynns_id_assets = dr["ynns_id_assets"].ToString();
                yns_id_latrine = dr["yns_id_latrine"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();

                swk_phone = dr["swk_phone"].ToString();
                caregiver_phone = dr["caregiver_phone"].ToString();
                _18_years_male = dr["_18_years_male"].ToString();
               _18_years_female = dr["_18_years_female"].ToString();
                below_18_male = dr["below_18_male"].ToString();
                below_18_female = dr["below_18_female"].ToString();
                total_hhm_male = dr["total_hhm_male"].ToString();
                total_hhm_female = dr["total_hhm_female"].ToString();
                yn_child_headed = dr["yn_child_headed"].ToString();
                yn_hh_disabled = dr["yn_hh_disabled"].ToString();
                yn_hhm_sick = dr["yn_hhm_sick"].ToString();
                yn_hhm_employed = dr["yn_hhm_employed"].ToString();
                yn_pay_unexpected_expense = dr["yn_pay_unexpected_expense"].ToString();
                yn_function_tp_means = dr["yn_function_tp_means"].ToString();
                yn_hhm_vocational_skills = dr["yn_hhm_vocational_skills"].ToString();
                yn_domestic_animals = dr["yn_domestic_animals"].ToString();
                yn_hh_access_to_land = dr["yn_hh_access_to_land"].ToString();
                hh_food_source = dr["hh_food_source"].ToString();
                yn_caregiver_knows_hiv_status = dr["yn_caregiver_knows_hiv_status"].ToString();
                yn_children_tested = dr["yn_children_tested"].ToString();
                yn_eligible_child_on_treatment = dr["yn_eligible_child_on_treatment"].ToString();
                yn_hh_access_water = dr["yn_hh_access_water"].ToString();
                yn_hhm_mosquito_net = dr["yn_hhm_mosquito_net"].ToString();
                yn_hh_access_public_health_facility = dr["yn_hh_access_public_health_facility"].ToString();
                yn_ob_clean_compound = dr["yn_ob_clean_compound"].ToString();
                yn_ob_drying_rack = dr["yn_ob_drying_rack"].ToString();
                yn_ob_garbage_pit = dr["yn_ob_garbage_pit"].ToString();
                yn_ob_animal_house = dr["yn_ob_animal_house"].ToString();
                yn_ob_washing_facility = dr["yn_ob_washing_facility"].ToString();
                hh_stable_shelter = dr["hh_stable_shelter"].ToString();
                ynna_children_go_to_school = dr["ynna_children_go_to_school"].ToString();
                total_hh_children_not_go_to_school = dr["total_hh_children_not_go_to_school"].ToString();
                yn_children_sad_unhappy = dr["yn_children_sad_unhappy"].ToString();
                yn_cp_repeated_abuse = dr["yn_cp_repeated_abuse"].ToString();
                yn_cp_child_labour = dr["yn_cp_child_labour"].ToString();
                yn_cp_sexually_abused = dr["yn_cp_sexually_abused"].ToString();
                yn_cp_stigmatised = dr["yn_cp_stigmatised"].ToString();
                yn_cp_conflict_with_law = dr["yn_cp_conflict_with_law"].ToString();
                yn_cp_withheld_meal = dr["yn_cp_withheld_meal"].ToString();
                yn_cp_abusive_language = dr["yn_cp_abusive_language"].ToString();
                hhs_id_visit_from_volunteer = dr["hhs_id_visit_from_volunteer"].ToString();
                hhs_id_financial_support = dr["hhs_id_financial_support"].ToString();
                hhs_id_parenting_counsiling = dr["hhs_id_parenting_counsiling"].ToString();
                hhs_id_early_child_dev = dr["hhs_id_early_child_dev"].ToString();
                hhs_id_health_hygiene = dr["hhs_id_health_hygiene"].ToString();
                hhs_id_hiv_gbv_prevention = dr["hhs_id_hiv_gbv_prevention"].ToString();
                hhs_id_nutrition_counsiling = dr["hhs_id_nutrition_counsiling"].ToString();
                hhs_id_pre_post_partum = dr["hhs_id_pre_post_partum"].ToString();
                hhs_id_hiv_testing = dr["hhs_id_hiv_testing"].ToString();
                hhs_id_couples_counsiling = dr["hhs_id_couples_counsiling"].ToString();
                hhs_id_birth_certificate = dr["hhs_id_birth_certificate"].ToString();
                hhs_id_child_protection = dr["hhs_id_child_protection"].ToString();
                hhs_id_psychosocial = dr["hhs_id_psychosocial"].ToString();
                hhs_id_food_security = dr["hhs_id_food_security"].ToString();
                hhs_id_other = dr["hhs_id_other"].ToString();
                hhs_id_none = dr["hhs_id_none"].ToString();
                hhcs_id_savings_groups = dr["hhcs_id_savings_groups"].ToString();
                hhcs_id_parenting_program = dr["hhcs_id_parenting_program"].ToString();
                hhcs_id_govt_sage_program = dr["hhcs_id_govt_sage_program"].ToString();
                hhcs_id_other_cash_transfer = dr["hhcs_id_other_cash_transfer"].ToString();
                hhcs_id_voluntary_hiv_testing = dr["hhcs_id_voluntary_hiv_testing"].ToString();
                hhcs_id_food_security_nutrition = dr["hhcs_id_food_security_nutrition"].ToString();
                hhcs_id_skills_employ_training = dr["hhcs_id_skills_employ_training"].ToString();
                hhcs_id_entrepreneurship_training = dr["hhcs_id_entrepreneurship_training"].ToString();
                hhcs_id_other = dr["hhcs_id_other"].ToString();
                hhcs_id_none = dr["hhcs_id_none"].ToString();
                hh_child_abuse_action = dr["hh_child_abuse_action"].ToString();
                hhm_go_hungry_past_month = dr["hhm_go_hungry_past_month"].ToString();
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE hh_household_assessment " +
                "SET hha_comments = '{1}', hha_date = '{2}', " +
                "hha_num_of_meals = '{3}', " +
                "hh_id = '{4}', hhm_id = '{5}', icc_id = '{6}', ics_id = '{7}', osn_id_disagreement = '{8}', swk_id = '{9}', " +
                "yn_id_child_separation = '{10}', yn_id_financial_savings = '{11}', yn_id_food_body_building = '{12}', yn_id_food_energy = '{13}', yn_id_food_protective = '{14}', yn_id_water = '{15}', " +
                "ynna_id_expenses_food = '{16}', ynna_id_expenses_health = '{17}', ynna_id_expenses_school = '{18}', " +
                "ynns_id_assets = '{19}', yns_id_latrine = '{20}', " +
                "usr_id_update = '{21}', usr_date_update = GETDATE(),district_id = '{22}', " +
                "[swk_phone] = '{23}',[caregiver_phone] ='{24}',[_18_years_male] = '{25}' ,[_18_years_female] = '{26}',[below_18_male] = '{27}'" + 
              ",[below_18_female] = '{28}',[total_hhm_male] = '{29}' ,[total_hhm_female] ='{30}',[yn_child_headed] = '{31}',[yn_hh_disabled] = '{32}' " + 
              ",[yn_hhm_sick] = '{33}' ,[yn_hhm_employed] = '{34}' ,[yn_pay_unexpected_expense] ='{35}' ,[yn_function_tp_means] = '{36}',[yn_hhm_vocational_skills] = '{37}' " +
              ",[yn_domestic_animals] = '{38}',[yn_hh_access_to_land] = '{39}' ,[hh_food_source] = '{40}' ,[yn_caregiver_knows_hiv_status] = '{41}',[yn_children_tested] ='{42}' " + 
              ",[yn_eligible_child_on_treatment] = '{43}',[yn_hh_access_water] = '{44}',[yn_hhm_mosquito_net] = '{45}' ,[yn_hh_access_public_health_facility] = '{46}' ,[yn_ob_clean_compound] = '{47}' " + 
              " ,[yn_ob_drying_rack] = '{48}' ,[yn_ob_garbage_pit] = '{49}' ,[yn_ob_animal_house] = '{50}' ,[yn_ob_washing_facility] = '{51}',[hh_stable_shelter] = '{52}',[ynna_children_go_to_school] = '{53}' " + 
              ",[total_hh_children_not_go_to_school] = '{54}',[yn_children_sad_unhappy] = '{55}',[yn_cp_repeated_abuse] = '{56}' ,[yn_cp_child_labour] = '{57}' ,[yn_cp_sexually_abused] = '{58}',[yn_cp_stigmatised] = '{59}' " + 
              ",[hhs_id_visit_from_volunteer] = '{60}' ,[hhs_id_financial_support] = '{61}',[hhs_id_parenting_counsiling] = '{62}' ,[hhs_id_early_child_dev] = '{63}',[hhs_id_health_hygiene] = '{64}',[hhs_id_hiv_gbv_prevention] = '{65}' " + 
              ",[hhs_id_nutrition_counsiling] = '{66}',[hhs_id_pre_post_partum] = '{67}' ,[hhs_id_hiv_testing] = '{68}' ,[hhs_id_couples_counsiling] = '{69}',[hhs_id_birth_certificate] = '{70}',[hhs_id_child_protection] = '{71}'" +
              ",[hhs_id_psychosocial] = '{72}',[hhs_id_food_security] = '{73}',[hhs_id_other] = '{74}',[hhs_id_none] = '{75}',[hhcs_id_savings_groups] = '{76}' ,[hhcs_id_parenting_program] = '{77}',[hhcs_id_govt_sage_program] = '{78}' " +
              ",[hhcs_id_other_cash_transfer] = '{79}' ,[hhcs_id_voluntary_hiv_testing] = '{80}' ,[hhcs_id_food_security_nutrition] = '{81}',[hhcs_id_skills_employ_training] = '{82}',[hhcs_id_entrepreneurship_training] = '{83}'"  +
              ",[hhcs_id_other] = '{84}',[hhcs_id_none] = '{85}',[hh_child_abuse_action] = '{86}',hhm_go_hungry_past_month = '{87}',yn_cp_conflict_with_law = '{88}',yn_cp_withheld_meal = '{89}',yn_cp_abusive_language = '{90}' " +
               "WHERE hha_id = '{0}' ";
            strSQL = string.Format(strSQL, hha_id, utilFormatting.StringForSQL(hha_comments), hha_date.ToString("dd MMM yyyy HH:mm:ss"),
                hha_num_of_meals.ToString(),
                hh_id, hhm_id, icc_id, ics_id, osn_id_disagreement, swk_id,
                yn_id_child_separation, yn_id_financial_savings, yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water,
                ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school,
                ynns_id_assets, yns_id_latrine,
                usr_id_update,Convert.ToInt32(district_id), swk_phone, caregiver_phone, _18_years_male, _18_years_female, below_18_male,
                below_18_female, total_hhm_male, total_hhm_female, yn_child_headed, yn_hh_disabled, yn_hhm_sick, yn_hhm_employed, yn_pay_unexpected_expense,
                yn_function_tp_means, yn_hhm_vocational_skills, yn_domestic_animals, yn_hh_access_to_land, hh_food_source, yn_caregiver_knows_hiv_status,
                yn_children_tested, yn_eligible_child_on_treatment, yn_hh_access_water, yn_hhm_mosquito_net, yn_hh_access_public_health_facility, yn_ob_clean_compound,
                yn_ob_drying_rack, yn_ob_garbage_pit, yn_ob_animal_house, yn_ob_washing_facility, hh_stable_shelter, ynna_children_go_to_school,
                total_hh_children_not_go_to_school, yn_children_sad_unhappy, yn_cp_repeated_abuse, yn_cp_child_labour, yn_cp_sexually_abused, yn_cp_stigmatised,
                hhs_id_visit_from_volunteer, hhs_id_financial_support, hhs_id_parenting_counsiling, hhs_id_early_child_dev, hhs_id_health_hygiene, hhs_id_hiv_gbv_prevention,
                hhs_id_nutrition_counsiling, hhs_id_pre_post_partum, hhs_id_hiv_testing, hhs_id_couples_counsiling, hhs_id_birth_certificate, hhs_id_child_protection,
                hhs_id_psychosocial, hhs_id_food_security, hhs_id_other, hhs_id_none, hhcs_id_savings_groups, hhcs_id_parenting_program, hhcs_id_govt_sage_program,
                hhcs_id_other_cash_transfer, hhcs_id_voluntary_hiv_testing, hhcs_id_food_security_nutrition, hhcs_id_skills_employ_training, hhcs_id_entrepreneurship_training,
                hhcs_id_other, hhcs_id_none, hh_child_abuse_action, hhm_go_hungry_past_month, yn_cp_conflict_with_law, yn_cp_withheld_meal, yn_cp_abusive_language);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Function Methods
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetHouseholdAssessment(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hha.* " +
            "FROM hh_household_assessment hha " +
            "WHERE hha.hha_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        //added by Tadeo

        public static DataTable Return_HHServicesReceived(string serviceType)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            switch (serviceType)
            {
                case "HHService":
                    SQL= "SELECT hhs_id,hhs_name FROM lst_hh_hat_services_received WHERE service_type_id = 1";
                    break;
                case "Community":
                    SQL = "SELECT hhs_id,hhs_name FROM lst_hh_hat_services_received WHERE service_type_id = 2";
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

        public static DataTable Return_Lookups(string lookupType,string id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;

            switch (lookupType)
            {
                case "IP":
                    SQL = "SELECT prt_id,prt_name FROM lst_partner";
                    break;
                case "CSOHAT":
                    SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso WHERE prt_id = '{0}'";
                    SQL = string.Format(SQL, id);
                    break;
                case "SocialWorkerPhone":
                    SQL = "SELECT [swk_phone] FROM swm_social_worker WHERE swk_id = '{0}'";
                    SQL = string.Format(SQL, id);
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
    }
}
