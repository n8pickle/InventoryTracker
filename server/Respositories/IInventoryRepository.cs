using System;
using System.Threading.Tasks;

namespace server.Repositories
{
    public interface IInventoryRepository
    {
        Task<int> GetQuantity(int productId);
        Task<DateTime> GetDateLastUpdated(int productId);
        Task AddQuantity(int productId, int amount);
        Task SubtractQuantity(int productId, int amount);
    }
}