﻿using BusinessLogic;
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

        public IActionResult FilterBy(string categoryName)
        {
            var products = _productService.FilterBy(categoryName);
            return View("Index", products);
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

        public IActionResult Edit(int productId)
        {
            var product = _productService.Get(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product productFromForm)
        {
            _productService.Edit(productFromForm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return RedirectToAction("Index");
        }
    }
}