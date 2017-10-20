using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmPostViolenceCareLine
    {
        #region Variables
        #region Public
        public string dpvcl_id = string.Empty;
        public string dpvcl_referred_from = string.Empty;
        public DateTime dpvcl_date = DateTime.Now;
        public string dm_id = utilConstants.cDFEmptyListValue;
        public string dpvc_id = utilConstants.cDFEmptyListValue;
        public string gbv_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public string[] dreams_service_other = "".Split(utilConstants.cDFSplitChar);
        public string[] pvc_service = "".Split(utilConstants.cDFSplitChar);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmPostViolenceCareLine()
        {
            Default();
        }

        public drmPostViolenceCareLine(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM drm_post_violence_care_line_dreams_service WHERE dpvcl_id = '{0}' " +
                "DELETE FROM drm_post_violence_care_line_service WHERE dpvcl_id = '{0}' " +
                "DELETE FROM drm_post_violence_care_line WHERE dpvcl_id = '{0}' ";
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
                DreamsServicesLoad(strId, dbCon);
                ServicesProvidedLoad(strId, dbCon);
            }
            #endregion Set Data
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(dpvcl_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            DreamsServicesUpdate(dbCon);
            ServicesProvidedUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            dpvcl_id = string.Empty;
            dpvcl_referred_from = string.Empty;
            dpvcl_date = DateTime.Now;
            dm_id = utilConstants.cDFEmptyListValue;
            dpvc_id = utilConstants.cDFEmptyListValue;
            gbv_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;

            dreams_service_other = "".Split(utilConstants.cDFSplitChar);
            pvc_service = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO drm_post_violence_care_line " +
                "(dpvcl_id, " +
                "dpvcl_referred_from, dpvcl_date, " +
                "dm_id, dpvc_id, gbv_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " + 
                "'{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, dpvcl_id,
                utilFormatting.StringForSQL(dpvcl_referred_from), dpvcl_date.ToString("dd MMM yyyy HH:mm:ss"),
                dm_id, dpvc_id, gbv_id, 
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
                dpvcl_id = dr["dpvcl_id"].ToString();
                dpvcl_referred_from = dr["dpvcl_referred_from"].ToString();
                dpvcl_date = Convert.ToDateTime(dr["dpvcl_date"]);
                dm_id = dr["dm_id"].ToString();
                dpvc_id = dr["dpvc_id"].ToString();
                gbv_id = dr["gbv_id"].ToString();
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
            strSQL = "UPDATE drm_post_violence_care_line " +
                "SET dpvcl_referred_from = '{1}', dpvcl_date = '{2}', " +
                "dm_id = '{3}', dpvc_id = '{4}', gbv_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE dpvcl_id = '{0}' ";
            strSQL = string.Format(strSQL, dpvcl_id,
                utilFormatting.StringForSQL(dpvcl_referred_from), dpvcl_date.ToString("dd MMM yyyy HH:mm:ss"),
                dm_id, dpvc_id, gbv_id, 
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
            strSQL = "SELECT dpvcl.* " +
            "FROM drm_post_violence_care_line dpvcl " +
            "WHERE dpvcl.dpvcl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region DREAMS Services
        private DataTable DreamsServicesGet(string strDpvclId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM drm_post_violence_care_line_dreams_service " +
            "WHERE dpvcl_id = '{0}' ";
            strSQL = string.Format(strSQL, strDpvclId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void DreamsServicesLoad(string strDpvclId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = DreamsServicesGet(strDpvclId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["dso_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["dso_id"].ToString();
            }

            dreams_service_other = strTemp.Split(utilConstants.cDFSplitChar);
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
            if (dreams_service_other.Length != 0)
            {
                strInsert = "INSERT INTO drm_post_violence_care_line_dreams_service (dpvclds_id, dpvcl_id, dso_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT dso_id FROM drm_post_violence_care_line_dreams_service WHERE dpvcl_id = '{0}') ";
                for (int intCount = 0; intCount < dreams_service_other.Length; intCount++)
                {
                    if (dreams_service_other[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", dreams_service_other[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", dreams_service_other[intCount]);
                        strSQL = strSQL + string.Format(strInsert, dpvcl_id, dreams_service_other[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM drm_post_violence_care_line_dreams_service WHERE dpvcl_id = '{0}' AND NOT dso_id IN ({1}) ";
            strSQL = string.Format(strSQL, dpvcl_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion DREAMS Services

        #region Services Provided
        private DataTable ServicesProvidedGet(string strDpvclId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM drm_post_violence_care_line_service " +
            "WHERE dpvcl_id = '{0}' ";
            strSQL = string.Format(strSQL, strDpvclId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void ServicesProvidedLoad(string strDpvclId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = ServicesProvidedGet(strDpvclId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["pvcs_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["pvcs_id"].ToString();
            }

            pvc_service = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void ServicesProvidedUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (pvc_service.Length != 0)
            {
                strInsert = "INSERT INTO drm_post_violence_care_line_service (dpvcls_id, dpvcl_id, pvcs_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT pvcs_id FROM drm_post_violence_care_line_service WHERE dpvcl_id = '{0}') ";
                for (int intCount = 0; intCount < pvc_service.Length; intCount++)
                {
                    if (pvc_service[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", pvc_service[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", pvc_service[intCount]);
                        strSQL = strSQL + string.Format(strInsert, dpvcl_id, pvc_service[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM drm_post_violence_care_line_service WHERE dpvcl_id = '{0}' AND NOT pvcs_id IN ({1}) ";
            strSQL = string.Format(strSQL, dpvcl_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services Provided
    }
}
