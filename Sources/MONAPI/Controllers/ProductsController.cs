using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MONAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>>  Create([FromBody] ProductDTO product)
        {
            _productService.Create(product);
            return  CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO product)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            _productService.Delete(existingProduct);
            return NoContent();
        }
    }

}

