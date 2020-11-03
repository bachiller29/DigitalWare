using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly BillingContext _context;

        public ProductsRepository(BillingContext context)
        {
            _context = context;
        }

        //cierre de coneccion segura
        public void Dispose()
        {
            _context.Dispose();
        }

        public Products Create(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<Products> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public void Update(Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
