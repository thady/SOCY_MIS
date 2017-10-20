using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhOVCIdentificationPrioritization
    {
        #region Variables
        #region Public
        public string oip_id = string.Empty;
        public string oip_comments = string.Empty;
        public DateTime oip_date = DateTime.Now;
        public int oip_18_above_female = 0;
        public int oip_18_above_male = 0;
        public int oip_18_below_female = 0;
        public int oip_18_below_male = 0;
        public int oip_hiv_adult = 0;
        public int oip_hiv_children = 0;
        public string oip_cp_month = utilConstants.cDFEmptyListValue;
        public string oip_interviewer_tel = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string yn_id_children = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_abuse = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_abuse_physical = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_abuse_sexual = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_marriage_teen_parent = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_neglected = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_no_birth_register = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_orphan = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_pregnancy = utilConstants.cDFEmptyListValue;
        public string yn_id_cp_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_edu_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_es_child_headed = utilConstants.cDFEmptyListValue;
        public string yn_id_es_disability = utilConstants.cDFEmptyListValue;
        public string yn_id_es_employment = utilConstants.cDFEmptyListValue;
        public string yn_id_es_expense = utilConstants.cDFEmptyListValue;
        public string yn_id_es_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_fsn_meals = utilConstants.cDFEmptyListValue;
        public string yn_id_fsn_malnourished = utilConstants.cDFEmptyListValue;
        public string yn_id_fsn_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_hwss_hiv_positive = utilConstants.cDFEmptyListValue;
        public string yn_id_hwss_hiv_status = utilConstants.cDFEmptyListValue;
        public string yn_id_hwss_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_hwss_shelter = utilConstants.cDFEmptyListValue;
        public string yn_id_hwss_water = utilConstants.cDFEmptyListValue;
        public string yn_id_psbc_referred = utilConstants.cDFEmptyListValue;
        public string yn_id_psbc_stigmatized = utilConstants.cDFEmptyListValue;
        public string ynna_id_edu_missed_school = utilConstants.cDFEmptyListValue;
        public string ynna_id_edu_not_enrolled = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;
        #endregion Public

        #region Private
        #endregion Private
        #endregion Variables
        #region Constractor Methods
        public hhOVCIdentificationPrioritization()
        {
            Default();
        }

        public hhOVCIdentificationPrioritization(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_ovc_identification_prioritization WHERE oip_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Object
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetObject(strId, dbCon);
                Load(dt);
            }
            #endregion Set Object
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(oip_id, dbCon);
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
            oip_id = string.Empty;
            oip_comments = string.Empty;
            oip_date = DateTime.Now;
            oip_18_above_female = 0;
            oip_18_above_male = 0;
            oip_18_below_female = 0;
            oip_18_below_male = 0;
            oip_hiv_adult = 0;
            oip_hiv_children = 0;
            oip_cp_month = utilConstants.cDFEmptyListValue;
            oip_interviewer_tel = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            yn_id_children = utilConstants.cDFEmptyListValue;
            yn_id_cp_abuse = utilConstants.cDFEmptyListValue;
            yn_id_cp_abuse_physical = utilConstants.cDFEmptyListValue;
            yn_id_cp_abuse_sexual = utilConstants.cDFEmptyListValue;
            yn_id_cp_marriage_teen_parent = utilConstants.cDFEmptyListValue;
            yn_id_cp_neglected = utilConstants.cDFEmptyListValue;
            yn_id_cp_no_birth_register = utilConstants.cDFEmptyListValue;
            yn_id_cp_orphan = utilConstants.cDFEmptyListValue;
            yn_id_cp_pregnancy = utilConstants.cDFEmptyListValue;
            yn_id_cp_referred = utilConstants.cDFEmptyListValue;
            yn_id_edu_referred = utilConstants.cDFEmptyListValue;
            yn_id_es_child_headed = utilConstants.cDFEmptyListValue;
            yn_id_es_disability = utilConstants.cDFEmptyListValue;
            yn_id_es_employment = utilConstants.cDFEmptyListValue;
            yn_id_es_expense = utilConstants.cDFEmptyListValue;
            yn_id_es_referred = utilConstants.cDFEmptyListValue;
            yn_id_fsn_malnourished = utilConstants.cDFEmptyListValue;
            yn_id_fsn_meals = utilConstants.cDFEmptyListValue;
            yn_id_fsn_referred = utilConstants.cDFEmptyListValue;
            yn_id_hwss_hiv_positive = utilConstants.cDFEmptyListValue;
            yn_id_hwss_hiv_status = utilConstants.cDFEmptyListValue;
            yn_id_hwss_referred = utilConstants.cDFEmptyListValue;
            yn_id_hwss_shelter = utilConstants.cDFEmptyListValue;
            yn_id_hwss_water = utilConstants.cDFEmptyListValue;
            yn_id_psbc_referred = utilConstants.cDFEmptyListValue;
            yn_id_psbc_stigmatized = utilConstants.cDFEmptyListValue;
            ynna_id_edu_missed_school = utilConstants.cDFEmptyListValue;
            ynna_id_edu_not_enrolled = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_ovc_identification_prioritization " +
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
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
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
                "'{43}', '{43}', GETDATE(), GETDATE(), '{44}','{45}') ";
            strSQL = string.Format(strSQL, oip_id, utilFormatting.StringForSQL(oip_comments), oip_date.ToString("dd MMM yyyy HH:mm:ss"),
                oip_18_above_female, oip_18_above_male, oip_18_below_female, oip_18_below_male, oip_hiv_adult, oip_hiv_children,
                oip_cp_month, utilFormatting.StringForSQL(oip_interviewer_tel),
                cso_id, hh_id, hhm_id, swk_id,
                yn_id_children,
                yn_id_cp_abuse, yn_id_cp_abuse_physical, yn_id_cp_abuse_sexual,
                yn_id_cp_marriage_teen_parent, yn_id_cp_neglected, yn_id_cp_no_birth_register,
                yn_id_cp_orphan, yn_id_cp_pregnancy, yn_id_cp_referred,
                yn_id_edu_referred, yn_id_es_child_headed, yn_id_es_disability,
                yn_id_es_employment, yn_id_es_expense, yn_id_es_referred,
                yn_id_fsn_meals, yn_id_fsn_malnourished, yn_id_fsn_referred,
                yn_id_hwss_hiv_positive, yn_id_hwss_hiv_status, yn_id_hwss_referred,
                yn_id_hwss_shelter, yn_id_hwss_water,
                yn_id_psbc_referred, yn_id_psbc_stigmatized,
                ynna_id_edu_missed_school, ynna_id_edu_not_enrolled,
                usr_id_update, ofc_id,district_id);

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
                oip_id = dr["oip_id"].ToString();
                oip_comments = dr["oip_comments"].ToString();
                oip_date = Convert.ToDateTime(dr["oip_date"]);
                oip_18_above_female = Convert.ToInt32(dr["oip_18_above_female"]);
                oip_18_above_male = Convert.ToInt32(dr["oip_18_above_male"]);
                oip_18_below_female = Convert.ToInt32(dr["oip_18_below_female"]);
                oip_18_below_male = Convert.ToInt32(dr["oip_18_below_male"]);
                oip_hiv_adult = Convert.ToInt32(dr["oip_hiv_adult"]);
                oip_hiv_children = Convert.ToInt32(dr["oip_hiv_children"]);
                oip_cp_month = dr["oip_cp_month"].ToString();
                oip_interviewer_tel = dr["oip_interviewer_tel"].ToString();
                cso_id = dr["cso_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                swk_id = dr["swk_id"].ToString();
                yn_id_children = dr["yn_id_children"].ToString();
                yn_id_cp_abuse = dr["yn_id_cp_abuse"].ToString();
                yn_id_cp_abuse_physical = dr["yn_id_cp_abuse_physical"].ToString();
                yn_id_cp_abuse_sexual = dr["yn_id_cp_abuse_sexual"].ToString();
                yn_id_cp_marriage_teen_parent = dr["yn_id_cp_marriage_teen_parent"].ToString();
                yn_id_cp_neglected = dr["yn_id_cp_neglected"].ToString();
                yn_id_cp_no_birth_register = dr["yn_id_cp_no_birth_register"].ToString();
                yn_id_cp_orphan = dr["yn_id_cp_orphan"].ToString();
                yn_id_cp_pregnancy = dr["yn_id_cp_pregnancy"].ToString();
                yn_id_cp_referred = dr["yn_id_cp_referred"].ToString();
                yn_id_edu_referred = dr["yn_id_edu_referred"].ToString();
                yn_id_es_child_headed = dr["yn_id_es_child_headed"].ToString();
                yn_id_es_disability = dr["yn_id_es_disability"].ToString();
                yn_id_es_employment = dr["yn_id_es_employment"].ToString();
                yn_id_es_expense = dr["yn_id_es_expense"].ToString();
                yn_id_es_referred = dr["yn_id_es_referred"].ToString();
                yn_id_fsn_malnourished = dr["yn_id_fsn_malnourished"].ToString();
                yn_id_fsn_meals = dr["yn_id_fsn_meals"].ToString();
                yn_id_fsn_referred = dr["yn_id_fsn_referred"].ToString();
                yn_id_hwss_hiv_positive = dr["yn_id_hwss_hiv_positive"].ToString();
                yn_id_hwss_hiv_status = dr["yn_id_hwss_hiv_status"].ToString();
                yn_id_hwss_referred = dr["yn_id_hwss_referred"].ToString();
                yn_id_hwss_shelter = dr["yn_id_hwss_shelter"].ToString();
                yn_id_hwss_water = dr["yn_id_hwss_water"].ToString();
                yn_id_psbc_referred = dr["yn_id_psbc_referred"].ToString();
                yn_id_psbc_stigmatized = dr["yn_id_psbc_stigmatized"].ToString();
                ynna_id_edu_missed_school = dr["ynna_id_edu_missed_school"].ToString();
                ynna_id_edu_not_enrolled = dr["ynna_id_edu_not_enrolled"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE hh_ovc_identification_prioritization " +
                "SET oip_comments = '{1}', oip_date = '{2}', " +
                "oip_18_above_female = {3}, oip_18_above_male = {4}, oip_18_below_female = {5}, oip_18_below_male = {6}, oip_hiv_adult = {7}, oip_hiv_children = {8}, " +
                "oip_cp_month = '{9}', oip_interviewer_tel = '{10}', " +
                "cso_id = '{11}', hh_id = '{12}', hhm_id = '{13}', swk_id = '{14}', " +
                "yn_id_children = '{15}', " +
                "yn_id_cp_abuse = '{16}', yn_id_cp_abuse_physical = '{17}', yn_id_cp_abuse_sexual = '{18}', " +
                "yn_id_cp_marriage_teen_parent = '{19}', yn_id_cp_neglected = '{20}', yn_id_cp_no_birth_register = '{21}', " +
                "yn_id_cp_orphan = '{22}', yn_id_cp_pregnancy = '{23}', yn_id_cp_referred = '{24}', " +
                "yn_id_edu_referred = '{25}', yn_id_es_child_headed = '{26}', yn_id_es_disability = '{27}', " +
                "yn_id_es_employment = '{28}', yn_id_es_expense = '{29}', yn_id_es_referred = '{30}', " +
                "yn_id_fsn_meals = '{31}', yn_id_fsn_malnourished = '{32}', yn_id_fsn_referred = '{33}', " +
                "yn_id_hwss_hiv_positive = '{34}', yn_id_hwss_hiv_status = '{35}', yn_id_hwss_referred = '{36}', " +
                "yn_id_hwss_shelter = '{37}', yn_id_hwss_water = '{38}', " +
                "yn_id_psbc_referred = '{39}', yn_id_psbc_stigmatized = '{40}', " +
                "ynna_id_edu_missed_school = '{41}', ynna_id_edu_not_enrolled = '{42}', " +
                "usr_id_update = '{43}', usr_date_update = GETDATE(),district_id = '{44}' " +
                "WHERE oip_id = '{0}' ";
            strSQL = string.Format(strSQL, oip_id, utilFormatting.StringForSQL(oip_comments), oip_date.ToString("dd MMM yyyy HH:mm:ss"),
                oip_18_above_female, oip_18_above_male, oip_18_below_female, oip_18_below_male, oip_hiv_adult, oip_hiv_children,
                oip_cp_month, utilFormatting.StringForSQL(oip_interviewer_tel),
                cso_id, hh_id, hhm_id, swk_id,
                yn_id_children,
                yn_id_cp_abuse, yn_id_cp_abuse_physical, yn_id_cp_abuse_sexual,
                yn_id_cp_marriage_teen_parent, yn_id_cp_neglected, yn_id_cp_no_birth_register,
                yn_id_cp_orphan, yn_id_cp_pregnancy, yn_id_cp_referred,
                yn_id_edu_referred, yn_id_es_child_headed, yn_id_es_disability,
                yn_id_es_employment, yn_id_es_expense, yn_id_es_referred,
                yn_id_fsn_meals, yn_id_fsn_malnourished, yn_id_fsn_referred,
                yn_id_hwss_hiv_positive, yn_id_hwss_hiv_status, yn_id_hwss_referred,
                yn_id_hwss_shelter, yn_id_hwss_water,
                yn_id_psbc_referred, yn_id_psbc_stigmatized,
                ynna_id_edu_missed_school, ynna_id_edu_not_enrolled,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Function Methods
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetByCriteria(string[,] arrFilter, int intArrayLength, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strWHERE = "WHERE 1=1 ";
            #endregion Variables

            #region SQL
            #region WHERE
            for (int intCount = 0; intCount < intArrayLength; intCount++)
            {
                switch (arrFilter[intCount, 0])
                {
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND dst.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "wrd_id":
                        strWHERE = strWHERE + string.Format("AND wrd.wrd_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swk_id":
                        strWHERE = strWHERE + string.Format("AND hh.swk_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hh_id":
                        strWHERE = strWHERE + string.Format("AND hh.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND oip.oip_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND oip.oip_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT oip.oip_id, hh.hh_code, wrd.wrd_name, sct.sct_name, dst.dst_name, " +
                "ISNULL(swk.swk_first_name + ' ' + swk.swk_last_name, '') AS swk_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), oip.oip_date, 106))) AS the_date_display, " +
                "oip.oip_date AS the_date " +
                "FROM hh_ovc_identification_prioritization oip " +
                "INNER JOIN hh_household hh ON oip.hh_id = hh.hh_id " +
                "INNER JOIN lst_ward wrd On hh.wrd_id = wrd.wrd_id AND wrd.lng_id = '{0}' " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id AND sct.lng_id = '{0}' " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id AND dst.lng_id = '{0}' " +
                "LEFT JOIN swm_social_worker swk ON oip.swk_id = swk.swk_id " +
                strWHERE +
                "ORDER BY hh.hh_code, the_date DESC ";

            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDateRange(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MIN(oip_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(oip_date), GETDATE()) AS date_end " +
                "FROM hh_ovc_identification_prioritization ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT oip.* " +
            "FROM hh_ovc_identification_prioritization oip " +
            "WHERE oip.oip_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
