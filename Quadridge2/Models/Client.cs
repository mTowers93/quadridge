using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace Quadridge2.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Display(Name ="Company")]
        public int? CompanyId { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string CellNo { get; set; }

        [StringLength(10)]
        public string BusinessNo { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstAddressLine { get; set; }

        [StringLength(255)]
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
    }
}