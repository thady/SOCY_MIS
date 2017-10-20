using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcSavingsRegisterMember
    {
        #region Variables
        #region Public
        public string ssrm_id = string.Empty;
        public decimal ssrm_shares_bought_today = 0;
        public decimal ssrm_shares_brought_forward = 0;
        public decimal ssrm_shares_redeemed = 0;
        public decimal ssrm_shares_total = 0;
        public string ssrm_welfare_fund = string.Empty;
        public string sgm_id = utilConstants.cDFEmptyListValue;
        public string ssr_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcSavingsRegisterMember()
        {
            Default();
        }

        public silcSavingsRegisterMember(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM silc_savings_register_member WHERE ssrm_id = '{0}' ";
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
                dt = GetMember(strId, dbCon);
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
            dt = GetMember(ssrm_id, dbCon);
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
            ssrm_id = string.Empty;
            ssrm_shares_bought_today = 0;
            ssrm_shares_brought_forward = 0;
            ssrm_shares_redeemed = 0;
            ssrm_shares_total = 0;
            ssrm_welfare_fund = string.Empty;
            sgm_id = utilConstants.cDFEmptyListValue;
            ssr_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO silc_savings_register_member " +
                "(ssrm_id, " +
		        "ssrm_shares_bought_today, ssrm_shares_brought_forward, ssrm_shares_redeemed, ssrm_shares_total, " +
		        "ssrm_welfare_fund, " +
		        "sgm_id, ssr_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "{1}, {2}, {3}, {4}, " +
                "'{5}', " +
                "'{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, ssrm_id, 
		        ssrm_shares_bought_today, ssrm_shares_brought_forward, ssrm_shares_redeemed, ssrm_shares_total,
		        utilFormatting.StringForSQL(ssrm_welfare_fund),
		        sgm_id, ssr_id, 
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
                ssrm_id = dr["ssrm_id"].ToString();
                ssrm_shares_bought_today = Convert.ToDecimal(dr["ssrm_shares_bought_today"]);
                ssrm_shares_brought_forward = Convert.ToDecimal(dr["ssrm_shares_brought_forward"]);
                ssrm_shares_redeemed = Convert.ToDecimal(dr["ssrm_shares_redeemed"]);
                ssrm_shares_total = Convert.ToDecimal(dr["ssrm_shares_total"]);
                ssrm_welfare_fund = dr["ssrm_welfare_fund"].ToString();
                sgm_id = dr["sgm_id"].ToString();
                ssr_id = dr["ssr_id"].ToString();
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
            strSQL = "UPDATE silc_savings_register_member " +
                "SET ssrm_shares_bought_today = {1}, ssrm_shares_brought_forward = {2}, ssrm_shares_redeemed = {3}, ssrm_shares_total = {4}, " +
                "ssrm_welfare_fund = '{5}', " +
                "sgm_id = '{6}', ssr_id = '{7}', " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE ssrm_id = '{0}' ";
            strSQL = string.Format(strSQL, ssrm_id,
                ssrm_shares_bought_today, ssrm_shares_brought_forward, ssrm_shares_redeemed, ssrm_shares_total,
                utilFormatting.StringForSQL(ssrm_welfare_fund),
                sgm_id, ssr_id,
                usr_id_update, district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetMember(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ssrm.* " +
            "FROM silc_savings_register_member ssrm " +
            "WHERE ssrm.ssrm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
