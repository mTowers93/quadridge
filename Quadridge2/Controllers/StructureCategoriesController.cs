using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}