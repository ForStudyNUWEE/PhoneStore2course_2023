using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryService _categoryService;

        public CategoryController(ILogger<HomeController> logger,
                            CategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index(List<Category> categoryFromForm)
        {
            return View();
        }
    }
}