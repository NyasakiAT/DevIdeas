using DevIdeas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevIdeas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DbAccess db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = new DbAccess();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View(new ProjectsViewModel()
            {
                DbEntries = db.GetAllEntries()
            });
        }

        [HttpPost]
        public IActionResult Index(FormModel model)
        {
            return Content($"Hello {model.Title}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
