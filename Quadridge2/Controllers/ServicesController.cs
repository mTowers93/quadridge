using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Services
        public ActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        [HttpPost]
        public ActionResult SaveService(Service service)
            {
            if (service.Id == 0)
                _context.Services.Add(service);
            else
            {
                var serviceInDb = _context.Services.SingleOrDefault(s => s.Id == service.Id);
                serviceInDb.Name = service.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Services");
        }

        [HttpDelete]
        public ActionResult DeleteService(int id)
        {
            var serviceInDb = _context.Services.SingleOrDefault(s => s.Id == id);

            if (serviceInDb == null)
                HttpNotFound();

            _context.Services.Remove(serviceInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Services");
        }
    }
}