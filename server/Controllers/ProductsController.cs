using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models.Domain;
using server.Services;

namespace server.controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]Product product)
        {
            try
            {
                await _productsService.CreateProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await _productsService.GetProducts());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("{SKU}")]
        public async Task<IActionResult> GetProduct(int SKU)
        {
            try
            {
                return Ok(await _productsService.GetProduct(SKU));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        [Route("{SKU}")]
        public async Task<IActionResult> UpdateProduct(int SKU, [FromBody]Product product)
        {
            try
            {
                await _productsService.UpdateProduct(SKU, product);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        [Route("{SKU}")]
        public async Task<IActionResult> DeleteProduct(int SKU)
        {
            try
            {
                await _productsService.DeleteProduct(SKU);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}