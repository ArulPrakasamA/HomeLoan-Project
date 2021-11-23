using System;
using System.Collections.Generic;

#nullable disable

namespace EfcoreLayout.Models
{
    public partial class LoanStatus
    {
        public int StatusId { get; set; }
        public string TrackStatus { get; set; }
        public int? ApplicationId { get; set; }

        public virtual UserDetail Application { get; set; }
    }
}
