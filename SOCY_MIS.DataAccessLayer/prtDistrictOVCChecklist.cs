using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtDistrictOVCChecklist
    {
        #region Variables
        #region Public
        public string doc_id = string.Empty;
        public DateTime doc_date = DateTime.Now;
        public int doc_cso_report = 0;
        public int doc_cso_total = 0;
        public int doc_sub_county_reviewed = 0;
        public int doc_sub_county_total = 0;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string yn_id_dovcc_actions_taken = utilConstants.cDFEmptyListValue;
        public string yn_id_dovcc_minutes = utilConstants.cDFEmptyListValue;
        public string yn_id_dovcc_minutes_available = utilConstants.cDFEmptyListValue;
        public string yn_id_meetings_held = utilConstants.cDFEmptyListValue;
        public string yn_id_membership_constituted = utilConstants.cDFEmptyListValue;
        public string yn_id_ovcmis_district = utilConstants.cDFEmptyListValue;
        public string yn_id_supervision_reports = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtDistrictOVCChecklist()
        {
            Default();
        }

        public prtDistrictOVCChecklist(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM prt_district_ovc_checklist WHERE doc_id = '{0}' ";
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
            dt = GetObject(doc_id, dbCon);
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
            doc_id = string.Empty;
            doc_date = DateTime.Now;
            doc_cso_report = 0;
            doc_cso_total = 0;
            doc_sub_county_reviewed = 0;
            doc_sub_county_total = 0;
            dst_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            qy_id = utilConstants.cDFEmptyListValue;
            yn_id_dovcc_actions_taken = utilConstants.cDFEmptyListValue;
            yn_id_dovcc_minutes = utilConstants.cDFEmptyListValue;
            yn_id_dovcc_minutes_available = utilConstants.cDFEmptyListValue;
            yn_id_meetings_held = utilConstants.cDFEmptyListValue;
            yn_id_membership_constituted = utilConstants.cDFEmptyListValue;
            yn_id_ovcmis_district = utilConstants.cDFEmptyListValue;
            yn_id_supervision_reports = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_district_ovc_checklist " +
                "(doc_id, doc_date, " +
                "doc_cso_report, doc_cso_total, doc_sub_county_reviewed, doc_sub_county_total, " +
                "dst_id, fy_id, qy_id, " +
                "yn_id_dovcc_actions_taken, yn_id_dovcc_minutes, yn_id_dovcc_minutes_available, " +
                "yn_id_meetings_held, yn_id_membership_constituted, yn_id_ovcmis_district, " +
                "yn_id_supervision_reports, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "{2}, {3}, {4}, {5}, " +
                "'{6}', '{7}', '{8}', " +
                "'{9}', '{10}', '{11}', " +
                "'{12}', '{13}', '{14}', " +
                "'{15}', " +
                "'{16}', '{16}', GETDATE(), GETDATE(), '{17}','{18}') ";
            strSQL = string.Format(strSQL, doc_id, doc_date.ToString("dd MMM yyyy HH:mm:ss"),
                doc_cso_report.ToString(), doc_cso_total.ToString(), doc_sub_county_reviewed.ToString(), doc_sub_county_total.ToString(),
                dst_id, fy_id, qy_id,
                yn_id_dovcc_actions_taken, yn_id_dovcc_minutes, yn_id_dovcc_minutes_available,
                yn_id_meetings_held, yn_id_membership_constituted, yn_id_ovcmis_district,
                yn_id_supervision_reports,
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
                doc_id = dr["doc_id"].ToString();
                doc_date = Convert.ToDateTime(dr["doc_date"]);
                doc_cso_report = Convert.ToInt32(dr["doc_cso_report"]);
                doc_cso_total = Convert.ToInt32(dr["doc_cso_total"]);
                doc_sub_county_reviewed = Convert.ToInt32(dr["doc_sub_county_reviewed"]);
                doc_sub_county_total = Convert.ToInt32(dr["doc_sub_county_total"]);
                dst_id = dr["dst_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                qy_id = dr["qy_id"].ToString();
                yn_id_dovcc_actions_taken = dr["yn_id_dovcc_actions_taken"].ToString();
                yn_id_dovcc_minutes = dr["yn_id_dovcc_minutes"].ToString();
                yn_id_dovcc_minutes_available = dr["yn_id_dovcc_minutes_available"].ToString();
                yn_id_meetings_held = dr["yn_id_meetings_held"].ToString();
                yn_id_membership_constituted = dr["yn_id_membership_constituted"].ToString();
                yn_id_ovcmis_district = dr["yn_id_ovcmis_district"].ToString();
                yn_id_supervision_reports = dr["yn_id_supervision_reports"].ToString();
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
            strSQL = "UPDATE prt_district_ovc_checklist " +
                "SET doc_date = '{1}', " +
                "doc_cso_report = {2}, doc_cso_total = {3}, doc_sub_county_reviewed = {4}, doc_sub_county_total = {5}, " +
                "dst_id = '{6}', fy_id = '{7}', qy_id = '{8}', " +
                "yn_id_dovcc_actions_taken = '{9}', yn_id_dovcc_minutes = '{10}', yn_id_dovcc_minutes_available = '{11}', " +
                "yn_id_meetings_held = '{12}', yn_id_membership_constituted = '{13}', yn_id_ovcmis_district = '{14}', " +
                "yn_id_supervision_reports = '{15}', " +
                "usr_id_update = '{16}', usr_date_update = GETDATE(),district_id = '{17}' " +
                "WHERE doc_id = '{0}' ";
            strSQL = string.Format(strSQL, doc_id, doc_date.ToString("dd MMM yyyy HH:mm:ss"),
                doc_cso_report.ToString(), doc_cso_total.ToString(), doc_sub_county_reviewed.ToString(), doc_sub_county_total.ToString(),
                dst_id, fy_id, qy_id,
                yn_id_dovcc_actions_taken, yn_id_dovcc_minutes, yn_id_dovcc_minutes_available,
                yn_id_meetings_held, yn_id_membership_constituted, yn_id_ovcmis_district,
                yn_id_supervision_reports,
                usr_id_update, district_id);

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
                        strWHERE = strWHERE + string.Format("AND doc.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND doc.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND doc.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND doc.doc_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND doc.doc_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT doc.doc_id, doc.ofc_id, ISNULL(dst.dst_name, '') AS dst_name, ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), doc.doc_date, 106))) AS the_date_display, " +
                "doc.doc_date AS the_date " +
                "FROM prt_district_ovc_checklist doc " +
                "LEFT JOIN lst_financial_year fy ON doc.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON doc.qy_id = qy.qy_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON doc.dst_id = dst.dst_id " +
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
            strSQL = "SELECT ISNULL(MIN(doc_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(doc_date), GETDATE()) AS date_end " +
                "FROM prt_district_ovc_checklist ";
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
            strSQL = "SELECT doc.* " +
            "FROM prt_district_ovc_checklist doc " +
            "WHERE doc.doc_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}