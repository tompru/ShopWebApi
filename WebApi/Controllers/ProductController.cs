
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Authorize(Policy = "Read")]
        public IActionResult Get()
        {
            var allProducts = productRepository.GetAll();
            if (!allProducts.Any())
            {
                return NotFound();
            }
            return Ok(allProducts);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "Read")]
        public IActionResult Get(int productId)
        {
            var product = productRepository.Get(productId);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Authorize(Policy = "Write")]
        public IActionResult Post(AddProductModel addProductModel)
        {
            try
            {
                var result = productRepository.Add(addProductModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured duting adding new product.\n{ex.Message}");
            }            
        }
    }
}
