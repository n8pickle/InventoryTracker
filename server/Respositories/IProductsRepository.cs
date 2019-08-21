using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IProductsRepository
    {
        Task CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int SKU);
        Task UpdateProduct(int SKU, Product product);
        Task DeleteProduct(int SKU);
    }
}