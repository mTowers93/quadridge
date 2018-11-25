using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Contact
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        public int? lawfirm { get; set; }

        public int? CompanyId { get; set; }

        public int? BankId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string ContactNo { get; set; }

        [MaxLength(15)]
        public string AltContactNo { get; set; }

    }
}