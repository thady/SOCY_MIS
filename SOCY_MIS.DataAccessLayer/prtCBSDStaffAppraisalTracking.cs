using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtCBSDStaffAppraisalTracking
    {
        #region Variables
        #region Public
        public string csat_id = string.Empty;
        public string csat_comment = string.Empty;
        public DateTime csat_date = DateTime.Now;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string prt_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtCBSDStaffAppraisalTracking()
        {
            Default();
        }

        public prtCBSDStaffAppraisalTracking(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            prtCBSDStaffAppraisalTrackingLine dalCSATL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalCSATL = new prtCBSDStaffAppraisalTrackingLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalCSATL.Delete(dt.Rows[intCount]["csatl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM prt_cbsd_staff_appraisal_tracking WHERE csat_id = '{0}' ";
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
            dt = GetObject(csat_id, dbCon);
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
            csat_id = string.Empty;
            csat_comment = string.Empty;
            csat_date = DateTime.Now;
            dst_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            prt_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_cbsd_staff_appraisal_tracking " +
                "(csat_id, csat_date, csat_comment, " +
                "dst_id, fy_id, prt_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
                "'{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, csat_id, csat_date.ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(csat_comment),
                dst_id, fy_id, prt_id,
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
                csat_id = dr["csat_id"].ToString();
                csat_comment = dr["csat_comment"].ToString();
                csat_date = Convert.ToDateTime(dr["csat_date"]);
                dst_id = dr["dst_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                prt_id = dr["prt_id"].ToString();
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
            strSQL = "UPDATE prt_cbsd_staff_appraisal_tracking " +
                "SET csat_date = '{1}', csat_comment = '{2}', " +
                "dst_id = '{3}', fy_id = '{4}', prt_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE csat_id = '{0}' ";
            strSQL = string.Format(strSQL, csat_id, csat_date.ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(csat_comment),
                dst_id, fy_id, prt_id,
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
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND csat.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND csat.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND csat.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND csat.csat_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND csat.csat_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT csat.csat_id, csat.ofc_id, ISNULL(dst.dst_name, '') AS dst_name, ISNULL(fy.fy_name, '') AS fy_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), csat.csat_date, 106))) AS the_date_display, " +
                "csat.csat_date AS the_date " +
                "FROM prt_cbsd_staff_appraisal_tracking csat " +
                "LEFT JOIN lst_financial_year fy ON csat.fy_id = fy.fy_id " +
                "LEFT JOIN lst_partner prt ON csat.prt_id = prt.prt_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON csat.dst_id = dst.dst_id " +
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
            strSQL = "SELECT ISNULL(MIN(csat_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(csat_date), GETDATE()) AS date_end " +
                "FROM prt_cbsd_staff_appraisal_tracking ";
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
            strSQL = "SELECT csatl.* " +
                "FROM prt_cbsd_staff_appraisal_tracking_line csatl " +
                "WHERE csatl.csat_id = '{0}' ";
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
            strSQL = "SELECT csat.* " +
            "FROM prt_cbsd_staff_appraisal_tracking csat " +
            "WHERE csat.csat_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}