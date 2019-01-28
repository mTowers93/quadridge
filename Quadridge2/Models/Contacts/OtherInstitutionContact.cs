using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class OtherInstitutionContact
    {
        public int Id { get; set; }

        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }

        public virtual OtherInstitution OtherInstitution { get; set; }
        public int OtherInstitutionId { get; set; }
    }
}