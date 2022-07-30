using Microsoft.AspNetCore.Mvc;
using ProjectDemo.DTOs;
using ProjectDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<ProductDTO> GetAllProduct()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public ProductDTO GetProductById(int Id)
        {
            return _service.GetById(Id);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                _service.Add(productDTO);
                Console.WriteLine("Hello");
                return Ok();
            }
            return BadRequest();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int Id)
        {
            _service.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDTO productDTO)
        {
            _service.Update(productDTO);
            return Ok();
        }
    }
}
