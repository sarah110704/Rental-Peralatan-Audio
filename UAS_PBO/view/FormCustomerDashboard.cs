using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UAS_PBO.model;

namespace UAS_PBO.view
{
    public partial class FormCustomerDashboard : Form
    {
        public FormCustomerDashboard()
        {
            InitializeComponent();
            InitializeDataGrid();
            GenerateEquipmentCards();
        }

        private void InitializeDataGrid()
        {
            dgCart.Columns.Clear();

            dgCart.Columns.Add("equipmentName", "Nama Barang");
            dgCart.Columns.Add("category", "Kategori");
            dgCart.Columns.Add("brand", "Brand");
            dgCart.Columns.Add("quantity", "Jumlah");
            dgCart.Columns.Add("pricePerDay", "Harga Sewa / Hari");
            dgCart.Columns.Add("totalPrice", "Total Harga");

            dgCart.Columns["equipmentName"].ReadOnly = true;
            dgCart.Columns["category"].ReadOnly = true;
            dgCart.Columns["brand"].ReadOnly = true;
            dgCart.Columns["pricePerDay"].ReadOnly = true;
            dgCart.Columns["totalPrice"].ReadOnly = true;
        }

        private void GenerateEquipmentCards()
        {
            flowLayoutPanel1.Controls.Clear();

            List<Equipment> equipmentList = new List<Equipment>
            {
                new Equipment { Name="Yamaha DXR12", Category="Speaker", Brand="Yamaha", Stock=5, RentalPrice=250000, Status="Tersedia", Description="Speaker aktif 12 inch", ImagePath="Images/speaker.jpg" },
                new Equipment { Name="Shure SM58", Category="Microphone", Brand="Shure", Stock=10, RentalPrice=50000, Status="Tersedia", Description="Microphone vocal dynamic", ImagePath="Images/microphone.jpg" }
            };

            foreach (var eq in equipmentList)
            {
                Panel equipmentPanel = new Panel
                {
                    Width = 250,
                    Height = 310,
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
                    Top = 130,
                    Left = 5
                };

                Label categoryLabel = new Label
                {
                    Text = $"Kategori: {eq.Category} | Brand: {eq.Brand}",
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 150,
                    Left = 5
                };

                Label stockLabel = new Label
                {
                    Text = $"Stok: {eq.Stock} | Status: {eq.Status}",
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 170,
                    Left = 5,
                    ForeColor = eq.Status == "Tersedia" ? Color.Green : Color.Red
                };

                Label descLabel = new Label
                {
                    Text = eq.Description,
                    Font = new Font("Arial", 8),
                    AutoSize = true,
                    Top = 190,
                    Left = 5
                };

                Label priceLabel = new Label
                {
                    Text = $"Harga: {eq.RentalPrice:C}",
                    Font = new Font("Arial", 9),
                    AutoSize = true,
                    ForeColor = Color.Green,
                    Top = 210,
                    Left = 5
                };

                NumericUpDown quantityInput = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = eq.Stock,
                    Value = 1,
                    Width = 60,
                    Top = 235,
                    Left = 5
                };

                Button orderButton = new Button
                {
                    Text = "Order Now",
                    BackColor = Color.Blue,
                    ForeColor = Color.White,
                    Width = 230,
                    Top = 270,
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

        private void AddToCart(Equipment eq, int qty)
        {
            if (eq == null)
            {
                MessageBox.Show("Error: Data equipment tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgCart.Columns.Count == 0)
            {
                MessageBox.Show("Error: DataGridView belum diinisialisasi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells["equipmentName"].Value != null && row.Cells["equipmentName"].Value.ToString() == eq.Name)
                {
                    MessageBox.Show("Barang sudah ada di keranjang!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            decimal totalHarga = eq.RentalPrice * qty;
            dgCart.Rows.Add(eq.Name, eq.Category, eq.Brand, qty, eq.RentalPrice.ToString("C"), totalHarga.ToString("C"));
            UpdateTotalPrice();
        }


        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells["totalPrice"].Value != null && row.Cells["equipmentName"].Value.ToString() != "Total")
                {
                    total += Convert.ToDecimal(row.Cells["totalPrice"].Value.ToString().Replace("Rp", "").Replace(",", "").Trim());
                }
            }

            if (dgCart.Rows.Count > 0)
            {
                if (dgCart.Rows[dgCart.Rows.Count - 1].Cells[0].Value?.ToString() == "Total")
                {
                    dgCart.Rows.RemoveAt(dgCart.Rows.Count - 1);
                }
            }

            dgCart.Rows.Add("Total", "", "", "", "", total.ToString("C"));
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            if (dgCart.Rows.Count <= 1)
            {
                MessageBox.Show("Keranjang masih kosong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtpSewa.Value;
            DateTime endDate = dtpKembali.Value;

            if (endDate <= startDate)
            {
                MessageBox.Show("Tanggal pengembalian harus setelah tanggal penyewaan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<M_Rental> rentalItems = new List<M_Rental>();

            foreach (DataGridViewRow row in dgCart.Rows)
            {
                if (row.Cells[0].Value?.ToString() == "Total") continue;

                rentalItems.Add(new M_Rental
                {
                    EquipmentName = row.Cells[0].Value.ToString(),
                    Quantity = Convert.ToInt32(row.Cells[3].Value),
                    PricePerDay = Convert.ToDecimal(row.Cells[4].Value.ToString().Replace("Rp", "").Replace(",", "").Trim()),
                    TotalPrice = Convert.ToDecimal(row.Cells[5].Value.ToString().Replace("Rp", "").Replace(",", "").Trim()),
                    RentalStart = startDate,
                    RentalEnd = endDate
                });
            }

            ShowRentalSummary(rentalItems);
        }

        private void ShowRentalSummary(List<M_Rental> rentalItems)
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine("📌 Ringkasan Penyewaan:\n");

            foreach (var rental in rentalItems)
            {
                summary.AppendLine($"Equipment: {rental.EquipmentName}");
                summary.AppendLine($"Jumlah: {rental.Quantity}");
                summary.AppendLine($"Harga/Hari: {rental.PricePerDay:C}");
                summary.AppendLine($"Tanggal Sewa: {rental.RentalStart:dd MMM yyyy}");
                summary.AppendLine($"Tanggal Kembali: {rental.RentalEnd:dd MMM yyyy}");
                summary.AppendLine($"Total Harga: {rental.TotalPrice:C}");
                summary.AppendLine("-------------------------------------\n");
            }

            MessageBox.Show(summary.ToString(), "Detail Penyewaan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
