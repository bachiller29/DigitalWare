using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BillingContext _context;

        public ClientRepository(BillingContext context)
        {
            _context = context;
        }

        //cierre de coneccion segura
        public void Dispose()
        {
            _context.Dispose();
        }

        public Client Create(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
            return client;
        }

        public async Task<Client> Delete(int clientId)
        {
            var client = await _context.Client.FindAsync(clientId);
            if (client == null) return null;

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Client.ToListAsync();
        }

        public void Update(Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }
    }
}
