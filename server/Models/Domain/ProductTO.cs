namespace server.Models
{
    public class ProductTO
    {
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int NotificationQuantity { get; set; }
        public string Color { get; set; }
        public string TrimColor { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public string Dimensions { get; set; }
        public int SKU { get; set; }
        public int Deleted { get; set; }
    }
}