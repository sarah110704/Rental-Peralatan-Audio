using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UAS_PBO.model;

namespace UAS_PBO.controller
{
    public class RentalController
    {
        private Connection koneksi = new Connection();

        // ✅ Menambahkan Rental
        public bool AddRental(M_Rental rental, List<M_RentalDetail> rentalDetails)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                // Query untuk menyimpan data rental ke tabel rental
                string rentalQuery = $"INSERT INTO rental (UserID, RentalDate, ReturnDate, TotalPrice, Status) " +
                                     $"VALUES ('{rental.UserID}', '{rental.RentalDate:yyyy-MM-dd}', '{rental.ReturnDate:yyyy-MM-dd}', '{rental.TotalPrice}', '{rental.Status}')";

                koneksi.ExecuteQueries(rentalQuery);

                // Ambil RentalID terbaru yang baru saja disimpan
                string getRentalIDQuery = "SELECT LAST_INSERT_ID()";
                var result = koneksi.reader(getRentalIDQuery);

                int rentalID = -1;
                if (result.Read())
                {
                    rentalID = Convert.ToInt32(result[0]);
                }
                result.Close();

                if (rentalID == -1)
                {
                    throw new Exception("Gagal mendapatkan Rental ID.");
                }

                // Loop untuk menyimpan setiap item ke tabel rental_detail
                foreach (var detail in rentalDetails)
                {
                    string rentalDetailQuery = $"INSERT INTO rentaldetail (RentalID, EquipmentID, Quantity, PricePerDay, TotalPrice) " +
                                               $"VALUES ('{rentalID}', '{detail.EquipmentID}', '{detail.Quantity}', '{detail.PricePerDay}', '{detail.TotalPrice}')";

                    koneksi.ExecuteQueries(rentalDetailQuery);

                    // Update stok di tabel equipment
                    string updateStockQuery = $"UPDATE equipment SET Stock = Stock - {detail.Quantity} WHERE Id = {detail.EquipmentID}";
                    koneksi.ExecuteQueries(updateStockQuery);
                }

                status = true;
                MessageBox.Show("Penyewaan berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Menyimpan Penyewaan\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ✅ Mengambil Semua Data Penyewaan
        public List<M_Rental> GetAllRentals()
        {
            List<M_Rental> rentalList = new List<M_Rental>();
            try
            {
                koneksi.OpenConnection();
                string query = "SELECT r.*, u.Username FROM rental r JOIN users u ON r.UserID = u.Id";
                var result = koneksi.reader(query);

                while (result.Read())
                {
                    decimal totalPrice = 0;
                    string totalPriceString = result["TotalPrice"].ToString();

                    // **Cek apakah totalPrice memiliki format mata uang atau simbol lain**
                    decimal.TryParse(totalPriceString.Replace("Rp", "").Replace(",", "").Trim(), out totalPrice);

                    rentalList.Add(new M_Rental
                    {
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        UserName = result["Username"].ToString(),
                        RentalDate = result["RentalDate"] != DBNull.Value ? Convert.ToDateTime(result["RentalDate"]) : DateTime.MinValue,
                        ReturnDate = result["ReturnDate"] != DBNull.Value ? Convert.ToDateTime(result["ReturnDate"]) : DateTime.MinValue,
                        TotalPrice = totalPrice,
                        Status = result["Status"].ToString()
                    });
                }
                result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return rentalList;
        }



        // ✅ Mengambil Detail Penyewaan berdasarkan RentalID
        public List<M_RentalDetail> GetRentalDetails(int rentalID)
        {
            List<M_RentalDetail> detailList = new List<M_RentalDetail>();
            try
            {
                koneksi.OpenConnection();
                string query = "SELECT d.RentalDetailID, d.RentalID, d.EquipmentID, e.Name AS EquipmentName, d.Quantity, d.PricePerDay, d.TotalPrice " +
                               "FROM rentaldetail d " +
                               "JOIN equipment e ON d.EquipmentID = e.Id " +
                               $"WHERE d.RentalID = {rentalID}";

                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_RentalDetail detail = new M_RentalDetail
                    {
                        RentalDetailID = Convert.ToInt32(result["RentalDetailID"]),
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        EquipmentID = Convert.ToInt32(result["EquipmentID"]),
                        EquipmentName = result["EquipmentName"].ToString(),
                        Quantity = Convert.ToInt32(result["Quantity"]),
                        PricePerDay = Convert.ToDecimal(result["PricePerDay"]),
                        TotalPrice = Convert.ToDecimal(result["TotalPrice"])
                    };
                    detailList.Add(detail);
                }
                result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil detail rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return detailList;
        }

        //update Status Penyewaan
        public bool UpdateRentalStatus(int rentalID, string newStatus)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                string query = $"UPDATE rental SET Status = '{newStatus}' WHERE RentalID = {rentalID}";
                koneksi.ExecuteQueries(query);
                status = true;
                MessageBox.Show("Status penyewaan berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui status rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        //Menghapus Penyewaan (Hanya jika status "Cancelled")
        public bool DeleteRental(int rentalID)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                // Cek status rental sebelum menghapus
                string checkStatusQuery = $"SELECT Status FROM rental WHERE RentalID = {rentalID}";
                var result = koneksi.reader(checkStatusQuery);

                string statusRental = "";
                if (result.Read())
                {
                    statusRental = result["Status"].ToString();
                }
                result.Close();

                if (statusRental != "Cancelled")
                {
                    MessageBox.Show("Hanya penyewaan dengan status 'Cancelled' yang bisa dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Hapus rental_detail terlebih dahulu
                string deleteDetailQuery = $"DELETE FROM rentaldetail WHERE RentalID = {rentalID}";
                koneksi.ExecuteQueries(deleteDetailQuery);

                // Hapus rental utama
                string deleteRentalQuery = $"DELETE FROM rental WHERE RentalID = {rentalID}";
                koneksi.ExecuteQueries(deleteRentalQuery);

                status = true;
                MessageBox.Show("Penyewaan berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ✅ 🔍 **Search Rental berdasarkan UserName, RentalDate, atau Status**
        public List<M_Rental> SearchRental(string keyword)
        {
            List<M_Rental> rentalList = new List<M_Rental>();
            try
            {
                koneksi.OpenConnection();
                string query = $"SELECT rental.*, users.Username FROM rental " +
                               $"JOIN users ON rental.UserID = users.Id " +
                               $"WHERE users.Username LIKE '%{keyword}%' " +
                               $"OR rental.RentalDate LIKE '%{keyword}%' " +
                               $"OR rental.Status LIKE '%{keyword}%'";

                var result = koneksi.reader(query);

                while (result.Read())
                {
                    rentalList.Add(new M_Rental
                    {
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        UserID = Convert.ToInt32(result["UserID"]),
                        UserName = result["Username"].ToString(),
                        RentalDate = Convert.ToDateTime(result["RentalDate"]),
                        ReturnDate = Convert.ToDateTime(result["ReturnDate"]),
                        TotalPrice = Convert.ToDecimal(result["TotalPrice"]),
                        Status = result["Status"].ToString()
                    });
                }
                result.Close();
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return rentalList;
        }

        public List<M_Rental> GetCompletedRentals()
        {
            List<M_Rental> rentalList = new List<M_Rental>();
            try
            {
                koneksi.OpenConnection();
                string query = "SELECT r.RentalID, r.UserID, u.Username, u.FirstName, u.LastName, u.PhoneNumber, u.Address, r.RentalDate, r.ReturnDate, r.TotalPrice, r.Status " +
                               "FROM rental r " +
                               "JOIN users u ON r.UserID = u.Id " +
                               "WHERE r.Status = 'Completed'";

                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_Rental rental = new M_Rental
                    {
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        UserID = Convert.ToInt32(result["UserID"]),
                        UserName = result["Username"].ToString(),
                        FirstName = result["FirstName"].ToString(),
                        LastName = result["LastName"].ToString(),
                        Phone = result["PhoneNumber"].ToString(),
                        Address = result["Address"].ToString(),
                        RentalDate = Convert.ToDateTime(result["RentalDate"]),
                        ReturnDate = Convert.ToDateTime(result["ReturnDate"]),
                        TotalPrice = Convert.ToDecimal(result["TotalPrice"]),
                        Status = result["Status"].ToString()
                    };
                    rentalList.Add(rental);
                }
                result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return rentalList;
        }

        public List<M_RentalOngoing> GetOngoingRentals(int userID)
        {
            List<M_RentalOngoing> rentalList = new List<M_RentalOngoing>();
            try
            {
                koneksi.OpenConnection();
                string query = $"SELECT r.RentalID, e.Name AS EquipmentName, rd.Quantity, rd.PricePerDay, rd.TotalPrice, r.RentalDate, r.ReturnDate, r.Status " +
                               $"FROM rental r " +
                               $"JOIN rentaldetail rd ON r.RentalID = rd.RentalID " +
                               $"JOIN equipment e ON rd.EquipmentID = e.Id " +
                               $"WHERE r.UserID = {userID} AND (r.Status = 'Pending' OR r.Status = 'Ongoing')";

                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_RentalOngoing rental = new M_RentalOngoing
                    {
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        EquipmentName = result["EquipmentName"].ToString(),
                        Quantity = Convert.ToInt32(result["Quantity"]),
                        PricePerDay = Convert.ToDecimal(result["PricePerDay"]),
                        TotalPrice = Convert.ToDecimal(result["TotalPrice"]),
                        RentalDate = Convert.ToDateTime(result["RentalDate"]),
                        ReturnDate = Convert.ToDateTime(result["ReturnDate"]),
                        Status = result["Status"].ToString()
                    };
                    rentalList.Add(rental);
                }
                result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data penyewaan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return rentalList;
        }

        public bool CancelRental(int rentalID)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                // Cek apakah rental masih dalam status "Pending"
                string checkQuery = $"SELECT Status FROM rental WHERE RentalID = {rentalID}";
                var result = koneksi.reader(checkQuery);

                string currentStatus = "";
                if (result.Read())
                {
                    currentStatus = result["Status"].ToString();
                }
                result.Close();

                if (currentStatus != "Pending")
                {
                    MessageBox.Show("Hanya penyewaan dengan status 'Pending' yang bisa dibatalkan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Batalkan penyewaan dengan mengubah status menjadi "Cancelled"
                string cancelQuery = $"UPDATE rental SET Status = 'Cancelled' WHERE RentalID = {rentalID}";
                koneksi.ExecuteQueries(cancelQuery);

                status = true;
                MessageBox.Show("Penyewaan berhasil dibatalkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membatalkan penyewaan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

    }
}
