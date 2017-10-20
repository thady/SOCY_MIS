using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtAlternativeCarePanel
    {
        #region Variables
        #region Public
        public string acp_id = string.Empty;
        public DateTime acp_date = DateTime.Now;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string prt_id = utilConstants.cDFEmptyListValue;
        public string rgn_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtAlternativeCarePanel()
        {
            Default();
        }

        public prtAlternativeCarePanel(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            prtAlternativeCarePanelDistrict dalACPD = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalACPD = new prtAlternativeCarePanelDistrict();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalACPD.Delete(dt.Rows[intCount]["acpd_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM prt_alternative_care_panel WHERE acp_id = '{0}' ";
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
            dt = GetObject(acp_id, dbCon);
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
            acp_id = string.Empty;
            acp_date = DateTime.Now;
            fy_id = utilConstants.cDFEmptyListValue;
            prt_id = utilConstants.cDFEmptyListValue;
            rgn_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_alternative_care_panel " +
                "(acp_id, acp_date, " +
                "fy_id, prt_id, rgn_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', " +
                "'{5}', '{5}', GETDATE(), GETDATE(), '{6}','{7}') ";
            strSQL = string.Format(strSQL, acp_id, acp_date.ToString("dd MMM yyyy HH:mm:ss"),
                fy_id, prt_id, rgn_id, 
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
                acp_id = dr["acp_id"].ToString();
                acp_date = Convert.ToDateTime(dr["acp_date"]);
                fy_id = dr["fy_id"].ToString();
                prt_id = dr["prt_id"].ToString();
                rgn_id = dr["rgn_id"].ToString();
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
            strSQL = "UPDATE prt_alternative_care_panel " +
                "SET acp_date = '{1}', " +
                "fy_id = '{2}', prt_id = '{3}', rgn_id = '{4}', " +
                "usr_id_update = '{5}', usr_date_update = GETDATE(),district_id = '{6}' " +
                "WHERE acp_id = '{0}' ";
            strSQL = string.Format(strSQL, acp_id, acp_date.ToString("dd MMM yyyy HH:mm:ss"),
                fy_id, prt_id, rgn_id,
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
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND acp.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND acp.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND acp.acp_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND acp.acp_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT acp.acp_id, acp.ofc_id, ISNULL(fy.fy_name, '') AS fy_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), acp.acp_date, 106))) AS the_date_display, " +
                "acp.acp_date AS the_date " +
                "FROM prt_alternative_care_panel acp " +
                "LEFT JOIN lst_financial_year fy ON acp.fy_id = fy.fy_id " +
                "LEFT JOIN lst_partner prt ON acp.prt_id = prt.prt_id " +
                strWHERE +
                "ORDER BY prt_name, the_date DESC ";
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
            strSQL = "SELECT ISNULL(MIN(acp_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(acp_date), GETDATE()) AS date_end " +
                "FROM prt_alternative_care_panel ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT acpd.acpd_id, acpd.ofc_id, dst.dst_name " +
                "FROM prt_alternative_care_panel_district acpd " +
                "INNER JOIN lst_district dst ON acpd.dst_id = dst.dst_id AND dst.lng_id = '{1}' " +
                "WHERE acpd.acp_id = '{0}' " +
                "ORDER BY dst.dst_name ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT acpd.acpd_id " +
                "FROM prt_alternative_care_panel_district acpd " +
                "WHERE acpd.acp_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT acp.* " +
            "FROM prt_alternative_care_panel acp " +
            "WHERE acp.acp_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}