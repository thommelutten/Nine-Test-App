using MediatR;
using Microsoft.AspNetCore.Mvc;
using NineTestApp.Application.Colors.Queries.GetColors;
using NineTestApp.WebUI.Models;
using System.Diagnostics;

namespace NineTestApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISender _mediator;

        public HomeController(ILogger<HomeController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var colors = await _mediator.Send(new GetColorsQuery());

            var homeViewModel = new HomeViewModel()
            {
                Colors = colors
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
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