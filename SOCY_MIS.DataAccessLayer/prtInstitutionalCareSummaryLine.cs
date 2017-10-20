using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class prtInstitutionalCareSummaryLine
    {
        #region Variables
        #region Public
        public string icsl_id = string.Empty;
        public int icsl_caregiver_age = 0;
        public string icsl_caregiver_name = string.Empty;
        public int icsl_child_age = 0;
        public string icsl_child_name = string.Empty;
        public string icsl_contact_tel = string.Empty;
        public string icsl_contact_village = string.Empty;
        public string gnd_id_caregiver = utilConstants.cDFEmptyListValue;
        public string gnd_id_child = utilConstants.cDFEmptyListValue;
        public string ics_id = utilConstants.cDFEmptyListValue;
        public string ins_id = utilConstants.cDFEmptyListValue;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public int district_id = Convert.ToInt32(static_variables.district_id);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public prtInstitutionalCareSummaryLine()
        {
            Default();
        }

        public prtInstitutionalCareSummaryLine(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Default()
        {
            #region Default
            icsl_id = string.Empty;
            icsl_caregiver_age = 0;
            icsl_caregiver_name = string.Empty;
            icsl_child_age = 0;
            icsl_child_name = string.Empty;
            icsl_contact_tel = string.Empty;
            icsl_contact_village = string.Empty;
            gnd_id_caregiver = utilConstants.cDFEmptyListValue;
            gnd_id_child = utilConstants.cDFEmptyListValue;
            ics_id = utilConstants.cDFEmptyListValue;
            ins_id = utilConstants.cDFEmptyListValue;
            wrd_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "DELETE FROM prt_institutional_care_summary_line WHERE icsl_id = '{0}' ";
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
            dt = GetObject(icsl_id, dbCon);
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
            strSQL = "INSERT INTO prt_institutional_care_summary_line " +
                "(icsl_id, " +
                "icsl_caregiver_age, icsl_caregiver_name, " +
                "icsl_child_age, icsl_child_name, " +
                "icsl_contact_tel, icsl_contact_village, " + 
                "gnd_id_caregiver, gnd_id_child, ics_id, ins_id, wrd_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "{1}, '{2}', " +
                "{3}, '{4}', " +
                "'{5}', '{6}', " +
                "'{7}', '{8}', '{9}', '{10}', '{11}', " +
                "'{12}', '{12}', GETDATE(), GETDATE(), '{13}','{14}') ";
            strSQL = string.Format(strSQL, icsl_id,
                icsl_caregiver_age, utilFormatting.StringForSQL(icsl_caregiver_name),
                icsl_child_age, utilFormatting.StringForSQL(icsl_child_name),
                utilFormatting.StringForSQL(icsl_contact_tel), utilFormatting.StringForSQL(icsl_contact_village),
                gnd_id_caregiver, gnd_id_child, ics_id, ins_id, wrd_id,  
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
                icsl_id = dr["icsl_id"].ToString();
                icsl_caregiver_age = Convert.ToInt32(dr["icsl_caregiver_age"]);
                icsl_caregiver_name = dr["icsl_caregiver_name"].ToString();
                icsl_child_age = Convert.ToInt32(dr["icsl_child_age"]);
                icsl_child_name = dr["icsl_child_name"].ToString();
                icsl_contact_tel = dr["icsl_contact_tel"].ToString();
                icsl_contact_village = dr["icsl_contact_village"].ToString();
                gnd_id_caregiver = dr["gnd_id_caregiver"].ToString();
                gnd_id_child = dr["gnd_id_child"].ToString();
                ics_id = dr["ics_id"].ToString();
                ins_id = dr["ins_id"].ToString();
                wrd_id = dr["wrd_id"].ToString();
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
            strSQL = "UPDATE prt_institutional_care_summary_line " +
                "SET icsl_caregiver_age = {1}, icsl_caregiver_name = '{2}', " +
                "icsl_child_age = {3}, icsl_child_name = '{4}', " +
                "icsl_contact_tel = '{5}', icsl_contact_village = '{6}', " +
                "gnd_id_caregiver = '{7}', gnd_id_child = '{8}', ics_id = '{9}', ins_id = '{10}', wrd_id = '{11}', " +
                "usr_id_update = '{12}', usr_date_update = GETDATE(),district_id = '{13}' " +
                "WHERE icsl_id = '{0}' ";
            strSQL = string.Format(strSQL, icsl_id, 
                icsl_caregiver_age, utilFormatting.StringForSQL(icsl_caregiver_name), 
                icsl_child_age, utilFormatting.StringForSQL(icsl_child_name), 
                utilFormatting.StringForSQL(icsl_contact_tel), utilFormatting.StringForSQL(icsl_contact_village), 
                gnd_id_caregiver, gnd_id_child, ics_id, ins_id, wrd_id, 
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
            strSQL = "SELECT icsl.* " +
            "FROM prt_institutional_care_summary_line icsl " +
            "WHERE icsl.icsl_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}