using System;
using System.Windows.Forms;

namespace UAS_PBO.view
{
    public partial class FormEditStatus : Form
    {
        public string SelectedStatus { get; private set; }

        public FormEditStatus(string currentStatus)
        {
            InitializeComponent();
            cbStatus.SelectedItem = currentStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("⚠ Pilih status terlebih dahulu!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedStatus = cbStatus.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
