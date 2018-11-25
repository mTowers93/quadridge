using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class LawFirm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Address Line")]
        public string FirstAddressLine { get; set; }

        [StringLength(255)]
        [Display(Name = "Second Address Line")]
        public string SecondAddressLine { get; set; }

        [Required]
        [StringLength(255)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(8)]
        public string Zip { get; set; }

        public Province Province { get; set; }

        [Display(Name = "Province")]
        public int? ProvinceId { get; set; }


        public Country Country { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
    }
}