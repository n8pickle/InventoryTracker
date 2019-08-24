using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IInventoryRepository
    {
        Task CreateInventory(Inventory inventory);
        Task<int> GetQuantity(int productId);
        Task<DateTime> GetDateLastUpdated(int productId);
        Task SetQuantity(int productId, int amount);
        Task AddQuantity(int productId, int amount);
        Task SubtractQuantity(int productId, int amount);
    }
}