using EfcoreLayout.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreLayout.Controllers
{
    public class AdminController : Controller
    {
        private readonly HomeLoanContext db;
        public AdminController(HomeLoanContext context)
        {
            db = context;
        }
        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();

        }

        public IActionResult DocVerify()
        {
            var id = (from m in db.UploadedDocuments where m.DocumentverifiedStatus.Equals("Sent for Verification") select m.ApplicationId).ToList();
            return View(id);
        }

        [HttpPost]
        public IActionResult DocVerify(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = db.UploadedDocuments
                .FirstOrDefault(m => m.ApplicationId == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        public IActionResult Verifyonclick(int id)
        {
            var user = db.UserDetails.Find(id);
            var userfiles = (from w in db.UploadedDocuments
                            where w.ApplicationId.Equals(id)
                            select w).ToList();
            ViewBag.Userfiles = userfiles;
            TempData["Id"] = id;
            TempData.Keep();
            return View(user);
        }

        [HttpPost]

        public IActionResult Verifyonclick(string button)
        {
            if(button== "Verify")
            {
                var docid = (from w in db.UploadedDocuments
                             where w.ApplicationId.Equals(TempData["Id"])
                             select w.DocumentId).FirstOrDefault();

                var userdoc = db.UploadedDocuments.Find(docid);
                userdoc.DocumentverifiedStatus = "Document Verified";
                db.SaveChanges();
                return RedirectToAction("Approval", "Admin");
            }
            else
            {
                var docid = (from w in db.UploadedDocuments
                             where w.ApplicationId.Equals(TempData["Id"])
                             select w.DocumentId).FirstOrDefault();

                var userdoc = db.UploadedDocuments.Find(docid);
                userdoc.DocumentverifiedStatus = "Documnet Verification Failed";
                db.SaveChanges();
                return RedirectToAction("AdminPage", "Admin");
            }
            
        }

        public IActionResult Approval()
        {
            var id = (from m in db.UploadedDocuments where m.DocumentverifiedStatus.Equals("Document Verified") select m.ApplicationId).ToList();
            return View(id);
        }

        [HttpPost]

        public IActionResult Approval(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = db.UploadedDocuments
                .FirstOrDefault(m => m.ApplicationId == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }
        
        
        public IActionResult Approveonclick(int id)
        {
            var loanid = (from w in db.LoanDetails
                             where w.ApplicationId.Equals(id)
                             select w.LoanId).FirstOrDefault();
            var loan = db.LoanDetails.Find(loanid);

            TempData["Id"] = id;
            TempData.Keep();
            return View(loan);
        }

        [HttpPost]

        public IActionResult Approveonclick(string status)
        {
            if (status == "Approve")
            {
                var docid = (from w in db.UploadedDocuments
                             where w.ApplicationId.Equals(TempData["Id"])
                             select w.DocumentId).FirstOrDefault();
                var userdoc = db.UploadedDocuments.Find(docid);
                userdoc.LoanApprovalStatus = "Loan Approved";
                db.SaveChanges();
                return RedirectToAction("AdminPage", "Admin");
            }

            else
            {
                var docid = (from w in db.UploadedDocuments
                             where w.ApplicationId.Equals(TempData["Id"])
                             select w.DocumentId).FirstOrDefault();

                var userdoc = db.UploadedDocuments.Find(docid);
                userdoc.LoanApprovalStatus = "Loan Rejected";
                db.SaveChanges();
                return RedirectToAction("AdminPage", "Admin");
            }
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AdminLogin(Admin admin)
        {
            int adminid = admin.AdminId;
            string Password = admin.AdminPassword;

            var idcheck = (from c in db.Admins where c.AdminId.Equals(admin.AdminId) select c).FirstOrDefault();
            var passwordcheck = (from d in db.Admins where d.AdminPassword.Equals(admin.AdminPassword) select d).FirstOrDefault();

            if (idcheck != null && passwordcheck != null)
            {
                return RedirectToAction("AdminPage", "Admin", admin);
            }
            else
            {
                ViewBag.Error = "Invalid Admin ID or Password";
                return View();
            }
            
        }

    }
}
