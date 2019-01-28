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

        public ActionResult Save(FeeType feeType)
        {
            if (feeType.Id == 0)
                _context.FeeTypes.Add(feeType);
            else
            {
                var feeTypeInDb = _context.FeeTypes.Single(f => f.Id == feeType.Id);
                feeTypeInDb.Type = feeType.Type;
            }
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "FeeTypes"); ;
            return Json(new { Url = redirectUrl });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var feeTypeInDb = _context.FeeTypes.Single(f => f.Id == id);

            if (feeTypeInDb == null)
                return HttpNotFound();

            _context.FeeTypes.Remove(feeTypeInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "FeeTypes"); ;
            return Json(new { Url = redirectUrl });
        }
    }
}