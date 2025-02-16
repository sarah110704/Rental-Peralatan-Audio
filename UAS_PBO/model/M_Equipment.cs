namespace UAS_PBO.model
{
    public class Equipment
    {
        private int id;
        private string name;
        private string category;
        private string brand;
        private decimal rentalPrice;
        private int stock;
        private string description;
        private string imagePath;
        private string status;

        public Equipment() { }

        public Equipment(int id, string name, string category, string brand, decimal rentalPrice, int stock, string description, string imagePath, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Brand = brand;
            this.RentalPrice = rentalPrice;
            this.Stock = stock;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Status = status;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Brand { get => brand; set => brand = value; }
        public decimal RentalPrice { get => rentalPrice; set => rentalPrice = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Description { get => description; set => description = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public string Status { get => status; set => status = value; }
    }
}
