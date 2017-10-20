using System;
using System.Collections.Generic;
using System.Text;

using PSAUtils;

namespace SOCY_MIS.DataAccessLayer
{
    public class ssError
    {
        #region Variables
        public string err_form = string.Empty;
        public string err_message = string.Empty;
        public string err_method = string.Empty;
        public string err_stack = string.Empty;
        public string usr_id_create = string.Empty;
        public string ofc_id = string.Empty;
        #endregion Variables

        #region Constructor
        public ssError()
        { }

        public ssError(string strErrForm, string strErrMethod, string strErrMessage, string strErrStack, string strUsrId, string strOfcId)
        {
            #region Load Variables
            err_form = strErrForm;
            err_message = strErrMessage;
            err_method = strErrMethod;
            err_stack = strErrStack;
            usr_id_create = strUsrId;
            ofc_id = strOfcId;
            #endregion Load Variables
        }
        #endregion Constructor

        #region Function Methods
        #region Public
        public void Save()
        {
            #region Variables
            DBConnection dbCon = null;
            #endregion Variables

            #region Save
            dbCon = new DBConnection(utilConstants.cACKConnection);
            try
            {
                Insert(dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Save
        }

        public void Save(DBConnection dbCon)
        {
            Insert(dbCon);
        }
        #endregion Public

        #region Private
        private void Insert(DBConnection dbCon)
        {
            #region Variables
            string strSQL = string.Empty;
            #endregion Variables

            #region SQL
            strSQL = "INSERT INTO ss_error (err_form, err_method, err_message, err_stack, usr_id_create, usr_date_create, ofc_id) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), '{5}') ";
            strSQL = string.Format(strSQL, err_form, err_method, utilFormatting.StringForSQL(err_message), utilFormatting.StringForSQL(err_stack), 
                usr_id_create, ofc_id);

            dbCon.ExecuteNonQuery(strSQL);
            #endregion SQL
        }
        #endregion Private
        #endregion Function Methods
    }
}
