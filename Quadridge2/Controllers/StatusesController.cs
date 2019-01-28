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
    public class StatusesController : Controller
    {

        private ApplicationDbContext _context;

        public StatusesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Statuses
        public ActionResult Index()
        {
            var statuses = _context.Statuses.ToList();
            return View(statuses);
        }

        public ActionResult Save(Status status)
        {
            if (status.Id == 0)
                _context.Statuses.Add(status);
            else
            {
                var statusInDb = _context.Statuses.Single(s => s.Id == status.Id);
                statusInDb.Type = status.Type;
            }
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Statuses"); ;
            return Json(new { Url = redirectUrl });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var statusInDb = _context.Statuses.Single(s => s.Id == id);

            if (statusInDb == null)
                return HttpNotFound();

            _context.Statuses.Remove(statusInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Statuses");
            return Json(new { Url = redirectUrl });
        }
    }
}