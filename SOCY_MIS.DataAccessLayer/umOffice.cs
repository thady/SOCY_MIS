using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class umOffice
    {
        #region Variables
        #region Public
        public string ofc_id = string.Empty;
        public string ofc_name = string.Empty;
        public string ofc_server_id = string.Empty;
        public string ofc_email = string.Empty;
        public string ofc_phone = string.Empty;
        public string ofc_address = string.Empty;
        public string ofc_app_version = "1.0";        
        public string ost_id = string.Empty;
        public string otp_id = string.Empty;
        public string usr_id_contact = string.Empty;
        public string usr_id_update = string.Empty;
        public string district_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public umOffice()
        {
            Default();
        }

        public umOffice(DBConnection dbCon)
        {
            Load(dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Load(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Office
            dt = GetOffice(dbCon);
            if (utilCollections.HasRows(dt))
            {
                Load(dt);
            }
            else
            {
                Default();
            }
            #endregion
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetOffice(dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }

        public void UpdateStatus(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE um_office " +
                " SET ost_id = '{1}' " +
                "WHERE ofc_id = '{0}' ";
            strSQL = string.Format(strSQL, ofc_id, ost_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            ofc_id = string.Empty;
            ofc_name = string.Empty;
            ofc_server_id = string.Empty;
            ofc_email = string.Empty;
            ofc_phone = string.Empty;
            ofc_address = string.Empty;
            ofc_app_version = "1.0"; 
            ost_id = utilConstants.cDFEmptyListValue;
            otp_id = utilConstants.cDFEmptyListValue;
            usr_id_contact = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO um_office " +
                "(ofc_id, ofc_name, ofc_server_id, " +
                "ofc_email, ofc_phone, ofc_address, ofc_app_version, " +
                "ost_id, otp_id, usr_id_contact, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
                "'{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}', " +
                "'{10}', '{10}'," +
                "GETDATE(), GETDATE(),'{11}')";
            strSQL = string.Format(strSQL, ofc_id, utilFormatting.StringForSQL(ofc_name), utilFormatting.StringForSQL(ofc_server_id),
                utilFormatting.StringForSQL(ofc_email), utilFormatting.StringForSQL(ofc_phone), utilFormatting.StringForSQL(ofc_address), ofc_app_version,
                ost_id, otp_id, usr_id_contact, usr_id_update,static_variables.district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        private void Load(DataTable dt)
        {
            #region Variables
            DataRow dr = null;
            #endregion Variables

            #region Set Office
            if (!utilCollections.HasRows(dt))
            {
                Default();
            }
            else
            {
                dr = dt.Rows[0];
                ofc_id = dr["ofc_id"].ToString();
                ofc_name = dr["ofc_name"].ToString();
                ofc_server_id = dr["ofc_server_id"].ToString();
                ofc_email = dr["ofc_email"].ToString();
                ofc_phone = dr["ofc_phone"].ToString();
                ofc_address = dr["ofc_address"].ToString();
                ofc_app_version = dr["ofc_app_version"].ToString();
                ost_id = dr["ost_id"].ToString();
                otp_id = dr["otp_id"].ToString();
                usr_id_contact = dr["usr_id_contact"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
            }
            #endregion Set Office
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE um_office " +
                " SET ofc_name = '{1}', ofc_server_id = '{2}', " +
                "ofc_email = '{3}', ofc_phone = '{4}', ofc_address = '{5}', ofc_app_version = '{6}', " +
                "ost_id = '{7}', otp_id = '{8}', usr_id_contact = '{9}', " +
                "usr_id_update = '{10}', usr_date_update = GETDATE() ,district_id = '{11}'" +
                "WHERE ofc_id = '{0}' ";
            strSQL = string.Format(strSQL, ofc_id, utilFormatting.StringForSQL(ofc_name), utilFormatting.StringForSQL(ofc_server_id),
                utilFormatting.StringForSQL(ofc_email), utilFormatting.StringForSQL(ofc_phone), utilFormatting.StringForSQL(ofc_address), ofc_app_version, 
                ost_id, otp_id, usr_id_contact, usr_id_update,Convert.ToInt32( static_variables.district_id));

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        private DataTable GetOffice(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT ofc.* FROM um_office ofc ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion
    }
}
