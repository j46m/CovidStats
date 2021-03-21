using CovidStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CovidStats.logic.Reports.Interfaces;

namespace CovidStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportBuilder _reportBuilder;

        public HomeController(ILogger<HomeController> logger, IReportBuilder reportBuilder)
        {
            _logger = logger;
            _reportBuilder = reportBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reportBuilder.GetReportData();
            return View(model);
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
