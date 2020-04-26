using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;
using Quadridge2.Models.Maintenance;

namespace Quadridge2.ViewModels
{
  public class LocationViewModel
  {
    public Location Location { get; set; }
    public virtual ICollection<Province> Provinces { get; set; }
    public virtual ICollection<Country> Countries { get; set; }
    public virtual ICollection<Institute> Institutes { get; set; }
  }
}