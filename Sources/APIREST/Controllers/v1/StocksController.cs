using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstracts;

namespace MONAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StocksController : Controller
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // GET: Stocks
        [HttpGet]
        public ActionResult Index()
        {
            var stock = _stockService.GetAll();
            return Ok(stock);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stock = _stockService.GetById(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public async Task<ActionResult<StockDTO>> Create([FromBody] StockDTO stock)
        {
            _stockService.Create(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StockDTO stock)
        {
            var existingStock = _stockService.GetById(id);
            if (existingStock == null)
            {
                return NotFound();
            }
            _stockService.Update(stock);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStock = _stockService.GetById(id);
            if (existingStock == null)
            {
                return NotFound();
            }
            _stockService.Delete(existingStock);
            return NoContent();
        }
    }
}