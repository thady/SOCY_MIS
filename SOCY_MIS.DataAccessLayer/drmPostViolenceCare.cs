using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmPostViolenceCare
    {
        #region Variables
        #region Public
        public string dpvc_id = string.Empty;
        public string flt_id = utilConstants.cDFEmptyListValue;
        public string sct_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public DateTime usr_date_create = DateTime.Now;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmPostViolenceCare()
        {
            Default();
        }

        public drmPostViolenceCare(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            drmPostViolenceCareLine dalDPVCL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalDPVCL = new drmPostViolenceCareLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalDPVCL.Delete(dt.Rows[intCount]["dpvcl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM drm_post_violence_care WHERE dpvc_id = '{0}' ";
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
                dt = GetObject(strId, dbCon);
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
            dt = GetObject(dpvc_id, dbCon);
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
            dpvc_id = string.Empty;
            flt_id = utilConstants.cDFEmptyListValue;
            sct_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_post_violence_care " +
                "(dpvc_id, " +
                "flt_id, sct_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " +
                "'{3}', '{3}', GETDATE(), GETDATE(), '{4}','{5}') ";
            strSQL = string.Format(strSQL, dpvc_id,
                flt_id, sct_id, 
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
                dpvc_id = dr["dpvc_id"].ToString();
                flt_id = dr["flt_id"].ToString();
                sct_id = dr["sct_id"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                usr_date_create = Convert.ToDateTime(dr["usr_date_create"]);
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE drm_post_violence_care " +
                "SET flt_id = '{1}', sct_id = '{2}', " +
                "usr_id_update = '{3}', usr_date_update = GETDATE(),district_id = '{4}' " +
                "WHERE dpvc_id = '{0}' ";
            strSQL = string.Format(strSQL, dpvc_id,
                flt_id, sct_id,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetByCriteria(string[,] arrFilter, int intArrayLength, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strWHERE = "WHERE 1=1 ";
            #endregion Variables

            #region SQL
            #region WHERE
            for (int intCount = 0; intCount < intArrayLength; intCount++)
            {
                switch (arrFilter[intCount, 0])
                {
                    case "flt_id":
                        strWHERE = strWHERE + string.Format("AND dpvc.flt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND dpvc.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_date_create_from":
                        strWHERE = strWHERE + string.Format("AND dpvc.usr_date_create >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "usr_date_create_to":
                        strWHERE = strWHERE + string.Format("AND dpvc.usr_date_create <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT dpvc.dpvc_id, dpvc.ofc_id, " +
                "ISNULL(flt.flt_name, '') AS flt_name, " +
                "ISNULL(sct.sct_name, '') AS sct_name, ISNULL(dst.dst_name, '') AS dst_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), dpvc.usr_date_create, 106))) AS usr_date_create " +
                "FROM drm_post_violence_care dpvc " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON dpvc.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                "LEFT JOIN lst_facility flt ON dpvc.flt_id = flt.flt_id " +
                strWHERE +
                "ORDER BY dst_name, sct_name ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDateRange(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MIN(usr_date_create), GETDATE()) AS usr_date_create_from, " +
                "ISNULL(MAX(usr_date_create), GETDATE()) AS usr_date_create_to " +
                "FROM drm_post_violence_care ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dpvcl.dpvcl_id, dpvcl.ofc_id, dm.dm_id_no, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dm.dm_first_name + ' ' + dm.dm_last_name) AS dm_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), dpvcl.dpvcl_date, 106))) AS dpvcl_date " +
                "FROM drm_post_violence_care dpvc " +
                "INNER JOIN drm_post_violence_care_line dpvcl ON dpvc.dpvc_id = dpvcl.dpvc_id " +
                "INNER JOIN drm_member dm ON dpvcl.dm_id = dm.dm_id " +
                "LEFT JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dpvc.dpvc_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
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
            strSQL = "SELECT dpvc.* " +
            "FROM drm_post_violence_care dpvc " +
            "WHERE dpvc.dpvc_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}