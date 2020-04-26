using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Deals;
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
    [Display(Name = "First name")]
    public string Firstname { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Surname")]
    public string Surname { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(15)]
    [Display(Name = "Contact Number")]
    public string ContactNo { get; set; }

    [MaxLength(15)]
    [Display(Name = "Work Contact Number")]
    public string AltContactNo { get; set; }

    public DateTime? Birthday { get; set; }

    // Address
    [Required]
    [Display(Name = "First Address Line")]
    public string FirstAddressLine { get; set; }

    [Display(Name = "Second Address Line")]
    public string SecondAddressLine { get; set; }

    [Required]
    public string Suburb { get; set; }

    public string City { get; set; }

    [Required]
    [Display(Name = "Postal Code")]
    public string Zip { get; set; }

    public virtual Province Province { get; set; }
    [Display(Name = "Province")]
    public int ProvinceId { get; set; }

    public virtual Country Country { get; set; }
    [Required]
    [Display(Name = "Country")]
    public int CountryId { get; set; }

    public bool? IsLawFirmContact { get; set; }
    public bool? IsFinancialContact { get; set; }
    public bool? IsStandalone { get; set; }
    public virtual Department Department { get; set; }

    [Display(Name="Department")]
    public int? DepartmentId { get; set; }

    // Relationships
    public ICollection<Interest> Interests { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }

    public ICollection<ContactComment> ContactComments { get; set; }

    public ICollection<CompanyContact> CompanyContacts { get; set; }

    public ICollection<StructureContact> StructureContacts { get; set; }

    public ICollection<LawFirmContact> LawFirmContact { get; set; }

    public ICollection<FinancialInstitutionContact> FinancialInstitutionContacts { get; set; }

    public string Fullname
    {
      get
      {
        return Firstname + " " + Surname;
      }
    }

  }
}