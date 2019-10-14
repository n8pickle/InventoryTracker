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
            Product p = new Product(product);
            await _productsRepository.CreateProduct(p);
            await _inventoryRepository.CreateInventory(new Inventory(p, product.Quantity, DateTime.Now));
        }

        public async Task DeleteProduct(double SKU)
        {
            await _productsRepository.DeleteProduct(SKU);
        }

        public async Task<ProductTO> GetProduct(double SKU)
        {
            ProductTO product = new ProductTO(await _productsRepository.GetProduct(SKU));
            product.Quantity = await _inventoryRepository.GetQuantityByProductId(product.ProductID);
            return product;
        }

        public async Task<List<ProductTO>> GetProducts()
        {
            List<ProductTO> products = new List<ProductTO>();
            foreach (Product p in await _productsRepository.GetProducts())
            {
                ProductTO product = new ProductTO(p);
                if (product.Deleted != 1)
                {
                    product.Quantity = await _inventoryRepository.GetQuantityByProductId(product.ProductID);
                    products.Add(product);
                }
            }
            return products;
        }

        public async Task UpdateProduct(double SKU, ProductTO product)
        {
            await _productsRepository.UpdateProduct(SKU, new Product(product));
            await _inventoryRepository.SetQuantity(SKU, product.Quantity);
        }
    }
}