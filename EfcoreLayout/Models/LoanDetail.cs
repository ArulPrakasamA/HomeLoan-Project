using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class LoanDetail
    {
        [Display(Name = "Loan ID")]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Please enter Minimum Amount")]
        [Display(Name = "Minimum Amount (Rs.)")]
        public double? Amount { get; set; }

        [Required(ErrorMessage = "Please enter Maximum Amount")]
        [Display(Name = "Maximum Amount (Rs.)")]
        public double? MaxAmountGrantable { get; set; }

        [Display(Name = "Interest Rate (%)")]
        public double? InterestRate { get; set; }

        [Required(ErrorMessage = "Please enter Tenure ")]
        [Display(Name = "Tenure in Months")]
        public double? Tenure { get; set; }

        [Required(ErrorMessage = "Please enter Loan Date")]
        [Display(Name = "Loan Date")]
        public DateTime? LoanDate { get; set; }

        [Display(Name = "Application ID")]
        public int? ApplicationId { get; set; }

        public virtual UserDetail Application { get; set; }
    }
}
