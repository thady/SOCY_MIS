using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcSavingsRegister
    {
        #region Variables
        #region Public
        public string ssr_id = string.Empty;
        public string ssr_cycle_number = string.Empty;
        public decimal ssr_share_value = 0;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string sg_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcSavingsRegister()
        {
            Default();
        }

        public silcSavingsRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            silcSavingsRegisterMember dalSSRM = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalSSRM = new silcSavingsRegisterMember();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalSSRM.Delete(dt.Rows[intCount]["ssrm_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM silc_savings_register WHERE ssr_id = '{0}' ";
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
            dt = GetRegister(ssr_id, dbCon);
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
            ssr_id = string.Empty;
            ssr_cycle_number = string.Empty;
            ssr_share_value = 0;
            cso_id = utilConstants.cDFEmptyListValue;
            fy_id = utilConstants.cDFEmptyListValue;
            qy_id = utilConstants.cDFEmptyListValue;
            wrd_id = utilConstants.cDFEmptyListValue;
            sg_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO silc_savings_register " +
                "(ssr_id, ssr_cycle_number, ssr_share_value, " +
                "cso_id, fy_id, qy_id, wrd_id, sg_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', {2},  " +
                "'{3}', '{4}', '{5}', '{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, ssr_id, utilFormatting.StringForSQL(ssr_cycle_number), ssr_share_value,
                cso_id, fy_id, qy_id, wrd_id, sg_id, 
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
                ssr_id = dr["ssr_id"].ToString();
                ssr_cycle_number = dr["ssr_cycle_number"].ToString();
                ssr_share_value = Convert.ToDecimal(dr["ssr_share_value"]);
                cso_id = dr["cso_id"].ToString();
                fy_id = dr["fy_id"].ToString();
                qy_id = dr["qy_id"].ToString();
                wrd_id = dr["wrd_id"].ToString();
                sg_id = dr["sg_id"].ToString();
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
            strSQL = "UPDATE silc_savings_register " +
                "SET ssr_cycle_number = '{1}', ssr_share_value = {2}, " +
                "cso_id = '{3}', fy_id = '{4}', qy_id = '{5}', wrd_id = '{6}', sg_id = '{7}', " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE ssr_id = '{0}' ";
            strSQL = string.Format(strSQL, ssr_id, utilFormatting.StringForSQL(ssr_cycle_number), ssr_share_value,
                cso_id, fy_id, qy_id, wrd_id, sg_id,
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
                        strWHERE = strWHERE + string.Format("AND ssr.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND ssr.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND ssr.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sg_id":
                        strWHERE = strWHERE + string.Format("AND ssr.sg_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "wrd_id":
                        strWHERE = strWHERE + string.Format("AND ssr.wrd_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT ssr.ssr_id, ssr.ofc_id, " +
                "ISNULL(cso.cso_name, '') AS cso_name, ISNULL(sg.sg_name, '') AS sg_name, " +
                "ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name, " +
                "ISNULL(dst.dst_name, '') AS dst_name, ISNULL(sct.sct_name, '') AS sct_name, ISNULL(wrd.wrd_name, '') AS wrd_name " +
                "FROM silc_savings_register ssr " +
                "LEFT JOIN lst_cso cso ON ssr.cso_id = cso.cso_id " +
                "LEFT JOIN lst_financial_year fy ON ssr.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON ssr.qy_id = qy.qy_id " +
                "LEFT JOIN (SELECT cso_id, cso_name FROM lst_cso) cso ON ssr.cso_id = cso.cso_id " +
                "LEFT JOIN (SELECT sg_id, sg_name FROM silc_group) sg ON ssr.sg_id = sg.sg_id " +
                "LEFT JOIN (SELECT wrd_id, wrd_name, sct_id FROM lst_ward WHERE lng_id = '{0}') wrd ON ssr.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON wrd.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                strWHERE +
                "ORDER BY sg_name ";
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
            strSQL = "SELECT ssrm.ssrm_id " +
                "FROM silc_savings_register_member ssrm " +
                "WHERE ssrm.ssr_id = '{0}' ";
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
            strSQL = "SELECT ssrm.ssrm_id, ssrm.ofc_id, sgm.sgm_id, ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, sgm.sgm_name) AS member_name, mtp.mtp_id, mtp.mtp_name " +
                "FROM silc_savings_register_member ssrm " +
                "INNER JOIN silc_group_member sgm ON ssrm.sgm_id = sgm.sgm_id " +
                "INNER JOIN lst_member_type mtp ON sgm.mtp_id = mtp.mtp_id AND mtp.lng_id = '{1}' " +
                "LEFT JOIN hh_household_member hhm ON sgm.hhm_id = hhm.hhm_id " +
                "WHERE ssrm.ssr_id = '{0}' " +
                "ORDER BY member_name  ";
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
            strSQL = "SELECT ssr.* " +
            "FROM silc_savings_register ssr " +
            "WHERE ssr.ssr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}