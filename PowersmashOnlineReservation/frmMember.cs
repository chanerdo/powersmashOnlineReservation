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
        private int court, price, id, user_id;
        private string start_time, end_time, search;

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
            cbxSearchBy.SelectedIndex = 0;
        }

        private void getUserData(string query)
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand(query, connDB);
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

        private void saveReference()
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand("INSERT INTO powersmash.reference (approve, reference_no, amt) VALUES ('1', 'WALK-IN', '" + price.ToString() + "')", connDB);
                cmdDB.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                connDB.Close();
            }
        }

        private void getLastReference()
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand("SELECT * FROM powersmash.reference", connDB);
                MySqlDataReader reader = cmdDB.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader.GetString("id"));
                }
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
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
                user_id = int.Parse(row.Cells[0].Value.ToString());
                lblName.Text = row.Cells[21].Value.ToString() + " " + row.Cells[22].Value.ToString();
                lblGender.Text = row.Cells[25].Value.ToString();
                lblContact.Text = row.Cells[41].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveReference();
            getLastReference();
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                string query = "INSERT INTO powersmash.reservation (user_id, court_id, date, reference_id, start_time, end_time, status, created_at)" +
                               "VALUES ('" + user_id.ToString() + "', '" + court + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "', (SELECT id FROM powersmash.reference WHERE id = '" + id.ToString() +
                               "'), '" + DateTime.Parse(start_time).ToString("HH:mm:ss") + "','" + DateTime.Parse(cbxEndTime.Text).ToString("HH:mm:ss") + "','2','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand(query, connDB);
                cmdDB.ExecuteNonQuery();
                MessageBox.Show("Walk-in Added");
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                connDB.Close();
            }

            if (MessageBox.Show("Do you want receipt?", "RECEIPT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                print_dialog.ShowDialog();
            }
            else
            {
                frmmain.Activate();
                frmcourt.Dispose();
                frmmain.refreshData();
                this.Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbxSearchBy.SelectedIndex = 0;
            tbxSearch.Text = "";
            lblName.Text = "";
            lblGender.Text = "";
            lblContact.Text = "";
            cbxEndTime.SelectedIndex = 0;
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbxSearchBy.SelectedIndex == 0) { search = "firstname"; }
            if (cbxSearchBy.SelectedIndex == 1) { search = "lastname"; }
            if (cbxSearchBy.Text.Equals(""))
            {
                MessageBox.Show("Please select item");
            }
            else
            {
                
                string query = "SELECT firstname, lastname, gender, contact FROM powersmash.user WHERE " + search + " LIKE '" + tbxSearch.Text.Trim() + "%'";
                getUserData(query);
            }
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM powersmash.user";
            getUserData(query);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmmain.Activate();
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
        }

        private void cbxEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeSpan answer = DateTime.Parse(cbxEndTime.Text).Subtract(DateTime.Parse(start_time));
            price = 150 * int.Parse(DateTime.Parse(answer.ToString()).ToString("HH"));
            lblPrice.Text = "P " + price.ToString() + ".00";
        }

        private void print_doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Powersmash Badminton Gym", new Font("Times New Roman", 24, FontStyle.Bold), Brushes.Black, 250, 40);
            e.Graphics.DrawString("2270 Chino Roces Avenue, Makati City", new Font("Times New Roman", 12, FontStyle.Italic), Brushes.Black, 320, 70);
            e.Graphics.DrawString("Contact: (02) 892 8024", new Font("Times New Roman", 12), Brushes.Black, 380, 85);
            e.Graphics.DrawString("Website: www.unicsoftworks.com", new Font("Times New Roman", 12), Brushes.Black, 340, 100);
            e.Graphics.DrawString("Cash Reciept", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, 350, 130);
            e.Graphics.DrawString("Reference #:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 150, 200);
            e.Graphics.DrawString("Date:", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 600, 200);
            e.Graphics.DrawString("Cash Recieved From_____________________________________ of Php_____________________________", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 50, 250);
            e.Graphics.DrawString(lblName.Text, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 300, 250);
            e.Graphics.DrawString(price.ToString(), new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 650, 250);
            e.Graphics.DrawString("For Transaction_________________________", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 50, 300);
            e.Graphics.DrawString("Walk-In Payment", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 200, 299);
            e.Graphics.DrawString("________________________________", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 500, 350);
            e.Graphics.DrawString("Signature Over Printed Name", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 525, 370);
        }

        private void print_dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain.Activate();
            frmmain.Enabled = true;
            frmcourt.Dispose();
            frmmain.refreshData();
            this.Dispose();
        }
    }
}
