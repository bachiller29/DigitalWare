using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Interfaces.Repositories
{
    public interface IProductsRepository : IDisposable
    {
        //se crea la firma de los metodos que se va a utilizar

        Products Create(Products product);

        void Update(Products product);

        Task<Products> Delete(int productId);

        Task<IEnumerable<Products>> GetAll();
    }
}
