using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Interfaces.Services
{
    public interface ISalesService
    {
        //se crea la firma de los metodos que se va a utilizar

        Sales Create(Sales sale);

        void Update(Sales sale);

        Task<Sales> Delete(int saleId);

        Task<IEnumerable<Sales>> GetAll();
    }
}
