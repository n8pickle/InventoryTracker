using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _iInventoryService;
        public InventoryController(IInventoryService iInventoryService)
        {
            _iInventoryService = iInventoryService;
        }

        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> AddQuantity(int productId, [FromBody]int amount)
        {
            try
            {
                await _iInventoryService.AddQuantity(productId, amount);
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
                return Ok(await _iInventoryService.GetDateLastUpdated(productId));
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
                return Ok(await _iInventoryService.GetQuantity(productId));
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
                await _iInventoryService.SubtractQuantity(productId, amount);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}