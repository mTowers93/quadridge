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
        [Display(Name = "Structure Name")]
        public string StructureName { get; set; }

        public int? RevenueId { get; set; }

        public DateTime Date { get; set; }

        public int? BankId { get; set; }
        public Bank Bank { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Display(Name ="Referring law firm")]
        public int? LawFirmId { get; set; }
        public LawFirm Lawfirm { get; set; }

        public DateTime DirectorshipStartDate { get; set; }

        public DateTime FirstBillingDate { get; set; }

        public string BillingBasis { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}