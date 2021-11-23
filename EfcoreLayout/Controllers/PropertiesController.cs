using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfcoreLayout.Models;

namespace EfcoreLayout.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly HomeLoanContext _context;

        public PropertiesController(HomeLoanContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var pid = (from d in _context.Properties orderby d.PropertyId descending select d.PropertyId).FirstOrDefault();
            var appprop = (from d in _context.IncomeDetails orderby d.ApplicationId descending select d.ApplicationId).FirstOrDefault();
            var appid = (from e in _context.UserDetails orderby e.ApplicationId descending select e.ApplicationId).FirstOrDefault();

            if (appprop != appid)
            {
                return RedirectToAction("create", "properties");
            }
            return RedirectToAction("Details", "properties", new { id = pid });
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertydetails = await _context.Properties
                .Include(l => l.Application)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (propertydetails == null)
            {
                return NotFound();
            }

            return View(propertydetails);
        }

        // GET: Properties/Create
        public IActionResult Create(IncomeDetail incomeDetail)
        {
            TempData["applicationid"] = incomeDetail.ApplicationId;
            TempData.Keep("applicationid");
            ViewBag.ApplicationId = incomeDetail.ApplicationId;
            ViewBag.IncomeID = incomeDetail.IncomeId;
            return View();
        }

        // POST: Properties/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,PropertyNumber,PropertyArea,Pincode,TypeOfProperty,EstimatedCost,ApplicationId")] Property propertydetails)
        {
            var pid = (from d in _context.Properties orderby d.PropertyId descending select d.PropertyId).FirstOrDefault();

            if (pid == 0)
            {
                TempData["propid"] = 5000;
                ViewBag.PropertyID = TempData.Peek("propid");
            }
            else
            {
                TempData["propid"] = ++pid;
                ViewBag.PropertyID = TempData.Peek("propid");
            }
            if (ModelState.IsValid)
            {
                ViewBag.ApplicationID = TempData["applicationid"];
                propertydetails.PropertyId = ViewBag.PropertyID;
                propertydetails.ApplicationId = ViewBag.ApplicationID;
                _context.Add(propertydetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "loandetails", propertydetails);
            }
            return View(propertydetails);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var propertydetails = await _context.Properties.FindAsync(id);
            if (propertydetails == null)
            {
                return NotFound();
            }
            ViewBag.PropertyID = propertydetails.PropertyId;
            ViewBag.ApplicationID = TempData["applicationid"];
            propertydetails.ApplicationId = ViewBag.ApplicationID;
            TempData.Keep();
            return View(propertydetails);
        }

        // POST: Properties/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,PropertyNumber,PropertyArea,Pincode,TypeOfProperty,EstimatedCost,ApplicationId")] Property propertydetails)
        {
                try
                {
                    ViewBag.ApplicationID = TempData["applicationid"];
                    propertydetails.ApplicationId = ViewBag.ApplicationID;
                    _context.Update(propertydetails);
                    await _context.SaveChangesAsync();
                }
                catch (KeyNotFoundException)
                {
                     return NotFound();
                }
            return RedirectToAction("Details", "properties", new { id = propertydetails.PropertyId });
        }
        }
    }
