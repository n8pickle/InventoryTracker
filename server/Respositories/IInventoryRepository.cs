using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IInventoryRepository
    {
        Task CreateInventory(Inventory inventory);
        Task<int> GetQuantityBySKU(int SKU);
        Task<int> GetQuantityByProductId(int productId);
        Task<DateTime> GetDateLastUpdated(int inventoryId);
        Task SetQuantity(int SKU, int amount);
        Task AddQuantity(int SKU, int amount);
        Task SubtractQuantity(int SKU, int amount);
    }
}