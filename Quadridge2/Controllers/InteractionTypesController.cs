using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class InteractionTypesController : Controller
    {

        private ApplicationDbContext _context;

        public InteractionTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: InteractionTypes
        public ActionResult Index()
        {
            var interactionTypes = _context.InteractionTypes.ToList();
            return View(interactionTypes);
        }

        [HttpPost]
        public ActionResult Save(InteractionType interactionType)
        {
            if (interactionType.Id == 0)
                _context.InteractionTypes.Add(interactionType);
            else
            {
                var serviceInDb = _context.Services.SingleOrDefault(i => i.Id == interactionType.Id);
                serviceInDb.Name = interactionType.Type;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "InteractionTypes");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var interactionTypeInDb = _context.InteractionTypes.SingleOrDefault(i => i.Id == id);

            if (interactionTypeInDb == null)
                HttpNotFound();

            _context.InteractionTypes.Remove(interactionTypeInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "InteractionTypes");
        }
    }
}