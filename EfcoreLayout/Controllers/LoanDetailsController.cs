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
    public class LoanDetailsController : Controller
    {
        private readonly HomeLoanContext _context;

        public LoanDetailsController(HomeLoanContext context)
        {
            _context = context;
        }

        // GET: LoanDetails
        public async Task<IActionResult> Index()
        {
            var loanid = (from d in _context.LoanDetails orderby d.LoanId descending select d.LoanId).FirstOrDefault();
            var apploa = (from d in _context.IncomeDetails orderby d.ApplicationId descending select d.ApplicationId).FirstOrDefault();
            var appid = (from e in _context.UserDetails orderby e.ApplicationId descending select e.ApplicationId).FirstOrDefault();

            if (apploa != appid)
            {
                return RedirectToAction("create", "loandetails");
            }
            return  RedirectToAction("Details", "loandetails", new { id = loanid });
        }

        // GET: LoanDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanDetail = await _context.LoanDetails
                .Include(l => l.Application)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            return View(loanDetail);
        }

        // GET: LoanDetails/Create
        public IActionResult Create(Property propertydetails)
        { 
            TempData["applicationid"] = propertydetails.ApplicationId;
            TempData.Keep("applicationid");
            ViewBag.ApplicationId = propertydetails.ApplicationId;
            ViewBag.PropertyID = propertydetails.PropertyId;
            return View();
        }

        // POST: LoanDetails/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,Amount,MaxAmountGrantable,InterestRate,Tenure,LoanDate,LoanApprovalStatus,ApplicationId")] LoanDetail loanDetail)
        {
            var lid = (from d in _context.LoanDetails orderby d.LoanId descending select d.LoanId).FirstOrDefault();

            if (lid == 0)
            {
                TempData["loanid"] = 3000;
                ViewBag.LoanID = TempData.Peek("loanid");
            }
            else
            {
                TempData["loanid"] = ++lid;
                ViewBag.LoanID = TempData.Peek("loanid");
            }

            if (ModelState.IsValid)
            {
                
                ViewBag.ApplicationID = TempData["applicationid"];
                TempData.Keep();
                loanDetail.LoanId = ViewBag.LoanID;
                loanDetail.ApplicationId = ViewBag.ApplicationID;
                loanDetail.InterestRate = 8.5;
                _context.Add(loanDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "UploadedDocuments");
            }
           
            return View(loanDetail);
        }

        // GET: LoanDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            var loanDetail = await _context.LoanDetails.FindAsync(id);
            if (loanDetail == null)
            {
                return NotFound();
            }
            ViewBag.LoanID = loanDetail.LoanId;
            ViewBag.ApplicationID = TempData["applicationid"];
            loanDetail.ApplicationId = ViewBag.ApplicationID;
            TempData.Keep();
            return View(loanDetail);
        }

        // POST: LoanDetails/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,Amount,MaxAmountGrantable,InterestRate,Tenure,LoanDate,LoanApprovalStatus,ApplicationId")] LoanDetail loanDetail)
        {
                try
                {
                    ViewBag.ApplicationID = TempData["applicationid"];
                    loanDetail.ApplicationId = ViewBag.ApplicationID;
                    _context.Update(loanDetail);
                    await _context.SaveChangesAsync();
                }
                catch (KeyNotFoundException)
                {
                        return NotFound();
                    
                }
            return RedirectToAction("Details", "loandetails", new { id = loanDetail.LoanId });

        }

        // GET: LoanDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanDetail = await _context.LoanDetails
                .Include(l => l.Application)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            return View(loanDetail);
        }

        // POST: LoanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanDetail = await _context.LoanDetails.FindAsync(id);
            _context.LoanDetails.Remove(loanDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanDetailExists(int id)
        {
            return _context.LoanDetails.Any(e => e.LoanId == id);
        }
    }
}
