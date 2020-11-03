using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Business.Interfaces.Services;
using DigitalWare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Business.Services
{
    public class ProductsServices : IProductsService
    {
        //inyecccion de dependencias union con el proyecto de Data
        private readonly IProductsRepository _repo;

        public ProductsServices(IProductsRepository repository)
        {
            _repo = repository;
        }

        public Products Create(Products product)
        {
            return _repo.Create(product);
        }

        public async Task<Products> Delete(int productId)
        {
            return await _repo.Delete(productId);
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _repo.GetAll();
        }

        public void Update(Products product)
        {
            _repo.Update(product);
        }
    }
}
