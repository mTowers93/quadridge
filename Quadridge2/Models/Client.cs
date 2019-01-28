using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace Quadridge2.Models
{
    public class Client
    {
        public int Id { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Trust> Trusts { get; set; }
    }
}