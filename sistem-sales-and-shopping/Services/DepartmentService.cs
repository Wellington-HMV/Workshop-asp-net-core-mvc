using system_sales_and_shopping.Models;
using System.Collections.Generic;
using System.Linq;

namespace system_sales_and_shopping.Services
{
    public class DepartmentService
    {
        private readonly system_sales_and_shoppingContext _context;
        public DepartmentService(system_sales_and_shoppingContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
