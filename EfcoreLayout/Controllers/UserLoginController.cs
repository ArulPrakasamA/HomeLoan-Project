using EfcoreLayout.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreLayout.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly HomeLoanContext db;
        public UserLoginController(HomeLoanContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         
        public IActionResult CustomerPage(UserDetail user)
        {
            var mail = user.Email;
            var id = (from y in db.UserDetails
                     where y.Email.Equals(mail)
                     select y.ApplicationId).FirstOrDefault();
            var userinfo = db.UserDetails.Find(id);
            var docid = (from w in db.UploadedDocuments
                         where w.ApplicationId.Equals(id)
                         select w.DocumentId).FirstOrDefault();

            var doc = db.UploadedDocuments.Find(docid);
            if (doc.LoanApprovalStatus == "Loan Approved" )
            {
                var amount = (from w in db.LoanDetails
                              where w.ApplicationId.Equals(id)
                              select w.Amount).FirstOrDefault();
                ViewBag.Balance = amount;
            }
            else
            {
                ViewBag.Balance = 0;
            }


            TempData["userid"] = id;
            TempData.Keep();
            return View(userinfo);
        }

        public IActionResult Profile()
        {
            var id = TempData["userid"];
            var userinfo = db.UserDetails.Find(id);
            return View(userinfo);

        }

        public IActionResult LoanTracker()
        {
            
            return View();
        }

        [HttpPost]

        public IActionResult LoanTracker(LoanStatus loanStatus)
        {
            var checkid = (from c in db.UploadedDocuments
                           where c.ApplicationId.Equals(loanStatus.ApplicationId)
                           select c.ApplicationId).FirstOrDefault();
            if(checkid!=null)
            {
                var statusid = (from x in db.LoanStatuses orderby x.StatusId descending select x.StatusId).FirstOrDefault();
                if (statusid == 0)
                {
                    loanStatus.StatusId = 10000;
                }
                else
                {
                    loanStatus.StatusId = ++statusid;   
                }

                var docid = (from w in db.UploadedDocuments
                             where w.ApplicationId.Equals(checkid)
                             select w.DocumentId).FirstOrDefault();

                var doc = db.UploadedDocuments.Find(docid);

                if (doc.DocumentverifiedStatus == "Sent for Verification")
                {
                    loanStatus.TrackStatus = "Sent for Verification";
                }
                else if (doc.DocumentverifiedStatus == "Documnet Verification Failed")
                {
                    loanStatus.TrackStatus = doc.DocumentverifiedStatus;
                }

                else if (doc.DocumentverifiedStatus == "Document Verified" && doc.LoanApprovalStatus == "Sent for Approval")
                {
                    loanStatus.TrackStatus = "Verified and Sent for Final Approval";
                }
                else if (doc.LoanApprovalStatus == "Loan Approved" || doc.LoanApprovalStatus == "Loan Rejected")
                {
                    loanStatus.TrackStatus = doc.LoanApprovalStatus;
                }

                ViewBag.Tracker = loanStatus.TrackStatus;
                db.SaveChanges();
                return View();

            }   
                
            return View();
        }


        public IActionResult CheckBalance()
        {

            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = db.UserDetails
                .FirstOrDefault(m => m.ApplicationId == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }
        
        public IActionResult Login()
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Login(UserDetail user)
        {
            string email = user.Email;
            string Password = user.UserPassword;

            var emailcheck = (from c in db.UserDetails where c.Email.Equals(user.Email) select c.Email).FirstOrDefault();
            var passwordcheck= (from d in db.UserDetails where d.UserPassword.Equals(user.UserPassword) select d.UserPassword).FirstOrDefault();

            if (emailcheck != null && passwordcheck!=null)
            {
                return RedirectToAction("CustomerPage","userlogin",user);
            }
            else
            {
                ViewBag.Error="Invalid Email ID or Password";
                return View();
            }
        }
    }
}
