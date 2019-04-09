using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHousehold
    {
        #region Variables
        #region Public
        public string hh_id = string.Empty;
        public string hh_code = string.Empty;
        public string hh_status_reason = string.Empty;
        public string hh_tel = string.Empty;
        public string hh_village = string.Empty;
        public string hhs_id = utilConstants.cDFEmptyListValue;
        public string hhsr_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string sct_id = utilConstants.cDFEmptyListValue;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhHousehold()
        {
            Default();
        }

        public hhHousehold(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM  WHERE at_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public string NextHouseholdCode(string strPrtId, string strCsoId, string strSctId, DBConnection dbCon)
        {
            #region Variables
            string strResult = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            //#region SQL
            //strSQL = string.Format("SELECT ISNULL((SELECT prt_other FROM lst_partner WHERE prt_id = '{0}'), '-') + '/' + " +
            //    "ISNULL((SELECT cso_other FROM lst_cso WHERE cso_id = '{1}'), '-') + '/' + " +
            //    "ISNULL((SELECT ( sct_id +'-'+ SUBSTRING(ISNULL(sct_name, ''), 1, 3)) FROM lst_sub_county WHERE sct_id = '{2}'), '-') + '/' + " + //combine sub county code with first three characters of sub county name
            //    "RIGHT('0000' + CAST(ISNULL(MAX(CAST(RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) AS INT)), 0) + 1 AS VARCHAR(4)), 4) " +
            //    "FROM hh_household hh " +
            //    "INNER JOIN hh_ovc_identification_prioritization oip ON hh.hh_id = oip.hh_id " +
            //    "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
            //    "WHERE wrd.sct_id = '{2}' AND oip.cso_id = '{1}' AND " + 
            //    "RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) < '9999' AND RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) >= '0000' ", 
            //strPrtId, strCsoId, strSctId);
            //strResult = dbCon.ExecuteScalar(strSQL);
            //#endregion SQL

            #region SQL
            strSQL = string.Format("SELECT ISNULL((SELECT (SUBSTRING(ISNULL(dst_name, ''), 1, 3)) FROM lst_district WHERE dst_id = '{0}'), '-') + '/' + " +
                "ISNULL((SELECT ( RIGHT('000'+ CONVERT(VARCHAR, sct_id), 3) +'-'+ SUBSTRING(ISNULL(sct_name, ''), 1, 3)) FROM lst_sub_county WHERE sct_id = '{2}'), '-') + '/' + " + //combine sub county code with first three characters of sub county name
                "RIGHT('0000' + CAST(ISNULL(MAX(CAST(RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) AS INT)), 0) + 1 AS VARCHAR(4)), 4) " +
                "FROM hh_household hh " +
                "INNER JOIN hh_ovc_identification_prioritization oip ON hh.hh_id = oip.hh_id " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "WHERE wrd.sct_id = '{2}' AND oip.cso_id = '{1}' AND " +
                "RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) < '9999' AND RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) >= '0000' ",
            strPrtId, strCsoId, strSctId);
            strResult = dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return strResult;
        }

        public string NextHHouseholdCode(string strPrtId, string strCsoId, string strSctId, DBConnection dbCon)
        {
            #region Variables
            string strResult = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT ISNULL((SELECT (SUBSTRING(ISNULL(dst_name, ''), 1, 3)) FROM lst_district WHERE dst_id = '{0}'), '-') + '/' + " +
                "ISNULL((SELECT cso_other FROM lst_cso WHERE cso_id = '{1}'), '-') + '/' + " +
                "ISNULL((SELECT ( sct_id +'-'+ SUBSTRING(ISNULL(sct_name, ''), 1, 3)) FROM lst_sub_county WHERE sct_id = '{2}'), '-') + '/' + " + //combine sub county code with first three characters of sub county name
                "RIGHT('0000' + CAST(ISNULL(MAX(CAST(RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) AS INT)), 0) + 1 AS VARCHAR(4)), 4) " +
                "FROM hh_household hh " +
                "INNER JOIN hh_ovc_identification_prioritization oip ON hh.hh_id = oip.hh_id " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "WHERE wrd.sct_id = '{2}' AND oip.cso_id = '{1}' AND " +
                "RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) < '9999' AND RIGHT(REPLACE(hh.hh_code, ' ', ''), 4) >= '0000' ",
            strPrtId, strCsoId, strSctId);
            strResult = dbCon.ExecuteScalar(strSQL);
            #endregion SQL

            return strResult;
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Household
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetHousehold(strId, dbCon);
                Load(dt);
            }
            #endregion Set Household
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetHousehold(hh_id, dbCon);
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
            hh_id = string.Empty;
            hh_code = string.Empty;
            hh_status_reason = string.Empty;
            hh_tel = string.Empty;
            hh_village = string.Empty;
            hhs_id = utilConstants.cDFEmptyListValue;
            hhsr_id = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            dst_id = utilConstants.cDFEmptyListValue;
            sct_id = utilConstants.cDFEmptyListValue;
            wrd_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_household " +
                "(hh_id, hh_code, " + 
                "hh_status_reason, hh_tel, hh_village, " +
                "hhs_id, hhsr_id, swk_id, wrd_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', " +
                "'{5}', '{6}', '{7}', '{8}', " +
                "'{9}', '{9}', GETDATE(), GETDATE(), '{10}','{11}') ";
            strSQL = string.Format(strSQL, hh_id, utilFormatting.StringForSQL(hh_code),
                utilFormatting.StringForSQL(hh_status_reason), utilFormatting.StringForSQL(hh_tel), utilFormatting.StringForSQL(hh_village),
                hhs_id, hhsr_id, swk_id, wrd_id,
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
                hh_id = dr["hh_id"].ToString();
                hh_code = dr["hh_code"].ToString();
                hh_status_reason = dr["hh_status_reason"].ToString();
                hh_tel = dr["hh_tel"].ToString();
                hh_village = dr["hh_village"].ToString();
                hhs_id = dr["hhs_id"].ToString();
                hhsr_id = dr["hhsr_id"].ToString();
                swk_id = dr["swk_id"].ToString();
                dst_id = dr["dst_id"].ToString();
                sct_id = dr["sct_id"].ToString();
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
            strSQL = "UPDATE hh_household " +
                "SET hh_code = '{1}', " +
                "hh_status_reason = '{2}', hh_tel = '{3}', hh_village = '{4}', " +
                "hhs_id = '{5}', hhsr_id = '{6}', swk_id = '{7}', wrd_id = '{8}', " +
                "usr_id_update = '{9}', usr_date_update = GETDATE() ,district_id = '{10}'" +
                "WHERE hh_id = '{0}' ";
            strSQL = string.Format(strSQL, hh_id, utilFormatting.StringForSQL(hh_code),
                utilFormatting.StringForSQL(hh_status_reason), utilFormatting.StringForSQL(hh_tel), utilFormatting.StringForSQL(hh_village),
                hhs_id, hhsr_id, swk_id, wrd_id,
                usr_id_update,Convert.ToInt32(district_id));

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
                        strWHERE = strWHERE + string.Format("AND dst.dst_id = '{0}' ",
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
                    case "swk_id":
                        strWHERE = strWHERE + string.Format("AND hh.swk_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hh_id":
                        strWHERE = strWHERE + string.Format("AND hh.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hh_code":
                        strWHERE = strWHERE + string.Format("AND LOWER(hh.hh_code) LIKE '%{0}%' ",
                            utilFormatting.StringForSQL(arrFilter[intCount, 1].ToLower().Trim()));
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT hh.hh_id, hh.hh_code, wrd.wrd_name, sct.sct_name, dst.dst_name, " +
                "ISNULL(swk.swk_first_name + ' ' + swk.swk_last_name, '') AS swk_name " +
                "FROM hh_household hh " + 
                "INNER JOIN lst_ward wrd On hh.wrd_id = wrd.wrd_id AND wrd.lng_id = '{0}' " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id AND sct.lng_id = '{0}' " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id AND dst.lng_id = '{0}' " +
                "LEFT JOIN swm_social_worker swk ON hh.swk_id = swk.swk_id " +
                strWHERE + " ORDER BY hh.hh_code ";
        
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetHousehold(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hh.*, sct.sct_id, dst.dst_id, " + 
                "wrd.wrd_name, sct.sct_name, dst.dst_name, hhs.hhs_name, ISNULL(swk.swk_first_name + ' ' + swk.swk_last_name, '') AS swk_name  " +
                "FROM hh_household hh " +
                "INNER JOIN (SELECT * FROM lst_ward WHERE lng_id = '{1}') wrd ON hh.wrd_id = wrd.wrd_id " +
                "INNER JOIN (SELECT * FROM lst_sub_county WHERE lng_id = '{1}') sct ON wrd.sct_id = sct.sct_id " +
                "INNER JOIN (SELECT * FROM lst_district WHERE lng_id = '{1}') dst ON sct.dst_id = dst.dst_id " +
                "INNER JOIN (SELECT * FROM lst_household_status WHERE lng_id = '{1}') hhs ON hh.hhs_id = hhs.hhs_id " +
                "LEFT JOIN swm_social_worker swk ON hh.swk_id = swk.swk_id " +
                "WHERE hh.hh_id = '{0}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetHouseholdMembersInOrder(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hhm_id, RTRIM(LTRIM(hhm_number + ' - ' + hhm_first_name + ' ' + hhm_last_name)) AS hhm_name " +
                "FROM hh_household_member " +
                "WHERE hh_id = '{0}' " +
                "ORDER BY yn_id_hoh DESC, yn_id_caregiver DESC, hhm_number ";
            strSQL = string.Format(strSQL, strId);
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
            strSQL = "SELECT hh.hh_id, hh.hh_code " +
                "FROM hh_household hh " +
                "ORDER BY hh.hhs_id DESC, hh.hh_code ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetListByDistrictAndForm(string strDstId, string strFormTable, string strFormPrefix, string strObjId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hh.hh_id, hh.hh_code " +
                "FROM hh_household hh " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id ";
            if (strDstId.Length != 0)
                strSQL = strSQL + string.Format("WHERE sct.dst_id = '{0}' ", strDstId);
            if (strObjId.Length != 0)
                strSQL = strSQL + string.Format("UNION SELECT hh_id, hh_code FROM hh_household " + 
                    "WHERE hh_id IN (SELECT DISTINCT hhm.hh_id FROM hh_household_member hhm " +
                    "INNER JOIN {0} {1} ON hhm.hhm_id = {1}.hhm_id " +
                    "WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId);
            strSQL = strSQL + "ORDER BY hh_code ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetListBySubCounty(string strSctId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hh.hh_id, hh.hh_code " +
                "FROM hh_household hh " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id ";
            if (strSctId.Length != 0)
                strSQL = strSQL + string.Format("WHERE wrd.sct_id = '{0}' ", strSctId);
            strSQL = strSQL + "ORDER BY hh_code ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetListBySubCountyAndForm(string strSctId, string strFormTable, string strFormPrefix, string strObjId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hh.hh_id, hh.hh_code " +
                "FROM hh_household hh " +
                "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id ";
            if (strSctId.Length != 0)
                strSQL = strSQL + string.Format("WHERE wrd.sct_id = '{0}' ", strSctId);
            if (strObjId.Length != 0)
                strSQL = strSQL + string.Format("UNION SELECT hh_id, hh_code FROM hh_household " +
                    "WHERE hh_id IN (SELECT DISTINCT hhm.hh_id FROM hh_household_member hhm " +
                    "INNER JOIN {0} {1} ON hhm.hhm_id = {1}.hhm_id " +
                    "WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId);
            strSQL = strSQL + "ORDER BY hh_code ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetRecords(string strId, string strRtpId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataRow dr = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLTemp = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT rtp.rtp_id, rtp.rtp_name, rtp.rtp_order " +
                "FROM lst_record_type rtp " +
                "WHERE rtp.lng_id = '{0}' ";
                if(strRtpId.Length !=0)
                    strSQL = strSQL + "AND rtp.rtp_id = '" + strRtpId + "' ";
                strSQL = strSQL + "ORDER BY rtp.rtp_order ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);

            strSQL = "";
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                dr = dt.Rows[intCount];
                strSQLTemp = "";

                switch (dr["rtp_id"].ToString())
                {
                    case utilConstants.cRTHomeVisit:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), hhv.hhv_date, 106))) AS the_date_display, " +
                            "hhv.hhv_date AS the_date, hhv.hhv_id AS rcd_id " +
                            "FROM hh_household_home_visit hhv " +
                            "WHERE hhv.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTHomeVisitArchive:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), hv.hv_date, 106))) AS the_date_display, " +
                            "hv.hv_date AS the_date, hv.hv_id AS rcd_id " +
                            "FROM hh_home_visit hv " +
                            "WHERE hv.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTHouseAssessment:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " + 
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " + 
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), hha.hha_date, 106))) AS the_date_display, " + 
                            "hha.hha_date AS the_date, hha.hha_id AS rcd_id " +
                            "FROM hh_household_assessment hha " +
                            "WHERE hha.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTOVCIdentificationPrioritization:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), oip.oip_date, 106))) AS the_date_display, " +
                            "oip.oip_date AS the_date, oip.oip_id AS rcd_id " +
                            "FROM hh_ovc_identification_prioritization oip " +
                            "WHERE oip.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTReferral:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), rfr.rfr_ra_date, 106))) AS the_date_display, " +
                            "rfr.rfr_ra_date AS the_date, rfr.rfr_id AS rcd_id " +
                            "FROM hh_referral rfr " +
                            "INNER JOIN hh_household_member hhm ON rfr.hhm_id = hhm.hhm_id " +
                            "WHERE hhm.hh_id = '{0}' ";
                        break;

                    case utilConstants.cRTHIP:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), hip.visit_date, 106))) AS the_date_display, " +
                            "hip.visit_date AS the_date, hip.hip_id AS rcd_id " +
                            "FROM hh_household_improvement_plan hip " +
                            "WHERE hip.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTOVCViralLoad:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), V.usr_date_create, 106))) AS the_date_display, " +
                            "V.usr_date_create AS the_date, v.vl_id AS rcd_id " +
                            "FROM ben_ovc_viral_load V " +
                            "WHERE V.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTRiskAssessment:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), V.date_of_visit, 106))) AS the_date_display, " +
                            "V.date_of_visit AS the_date, v.ras_id AS rcd_id " +
                            "FROM hh_household_risk_assessment_header V " +
                            "WHERE V.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTGBV:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), V.gbv_screen_date, 106))) AS the_date_display, " +
                            "V.gbv_screen_date AS the_date, v.gbv_id AS rcd_id " +
                            "FROM ben_gbv_screening V " +
                            "INNER JOIN hh_household_member hhm ON V.hhm_id = hhm.hhm_id " + 
                            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " + 
                            "WHERE hh.hh_id = '{0}' ";
                        break;
                    case utilConstants.cRTAdherence:
                        strSQLTemp = "SELECT '" + dr["rtp_id"].ToString() + "' AS rtp_id, " +
                            "'" + dr["rtp_name"].ToString() + "' AS rtp_name, " +
                            dr["rtp_order"].ToString() + " AS rtp_order, " +
                            "RTRIM(LTRIM(CONVERT(CHAR(15), V.visit_date, 106))) AS the_date_display, " +
                            "V.visit_date AS the_date, v.iac_id AS rcd_id " +
                            "FROM ben_adherence_counselling V " +
                            "INNER JOIN hh_household_member hhm ON V.hhm_id = hhm.hhm_id " +
                            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                            "WHERE hh.hh_id = '{0}' ";
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

            strSQL = strSQL + "ORDER BY rtp_order, the_date DESC ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetHousehold(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT hh.*, sct.sct_id, dst.dst_id " +
            "FROM hh_household hh " +
            "INNER JOIN lst_ward wrd ON hh.wrd_id = wrd.wrd_id " +
            "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
            "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
            "WHERE hh.hh_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
