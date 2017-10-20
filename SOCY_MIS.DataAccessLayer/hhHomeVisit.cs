using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHomeVisit
    {
        #region Variables
        #region Public
        public string hv_id = string.Empty;
        public int hv_number_of_children = 0;
        public DateTime hv_date = DateTime.Now;
        public DateTime hv_previous_visit_date = DateTime.Now;
        public string hv_previous_visit_purpose = string.Empty;
        public string hv_previous_visit_service = string.Empty;
        public string hv_actions = string.Empty;
        public string hv_findings = string.Empty;
        public string hv_next_steps = string.Empty;
        public string hv_girl_name = string.Empty;
        public int hv_girl_age = 0;
        public string hv_girl_education_type = string.Empty;
        public string edu_id = utilConstants.cDFEmptyListValue;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string yn_id_consumption_program = utilConstants.cDFEmptyListValue;
        public string yn_id_girl_education_support = utilConstants.cDFEmptyListValue;
        public string yn_id_improvement_plan = utilConstants.cDFEmptyListValue;
        public string yn_id_previous_visit = utilConstants.cDFEmptyListValue;
        public string yn_id_referral = utilConstants.cDFEmptyListValue;
        public string yn_id_referral_completed = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string[] home_visit_service = "".Split(utilConstants.cDFSplitChar);
        public string[] home_visit_service_previous = "".Split(utilConstants.cDFSplitChar);
        public string district_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhHomeVisit()
        {
            Default();
        }

        public hhHomeVisit(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_home_visit_service WHERE hv_id = '{0}' " +
                "DELETE FROM hh_home_visit_service_previous WHERE hv_id = '{0}' " + 
                "DELETE FROM hh_home_visit WHERE hv_id = '{0}' ";
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
                dt = GetHomeVisit(strId, dbCon);
                Load(dt);
                ServicesLoad(strId, dbCon);
                ServicesPreviousLoad(strId, dbCon);
            }
            #endregion Set HomeVisit
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetHomeVisit(hv_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            ServicesUpdate(dbCon);
            ServicesPreviousUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            hv_id = string.Empty;
            hv_number_of_children = 0;
            hv_date = DateTime.Now;
            hv_previous_visit_date = DateTime.Now;
            hv_previous_visit_purpose = string.Empty;
            hv_previous_visit_service = string.Empty;
            hv_actions = string.Empty;
            hv_findings = string.Empty;
            hv_next_steps = string.Empty;
            hv_girl_name = string.Empty;
            hv_girl_age = 0;
            hv_girl_education_type = string.Empty;
            edu_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            yn_id_consumption_program = utilConstants.cDFEmptyListValue;
            yn_id_girl_education_support = utilConstants.cDFEmptyListValue;
            yn_id_improvement_plan = utilConstants.cDFEmptyListValue;
            yn_id_previous_visit = utilConstants.cDFEmptyListValue;
            yn_id_referral = utilConstants.cDFEmptyListValue;
            yn_id_referral_completed = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            home_visit_service = "".Split(utilConstants.cDFSplitChar);
            home_visit_service_previous = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_home_visit " +
                "(hv_id, hv_number_of_children, hv_date, " +
                "hv_previous_visit_date, " + 
                "hv_previous_visit_purpose, hv_previous_visit_service, " +
                "hv_actions, hv_findings, hv_next_steps, " +
                "hv_girl_name, hv_girl_age, " + 
                "hv_girl_education_type, " + 
                "edu_id, hh_id, hhm_id, swk_id, " +
                "yn_id_consumption_program, yn_id_girl_education_support, yn_id_improvement_plan, " + 
                "yn_id_previous_visit, yn_id_referral, yn_id_referral_completed, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', {1}, '{2}', " +
                "'{3}', " +
                "'{4}', '{5}', " +
                "'{6}', '{7}', '{8}', " +
                "'{9}', {10}, " +
                "'{11}', " +
                "'{12}', '{13}', '{14}', '{15}', " +
                "'{16}', '{17}', '{18}', " +
                "'{19}', '{20}', '{21}', " +
                "'{22}', '{22}', GETDATE(), GETDATE(), '{23}',{24}) ";
            strSQL = string.Format(strSQL, hv_id, hv_number_of_children.ToString(), hv_date.ToString("dd MMM yyyy HH:mm:ss"),
                hv_previous_visit_date.ToString("dd MMM yyyy HH:mm:ss"), 
                utilFormatting.StringForSQL(hv_previous_visit_purpose), utilFormatting.StringForSQL(hv_previous_visit_service),
                utilFormatting.StringForSQL(hv_actions), utilFormatting.StringForSQL(hv_findings), utilFormatting.StringForSQL(hv_next_steps),
                utilFormatting.StringForSQL(hv_girl_name), hv_girl_age.ToString(), 
                utilFormatting.StringForSQL(hv_girl_education_type), 
                edu_id, hh_id, hhm_id, swk_id,
                yn_id_consumption_program, yn_id_girl_education_support, yn_id_improvement_plan, 
                yn_id_previous_visit, yn_id_referral, yn_id_referral_completed,
                usr_id_update, ofc_id,Convert.ToInt32(district_id));

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
                hv_id = dr["hv_id"].ToString();
                hv_number_of_children = Convert.ToInt32(dr["hv_number_of_children"]);
                hv_date = Convert.ToDateTime(dr["hv_date"]);
                hv_previous_visit_date = Convert.ToDateTime(dr["hv_previous_visit_date"]);
                hv_previous_visit_purpose = dr["hv_previous_visit_purpose"].ToString();
                hv_previous_visit_service = dr["hv_previous_visit_service"].ToString();
                hv_actions = dr["hv_actions"].ToString();
                hv_findings = dr["hv_findings"].ToString();
                hv_next_steps = dr["hv_next_steps"].ToString();
                hv_girl_name = dr["hv_girl_name"].ToString();
                hv_girl_age = Convert.ToInt32(dr["hv_girl_age"]);
                hv_girl_education_type = dr["hv_girl_education_type"].ToString();
                edu_id = dr["edu_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                swk_id = dr["swk_id"].ToString();
                yn_id_consumption_program = dr["yn_id_consumption_program"].ToString();
                yn_id_girl_education_support = dr["yn_id_girl_education_support"].ToString();
                yn_id_improvement_plan = dr["yn_id_improvement_plan"].ToString();
                yn_id_previous_visit = dr["yn_id_previous_visit"].ToString();
                yn_id_referral = dr["yn_id_referral"].ToString();
                yn_id_referral_completed = dr["yn_id_referral_completed"].ToString();
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
            strSQL = "UPDATE hh_home_visit " +
                "SET hv_number_of_children = {1}, hv_date = '{2}', " +
                "hv_previous_visit_date = '{3}', " +
                "hv_previous_visit_purpose = '{4}', hv_previous_visit_service = '{5}', " +
                "hv_actions = '{6}', hv_findings = '{7}', hv_next_steps = '{8}', " +
                "hv_girl_name = '{9}', hv_girl_age = {10}, " +
                "hv_girl_education_type = '{11}', " + 
                "edu_id = '{12}', hh_id = '{13}', hhm_id = '{14}', swk_id = '{15}', " +
                "yn_id_consumption_program = '{16}', yn_id_girl_education_support = '{17}', yn_id_improvement_plan = '{18}', " +
                "yn_id_previous_visit = '{19}', yn_id_referral = '{20}', yn_id_referral_completed = '{21}', " +
                "usr_id_update = '{22}', usr_date_update = GETDATE(),district_id = '{23}' " +
                "WHERE hv_id = '{0}' ";
            strSQL = string.Format(strSQL, hv_id, hv_number_of_children.ToString(), hv_date.ToString("dd MMM yyyy HH:mm:ss"),
                hv_previous_visit_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(hv_previous_visit_purpose), utilFormatting.StringForSQL(hv_previous_visit_service),
                utilFormatting.StringForSQL(hv_actions), utilFormatting.StringForSQL(hv_findings), utilFormatting.StringForSQL(hv_next_steps),
                utilFormatting.StringForSQL(hv_girl_name), hv_girl_age.ToString(),
                utilFormatting.StringForSQL(hv_girl_education_type),
                edu_id, hh_id, hhm_id, swk_id,
                yn_id_consumption_program, yn_id_girl_education_support, yn_id_improvement_plan,
                yn_id_previous_visit, yn_id_referral, yn_id_referral_completed,
                usr_id_update,Convert.ToInt32(district_id));

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
                    case "hh_id":
                        strWHERE = strWHERE + string.Format("AND hv.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hv_date_begin":
                        strWHERE = strWHERE + string.Format("AND hv.hv_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hv_date_end":
                        strWHERE = strWHERE + string.Format("AND hv.hv_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT hv.hv_id, hh.hh_code, " + 
                "RTRIM(LTRIM(CONVERT(CHAR(15), hv.hv_date, 106))) AS the_date_display, " +
                "hv.hv_date AS the_date " +
                "FROM hh_home_visit hv " +
                "INNER JOIN hh_household hh ON hv.hh_id = hh.hh_id " +
                strWHERE +
                "ORDER BY hh.hh_code, the_date DESC ";
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
            strSQL = "SELECT ISNULL(MIN(hv_date), GETDATE()) AS hv_date_begin, " +
                "ISNULL(MAX(hv_date), GETDATE()) AS hv_date_end " +
                "FROM hh_home_visit ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetHomeVisit(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hv.* " +
            "FROM hh_home_visit hv " +
            "WHERE hv.hv_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region Services
        private DataTable ServicesGet(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM hh_home_visit_service " +
            "WHERE hv_id = '{0}' ";
            strSQL = string.Format(strSQL, strHvId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void ServicesLoad(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = ServicesGet(strHvId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["shv_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["shv_id"].ToString();
            }

            home_visit_service = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void ServicesUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (home_visit_service.Length != 0)
            {
                strInsert = "INSERT INTO hh_home_visit_service (hvs_id, hv_id, shv_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " + 
                    "(SELECT shv_id FROM hh_home_visit_service WHERE hv_id = '{0}') ";
                for (int intCount = 0; intCount < home_visit_service.Length; intCount++)
                {
                    if (home_visit_service[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", home_visit_service[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", home_visit_service[intCount]);
                        strSQL = strSQL + string.Format(strInsert, hv_id, home_visit_service[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM hh_home_visit_service WHERE hv_id = '{0}' AND NOT shv_id IN ({1}) ";
            strSQL = string.Format(strSQL, hv_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services

        #region Services Previous
        private DataTable ServicesPreviousGet(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM hh_home_visit_service_previous " +
            "WHERE hv_id = '{0}' ";
            strSQL = string.Format(strSQL, strHvId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void ServicesPreviousLoad(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = ServicesPreviousGet(strHvId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["shvp_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["shvp_id"].ToString();
            }

            home_visit_service_previous = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void ServicesPreviousUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (home_visit_service_previous.Length != 0)
            {
                strInsert = "INSERT INTO hh_home_visit_service_previous (hvsp_id, hv_id, shvp_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT shvp_id FROM hh_home_visit_service_previous WHERE hv_id = '{0}') ";
                for (int intCount = 0; intCount < home_visit_service_previous.Length; intCount++)
                {
                    if (home_visit_service_previous[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", home_visit_service_previous[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", home_visit_service_previous[intCount]);
                        strSQL = strSQL + string.Format(strInsert, hv_id, home_visit_service_previous[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM hh_home_visit_service_previous WHERE hv_id = '{0}' AND NOT shvp_id IN ({1}) ";
            strSQL = string.Format(strSQL, hv_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services Previous
    }
}