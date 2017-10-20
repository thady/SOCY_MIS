using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmSteppingStonesRegisterLine
    {
        #region Variables
        #region Public
        public string dssrl_id = string.Empty;
        public string dssrl_contact = string.Empty;
        public string dm_id = string.Empty;
        public string dssr_id = string.Empty;
        public string yn_id_m1 = utilConstants.cDFEmptyListValue;
        public string yn_id_m2 = utilConstants.cDFEmptyListValue;
        public string yn_id_m3 = utilConstants.cDFEmptyListValue;
        public string yn_id_sa = utilConstants.cDFEmptyListValue;
        public string yn_id_sb = utilConstants.cDFEmptyListValue;
        public string yn_id_sc = utilConstants.cDFEmptyListValue;
        public string yn_id_sd = utilConstants.cDFEmptyListValue;
        public string yn_id_se = utilConstants.cDFEmptyListValue;
        public string yn_id_sf = utilConstants.cDFEmptyListValue;
        public string yn_id_sg = utilConstants.cDFEmptyListValue;
        public string yn_id_sh = utilConstants.cDFEmptyListValue;
        public string yn_id_si = utilConstants.cDFEmptyListValue;
        public string yn_id_sj = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmSteppingStonesRegisterLine()
        {
            Default();
        }

        public drmSteppingStonesRegisterLine(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM drm_stepping_stones_register_line WHERE dssrl_id = '{0}' ";
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
            dt = GetObject(dssrl_id, dbCon);
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
            dssrl_id = string.Empty;
            dssrl_contact = string.Empty;
            dm_id = string.Empty;
            dssr_id = string.Empty;
            yn_id_m1 = utilConstants.cDFEmptyListValue;
            yn_id_m2 = utilConstants.cDFEmptyListValue;
            yn_id_m3 = utilConstants.cDFEmptyListValue;
            yn_id_sa = utilConstants.cDFEmptyListValue;
            yn_id_sb = utilConstants.cDFEmptyListValue;
            yn_id_sc = utilConstants.cDFEmptyListValue;
            yn_id_sd = utilConstants.cDFEmptyListValue;
            yn_id_se = utilConstants.cDFEmptyListValue;
            yn_id_sf = utilConstants.cDFEmptyListValue;
            yn_id_sg = utilConstants.cDFEmptyListValue;
            yn_id_sh = utilConstants.cDFEmptyListValue;
            yn_id_si = utilConstants.cDFEmptyListValue;
            yn_id_sj = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_stepping_stones_register_line " +
                "(dssrl_id, " +
                "dssrl_contact, dm_id, dssr_id, " +
                "yn_id_m1, yn_id_m2, yn_id_m3, " +
                "yn_id_sa, yn_id_sb, yn_id_sc, " +
                "yn_id_sd, yn_id_se, yn_id_sf, " +
                "yn_id_sg, yn_id_sh, yn_id_si, " +
                "yn_id_sj, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', " +
                "'{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', " +
                "'{10}', '{11}', '{12}', " +
                "'{13}', '{14}', '{15}', " +
                "'{16}', " +
                "'{17}', '{17}', GETDATE(), GETDATE(), '{18}','{19}') ";
            strSQL = string.Format(strSQL, dssrl_id,
                utilFormatting.StringForSQL(dssrl_contact), dm_id, dssr_id,
                yn_id_m1, yn_id_m2, yn_id_m3,
                yn_id_sa, yn_id_sb, yn_id_sc,
                yn_id_sd, yn_id_se, yn_id_sf,
                yn_id_sg, yn_id_sh, yn_id_si,
                yn_id_sj,
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
                dssrl_id = dr["dssrl_id"].ToString();
                dssrl_contact = dr["dssrl_contact"].ToString();
                dm_id = dr["dm_id"].ToString();
                dssr_id = dr["dssr_id"].ToString();
                yn_id_m1 = dr["yn_id_m1"].ToString();
                yn_id_m2 = dr["yn_id_m2"].ToString();
                yn_id_m3 = dr["yn_id_m3"].ToString();
                yn_id_sa = dr["yn_id_sa"].ToString();
                yn_id_sb = dr["yn_id_sb"].ToString();
                yn_id_sc = dr["yn_id_sc"].ToString();
                yn_id_sd = dr["yn_id_sd"].ToString();
                yn_id_se = dr["yn_id_se"].ToString();
                yn_id_sf = dr["yn_id_sf"].ToString();
                yn_id_sg = dr["yn_id_sg"].ToString();
                yn_id_sh = dr["yn_id_sh"].ToString();
                yn_id_si = dr["yn_id_si"].ToString();
                yn_id_sj = dr["yn_id_sj"].ToString();
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
            strSQL = "UPDATE drm_stepping_stones_register_line " +
                "SET dssrl_contact = '{1}', dm_id = '{2}', dssr_id = '{3}', " +
                "yn_id_m1 = '{4}', yn_id_m2 = '{5}', yn_id_m3 = '{6}', " +
                "yn_id_sa = '{7}', yn_id_sb = '{8}', yn_id_sc = '{9}', " +
                "yn_id_sd = '{10}', yn_id_se = '{11}', yn_id_sf = '{12}', " +
                "yn_id_sg = '{13}', yn_id_sh = '{14}', yn_id_si = '{15}', " +
                "yn_id_sj = '{16}', " +
                "usr_id_update = '{17}', usr_date_update = GETDATE(),district_id = '{18}' " +
                "WHERE dssrl_id = '{0}' ";
            strSQL = string.Format(strSQL, dssrl_id,
                utilFormatting.StringForSQL(dssrl_contact), dm_id, dssr_id,
                yn_id_m1, yn_id_m2, yn_id_m3,
                yn_id_sa, yn_id_sb, yn_id_sc,
                yn_id_sd, yn_id_se, yn_id_sf,
                yn_id_sg, yn_id_sh, yn_id_si,
                yn_id_sj,
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
            strSQL = "SELECT dssrl.* " +
            "FROM drm_stepping_stones_register_line dssrl " +
            "WHERE dssrl.dssrl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}