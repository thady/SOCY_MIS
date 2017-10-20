using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benActivityTraining
    {
        #region Variables
        #region Public
        public string at_id = string.Empty;
        public string at_activity = string.Empty;
        public string at_training_for = string.Empty;
        public string at_training_point = string.Empty;
        public DateTime at_date_begin = DateTime.Now;
        public DateTime at_date_end = DateTime.Now;
        public int at_days = 0;
        public int at_session = 0;
        public string at_coordinator = string.Empty;
        public string at_coordinator_tel = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string ttp_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = static_variables.district_id;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benActivityTraining()
        {
            Default();
        }

        public benActivityTraining(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public void Delete(string strId, DBConnection dbCon)
        {
            #region Variables
            benActivityTrainingParticipant dalATP = null;
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region Linked Records
            dt = GetLines(strId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                dalATP = new benActivityTrainingParticipant();
                for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                {
                    dalATP.Delete(dt.Rows[intCount]["atp_id"].ToString(), dbCon);
                }
            }
            #endregion Linked Records

            #region SQL
            strSQL = "DELETE FROM ben_activity_training WHERE at_id = '{0}' ";
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
                dt = GetRegister(strId, dbCon);
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
            dt = GetRegister(at_id, dbCon);
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
            at_id = string.Empty;
            at_activity = string.Empty;
            at_training_for = string.Empty;
            at_training_point = string.Empty;
            at_date_begin = DateTime.Now;
            at_date_end = DateTime.Now;
            at_days = 0;
            at_session = 0;
            at_coordinator = string.Empty;
            at_coordinator_tel = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            ttp_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_activity_training " +
                "(at_id, " + 
                "at_activity, at_training_for, at_training_point, " +
                "at_date_begin, at_date_end, at_days, at_session, " +
                "at_coordinator, at_coordinator_tel, " +
                "cso_id, ttp_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', " +
                "'{1}', '{2}', '{3}', " +
                "'{4}', '{5}', {6}, '{7}', " +
                "'{8}', '{9}', " +
                "'{10}', '{11}', " +
                "'{12}', '{12}', GETDATE(), GETDATE(), '{13}','{14}') ";
            strSQL = string.Format(strSQL, at_id, 
                utilFormatting.StringForSQL(at_activity), utilFormatting.StringForSQL(at_training_for), utilFormatting.StringForSQL(at_training_point),
                at_date_begin.ToString("dd MMM yyyy HH:mm:ss"), at_date_end.ToString("dd MMM yyyy HH:mm:ss"), at_days, at_session,
                utilFormatting.StringForSQL(at_coordinator), utilFormatting.StringForSQL(at_coordinator_tel), 
                cso_id, ttp_id, 
                usr_id_update, ofc_id, Convert.ToInt32(district_id));

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
                at_id = dr["at_id"].ToString();
                at_activity = dr["at_activity"].ToString();
                at_training_for = dr["at_training_for"].ToString();
                at_training_point = dr["at_training_point"].ToString();
                at_date_begin = Convert.ToDateTime(dr["at_date_begin"]);
                at_date_end = Convert.ToDateTime(dr["at_date_end"]);
                at_days = Convert.ToInt32(dr["at_days"]);
                at_session = Convert.ToInt32(dr["at_session"]);
                at_coordinator = dr["at_coordinator"].ToString();
                at_coordinator_tel = dr["at_coordinator_tel"].ToString();
                cso_id = dr["cso_id"].ToString();
                ttp_id = dr["ttp_id"].ToString();
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
            strSQL = "UPDATE ben_activity_training " +
                "SET at_activity = '{1}', at_training_for = '{2}', at_training_point = '{3}', " +
                "at_date_begin = '{4}', at_date_end = '{5}', at_days = {6}, at_session = {7}, " +
                "at_coordinator = '{8}', at_coordinator_tel = '{9}', " +
                "cso_id = '{10}', ttp_id = '{11}', " +
                "usr_id_update = '{12}', usr_date_update = GETDATE(),district_id = '{13}' " +
                "WHERE at_id = '{0}' ";
            strSQL = string.Format(strSQL, at_id,
                utilFormatting.StringForSQL(at_activity), utilFormatting.StringForSQL(at_training_for), utilFormatting.StringForSQL(at_training_point),
                at_date_begin.ToString("dd MMM yyyy HH:mm:ss"), at_date_end.ToString("dd MMM yyyy HH:mm:ss"), at_days, at_session,
                utilFormatting.StringForSQL(at_coordinator), utilFormatting.StringForSQL(at_coordinator_tel),
                cso_id, ttp_id,
                usr_id_update, Convert.ToInt32(district_id));

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
                    case "cso_id":
                        strWHERE = strWHERE + string.Format("AND at.cso_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "at_date_begin":
                        strWHERE = strWHERE + string.Format("AND at.at_date_begin >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "at_date_end":
                        strWHERE = strWHERE + string.Format("AND at.at_date_end <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT at.at_id, at.ofc_id, at.at_training_for, " +
                "ISNULL(cso.cso_name, '') AS cso_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), at.at_date_begin, 106))) AS at_date_begin, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), at.at_date_end, 106))) AS at_date_end " +
                "FROM ben_activity_training at " +
                "LEFT JOIN (SELECT cso_id, cso_name FROM lst_cso) cso ON at.cso_id = cso.cso_id " +
                strWHERE +
                "ORDER BY cso_name ";
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
            strSQL = "SELECT ISNULL(MIN(at_date_begin), GETDATE()) AS at_date_begin, " +
                "ISNULL(MAX(at_date_end), GETDATE()) AS at_date_end " +
                "FROM ben_activity_training ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT atp.atp_id " +
                "FROM ben_activity_training_participant atp " +
                "WHERE atp.at_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetLines(string strId, string strLngId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT atp.atp_id, atp.atp_days, atp.ofc_id, " +
                "ISNULL(hhm.hhm_first_name + ' ' + hhm.hhm_last_name, atp.atp_name) AS atp_name, ISNULL(hh.hh_code + '/' + hhm.hhm_number, '') AS hhm_code, " +
                "REPLACE(ISNULL(hhm.hhm_year_of_birth, atp.atp_year_of_birth), '-1', '') AS atp_year_of_birth, " +
                "ISNULL(hgnd.gnd_name, gnd.gnd_name) AS gnd_name, mtp.mtp_name " +
                "FROM ben_activity_training_participant atp " +
                "INNER JOIN lst_member_type mtp ON atp.mtp_id = mtp.mtp_id AND mtp.lng_id = '{1}' " +
                "LEFT JOIN (SELECT gnd_id, gnd_name FROM lst_gender) gnd ON atp.gnd_id = gnd.gnd_id " +
                "LEFT JOIN hh_household_member hhm ON atp.hhm_id = hhm.hhm_id " +
                "LEFT JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
                "LEFT JOIN (SELECT gnd_id, gnd_name FROM lst_gender) hgnd ON hhm.gnd_id = hgnd.gnd_id " +
                "WHERE atp.at_id = '{0}' " +
                "ORDER BY atp_name  ";
            strSQL = string.Format(strSQL, strId, strLngId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public

        #region Private
        private DataTable GetRegister(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT at.* " +
            "FROM ben_activity_training at " +
            "WHERE at.at_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}