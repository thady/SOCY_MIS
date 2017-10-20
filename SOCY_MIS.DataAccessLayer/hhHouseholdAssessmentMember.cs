using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdAssessmentMember
    {
        #region Variables
        #region Public
        public string ham_id = string.Empty;
        public string ham_first_name = string.Empty;
        public string ham_last_name = string.Empty;
        public string ham_year_of_birth = utilConstants.cDFEmptyListValue;
        public string dtp_id = utilConstants.cDFEmptyListValue;
        public string edu_id = utilConstants.cDFEmptyListValue;
        public string gnd_id = utilConstants.cDFEmptyListValue;
        public string hooh_id = utilConstants.cDFEmptyListValue;
        public string hha_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
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
        public int district_id = Convert.ToInt32(static_variables.district_id);

        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhHouseholdAssessmentMember()
        {
            Default();
        }

        public hhHouseholdAssessmentMember(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_household_assessment_member WHERE ham_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
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
            strSQL = "SELECT ISNULL(MAX(CONVERT(int, ham_number)), 0) + 1 AS ham_number " +
                "FROM hh_household_assessment_member " +
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
            dt = GetMember(ham_id, dbCon);
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
            ham_id = string.Empty;
            ham_first_name = string.Empty;
            ham_last_name = string.Empty;
            ham_year_of_birth = utilConstants.cDFEmptyListValue;
            dtp_id = utilConstants.cDFEmptyListValue;
            edu_id = utilConstants.cDFEmptyListValue;
            gnd_id = utilConstants.cDFEmptyListValue;
            hha_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO hh_household_assessment_member " +
                "(ham_id, " +
                "ham_first_name, ham_last_name, " +
                "ham_year_of_birth, " +
                "dtp_id, edu_id, gnd_id, " +
                "hha_id, hhm_id, hst_id, mst_id, " +
                "prf_id, prt_id, " +
                "yn_id_art, yn_id_birth_registration, yn_id_caregiver, " +
                "yn_id_disability, yn_id_given_birth, yn_id_hoh, " +
                "yn_id_immun, yn_id_pregnant, yn_id_school, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " +
                "'{3}', " +
                "'{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', '{10}', " +
                "'{11}', '{12}', " +
                "'{13}', '{14}', '{15}', " +
                "'{16}', '{17}', '{18}', " +
                "'{19}', '{20}', '{21}', " +
                "'{22}', '{22}', GETDATE(), GETDATE(), '{23}','{24}') ";
            strSQL = string.Format(strSQL, ham_id,
                utilFormatting.StringForSQL(ham_first_name), utilFormatting.StringForSQL(ham_last_name),
                utilFormatting.StringForSQL(ham_year_of_birth),  
                dtp_id, edu_id, gnd_id,
                hha_id, hhm_id, hst_id, mst_id, 
                prf_id, prt_id, 
                yn_id_art, yn_id_birth_registration, yn_id_caregiver, 
                yn_id_disability, yn_id_given_birth, yn_id_hoh, 
                yn_id_immun, yn_id_pregnant, yn_id_school, 
                usr_id_update, ofc_id, district_id);

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
                ham_id = dr["ham_id"].ToString();
                ham_first_name = dr["ham_first_name"].ToString();
                ham_last_name = dr["ham_last_name"].ToString();
                ham_year_of_birth = dr["ham_year_of_birth"].ToString();
                dtp_id = dr["dtp_id"].ToString();
                edu_id = dr["edu_id"].ToString();
                gnd_id = dr["gnd_id"].ToString();
                hha_id = dr["hha_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
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
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE hh_household_assessment_member " +
                "SET ham_first_name = '{1}', ham_last_name = '{2}', " +
                "ham_year_of_birth = '{3}', " +
                "dtp_id = '{4}', edu_id = '{5}', gnd_id = '{6}', " +
                "hha_id = '{7}', hhm_id = '{8}', hst_id = '{9}', mst_id = '{10}', " +
                "prf_id = '{11}', prt_id = '{12}', " +
                "yn_id_art = '{13}', yn_id_birth_registration = '{14}', yn_id_caregiver = '{15}', " +
                "yn_id_disability = '{16}', yn_id_given_birth = '{17}', yn_id_hoh = '{18}', " +
                "yn_id_immun = '{19}', yn_id_pregnant = '{20}', yn_id_school = '{21}', " +
                "usr_id_update = '{22}', usr_date_update = GETDATE(),district_id = '{23}' " +
                "WHERE ham_id = '{0}' ";
            strSQL = string.Format(strSQL, ham_id,
                utilFormatting.StringForSQL(ham_first_name), utilFormatting.StringForSQL(ham_last_name),
                utilFormatting.StringForSQL(ham_year_of_birth),
                dtp_id, edu_id, gnd_id,
                hha_id, hhm_id, hst_id, mst_id,
                prf_id, prt_id,
                yn_id_art, yn_id_birth_registration, yn_id_caregiver,
                yn_id_disability, yn_id_given_birth, yn_id_hoh,
                yn_id_immun, yn_id_pregnant, yn_id_school, 
                usr_id_update, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
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
            strSQL = "SELECT ham.ham_id, RTRIM(LTRIM(ham.ham_number + ' - ' + ham.ham_first_name + ' ' + ham.ham_last_name)) AS ham_name " +
                "FROM hh_household_assessment_member ham ";
            if (strHHId.Length != 0)
                strSQL = strSQL + string.Format("WHERE ham.hh_id = '{0}' ", strHHId);
            strSQL = strSQL + "ORDER BY ham.ham_number ";
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
            strSQL = "SELECT ham.*, hh.hh_code, hh.hh_code + '/' + ham.ham_number AS ham_code, " + 
                "gnd.gnd_name, hst.hst_name, hh.hh_village, wrd_name, sct_name, REPLACE(ham.ham_year_of_birth, '-1', '') AS year_of_birth " +
                "FROM hh_household_assessment_member ham " +
                "INNER JOIN hh_household hh ON ham.hh_id = hh.hh_id " +
                "LEFT JOIN (SELECT * FROM lst_gender WHERE lng_id = '{1}') gnd ON ham.gnd_id = gnd.gnd_id " +
                "LEFT JOIN (SELECT * FROM lst_hiv_status WHERE lng_id = '{1}') hst ON ham.hst_id = hst.hst_id " +
                "LEFT JOIN (SELECT * FROM lst_ward WHERE lng_id = '{1}') wrd ON hh.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT * FROM lst_sub_county WHERE lng_id = '{1}') sct ON wrd.sct_id = sct.sct_id " +
                "WHERE ham.ham_id = '{0}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembers(string strHhaId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ham.*, gnd.gnd_name, REPLACE(ham.ham_year_of_birth, '-1', '') AS year_of_birth, hhm.hhm_number " +
                "FROM hh_household_assessment_member ham " +
                "INNER JOIN hh_household_member hhm ON ham.hhm_id = hhm.hhm_id " +
                "LEFT JOIN (SELECT * FROM lst_gender WHERE lng_id = '{1}') gnd ON ham.gnd_id = gnd.gnd_id " +
                "WHERE ham.hha_id = '{0}' ";
            strSQL = string.Format(strSQL, strHhaId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetMember(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ham.* " +
            "FROM hh_household_assessment_member ham " +
            "WHERE ham.ham_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
