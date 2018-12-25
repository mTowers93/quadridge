using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        public int? CompanyId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string CellNo { get; set; }

        [Phone]
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

        public int? ProvinceId { get; set; }

        public int CountryId { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}