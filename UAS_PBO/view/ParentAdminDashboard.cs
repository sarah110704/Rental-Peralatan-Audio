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
    public partial class ParentAdminDashboard : Form
    {
        public ParentAdminDashboard()
        {
            InitializeComponent();
        }


        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ManajemenEquipment manajemenEquipment = new ManajemenEquipment();
            manajemenEquipment.MdiParent = this;
            manajemenEquipment.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ManajemenRental manajemenRental = new ManajemenRental();
            manajemenRental.MdiParent = this;
            manajemenRental.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ManajemenUser manajemenUser = new ManajemenUser();
            manajemenUser.MdiParent = this;
            manajemenUser.Show();
        }
    }
}
