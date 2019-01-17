using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class TrustsController : Controller
    {
        private ApplicationDbContext _context;

        public TrustsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Trusts
        public ActionResult Index()
        {
            var trusts = _context.Trusts.ToList();
            return View(trusts);
        }
    }
}