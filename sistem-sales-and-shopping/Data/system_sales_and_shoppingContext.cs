using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace system_sales_and_shopping.Models
{
    public class system_sales_and_shoppingContext : DbContext
    {
        public system_sales_and_shoppingContext (DbContextOptions<system_sales_and_shoppingContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
