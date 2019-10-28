using System.Collections.Generic;
using server.Models.Domain;

namespace server.Models
{
    public class ProductTO
    {
        public ProductTO()
        {

        }
        public ProductTO(Product product)
        {
            this.Quantity = 0;
            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            this.NotificationQuantity = product.NotificationQuantity;
            this.Color = product.Color;
            this.TrimColor = product.TrimColor;
            this.Size = product.Size;
            this.Price = product.Price;
            this.Dimensions = product.Dimensions;
            this.SKU = product.SKU;
            this.Deleted = product.Deleted;
        }
        public int Quantity { get; set; }
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