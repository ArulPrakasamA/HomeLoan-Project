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
    public class IncomeDetailsController : Controller
    {
        private readonly HomeLoanContext _context;
        

        public IncomeDetailsController(HomeLoanContext context)
        {
            _context = context;
        }

        // GET: IncomeDetails
        public async Task<IActionResult> Index()
        {

            var Incid = (from d in _context.IncomeDetails orderby d.IncomeId descending select d.IncomeId).FirstOrDefault();
            var appinc = (from d in _context.IncomeDetails orderby d.ApplicationId descending select d.ApplicationId).FirstOrDefault();
            var appid = (from e in _context.UserDetails orderby e.ApplicationId descending select e.ApplicationId).FirstOrDefault();

            if(appinc!=appid)
            {
                return RedirectToAction("create", "incomedetails");
            }

            return RedirectToAction("Details", "incomedetails", new { id = Incid });
        }


            // GET: IncomeDetails/Create
        public IActionResult Create(UserDetail userDetail)
        {
            

            TempData["applicationid"] = userDetail.ApplicationId;
            TempData.Keep();
            ViewBag.ApplicationID = TempData.Peek("applicationid");

            return View();
        }

        // POST: IncomeDetails/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncomeId,TypeOfEmployment,OrganizationType,OrganizationName,Salary,RetirementAge,ApplicationId")] IncomeDetail incomeDetail)
        {
            var Incid = (from d in _context.IncomeDetails orderby d.IncomeId descending select d.IncomeId).FirstOrDefault();

            if (Incid == 0)
            {
                TempData["incomeid"] = 1000;
                ViewBag.IncomeID = TempData.Peek("incomeid");
            }
            else
            {
                TempData["incomeid"] = ++Incid;
                ViewBag.IncomeID = TempData.Peek("incomeid");
            }

            if (ModelState.IsValid)
            {
                
                ViewBag.ApplicationID = TempData["applicationid"];
                incomeDetail.IncomeId = ViewBag.IncomeID;
                incomeDetail.ApplicationId= ViewBag.ApplicationID;
                _context.Add(incomeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "properties", incomeDetail);
            }
            return View(incomeDetail);
        }

        // GET: IncomeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {        
            
            var incomeDetail = await _context.IncomeDetails.FindAsync(id);
            if (incomeDetail == null)
            {
                return NotFound();
            }
            ViewBag.IncomeID = incomeDetail.IncomeId ;
            TempData["incomeid"] = incomeDetail.IncomeId;
            ViewBag.ApplicationID = TempData["applicationid"];
            incomeDetail.ApplicationId = ViewBag.ApplicationID;
            TempData.Keep();
            return View(incomeDetail);
        }


        // POST: IncomeDetails/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncomeId,TypeOfEmployment,OrganizationType,OrganizationName,Salary,RetirementAge,ApplicationId")] IncomeDetail incomeDetail)
        {        
                try
                {
                    ViewBag.ApplicationID = TempData["applicationid"];
                    incomeDetail.ApplicationId = ViewBag.ApplicationID;
                    incomeDetail.IncomeId = (int)TempData["incomeid"];
                    _context.Update(incomeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                     return NotFound();
                }
            return RedirectToAction("Details","incomedetails",new { id = incomeDetail.IncomeId });
        }

        // GET: IncomeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeDetail = await _context.IncomeDetails
                .Include(i => i.Application)
                .FirstOrDefaultAsync(m => m.IncomeId == id);
            if (incomeDetail == null)
            {
                return NotFound();
            }

            return View(incomeDetail);
        }
        // GET: IncomeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeDetail = await _context.IncomeDetails
                .Include(i => i.Application)
                .FirstOrDefaultAsync(m => m.IncomeId == id);
            if (incomeDetail == null)
            {
                return NotFound();
            }

            return View(incomeDetail);
        }

        // POST: IncomeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeDetail = await _context.IncomeDetails.FindAsync(id);
            _context.IncomeDetails.Remove(incomeDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeDetailExists(int id)
        {
            return _context.IncomeDetails.Any(e => e.IncomeId == id);
        }
    }
}
