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

    public virtual Department Department { get; set; }

    [Display(Name="Department")]
    public int? DepartmentId { get; set; }

    // Relationships
    public ICollection<Interest> Interests { get; set; }

    public virtual ICollection<Interaction> Interactions { get; set; }

    public ICollection<ContactComment> ContactComments { get; set; }

    public ICollection<CompanyContact> CompanyContacts { get; set; }

    public ICollection<StructureContact> StructureContacts { get; set; }

    public virtual Institute Institute { get; set; }
    // Temporarily null so that everyone gets assigned to a company = could set to 0 so that they all get defaulted and must be changed. probably better
    [Display(Name="Institution")]
    public int? InstituteId { get; set; }
    public virtual Location Location { get; set; }
    [Display(Name="Location")]
    public int? LocationId{ get; set; }

    public string Fullname
    {
      get
      {
        return Firstname + " " + Surname;
      }
    }

  }
}