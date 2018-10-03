using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels
{
    public class DealFormViewModel
    {
        public IEnumerable<DealType> Types { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
        public IEnumerable<Lawyer> Lawyeres { get; set; }

        public Deal Deal { get; set; }
    }
}