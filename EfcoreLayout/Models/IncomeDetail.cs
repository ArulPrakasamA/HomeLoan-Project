using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class IncomeDetail
    {
        [Display(Name ="Income ID")]
        public int IncomeId { get; set; }

        [Required(ErrorMessage = "Please enter Type Of Employment ")]
        [Display(Name = "Type Of Employment")]
        public string TypeOfEmployment { get; set; }

        [Required(ErrorMessage = "Please enter Organization Type")]
        [Display(Name = "Organization Type")]
        public string OrganizationType { get; set; }

        [Required(ErrorMessage = "Please enter Organization Name")]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Please enter Salary ")]
        [Display(Name = "Salary per Month")]
        public double? Salary { get; set; }

        [Required(ErrorMessage = "Please enter Retirement Age ")]
        [Display(Name = "Retirement Age")]
        public int? RetirementAge { get; set; }

        [Display(Name = "Application ID")]
        public int? ApplicationId { get; set; }

        public virtual UserDetail Application { get; set; }
    }
}
