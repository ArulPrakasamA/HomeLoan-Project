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
    public class UserDetailsController : Controller
    {
        private readonly HomeLoanContext _context;

        public UserDetailsController(HomeLoanContext context)
        {
            _context = context;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
            var Appid = (from x in _context.UserDetails orderby x.ApplicationId descending select x.ApplicationId).FirstOrDefault();
            return RedirectToAction("Details", "userdetails", new { id = Appid });
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {    
            return View();
        }

        // POST: UserDetails/Create
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ApplicationId,UserPassword,FirstName,MiddleName,LastName,Email,PhoneNumber,DateOfBirth,Gender,Nationality,AadharNumber,PanNumber,BankAccountNumber")] UserDetail userDetail)
        {
                if (ModelState.IsValid)
                {
                var checkemail = (from c in _context.UserDetails where c.Email.Equals(userDetail.Email) select c.Email).FirstOrDefault();
                var checkphone = (from c in _context.UserDetails where c.PhoneNumber.Equals(userDetail.PhoneNumber) select c.PhoneNumber).FirstOrDefault();
                var checkpan = (from c in _context.UserDetails where c.PanNumber.Equals(userDetail.PanNumber) select c.PanNumber).FirstOrDefault();
                var checkaadhar = (from c in _context.UserDetails where c.AadharNumber.Equals(userDetail.AadharNumber) select c.AadharNumber).FirstOrDefault();
                var checkbankacc = (from c in _context.UserDetails where c.BankAccountNumber.Equals(userDetail.BankAccountNumber) select c.BankAccountNumber).FirstOrDefault();

                if (checkemail != null)
                {
                    ViewBag.Email = "Email ID is Already Registerd";
                }
                if (checkpan != null)
                {
                    ViewBag.Pan = "Pan Number is Already Registerd ";
                }
                if (checkphone != null)
                {
                    ViewBag.Phone = "Phone Number is Already Registerd";
                }
                if (checkaadhar != null)
                {
                    ViewBag.Aadhar = "Aadhar Number is Already Registerd";
                }
                if (checkbankacc != null)
                {
                    ViewBag.Bankacc = "Bank Account Number is Already Registerd";
                }

                if (checkemail == null && checkphone == null && checkpan == null && checkaadhar == null && checkbankacc == null)
                    {
                        var Appid = (from x in _context.UserDetails orderby x.ApplicationId descending select x.ApplicationId).FirstOrDefault();

                        if (Appid == 0)
                        {
                            TempData["AppID"] = 1;
                            TempData.Peek("AppID");
                        }
                        else
                        {
                            TempData["AppID"] = ++Appid;
                            TempData.Peek("AppID");
                        }
                        ViewBag.ApplicationID = TempData["AppID"];
                        userDetail.ApplicationId = ViewBag.ApplicationID;
                        _context.Add(userDetail);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("create", "incomedetails", userDetail);
                    }                
                }           
                return View(userDetail); ;
        }

        // GET: UserDetails/Edit/5

        
        public async Task<IActionResult> Edit(int? id)
        {
           
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }
            TempData["user"] = userDetail.ApplicationId;

            return View(userDetail);
        }
        
        // POST: UserDetails/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("ApplicationId,UserPassword,FirstName,MiddleName,LastName,Email,PhoneNumber,DateOfBirth,Gender,Nationality,AadharNumber,PanNumber,BankAccountNumber")] UserDetail userDetail)
        {               
                try
                {
                    userDetail.ApplicationId = (int)TempData["user"];
                    _context.Update(userDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailExists(userDetail.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction("Details", "userdetails", new { id = userDetail.ApplicationId });
        }
            
     

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.ApplicationId == id);
        }
    }
}
