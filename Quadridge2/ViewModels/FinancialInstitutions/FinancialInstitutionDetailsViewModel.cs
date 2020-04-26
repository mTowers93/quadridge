using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.FinancialInstitutions
{
  public class FinancialInstitutionDetailsViewModel
  {
    public Institute FinancialInstitution { get; set; }
    public ICollection<Structure> Structures { get; set; }
    public ICollection<Structure> FiStructures { get; set; }
    public ICollection<Contact> Contacts { get; set; }

    // Can probably remove this and have contacts under Institute - does not work for structures due to structures being used multiple times
    public ICollection<Contact> FiContacts { get; set; }
  }
}