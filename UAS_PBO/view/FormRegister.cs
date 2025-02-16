using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UAS_PBO.view
{
    public partial class FormRegister : Form
    {
        private controller.UserController userController = new controller.UserController();

        public FormRegister()
        {
            InitializeComponent();

            tbFirstName.Text = tbLastName.Text = tbPhoneNumber.Text = tbUsername.Text = tbPassword.Text = tbConfirmPassword.Text = tbAddress.Text = "";
            tbFirstName.Leave += TbFirstName_Leave;
            tbLastName.Leave += TbLastName_Leave;
            tbPhoneNumber.Leave += TbPhoneNumber_Leave;
            tbUsername.Leave += TbUsername_Leave;
            tbPassword.Leave += TbPassword_Leave;
            tbConfirmPassword.Leave += TbConfirmPassword_Leave;
            tbAddress.Leave += TbAddress_Leave;
        }

        private void SetErrorMessages(TextBox textBox, string warningMessage, string wrongMessage, string correctMessage)
        {
            if (textBox != null)  
            {
                epWarning.SetError(textBox, warningMessage ?? "");
                epWrong.SetError(textBox, wrongMessage ?? "");
                epCorrect.SetError(textBox, correctMessage ?? "");
            }
        }

   
        private void TbFirstName_Leave(object sender, EventArgs e)
        {
            if (tbFirstName.Text.Length == 0) return; 
            SetErrorMessages(tbFirstName, string.IsNullOrWhiteSpace(tbFirstName.Text) ? "First Name tidak boleh kosong!" : "", "", "First Name valid");
        }

        private void TbLastName_Leave(object sender, EventArgs e)
        {
            if (tbLastName.Text.Length == 0) return; 
            SetErrorMessages(tbLastName, string.IsNullOrWhiteSpace(tbLastName.Text) ? "Last Name tidak boleh kosong!" : "", "", "Last Name valid");
        }

        private void TbPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (tbPhoneNumber.Text.Length == 0) return;

            if (!Regex.IsMatch(tbPhoneNumber.Text, @"^\d+$"))
            {
                SetErrorMessages(tbPhoneNumber, "", "Nomor telepon hanya boleh angka!", "");
                return;
            }
            SetErrorMessages(tbPhoneNumber, "", "", "Phone Number valid");
        }

        private void TbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length == 0) return; 

            if (userController.IsUsernameExists(tbUsername.Text))
                SetErrorMessages(tbUsername, "", "Username sudah digunakan!", "");
            else
                SetErrorMessages(tbUsername, "", "", "Username tersedia");
        }

        private void TbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text.Length == 0) return; 

            if (tbPassword.Text.Length < 6)
                SetErrorMessages(tbPassword, "", "Password harus minimal 6 karakter!", "");
            else
                SetErrorMessages(tbPassword, "", "", "Password valid");
        }

        private void TbConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (tbConfirmPassword.Text.Length == 0) return; 

            if (tbConfirmPassword.Text != tbPassword.Text)
                SetErrorMessages(tbConfirmPassword, "", "Password tidak cocok!", "");
            else
                SetErrorMessages(tbConfirmPassword, "", "", "Password cocok");
        }

        private void TbAddress_Leave(object sender, EventArgs e)
        {
            if (tbAddress.Text.Length == 0) return; 
            SetErrorMessages(tbAddress, string.IsNullOrWhiteSpace(tbAddress.Text) ? "Address tidak boleh kosong!" : "", "", "Address valid");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (epWarning.GetError(tbFirstName) != "" || epWarning.GetError(tbLastName) != "" ||
                epWarning.GetError(tbPhoneNumber) != "" || epWarning.GetError(tbUsername) != "" ||
                epWarning.GetError(tbPassword) != "" || epWarning.GetError(tbConfirmPassword) != "" ||
                epWarning.GetError(tbAddress) != "")
            {
                MessageBox.Show("Perbaiki input yang salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            model.M_User user = new model.M_User
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Phonenumber = tbPhoneNumber.Text,
                Username = tbUsername.Text,
                Password = tbPassword.Text,  
                Role = "Customer",
                Address = tbAddress.Text,
                Gender = rbPria.Checked ? "Pria" : "Wanita"
            };

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
