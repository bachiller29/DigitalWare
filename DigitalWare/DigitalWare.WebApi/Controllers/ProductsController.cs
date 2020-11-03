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
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProduct()
        {
            var result = await _productsService.GetAll();
            return result.ToList();
        }

        // GET api/<ProductsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/Products
        [HttpPost]
        public async Task<ActionResult<Products>> PostProduct(Products products)
        {
            var result = _productsService.Create(products);
            return result;
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Products product)
        {
            if (id != product.IdProduc) return BadRequest();

            try
            {
                _productsService.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return NoContent();
        }

        // DELETE api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProduct(int id)
        {
            var product = await _productsService.Delete(id);
            if (product == null) return NotFound();
            return product;
        }
    }
}
