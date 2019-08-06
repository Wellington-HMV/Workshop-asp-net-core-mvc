using System;
using system_sales_and_shopping.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using system_sales_and_shopping.Models;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]//indicando que o metodo é post
        [ValidateAntiForgeryToken]//prevenção de ataque CSRF
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}