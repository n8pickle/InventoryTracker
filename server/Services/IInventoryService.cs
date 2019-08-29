using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Services
{
    public interface IInventoryService
    {
        Task CreateInventory(InventoryTO inventory);
        Task<int> GetQuantity(int SKU);
        Task<DateTime> GetDateLastUpdated(int inventoryId);
        Task SetQuantity(int SKU, int amount);
        Task AddQuantity(int SKU, int amount);
        Task SubtractQuantity(int SKU, int amount);
    }
}