using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system_sales_and_shopping.Models;
using system_sales_and_shopping.Services.Exception;
using Microsoft.EntityFrameworkCore;

namespace system_sales_and_shopping.Services
{
    public class SellerService
    {
        private readonly system_sales_and_shoppingContext _context;
        public SellerService(system_sales_and_shoppingContext context)
        {
            _context = context;
        }
        public async Task<List<Seller>> FindAllAsync()//transformando a operação em assincrona que neste caso ela espera para ser executada
        {                                             //aumentando a performace da aplicação
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seller obj)
        {
            bool hasany = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasany)
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
