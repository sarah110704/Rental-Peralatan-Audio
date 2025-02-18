using System;

namespace UAS_PBO.model
{
    public class M_RentalOngoing
    {
        private int rentalID;
        private string equipmentName;
        private int quantity;
        private decimal pricePerDay;
        private decimal totalPrice;
        private DateTime rentalDate;
        private DateTime returnDate;
        private string status;  // 🟢 Tambahkan Status Penyewaan

        public M_RentalOngoing() { }

        public M_RentalOngoing(int rentalID, string equipmentName, int quantity, decimal pricePerDay, decimal totalPrice, DateTime rentalDate, DateTime returnDate, string status)
        {
            this.RentalID = rentalID;
            this.EquipmentName = equipmentName;
            this.Quantity = quantity;
            this.PricePerDay = pricePerDay;
            this.TotalPrice = totalPrice;
            this.RentalDate = rentalDate;
            this.ReturnDate = returnDate;
            this.Status = status;  // 🟢 Simpan status penyewaan
        }

        public int RentalID { get => rentalID; set => rentalID = value; }
        public string EquipmentName { get => equipmentName; set => equipmentName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal PricePerDay { get => pricePerDay; set => pricePerDay = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DateTime RentalDate { get => rentalDate; set => rentalDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public string Status { get => status; set => status = value; }  // 🟢 Properti Status
    }
}
