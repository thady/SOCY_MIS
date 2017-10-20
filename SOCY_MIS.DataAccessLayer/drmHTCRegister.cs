using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmHTCRegister
    {
        #region Variables
        #region Public
        public string dhr_id = string.Empty;
        public string dhr_result_01 = string.Empty;
        public DateTime dhr_result_01_date = DateTime.Now;
        public string dhr_result_02 = string.Empty;
        public DateTime dhr_result_02_date = DateTime.Now;
        public string dhr_result_03 = string.Empty;
        public DateTime dhr_result_03_date = DateTime.Now;
        public string dhr_result_04 = string.Empty;
        public DateTime dhr_result_04_date = DateTime.Now;
        public string dhr_result_05 = string.Empty;
        public DateTime dhr_result_05_date = DateTime.Now;
        public string dm_id = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmHTCRegister()
        {
            Default();
        }

        public drmHTCRegister(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM drm_htc_register WHERE dhr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Object
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetObject(strId, dbCon);
                Load(dt);
            }
            #endregion Set Object
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetObject(dhr_id, dbCon);
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
            dhr_id = string.Empty;
            dhr_result_01 = string.Empty;
            dhr_result_01_date = DateTime.Now;
            dhr_result_02 = string.Empty;
            dhr_result_02_date = DateTime.Now;
            dhr_result_03 = string.Empty;
            dhr_result_03_date = DateTime.Now;
            dhr_result_04 = string.Empty;
            dhr_result_04_date = DateTime.Now;
            dhr_result_05 = string.Empty;
            dhr_result_05_date = DateTime.Now;
            dm_id = string.Empty;
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
            strSQL = "INSERT INTO drm_htc_register " +
                "(dhr_id, " +
                "dhr_result_01, dhr_result_01_date, " + 
                "dhr_result_02, dhr_result_02_date, " +
                "dhr_result_03, dhr_result_03_date, " +
                "dhr_result_04, dhr_result_04_date, " +
                "dhr_result_05, dhr_result_05_date, " +
                "dm_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', " + 
                "'{3}', '{4}', " + 
                "'{5}', '{6}', " + 
                "'{7}', '{8}', " + 
                "'{9}', '{10}', " + 
                "'{11}', " +
                "'{12}', '{12}', GETDATE(), GETDATE(), '{13}', '{14}') ";
            strSQL = string.Format(strSQL, dhr_id,
                utilFormatting.StringForSQL(dhr_result_01), dhr_result_01_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_02), dhr_result_02_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_03), dhr_result_03_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_04), dhr_result_04_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_05), dhr_result_05_date.ToString("dd MMM yyyy HH:mm:ss"),
                dm_id,
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
                dhr_id = dr["dhr_id"].ToString();
                dhr_result_01 = dr["dhr_result_01"].ToString();
                dhr_result_01_date = Convert.ToDateTime(dr["dhr_result_01_date"]);
                dhr_result_02 = dr["dhr_result_02"].ToString();
                dhr_result_02_date = Convert.ToDateTime(dr["dhr_result_02_date"]);
                dhr_result_03 = dr["dhr_result_03"].ToString();
                dhr_result_03_date = Convert.ToDateTime(dr["dhr_result_03_date"]);
                dhr_result_04 = dr["dhr_result_04"].ToString();
                dhr_result_04_date = Convert.ToDateTime(dr["dhr_result_04_date"]);
                dhr_result_05 = dr["dhr_result_05"].ToString();
                dhr_result_05_date = Convert.ToDateTime(dr["dhr_result_05_date"]);
                dm_id = dr["dm_id"].ToString();
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
            strSQL = "UPDATE drm_htc_register " +
                "SET dhr_result_01 = '{1}', dhr_result_01_date = '{2}', " +
                "dhr_result_02 = '{3}', dhr_result_02_date = '{4}', " +
                "dhr_result_03 = '{5}', dhr_result_03_date = '{6}', " +
                "dhr_result_04 = '{7}', dhr_result_04_date = '{8}', " +
                "dhr_result_05 = '{9}', dhr_result_05_date = '{10}', " +
                "dm_id = '{11}', " +
                "usr_id_update = '{12}', usr_date_update = GETDATE(),district_id = '{13}' " +
                "WHERE dhr_id = '{0}' ";
            strSQL = string.Format(strSQL, dhr_id,
                utilFormatting.StringForSQL(dhr_result_01), dhr_result_01_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_02), dhr_result_02_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_03), dhr_result_03_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_04), dhr_result_04_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(dhr_result_05), dhr_result_05_date.ToString("dd MMM yyyy HH:mm:ss"),
                dm_id,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetList(string strDmId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT dhr.dhr_id, dhr.ofc_id, RTRIM(LTRIM(CONVERT(CHAR(15), dhr.usr_date_create, 106))) AS usr_date_create " +
                "FROM drm_htc_register dhr " +
                "WHERE dhr.dm_id = '{0}' " +
                "ORDER BY usr_date_create DESC ";
            strSQL = string.Format(strSQL, strDmId);
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
            strSQL = "SELECT * " +
            "FROM drm_htc_register " +
            "WHERE dhr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}