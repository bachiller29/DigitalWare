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
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            var result = await _clientService.GetAll();
            return result.ToList();
        }

        // GET api/<ClientController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Client>> PostClien(Client client)
        {
            var result = _clientService.Create(client);
            return result;
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Client client)
        {
            if (id != client.IdClient) return BadRequest();

            try
            {
                _clientService.Update(client);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClien(int id)
        {
            var client = await _clientService.Delete(id);
            if (client == null) return NotFound();
            return client;
        }
    }
}
