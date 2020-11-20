using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TotalPriceApi.Logic;
using TotalPriceApi.Models;

namespace TotalPriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersTotalPriceController : ControllerBase
    {
        // POST: api/<OrdersTotalPriceController>
        [HttpPost]
        public IActionResult Post(AddOrderModel addOrderModel)
        {
            if (!addOrderModel.Products.Any())
            {
                return BadRequest("Product list can not be empty.");
            }
            var totalPriceHelper = new TotalPriceHelper(addOrderModel.Client.Id);
            var totalPrice = Math.Round(totalPriceHelper.CalculateTotalPrice(addOrderModel.Products),2);
            return Ok(totalPrice);
        }
    }
}
