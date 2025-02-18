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

        private void LoadHistoryData()
        {
            dgHistory.Rows.Clear();
            dgHistory.Columns.Clear();

            dgHistory.Columns.Add("rentalID", "ID");
            dgHistory.Columns.Add("userName", "Nama User");
            dgHistory.Columns.Add("rentalDate", "Tanggal Sewa");
            dgHistory.Columns.Add("returnDate", "Tanggal Kembali");
            dgHistory.Columns.Add("totalPrice", "Total Harga");

            List<M_Rental> rentalList = rentalController.GetCompletedRentals();

            foreach (var rental in rentalList)
            {
                dgHistory.Rows.Add(
                    rental.RentalID,
                    rental.UserID, // Jika ada UserName, ganti dengan rental.UserName
                    rental.RentalDate.ToString("dd-MMM-yyyy"),
                    rental.ReturnDate.ToString("dd-MMM-yyyy"),
                    rental.TotalPrice.ToString("C"));
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            save.FileName = "History_Penyewaan.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string directory = Path.GetDirectoryName(save.FileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(save.FileName);
                string extension = Path.GetExtension(save.FileName);
                int count = 1;
                string filePath = save.FileName;

                while (File.Exists(filePath))
                {
                    filePath = Path.Combine(directory, $"{fileNameWithoutExt} ({count}){extension}");
                    count++;
                }

                try
                {
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("History Rental");

                        // Header
                        for (int col = 1; col <= dgHistory.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col].Value = dgHistory.Columns[col - 1].HeaderText;
                            worksheet.Cells[1, col].Style.Font.Bold = true;
                        }

                        // Data
                        for (int row = 0; row < dgHistory.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgHistory.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dgHistory.Rows[row].Cells[col].Value?.ToString();
                            }
                        }

                        // Simpan file
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
