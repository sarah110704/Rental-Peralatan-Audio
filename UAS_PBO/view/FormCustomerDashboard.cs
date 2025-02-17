using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UAS_PBO.controller;
using UAS_PBO.model;
using UAS_PBO.utils;

namespace UAS_PBO.view
{
    public partial class FormCustomerDashboard : Form
    {
        private RentalController rentalController = new RentalController();
        private EquipmentController equipmentController = new EquipmentController();

        public FormCustomerDashboard()
        {
            InitializeComponent();
            InitializeDataGrid();
            GenerateEquipmentCards();
        }

        // ✅ Inisialisasi DataGrid untuk List Barang yang Dipilih
        private void InitializeDataGrid()
        {
            dgCart.Columns.Clear();

            dgCart.Columns.Add("equipmentID", "ID");
            dgCart.Columns.Add("equipmentName", "Nama Barang");
            dgCart.Columns.Add("category", "Kategori");
            dgCart.Columns.Add("brand", "Brand");
            dgCart.Columns.Add("quantity", "Jumlah");
            dgCart.Columns.Add("pricePerDay", "Harga Sewa / Hari");
            dgCart.Columns.Add("totalPrice", "Total Harga");

            dgCart.Columns["equipmentID"].Visible = false; // Sembunyikan ID untuk keperluan internal
            dgCart.Columns["equipmentName"].ReadOnly = true;
            dgCart.Columns["category"].ReadOnly = true;
            dgCart.Columns["brand"].ReadOnly = true;
            dgCart.Columns["pricePerDay"].ReadOnly = true;
            dgCart.Columns["totalPrice"].ReadOnly = true;
        }

        // ✅ Menampilkan Kartu Equipment dari Database
        private void GenerateEquipmentCards()
        {
            flowLayoutPanel1.Controls.Clear();

            List<Equipment> equipmentList = equipmentController.GetAllEquipment(); // Ambil dari database

            foreach (var eq in equipmentList)
            {
                Panel equipmentPanel = new Panel
                {
                    Width = 250,
                    Height = 350,
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(5)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Width = 230,
                    Height = 160,
                    ImageLocation = eq.ImagePath,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Top = 5,
                    Left = 5
                };

                Label nameLabel = new Label
                {
                    Text = eq.Name,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true,
                    Top = 170,
                    Left = 5
                };

                Label categoryLabel = new Label
                {
                    Text = $"Kategori: {eq.Category} | Brand: {eq.Brand}",
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 190,
                    Left = 5
                };

                Label stockLabel = new Label
                {
                    Text = $"Stok: {eq.Stock} | Status: {eq.Status}",
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 210,
                    Left = 5,
                    ForeColor = eq.Status == "Tersedia" ? Color.Green : Color.Red
                };

                Label descLabel = new Label
                {
                    Text = eq.Description,
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 230,
                    Left = 5
                };

                Label priceLabel = new Label
                {
                    Text = $"Harga: {eq.RentalPrice:C}",
                    Font = new Font("Arial", 9),
                    AutoSize = true,
                    ForeColor = Color.Green,
                    Top = 250,
                    Left = 5
                };

                NumericUpDown quantityInput = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = eq.Stock,
                    Value = 1,
                    Width = 60,
                    Top = 275,
                    Left = 5
                };

                Button orderButton = new Button
                {
                    Text = "Order Now",
                    BackColor = Color.Blue,
                    ForeColor = Color.White,
                    Width = 230,
                    Top = 310,
                    Left = 5
                };

                orderButton.Click += (sender, e) =>
                {
                    int qty = (int)quantityInput.Value;
                    if (qty > eq.Stock)
                    {
                        MessageBox.Show("Stok tidak mencukupi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    AddToCart(eq, qty);
                };

                equipmentPanel.Controls.Add(pictureBox);
                equipmentPanel.Controls.Add(nameLabel);
                equipmentPanel.Controls.Add(categoryLabel);
                equipmentPanel.Controls.Add(stockLabel);
                equipmentPanel.Controls.Add(descLabel);
                equipmentPanel.Controls.Add(priceLabel);
                equipmentPanel.Controls.Add(quantityInput);
                equipmentPanel.Controls.Add(orderButton);

                flowLayoutPanel1.Controls.Add(equipmentPanel);
            }
        }

        // ✅ Menambahkan Equipment ke Keranjang
        private void AddToCart(Equipment eq, int qty)
        {
            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells["equipmentName"].Value != null && row.Cells["equipmentName"].Value.ToString() == eq.Name)
                {
                    MessageBox.Show("Barang sudah ada di keranjang!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            decimal totalHarga = eq.RentalPrice * qty;
            MessageBox.Show($"Equipment ID: {eq.Id}");
            dgCart.Rows.Add(eq.Id, eq.Name, eq.Category, eq.Brand, qty, eq.RentalPrice, totalHarga);
            UpdateTotalPrice();
        }

        // ✅ Mengupdate Total Harga
        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells["totalPrice"].Value != null && row.Cells["equipmentName"].Value.ToString() != "Total")
                {
                    total += Convert.ToDecimal(row.Cells["totalPrice"].Value);
                }
            }

            if (dgCart.Rows.Count > 0)
            {
                if (dgCart.Rows[dgCart.Rows.Count - 1].Cells[0].Value?.ToString() == "Total")
                {
                    dgCart.Rows.RemoveAt(dgCart.Rows.Count - 1);
                }
            }

            dgCart.Rows.Add("Total", "", "", "", "", "", total.ToString("C"));
        }

        // ✅ Menyimpan Data Penyewaan
        private void btnSewa_Click(object sender, EventArgs e)
        {
            if (dgCart.Rows.Count <= 1)
            {
                MessageBox.Show("Keranjang masih kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.UserID == -1)
            {
                MessageBox.Show("Anda belum login! Silakan login terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime startDate = dtpSewa.Value;
            DateTime endDate = dtpKembali.Value;

            if (endDate <= startDate)
            {
                MessageBox.Show("Tanggal pengembalian harus setelah tanggal penyewaan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userID = SessionManager.UserID; // Ambil UserID dari sesi login

            decimal totalPrice = 0;
            List<M_RentalDetail> rentalDetails = new List<M_RentalDetail>();

            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells[0].Value?.ToString() == "Total") continue;

                rentalDetails.Add(new M_RentalDetail
                {
                    EquipmentID = Convert.ToInt32(row.Cells["equipmentID"].Value),
                    Quantity = Convert.ToInt32(row.Cells["quantity"].Value),
                    PricePerDay = Convert.ToDecimal(row.Cells["pricePerDay"].Value),
                    TotalPrice = Convert.ToDecimal(row.Cells["totalPrice"].Value)
                });

                totalPrice += Convert.ToDecimal(row.Cells["totalPrice"].Value);
            }

            M_Rental rental = new M_Rental
            {
                UserID = userID, 
                RentalDate = startDate,
                ReturnDate = endDate,
                TotalPrice = totalPrice,
                Status = "Ongoing"
            };

            bool success = rentalController.AddRental(rental, rentalDetails);
            if (success)
            {
                MessageBox.Show("Penyewaan berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCart();
            }
        }


        private void ClearCart()
        {
            dgCart.Rows.Clear();
        }
    }
}
