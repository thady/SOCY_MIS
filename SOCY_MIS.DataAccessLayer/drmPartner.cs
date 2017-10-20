using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmPartner
    {
        #region Variables
        #region Public
        public string dp_id = string.Empty;
        public string dp_first_name = string.Empty;
        public string dp_last_name = string.Empty;
        public string dm_id = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmPartner()
        {
            Default();
        }

        public drmPartner(string strId, DBConnection dbCon)
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
            dt = GetObject(dp_id, dbCon);
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
            dp_id = string.Empty;
            dp_first_name = string.Empty;
            dp_last_name = string.Empty;
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
            strSQL = "INSERT INTO drm_partner " +
                "(dp_id, dp_first_name, dp_last_name, dm_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', " +
                "'{4}', '{4}', GETDATE(), GETDATE(), '{5}','{6}') ";
            strSQL = string.Format(strSQL, dp_id, utilFormatting.StringForSQL(dp_first_name), utilFormatting.StringForSQL(dp_last_name), dm_id, 
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
                dp_id = dr["dp_id"].ToString();
                dp_first_name = dr["dp_first_name"].ToString();
                dp_last_name = dr["dp_last_name"].ToString();
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
            strSQL = "UPDATE drm_partner " +
                "SET dp_first_name = '{1}', dp_last_name = '{2}', dm_id = '{3}', " +
                "usr_id_update = '{4}', usr_date_update = GETDATE(),district_id = '{5}' " +
                "WHERE dp_id = '{0}' ";
            strSQL = string.Format(strSQL, dp_id, utilFormatting.StringForSQL(dp_first_name), utilFormatting.StringForSQL(dp_last_name), dm_id, 
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
            strSQL = "SELECT dp_id, dp_first_name + ' ' + dp_last_name AS dp_name " +
                "FROM drm_partner " +
                "WHERE dm_id = '{0}' " +
                "ORDER BY dp_name ";
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
                "FROM drm_partner " +
                "WHERE dp_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}