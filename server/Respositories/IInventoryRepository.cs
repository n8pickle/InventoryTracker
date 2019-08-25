using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IInventoryRepository
    {
        Task CreateInventory(Inventory inventory);
        Task<int> GetQuantity(int inventoryId);
        Task<DateTime> GetDateLastUpdated(int inventoryId);
        Task SetQuantity(int inventoryId, int amount);
        Task AddQuantity(int inventoryId, int amount);
        Task SubtractQuantity(int inventoryId, int amount);
    }
}