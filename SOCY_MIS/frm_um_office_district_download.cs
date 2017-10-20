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
    public partial class frm_um_office_district_download : Form
    {
        public frm_um_office_district_download()
        {
            InitializeComponent();
        }

        private void frm_um_office_district_download_Load(object sender, EventArgs e)
        {
            //return district list
            return_district_list();
            return_districts_for_gdv_display();

        }

        protected void return_district_list()
        {
            DataTable dt = SystemConstants.Return_list_of_districts_data_download();
            if (dt.Rows.Count > 0)
            {
                DataRow dtRow = dt.NewRow();
                dtRow["dst_id"] = -999;
                dtRow["dst_name"] = "select district";

                dt.Rows.InsertAt(dtRow, 0);
                cbo_district.DataSource = dt;
                cbo_district.ValueMember = "dst_id";
                cbo_district.DisplayMember = "dst_name";
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_district_download();
        }

        protected void save_district_download()
        {
            if (cbo_district.SelectedValue.ToString() == "-999")
            {
                MessageBox.Show("Select a district", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SystemConstants.Save_update_district_for_data_download(Convert.ToInt32(cbo_district.SelectedValue.ToString()), chk_active.Checked == true ? true : false);
                MessageBox.Show("Success", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //return districts
                return_districts_for_gdv_display();
            }
        }

        protected void return_districts_for_gdv_display()
        {
            DataTable dt = SystemConstants.Return_list_of_districts_data_download_display();
            if (dt != null)
            {
                gdv_districts.DataSource = dt;

                gdv_districts.Columns["dst_name"].HeaderText = "District Name";
                gdv_districts.Columns["download_active"].HeaderText = "Active Download";

                gdv_districts.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_districts.DefaultCellStyle.SelectionForeColor = Color.Black;

                gdv_districts.RowsDefaultCellStyle.BackColor = Color.LightGray;
                gdv_districts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

                // Set the row and column header styles.
                gdv_districts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gdv_districts.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                gdv_districts.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                // Set the selection background color for all the cells.
                gdv_districts.DefaultCellStyle.SelectionBackColor = Color.White;
                gdv_districts.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void gdv_districts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdv_districts.Rows.Count != 0)
            {
                cbo_district.Text = gdv_districts.CurrentRow.Cells[0].Value.ToString();
                chk_active.Checked = Convert.ToBoolean(gdv_districts.CurrentRow.Cells[1].Value);
            }
        }
    }
}