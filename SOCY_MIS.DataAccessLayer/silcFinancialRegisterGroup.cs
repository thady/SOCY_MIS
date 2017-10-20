using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcFinancialRegisterGroup
    {
        #region Variables
        #region Public
        public string sfrg_id = string.Empty;
        public int sfrg_members_female = 0;
        public int sfrg_members_male = 0;
        public decimal sfrg_amount_borrowed = 0;
        public string sfr_id = utilConstants.cDFEmptyListValue;
        public string sg_id = utilConstants.cDFEmptyListValue;
        public string yn_id_borrowed = utilConstants.cDFEmptyListValue;
        public string yn_id_linked = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcFinancialRegisterGroup()
        {
            Default();
        }

        public silcFinancialRegisterGroup(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM silc_financial_register_group WHERE sfrg_id = '{0}' ";
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
                dt = GetGroup(strId, dbCon);
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
            dt = GetGroup(sfrg_id, dbCon);
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
            sfrg_id = string.Empty;
            sfrg_members_female = 0;
            sfrg_members_male = 0;
            sfrg_amount_borrowed = 0;
            sfr_id = utilConstants.cDFEmptyListValue;
            sg_id = utilConstants.cDFEmptyListValue;
            yn_id_borrowed = utilConstants.cDFEmptyListValue;
            yn_id_linked = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO silc_financial_register_group " +
                "(sfrg_id, " +
                "sfrg_members_female, sfrg_members_male, sfrg_amount_borrowed, " +
                "sfr_id, sg_id, yn_id_borrowed, yn_id_linked, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "{1}, {2}, {3}, " +
                "'{4}', '{5}', '{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, sfrg_id, 
                sfrg_members_female, sfrg_members_male, sfrg_amount_borrowed,
                sfr_id, sg_id, yn_id_borrowed, yn_id_linked,
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
                sfrg_id = dr["sfrg_id"].ToString();
                sfrg_members_female = Convert.ToInt32(dr["sfrg_members_female"]);
                sfrg_members_male = Convert.ToInt32(dr["sfrg_members_male"]);
                sfrg_amount_borrowed = Convert.ToDecimal(dr["sfrg_amount_borrowed"]);
                sfr_id = dr["sfr_id"].ToString();
                sg_id = dr["sg_id"].ToString();
                yn_id_borrowed = dr["yn_id_borrowed"].ToString();
                yn_id_linked = dr["yn_id_linked"].ToString();
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
            strSQL = "UPDATE silc_financial_register_group " +
                "SET sfrg_members_female = {1}, sfrg_members_male = {2}, sfrg_amount_borrowed = {3}, " +
                "sfr_id = '{4}', sg_id = '{5}', yn_id_borrowed = '{6}', yn_id_linked = '{7}', " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE sfrg_id = '{0}' ";
            strSQL = string.Format(strSQL, sfrg_id,
                sfrg_members_female, sfrg_members_male, sfrg_amount_borrowed,
                sfr_id, sg_id, yn_id_borrowed, yn_id_linked,
                usr_id_update);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetGroup(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT sfrg.* " +
            "FROM silc_financial_register_group sfrg " +
            "WHERE sfrg.sfrg_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}