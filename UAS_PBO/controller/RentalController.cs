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


                    // Insert rentaldetail jika EquipmentID valid
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
                string query = "SELECT * FROM rental";
                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_Rental rental = new M_Rental
                    {
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        UserID = Convert.ToInt32(result["UserID"]),
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

        // ✅ Mengambil Detail Penyewaan berdasarkan RentalID
        public List<M_RentalDetail> GetRentalDetails(int rentalID)
        {
            List<M_RentalDetail> detailList = new List<M_RentalDetail>();
            try
            {
                koneksi.OpenConnection();
                string query = $"SELECT * FROM rentaldetail WHERE RentalID = {rentalID}";
                var result = koneksi.reader(query);

                while (result.Read())
                {
                    M_RentalDetail detail = new M_RentalDetail
                    {
                        RentalDetailID = Convert.ToInt32(result["RentalDetailID"]),
                        RentalID = Convert.ToInt32(result["RentalID"]),
                        EquipmentID = Convert.ToInt32(result["EquipmentID"]),
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

        // ✅ Mengupdate Status Penyewaan
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

        // ✅ Menghapus Penyewaan (Hanya jika status "Cancelled")
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
    }
}
