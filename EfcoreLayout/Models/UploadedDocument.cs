using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class UploadedDocument
    {
        [Display(Name = "Document ID")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Please Upload Pan Card ")]
        [Display(Name = "Pan Card")]
        public string PanCard { get; set; }

        [Required(ErrorMessage = "Please Upload Aadhar Card")]
        [Display(Name = "Aadhar Card")]
        public string AadharCard { get; set; }

        [Required(ErrorMessage = "Please Upload Salary Slip")]
        [Display(Name = "Salary Slip")]
        public string SalarySlip { get; set; }

        [Required(ErrorMessage = "Please Upload LOA ")]
        [Display(Name = "Letter Of Approval")]
        public string Loa { get; set; }

        [Required(ErrorMessage = "Please Upload NOC ")]
        [Display(Name = "No Objection Certificate")]
        public string Noc { get; set; }

        [Required(ErrorMessage = "Please Upload Agreement")]
        [Display(Name = "Agreement")]
        public string Agreement { get; set; }

        [Display(Name = "Document verified Status")]
        public string DocumentverifiedStatus { get; set; }

        [Display(Name = "Application ID")]
        public int? ApplicationId { get; set; }

        [Display(Name = "Loan Approval Status")]
        public string LoanApprovalStatus { get; set; }

        [Display(Name = "Application ID")]
        public virtual UserDetail Application { get; set; }
    }
}
