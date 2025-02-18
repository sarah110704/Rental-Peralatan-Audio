using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAS_PBO.controller;
using UAS_PBO.model;
using UAS_PBO.utils;

namespace UAS_PBO.view
{
    public partial class FormOngoingPemesanan : Form
    {
        private RentalController rentalController = new RentalController();
        private int userID; 
        public FormOngoingPemesanan()
        {
            InitializeComponent();
            this.userID = userID;
            LoadOngoingRentals();
        }
        private void LoadOngoingRentals()
        {
            dgOngoing.Rows.Clear();
            dgOngoing.Columns.Clear();

            dgOngoing.Columns.Add("rentalID", "ID");
            dgOngoing.Columns.Add("equipmentName", "Nama Alat");
            dgOngoing.Columns.Add("quantity", "Jumlah");
            dgOngoing.Columns.Add("pricePerDay", "Harga/Hari");
            dgOngoing.Columns.Add("totalPrice", "Total Harga");
            dgOngoing.Columns.Add("rentalDate", "Tanggal Sewa");
            dgOngoing.Columns.Add("returnDate", "Tanggal Kembali");
            dgOngoing.Columns.Add("status", "Status");

            int userID = SessionManager.UserID;
            MessageBox.Show($"User ID saat ini: {userID}"); 

            if (userID == 0)
            {
                MessageBox.Show("User belum login. Silakan login ulang!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<M_RentalOngoing> rentalList = rentalController.GetOngoingRentals(userID);

            if (rentalList.Count == 0)
            {
                MessageBox.Show("Tidak ada penyewaan yang sedang berlangsung!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var rental in rentalList)
            {
                dgOngoing.Rows.Add(
                    rental.RentalID,
                    rental.EquipmentName,
                    rental.Quantity,
                    rental.PricePerDay.ToString("C", new System.Globalization.CultureInfo("id-ID")),
                    rental.TotalPrice.ToString("C", new System.Globalization.CultureInfo("id-ID")),
                    rental.RentalDate.ToString("dd-MMM-yyyy"),
                    rental.ReturnDate.ToString("dd-MMM-yyyy"),
                    rental.Status);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgOngoing.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih penyewaan yang ingin dibatalkan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentalID = Convert.ToInt32(dgOngoing.SelectedRows[0].Cells["rentalID"].Value);
            string status = dgOngoing.SelectedRows[0].Cells["status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Hanya penyewaan dengan status 'Pending' yang bisa dibatalkan!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = rentalController.CancelRental(rentalID);
            if (success)
            {
                LoadOngoingRentals();
            }
        }

        private void dgOngoing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rentalID = Convert.ToInt32(dgOngoing.Rows[e.RowIndex].Cells["rentalID"].Value);
            string status = dgOngoing.Rows[e.RowIndex].Cells["status"].Value.ToString();
            if (status == "Pending")
            {
                btnCancel.Enabled = true;
            }
            else
            {
                btnCancel.Enabled = false;
            }

        }
    }
}
