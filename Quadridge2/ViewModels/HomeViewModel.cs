using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Quadridge2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Interaction> Interactions { get; set; }
        public IEnumerable<Contact> NewContacts { get; set; }
        public IEnumerable<Structure> Structures { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public ICollection<Contact> BirthdayContacts { get; set; }
    }
}