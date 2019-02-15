using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SOCY_MIS.DataAccessLayer
{
    public static class benOvcNonSuppressionAdherenceCounselling
    {
        #region dbconnection
        static DataAccessLayer.DBConnection dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
        static string SQLConnection = dbCon.SQLDBConnection(utilConstants.cACKConnection);
        static SqlConnection conn = null;

        #endregion dbconnection

        public static DataTable ReturnLists(string Table)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Adapt;
            string SQL = string.Empty;
            switch (Table)
            {
                case "lst_non_supress_health_facility":
                    SQL = "SELECT [nsp_id],[nsp_name] FROM lst_non_supress_health_facility";
                    break;
                case "lst_non_supress_household":
                    SQL = "SELECT [nsp_id],[nsp_name] FROM lst_non_supress_household";
                    break;
                case "lst_non_supress_action":
                    SQL = "SELECT [nspa_id],[nspa_name],GETDATE() AS time_line FROM lst_non_supress_action";
                    break;
            }

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
