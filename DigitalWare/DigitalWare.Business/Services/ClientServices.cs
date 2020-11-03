using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Business.Interfaces.Services;
using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Services
{
    public class ClientServices : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientServices(IClientRepository repository)
        {
            _repo = repository;
        }

        public Client Create(Client client)
        {
            return _repo.Create(client);
        }

        public async Task<Client> Delete(int clientId)
        {
            return await _repo.Delete(clientId);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _repo.GetAll();
        }

        public void Update(Client client)
        {
            _repo.Update(client);
        }
    }
}
