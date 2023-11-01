using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger,
                            HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index(List<Category> categoryFromForm)
        {
            List<Category> categories = _homeService.ChangeName();
            var product = _homeService.Get(2);
            return View(categories);
        }

        public IActionResult Privacy()
        {
            //Product product = null;
            //_homeService.Add(product);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}