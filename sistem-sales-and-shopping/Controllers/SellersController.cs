using System;
using system_sales_and_shopping.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace system_sales_and_shopping.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService; // injeção de dependencia
        }
        public IActionResult Index() // controlador
        {
            var list = _sellerService.FindAll();//model
            return View(list);//view
        }
    }
}