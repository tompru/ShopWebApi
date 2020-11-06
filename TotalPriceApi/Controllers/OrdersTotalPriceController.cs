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
        public IActionResult Post(List<ProductModel> products)
        {
            if (!products.Any())
            {
                return BadRequest("Product list can not be empty.");
            }
            var totalPriceHelper = new TotalPriceHelper();
            var totalPrice = Math.Round(totalPriceHelper.CalculateTotalPrice(products),2);
            return Ok(totalPrice);
        }

/*        // GET api/<OrdersTotalPriceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersTotalPriceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersTotalPriceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersTotalPriceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
