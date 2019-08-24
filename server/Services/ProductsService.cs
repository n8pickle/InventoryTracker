using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using server.Models.Domain;
using server.Repositories;

namespace server.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IInventoryRepository _inventoryRepository;
        public ProductsService(IProductsRepository productsRepository, IInventoryRepository inventoryRepository)
        {

            _productsRepository = productsRepository;
            _inventoryRepository = inventoryRepository;
        }
        public async Task CreateProduct(ProductTO product)
        {
            await _productsRepository.CreateProduct(new Product(product));
            await _inventoryRepository.CreateInventory(new Inventory(product.Quantity, DateTime.Now));
        }

        public async Task DeleteProduct(int SKU)
        {
            await _productsRepository.DeleteProduct(SKU);
        }

        public async Task<ProductTO> GetProduct(int SKU)
        {
            ProductTO product = new ProductTO(await _productsRepository.GetProduct(SKU));
            product.Quantity = await _inventoryRepository.GetQuantity(product.ProductID);
            return product;
        }

        public async Task<List<ProductTO>> GetProducts()
        {
            List<ProductTO> products = new List<ProductTO>();
            foreach (Product p in await _productsRepository.GetProducts())
            {
                ProductTO product = new ProductTO(p);
                product.Quantity = await _inventoryRepository.GetQuantity(product.ProductID);
                products.Add(product);
            }
            return products;
        }

        public async Task UpdateProduct(int SKU, ProductTO product)
        {
            await _productsRepository.UpdateProduct(SKU, new Product(product));
            await _inventoryRepository.AddQuantity(product.ProductID, product.Quantity);
        }
    }
}