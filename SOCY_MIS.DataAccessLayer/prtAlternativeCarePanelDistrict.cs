using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtAlternativeCarePanelDistrict
    {
        #region Variables
        #region Public
        public string acpd_id = string.Empty;
        public string acpd_support_extended = string.Empty;
        public string acp_id = utilConstants.cDFEmptyListValue;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string yn_id_established = utilConstants.cDFEmptyListValue;
        public string yn_id_functional = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtAlternativeCarePanelDistrict()
        {
            Default();
        }

        public prtAlternativeCarePanelDistrict(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM prt_alternative_care_panel_district WHERE acpd_id = '{0}' ";
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
            dt = GetObject(acpd_id, dbCon);
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
            acpd_id = string.Empty;
            acpd_support_extended = string.Empty;
            acp_id = utilConstants.cDFEmptyListValue;
            dst_id = utilConstants.cDFEmptyListValue;
            yn_id_established = utilConstants.cDFEmptyListValue;
            yn_id_functional = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_alternative_care_panel_district " +
                "(acpd_id, acpd_support_extended, " +
                "acp_id, dst_id, yn_id_established, yn_id_functional, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " +
                "'{2}', '{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, acpd_id, utilFormatting.StringForSQL(acpd_support_extended),
                acp_id, dst_id, yn_id_established, yn_id_functional,
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
                acpd_id = dr["acpd_id"].ToString();
                acpd_support_extended = dr["acpd_support_extended"].ToString();
                acp_id = dr["acp_id"].ToString();
                dst_id = dr["dst_id"].ToString();
                yn_id_established = dr["yn_id_established"].ToString();
                yn_id_functional = dr["yn_id_functional"].ToString();
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
            strSQL = "UPDATE prt_alternative_care_panel_district " +
                "SET acpd_support_extended = '{1}', " +
                "acp_id = '{2}', dst_id = '{3}', yn_id_established = '{4}', yn_id_functional = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE acpd_id = '{0}' ";
            strSQL = string.Format(strSQL, acpd_id, utilFormatting.StringForSQL(acpd_support_extended), 
                acp_id, dst_id, yn_id_established, yn_id_functional,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetObject(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT acpd.* " +
            "FROM prt_alternative_care_panel_district acpd " +
            "WHERE acpd.acpd_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}