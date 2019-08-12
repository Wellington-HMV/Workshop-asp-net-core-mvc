using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system_sales_and_shopping.Models;
using system_sales_and_shopping.Services.Exception;

namespace system_sales_and_shopping.Services
{
    public class SellerService
    {
        private readonly system_sales_and_shoppingContext _context;
        public SellerService(system_sales_and_shoppingContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById (int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
