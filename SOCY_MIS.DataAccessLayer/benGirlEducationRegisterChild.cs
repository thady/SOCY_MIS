using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benGirlEducationRegisterChild
    {
        #region Variables
        #region Public
        public string gerc_id = string.Empty;
        public string gerc_support_institution = string.Empty;
        public string edu_id = utilConstants.cDFEmptyListValue;
        public string fst_id = utilConstants.cDFEmptyListValue;
        public string ger_id = utilConstants.cDFEmptyListValue;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string hhm_id_caregiver = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benGirlEducationRegisterChild()
        {
            Default();
        }

        public benGirlEducationRegisterChild(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM ben_girl_education_register_child WHERE gerc_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set HomeVisit
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetChild(strId, dbCon);
                Load(dt);
            }
            #endregion Set HomeVisit
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetChild(gerc_id, dbCon);
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
            gerc_id = string.Empty;
            gerc_support_institution = string.Empty;
            edu_id = utilConstants.cDFEmptyListValue;
            fst_id = utilConstants.cDFEmptyListValue;
            ger_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            hhm_id_caregiver = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_girl_education_register_child " +
                "(gerc_id, gerc_support_institution, " +
                "edu_id, fst_id, ger_id, hhm_id, hhm_id_caregiver, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{7}', GETDATE(), GETDATE(), '{8}','{9}') ";
            strSQL = string.Format(strSQL, gerc_id, utilFormatting.StringForSQL(gerc_support_institution),
                edu_id, fst_id, ger_id, hhm_id, hhm_id_caregiver,
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
                gerc_id = dr["gerc_id"].ToString();
                gerc_support_institution = dr["gerc_support_institution"].ToString();
                edu_id = dr["edu_id"].ToString();
                fst_id = dr["fst_id"].ToString();
                ger_id = dr["ger_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                hhm_id_caregiver = dr["hhm_id_caregiver"].ToString();
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
            strSQL = "UPDATE ben_girl_education_register_child " +
                "SET gerc_support_institution = '{1}', " +
                "edu_id = '{2}', fst_id = '{3}', ger_id = '{4}', hhm_id = '{5}', hhm_id_caregiver = '{6}', " +
                "usr_id_update = '{7}', usr_date_update = GETDATE(),district_id = '{8}' " +
                "WHERE gerc_id = '{0}' ";
            strSQL = string.Format(strSQL, gerc_id, utilFormatting.StringForSQL(gerc_support_institution),
                edu_id, fst_id, ger_id, hhm_id, hhm_id_caregiver,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetChild(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT gerc.*, hhm.hh_id " +
            "FROM ben_girl_education_register_child gerc " +
            "INNER JOIN hh_household_member hhm ON gerc.hhm_id = hhm.hhm_id " +
            "WHERE gerc.gerc_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}