using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Maintenance
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Entity> Entities { get; set; }
    }
}