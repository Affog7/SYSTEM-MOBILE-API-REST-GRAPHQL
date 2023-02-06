using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Abstracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MONAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            ILogger<ProductsController> logger, IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int page, int taille)
        {

           

            var products = _productService.GetAll();
            var resources = products
             .Skip((page - 1) * taille)
             .Take(taille)
             .ToList();

            _logger.LogInformation("Fectching....");

            return Ok(new
            {
                data = resources,
                totalPages = Math.Ceiling((double) products.Count() / taille),
                page,
                total = resources.Count,
                taille
            });

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

