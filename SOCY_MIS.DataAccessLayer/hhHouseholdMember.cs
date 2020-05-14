using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdMember
    {
        #region Variables
        #region Public
        public string hhm_id = string.Empty;
        public string hhm_first_name = string.Empty;
        public string hhm_last_name = string.Empty;
        public string hhm_number = string.Empty;
        public string hhm_year_of_birth = utilConstants.cDFEmptyListValue;
        public string dtp_id = utilConstants.cDFEmptyListValue;
        public string edu_id = utilConstants.cDFEmptyListValue;
        public string gnd_id = utilConstants.cDFEmptyListValue;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hst_id = utilConstants.cDFEmptyListValue;
        public string mst_id = utilConstants.cDFEmptyListValue;
        public string prf_id = utilConstants.cDFEmptyListValue;
        public string prt_id = utilConstants.cDFEmptyListValue;
        public string yn_id_art = utilConstants.cDFEmptyListValue;
        public string yn_id_birth_registration = utilConstants.cDFEmptyListValue;
        public string yn_id_caregiver = utilConstants.cDFEmptyListValue;
        public string yn_id_disability = utilConstants.cDFEmptyListValue;
        public string yn_id_given_birth = utilConstants.cDFEmptyListValue;
        public string yn_id_hoh = utilConstants.cDFEmptyListValue;
        public string yn_id_immun = utilConstants.cDFEmptyListValue;
        public string yn_id_pregnant = utilConstants.cDFEmptyListValue;
        public string yn_id_school = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;
        public string hhm_status = string.Empty;
        public  string yn_dreams = string.Empty;
        public int Age = 0;
        public  DateTime dreams_enroll_date = DateTime.Now;
        public string yn_attained_vocational_skill = utilConstants.cDFEmptyListValue;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhHouseholdMember()
        {
            Default();
        }

        public hhHouseholdMember(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public bool AllowCaregiver(string strHhmId, string strHhId, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(COUNT(hhm_id), 0) " +
                "FROM hh_household_member " +
                "WHERE NOT hhm_id = '{0}' AND hh_id = '{1}' AND yn_id_caregiver = '{2}' ";
            strSQL = string.Format(strSQL, strHhmId, strHhId, utilConstants.cDFListValueYes);
            if (dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public bool AllowHeadOfHousehold(string strHhmId, string strHhId, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(COUNT(hhm_id), 0) " +
                "FROM hh_household_member " +
                "WHERE NOT hhm_id = '{0}' AND hh_id = '{1}' AND yn_id_hoh = '{2}' ";
            strSQL = string.Format(strSQL, strHhmId, strHhId, utilConstants.cDFListValueYes);
            if (dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            hhHouseholdAssessmentMember dalHAM = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetAssessmentLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalHAM = new hhHouseholdAssessmentMember();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalHAM.Delete(dt.Rows[intCount]["ham_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM hh_household_member WHERE hhm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        
        public bool DeleteAllowed(string strHhmId, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(SUM(tc), 0) AS theCount FROM ( " +
                "SELECT COUNT(hhm_id) AS tc FROM ben_activity_training_participant WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM ben_apprenticeship_register_line WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM ben_girl_education_register_child WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id_caregiver) AS tc FROM ben_girl_education_register_child WHERE hhm_id_caregiver = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM ben_service_register_line WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM ben_value_chain_register_actor WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM drm_member WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM hh_home_visit WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM hh_household_assessment WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM hh_ovc_identification_prioritization WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM hh_referral WHERE hhm_id = '{0}' UNION ALL " +
                "SELECT COUNT(hhm_id) AS tc FROM silc_group_member WHERE hhm_id = '{0}') chk ";
            strSQL = string.Format(strSQL, strHhmId);
            if (dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Member
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetMember(strId, dbCon);
                Load(dt);
            }
            #endregion Set Member
        }

        public string NextMemberNumber(string strHhId, DBConnection dbCon)
        {
            #region Variables
            string strNextNumber =  string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MAX(CONVERT(int, hhm_number)), 0) + 1 AS hhm_number " +
                "FROM hh_household_member " +
                "WHERE hh_id = '{0}' ";
            strSQL = string.Format(strSQL, strHhId);
            strNextNumber = dbCon.ExecuteScalar(strSQL);
            if (strNextNumber.Length == 1)
                strNextNumber = "0" + strNextNumber;
            #endregion SQL

            return strNextNumber;
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetMember(hhm_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private Methods
        private void Default()
        {
            #region Default
            hhm_id = string.Empty;
            hhm_first_name = string.Empty;
            hhm_last_name = string.Empty;
            hhm_number = string.Empty;
            hhm_year_of_birth = utilConstants.cDFEmptyListValue;
            dtp_id = utilConstants.cDFEmptyListValue;
            edu_id = utilConstants.cDFEmptyListValue;
            gnd_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hst_id = utilConstants.cDFEmptyListValue;
            mst_id = utilConstants.cDFEmptyListValue;
            prf_id = utilConstants.cDFEmptyListValue;
            prt_id = utilConstants.cDFEmptyListValue;
            yn_id_art = utilConstants.cDFEmptyListValue;
            yn_id_birth_registration = utilConstants.cDFEmptyListValue;
            yn_id_caregiver = utilConstants.cDFEmptyListValue;
            yn_id_disability = utilConstants.cDFEmptyListValue;
            yn_id_given_birth = utilConstants.cDFEmptyListValue;
            yn_id_hoh = utilConstants.cDFEmptyListValue;
            yn_id_immun = utilConstants.cDFEmptyListValue;
            yn_id_pregnant = utilConstants.cDFEmptyListValue;
            yn_id_school = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_household_member " +
                "(hhm_id, " +
                "hhm_first_name, hhm_last_name, " +
                "hhm_number, hhm_year_of_birth, " +
                "dtp_id, edu_id, gnd_id, " +
                "hh_id, hst_id, mst_id, " +
                "prf_id, prt_id, " +
                "yn_id_art, yn_id_birth_registration, yn_id_caregiver, " +
                "yn_id_disability, yn_id_given_birth, yn_id_hoh, " +
                "yn_id_immun, yn_id_pregnant, yn_id_school, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id,hst_id_new,hhm_status,yn_dreams,dreams_enroll_date) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " +
                "'{3}', '{4}', " +
                "'{5}', '{6}', '{7}', " +
                "'{8}', '{9}', '{10}', " +
                "'{11}', '{12}', " +
                "'{13}', '{14}', '{15}', " +
                "'{16}', '{17}', '{18}', " +
                "'{19}', '{20}', '{21}', " +
                "'{22}', '{22}', GETDATE(), GETDATE(), '{23}','{24}','{9}','{25}','{26}','{27}') ";
            strSQL = string.Format(strSQL, hhm_id,
                utilFormatting.StringForSQL(hhm_first_name), utilFormatting.StringForSQL(hhm_last_name),
                utilFormatting.StringForSQL(hhm_number), utilFormatting.StringForSQL(hhm_year_of_birth),  
                dtp_id, edu_id, gnd_id, 
                hh_id, hst_id, mst_id, 
                prf_id, prt_id, 
                yn_id_art, yn_id_birth_registration, yn_id_caregiver, 
                yn_id_disability, yn_id_given_birth, yn_id_hoh, 
                yn_id_immun, yn_id_pregnant, yn_id_school, 
                usr_id_update, ofc_id,district_id,hhm_status,yn_dreams,dreams_enroll_date);

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
                hhm_id = dr["hhm_id"].ToString();
                hhm_first_name = dr["hhm_first_name"].ToString();
                hhm_last_name = dr["hhm_last_name"].ToString();
                hhm_number = dr["hhm_number"].ToString();
                hhm_year_of_birth = dr["hhm_year_of_birth"].ToString();
                dtp_id = dr["dtp_id"].ToString();
                edu_id = dr["edu_id"].ToString();
                gnd_id = dr["gnd_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hst_id = dr["hst_id"].ToString();
                mst_id = dr["mst_id"].ToString();
                prf_id = dr["prf_id"].ToString();
                prt_id = dr["prt_id"].ToString();
                yn_id_art = dr["yn_id_art"].ToString();
                yn_id_birth_registration = dr["yn_id_birth_registration"].ToString();
                yn_id_caregiver = dr["yn_id_caregiver"].ToString();
                yn_id_disability = dr["yn_id_disability"].ToString();
                yn_id_given_birth = dr["yn_id_given_birth"].ToString();
                yn_id_hoh = dr["yn_id_hoh"].ToString();
                yn_id_immun = dr["yn_id_immun"].ToString();
                yn_id_pregnant = dr["yn_id_pregnant"].ToString();
                yn_id_school = dr["yn_id_school"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                hhm_status = dr["hhm_status"].ToString();
                yn_dreams = dr["yn_dreams"].ToString();
                dreams_enroll_date = Convert.ToDateTime( dr["dreams_enroll_date"].ToString());
                Age = Convert.ToInt32( dr["Age"].ToString());
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE hh_household_member " +
                "SET hhm_first_name = '{1}', hhm_last_name = '{2}', " +
                "hhm_number = '{3}', hhm_year_of_birth = '{4}', " +
                "dtp_id = '{5}', edu_id = '{6}', gnd_id = '{7}', " +
                "hh_id = '{8}', hst_id = '{9}', mst_id = '{10}', " +
                "prf_id = '{11}', prt_id = '{12}', " +
                "yn_id_art = '{13}', yn_id_birth_registration = '{14}', yn_id_caregiver = '{15}', " +
                "yn_id_disability = '{16}', yn_id_given_birth = '{17}', yn_id_hoh = '{18}', " +
                "yn_id_immun = '{19}', yn_id_pregnant = '{20}', yn_id_school = '{21}', " +
                "usr_id_update = '{22}', usr_date_update = GETDATE() ,district_id = '{23}',hhm_status = '{24}',hst_id_new = '{9}'," +
                " yn_dreams = '{25}',dreams_enroll_date = '{26}'" + 
                "WHERE hhm_id = '{0}' ";
            strSQL = string.Format(strSQL, hhm_id,
                utilFormatting.StringForSQL(hhm_first_name), utilFormatting.StringForSQL(hhm_last_name),
                utilFormatting.StringForSQL(hhm_number), utilFormatting.StringForSQL(hhm_year_of_birth),
                dtp_id, edu_id, gnd_id,
                hh_id, hst_id, mst_id,
                prf_id, prt_id,
                yn_id_art, yn_id_birth_registration, yn_id_caregiver,
                yn_id_disability, yn_id_given_birth, yn_id_hoh,
                yn_id_immun, yn_id_pregnant, yn_id_school, 
                usr_id_update,district_id,hhm_status, yn_dreams, dreams_enroll_date);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL

            #region UpdateHomevisitData
            if (hst_id != "1")
            {
                strSQL = @"UPDATE hh_household_home_visit_member_v_2 SET hst_id = '{1}',ynna_on_art = '2',adherence_level = 'NA',ynna_follow_art_prescription = '2'
                        WHERE hhm_id = '{0}'";
                strSQL = string.Format(strSQL,hhm_id,hst_id);
                dbCon.ExecuteNonQuery(strSQL);

                strSQL = @"UPDATE hh_household_home_visit_member SET hst_id = '{1}',ynna_id_hhp_art = '2',ynna_id_hhp_adhering = '2' 
                            WHERE hhm_id = '{0}'";
                strSQL = string.Format(strSQL, hhm_id, hst_id);
                dbCon.ExecuteNonQuery(strSQL);
            }

            #endregion UpdateHomevisitData
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetList(string strHHId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name " +
                "FROM hh_household_member hhm ";
            strSQL = strSQL + string.Format("WHERE hhm.hh_id = '{0}' AND hhm.hhm_status = '1' ", strHHId);
            strSQL = strSQL + "ORDER BY hhm.hhm_number ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetListUnderAge(string strHhId, string strHhmId, int intAge, DateTime dtmAtDate, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            //#region SQL
            //strSQL = string.Format("SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name, hhm.hhm_number " +
            //    "FROM hh_household_member hhm " +
            //    "WHERE hhm.hh_id = '{0}' " +
            //    "AND DATEADD(year, {2}, hhm_year_of_birth + '/01/01') > '{3}' " +
            //    "AND hhm_year_of_birth + '/01/01' < DATEADD(year, 1, '{3}') " +
            //    "UNION " +
            //    "SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name, hhm.hhm_number " +
            //    "FROM hh_household_member hhm " + 
            //    "WHERE hhm.hhm_id = '{1}' " +
            //    "ORDER BY hhm_number ", strHhId, strHhmId, intAge, dtmAtDate.ToString("dd MMM yyyy"));
            //dt = dbCon.ExecuteQueryDataTable(strSQL);
            //#endregion SQL

            #region SQL
            strSQL = string.Format("SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name, hhm.hhm_number " +
                "FROM hh_household_member hhm " +
                "WHERE hhm.hh_id = '{0}' " +
                "UNION " +
                "SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name, hhm.hhm_number " +
                "FROM hh_household_member hhm " +
                "WHERE hhm.hhm_id = '{1}' " +
                "ORDER BY hhm_number ", strHhId, strHhmId, intAge, dtmAtDate.ToString("dd MMM yyyy"));
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetListForForm(string strHHId, string strHhmId, string strFormTable, string strFormPrefix, string strObjId, DBConnection dbCon)
        {
            return GetListForForm(strHHId, strHhmId, strFormTable, strFormPrefix, strObjId, "hhm_id", dbCon);
        }

        public DataTable GetListForForm(string strHHId, string strHhmId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region SQL
            strSQLSelect = string.Format("SELECT hhm.hhm_id, RTRIM(LTRIM(hhm.hhm_number + ' - ' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name " +
                "FROM hh_household_member hhm " +
                "WHERE hhm.hh_id = '{0}' ", strHHId);
            strSQL = strSQLSelect + string.Format("AND NOT hhm.hhm_id IN (SELECT {3} FROM {0} {1} WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId, strMemberField);
            if (strHhmId.Length != 0)
                strSQL = strSQL + "UNION " + strSQLSelect + string.Format("AND hhm.hh_Id = '{0}' AND hhm.hhm_Id = '{1}' ", strHHId, strHhmId);
            strSQL = strSQL + "ORDER BY hhm_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMember(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm.*, hh.hh_code, hh.hh_code + '/' + hhm.hhm_number AS hhm_code, " + 
                "gnd.gnd_name, hst.hst_name, hh.hh_village, wrd_name, sct.sct_id, sct_name, REPLACE(hhm.hhm_year_of_birth, '-1', '') AS year_of_birth " +
                "FROM hh_household_member hhm " +
                "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "LEFT JOIN (SELECT * FROM lst_gender WHERE lng_id = '{1}') gnd ON hhm.gnd_id = gnd.gnd_id " +
                "LEFT JOIN (SELECT * FROM lst_hiv_status WHERE lng_id = '{1}') hst ON hhm.hst_id = hst.hst_id " +
                "LEFT JOIN (SELECT * FROM lst_ward WHERE lng_id = '{1}') wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT * FROM lst_sub_county WHERE lng_id = '{1}') sct ON wrd.sct_id = sct.sct_id " +
                "WHERE hhm.hhm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembers(string strHhId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm.*, gnd.gnd_name, REPLACE(hhm.hhm_year_of_birth, '-1', '') AS year_of_birth " +
                "FROM hh_household_member hhm " +
                "LEFT JOIN (SELECT * FROM lst_gender WHERE lng_id = '{1}') gnd ON hhm.gnd_id = gnd.gnd_id " +
                "WHERE hhm.hh_id = '{0}' ";
            strSQL = string.Format(strSQL, strHhId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public string GetMemberCaregiver(string strHHId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strId = utilConstants.cDFEmptyListValue;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm_id " +
                "FROM hh_household_member " +
                "WHERE hh_id = '{0}' AND yn_id_caregiver = '{1}' ";
            strSQL = string.Format(strSQL, strHHId, utilConstants.cDFListValueYes);
            dt = dbCon.ExecuteQueryDataTable(strSQL);

            if (utilCollections.HasRows(dt))
                strId = dt.Rows[0]["hhm_id"].ToString();
            #endregion SQL

            return strId;
        }

        public string GetMemberPrime(string strHHId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strId = utilConstants.cDFEmptyListValue;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm_id " +
                "FROM hh_household_member " +
                "WHERE hh_id = '{0}' " +
                "ORDER BY yn_id_hoh DESC, yn_id_caregiver DESC, hhm_number ";
            strSQL = string.Format(strSQL, strHHId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);

            if (utilCollections.HasRows(dt))
                strId = dt.Rows[0]["hhm_id"].ToString();
            #endregion SQL

            return strId;
        }
        #endregion Public

        #region Private
        private DataTable GetAssessmentLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ham.* " +
            "FROM hh_household_assessment_member ham " +
            "WHERE ham.hhm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetMember(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm.*,YEAR(GETDATE()) - hhm_year_of_birth AS Age " +
            "FROM hh_household_member hhm " +
            "WHERE hhm.hhm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
