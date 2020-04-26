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
    public class StructureCategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public StructureCategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: StructureCategories
        public ActionResult Index()
        {
            var structureCategories = _context.StructureCategories.ToList();
            return View(structureCategories);
        }

        [HttpPost]
        public ActionResult Save(StructureCategory structureCategory)
        {
            if (structureCategory.Id == 0)
                _context.StructureCategories.Add(structureCategory);
            else
            {
                var structureCategoryInDb = _context.StructureCategories.Single(s => s.Id == structureCategory.Id);
                structureCategoryInDb.Category = structureCategory.Category;
            }
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "StructureCategories");
            return Json(new { Url = redirectUrl });
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var structureCategoryInDb = _context.StructureCategories.Single(s => s.Id == id);

            if (structureCategoryInDb == null)
                return HttpNotFound();

            _context.StructureCategories.Remove(structureCategoryInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "StructureCategories"); ;
            return Json(new { Url = redirectUrl });
        }
    }
}