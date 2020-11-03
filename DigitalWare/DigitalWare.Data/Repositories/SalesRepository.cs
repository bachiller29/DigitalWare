using DigitalWare.Business.Interfaces.Repositories;
using DigitalWare.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly BillingContext _context;

        public SalesRepository(BillingContext context)
        {
            _context = context;
        }

        //cierre de coneccion segura
        public void Dispose()
        {
            _context.Dispose();
        }

        public Sales Create(Sales sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
            return sale;
        }

        public async Task<Sales> Delete(int saleId)
        {
            var sale = await _context.Sales.FindAsync(saleId);
            if (sale == null) return null;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<IEnumerable<Sales>> GetAll()
        {
            return await _context.Sales.ToListAsync();
        }

        public void Update(Sales sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }
    }
}
