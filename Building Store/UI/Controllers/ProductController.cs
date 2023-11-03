using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<HomeController> logger,
                            ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product productFromForm)
        {
            _productService.Add(productFromForm);
            return RedirectToAction("Index");
        }
    }
}