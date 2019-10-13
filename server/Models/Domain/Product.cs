namespace server.Models.Domain
{
    public class Product
    {
        public Product() { }
        public Product(ProductTO p)
        {
            this.ProductID = p.ProductID;
            this.ProductName = p.ProductName;
            this.NotificationQuantity = p.NotificationQuantity;
            this.Color = p.Color;
            this.TrimColor = p.TrimColor;
            this.Size = p.Size;
            this.Price = p.Price;
            this.Dimensions = p.Dimensions;
            this.SKU = p.SKU;
            this.Deleted = p.Deleted;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int NotificationQuantity { get; set; }
        public string Color { get; set; }
        public string TrimColor { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public string Dimensions { get; set; }
        public double SKU { get; set; }
        public int Deleted { get; set; }
    }
}