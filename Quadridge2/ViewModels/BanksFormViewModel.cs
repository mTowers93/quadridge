using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels
{
    public class BanksFormViewModel
    {
        public Bank Bank { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}