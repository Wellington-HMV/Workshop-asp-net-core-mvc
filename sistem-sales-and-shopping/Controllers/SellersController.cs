using System;
using system_sales_and_shopping.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using system_sales_and_shopping.Models;
using system_sales_and_shopping.Models.ViewModels;

namespace system_sales_and_shopping.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService; // injeção de dependencia
            _departmentService = departmentService;
        }
        public IActionResult Index() // controlador
        {
            var list = _sellerService.FindAll();//model
            return View(list);//view
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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