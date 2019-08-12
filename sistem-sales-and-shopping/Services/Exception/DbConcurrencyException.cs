using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace system_sales_and_shopping.Services.Exception
{
    public class DbConcurrencyException: ApplicationException
    {
        public DbConcurrencyException(string message) : base(message) { }
    }
}
