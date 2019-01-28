using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class OtherInstitutionsController : Controller
    {
        private ApplicationDbContext _context;

        public OtherInstitutionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: OtherInstitutions
        public ActionResult Index()
        {
            var otherInstitutions = _context.OtherInstitutions.ToList();
            return View(otherInstitutions);
        }

        [HttpPost]
        public ActionResult Save(OtherInstitution otherInstitution)
        {
            if (otherInstitution.Id == 0)
                _context.OtherInstitutions.Add(otherInstitution);
            else
            {
                var otherInstitutionInDb = _context.OtherInstitutions.Single(c => c.Id == otherInstitution.Id);

                otherInstitutionInDb.Name = otherInstitution.Name;
            }
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "OtherInstitutions");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl });

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var otherInstitutionInDb = _context.OtherInstitutions.SingleOrDefault(b => b.Id == id);

            if (otherInstitutionInDb == null)
            {
                return HttpNotFound();
            }
            _context.OtherInstitutions.Remove(otherInstitutionInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "OtherInstitutions");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl });
        }
    }
}