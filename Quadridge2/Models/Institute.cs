using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
  public class Institute
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public virtual InstitutionType Type { get; set; }
    public ICollection<Location> Locations { get; set; }
    public ICollection<Contact> Contacts { get; set; }
  }
}