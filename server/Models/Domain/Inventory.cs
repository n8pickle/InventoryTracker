using System;

namespace server.Models.Domain
{
    public class Inventory
    {
        private InventoryTO inventory;

        public Inventory() { }

        public Inventory(InventoryTO inventory)
        {
            this.inventory = inventory;
        }

        public Inventory(Product p, int quantity, DateTime dateLastUpdated)
        {
            this.product = p;
            this.Quantity = quantity;
            this.DateLastUpdated = dateLastUpdated;
        }

        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ProductID { get; set; }
        public Product product { get; set; }
        public int Deleted { get; set; }
    }
}