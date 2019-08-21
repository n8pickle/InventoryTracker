using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Domain;
using server.Repositories;

namespace server.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task CreateProduct(Product product)
        {
            await _productsRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int SKU)
        {
            await _productsRepository.DeleteProduct(SKU);
        }

        public async Task<Product> GetProduct(int SKU)
        {
            return await _productsRepository.GetProduct(SKU);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productsRepository.GetProducts();
        }

        public async Task UpdateProduct(int SKU, Product product)
        {
            await _productsRepository.UpdateProduct(SKU, product);
        }
    }
}