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

        public async Task AddQuantity(int productId, int amount)
        {
            await _iInventoryRepository.AddQuantity(productId, amount);
        }

        public async Task<DateTime> GetDateLastUpdated(int productId)
        {
            return await _iInventoryRepository.GetDateLastUpdated(productId);
        }

        public async Task SetQuantity(int productId, int amount)
        {
            await _iInventoryRepository.SetQuantity(productId, amount);
        }

        public async Task<int> GetQuantity(int productId)
        {
            return await _iInventoryRepository.GetQuantity(productId);
        }

        public async Task SubtractQuantity(int productId, int amount)
        {
            await _iInventoryRepository.SubtractQuantity(productId, amount);
        }
    }
}