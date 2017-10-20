using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class benActivityTrainingParticipant
    {
        #region Variables
        #region Public
        public string atp_id = string.Empty;
        public string atp_name = string.Empty;
        public string atp_year_of_birth = utilConstants.cDFEmptyListValue;
        public int atp_days = 0;
        public string at_id = utilConstants.cDFEmptyListValue;
        public string gnd_id = utilConstants.cDFEmptyListValue;
        public string hh_id = utilConstants.cDFEmptyListValue;
        public string hhm_id = utilConstants.cDFEmptyListValue;
        public string mtp_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public benActivityTrainingParticipant()
        {
            Default();
        }

        public benActivityTrainingParticipant(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM ben_activity_training_participant WHERE atp_id = '{0}' ";
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
            dt = GetMember(atp_id, dbCon);
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
            atp_id = string.Empty;
            atp_name = string.Empty;
            atp_year_of_birth = utilConstants.cDFEmptyListValue;
            atp_days = 0;
            at_id = utilConstants.cDFEmptyListValue;
            gnd_id = utilConstants.cDFEmptyListValue;
            hh_id = utilConstants.cDFEmptyListValue;
            hhm_id = utilConstants.cDFEmptyListValue;
            mtp_id = utilConstants.cDFEmptyListValue;
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
            strSQL = "INSERT INTO ben_activity_training_participant " +
                "(atp_id, atp_name, atp_year_of_birth, atp_days, " +
                "at_id, gnd_id, hhm_id, mtp_id, " +
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', {3}, " +
                "'{4}', '{5}', '{6}', '{7}', " +
                "'{8}', '{8}', GETDATE(), GETDATE(), '{9}','{10}') ";
            strSQL = string.Format(strSQL, atp_id, utilFormatting.StringForSQL(atp_name), atp_year_of_birth, atp_days,
                at_id, gnd_id, hhm_id, mtp_id,  
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
                atp_id = dr["atp_id"].ToString();
                atp_name = dr["atp_name"].ToString();
                atp_year_of_birth = dr["atp_year_of_birth"].ToString();
                atp_days = Convert.ToInt32(dr["atp_days"]);
                at_id = dr["at_id"].ToString();
                gnd_id = dr["gnd_id"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                mtp_id = dr["mtp_id"].ToString();
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
            strSQL = "UPDATE ben_activity_training_participant " +
                "SET atp_name = '{1}', atp_year_of_birth = '{2}', atp_days = {3}, " +
                "at_id = '{4}', gnd_id = '{5}', hhm_id = '{6}', mtp_id = '{7}', " +
                "usr_id_update = '{8}', usr_date_update = GETDATE(),district_id = '{9}' " +
                "WHERE atp_id = '{0}' ";
            strSQL = string.Format(strSQL, atp_id, utilFormatting.StringForSQL(atp_name), atp_year_of_birth, atp_days,
                at_id, gnd_id, hhm_id, mtp_id,  
                usr_id_update, Convert.ToInt32(district_id));

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
            strSQL = "SELECT atp.*, " +
                "ISNULL(hhm.hh_id, '') AS hh_id " +
                "FROM ben_activity_training_participant atp " +
                "LEFT JOIN hh_household_member hhm ON atp.hhm_id = hhm.hhm_id " +
                "WHERE atp.atp_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods
    }
}
