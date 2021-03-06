﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmSteppingStonesMissedSession
    {
        #region Variables
        #region Public
        public string dssms_id = string.Empty;
        public string dssms_contact = string.Empty;
        public DateTime dssms_date = DateTime.Now;
        public DateTime dssms_date_followup = DateTime.Now;
        public string dssms_action_other = string.Empty;
        public string dssms_followup_other = string.Empty;
        public string dssms_followup_method_other = string.Empty;
        public string dm_id = string.Empty;
        public string dsa_id = utilConstants.cDFEmptyListValue;
        public string dsf_id = utilConstants.cDFEmptyListValue;
        public string dsfm_id = utilConstants.cDFEmptyListValue;
        public string yn_id_followup = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmSteppingStonesMissedSession()
        {
            Default();
        }

        public drmSteppingStonesMissedSession(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM drm_stepping_stones_missed_session WHERE dssms_id = '{0}' ";
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
            dt = GetObject(dssms_id, dbCon);
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
            dssms_id = string.Empty;
            dssms_contact = string.Empty;
            dssms_date = DateTime.Now;
            dssms_date_followup = DateTime.Now;
            dssms_action_other = string.Empty;
            dssms_followup_other = string.Empty;
            dssms_followup_method_other = string.Empty;
            dm_id = string.Empty;
            dsa_id = utilConstants.cDFEmptyListValue;
            dsf_id = utilConstants.cDFEmptyListValue;
            dsfm_id = utilConstants.cDFEmptyListValue;
            yn_id_followup = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_stepping_stones_missed_session " +
                "(dssms_id, dssms_contact, " +
                "dssms_date, dssms_date_followup, " +
                "dssms_action_other, dssms_followup_other, dssms_followup_method_other, " +
                "dm_id, dsa_id, dsf_id, dsfm_id, yn_id_followup, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', " +
                "'{4}', '{5}', '{6}', " + 
                "'{7}', '{8}', '{9}', '{10}', '{11}', " +
                "'{12}', '{12}', GETDATE(), GETDATE(), '{13}','{14}') ";
            strSQL = string.Format(strSQL, dssms_id, utilFormatting.StringForSQL(dssms_contact),
                dssms_date.ToString("dd MMM yyyy HH:mm:ss"), dssms_date_followup.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dssms_action_other), utilFormatting.StringForSQL(dssms_followup_other), utilFormatting.StringForSQL(dssms_followup_method_other),
                dm_id, dsa_id, dsf_id, dsfm_id, yn_id_followup, 
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
                dssms_id = dr["dssms_id"].ToString();
                dssms_contact = dr["dssms_contact"].ToString();
                dssms_date = Convert.ToDateTime(dr["dssms_date"]);
                dssms_date_followup = Convert.ToDateTime(dr["dssms_date_followup"]);
                dssms_action_other = dr["dssms_action_other"].ToString();
                dssms_followup_other = dr["dssms_followup_other"].ToString();
                dssms_followup_method_other = dr["dssms_followup_method_other"].ToString();
                dm_id = dr["dm_id"].ToString();
                dsa_id = dr["dsa_id"].ToString();
                dsf_id = dr["dsf_id"].ToString();
                dsfm_id = dr["dsfm_id"].ToString();
                yn_id_followup = dr["yn_id_followup"].ToString();
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
            strSQL = "UPDATE drm_stepping_stones_missed_session " +
                "SET dssms_contact = '{1}', " +
                "dssms_date = '{2}', dssms_date_followup = '{3}', " +
                "dssms_action_other = '{4}', dssms_followup_other = '{5}', dssms_followup_method_other = '{6}', " +
                "dm_id = '{7}', dsa_id = '{8}', dsf_id = '{9}', dsfm_id = '{10}', yn_id_followup = '{11}', " +
                "usr_id_update = '{12}', usr_date_update = GETDATE(),district_id = '{13}' " +
                "WHERE dssms_id = '{0}' ";
            strSQL = string.Format(strSQL, dssms_id, utilFormatting.StringForSQL(dssms_contact),
                dssms_date.ToString("dd MMM yyyy HH:mm:ss"), dssms_date_followup.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dssms_action_other), utilFormatting.StringForSQL(dssms_followup_other), utilFormatting.StringForSQL(dssms_followup_method_other),
                dm_id, dsa_id, dsf_id, dsfm_id, yn_id_followup, 
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetList(string strDmId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dssms.dssms_id, dssms.ofc_id, RTRIM(LTRIM(CONVERT(CHAR(15), dssms.dssms_date, 106))) AS dssms_date " +
                "FROM drm_stepping_stones_missed_session dssms " +
                "WHERE dssms.dm_id = '{0}' " +
                "ORDER BY dssms_date DESC ";
            strSQL = string.Format(strSQL, strDmId);
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
            strSQL = "SELECT * " +
            "FROM drm_stepping_stones_missed_session " +
            "WHERE dssms_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}