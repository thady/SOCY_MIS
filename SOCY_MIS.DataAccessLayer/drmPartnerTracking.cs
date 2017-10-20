using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmPartnerTracking
    {
        #region Variables
        #region Public
        public string dpt_id = string.Empty;
        public DateTime dpt_date = DateTime.Now;
        public string dpt_dptp_other = string.Empty;
        public string dpt_phone = string.Empty;
        public string dpt_address = string.Empty;
        public string dpt_service = string.Empty;
        public string dp_id = string.Empty;
        public string dptp_id = utilConstants.cDFEmptyListValue;
        public string hst_id = utilConstants.cDFEmptyListValue;
        public string yn_id_traced = utilConstants.cDFEmptyListValue;
        public string ynd_id_vmmc = utilConstants.cDFEmptyListValue;        
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public string dm_id = string.Empty;
        public string[] dreams_service = "".Split(utilConstants.cDFSplitChar);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmPartnerTracking()
        {
            Default();
        }

        public drmPartnerTracking(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, string strDpId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM drm_partner_tracking_service WHERE dpt_id = '{0}' " +
                "DELETE FROM drm_partner_tracking WHERE dpt_id = '{0}' " +
                "DELETE FROM drm_partner WHERE NOT dp_id IN (SELECT dp_id FROM drm_partner_tracking WHERE dp_id = '{1}') ";
            strSQL = string.Format(strSQL, strId, strDpId);

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
                DreamsServicesLoad(strId, dbCon);
            }
            #endregion Set Object
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(dpt_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            DreamsServicesUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            dpt_id = string.Empty;
            dpt_date = DateTime.Now;
            dpt_dptp_other = string.Empty;
            dpt_phone = string.Empty;
            dpt_address = string.Empty;
            dpt_service = string.Empty;
            dp_id = string.Empty;
            dptp_id = utilConstants.cDFEmptyListValue;
            hst_id = utilConstants.cDFEmptyListValue;
            yn_id_traced = utilConstants.cDFEmptyListValue;
            ynd_id_vmmc = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;

            dm_id = string.Empty;
            dreams_service = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO drm_partner_tracking " +
                "(dpt_id, dpt_date, " +
                "dpt_dptp_other, dpt_phone, " +
                "dpt_address, dpt_service, " +
                "dp_id, dptp_id, hst_id, " +
                "yn_id_traced, ynd_id_vmmc, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " + 
                "'{1}', " +
                "'{2}', '{3}', " +
                "'{4}', '{5}', " +
                "'{6}', '{7}', '{8}', " +
                "'{9}', '{10}', " +
                "'{11}', '{11}', GETDATE(), GETDATE(), '{12}','{13}') ";
            strSQL = string.Format(strSQL, dpt_id,
                dpt_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dpt_dptp_other), utilFormatting.StringForSQL(dpt_phone),
                utilFormatting.StringForSQL(dpt_address), utilFormatting.StringForSQL(dpt_service),
                dp_id, dptp_id, hst_id,
                yn_id_traced, ynd_id_vmmc,
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
                dpt_id = dr["dpt_id"].ToString();
                dpt_date = Convert.ToDateTime(dr["dpt_date"]);
                dpt_dptp_other = dr["dpt_dptp_other"].ToString();
                dpt_phone = dr["dpt_phone"].ToString();
                dpt_address = dr["dpt_address"].ToString();
                dpt_service = dr["dpt_service"].ToString();
                dp_id = dr["dp_id"].ToString();
                dptp_id = dr["dptp_id"].ToString();
                hst_id = dr["hst_id"].ToString();
                yn_id_traced = dr["yn_id_traced"].ToString();
                ynd_id_vmmc = dr["ynd_id_vmmc"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                dm_id = dr["dm_id"].ToString();
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE drm_partner_tracking " +
                "SET dpt_date = '{1}', " +
                "dpt_dptp_other = '{2}', dpt_phone = '{3}', " +
                "dpt_address = '{4}', dpt_service = '{5}', " +
                "dp_id = '{6}', dptp_id = '{7}', hst_id = '{8}', " +
                "yn_id_traced = '{9}', ynd_id_vmmc = '{10}', " +
                "usr_id_update = '{11}', usr_date_update = GETDATE(),district_id = '{12}' " +
                "WHERE dpt_id = '{0}' ";
            strSQL = string.Format(strSQL, dpt_id,
                dpt_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dpt_dptp_other), utilFormatting.StringForSQL(dpt_phone),
                utilFormatting.StringForSQL(dpt_address), utilFormatting.StringForSQL(dpt_service),
                dp_id, dptp_id, hst_id,
                yn_id_traced, ynd_id_vmmc,
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
            strSQL = "SELECT dpt.dpt_id, dpt.dp_id, dpt.ofc_id, dp.dp_first_name + ' ' + dp.dp_last_name AS dp_name, RTRIM(LTRIM(CONVERT(CHAR(15), dpt.dpt_date, 106))) AS dpt_date " +
                "FROM drm_partner dp " +
                "INNER JOIN drm_partner_tracking dpt ON dp.dp_id = dpt.dp_id " +
                "WHERE dp.dm_id = '{0}' " +
                "ORDER BY dpt_date DESC ";
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
            strSQL = "SELECT dpt.*, dp.dm_id " +
            "FROM drm_partner_tracking dpt " +
            "INNER JOIN drm_partner dp ON dpt.dp_id = dp.dp_id " +
            "WHERE dpt.dpt_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region Dreams Services
        private DataTable DreamsServicesGet(string strDptId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM drm_partner_tracking_service " +
            "WHERE dpt_id = '{0}' ";
            strSQL = string.Format(strSQL, strDptId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void DreamsServicesLoad(string strDptId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = DreamsServicesGet(strDptId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["dsrv_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["dsrv_id"].ToString();
            }

            dreams_service = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void DreamsServicesUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (dreams_service.Length != 0)
            {
                strInsert = "INSERT INTO drm_partner_tracking_service (dpts_id, dpt_id, dsrv_id, usr_id_create, usr_date_create, ofc_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT dsrv_id FROM drm_partner_tracking_service WHERE dpt_id = '{0}') ";
                for (int intCount = 0; intCount < dreams_service.Length; intCount++)
                {
                    if (dreams_service[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", dreams_service[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", dreams_service[intCount]);
                        strSQL = strSQL + string.Format(strInsert, dpt_id, dreams_service[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM drm_partner_tracking_service WHERE dpt_id = '{0}' AND NOT dsrv_id IN ({1}) ";
            strSQL = string.Format(strSQL, dpt_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Dreams Services
    }
}