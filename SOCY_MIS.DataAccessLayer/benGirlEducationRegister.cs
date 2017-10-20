using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benGirlEducationRegister
    {
        #region Variables
        #region Public
        public string ger_id = string.Empty;
        public string ger_contact_details = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string qy_id = utilConstants.cDFEmptyListValue;
        public string sct_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = int.Parse(static_variables.district_id); 
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benGirlEducationRegister()
        {
            Default();
        }

        public benGirlEducationRegister(string strId, DBConnection dbCon)
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
                    dalGERC.Delete(dt.Rows[intCount]["gerc_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM ben_girl_education_register WHERE ger_id = '{0}' ";
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
                dt = GetRegister(strId, dbCon);
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
            dt = GetRegister(ger_id, dbCon);
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
            ger_id = string.Empty;
            ger_contact_details = string.Empty;
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
            strSQL = "INSERT INTO ben_girl_education_register " +
                "(ger_id, ger_contact_details, " +
                "cso_id, fy_id, qy_id, sct_id, swk_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{7}', GETDATE(), GETDATE(), '{8}','{9}') ";
            strSQL = string.Format(strSQL, ger_id, utilFormatting.StringForSQL(ger_contact_details),
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
                ger_id = dr["ger_id"].ToString();
                ger_contact_details = dr["ger_contact_details"].ToString();
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
            strSQL = "UPDATE ben_girl_education_register " +
                "SET ger_contact_details = '{1}', cso_id = '{2}', fy_id = '{3}', qy_id = '{4}', sct_id = '{5}', swk_id = '{6}', " +
                "usr_id_update = '{7}', usr_date_update = GETDATE(),district_id = '{8}' " +
                "WHERE ger_id = '{0}' ";
            strSQL = string.Format(strSQL, ger_id, utilFormatting.StringForSQL(ger_contact_details),
                cso_id, fy_id, qy_id, sct_id, swk_id, usr_id_update, district_id);


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
                        strWHERE = strWHERE + string.Format("AND ger.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND ger.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND cso.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "qy_id":
                        strWHERE = strWHERE + string.Format("AND ger.qy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND ger.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT ger.ger_id, ger.ofc_id, " +
                "ISNULL(cso.cso_name, '') AS cso_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "ISNULL(sct.sct_name, '') AS sct_name, ISNULL(dst.dst_name, '') AS dst_name, " +
                "ISNULL(fy.fy_name, '') AS fy_name, ISNULL(qy.qy_name, '') AS qy_name " +
                "FROM ben_girl_education_register ger " +
                "LEFT JOIN (SELECT cso_id, cso_name, prt_id FROM lst_cso) cso ON ger.cso_id = cso.cso_id " +
                "LEFT JOIN (SELECT prt_id, prt_name FROM lst_partner) prt ON cso.prt_id = prt.prt_id " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON ger.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                "LEFT JOIN lst_financial_year fy ON ger.fy_id = fy.fy_id " +
                "LEFT JOIN lst_quarter_year qy ON ger.qy_id = qy.qy_id " +
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
            strSQL = "SELECT gerc.gerc_id, gerc.ofc_id, hh.hh_code, hhm.hhm_number, hhm.hhm_first_name + ' ' + hhm.hhm_last_name AS hhm_name " +
            "FROM ben_girl_education_register_child gerc " +
            "INNER JOIN hh_household_member hhm ON gerc.hhm_id = hhm.hhm_id " +
            "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
            "WHERE gerc.ger_id = '{0}' ";
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
            strSQL = "SELECT ger.* " +
            "FROM ben_girl_education_register ger " +
            "WHERE ger.ger_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}