using system_sales_and_shopping.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace system_sales_and_shopping.Services
{
    public class DepartmentService
    {
        private readonly system_sales_and_shoppingContext _context;
        public DepartmentService(system_sales_and_shoppingContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()//incluindo o task para que seja implementado de forma assicrona
        {
            return  await _context.Department.OrderBy(x => x.Name).ToListAsync();//await para avisa o compilador que é uma chamada asincrona
        }
    }
}
