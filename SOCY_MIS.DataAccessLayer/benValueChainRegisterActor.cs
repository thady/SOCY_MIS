using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benValueChainRegisterActor
    {
        #region Variables
        #region Public
        public string vcra_id = string.Empty;
        public string vcra_commodity = string.Empty;
        public string vcra_bds_service = string.Empty;
        public decimal vcra_id_price = 0;
        public decimal vcra_id_qty = 0;
        public decimal vcra_id_revenue = 0;
        public decimal vcra_pb_price = 0;
        public decimal vcra_pb_qty = 0;
        public decimal vcra_pb_revenue = 0;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string vcr_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benValueChainRegisterActor()
        {
            Default();
        }

        public benValueChainRegisterActor(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM ben_value_chain_register_actor WHERE vcra_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set HomeVisit
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetActor(strId, dbCon);
                Load(dt);
            }
            #endregion Set HomeVisit
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetActor(vcra_id, dbCon);
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
            vcra_id = string.Empty;
            vcra_commodity = string.Empty;
            vcra_bds_service = string.Empty;
            vcra_id_price = 0;
            vcra_id_qty = 0;
            vcra_id_revenue = 0;
            vcra_pb_price = 0;
            vcra_pb_qty = 0;
            vcra_pb_revenue = 0;
            hhm_id = utilConstants.cDFEmptyListValue;
            vcr_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_value_chain_register_actor " +
                "(vcra_id, vcra_commodity, vcra_bds_service, " +
		        "vcra_id_price, vcra_id_qty, vcra_id_revenue, " +
                "vcra_pb_price, vcra_pb_qty, vcra_pb_revenue, " +
                "hhm_id, vcr_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
                "{3}, {4}, {5}, " +
                "{6}, {7}, {8}, " +
                "'{9}', '{10}', " +
                "'{11}', '{11}', GETDATE(), GETDATE(), '{12}','{13}') ";
            strSQL = string.Format(strSQL, vcra_id, utilFormatting.StringForSQL(vcra_commodity), utilFormatting.StringForSQL(vcra_bds_service),
                vcra_id_price, vcra_id_qty, vcra_id_revenue, 
                vcra_pb_price, vcra_pb_qty, vcra_pb_revenue, 
                hhm_id, vcr_id,
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
                vcra_id = dr["vcra_id"].ToString();
                vcra_commodity = dr["vcra_commodity"].ToString();
                vcra_bds_service = dr["vcra_bds_service"].ToString();
                vcra_id_price = Convert.ToDecimal(dr["vcra_id_price"]);
                vcra_id_qty = Convert.ToDecimal(dr["vcra_id_qty"]);
                vcra_id_revenue = Convert.ToDecimal(dr["vcra_id_revenue"]);
                vcra_pb_price = Convert.ToDecimal(dr["vcra_pb_price"]);
                vcra_pb_qty = Convert.ToDecimal(dr["vcra_pb_qty"]);
                vcra_pb_revenue = Convert.ToDecimal(dr["vcra_pb_revenue"]);
                hhm_id = dr["hhm_id"].ToString();
                vcr_id = dr["vcr_id"].ToString();
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
            strSQL = "UPDATE ben_value_chain_register_actor " +
                "SET vcra_commodity = '{1}', vcra_bds_service = '{2}', " +
                "vcra_id_price = {3}, vcra_id_qty = {4}, vcra_id_revenue = {5}, " +
                "vcra_pb_price = {6}, vcra_pb_qty = {7}, vcra_pb_revenue = {8}, " +
                "hhm_id = '{9}', vcr_id = '{10}', " +
                "usr_id_update = '{11}', usr_date_update = GETDATE(),district_id = '{12}' " +
                "WHERE vcra_id = '{0}' ";
            strSQL = string.Format(strSQL, vcra_id, utilFormatting.StringForSQL(vcra_commodity), utilFormatting.StringForSQL(vcra_bds_service),
                vcra_id_price, vcra_id_qty, vcra_id_revenue,
                vcra_pb_price, vcra_pb_qty, vcra_pb_revenue,
                hhm_id, vcr_id,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetActor(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT vcra.*, hhm.hh_id " +
            "FROM ben_value_chain_register_actor vcra " +
            "INNER JOIN hh_household_member hhm ON vcra.hhm_id = hhm.hhm_id " +
            "WHERE vcra.vcra_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
