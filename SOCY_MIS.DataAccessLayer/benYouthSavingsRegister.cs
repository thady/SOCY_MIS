using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
   public static class benYouthSavingsRegister
    {
        #region Variables

        #region ben_youthgroup_savings_register Table
        public static string ysr_id = string.Empty;
        public static string prt_id = string.Empty;
        public static string cso_id = string.Empty;
        public static string dst_id = string.Empty;
        public static string sct_id = string.Empty;
        public static string wrd_id = string.Empty;
        public static string village = string.Empty;
        public static string month = string.Empty;
        public static string year = string.Empty;
        public static string ygrp_name = string.Empty;
        public static string ygrp_chairperson_name = string.Empty;
        public static string ygrp_chairperson_name_phone = string.Empty;
        public static string youth_field_assisstant_name = string.Empty;
        public static string usr_id_create = string.Empty;
        public static string usr_id_update = string.Empty;
        public static DateTime usr_date_create = DateTime.Now;
        public static DateTime usr_date_update = DateTime.Now;
        public static string ofc_id = string.Empty;
        public static string district_id = string.Empty;
        #endregion ben_youthgroup_savings_register Table

        #region ben_youthgroup_savings_register_member Table
        public static string ysrm_id = string.Empty;
        public static string hhm_code = string.Empty;
        public static string hhm_name = string.Empty;
        public static string hhm_id = string.Empty;
        public static string yn_direct_beneficiary = string.Empty;
        #endregion ben_youthgroup_savings_register_member Table

        #region ben_youthgroup_savings_register_member_amount Table
        public static string ysrms_id = string.Empty;
        public static string total_savings = string.Empty;
        public static string amout_borrowed = string.Empty;
        public static string loan_purpose = string.Empty;
        public static string loan_purpose_other = string.Empty;
        #endregion ben_youthgroup_savings_register_member_amount Table

        #endregion  Variables

        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        public static DataTable Return_lookups(string lookup_type, string id, string dst_id, string sct_id,string wrd_id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                switch (lookup_type)
                {
                    case "district":
                        SQL = "SELECT dst_id, dst_name FROM lst_district";
                        break;
                    case "subcounty":
                        if (id != string.Empty)
                        {
                            SQL = "SELECT sct_id,sct_name FROM lst_sub_county WHERE dst_id = '" + id + "'";
                        }
                        else
                        {
                            SQL = "SELECT sct_id,sct_name FROM lst_sub_county";
                        }
                        break;
                    case "parish":
                        SQL = "SELECT wrd_id,wrd_name FROM lst_ward WHERE sct_id = '" + id + "'";
                        break;
                    case "IP":
                        SQL = "SELECT prt_id,prt_name FROM lst_partner";
                        break;
                    case "services_provided":
                        SQL = "SELECT linkages_service_id,service_name FROM lst_linkages_services_provided";
                        break;
                    case "services_required":
                        SQL = " SELECT linkages_service_offered_id,service_name FROM lst_linkages_services_required";
                        break;
                    case "CSO":
                        if (id != string.Empty)
                        {
                            SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso WHERE prt_id = '" + id + "'";
                        }
                        else
                        {
                            SQL = "SELECT [cso_id],[cso_other]  FROM lst_cso";
                        }
                        break;
                    case "gender":
                        SQL = "  SELECT gnd_id,gnd_name FROM lst_gender";
                        break;
                    case "hh_codes":
                        SQL = @"SELECT H.hh_code,H.hh_id FROM hh_household H
                                LEFT JOIN lst_ward W ON H.wrd_id = W.wrd_sid
                                LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                                LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                                WHERE D.dst_id = '{0}'
                                AND S.sct_id = '{1}'
                                AND w.wrd_id = '{2}'";
                        SQL = string.Format(SQL, dst_id, sct_id,wrd_id);
                        break;
                }
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

            return dt;
        }

        #region Save Youth Savings register
        public static string save_update_YouthSavingsRegister(string action)
        {
            string Query = string.Empty;
            string _ysr_id = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ysr_id nvarchar(150))INSERT INTO [dbo].[ben_youthgroup_savings_register]
                       ([ysr_id],[prt_id],[cso_id],[dst_id],[sct_id],[wrd_id],[village],[month]
                       ,[year],[ygrp_name],[ygrp_chairperson_name],[ygrp_chairperson_name_phone]
                       ,[youth_field_assisstant_name],[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update],[ofc_id],[district_id])
                        OUTPUT INSERTED.[ysr_id] INTO @tempTable
                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')
                       SELECT ysr_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_youthgroup_savings_register]
                           SET [prt_id] = '{1}',[cso_id] = '{2}' ,[dst_id] = '{3}' ,[sct_id] = '{4}'
                              ,[wrd_id] = '{5}' ,[village] = '{6}',[month] = '{7}',[year] = '{8}'
                              ,[ygrp_name] = '{9}',[ygrp_chairperson_name] = '{10}',[ygrp_chairperson_name_phone] = '{11}'
                              ,[youth_field_assisstant_name] = '{12}',[usr_id_update] = '{13}',[usr_date_update] ='{14}'
                         WHERE [ysr_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ysr_id, prt_id, cso_id, dst_id, sct_id, wrd_id, village, month, year, utilFormatting.StringForSQL(ygrp_name) , ygrp_chairperson_name, ygrp_chairperson_name_phone, youth_field_assisstant_name,
                        usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ysr_id, prt_id, cso_id, dst_id, sct_id, wrd_id, village, month, year, utilFormatting.StringForSQL(ygrp_name), ygrp_chairperson_name, ygrp_chairperson_name_phone, youth_field_assisstant_name,
                        usr_id_update, usr_date_update);

                }
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (action == "insert")
                    {
                        _ysr_id = (string)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
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
            if (action == "insert")
            {
                return _ysr_id;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion Save Youth Savings register

        #region save Youth savings register member
        public static string save_update_YouthSavingsRegisterMember(string action)
        {
            string Query = string.Empty;
            string _ysrm_id = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ysrm_id nvarchar(150))INSERT INTO [dbo].[ben_youthgroup_savings_register_member]
                       ([ysrm_id],[ysr_id],[hhm_code],[hhm_name]
                       ,[usr_id_create],[usr_id_update],[usr_date_create],[usr_date_update]
                       ,[ofc_id],[district_id],[hhm_id],[yn_direct_beneficiary])
                        OUTPUT INSERTED.[ysrm_id] INTO @tempTable
                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')
                       SELECT ysrm_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_youthgroup_savings_register_member]
                           SET [hhm_code] = '{1}'
                              ,[hhm_name] = '{2}'
                              ,[usr_id_update] = '{3}'
                              ,[usr_date_update] = '{4}'
                              ,[hhm_id] = '{5}'
                              ,[yn_direct_beneficiary] = '{6}'
                         WHERE [ysrm_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ysrm_id, ysr_id, hhm_code, hhm_name,
                        usr_id_create, usr_id_update, usr_date_create, usr_date_update, ofc_id, district_id,hhm_id,yn_direct_beneficiary);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ysrm_id, hhm_code, hhm_name,
                        usr_id_update, usr_date_update, hhm_id, yn_direct_beneficiary);

                }
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (action == "insert")
                    {
                        _ysrm_id = (string)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
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
            if (action == "insert")
            {
                return _ysrm_id;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion save Youth savings register member

        #region Save Youth Member savings and Loans
        public static string save_update_YouthSavingsRegisterMemberAmount(string action)
        {
            string Query = string.Empty;
            string _ysrms_id = string.Empty;

            if (action == "insert")
            {
                //insert
                Query = @"DECLARE @tempTable TABLE (ysrms_id nvarchar(150))INSERT INTO [dbo].[ben_youthgroup_savings_register_member_amount]
                       ([ysrm_id]
                       ,[ysrms_id]
                       ,[total_savings]
                       ,[amout_borrowed]
                       ,[loan_purpose]
                       ,[loan_purpose_other]
                       ,[district_id])
                        OUTPUT INSERTED.[ysrms_id] INTO @tempTable
                       VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')
                       SELECT ysrms_id FROM @tempTable";
            }
            else if (action == "update")
            {
                //update
                Query = @"UPDATE [dbo].[ben_youthgroup_savings_register_member_amount]
                           SET [total_savings] = '{1}'
                              ,[amout_borrowed] = '{2}'
                              ,[loan_purpose] = '{3}'
                              ,[loan_purpose_other] = '{4}'
                         WHERE [ysrms_id] = '{0}'";
            }
            string SQL = string.Empty;
            try
            {
                if (action == "insert")
                {
                    SQL = string.Format(Query, ysrm_id, ysrms_id, total_savings, amout_borrowed,
                        loan_purpose, loan_purpose_other,district_id);

                }
                else if (action == "update")
                {
                    SQL = string.Format(Query, ysrms_id, total_savings, amout_borrowed, loan_purpose, loan_purpose_other);
                       

                }
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    if (action == "insert")
                    {
                        _ysrms_id = (string)cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
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
            if (action == "insert")
            {
                return _ysrms_id;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion  Save Youth Member savings and Loans
        public static DataTable ReturnYouthGroups()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
               
                SQL = @"SELECT ysr_id,month,year,ygrp_name FROM ben_youthgroup_savings_register";

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

            return dt;
        }

        public static DataTable Search(string dst_id, string sct_id, string prt_id, string cso_id, string wrd_id,string grp_name)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                SQL = @" SELECT ysr_id,month,year,ygrp_name
                         FROM ben_youthgroup_savings_register Y
                         LEFT JOIN lst_ward W ON Y.wrd_id = W.wrd_id
                         LEFT JOIN lst_sub_county S ON W.sct_id = S.sct_id
                         LEFT JOIN lst_district D ON S.dst_id = D.dst_id
                         LEFT JOIN lst_partner P ON Y.prt_id = P.prt_id
                         LEFT JOIN lst_cso C ON Y.cso_id = C.cso_id
                         WHERE (@dst_id = '-1' OR Y.dst_id = @dst_id )
                         AND (@sct_id = '-1' OR Y.sct_id = @sct_id)
                         AND (@prt_id = '-1' OR Y.prt_id = @prt_id)
                         AND (@cso_id = '-1' OR Y.cso_id = @cso_id)
                         AND (@wrd_id = '-1' OR Y.wrd_id =  @wrd_id)
                         AND (@ygrp_name = '' OR Y.ygrp_name LIKE '%' + @ygrp_name + '%')
                        ";
                using (conn = new SqlConnection(SQLConnection))
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandTimeout = 3600;

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@dst_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@dst_id"].Value = dst_id;

                    cmd.Parameters.Add("@sct_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@sct_id"].Value = sct_id;

                    cmd.Parameters.Add("@prt_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@prt_id"].Value = prt_id;

                    cmd.Parameters.Add("@cso_id", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@cso_id"].Value = cso_id;

                    cmd.Parameters.Add("@wrd_id", SqlDbType.NVarChar, 20);
                    cmd.Parameters["@wrd_id"].Value = wrd_id;

                    cmd.Parameters.Add("@ygrp_name", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@ygrp_name"].Value = grp_name;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    Adapt = new SqlDataAdapter(cmd);
                    Adapt.Fill(dt);

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

            return dt;
        }

        public static DataTable ReturnYouthGroupDetails(string id,string action)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            try
            {
                if (action == "group_details")
                {
                    SQL = @"SELECT* FROM ben_youthgroup_savings_register WHERE ysr_id = '" + id + "'";
                }
                else if (action == "group_members")
                {
                    SQL = @"SELECT A.ysrms_id,M.hhm_code,M.hhm_name,ISNULL(A.total_savings, '') AS total_savings,ISNULL(A.amout_borrowed, '') AS amout_borrowed ,ISNULL(A.loan_purpose, '') AS loan_purpose,
                            A.loan_purpose_other,M.hhm_id,M.yn_direct_beneficiary,M.ysrm_id
                            FROM ben_youthgroup_savings_register_member M
                            LEFT JOIN ben_youthgroup_savings_register_member_amount A ON M.ysrm_id = A.ysrm_id
                            WHERE ysr_id = '" + id + "' ";
                }
                else if (action == "member_savings")
                {
                    SQL = @"SELECT A.ysrms_id,M.hhm_code,M.hhm_name,A.total_savings,A.amout_borrowed,A.loan_purpose,A.loan_purpose_other
                              FROM ben_youthgroup_savings_register_member_amount A
                              LEFT JOIN ben_youthgroup_savings_register_member M ON A.ysrm_id = M.ysrm_id
                            WHERE A.ysrm_id = '" + id + "'";
                }
                else if (action == "Youth")
                {
                    SQL = @"SELECT hhm_first_name + ' ' + hhm_last_name AS hhm_name,hhm_id
                            FROM hh_household_member WHERE hh_id = '{0}'
                            AND hhm_year_of_birth <> '*' 
                            AND hhm_year_of_birth <> '-1' 
                            AND YEAR(GETDATE()) - CAST(hhm_year_of_birth AS INT)  >= 15 
                            AND YEAR(GETDATE()) - CAST(hhm_year_of_birth AS INT) <= 24 ";

                    SQL = string.Format(SQL, id);
                }
                

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

            return dt;
        }
    }
}
