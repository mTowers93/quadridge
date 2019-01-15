using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
    public class ClientCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Structure> Structures { get; set; }
    }
}