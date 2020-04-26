using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
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
      var date2weeksAgo = DateTime.Now.AddDays(-14);
      var date1weekAhead = DateTime.Now.AddDays(7);
      var newContacts = _context.Contacts.OrderByDescending(c => c.Id).Take(5).ToList();
      var newInteractions = _context.Interactions.OrderByDescending(i => i.Id).Take(5).ToList();
      var newCompanies = _context.Companies.OrderByDescending(c => c.Id).Take(5).ToList();
      var birthdayContacts = _context.Contacts.Where(c => c.Birthday > date2weeksAgo && c.Birthday < date1weekAhead).OrderByDescending(c => c.Birthday).Take(10).ToList();
      var newStructures = _context.Structures.OrderByDescending(s => s.Id).Take(5).ToList();
      var viewModel = new HomeViewModel
      {
        NewContacts = newContacts,
        Interactions = newInteractions,
        Companies = newCompanies,
        BirthdayContacts = birthdayContacts,
        Structures = newStructures
      };
      return View(viewModel);
    }
  }
}