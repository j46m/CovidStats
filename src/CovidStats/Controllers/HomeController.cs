using CovidStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace CovidStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportBuilder _reportBuilder;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileGetter _fileGetter;

        public HomeController(ILogger<HomeController> logger, IReportBuilder reportBuilder, IWebHostEnvironment webHostEnvironment, IFileGetter fileGetter)
        {
            _logger = logger;
            _reportBuilder = reportBuilder;
            _webHostEnvironment = webHostEnvironment;
            _fileGetter = fileGetter;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reportBuilder.GetReportData();
            return View(model);
        }

        public async Task<IActionResult> Details(string regionIso)
        {
            var param = $"?iso={regionIso}";
            var model = await _reportBuilder.GetReportData(param);
            return View(model);
        }

        public async Task<IActionResult> DownloadFile(string fileExtension)
        {
            var path = GetFilePath();
            var (fileType, fileData, fileName) = await _fileGetter.GetFile(path, fileExtension);
            return File(fileData, fileType, fileName);
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

        private string GetFilePath()
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(webRootPath, "files");
            return path;
        }
    }
}
