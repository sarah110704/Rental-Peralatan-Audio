using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using UAS_PBO.controller;
using UAS_PBO.model;

namespace UAS_PBO.view
{
    public partial class ManajemenUser : Form
    {
        private UserController userController = new UserController();
        private int selectedUserId = -1;

        public ManajemenUser()
        {
            InitializeComponent();
            TampilData();
        }

        public void TampilData()
        {
            try
            {
                dgUser.Rows.Clear();
                dgUser.Columns.Clear(); 

                dgUser.Columns.Add("id", "ID");
                dgUser.Columns.Add("firstname", "Firstname");
                dgUser.Columns.Add("lastname", "Lastname");
                dgUser.Columns.Add("phonenumber", "PhoneNumber");
                dgUser.Columns.Add("username", "Username");
                dgUser.Columns.Add("password", "Password");
                dgUser.Columns.Add("address", "Address");
                dgUser.Columns.Add("gender", "Gender");
                dgUser.Columns.Add("role", "Role");

                dgUser.Columns["id"].ReadOnly = true;
                dgUser.Columns["password"].ReadOnly = true;

                List<M_User> userList = userController.GetAllUsers();

                foreach (var user in userList)
                {
                     dgUser.Rows.Add(user.Id, user.FirstName, user.LastName, user.Phonenumber, user.Username, "******", user.Role, user.Gender, user.Address);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menampilkan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                tbHashedPassword.Text = HashPassword(tbPassword.Text);
            }
            else
            {
                tbHashedPassword.Clear();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) ||
                string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
                cbRole.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Harap isi semua kolom yang wajib!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            M_User user = new M_User
            {
                Id = selectedUserId.ToString(),
                Username = tbUsername.Text,
                Password = tbHashedPassword.Text,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Address = tbAddress.Text,
                Phonenumber = tbPhoneNumber.Text,
                Role = cbRole.SelectedItem.ToString(),
                Gender = cbGender.SelectedItem.ToString()
            };

            if (selectedUserId == -1)
            {
                // Insert User
                if (userController.IsUsernameExists(user.Username))
                {
                    MessageBox.Show("Username sudah digunakan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userController.Register(user))
                {
                    MessageBox.Show("User berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (userController.UpdateUser(user))
                {
                    MessageBox.Show("User berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ClearForm();
            TampilData();
        }

        private void dgUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgUser.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells[0].Value);
                tbFirstName.Text = row.Cells[1].Value.ToString();
                tbLastName.Text = row.Cells[2].Value.ToString();
                tbPhoneNumber.Text = row.Cells[3].Value.ToString();
                tbUsername.Text = row.Cells[4].Value.ToString();
                tbHashedPassword.Text = row.Cells[5].Value.ToString();
                tbAddress.Text = row.Cells[6].Value.ToString();
                cbGender.SelectedItem = row.Cells[7].Value.ToString();
                cbRole.SelectedItem = row.Cells[8].Value.ToString();
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Pilih user yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (userController.DeleteUser(selectedUserId))
                {
                    MessageBox.Show("User berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                TampilData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Pilih user yang ingin diedit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSimpan_Click(sender, e);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbSearch.Text.Trim();
            dgUser.Rows.Clear();
            List<M_User> userList = userController.SearchUsers(keyword);

            foreach (var user in userList)
            {
                dgUser.Rows.Add(user.Id, user.Username, "******", user.FirstName, user.LastName, user.Address, user.Phonenumber, user.Gender, user.Role );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            TampilData();
        }

        private void ClearForm()
        {
            selectedUserId = -1;
            tbUsername.Clear();
            tbPassword.Clear();
            tbHashedPassword.Clear();
            tbFirstName.Clear();
            tbLastName.Clear();
            tbAddress.Clear();
            tbPhoneNumber.Clear();
            cbRole.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
        }

        private void ManajemenUser_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Pilih user yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (userController.DeleteUser(selectedUserId))
                {
                    MessageBox.Show("User berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                TampilData();
            }

        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) ||
       string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
       cbRole.SelectedIndex == -1 || cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Harap isi semua kolom yang wajib!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            M_User user = new M_User
            {
                Id = selectedUserId.ToString(),
                Username = tbUsername.Text,
                Password = tbHashedPassword.Text,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Address = tbAddress.Text,
                Phonenumber = tbPhoneNumber.Text,
                Role = cbRole.SelectedItem.ToString(),
                Gender = cbGender.SelectedItem.ToString()
            };

            if (selectedUserId == -1)
            {
                if (userController.IsUsernameExists(user.Username))
                {
                    MessageBox.Show("Username sudah digunakan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userController.Register(user))
                {
                    MessageBox.Show("User berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (userController.UpdateUser(user))
                {
                    MessageBox.Show("User berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ClearForm();
            TampilData();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Pilih user yang ingin diedit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSimpan_Click(sender, e);


        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            ClearForm();
            TampilData();
        }
    }
}
