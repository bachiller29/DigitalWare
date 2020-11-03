using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Interfaces.Repositories
{
    public interface IClientRepository : IDisposable
    {
        //se crea la firma de los metodos que se va a utilizar

        Client Create(Client client);

        void Update(Client client);

        Task<Client> Delete(int clientId);

        Task<IEnumerable<Client>> GetAll();
    }
}
