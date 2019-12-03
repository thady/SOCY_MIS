using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;
using PSAUtilsWin32;

namespace SOCY_MIS
{
    public partial class frmBeneficiaryschoolAssessment : Form
    {
        string strErrorMessage = string.Empty;
        DataTable dt = new DataTable();
        public frmBeneficiaryschoolAssessment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void save()
        {
            if (ValidateInput())
            {
                #region setVariables

                benAdolescentSchoolAssessment.hhm_id = cboChild.SelectedValue.ToString();
                benAdolescentSchoolAssessment.yn_hhm_in_school = utilControls.RadioButtonGetSelection(rbtnschoolYes, rbtnschoolNo);
                benAdolescentSchoolAssessment.yn_current_school = txtcurrentschoolname.Text;
                benAdolescentSchoolAssessment.current_class = cboCurrentClass.Text;
                benAdolescentSchoolAssessment.total_days_missed_school_last_term = cboDaysMissed.Text;
                benAdolescentSchoolAssessment.reason_for_missing_sch = cboMissingSchoolReason.Text;
                benAdolescentSchoolAssessment.prev_school_attended = txtPrevSchool.Text;
                benAdolescentSchoolAssessment.class_at_dropout = cboPrevClassAttended.Text;
                benAdolescentSchoolAssessment.dropout_reason = cboReasonforDropOut.Text;
                benAdolescentSchoolAssessment.yn_school_or_vocational = cboSchoolOption.Text;
                benAdolescentSchoolAssessment.school_term_start = cboSchoolTerm.Text;
                benAdolescentSchoolAssessment.usr_id_create = SystemConstants.user_id;
                benAdolescentSchoolAssessment.usr_id_update = SystemConstants.user_id;
                benAdolescentSchoolAssessment.usr_date_create = DateTime.Now;
                benAdolescentSchoolAssessment.usr_date_update = DateTime.Now;
                benAdolescentSchoolAssessment.ofc_id = SystemConstants.ofc_id;
                benAdolescentSchoolAssessment.district_id = SystemConstants.Return_office_district();
                #endregion

                if (lblid.Text == "--")
                {
                    benAdolescentSchoolAssessment.record_id = Guid.NewGuid().ToString();
                    benAdolescentSchoolAssessment.save();
                    MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    benAdolescentSchoolAssessment.record_id = lblid.Text;
                    benAdolescentSchoolAssessment.update();
                    MessageBox.Show("Success", "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
            else
            {
                MessageBox.Show(strErrorMessage, "SOCYMIS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        protected bool ValidateInput()
        {
            bool isValid = false;
            if (cboChild.SelectedValue.ToString() == "-1")
            {
                strErrorMessage = "No beneficiary selected";
                isValid = false;
            }
            else if (rbtnschoolYes.Checked & (txtcurrentschoolname.Text == string.Empty || cboCurrentClass.Text == string.Empty || cboDaysMissed.Text == string.Empty || cboMissingSchoolReason.Text == string.Empty))
            {
                strErrorMessage = "Beneficairy is in school,all in school responses required";
                isValid = false;
            }
            else if (rbtnschoolNo.Checked & (txtPrevSchool.Text == string.Empty || cboPrevClassAttended.Text == string.Empty || cboReasonforDropOut.Text == string.Empty || cboSchoolOption.Text == string.Empty || (cboSchoolOption.Text == "School" & cboSchoolTerm.Text == string.Empty)))
            {
                strErrorMessage = "Beneficairy is out of school,all out of school responses required";
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        protected void Clear()
        {
            cboChild.SelectedValue = "-1";
            rbtnschoolYes.Checked = false;
            rbtnschoolNo.Checked = false;
            txtcurrentschoolname.Clear();
            cboCurrentClass.SelectedValue = "-1";
            cboDaysMissed.Text = "";
            cboMissingSchoolReason.Text = "";
            txtPrevSchool.Clear();
            cboReasonforDropOut.Text = "";
            cboSchoolOption.Text = "";
            cboSchoolTerm.Text = "";
            cboPrevClassAttended.SelectedValue = "-1";
            lblid.Text = "--";
        }

        protected void LoadDetails(string id)
        {
            dt = benAdolescentSchoolAssessment.LoadDetails(id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                cboChild.SelectedValue = dtRow["hhm_id"].ToString();
                utilControls.RadioButtonSetSelection(rbtnschoolYes, rbtnschoolNo, dtRow["yn_hhm_in_school"].ToString());

                txtcurrentschoolname.Text = dtRow["yn_current_school"].ToString();
                cboDaysMissed.Text = dtRow["total_days_missed_school_last_term"].ToString();
                cboMissingSchoolReason.Text = dtRow["reason_for_missing_sch"].ToString();
                txtPrevSchool.Text = dtRow["prev_school_attended"].ToString();
                cboReasonforDropOut.Text = dtRow["dropout_reason"].ToString();
                cboSchoolOption.Text = dtRow["yn_school_or_vocational"].ToString();
                cboSchoolTerm.Text = dtRow["school_term_start"].ToString();
                cboPrevClassAttended.Text = dtRow["class_at_dropout"].ToString();
                cboCurrentClass.Text = dtRow["current_class"].ToString();
                lblid.Text = dtRow["record_id"].ToString();
            }
        }

        private void rbtnschoolYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnschoolYes.Checked)
            {
                tlpDisplayInschool.Enabled = true;
                tlpDisplayOutOfschool.Enabled = false;
                txtPrevSchool.Clear();
                cboReasonforDropOut.Text = "";
                cboSchoolOption.Text = "";
                cboSchoolTerm.Text = "";
                cboPrevClassAttended.SelectedValue = "-1";
            }
            else
            {
                tlpDisplayInschool.Enabled = false;
                tlpDisplayOutOfschool.Enabled = true;
                txtcurrentschoolname.Clear();
                cboDaysMissed.Text = "";
                cboMissingSchoolReason.Text = "";
                cboCurrentClass.SelectedValue = "-1";
            }
        }

        private void rbtnschoolNo_CheckedChanged(object sender, EventArgs e)
        {
            rbtnschoolYes_CheckedChanged(rbtnschoolYes, null);
        }

        protected void LoadMembers(string hh_id)
        {
            dt = benAdolescentSchoolAssessment.LoadMembers(hh_id);
            DataRow dtRow = dt.NewRow();
            dtRow["hhm_name"] = "select one";
            dtRow["hhm_id"] = "-1";
            dt.Rows.InsertAt(dtRow, 0);

            cboChild.DataSource = dt;
            cboChild.DisplayMember = "hhm_name";
            cboChild.ValueMember = "hhm_id";
        }

        protected void LoadEducationLevel()
        {
            dt = benAdolescentSchoolAssessment.LoadEducationLevel();
            DataRow dtRow = dt.NewRow();
            dtRow["edu_name"] = "select one";
            dtRow["edu_id"] = "-1";
            dt.Rows.InsertAt(dtRow, 0);

            cboCurrentClass.DataSource = dt;
            cboCurrentClass.DisplayMember = "edu_name";
            cboCurrentClass.ValueMember = "edu_id";

            dt = benAdolescentSchoolAssessment.LoadEducationLevel();
            DataRow dt_Row = dt.NewRow();
            dtRow["edu_name"] = "select one";
            dtRow["edu_id"] = "-1";
            dt.Rows.InsertAt(dt_Row, 0);

            cboPrevClassAttended.DataSource = dt;
            cboPrevClassAttended.DisplayMember = "edu_name";
            cboPrevClassAttended.ValueMember = "edu_id";
        }

        protected void LoadAssessmentDetailsByselectedChild(string hhm_id)
        {
            dt = benAdolescentSchoolAssessment.AssessmentDetails(hhm_id);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];
                LoadDetails(dtRow["record_id"].ToString());
            }
            else
            {
                rbtnschoolYes.Checked = false;
                rbtnschoolNo.Checked = false;
                txtcurrentschoolname.Clear();
                cboDaysMissed.Text = "";
                cboMissingSchoolReason.Text = "";
                txtPrevSchool.Clear();
                cboReasonforDropOut.Text = "";
                cboSchoolOption.Text = "";
                cboSchoolTerm.Text = "";
                cboPrevClassAttended.SelectedValue = "-1";
            }
        }
        private void frmBeneficiaryschoolAssessment_Load(object sender, EventArgs e)
        {
            LoadEducationLevel();
            LoadMembers(benAdolescentSchoolAssessment.hh_id);
        }

        private void cboChild_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssessmentDetailsByselectedChild(cboChild.SelectedValue.ToString());
        }

        private void cboSchoolOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSchoolOption.Text == "School")
            {
                cboSchoolTerm.Enabled = true;
            }
            else
            {
                cboSchoolTerm.Enabled = false;
                cboSchoolTerm.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this form?All unsaved changes will be lost", "SOCYMIS", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Visible = true;
            }
        }
    }
}
