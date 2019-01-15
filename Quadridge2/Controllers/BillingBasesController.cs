using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class BillingBasesController : Controller
    {
        private ApplicationDbContext _context;

        public BillingBasesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool Disposing)
        {
            _context.Dispose();
        }

        // GET: BillingBases
        public ActionResult Index()
        {
            var billingBases = _context.BillingBases.ToList();
            return View(billingBases);
        }
    }
}