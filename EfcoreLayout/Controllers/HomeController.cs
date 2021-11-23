using EfcoreLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreLayout.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeLoanContext _context;


        public HomeController( ILogger<HomeController> logger, HomeLoanContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EMI()
        {
            return View();
        }

        
        public IActionResult Calculator()
        {
            return View();
        }

        public IActionResult Eligiblity()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Aboutus()
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
