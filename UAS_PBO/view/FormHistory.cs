using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using UAS_PBO.controller;
using UAS_PBO.model;

namespace UAS_PBO.view
{
    public partial class FormHistory : Form
    {
        private RentalController rentalController = new RentalController();

        public FormHistory()
        {
            InitializeComponent();
            LoadHistoryData();
        }

        // ✅ Memuat Data Penyewaan yang Berstatus "Completed"
        private void LoadHistoryData()
        {
            dgHistory.Rows.Clear();
            dgHistory.Columns.Clear();

            // 🔹 Definisi Kolom DataGridView
            dgHistory.Columns.Add("rentalID", "ID");
            dgHistory.Columns.Add("userName", "Nama User");
            dgHistory.Columns.Add("firstName", "Nama Depan");
            dgHistory.Columns.Add("lastName", "Nama Belakang");
            dgHistory.Columns.Add("phone", "Nomor HP");
            dgHistory.Columns.Add("address", "Alamat");
            dgHistory.Columns.Add("rentalDate", "Tanggal Sewa");
            dgHistory.Columns.Add("returnDate", "Tanggal Kembali");
            dgHistory.Columns.Add("equipmentName", "Nama Equipment");
            dgHistory.Columns.Add("quantity", "Jumlah");
            dgHistory.Columns.Add("pricePerDay", "Harga/Hari (Rp)");
            dgHistory.Columns.Add("totalPrice", "Total Harga (Rp)");

            // 🔹 Mengambil data dari database (hanya yang berstatus 'Completed')
            List<M_Rental> rentalList = rentalController.GetCompletedRentals();

            foreach (var rental in rentalList)
            {
                List<M_RentalDetail> rentalDetails = rentalController.GetRentalDetails(rental.RentalID);

                foreach (var detail in rentalDetails)
                {
                    dgHistory.Rows.Add(
                        rental.RentalID,
                        rental.UserName,
                        rental.FirstName,
                        rental.LastName,
                        rental.Phone,
                        rental.Address,
                        rental.RentalDate.ToString("dd-MMM-yyyy"),
                        rental.ReturnDate.ToString("dd-MMM-yyyy"),
                        detail.EquipmentName,
                        detail.Quantity,
                        detail.PricePerDay.ToString("N0"),
                        detail.TotalPrice.ToString("N0") // Format angka rupiah tanpa desimal
                    );
                }
            }
        }

        // ✅ Ekspor Data ke Excel Menggunakan EPPlus
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            save.FileName = "History_Penyewaan.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string filePath = save.FileName;
                try
                {
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("History Rental");

                        // 🔹 Header
                        for (int col = 1; col <= dgHistory.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col].Value = dgHistory.Columns[col - 1].HeaderText;
                            worksheet.Cells[1, col].Style.Font.Bold = true;
                        }

                        // 🔹 Data
                        for (int row = 0; row < dgHistory.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgHistory.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dgHistory.Rows[row].Cells[col].Value?.ToString();
                            }
                        }

                        // 🔹 Simpan file
                        File.WriteAllBytes(filePath, excel.GetAsByteArray());

                        MessageBox.Show("Data berhasil diekspor ke file Excel.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengekspor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ✅ Menutup Form History
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
