using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmMember
    {
        #region Variables
        #region Public
        public string dm_id = string.Empty;
        public string dm_first_name = string.Empty;
        public string dm_last_name = string.Empty;
        public string dm_id_no = string.Empty;
        public string dm_village = string.Empty;
        public string dm_phone = string.Empty;
        public string dm_status_reason = string.Empty;
        public int dm_active = utilConstants.cDFActive;
        public DateTime dm_dob = DateTime.Now;
        public DateTime dm_registration = DateTime.Now;
        public string etp_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string mtp_id = utilConstants.cDFEmptyListValue;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmMember()
        {
            Default();
        }

        public drmMember(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public bool CheckIDNoInUse(string strID, string strIDNo, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT COUNT(dm_id) FROM drm_member WHERE LOWER(dm_id_no) = '{1}' " +
                "AND NOT dm_id IN (SELECT dm_id FROM drm_member WHERE LOWER(dm_id_no) = '{1}' AND dm_id = '{0}') ", strID, strIDNo);
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
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
            dt = GetObject(dm_id, dbCon);
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
            dm_id = string.Empty;
            dm_first_name = string.Empty;
            dm_last_name = string.Empty;
            dm_id_no = string.Empty;
            dm_village = string.Empty;
            dm_phone = string.Empty;
            dm_status_reason = string.Empty;
            dm_active = utilConstants.cDFActive;
            dm_dob = DateTime.Now;
            dm_registration = DateTime.Now;
            etp_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            mtp_id = utilConstants.cDFEmptyListValue;
            wrd_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_member " +
                "(dm_id, " +
		        "dm_first_name, dm_last_name, dm_id_no, " +
		        "dm_village, dm_phone, dm_status_reason, " +
		        "dm_active, " +
		        "dm_dob, dm_registration,  " +
		        "etp_id, hhm_id, mtp_id, wrd_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " + 
                "'{1}', '{2}', '{3}', " +
                "'{4}', '{5}', '{6}', " +
                "{7}, " +
                "'{8}', '{9}', " +
                "'{10}', '{11}', '{12}', '{13}', " +
                "'{14}', '{14}', GETDATE(), GETDATE(), '{15}','{16}') ";
            strSQL = string.Format(strSQL, dm_id,
                utilFormatting.StringForSQL(dm_first_name), utilFormatting.StringForSQL(dm_last_name), utilFormatting.StringForSQL(dm_id_no),
                utilFormatting.StringForSQL(dm_village), utilFormatting.StringForSQL(dm_phone), utilFormatting.StringForSQL(dm_status_reason),
                dm_active,
                dm_dob.ToString("dd MMM yyyy HH:mm:ss"), dm_registration.ToString("dd MMM yyyy HH:mm:ss"),
                etp_id, hhm_id, mtp_id, wrd_id, 
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
                dm_id = dr["dm_id"].ToString();
                dm_first_name = dr["dm_first_name"].ToString();
                dm_last_name = dr["dm_last_name"].ToString();
                dm_id_no = dr["dm_id_no"].ToString();
                dm_village = dr["dm_village"].ToString();
                dm_phone = dr["dm_phone"].ToString();
                dm_status_reason = dr["dm_status_reason"].ToString();
                dm_active = Convert.ToInt32(dr["dm_active"]);
                dm_dob = Convert.ToDateTime(dr["dm_dob"]);
                dm_registration = Convert.ToDateTime(dr["dm_registration"]);
                etp_id = dr["etp_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                mtp_id = dr["mtp_id"].ToString();
                wrd_id = dr["wrd_id"].ToString();
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
            strSQL = "UPDATE drm_member " +
                "SET dm_first_name = '{1}', dm_last_name = '{2}', dm_id_no = '{3}', " +
                "dm_village = '{4}', dm_phone = '{5}', dm_status_reason = '{6}', " +
                "dm_active = {7}, " +
                "dm_dob = '{8}', dm_registration = '{9}', " +
                "etp_id = '{10}', hhm_id = '{11}', mtp_id = '{12}', wrd_id = '{13}', " +
                "usr_id_update = '{14}', usr_date_update = GETDATE(),district_id = '{15}' " +
                "WHERE dm_id = '{0}' ";
            strSQL = string.Format(strSQL, dm_id,
                utilFormatting.StringForSQL(dm_first_name), utilFormatting.StringForSQL(dm_last_name), utilFormatting.StringForSQL(dm_id_no),
                utilFormatting.StringForSQL(dm_village), utilFormatting.StringForSQL(dm_phone), utilFormatting.StringForSQL(dm_status_reason),
                dm_active,
                dm_dob.ToString("dd MMM yyyy HH:mm:ss"), dm_registration.ToString("dd MMM yyyy HH:mm:ss"),
                etp_id, hhm_id, mtp_id, wrd_id,
                usr_id_update, ofc_id,district_id);

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
                    case "dm_id":
                        strWHERE = strWHERE + string.Format("AND dm.dm_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "wrd_id":
                        strWHERE = strWHERE + string.Format("AND wrd.wrd_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT dm.dm_id, dm.dm_id_no, dm.dm_first_name + ' ' + dm.dm_last_name AS member_name, dst.dst_name, sct.sct_name " +
                "FROM drm_member dm " +
                "INNER JOIN lst_ward wrd ON dm.wrd_id = wrd.wrd_id AND wrd.lng_id = '{0}' " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id AND sct.lng_id = '{0}' " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id AND dst.lng_id = '{0}' " +
                strWHERE +
                "UNION " +
                "SELECT dm.dm_id, dm.dm_id_no, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS member_name, dst.dst_name, sct.sct_name " +
                "FROM drm_member dm " +
                "INNER JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id AND wrd.lng_id = '{0}' " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id AND sct.lng_id = '{0}' " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id AND dst.lng_id = '{0}' " +
                strWHERE +
                "ORDER BY dm_id_no ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetHouseholds(string strDstId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT hh.hh_id, hh.hh_code FROM hh_household hh {0} " +
                "WHERE hh.hh_id IN ( " +
                "SELECT DISTINCT hhm.hh_id FROM hh_household_member hhm " +
                "WHERE hhm.gnd_id = '" + utilConstants.cGNDFemale + "' AND NOT hhm.hhm_id IN ( " +
                "SELECT dm.hhm_id FROM drm_member dm)) {1} ";
            if (strDstId.Length != 0 && !strDstId.Equals(utilConstants.cDFEmptyListValue))
                strSQL = string.Format(strSQL, "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id ", 
                    "AND sct.dst_id = '" + strDstId + "'");
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetHouseholdMembers(string strHhId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm.hhm_id, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name FROM hh_household_member hhm " +
                "WHERE hhm.hh_id = '{0}' AND hhm.gnd_id = '{1}' AND NOT hhm.hhm_id IN ( " +
                "SELECT dm.hhm_id FROM drm_member dm) ";
            strSQL = string.Format(strSQL, strHhId, utilConstants.cGNDFemale);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetList(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dm.dm_id, dm.dm_id_no + '-' + dm.dm_first_name + ' ' + dm.dm_last_name AS member_name " +
                "FROM drm_member dm " +
                "WHERE dm.mtp_id = '{0}' " +
                "UNION " +
                "SELECT dm.dm_id, dm.dm_id_no + '-' + hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS member_name " +
                "FROM drm_member dm " +
                "INNER JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dm.mtp_id = '{1}' " +
                "ORDER BY member_name ";
            strSQL = string.Format(strSQL, utilConstants.cMTExternal, utilConstants.cMTHousehold);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMember(string strDmId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dm.dm_id, dm.ofc_id, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dm.dm_first_name + ' ' + dm.dm_last_name) AS dm_name, " +
                "ISNULL(CASE WHEN LEN(ISNULL(hhm.hhm_year_of_birth, '')) = 4 THEN CAST(hhm.hhm_year_of_birth + '/01/01' AS DATETIME) ELSE null END, dm.dm_dob) AS dm_dob " +
                "FROM drm_member dm " +
                "LEFT JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dm.dm_id = '{0}' ";
            strSQL = string.Format(strSQL, strDmId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetMembersForForm(string strDstId, string strDmId, string strFormTable, string strFormPrefix, string strObjId, DBConnection dbCon)
        {
            return GetMembersForForm(strDstId, "", strDmId, strFormTable, strFormPrefix, strObjId, "dm_id", dbCon);
        }

        public DataTable GetMembersForForm(string strDstId, string strDmId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, DBConnection dbCon)
        {
            return GetMembersForForm(strDstId, "", strDmId, strFormTable, strFormPrefix, strObjId, strMemberField, dbCon);
        }

        public DataTable GetMembersForForm(string strDstId, string strSctId, string strDmId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLWhere = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dm.dm_id, dm.dm_id_no, dm.dm_first_name + ' ' + dm.dm_last_name AS member_name " +
                "FROM drm_member dm " +
                "INNER JOIN lst_ward wrd ON dm.wrd_id = wrd.wrd_id " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dm.mtp_id = '{0}' {2} " + 
                "UNION " +
                "SELECT DISTINCT dm.dm_id, dm.dm_id_no, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS member_name " +
                "FROM drm_member dm " +
                "INNER JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "WHERE dm.mtp_id = '{1}' {2} ";
            
                if (strSctId.Length != 0 && !strSctId.Equals(utilConstants.cDFEmptyListValue))
                    strSQLWhere = strSQLWhere + 
                        string.Format("AND sct.sct_id = '{0}' ", strSctId);

                if (strDstId.Length != 0 && !strDstId.Equals(utilConstants.cDFEmptyListValue))
                    strSQLWhere = strSQLWhere + 
                        string.Format("AND sct.dst_id = '{0}' ", strDstId);

                strSQLWhere = strSQLWhere +
                    string.Format("AND NOT dm.dm_id IN (SELECT {3} FROM {0} {1} WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId, strMemberField);

                strSQL = string.Format(strSQL, utilConstants.cMTExternal, utilConstants.cMTHousehold, strSQLWhere);

            if (strDmId.Length != 0)
                strSQL = strSQL + "UNION " + string.Format("SELECT DISTINCT dm.dm_id, dm.dm_id_no, dm.dm_first_name + ' ' + dm.dm_last_name AS member_name " +
                "FROM drm_member dm " +
                "WHERE dm.dm_id = '{0}' AND dm.mtp_id = '{1}' " +
                "UNION " +
                "SELECT DISTINCT dm.dm_id, dm.dm_id_no, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS member_name " +
                "FROM drm_member dm " +
                "INNER JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dm.dm_id = '{0}' AND dm.mtp_id = '{2}' ", strDmId, utilConstants.cMTExternal, utilConstants.cMTHousehold);
            strSQL = strSQL + "ORDER BY member_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetRecords(string strId, string strDrtId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataRow dr = null;
            DataTable dt = null;

            bool blnSQL = false;
            string strSQL = string.Empty;
            string strSQLTemp = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT drt.drt_id, drt.drt_name, drt.drt_order " +
                "FROM lst_dreams_record_type drt " +
                "WHERE drt.lng_id = '{0}' ";
            if (strDrtId.Length != 0)
                strSQL = strSQL + "AND drt.drt_id = '" + strDrtId + "' ";
            strSQL = strSQL + "ORDER BY drt.drt_order ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);

            strSQL = "";
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                dr = dt.Rows[intCount];
                strSQLTemp = "";

                switch (dr["drt_id"].ToString())
                {
                    case utilConstants.cDRTHTCRegister:
                        strSQLTemp = "SELECT '" + dr["drt_id"].ToString() + "' AS drt_id, " +
                            "'" + dr["drt_name"].ToString() + "' AS drt_name, " +
                            dr["drt_order"].ToString() + " AS drt_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), dhr.usr_date_create, 106))) AS the_date_display, " +
                            "dhr.usr_date_create AS the_date, dhr.dhr_id AS rcd_id " +
                            "FROM drm_htc_register dhr " +
                            "WHERE dhr.dm_id = '{0}' ";
                        blnSQL = true;
                        break;
                    case utilConstants.cDRTPartnerTracking:
                        strSQLTemp = "SELECT '" + dr["drt_id"].ToString() + "' AS drt_id, " +
                            "'" + dr["drt_name"].ToString() + "' AS drt_name, " +
                            dr["drt_order"].ToString() + " AS drt_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), dpt.dpt_date, 106))) AS the_date_display, " +
                            "dpt.dpt_date AS the_date, dpt.dpt_id AS rcd_id " +
                            "FROM drm_partner_tracking dpt " +
                            "INNER JOIN drm_partner dp ON dpt.dp_id = dp.dp_id " +
                            "WHERE dp.dm_id = '{0}' ";
                        blnSQL = true;
                        break;
                    case utilConstants.cDRTSINOVUYOMissedSessions:
                        strSQLTemp = "SELECT '" + dr["drt_id"].ToString() + "' AS drt_id, " +
                            "'" + dr["drt_name"].ToString() + "' AS drt_name, " +
                            dr["drt_order"].ToString() + " AS drt_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), dsms.dsms_date, 106))) AS the_date_display, " +
                            "dsms.dsms_date AS the_date, dsms.dsms_id AS rcd_id " +
                            "FROM drm_sinovuyo_missed_session dsms " +
                            "WHERE dsms.dm_id = '{0}' ";
                        blnSQL = true;
                        break;
                    case utilConstants.cDRTSteppingStonesMissedSessions:
                        strSQLTemp = "SELECT '" + dr["drt_id"].ToString() + "' AS drt_id, " +
                            "'" + dr["drt_name"].ToString() + "' AS drt_name, " +
                            dr["drt_order"].ToString() + " AS drt_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), dssms.dssms_date, 106))) AS the_date_display, " +
                            "dssms.dssms_date AS the_date, dssms.dssms_id AS rcd_id " +
                            "FROM drm_stepping_stones_missed_session dssms " +
                            "WHERE dssms.dm_id = '{0}' ";
                        blnSQL = true;
                        break;
                }

                if (strSQLTemp.Length != 0)
                {
                    if (strSQL.Length == 0)
                        strSQL = strSQLTemp;
                    else
                        strSQL = strSQL + "UNION ALL " + strSQLTemp;
                }
            }

            strSQL = strSQL + "ORDER BY drt_order, the_date DESC ";
            strSQL = string.Format(strSQL, strId);
            if (blnSQL)
                dt = dbCon.ExecuteQueryDataTable(strSQL);
            else
                dt = new DataTable();
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
            strSQL = "SELECT dm.* " +
            "FROM drm_member dm " +
            "WHERE dm.dm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
