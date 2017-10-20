using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benServiceRegister
    {
        #region Variables
        #region Public
        public string svr_id = string.Empty;
        public string svr_contact_details = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benServiceRegister()
        {
            Default();
        }

        public benServiceRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            benServiceRegisterLine dalSVRL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalSVRL = new benServiceRegisterLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalSVRL.Delete(dt.Rows[intCount]["svrl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM ben_service_register WHERE svr_id = '{0}' ";
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
                dt = GetService(strId, dbCon);
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
            dt = GetService(svr_id, dbCon);
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
            svr_id = string.Empty;
            svr_contact_details = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            dst_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_service_register " +
                "(svr_id, svr_contact_details, " +
                "cso_id, dst_id, fy_id, qy_id, swk_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " + 
                "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{7}', GETDATE(), GETDATE(), '{8}','{9}') ";
            strSQL = string.Format(strSQL, svr_id, utilFormatting.StringForSQL(svr_contact_details),
                cso_id, dst_id, fy_id, qy_id, swk_id, 
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
                svr_id = dr["svr_id"].ToString();
                svr_contact_details = dr["svr_contact_details"].ToString();
                cso_id = dr["cso_id"].ToString();
                dst_id = dr["dst_id"].ToString();
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
            strSQL = "UPDATE ben_service_register " +
                "SET svr_contact_details = '{1}', " +
                "cso_id = '{2}', dst_id = '{3}', fy_id = '{4}', qy_id = '{5}', swk_id = '{6}', " + 
                "usr_id_update = '{7}', usr_date_update = GETDATE(),district_id = '{8}' " +
                "WHERE svr_id = '{0}' ";
            strSQL = string.Format(strSQL, svr_id, utilFormatting.StringForSQL(svr_contact_details),
                cso_id, dst_id, fy_id, qy_id, swk_id,
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
                        strWHERE = strWHERE + string.Format("AND svr.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND svr.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND svr.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND cso.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND svr.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT svr.svr_id, svr.ofc_id, " +
                "ISNULL(cso.cso_name, '') AS cso_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "ISNULL(dst.dst_name, '') AS dst_name, ISNULL(qy.qy_name, '') AS qy_name, ISNULL(fy.fy_name, '') AS fy_name " +
                "FROM ben_service_register svr " +
                "LEFT JOIN lst_cso cso ON svr.cso_id = cso.cso_id " +
                "LEFT JOIN lst_partner prt ON cso.prt_id = prt.prt_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON svr.dst_id = dst.dst_id " +
                "LEFT JOIN lst_financial_year fy ON svr.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON svr.qy_id = qy.qy_id " +
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
            strSQL = "SELECT svrl.svrl_id, svrl.ofc_id, hh.hh_code, hhm.hhm_number, LTRIM(RTRIM(hhm.hhm_first_name + ' ' + hhm.hhm_last_name)) AS hhm_name " +
            "FROM ben_service_register_line svrl " +
            "INNER JOIN hh_household_member hhm ON svrl.hhm_id = hhm.hhm_id " +
            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
            "WHERE svrl.svr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetService(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT svr.* " +
            "FROM ben_service_register svr " +
            "WHERE svr.svr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}