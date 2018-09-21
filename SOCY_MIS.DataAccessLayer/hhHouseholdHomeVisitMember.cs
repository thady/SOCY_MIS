using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdHomeVisitMember
    {
        #region Variables
        #region Public
        public string hhvm_id = string.Empty;
        public string hhm_id = string.Empty;
        public string hhv_id = string.Empty;
        public string hst_id = string.Empty;
        public string yn_id_hhm_active = string.Empty;
        public string yn_id_edu_sensitised = string.Empty;
        public string yn_id_es_aflateen = string.Empty;
        public string yn_id_es_agro = string.Empty;
        public string yn_id_es_apprenticeship = string.Empty;
        public string yn_id_es_silc = string.Empty;
        public string yn_id_fsn_nutrition = string.Empty;
        public string yn_id_fsn_referred = string.Empty;
        public string yn_id_fsn_wash = string.Empty;
        public string ynna_id_edu_enrolled = string.Empty;
        public string ynna_id_edu_support = string.Empty;
        public string ynna_id_fsn_education = string.Empty;
        public string ynna_id_fsn_support = string.Empty;
        public string ynna_id_hhp_adhering = string.Empty;
        public string ynna_id_hhp_art = string.Empty;
        public string ynna_id_hhp_referred = string.Empty;
        public string ynna_id_pro_birth_certificate = string.Empty;
        public string ynna_id_pro_birth_registration = string.Empty;
        public string ynna_id_pro_child_abuse = string.Empty;
        public string ynna_id_pro_child_labour = string.Empty;
        public string ynna_id_pro_reintegrated = string.Empty;
        public string ynna_id_ps_parenting = string.Empty;
        public string ynna_id_ps_support = string.Empty;
        public string ynna_id_ps_violence = string.Empty;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        public string yn_id_es_caregiver_group = string.Empty;
        public string ynna_id_edu_attend_school_regularly = string.Empty;
        public string ynna_id_es_other_lending_group = string.Empty;
        #endregion Public

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection
        #endregion Variables

        #region Constractor Methods
        public hhHouseholdHomeVisitMember()
        {
            Default();
        }

        public hhHouseholdHomeVisitMember(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_household_home_visit_member WHERE hhvm_id = '{0}' ";
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
            dt = GetObject(hhvm_id, dbCon);
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
            hhvm_id = string.Empty;
            hhm_id = utilConstants.cDFEmptyListValue;
            hhv_id = utilConstants.cDFEmptyListValue;
            hst_id = utilConstants.cDFEmptyListValue;
            yn_id_hhm_active = utilConstants.cDFEmptyListValue;
            yn_id_edu_sensitised = utilConstants.cDFEmptyListValue;
            yn_id_es_aflateen = utilConstants.cDFEmptyListValue;
            yn_id_es_agro = utilConstants.cDFEmptyListValue;
            yn_id_es_apprenticeship = utilConstants.cDFEmptyListValue;
            yn_id_es_silc = utilConstants.cDFEmptyListValue;
            yn_id_fsn_nutrition = utilConstants.cDFEmptyListValue;
            yn_id_fsn_referred = utilConstants.cDFEmptyListValue;
            yn_id_fsn_wash = utilConstants.cDFEmptyListValue;
            ynna_id_edu_enrolled = utilConstants.cDFEmptyListValue;
            ynna_id_edu_support = utilConstants.cDFEmptyListValue;
            ynna_id_fsn_education = utilConstants.cDFEmptyListValue;
            ynna_id_fsn_support = utilConstants.cDFEmptyListValue;
            ynna_id_hhp_adhering = utilConstants.cDFEmptyListValue;
            ynna_id_hhp_art = utilConstants.cDFEmptyListValue;
            ynna_id_hhp_referred = utilConstants.cDFEmptyListValue;
            ynna_id_pro_birth_certificate = utilConstants.cDFEmptyListValue;
            ynna_id_pro_birth_registration = utilConstants.cDFEmptyListValue;
            ynna_id_pro_child_abuse = utilConstants.cDFEmptyListValue;
            ynna_id_pro_child_labour = utilConstants.cDFEmptyListValue;
            ynna_id_pro_reintegrated = utilConstants.cDFEmptyListValue;
            ynna_id_ps_parenting = utilConstants.cDFEmptyListValue;
            ynna_id_ps_support = utilConstants.cDFEmptyListValue;
            ynna_id_ps_violence = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO hh_household_home_visit_member " +
                "(hhvm_id, hhm_id, hhv_id, hst_id, " +
                "yn_id_hhm_active, " +
                "yn_id_edu_sensitised, yn_id_es_aflateen, yn_id_es_agro, yn_id_es_apprenticeship, yn_id_es_silc, " +
                "yn_id_fsn_nutrition, yn_id_fsn_referred, yn_id_fsn_wash, " +
                "ynna_id_edu_enrolled, ynna_id_edu_support, ynna_id_fsn_education, ynna_id_fsn_support, " +
                "ynna_id_hhp_adhering, ynna_id_hhp_art, ynna_id_hhp_referred, " +
                "ynna_id_pro_birth_certificate, ynna_id_pro_birth_registration, ynna_id_pro_child_abuse, " + 
                "ynna_id_pro_child_labour, ynna_id_pro_reintegrated, " +
                "ynna_id_ps_parenting, ynna_id_ps_support, ynna_id_ps_violence, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id,ynna_id_edu_attend_school_regularly,yn_id_es_caregiver_group,ynna_id_es_other_lending_group) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', " +
                "'{4}', " +
                "'{5}', '{6}', '{7}', '{8}', '{9}', " +
                "'{10}', '{11}', '{12}', " +
                "'{13}', '{14}', '{15}', '{16}', " +
                "'{17}', '{18}', '{19}', " +
                "'{20}', '{21}', '{22}', " + 
                "'{23}', '{24}', " +
                "'{25}', '{26}', '{27}', " +
                "'{28}', '{28}', GETDATE(), GETDATE(), '{29}','{30}','{31}','{32}','{33}') ";
            strSQL = string.Format(strSQL, hhvm_id, hhm_id, hhv_id, hst_id,
                yn_id_hhm_active,
                yn_id_edu_sensitised, yn_id_es_aflateen, yn_id_es_agro, yn_id_es_apprenticeship, yn_id_es_silc,
                yn_id_fsn_nutrition, yn_id_fsn_referred, yn_id_fsn_wash,
                ynna_id_edu_enrolled, ynna_id_edu_support, ynna_id_fsn_education, ynna_id_fsn_support,
                ynna_id_hhp_adhering, ynna_id_hhp_art, ynna_id_hhp_referred,
                ynna_id_pro_birth_certificate, ynna_id_pro_birth_registration, 
                ynna_id_pro_child_abuse, ynna_id_pro_child_labour, ynna_id_pro_reintegrated,
                ynna_id_ps_parenting, ynna_id_ps_support, ynna_id_ps_violence,
                usr_id_update, ofc_id,district_id, ynna_id_edu_attend_school_regularly, yn_id_es_caregiver_group, ynna_id_es_other_lending_group);

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
                hhvm_id = dr["hhvm_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                hhv_id = dr["hhv_id"].ToString();
                hst_id = dr["hst_id"].ToString();
                yn_id_hhm_active = dr["yn_id_hhm_active"].ToString();
                yn_id_edu_sensitised = dr["yn_id_edu_sensitised"].ToString();
                yn_id_es_aflateen = dr["yn_id_es_aflateen"].ToString();
                yn_id_es_agro = dr["yn_id_es_agro"].ToString();
                yn_id_es_apprenticeship = dr["yn_id_es_apprenticeship"].ToString();
                yn_id_es_silc = dr["yn_id_es_silc"].ToString();
                yn_id_fsn_nutrition = dr["yn_id_fsn_nutrition"].ToString();
                yn_id_fsn_referred = dr["yn_id_fsn_referred"].ToString();
                yn_id_fsn_wash = dr["yn_id_fsn_wash"].ToString();
                ynna_id_edu_enrolled = dr["ynna_id_edu_enrolled"].ToString();
                ynna_id_edu_support = dr["ynna_id_edu_support"].ToString();
                ynna_id_fsn_education = dr["ynna_id_fsn_education"].ToString();
                ynna_id_fsn_support = dr["ynna_id_fsn_support"].ToString();
                ynna_id_hhp_adhering = dr["ynna_id_hhp_adhering"].ToString();
                ynna_id_hhp_art = dr["ynna_id_hhp_art"].ToString();
                ynna_id_hhp_referred = dr["ynna_id_hhp_referred"].ToString();
                ynna_id_pro_birth_certificate = dr["ynna_id_pro_birth_certificate"].ToString();
                ynna_id_pro_birth_registration = dr["ynna_id_pro_birth_registration"].ToString();
                ynna_id_pro_child_abuse = dr["ynna_id_pro_child_abuse"].ToString();
                ynna_id_pro_child_labour = dr["ynna_id_pro_child_labour"].ToString();
                ynna_id_pro_reintegrated = dr["ynna_id_pro_reintegrated"].ToString();
                ynna_id_ps_parenting = dr["ynna_id_ps_parenting"].ToString();
                ynna_id_ps_support = dr["ynna_id_ps_support"].ToString();
                ynna_id_ps_violence = dr["ynna_id_ps_violence"].ToString();
                ynna_id_es_other_lending_group = dr["ynna_id_es_other_lending_group"].ToString();
                ynna_id_edu_attend_school_regularly = dr["ynna_id_edu_attend_school_regularly"].ToString();
                yn_id_es_caregiver_group = dr["yn_id_es_caregiver_group"].ToString();
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
            strSQL = "UPDATE hh_household_home_visit_member " +
                "SET hhm_id = '{1}', hhv_id = '{2}', hst_id = '{3}', " +
                "yn_id_hhm_active = '{4}', " +
                "yn_id_edu_sensitised = '{5}', yn_id_es_aflateen = '{6}', yn_id_es_agro = '{7}', yn_id_es_apprenticeship = '{8}', yn_id_es_silc = '{9}', " +
                "yn_id_fsn_nutrition = '{10}', yn_id_fsn_referred = '{11}', yn_id_fsn_wash = '{12}', " +
                "ynna_id_edu_enrolled = '{13}', ynna_id_edu_support = '{14}', ynna_id_fsn_education = '{15}', ynna_id_fsn_support = '{16}', " +
                "ynna_id_hhp_adhering = '{17}', ynna_id_hhp_art = '{18}', ynna_id_hhp_referred = '{19}', " +
                "ynna_id_pro_birth_certificate = '{20}', ynna_id_pro_birth_registration = '{21}', ynna_id_pro_child_abuse = '{22}', " + 
                "ynna_id_pro_child_labour = '{23}', ynna_id_pro_reintegrated = '{24}', " +
                "ynna_id_ps_parenting = '{25}', ynna_id_ps_support = '{26}', ynna_id_ps_violence = '{27}', " +
                "usr_id_update = '{28}', usr_date_update = GETDATE(),district_id = '{29}',ynna_id_edu_attend_school_regularly = '{30}',yn_id_es_caregiver_group = '{31}', " +
                "ynna_id_es_other_lending_group = '{32}' " + 
                "WHERE hhvm_id = '{0}' ";
            strSQL = string.Format(strSQL, hhvm_id, hhm_id, hhv_id, hst_id,
                yn_id_hhm_active,
                yn_id_edu_sensitised, yn_id_es_aflateen, yn_id_es_agro, yn_id_es_apprenticeship, yn_id_es_silc,
                yn_id_fsn_nutrition, yn_id_fsn_referred, yn_id_fsn_wash,
                ynna_id_edu_enrolled, ynna_id_edu_support, ynna_id_fsn_education, ynna_id_fsn_support,
                ynna_id_hhp_adhering, ynna_id_hhp_art, ynna_id_hhp_referred,
                ynna_id_pro_birth_certificate, ynna_id_pro_birth_registration,
                ynna_id_pro_child_abuse, ynna_id_pro_child_labour, ynna_id_pro_reintegrated,
                ynna_id_ps_parenting, ynna_id_ps_support, ynna_id_ps_violence,
                usr_id_update,district_id, ynna_id_edu_attend_school_regularly, yn_id_es_caregiver_group, ynna_id_es_other_lending_group);

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
            strSQL = "SELECT hhvm.*, " +
                "ISNULL(hhm.hh_id, '') AS hh_id " +
                "FROM hh_household_home_visit_member hhvm " +
                "LEFT JOIN hh_household_member hhm ON hhvm.hhm_id = hhm.hhm_id " +
                "WHERE hhvm.hhvm_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        public static string LoadBenHIVStatus(string hhm_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string hst_id = string.Empty;
            string SQL = @"SELECT hst_id FROM hh_household_member WHERE hhm_id = '{0}'";

            SQL = string.Format(SQL, hhm_id);
            try
            {
                string strConn = dbCon.ToString();

                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    Adapt = new SqlDataAdapter(cmd);
                    Adapt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dtRow = dt.Rows[0];
                        hst_id = dtRow["hst_id"].ToString();
                    }

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

            return hst_id;
        }
    }
}
