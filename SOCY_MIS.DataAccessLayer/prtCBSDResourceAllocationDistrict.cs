using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtCBSDResourceAllocationDistrict
    {
        #region Variables
        #region Public
        public string crad_id = string.Empty;
        public decimal crad_cbsd_budget = 0;
        public decimal crad_cbsd_realization = 0;
        public decimal crad_district_grant_budget = 0;
        public decimal crad_probation_realization = 0;
        public decimal crad_probation_share = 0;
        public string cra_id = utilConstants.cDFEmptyListValue;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtCBSDResourceAllocationDistrict()
        {
            Default();
        }

        public prtCBSDResourceAllocationDistrict(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM prt_cbsd_resource_allocation_district WHERE crad_id = '{0}' ";
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
            dt = GetObject(crad_id, dbCon);
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
            crad_id = string.Empty;
            crad_cbsd_budget = 0;
            crad_cbsd_realization = 0;
            crad_district_grant_budget = 0;
            crad_probation_realization = 0;
            crad_probation_share = 0;
            cra_id = utilConstants.cDFEmptyListValue;
            dst_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_cbsd_resource_allocation_district " +
                "(crad_id, " +
                "crad_cbsd_budget, crad_cbsd_realization, " +
                "crad_district_grant_budget, crad_probation_realization, crad_probation_share, " +
                "cra_id, dst_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "{1}, {2}, " +
                "{3}, {4}, {5}, " +
                "'{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, crad_id,
                crad_cbsd_budget, crad_cbsd_realization,
                crad_district_grant_budget, crad_probation_realization, crad_probation_share, 
                cra_id, dst_id, 
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
                crad_id = dr["crad_id"].ToString();
                crad_cbsd_budget = Convert.ToDecimal(dr["crad_cbsd_budget"]);
                crad_cbsd_realization = Convert.ToDecimal(dr["crad_cbsd_realization"]);
                crad_district_grant_budget = Convert.ToDecimal(dr["crad_district_grant_budget"]);
                crad_probation_realization = Convert.ToDecimal(dr["crad_probation_realization"]);
                crad_probation_share = Convert.ToDecimal(dr["crad_probation_share"]);
                cra_id = dr["cra_id"].ToString();
                dst_id = dr["dst_id"].ToString();
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
            strSQL = "UPDATE prt_cbsd_resource_allocation_district " +
                "SET crad_cbsd_budget = {1}, crad_cbsd_realization = {2}, " +
                "crad_district_grant_budget = {3}, crad_probation_realization = {4}, crad_probation_share = {5}, " +
                "cra_id = '{6}', dst_id = '{7}',  " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE crad_id = '{0}' ";
            strSQL = string.Format(strSQL, crad_id,
                crad_cbsd_budget, crad_cbsd_realization,
                crad_district_grant_budget, crad_probation_realization, crad_probation_share, 
                cra_id, dst_id, 
                usr_id_update, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT crad.* " +
            "FROM prt_cbsd_resource_allocation_district crad " +
            "WHERE crad.crad_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}