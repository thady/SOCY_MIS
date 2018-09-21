using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class hhReferral
    {
        #region Variables
        #region Public
        public string rfr_id = string.Empty;
        public string rfr_serial_no = string.Empty;
        public string rfr_ra_location = string.Empty;
        public string rfr_ra_tel = string.Empty;
        public string rfr_ra_email = string.Empty;
        public string rfr_ra_person_name = string.Empty;
        public string rfr_ra_person_title = string.Empty;
        public string rfr_ra_person_tel = string.Empty;
        public string rfr_ra_person_email = string.Empty;
        public DateTime rfr_ra_date = DateTime.Now;
        public string rfr_cd_case_no = string.Empty;
        public string rfr_cd_nature = string.Empty;
        public string rfr_cd_perpetrator = string.Empty;
        public string rfr_cd_perpetrator_relationship = string.Empty;
        public DateTime rfr_cd_date_occured = DateTime.Now;
        public string rfr_cd_other = string.Empty;
        public string rfr_cd_accompany_name = string.Empty;
        public string rfr_cd_accompany_tel = string.Empty;
        public string rfr_cd_accompany_email = string.Empty;
        public string rfr_cd_accompany_relationship = string.Empty;
        public string rfr_cd_guardian_name = string.Empty;
        public string rfr_cd_guardian_tel = string.Empty;
        public string rfr_cd_guardian_village = string.Empty;
        public string rfr_service_before = string.Empty;
        public string rfr_service_referral = string.Empty;
        public string rfr_service_discussion = string.Empty;
        public string rfr_ar_name = string.Empty;
        public string rfr_ar_location = string.Empty;
        public string rfr_ar_contact_name = string.Empty;
        public string rfr_ar_contact_tel = string.Empty;
        public string rfr_ar_contact_email = string.Empty;
        public string rfr_fb_agency_name = string.Empty;
        public string rfr_fb_person_name = string.Empty;
        public string rfr_fb_person_title = string.Empty;
        public string rfr_fb_location = string.Empty;
        public string rfr_fb_tel = string.Empty;
        public string rfr_fb_email = string.Empty;
        public DateTime rfr_fb_date = DateTime.Now;
        public string rfr_fb_id_no = string.Empty;
        public string rfr_fb_case_no = string.Empty;
        public string rfr_fb_service = string.Empty;
        public string rfr_fb_other = string.Empty;
        public string hh_id = string.Empty;
        public string hhm_id = string.Empty;
        public string prt_cso_id_ra = string.Empty;
        public string wrd_id_guardian = utilConstants.cDFEmptyListValue;
        public string yn_id_discussion = utilConstants.cDFEmptyListValue;
        public string yn_id_helpline = utilConstants.cDFEmptyListValue;
        public string usr_id_update = string.Empty;
        public string ofc_id = string.Empty;
        public string district_id = string.Empty;

        public string[] service_provided = "".Split(utilConstants.cDFSplitChar);
        public string[] service_referred = "".Split(utilConstants.cDFSplitChar);
        #endregion Public
        #endregion Variables

        #region Constractor Methods
        public hhReferral()
        {
            Default();
        }

        public hhReferral(string strId, DBConnection dbCon)
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
            strSQL = "DELETE FROM hh_referral_service_provided WHERE rfr_id = '{0}' " +
                "DELETE FROM hh_referral_service_referrred WHERE rfr_id = '{0}' " +
                "DELETE FROM hh_referral WHERE rfr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }

        public void Load(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Set Referral
            if (strId.Length == 0)
            {
                Default();
            }
            else
            {
                dt = GetReferral(strId, dbCon);
                Load(dt);
                ServicesProvidedLoad(strId, dbCon);
                ServicesReferredLoad(strId, dbCon);
            }
            #endregion Set Referral
        }

        public void Save(DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            #endregion Variables

            #region Save
            dt = GetReferral(rfr_id, dbCon);
            if (utilCollections.HasRows(dt))
                Update(dbCon);
            else
                Insert(dbCon);
            ServicesProvidedUpdate(dbCon);
            ServicesReferredUpdate(dbCon);
            #endregion Save
        }
        #endregion Public

        #region Private
        private void Default()
        {
            #region Default
            rfr_id = string.Empty;
            rfr_serial_no = string.Empty;
            rfr_ra_location = string.Empty;
            rfr_ra_tel = string.Empty;
            rfr_ra_email = string.Empty;
            rfr_ra_person_name = string.Empty;
            rfr_ra_person_title = string.Empty;
            rfr_ra_person_tel = string.Empty;
            rfr_ra_person_email = string.Empty;
            rfr_ra_date = DateTime.Now;
            rfr_cd_case_no = string.Empty;
            rfr_cd_nature = string.Empty;
            rfr_cd_perpetrator = string.Empty;
            rfr_cd_perpetrator_relationship = string.Empty;
            rfr_cd_date_occured = DateTime.Now;
            rfr_cd_other = string.Empty;
            rfr_cd_accompany_name = string.Empty;
            rfr_cd_accompany_tel = string.Empty;
            rfr_cd_accompany_email = string.Empty;
            rfr_cd_accompany_relationship = string.Empty;
            rfr_cd_guardian_name = string.Empty;
            rfr_cd_guardian_tel = string.Empty;
            rfr_cd_guardian_village = string.Empty;
            rfr_service_before = string.Empty;
            rfr_service_referral = string.Empty;
            rfr_service_discussion = string.Empty;
            rfr_ar_name = string.Empty;
            rfr_ar_location = string.Empty;
            rfr_ar_contact_name = string.Empty;
            rfr_ar_contact_tel = string.Empty;
            rfr_ar_contact_email = string.Empty;
            rfr_fb_agency_name = string.Empty;
            rfr_fb_person_name = string.Empty;
            rfr_fb_person_title = string.Empty;
            rfr_fb_location = string.Empty;
            rfr_fb_tel = string.Empty;
            rfr_fb_email = string.Empty;
            rfr_fb_date = DateTime.Now;
            rfr_fb_id_no = string.Empty;
            rfr_fb_case_no = string.Empty;
            rfr_fb_service = string.Empty;
            rfr_fb_other = string.Empty;
            hh_id = string.Empty;
            hhm_id = string.Empty;
            prt_cso_id_ra = utilConstants.cDFEmptyListValue;
            wrd_id_guardian = utilConstants.cDFEmptyListValue;
            yn_id_discussion = utilConstants.cDFEmptyListValue;
            yn_id_helpline = utilConstants.cDFEmptyListValue;
            usr_id_update = string.Empty;
            ofc_id = string.Empty;
            
            service_provided = "".Split(utilConstants.cDFSplitChar);
            service_referred = "".Split(utilConstants.cDFSplitChar);
            #endregion Default
        }

        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO hh_referral " +
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
                "usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id,district_id) " +
                "VALUES ('{0}', '{1}', '{2}', " +
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
                "'{47}', '{47}', GETDATE(), GETDATE(), '{48}',{49}) ";
            strSQL = string.Format(strSQL, rfr_id, utilFormatting.StringForSQL(rfr_serial_no), utilFormatting.StringForSQL(rfr_ra_location),
                utilFormatting.StringForSQL(rfr_ra_tel), utilFormatting.StringForSQL(rfr_ra_email),
                utilFormatting.StringForSQL(rfr_ra_person_name), utilFormatting.StringForSQL(rfr_ra_person_title),
                utilFormatting.StringForSQL(rfr_ra_person_tel), utilFormatting.StringForSQL(rfr_ra_person_email),
                rfr_ra_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(rfr_cd_case_no),
                utilFormatting.StringForSQL(rfr_cd_nature), utilFormatting.StringForSQL(rfr_cd_perpetrator), utilFormatting.StringForSQL(rfr_cd_perpetrator_relationship),
                rfr_cd_date_occured.ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(rfr_cd_other),
                utilFormatting.StringForSQL(rfr_cd_accompany_name), utilFormatting.StringForSQL(rfr_cd_accompany_tel), 
                utilFormatting.StringForSQL(rfr_cd_accompany_email), utilFormatting.StringForSQL(rfr_cd_accompany_relationship),
                utilFormatting.StringForSQL(rfr_cd_guardian_name), utilFormatting.StringForSQL(rfr_cd_guardian_tel), utilFormatting.StringForSQL(rfr_cd_guardian_village),
                utilFormatting.StringForSQL(rfr_service_before), utilFormatting.StringForSQL(rfr_service_referral), utilFormatting.StringForSQL(rfr_service_discussion),
                utilFormatting.StringForSQL(rfr_ar_name), utilFormatting.StringForSQL(rfr_ar_location), utilFormatting.StringForSQL(rfr_ar_contact_name),
                utilFormatting.StringForSQL(rfr_ar_contact_tel), utilFormatting.StringForSQL(rfr_ar_contact_email),
                utilFormatting.StringForSQL(rfr_fb_agency_name), utilFormatting.StringForSQL(rfr_fb_person_name), utilFormatting.StringForSQL(rfr_fb_person_title),
                utilFormatting.StringForSQL(rfr_fb_location), utilFormatting.StringForSQL(rfr_fb_tel), utilFormatting.StringForSQL(rfr_fb_email),
                rfr_fb_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(rfr_fb_id_no), utilFormatting.StringForSQL(rfr_fb_case_no),
                utilFormatting.StringForSQL(rfr_fb_service), utilFormatting.StringForSQL(rfr_fb_other),
                hhm_id, prt_cso_id_ra, wrd_id_guardian,
                yn_id_discussion, yn_id_helpline, 
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
                rfr_id = dr["rfr_id"].ToString();
                rfr_serial_no = dr["rfr_serial_no"].ToString();
                rfr_ra_location = dr["rfr_ra_location"].ToString();
                rfr_ra_tel = dr["rfr_ra_tel"].ToString();
                rfr_ra_email = dr["rfr_ra_email"].ToString();
                rfr_ra_person_name = dr["rfr_ra_person_name"].ToString();
                rfr_ra_person_title = dr["rfr_ra_person_title"].ToString();
                rfr_ra_person_tel = dr["rfr_ra_person_tel"].ToString();
                rfr_ra_person_email = dr["rfr_ra_person_email"].ToString();
                rfr_ra_date = Convert.ToDateTime(dr["rfr_ra_date"]);
                rfr_cd_case_no = dr["rfr_cd_case_no"].ToString();
                rfr_cd_nature = dr["rfr_cd_nature"].ToString();
                rfr_cd_perpetrator = dr["rfr_cd_perpetrator"].ToString();
                rfr_cd_perpetrator_relationship = dr["rfr_cd_perpetrator_relationship"].ToString();
                rfr_cd_date_occured = Convert.ToDateTime(dr["rfr_cd_date_occured"]);
                rfr_cd_other = dr["rfr_cd_other"].ToString();
                rfr_cd_accompany_name = dr["rfr_cd_accompany_name"].ToString();
                rfr_cd_accompany_tel = dr["rfr_cd_accompany_tel"].ToString();
                rfr_cd_accompany_email = dr["rfr_cd_accompany_email"].ToString();
                rfr_cd_accompany_relationship = dr["rfr_cd_accompany_relationship"].ToString();
                rfr_cd_guardian_name = dr["rfr_cd_guardian_name"].ToString();
                rfr_cd_guardian_tel = dr["rfr_cd_guardian_tel"].ToString();
                rfr_cd_guardian_village = dr["rfr_cd_guardian_village"].ToString();
                rfr_service_before = dr["rfr_service_before"].ToString();
                rfr_service_referral = dr["rfr_service_referral"].ToString();
                rfr_service_discussion = dr["rfr_service_discussion"].ToString();
                rfr_ar_name = dr["rfr_ar_name"].ToString();
                rfr_ar_location = dr["rfr_ar_location"].ToString();
                rfr_ar_contact_name = dr["rfr_ar_contact_name"].ToString();
                rfr_ar_contact_tel = dr["rfr_ar_contact_tel"].ToString();
                rfr_ar_contact_email = dr["rfr_ar_contact_email"].ToString();
                rfr_fb_agency_name = dr["rfr_fb_agency_name"].ToString();
                rfr_fb_person_name = dr["rfr_fb_person_name"].ToString();
                rfr_fb_person_title = dr["rfr_fb_person_title"].ToString();
                rfr_fb_location = dr["rfr_fb_location"].ToString();
                rfr_fb_tel = dr["rfr_fb_tel"].ToString();
                rfr_fb_email = dr["rfr_fb_email"].ToString();
                rfr_fb_date = Convert.ToDateTime(dr["rfr_fb_date"]);
                rfr_fb_id_no = dr["rfr_fb_id_no"].ToString();
                rfr_fb_case_no = dr["rfr_fb_case_no"].ToString();
                rfr_fb_service = dr["rfr_fb_service"].ToString();
                rfr_fb_other = dr["rfr_fb_other"].ToString();
                hh_id = dr["hh_id"].ToString();
                hhm_id = dr["hhm_id"].ToString();
                prt_cso_id_ra = dr["prt_cso_id_ra"].ToString();
                wrd_id_guardian = dr["wrd_id_guardian"].ToString();
                yn_id_discussion = dr["yn_id_discussion"].ToString();
                yn_id_helpline = dr["yn_id_helpline"].ToString();
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
            strSQL = "UPDATE hh_referral " +
                "SET rfr_serial_no = '{1}', rfr_ra_location = '{2}', " +
                "rfr_ra_tel = '{3}', rfr_ra_email = '{4}', " +
                "rfr_ra_person_name = '{5}', rfr_ra_person_title = '{6}', " +
                "rfr_ra_person_tel = '{7}', rfr_ra_person_email = '{8}', " +
                "rfr_ra_date = '{9}', " +
                "rfr_cd_case_no = '{10}', " +
                "rfr_cd_nature = '{11}', rfr_cd_perpetrator = '{12}', rfr_cd_perpetrator_relationship = '{13}', " +
                "rfr_cd_date_occured = '{14}', rfr_cd_other = '{15}', " +
                "rfr_cd_accompany_name = '{16}', rfr_cd_accompany_tel = '{17}', " +
                "rfr_cd_accompany_email = '{18}', rfr_cd_accompany_relationship = '{19}', " +
                "rfr_cd_guardian_name = '{20}', rfr_cd_guardian_tel = '{21}', rfr_cd_guardian_village = '{22}', " +
                "rfr_service_before = '{23}', rfr_service_referral = '{24}', rfr_service_discussion = '{25}', " +
                "rfr_ar_name = '{26}', rfr_ar_location = '{27}', rfr_ar_contact_name = '{28}', " +
                "rfr_ar_contact_tel = '{29}', rfr_ar_contact_email = '{30}', " +
                "rfr_fb_agency_name = '{31}', rfr_fb_person_name = '{32}', rfr_fb_person_title = '{33}', " +
                "rfr_fb_location = '{34}', rfr_fb_tel = '{35}', rfr_fb_email = '{36}', " +
                "rfr_fb_date = '{37}', " +
                "rfr_fb_id_no = '{38}', rfr_fb_case_no = '{39}', " +
                "rfr_fb_service = '{40}', rfr_fb_other = '{41}', " +
                "hhm_id = '{42}', prt_cso_id_ra = '{43}', wrd_id_guardian = '{44}', " +
                "yn_id_discussion = '{45}', yn_id_helpline = '{46}', " +
                "usr_id_update = '{47}', usr_date_update = GETDATE(),district_id = '{48}' " +
                "WHERE rfr_id = '{0}' ";
            strSQL = string.Format(strSQL, rfr_id, utilFormatting.StringForSQL(rfr_serial_no), utilFormatting.StringForSQL(rfr_ra_location),
                utilFormatting.StringForSQL(rfr_ra_tel), utilFormatting.StringForSQL(rfr_ra_email),
                utilFormatting.StringForSQL(rfr_ra_person_name), utilFormatting.StringForSQL(rfr_ra_person_title),
                utilFormatting.StringForSQL(rfr_ra_person_tel), utilFormatting.StringForSQL(rfr_ra_person_email),
                rfr_ra_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(rfr_cd_case_no),
                utilFormatting.StringForSQL(rfr_cd_nature), utilFormatting.StringForSQL(rfr_cd_perpetrator), utilFormatting.StringForSQL(rfr_cd_perpetrator_relationship),
                rfr_cd_date_occured.ToString("dd MMM yyyy HH:mm:ss"), utilFormatting.StringForSQL(rfr_cd_other),
                utilFormatting.StringForSQL(rfr_cd_accompany_name), utilFormatting.StringForSQL(rfr_cd_accompany_tel),
                utilFormatting.StringForSQL(rfr_cd_accompany_email), utilFormatting.StringForSQL(rfr_cd_accompany_relationship),
                utilFormatting.StringForSQL(rfr_cd_guardian_name), utilFormatting.StringForSQL(rfr_cd_guardian_tel), utilFormatting.StringForSQL(rfr_cd_guardian_village),
                utilFormatting.StringForSQL(rfr_service_before), utilFormatting.StringForSQL(rfr_service_referral), utilFormatting.StringForSQL(rfr_service_discussion),
                utilFormatting.StringForSQL(rfr_ar_name), utilFormatting.StringForSQL(rfr_ar_location), utilFormatting.StringForSQL(rfr_ar_contact_name),
                utilFormatting.StringForSQL(rfr_ar_contact_tel), utilFormatting.StringForSQL(rfr_ar_contact_email),
                utilFormatting.StringForSQL(rfr_fb_agency_name), utilFormatting.StringForSQL(rfr_fb_person_name), utilFormatting.StringForSQL(rfr_fb_person_title),
                utilFormatting.StringForSQL(rfr_fb_location), utilFormatting.StringForSQL(rfr_fb_tel), utilFormatting.StringForSQL(rfr_fb_email),
                rfr_fb_date.ToString("dd MMM yyyy HH:mm:ss"),
                utilFormatting.StringForSQL(rfr_fb_id_no), utilFormatting.StringForSQL(rfr_fb_case_no),
                utilFormatting.StringForSQL(rfr_fb_service), utilFormatting.StringForSQL(rfr_fb_other),
                hhm_id, prt_cso_id_ra, wrd_id_guardian,
                yn_id_discussion, yn_id_helpline, 
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
                        strWHERE = strWHERE + string.Format("AND hhm.hh_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "hhm_id":
                        strWHERE = strWHERE + string.Format("AND rfr.hhm_id = '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "rfr_date_begin":
                        strWHERE = strWHERE + string.Format("AND rfr.rfr_ra_date >= '{0}' ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                    case "rfr_date_end":
                        strWHERE = strWHERE + string.Format("AND rfr.rfr_ra_date <= DATEADD(d, 1, '{0}') ",
                            arrFilter[intCount, 1].ToLower());
                        break;
                }
            }
            #endregion WHERE

            strSQL = "SELECT rfr.rfr_id, rfr.ofc_id, hh.hh_code, hhm.hhm_number, hhm.hhm_name, " +
                "RTRIM(LTRIM(CONVERT(CHAR(15), rfr.rfr_ra_date, 106))) AS the_date_display, " +
                "rfr.rfr_ra_date AS the_date " +
                "FROM hh_referral rfr " +
                "INNER JOIN hh_household_member hhm ON rfr.hhm_id = hhm.hhm_id " +
                "INNER JOIN hh_household hh ON hhm.hh_id = hh.hh_id " +
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
            strSQL = "SELECT ISNULL(MIN(rfr_ra_date), GETDATE()) AS rfr_date_begin, " +
                "ISNULL(MAX(rfr_ra_date), GETDATE()) AS rfr_date_end " +
                "FROM hh_referral ";
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Public 

        #region Private
        private DataTable GetReferral(string strId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT rfr.*, hhm.hh_id " +
            "FROM hh_referral rfr " +
            "INNER JOIN hh_household_member hhm ON rfr.hhm_id = hhm.hhm_id " +
            "WHERE rfr.rfr_id = '{0}' ";
            strSQL = string.Format(strSQL, strId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }
        #endregion Private
        #endregion Get Methods

        #region Services Provided
        private DataTable ServicesProvidedGet(string strRfrId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM hh_referral_service_provided " +
            "WHERE rfr_id = '{0}' ";
            strSQL = string.Format(strSQL, strRfrId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void ServicesProvidedLoad(string strRfrId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = ServicesProvidedGet(strRfrId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["svp_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["svp_id"].ToString();
            }

            service_provided = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void ServicesProvidedUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (service_provided.Length != 0)
            {
                strInsert = "INSERT INTO hh_referral_service_provided (rsp_id, rfr_id, svp_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT svp_id FROM hh_referral_service_provided WHERE rfr_id = '{0}') ";
                for (int intCount = 0; intCount < service_provided.Length; intCount++)
                {
                    if (service_provided[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", service_provided[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", service_provided[intCount]);
                        strSQL = strSQL + string.Format(strInsert, rfr_id, service_provided[intCount], usr_id_update, ofc_id, Convert.ToInt32(district_id));
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM hh_referral_service_provided WHERE rfr_id = '{0}' AND NOT svp_id IN ({1}) ";
            strSQL = string.Format(strSQL, rfr_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services Provided

        #region Services Referred
        private DataTable ServicesReferredGet(string strRfrId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "SELECT * " +
            "FROM hh_referral_service_referred " +
            "WHERE rfr_id = '{0}' ";
            strSQL = string.Format(strSQL, strRfrId);
            dt = dbCon.ExecuteQueryDataTable(strSQL);
            #endregion SQL

            return dt;
        }

        private void ServicesReferredLoad(string strHvId, DBConnection dbCon)
        {
            #region Variables
            DataTable dt = null;
            string strTemp = string.Empty;
            #endregion Variables

            #region Load Data
            dt = ServicesReferredGet(strHvId, dbCon);
            if (utilCollections.HasRows(dt))
            {
                strTemp = dt.Rows[0]["svr_id"].ToString();
                for (int intCount = 1; intCount < dt.Rows.Count; intCount++)
                    strTemp = strTemp + utilConstants.cDFSplitChar + dt.Rows[intCount]["svr_id"].ToString();
            }

            service_referred = strTemp.Split(utilConstants.cDFSplitChar);
            #endregion Load Data
        }

        private void ServicesReferredUpdate(DBConnection dbCon)
        {
            #region Variables
            string strInList = string.Empty;
            string strInsert = string.Empty;
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            if (service_referred.Length != 0)
            {
                strInsert = "INSERT INTO hh_referral_service_referred (rsr_id, rfr_id, svr_id, usr_id_create, usr_date_create, ofc_id,district_id) " +
                    "SELECT LOWER(NEWID()), '{0}', '{1}', '{2}', GETDATE(), '{3}','{4}' WHERE NOT '{1}' IN " +
                    "(SELECT svr_id FROM hh_referral_service_referred WHERE rfr_id = '{0}') ";
                for (int intCount = 0; intCount < service_referred.Length; intCount++)
                {
                    if (service_referred[intCount].Trim().Length != 0)
                    {
                        if (intCount == 0)
                            strInList = string.Format("'{0}'", service_referred[intCount]);
                        else
                            strInList = strInList + "," + string.Format("'{0}'", service_referred[intCount]);
                        strSQL = strSQL + string.Format(strInsert, rfr_id, service_referred[intCount], usr_id_update, ofc_id,district_id);
                    }
                }
            }
            if (strInList.Trim().Length == 0)
                strInList = "''";
            strSQL = strSQL + "DELETE FROM hh_referral_service_referred WHERE rfr_id = '{0}' AND NOT svr_id IN ({1}) ";
            strSQL = string.Format(strSQL, rfr_id, strInList);
            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Services Referred
    }
}