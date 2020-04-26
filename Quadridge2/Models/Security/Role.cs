using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Security
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}