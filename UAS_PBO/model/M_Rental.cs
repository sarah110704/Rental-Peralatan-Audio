using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_PBO.model
{
    public class M_Rental
    {
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }

        public M_Rental() { }

        public M_Rental(string equipmentName, int quantity, decimal pricePerDay, decimal totalPrice, DateTime rentalStart, DateTime rentalEnd)
        {
            EquipmentName = equipmentName;
            Quantity = quantity;
            PricePerDay = pricePerDay;
            TotalPrice = totalPrice;
            RentalStart = rentalStart;
            RentalEnd = rentalEnd;
        }
    }
}