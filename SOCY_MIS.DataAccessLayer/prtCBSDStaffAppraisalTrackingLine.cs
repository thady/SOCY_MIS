using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtCBSDStaffAppraisalTrackingLine
    {
        #region Variables
        #region Public
        public string csatl_id = string.Empty;
        public int csatl_posts_approved = 0;
        public int csatl_posts_filled = 0;
        public string csat_id = utilConstants.cDFEmptyListValue;
        public string ss_id = utilConstants.cDFEmptyListValue;
        public string yn_id_conducted = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtCBSDStaffAppraisalTrackingLine()
        {
            Default();
        }

        public prtCBSDStaffAppraisalTrackingLine(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Default()
        {
            #region Default
            csatl_id = string.Empty;
            csatl_posts_approved = 0;
            csatl_posts_filled = 0;
            csat_id = utilConstants.cDFEmptyListValue;
            ss_id = utilConstants.cDFEmptyListValue;
            yn_id_conducted = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM prt_cbsd_staff_appraisal_tracking_line WHERE csatl_id = '{0}' ";
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
            dt = GetObject(csatl_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO prt_cbsd_staff_appraisal_tracking_line " +
                "(csatl_id, " +
                "csatl_posts_approved, csatl_posts_filled, " +
                "csat_id, ss_id, yn_id_conducted, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "{1}, {2}, " +
                "'{3}', '{4}', '{5}', " +
                "'{6}', '{6}', GETDATE(), GETDATE(), '{7}','{8}') ";
            strSQL = string.Format(strSQL, csatl_id,
                csatl_posts_approved, csatl_posts_filled, 
                csat_id, ss_id, yn_id_conducted, 
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
                csatl_id = dr["csatl_id"].ToString();
                csatl_posts_approved = Convert.ToInt32(dr["csatl_posts_approved"]);
                csatl_posts_filled = Convert.ToInt32(dr["csatl_posts_filled"]);
                csat_id = dr["csat_id"].ToString();
                ss_id = dr["ss_id"].ToString();
                yn_id_conducted = dr["yn_id_conducted"].ToString();
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
            strSQL = "UPDATE prt_cbsd_staff_appraisal_tracking_line " +
                "SET csatl_posts_approved = {1}, csatl_posts_filled = {2}, " +
                "csat_id = '{3}', ss_id = '{4}', yn_id_conducted = '{5}', " +
                "usr_id_update = '{6}', usr_date_update = GETDATE(),district_id = '{7}' " +
                "WHERE csatl_id = '{0}' ";
            strSQL = string.Format(strSQL, csatl_id,
                csatl_posts_approved, csatl_posts_filled, 
                csat_id, ss_id, yn_id_conducted, 
                usr_id_update, district_id);

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
            strSQL = "SELECT csatl.* " +
            "FROM prt_cbsd_staff_appraisal_tracking_line csatl " +
            "WHERE csatl.csatl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}