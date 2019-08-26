using System;

namespace server.Models.Domain
{
    public class InventoryTO
    {
        public InventoryTO() { }
        public InventoryTO(int quantity, DateTime dateLastUpdated)
        {
            Quantity = quantity;
            DateLastUpdated = dateLastUpdated;
        }
        public int SKU { get; set; }
        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ProductID { get; set; }
        public int Deleted { get; set; }
    }
}