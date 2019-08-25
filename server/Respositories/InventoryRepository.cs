using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models.Database;
using server.Models.Domain;

namespace server.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly MySqlDbContext _mySqlDbContext;
        public InventoryRepository(MySqlDbContext mySqlContext)
        {
            _mySqlDbContext = mySqlContext;
        }
        public async Task CreateInventory(Inventory inventory)
        {
            await _mySqlDbContext.Inventory.AddAsync(inventory);
            await _mySqlDbContext.SaveChangesAsync();
        }
        public async Task AddQuantity(int inventoryId, int amount)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.InventoryID == inventoryId).FirstOrDefaultAsync();
            result.Quantity += amount;
            await _mySqlDbContext.SaveChangesAsync();
        }

        public async Task<DateTime> GetDateLastUpdated(int inventoryId)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.InventoryID == inventoryId).FirstOrDefaultAsync();
            return result.DateLastUpdated;
        }

        public async Task SetQuantity(int inventoryId, int amount)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.InventoryID == inventoryId).FirstOrDefaultAsync();
            result.Quantity = amount;
            await _mySqlDbContext.SaveChangesAsync();
        }

        public async Task<int> GetQuantity(int inventoryId)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.InventoryID == inventoryId).FirstOrDefaultAsync();
            return result.Quantity;
        }

        public async Task SubtractQuantity(int inventoryId, int amount)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.InventoryID == inventoryId).FirstOrDefaultAsync();
            result.Quantity -= amount;
            await _mySqlDbContext.SaveChangesAsync();
        }
    }
}