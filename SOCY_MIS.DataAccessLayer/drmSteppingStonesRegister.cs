using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class drmSteppingStonesRegister
    {
        #region Variables
        #region Public
        public string dssr_id = string.Empty;
        public string dssr_facilitator = string.Empty;
        public string dssr_group = string.Empty;
        public string dssr_village = string.Empty;
        public DateTime dssr_date = DateTime.Now;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);

        public DateTime usr_date_create = DateTime.Now;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public drmSteppingStonesRegister()
        {
            Default();
        }

        public drmSteppingStonesRegister(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            drmSteppingStonesRegisterLine dalDSSRL = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalDSSRL = new drmSteppingStonesRegisterLine();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalDSSRL.Delete(dt.Rows[intCount]["dssrl_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM drm_stepping_stones_register WHERE dssr_id = '{0}' ";
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
            dt = GetObject(dssr_id, dbCon);
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
            dssr_id = string.Empty;
            dssr_facilitator = string.Empty;
            dssr_group = string.Empty;
            dssr_village = string.Empty;
            dssr_date = DateTime.Now;
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
            strSQL = "INSERT INTO drm_stepping_stones_register " +
                "(dssr_id, " +
                "dssr_facilitator, dssr_group, dssr_village, " +
                "dssr_date, " +
                "wrd_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', " +
                "'{4}', " +
                "'{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, dssr_id,
                utilFormatting.StringForSQL(dssr_facilitator), utilFormatting.StringForSQL(dssr_group), utilFormatting.StringForSQL(dssr_village),
                dssr_date.ToString("dd MMM yyyy HH:mm:ss"), 
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
                dssr_id = dr["dssr_id"].ToString();
                dssr_facilitator = dr["dssr_facilitator"].ToString();
                dssr_group = dr["dssr_group"].ToString();
                dssr_village = dr["dssr_village"].ToString();
                dssr_date = Convert.ToDateTime(dr["dssr_date"]);
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
            strSQL = "UPDATE drm_stepping_stones_register " +
                "SET dssr_facilitator = '{1}', dssr_group = '{2}', dssr_village = '{3}', " +
                "dssr_date = '{4}', " +
                "wrd_id = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE dssr_id = '{0}' ";
            strSQL = string.Format(strSQL, dssr_id,
                utilFormatting.StringForSQL(dssr_facilitator), utilFormatting.StringForSQL(dssr_group), utilFormatting.StringForSQL(dssr_village),
                dssr_date.ToString("dd MMM yyyy HH:mm:ss"),
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
                    case "dssr_facilitator":
                        strWHERE = strWHERE + string.Format("AND dssr.dssr_facilitator = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dssr_group":
                        strWHERE = strWHERE + string.Format("AND dssr.dssr_group = '{0}' ",
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
                    case "dssr_date_from":
                        strWHERE = strWHERE + string.Format("AND dssr.dssr_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "dssr_date_to":
                        strWHERE = strWHERE + string.Format("AND dssr.dssr_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT dssr.dssr_id, dssr.ofc_id, " + 
                "dssr.dssr_facilitator, dssr.dssr_group, dssr.dssr_village, " +
                "ISNULL(wrd.wrd_name, '') AS wrd_name, " +
                "ISNULL(sct.sct_name, '') AS sct_name, " + 
                "ISNULL(dst.dst_name, '') AS dst_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), dssr.dssr_date, 106))) AS dssr_date " +
                "FROM drm_stepping_stones_register dssr " +
                "LEFT JOIN (SELECT wrd_id, wrd_name, sct_id FROM lst_ward WHERE lng_id = '{0}') wrd ON dssr.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT sct_id, sct_name, dst_id FROM lst_sub_county WHERE lng_id = '{0}') sct ON wrd.sct_id = sct.sct_id " +
                "LEFT JOIN (SELECT dst_id, dst_name FROM lst_district WHERE lng_id = '{0}') dst ON sct.dst_id = dst.dst_id " +
                strWHERE +
                "ORDER BY dssr.dssr_date DESC, dssr_facilitator ";
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
            strSQL = "SELECT DISTINCT dssr_facilitator AS fcl_id, dssr_facilitator AS fcl_name " +
                "FROM drm_stepping_stones_register " +
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
            strSQL = "SELECT DISTINCT dssr_group AS grp_id, dssr_group AS grp_name " +
                "FROM drm_stepping_stones_register " +
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
            strSQL = "SELECT ISNULL(MIN(dssr_date), GETDATE()) AS dssr_date_from, " +
                "ISNULL(MAX(dssr_date), GETDATE()) AS dssr_date_to " +
                "FROM drm_stepping_stones_register ";
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
            strSQL = "SELECT dssrl.dssrl_id, dssrl.ofc_id, dm.dm_id_no, dssrl.dssrl_contact, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, dm.dm_first_name + ' ' + dm.dm_last_name) AS dm_name " +
                "FROM drm_stepping_stones_register dssr " +
                "INNER JOIN drm_stepping_stones_register_line dssrl ON dssr.dssr_id = dssrl.dssr_id " +
                "INNER JOIN drm_member dm ON dssrl.dm_id = dm.dm_id " +
                "LEFT JOIN hh_household_member hhm ON dm.hhm_id = hhm.hhm_id " +
                "WHERE dssr.dssr_id = '{0}' ";
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
            strSQL = "SELECT dssr.* " +
            "FROM drm_stepping_stones_register dssr " +
            "WHERE dssr.dssr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}