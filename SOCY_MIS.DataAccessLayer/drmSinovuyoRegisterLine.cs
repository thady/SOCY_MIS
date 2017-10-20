using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmSinovuyoRegisterLine
    {
        #region Variables
        #region Public
        public string dsrl_id = string.Empty;
        public string dsrl_contact = string.Empty;
        public string dm_id = string.Empty;
        public string dsr_id = string.Empty;
        public string pca_id_01 = utilConstants.cDFEmptyListValue;
        public string pca_id_02 = utilConstants.cDFEmptyListValue;
        public string pca_id_03 = utilConstants.cDFEmptyListValue;
        public string pca_id_04 = utilConstants.cDFEmptyListValue;
        public string pca_id_05 = utilConstants.cDFEmptyListValue;
        public string pca_id_06 = utilConstants.cDFEmptyListValue;
        public string pca_id_07 = utilConstants.cDFEmptyListValue;
        public string pca_id_08 = utilConstants.cDFEmptyListValue;
        public string pca_id_09 = utilConstants.cDFEmptyListValue;
        public string pca_id_10 = utilConstants.cDFEmptyListValue;
        public string pca_id_11 = utilConstants.cDFEmptyListValue;
        public string pca_id_12 = utilConstants.cDFEmptyListValue;
        public string pca_id_13 = utilConstants.cDFEmptyListValue;
        public string pca_id_14 = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public string ofc_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmSinovuyoRegisterLine()
        {
            Default();
        }

        public drmSinovuyoRegisterLine(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM drm_sinovuyo_register_line WHERE dsrl_id = '{0}' ";
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
            dt = GetObject(dsrl_id, dbCon);
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
            dsrl_id = string.Empty;
            dsrl_contact = string.Empty;
            dm_id = string.Empty;
            dsr_id = string.Empty;
            pca_id_01 = utilConstants.cDFEmptyListValue;
            pca_id_02 = utilConstants.cDFEmptyListValue;
            pca_id_03 = utilConstants.cDFEmptyListValue;
            pca_id_04 = utilConstants.cDFEmptyListValue;
            pca_id_05 = utilConstants.cDFEmptyListValue;
            pca_id_06 = utilConstants.cDFEmptyListValue;
            pca_id_07 = utilConstants.cDFEmptyListValue;
            pca_id_08 = utilConstants.cDFEmptyListValue;
            pca_id_09 = utilConstants.cDFEmptyListValue;
            pca_id_10 = utilConstants.cDFEmptyListValue;
            pca_id_11 = utilConstants.cDFEmptyListValue;
            pca_id_12 = utilConstants.cDFEmptyListValue;
            pca_id_13 = utilConstants.cDFEmptyListValue;
            pca_id_14 = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_sinovuyo_register_line " +
                "(dsrl_id, " +
                "dsrl_contact, dm_id, dsr_id, " +
                "pca_id_01, pca_id_02, pca_id_03, " +
                "pca_id_04, pca_id_05, pca_id_06, " +
                "pca_id_07, pca_id_08, pca_id_09, " +
                "pca_id_10, pca_id_11, pca_id_12, " +
                "pca_id_13, pca_id_14, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', " +
                "'{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', " +
                "'{10}', '{11}', '{12}', " +
                "'{13}', '{14}', '{15}', " +
                "'{16}', '{17}', " +
                "'{18}', '{18}', GETDATE(), GETDATE(), '{19}','{20}') ";
            strSQL = string.Format(strSQL, dsrl_id,
                utilFormatting.StringForSQL(dsrl_contact), dm_id, dsr_id,
                pca_id_01, pca_id_02, pca_id_03,
                pca_id_04, pca_id_05, pca_id_06,
                pca_id_07, pca_id_08, pca_id_09,
                pca_id_10, pca_id_11, pca_id_12,
                pca_id_13, pca_id_14,
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
                dsrl_id = dr["dsrl_id"].ToString();
                dsrl_contact = dr["dsrl_contact"].ToString();
                dm_id = dr["dm_id"].ToString();
                dsr_id = dr["dsr_id"].ToString();
                pca_id_01 = dr["pca_id_01"].ToString();
                pca_id_02 = dr["pca_id_02"].ToString();
                pca_id_03 = dr["pca_id_03"].ToString();
                pca_id_04 = dr["pca_id_04"].ToString();
                pca_id_05 = dr["pca_id_05"].ToString();
                pca_id_06 = dr["pca_id_06"].ToString();
                pca_id_07 = dr["pca_id_07"].ToString();
                pca_id_08 = dr["pca_id_08"].ToString();
                pca_id_09 = dr["pca_id_09"].ToString();
                pca_id_10 = dr["pca_id_10"].ToString();
                pca_id_11 = dr["pca_id_11"].ToString();
                pca_id_12 = dr["pca_id_12"].ToString();
                pca_id_13 = dr["pca_id_13"].ToString();
                pca_id_14 = dr["pca_id_14"].ToString();
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
            strSQL = "UPDATE drm_sinovuyo_register_line " +
                "SET dsrl_contact = '{1}', dm_id = '{2}', dsr_id = '{3}', " +
                "pca_id_01 = '{4}', pca_id_02 = '{5}', pca_id_03 = '{6}', " +
                "pca_id_04 = '{7}', pca_id_05 = '{8}', pca_id_06 = '{9}', " +
                "pca_id_07 = '{10}', pca_id_08 = '{11}', pca_id_09 = '{12}', " +
                "pca_id_10 = '{13}', pca_id_11 = '{14}', pca_id_12 = '{15}', " +
                "pca_id_13 = '{16}', pca_id_14 = '{17}', " +
                "usr_id_update = '{18}', usr_date_update = GETDATE(),district_id = '{19}' " +
                "WHERE dsrl_id = '{0}' ";
            strSQL = string.Format(strSQL, dsrl_id,
                utilFormatting.StringForSQL(dsrl_contact), dm_id, dsr_id,
                pca_id_01, pca_id_02, pca_id_03,
                pca_id_04, pca_id_05, pca_id_06,
                pca_id_07, pca_id_08, pca_id_09,
                pca_id_10, pca_id_11, pca_id_12,
                pca_id_13, pca_id_14,
                usr_id_update, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dsrl.* " +
            "FROM drm_sinovuyo_register_line dsrl " +
            "WHERE dsrl.dsrl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}