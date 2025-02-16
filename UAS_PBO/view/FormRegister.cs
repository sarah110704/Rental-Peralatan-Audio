using System;
using System.Windows.Forms;

namespace UAS_PBO.view
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbPhoneNumber.Text == "" || tbUsername.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "" || tbAddress.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbPria.Checked && !rbWanita.Checked)
            {
                MessageBox.Show("Pilih salah satu jenis kelamin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Membuat objek user
            controller.UserController userController = new controller.UserController();
            model.M_User user = new model.M_User();
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.Phonenumber = tbPhoneNumber.Text;
            user.Username = tbUsername.Text;
            user.Password = tbPassword.Text; 
            user.Role = "Customer";  
            user.Address = tbAddress.Text;


            user.Gender = rbPria.Checked ? "Pria" : "Wanita";
            bool success = userController.Register(user);


            if (success)
            {
                MessageBox.Show("Registrasi berhasil! Silakan login.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Registrasi gagal! Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
