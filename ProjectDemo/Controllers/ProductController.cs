using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.DTOs;
using ProjectDemo.Models;
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
        [Route("add")]
        public ActionResult AddProduct([FromForm] ProductDTO productDTO)
        {
           
            if (ModelState.IsValid)
            {
                if (_service.Add(productDTO) == ActionStatus.Success)
                    return Ok(ModelState);
                else
                    return BadRequest(ModelState);
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int Id)
        {
            if (ModelState.IsValid)
            {
                if (_service.Delete(Id) == ActionStatus.Success)
                    return Ok(ModelState);
                else
                    return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromForm] ProductDTO productDTO)
        {
            
            if (ModelState.IsValid)
            {
                if (_service.Update(productDTO)== ActionStatus.Success)
                    return Ok(ModelState);
                else
                    return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
           
        }
    }
}
