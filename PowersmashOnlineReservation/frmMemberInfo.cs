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
        private int reserve_id;

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
                    int rowcount = 0;
                    byte[] image = null;
                    foreach (DataRow user_row in user_data.Rows)
                    {
                        if (user_row.Field<int>(0) == 1) { rowcount++; }
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
                                if (reserve_row.Field<int>(1) == id)
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
                                image = (byte[])(user_data.Rows[rowcount][42]);
                                if (reserve_row.Field<int>(1) == id)
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
                            rowcount++;
                        }
                    }
                    lblCourt.Text = reserve_row.Field<int>(2).ToString();
                    lblDate.Text = reserve_row.Field<DateTime>(4).ToString("yyyy-MM-dd");
                    lblTime.Text = reserve_row.Field<TimeSpan>(5).ToString() + " - " + reserve_row.Field<TimeSpan>(6).ToString();
                }
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
