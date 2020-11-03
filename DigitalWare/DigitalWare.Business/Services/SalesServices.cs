using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Business.Interfaces.Services;
using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Services
{
    public class SalesServices : ISalesService
    {
        //inyecccion de dependencias union con el proyecto de Data
        private readonly ISalesRepository _repo;

        public SalesServices(ISalesRepository repository)
        {
            _repo = repository;
        }

        public Sales Create(Sales sale)
        {
            return _repo.Create(sale);
        }

        public async Task<Sales> Delete(int saleId)
        {
            return await _repo.Delete(saleId);
        }

        public async Task<IEnumerable<Sales>> GetAll()
        {
            return await _repo.GetAll();
        }

        public void Update(Sales sale)
        {
            _repo.Update(sale);
        }
    }
}
