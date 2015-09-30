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
    public partial class frmMember : Form
    {

        private frmMain frmmain;
        private frmCourtTime frmcourt;
        private Form parent;
        private int start_time;

        public frmMember(frmMain fm, frmCourtTime frm, Form f, int stime)
        {
            frmcourt = frm;
            frmmain = fm;
            parent = f;
            start_time = stime;
            InitializeComponent();
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmmain.Activate();
            frmcourt.Show();
            frmcourt.Activate();
            this.Dispose();
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
