using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models.Database;
using server.Models.Domain;

namespace server.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MySqlDbContext _mySqlDbContext;
        public ProductsRepository(MySqlDbContext mySqlDbContext)
        {
            _mySqlDbContext = mySqlDbContext;
        }
        public async Task CreateProduct(Product product)
        {
            await _mySqlDbContext.Product.AddAsync(product);
            await _mySqlDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(double SKU)
        {
            return await _mySqlDbContext.Product.Where(p => p.SKU == SKU && p.Deleted != 1).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _mySqlDbContext.Product.ToListAsync();
        }

        public async Task DeleteProduct(double SKU)
        {
            var result = await _mySqlDbContext.Product.Where(p => p.SKU == SKU && p.Deleted != 1).FirstOrDefaultAsync();
            result.Deleted = 1;
            await _mySqlDbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(double SKU, Product product)
        {
            var result = await _mySqlDbContext.Product.Where(p => p.SKU == SKU).FirstOrDefaultAsync();
            result.SKU = product.SKU;
            result.ProductID = product.ProductID;
            result.Price = product.Price;
            result.NotificationQuantity = product.NotificationQuantity;
            result.ProductName = product.ProductName;
            result.Size = product.Size;
            result.TrimColor = product.TrimColor;
            result.Color = product.Color;
            result.Dimensions = product.Dimensions;
            await _mySqlDbContext.SaveChangesAsync();
        }
    }
}