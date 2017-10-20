using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benServiceRegisterLine
    {
        #region Variables
        #region Public
        public string svrl_id = string.Empty;
        public string svrl_eco_strength_other = string.Empty;
        public string hh_id = string.Empty;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string yn_id_agricalture_advisory = utilConstants.cDFEmptyListValue;
        public string yn_id_apprentice_skills = utilConstants.cDFEmptyListValue;
        public string yn_id_basic_care = utilConstants.cDFEmptyListValue;
        public string yn_id_birth_registration = utilConstants.cDFEmptyListValue;
        public string yn_id_case_handled = utilConstants.cDFEmptyListValue;
        public string yn_id_eco_strength_other = utilConstants.cDFEmptyListValue;
        public string yn_id_newly_enrolled = utilConstants.cDFEmptyListValue;
        public string yn_id_parenting = utilConstants.cDFEmptyListValue;
        public string yn_id_psych_support = utilConstants.cDFEmptyListValue;
        public string yn_id_reintegrated = utilConstants.cDFEmptyListValue;
        public string yn_id_silc_intervention = utilConstants.cDFEmptyListValue;
        public string svr_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string[] social_economic = "".Split(utilConstants.cDFSplitChar);
        public int district_id = Convert.ToInt32(static_variables.district_id);

        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benServiceRegisterLine()
        {
            Default();
        }

        public benServiceRegisterLine(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM ben_service_register_line_social_economic WHERE svrl_id = '{0}' " +
                "DELETE FROM ben_service_register_line WHERE svrl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

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
                dt = GetLine(strId, dbCon);
                Load(dt);
                SocialEconomicLoad(strId, dbCon);
            }
            #endregion Set Data
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetLine(svrl_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            SocialEconomicUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default        
            svrl_id = string.Empty;
            svrl_eco_strength_other = string.Empty;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            yn_id_apprentice_skills = utilConstants.cDFEmptyListValue;
            yn_id_basic_care = utilConstants.cDFEmptyListValue;
            yn_id_birth_registration = utilConstants.cDFEmptyListValue;
            yn_id_case_handled = utilConstants.cDFEmptyListValue;
            yn_id_newly_enrolled = utilConstants.cDFEmptyListValue;
            yn_id_parenting = utilConstants.cDFEmptyListValue;
            yn_id_psych_support = utilConstants.cDFEmptyListValue;
            yn_id_reintegrated = utilConstants.cDFEmptyListValue;
            yn_id_silc_intervention = utilConstants.cDFEmptyListValue;
            svr_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;
            social_economic = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO ben_service_register_line " +
                "(svrl_id, svrl_eco_strength_other, " +
                "hhm_id, " +
                "yn_id_agricalture_advisory, yn_id_apprentice_skills, yn_id_basic_care, yn_id_birth_registration, " +
                "yn_id_case_handled, yn_id_eco_strength_other, yn_id_newly_enrolled, yn_id_parenting, " +
                "yn_id_psych_support, yn_id_reintegrated, yn_id_silc_intervention, " +
                "svr_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " + 
                "'{2}', " +
                "'{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', '{10}', " +
                "'{11}', '{12}', '{13}', " +
                "'{14}', " +
                "'{15}', '{15}', GETDATE(), GETDATE(), '{16}','{17}') ";
            strSQL = string.Format(strSQL, svrl_id, utilFormatting.StringForSQL(svrl_eco_strength_other), 
                hhm_id,
                yn_id_agricalture_advisory, yn_id_apprentice_skills, yn_id_basic_care, yn_id_birth_registration,
                yn_id_case_handled, yn_id_eco_strength_other, yn_id_newly_enrolled, yn_id_parenting, 
                yn_id_psych_support, yn_id_reintegrated, yn_id_silc_intervention, 
                svr_id,
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
                svrl_id = dr["svrl_id"].ToString();
                svrl_eco_strength_other = dr["svrl_eco_strength_other"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                yn_id_agricalture_advisory = dr["yn_id_agricalture_advisory"].ToString();
                yn_id_apprentice_skills = dr["yn_id_apprentice_skills"].ToString();
                yn_id_basic_care = dr["yn_id_basic_care"].ToString();
                yn_id_birth_registration = dr["yn_id_birth_registration"].ToString();
                yn_id_case_handled = dr["yn_id_case_handled"].ToString();
                yn_id_eco_strength_other = dr["yn_id_eco_strength_other"].ToString();
                yn_id_newly_enrolled = dr["yn_id_newly_enrolled"].ToString();
                yn_id_parenting = dr["yn_id_parenting"].ToString();
                yn_id_psych_support = dr["yn_id_psych_support"].ToString();
                yn_id_reintegrated = dr["yn_id_reintegrated"].ToString();
                yn_id_silc_intervention = dr["yn_id_silc_intervention"].ToString();
                svr_id = dr["svr_id"].ToString();
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
            strSQL = "UPDATE ben_service_register_line " +
                "SET svrl_eco_strength_other = '{1}', " +
                "hhm_id = '{2}', " +
                "yn_id_agricalture_advisory = '{3}', yn_id_apprentice_skills = '{4}', yn_id_basic_care = '{5}', yn_id_birth_registration = '{6}', " +
                "yn_id_case_handled = '{7}', yn_id_eco_strength_other = '{8}', yn_id_newly_enrolled = '{9}', yn_id_parenting = '{10}', " +
                "yn_id_psych_support = '{11}', yn_id_reintegrated = '{12}', yn_id_silc_intervention = '{13}', " +
                "svr_id = '{14}', " +
                "usr_id_update = '{15}', usr_date_update = GETDATE(),district_id = '{16}' " +
                "WHERE svrl_id = '{0}' ";
            strSQL = string.Format(strSQL, svrl_id, utilFormatting.StringForSQL(svrl_eco_strength_other), 
                hhm_id,
                yn_id_agricalture_advisory, yn_id_apprentice_skills, yn_id_basic_care, yn_id_birth_registration,
                yn_id_case_handled, yn_id_eco_strength_other, yn_id_newly_enrolled, yn_id_parenting,
                yn_id_psych_support, yn_id_reintegrated, yn_id_silc_intervention,
                svr_id,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetLine(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT svrl.*, hhm.hh_id " +
            "FROM ben_service_register_line svrl " +
            "INNER JOIN hh_household_member hhm ON svrl.hhm_id = hhm.hhm_id " +
            "WHERE svrl.svrl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region Training Type
        private DataTable SocialEconomicGet(string strAtId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM ben_service_register_line_social_economic " +
            "WHERE svrl_id = '{0}' ";
            strSQL = string.Format(strSQL, strAtId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void SocialEconomicLoad(string strAtId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = SocialEconomicGet(strAtId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["sec_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["sec_id"].ToString();
            }

            social_economic = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void SocialEconomicUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (social_economic.Length != 0)
            {
                strInsert = "INSERT INTO ben_service_register_line_social_economic (svrlse_id, svrl_id, sec_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT sec_id FROM ben_service_register_line_social_economic WHERE svrl_id = '{0}') ";
                for (int intCount = 0; intCount < social_economic.Length; intCount++)
                {
                    if (social_economic[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", social_economic[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", social_economic[intCount]);
                        strSQL = strSQL + string.Format(strInsert, svrl_id, social_economic[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if(strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM ben_service_register_line_social_economic WHERE svrl_id = '{0}' AND NOT sec_id IN ({1}) ";
            strSQL = string.Format(strSQL, svrl_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Training Type
    }
}
