using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Quadridge2.Models.Maintenance;

namespace Quadridge2.Models
{
  public class Location
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "First Line")]
    public string FirstLine { get; set; }
    [Display(Name = "Second Line")]
    public string SecondLine { get; set; }
    public string City { get; set; }
    public string Suburb { get; set; }

    [Display(Name="Postal Code")]
    public string PostalCode { get; set; }

    //Foreign tables
    public int? ProvinceId { get; set; }
    public virtual Province Province { get; set; }

    public int CountryId { get; set; }
    public virtual Country Country { get; set; }

    public virtual Institute Institute { get; set; }
    [Display(Name="Institution")]
    public int InstituteId { get; set; }
  }
}