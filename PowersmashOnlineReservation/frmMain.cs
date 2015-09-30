using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PowersmashOnlineReservation
{
    public partial class frmMain : Form
    {

        private MySqlConnection connDB = new MySqlConnection("datasource=unicsoftworks.com;port=3306;username=admin;password=powersmash123;Convert Zero Datetime=true;");
        //private MySqlConnection connDB = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;");
        private DataTable reserve_data;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM powersmash.reservation";
            getData(query);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            tlpCourt1.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt1_CellPaint);
            tlpCourt2.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt2_CellPaint);
            tlpCourt3.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt3_CellPaint);
            tlpCourt4.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt4_CellPaint);
            tlpCourt5.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt5_CellPaint);
            tlpCourt6.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt6_CellPaint);
            tlpCourt7.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt7_CellPaint);
            tlpCourt8.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt8_CellPaint);
            tlpCourt9.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt9_CellPaint);
            tlpCourt10.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt10_CellPaint);
        }

        public void getData(string query)
        {
            try
            {
                if (connDB.State == ConnectionState.Open) { connDB.Close(); }
                connDB.Open();
                MySqlCommand cmdDB = new MySqlCommand(query, connDB);
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

        public void clearStatus()
        {
            tlpCourt1.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt1_CellPaint);
            tlpCourt1.Invalidate();
            tlpCourt2.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt2_CellPaint);
            tlpCourt2.Invalidate();
            tlpCourt3.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt3_CellPaint);
            tlpCourt3.Invalidate();
            tlpCourt4.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt4_CellPaint);
            tlpCourt4.Invalidate();
            tlpCourt5.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt5_CellPaint);
            tlpCourt5.Invalidate();
            tlpCourt6.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt6_CellPaint);
            tlpCourt6.Invalidate();
            tlpCourt7.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt7_CellPaint);
            tlpCourt7.Invalidate();
            tlpCourt8.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt8_CellPaint);
            tlpCourt8.Invalidate();
            tlpCourt9.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt9_CellPaint);
            tlpCourt9.Invalidate();
            tlpCourt10.CellPaint -= new TableLayoutCellPaintEventHandler(tlpCourt10_CellPaint);
            tlpCourt10.Invalidate();
        }

        private void setStatus_CellPaint(int court, TableLayoutCellPaintEventArgs e)
        {
            foreach (DataRow row in reserve_data.Rows)
            {
                int id = row.Field<int>(0);
                int court_id = row.Field<int>(2);
                string date = row.Field<DateTime>(4).ToString("yyyy-MM-dd");
                int start_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(5).ToString()).ToString("HH"));
                int end_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(6).ToString()).ToString("HH"));
                int status = row.Field<int>(8);
                if (date.Equals(dtpDate.Text))
                {
                    if (court == court_id)
                    {
                        while (start_time < end_time)
                        {
                            if (start_time == 06)
                            {
                                if (e.Row == 0 && e.Column == 0)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 07)
                            {
                                if (e.Row == 0 && e.Column == 1)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 08)
                            {
                                if (e.Row == 0 && e.Column == 2)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 09)
                            {
                                if (e.Row == 0 && e.Column == 3)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 10)
                            {
                                if (e.Row == 0 && e.Column == 4)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 11)
                            {
                                if (e.Row == 0 && e.Column == 5)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 12)
                            {
                                if (e.Row == 1 && e.Column == 0)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 13)
                            {
                                if (e.Row == 1 && e.Column == 1)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 14)
                            {
                                if (e.Row == 1 && e.Column == 2)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 15)
                            {
                                if (e.Row == 1 && e.Column == 3)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 16)
                            {
                                if (e.Row == 1 && e.Column == 4)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 17)
                            {
                                if (e.Row == 1 && e.Column == 5)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 18)
                            {
                                if (e.Row == 2 && e.Column == 0)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 19)
                            {
                                if (e.Row == 2 && e.Column == 1)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 20)
                            {
                                if (e.Row == 2 && e.Column == 2)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 21)
                            {
                                if (e.Row == 2 && e.Column == 3)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 22)
                            {
                                if (e.Row == 2 && e.Column == 4)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            if (start_time == 23)
                            {
                                if (e.Row == 2 && e.Column == 5)
                                {
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); }
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); }
                                }
                            }
                            start_time++;
                        }
                    }
                }
            }
        }

        private void tlpCourt1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(1, e);
        }

        private void tlpCourt2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(2, e);
        }

        private void tlpCourt3_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(3, e);
        }

        private void tlpCourt4_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(4, e);
        }

        private void tlpCourt5_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(5, e);
        }

        private void tlpCourt6_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(6, e);
        }

        private void tlpCourt7_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(7, e);
        }

        private void tlpCourt8_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(8, e);
        }

        private void tlpCourt9_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(9, e);
        }

        private void tlpCourt10_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus_CellPaint(10, e);
        }

        private void Court1_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 1, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court2_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 2, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court3_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 3, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court4_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 4, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court5_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 5, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court6_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 6, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court7_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 7, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court8_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 8, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court9_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 9, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void Court10_Click(object sender, EventArgs e)
        {
            frmCourtTime court_time = new frmCourtTime(this, this, reserve_data, 10, dtpDate.Text);
            court_time.Show();
            this.Enabled = false;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            clearStatus();
            tlpCourt1.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt1_CellPaint);
            tlpCourt1.Invalidate();
            tlpCourt2.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt2_CellPaint);
            tlpCourt2.Invalidate();
            tlpCourt3.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt3_CellPaint);
            tlpCourt3.Invalidate();
            tlpCourt4.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt4_CellPaint);
            tlpCourt4.Invalidate();
            tlpCourt5.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt5_CellPaint);
            tlpCourt5.Invalidate();
            tlpCourt6.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt6_CellPaint);
            tlpCourt6.Invalidate();
            tlpCourt7.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt7_CellPaint);
            tlpCourt7.Invalidate();
            tlpCourt8.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt8_CellPaint);
            tlpCourt8.Invalidate();
            tlpCourt9.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt9_CellPaint);
            tlpCourt9.Invalidate();
            tlpCourt10.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt10_CellPaint);
            tlpCourt10.Invalidate();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string query = "SELECT * FROM powersmash.reservation";
            getData(query);
            clearStatus();
            tlpCourt1.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt1_CellPaint);
            tlpCourt1.Invalidate();
            tlpCourt2.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt2_CellPaint);
            tlpCourt2.Invalidate();
            tlpCourt3.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt3_CellPaint);
            tlpCourt3.Invalidate();
            tlpCourt4.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt4_CellPaint);
            tlpCourt4.Invalidate();
            tlpCourt5.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt5_CellPaint);
            tlpCourt5.Invalidate();
            tlpCourt6.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt6_CellPaint);
            tlpCourt6.Invalidate();
            tlpCourt7.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt7_CellPaint);
            tlpCourt7.Invalidate();
            tlpCourt8.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt8_CellPaint);
            tlpCourt8.Invalidate();
            tlpCourt9.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt9_CellPaint);
            tlpCourt9.Invalidate();
            tlpCourt10.CellPaint += new TableLayoutCellPaintEventHandler(tlpCourt10_CellPaint);
            tlpCourt10.Invalidate();
        }
    }
}
