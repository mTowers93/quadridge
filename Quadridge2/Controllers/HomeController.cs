using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var newContacts = _context.Contacts.OrderByDescending(c => c.Id).Take(5).ToList();
            var newInteractions = _context.Interactions.OrderByDescending(i => i.Id).Take(5).ToList();
            var newCompanies = _context.Companies.OrderByDescending(c => c.Id).Take(5).ToList();
            var viewModel = new HomeViewModel
            {
                Contacts = newContacts,
                Interactions = newInteractions,
                Companies = newCompanies
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}