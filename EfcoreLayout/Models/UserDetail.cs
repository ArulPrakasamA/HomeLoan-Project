
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            IncomeDetails = new HashSet<IncomeDetail>();
            LoanDetails = new HashSet<LoanDetail>();
            LoanStatuses = new HashSet<LoanStatus>();
            Properties = new HashSet<Property>();
            UploadedDocuments = new HashSet<UploadedDocument>();
        }

        [Display(Name = "Application ID")]
        public int ApplicationId { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Plese Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Plese Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Invalid Email ID")]
        [Display(Name = "Email ID")]
        public string  Email  { get; set; }

        [Required(ErrorMessage = "Please enter 10 digit Phone Number")]
        [Display(Name = "Mobile Number")]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please Enter 12 digit Aadhar Number")]
        [StringLength(12, MinimumLength = 12)]
        [Display(Name = "Aadhar Number")]
        public string AadharNumber { get; set; }

        [Required(ErrorMessage = "Please Enter 10 digit PAN Number")]
        [StringLength(10, MinimumLength = 10)]
        [Display(Name = "Pan Number")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Please Enter 10-15 digit Account Number")]
        [StringLength(15, MinimumLength = 10)]
        [Display(Name = "Bank Account Number")]
        public string BankAccountNumber { get; set; }

        public virtual ICollection<IncomeDetail> IncomeDetails { get; set; }
        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
        public virtual ICollection<LoanStatus> LoanStatuses { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<UploadedDocument> UploadedDocuments { get; set; }
    }
}
