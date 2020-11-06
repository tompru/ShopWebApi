using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            var allOrders = orderRepository.GetAllOrders();
            if (!allOrders.Any())
            {
                return NotFound();
            }
            return Ok(allOrders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int clientId)
        {
            var clientOrders = orderRepository.GetClientOrders(clientId);
            if (!clientOrders.Any())
            {
                return NotFound();
            }
            return Ok(clientOrders);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post(AddOrderModel addOrderModel)
        {
            try
            {
                var result = orderRepository.AddOrder(addOrderModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured during adding new product.\n{ex.Message}");
            }
        }




/*        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
