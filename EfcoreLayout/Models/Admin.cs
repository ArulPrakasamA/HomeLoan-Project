using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class Admin
    {
        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }
        [Display(Name = "Password")]
        public string AdminPassword { get; set; }
    }
}
