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

        public Client Client { get; set; }
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        public LawFirm LawFirm { get; set; }
        public int? LawfirmId { get; set; }

        public Bank Bank { get; set; }
        public int? BankId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string ContactNo { get; set; }

        [MaxLength(15)]
        public string AltContactNo { get; set; }

        public DateTime Birthday { get; set; }

        // Relationships

        public Entity Entity { get; set; }
        public int EntityId { get; set; }

        public IEnumerable<Interest> Interests { get; set; }

        public IEnumerable<ContactComment> ContactComments { get; set; }

    }
}