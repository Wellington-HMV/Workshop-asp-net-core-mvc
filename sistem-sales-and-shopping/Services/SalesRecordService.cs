using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system_sales_and_shopping.Models;
using Microsoft.EntityFrameworkCore;

namespace system_sales_and_shopping.Services
{
    public class SalesRecordService
    {
        private readonly system_sales_and_shoppingContext _context;
        public SalesRecordService(system_sales_and_shoppingContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime ? minDate, DateTime ? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x=>x.Seller)
                .Include(x=>x.Seller.Department)
                .OrderByDescending(x=>x.Date)
                .ToListAsync();
        }
    }
}
