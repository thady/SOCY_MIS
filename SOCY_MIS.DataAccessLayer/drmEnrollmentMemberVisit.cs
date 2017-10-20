using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmEnrollmentMemberVisit
    {
        #region Variables
        #region Public
        public string demv_id = string.Empty;
        public string demv_comment = string.Empty;
        public string demv_referral = string.Empty;
        public DateTime demv_date = DateTime.Now;
        public string dem_id = utilConstants.cDFEmptyListValue;
        public string vst_id = utilConstants.cDFEmptyListValue;
        public string yn_id_anc = utilConstants.cDFEmptyListValue;
        public string yn_id_art = utilConstants.cDFEmptyListValue;
        public string yn_id_cmnc = utilConstants.cDFEmptyListValue;
        public string yn_id_condom_promotion = utilConstants.cDFEmptyListValue;
        public string yn_id_contraceptive_mix = utilConstants.cDFEmptyListValue;
        public string yn_id_hiv_testing = utilConstants.cDFEmptyListValue;
        public string yn_id_parenting_program = utilConstants.cDFEmptyListValue;
        public string yn_id_post_violence_care = utilConstants.cDFEmptyListValue;
        public string yn_id_school_based_prevention = utilConstants.cDFEmptyListValue;
        public string yn_id_social_economic = utilConstants.cDFEmptyListValue;
        public string yn_id_vmmc = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmEnrollmentMemberVisit()
        {
            Default();
        }

        public drmEnrollmentMemberVisit(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Data
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetObject(strId, dbCon);
                Load(dt);
            }
            #endregion Set Data
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(demv_id, dbCon);
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
            demv_id = string.Empty;
            demv_comment = string.Empty;
            demv_referral = string.Empty;
            demv_date = DateTime.Now;
            dem_id = utilConstants.cDFEmptyListValue;
            vst_id = utilConstants.cDFEmptyListValue;
            yn_id_anc = utilConstants.cDFEmptyListValue;
            yn_id_art = utilConstants.cDFEmptyListValue;
            yn_id_cmnc = utilConstants.cDFEmptyListValue;
            yn_id_condom_promotion = utilConstants.cDFEmptyListValue;
            yn_id_contraceptive_mix = utilConstants.cDFEmptyListValue;
            yn_id_hiv_testing = utilConstants.cDFEmptyListValue;
            yn_id_parenting_program = utilConstants.cDFEmptyListValue;
            yn_id_post_violence_care = utilConstants.cDFEmptyListValue;
            yn_id_school_based_prevention = utilConstants.cDFEmptyListValue;
            yn_id_social_economic = utilConstants.cDFEmptyListValue;
            yn_id_vmmc = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO drm_enrollment_member_visit " +
                "(demv_id, demv_comment, demv_referral, " +
                "demv_date, " +
                "dem_id, vst_id, " +
                "yn_id_anc, yn_id_art, yn_id_cmnc, " +
                "yn_id_condom_promotion, yn_id_contraceptive_mix, yn_id_hiv_testing, " +
                "yn_id_parenting_program, yn_id_post_violence_care, yn_id_school_based_prevention, " +
                "yn_id_social_economic, yn_id_vmmc, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
                "'{3}', " +
                "'{4}', '{5}', " +
                "'{6}', '{7}', '{8}', " +
                "'{9}', '{10}', '{11}', " +
                "'{12}', '{13}', '{14}', " +
                "'{15}', '{16}', " +
                "'{17}', '{17}', GETDATE(), GETDATE(), '{18}','{19}') ";
            strSQL = string.Format(strSQL, demv_id, utilFormatting.StringForSQL(demv_comment), utilFormatting.StringForSQL(demv_referral),
                demv_date.ToString("dd MMM yyyy HH:mm:ss"),
                dem_id, vst_id,
                yn_id_anc, yn_id_art, yn_id_cmnc,
                yn_id_condom_promotion, yn_id_contraceptive_mix, yn_id_hiv_testing,
                yn_id_parenting_program, yn_id_post_violence_care, yn_id_school_based_prevention,
                yn_id_social_economic, yn_id_vmmc, 
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
                demv_id = dr["demv_id"].ToString();
                demv_comment = dr["demv_comment"].ToString();
                demv_referral = dr["demv_referral"].ToString();
                demv_date = Convert.ToDateTime(dr["demv_date"]);
                dem_id = dr["dem_id"].ToString();
                vst_id = dr["vst_id"].ToString();
                yn_id_anc = dr["yn_id_anc"].ToString();
                yn_id_art = dr["yn_id_art"].ToString();
                yn_id_cmnc = dr["yn_id_cmnc"].ToString();
                yn_id_condom_promotion = dr["yn_id_condom_promotion"].ToString();
                yn_id_contraceptive_mix = dr["yn_id_contraceptive_mix"].ToString();
                yn_id_hiv_testing = dr["yn_id_hiv_testing"].ToString();
                yn_id_parenting_program = dr["yn_id_parenting_program"].ToString();
                yn_id_post_violence_care = dr["yn_id_post_violence_care"].ToString();
                yn_id_school_based_prevention = dr["yn_id_school_based_prevention"].ToString();
                yn_id_social_economic = dr["yn_id_social_economic"].ToString();
                yn_id_vmmc = dr["yn_id_vmmc"].ToString();
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
            strSQL = "UPDATE drm_enrollment_member_visit " +
                "SET demv_comment = '{1}', demv_referral = '{2}', " +
                "demv_date = '{3}', " +
                "dem_id = '{4}', vst_id = '{5}', " +
                "yn_id_anc = '{6}', yn_id_art = '{7}', yn_id_cmnc = '{8}', " +
                "yn_id_condom_promotion = '{9}', yn_id_contraceptive_mix = '{10}', yn_id_hiv_testing = '{11}', " +
                "yn_id_parenting_program = '{12}', yn_id_post_violence_care = '{13}', yn_id_school_based_prevention = '{14}', " +
                "yn_id_social_economic = '{15}', yn_id_vmmc = '{16}',  " +
                "usr_id_update = '{17}', usr_date_update = GETDATE(),district_id = '{18}' " +
                "WHERE demv_id = '{0}' ";
            strSQL = string.Format(strSQL, demv_id, utilFormatting.StringForSQL(demv_comment), utilFormatting.StringForSQL(demv_referral),
                demv_date.ToString("dd MMM yyyy HH:mm:ss"),
                dem_id, vst_id,
                yn_id_anc, yn_id_art, yn_id_cmnc,
                yn_id_condom_promotion, yn_id_contraceptive_mix, yn_id_hiv_testing,
                yn_id_parenting_program, yn_id_post_violence_care, yn_id_school_based_prevention,
                yn_id_social_economic, yn_id_vmmc,
                usr_id_update, ofc_id, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetList(string strDemId, string strVstId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT vst.vst_id, vst.vst_name, vst.vst_order " +
                "FROM lst_visit vst " +
                "WHERE vst.lng_id = '{1}' AND NOT vst.vst_id IN ( " +
                "SELECT vst_id FROM drm_enrollment_member_visit WHERE dem_id = '{0}') ", strDemId, strLngId);
            if(strVstId.Length != 0)
                strSQL = strSQL + string.Format("UNION " +
                "SELECT vst.vst_id, vst.vst_name, vst.vst_order " +
                "FROM lst_visit vst " +
                "WHERE vst.lng_id = '{1}' AND vst.vst_id = '{0}' " +
                "ORDER BY vst_order ", strVstId, strLngId);
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
            strSQL = "SELECT demv.* " +
            "FROM drm_enrollment_member_visit demv " +
            "WHERE demv.demv_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
