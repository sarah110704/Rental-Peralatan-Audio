using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using UAS_PBO.controller;
using UAS_PBO.model;

namespace UAS_PBO.view
{
    public partial class ManajemenEquipment : Form
    {
        private EquipmentController equipmentController = new EquipmentController();
        private int selectedEquipmentId = -1;

        public ManajemenEquipment()
        {
            InitializeComponent();
            TampilData();
        }

        // ✅ Menampilkan semua data equipment di DataGridView
        public void TampilData()
        {
            try
            {
                dgEquipment.Rows.Clear();

                // Pastikan kolom tidak ditambahkan ulang setiap kali method dipanggil
                if (dgEquipment.Columns.Count == 0)
                {
                    dgEquipment.Columns.Add("id", "ID");
                    dgEquipment.Columns.Add("name", "Nama");
                    dgEquipment.Columns.Add("category", "Kategori");
                    dgEquipment.Columns.Add("brand", "Brand");
                    dgEquipment.Columns.Add("rental_price", "Harga Rental");
                    dgEquipment.Columns.Add("stock", "Stock");
                    dgEquipment.Columns.Add("description", "Deskripsi");
                    dgEquipment.Columns.Add("image_path", "Gambar");
                    dgEquipment.Columns.Add("status", "Status");
                }

                List<Equipment> equipmentList = equipmentController.GetAllEquipment();

                foreach (var eq in equipmentList)
                {
                    dgEquipment.Rows.Add(eq.Id, eq.Name, eq.Category, eq.Brand, eq.RentalPrice, eq.Stock, eq.Description, eq.ImagePath, eq.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menampilkan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnDirectory_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbImage.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnsimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEquipmentName.Text) || string.IsNullOrWhiteSpace(tbPrice.Text) ||
                string.IsNullOrWhiteSpace(numStock.Text) || string.IsNullOrWhiteSpace(tbImage.Text))
            {
                MessageBox.Show("Harap isi semua kolom yang wajib!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tbPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal hargaRental) ||
                !int.TryParse(numStock.Text, out int stock))
            {
                MessageBox.Show("Harga rental harus angka desimal dan stok harus bilangan bulat!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Equipment equipment = new Equipment
            {
                Id = selectedEquipmentId,
                Name = tbEquipmentName.Text,
                Category = cbCategory.Text,
                Brand = tbBrand.Text,
                RentalPrice = hargaRental,
                Stock = stock,
                Description = tbDescription.Text,
                ImagePath = tbImage.Text,
                Status = cbStatus.Text
            };

            if (selectedEquipmentId == -1)
            {
                if (equipmentController.IsEquipmentExists(equipment.Name))
                {
                    MessageBox.Show("Nama equipment sudah digunakan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (equipmentController.InsertEquipment(equipment))
                {
                    MessageBox.Show("Equipment berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (equipmentController.UpdateEquipment(equipment))
                {
                    MessageBox.Show("Equipment berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ClearForm();
            TampilData();
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Pilih equipment yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus equipment ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (equipmentController.DeleteEquipment(selectedEquipmentId))
                {
                    MessageBox.Show("Equipment berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                TampilData();
            }
        }

        private void bttnedit_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Pilih equipment yang ingin diedit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnsimpan_Click(sender, e);
        }

        private void dgEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgEquipment.Rows.Count)
            {
                DataGridViewRow row = dgEquipment.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    selectedEquipmentId = Convert.ToInt32(row.Cells[0].Value);
                    tbEquipmentName.Text = row.Cells[1].Value.ToString();
                    cbCategory.Text = row.Cells[2].Value.ToString();
                    tbBrand.Text = row.Cells[3].Value.ToString();
                    tbPrice.Text = row.Cells[4].Value.ToString();
                    numStock.Text = row.Cells[5].Value.ToString();
                    tbDescription.Text = row.Cells[6].Value.ToString();
                    tbImage.Text = row.Cells[7].Value.ToString();
                    cbStatus.Text = row.Cells[8].Value.ToString();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbSearch.Text.Trim();
            dgEquipment.Rows.Clear();
            List<Equipment> equipmentList = equipmentController.SearchEquipment(keyword);

            foreach (var eq in equipmentList)
            {
                dgEquipment.Rows.Add(eq.Id, eq.Name, eq.Category, eq.Brand, eq.RentalPrice, eq.Stock, eq.Description, eq.ImagePath, eq.Status);
            }
        }

        private void buttnrfresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            TampilData();
        }

        private void ClearForm()
        {
            selectedEquipmentId = -1;
            tbEquipmentName.Clear();
            cbCategory.SelectedIndex = -1;
            tbBrand.Clear();
            tbPrice.Clear();
            numStock.Value = 0;
            tbDescription.Clear();
            tbImage.Clear();
            cbStatus.SelectedIndex = -1;
        }



        private void ManageEquipment_Load(object sender, EventArgs e)
        {
            string keyword = tbSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                TampilData(); 
                return;
            }

            dgEquipment.Rows.Clear();

            List<Equipment> equipmentList = equipmentController.SearchEquipment(keyword);

            equipmentList.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));

            foreach (var eq in equipmentList)
            {
                dgEquipment.Rows.Add(eq.Id, eq.Name, eq.Category, eq.Brand, eq.RentalPrice, eq.Stock, eq.Description, eq.ImagePath, eq.Status);
            }
        }
    }
}
