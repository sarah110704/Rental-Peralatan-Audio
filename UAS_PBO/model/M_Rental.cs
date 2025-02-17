using System;

namespace UAS_PBO.model
{
    public class M_Rental
    {
        private int rentalID;
        private int userID;
        private string userName; 
        private DateTime rentalDate;
        private DateTime returnDate;
        private decimal totalPrice;
        private string status;

        public M_Rental() { }

        public M_Rental(int rentalID, int userID, string userName, DateTime rentalDate, DateTime returnDate, decimal totalPrice, string status)
        {
            this.RentalID = rentalID;
            this.UserID = userID;
            this.UserName = userName;
            this.RentalDate = rentalDate;
            this.ReturnDate = returnDate;
            this.TotalPrice = totalPrice;
            this.Status = status;
        }

        public int RentalID { get => rentalID; set => rentalID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; } // 🟢 Properti baru
        public DateTime RentalDate { get => rentalDate; set => rentalDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Status { get => status; set => status = value; }
    }
}
