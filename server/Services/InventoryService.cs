using System;
using System.Threading.Tasks;
using server.Models.Domain;
using server.Repositories;

namespace server.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _iInventoryRepository;
        public InventoryService(IInventoryRepository iInventoryRepository)
        {
            _iInventoryRepository = iInventoryRepository;
        }

        public async Task CreateInventory(InventoryTO inventory)
        {
            inventory.DateLastUpdated = DateTime.Now;
            await _iInventoryRepository.CreateInventory(new Inventory(inventory));
        }

        public async Task AddQuantity(double SKU, int amount)
        {
            await _iInventoryRepository.AddQuantity(SKU, amount);
        }

        public async Task<DateTime> GetDateLastUpdated(int inventoryId)
        {
            return await _iInventoryRepository.GetDateLastUpdated(inventoryId);
        }

        public async Task SetQuantity(double SKU, int amount)
        {
            await _iInventoryRepository.SetQuantity(SKU, amount);
        }

        public async Task<double> GetQuantity(double SKU)
        {
            return await _iInventoryRepository.GetQuantityBySKU(SKU);
        }

        public async Task SubtractQuantity(double SKU, int amount)
        {
            await _iInventoryRepository.SubtractQuantity(SKU, amount);
        }
    }
}