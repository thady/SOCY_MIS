using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtInstitutionalCareSummary
    {
        #region Variables
        #region Public
        public string ics_id = string.Empty;
        public DateTime ics_date = DateTime.Now;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = utilConstants.cDFEmptyListValue;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        public string prt_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtInstitutionalCareSummary()
        {
            Default();
        }

        public prtInstitutionalCareSummary(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            prtCBSDStaffAppraisalTrackingLine dalicsL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalicsL = new prtCBSDStaffAppraisalTrackingLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalicsL.Delete(dt.Rows[intCount]["icsl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM prt_institutional_care_summary WHERE ics_id = '{0}' ";
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
            dt = GetObject(ics_id, dbCon);
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
            ics_id = string.Empty;
            ics_date = DateTime.Now;
            dst_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            qy_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_institutional_care_summary " +
                "(ics_id, ics_date, " +
                "dst_id, fy_id, qy_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id,prt_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', " +
                "'{5}', '{5}', GETDATE(), GETDATE(), '{6}','{7}','{8}') ";
            strSQL = string.Format(strSQL, ics_id, ics_date.ToString("dd MMM yyyy HH:mm:ss"), 
                dst_id, fy_id, qy_id,
                usr_id_update, ofc_id, district_id, prt_id);

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
                ics_id = dr["ics_id"].ToString();
                ics_date = Convert.ToDateTime(dr["ics_date"]);
                dst_id = dr["dst_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                qy_id = dr["qy_id"].ToString();
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
            strSQL = "UPDATE prt_institutional_care_summary " +
                "SET ics_date = '{1}', " +
                "dst_id = '{2}', fy_id = '{3}', qy_id = '{4}', " +
                "usr_id_update = '{5}', usr_date_update = GETDATE(),district_id = '{6}',prt_id = '{7}' " +
                "WHERE ics_id = '{0}' ";
            strSQL = string.Format(strSQL, ics_id, ics_date.ToString("dd MMM yyyy HH:mm:ss"), 
                dst_id, fy_id, qy_id,
                usr_id_update,district_id, prt_id);

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
                        strWHERE = strWHERE + string.Format("AND ics.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND ics.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND ics.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND ics.ics_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND ics.ics_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT ics.ics_id, ics.ofc_id, ISNULL(dst.dst_name, '') AS dst_name, ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), ics.ics_date, 106))) AS the_date_display, " +
                "ics.ics_date AS the_date " +
                "FROM prt_institutional_care_summary ics " +
                "LEFT JOIN lst_financial_year fy ON ics.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON ics.qy_id = qy.qy_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON ics.dst_id = dst.dst_id " +
                strWHERE +
                "ORDER BY dst_name, the_date DESC ";
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
            strSQL = "SELECT ISNULL(MIN(ics_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(ics_date), GETDATE()) AS date_end " +
                "FROM prt_institutional_care_summary ";
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
            strSQL = "SELECT icsl.*, ins.ins_name " +
                "FROM prt_institutional_care_summary_line icsl " +
                "INNER JOIN lst_institution ins ON icsl.ins_id = ins.ins_id " +
                "WHERE icsl.ics_id = '{0}' ";
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
            strSQL = "SELECT ics.* " +
            "FROM prt_institutional_care_summary ics " +
            "WHERE ics.ics_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}