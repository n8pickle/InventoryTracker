using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models.Domain;
using server.Services;

namespace server.controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody]Inventory inventory)
        {
            try
            {
                await _inventoryService.CreateInventory(inventory);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> AddQuantity(int productId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.AddQuantity(productId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetDateLastUpdated(int productId)
        {
            try
            {
                return Ok(await _inventoryService.GetDateLastUpdated(productId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> SetQuantity(int productId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.SetQuantity(productId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQuantity(int productId)
        {
            try
            {
                return Ok(await _inventoryService.GetQuantity(productId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> SubtractQuantity(int productId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.SubtractQuantity(productId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}