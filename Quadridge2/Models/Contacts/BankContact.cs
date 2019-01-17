using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class BankContact
    {
        public int? Id { get; set; }
        
        public Bank Bank { get; set; }
        public int BankId { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}