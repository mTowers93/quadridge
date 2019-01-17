using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Contacts
{
    public class ContactComment
    {
        [Required]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}