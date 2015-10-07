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
        private frmMain frmmain;
        private Form parent;
        private DataTable data;
        private int court;
        private string datereserve;

        public frmCourtTime(frmMain frm, Form f, DataTable d, int c, string dt)
        {
            frmmain = frm;
            parent = f;
            data = d;
            court = c;
            datereserve = dt;
            InitializeComponent();
            lblCourt.Text += " " + court.ToString();
            tlpHours.CellPaint += new TableLayoutCellPaintEventHandler(tlpHours_CellPaint);
        }

        private void frmCourtTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain.Activate();
            frmmain.Enabled = true;
            this.Dispose();
        }

        private void setStatus(TableLayoutCellPaintEventArgs e)
        {
            foreach (DataRow row in data.Rows)
            {
                int id = row.Field<int>(0);
                int user_id = row.Field<int>(0);
                int court_id = row.Field<int>(2);
                string date = row.Field<DateTime>(4).ToString("yyyy-MM-dd");
                int start_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(5).ToString()).ToString("HH"));
                int end_time = int.Parse(DateTime.Parse(row.Field<TimeSpan>(6).ToString()).ToString("HH"));
                int status = row.Field<int>(9);
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
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 07)
                            {
                                if (e.Row == 1)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 08)
                            {
                                if (e.Row == 2)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 09)
                            {
                                if (e.Row == 3)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 10)
                            {
                                if (e.Row == 4)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 11)
                            {
                                if (e.Row == 5)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 12)
                            {
                                if (e.Row == 6)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 13)
                            {
                                if (e.Row == 7)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 14)
                            {
                                if (e.Row == 8)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 15)
                            {
                                if (e.Row == 9)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 16)
                            {
                                if (e.Row == 10)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 17)
                            {
                                if (e.Row == 11)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 18)
                            {
                                if (e.Row == 12)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 19)
                            {
                                if (e.Row == 13)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 20)
                            {
                                if (e.Row == 14)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 21)
                            {
                                if (e.Row == 15)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 22)
                            {
                                if (e.Row == 16)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            if (start_time == 23)
                            {
                                if (e.Row == 17)
                                {
                                    if (status == 1) { e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 2) { e.Graphics.FillRectangle(Brushes.Firebrick, e.CellBounds); setReserveID(start_time, id); }
                                    if (status == 3) { e.Graphics.FillRectangle(Brushes.Gold, e.CellBounds); setReserveID(start_time, id); }
                                }
                            }
                            start_time++;
                        }
                    }
                }
            }
        }

        private int setReserveID(int stime, int rid)
        {
            if (stime == 06) { lbl06.Text = rid.ToString(); }
            if (stime == 07) { lbl07.Text = rid.ToString(); }
            if (stime == 08) { lbl08.Text = rid.ToString(); }
            if (stime == 09) { lbl09.Text = rid.ToString(); }
            if (stime == 10) { lbl10.Text = rid.ToString(); }
            if (stime == 11) { lbl11.Text = rid.ToString(); }
            if (stime == 12) { lbl12.Text = rid.ToString(); }
            if (stime == 13) { lbl13.Text = rid.ToString(); }
            if (stime == 14) { lbl14.Text = rid.ToString(); }
            if (stime == 15) { lbl15.Text = rid.ToString(); }
            if (stime == 16) { lbl16.Text = rid.ToString(); }
            if (stime == 17) { lbl17.Text = rid.ToString(); }
            if (stime == 18) { lbl18.Text = rid.ToString(); }
            if (stime == 19) { lbl19.Text = rid.ToString(); }
            if (stime == 20) { lbl20.Text = rid.ToString(); }
            if (stime == 21) { lbl21.Text = rid.ToString(); }
            if (stime == 22) { lbl22.Text = rid.ToString(); }
            if (stime == 23) { lbl23.Text = rid.ToString(); }
            return rid;
        }

        private void tlpHours_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            setStatus(e);
            Invalidate();
        }

        private void tlpHours_MouseClick(object sender, MouseEventArgs e)
        {
            Point selectedCell = new Point(e.X / (tlpHours.Width / tlpHours.ColumnCount), e.Y / (tlpHours.Height / tlpHours.RowCount));
            if(selectedCell.Y == 0)
            {
                if (lbl06.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 06);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("06:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl06.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 1)
            {
                if (lbl07.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 07);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("07:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl07.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 2)
            {
                if (lbl08.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 08);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("08:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl08.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 3)
            {
                if (lbl09.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 09);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("09:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl09.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 4)
            {
                if (lbl10.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 10);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("10:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl10.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 5)
            {
                if (lbl11.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 11);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("11:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl11.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 6)
            {
                if (lbl12.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 12);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("12:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl12.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 7)
            {
                if (lbl13.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 13);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("13:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl13.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 8)
            {
                if (lbl14.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 14);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("14:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl14.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 9)
            {
                if (lbl15.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 15);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("15:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl15.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 10)
            {
                if (lbl16.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 16);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("16:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl16.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 11)
            {
                if (lbl17.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 17);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("17:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl17.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 12)
            {
                if (lbl18.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 18);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("18:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl18.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 13)
            {
                if (lbl19.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 19);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("19:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl19.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 14)
            {
                if (lbl20.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 20);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("20:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl20.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 15)
            {
                if (lbl21.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 21);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("21:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl21.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 16)
            {
                if (lbl22.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 22);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("22:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl22.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
            if (selectedCell.Y == 17)
            {
                if (lbl23.Text.Equals("0"))
                {
                    //show add
                    if (MessageBox.Show("are you a member?", "member", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmMember addmember = new frmMember(frmmain, this, this, 23);
                        addmember.Show();
                        this.Hide();
                    }
                    else
                    {
                        frmNonMember nonmember = new frmNonMember(frmmain, this, this, DateTime.Parse("23:00:00").ToString("hh:mm tt"), court);
                        nonmember.Show();
                        this.Hide();
                    }
                }
                else
                {
                    //show details
                    frmMemberInfo meminfo = new frmMemberInfo(this, this, lbl23.Text);
                    meminfo.Show();
                    this.Hide();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmmain.Activate();
            frmmain.Enabled = true;
            this.Dispose();
        }
    }
}
