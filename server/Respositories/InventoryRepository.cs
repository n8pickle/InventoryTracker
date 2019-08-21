using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models.Database;

namespace server.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly MySqlDbContext _mySqlDbContext;
        public InventoryRepository(MySqlDbContext mySqlContext)
        {
            _mySqlDbContext = mySqlContext;
        }
        public async Task AddQuantity(int productId, int amount)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.ProductID == productId).FirstOrDefaultAsync();
            result.Quantity += amount;
            _mySqlDbContext.SaveChanges();
        }

        public async Task<DateTime> GetDateLastUpdated(int productId)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.ProductID == productId).FirstOrDefaultAsync();
            return result.DateLastUpdated;
        }

        public async Task<int> GetQuantity(int productId)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.ProductID == productId).FirstOrDefaultAsync();
            return result.Quantity;
        }

        public async Task SubtractQuantity(int productId, int amount)
        {
            var result = await _mySqlDbContext.Inventory.Where(p => p.ProductID == productId).FirstOrDefaultAsync();
            result.Quantity -= amount;
            _mySqlDbContext.SaveChanges();
        }
    }
}