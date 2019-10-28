using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IInventoryRepository
    {
        Task CreateInventory(Inventory inventory);
        Task<int> GetQuantityBySKU(double SKU);
        Task<int> GetQuantityByProductId(int productId);
        Task<DateTime> GetDateLastUpdated(int inventoryId);
        Task SetQuantity(double SKU, int amount);
        Task AddQuantity(double SKU, int amount);
        Task SubtractQuantity(double SKU, int amount);
    }
}