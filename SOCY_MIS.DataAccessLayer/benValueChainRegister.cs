using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benValueChainRegister
    {
        #region Variables
        #region Public
        public string vcr_id = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string sct_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benValueChainRegister()
        {
            Default();
        }

        public benValueChainRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            benGirlEducationRegisterChild dalGERC = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalGERC = new benGirlEducationRegisterChild();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalGERC.Delete(dt.Rows[intCount]["vcra_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM ben_value_chain_register WHERE vcr_id = '{0}' ";
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
                dt = GetValueChain(strId, dbCon);
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
            dt = GetValueChain(vcr_id, dbCon);
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
            vcr_id = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            qy_id = utilConstants.cDFEmptyListValue;
            sct_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_value_chain_register " +
                "(vcr_id, " +
                "cso_id, fy_id, qy_id, sct_id, swk_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, vcr_id,
                cso_id, fy_id, qy_id, sct_id, swk_id,
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
                vcr_id = dr["vcr_id"].ToString();
                cso_id = dr["cso_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                qy_id = dr["qy_id"].ToString();
                sct_id = dr["sct_id"].ToString();
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
            strSQL = "UPDATE ben_value_chain_register " +
                "SET cso_id = '{1}', fy_id = '{2}', qy_id = '{3}', sct_id = '{4}', swk_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE vcr_id = '{0}' ";
            strSQL = string.Format(strSQL, vcr_id,
                cso_id, fy_id, qy_id, sct_id, swk_id,
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
                    case "cso_id":
                        strWHERE = strWHERE + string.Format("AND vcr.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND cso.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND vcr.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND vcr.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND vcr.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT vcr.vcr_id, vcr.ofc_id, " +
                "ISNULL(cso.cso_name, '') AS cso_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "ISNULL(sct.sct_name, '') AS sct_name, ISNULL(dst.dst_name, '') AS dst_name, " +
                "ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name " +
                "FROM ben_value_chain_register vcr " +
                "LEFT JOIN lst_cso cso ON vcr.cso_id = cso.cso_id " +
                "LEFT JOIN lst_partner prt ON cso.prt_id = prt.prt_id " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON vcr.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                "LEFT JOIN lst_financial_year fy ON vcr.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON vcr.qy_id = qy.qy_id " +
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
            strSQL = "SELECT vcra.vcra_id, vcra.ofc_id, vcra.vcra_commodity, hh.hh_code, hhm.hhm_number, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name " +
            "FROM ben_value_chain_register_actor vcra " +
            "INNER JOIN hh_household_member hhm ON vcra.hhm_id = hhm.hhm_id " +
            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
            "WHERE vcra.vcr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetValueChain(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT vcr.* " +
            "FROM ben_value_chain_register vcr " +
            "WHERE vcr.vcr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}