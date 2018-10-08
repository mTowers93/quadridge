using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Dtos
{
    public class DealDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? RevenueId { get; set; }

        public DateTime Date { get; set; }

        public int? BankId { get; set; }

        public int StatusId { get; set; }

        public int? LawyerId { get; set; }
    }
}