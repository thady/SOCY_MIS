using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PSAUtils;
using PSAUtilsWin32;
using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmCBSDStaffAppraisalTracking : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strId = string.Empty;
        private frmCBSDStaffAppraisalTrackingSearch frmCll = null;
        private frmResultArea02 frmPrt = null;
        #endregion Variables

        #region Property
        public frmCBSDStaffAppraisalTrackingSearch FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmResultArea02 FormParent
        {
            get { return frmPrt; }
            set { frmPrt = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property
        
        #region Form Methods
        public frmCBSDStaffAppraisalTracking()
        {
            InitializeComponent();
        }

        private void frmCBSDStaffAppraisalTracking_Load(object sender, EventArgs e)
        {
            if (FormParent.FormMaster.NoDatabase)
            {
                btnCancel.Enabled = !FormParent.FormMaster.NoDatabase;
                btnSave.Enabled = !FormParent.FormMaster.NoDatabase;
            }
            else
            {
                SetPermissions();
                LoadDisplay();
            }
        }

        private void frmCBSDStaffAppraisalTracking_Paint(object sender, PaintEventArgs e)
        {
            cbDistrict.SelectionLength = 0;
            cbFinancialYear.SelectionLength = 0;
            cbPartner.SelectionLength = 0;
            cbRegion.SelectionLength = 0;
        }
        #endregion Form Methods

        #region Control Methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadListsArea("", cbRegion.SelectedValue.ToString());
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        #region Lables
        private void lblPostsApprovedTotal_TextChanged(object sender, EventArgs e)
        {
            SetProportion(lblPostsApprovedTotal, lblPostsFilledTotal, lblPostsProportionTotal);
        }

        private void lblPostsFilledTotal_TextChanged(object sender, EventArgs e)
        {
            SetProportion(lblPostsApprovedTotal, lblPostsFilledTotal, lblPostsProportionTotal);
        }
        #endregion Labels

        #region TextBoxes / Labels
        private void txtPostsApprovedACDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsApprovedACDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedACDO, txtPostsFilledACDO, lblPostsProportionACDO, lblStaffingGapACDO);
            SetTotal(txtPostsApprovedACDO, txtPostsApprovedCDO, txtPostsApprovedDCDO, txtPostsApprovedSPSWO, txtPostsApprovedSCDO, lblPostsApprovedTotal);
        }

        private void txtPostsApprovedCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsApprovedCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedCDO, txtPostsFilledCDO, lblPostsProportionCDO, lblStaffingGapCDO);
            SetTotal(txtPostsApprovedACDO, txtPostsApprovedCDO, txtPostsApprovedDCDO, txtPostsApprovedSPSWO, txtPostsApprovedSCDO, lblPostsApprovedTotal);
        }

        private void txtPostsApprovedDCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsApprovedDCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedDCDO, txtPostsFilledDCDO, lblPostsProportionDCDO, lblStaffingGapDCDO);
            SetTotal(txtPostsApprovedACDO, txtPostsApprovedCDO, txtPostsApprovedDCDO, txtPostsApprovedSPSWO, txtPostsApprovedSCDO, lblPostsApprovedTotal);
        }

        private void txtPostsApprovedSPSWO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsApprovedSPSWO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedSPSWO, txtPostsFilledSPSWO, lblPostsProportionSPSWO, lblStaffingGapSPSWO);
            SetTotal(txtPostsApprovedACDO, txtPostsApprovedCDO, txtPostsApprovedDCDO, txtPostsApprovedSPSWO, txtPostsApprovedSCDO, lblPostsApprovedTotal);
        }

        private void txtPostsApprovedSCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsApprovedSCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedSCDO, txtPostsFilledSCDO, lblPostsProportionSCDO, lblStaffingGapSCDO);
            SetTotal(txtPostsApprovedACDO, txtPostsApprovedCDO, txtPostsApprovedDCDO, txtPostsApprovedSPSWO, txtPostsApprovedSCDO, lblPostsApprovedTotal);
        }

        private void txtPostsFilledACDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsFilledACDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedACDO, txtPostsFilledACDO, lblPostsProportionACDO, lblStaffingGapACDO);
            SetTotal(txtPostsFilledACDO, txtPostsFilledCDO, txtPostsFilledDCDO, txtPostsFilledSPSWO, txtPostsFilledSCDO, lblPostsFilledTotal);
        }

        private void txtPostsFilledCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsFilledCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedCDO, txtPostsFilledCDO, lblPostsProportionCDO, lblStaffingGapCDO);
            SetTotal(txtPostsFilledACDO, txtPostsFilledCDO, txtPostsFilledDCDO, txtPostsFilledSPSWO, txtPostsFilledSCDO, lblPostsFilledTotal);
        }

        private void txtPostsFilledDCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsFilledDCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedDCDO, txtPostsFilledDCDO, lblPostsProportionDCDO, lblStaffingGapDCDO);
            SetTotal(txtPostsFilledACDO, txtPostsFilledCDO, txtPostsFilledDCDO, txtPostsFilledSPSWO, txtPostsFilledSCDO, lblPostsFilledTotal);
        }

        private void txtPostsFilledSPSWO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsFilledSPSWO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedSPSWO, txtPostsFilledSPSWO, lblPostsProportionSPSWO, lblStaffingGapSPSWO);
            SetTotal(txtPostsFilledACDO, txtPostsFilledCDO, txtPostsFilledDCDO, txtPostsFilledSPSWO, txtPostsFilledSCDO, lblPostsFilledTotal);
        }

        private void txtPostsFilledSCDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = utilControls.TextboxInteger(e.KeyChar, (sender as TextBox).Text);
        }

        private void txtPostsFilledSCDO_TextChanged(object sender, EventArgs e)
        {
            SetProportion(txtPostsApprovedSCDO, txtPostsFilledSCDO, lblPostsProportionSCDO, lblStaffingGapSCDO);
            SetTotal(txtPostsFilledACDO, txtPostsFilledCDO, txtPostsFilledDCDO, txtPostsFilledSPSWO, txtPostsFilledSCDO, lblPostsFilledTotal);
        }

        private void lblStaffingGapACDO_TextChanged(object sender, EventArgs e)
        {
            SetTotal(lblStaffingGapACDO, lblStaffingGapCDO, lblStaffingGapDCDO, lblStaffingGapSPSWO, lblStaffingGapSCDO, lblStaffingGapTotal);
        }

        private void lblStaffingGapCDO_TextChanged(object sender, EventArgs e)
        {
            SetTotal(lblStaffingGapACDO, lblStaffingGapCDO, lblStaffingGapDCDO, lblStaffingGapSPSWO, lblStaffingGapSCDO, lblStaffingGapTotal);
        }

        private void lblStaffingGapDCDO_TextChanged(object sender, EventArgs e)
        {
            SetTotal(lblStaffingGapACDO, lblStaffingGapCDO, lblStaffingGapDCDO, lblStaffingGapSPSWO, lblStaffingGapSCDO, lblStaffingGapTotal);
        }

        private void lblStaffingGapSPSWO_TextChanged(object sender, EventArgs e)
        {
            SetTotal(lblStaffingGapACDO, lblStaffingGapCDO, lblStaffingGapDCDO, lblStaffingGapSPSWO, lblStaffingGapSCDO, lblStaffingGapTotal);
        }

        private void lblStaffingGapSCDO_TextChanged(object sender, EventArgs e)
        {
            SetTotal(lblStaffingGapACDO, lblStaffingGapCDO, lblStaffingGapDCDO, lblStaffingGapSPSWO, lblStaffingGapSCDO, lblStaffingGapTotal);
        }
        #endregion TextBoxes
        #endregion Control Methods

        #region Private Methods
        private void Back()
        {
            FormCalling.BackDisplay();
            FormParent.LoadControl(FormCalling, this.Name);
        }

        private void Clear()
        {
            try
            {
                #region Clear
                if (ObjectId.Length == 0)
                {
                    #region Clear
                    cbFinancialYear.SelectedIndex = 0;
                    cbPartner.SelectedIndex = 0;
                    cbRegion.SelectedIndex = 0;
                    dtpDate.Value = DateTime.Now;
                    txtComments.Text = string.Empty;

                    txtPostsApprovedACDO.Text = "0";
                    txtPostsApprovedCDO.Text = "0";
                    txtPostsApprovedDCDO.Text = "1";
                    txtPostsApprovedSPSWO.Text = "1";
                    txtPostsFilledACDO.Text = "0";
                    txtPostsFilledCDO.Text = "0";
                    txtPostsFilledDCDO.Text = "0";
                    txtPostsFilledSPSWO.Text = "0";

                    LoadListsArea("", cbRegion.SelectedValue.ToString());
                    #endregion Clear
                }
                else
                {
                    LoadDisplay();
                }
                #endregion Clear
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Clear", exc);
            }
        }

        private void LoadDisplay()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                prtCBSDStaffAppraisalTracking dalCSAT = null;
                prtCBSDStaffAppraisalTrackingLine dalCSATL = null;
                DataTable dt = null;
                #endregion Variables

                if (ObjectId.Length == 0)
                {
                    LoadLists();
                }
                else
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        #region Load Display
                        dalCSAT = new prtCBSDStaffAppraisalTracking(ObjectId, dbCon);
                        dtpDate.Value = dalCSAT.csat_date;
                        txtComments.Text = dalCSAT.csat_comment;
                        LoadLists(dalCSAT.dst_id, dalCSAT.fy_id, dalCSAT.prt_id, dbCon);

                        #region Lines
                        dt = dalCSAT.GetLines(ObjectId, dbCon);

                        if (utilCollections.HasRows(dt))
                        {
                            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
                            {
                                dalCSATL = new prtCBSDStaffAppraisalTrackingLine(dt.Rows[intCount]["csatl_id"].ToString(), dbCon);
                                switch (dalCSATL.ss_id)
                                {
                                    case utilConstants.cSSACDO:
                                        lblACDOId.Text = dalCSATL.csatl_id;
                                        txtPostsApprovedACDO.Text = dalCSATL.csatl_posts_approved.ToString();
                                        txtPostsFilledACDO.Text = dalCSATL.csatl_posts_filled.ToString();
                                        utilControls.RadioButtonSetSelection(rbtnAppraisalStatusACDOYes, rbtnAppraisalStatusACDONo, dalCSATL.yn_id_conducted);
                                        break;
                                    case utilConstants.cSSCDO:
                                        lblCDOId.Text = dalCSATL.csatl_id;
                                        txtPostsApprovedCDO.Text = dalCSATL.csatl_posts_approved.ToString();
                                        txtPostsFilledCDO.Text = dalCSATL.csatl_posts_filled.ToString();
                                        utilControls.RadioButtonSetSelection(rbtnAppraisalStatusCDOYes, rbtnAppraisalStatusCDONo, dalCSATL.yn_id_conducted);
                                        break;
                                    case utilConstants.cSSDCDO:
                                        lblDCDOId.Text = dalCSATL.csatl_id;
                                        txtPostsApprovedDCDO.Text = dalCSATL.csatl_posts_approved.ToString();
                                        txtPostsFilledDCDO.Text = dalCSATL.csatl_posts_filled.ToString();
                                        utilControls.RadioButtonSetSelection(rbtnAppraisalStatusDCDOYes, rbtnAppraisalStatusDCDONo, dalCSATL.yn_id_conducted);
                                        break;
                                    case utilConstants.cSSSPSWO:
                                        lblSPSWOId.Text = dalCSATL.csatl_id;
                                        txtPostsApprovedSPSWO.Text = dalCSATL.csatl_posts_approved.ToString();
                                        txtPostsFilledSPSWO.Text = dalCSATL.csatl_posts_filled.ToString();
                                        utilControls.RadioButtonSetSelection(rbtnAppraisalStatusSPSWOYes, rbtnAppraisalStatusSPSWONo, dalCSATL.yn_id_conducted);
                                        break;
                                    case utilConstants.cSSSCDO:
                                        lblSCDOId.Text = dalCSATL.csatl_id;
                                        txtPostsApprovedSCDO.Text = dalCSATL.csatl_posts_approved.ToString();
                                        txtPostsFilledSCDO.Text = dalCSATL.csatl_posts_filled.ToString();
                                        utilControls.RadioButtonSetSelection(rbtnAppraisalStatusSCDOYes, rbtnAppraisalStatusSCDONo, dalCSATL.yn_id_conducted);
                                        break;
                                }
                            }
                        }
                        #endregion Lines

                        btnSave.Enabled = pblnManage && (FormParent.FormMaster.OfficeId.Equals(dalCSAT.ofc_id) || SystemConstants.Validate_Office_group_access(FormParent.FormMaster.OfficeId, dalCSAT.ofc_id));
                        #endregion Load Display
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadDisplay", exc);
            }
        }

        private void LoadLists()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadLists("", "", "", dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadLists(string strDstId, string strFyId, string strPrtId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetData("lst_region", true, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbRegion, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_financial_year", true, strFyId, true, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbFinancialYear, dt, "lt_id", "lt_name");

                dt = uLT.GetData("lst_partner", true, strPrtId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbPartner, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strFyId.Length != 0)
                    cbFinancialYear.SelectedValue = strFyId;
                else
                    cbFinancialYear.SelectedIndex = 0;
                if (strPrtId.Length != 0)
                    cbPartner.SelectedValue = strPrtId;
                else
                    cbPartner.SelectedIndex = 0;
                #endregion Set List Selection

                LoadListsArea(strDstId, cbRegion.SelectedValue.ToString(), dbCon);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadLists", exc);
            }
        }

        private void LoadListsArea(string strDstId, string strRgnId)
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            #endregion Variables

            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                LoadListsArea("", strRgnId, dbCon);
            }
            finally
            {
                dbCon.Dispose();
            }
        }

        private void LoadListsArea(string strDstId, string strRgnId, DataAccessLayer.DBConnection dbCon)
        {
            try
            {
                #region Variables
                utilLanguageTranslation utilLT = null;
                utilListTable uLT = null;
                utilSOCY_MIS utilSM = null;

                DataTable dt = null;
                string strEmptySingleSelect = string.Empty;
                #endregion Variables

                utilLT = new utilLanguageTranslation();
                utilLT.Language = FormParent.FormMaster.LanguageId;
                strEmptySingleSelect = utilLT.GetMessageTranslation(utilConstants.cMIDEmptyListSingleSelect, dbCon.dbCon);

                #region Get Region
                if (strDstId.Length != 0 && (strRgnId.Length == 0 || strRgnId.Equals(utilConstants.cDFEmptyListValue)))
                { 
                    utilSM = new utilSOCY_MIS();
                    dt = utilSM.GetParentRegion(strDstId, "", dbCon);
                    if (utilCollections.HasRows(dt))
                        strRgnId = dt.Rows[0]["rgn_id"].ToString();
                }
                #endregion Get Region

                #region Load Lists
                uLT = new utilListTable();

                dt = uLT.GetDataByParent("lst_district", strRgnId, true, strDstId, FormParent.FormMaster.LanguageId, dbCon.dbCon);
                dt = utilCollections.AddEmptyItemFront(dt, "lt_id", "lt_name", utilConstants.cDFEmptyListValue, strEmptySingleSelect);
                utilControls.ComboBoxFill(cbDistrict, dt, "lt_id", "lt_name");
                #endregion Load Lists

                #region Set List Selection
                if (strDstId.Length != 0)
                    cbDistrict.SelectedValue = strDstId;
                else
                    cbDistrict.SelectedIndex = 0;
                if (strRgnId.Length != 0)
                    cbRegion.SelectedValue = strRgnId;
                else
                    cbRegion.SelectedIndex = 0;
                #endregion Set List Selection
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "LoadListsArea", exc);
            }
        }

        private void Save()
        {
            try
            {
                #region Variables
                DataAccessLayer.DBConnection dbCon = null;
                utilLanguageTranslation utilLT = null;
                prtCBSDStaffAppraisalTracking dalCSAT = null;
                prtCBSDStaffAppraisalTrackingLine dalCSATL = null;

                int intPopUpType = utilConstants.cPTWarning;
                string strMessage = ValidateInput();
                #endregion Variables

                #region Save
                if (strMessage.Length == 0)
                {
                    dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                    try
                    {
                        dbCon.TransactionBegin();
                        dalCSAT = new prtCBSDStaffAppraisalTracking();

                        if (ObjectId.Length == 0)
                        {
                            ObjectId = Guid.NewGuid().ToString();
                            dalCSAT.csat_id = ObjectId;
                            dalCSAT.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSAT.Load(ObjectId, dbCon);

                        dalCSAT.csat_date = dtpDate.Value;
                        dalCSAT.csat_comment = txtComments.Text.Trim();
                        dalCSAT.dst_id = cbDistrict.SelectedValue.ToString();
                        dalCSAT.fy_id = cbFinancialYear.SelectedValue.ToString();
                        dalCSAT.prt_id = cbPartner.SelectedValue.ToString();
                        dalCSAT.usr_id_update = FormParent.FormMaster.UserId;

                        dalCSAT.Save(dbCon);

                        dalCSATL = new prtCBSDStaffAppraisalTrackingLine();

                        #region ACDO
                        if (lblACDOId.Text.Trim().Length == 0 || lblACDOId.Text.Trim().Equals("-"))
                        {
                            dalCSATL.Default();
                            lblACDOId.Text = Guid.NewGuid().ToString();
                            dalCSATL.csatl_id = lblACDOId.Text;
                            dalCSATL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSATL.Load(lblACDOId.Text, dbCon);

                        dalCSATL.csat_id = ObjectId;

                        if (txtPostsApprovedACDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_approved = 0;
                        else
                            dalCSATL.csatl_posts_approved = Convert.ToInt32(txtPostsApprovedACDO.Text.Trim());
                        if (txtPostsFilledACDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_filled = 0;
                        else
                            dalCSATL.csatl_posts_filled = Convert.ToInt32(txtPostsFilledACDO.Text.Trim());

                        dalCSATL.ss_id = utilConstants.cSSACDO;
                        dalCSATL.yn_id_conducted = utilControls.RadioButtonGetSelection(rbtnAppraisalStatusACDOYes, rbtnAppraisalStatusACDONo);
                        dalCSATL.Save(dbCon);
                        #endregion ACDO

                        #region CDO
                        if (lblCDOId.Text.Trim().Length == 0 || lblCDOId.Text.Trim().Equals("-"))
                        {
                            dalCSATL.Default();
                            lblCDOId.Text = Guid.NewGuid().ToString();
                            dalCSATL.csatl_id = lblCDOId.Text;
                            dalCSATL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSATL.Load(lblCDOId.Text, dbCon);

                        dalCSATL.csat_id = ObjectId;

                        if (txtPostsApprovedCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_approved = 0;
                        else
                            dalCSATL.csatl_posts_approved = Convert.ToInt32(txtPostsApprovedCDO.Text.Trim());
                        if (txtPostsFilledCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_filled = 0;
                        else
                            dalCSATL.csatl_posts_filled = Convert.ToInt32(txtPostsFilledCDO.Text.Trim());

                        dalCSATL.ss_id = utilConstants.cSSCDO;
                        dalCSATL.yn_id_conducted = utilControls.RadioButtonGetSelection(rbtnAppraisalStatusCDOYes, rbtnAppraisalStatusCDONo);
                        dalCSATL.Save(dbCon);
                        #endregion CDO

                        #region DCDO
                        if (lblDCDOId.Text.Trim().Length == 0 || lblDCDOId.Text.Trim().Equals("-"))
                        {
                            dalCSATL.Default();
                            lblDCDOId.Text = Guid.NewGuid().ToString();
                            dalCSATL.csatl_id = lblDCDOId.Text;
                            dalCSATL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSATL.Load(lblDCDOId.Text, dbCon);

                        dalCSATL.csat_id = ObjectId;

                        if (txtPostsApprovedDCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_approved = 0;
                        else
                            dalCSATL.csatl_posts_approved = Convert.ToInt32(txtPostsApprovedDCDO.Text.Trim());
                        if (txtPostsFilledDCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_filled = 0;
                        else
                            dalCSATL.csatl_posts_filled = Convert.ToInt32(txtPostsFilledDCDO.Text.Trim());

                        dalCSATL.ss_id = utilConstants.cSSDCDO;
                        dalCSATL.yn_id_conducted = utilControls.RadioButtonGetSelection(rbtnAppraisalStatusDCDOYes, rbtnAppraisalStatusDCDONo);
                        dalCSATL.Save(dbCon);
                        #endregion DCDO

                        #region SPSWO
                        if (lblSPSWOId.Text.Trim().Length == 0 || lblSPSWOId.Text.Trim().Equals("-"))
                        {
                            dalCSATL.Default();
                            lblSPSWOId.Text = Guid.NewGuid().ToString();
                            dalCSATL.csatl_id = lblSPSWOId.Text;
                            dalCSATL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSATL.Load(lblSPSWOId.Text, dbCon);

                        dalCSATL.csat_id = ObjectId;

                        if (txtPostsApprovedSPSWO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_approved = 0;
                        else
                            dalCSATL.csatl_posts_approved = Convert.ToInt32(txtPostsApprovedSPSWO.Text.Trim());
                        if (txtPostsFilledSPSWO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_filled = 0;
                        else
                            dalCSATL.csatl_posts_filled = Convert.ToInt32(txtPostsFilledSPSWO.Text.Trim());

                        dalCSATL.ss_id = utilConstants.cSSSPSWO;
                        dalCSATL.yn_id_conducted = utilControls.RadioButtonGetSelection(rbtnAppraisalStatusSPSWOYes, rbtnAppraisalStatusSPSWONo);
                        dalCSATL.Save(dbCon);
                        #endregion SPSWO

                        #region SCDO
                        if (lblSCDOId.Text.Trim().Length == 0 || lblSCDOId.Text.Trim().Equals("-"))
                        {
                            dalCSATL.Default();
                            lblSCDOId.Text = Guid.NewGuid().ToString();
                            dalCSATL.csatl_id = lblSCDOId.Text;
                            dalCSATL.ofc_id = FormParent.FormMaster.OfficeId;
                        }
                        else
                            dalCSATL.Load(lblSCDOId.Text, dbCon);

                        dalCSATL.csat_id = ObjectId;

                        if (txtPostsApprovedSCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_approved = 0;
                        else
                            dalCSATL.csatl_posts_approved = Convert.ToInt32(txtPostsApprovedSCDO.Text.Trim());
                        if (txtPostsFilledSCDO.Text.Trim().Length == 0)
                            dalCSATL.csatl_posts_filled = 0;
                        else
                            dalCSATL.csatl_posts_filled = Convert.ToInt32(txtPostsFilledSCDO.Text.Trim());

                        dalCSATL.ss_id = utilConstants.cSSSCDO;
                        dalCSATL.yn_id_conducted = utilControls.RadioButtonGetSelection(rbtnAppraisalStatusSCDOYes, rbtnAppraisalStatusSCDONo);
                        dalCSATL.Save(dbCon);
                        #endregion SCDO

                        dbCon.TransactionCommit();

                        utilLT = new utilLanguageTranslation();
                        utilLT.Language = FormParent.FormMaster.LanguageId;
                        strMessage = utilLT.GetMessageTranslation(utilConstants.cMIDSaved, dbCon.dbCon);
                        intPopUpType = utilConstants.cPTInfo;
                    }
                    catch (Exception exc)
                    {
                        dbCon.TransactionRollback();
                        throw exc;
                    }
                    finally
                    {
                        dbCon.Dispose();
                    }
                }
                #endregion Save

                FormParent.FormMaster.ShowMessage(intPopUpType, strMessage);
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "Save", exc);
            }
        }

        private void SetProportion(Label lblA, Label lblB, Label lblProportion)
        {
            #region Varaibles
            bool blnValue = false;
            int intTotal = 0;
            #endregion Variables

            #region Get Value
            if (utilFormatting.IsInt(lblA.Text.Trim()) && utilFormatting.IsInt(lblB.Text.Trim()) && Convert.ToInt32(lblA.Text.Trim()) != 0)
            {
                blnValue = true;
                intTotal = Convert.ToInt32(lblB.Text.Trim()) * 100 / Convert.ToInt32(lblA.Text.Trim());
            }
            #endregion Get Value

            #region Set Value
            if (blnValue)
                lblProportion.Text = intTotal.ToString();
            else
                lblProportion.Text = "-";
            #endregion Set Value
        }

        private void SetProportion(TextBox txtA, TextBox txtB, Label lblProportion, Label lblStaffGap)
        {
            #region Varaibles
            bool blnValue = false;
            int intTotal = 0;
            string strStaffGap = "-";
            #endregion Variables

            #region Get Value
            if (utilFormatting.IsInt(txtA.Text.Trim()) && utilFormatting.IsInt(txtB.Text.Trim()))
            {
                if (Convert.ToInt32(txtA.Text.Trim()) != 0)
                {
                    blnValue = true;
                    intTotal = Convert.ToInt32(txtB.Text.Trim()) * 100 / Convert.ToInt32(txtA.Text.Trim());
                }
                strStaffGap = (Convert.ToInt32(txtA.Text.Trim()) - Convert.ToInt32(txtB.Text.Trim())).ToString();
            }
            #endregion Get Value

            #region Set Value
            if (blnValue)
                lblProportion.Text = intTotal.ToString();
            else
                lblProportion.Text = "-";
            lblStaffGap.Text = strStaffGap;
            #endregion Set Value
        }

        private void SetTotal(TextBox txtACDO, TextBox txtCDO, TextBox txtDCDO, TextBox txtSPSWO, TextBox txtSCDO, Label lblTotal)
        {
            #region Varaibles
            bool blnValue = false;
            int intTotal = 0;
            #endregion Variables

            #region Get Value
            if (utilFormatting.IsInt(txtACDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(txtACDO.Text.Trim());
            }
            if (utilFormatting.IsInt(txtCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(txtCDO.Text.Trim());
            }
            if (utilFormatting.IsInt(txtDCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(txtDCDO.Text.Trim());
            }
            if (utilFormatting.IsInt(txtSPSWO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(txtSPSWO.Text.Trim());
            }
            if (utilFormatting.IsInt(txtSCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(txtSCDO.Text.Trim());
            }
            #endregion Get Value

            #region Set Value
            if (blnValue)
                lblTotal.Text = intTotal.ToString();
            else
                lblTotal.Text = "-";
            #endregion Set Value
        }

        private void SetTotal(Label lblACDO, Label lblCDO, Label lblDCDO, Label lblSPSWO, Label lblSCDO, Label lblTotal)
        {
            #region Varaibles
            bool blnValue = false;
            int intTotal = 0;
            #endregion Variables

            #region Get Value
            if (utilFormatting.IsInt(lblACDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(lblACDO.Text.Trim());
            }
            if (utilFormatting.IsInt(lblCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(lblCDO.Text.Trim());
            }
            if (utilFormatting.IsInt(lblDCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(lblDCDO.Text.Trim());
            }
            if (utilFormatting.IsInt(lblSPSWO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(lblSPSWO.Text.Trim());
            }
            if (utilFormatting.IsInt(lblSCDO.Text.Trim()))
            {
                blnValue = true;
                intTotal += Convert.ToInt32(lblSCDO.Text.Trim());
            }
            #endregion Get Value

            #region Set Value
            if (blnValue)
                lblTotal.Text = intTotal.ToString();
            else
                lblTotal.Text = "-";
            #endregion Set Value
        }

        private string ValidateInput()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            utilLanguageTranslation utilLT = null;

            string[] arrMessage = null;
            string strMessage = string.Empty;
            #endregion Variables

            #region Required Fields
            if (cbDistrict.SelectedIndex == 0 || cbFinancialYear.SelectedIndex == 0 || cbPartner.SelectedIndex == 0)
                strMessage = strMessage + "," + utilConstants.cMIDRequiredFields;
            #endregion Required Fields

            #region Get Messages
            if (strMessage.Length != 0)
            {
                dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
                try
                {
                    strMessage = strMessage.Substring(1);
                    utilLT = new utilLanguageTranslation();
                    utilLT.Language = FormParent.FormMaster.LanguageId;
                    arrMessage = utilLT.GetMessagesTranslation(strMessage.Split(','), dbCon.dbCon);
                    if (arrMessage.Length != 0)
                    {
                        strMessage = arrMessage[0];
                        for (int intCount = 1; intCount < arrMessage.Length; intCount++)
                            strMessage = strMessage + "\n" + arrMessage[intCount];
                    }
                }
                finally
                {
                    dbCon.Dispose();
                }
            }
            #endregion Get Messages

            return strMessage;
        }
        #endregion Private Methods

        #region Permissions
        private void SetPermissions()
        {
            #region Variables
            DataAccessLayer.DBConnection dbCon = null;
            umUser dalUsr = new umUser();
            #endregion Variables

            #region Set Permissions
            dbCon = new DataAccessLayer.DBConnection(utilConstants.cACKConnection);
            try
            {
                pblnManage = dalUsr.HasPermission(FormParent.FormMaster.UserId, utilConstants.cPMManageCBSDStaffandAppraisalTracking, dbCon);
                btnSave.Visible = pblnManage;
            }
            catch (Exception exc)
            {
                FormParent.FormMaster.ShowMessage(utilConstants.cPTError, this.Name, "SetPermissions", exc);
            }
            finally
            {
                dbCon.Dispose();
            }
            #endregion Set Permissions
        }
        #endregion Permissions
    }
}
