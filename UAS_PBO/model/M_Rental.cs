using System;

namespace UAS_PBO.model
{
    public class M_Rental
    {
        private int rentalID;
        private int userID;
        private DateTime rentalDate;
        private DateTime returnDate;
        private decimal totalPrice;
        private string status;

        public M_Rental() { }

        public M_Rental(int rentalID, int userID, DateTime rentalDate, DateTime returnDate, decimal totalPrice, string status)
        {
            this.RentalID = rentalID;
            this.UserID = userID;
            this.RentalDate = rentalDate;
            this.ReturnDate = returnDate;
            this.TotalPrice = totalPrice;
            this.Status = status;
        }

        public int RentalID { get => rentalID; set => rentalID = value; }
        public int UserID { get => userID; set => userID = value; }
        public DateTime RentalDate { get => rentalDate; set => rentalDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Status { get => status; set => status = value; }
    }
}
