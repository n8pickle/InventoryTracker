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

        public async Task CreateInventory(Inventory inventory)
        {
            inventory.DateLastUpdated = DateTime.Now;
            await _iInventoryRepository.CreateInventory(inventory);
        }

        public async Task AddQuantity(int inventoryId, int amount)
        {
            await _iInventoryRepository.AddQuantity(inventoryId, amount);
        }

        public async Task<DateTime> GetDateLastUpdated(int inventoryId)
        {
            return await _iInventoryRepository.GetDateLastUpdated(inventoryId);
        }

        public async Task SetQuantity(int inventoryId, int amount)
        {
            await _iInventoryRepository.SetQuantity(inventoryId, amount);
        }

        public async Task<int> GetQuantity(int inventoryId)
        {
            return await _iInventoryRepository.GetQuantity(inventoryId);
        }

        public async Task SubtractQuantity(int inventoryId, int amount)
        {
            await _iInventoryRepository.SubtractQuantity(inventoryId, amount);
        }
    }
}