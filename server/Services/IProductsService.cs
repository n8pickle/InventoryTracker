using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Models.Domain;

namespace server.Services
{
    public interface IProductsService
    {
        Task CreateProduct(ProductTO product);
        Task<List<ProductTO>> GetProducts();
        Task<ProductTO> GetProduct(double SKU);
        Task UpdateProduct(double SKU, ProductTO product);
        Task DeleteProduct(double SKU);

    }
}