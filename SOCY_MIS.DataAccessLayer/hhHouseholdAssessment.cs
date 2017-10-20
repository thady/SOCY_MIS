using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhHouseholdAssessment
    {
        #region Variables
        #region Public
        public string hha_id = string.Empty;
        public string hha_comments = string.Empty;
        public DateTime hha_date = DateTime.Now;
        public int hha_num_of_meals = 0;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string icc_id = utilConstants.cDFEmptyListValue;
        public string ics_id = utilConstants.cDFEmptyListValue;
        public string osn_id_disagreement = utilConstants.cDFEmptyListValue;
        public string swk_id = utilConstants.cDFEmptyListValue;
        public string yn_id_child_separation = utilConstants.cDFEmptyListValue;
        public string yn_id_financial_savings = utilConstants.cDFEmptyListValue;
        public string yn_id_food_body_building = utilConstants.cDFEmptyListValue;
        public string yn_id_food_energy = utilConstants.cDFEmptyListValue;
        public string yn_id_food_protective = utilConstants.cDFEmptyListValue;
        public string yn_id_water = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_food = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_health = utilConstants.cDFEmptyListValue;
        public string ynna_id_expenses_school = utilConstants.cDFEmptyListValue;
        public string ynns_id_assets = utilConstants.cDFEmptyListValue;
        public string yns_id_latrine = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;

        #endregion Public

        #region Private
        #endregion Private
        #endregion Variables
        #region Constractor Methods
        public hhHouseholdAssessment()
        {
            Default();
        }

        public hhHouseholdAssessment(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_household_assessment WHERE hha_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Household Assessment
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetHouseholdAssessment(strId, dbCon);
                Load(dt);
            }
            #endregion Set Household Assessment
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetHouseholdAssessment(hha_id, dbCon);
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
            hha_id = string.Empty;
            hha_comments = string.Empty;
            hha_date = DateTime.Now;
            hha_num_of_meals = 0;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            icc_id = utilConstants.cDFEmptyListValue;
            ics_id = utilConstants.cDFEmptyListValue;
            osn_id_disagreement = utilConstants.cDFEmptyListValue;
            swk_id = utilConstants.cDFEmptyListValue;
            yn_id_child_separation = utilConstants.cDFEmptyListValue;
            yn_id_financial_savings = utilConstants.cDFEmptyListValue;
            yn_id_food_body_building = utilConstants.cDFEmptyListValue;
            yn_id_food_energy = utilConstants.cDFEmptyListValue;
            yn_id_food_protective = utilConstants.cDFEmptyListValue;
            yn_id_water = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_food = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_health = utilConstants.cDFEmptyListValue;
            ynna_id_expenses_school = utilConstants.cDFEmptyListValue;
            ynns_id_assets = utilConstants.cDFEmptyListValue;
            yns_id_latrine = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_household_assessment " +
                "(hha_id, hha_comments, hha_date, " + 
                "hha_num_of_meals, " +
                "hh_id, hhm_id, icc_id, ics_id, osn_id_disagreement, swk_id, " +
                "yn_id_child_separation, yn_id_financial_savings, yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water, " +
                "ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school, " +
                "ynns_id_assets, yns_id_latrine, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
                "{3}, " +
                "'{4}', '{5}', '{6}', '{7}', '{8}', '{9}', " +
                "'{10}', '{11}', '{12}', '{13}', '{14}', '{15}', " +
                "'{16}', '{17}', '{18}', " +
                "'{19}', '{20}', " +
                "'{21}', '{21}', GETDATE(), GETDATE(), '{22}',{23}) ";
            strSQL = string.Format(strSQL, hha_id, utilFormatting.StringForSQL(hha_comments), hha_date.ToString("dd MMM yyyy HH:mm:ss"),
                hha_num_of_meals.ToString(),
                hh_id, hhm_id, icc_id, ics_id, osn_id_disagreement, swk_id,
                yn_id_child_separation, yn_id_financial_savings, yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water,
                ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school,
                ynns_id_assets, yns_id_latrine,
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
                hha_id = dr["hha_id"].ToString();
                hha_comments = dr["hha_comments"].ToString();
                hha_date = Convert.ToDateTime(dr["hha_date"]);
                hha_num_of_meals = Convert.ToInt32(dr["hha_num_of_meals"]);
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                icc_id = dr["icc_id"].ToString();
                ics_id = dr["ics_id"].ToString();
                osn_id_disagreement = dr["osn_id_disagreement"].ToString();
                swk_id = dr["swk_id"].ToString();
                yn_id_child_separation = dr["yn_id_child_separation"].ToString();
                yn_id_financial_savings = dr["yn_id_financial_savings"].ToString();
                yn_id_food_body_building = dr["yn_id_food_body_building"].ToString();
                yn_id_food_energy = dr["yn_id_food_energy"].ToString();
                yn_id_food_protective = dr["yn_id_food_protective"].ToString();
                yn_id_water = dr["yn_id_water"].ToString();
                ynna_id_expenses_food = dr["ynna_id_expenses_food"].ToString();
                ynna_id_expenses_health = dr["ynna_id_expenses_health"].ToString();
                ynna_id_expenses_school = dr["ynna_id_expenses_school"].ToString();
                ynns_id_assets = dr["ynns_id_assets"].ToString();
                yns_id_latrine = dr["yns_id_latrine"].ToString();
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
            strSQL = "UPDATE hh_household_assessment " +
                "SET hha_comments = '{1}', hha_date = '{2}', " +
                "hha_num_of_meals = {3}, " +
                "hh_id = '{4}', hhm_id = '{5}', icc_id = '{6}', ics_id = '{7}', osn_id_disagreement = '{8}', swk_id = '{9}', " +
                "yn_id_child_separation = '{10}', yn_id_financial_savings = '{11}', yn_id_food_body_building = '{12}', yn_id_food_energy = '{13}', yn_id_food_protective = '{14}', yn_id_water = '{15}', " +
                "ynna_id_expenses_food = '{16}', ynna_id_expenses_health = '{17}', ynna_id_expenses_school = '{18}' " +
                "ynns_id_assets = '{19}', yns_id_latrine = '{20}', " +
                "usr_id_update = '{21}', usr_date_update = GETDATE(),district_id = '{22}' " +
                "WHERE hha_id = '{0}' ";
            strSQL = string.Format(strSQL, hha_id, utilFormatting.StringForSQL(hha_comments), hha_date.ToString("dd MMM yyyy HH:mm:ss"),
                hha_num_of_meals.ToString(),
                hh_id, hhm_id, icc_id, ics_id, osn_id_disagreement, swk_id,
                yn_id_child_separation, yn_id_financial_savings, yn_id_food_body_building, yn_id_food_energy, yn_id_food_protective, yn_id_water,
                ynna_id_expenses_food, ynna_id_expenses_health, ynna_id_expenses_school,
                ynns_id_assets, yns_id_latrine,
                usr_id_update,Convert.ToInt32(district_id));

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Function Methods
        #endregion Function Methods

        #region Get Methods
        #region Private
        private DataTable GetHouseholdAssessment(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT hha.* " +
            "FROM hh_household_assessment hha " +
            "WHERE hha.hha_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
