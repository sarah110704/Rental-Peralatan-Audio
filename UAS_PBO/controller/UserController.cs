using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using UAS_PBO.model;
using System.Collections.Generic;

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

        public bool IsUsernameExists(string username)
        {
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT COUNT(*) FROM Users WHERE username = '" + username + "'");

                if (result.Read() && Convert.ToInt32(result[0]) > 0)
                {
                    return true; 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }

            return false; 
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

        public List<M_User> GetAllUsers()
        {
            List<M_User> userList = new List<M_User>();
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT id, firstname, lastname, phonenumber, username, passwordhash,address, gender, role FROM Users ORDER BY id ASC");

                while (result.Read())
                {
                    M_User user = new M_User
                    (
                        result["id"].ToString(),
                        result["firstname"].ToString(),
                        result["lastname"].ToString(),
                        result["phonenumber"].ToString(),
                        result["username"].ToString(),
                        result["passwordhash"].ToString(), 
                        result["address"].ToString(),
                        result["gender"].ToString(),
                        result["role"].ToString()
                    );
                    userList.Add(user);
                }
                result.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return userList;
        }



        public bool UpdateUser(M_User user)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                string updateQuery;
                if (!string.IsNullOrEmpty(user.Password))
                {
                    string hashedPassword = HashPasswordSHA256(user.Password);
                    updateQuery = "UPDATE Users SET firstname = '" + user.FirstName + "', lastname = '" + user.LastName +
                                  "', address = '" + user.Address + "', phonenumber = '" + user.Phonenumber +
                                  "', passwordhash = '" + hashedPassword + "' WHERE id = " + user.Id;
                }
                else
                {
                    updateQuery = "UPDATE Users SET firstname = '" + user.FirstName + "', lastname = '" + user.LastName +
                                  "', address = '" + user.Address + "', phonenumber = '" + user.Phonenumber +
                                  "' WHERE id = " + user.Id;
                }

                koneksi.ExecuteQueries(updateQuery);
                status = true;
                MessageBox.Show("Data user berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        public bool DeleteUser(int id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQueries("DELETE FROM Users WHERE id = " + id);
                status = true;
                MessageBox.Show("User berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        public List<M_User> SearchUsers(string keyword)
        {
            List<M_User> userList = new List<M_User>();
            try
            {
                koneksi.OpenConnection();

                // Query pencarian berdasarkan Username, First Name, atau Last Name
                string query = "SELECT id, username, firstname, lastname, address, phonenumber FROM Users " +
                               "WHERE username LIKE '%" + keyword + "%' " +
                               "OR firstname LIKE '%" + keyword + "%' " +
                               "OR lastname LIKE '%" + keyword + "%'";

                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_User user = new M_User
                    (
                        result["id"].ToString(),
                        result["username"].ToString(),
                        "",
                        result["firstname"].ToString(),
                        result["lastname"].ToString(),
                        result["address"].ToString(),
                        result["phonenumber"].ToString(),
                        result["role"].ToString(),
                        result["gender"].ToString() 
                    );
                    userList.Add(user);
                }
                result.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return userList;
        }




    }
}
 