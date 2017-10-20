using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcFinancialRegister
    {
        #region Variables
        #region Public
        public string sfr_id = string.Empty;
        public string sfr_contact_details = string.Empty;
        public string cso_id = string.Empty;
        public string fy_id = string.Empty;
        public string qy_id = string.Empty;
        public string swk_id = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcFinancialRegister()
        {
            Default();
        }

        public silcFinancialRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            silcFinancialRegisterGroup dalSFRG = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalSFRG = new silcFinancialRegisterGroup();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalSFRG.Delete(dt.Rows[intCount]["sfrg_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM silc_financial_register WHERE sfr_id = '{0}' ";
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
            dt = GetRegister(sfr_id, dbCon);
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
            sfr_id = string.Empty;
            sfr_contact_details = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            qy_id = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO silc_financial_register " +
                "(sfr_id, sfr_contact_details, " +
		        "cso_id, fy_id, qy_id, swk_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, sfr_id, utilFormatting.StringForSQL(sfr_contact_details),
                cso_id, fy_id, qy_id, swk_id, 
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
                sfr_id = dr["sfr_id"].ToString();
                sfr_contact_details = dr["sfr_contact_details"].ToString();
                cso_id = dr["cso_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                qy_id = dr["qy_id"].ToString();
                swk_id = dr["swk_id"].ToString();
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
            strSQL = "UPDATE silc_financial_register " +
                "SET sfr_contact_details = '{1}', " +
                "cso_id = '{2}', fy_id = '{3}', qy_id = '{4}', swk_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE sfr_id = '{0}' ";
            strSQL = string.Format(strSQL, sfr_id, utilFormatting.StringForSQL(sfr_contact_details),
                cso_id, fy_id, qy_id, swk_id, 
                usr_id_update);

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
                    case "cso_id":
                        strWHERE = strWHERE + string.Format("AND sfr.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND sfr.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND cso.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND sfr.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT sfr.sfr_id, sfr.ofc_id, " +
                "ISNULL(cso.cso_name, '') AS cso_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name " +
                "FROM silc_financial_register sfr " +
                "LEFT JOIN lst_cso cso ON sfr.cso_id = cso.cso_id " +
                "LEFT JOIN lst_financial_year fy ON sfr.fy_id = fy.fy_id " +
                "LEFT JOIN lst_partner prt ON cso.prt_id = prt.prt_id " +
                "LEFT JOIN lst_quarter_year qy ON sfr.qy_id = qy.qy_id " +
                strWHERE +
                "ORDER BY prt_name ";
            strSQL = string.Format(strSQL, strLngId);
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
            strSQL = "SELECT sfrg.sfrg_id, sfrg.ofc_id, " +
                "sfrg.sfrg_members_female, sfrg.sfrg_members_male, sfrg.sfrg_amount_borrowed, " +
                "sg.sg_name " +
                "FROM silc_financial_register_group sfrg " +
                "INNER JOIN silc_group sg ON sfrg.sg_id = sg.sg_id " +
                "WHERE sfrg.sfr_id = '{0}' " +
                "ORDER BY sg.sg_name ";
            strSQL = string.Format(strSQL, strId);
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
            strSQL = "SELECT sfr.* " +
            "FROM silc_financial_register sfr " +
            "WHERE sfr.sfr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}