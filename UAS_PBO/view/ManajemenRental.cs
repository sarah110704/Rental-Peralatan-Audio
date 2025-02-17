using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UAS_PBO.controller;
using UAS_PBO.model;
using Microsoft.VisualBasic;


namespace UAS_PBO.view
{
    public partial class ManajemenRental : Form
    {
        private RentalController rentalController = new RentalController();
        private int selectedRentalID = -1;

        public ManajemenRental()
        {
            InitializeComponent();
            InitializeDataGrid();
            LoadRentalData();
        }

        // ✅ Inisialisasi DataGridView
        private void InitializeDataGrid()
        {
            dgRental.Columns.Clear();

            dgRental.Columns.Add("rentalID", "ID");
            dgRental.Columns.Add("userName", "Nama User");
            dgRental.Columns.Add("rentalDate", "Tanggal Sewa");
            dgRental.Columns.Add("returnDate", "Tanggal Kembali");
            dgRental.Columns.Add("totalPrice", "Total Harga");
            dgRental.Columns.Add("status", "Status");

            dgRental.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgRental.MultiSelect = false;
        }


        // ✅ Memuat Data Penyewaan dari Database
        private void LoadRentalData()
        {
            dgRental.Rows.Clear();
            List<M_Rental> rentalList = rentalController.GetAllRentals();

            foreach (var rental in rentalList)
            {
                // Pastikan data yang di-load bersih dari format mata uang
                string userName = rental.UserName ?? "Unknown";
                string status = rental.Status ?? "Pending";
                string rentalDate = rental.RentalDate != DateTime.MinValue ? rental.RentalDate.ToString("dd-MMM-yyyy") : "N/A";
                string returnDate = rental.ReturnDate != DateTime.MinValue ? rental.ReturnDate.ToString("dd-MMM-yyyy") : "N/A";
                string totalPrice = rental.TotalPrice > 0 ? rental.TotalPrice.ToString("N0") : "0";

                dgRental.Rows.Add(
                    rental.RentalID,
                    userName,
                    rentalDate,
                    returnDate,
                    totalPrice,
                    status);
            }
        }

        private void dgRental_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRental.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgRental.SelectedRows[0];

                if (row.Cells["rentalID"].Value != null)
                {
                    selectedRentalID = Convert.ToInt32(row.Cells["rentalID"].Value);
                }
            }
        }


        // ✅ Handle Click pada DataGridView (Edit & Hapus)
        private void dgRental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan baris yang diklik valid dan bukan header
            if (e.RowIndex >= 0 && e.RowIndex < dgRental.Rows.Count)
            {
                // Ambil baris yang diklik
                DataGridViewRow row = dgRental.Rows[e.RowIndex];

                // **Pastikan semua kolom tidak null sebelum akses**
                if (row.Cells["rentalID"].Value == null ||
                    row.Cells["status"].Value == null ||
                    row.Cells["rentalDate"].Value == null ||
                    row.Cells["returnDate"].Value == null ||
                    row.Cells["totalPrice"].Value == null)
                {
                    MessageBox.Show("⚠ Error: Data tidak lengkap atau belum tersedia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rentalID;
                string currentStatus = row.Cells["status"].Value.ToString();
                DateTime rentalDate, returnDate;
                decimal totalPrice;

                // **Gunakan TryParse untuk menghindari error format**
                if (!int.TryParse(row.Cells["rentalID"].Value.ToString(), out rentalID))
                {
                    MessageBox.Show("⚠ Error: Format Rental ID tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(row.Cells["rentalDate"].Value.ToString(), out rentalDate))
                {
                    MessageBox.Show("⚠ Error: Format Tanggal Sewa tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(row.Cells["returnDate"].Value.ToString(), out returnDate))
                {
                    MessageBox.Show("⚠ Error: Format Tanggal Kembali tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // **Pastikan data total harga dalam format numerik**
                string totalPriceString = row.Cells["totalPrice"].Value.ToString().Replace("Rp", "").Replace(",", "").Trim();
                if (!decimal.TryParse(totalPriceString, out totalPrice))
                {
                    MessageBox.Show("⚠ Error: Format Total Harga tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // **Pastikan kolom Edit & Hapus ada sebelum diproses**
                if (dgRental.Columns.Contains("Edit") && e.ColumnIndex == dgRental.Columns["Edit"].Index)
                {
                    EditRental(rentalID, currentStatus);
                }
                else if (dgRental.Columns.Contains("Hapus") && e.ColumnIndex == dgRental.Columns["Hapus"].Index)
                {
                    DeleteRental(rentalID);
                }
            }
        }




        private void EditRental(int rentalID, string currentStatus)
        {
            using (FormEditStatus form = new FormEditStatus(currentStatus))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    bool success = rentalController.UpdateRentalStatus(rentalID, form.SelectedStatus);
                    if (success)
                    {
                        MessageBox.Show("Status penyewaan berhasil diperbarui!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRentalData();
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui status penyewaan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        // ✅ Hapus Penyewaan
        private void DeleteRental(int rentalID)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus penyewaan ini?",
                                                  "Konfirmasi",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = rentalController.DeleteRental(rentalID);
                if (success)
                {
                    MessageBox.Show("Penyewaan berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRentalData();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus penyewaan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ✅ Mencari Penyewaan berdasarkan Nama User
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchRentals.Text.Trim();
            dgRental.Rows.Clear();
            List<M_Rental> rentalList = rentalController.SearchRental(keyword);

            foreach (var rental in rentalList)
            {
                dgRental.Rows.Add(
                    rental.RentalID,
                    rental.UserName,
                    rental.RentalDate.ToString("dd-MMM-yyyy"),
                    rental.ReturnDate.ToString("dd-MMM-yyyy"),
                    rental.TotalPrice.ToString("C"),
                    rental.Status);
            }
        }

        // ✅ Refresh Data
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SearchRentals.Clear();
            LoadRentalData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgRental.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠ Pilih penyewaan yang ingin diedit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil baris yang dipilih
            DataGridViewRow row = dgRental.SelectedRows[0];

            // Pastikan kolom memiliki nilai sebelum mengambil data
            if (row.Cells["rentalID"].Value == null || row.Cells["status"].Value == null)
            {
                MessageBox.Show("⚠ Data tidak lengkap, pilih penyewaan lain!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalID;
            string currentStatus = row.Cells["status"].Value.ToString();

            if (!int.TryParse(row.Cells["rentalID"].Value.ToString(), out rentalID))
            {
                MessageBox.Show("⚠ Error: Format Rental ID tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditRental(rentalID, currentStatus);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgRental.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠ Pilih penyewaan yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil baris yang dipilih
            DataGridViewRow row = dgRental.SelectedRows[0];

            if (row.Cells["rentalID"].Value == null)
            {
                MessageBox.Show("⚠ Data tidak lengkap, pilih penyewaan lain!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalID;
            if (!int.TryParse(row.Cells["rentalID"].Value.ToString(), out rentalID))
            {
                MessageBox.Show("⚠ Error: Format Rental ID tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DeleteRental(rentalID);
        }

    }
}
