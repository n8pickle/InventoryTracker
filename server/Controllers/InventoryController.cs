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
        public async Task<IActionResult> CreateInventory([FromBody]InventoryTO inventory)
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
        [Route("{SKU}/add/{amount}")]
        public async Task<IActionResult> AddQuantity(double SKU, int amount)
        {
            try
            {
                await _inventoryService.AddQuantity(SKU, amount);
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
        [Route("{SKU}/set/{amount}")]
        public async Task<IActionResult> SetQuantity(double SKU, int amount)
        {
            try
            {
                await _inventoryService.SetQuantity(SKU, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQuantity([FromBody]double SKU)
        {
            try
            {
                return Ok(await _inventoryService.GetQuantity(SKU));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("{SKU}/sbt/{amount}")]
        public async Task<IActionResult> SubtractQuantity(double SKU, int amount)
        {
            try
            {
                await _inventoryService.SubtractQuantity(SKU, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}