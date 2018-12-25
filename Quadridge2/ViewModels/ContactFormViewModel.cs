using System.Collections.Generic;
using Quadridge2.Models;

namespace Quadridge2.ViewModels
{
    public class ContactFormViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public Contact Contact { get; set; }
    }
}