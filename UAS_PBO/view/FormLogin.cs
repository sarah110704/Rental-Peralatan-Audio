using System;
using System.Windows.Forms;
using UAS_PBO.view;
using UAS_PBO.utils;

namespace UAS_PBO
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controller.UserController userController = new controller.UserController();
            model.M_User user = userController.Login(tbUsername.Text, tbPassword.Text);

            if (user != null)
            {
                
                SessionManager.UserID = int.Parse(user.Id);
                SessionManager.Username = user.Username;
                SessionManager.Role = user.Role;

                MessageBox.Show($"Login berhasil! Selamat datang {user.FirstName}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                
                if (user.Role == "Admin")
                {
                    ManajemenEquipment equipment = new ManajemenEquipment();
                    equipment.Show();
                }
                else
                {
                    FormCustomerDashboard customerDashboard = new FormCustomerDashboard();
                    customerDashboard.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
