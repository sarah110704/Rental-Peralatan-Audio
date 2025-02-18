namespace UAS_PBO.model
{
    public class M_RentalDetail
    {
        private int rentalDetailID;
        private int rentalID;
        private int equipmentID;
        private string equipmentName; // 🔹 Tambahkan nama equipment
        private int quantity;
        private decimal pricePerDay;
        private decimal totalPrice;

        public M_RentalDetail() { }

        public M_RentalDetail(int rentalDetailID, int rentalID, int equipmentID, string equipmentName, int quantity, decimal pricePerDay, decimal totalPrice)
        {
            this.RentalDetailID = rentalDetailID;
            this.RentalID = rentalID;
            this.EquipmentID = equipmentID;
            this.EquipmentName = equipmentName; // 🔹 Simpan nama equipment
            this.Quantity = quantity;
            this.PricePerDay = pricePerDay;
            this.TotalPrice = totalPrice;
        }

        public int RentalDetailID { get => rentalDetailID; set => rentalDetailID = value; }
        public int RentalID { get => rentalID; set => rentalID = value; }
        public int EquipmentID { get => equipmentID; set => equipmentID = value; }
        public string EquipmentName { get => equipmentName; set => equipmentName = value; } // 🔹 Properti baru
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal PricePerDay { get => pricePerDay; set => pricePerDay = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
