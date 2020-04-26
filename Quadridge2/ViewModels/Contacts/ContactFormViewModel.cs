using System.Collections.Generic;
using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;

namespace Quadridge2.ViewModels.Contacts
{
  public class ContactFormViewModel
  {
    public ICollection<Institute> Institutes { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<Province> Provinces { get; set; }
    public ICollection<Country> Countries { get; set; }
    public ICollection<Department> Departments { get; set; }
    public Contact Contact { get; set; }
    public int ContactId { get; set; }

  }
}