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

        public Inventory(int quantity, DateTime dateLastUpdated)
        {
            this.Quantity = quantity;
            this.DateLastUpdated = dateLastUpdated;
        }

        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ProductID { get; set; }
        public int Deleted { get; set; }
    }
}