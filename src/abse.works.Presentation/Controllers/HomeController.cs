using Microsoft.AspNetCore.Mvc;
using abse.works.Application.Interfaces;
using abse.works.Application.ViewModels;
using abse.works.Application.ViewModels.HomePage;
using abse.works.Web.Helpers;
using System.Diagnostics;

namespace abse.works.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly ResultHandler _resultHandler;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, ResultHandler resultHandler)
        {
            _logger = logger;
            _homeService = homeService;
            _resultHandler = resultHandler;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            return View(homeViewModel);
        }

        public async Task<IActionResult> JobOffers(int page = 1, int pageSize = 10)
        {
            var model = _resultHandler.Handle(await _homeService.GetJobOffers(page, pageSize));
            return View(model);
        }

        public async Task<IActionResult> JobOfferDetails(int id)
        {
            var model = _resultHandler.Handle(await _homeService.GetJobOfferDetails(id));
            return View(model);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
