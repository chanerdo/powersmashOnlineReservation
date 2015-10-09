using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PowersmashOnlineReservation
{
    public partial class frmNonMember : Form
    {

        private MySqlConnection connDB = new MySqlConnection("datasource=unicsoftworks.com;port=3306;username=admin;password=powersmash123;");
        private frmMain frmmain;
        private frmCourtTime frmcourt;
        private Form parent;
        private string start_time, end_time;
        private int court, price, id;

        public frmNonMember(frmMain m, frmCourtTime frm, Form f, string stime, int c)
        {
            frmcourt = frm;
            frmmain = m;
            parent = f;
            start_time = stime;
            end_time = stime;
            court = c;
            InitializeComponent();
        }

        private void frmNonMember_Shown(object sender, EventArgs e)
        {
            while (!end_time.Equals("11:00 PM"))
            {
                DateTime answer = DateTime.Parse(end_time).Add(DateTime.Parse("1:00:00").TimeOfDay);
                end_time = answer.ToString("hh:mm tt");
                cbxEndTime.Items.Add(end_time);
            }
            lblStartTime.Text = start_time + " - ";
            lblCourt.Text = court.ToString();
            cbxEndTime.SelectedIndex = 0;
        }

        private void frmNonMember_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain.Activate();
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            saveReference();
            getLastReference();
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                string query = "INSERT INTO powersmash.reservation (user_id, court_id, date, reference_id, start_time, end_time, status, walkin_name, created_at)" +
                               "VALUES ('1', '" + court + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "', (SELECT id FROM powersmash.reference WHERE id = '" + id.ToString() + 
                               "'), '" + DateTime.Parse(start_time).ToString("HH:mm:ss") + "','" + DateTime.Parse(cbxEndTime.Text).ToString("HH:mm:ss") + "','2','" + tbxName.Text + 
                               "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand(query, connDB);
                cmdDB.ExecuteNonQuery();
                MessageBox.Show("Walk-in Added");
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                connDB.Close();
                frmmain.Activate();
                frmcourt.Show();
                frmcourt.Activate();
                this.Dispose();
            }
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
    }
}
