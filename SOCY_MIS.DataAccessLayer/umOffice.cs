using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;
using System.Data.SqlClient;

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
            string strSQL = string.Empty;
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

           // updateUploadTableDistrictID();
        }

        protected void updateUploadTableDistrictID()
        {
            #region Variables
            string strSQL = string.Empty;
            DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            #endregion Variables
            if (ReturnYouthGroups() > 19)
            {
                #region Update district id in upload tables
                strSQL = "UPDATE ben_activity_training_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_assessment_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_activity_training_participant_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_apprenticeship_register_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_girl_education_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_girl_education_register_child_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_service_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_service_register_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_service_register_line_social_economic_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_value_chain_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE ben_value_chain_register_actor_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_enrollment_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_enrollment_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_enrollment_member_segment_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_enrollment_member_visit_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_htc_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_partner_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_partner_tracking_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_partner_tracking_service_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_post_violence_care_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_post_violence_care_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_post_violence_care_line_dreams_service_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_post_violence_care_line_service_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_sinovuyo_missed_session_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_sinovuyo_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_sinovuyo_register_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_stepping_stones_missed_session_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_stepping_stones_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE drm_stepping_stones_register_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_home_visit_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_home_visit_service_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_home_visit_service_previous_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_assessment_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_assessment_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_home_visit_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_household_home_visit_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_ovc_identification_prioritization_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE hh_referral_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  [dbo].[hh_referral_service_provided_upload] SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  hh_referral_service_referred_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_alternative_care_panel_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_alternative_care_panel_district_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_cbsd_resource_allocation_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_cbsd_resource_allocation_district_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_cbsd_staff_appraisal_tracking_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_cbsd_staff_appraisal_tracking_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_district_ovc_checklist_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_institutional_care_summary_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_institutional_care_summary_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  prt_institutional_care_summary_line_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_financial_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_financial_register_group_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_group_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_group_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_savings_register_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  silc_savings_register_member_upload SET district_id = '" + static_variables.district_id + "'";
                dbCon.ExecuteNonQuery(strSQL);
                strSQL = "UPDATE  swm_social_worker_upload SET district_id = '" + static_variables.district_id + "'";
                //dbCon.ExecuteNonQuery(strSQL);
                #endregion Update district id in upload tables
            }
        }

        public static int ReturnYouthGroups()
        {
            #region Variables
            DataTable dt = new DataTable();
            string SQL = string.Empty;
            DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
            SqlConnection conn = new SqlConnection(SQLConnection);
            string dbName = conn.Database;
            int columnCount = 0;
            #endregion Variables

            try
            {

                SQL = "SELECT COUNT(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_CATALOG = '"+ dbName +"' AND TABLE_SCHEMA = 'dbo'  AND TABLE_NAME = 'ben_activity_training_upload'";

                using (conn)
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    columnCount = (int)cmd.ExecuteScalar();

                    cmd.Parameters.Clear();

                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }

            finally
            {
                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }

            return columnCount;
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
                ost_id, otp_id, usr_id_contact, usr_id_update,static_variables.district_id);

            dbCon.ExecuteNonQuery(strSQL);

            //updateUploadTableDistrictID();

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
