using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmEnrollmentMember
    {
        #region Variables
        #region Public
        public string dem_id = string.Empty;
        public string dem_sn = string.Empty;
        public string de_id = utilConstants.cDFEmptyListValue;
        public string dm_id = utilConstants.cDFEmptyListValue;
        public string est_id = utilConstants.cDFEmptyListValue;
        public string pst_id = utilConstants.cDFEmptyListValue;
        public string sst_id = utilConstants.cDFEmptyListValue;
        public string yn_id_disability = utilConstants.cDFEmptyListValue;
        public string yn_id_given_birth = utilConstants.cDFEmptyListValue;
        public string yn_id_married = utilConstants.cDFEmptyListValue;
        public string yn_id_partner = utilConstants.cDFEmptyListValue;
        public string yn_id_pregnant = utilConstants.cDFEmptyListValue;
        public string yn_id_ts = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public string[] segment = "".Split(utilConstants.cDFSplitChar);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmEnrollmentMember()
        {
            Default();
        }

        public drmEnrollmentMember(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
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
                SegmentLoad(strId, dbCon);
            }
            #endregion Set Data
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(dem_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            SegmentUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            dem_id = string.Empty;
            dem_sn = string.Empty;
            de_id = utilConstants.cDFEmptyListValue;
            dm_id = utilConstants.cDFEmptyListValue;
            est_id = utilConstants.cDFEmptyListValue;
            pst_id = utilConstants.cDFEmptyListValue;
            sst_id = utilConstants.cDFEmptyListValue;
            yn_id_disability = utilConstants.cDFEmptyListValue;
            yn_id_given_birth = utilConstants.cDFEmptyListValue;
            yn_id_married = utilConstants.cDFEmptyListValue;
            yn_id_partner = utilConstants.cDFEmptyListValue;
            yn_id_pregnant = utilConstants.cDFEmptyListValue;
            yn_id_ts = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_enrollment_member " +
                "(dem_id, dem_sn, " +
                "de_id, dm_id, est_id, pst_id, sst_id, " +
                "yn_id_disability, yn_id_given_birth, yn_id_married, " +
                "yn_id_partner, yn_id_pregnant, yn_id_ts, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', " +
                "'{10}', '{11}', '{12}', " +
                "'{13}', '{13}', GETDATE(), GETDATE(), '{14}','{15}') ";
            strSQL = string.Format(strSQL, dem_id, utilFormatting.StringForSQL(dem_sn), 
                de_id, dm_id, est_id, pst_id, sst_id, 
                yn_id_disability, yn_id_given_birth, yn_id_married, 
                yn_id_partner, yn_id_pregnant, yn_id_ts,
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
                dem_id = dr["dem_id"].ToString();
                dem_sn = dr["dem_sn"].ToString();
                de_id = dr["de_id"].ToString();
                dm_id = dr["dm_id"].ToString();
                est_id = dr["est_id"].ToString();
                pst_id = dr["pst_id"].ToString();
                sst_id = dr["sst_id"].ToString();
                yn_id_disability = dr["yn_id_disability"].ToString();
                yn_id_given_birth = dr["yn_id_given_birth"].ToString();
                yn_id_married = dr["yn_id_married"].ToString();
                yn_id_partner = dr["yn_id_partner"].ToString();
                yn_id_pregnant = dr["yn_id_pregnant"].ToString();
                yn_id_ts = dr["yn_id_ts"].ToString();
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
            strSQL = "UPDATE drm_enrollment_member " +
                "SET dem_sn = '{1}', " +
                "de_id = '{2}', dm_id = '{3}', est_id = '{4}', pst_id = '{5}', sst_id = '{6}', " +
                "yn_id_disability = '{7}', yn_id_given_birth = '{8}', yn_id_married = '{9}', " +
                "yn_id_partner = '{10}', yn_id_pregnant = '{11}', yn_id_ts = '{12}', " +
                "usr_id_update = '{13}', usr_date_update = GETDATE(),district_id = '{14}' " +
                "WHERE dem_id = '{0}' ";
            strSQL = string.Format(strSQL, dem_id, utilFormatting.StringForSQL(dem_sn),
                de_id, dm_id, est_id, pst_id, sst_id,
                yn_id_disability, yn_id_given_birth, yn_id_married,
                yn_id_partner, yn_id_pregnant, yn_id_ts,
                usr_id_update, ofc_id, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetLines(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT demv.demv_id, vst.vst_name, RTRIM(LTRIM(CONVERT(CHAR(15), demv.demv_date, 106))) AS demv_date, vst.vst_order " +
                "FROM drm_enrollment_member dem " +
                "INNER JOIN drm_enrollment_member_visit demv ON dem.dem_id = demv.dem_id " +
                "INNER JOIN (SELECT vst_id, vst_name, vst_order FROM lst_visit WHERE lng_id = '{1}') vst ON demv.vst_id = vst.vst_id " +
                "WHERE demv.dem_id = '{0}' " + 
                "ORDER BY vst_order ";
            strSQL = string.Format(strSQL, strId, strLngId);
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
            strSQL = "SELECT dem.* " +
            "FROM drm_enrollment_member dem " +
            "WHERE dem.dem_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region Segment
        private DataTable SegmentGet(string strDemId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM drm_enrollment_member_segment " +
            "WHERE dem_id = '{0}' ";
            strSQL = string.Format(strSQL, strDemId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void SegmentLoad(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = SegmentGet(strHvId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["sgm_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["sgm_id"].ToString();
            }

            segment = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void SegmentUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (segment.Length != 0)
            {
                strInsert = "INSERT INTO drm_enrollment_member_segment (dems_id, dem_id, sgm_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT sgm_id FROM drm_enrollment_member_segment WHERE dem_id = '{0}') ";
                for (int intCount = 0; intCount < segment.Length; intCount++)
                {
                    if (segment[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", segment[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", segment[intCount]);
                        strSQL = strSQL + string.Format(strInsert, dem_id, segment[intCount], usr_id_update, ofc_id, district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM drm_enrollment_member_segment WHERE dem_id = '{0}' AND NOT sgm_id IN ({1}) ";
            strSQL = string.Format(strSQL, dem_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services Referred
    }
}
