using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public ActionResult Save(BillingBasis billingBasis)
        {
            if (billingBasis.Id == 0)
                _context.BillingBases.Add(billingBasis);
            else
            {
                var billingBasisInDb = _context.BillingBases.Single(s => s.Id == billingBasis.Id);
                billingBasisInDb.Basis = billingBasis.Basis;
            }
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "BillingBases"); ;
            return Json(new { Url = redirectUrl });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var billingBasisInDb = _context.BillingBases.Single(s => s.Id == id);

            if (billingBasisInDb == null)
                return HttpNotFound();

            _context.BillingBases.Remove(billingBasisInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "StructureCategories"); ;
            return Json(new { Url = redirectUrl });
        }
    }
}