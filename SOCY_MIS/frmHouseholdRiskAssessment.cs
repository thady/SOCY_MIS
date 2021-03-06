﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frmHouseholdRiskAssessment : UserControl
    {
        #region Variables
        private bool pblnManage = false;
        private string strHHId = string.Empty;
        private string strId = string.Empty;
        private frmHouseholdRiskAssessmentMain frmCll = null;
        private frmHouseholdRiskAssessmentChild rasChild = new frmHouseholdRiskAssessmentChild();
        private Master frmMST = null;
        int Age = 0;
        DataTable dt = null;
        string errorMessage = string.Empty;
        #endregion Variables

        #region Property
        public frmHouseholdRiskAssessmentMain FormCalling
        {
            get { return frmCll; }
            set { frmCll = value; }
        }

        public frmHouseholdRiskAssessmentChild FormRiskAssessmentChild
        {
            get { return rasChild; }
            set { rasChild = value; }
        }

        public Master FormMaster
        {
            get { return frmMST; }
            set { frmMST = value; }
        }

        public string HouseholdId
        {
            get { return strHHId; }
            set { strHHId = value; }
        }

        public string ObjectId
        {
            get { return strId; }
            set { strId = value; }
        }
        #endregion Property

        public frmHouseholdRiskAssessment()
        {
            InitializeComponent();
        }

        private void frmHouseholdRiskAssessment_Load(object sender, EventArgs e)
        {
            Return_lookups();
            LoadHHDisplay();
            LoadDisplay(ObjectId);
        }

        protected void LoadHHDisplay()
        {
            if (HouseholdId != string.Empty)
            {
                dt = hhHouseholdRiskAssessment.ReturnHHDetails(HouseholdId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboHHCode.SelectedValue = HouseholdId;
                    txtVillage.Text = dtRow["hh_village"].ToString();
                }
            }
            else if (SystemConstants.isRiskAssessmentPopup == true)
            {
                dt = hhHouseholdRiskAssessment.ReturnHHDetails(SystemConstants.HouseholdId);
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];

                    cboDistrict.SelectedValue = dtRow["dst_id"].ToString();
                    cboSubCounty.SelectedValue = dtRow["sct_id"].ToString();
                    cboParish.SelectedValue = dtRow["wrd_id"].ToString();
                    cboHHCode.SelectedValue = SystemConstants.HouseholdId;
                    txtVillage.Text = dtRow["hh_village"].ToString();
                }

                lblBack.Visible = false;
            }
        }

        protected void Return_lookups()
        {
            #region districts
            dt = silcCommunityTrainingRegister.Return_lookups("district", string.Empty, string.Empty, string.Empty, string.Empty); //reused

            DataRow dstemptyRow = dt.NewRow();
            dstemptyRow["dst_id"] = "-1";
            dstemptyRow["dst_name"] = "Select district";
            dt.Rows.InsertAt(dstemptyRow, 0);

            cboDistrict.DisplayMember = "dst_name";
            cboDistrict.ValueMember = "dst_id";
            cboDistrict.DataSource = dt;
            #endregion districts


            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion subcounty

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";

            #region hhm
            if (!SystemConstants.isRiskAssessmentPopup == true)
            {
                dt = GBV_screeningTool.ReturnLists("hhm", HouseholdId);
                DataRow hhm_emptyRow = dt.NewRow();
                hhm_emptyRow["hhm_id"] = "-1";
                hhm_emptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(hhm_emptyRow, 0);

                cboHHMemberName.DataSource = dt;
                cboHHMemberName.DisplayMember = "hhm_name";
                cboHHMemberName.ValueMember = "hhm_id";
            }
            else
            {
                dt = GBV_screeningTool.ReturnLists("hhm", SystemConstants.HouseholdId);
                DataRow hhm_emptyRow = dt.NewRow();
                hhm_emptyRow["hhm_id"] = "-1";
                hhm_emptyRow["hhm_name"] = "Select one";
                dt.Rows.InsertAt(hhm_emptyRow, 0);

                cboHHMemberName.DataSource = dt;
                cboHHMemberName.DisplayMember = "hhm_name";
                cboHHMemberName.ValueMember = "hhm_id";
            }
            
            #endregion hhm_name

        }

        protected void returnHHCodesByLocation()
        {
            #region HH Codes
            dt = silcCommunityTrainingRegister.Return_lookups("HouseHoldCode", string.Empty, cboDistrict.SelectedValue.ToString(), cboSubCounty.SelectedValue.ToString(), cboParish.SelectedValue.ToString());  //reused

            DataRow hhCode_emptyRow = dt.NewRow();
            hhCode_emptyRow["hh_id"] = "-1";
            hhCode_emptyRow["hh_code"] = "select household code";
            dt.Rows.InsertAt(hhCode_emptyRow, 0);

            cboHHCode.DataSource = dt;

            cboHHCode.DisplayMember = "hh_code";
            cboHHCode.ValueMember = "hh_id";
            #endregion HH Codes
        }


        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Back();
        }

        protected void Back()
        {
            FormCalling.Back();
        }

        private void cboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region subcounty
            dt = silcCommunityTrainingRegister.Return_lookups("subcounty", cboDistrict.SelectedValue.ToString(), string.Empty, string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["sct_id"] = "-1";
            sctemptyRow["sct_name"] = "Select Sub County";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboSubCounty.DataSource = dt;
            cboSubCounty.DisplayMember = "sct_name";
            cboSubCounty.ValueMember = "sct_id";
            #endregion subcounty
        }

        private void cboParish_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnHHCodesByLocation();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (rbtnNoMeansNoYes.Checked == false)
            {
                if (cboHHMemberName.SelectedValue.ToString() == "-1" || !dtscreenDate.Checked)
                {
                    MessageBox.Show("Please fill in all missing values,save failed", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    save();
                }
            }
            else
            {
                save();
            }
           
        }


        #region save
        protected void save()
        {
            #region set variables
            if(rbtnNoMeansNoYes.Checked == false)
            {
                hhHouseholdRiskAssessment.hh_id = HouseholdId;
                hhHouseholdRiskAssessment.scr_date = dtscreenDate.Value;
                hhHouseholdRiskAssessment.hhm_id = cboHHMemberName.SelectedValue.ToString();
                hhHouseholdRiskAssessment.usr_id_create = SystemConstants.user_id;
                hhHouseholdRiskAssessment.usr_id_update = SystemConstants.user_id;
                hhHouseholdRiskAssessment.usr_date_create = DateTime.Today;
                hhHouseholdRiskAssessment.usr_date_update = DateTime.Today;
                hhHouseholdRiskAssessment.ofc_id = SystemConstants.ofc_id;
                hhHouseholdRiskAssessment.district_id = SystemConstants.Return_office_district();
            }
            else
            {
                hhHouseholdRiskAssessment.hh_id = "NMN";
                hhHouseholdRiskAssessment.scr_date = dtscreenDate.Value;
                hhHouseholdRiskAssessment.hhm_id = "NMN";
                hhHouseholdRiskAssessment.usr_id_create = SystemConstants.user_id;
                hhHouseholdRiskAssessment.usr_id_update = SystemConstants.user_id;
                hhHouseholdRiskAssessment.usr_date_create = DateTime.Today;
                hhHouseholdRiskAssessment.usr_date_update = DateTime.Today;
                hhHouseholdRiskAssessment.ofc_id = SystemConstants.ofc_id;
                hhHouseholdRiskAssessment.district_id = SystemConstants.Return_office_district();
            }
           
            #endregion set variables

            if (ObjectId == string.Empty)
            {
                hhHouseholdRiskAssessment.ra_id = Guid.NewGuid().ToString();
                ObjectId = hhHouseholdRiskAssessment.ra_id;
                hhHouseholdRiskAssessment.save_hh_household_risk_assessment("insert");
                MessageBox.Show("save successful", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormCalling.MembersTab(ObjectId);
                rasChild.EnableDisableNMNLists(rbtnNoMeansNoYes.Checked?true:false);
               
            }
            else
            {
                hhHouseholdRiskAssessment.save_hh_household_risk_assessment("update");
                MessageBox.Show("update successful", "SOCY MIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormCalling.MembersTab(ObjectId);
                rasChild.EnableDisableNMNLists(rbtnNoMeansNoYes.Checked ? true : false);
            }

            
        }
        #endregion save

        protected void LoadDisplay(string objectID)
        {
            if (ObjectId != string.Empty)
            {
                dt = hhHouseholdRiskAssessment.LoadRATDetails(objectID,"main");
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];
                    dtscreenDate.Value = Convert.ToDateTime(dtRow["scr_date"].ToString());
                    cboHHMemberName.SelectedValue = dtRow["hhm_id"].ToString();
                    FormCalling.MembersTab(objectID);
                }
            }
        }

        private void rbtnNoMeansNoYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNoMeansNoYes.Checked == true)
            {
                cboSubCounty.Enabled = true;
                cboParish.Enabled = true;
                txtVillage.Enabled = true;
                txtVillage.Clear();
                cboHHCode.SelectedValue = "-1";
                cboHHCode.Enabled = false;
                cboHHMemberName.SelectedValue = "-1";
                cboHHMemberName.Enabled = false;
            }
            else
            {
                cboSubCounty.Enabled = false;
                cboParish.Enabled = false;
                txtVillage.Enabled = false;
                cboHHCode.SelectedValue = "-1";
                cboHHCode.Enabled = true;
                cboHHMemberName.SelectedValue = "-1";
                cboHHMemberName.Enabled = true;
            }
        }

        private void rbtnNoMeansNoNo_CheckedChanged(object sender, EventArgs e)
        {
            rbtnNoMeansNoYes_CheckedChanged(rbtnNoMeansNoYes,null);
        }

        private void cboSubCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Load Parishes
            dt = benYouthTrainingInventory.Return_lookups("parish", cboSubCounty.SelectedValue.ToString(), string.Empty, string.Empty);

            DataRow sctemptyRow = dt.NewRow();
            sctemptyRow["wrd_id"] = "-1";
            sctemptyRow["wrd_name"] = "Select Parish";
            dt.Rows.InsertAt(sctemptyRow, 0);

            cboParish.DataSource = dt;
            cboParish.DisplayMember = "wrd_name";
            cboParish.ValueMember = "wrd_id";
            #endregion Load Parishes
        }
    }
}
