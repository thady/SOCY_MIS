using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmEnrollment
    {
        #region Variables
        #region Public
        public string de_id = string.Empty;
        public string dst_id = string.Empty;
        public string flt_id = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmEnrollment()
        {
            Default();
        }

        public drmEnrollment(string strId, DBConnection dbCon)
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
                dt = GetRegister(strId, dbCon);
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
            dt = GetRegister(de_id, dbCon);
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
            de_id = string.Empty;
            dst_id = utilConstants.cDFEmptyListValue;
            flt_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_enrollment " +
                "(de_id, " + 
                "dst_id, flt_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " +
                "'{3}', '{3}', GETDATE(), GETDATE(), '{4}','{5}') ";
            strSQL = string.Format(strSQL, de_id, 
                dst_id, flt_id, 
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
                de_id = dr["de_id"].ToString();
                dst_id = dr["dst_id"].ToString();
                flt_id = dr["flt_id"].ToString();
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
            strSQL = "UPDATE drm_enrollment " +
                "SET dst_id = '{1}', flt_id = '{2}', " +
                "usr_id_update = '{3}', usr_date_update = GETDATE(),district_id = '{4}' " +
                "WHERE de_id = '{0}' ";
            strSQL = string.Format(strSQL, de_id,
                dst_id, flt_id,
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
                        strWHERE = strWHERE + string.Format("AND de.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "flt_id":
                        strWHERE = strWHERE + string.Format("AND de.flt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_create_begin":
                        strWHERE = strWHERE + string.Format("AND de.usr_date_create >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_create_end":
                        strWHERE = strWHERE + string.Format("AND de.usr_date_create <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT de.de_id, " +
                "ISNULL(dst.dst_name, '') AS dst_name, " +
                "ISNULL(flt.flt_name, '') AS flt_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), de.usr_date_create, 106))) AS date_create " +
                "FROM drm_enrollment de " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON de.dst_id = dst.dst_id " +
                "LEFT JOIN (SELECT flt_id, flt_name FROM lst_facility) flt ON de.flt_id = flt.flt_id " +
                strWHERE +
                "ORDER BY usr_date_create, flt_name, dst_name ";
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
            strSQL = "SELECT ISNULL(MIN(usr_date_create), GETDATE()) AS date_create_begin, " +
                "ISNULL(MAX(usr_date_create), GETDATE()) AS date_create_end " +
                "FROM drm_enrollment ";
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
            strSQL = "SELECT dem.dem_id, dm.dm_id_no, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dm.dm_first_name + ' ' + dm.dm_last_name) AS member_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), dm.dm_registration, 106))) AS dm_registration " +
                "FROM drm_enrollment_member dem " +
                "INNER JOIN drm_member dm ON dem.dm_id = dm.dm_id " +
                "LEFT JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dem.de_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
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
            strSQL = "SELECT dem.dem_id, dem.dem_days, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dem.dem_name) AS dem_name, ISNULL(hh.hh_code + '/' + hhm.hhm_number, '') AS hhm_code, " +
                "REPLACE(ISNULL(hhm.hhm_year_of_birth, dem.dem_year_of_birth), '-1', '') AS dem_year_of_birth, " +
                "ISNULL(hgnd.gnd_name, gnd.gnd_name) AS gnd_name, mtp.mtp_name " +
                "FROM drm_enrollment_participant dem " +
                "INNER JOIN lst_member_type mtp ON dem.mtp_id = mtp.mtp_id AND mtp.lng_id = '{1}' " +
                "LEFT JOIN (SELECT gnd_id, gnd_name FROM lst_gender) gnd ON dem.gnd_id = gnd.gnd_id " +
                "LEFT JOIN hh_household_member hhm ON dem.hhm_id = hhm.hhm_id " +
                "LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "LEFT JOIN (SELECT gnd_id, gnd_name FROM lst_gender) hgnd ON hhm.gnd_id = hgnd.gnd_id " +
                "WHERE dem.de_id = '{0}' " +
                "ORDER BY dem_name  ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetRegister(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT de.* " +
            "FROM drm_enrollment de " +
            "WHERE de.de_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}