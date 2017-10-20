using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmSinovuyoRegister
    {
        #region Variables
        #region Public
        public string dsr_id = string.Empty;
        public string dsr_facilitator = string.Empty;
        public string dsr_group = string.Empty;
        public string dsr_village = string.Empty;
        public DateTime dsr_date = DateTime.Now;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public DateTime usr_date_create = DateTime.Now;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmSinovuyoRegister()
        {
            Default();
        }

        public drmSinovuyoRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            drmSinovuyoRegisterLine dalDRSL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalDRSL = new drmSinovuyoRegisterLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalDRSL.Delete(dt.Rows[intCount]["dsrl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM drm_sinovuyo_register WHERE dsr_id = '{0}' ";
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
                dt = GetObject(strId, dbCon);
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
            dt = GetObject(dsr_id, dbCon);
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
            dsr_id = string.Empty;
            dsr_facilitator = string.Empty;
            dsr_group = string.Empty;
            dsr_village = string.Empty;
            dsr_date = DateTime.Now;
            wrd_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO drm_sinovuyo_register " +
                "(dsr_id, " +
                "dsr_facilitator, dsr_group, dsr_village, " +
                "dsr_date, " +
                "wrd_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', " +
                "'{4}', " +
                "'{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, dsr_id,
                utilFormatting.StringForSQL(dsr_facilitator), utilFormatting.StringForSQL(dsr_group), utilFormatting.StringForSQL(dsr_village),
                dsr_date.ToString("dd MMM yyyy HH:mm:ss"), 
                wrd_id, 
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
                dsr_id = dr["dsr_id"].ToString();
                dsr_facilitator = dr["dsr_facilitator"].ToString();
                dsr_group = dr["dsr_group"].ToString();
                dsr_village = dr["dsr_village"].ToString();
                dsr_date = Convert.ToDateTime(dr["dsr_date"]);
                wrd_id = dr["wrd_id"].ToString();                
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                usr_date_create = Convert.ToDateTime(dr["usr_date_create"]);
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE drm_sinovuyo_register " +
                "SET dsr_facilitator = '{1}', dsr_group = '{2}', dsr_village = '{3}', " +
                "dsr_date = '{4}', " +
                "wrd_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE dsr_id = '{0}' ";
            strSQL = string.Format(strSQL, dsr_id,
                utilFormatting.StringForSQL(dsr_facilitator), utilFormatting.StringForSQL(dsr_group), utilFormatting.StringForSQL(dsr_village),
                dsr_date.ToString("dd MMM yyyy HH:mm:ss"),
                wrd_id, 
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
                    case "dsr_facilitator":
                        strWHERE = strWHERE + string.Format("AND dsr.dsr_facilitator = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dsr_group":
                        strWHERE = strWHERE + string.Format("AND dsr.dsr_group = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND dst.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "wrd_id":
                        strWHERE = strWHERE + string.Format("AND wrd.wrd_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dsr_date_from":
                        strWHERE = strWHERE + string.Format("AND dsr.dsr_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dsr_date_to":
                        strWHERE = strWHERE + string.Format("AND dsr.dsr_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT dsr.dsr_id, dsr.ofc_id, " + 
                "dsr.dsr_facilitator, dsr.dsr_group, dsr.dsr_village, " +
                "ISNULL(wrd.wrd_name, '') AS wrd_name, " +
                "ISNULL(sct.sct_name, '') AS sct_name, " + 
                "ISNULL(dst.dst_name, '') AS dst_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), dsr.dsr_date, 106))) AS dsr_date " +
                "FROM drm_sinovuyo_register dsr " +
                "LEFT JOIN (SELECT wrd_id, wrd_name, sct_id FROM lst_ward WHERE lng_id = '{0}') wrd ON dsr.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON wrd.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                strWHERE +
                "ORDER BY dsr.dsr_date DESC, dsr_facilitator ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetFacilitator(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dsr_facilitator AS fcl_id, dsr_facilitator AS fcl_name " +
                "FROM drm_sinovuyo_register " +
                "ORDER BY fcl_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetGroup(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dsr_group AS grp_id, dsr_group AS grp_name " +
                "FROM drm_sinovuyo_register " +
                "ORDER BY grp_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDateRange(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ISNULL(MIN(dsr_date), GETDATE()) AS dsr_date_from, " +
                "ISNULL(MAX(dsr_date), GETDATE()) AS dsr_date_to " +
                "FROM drm_sinovuyo_register ";
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
            strSQL = "SELECT dsrl.dsrl_id, dsrl.ofc_id, dm.dm_id_no, dsrl.dsrl_contact, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dm.dm_first_name + ' ' + dm.dm_last_name) AS dm_name " +
                "FROM drm_sinovuyo_register dsr " +
                "INNER JOIN drm_sinovuyo_register_line dsrl ON dsr.dsr_id = dsrl.dsr_id " +
                "INNER JOIN drm_member dm ON dsrl.dm_id = dm.dm_id " +
                "LEFT JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dsr.dsr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
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
            strSQL = "SELECT dsr.* " +
            "FROM drm_sinovuyo_register dsr " +
            "WHERE dsr.dsr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}