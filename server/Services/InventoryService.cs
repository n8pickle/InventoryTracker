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

        public async Task AddQuantity(int SKU, int inventoryId, int amount)
        {
            await _iInventoryRepository.AddQuantity(SKU, inventoryId, amount);
        }

        public async Task<DateTime> GetDateLastUpdated(int inventoryId)
        {
            return await _iInventoryRepository.GetDateLastUpdated(inventoryId);
        }

        public async Task SetQuantity(int SKU, int inventoryId, int amount)
        {
            await _iInventoryRepository.SetQuantity(SKU, inventoryId, amount);
        }

        public async Task<int> GetQuantity(int SKU, int inventoryId)
        {
            return await _iInventoryRepository.GetQuantity(SKU, inventoryId);
        }

        public async Task SubtractQuantity(int SKU, int inventoryId, int amount)
        {
            await _iInventoryRepository.SubtractQuantity(SKU, inventoryId, amount);
        }
    }
}