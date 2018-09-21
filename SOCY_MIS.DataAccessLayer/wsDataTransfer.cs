using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class wsDataTransfer
    {
        #region Function Methods
        public void Delete(string strTable, string strPrimaryKey, string strID, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("DELETE FROM {0} WHERE {1} = '{2}' ", strTable, strPrimaryKey, strID);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public string ProcessDownload(string strTable, DataTable dt, DBConnection dbCon)
        {
            #region Variables
            DataRow dr = null;

            string strId = string.Empty;
            string strSQL = string.Empty;
            string strSQLData = string.Empty;
            string strSQLDelete = string.Empty;
            string strSQLSelect = string.Empty;
            #endregion Variables

            #region Process Records
            switch (strTable)
            {
                #region ben_activity_training
                case "ben_activity_training":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE at_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(at_id, " +
                        "at_activity, at_training_for, at_training_point, " +
                        "at_date_begin, at_date_end, " +
                        "at_days, at_session, " +
                        "at_coordinator, at_coordinator_tel, " +
                        "cso_id, ttp_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                          "'{1}', '{2}', '{3}', " +
                          "'{4}', '{5}', {6}, '{7}', " +
                          "'{8}', '{9}', " +
                          "'{10}', '{11}', " +
                          "'{12}', '{13}', " +
                          "'{14}', '{15}', " +
                          "'{16}','{17}' ";
                    strId = dt.Rows[dt.Rows.Count - 1]["at_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["at_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["at_id"].ToString(),
                            utilFormatting.StringForSQL(dr["at_activity"].ToString()), utilFormatting.StringForSQL(dr["at_training_for"].ToString()), utilFormatting.StringForSQL(dr["at_training_point"].ToString()),
                            Convert.ToDateTime(dr["at_date_begin"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["at_date_end"]).ToString("dd MMM yyyy HH:mm:ss"),
                            dr["at_days"].ToString(), dr["at_session"].ToString(),
                            utilFormatting.StringForSQL(dr["at_coordinator"].ToString()), utilFormatting.StringForSQL(dr["at_coordinator_tel"].ToString()),
                            dr["cso_id"].ToString(), dr["ttp_id"].ToString(),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                            Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                            dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_activity_training

                #region ben_activity_training_participant
                case "ben_activity_training_participant":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE atp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(atp_id, atp_name, atp_year_of_birth, atp_days, " +
                        "at_id, gnd_id, hhm_id, mtp_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', {3}, " +
                        "'{4}', '{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}',{13}";
                    strId = dt.Rows[dt.Rows.Count - 1]["atp_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["atp_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["atp_id"].ToString(), utilFormatting.StringForSQL(dr["atp_name"].ToString()), dr["atp_year_of_birth"].ToString(), dr["atp_days"].ToString(),
                        dr["at_id"].ToString(), dr["gnd_id"].ToString(), dr["hhm_id"].ToString(), dr["mtp_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_activity_training_participant

                #region ben_apprenticeship_register_line
                case "ben_apprenticeship_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE aprl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(aprl_id, aprl_enterprise, " +
                        "aprl_date_begin, aprl_date_complete, " +
                        "apr_id, apt_id, cso_id, hhm_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}',{13}";
                    strId = dt.Rows[dt.Rows.Count - 1]["aprl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["aprl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["aprl_id"].ToString(), utilFormatting.StringForSQL(dr["aprl_enterprise"].ToString()),
                        Convert.ToDateTime(dr["aprl_date_begin"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["aprl_date_complete"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["apr_id"].ToString(), dr["apt_id"].ToString(), dr["cso_id"].ToString(), dr["hhm_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_apprenticeship_register_line

                #region ben_girl_education_register
                case "ben_girl_education_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ger_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(ger_id, ger_contact_details, " +
                        "cso_id, fy_id, qy_id, sct_id, swk_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}',{12}";
                    strId = dt.Rows[dt.Rows.Count - 1]["ger_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ger_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ger_id"].ToString(), utilFormatting.StringForSQL(dr["ger_contact_details"].ToString()),
                        dr["cso_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["sct_id"].ToString(), dr["swk_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_girl_education_register

                #region ben_girl_education_register_child
                case "ben_girl_education_register_child":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE gerc_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(gerc_id, gerc_support_institution, " +
                        "edu_id, fst_id, ger_id, hhm_id, hhm_id_caregiver, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}',{12}";
                    strId = dt.Rows[dt.Rows.Count - 1]["gerc_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["gerc_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect,  dr["gerc_id"].ToString(), utilFormatting.StringForSQL(dr["gerc_support_institution"].ToString()),
                        dr["edu_id"].ToString(), dr["fst_id"].ToString(), dr["ger_id"].ToString(), dr["hhm_id"].ToString(), dr["hhm_id_caregiver"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_girl_education_register_child

                #region ben_service_register
                case "ben_service_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE svr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(svr_id, svr_contact_details, " +
                        "cso_id, dst_id, fy_id, qy_id, swk_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}',{12}";
                    strId = dt.Rows[dt.Rows.Count - 1]["svr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["svr_id"].ToString(), utilFormatting.StringForSQL(dr["svr_contact_details"].ToString()),
                        dr["cso_id"].ToString(), dr["dst_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["swk_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_service_register

                #region ben_service_register_line
                case "ben_service_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE svrl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(svrl_id, svrl_eco_strength_other, " +
                        "hhm_id, " +
                        "yn_id_agricalture_advisory, yn_id_apprentice_skills, yn_id_basic_care, yn_id_birth_registration, " +
                        "yn_id_case_handled, yn_id_eco_strength_other, yn_id_newly_enrolled, yn_id_parenting, " +
                        "yn_id_psych_support, yn_id_reintegrated, yn_id_silc_intervention, " +
                        "svr_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', " +
                        "'{3}', '{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', '{10}', " +
                        "'{11}', '{12}', '{13}', " +
                        "'{14}', " +
                        "'{15}', '{16}', " +
                        "'{17}', '{18}', " +
                        "'{19}',{20}";
                    strId = dt.Rows[dt.Rows.Count - 1]["svrl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svrl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["svrl_id"].ToString(), utilFormatting.StringForSQL(dr["svrl_eco_strength_other"].ToString()),
                        dr["hhm_id"].ToString(),
                        dr["yn_id_agricalture_advisory"].ToString(), dr["yn_id_apprentice_skills"].ToString(), dr["yn_id_basic_care"].ToString(), dr["yn_id_birth_registration"].ToString(),
                        dr["yn_id_case_handled"].ToString(), dr["yn_id_eco_strength_other"].ToString(), dr["yn_id_newly_enrolled"].ToString(), dr["yn_id_parenting"].ToString(),
                        dr["yn_id_psych_support"].ToString(), dr["yn_id_reintegrated"].ToString(), dr["yn_id_silc_intervention"].ToString(),
                        dr["svr_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_service_register_line

                #region ben_service_register_line_social_economic
                case "ben_service_register_line_social_economic":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE svrlse_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(svrlse_id, svrl_id, sec_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}',{6}";
                    strId = dt.Rows[dt.Rows.Count - 1]["svrlse_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svrlse_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["svrlse_id"].ToString(), dr["svrl_id"].ToString(), dr["sec_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_service_register_line_social_economic

                #region ben_value_chain_register
                case "ben_value_chain_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE vcr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(vcr_id, " +
                        "cso_id, fy_id, qy_id, sct_id, swk_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}',{11}";
                    strId = dt.Rows[dt.Rows.Count - 1]["vcr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["vcr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["vcr_id"].ToString(),
                        dr["cso_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["sct_id"].ToString(), dr["swk_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_value_chain_register

                #region ben_value_chain_register_actor
                case "ben_value_chain_register_actor":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE vcra_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(vcra_id, vcra_commodity, vcra_bds_service, " +
                        "vcra_id_price, vcra_id_qty, vcra_id_revenue, " +
                        "vcra_pb_price, vcra_pb_qty, vcra_pb_revenue, " +
                        "hhm_id, vcr_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "{3}, {4}, {5}, " +
                        "{6}, {7}, {8}, " +
                        "'{9}', '{10}', " +
                        "'{11}', '{12}', " +
                        "'{13}', '{14}', " +
                        "'{15}',{16}";
                    strId = dt.Rows[dt.Rows.Count - 1]["vcra_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["vcra_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["vcra_id"].ToString(), utilFormatting.StringForSQL(dr["vcra_commodity"].ToString()), utilFormatting.StringForSQL(dr["vcra_bds_service"].ToString()),
                        dr["vcra_id_price"].ToString(), dr["vcra_id_qty"].ToString(), dr["vcra_id_revenue"].ToString(),
                        dr["vcra_pb_price"].ToString(), dr["vcra_pb_qty"].ToString(), dr["vcra_pb_revenue"].ToString(),
                        dr["hhm_id"].ToString(), dr["vcr_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_value_chain_register_actor

                #region drm_enrollment
                case "drm_enrollment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE de_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(de_id, " +
                        "dst_id, flt_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}',{8}";
                    strId = dt.Rows[dt.Rows.Count - 1]["de_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["de_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["de_id"].ToString(),
                        dr["dst_id"].ToString(), dr["flt_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment

                #region drm_enrollment_member
                case "drm_enrollment_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dem_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dem_id, dem_sn, " +
                        "de_id, dm_id, est_id, pst_id, sst_id, " +
                        "yn_id_disability, yn_id_given_birth, yn_id_married, " +
                        "yn_id_partner, yn_id_pregnant, yn_id_ts, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', " +
                        "'{10}', '{11}', '{12}', " +
                        "'{13}', '{14}', " +
                        "'{15}', '{16}', " +
                        "'{17}',{18}";
                    strId = dt.Rows[dt.Rows.Count - 1]["dem_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dem_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dem_id"].ToString(), utilFormatting.StringForSQL(dr["dem_sn"].ToString()),
                        dr["de_id"].ToString(), dr["dm_id"].ToString(), dr["est_id"].ToString(), dr["pst_id"].ToString(), dr["sst_id"].ToString(),
                        dr["yn_id_disability"].ToString(), dr["yn_id_given_birth"].ToString(), dr["yn_id_married"].ToString(),
                        dr["yn_id_partner"].ToString(), dr["yn_id_pregnant"].ToString(), dr["yn_id_ts"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member

                #region drm_enrollment_member_segment
                case "drm_enrollment_member_segment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE dems_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dems_id, dem_id, sgm_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}',{6}";
                    strId = dt.Rows[dt.Rows.Count - 1]["dems_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dems_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dems_id"].ToString(), dr["dem_id"].ToString(), dr["sgm_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member_segment

                #region drm_enrollment_member_visit
                case "drm_enrollment_member_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE demv_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(demv_id, demv_comment, demv_referral, " +
                        "demv_date, " +
                        "dem_id, vst_id, " +
                        "yn_id_anc, yn_id_art, yn_id_cmnc, " +
                        "yn_id_condom_promotion, yn_id_contraceptive_mix, yn_id_hiv_testing, " +
                        "yn_id_parenting_program, yn_id_post_violence_care, yn_id_school_based_prevention, " +
                        "yn_id_social_economic, yn_id_vmmc, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', '{5}', " +
                        "'{6}', '{7}', '{8}', " +
                        "'{9}', '{10}', '{11}', " +
                        "'{12}', '{13}', '{14}', " +
                        "'{15}', '{16}', " +
                        "'{17}', '{18}', " +
                        "'{19}', '{20}', " +
                        "'{21}',{22}";
                    strId = dt.Rows[dt.Rows.Count - 1]["demv_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["demv_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["demv_id"].ToString(), utilFormatting.StringForSQL(dr["demv_comment"].ToString()), utilFormatting.StringForSQL(dr["demv_referral"].ToString()),
                        Convert.ToDateTime(dr["demv_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["dem_id"].ToString(), dr["vst_id"].ToString(),
                        dr["yn_id_anc"].ToString(), dr["yn_id_art"].ToString(), dr["yn_id_cmnc"].ToString(),
                        dr["yn_id_condom_promotion"].ToString(), dr["yn_id_contraceptive_mix"].ToString(), dr["yn_id_hiv_testing"].ToString(),
                        dr["yn_id_parenting_program"].ToString(), dr["yn_id_post_violence_care"].ToString(), dr["yn_id_school_based_prevention"].ToString(),
                        dr["yn_id_social_economic"].ToString(), dr["yn_id_vmmc"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member_visit

                #region drm_htc_register
                case "drm_htc_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dhr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dhr_id, " +
                        "dhr_result_01, dhr_result_01_date, " +
                        "dhr_result_02, dhr_result_02_date, " +
                        "dhr_result_03, dhr_result_03_date, " +
                        "dhr_result_04, dhr_result_04_date, " +
                        "dhr_result_05, dhr_result_05_date, " +
                        "dm_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}', " +
                        "'{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}','{17}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dhr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dhr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dhr_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dhr_result_01"].ToString()), Convert.ToDateTime(dr["dhr_result_01_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dhr_result_02"].ToString()), Convert.ToDateTime(dr["dhr_result_02_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dhr_result_03"].ToString()), Convert.ToDateTime(dr["dhr_result_03_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dhr_result_04"].ToString()), Convert.ToDateTime(dr["dhr_result_04_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dhr_result_05"].ToString()), Convert.ToDateTime(dr["dhr_result_05_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["dm_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_htc_register

                #region drm_member
                case "drm_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dm_id, " +
                        "dm_first_name, dm_last_name, dm_id_no, " +
                        "dm_village, dm_phone, dm_status_reason, " +
                        "dm_active, " +
                        "dm_dob, dm_registration,  " +
                        "etp_id, hhm_id, mtp_id, wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "{7}, " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', '{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}','{19}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dm_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dm_first_name"].ToString()), utilFormatting.StringForSQL(dr["dm_last_name"].ToString()), utilFormatting.StringForSQL(dr["dm_id_no"].ToString()),
                        utilFormatting.StringForSQL(dr["dm_village"].ToString()), utilFormatting.StringForSQL(dr["dm_phone"].ToString()), utilFormatting.StringForSQL(dr["dm_status_reason"].ToString()),
                        Convert.ToInt32(Convert.ToBoolean(dr["dm_active"])),
                        Convert.ToDateTime(dr["dm_dob"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["dm_registration"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["etp_id"].ToString(), dr["hhm_id"].ToString(), dr["mtp_id"].ToString(), dr["wrd_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_member

                #region drm_partner
                case "drm_partner":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dp_id, dp_first_name, dp_last_name, dm_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', '{3}', " +
                        "'{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}','{9}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dp_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dp_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dp_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dp_first_name"].ToString()), utilFormatting.StringForSQL(dr["dp_last_name"].ToString()), dr["dm_id"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_partner

                #region drm_partner_tracking
                case "drm_partner_tracking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dpt_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpt_id, dpt_date, " +
                        "dpt_dptp_other, dpt_phone, " +
                        "dpt_address, dpt_service, " +
                        "dp_id, dptp_id, hst_id, " +
                        "yn_id_traced, ynd_id_vmmc, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', " +
                        "'{6}', '{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}', '{12}', " +
                        "'{13}', '{14}', " +
                        "'{15}','{16}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpt_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpt_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpt_id"].ToString(),
                        Convert.ToDateTime(dr["dpt_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dpt_dptp_other"].ToString()), utilFormatting.StringForSQL(dr["dpt_phone"].ToString()),
                        utilFormatting.StringForSQL(dr["dpt_address"].ToString()), utilFormatting.StringForSQL(dr["dpt_service"].ToString()),
                        dr["dp_id"].ToString(), dr["dptp_id"].ToString(), dr["hst_id"].ToString(),
                        dr["yn_id_traced"].ToString(), dr["ynd_id_vmmc"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_partner_tracking

                #region drm_partner_tracking_service
                case "drm_partner_tracking_service":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE dpts_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpts_id, dpt_id, dsrv_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpts_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpts_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpts_id"].ToString(), dr["dpt_id"].ToString(), dr["dsrv_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_partner_tracking_service

                #region drm_post_violence_care
                case "drm_post_violence_care":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dpvc_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpvc_id, " +
                        "flt_id, sct_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}','{8}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpvc_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpvc_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpvc_id"].ToString(),
                        dr["flt_id"].ToString(), dr["sct_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_post_violence_care

                #region drm_post_violence_care_line
                case "drm_post_violence_care_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dpvcl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpvcl_id, " +
                        "dpvcl_referred_from, dpvcl_date, " +
                        "dm_id, dpvc_id, gbv_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpvcl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpvcl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpvcl_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dpvcl_referred_from"].ToString()), Convert.ToDateTime(dr["dpvcl_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["dm_id"].ToString(), dr["dpvc_id"].ToString(), dr["gbv_id"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_post_violence_care_line

                #region drm_post_violence_care_line_dreams_service
                case "drm_post_violence_care_line_dreams_service":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE dpvclds_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpvclds_id, dpvcl_id, dso_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpvclds_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpvclds_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpvclds_id"].ToString(), dr["dpvcl_id"].ToString(), dr["dso_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_post_violence_care_line_dreams_service

                #region drm_post_violence_care_line_service
                case "drm_post_violence_care_line_service":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE dpvcls_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dpvcls_id, dpvcl_id, pvcs_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dpvcls_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dpvcls_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dpvcls_id"].ToString(), dr["dpvcl_id"].ToString(), dr["pvcs_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_post_violence_care_line_service

                #region drm_sinovuyo_missed_session
                case "drm_sinovuyo_missed_session":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dsms_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dsms_id, dsms_contact, " +
                        "dsms_date, dsms_date_followup, " +
                        "dsms_action_other, dsms_followup_other, dsms_followup_method_other, " +
                        "dm_id, dsa_id, dsf_id, dsfm_id, yn_id_followup, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', '{10}', '{11}', " +
                        "'{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}','{17}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dsms_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dsms_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dsms_id"].ToString(), utilFormatting.StringForSQL(dr["dsms_contact"].ToString()),
                        Convert.ToDateTime(dr["dsms_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["dsms_date_followup"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dsms_action_other"].ToString()), utilFormatting.StringForSQL(dr["dsms_followup_other"].ToString()), utilFormatting.StringForSQL(dr["dsms_followup_method_other"].ToString()),
                        dr["dm_id"].ToString(), dr["dsa_id"].ToString(), dr["dsf_id"].ToString(), dr["dsfm_id"].ToString(), dr["yn_id_followup"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_sinovuyo_missed_session

                #region drm_sinovuyo_register
                case "drm_sinovuyo_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dsr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dsr_id, " +
                        "dsr_facilitator, dsr_group, dsr_village, " +
                        "dsr_date, " +
                        "wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', " +
                        "'{4}', " +
                        "'{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dsr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dsr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dsr_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dsr_facilitator"].ToString()), utilFormatting.StringForSQL(dr["dsr_group"].ToString()), utilFormatting.StringForSQL(dr["dsr_village"].ToString()),
                        Convert.ToDateTime(dr["dsr_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["wrd_id"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_sinovuyo_register

                #region drm_sinovuyo_register_line
                case "drm_sinovuyo_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dsrl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dsrl_id, " +
                        "dsrl_contact, dm_id, dsr_id, " +
                        "pca_id_01, pca_id_02, pca_id_03, " +
                        "pca_id_04, pca_id_05, pca_id_06, " +
                        "pca_id_07, pca_id_08, pca_id_09, " +
                        "pca_id_10, pca_id_11, pca_id_12, " +
                        "pca_id_13, pca_id_14, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', " +
                        "'{10}', '{11}', '{12}', " +
                        "'{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}', '{19}', " +
                        "'{20}', '{21}', " +
                        "'{22}','{23}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dsrl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dsrl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dsrl_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dsrl_contact"].ToString()), dr["dm_id"].ToString(), dr["dsr_id"].ToString(),
                        dr["pca_id_01"].ToString(), dr["pca_id_02"].ToString(), dr["pca_id_03"].ToString(),
                        dr["pca_id_04"].ToString(), dr["pca_id_05"].ToString(), dr["pca_id_06"].ToString(),
                        dr["pca_id_07"].ToString(), dr["pca_id_08"].ToString(), dr["pca_id_09"].ToString(),
                        dr["pca_id_10"].ToString(), dr["pca_id_11"].ToString(), dr["pca_id_12"].ToString(),
                        dr["pca_id_13"].ToString(), dr["pca_id_14"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_sinovuyo_register_line

                #region drm_stepping_stones_missed_session
                case "drm_stepping_stones_missed_session":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dssms_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dssms_id, dssms_contact, " +
                        "dssms_date, dssms_date_followup, " +
                        "dssms_action_other, dssms_followup_other, dssms_followup_method_other, " +
                        "dm_id, dsa_id, dsf_id, dsfm_id, yn_id_followup, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', '{10}', '{11}', " +
                        "'{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}','{17}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dssms_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dssms_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dssms_id"].ToString(), utilFormatting.StringForSQL(dr["dssms_contact"].ToString()),
                        Convert.ToDateTime(dr["dssms_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["dssms_date_followup"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["dssms_action_other"].ToString()), utilFormatting.StringForSQL(dr["dssms_followup_other"].ToString()), utilFormatting.StringForSQL(dr["dssms_followup_method_other"].ToString()),
                        dr["dm_id"].ToString(), dr["dsa_id"].ToString(), dr["dsf_id"].ToString(), dr["dsfm_id"].ToString(), dr["yn_id_followup"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_stepping_stones_missed_session

                #region drm_stepping_stones_register
                case "drm_stepping_stones_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dssr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dssr_id, " +
                        "dssr_facilitator, dssr_group, dssr_village, " +
                        "dssr_date, " +
                        "wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', " +
                        "'{4}', " +
                        "'{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dssr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dssr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dssr_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dssr_facilitator"].ToString()), utilFormatting.StringForSQL(dr["dssr_group"].ToString()), utilFormatting.StringForSQL(dr["dssr_village"].ToString()),
                        Convert.ToDateTime(dr["dssr_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["wrd_id"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_stepping_stones_register

                #region drm_stepping_stones_register_line
                case "drm_stepping_stones_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE dssrl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(dssrl_id, " +
                        "dssrl_contact, dm_id, dssr_id, " +
                        "yn_id_m1, yn_id_m2, yn_id_m3, " +
                        "yn_id_sa, yn_id_sb, yn_id_sc, " +
                        "yn_id_sd, yn_id_se, yn_id_sf, " +
                        "yn_id_sg, yn_id_sh, yn_id_si, " +
                        "yn_id_sj, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', '{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', " +
                        "'{10}', '{11}', '{12}', " +
                        "'{13}', '{14}', '{15}', " +
                        "'{16}', " +
                        "'{17}', '{18}', " +
                        "'{19}', '{20}', " +
                        "'{21}','{22}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["dssrl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dssrl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["dssrl_id"].ToString(),
                        utilFormatting.StringForSQL(dr["dssrl_contact"].ToString()), dr["dm_id"].ToString(), dr["dssr_id"].ToString(),
                        dr["yn_id_m1"].ToString(), dr["yn_id_m2"].ToString(), dr["yn_id_m3"].ToString(),
                        dr["yn_id_sa"].ToString(), dr["yn_id_sb"].ToString(), dr["yn_id_sc"].ToString(),
                        dr["yn_id_sd"].ToString(), dr["yn_id_se"].ToString(), dr["yn_id_sf"].ToString(),
                        dr["yn_id_sg"].ToString(), dr["yn_id_sh"].ToString(), dr["yn_id_si"].ToString(),
                        dr["yn_id_sj"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion drm_stepping_stones_register_line

                #region hh_home_visit
                case "hh_home_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hv_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hv_id, hv_number_of_children, " +
                        "hv_date, hv_previous_visit_date, " +
                        "hv_previous_visit_purpose, hv_previous_visit_service, " +
                        "hv_actions, hv_findings, hv_next_steps, " +
                        "hv_girl_name, hv_girl_age, " +
                        "hv_girl_education_type, " +
                        "edu_id, hh_id, hhm_id, swk_id, " +
                        "yn_id_consumption_program, yn_id_girl_education_support, yn_id_improvement_plan, " +
                        "yn_id_previous_visit, yn_id_referral, yn_id_referral_completed, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', {1}, " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', " +
                        "'{6}', '{7}', '{8}', " +
                        "'{9}', {10}, " +
                        "'{11}', " +
                        "'{12}', '{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', '{18}', " +
                        "'{19}', '{20}', '{21}', " +
                        "'{22}', '{23}', " +
                        "'{24}', '{25}', " +
                        "'{26}','{27}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hv_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hv_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hv_id"].ToString(), dr["hv_number_of_children"].ToString(),
                        Convert.ToDateTime(dr["hv_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["hv_previous_visit_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["hv_previous_visit_purpose"].ToString()), utilFormatting.StringForSQL(dr["hv_previous_visit_service"].ToString()),
                        utilFormatting.StringForSQL(dr["hv_actions"].ToString()), utilFormatting.StringForSQL(dr["hv_findings"].ToString()), utilFormatting.StringForSQL(dr["hv_next_steps"].ToString()),
                        utilFormatting.StringForSQL(dr["hv_girl_name"].ToString()), dr["hv_girl_age"].ToString(),
                        utilFormatting.StringForSQL(dr["hv_girl_education_type"].ToString()),
                        dr["edu_id"].ToString(), dr["hh_id"].ToString(), dr["hhm_id"].ToString(), dr["swk_id"].ToString(),
                        dr["yn_id_consumption_program"].ToString(), dr["yn_id_girl_education_support"].ToString(), dr["yn_id_improvement_plan"].ToString(),
                        dr["yn_id_previous_visit"].ToString(), dr["yn_id_referral"].ToString(), dr["yn_id_referral_completed"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit

                #region hh_home_visit_service
                case "hh_home_visit_service":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE hvs_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hvs_id, hv_id, shv_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hvs_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hvs_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hvs_id"].ToString(), dr["hv_id"].ToString(), dr["shv_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit_service

                #region hh_home_visit_service_previous
                case "hh_home_visit_service_previous":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE hvsp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hvsp_id, hv_id, shvp_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hvsp_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hvsp_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hvsp_id"].ToString(), dr["hv_id"].ToString(), dr["shvp_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit_service_previous

                #region hh_household
                case "hh_household":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hh_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hh_id, hh_code, " +
                        "hh_status_reason, hh_tel, hh_village, " +
                        "hhs_id, hhsr_id, swk_id, wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', " +
                        "'{5}', '{6}', '{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}', '{12}', " +
                        "'{13}','{14}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hh_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hh_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hh_id"].ToString(), utilFormatting.StringForSQL(dr["hh_code"].ToString()),
                        utilFormatting.StringForSQL(dr["hh_status_reason"].ToString()), utilFormatting.StringForSQL(dr["hh_tel"].ToString()), utilFormatting.StringForSQL(dr["hh_village"].ToString()),
                        dr["hhs_id"].ToString(), dr["hhsr_id"].ToString(), dr["swk_id"].ToString(), dr["wrd_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household

                #region hh_household_assessment
                case "hh_household_assessment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hha_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hha_id, hha_comments, " +
                        "hha_date, " +
                        "hha_num_of_meals, " +
                        "hh_id, hhm_id, icc_id, " +
                        "ics_id, osn_id_disagreement, swk_id, " +
                        "yn_id_child_separation, yn_id_financial_savings, " +
                        "yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water, " +
                        "ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school, " +
                        "ynns_id_assets, yns_id_latrine, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,[swk_phone],[caregiver_phone],[_18_years_male],[_18_years_female]" + 
                      ",[below_18_male],[below_18_female],[total_hhm_male],[total_hhm_female]" + 
                      ",[yn_child_headed],[yn_hh_disabled],[yn_hhm_sick],[yn_hhm_employed]" + 
                      ",[yn_pay_unexpected_expense],[yn_function_tp_means],[yn_hhm_vocational_skills]" + 
                      ",[yn_domestic_animals],[yn_hh_access_to_land],[hh_food_source]" + 
                      ",[hhm_go_hungry_past_month],[yn_caregiver_knows_hiv_status],[yn_children_tested]" + 
                      ",[yn_eligible_child_on_treatment],[yn_hh_access_water],[yn_hhm_mosquito_net]" + 
                      ",[yn_hh_access_public_health_facility],[yn_ob_clean_compound],[yn_ob_drying_rack]" +
                      ",[yn_ob_garbage_pit],[yn_ob_animal_house],[yn_ob_washing_facility],[hh_stable_shelter]" +
                      ",[ynna_children_go_to_school],[total_hh_children_not_go_to_school],[yn_children_sad_unhappy]" +
                      ",[yn_cp_repeated_abuse],[yn_cp_child_labour],[yn_cp_sexually_abused],[yn_cp_stigmatised]" +
                      ",[hhs_id_visit_from_volunteer],[hhs_id_financial_support],[hhs_id_parenting_counsiling]" +
                      ",[hhs_id_early_child_dev],[hhs_id_health_hygiene],[hhs_id_hiv_gbv_prevention],[hhs_id_nutrition_counsiling]" +
                      ",[hhs_id_pre_post_partum],[hhs_id_hiv_testing],[hhs_id_couples_counsiling] ,[hhs_id_birth_certificate]" +
                      ",[hhs_id_child_protection],[hhs_id_psychosocial],[hhs_id_food_security],[hhs_id_other],[hhs_id_none],[hhcs_id_savings_groups]" +
                      ",[hhcs_id_parenting_program],[hhcs_id_govt_sage_program],[hhcs_id_other_cash_transfer],[hhcs_id_voluntary_hiv_testing]" +
                      ",[hhcs_id_food_security_nutrition],[hhcs_id_skills_employ_training],[hhcs_id_entrepreneurship_training],[hhcs_id_other]" +
                      ",[hhcs_id_none],[hh_child_abuse_action],[yn_cp_conflict_with_law],[yn_cp_withheld_meal],[yn_cp_abusive_language]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}', '{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', '{18}', " +
                        "'{19}', '{20}', " +
                        "'{21}', '{22}', " +
                        "'{23}', '{24}', " +
                        "'{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}'," +
                        "'{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}','{71}','{72}','{73}'," +
                        "'{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}','{88}','{89}','{90}','{91}','{92}','{93}','{94}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hha_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hha_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hha_id"].ToString(), utilFormatting.StringForSQL(dr["hha_comments"].ToString()),
                        Convert.ToDateTime(dr["hha_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["hha_num_of_meals"].ToString(),
                        dr["hh_id"].ToString(), dr["hhm_id"].ToString(), dr["icc_id"].ToString(),
                        dr["ics_id"].ToString(), dr["osn_id_disagreement"].ToString(), dr["swk_id"].ToString(),
                        dr["yn_id_child_separation"].ToString(), dr["yn_id_financial_savings"].ToString(),
                        dr["yn_id_food_body_building"].ToString(), dr["yn_id_food_energy"].ToString(), dr["yn_id_food_protective"].ToString(), dr["yn_id_water"].ToString(),
                        dr["ynna_id_expenses_food"].ToString(), dr["ynna_id_expenses_health"].ToString(), dr["ynna_id_expenses_school"].ToString(),
                        dr["ynns_id_assets"].ToString(), dr["yns_id_latrine"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(),

                        dr["swk_phone"].ToString(), dr["caregiver_phone"].ToString(), dr["_18_years_male"].ToString(), dr["_18_years_female"].ToString(), dr["below_18_male"].ToString(), dr["below_18_female"].ToString(), dr["total_hhm_male"].ToString(),
                        dr["total_hhm_female"].ToString(), dr["yn_child_headed"].ToString(), dr["yn_hh_disabled"].ToString(), dr["yn_hhm_sick"].ToString(), dr["yn_hhm_employed"].ToString(), dr["yn_pay_unexpected_expense"].ToString(), dr["yn_function_tp_means"].ToString(),
                        dr["yn_hhm_vocational_skills"].ToString(), dr["yn_domestic_animals"].ToString(), dr["yn_hh_access_to_land"].ToString(), dr["hh_food_source"].ToString(), dr["hhm_go_hungry_past_month"].ToString(), dr["yn_caregiver_knows_hiv_status"].ToString(), dr["yn_children_tested"].ToString(),
                        dr["yn_eligible_child_on_treatment"].ToString(), dr["yn_hh_access_water"].ToString(), dr["yn_hhm_mosquito_net"].ToString(), dr["yn_hh_access_public_health_facility"].ToString(), dr["yn_ob_clean_compound"].ToString(), dr["yn_ob_drying_rack"].ToString(), dr["yn_ob_garbage_pit"].ToString(),
                        dr["yn_ob_animal_house"].ToString(), dr["yn_ob_washing_facility"].ToString(), dr["hh_stable_shelter"].ToString(), dr["ynna_children_go_to_school"].ToString(), dr["total_hh_children_not_go_to_school"].ToString(), dr["yn_children_sad_unhappy"].ToString(), dr["yn_cp_repeated_abuse"].ToString(), dr["yn_cp_child_labour"].ToString(),
                        dr["yn_cp_sexually_abused"].ToString(), dr["yn_cp_stigmatised"].ToString(), dr["hhs_id_visit_from_volunteer"].ToString(), dr["hhs_id_financial_support"].ToString(), dr["hhs_id_parenting_counsiling"].ToString(), dr["hhs_id_early_child_dev"].ToString(), dr["hhs_id_health_hygiene"].ToString(),
                        dr["hhs_id_hiv_gbv_prevention"].ToString(), dr["hhs_id_nutrition_counsiling"].ToString(), dr["hhs_id_pre_post_partum"].ToString(), dr["hhs_id_hiv_testing"].ToString(), dr["hhs_id_couples_counsiling"].ToString(), dr["hhs_id_birth_certificate"].ToString(), dr["hhs_id_child_protection"].ToString(),
                        dr["hhs_id_psychosocial"].ToString(), dr["hhs_id_food_security"].ToString(), dr["hhs_id_other"].ToString(), dr["hhs_id_none"].ToString(), dr["hhcs_id_savings_groups"].ToString(), dr["hhcs_id_parenting_program"].ToString(), dr["hhcs_id_govt_sage_program"].ToString(),
                        dr["hhcs_id_other_cash_transfer"].ToString(), dr["hhcs_id_voluntary_hiv_testing"].ToString(), dr["hhcs_id_food_security_nutrition"].ToString(), dr["hhcs_id_skills_employ_training"].ToString(), dr["hhcs_id_entrepreneurship_training"].ToString(), dr["hhcs_id_other"].ToString(), dr["hhcs_id_none"].ToString(),
                        dr["hh_child_abuse_action"].ToString(), dr["yn_cp_conflict_with_law"].ToString(), dr["yn_cp_withheld_meal"].ToString(), dr["yn_cp_abusive_language"].ToString());
                    }
                    break;
                #endregion hh_household_assessment

                #region hh_household_assessment_member
                case "hh_household_assessment_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ham_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(ham_id, " +
                        "ham_first_name, ham_last_name, " +
                        "ham_year_of_birth, " +
                        "dtp_id, edu_id, gnd_id, " +
                        "hha_id, hhm_id, hst_id, mst_id, " +
                        "prf_id, prt_id, " +
                        "yn_id_art, yn_id_birth_registration, yn_id_caregiver, " +
                        "yn_id_disability, yn_id_given_birth, yn_id_hoh, " +
                        "yn_id_immun, yn_id_pregnant, yn_id_school, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,yn_attained_vocational_skill) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', '{10}', " +
                        "'{11}', '{12}', " +
                        "'{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', '{18}', " +
                        "'{19}', '{20}', '{21}', " +
                        "'{22}', '{23}', " +
                        "'{24}', '{25}', " +
                        "'{26}','{27}','{28}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["ham_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ham_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ham_id"].ToString(),
                        utilFormatting.StringForSQL(dr["ham_first_name"].ToString()), utilFormatting.StringForSQL(dr["ham_last_name"].ToString()),
                        dr["ham_year_of_birth"].ToString(),
                        dr["dtp_id"].ToString(), dr["edu_id"].ToString(), dr["gnd_id"].ToString(),
                        dr["hha_id"].ToString(), dr["hhm_id"].ToString(), dr["hst_id"].ToString(), dr["mst_id"].ToString(),
                        dr["prf_id"].ToString(), dr["prt_id"].ToString(),
                        dr["yn_id_art"].ToString(), dr["yn_id_birth_registration"].ToString(), dr["yn_id_caregiver"].ToString(),
                        dr["yn_id_disability"].ToString(), dr["yn_id_given_birth"].ToString(), dr["yn_id_hoh"].ToString(),
                        dr["yn_id_immun"].ToString(), dr["yn_id_pregnant"].ToString(), dr["yn_id_school"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), dr["yn_attained_vocational_skill"].ToString());
                    }
                    break;
                #endregion hh_household_assessment_member

                #region hh_household_member
                case "hh_household_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hhm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hhm_id, " +
                        "hhm_first_name, hhm_last_name, " +
                        "hhm_number, hhm_year_of_birth, " +
                        "dtp_id, edu_id, gnd_id, " +
                        "hh_id, hst_id, mst_id, " +
                        "prf_id, prt_id, " +
                        "yn_id_art, yn_id_birth_registration, yn_id_caregiver, " +
                        "yn_id_disability, yn_id_given_birth, yn_id_hoh, " +
                        "yn_id_immun, yn_id_pregnant, yn_id_school, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', '{10}', " +
                        "'{11}', '{12}', " +
                        "'{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', '{18}', " +
                        "'{19}', '{20}', '{21}', " +
                        "'{22}', '{23}', " +
                        "'{24}', '{25}', " +
                        "'{26}','{27}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hhm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hhm_id"].ToString(),
                        utilFormatting.StringForSQL(dr["hhm_first_name"].ToString()), utilFormatting.StringForSQL(dr["hhm_last_name"].ToString()),
                        dr["hhm_number"].ToString(), dr["hhm_year_of_birth"].ToString(),
                        dr["dtp_id"].ToString(), dr["edu_id"].ToString(), dr["gnd_id"].ToString(),
                        dr["hh_id"].ToString(), dr["hst_id"].ToString(), dr["mst_id"].ToString(),
                        dr["prf_id"].ToString(), dr["prt_id"].ToString(),
                        dr["yn_id_art"].ToString(), dr["yn_id_birth_registration"].ToString(), dr["yn_id_caregiver"].ToString(),
                        dr["yn_id_disability"].ToString(), dr["yn_id_given_birth"].ToString(), dr["yn_id_hoh"].ToString(),
                        dr["yn_id_immun"].ToString(), dr["yn_id_pregnant"].ToString(), dr["yn_id_school"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household_member

                #region hh_household_home_visit
                case "hh_household_home_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hhv_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hhv_id, " +
                        "hhv_date, hhv_date_next_visit, " +
                        "hhv_household_income, " +
                        "hhv_comments, hhv_next_steps, " +
                        "hhv_swk_code, hhv_visitor_tel, " +
                        "am_id, hvhs_id, hvr_id, hh_id, hhm_id, hnr_id_visitor, swk_id, swk_id_visitor, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "'{1}', '{2}', " +
                        "{3}, " +
                        "'{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}', '{19}', " +
                        "'{20}','{21}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hhv_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhv_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect,
                        dr["hhv_id"].ToString(), 
                        Convert.ToDateTime(dr["hhv_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["hhv_date_next_visit"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["hhv_household_income"].ToString(),
                        utilFormatting.StringForSQL(dr["hhv_comments"].ToString()), utilFormatting.StringForSQL(dr["hhv_next_steps"].ToString()),
                        utilFormatting.StringForSQL(dr["hhv_swk_code"].ToString()), utilFormatting.StringForSQL(dr["hhv_visitor_tel"].ToString()),
                        dr["am_id"].ToString(), dr["hvhs_id"].ToString(), dr["hvr_id"].ToString(), dr["hh_id"].ToString(), 
                        dr["hhm_id"].ToString(), dr["hnr_id_visitor"].ToString(), dr["swk_id"].ToString(), dr["swk_id_visitor"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household_home_visit

                #region hh_household_home_visit_member
                case "hh_household_home_visit_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hhvm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hhvm_id, hhm_id, hhv_id, hst_id, " +
                        "yn_id_hhm_active, " +
                        "yn_id_edu_sensitised, yn_id_es_aflateen, yn_id_es_agro, yn_id_es_apprenticeship, yn_id_es_silc, " +
                        "yn_id_fsn_nutrition, yn_id_fsn_referred, yn_id_fsn_wash, " +
                        "ynna_id_edu_enrolled, ynna_id_edu_support, ynna_id_fsn_education, ynna_id_fsn_support, " +
                        "ynna_id_hhp_adhering, ynna_id_hhp_art, ynna_id_hhp_referred, " +
                        "ynna_id_pro_birth_certificate, ynna_id_pro_birth_registration, ynna_id_pro_child_abuse, " +
                        "ynna_id_pro_child_labour, ynna_id_pro_reintegrated, " +
                        "ynna_id_ps_parenting, ynna_id_ps_support, ynna_id_ps_violence, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,yn_id_es_caregiver_group,ynna_id_edu_attend_school_regularly,ynna_id_es_other_lending_group) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', '{3}', " +
                        "'{4}', " +
                        "'{5}', '{6}', '{7}', '{8}', '{9}', " +
                        "'{10}', '{11}', '{12}', " +
                        "'{13}', '{14}', '{15}', '{16}', " +
                        "'{17}', '{18}', '{19}', " +
                        "'{20}', '{21}', '{22}', " + 
                        "'{23}', '{24}', " +
                        "'{25}', '{26}', '{27}', " +
                        "'{28}', '{29}', " +
                        "'{30}', '{31}', " +
                        "'{32}','{33}','{34}','{35}','{36}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hhvm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhvm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect,
                        dr["hhvm_id"].ToString(), dr["hhm_id"].ToString(), dr["hhv_id"].ToString(), dr["hst_id"].ToString(), 
                        dr["yn_id_hhm_active"].ToString(),
                        dr["yn_id_edu_sensitised"].ToString(), dr["yn_id_es_aflateen"].ToString(), dr["yn_id_es_agro"].ToString(), dr["yn_id_es_apprenticeship"].ToString(), dr["yn_id_es_silc"].ToString(),
                        dr["yn_id_fsn_nutrition"].ToString(), dr["yn_id_fsn_referred"].ToString(), dr["yn_id_fsn_wash"].ToString(),
                        dr["ynna_id_edu_enrolled"].ToString(), dr["ynna_id_edu_support"].ToString(), dr["ynna_id_fsn_education"].ToString(), dr["ynna_id_fsn_support"].ToString(),
                        dr["ynna_id_hhp_adhering"].ToString(), dr["ynna_id_hhp_art"].ToString(), dr["ynna_id_hhp_referred"].ToString(),
                        dr["ynna_id_pro_birth_certificate"].ToString(), dr["ynna_id_pro_birth_registration"].ToString(), dr["ynna_id_pro_child_abuse"].ToString(),
                        dr["ynna_id_pro_child_labour"].ToString(), dr["ynna_id_pro_reintegrated"].ToString(), 
                        dr["ynna_id_ps_parenting"].ToString(), dr["ynna_id_ps_support"].ToString(), dr["ynna_id_ps_violence"].ToString(), 
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), dr["yn_id_es_caregiver_group"].ToString(), dr["ynna_id_edu_attend_school_regularly"].ToString(), dr["ynna_id_es_other_lending_group"].ToString());
                    }
                    break;
                #endregion hh_household_home_visit_member

                #region hh_ovc_identification_prioritization
                case "hh_ovc_identification_prioritization":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE oip_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(oip_id, oip_comments, " +
                        "oip_date, " +
                        "oip_18_above_female, oip_18_above_male, oip_18_below_female, " +
                        "oip_18_below_male, oip_hiv_adult, oip_hiv_children, " +
                        "oip_cp_month, oip_interviewer_tel, " +
                        "cso_id, hh_id, hhm_id, swk_id, " +
                        "yn_id_children, " +
                        "yn_id_cp_abuse, yn_id_cp_abuse_physical, yn_id_cp_abuse_sexual, " +
                        "yn_id_cp_marriage_teen_parent, yn_id_cp_neglected, yn_id_cp_no_birth_register, " +
                        "yn_id_cp_orphan, yn_id_cp_pregnancy, yn_id_cp_referred, " +
                        "yn_id_edu_referred, yn_id_es_child_headed, yn_id_es_disability, " +
                        "yn_id_es_employment, yn_id_es_expense, yn_id_es_referred, " +
                        "yn_id_fsn_meals, yn_id_fsn_malnourished, yn_id_fsn_referred, " +
                        "yn_id_hwss_hiv_positive, yn_id_hwss_hiv_status, yn_id_hwss_referred, " +
                        "yn_id_hwss_shelter, yn_id_hwss_water, " +
                        "yn_id_psbc_referred, yn_id_psbc_stigmatized, " +
                        "ynna_id_edu_missed_school, ynna_id_edu_not_enrolled, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,ids_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', " +
                        "{3}, {4}, {5}, " +
                        "{6}, {7}, {8}, " +
                        "'{9}', '{10}', " +
                        "'{11}', '{12}', '{13}', '{14}', " +
                        "'{15}', " +
                        "'{16}', '{17}', '{18}', " +
                        "'{19}', '{20}', '{21}', " +
                        "'{22}', '{23}', '{24}', " +
                        "'{25}', '{26}', '{27}', " +
                        "'{28}', '{29}', '{30}', " +
                        "'{31}', '{32}', '{33}', " +
                        "'{34}', '{35}', '{36}', " +
                        "'{37}', '{38}', " +
                        "'{39}', '{40}', " +
                        "'{41}', '{42}', " +
                        "'{43}', '{44}', " +
                        "'{45}', '{46}', " +
                        "'{47}','{48}','{49}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["oip_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["oip_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["oip_id"].ToString(), utilFormatting.StringForSQL(dr["oip_comments"].ToString()),
                        Convert.ToDateTime(dr["oip_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["oip_18_above_female"].ToString(), dr["oip_18_above_male"].ToString(), dr["oip_18_below_female"].ToString(),
                        dr["oip_18_below_male"].ToString(), dr["oip_hiv_adult"].ToString(), dr["oip_hiv_children"].ToString(),
                        dr["oip_cp_month"].ToString(), utilFormatting.StringForSQL(dr["oip_interviewer_tel"].ToString()),
                        dr["cso_id"].ToString(), dr["hh_id"].ToString(), dr["hhm_id"].ToString(), dr["swk_id"].ToString(),
                        dr["yn_id_children"].ToString(),
                        dr["yn_id_cp_abuse"].ToString(), dr["yn_id_cp_abuse_physical"].ToString(), dr["yn_id_cp_abuse_sexual"].ToString(),
                        dr["yn_id_cp_marriage_teen_parent"].ToString(), dr["yn_id_cp_neglected"].ToString(), dr["yn_id_cp_no_birth_register"].ToString(),
                        dr["yn_id_cp_orphan"].ToString(), dr["yn_id_cp_pregnancy"].ToString(), dr["yn_id_cp_referred"].ToString(),
                        dr["yn_id_edu_referred"].ToString(), dr["yn_id_es_child_headed"].ToString(), dr["yn_id_es_disability"].ToString(),
                        dr["yn_id_es_employment"].ToString(), dr["yn_id_es_expense"].ToString(), dr["yn_id_es_referred"].ToString(),
                        dr["yn_id_fsn_meals"].ToString(), dr["yn_id_fsn_malnourished"].ToString(), dr["yn_id_fsn_referred"].ToString(),
                        dr["yn_id_hwss_hiv_positive"].ToString(), dr["yn_id_hwss_hiv_status"].ToString(), dr["yn_id_hwss_referred"].ToString(),
                        dr["yn_id_hwss_shelter"].ToString(), dr["yn_id_hwss_water"].ToString(),
                        dr["yn_id_psbc_referred"].ToString(), dr["yn_id_psbc_stigmatized"].ToString(),
                        dr["ynna_id_edu_missed_school"].ToString(), dr["ynna_id_edu_not_enrolled"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), dr["ids_id"].ToString());
                    }
                    break;
                #endregion hh_ovc_identification_prioritization

                #region hh_referral
                case "hh_referral":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE rfr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(rfr_id, rfr_serial_no, rfr_ra_location, " +
                        "rfr_ra_tel, rfr_ra_email, " +
                        "rfr_ra_person_name, rfr_ra_person_title, " +
                        "rfr_ra_person_tel, rfr_ra_person_email, " +
                        "rfr_ra_date, " +
                        "rfr_cd_case_no, " +
                        "rfr_cd_nature, rfr_cd_perpetrator, rfr_cd_perpetrator_relationship, " +
                        "rfr_cd_date_occured, rfr_cd_other, " +
                        "rfr_cd_accompany_name, rfr_cd_accompany_tel, " +
                        "rfr_cd_accompany_email, rfr_cd_accompany_relationship, " +
                        "rfr_cd_guardian_name, rfr_cd_guardian_tel, rfr_cd_guardian_village, " +
                        "rfr_service_before, rfr_service_referral, rfr_service_discussion, " +
                        "rfr_ar_name, rfr_ar_location, rfr_ar_contact_name, " +
                        "rfr_ar_contact_tel, rfr_ar_contact_email, " +
                        "rfr_fb_agency_name, rfr_fb_person_name, rfr_fb_person_title, " +
                        "rfr_fb_location, rfr_fb_tel, rfr_fb_email, " +
                        "rfr_fb_date, " +
                        "rfr_fb_id_no, rfr_fb_case_no, " +
                        "rfr_fb_service, rfr_fb_other, " +
                        "hhm_id, prt_cso_id_ra, wrd_id_guardian, " +
                        "yn_id_discussion, yn_id_helpline, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', " +
                        "'{10}', " +
                        "'{11}', '{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}', '{19}', " +
                        "'{20}', '{21}', '{22}', " +
                        "'{23}', '{24}', '{25}', " +
                        "'{26}', '{27}', '{28}', " +
                        "'{29}', '{30}', " +
                        "'{31}', '{32}', '{33}', " +
                        "'{34}', '{35}', '{36}', " +
                        "'{37}', " +
                        "'{38}', '{39}', " +
                        "'{40}', '{41}', " +
                        "'{42}', '{43}', '{44}', " +
                        "'{45}', '{46}', " +
                        "'{47}', '{48}', " +
                        "'{49}', '{50}', " +
                        "'{51}','{52}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["rfr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rfr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["rfr_id"].ToString(), utilFormatting.StringForSQL(dr["rfr_serial_no"].ToString()), utilFormatting.StringForSQL(dr["rfr_ra_location"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_ra_tel"].ToString()), utilFormatting.StringForSQL(dr["rfr_ra_email"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_ra_person_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_ra_person_title"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_ra_person_tel"].ToString()), utilFormatting.StringForSQL(dr["rfr_ra_person_email"].ToString()),
                        Convert.ToDateTime(dr["rfr_ra_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["rfr_cd_case_no"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_cd_nature"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_perpetrator"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_perpetrator_relationship"].ToString()),
                        Convert.ToDateTime(dr["rfr_cd_date_occured"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["rfr_cd_other"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_cd_accompany_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_accompany_tel"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_cd_accompany_email"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_accompany_relationship"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_cd_guardian_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_guardian_tel"].ToString()), utilFormatting.StringForSQL(dr["rfr_cd_guardian_village"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_service_before"].ToString()), utilFormatting.StringForSQL(dr["rfr_service_referral"].ToString()), utilFormatting.StringForSQL(dr["rfr_service_discussion"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_ar_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_ar_location"].ToString()), utilFormatting.StringForSQL(dr["rfr_ar_contact_name"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_ar_contact_tel"].ToString()), utilFormatting.StringForSQL(dr["rfr_ar_contact_email"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_fb_agency_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_person_name"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_person_title"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_fb_location"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_tel"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_email"].ToString()),
                        Convert.ToDateTime(dr["rfr_fb_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["rfr_fb_id_no"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_case_no"].ToString()),
                        utilFormatting.StringForSQL(dr["rfr_fb_service"].ToString()), utilFormatting.StringForSQL(dr["rfr_fb_other"].ToString()),
                        dr["hhm_id"].ToString(), dr["prt_cso_id_ra"].ToString(), dr["wrd_id_guardian"].ToString(),
                        dr["yn_id_discussion"].ToString(), dr["yn_id_helpline"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_referral

                #region hh_referral_service_provided
                case "hh_referral_service_provided":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE rsp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(rsp_id, rfr_id, svp_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["rsp_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rsp_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["rsp_id"].ToString(), dr["rfr_id"].ToString(), dr["svp_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_referral_service_provided

                #region hh_referral_service_referred
                case "hh_referral_service_referred":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "DELETE FROM {0} WHERE rsr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(rsr_id, rfr_id, svr_id, " +
                        "usr_id_create, " +
                        "usr_date_create, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', " +
                        "'{4}', " +
                        "'{5}','{6}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["rsr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rsr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["rsr_id"].ToString(), dr["rfr_id"].ToString(), dr["svr_id"].ToString(),
                        dr["usr_id_create"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_referral_service_referred

                #region prt_alternative_care_panel
                case "prt_alternative_care_panel":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE acp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(acp_id, acp_date, " +
                        "fy_id, prt_id, rgn_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}','{10}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["acp_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["acp_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["acp_id"].ToString(), Convert.ToDateTime(dr["acp_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["fy_id"].ToString(), dr["prt_id"].ToString(), dr["rgn_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_alternative_care_panel

                #region prt_alternative_care_panel_district
                case "prt_alternative_care_panel_district":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE acpd_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(acpd_id, acpd_support_extended, " +
                        "acp_id, dst_id, yn_id_established, yn_id_functional, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["acpd_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["acpd_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["acpd_id"].ToString(), utilFormatting.StringForSQL(dr["acpd_support_extended"].ToString()),
                        dr["acp_id"].ToString(), dr["dst_id"].ToString(), dr["yn_id_established"].ToString(), dr["yn_id_functional"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_alternative_care_panel_district

                #region prt_cbsd_resource_allocation
                case "prt_cbsd_resource_allocation":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE cra_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(cra_id, cra_date, " +
                        "fy_id, prt_id, rgn_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}','{10}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["cra_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["cra_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["cra_id"].ToString(), Convert.ToDateTime(dr["cra_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["fy_id"].ToString(), dr["prt_id"].ToString(), dr["rgn_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_resource_allocation

                #region prt_cbsd_resource_allocation_district
                case "prt_cbsd_resource_allocation_district":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE crad_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(crad_id, " +
                        "crad_cbsd_budget, crad_cbsd_realization, " +
                        "crad_district_grant_budget, crad_probation_realization, crad_probation_share, " +
                        "cra_id, dst_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,crad_partner_funding) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "{1}, {2}, " +
                        "{3}, {4}, {5}, " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}','{13}',{14}";
                    strId = dt.Rows[dt.Rows.Count - 1]["crad_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["crad_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["crad_id"].ToString(),
                        dr["crad_cbsd_budget"].ToString(), dr["crad_cbsd_realization"].ToString(),
                        dr["crad_district_grant_budget"].ToString(), dr["crad_probation_realization"].ToString(), dr["crad_probation_share"].ToString(),
                        dr["cra_id"].ToString(), dr["dst_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), Convert.ToDecimal(dr["crad_partner_funding"].ToString()));
                    }
                    break;
                #endregion prt_cbsd_resource_allocation_district

                #region prt_cbsd_staff_appraisal_tracking
                case "prt_cbsd_staff_appraisal_tracking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE csat_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(csat_id, " +
                        "csat_date, csat_comment, " +
                        "dst_id, fy_id, prt_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["csat_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["csat_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["csat_id"].ToString(),
                        Convert.ToDateTime(dr["csat_date"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["csat_comment"].ToString()),
                        dr["dst_id"].ToString(), dr["fy_id"].ToString(), dr["prt_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_staff_appraisal_tracking

                #region prt_cbsd_staff_appraisal_tracking_line
                case "prt_cbsd_staff_appraisal_tracking_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE csatl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(csatl_id, " +
                        "csatl_posts_approved, csatl_posts_filled, " +
                        "csat_id, ss_id, yn_id_conducted, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "{1}, {2}, " +
                        "'{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["csatl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["csatl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["csatl_id"].ToString(),
                        dr["csatl_posts_approved"].ToString(), dr["csatl_posts_filled"].ToString(),
                        dr["csat_id"].ToString(), dr["ss_id"].ToString(), dr["yn_id_conducted"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_staff_appraisal_tracking_line

                #region prt_district_ovc_checklist
                case "prt_district_ovc_checklist":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE doc_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(doc_id, doc_date, " +
                        "doc_cso_report, doc_cso_total, doc_sub_county_reviewed, doc_sub_county_total, " +
                        "dst_id, fy_id, qy_id, " +
                        "yn_id_dovcc_actions_taken, yn_id_dovcc_minutes, yn_id_dovcc_minutes_available, " +
                        "yn_id_meetings_held, yn_id_membership_constituted, yn_id_ovcmis_district, " +
                        "yn_id_supervision_reports, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "{2}, {3}, {4}, {5}, " +
                        "'{6}', '{7}', '{8}', " +
                        "'{9}', '{10}', '{11}', " +
                        "'{12}', '{13}', '{14}', " +
                        "'{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}', '{19}', " +
                        "'{20}','{21}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["doc_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["doc_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["doc_id"].ToString(), Convert.ToDateTime(dr["doc_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["doc_cso_report"].ToString(), dr["doc_cso_total"].ToString(), dr["doc_sub_county_reviewed"].ToString(), dr["doc_sub_county_total"].ToString(),
                        dr["dst_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(),
                        dr["yn_id_dovcc_actions_taken"].ToString(), dr["yn_id_dovcc_minutes"].ToString(), dr["yn_id_dovcc_minutes_available"].ToString(),
                        dr["yn_id_meetings_held"].ToString(), dr["yn_id_membership_constituted"].ToString(), dr["yn_id_ovcmis_district"].ToString(),
                        dr["yn_id_supervision_reports"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion prt_district_ovc_checklist

                #region prt_institutional_care_summary
                case "prt_institutional_care_summary":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ics_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(ics_id, ics_date, " +
                        "dst_id, fy_id, qy_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,prt_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}','{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["ics_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ics_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ics_id"].ToString(), Convert.ToDateTime(dr["ics_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["dst_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), dr["prt_id"].ToString());
                    }
                    break;
                #endregion prt_institutional_care_summary

                #region prt_institutional_care_summary_line
                case "prt_institutional_care_summary_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE icsl_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(icsl_id, " +
                        "icsl_caregiver_age, icsl_caregiver_name, " +
                        "icsl_child_age, icsl_child_name, " +
                        "icsl_contact_tel, icsl_contact_village, " +
                        "gnd_id_caregiver, gnd_id_child, ics_id, ins_id, wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id,idst_other,isct_other,iwrd_other) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "{1}, '{2}', " +
                        "{3}, '{4}', " +
                        "'{5}', '{6}', " +
                        "'{7}', '{8}', '{9}', '{10}', '{11}', " +
                        "'{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}','{17}','{18}','{19}','{20}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["icsl_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["icsl_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["icsl_id"].ToString(),
                        dr["icsl_caregiver_age"].ToString(), utilFormatting.StringForSQL(dr["icsl_caregiver_name"].ToString()),
                        dr["icsl_child_age"].ToString(), utilFormatting.StringForSQL(dr["icsl_child_name"].ToString()),
                        utilFormatting.StringForSQL(dr["icsl_contact_tel"].ToString()), utilFormatting.StringForSQL(dr["icsl_contact_village"].ToString()),
                        dr["gnd_id_caregiver"].ToString(), dr["gnd_id_child"].ToString(), dr["ics_id"].ToString(), dr["ins_id"].ToString(), dr["wrd_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString(), dr["idst_other"].ToString(), dr["isct_other"].ToString(), dr["iwrd_other"].ToString());
                    }
                    break;
                #endregion prt_institutional_care_summary_line

                #region silc_financial_register
                case "silc_financial_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE sfr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(sfr_id, sfr_contact_details, " +
                        "cso_id, fy_id, qy_id, swk_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', '{4}', '{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}','{11}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["sfr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sfr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["sfr_id"].ToString(), utilFormatting.StringForSQL(dr["sfr_contact_details"].ToString()),
                        dr["cso_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["swk_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_financial_register

                #region silc_financial_register_group
                case "silc_financial_register_group":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE sfrg_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(sfrg_id, " +
                        "sfrg_members_female, sfrg_members_male, sfrg_amount_borrowed, " +
                        "sfr_id, sg_id, yn_id_borrowed, yn_id_linked, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "{1}, {2}, {3}, " +
                        "'{4}', '{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}','{13}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["sfrg_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sfrg_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect,  dr["sfrg_id"].ToString(),
                        dr["sfrg_members_female"].ToString(), dr["sfrg_members_male"].ToString(), dr["sfrg_amount_borrowed"].ToString(),
                        dr["sfr_id"].ToString(), dr["sg_id"].ToString(), dr["yn_id_borrowed"].ToString(), dr["yn_id_linked"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_financial_register_group

                #region silc_group
                case "silc_group":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE sg_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(sg_id, sg_name, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', '{3}', " +
                        "'{4}', '{5}', " +
                        "'{6}','{7}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["sg_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sg_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["sg_id"].ToString(), utilFormatting.StringForSQL(dr["sg_name"].ToString()),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_group

                #region silc_group_member
                case "silc_group_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE sgm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(sgm_id, sgm_name, " +
                        "sgm_status_reason, sgm_active, " +
                        "hhm_id, mtp_id, sg_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', " +
                        "'{2}', {3}, " +
                        "'{4}', '{5}', '{6}', " +
                        "'{7}', '{8}', " +
                        "'{9}', '{10}', " +
                        "'{11}','{12}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["sgm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sgm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["sgm_id"].ToString(), utilFormatting.StringForSQL(dr["sgm_name"].ToString()),
                        utilFormatting.StringForSQL(dr["sgm_status_reason"].ToString()), Convert.ToInt32(Convert.ToBoolean(dr["sgm_active"])),
                        dr["hhm_id"].ToString(), dr["mtp_id"].ToString(), dr["sg_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_group_member

                #region silc_savings_register
                case "silc_savings_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ssr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(ssr_id, ssr_cycle_number, ssr_share_value, " +
                        "cso_id, fy_id, qy_id, wrd_id, sg_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', {2},  " +
                        "'{3}', '{4}', '{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}','{13}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["ssr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ssr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ssr_id"].ToString(), utilFormatting.StringForSQL(dr["ssr_cycle_number"].ToString()), dr["ssr_share_value"].ToString(),
                        dr["cso_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["wrd_id"].ToString(), dr["sg_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_savings_register

                #region silc_savings_register_member
                case "silc_savings_register_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ssrm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(ssrm_id, " +
                        "ssrm_shares_bought_today, ssrm_shares_brought_forward, " +
                        "ssrm_shares_redeemed, ssrm_shares_total, " +
                        "ssrm_welfare_fund, " +
                        "sgm_id, ssr_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', " +
                        "{1}, {2}, " +
                        "{3}, {4}, " +
                        "'{5}', " +
                        "'{6}', '{7}', " +
                        "'{8}', '{9}', " +
                        "'{10}', '{11}', " +
                        "'{12}','{13}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["ssrm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ssrm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ssrm_id"].ToString(),
                        dr["ssrm_shares_bought_today"].ToString(), dr["ssrm_shares_brought_forward"].ToString(),
                        dr["ssrm_shares_redeemed"].ToString(), dr["ssrm_shares_total"].ToString(),
                        utilFormatting.StringForSQL(dr["ssrm_welfare_fund"].ToString()),
                        dr["sgm_id"].ToString(), dr["ssr_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_savings_register_member

                #region swm_social_worker
                case "swm_social_worker":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE swk_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(swk_id, swk_first_name, swk_last_name, " +
                        "swk_email, swk_phone, swk_phone_other, " +
                        "swk_status_reason, swk_village, " +
                        "cso_id, hnr_id, swk_id_manager, " +
                        "sws_id, swt_id, wrd_id, " +
                        "usr_id_create, usr_id_update, " +
                        "usr_date_create, usr_date_update, " +
                        "ofc_id,district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', '{10}', " +
                        "'{11}', '{12}', '{13}', " +
                        "'{14}', '{15}', " +
                        "'{16}', '{17}', " +
                        "'{18}','{19}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["swk_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["swk_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["swk_id"].ToString(), utilFormatting.StringForSQL(dr["swk_first_name"].ToString()), utilFormatting.StringForSQL(dr["swk_last_name"].ToString()),
                        utilFormatting.StringForSQL(dr["swk_email"].ToString()), utilFormatting.StringForSQL(dr["swk_phone"].ToString()), utilFormatting.StringForSQL(dr["swk_phone_other"].ToString()),
                        utilFormatting.StringForSQL(dr["swk_status_reason"].ToString()), utilFormatting.StringForSQL(dr["swk_village"].ToString()),
                        dr["cso_id"].ToString(), dr["hnr_id"].ToString(), dr["swk_id_manager"].ToString(),
                        dr["sws_id"].ToString(), dr["swt_id"].ToString(), dr["wrd_id"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion swm_social_worker

                #region hh_household_linkages_tracking
                case "hh_household_linkages_tracking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hhm_linkages_record_guid IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(hhm_linkages_record_guid, partner_id, hhm_district_id, " +
                        "subcounty_id, parish_id, village, " +
                        "hhm_id, service_provider_id, " +
                        "usr_id_create, usr_id_update, usr_date_create, " +
                        "usr_date_update, ofc_id, district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', '{7}', " +
                        "'{8}', '{9}', '{10}', " +
                        "'{11}', '{12}', '{13}'";
                    strId = dt.Rows[dt.Rows.Count - 1]["hhm_linkages_record_guid"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhm_linkages_record_guid"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hhm_linkages_record_guid"].ToString(), utilFormatting.StringForSQL(dr["partner_id"].ToString()), utilFormatting.StringForSQL(dr["hhm_district_id"].ToString()),
                        utilFormatting.StringForSQL(dr["subcounty_id"].ToString()), utilFormatting.StringForSQL(dr["parish_id"].ToString()), utilFormatting.StringForSQL(dr["village"].ToString()),
                        utilFormatting.StringForSQL(dr["hhm_id"].ToString()), utilFormatting.StringForSQL(dr["service_provider_id"].ToString()),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;

                #endregion hh_household_linkages_tracking

                #region hh_household_linkages_services_required
                case "hh_household_linkages_services_required":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE lsr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(record_guid,hhm_linkages_record_guid, lsr_id, " +
                        "usr_id_create, usr_id_update, usr_date_create, " +
                        "usr_date_update, ofc_id, district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}', '{6}', '{7}'," +
                        "'{8}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["record_guid"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["record_guid"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["record_guid"].ToString(), dr["hhm_linkages_record_guid"].ToString(), utilFormatting.StringForSQL(dr["lsr_id"].ToString()),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;

                #endregion hh_household_linkages_services_required

                #region hh_household_linkages_services_provided
                case "hh_household_linkages_services_provided":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE lsp_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "(record_guid,lsp_id, hhm_linkages_record_guid, " +
                        "usr_id_create, usr_date_create, " +
                        "ofc_id, district_id) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}','{6}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["record_guid"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["record_guid"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["record_guid"].ToString(), dr["lsp_id"].ToString(), utilFormatting.StringForSQL(dr["hhm_linkages_record_guid"].ToString()),
                        dr["usr_id_create"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;

                #endregion hh_household_linkages_services_provided

                #region hh_household_risk_assessment_header
                case "hh_household_risk_assessment_header":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ras_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ras_id],[hh_code],[hh_id],[interviewed_member_id],[date_of_visit] ,[usr_id_create]" + 
                        ",[usr_id_update] ,[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}','{6}','{7}','{8}','{9}','{10}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ras_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ras_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ras_id"].ToString(), dr["hh_code"].ToString(), utilFormatting.StringForSQL(dr["hh_id"].ToString()),
                        dr["interviewed_member_id"].ToString(), Convert.ToDateTime(dr["date_of_visit"]).ToString("dd MMM yyyy HH:mm:ss"), dr["usr_id_create"].ToString(),
                        dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household_risk_assessment_header

                #region hh_household_risk_assessment_beneficiaries
                case "hh_household_risk_assessment_beneficiaries":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE rasm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ras_id],[rasm_id],[hh_member_id],[hh_member_code] ,[current_hiv_status_id] ,[is_on_art],[screen_hospital_last_six_months]" +
                         ",[screen_either_parents_deceased],[screen_either_siblings_deceased] ,[screen_poor_health_last_three_months],[screen_adult_child_with_hiv_or_tb]" +
                          ",[screen_below_relative_grade],[child_eligible_for_test_refferal],[care_giver_accepted_to_test_child],[test_result],[usr_id_create]" + 
                          ",[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id] ,[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}', '{1}', '{2}', " +
                        "'{3}', '{4}', " +
                        "'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["rasm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rasm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ras_id"].ToString(), dr["rasm_id"].ToString(), utilFormatting.StringForSQL(dr["hh_member_id"].ToString()),
                        dr["hh_member_code"].ToString(), dr["current_hiv_status_id"].ToString(), dr["is_on_art"].ToString(), dr["screen_hospital_last_six_months"].ToString(),
                        dr["screen_either_parents_deceased"].ToString(), dr["screen_either_siblings_deceased"].ToString(), dr["screen_poor_health_last_three_months"].ToString(),
                        dr["screen_adult_child_with_hiv_or_tb"].ToString(), dr["screen_below_relative_grade"].ToString(), dr["child_eligible_for_test_refferal"].ToString(),
                        dr["care_giver_accepted_to_test_child"].ToString(), dr["test_result"].ToString(), dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(),
                         Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                         dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household_risk_assessment_beneficiaries

                #region hh_household_improvement_plan
                case "hh_household_improvement_plan":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE hip_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([hip_id],[hh_code],[hh_id],[visit_date] ,[ov_below_seventeen_yrs_male],[ov_below_seventeen_yrs_female]" + 
                       ",[ov_above_eighteen_yrs_male],[ov_above_eighteen_yrs_female],[health_knows_status_of_children] ,[health_enrolled_on_art],[health_action_plan] " + 
                       ",[health_follow_up_date],[household_is_healthy],[safe_has_birth_certificates],[safe_no_child_abuse],[safe_action_plan],[safe_follow_up_date] " +
                      " ,[household_is_safe],[stable_source_of_income],[stable_financial_services],[stable_two_or_more_meals],[stable_action_plan],[stable_follow_up_date] " + 
                      " ,[household_is_stable],[schooled_all_attending_school],[schooled_attained_techinical_skill],[schooled_others],[schooled_action_plan],[schooled_follow_up_date] " + 
                      " ,[household_is_schooled],[sw_id],[sw_comment],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}'," +
                    "'{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["hip_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hip_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["hip_id"].ToString(), dr["hh_code"].ToString(), utilFormatting.StringForSQL(dr["hh_id"].ToString()),
                        Convert.ToDateTime(dr["visit_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToInt32( dr["ov_below_seventeen_yrs_male"].ToString()),Convert.ToInt32( dr["ov_below_seventeen_yrs_female"].ToString())
                        ,Convert.ToInt32( dr["ov_above_eighteen_yrs_male"].ToString()), Convert.ToInt32(dr["ov_above_eighteen_yrs_female"].ToString()),

                        dr["health_knows_status_of_children"].ToString(), dr["health_enrolled_on_art"].ToString(), dr["health_action_plan"].ToString(),
                        dr["health_follow_up_date"].ToString(), dr["household_is_healthy"].ToString(), dr["safe_has_birth_certificates"].ToString(),
                        dr["safe_no_child_abuse"].ToString(), dr["safe_action_plan"].ToString(), dr["safe_follow_up_date"].ToString(), dr["household_is_safe"].ToString(),
                        dr["stable_source_of_income"].ToString(), dr["stable_financial_services"].ToString(), dr["stable_two_or_more_meals"].ToString(), dr["stable_action_plan"].ToString(), dr["stable_follow_up_date"].ToString(),
                        dr["household_is_stable"].ToString(), dr["schooled_all_attending_school"].ToString(), dr["schooled_attained_techinical_skill"].ToString(), dr["schooled_others"].ToString(),
                        dr["schooled_action_plan"].ToString(), dr["schooled_follow_up_date"].ToString(), dr["household_is_schooled"].ToString(), dr["sw_id"].ToString(), dr["sw_comment"].ToString(),
                        dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion hh_household_improvement_plan

                #region silc_community_training_register
                case "silc_community_training_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ctr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ctr_id],[prt_id],[cso_id],[dst_id] ,[sct_id],[tr_name],[module_name],[tr_total_days] ,[tr_date_from] " +
                         ",[tr_date_to] ,[module_desc],[tr_venue] ,[trainer_type],[artisan_name],[facilitator_trainer_name] " +
                          ",[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ctr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ctr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ctr_id"].ToString(), dr["prt_id"].ToString(), utilFormatting.StringForSQL(dr["cso_id"].ToString()),
                        utilFormatting.StringForSQL(dr["dst_id"].ToString()), utilFormatting.StringForSQL(dr["sct_id"].ToString()), utilFormatting.StringForSQL(dr["tr_name"].ToString()),
                        utilFormatting.StringForSQL(dr["module_name"].ToString()), utilFormatting.StringForSQL(dr["tr_total_days"].ToString()), Convert.ToDateTime(dr["tr_date_from"]).ToString("dd MMM yyyy HH:mm:ss"),
                        Convert.ToDateTime(dr["tr_date_to"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["module_desc"].ToString()), utilFormatting.StringForSQL(dr["tr_venue"].ToString()),
                        utilFormatting.StringForSQL(dr["trainer_type"].ToString()), utilFormatting.StringForSQL(dr["artisan_name"].ToString()), utilFormatting.StringForSQL(dr["facilitator_trainer_name"].ToString()),
                        utilFormatting.StringForSQL(dr["usr_id_create"].ToString()), utilFormatting.StringForSQL(dr["usr_id_update"].ToString()),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_community_training_register

                #region silc_community_training_register_member
                case "silc_community_training_register_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ctrm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ctrm_id] ,[ctr_id],[ben_type] ,[hhm_code],[parcipant_name],[gnd_id],[age] " +
                         ",[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id] ) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ctrm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ctrm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ctrm_id"].ToString(), dr["ctr_id"].ToString(), utilFormatting.StringForSQL(dr["ben_type"].ToString()),
                        utilFormatting.StringForSQL(dr["hhm_code"].ToString()), utilFormatting.StringForSQL(dr["parcipant_name"].ToString()), utilFormatting.StringForSQL(dr["gnd_id"].ToString()),
                        utilFormatting.StringForSQL(dr["age"].ToString()), utilFormatting.StringForSQL(dr["usr_id_create"].ToString()), utilFormatting.StringForSQL(dr["usr_id_update"].ToString()),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_community_training_register_member

                #region silc_community_training_register_member_attendance_dates
                case "silc_community_training_register_member_attendance_dates":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ctrmD_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ctrmD_id],[ctrm_id],[date],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = "SELECT '{0}','{1}','{2}','{3}','{4}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ctrmD_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ctrmD_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ctrmD_id"].ToString(), dr["ctrm_id"].ToString(),
                        Convert.ToDateTime(dr["date"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion silc_community_training_register_member_attendance_dates

                #region ben_youth_training_inventory
                case "ben_youth_training_inventory":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE yti_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([yti_id],[prt_id],[cso_id] ,[dst_id] ,[sct_id] ,[wrd_id] ,[begin_date],[hhm_code] " +
                       ",[hhm_name] ,[grp_name] ,[age],[gnd_id],[training_type],[trainer_name],[exp_date_completion] " + 
                       ",[actual_date_completion],[usr_id_create] ,[usr_id_update],[usr_date_create] ,[usr_date_update] " + 
                       ",[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}'
                        ,'{20}','{21}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["yti_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["yti_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["yti_id"].ToString(), dr["prt_id"].ToString(), utilFormatting.StringForSQL(dr["cso_id"].ToString()),
                        utilFormatting.StringForSQL(dr["dst_id"].ToString()), utilFormatting.StringForSQL(dr["sct_id"].ToString()), utilFormatting.StringForSQL(dr["wrd_id"].ToString()),
                        Convert.ToDateTime(dr["begin_date"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["hhm_code"].ToString()), utilFormatting.StringForSQL(dr["hhm_name"].ToString()),
                        utilFormatting.StringForSQL(dr["grp_name"].ToString()), utilFormatting.StringForSQL(dr["age"].ToString()), utilFormatting.StringForSQL(dr["gnd_id"].ToString()),
                        utilFormatting.StringForSQL(dr["training_type"].ToString()), utilFormatting.StringForSQL(dr["trainer_name"].ToString()), Convert.ToDateTime(dr["exp_date_completion"]).ToString("dd MMM yyyy HH:mm:ss"),
                        Convert.ToDateTime(dr["actual_date_completion"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["usr_id_create"].ToString()), utilFormatting.StringForSQL(dr["usr_id_update"].ToString()),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_youth_training_inventory

                #region ben_youthgroup_savings_register
                case "ben_youthgroup_savings_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ysr_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ysr_id],[prt_id] ,[cso_id],[dst_id],[sct_id] ,[wrd_id],[village] " +
                       ",[month] ,[year],[ygrp_name] ,[ygrp_chairperson_name],[ygrp_chairperson_name_phone] " +
                       ",[youth_field_assisstant_name],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update] " +
                       ",[ofc_id] ,[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ysr_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ysr_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ysr_id"].ToString(), dr["prt_id"].ToString(), utilFormatting.StringForSQL(dr["cso_id"].ToString()),
                        utilFormatting.StringForSQL(dr["dst_id"].ToString()), utilFormatting.StringForSQL(dr["sct_id"].ToString()), utilFormatting.StringForSQL(dr["wrd_id"].ToString()),
                        utilFormatting.StringForSQL(dr["village"].ToString()), utilFormatting.StringForSQL(dr["month"].ToString()), utilFormatting.StringForSQL(dr["year"].ToString()),
                        utilFormatting.StringForSQL(dr["ygrp_name"].ToString()), utilFormatting.StringForSQL(dr["ygrp_chairperson_name"].ToString()), utilFormatting.StringForSQL(dr["ygrp_chairperson_name_phone"].ToString()),
                        utilFormatting.StringForSQL(dr["youth_field_assisstant_name"].ToString()),
                        utilFormatting.StringForSQL(dr["usr_id_create"].ToString()), utilFormatting.StringForSQL(dr["usr_id_update"].ToString()),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_youthgroup_savings_register

                #region ben_youthgroup_savings_register_member
                case "ben_youthgroup_savings_register_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ysrm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ysrm_id],[ysr_id],[hhm_code] ,[hhm_name],[usr_id_create],[usr_id_update],[usr_date_create] " +
                        ",[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ysrm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ysrm_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ysrm_id"].ToString(), dr["ysr_id"].ToString(), utilFormatting.StringForSQL(dr["hhm_code"].ToString()),
                        utilFormatting.StringForSQL(dr["hhm_name"].ToString()), utilFormatting.StringForSQL(dr["usr_id_create"].ToString()), utilFormatting.StringForSQL(dr["usr_id_update"].ToString()),
                        Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        dr["ofc_id"].ToString(), dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_youthgroup_savings_register_member

                #region ben_youthgroup_savings_register_member_amount
                case "ben_youthgroup_savings_register_member_amount":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ysrms_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ysrm_id],[ysrms_id] ,[total_savings],[amout_borrowed],[loan_purpose],[loan_purpose_other],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ysrms_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ysrms_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ysrm_id"].ToString(), dr["ysrms_id"].ToString(), utilFormatting.StringForSQL(dr["total_savings"].ToString()),
                        utilFormatting.StringForSQL(dr["amout_borrowed"].ToString()), utilFormatting.StringForSQL(dr["loan_purpose"].ToString()), utilFormatting.StringForSQL(dr["loan_purpose_other"].ToString()),
                        utilFormatting.StringForSQL(dr["district_id"].ToString()));
                    }
                    break;
                #endregion ben_youthgroup_savings_register_member_amount

                #region ben_education_subsidy_assessment
                case "ben_education_subsidy_assessment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ed_sub_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ed_sub_id],[prt_id],[cso_id],[dst_id],[sct_id],[wrd_id],[village],[assessment_date],[hhm_id_caregiver],[caregiver_phone],[hh_id],[usr_id_create] " +
                        ",[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ed_sub_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ed_sub_id"].ToString());
                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ed_sub_id"].ToString(), dr["prt_id"].ToString(), utilFormatting.StringForSQL(dr["cso_id"].ToString()),
                        utilFormatting.StringForSQL(dr["dst_id"].ToString()), utilFormatting.StringForSQL(dr["sct_id"].ToString()), utilFormatting.StringForSQL(dr["wrd_id"].ToString()),
                        utilFormatting.StringForSQL(dr["village"].ToString()), Convert.ToDateTime(dr["assessment_date"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["hhm_id_caregiver"].ToString()),
                        utilFormatting.StringForSQL(dr["caregiver_phone"].ToString()), utilFormatting.StringForSQL(dr["hh_id"].ToString()), utilFormatting.StringForSQL(dr["usr_id_create"].ToString()),
                        utilFormatting.StringForSQL(dr["usr_id_update"].ToString()), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"),
                        utilFormatting.StringForSQL(dr["ofc_id"].ToString()), utilFormatting.StringForSQL(dr["district_id"].ToString()));
                    }
                    break;
                #endregion ben_education_subsidy_assessment

                #region ben_education_subsidy_assessment_member
                case "ben_education_subsidy_assessment_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE ed_subm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([ed_subm_id],[ed_sub_id],[hhm_id],[last_class_completed],[prev_school],[drop_out_year],[dropout_reason],[yn_id_willing_to_study] " +

                       ",[enrollment_class],[ttps_id],[preffered_school],[caregiver_contribution],[yn_id_hh_head_in_silc_grp] " +

                       ",[yn_id_caregiver_commit_sch_attendance],[yn_id_caregiver_commit_pta_meeting],[yn_id_caregiver_commit_acad_performance] " +

                       ",[yn_id_caregiver_commit_project_interventions],[yn_id_caregiver_commit_contribute_fee],[yn_id_caregiver_commit_keep_child_in_sch] " +

                       ",[swk_id],[swk_phone],[psw_id],[psw_phone],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +

                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',
                                    '{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["ed_subm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ed_subm_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["ed_subm_id"].ToString(), dr["ed_sub_id"].ToString(), dr["hhm_id"].ToString(), utilFormatting.StringForSQL(dr["last_class_completed"].ToString()),
                        utilFormatting.StringForSQL(dr["prev_school"].ToString()), utilFormatting.StringForSQL(dr["drop_out_year"].ToString()), utilFormatting.StringForSQL(dr["dropout_reason"].ToString()),
                        utilFormatting.StringForSQL(dr["yn_id_willing_to_study"].ToString()), utilFormatting.StringForSQL(dr["enrollment_class"].ToString()), utilFormatting.StringForSQL(dr["ttps_id"].ToString()),
                        utilFormatting.StringForSQL(dr["preffered_school"].ToString()), utilFormatting.StringForSQL(dr["caregiver_contribution"].ToString()), utilFormatting.StringForSQL(dr["yn_id_hh_head_in_silc_grp"].ToString()),
                        utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_sch_attendance"].ToString()), utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_pta_meeting"].ToString()),
                        utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_acad_performance"].ToString()),
                        utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_project_interventions"].ToString()), utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_contribute_fee"].ToString()),
                        utilFormatting.StringForSQL(dr["yn_id_caregiver_commit_keep_child_in_sch"].ToString()), utilFormatting.StringForSQL(dr["swk_id"].ToString()), utilFormatting.StringForSQL(dr["swk_phone"].ToString()),
                        utilFormatting.StringForSQL(dr["psw_id"].ToString()), utilFormatting.StringForSQL(dr["psw_phone"].ToString()), utilFormatting.StringForSQL(dr["usr_id_create"].ToString()),
                        utilFormatting.StringForSQL(dr["usr_id_update"].ToString()), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                        Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(dr["ofc_id"].ToString()), utilFormatting.StringForSQL(dr["district_id"].ToString()));
                    }
                    break;
                #endregion ben_education_subsidy_assessment

                #region prt_subcounty_ovc_checklist
                case "prt_subcounty_ovc_checklist":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE soc_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([soc_id],[soc_date],[soc_cso_report],[soc_cso_total],[soc_action_points_implemented],[soc_action_points_total_identified],[dst_id] " + 
				       ",[fy_id],[qy_id],[yn_id_meetings_held],[yn_id_membership_constituted],[yn_id_cdo_supervision],[yn_signed_minutes_available] " +
				       ",[yn_id_sovcc_discussed_minutes_available],[yn_id_ovcmis_district],[usr_id_create] ,[usr_id_update],[usr_date_create],[usr_date_update] " + 
				       ",[ofc_id],[district_id],[sct_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',
                                    '{17}','{18}','{19}','{20}','{21}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["soc_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["soc_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["soc_id"].ToString(), Convert.ToDateTime(dr["soc_date"]).ToString("dd MMM yyyy HH:mm:ss"), Convert.ToInt32(dr["soc_cso_report"].ToString()),
                            Convert.ToInt32(dr["soc_cso_total"].ToString()), Convert.ToInt32(dr["soc_action_points_implemented"].ToString()), Convert.ToInt32(dr["soc_action_points_total_identified"].ToString()),
                            dr["dst_id"].ToString(), dr["fy_id"].ToString(), dr["qy_id"].ToString(), dr["yn_id_meetings_held"].ToString(), dr["yn_id_membership_constituted"].ToString(), dr["yn_id_cdo_supervision"].ToString(),
                            dr["yn_signed_minutes_available"].ToString(), dr["yn_id_sovcc_discussed_minutes_available"].ToString(), dr["yn_id_ovcmis_district"].ToString(),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), dr["ofc_id"].ToString(),
                             dr["district_id"].ToString(), dr["sct_id"].ToString());
                    }
                    break;
                #endregion prt_subcounty_ovc_checklist


                #region ben_agro_enterprise_ranking_matrix
                case "ben_agro_enterprise_ranking_matrix":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE agro_ent_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([agro_ent_id] ,[prt_id],[cso_id],[wrd_id],[date],[hhm_id] " +
                         ",[fa_name],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["agro_ent_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["agro_ent_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["agro_ent_id"].ToString(), dr["prt_id"].ToString(), dr["cso_id"].ToString(), dr["wrd_id"].ToString(), Convert.ToDateTime(dr["date"]).ToString("dd MMM yyyy HH:mm:ss"), dr["hhm_id"].ToString(),
                            dr["fa_name"].ToString(),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), dr["ofc_id"].ToString(),
                             dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_agro_enterprise_ranking_matrix

                #region ben_agro_enterprise_ranking_matrix_crop_ranking
                case "ben_agro_enterprise_ranking_matrix_crop_ranking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE agro_entm_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([agro_entm_id],[agro_ent_id],[crop_1_id],[crop_1_param1_score],[crop_1_param2_score],[crop_1_param3_score],[crop_1_param4_score],[crop_1_param5_score]" +
                       ",[crop_1_param6_score],[crop_1_param7_score],[crop_1_param8_score],[crop_1_total_score],[crop_1_rank]" +
                       ",[crop_2_id],[crop_2_param1_score],[crop_2_param2_score],[crop_2_param3_score],[crop_2_param4_score],[crop_2_param5_score],[crop_2_param6_score]" +
                       ",[crop_2_param7_score],[crop_2_param8_score],[crop_2_total_score],[crop_2_rank]" +
                       ",[crop3_id],[crop_3_param1_score],[crop_3_param2_score],[crop_3_param3_score],[crop_3_param4_score],[crop_3_param5_score],[crop_3_param6_score],[crop_3_param7_score]" +
                       ",[crop_3_param8_score],[crop_3_total_score],[crop_3_rank]" +
                       ",[crop_4_id],[crop_4_param1_score],[crop_4_param2_score],[crop_4_param3_score],[crop_4_param4_score],[crop_4_param5_score],[crop_4_param6_score],[crop_4_param7_score]" +
                       ",[crop_4_param8_score],[crop_4_total_score],[crop_4_rank]" +
		               ",[crop_5_id],[crop_5_param1_score],[crop_5_param2_score],[crop_5_param3_score],[crop_5_param4_score],[crop_5_param5_score],[crop_5_param6_score],[crop_5_param7_score]" +
                       ",[crop_5_param8_score],[crop_5_total_score],[crop_5_rank],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},'{13}',{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},'{24}',{25},{26},{27},{28},{29},{30},{31},
                    {32},{33},{34},'{35}',{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},'{46}',{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},'{57}','{58}','{59}','{60}','{61}','{62}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["agro_entm_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["agro_entm_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["agro_entm_id"].ToString(), dr["agro_ent_id"].ToString(), dr["crop_1_id"].ToString(), Convert.ToInt32(dr["crop_1_param1_score"].ToString()), Convert.ToInt32(dr["crop_1_param2_score"].ToString()),
                            Convert.ToInt32(dr["crop_1_param3_score"].ToString()), Convert.ToInt32(dr["crop_1_param4_score"].ToString()), Convert.ToInt32(dr["crop_1_param5_score"].ToString()), Convert.ToInt32(dr["crop_1_param6_score"].ToString()), Convert.ToInt32(dr["crop_1_param7_score"].ToString()),
                            Convert.ToInt32(dr["crop_1_param8_score"].ToString()), Convert.ToInt32(dr["crop_1_total_score"].ToString()), Convert.ToInt32(dr["crop_1_rank"].ToString()), dr["crop_2_id"].ToString(), Convert.ToInt32(dr["crop_2_param1_score"].ToString()), Convert.ToInt32(dr["crop_2_param2_score"].ToString()),
                            Convert.ToInt32(dr["crop_2_param3_score"].ToString()), Convert.ToInt32(dr["crop_2_param4_score"].ToString()), Convert.ToInt32(dr["crop_2_param5_score"].ToString()), Convert.ToInt32(dr["crop_2_param6_score"].ToString()), Convert.ToInt32(dr["crop_2_param7_score"].ToString()),
                            Convert.ToInt32(dr["crop_2_param8_score"].ToString()), Convert.ToInt32(dr["crop_2_total_score"].ToString()), Convert.ToInt32(dr["crop_2_rank"].ToString()), dr["crop3_id"].ToString(), Convert.ToInt32(dr["crop_3_param1_score"].ToString()), Convert.ToInt32(dr["crop_3_param2_score"].ToString()),
                            Convert.ToInt32(dr["crop_3_param3_score"].ToString()), Convert.ToInt32(dr["crop_3_param4_score"].ToString()), Convert.ToInt32(dr["crop_3_param5_score"].ToString()), Convert.ToInt32(dr["crop_3_param6_score"].ToString()), Convert.ToInt32(dr["crop_3_param7_score"].ToString()),
                            Convert.ToInt32(dr["crop_3_param8_score"].ToString()), Convert.ToInt32(dr["crop_3_total_score"].ToString()), Convert.ToInt32(dr["crop_3_rank"].ToString()), dr["crop_4_id"].ToString(), Convert.ToInt32(dr["crop_4_param1_score"].ToString()), Convert.ToInt32(dr["crop_4_param2_score"].ToString()),
                            Convert.ToInt32(dr["crop_4_param3_score"].ToString()), Convert.ToInt32(dr["crop_4_param4_score"].ToString()), Convert.ToInt32(dr["crop_4_param5_score"].ToString()), Convert.ToInt32(dr["crop_4_param6_score"].ToString()), Convert.ToInt32(dr["crop_4_param7_score"].ToString()),
                            Convert.ToInt32(dr["crop_4_param8_score"].ToString()), Convert.ToInt32(dr["crop_4_total_score"].ToString()), Convert.ToInt32(dr["crop_4_rank"].ToString()), dr["crop_5_id"].ToString(), Convert.ToInt32(dr["crop_5_param1_score"].ToString()), Convert.ToInt32(dr["crop_5_param2_score"].ToString()),
                            Convert.ToInt32(dr["crop_5_param3_score"].ToString()), Convert.ToInt32(dr["crop_5_param4_score"].ToString()), Convert.ToInt32(dr["crop_5_param5_score"].ToString()), Convert.ToInt32(dr["crop_5_param6_score"].ToString()), Convert.ToInt32(dr["crop_5_param7_score"].ToString()),
                            Convert.ToInt32(dr["crop_5_param8_score"].ToString()), Convert.ToInt32(dr["crop_5_total_score"].ToString()), Convert.ToInt32(dr["crop_5_rank"].ToString()),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), dr["ofc_id"].ToString(),
                             dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_agro_enterprise_ranking_matrix_crop_ranking

                #region ben_apprenticeship_skill_acquisition_tracking
                case "ben_apprenticeship_skill_acquisition_tracking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE asat_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([asat_id],[review_date_from],[review_date_to],[wrd_id],[hhm_id],[trade_id],[module_id],[youth_acquire_not_acquire_skill_reason]" +
                        ",[recommended_steps],[artisan_name],[artisan_report_date],[youth_skills_acquired],[yn_skill_not_acquired_well],[skill_not_acquired_well],[skill_not_acquired_well_reason]," +
                        "[youth_report_date],[dyo_name],[dyo_review_date],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'
                                    ,'{18}','{19}','{20}','{21}','{22}','{23}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["asat_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["asat_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["asat_id"].ToString(), Convert.ToDateTime(dr["review_date_from"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["review_date_to"]).ToString("dd MMM yyyy HH:mm:ss"), dr["wrd_id"].ToString(), dr["hhm_id"].ToString(), dr["trade_id"].ToString(),
                            dr["module_id"].ToString(), dr["youth_acquire_not_acquire_skill_reason"].ToString(), dr["recommended_steps"].ToString(), dr["artisan_name"].ToString(),
                            Convert.ToDateTime(dr["artisan_report_date"]).ToString("dd MMM yyyy HH:mm:ss"), dr["youth_skills_acquired"].ToString(), dr["yn_skill_not_acquired_well"].ToString(),
                            dr["skill_not_acquired_well"].ToString(), dr["skill_not_acquired_well_reason"].ToString(), Convert.ToDateTime(dr["youth_report_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                            dr["dyo_name"].ToString(), Convert.ToDateTime(dr["dyo_review_date"]).ToString("dd MMM yyyy HH:mm:ss"),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                #endregion ben_apprenticeship_skill_acquisition_tracking

                #region ben_apprenticeship_skill_acquisition_tracking_skill
                case "ben_apprenticeship_skill_acquisition_tracking_skill":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} DISABLE TRIGGER {0}_update " +
                        "DELETE FROM {0} WHERE asatskill_id IN ({1}) " +
                        "INSERT INTO {0} " +
                        "([asatskill_id],[asat_id],[module_id],[skill_id],[excellent_acquired_skr_id],[average_acquired_skr_id],[not_acquired_skr_id],[usr_id_create],[usr_id_update]" + 
                         ",[usr_date_create],[usr_date_update],[ofc_id],[district_id]) " +
                        "{2} " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_insert " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_update ";
                    strSQLSelect = @"SELECT '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'";

                    strId = dt.Rows[dt.Rows.Count - 1]["asatskill_id"].ToString();
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLData = strSQLData + "UNION ALL ";
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["asatskill_id"].ToString());

                        strSQLData = strSQLData + string.Format(strSQLSelect, dr["asatskill_id"].ToString(), dr["asat_id"].ToString(), dr["module_id"].ToString(), dr["skill_id"].ToString(),
                            dr["excellent_acquired_skr_id"].ToString(), dr["average_acquired_skr_id"].ToString(), dr["not_acquired_skr_id"].ToString(),
                            dr["usr_id_create"].ToString(), dr["usr_id_update"].ToString(), Convert.ToDateTime(dr["usr_date_create"]).ToString("dd MMM yyyy HH:mm:ss"),
                            Convert.ToDateTime(dr["usr_date_update"]).ToString("dd MMM yyyy HH:mm:ss"), dr["ofc_id"].ToString(),dr["district_id"].ToString());
                    }
                    break;
                    #endregion ben_apprenticeship_skill_acquisition_tracking_skill
            }

            if (strSQL.Length != 0)
            {
                try
                {
                    dbCon.TransactionBegin();
                    strSQL = string.Format(strSQL, strTable, strSQLDelete, strSQLData);
                    dbCon.ExecuteNonQuery(strSQL);
                    dbCon.TransactionCommit();
                }
                catch (Exception exc)
                {
                    dbCon.TransactionRollback();
                    throw exc;
                }
            }
            #endregion Process Records

            return strId;
        }

        public string ProcessDownloadDelete(string strTable, DataTable dt, DBConnection dbCon)
        {
            #region Variables
            DataRow dr = null;

            string strSQL = string.Empty;
            string strSQLDelete = string.Empty;
            #endregion Variables

            #region Process Records
            switch (strTable)
            {
                #region ben_activity_training
                case "ben_activity_training":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE at_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["at_id"].ToString());
                    }
                    break;
                #endregion ben_activity_training

                #region ben_activity_training_participant
                case "ben_activity_training_participant":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE atp_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["atp_id"].ToString());
                    }
                    break;
                #endregion ben_activity_training_participant

                #region ben_apprenticeship_register_line
                case "ben_apprenticeship_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE aprl_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["aprl_id"].ToString());
                    }
                    break;
                #endregion ben_apprenticeship_register_line

                #region ben_girl_education_register
                case "ben_girl_education_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE ger_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ger_id"].ToString());
                    }
                    break;
                #endregion ben_girl_education_register

                #region ben_girl_education_register_child
                case "ben_girl_education_register_child":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE gerc_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["gerc_id"].ToString());
                    }
                    break;
                #endregion ben_girl_education_register_child

                #region ben_service_register
                case "ben_service_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE svr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svr_id"].ToString());
                    }
                    break;
                #endregion ben_service_register

                #region ben_service_register_line
                case "ben_service_register_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE svrl_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svrl_id"].ToString());
                    }
                    break;
                #endregion ben_service_register_line

                #region ben_service_register_line_social_economic
                case "ben_service_register_line_social_economic":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE svrlse_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["svrlse_id"].ToString());
                    }
                    break;
                #endregion ben_service_register_line_social_economic

                #region ben_value_chain_register
                case "ben_value_chain_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE vcr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["vcr_id"].ToString());
                    }
                    break;
                #endregion ben_value_chain_register

                #region ben_value_chain_register_actor
                case "ben_value_chain_register_actor":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE vcra_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["vcra_id"].ToString());
                    }
                    break;
                #endregion ben_value_chain_register_actor

                #region drm_enrollment
                case "drm_enrollment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE de_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["de_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment

                #region drm_enrollment_member
                case "drm_enrollment_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE dem_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dem_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member

                #region drm_enrollment_member_segment
                case "drm_enrollment_member_segment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE dems_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dems_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member_segment

                #region drm_enrollment_member_visit
                case "drm_enrollment_member_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE demv_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["demv_id"].ToString());
                    }
                    break;
                #endregion drm_enrollment_member_visit

                #region drm_member
                case "drm_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE dm_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["dm_id"].ToString());
                    }
                    break;
                #endregion drm_member

                #region hh_home_visit
                case "hh_home_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hv_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hv_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit

                #region hh_home_visit_service
                case "hh_home_visit_service":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hvs_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hvs_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit_service

                #region hh_home_visit_service_previous
                case "hh_home_visit_service_previous":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hvsp_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hvsp_id"].ToString());
                    }
                    break;
                #endregion hh_home_visit_service_previous

                #region hh_household
                case "hh_household":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hh_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hh_id"].ToString());
                    }
                    break;
                #endregion hh_household

                #region hh_household_assessment
                case "hh_household_assessment":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hha_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hha_id"].ToString());
                    }
                    break;
                #endregion hh_household_assessment

                #region hh_household_assessment_member
                case "hh_household_assessment_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE ham_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ham_id"].ToString());
                    }
                    break;
                #endregion hh_household_assessment_member

                #region hh_household_member
                case "hh_household_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hhm_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhm_id"].ToString());
                    }
                    break;
                #endregion hh_household_member

                #region hh_household_home_visit
                case "hh_household_home_visit":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hhv_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhv_id"].ToString());
                    }
                    break;
                #endregion hh_household_assessment

                #region hh_household_home_visit_member
                case "hh_household_home_visit_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE hhvm_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["hhvm_id"].ToString());
                    }
                    break;
                #endregion hh_household_assessment_member

                #region hh_ovc_identification_prioritization
                case "hh_ovc_identification_prioritization":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE oip_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["oip_id"].ToString());
                    }
                    break;
                #endregion hh_ovc_identification_prioritization

                #region hh_referral
                case "hh_referral":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE rfr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rfr_id"].ToString());
                    }
                    break;
                #endregion hh_referral

                #region hh_referral_service_provided
                case "hh_referral_service_provided":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE rsp_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rsp_id"].ToString());
                    }
                    break;
                #endregion hh_referral_service_provided

                #region hh_referral_service_referred
                case "hh_referral_service_referred":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE rsr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["rsr_id"].ToString());
                    }
                    break;
                #endregion hh_referral_service_referred

                #region prt_alternative_care_panel
                case "prt_alternative_care_panel":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE acp_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["acp_id"].ToString());
                    }
                    break;
                #endregion prt_alternative_care_panel

                #region prt_alternative_care_panel_district
                case "prt_alternative_care_panel_district":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE acpd_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["acpd_id"].ToString());
                    }
                    break;
                #endregion prt_alternative_care_panel_district

                #region prt_cbsd_resource_allocation
                case "prt_cbsd_resource_allocation":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE cra_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["cra_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_resource_allocation

                #region prt_cbsd_resource_allocation_district
                case "prt_cbsd_resource_allocation_district":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE crad_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["crad_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_resource_allocation_district

                #region prt_cbsd_staff_appraisal_tracking
                case "prt_cbsd_staff_appraisal_tracking":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE csat_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["csat_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_staff_appraisal_tracking

                #region prt_cbsd_staff_appraisal_tracking_line
                case "prt_cbsd_staff_appraisal_tracking_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE csatl_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["csatl_id"].ToString());
                    }
                    break;
                #endregion prt_cbsd_staff_appraisal_tracking_line

                #region prt_district_ovc_checklist
                case "prt_district_ovc_checklist":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE doc_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["doc_id"].ToString());
                    }
                    break;
                #endregion prt_district_ovc_checklist

                #region prt_institutional_care_summary
                case "prt_institutional_care_summary":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE ics_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ics_id"].ToString());
                    }
                    break;
                #endregion prt_institutional_care_summary

                #region prt_institutional_care_summary_line
                case "prt_institutional_care_summary_line":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE icsl_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["icsl_id"].ToString());
                    }
                    break;
                #endregion prt_institutional_care_summary_line

                #region silc_financial_register
                case "silc_financial_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE sfr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sfr_id"].ToString());
                    }
                    break;
                #endregion silc_financial_register

                #region silc_financial_register_group
                case "silc_financial_register_group":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE sfrg_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sfrg_id"].ToString());
                    }
                    break;
                #endregion silc_financial_register_group

                #region silc_group
                case "silc_group":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE sg_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sg_id"].ToString());
                    }
                    break;
                #endregion silc_group

                #region silc_group_member
                case "silc_group_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE sgm_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["sgm_id"].ToString());
                    }
                    break;
                #endregion silc_group_member

                #region silc_savings_register
                case "silc_savings_register":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE ssr_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ssr_id"].ToString());
                    }
                    break;
                #endregion silc_savings_register

                #region silc_savings_register_member
                case "silc_savings_register_member":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE ssrm_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["ssrm_id"].ToString());
                    }
                    break;
                #endregion silc_savings_register_member

                #region swm_social_worker
                case "swm_social_worker":
                    strSQL = "ALTER TABLE {0} DISABLE TRIGGER {0}_delete " +
                        "DELETE FROM {0} WHERE swk_id IN ({1}) " +
                        "ALTER TABLE {0} ENABLE TRIGGER {0}_delete ";
                    for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                    {
                        dr = dt.Rows[intCount];
                        if (intCount != 0)
                        {
                            strSQLDelete = strSQLDelete + ", ";
                        }
                        strSQLDelete = strSQLDelete + string.Format("'{0}'", dr["swk_id"].ToString());
                    }
                    break;
                #endregion swm_social_worker
            }

            if (strSQL.Length != 0)
            {
                try
                {
                    dbCon.TransactionBegin();
                    strSQL = string.Format(strSQL, strTable, strSQLDelete);
                    dbCon.ExecuteNonQuery(strSQL);
                    dbCon.TransactionCommit();
                }
                catch (Exception exc)
                {
                    dbCon.TransactionRollback();
                    throw exc;
                }
            }
            #endregion Process Records

            return utilConstants.cDFMaxGUID;
        }
        #endregion Function Methdos

        #region Get Methods
        public DataTable GetData(string strTable, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT * FROM {0} ", strTable);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetData(string strTable, string strPrimaryKey, string strID, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT * FROM {0} WHERE {1} = '{2}' ", strTable, strPrimaryKey, strID);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetDataTop01(string strTable, string strPrimaryKey, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT TOP 1 * FROM {0} ORDER BY {1} ", strTable, strPrimaryKey);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public int GetUploadTotal(DataTable dtSync, string strColumnName, DBConnection dbCon)
        {
            #region Variables
            int intResult = 0;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            for (int intCount = 0; intCount < dtSync.Rows.Count; intCount++)
            {
                strSQL = string.Format("SELECT COUNT(*) FROM {0} ",
                dtSync.Rows[intCount][strColumnName].ToString());
                intResult = intResult + Convert.ToInt32(dbCon.ExecuteScalar(strSQL));
            }
            #endregion SQL

            return intResult;
        }
        #endregion Get Methods
    }
}
