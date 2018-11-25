using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Deal
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? RevenueId { get; set; }

        public DateTime Date { get; set; }

        public int? BankId { get; set; }
        public Bank Bank { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int? LawFirmId { get; set; }
        public LawFirm Lawfirm { get; set; }
    }
}