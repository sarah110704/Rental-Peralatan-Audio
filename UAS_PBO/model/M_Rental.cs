using System;

namespace UAS_PBO.model
{
    public class M_Rental
    {
        private int rentalID;
        private int userID;
        private string userName;
        private string firstName;
        private string lastName;
        private string phone;
        private string address;
        private DateTime rentalDate;
        private DateTime returnDate;
        private decimal totalPrice;
        private string status;

        public M_Rental() { }

        public M_Rental(int rentalID, int userID, string userName, string firstName, string lastName, string phone, string address, DateTime rentalDate, DateTime returnDate, decimal totalPrice, string status)
        {
            this.RentalID = rentalID;
            this.UserID = userID;
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Address = address;
            this.RentalDate = rentalDate;
            this.ReturnDate = returnDate;
            this.TotalPrice = totalPrice;
            this.Status = status;
        }

        public int RentalID { get => rentalID; set => rentalID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public DateTime RentalDate { get => rentalDate; set => rentalDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Status { get => status; set => status = value; }
    }
}
