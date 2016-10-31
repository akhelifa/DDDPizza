using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DDDPizzaInc.ApplicationServices;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.Api.Controllers
{
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("api/inventory")]
        public async Task<IHttpActionResult> GetFullInventory()
        {
            try
            {
                var cheese = await _inventoryService.GetCheeses();
                var bread = await _inventoryService.GetBreads();
                var sauce = await _inventoryService.GetSauces();
                var topping = await _inventoryService.GetToppings();
                var size = await _inventoryService.GetSizes();

                var lookup = new FullInventoryVm
                {
                    Cheeses = cheese.ToList(),
                    Breads = bread.ToList(),
                    Sauces = sauce.ToList(),
                    Toppings = topping.ToList(),
                    Sizes = size.ToList()                  
                };

                return Ok(lookup);
            }
            catch (Exception)
            {
                // TODO: Add Raygun
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/inventory/breads")]
        public async Task<IHttpActionResult> GetBreads()
        {
            var result = await _inventoryService.GetBreads();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/breads/{id}", Name = "GetBreadById")]
        public async Task<IHttpActionResult> GetBreadById(string id)
        {
            var result = await _inventoryService.GetBreadById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/cheeses")]
        public async Task<IHttpActionResult> GetCheeses()
        {
            var result = await _inventoryService.GetCheeses();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/cheeses/{id}", Name = "GetCheeseById")]
        public async Task<IHttpActionResult> GetCheeseById(string id)
        {
            var result = await _inventoryService.GetCheeseById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/sauces")]
        public async Task<IHttpActionResult> GetSauces()
        {
            var result = await _inventoryService.GetSauces();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/sauces/{id}", Name = "GetSaucesById")]
        public async Task<IHttpActionResult> GetSaucesById(string id)
        {
            var result = await _inventoryService.GetSauceById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/toppings")]
        public async Task<IHttpActionResult> GetToppings()
        {
            var result = await _inventoryService.GetToppings();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/toppings/{id}", Name = "GetToppingsById")]
        public async Task<IHttpActionResult> GetToppingsById(string id)
        {
            var result = await _inventoryService.GetToppingById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/sizes")]
        public async Task<IHttpActionResult> GetSizes()
        {
            var result = await _inventoryService.GetSizes();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/inventory/sizes/{id}", Name = "GetSizesById")]
        public async Task<IHttpActionResult> GetSizesById(string id)
        {
            var result = await _inventoryService.GetSizeById(id);
            return Ok(result);
        }
    }
}