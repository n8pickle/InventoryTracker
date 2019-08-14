using System;

namespace server.Models.Domain
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public int ProductID { get; set; }
        public int Deleted { get; set; }
    }
}