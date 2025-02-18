using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_PBO.view
{
    public partial class ParentCustomerDahsboard : Form
    {
        public ParentCustomerDahsboard()
        {
            InitializeComponent();
        }

        private void rentalSekarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomerDashboard rent = new FormCustomerDashboard();
            rent.MdiParent = this;
            rent.Show();
        }

        private void onGoingRentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOngoingPemesanan onGoing = new FormOngoingPemesanan();
            onGoing.MdiParent = this;
            onGoing.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
