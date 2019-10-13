using System;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Services
{
    public interface IInventoryService
    {
        Task CreateInventory(InventoryTO inventory);
        Task<double> GetQuantity(double SKU);
        Task<DateTime> GetDateLastUpdated(int inventoryId);
        Task SetQuantity(double SKU, int amount);
        Task AddQuantity(double SKU, int amount);
        Task SubtractQuantity(double SKU, int amount);
    }
}