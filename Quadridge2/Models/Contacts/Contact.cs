using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Contacts
{
    public class Contact
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="First name")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name ="Contact Number")]
        public string ContactNo { get; set; }

        [MaxLength(15)]
        [Display(Name ="Alternative Number")]
        public string AltContactNo { get; set; }

        public DateTime Birthday { get; set; }

        // Relationships
        public ICollection<Interest> Interests { get; set; }

        public ICollection<ContactComment> ContactComments { get; set; }

    }
}