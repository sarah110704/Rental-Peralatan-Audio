using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using UAS_PBO.model;

namespace UAS_PBO.controller
{
    internal class UserController
    {
        Connection koneksi = new Connection();

        public string HashPasswordSHA256(string password)
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

        public bool Register(M_User user)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                string hashedPassword = HashPasswordSHA256(user.Password);
                koneksi.ExecuteQueries("INSERT INTO Users (firstname, lastname, phonenumber, username, passwordhash, role, gender, address) " +
                    "VALUES ('" + user.FirstName + "', '" + user.LastName + "', '" + user.Phonenumber + "', '" + user.Username + "', '" +
                    hashedPassword + "', '" + user.Role + "', '" + user.Gender + "', '" + user.Address + "')");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }
        public M_User Login(string username, string password)
        {
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT * FROM Users WHERE username = '" + username + "'");

                if (result.Read()) 
                {
                    string storedHashedPassword = result["passwordhash"].ToString();
                    string hashedInputPassword = HashPasswordSHA256(password); 

                    if (hashedInputPassword == storedHashedPassword)
                    {
                        return new M_User(
                            result["id"].ToString(),
                            result["firstname"].ToString(),
                            result["lastname"].ToString(),
                            result["phonenumber"].ToString(),
                            result["username"].ToString(),
                            storedHashedPassword,
                            result["role"].ToString(),
                            result["gender"].ToString(),
                            result["address"].ToString()
                        );
                    }
                }

                MessageBox.Show("Username atau password salah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }

            return null;
        }
    }
}
 