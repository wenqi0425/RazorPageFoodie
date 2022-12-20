using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RazorPageFoodie.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageFoodie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
        [BindProperty]
        public RideCriteriaInputModel RideCriteria { get; set; } = new RideCriteriaInputModel();

        public IndexModel(ILogger<IndexModel> logger, IRideService service)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RideCriteria.StartTime = DateTime.Now;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Rides/GetRides", RideCriteria);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
