using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benCovid19DataCollection
    {
        #region Variables
        public static string cdc_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string report_month = string.Empty;
        public static string week_name = string.Empty;
        public static string swk_id = string.Empty;
        public static string psw_id = string.Empty;
        public static string total_hh_visited = string.Empty;
        public static string total_hh_hip_reviewed = string.Empty;
        public static string total_ben_served = string.Empty;
        public static string total_ben_hiv_pos = string.Empty;
        public static string total_ben_hiv_neg = string.Empty;
        public static string total_ben_hiv_tnr = string.Empty;
        public static string total_ben_hiv_unknown = string.Empty;
        public static string total_ben_risk_assessed = string.Empty;
        public static string total_new_referals_made = string.Empty;
        public static string total_old_referals_followedup = string.Empty;
        public static string total_ben_with_vl = string.Empty;
        public static string total_ben_not_supress = string.Empty;
        public static string total_emergency_case_found = string.Empty;
        public static string general_comment = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion

        public static void save(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"INSERT INTO [dbo].[ben_covid19_data_collection]
                    ([cdc_id] ,[wrd_id] ,[report_month] ,[week_name],[swk_id],[psw_id] ,[total_hh_visited],[total_hh_hip_reviewed] ,[total_ben_served] ,[total_ben_hiv_pos]
                    ,[total_ben_hiv_neg] ,[total_ben_hiv_tnr] ,[total_ben_hiv_unknown] ,[total_ben_risk_assessed] ,[total_new_referals_made] ,[total_old_referals_followedup]
                    ,[total_ben_with_vl] ,[total_ben_not_supress] ,[total_emergency_case_found] ,[general_comment] ,[usr_id_create] ,[usr_id_update] ,[usr_date_create] ,[usr_date_update]
                    ,[ofc_id] ,[district_id])
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')";

            strSQL = string.Format(strSQL, cdc_id, wrd_id, report_month, week_name, swk_id, psw_id, total_hh_visited, total_hh_hip_reviewed, total_ben_served, total_ben_hiv_pos
           , total_ben_hiv_neg, total_ben_hiv_tnr, total_ben_hiv_unknown, total_ben_risk_assessed, total_new_referals_made, total_old_referals_followedup
           , total_ben_with_vl, total_ben_not_supress, total_emergency_case_found, general_comment, usr_id_create, usr_id_update, usr_date_create, usr_date_update
           , ofc_id, district_id);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }

        public static void update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = @"UPDATE [dbo].[ben_covid19_data_collection]
                       SET [wrd_id] =  '{1}'
                          ,[report_month] = '{2}'
                          ,[week_name] = '{3}'
                          ,[swk_id] = '{4}'
                          ,[psw_id] = '{5}'
                          ,[total_hh_visited] = '{6}'
                          ,[total_hh_hip_reviewed] = '{7}'
                          ,[total_ben_served] = '{8}'
                          ,[total_ben_hiv_pos] = '{9}'
                          ,[total_ben_hiv_neg] ='{10}'
                          ,[total_ben_hiv_tnr] = '{11}'
                          ,[total_ben_hiv_unknown] = '{12}'
                          ,[total_ben_risk_assessed] = '{13}'
                          ,[total_new_referals_made] = '{14}'
                          ,[total_old_referals_followedup] = '{51}'
                          ,[total_ben_with_vl] ='{16}'
                          ,[total_ben_not_supress] = '{17}'
                          ,[total_emergency_case_found] = '{18}'
                          ,[general_comment] = '{19}'
                          ,[usr_id_update] = '{20}'
                          ,[usr_date_update] = '{21}'
                     WHERE  [cdc_id] = '{0}'";

            strSQL = string.Format(strSQL, cdc_id, wrd_id, report_month, week_name, swk_id, psw_id, total_hh_visited, total_hh_hip_reviewed, total_ben_served, total_ben_hiv_pos
           , total_ben_hiv_neg, total_ben_hiv_tnr, total_ben_hiv_unknown, total_ben_risk_assessed, total_new_referals_made, total_old_referals_followedup
           , total_ben_with_vl, total_ben_not_supress, total_emergency_case_found, general_comment, usr_id_update, usr_date_update);
            dbCon.ExecuteScalar(strSQL);
            #endregion SQL
        }
    }
}
