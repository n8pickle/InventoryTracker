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
        [Route("{inventoryId}")]
        public async Task<IActionResult> AddQuantity(int inventoryId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.AddQuantity(inventoryId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("{inventoryId}")]
        public async Task<IActionResult> GetDateLastUpdated(int inventoryId)
        {
            try
            {
                return Ok(await _inventoryService.GetDateLastUpdated(inventoryId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{inventoryId}")]
        public async Task<IActionResult> SetQuantity(int inventoryId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.SetQuantity(inventoryId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQuantity(int inventoryId)
        {
            try
            {
                return Ok(await _inventoryService.GetQuantity(inventoryId));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{inventoryId")]
        public async Task<IActionResult> SubtractQuantity(int inventoryId, [FromBody]int amount)
        {
            try
            {
                await _inventoryService.SubtractQuantity(inventoryId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}