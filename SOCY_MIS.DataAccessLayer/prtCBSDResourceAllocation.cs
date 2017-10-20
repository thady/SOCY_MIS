using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtCBSDResourceAllocation
    {
        #region Variables
        #region Public
        public string cra_id = string.Empty;
        public DateTime cra_date = DateTime.Now;
        public string fy_id = utilConstants.cDFEmptyListValue;
        public string prt_id = utilConstants.cDFEmptyListValue;
        public string rgn_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtCBSDResourceAllocation()
        {
            Default();
        }

        public prtCBSDResourceAllocation(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            prtCBSDResourceAllocationDistrict dalCRAD = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalCRAD = new prtCBSDResourceAllocationDistrict();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalCRAD.Delete(dt.Rows[intCount]["crad_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM prt_cbsd_resource_allocation WHERE cra_id = '{0}' ";
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
                dt = GetObject(strId, dbCon);
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
            dt = GetObject(cra_id, dbCon);
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
            cra_id = string.Empty;
            cra_date = DateTime.Now;
            fy_id = utilConstants.cDFEmptyListValue;
            prt_id = utilConstants.cDFEmptyListValue;
            rgn_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_cbsd_resource_allocation " +
                "(cra_id, cra_date, " +
                "fy_id, prt_id, rgn_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', " +
                "'{5}', '{5}', GETDATE(), GETDATE(), '{6}','{7}') ";
            strSQL = string.Format(strSQL, cra_id, cra_date.ToString("dd MMM yyyy HH:mm:ss"),
                fy_id, prt_id, rgn_id,
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
                cra_id = dr["cra_id"].ToString();
                cra_date = Convert.ToDateTime(dr["cra_date"]);
                fy_id = dr["fy_id"].ToString();
                prt_id = dr["prt_id"].ToString();
                rgn_id = dr["rgn_id"].ToString();
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
            strSQL = "UPDATE prt_cbsd_resource_allocation " +
                "SET cra_date = '{1}', " +
                "fy_id = '{2}', prt_id = '{3}', rgn_id = '{4}', " +
                "usr_id_update = '{5}', usr_date_update = GETDATE(),district_id ='{6}' " +
                "WHERE cra_id = '{0}' ";
            strSQL = string.Format(strSQL, cra_id, cra_date.ToString("dd MMM yyyy HH:mm:ss"),
                fy_id, prt_id, rgn_id,
                usr_id_update, district_id);

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
                    case "fy_id":
                        strWHERE = strWHERE + string.Format("AND cra.fy_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "prt_id":
                        strWHERE = strWHERE + string.Format("AND cra.prt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_begin":
                        strWHERE = strWHERE + string.Format("AND cra.cra_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "date_end":
                        strWHERE = strWHERE + string.Format("AND cra.cra_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT cra.cra_id, cra.ofc_id, ISNULL(fy.fy_name, '') AS fy_name, ISNULL(prt.prt_name, '') AS prt_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), cra.cra_date, 106))) AS the_date_display, " +
                "cra.cra_date AS the_date " +
                "FROM prt_cbsd_resource_allocation cra " +
                "LEFT JOIN lst_financial_year fy ON cra.fy_id = fy.fy_id " +
                "LEFT JOIN lst_partner prt ON cra.prt_id = prt.prt_id " +
                strWHERE +
                "ORDER BY prt_name, the_date DESC ";
            strSQL = string.Format(strSQL, strLngId);
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
            strSQL = "SELECT ISNULL(MIN(cra_date), GETDATE()) AS date_begin, " +
                "ISNULL(MAX(cra_date), GETDATE()) AS date_end " +
                "FROM prt_cbsd_resource_allocation ";
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
            strSQL = "SELECT crad.crad_id, crad.ofc_id, dst.dst_name " +
                "FROM prt_cbsd_resource_allocation_district crad " +
                "INNER JOIN lst_district dst ON crad.dst_id = dst.dst_id AND dst.lng_id = '{1}' " +
                "WHERE crad.cra_id = '{0}' " +
                "ORDER BY dst.dst_name ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT crad.crad_id " +
                "FROM prt_cbsd_resource_allocation_district crad " +
                "WHERE crad.cra_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT cra.* " +
            "FROM prt_cbsd_resource_allocation cra " +
            "WHERE cra.cra_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}