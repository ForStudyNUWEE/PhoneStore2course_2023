using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<HomeController> logger,
                            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> FilterBy(string categoryName)
        {
            var products = await _productService.FilterBy(categoryName);
            return View("Index", products);
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();

            return View(products);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product productFromForm)
        {
            await _productService.Add(productFromForm);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int productId)
        {
            var product = await _productService.Get(productId);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product productFromForm)
        {
            await _productService.Edit(productFromForm);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int productId)
        {
            await _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}