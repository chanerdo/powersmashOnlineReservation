using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowersmashOnlineReservation
{
    public partial class frmCourtTime : Form
    {
        private frmMain main;
        private Form parent;
        private DataTable data;
        private int court;
        private string datereserve;

        public frmCourtTime(frmMain frm, Form f, DataTable d, int c, string dt)
        {
            main = frm;
            parent = f;
            data = d;
            court = c;
            datereserve = dt;
            InitializeComponent();
            lblCourt.Text += " " + court.ToString();
            tlpHours.CellPaint += new TableLayoutCellPaintEventHandler(tlpHours_CellPaint);
        }

        private void setStatus(TableLayoutCellPaintEventArgs e)
        {
            foreach (DataRow row in data.Rows)
            {
                int id = row.Field<int>(0);
                int user_id = row.Field<int>(1);
                int court_id = row.Field<int>(2);
                string date = row.Field<DateTime>(4).ToString("yyyy-MM-dd");
                int start_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(5).ToString()).ToString("HH"));
                int end_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(6).ToString()).ToString("HH"));
                int status = row.Field<int>(8);
                if (datereserve.Equals(date))
                {
                    if (court == court_id)
                    {
                        while (start_time < end_time)
                        {
                            if (start_time == 06)
                            {
                                if(e.Row == 0)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 07)
                            {
                                if (e.Row == 1)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 08)
                            {
                                if (e.Row == 2)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 09)
                            {
                                if (e.Row == 3)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 10)
                            {
                                if (e.Row == 4)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 11)
                            {
                                if (e.Row == 5)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 12)
                            {
                                if (e.Row == 6)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 13)
                            {
                                if (e.Row == 7)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 14)
                            {
                                if (e.Row == 8)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 15)
                            {
                                if (e.Row == 9)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 16)
                            {
                                if (e.Row == 10)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 17)
                            {
                                if (e.Row == 11)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 18)
                            {
                                if (e.Row == 12)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 19)
                            {
                                if (e.Row == 13)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 20)
                            {
                                if (e.Row == 14)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 21)
                            {
                                if (e.Row == 15)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 22)
                            {
                                if (e.Row == 16)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            if (start_time == 23)
                            {
                                if (e.Row == 17)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, user_id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, user_id); }
                                }
                            }
                            start_time++;
                        }
                    }
                }
            }
        }

        private int setReserveID(int stime, int id)
        {
            if (stime == 06) { lbl06.Text = id.ToString(); }
            if (stime == 07) { lbl07.Text = id.ToString(); }
            if (stime == 08) { lbl08.Text = id.ToString(); }
            if (stime == 09) { lbl09.Text = id.ToString(); }
            if (stime == 10) { lbl10.Text = id.ToString(); }
            if (stime == 11) { lbl11.Text = id.ToString(); }
            if (stime == 12) { lbl12.Text = id.ToString(); }
            if (stime == 13) { lbl13.Text = id.ToString(); }
            if (stime == 14) { lbl14.Text = id.ToString(); }
            if (stime == 15) { lbl15.Text = id.ToString(); }
            if (stime == 16) { lbl16.Text = id.ToString(); }
            if (stime == 17) { lbl17.Text = id.ToString(); }
            if (stime == 18) { lbl18.Text = id.ToString(); }
            if (stime == 19) { lbl19.Text = id.ToString(); }
            if (stime == 20) { lbl20.Text = id.ToString(); }
            if (stime == 21) { lbl21.Text = id.ToString(); }
            if (stime == 22) { lbl22.Text = id.ToString(); }
            if (stime == 23) { lbl23.Text = id.ToString(); }
            return id;
        }

        private void tlpHours_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus(e);
        }

        private void tlpHours_MouseClick(object sender, MouseEventArgs e)
        {
            Point selectedCell = new Point(e.X / (tlpHours.Width / tlpHours.ColumnCount), e.Y / (tlpHours.Height / tlpHours.RowCount));
            if(selectedCell.Y == 0)
            {
                if (lbl06.Text.Equals("0"))
                {
                    //show add court usage
                }
                else
                {
                    //show details
                }
            }
        }
    }
}
