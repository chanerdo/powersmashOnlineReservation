using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace PowersmashOnlineReservation
{
    public partial class frmMemberInfo : Form
    {

        private MySqlConnection connDB = new MySqlConnection("datasource=unicsoftworks.com;port=3306;username=admin;password=powersmash123;Convert Zero Datetime=true;");
        private frmCourtTime frmcourt;
        private Form parent;
        private DataTable user_data, reserve_data;
        private Timer court_timer = new Timer();
        private int reserve_id, status;
        private string start_time, end_time;

        public frmMemberInfo(frmCourtTime frm, Form f, string rid)
        {
            frmcourt = frm;
            parent = f;
            reserve_id = int.Parse(rid);
            InitializeComponent();
        }

        private void frmMemberInfo_Load(object sender, EventArgs e)
        {

        }

        private void frmMemberInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
        }

        private void frmMemberInfo_Shown(object sender, EventArgs e)
        {
            getReserveData();
            getUserData();
            foreach (DataRow reserve_row in reserve_data.Rows)
            {
                if (reserve_row.Field<int>(0) == reserve_id)
                {
                    byte[] image = null;
                    int rowcount = 0;
                    foreach (DataRow user_row in user_data.Rows)
                    {
                        if (user_row.Field<int>(0) == 1) { }
                        else
                        {
                            int id = user_row.Field<int>(0);
                            string firstname = user_row.Field<string>(21);
                            string lastname = user_row.Field<string>(22);
                            string gender = user_row.Field<string>(25);
                            string dateofbirth = user_row.Field<DateTime>(40).ToString("yyyy-MM-dd");
                            string contactnum = user_row.Field<string>(41);
                            string email = user_row.Field<string>(4);
                            string address = user_row.Field<string>(43);
                            if (user_data.Rows[rowcount][42].ToString().Equals(""))
                            {
                                if (reserve_row.Field<int>(0) == id)
                                {
                                    lblID.Text = id.ToString();
                                    lblName.Text = firstname;
                                    lblGender.Text = gender;
                                    lblBirth.Text = dateofbirth;
                                    lblContact.Text = contactnum;
                                    lblEmail.Text = email;
                                    lblAddress.Text = address;
                                }
                            }
                            else
                            {
                                image = (byte[])(user_row.Field<byte[]>(42));
                                if (reserve_row.Field<int>(0) == id)
                                {
                                    MemoryStream memstream = new MemoryStream(image);
                                    pbxProfile.Image = Image.FromStream(memstream);
                                    lblID.Text = id.ToString();
                                    lblName.Text = firstname;
                                    lblGender.Text = gender;
                                    lblBirth.Text = dateofbirth;
                                    lblContact.Text = contactnum;
                                    lblEmail.Text = email;
                                    lblAddress.Text = address;
                                }
                            }
                        }
                    }
                    lblCourt.Text = reserve_row.Field<int>(2).ToString();
                    lblDate.Text = reserve_row.Field<DateTime>(4).ToString("yyyy-MM-dd");
                    lblTime.Text = reserve_row.Field<TimeSpan>(5).ToString() + " - " + reserve_row.Field<TimeSpan>(6).ToString();
                    start_time = reserve_row.Field<TimeSpan>(5).ToString();
                    end_time = reserve_row.Field<TimeSpan>(6).ToString();
                    status = reserve_row.Field<int>(9);
                    if (status == 1)
                    {
                        btnTimer.Text = "Time-In";
                        int compare_time = DateTime.Compare(DateTime.Parse(start_time.ToString()), DateTime.Parse(DateTime.Now.AddHours(-0).ToString("hh:mm tt")));
                        if (compare_time == 0 || compare_time == -1)
                        {
                            court_timer.Interval = 1000;
                            court_timer.Tick += new EventHandler(this.noshowTimer_Tick);
                            court_timer.Start();
                        }
                        else
                        {
                            court_timer.Stop();
                            lblTimer.Text = "00:00:00";
                        }
                    }
                    if (status == 2)
                    {
                        btnTimer.Text = "Time-Out";
                        court_timer.Interval = 1000;
                        court_timer.Tick += new EventHandler(this.endcourtTimer_Tick);
                        court_timer.Start();
                    }
                    rowcount++;
                }
            }
        }

        private void noshowTimer_Tick(object sender, EventArgs e)
        {
            DateTime answer = DateTime.Parse(start_time).Add(DateTime.Parse("00:30:00").TimeOfDay);
            TimeSpan totalTime = DateTime.Parse(answer.ToString("hh:mm tt")).Subtract(DateTime.Parse(DateTime.Now.AddHours(-0).ToString("hh:mm:ss tt")));
            int compareTime = DateTime.Compare(DateTime.Parse(answer.ToString("hh:mm tt")), DateTime.Parse(DateTime.Now.AddHours(-0).ToString("hh:mm tt")));
            if (compareTime == 1) { lblTimer.Text = totalTime.ToString(); }
            else
            {
                court_timer.Stop();
                lblTimer.Text = "00:00:00";
            }
        }

        private void endcourtTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan totalTime = DateTime.Parse(end_time).Subtract(DateTime.Parse(DateTime.Now.AddHours(-0).ToString("hh:mm:ss tt")));
            lblTimer.Text = totalTime.ToString();
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            if (btnTimer.Text.Equals("Time-In"))
            {
                MessageBox.Show(reserve_id.ToString());
                string query = "UPDATE powersmash.reservation SET status = '2' WHERE id = '" + reserve_id.ToString() + "'";
                updateData(query);
                btnTimer.Text = "Time-Out";
                court_timer.Interval = 1000;
                court_timer.Tick += new EventHandler(this.endcourtTimer_Tick);
                court_timer.Start();
            }
            if (btnTimer.Text.Equals("Time-Out"))
            {
                //set status to 0
                string query = "UPDATE powersmash.reservation SET status = '0' WHERE id = '" + reserve_id.ToString() + "'";
                updateData(query);
            }
        }

        private void updateData(string query)
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand(query, connDB);
                cmdDB.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                connDB.Close();
            }
        }

        public void getReserveData()
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand("SELECT * FROM powersmash.reservation", connDB);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdDB);
                reserve_data = new DataTable();
                sqlDataAdapter.Fill(reserve_data);
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

        public void getUserData()
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand("SELECT * FROM powersmash.user", connDB);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdDB);
                user_data = new DataTable();
                sqlDataAdapter.Fill(user_data);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
        }
    }
}
