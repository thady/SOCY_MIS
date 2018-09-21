using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOCY_MIS.DataAccessLayer;

namespace SOCY_MIS
{
    public partial class frm_linkages_register : Form
    {
        DataTable dt = null;
      
        public frm_linkages_register()
        {
            InitializeComponent();
        }

        private void frm_linkages_register_Load(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Maximized;

            Return_lookups();
            display_hh_details();
            Return_household_members();
        }

        //retutn household details
        protected void display_hh_details()
        {
            DataTable dt = hhHousehold_linkages_register.Return_household_details(SystemConstants.hh_record_guid);
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.Rows[0];

                cbo_ip.Text = dtRow["prt_name"].ToString();
                cbo_district.Text = dtRow["dst_name"].ToString();
                cbo_subcouty.Text = dtRow["sct_name"].ToString();
                cbo_parish.Text = dtRow["wrd_name"].ToString();
                cbo_village.Text = dtRow["hh_village"].ToString();
            }
        }

        protected void Return_lookups()
        {
            //districts
            dt = hhHousehold_linkages_register.Return_lookups("district");
            cbo_district.DisplayMember = "dst_name";
            cbo_district.ValueMember = "dst_id";
            cbo_district.DataSource = dt;

            //IP
            dt = hhHousehold_linkages_register.Return_lookups("IP");
            cbo_ip.DataSource = dt;
            cbo_ip.DisplayMember = "prt_name";
            cbo_ip.ValueMember = "prt_id";

            //subcounty
            dt = hhHousehold_linkages_register.Return_lookups("subcounty");
            cbo_subcouty.DataSource = dt;
            cbo_subcouty.DisplayMember = "sct_name";
            cbo_subcouty.ValueMember = "sct_id";

            //Ward
            dt = hhHousehold_linkages_register.Return_lookups("parish");
            cbo_parish.DataSource = dt;
            cbo_parish.DisplayMember = "wrd_name";
            cbo_parish.ValueMember = "wrd_id";

            //services provided
            dt = hhHousehold_linkages_register.Return_lookups("services_provided");

            chk_list_services_received.DataSource = dt;
            chk_list_services_received.DisplayMember = "service_name";
            chk_list_services_received.ValueMember = "linkages_service_id";

            //services required
            dt = hhHousehold_linkages_register.Return_lookups("services_required");

            chk_list_services_required.DataSource = dt;
            chk_list_services_required.DisplayMember = "service_name";
            chk_list_services_required.ValueMember = "linkages_service_offered_id";

            //service providers
            dt = hhHousehold_linkages_register.Return_lookups("CSO");
            cbo_service_provider.DataSource = dt;
            cbo_service_provider.DisplayMember = "cso_other";
            cbo_service_provider.ValueMember = "cso_id";
        }

        //household members
        protected void Return_household_members()
        {
            dt = hhHousehold_linkages_register.Return_household_member_details(SystemConstants.hh_record_guid);
            if (dt.Rows.Count > 0)
            {
                gdv_household_members.DataSource = dt;

                gdv_household_members.Columns["hhm_number"].HeaderText = "Household Member N";
                gdv_household_members.Columns["hhm_first_name"].HeaderText = "First Name";
                gdv_household_members.Columns["hhm_last_name"].HeaderText = "Last Name";
                gdv_household_members.Columns["gnd_name"].HeaderText = "Gender";
                gdv_household_members.Columns["hhm_year_of_birth"].HeaderText = "Year of Birth";

                gdv_household_members.Columns["hhm_code"].Visible = false;
                gdv_household_members.Columns["hhm_id"].Visible = false;
                gdv_household_members.Columns["Name"].Visible = false;

                gdv_household_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_household_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_household_members.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_household_members.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_household_members.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_household_members.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_household_members.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_household_members.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_household_members.DefaultCellStyle.SelectionForeColor = Color.Black;

                foreach (DataGridViewColumn c in gdv_household_members.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
                }
            }
        }

        private void gdv_household_members_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //clear controls first
            clearControls();

            if (gdv_household_members.Rows.Count > 0)
            {
                
                txt_hh_member_code.Text = gdv_household_members.CurrentRow.Cells[5].Value.ToString();
                txt_hh_member_name.Text = gdv_household_members.CurrentRow.Cells[1].Value.ToString() + " " + gdv_household_members.CurrentRow.Cells[2].Value.ToString();
                cbo_gender.Text = gdv_household_members.CurrentRow.Cells[3].Value.ToString();
                string birth_yr = gdv_household_members.CurrentRow.Cells[4].Value.ToString();

                //set the hhm_id
                hhHousehold_linkages_register.hhm_id = gdv_household_members.CurrentRow.Cells[6].Value.ToString();

                if (birth_yr != string.Empty && birth_yr != "-1")
                {
                    int age = (DateTime.Today.Year) - Convert.ToInt32(birth_yr);
                    txt_age.Text = age.ToString();
                }
                else { txt_age.Text = string.Empty; }

                #region Household member linkages details
                //get details from header table
                dt = hhHousehold_linkages_register.Return_hhm_linkages_tracking_details(hhHousehold_linkages_register.hhm_id, "main_header");
                if (dt.Rows.Count > 0)
                {
                    DataRow dtRow = dt.Rows[0];
                    cbo_service_provider.Text = dtRow["service_provider_id"].ToString();  
                    lbl_guid.Text = dtRow["hhm_linkages_record_guid"].ToString();
                    hhHousehold_linkages_register.hhm_linkages_record_guid = dtRow["hhm_linkages_record_guid"].ToString();

                }
                //get services provided
                dt = hhHousehold_linkages_register.Return_hhm_linkages_tracking_details(hhHousehold_linkages_register.hhm_linkages_record_guid, "services_provided");


                if (dt.Rows.Count > 0)

                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dtRow_service = dt.Rows[i];
                        string service_name = dtRow_service["service_name"].ToString();

                        for (int x = 0; x < chk_list_services_received.Items.Count; x++)
                        {
                            DataRowView drv = null;
                            drv = (DataRowView)chk_list_services_received.Items[x];

                            if (drv["service_name"].ToString() == service_name)
                            {
                                chk_list_services_received.SetItemChecked(x, true);
                            } 
                        }
                    }
                }

                //get services required
                dt = hhHousehold_linkages_register.Return_hhm_linkages_tracking_details(hhHousehold_linkages_register.hhm_linkages_record_guid, "services_required");
                if (dt.Rows.Count > 0)

                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dtRow_service = dt.Rows[i];
                        string service_name = dtRow_service["service_name"].ToString();

                        for (int x = 0; x < chk_list_services_required.Items.Count; x++)
                        {
                            DataRowView drv = null;
                            drv = (DataRowView)chk_list_services_required.Items[x];

                            if (drv["service_name"].ToString() == service_name)
                            {
                                chk_list_services_required.SetItemChecked(x, true);
                            }
                        }
                    }
                }
                #endregion Household member linkages details
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (SystemConstants.ValidateDistrictID())
            {
                save();
            }
            else
            {
                MessageBox.Show("No district set for this office,please set the office district under office information screen", "SOCY MIS Message Centre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        protected void save()
        {
            if (chk_list_services_received.CheckedIndices.Count == 0 || chk_list_services_required.CheckedIndices.Count == 0)
            {

                MessageBox.Show("Atleast one service provided and required must be selected", "Message center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_hh_member_name.Text == string.Empty)
            {
                MessageBox.Show("No household member selected","Message center",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string record_guid = string.Empty;

                if (lbl_guid.Text == "record_id")
                {
                    record_guid = Guid.NewGuid().ToString();

                    hhHousehold_linkages_register.hhm_linkages_record_guid = record_guid;
                    hhHousehold_linkages_register.partner_id = cbo_ip.SelectedValue.ToString();
                    hhHousehold_linkages_register.hhm_district_id = cbo_district.SelectedValue.ToString();
                    hhHousehold_linkages_register.subcounty_id = cbo_subcouty.SelectedValue.ToString();
                    hhHousehold_linkages_register.parish_id = cbo_parish.SelectedValue.ToString();
                    hhHousehold_linkages_register.village = cbo_village.Text;
                    hhHousehold_linkages_register.service_provider_id = cbo_service_provider.SelectedValue.ToString();
                    hhHousehold_linkages_register.usr_id_create = hhHousehold_linkages_register.user_id;
                    hhHousehold_linkages_register.usr_id_update = hhHousehold_linkages_register.user_id;
                    hhHousehold_linkages_register.district_id = SystemConstants.Return_office_district();

                    //save
                    hhHousehold_linkages_register.save_update_hhm_linkages_details("insert");
                    save_hh_linkages_services();
                    MessageBox.Show("Success");
                }
                else
                {

                    record_guid = lbl_guid.Text;

                    hhHousehold_linkages_register.hhm_linkages_record_guid = record_guid;
                    hhHousehold_linkages_register.partner_id = cbo_ip.SelectedValue.ToString();
                    hhHousehold_linkages_register.hhm_district_id = cbo_district.SelectedValue.ToString();
                    hhHousehold_linkages_register.subcounty_id = cbo_subcouty.SelectedValue.ToString();
                    hhHousehold_linkages_register.parish_id = cbo_parish.SelectedValue.ToString();
                    hhHousehold_linkages_register.village = cbo_village.Text;
                    hhHousehold_linkages_register.service_provider_id = cbo_service_provider.SelectedValue.ToString();
                    hhHousehold_linkages_register.usr_id_create = hhHousehold_linkages_register.user_id;
                    hhHousehold_linkages_register.usr_id_update = hhHousehold_linkages_register.user_id;
                    hhHousehold_linkages_register.district_id = SystemConstants.Return_office_district();

                    //update
                    hhHousehold_linkages_register.save_update_hhm_linkages_details("update");
                    save_hh_linkages_services();
                    MessageBox.Show("Success");
                }
            }   
        }

        protected void save_hh_linkages_services()
        {
            #region services provided
            foreach (var item in chk_list_services_received.CheckedItems)
            {
             
                var row = (item as DataRowView).Row;

                string service_name = row.Field<string>("service_name");
                int service_id = row.Field<int>("linkages_service_id");
                //MessageBox.Show(service_name + ": " + service_id);

                //set static varials
                hhHousehold_linkages_register.lsp_id = service_id.ToString();
                hhHousehold_linkages_register.save_hh_linkages_services_provided("provided");
            }
            #endregion services provided

            #region services required
            foreach (var item in chk_list_services_required.CheckedItems)
            {

                var row = (item as DataRowView).Row;

                string service_name = row.Field<string>("service_name");
                int service_id = row.Field<int>("linkages_service_offered_id");
                //MessageBox.Show(service_name + ": " + service_id);

                //set static varials
                hhHousehold_linkages_register.lsr_id = service_id.ToString();
                hhHousehold_linkages_register.save_hh_linkages_services_provided("required");
            }
            #endregion services required
        }

        #region clear controls
        protected void clearControls()
        {
            cbo_service_provider.Text = string.Empty;
            lbl_guid.Text = "record_id";
            hhHousehold_linkages_register.hhm_linkages_record_guid = string.Empty;

            foreach (int i in chk_list_services_received.CheckedIndices)
            {
                chk_list_services_received.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (int i in chk_list_services_required.CheckedIndices)
            {
                chk_list_services_required.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        #endregion clear controls

        private void btnedit_Click(object sender, EventArgs e)
        {
           

        }

    }
}
