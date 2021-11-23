using EfcoreLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreLayout.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HomeLoanContext db;

        public CustomerController(HomeLoanContext context)
        {
            db = context;
        }

        public IActionResult CusIndex()
        {
            return View();
        }

        private readonly HomeLoanContext _context;
        

        
        

        
    }
}
