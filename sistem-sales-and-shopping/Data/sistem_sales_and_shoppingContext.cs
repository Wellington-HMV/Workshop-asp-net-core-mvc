using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sistem_sales_and_shopping.Models
{
    public class sistem_sales_and_shoppingContext : DbContext
    {
        public sistem_sales_and_shoppingContext (DbContextOptions<sistem_sales_and_shoppingContext> options)
            : base(options)
        {
        }

        public DbSet<sistem_sales_and_shopping.Models.Department> Department { get; set; }
    }
}
