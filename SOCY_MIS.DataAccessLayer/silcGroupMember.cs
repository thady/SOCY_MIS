using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class silcGroupMember
    {
        #region Variables
        #region Public
        public string sgm_id = string.Empty;
        public string sgm_name = string.Empty;
        public string sgm_status_reason = string.Empty;
        public int sgm_active = utilConstants.cDFActive;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string mtp_id = utilConstants.cDFEmptyListValue;
        public string sg_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public silcGroupMember()
        {
            Default();
        }

        public silcGroupMember(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM  WHERE at_id = '{0}' ";
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
                dt = GetMember(strId, dbCon);
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
            dt = GetMember(sgm_id, dbCon);
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
            sgm_id = string.Empty;
            sgm_name = string.Empty;
            sgm_status_reason = string.Empty;
            sgm_active = utilConstants.cDFActive;
            hhm_id = utilConstants.cDFEmptyListValue;
            mtp_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO silc_group_member " +
                "(sgm_id, sgm_name, " +
		        "sgm_status_reason, sgm_active, " +
                "hhm_id, mtp_id, sg_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', " + 
                "'{2}', {3}, " +
                "'{4}', '{5}', '{6}', " +
                "'{7}', '{7}', GETDATE(), GETDATE(), '{8}','{9}') ";
            strSQL = string.Format(strSQL, sgm_id, utilFormatting.StringForSQL(sgm_name),
                utilFormatting.StringForSQL(sgm_status_reason), sgm_active,
                hhm_id, mtp_id, sg_id, 
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
                sgm_id = dr["sgm_id"].ToString();
                sgm_name = dr["sgm_name"].ToString();
                sgm_status_reason = dr["sgm_status_reason"].ToString();
                sgm_active = Convert.ToInt32(dr["sgm_active"]);
                hhm_id = dr["hhm_id"].ToString();
                mtp_id = dr["mtp_id"].ToString();
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
            strSQL = "UPDATE silc_group_member " +
                "SET sgm_name = '{1}', " +
                "sgm_status_reason = '{2}', sgm_active = {3}, " +
                "hhm_id = '{4}', mtp_id = '{5}', sg_id = '{6}', " +
                "usr_id_update = '{7}', usr_date_update = GETDATE(),district_id = '{8}' " +
                "WHERE sgm_id = '{0}' ";
            strSQL = string.Format(strSQL, sgm_id, utilFormatting.StringForSQL(sgm_name),
                utilFormatting.StringForSQL(sgm_status_reason), sgm_active,
                hhm_id, mtp_id, sg_id,
                usr_id_update,district_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetMember(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT sgm.* " +
            "FROM silc_group_member sgm " +
            "WHERE sgm.sgm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
