using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace PowersmashOnlineReservation
{
    public partial class frmMember : Form
    {

        private MySqlConnection connDB = new MySqlConnection("datasource=unicsoftworks.com;port=3306;username=admin;password=powersmash123;Convert Zero Datetime=true;");
        private DataTable user_data;
        private frmMain frmmain;
        private frmCourtTime frmcourt;
        private Form parent;
        private int court;
        private string start_time, end_time;

        public frmMember(frmMain fm, frmCourtTime frm, Form f, string stime, int c)
        {
            frmcourt = frm;
            frmmain = fm;
            parent = f;
            start_time = stime;
            end_time = stime;
            court = c;
            InitializeComponent();
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain.Activate();
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
        }

        private void frmMember_Shown(object sender, EventArgs e)
        {
            getUserData();
            for (int i = 0; i < dgvMember.ColumnCount; i++) { dgvMember.Columns[i].Visible = false; }
            dgvMember.Rows[0].Visible = false;
            dgvMember.Columns[21].Visible = true;
            dgvMember.Columns[22].Visible = true;
            dgvMember.Columns[25].Visible = true;
            dgvMember.Columns[41].Visible = true;
            lblCourt.Text = court.ToString();
            lblStartTime.Text = start_time;
            while (!end_time.Equals("11:00 PM"))
            {
                DateTime answer = DateTime.Parse(end_time).Add(DateTime.Parse("1:00:00").TimeOfDay);
                end_time = answer.ToString("hh:mm tt");
                cbxEndTime.Items.Add(end_time);
            }
            cbxEndTime.SelectedIndex = 0;
        }

        private void getUserData()
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand("SELECT * FROM powersmash.user", connDB);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdDB);
                user_data = new DataTable();
                sqlDataAdapter.Fill(user_data);
                dgvMember.DataSource = user_data;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connDB.Close();
            }
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvMember.Rows[e.RowIndex];
                lblName.Text = row.Cells[21].Value.ToString() + " " + row.Cells[22].Value.ToString();
                lblGender.Text = row.Cells[25].Value.ToString();
                lblContact.Text = row.Cells[41].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmmain.Activate();
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
        }
    }
}
