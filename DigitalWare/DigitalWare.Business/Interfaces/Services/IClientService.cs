using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Interfaces.Services
{
    public interface IClientService
    {
        //se crea la firma de los metodos que se va a utilizar

        Client Create(Client client);

        void Update(Client client);

        Task<Client> Delete(int clientId);

        Task<IEnumerable<Client>> GetAll();
    }
}
