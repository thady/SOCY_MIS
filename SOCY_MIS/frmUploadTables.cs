using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using SOCY_MIS.DataAccessLayer;
using System.ServiceModel.Dispatcher;

namespace SOCY_MIS
{
    public partial class frmUploadTables : Form
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;
        string table_id = string.Empty;

        #endregion dbconnection
        public frmUploadTables()
        {
            InitializeComponent();
        }

        private void frmUploadTables_Load(object sender, EventArgs e)
        {
            GetTable();
            Return_lookups();
        }

        public void LoadWSResults(string DownLoadTable,string dst_id)
        {
            DataTable dt = new DataTable();
            SOCY_WS.SOCY_WS wsSM = null;
            string SQL = string.Empty;
            

            try
            {
                wsSM = new SOCY_WS.SOCY_WS();
                wsSM.Timeout = -1;

                SetstatusText("Now Synching with server..Please wait...");
                dt = wsSM.Download_Data(dst_id,dtdatefrom.Value.Date,dtdateTo.Value.Date, DownLoadTable);
                dt.TableName = "TblResults";

                SetstatusText("Completed Downloading batch..Preparing to run import...please wait...");

                if (dt.Rows.Count > 0)
                {
                    //gdvResults.DataSource = dt;
                    importData(dt, DownLoadTable);
                }
            }
            catch (System.Net.WebException exc)
            {
                throw exc;
            }

        }

        #region Tables
        public void  GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("tablename", typeof(string));
            table.Columns.Add("table_id", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add("Household Data", "hh_household");
            table.Rows.Add("Household Member Data", "hh_household_member");
            table.Rows.Add("Household Assessment", "hh_household_assessment");
            table.Rows.Add("Household Visit Data", "hh_household_home_visit");
            table.Rows.Add("Household Visit Member Data", "hh_household_home_visit_member");
            table.Rows.Add("Social Workers", "swm_social_worker");
            table.Rows.Add("Household Identification & Prioritization", "hh_ovc_identification_prioritization");
            table.Rows.Add("Household Improvement Plan", "hh_household_improvement_plan");

            DataRow dstemptyRow = table.NewRow();
            dstemptyRow["table_id"] = "-1";
            dstemptyRow["tablename"] = "Select Tool";
            table.Rows.InsertAt(dstemptyRow, 0);

            cboDownloadList.DisplayMember = "tablename";
            cboDownloadList.ValueMember = "table_id";
            cboDownloadList.DataSource = table;
        }

        #endregion Tables

        #region Lookups
        protected void Return_lookups()
        {
            DataTable dt = null;
            #region districts
            dt = benYouthTrainingInventory.Return_lookups("district", string.Empty, string.Empty, string.Empty); //reused

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["dst_id"] = "-1";
            dstemptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;

            cboDistrict.SelectedValue = SystemConstants.Return_office_district();

            #endregion districts
        }
        #endregion Lookups

        protected void importData(DataTable dt,string DownLoadTable)
        {
            #region Variables
            DataRow dtRow = null;
            string strSQLInsert = string.Empty;
            string strSQLDelete = string.Empty;
            string strSQLTrigger = string.Empty;
            string strID = string.Empty;
            int count = 0;
            #endregion Variables

            if (dt.Rows.Count > 0)
            {
                SetProgressBarMaxValue(dt.Rows.Count);
                SetstatusText("Now running imports...please wait...");

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    try
                    {
                        SetstatusText("Importing row data...please wait...");

                        dtRow = dt.Rows[x];

                        #region Switch Tables

                        switch (DownLoadTable)
                        {

                            #region hh_household
                            case "hh_household":

                                #region Delete
                                strID = dtRow["hh_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hh_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                #region Insert

                                strSQLInsert = "INSERT INTO {0} " +
                               "(hh_id, hh_code, " +
                               "hh_status_reason, hh_tel, hh_village, " +
                               "hhs_id, hhsr_id, swk_id, wrd_id, " +
                               "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                               "VALUES ('{1}', '{2}', '{3}', '{4}', " +
                               "'{5}', '{6}', '{7}', '{8}', " +
                               "'{9}', '{10}','{10}', GETDATE(), GETDATE(), '{11}','{12}') ";

                                strSQLInsert = string.Format(strSQLInsert, DownLoadTable, dtRow["hh_id"].ToString(), dtRow["hh_code"].ToString(),
                                dtRow["hh_status_reason"].ToString(), dtRow["hh_tel"].ToString(), dtRow["hh_village"].ToString(),
                                dtRow["hhs_id"].ToString(), dtRow["hhsr_id"].ToString(), dtRow["swk_id"].ToString(), dtRow["wrd_id"].ToString(),
                                dtRow["usr_id_create"].ToString(), dtRow["ofc_id"].ToString(), dtRow["dst_id"].ToString());
                                break;
                            #endregion Insert

                            #endregion hh_household

                            #region hh_household_member
                            case "hh_household_member":

                                #region Delete
                                strID = dtRow["hhm_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hhm_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = "INSERT INTO {0} " +
                                         "(hhm_id, " +
                                         "hhm_first_name, hhm_last_name, " +
                                         "hhm_number, hhm_year_of_birth, " +
                                         "dtp_id, edu_id, gnd_id, " +
                                         "hh_id, hst_id, mst_id, " +
                                         "prf_id, prt_id, " +
                                         "yn_id_art, yn_id_birth_registration, yn_id_caregiver, " +
                                         "yn_id_disability, yn_id_given_birth, yn_id_hoh, " +
                                         "yn_id_immun, yn_id_pregnant, yn_id_school, " +
                                         "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                                         "VALUES ('{1}', '{2}', " +
                                         "'{3}', '{4}', " +
                                         "'{5}', '{6}', '{7}', " +
                                         "'{8}', '{9}', '{10}', " +
                                         "'{11}', '{12}', " +
                                         "'{13}', '{14}', '{15}', " +
                                         "'{16}', '{17}', '{18}', " +
                                         "'{19}', '{20}', '{21}', " +
                                         "'{22}', '{23}','{23}', GETDATE(), GETDATE(), '{24}','{25}') ";

                                strSQLInsert = string.Format(strSQLInsert, DownLoadTable, dtRow["hhm_id"].ToString(),
                                    dtRow["hhm_first_name"].ToString(), dtRow["hhm_last_name"].ToString(),
                                     dtRow["hhm_number"].ToString(), dtRow["hhm_year_of_birth"].ToString(),
                                    dtRow["dtp_id"].ToString(), dtRow["edu_id"].ToString(), dtRow["gnd_id"].ToString(),
                                    dtRow["hh_id"].ToString(), dtRow["hst_id"].ToString(), dtRow["mst_id"].ToString(),
                                    dtRow["prf_id"].ToString(), dtRow["prt_id"].ToString(),
                                    dtRow["yn_id_art"].ToString(), dtRow["yn_id_birth_registration"].ToString(), dtRow["yn_id_caregiver"].ToString(),
                                    dtRow["yn_id_disability"].ToString(), dtRow["yn_id_given_birth"].ToString(), dtRow["yn_id_hoh"].ToString(),
                                    dtRow["yn_id_immun"].ToString(), dtRow["yn_id_pregnant"].ToString(), dtRow["yn_id_school"].ToString(),
                                    dtRow["usr_id_update"].ToString(), dtRow["ofc_id"].ToString(), dtRow["dst_id"].ToString());

                                break;

                            #endregion hh_household_member

                            #region hh_household_assessment
                            case "hh_household_assessment":

                                #region Delete
                                strID = dtRow["hha_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hha_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = @"INSERT INTO hh_household_assessment( [hha_id],[hha_comments],[hha_date],[hha_num_of_meals],[hh_id],[hhm_id],[icc_id],[ics_id],[osn_id_disagreement],[swk_id],[yn_id_child_separation]
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
                                                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',
                                                 '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}',
                                                '{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}',
                                                '{69}','{70}','{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}','{88}','{89}','{90}','{91}','{92}','{93}','{94}')";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["hha_id"].ToString(), dtRow["hha_comments"].ToString(), Convert.ToDateTime(dtRow["hha_date"]), dtRow["hha_num_of_meals"].ToString(),
                                                dtRow["hh_id"].ToString(), dtRow["hhm_id"].ToString(), dtRow["icc_id"].ToString(), dtRow["ics_id"].ToString(), dtRow["osn_id_disagreement"].ToString(), dtRow["swk_id"].ToString(),
                                                dtRow["yn_id_child_separation"].ToString(), dtRow["yn_id_financial_savings"].ToString(), dtRow["yn_id_food_body_building"].ToString(), dtRow["yn_id_food_energy"].ToString(), dtRow["yn_id_food_protective"].ToString(), dtRow["yn_id_water"].ToString(),
                                                dtRow["ynna_id_expenses_food"].ToString(), dtRow["ynna_id_expenses_health"].ToString(), dtRow["ynna_id_expenses_school"].ToString(),
                                                dtRow["ynns_id_assets"].ToString(), dtRow["yns_id_latrine"].ToString(), dtRow["usr_id_create"].ToString(),
                                                dtRow["usr_id_update"].ToString(), Convert.ToDateTime(dtRow["usr_date_create"]), Convert.ToDateTime(dtRow["usr_date_update"]), dtRow["ofc_id"].ToString(), dtRow["district_id"].ToString(), dtRow["swk_phone"].ToString(), dtRow["caregiver_phone"].ToString(), dtRow["_18_years_male"].ToString(), dtRow["_18_years_female"].ToString(), dtRow["below_18_male"].ToString(),
                                                dtRow["below_18_female"].ToString(), dtRow["total_hhm_male"].ToString(), dtRow["total_hhm_female"].ToString(), dtRow["yn_child_headed"].ToString(), dtRow["yn_hh_disabled"].ToString(), dtRow["yn_hhm_sick"].ToString(), dtRow["yn_hhm_employed"].ToString(), dtRow["yn_pay_unexpected_expense"].ToString(),
                                                dtRow["yn_function_tp_means"].ToString(), dtRow["yn_hhm_vocational_skills"].ToString(), dtRow["yn_domestic_animals"].ToString(), dtRow["yn_hh_access_to_land"].ToString(), dtRow["hh_food_source"].ToString(), dtRow["hhm_go_hungry_past_month"].ToString(), dtRow["yn_caregiver_knows_hiv_status"].ToString(),
                                                dtRow["yn_children_tested"].ToString(), dtRow["yn_eligible_child_on_treatment"].ToString(), dtRow["yn_hh_access_water"].ToString(), dtRow["yn_hhm_mosquito_net"].ToString(), dtRow["yn_hh_access_public_health_facility"].ToString(), dtRow["yn_ob_clean_compound"].ToString(),
                                                dtRow["yn_ob_drying_rack"].ToString(), dtRow["yn_ob_garbage_pit"].ToString(), dtRow["yn_ob_animal_house"].ToString(), dtRow["yn_ob_washing_facility"].ToString(), dtRow["hh_stable_shelter"].ToString(), dtRow["ynna_children_go_to_school"].ToString(),
                                                dtRow["total_hh_children_not_go_to_school"].ToString(), dtRow["yn_children_sad_unhappy"].ToString(), dtRow["yn_cp_repeated_abuse"].ToString(), dtRow["yn_cp_child_labour"].ToString(), dtRow["yn_cp_sexually_abused"].ToString(), dtRow["yn_cp_stigmatised"].ToString(),
                                                dtRow["hhs_id_visit_from_volunteer"].ToString(), dtRow["hhs_id_financial_support"].ToString(), dtRow["hhs_id_parenting_counsiling"].ToString(), dtRow["hhs_id_early_child_dev"].ToString(), dtRow["hhs_id_health_hygiene"].ToString(), dtRow["hhs_id_hiv_gbv_prevention"].ToString(),
                                                dtRow["hhs_id_nutrition_counsiling"].ToString(), dtRow["hhs_id_pre_post_partum"].ToString(), dtRow["hhs_id_hiv_testing"].ToString(), dtRow["hhs_id_couples_counsiling"].ToString(), dtRow["hhs_id_birth_certificate"].ToString(), dtRow["hhs_id_child_protection"].ToString(),
                                                dtRow["hhs_id_psychosocial"].ToString(), dtRow["hhs_id_food_security"].ToString(), dtRow["hhs_id_other"].ToString(), dtRow["hhs_id_none"].ToString(), dtRow["hhcs_id_savings_groups"].ToString(), dtRow["hhcs_id_parenting_program"].ToString(), dtRow["hhcs_id_govt_sage_program"].ToString(),
                                                dtRow["hhcs_id_other_cash_transfer"].ToString(), dtRow["hhcs_id_voluntary_hiv_testing"].ToString(), dtRow["hhcs_id_food_security_nutrition"].ToString(), dtRow["hhcs_id_skills_employ_training"].ToString(), dtRow["hhcs_id_entrepreneurship_training"].ToString(),
                                                 dtRow["hhcs_id_other"].ToString(), dtRow["hhcs_id_none"].ToString(), dtRow["hh_child_abuse_action"].ToString(), dtRow["yn_cp_conflict_with_law"].ToString(), dtRow["yn_cp_withheld_meal"].ToString(), dtRow["yn_cp_abusive_language"].ToString());

                                break;

                            #endregion hh_household_assessment

                            #region hh_household_home_visit
                            case "hh_household_home_visit":

                                #region Delete
                                strID = dtRow["hhv_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hhv_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = "INSERT INTO hh_household_home_visit " +
                                                "(hhv_id, " +
                                                "hhv_date, hhv_date_next_visit, " +
                                                "hhv_household_income, " +
                                                "hhv_comments, hhv_next_steps, " +
                                                "hhv_swk_code, hhv_visitor_tel, " +
                                                "am_id, hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor, " +
                                                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                                                "VALUES ('{0}', " +
                                                "'{1}', '{2}', " +
                                                "{3}, " +
                                                "'{4}', '{5}', " +
                                                "'{6}', '{7}', " +
                                                "'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', " +
                                                "'{16}', '{17}', '{18}', '{19}', '{20}','{21}') ";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["hhv_id"].ToString(), Convert.ToDateTime(dtRow["hhv_date"]), Convert.ToDateTime(dtRow["hhv_date_next_visit"]),
                                         dtRow["hhv_household_income"].ToString(), dtRow["hhv_comments"].ToString(), dtRow["hhv_next_steps"].ToString(), dtRow["hhv_swk_code"].ToString(),
                                         dtRow["hhv_visitor_tel"].ToString(), dtRow["am_id"].ToString(), dtRow["hvhs_id"].ToString(), dtRow["hvr_id"].ToString(), dtRow["hh_id"].ToString(),
                                         dtRow["hhm_id"].ToString(), dtRow["hnr_id_visitor"].ToString(), dtRow["swk_id"].ToString(), dtRow["swk_id_visitor"].ToString(), dtRow["usr_id_create"].ToString(), dtRow["usr_id_update"].ToString(),
                                         Convert.ToDateTime(dtRow["usr_date_create"]), Convert.ToDateTime(dtRow["usr_date_update"]), dtRow["ofc_id"].ToString(), dtRow["district_id"].ToString());

                                break;
                            #endregion hh_household_home_visit

                            #region hh_household_home_visit_member
                            case "hh_household_home_visit_member":

                                #region Delete
                                strID = dtRow["hhvm_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hhvm_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = "INSERT INTO hh_household_home_visit_member " +
                                               "(hhvm_id, hhm_id, hhv_id, hst_id, " +
                                               "yn_id_hhm_active, " +
                                               "yn_id_edu_sensitised, yn_id_es_aflateen, yn_id_es_agro, yn_id_es_apprenticeship, yn_id_es_silc, " +
                                               "yn_id_fsn_nutrition, yn_id_fsn_referred, yn_id_fsn_wash, " +
                                               "ynna_id_edu_enrolled, ynna_id_edu_support, ynna_id_fsn_education, ynna_id_fsn_support, " +
                                               "ynna_id_hhp_adhering, ynna_id_hhp_art, ynna_id_hhp_referred, " +
                                               "ynna_id_pro_birth_certificate, ynna_id_pro_birth_registration, ynna_id_pro_child_abuse, " +
                                               "ynna_id_pro_child_labour, ynna_id_pro_reintegrated, " +
                                               "ynna_id_ps_parenting, ynna_id_ps_support, ynna_id_ps_violence, " +
                                               "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id,ynna_id_edu_attend_school_regularly,yn_id_es_caregiver_group,ynna_id_es_other_lending_group) " +
                                               "VALUES ('{0}', '{1}', '{2}', '{3}', " +
                                               "'{4}', " +
                                               "'{5}', '{6}', '{7}', '{8}', '{9}', " +
                                               "'{10}', '{11}', '{12}', " +
                                               "'{13}', '{14}', '{15}', '{16}', " +
                                               "'{17}', '{18}', '{19}', " +
                                               "'{20}', '{21}', '{22}', " +
                                               "'{23}', '{24}', " +
                                               "'{25}', '{26}', '{27}', " +
                                               "'{28}', '{29}','{30}','{31}', '{32}','{33}','{34}','{35}','{36}') ";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["hhvm_id"].ToString(), dtRow["hhm_id"].ToString(), dtRow["hhv_id"].ToString(), dtRow["hst_id"].ToString(),
                                                dtRow["yn_id_hhm_active"].ToString(),
                                                dtRow["yn_id_edu_sensitised"].ToString(), dtRow["yn_id_es_aflateen"].ToString(), dtRow["yn_id_es_agro"].ToString(), dtRow["yn_id_es_apprenticeship"].ToString(), dtRow["yn_id_es_silc"].ToString(),
                                                dtRow["yn_id_fsn_nutrition"].ToString(), dtRow["yn_id_fsn_referred"].ToString(), dtRow["yn_id_fsn_wash"].ToString(),
                                                dtRow["ynna_id_edu_enrolled"].ToString(), dtRow["ynna_id_edu_support"].ToString(), dtRow["ynna_id_fsn_education"].ToString(), dtRow["ynna_id_fsn_support"].ToString(),
                                                dtRow["ynna_id_hhp_adhering"].ToString(), dtRow["ynna_id_hhp_art"].ToString(), dtRow["ynna_id_hhp_referred"].ToString(),
                                                dtRow["ynna_id_pro_birth_certificate"].ToString(), dtRow["ynna_id_pro_birth_registration"].ToString(),
                                                dtRow["ynna_id_pro_child_abuse"].ToString(), dtRow["ynna_id_pro_child_labour"].ToString(), dtRow["ynna_id_pro_reintegrated"].ToString(),
                                                dtRow["ynna_id_ps_parenting"].ToString(), dtRow["ynna_id_ps_support"].ToString(), dtRow["ynna_id_ps_violence"].ToString(), dtRow["usr_id_create"].ToString(),
                                                dtRow["usr_id_update"].ToString(), Convert.ToDateTime(dtRow["usr_date_create"]), Convert.ToDateTime(dtRow["usr_date_update"]), dtRow["ofc_id"].ToString(), dtRow["district_id"].ToString(),
                                                dtRow["ynna_id_edu_attend_school_regularly"].ToString(), dtRow["yn_id_es_caregiver_group"].ToString(), dtRow["ynna_id_es_other_lending_group"].ToString());

                                break;
                            #endregion hh_household_home_visit_member

                            #region swm_social_worker
                            case "swm_social_worker":

                                #region Delete
                                strID = dtRow["swk_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE swk_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = "INSERT INTO swm_social_worker " +
                                            "(swk_id, swk_first_name, swk_last_name, " +
                                            "swk_email, swk_phone, swk_phone_other, " +
                                            "swk_status_reason, swk_village, " +
                                            "cso_id, hnr_id, swk_id_manager, sws_id, swt_id, wrd_id, " +
                                            "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                                            "VALUES ('{0}', '{1}', '{2}', " +
                                            "'{3}', '{4}', " +
                                            "'{5}', '{6}', '{7}', " +
                                            "'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', " +
                                            "'{14}', '{15}','{16}','{17}', '{18}','{19}') ";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["swk_id"].ToString(), dtRow["swk_first_name"].ToString(), dtRow["swk_last_name"].ToString(),
                                        dtRow["swk_email"].ToString(), dtRow["swk_phone"].ToString(), dtRow["swk_phone_other"].ToString(),
                                        dtRow["swk_status_reason"].ToString(), dtRow["swk_village"].ToString(),
                                        dtRow["cso_id"].ToString(), dtRow["hnr_id"].ToString() , dtRow["swk_id_manager"].ToString()  , dtRow["sws_id"].ToString()  , dtRow["swt_id"].ToString() , dtRow["wrd_id"].ToString() ,
                                        dtRow["usr_id_create"].ToString(), dtRow["usr_id_update"].ToString(),Convert.ToDateTime(dtRow["usr_date_create"]), Convert.ToDateTime(dtRow["usr_date_update"]), dtRow["ofc_id"].ToString() , dtRow["district_id"].ToString());

                                break;
                            #endregion swm_social_worker

                            #region hh_ovc_identification_prioritization
                            case "hh_ovc_identification_prioritization":

                                #region Delete
                                strID = dtRow["oip_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE oip_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = "INSERT INTO hh_ovc_identification_prioritization " +
                                                "(oip_id, oip_comments, oip_date, " +
                                                "oip_18_above_female, oip_18_above_male, oip_18_below_female, oip_18_below_male, oip_hiv_adult, oip_hiv_children, " +
                                                "oip_cp_month, oip_interviewer_tel, " +
                                                "cso_id, hh_id, hhm_id, swk_id, " +
                                                "yn_id_children, " +
                                                "yn_id_cp_abuse, yn_id_cp_abuse_physical, yn_id_cp_abuse_sexual, " +
                                                "yn_id_cp_marriage_teen_parent, yn_id_cp_neglected, yn_id_cp_no_birth_register, " +
                                                "yn_id_cp_orphan, yn_id_cp_pregnancy, yn_id_cp_referred, " +
                                                "yn_id_edu_referred, yn_id_es_child_headed, yn_id_es_disability, " +
                                                "yn_id_es_employment, yn_id_es_expense, yn_id_es_referred, " +
                                                "yn_id_fsn_meals, yn_id_fsn_malnourished, yn_id_fsn_referred, " +
                                                "yn_id_hwss_hiv_positive, yn_id_hwss_hiv_status, yn_id_hwss_referred, " +
                                                "yn_id_hwss_shelter, yn_id_hwss_water, " +
                                                "yn_id_psbc_referred, yn_id_psbc_stigmatized, " +
                                                "ynna_id_edu_missed_school, ynna_id_edu_not_enrolled, " +
                                                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id,ids_id) " +
                                                "VALUES ('{0}', '{1}', '{2}', " +
                                                "{3}, {4}, {5}, {6}, {7}, {8}, " +
                                                "'{9}', '{10}', " +
                                                "'{11}', '{12}', '{13}', '{14}', " +
                                                "'{15}', " +
                                                "'{16}', '{17}', '{18}', " +
                                                "'{19}', '{20}', '{21}', " +
                                                "'{22}', '{23}', '{24}', " +
                                                "'{25}', '{26}', '{27}', " +
                                                "'{28}', '{29}', '{30}', " +
                                                "'{31}', '{32}', '{33}', " +
                                                "'{34}', '{35}', '{36}', " +
                                                "'{37}', '{38}', " +
                                                "'{39}', '{40}', " +
                                                "'{41}', '{42}', " +
                                                "'{43}', '{44}','{45}','{46}', '{47}','{48}','{49}')";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["oip_id"].ToString(), dtRow["oip_comments"].ToString(), Convert.ToDateTime(dtRow["oip_date"]),
                                            dtRow["oip_18_above_female"].ToString(), dtRow["oip_18_above_male"].ToString() , dtRow["oip_18_below_female"].ToString() , dtRow["oip_18_below_male"].ToString() , dtRow["oip_hiv_adult"].ToString(), dtRow["oip_hiv_children"].ToString(),
                                            dtRow["oip_cp_month"].ToString(), dtRow["oip_interviewer_tel"].ToString(),
                                            dtRow["cso_id"].ToString(), dtRow["hh_id"].ToString() , dtRow["hhm_id"].ToString() , dtRow["swk_id"].ToString()  ,
                                            dtRow["yn_id_children"].ToString(),
                                                dtRow["yn_id_cp_abuse"].ToString(), dtRow["yn_id_cp_abuse_physical"].ToString(), dtRow["yn_id_cp_abuse_sexual"].ToString(),
                                            dtRow["yn_id_cp_marriage_teen_parent"].ToString(), dtRow["yn_id_cp_neglected"].ToString() , dtRow["yn_id_cp_no_birth_register"].ToString() ,
                                            dtRow["yn_id_cp_orphan"].ToString() , dtRow["yn_id_cp_pregnancy"].ToString() , dtRow["yn_id_cp_referred"].ToString() ,
                                            dtRow["yn_id_edu_referred"].ToString(), dtRow["yn_id_es_child_headed"].ToString() , dtRow["yn_id_es_disability"].ToString() ,
                                            dtRow["yn_id_es_employment"].ToString(), dtRow["yn_id_es_expense"].ToString() , dtRow["yn_id_es_referred"].ToString() ,
                                            dtRow["yn_id_fsn_meals"].ToString(), dtRow["yn_id_fsn_malnourished"].ToString() , dtRow["yn_id_fsn_referred"].ToString() ,
                                            dtRow["yn_id_hwss_hiv_positive"].ToString() , dtRow["yn_id_hwss_hiv_status"].ToString()  , dtRow["yn_id_hwss_referred"].ToString() ,
                                            dtRow["yn_id_hwss_shelter"].ToString(), dtRow["yn_id_hwss_water"].ToString() ,
                                            dtRow["yn_id_psbc_referred"].ToString() , dtRow["yn_id_psbc_stigmatized"].ToString()  ,
                                            dtRow["ynna_id_edu_missed_school"].ToString(), dtRow["ynna_id_edu_not_enrolled"].ToString() ,
                                            dtRow["usr_id_create"].ToString(), dtRow["usr_id_update"].ToString(), Convert.ToDateTime(dtRow["usr_date_create"]), Convert.ToDateTime(dtRow["usr_date_update"]), dtRow["ofc_id"].ToString(), dtRow["district_id"].ToString() , dtRow["ids_id"].ToString());

                                break;
                            #endregion hh_ovc_identification_prioritization

                            #region hh_household_improvement_plan
                            case "hh_household_improvement_plan":

                                #region Delete
                                strID = dtRow["hip_id"].ToString();
                                strSQLDelete = " DELETE FROM {0} WHERE hip_id = '{1}'";
                                strSQLDelete = string.Format(strSQLDelete, DownLoadTable, strID);
                                #endregion Delete

                                strSQLInsert = @"INSERT INTO [dbo].[hh_household_improvement_plan]([hip_id],[hh_code],[hh_id],[visit_date] ,[ov_below_seventeen_yrs_male],[ov_below_seventeen_yrs_female]
                                           ,[ov_above_eighteen_yrs_male],[ov_above_eighteen_yrs_female],[health_knows_status_of_children] ,[health_enrolled_on_art],[health_action_plan]
                                           ,[health_follow_up_date],[household_is_healthy],[safe_has_birth_certificates],[safe_no_child_abuse],[safe_action_plan],[safe_follow_up_date]
                                           ,[household_is_safe],[stable_source_of_income],[stable_financial_services],[stable_two_or_more_meals],[stable_action_plan],[stable_follow_up_date]
                                           ,[household_is_stable],[schooled_all_attending_school],[schooled_attained_techinical_skill],[schooled_others],[schooled_action_plan],[schooled_follow_up_date]
                                           ,[household_is_schooled],[sw_id],[sw_comment],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])

                                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}',
                                                    '{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}')";

                                strSQLInsert = string.Format(strSQLInsert, dtRow["hip_id"].ToString(), dtRow["hh_code"].ToString(), dtRow["hh_id"].ToString(), Convert.ToDateTime(dtRow["visit_date"]) , dtRow["ov_below_seventeen_yrs_male"].ToString() , dtRow["ov_below_seventeen_yrs_female"].ToString() , dtRow["ov_above_eighteen_yrs_male"].ToString() ,
                        dtRow["ov_above_eighteen_yrs_female"].ToString(), dtRow["health_knows_status_of_children"].ToString() , dtRow["health_enrolled_on_art"].ToString(), dtRow["health_action_plan"].ToString() , dtRow["health_follow_up_date"].ToString() , dtRow["household_is_healthy"].ToString() ,
                        dtRow["safe_has_birth_certificates"].ToString(), dtRow["safe_no_child_abuse"].ToString() , dtRow["safe_action_plan"].ToString() , dtRow["safe_follow_up_date"].ToString() , dtRow["household_is_safe"].ToString() , dtRow["stable_source_of_income"].ToString() , dtRow["stable_financial_services"].ToString() ,
                        dtRow["stable_two_or_more_meals"].ToString(), dtRow["stable_action_plan"].ToString() , dtRow["stable_follow_up_date"].ToString() , dtRow["household_is_stable"].ToString() , dtRow["schooled_all_attending_school"].ToString() , dtRow["schooled_attained_techinical_skill"].ToString() ,
                        dtRow["schooled_others"].ToString(), dtRow["schooled_action_plan"].ToString() , dtRow["schooled_follow_up_date"].ToString() , dtRow["household_is_schooled"].ToString() , dtRow["sw_id"].ToString() , dtRow["sw_comment"].ToString() , dtRow["usr_id_create"].ToString() , dtRow["usr_id_update"].ToString() , Convert.ToDateTime(dtRow["usr_date_create"]) ,
                        Convert.ToDateTime(dtRow["usr_date_update"]) , dtRow["ofc_id"].ToString()  , dtRow["district_id"].ToString()  );

                                break;
                                #endregion hh_household_improvement_plan
                        }

                        #endregion Switch Tables

                        #region Disbale Triggers

                        strSQLTrigger = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} DISABLE TRIGGER {0}_insert";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} DISABLE TRIGGER {0}_update";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);

                        #endregion Disbale Triggers

                        #region Execute Delete
                        using (conn = new SqlConnection(SQLConnection))
                        using (SqlCommand cmd = new SqlCommand(strSQLDelete, conn))
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
                        #endregion Execute Delete

                        #region Execute Insert

                        using (conn = new SqlConnection(SQLConnection))
                        using (SqlCommand cmd = new SqlCommand(strSQLInsert, conn))
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
                        #endregion Execute Insert

                        #region Enable Triggers

                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_delete";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_insert";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_update";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);

                        #endregion Enable Triggers


                        count += x;
                        SetText(count.ToString());

                        bgWorkerImport.ReportProgress(x);
                    }
                    catch (SqlException ex)
                    {
                        #region Enable Triggers

                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_delete";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_insert";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);
                        strSQLTrigger = "ALTER TABLE {0} ENABLE TRIGGER {0}_update";
                        strSQLTrigger = string.Format(strSQLTrigger, DownLoadTable);
                        dbCon.ExecuteNonQuery(strSQLTrigger);

                        #endregion Enable Triggers

                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }

                    SetstatusText("Fetching next row for import...please wait...");
                }

                SetstatusText("Data Import Completed...");
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (CheckOfficeValidation(SystemConstants.ofc_id))
            {
                lblofficestatus.Text = "Validated";
                btnSync.Enabled = false;
                bgWorkerImport.RunWorkerAsync();
            }
            else
            {
                lblofficestatus.Text = "Not Validated";
                MessageBox.Show("Office Not yet Validated,contact palladium support for assistance", "SOCY MIS Message Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }

        }

        protected bool CheckOfficeValidation(string ofc_id)
        {
            bool isValidated = false;

            SOCY_WS.SOCY_WS wsSM = null;


            try
            {
                wsSM = new SOCY_WS.SOCY_WS();
                wsSM.Timeout = -1;

                SetstatusText("Now communicating with server.... please wait.....");
                SetstatusText("Connection established.... please wait.....");
                SetstatusText("Checking office validation.... please wait.....");

                isValidated = wsSM.CheckOfficeValidation(ofc_id);
                SetstatusText("Validation completed.... please wait.....");
            }
            catch (System.Net.WebException exc)
            {
                throw exc;
            }

            return isValidated;
        }

        private void bgWorkerImport_DoWork(object sender, DoWorkEventArgs e)
        {
            string table_id = string.Empty;
            string dst_id = string.Empty;

            MethodInvoker ReadComboDownLoadTable = new MethodInvoker(() =>
            {
                table_id = cboDownloadList.SelectedValue.ToString();
            });
            this.Invoke(ReadComboDownLoadTable);

            MethodInvoker ReadComboDistrict = new MethodInvoker(() =>
            {
                dst_id = cboDistrict.SelectedValue.ToString();
            });
            this.Invoke(ReadComboDistrict);

            if (table_id == "-1")
            {
                MessageBox.Show("Please select a dataset before proceeding!", "SOCY MIS Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                LoadWSResults(table_id, dst_id);
            } 

            
        }

        private void bgWorkerImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string table_id = string.Empty;

            MethodInvoker ReadComboDownLoadTable = new MethodInvoker(() =>
            {
                table_id = cboDownloadList.SelectedValue.ToString();
            });
            this.Invoke(ReadComboDownLoadTable);

            Cursor = Cursors.Default;
            btnSync.Enabled = true;

            if (table_id == "-1")
            {
                MessageBox.Show("Import unsuccessful!", "SOCY MIS Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("All Imports for " + cboDownloadList.Text + " Completed Successfully", "SOCY MIS Import Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.lblCount.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblCount.Text = text;
            }
        }

        private void SetstatusText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.lblstatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetstatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblstatus.Text = text;
            }


        }

        delegate void SetProgressBarMaxCallback(int value);

        private void SetProgressBarMaxValue(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.PBarDownload.InvokeRequired)
            {
                SetProgressBarMaxCallback d = new SetProgressBarMaxCallback(SetProgressBarMaxValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                PBarDownload.Maximum = value;
            }


        }

        private void bgWorkerImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PBarDownload.Value = e.ProgressPercentage;
            PBarDownload.Text = e.ProgressPercentage.ToString();
        }

        private void cboDownloadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDates.Visible = cboDownloadList.SelectedValue.ToString() == "hh_household_home_visit" || cboDownloadList.SelectedValue.ToString() == "hh_household_home_visit_member" ? true : false;
        }
    }
}
