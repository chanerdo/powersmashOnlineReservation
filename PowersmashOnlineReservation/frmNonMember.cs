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
        private string start_time;
        private int court;

        public frmNonMember(frmMain m, frmCourtTime frm, Form f, string stime, int c)
        {
            frmcourt = frm;
            frmmain = m;
            parent = f;
            start_time = stime;
            court = c;
            InitializeComponent();
        }

        private void frmNonMember_Shown(object sender, EventArgs e)
        {
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                string query = "INSERT INTO powersmash.reservation (court_id, date, start_time, end_time, status)" +
                             "VALUES ('" + court + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Parse(start_time).ToString("HH:mm:ss") + "','" + DateTime.Parse(cbxEndTime.Text).ToString("HH:mm:ss") + "','2')";
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
    }
}
