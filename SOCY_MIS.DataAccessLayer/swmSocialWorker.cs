using System;
using System.Data;

using PSAUtils;
using PSAUtilsWin32;

namespace SOCY_MIS.DataAccessLayer
{
    public class swmSocialWorker
    {
        #region Variables
        #region Public
        public string swk_id = string.Empty;
        public string swk_first_name = string.Empty;
        public string swk_last_name = string.Empty;
        public string swk_email = string.Empty;
        public string swk_phone = string.Empty;
        public string swk_phone_other = string.Empty;
        public string swk_status_reason = string.Empty;
        public string swk_village = string.Empty;
        public string cso_id = utilConstants.cDFEmptyListValue;
        public string hnr_id = utilConstants.cDFEmptyListValue;
        public string swk_id_manager = utilConstants.cDFEmptyListValue;
        public string sws_id = utilConstants.cDFStatus;
        public string swt_id = utilConstants.cDFEmptyListValue;
        public string dst_id = utilConstants.cDFEmptyListValue;
        public string sct_id = utilConstants.cDFEmptyListValue;
        public string wrd_id = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string swk_hh_target = string.Empty;
        public string district_id = string.Empty;
        #endregion Public

        #region Private
        #endregion Private
        #endregion Variables

        #region Constractor Methods
        public swmSocialWorker()
        {
            Default();
        }

        public swmSocialWorker(string strId, DBConnection dbCon)
        {
            Load(strId, dbCon);
        }
        #endregion Constractor Methods

        #region Function Methods
        #region Public
        public bool CheckPhoneNumberInUse(string strId, string strPhoneNumber, DBConnection dbCon)
        {
            #region Variables
            bool blnResult = false;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = string.Format("SELECT ISNULL(COUNT(swk_id), 0) FROM swm_social_worker WHERE REPLACE(LOWER(swk_phone), ' ', '') = '{1}' " +
                "AND NOT swk_id IN (SELECT swk_id FROM swm_social_worker WHERE REPLACE(LOWER(swk_phone), ' ', '') = '{1}' AND swk_id = '{0}') ", strId, strPhoneNumber.ToLower().Replace(" ", ""));
            if (!dbCon.ExecuteScalar(strSQL).Equals("0"))
                blnResult = true;
            #endregion SQL

            return blnResult;
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Social Worker
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetSocialWorker(strId, dbCon);
                Load(dt);
            }
            #endregion Set Social Worker
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables
            
            #region Save
            dt = GetSocialWorker(swk_id, dbCon);
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
            swk_id = string.Empty;
            swk_first_name = string.Empty;
            swk_last_name = string.Empty;
            swk_email = string.Empty;
            swk_phone = string.Empty;
            swk_phone_other = string.Empty;
            swk_status_reason = string.Empty;
            swk_village = string.Empty;
            cso_id = utilConstants.cDFEmptyListValue;
            hnr_id = utilConstants.cDFEmptyListValue;
            swk_id_manager = utilConstants.cDFEmptyListValue;
            sws_id = utilConstants.cDFStatus;
            swt_id = utilConstants.cDFEmptyListValue;
            dst_id = utilConstants.cDFEmptyListValue;
            sct_id = utilConstants.cDFEmptyListValue;
            wrd_id = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO swm_social_worker " +
               "(swk_id, swk_first_name, swk_last_name, " +
               "swk_email, swk_phone, swk_phone_other, " + 
               "swk_status_reason, swk_village, " +
               "cso_id, hnr_id, swk_id_manager, sws_id, swt_id, wrd_id, " +
               "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
               "VALUES ('{0}', '{1}', '{2}', " +
               "'{3}', '{4}', " +
               "'{5}', '{6}', '{7}', " +
               "'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', " +
               "'{14}', '{14}', GETDATE(), GETDATE(), '{15}','{16}') ";
            strSQL = string.Format(strSQL, swk_id, utilFormatting.StringForSQL(swk_first_name), utilFormatting.StringForSQL(swk_last_name),
                utilFormatting.StringForSQL(swk_email), utilFormatting.StringForSQL(swk_phone), utilFormatting.StringForSQL(swk_phone_other),
                utilFormatting.StringForSQL(swk_status_reason), utilFormatting.StringForSQL(swk_village),
                cso_id, hnr_id, swk_id_manager, sws_id, swt_id, wrd_id,
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
                swk_id = dr["swk_id"].ToString();
                swk_first_name = dr["swk_first_name"].ToString();
                swk_last_name = dr["swk_last_name"].ToString();
                swk_email = dr["swk_email"].ToString();
                swk_phone = dr["swk_phone"].ToString();
                swk_phone_other = dr["swk_phone_other"].ToString();
                swk_status_reason = dr["swk_status_reason"].ToString();
                swk_village = dr["swk_village"].ToString();
                cso_id = dr["cso_id"].ToString();
                hnr_id = dr["hnr_id"].ToString();
                swk_id_manager = dr["swk_id_manager"].ToString();
                sws_id = dr["sws_id"].ToString();
                swt_id = dr["swt_id"].ToString();
                dst_id = dr["dst_id"].ToString();
                sct_id = dr["sct_id"].ToString();
                wrd_id = dr["wrd_id"].ToString();
                usr_id_update = dr["usr_id_update"].ToString();
                ofc_id = dr["ofc_id"].ToString();
                //swk_hh_target = dr["swk_hh_target"].ToString();
                #endregion Load Values
            }
        }

        private void Update(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "UPDATE swm_social_worker " +
               "SET swk_first_name = '{1}', swk_last_name = '{2}', " +
               "swk_email = '{3}', swk_phone = '{4}', swk_phone_other = '{5}', " +
               "swk_status_reason = '{6}', swk_village = '{7}', " +
               "cso_id = '{8}', hnr_id = '{9}', swk_id_manager = '{10}', sws_id = '{11}', swt_id = '{12}', wrd_id = '{13}', " +
               "usr_id_update = '{14}', usr_date_update = GETDATE(),district_id = '{15}'" +
               "WHERE swk_id = '{0}' ";
            strSQL = string.Format(strSQL, swk_id, utilFormatting.StringForSQL(swk_first_name), utilFormatting.StringForSQL(swk_last_name),
                utilFormatting.StringForSQL(swk_email), utilFormatting.StringForSQL(swk_phone), utilFormatting.StringForSQL(swk_phone_other),
                utilFormatting.StringForSQL(swk_status_reason), utilFormatting.StringForSQL(swk_village),
                cso_id, hnr_id, swk_id_manager, sws_id, swt_id, wrd_id,
                usr_id_update,Convert.ToInt32(district_id));

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods

        #region Get Methods
        #region Public
        public DataTable GetByCriteria(string[,] arrFilter, int intArrayLength, DBConnection dbCon)
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
                    case "dst_id":
                        strWHERE = strWHERE + string.Format("AND sct.dst_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "sct_id":
                        strWHERE = strWHERE + string.Format("AND sct.sct_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "wrd_id":
                        strWHERE = strWHERE + string.Format("AND swk.wrd_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swk_id":
                        strWHERE = strWHERE + string.Format("AND swk.swk_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swt_id":
                        strWHERE = strWHERE + string.Format("AND swk.swt_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swk_first_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(swk.swk_first_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swk_last_name":
                        strWHERE = strWHERE + string.Format("AND LOWER(RTRIM(LTRIM(swk.swk_last_name))) LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "swk_phone":
                        strWHERE = strWHERE + string.Format("AND REPLACE(LOWER(RTRIM(LTRIM(swk.swk_phone))), ' ', '') LIKE '%{0}%' ",
                            arrFilter[intCount, 1].ToLower().Replace(" ", ""));
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT swk.* FROM swm_social_worker swk " +
                "LEFT JOIN (SELECT DISTINCT wrd_id, sct_id FROM lst_ward) wrd ON swk.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT DISTINCT sct_id, dst_id FROM lst_sub_county) sct ON wrd.sct_id = sct.sct_id " +
                strWHERE + 
                "ORDER BY swk.swk_last_name, swk.swk_first_name ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        public DataTable GetList(DBConnection dbCon)
        {
            return GetListPrivate("", "", "", dbCon);
        }

        public DataTable GetList(string strId, DBConnection dbCon)
        {
            return GetListPrivate(strId, "", "", dbCon);
        }

        public DataTable GetList(string strId, string strSwtId, DBConnection dbCon)
        {
            return GetListPrivate(strId, strSwtId, "", dbCon);
        }

        public DataTable GetList(string strId, string strSwtId, string strDstId, DBConnection dbCon)
        {
            return GetListPrivate(strId, strSwtId, strDstId, dbCon);
        }
        #endregion Public

        #region Private
        private DataTable GetListPrivate(string strId, string strSwtId, string strDstId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT swk.swk_id, swk.swk_first_name + ' ' + swk.swk_last_name AS swk_name, swk.swk_email, swk.swk_phone " +
                "FROM swm_social_worker swk ";
            if (strDstId.Length != 0)
            {
                strSQL = strSQL + string.Format("INNER JOIN lst_ward wrd ON swk.wrd_id = wrd.wrd_id INNER JOIN lst_sub_county sct ON wrd.sct_id = sct.sct_id AND sct.dst_id = '{0}' ", strDstId);
            }
            if (strSwtId.Length != 0)
            {
                strSQL = strSQL + string.Format("WHERE swk.swt_id = '{0}' ", strSwtId);
            }
            if (strId.Length != 0)
            {
                strSQL = strSQL + "UNION " +
                "SELECT swk.swk_id, swk.swk_first_name + ' ' + swk.swk_last_name AS swk_name, swk.swk_email, swk.swk_phone " +
                "FROM swm_social_worker swk " +
                "WHERE swk.swk_id = '{0}' ";
            }
            strSQL = strSQL + "ORDER BY swk_name ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private DataTable GetSocialWorker(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT swk.*, ISNULL(sct.sct_id, '" + utilConstants.cDFEmptyListValue + "') AS sct_id, ISNULL(sct.dst_id, '" + utilConstants.cDFEmptyListValue + "') AS dst_id " +
                "FROM swm_social_worker swk " +
                "LEFT JOIN (SELECT DISTINCT wrd_id, sct_id FROM lst_ward) wrd ON swk.wrd_id = wrd.wrd_id " +
                "LEFT JOIN (SELECT DISTINCT sct_id, dst_id FROM lst_sub_county) sct ON wrd.sct_id = sct.sct_id " +
                "WHERE swk.swk_id = '{0}' "; 
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get methods
    }
}
