using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class FeeTypesController : Controller
    {
        private ApplicationDbContext _context;

        public FeeTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FeeTypes
        public ActionResult Index()
        {
            var feeTypes = _context.FeeTypes.ToList();
            return View(feeTypes);
        }
    }
}