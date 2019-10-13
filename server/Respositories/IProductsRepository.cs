using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Domain;

namespace server.Repositories
{
    public interface IProductsRepository
    {
        Task CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(double SKU);
        Task UpdateProduct(double SKU, Product product);
        Task DeleteProduct(double SKU);
    }
}