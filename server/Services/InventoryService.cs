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

        public async Task AddQuantity(int SKU, int amount)
        {
            await _iInventoryRepository.AddQuantity(SKU, amount);
        }

        public async Task<DateTime> GetDateLastUpdated(int inventoryId)
        {
            return await _iInventoryRepository.GetDateLastUpdated(inventoryId);
        }

        public async Task SetQuantity(int SKU, int amount)
        {
            await _iInventoryRepository.SetQuantity(SKU, amount);
        }

        public async Task<int> GetQuantity(int SKU)
        {
            return await _iInventoryRepository.GetQuantityBySKU(SKU);
        }

        public async Task SubtractQuantity(int SKU, int amount)
        {
            await _iInventoryRepository.SubtractQuantity(SKU, amount);
        }
    }
}