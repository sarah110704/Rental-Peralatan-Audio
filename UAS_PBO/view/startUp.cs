using System;
using System.Windows.Forms;

namespace UAS_PBO.view
{
    public partial class startUp : Form
    {
        public startUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar.Width += 3;
            if (ProgressBar.Width >= 599)
            {
                timer1.Stop();
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }

        }
    }
}
