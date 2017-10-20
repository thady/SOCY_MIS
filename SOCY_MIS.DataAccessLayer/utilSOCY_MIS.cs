using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;

namespace SOCY_MIS.DataAccessLayer
{
    public class utilSOCY_MIS
    {
        #region Data Ownership
        public void CheckDataOwnership(string strId, string strTable, string strPrefix, bool blnManage, Button btn01, DataAccessLayer.DBConnection dbCon)
        {
            CheckDataOwnership(strId, strTable, strPrefix, blnManage, btn01, null, null, dbCon);
        }

        public void CheckDataOwnership(string strId, string strTable, string strPrefix, bool blnManage, Button btn01, Button btn02, DataAccessLayer.DBConnection dbCon)
        {
            CheckDataOwnership(strId, strTable, strPrefix, blnManage, btn01, btn02, null, dbCon);
        }

        public void CheckDataOwnership(string strId, string strTable, string strPrefix, bool blnManage, Button btn01, Button btn02, Button btn03, DataAccessLayer.DBConnection dbCon)
        {
            #region Variables
            #endregion Variables

            #region Set Controls
            #endregion Set
        }
        #endregion Data Ownership

        #region DataTable
        public DataTable BlankDataTable(string strValue, string strDisplay, string strEmptyItemValue, string strEmptyItemText)
        {
            #region Variables
            DataTable dt = new DataTable();
            DataRow dr = null;
            #endregion Variables

            #region Create Table
            dt.Columns.Add(new DataColumn(strValue));
            dt.Columns.Add(new DataColumn(strDisplay));
            dr = dt.NewRow();
            dr[strValue] = strEmptyItemValue;
            dr[strDisplay] = strEmptyItemText;

            dt.Rows.Add(dr);
            dt.AcceptChanges();
            #endregion Create Table

            return dt;
        }
        #endregion DataTable

        #region District, Sub County and Ward
        #region Public Methods
        public DataTable GetDistrictParents(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dst.rgn_id " +
                "FROM lst_district dst " +
                "WHERE dst.dst_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDistrictByParents(string strRgnId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dst.dst_id AS lt_id, dst.dst_name AS lt_name " +
                "FROM lst_district dst " +
                "WHERE dst.lng_id = '{0}' ";
            if (strRgnId.Length != 0)
                strSQL = strSQL + "AND dst.rgn_id = '" + strRgnId + "' ";
            strSQL = strSQL + "ORDER BY lt_name ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetSubCountyParents(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT sct.dst_id, dst.rgn_id " +
                "FROM lst_sub_county sct " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "WHERE sct.sct_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetSubCountyParentsWithNames(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT dst.dst_id, dst.dst_name, rgn.rgn_id, rgn.rgn_name " +
                "FROM lst_sub_county sct " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "INNER JOIN lst_region rgn ON dst.rgn_id = rgn.rgn_id " +
                "WHERE sct.sct_id = '{0}' " +
                "AND sct.lng_id = '{1}' AND dst.lng_id = '{1}' AND rgn.lng_id = '{1}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetSubCountyByParents(string strRgnId, string strDstId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT sct.sct_id AS lt_id, sct.sct_name AS lt_name " +
                "FROM lst_sub_county sct " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "WHERE sct.lng_id = '{0}' ";
            if (strDstId.Length != 0)
                strSQL = strSQL + "AND sct.dst_id = '" + strDstId + "' ";
            if (strRgnId.Length != 0)
                strSQL = strSQL + "AND dst.rgn_id = '" + strRgnId + "' ";
            strSQL = strSQL + "ORDER BY lt_name ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetWardParents(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT sct.sct_id, sct.dst_id, dst.rgn_id " +
                "FROM lst_ward wrd " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "WHERE wrd.wrd_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetWardParentsWithNames(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT sct.sct_id, sct.sct_name, dst.dst_id, dst.dst_name, rgn.rgn_id, rgn.rgn_name " +
                "FROM lst_ward wrd " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "INNER JOIN lst_region rgn ON dst.rgn_id = rgn.rgn_id " +
                "WHERE wrd.wrd_id = '{0}' " +
                "AND wrd.lng_id = '{1}' AND sct.lng_id = '{1}' AND dst.lng_id = '{1}' AND rgn.lng_id = '{1}' ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetWardByParents(string strRgnId, string strDstId, string strSctId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT wrd.wrd_id AS lt_id, wrd.wrd_name AS lt_name " +
                "FROM lst_ward wrd " +
                "INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id " +
                "INNER JOIN lst_district dst ON sct.dst_id = dst.dst_id " +
                "WHERE wrd.lng_id = '{0}' ";
            if (strDstId.Length != 0)
                strSQL = strSQL + "AND sct.dst_id = '" + strDstId + "' ";
            if (strSctId.Length != 0)
                strSQL = strSQL + "AND sct.sct_id = '" + strSctId + "' ";
            if (strRgnId.Length != 0)
                strSQL = strSQL + "AND dst.rgn_id = '" + strRgnId + "' ";
            strSQL = strSQL + "ORDER BY lt_name ";
            strSQL = string.Format(strSQL, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public void LoadListsArea(string strDstId, string strSctId,
            ComboBox cbDistrict, ComboBox cbSubCounty,
            string strLngId, DBConnection dbCon)
        {
            LoadListsArea("", strDstId, strSctId, "",
                null, cbDistrict, cbSubCounty, null,
                strLngId, dbCon);
        }

        public void LoadListsArea(string strDstId, string strSctId, string strWrdId,
            ComboBox cbDistrict, ComboBox cbSubCounty, ComboBox cbWard,
            string strLngId, DBConnection dbCon)
        {
            LoadListsArea("", strDstId, strSctId, strWrdId,
                null, cbDistrict, cbSubCounty, cbWard,
                strLngId, dbCon);
        }

        public void LoadListsArea(string strRgnId, string strDstId, string strSctId, string strWrdId,
            ComboBox cbRegion, ComboBox cbDistrict, ComboBox cbSubCounty, ComboBox cbWard,
            string strLngId, DBConnection dbCon)
        {
            #region Variables
            utilLanguageTranslation utilLT = null;
            utilListTable uLT = null;

            DataTable dt = null;
            string strEmptySingleSelect = string.Empty;
            #endregion Variables

            utilLT = new utilLanguageTranslation();
            utilLT.Language = strLngId;
            strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

            #region Get Parent Values
            if (strWrdId.Length != 0 && !strWrdId.Equals(utilConstants.cDFEmptyListValue))
            {
                dt = GetWardParents(strWrdId, dbCon);
                if (utilCollections.HasRows(dt))
                {
                    strSctId = dt.Rows[0]["sct_id"].ToString();
                    strDstId = dt.Rows[0]["dst_id"].ToString();
                    if(cbRegion != null)
                        strRgnId = dt.Rows[0]["rgn_id"].ToString();
                }
                else
                {
                    strWrdId = string.Empty;
                    strSctId = string.Empty;
                    strDstId = string.Empty;
                    strRgnId = string.Empty;
                }
            }
            else if (strSctId.Length != 0 && !strSctId.Equals(utilConstants.cDFEmptyListValue))
            {
                dt = GetSubCountyParents(strSctId, dbCon);
                if (utilCollections.HasRows(dt))
                {
                    strDstId = dt.Rows[0]["dst_id"].ToString();
                    if (cbRegion != null)
                        strRgnId = dt.Rows[0]["rgn_id"].ToString();
                }
                else
                {
                    strSctId = string.Empty;
                    strDstId = string.Empty;
                    strRgnId = string.Empty;
                }
                strWrdId = string.Empty;
            }
            else if (strDstId.Length != 0 && !strDstId.Equals(utilConstants.cDFEmptyListValue))
            {
                dt = GetDistrictParents(strDstId, dbCon);
                if (utilCollections.HasRows(dt))
                {
                    if (cbRegion != null)
                        strRgnId = dt.Rows[0]["rgn_id"].ToString();
                }
                else
                {
                    strDstId = string.Empty;
                    strRgnId = string.Empty;
                }
                strWrdId = string.Empty;
                strSctId = string.Empty;
            }
            else if (strRgnId.Length != 0 && !strRgnId.Equals(utilConstants.cDFEmptyListValue))
            {
                strWrdId = string.Empty;
                strSctId = string.Empty;
                strDstId = string.Empty;
            }
            else
            {
                strWrdId = string.Empty;
                strSctId = string.Empty;
                strDstId = string.Empty;
                strRgnId = string.Empty;
            }
            #endregion Get Parent Values

            #region Load Lists
            uLT = new utilListTable();

            if (cbRegion != null)
            {
                dt = uLT.GetData("lst_region", true, strRgnId, strLngId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRegion, dt, "lt_id", "lt_name");

                if (strRgnId.Length != 0)
                    cbRegion.SelectedValue = strRgnId;
                else
                    cbRegion.SelectedIndex = 0;
            }

            if (cbDistrict != null)
            {
                dt = GetDistrictByParents(strRgnId, strLngId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");

                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
            }

            if (cbSubCounty != null)
            {
                dt = GetSubCountyByParents(strRgnId, strDstId, strLngId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbSubCounty, dt, "lt_id", "lt_name");

                if (strSctId.Length != 0)
                    cbSubCounty.SelectedValue = strSctId;
                else
                    cbSubCounty.SelectedIndex = 0;
            }

            if (cbWard != null)
            {
                dt = GetWardByParents(strRgnId, strDstId, strSctId, strLngId, dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbWard, dt, "lt_id", "lt_name");

                if (strWrdId.Length != 0)
                    cbWard.SelectedValue = strWrdId;
                else
                    cbWard.SelectedIndex = 0;
            }
            #endregion Load Lists
        }
        #endregion Public Methods
        #endregion District, Sub County and Ward

        #region CSO and Partner/Region
        #region Private Methods
        private DataTable GetCSOByParents(string strPrtId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT cso.cso_id AS lt_id, cso.cso_name AS lt_name " +
                "FROM lst_cso cso ";
            if (strPrtId.Length != 0)
                strSQL = strSQL + "WHERE cso.prt_id = '" + strPrtId + "' ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetCSOParent(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT cso.prt_id " +
                "FROM lst_cso cso " +
                "WHERE cso.cso_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private Methods

        #region Public Methods
        public DataTable GetListParentCSO(bool blnActiveOnly, string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = strSQL + "SELECT prt_id AS lt_id, prt_name AS lt_name, '1' AS lt_order FROM lst_partner ";
            if (blnActiveOnly)
                strSQL = strSQL + "WHERE prt_active = 1 ";
            strSQL = strSQL + "UNION SELECT cso_id AS lt_id, cso_name AS lt_name, '2' AS lt_order FROM lst_cso ";
            if (blnActiveOnly)
                strSQL = strSQL + "WHERE cso_active = 1 ";
            if (strId.Length != 0)
            {
                strSQL = strSQL + string.Format("UNION SELECT prt_id AS lt_id, prt_name AS lt_name, '1' AS lt_order FROM lst_partner WHERE prt_id = '{0}' " +
                    "UNION SELECT cso_id AS lt_id, cso_name AS lt_name, '2' AS lt_order FROM lst_cso WHERE cso_id = '{0}' ", strId);
            }
            strSQL = strSQL + "ORDER BY lt_order, lt_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public void LoadListsOrganization(string strPrtId, string strCsoId,
            ComboBox cbPartner, ComboBox cbCSO, 
            string strLngId, DBConnection dbCon)
        {
            #region Variables
            utilLanguageTranslation utilLT = null;
            utilListTable uLT = null;

            DataTable dt = null;
            string strEmptySingleSelect = string.Empty;
            #endregion Variables

            utilLT = new utilLanguageTranslation();
            utilLT.Language = strLngId;
            strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

            #region Get Parent Values
            if (strCsoId.Length != 0)
            {
                dt = GetCSOParent(strCsoId, dbCon);
                if (utilCollections.HasRows(dt))
                {
                    strPrtId = dt.Rows[0]["prt_id"].ToString();
                }
                else
                {
                    strCsoId = string.Empty;
                    strPrtId = string.Empty;
                }
            }
            else if (strPrtId.Length != 0)
            {
                strCsoId = string.Empty;
            }
            #endregion Get Parent Values

            #region Load Lists
            uLT = new utilListTable();

            dt = uLT.GetData("lst_partner", true, strPrtId, false, dbCon.dbCon);
            dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
            utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");

            dt = GetCSOByParents(strPrtId, dbCon);
            dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
            utilControls.ComboBoxFill(cbCSO, dt, "lt_id", "lt_name");
            #endregion Load Lists

            #region Set List Selection
            if (strPrtId.Length != 0)
                cbPartner.SelectedValue = strPrtId;
            else
                cbPartner.SelectedIndex = 0;
            if (strCsoId.Length != 0)
                cbCSO.SelectedValue = strCsoId;
            else
                cbCSO.SelectedIndex = 0;
            #endregion Set List Selection
        }
        #endregion Public Methods
        #endregion CSO and Partner/Region

        #region District and Region
        public DataTable GetParentRegion(string strDstId, string strRgnId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT DISTINCT rgn.rgn_id AS rgn_id " +
                "FROM lst_region rgn ";
            if (strDstId.Length != 0)
                strSQL = strSQL + "INNER JOIN lst_district dst ON rgn.rgn_id = dst.rgn_id AND dst.dst_id = '" + strDstId + "' ";
            if (strRgnId.Length != 0)
                strSQL = strSQL + "WHERE rgn.rgn_id = '" + strRgnId + "' ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion District and Region

        #region District
        public DataTable GetDistrictForForm(string strRgnId, string strDstId, string strFormTable, string strFormPrefix, string strObjId, string strMemberField, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region SQL
            strSQLSelect = string.Format("SELECT dst.dst_id AS lt_id, dst.dst_name AS lt_name " +
                "FROM lst_district dst " +
                "WHERE dst.lng_id = '{0}' ", strLngId);
            if (strRgnId.Length != 0)
                strSQLSelect = strSQLSelect + string.Format("AND dst.rgn_id = '{0}' ", strRgnId);
            strSQL = strSQLSelect + string.Format("AND NOT dst.dst_id IN (SELECT {3} FROM {0} {1} WHERE {1}.{1}_id = '{2}') ", strFormTable, strFormPrefix, strObjId, strMemberField);
            if (strDstId.Length != 0)
                strSQL = strSQL + "UNION " + strSQLSelect + string.Format("AND dst.dst_id = '{0}' ", strDstId);
            strSQL = strSQL + "ORDER BY lt_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion District

        #region Months
        public static DataTable GetMonths()
        {
            #region Variables
            DataRow dr = null;
            DataTable dt = new DataTable();
            #endregion Variables

            #region Create Columns
            dt.Columns.Add(new DataColumn("lt_id"));
            dt.Columns.Add(new DataColumn("lt_name"));
            #endregion Create Columns

            #region Create Rows
            for (int intCount = 1; intCount <= 12; intCount++)
            {
                dr = dt.NewRow();
                dr["lt_id"] = intCount.ToString();
                dr["lt_name"] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(intCount);
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            #endregion Create Rows

            return dt;
        }
        #endregion Months

        #region List Value
        public string GetListItemValue(string strId, string strTable, string strPrefix, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strResult = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT {2}_name AS lt_name " +
                "FROM {1} " +
                "WHERE {2}_id = '{0}' ", strId, strTable, strPrefix);
            if (strLngId.Length != 0)
                strSQL = strSQL + string.Format("AND lng_id = '{0}' ", strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            if(utilCollections.HasRows(dt))
                strResult = dt.Rows[0]["lt_name"].ToString();

            return strResult;
        }
        #endregion List Value
    }
}
