using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class Property
    {
        [Display(Name = "Property ID")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Please enter Property Number")]
        [Display(Name = "Property Number")]
        public int? PropertyNumber { get; set; }

        [Required(ErrorMessage = "Please enter Property Area")]
        [Display(Name = "Property Area (SquareFeet)")]
        public string PropertyArea { get; set; }

        [Required(ErrorMessage = "Please enter Pincode")]
        public int? Pincode { get; set; }

        [Required(ErrorMessage = "Please enter Type Of Property ")]
        [Display(Name = "Type Of Property")]
        public string TypeOfProperty { get; set; }

        [Required(ErrorMessage = "Please enter Estimated Cost")]
        [Display(Name = "Estimated Cost (Rs.)")]
        public double? EstimatedCost { get; set; }

        [Display(Name = "Appliaction ID")]
        public int? ApplicationId { get; set; }

        public virtual UserDetail Application { get; set; }
    }
}
