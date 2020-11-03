using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWare.Business.Interfaces.Services;
using DigitalWare.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWare.WebApi.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            var result = await _salesService.GetAll();
            return result.ToList();
        }

        // GET api/<SalesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SalesController>

        [HttpPost]
        public async Task<ActionResult<Sales>> PostSale(Sales sale)
        {
            var result = _salesService.Create(sale);
            return result;
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sales sale)
        {
            if (id != sale.IdSales) return BadRequest();

            try
            {
                _salesService.Update(sale);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return NoContent();
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sales>> DeleteSale(int id)
        {
            var sale = await _salesService.Delete(id);
            if (sale == null) return NotFound();

            return sale;
        }
    }
}
