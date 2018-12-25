using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}