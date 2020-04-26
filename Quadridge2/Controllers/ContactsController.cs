using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.ViewModels.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class ContactsController : Controller
  {
    private ApplicationDbContext _context;

    public ContactsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Contacts
    public ActionResult Index()
    {
      var contacts = _context.Contacts.ToList();
      return View(contacts);
    }

    public ActionResult Details(int id)
    {
      var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);
      if (contact == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      contact.Department = _context.Departments.SingleOrDefault(c => c.Id == contact.DepartmentId);
      var viewModel = new ContactDetailsViewModel()
      {
        Contact = contact,
        InteractionTypes = _context.InteractionTypes.ToList()
      };

      return View(viewModel);
    }

    public ActionResult New()
    {
      var viewModel = new ContactFormViewModel
      {
        Contact = new Contact(),
        Institutes = _context.Institutes.ToList(),
        Provinces = _context.Provinces.ToList(),
        Countries = _context.Countries.ToList(),
        Departments = _context.Departments.ToList(),
        Locations = _context.Locations.ToList()

      };

      return View("ContactForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(ContactFormViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        viewModel.Countries = _context.Countries.ToList();
        viewModel.Provinces = _context.Provinces.ToList();
        viewModel.Institutes = _context.Institutes.ToList();
        viewModel.Departments = _context.Departments.ToList();
        return View("ContactForm", viewModel);
      }

      if (viewModel.Contact.Id == 0)
      {
        var contact = _context.Contacts.FirstOrDefault(c => c.Email == viewModel.Contact.Email);
        if (contact != null)
        {
          ModelState.AddModelError("Email", "Email already used");
          viewModel.Countries = _context.Countries.ToList();
          viewModel.Provinces = _context.Provinces.ToList();
          viewModel.Institutes = _context.Institutes.ToList();
          viewModel.Departments = _context.Departments.ToList();
          return View("ContactForm", viewModel);
        }

        _context.Contacts.Add(viewModel.Contact);
        _context.SaveChanges();
        return RedirectToAction("Index", "Contacts");
      }
      else
      {
        var contactInDb = _context.Contacts.Single(c => c.Id == viewModel.Contact.Id);

        contactInDb.Firstname = viewModel.Contact.Firstname;
        contactInDb.Surname = viewModel.Contact.Surname;
        contactInDb.Email = viewModel.Contact.Email;
        contactInDb.ContactNo = viewModel.Contact.ContactNo;


        if (!String.IsNullOrWhiteSpace(viewModel.Contact.AltContactNo))
          contactInDb.AltContactNo = viewModel.Contact.AltContactNo;
        contactInDb.Birthday = viewModel.Contact.Birthday;
        contactInDb.InstituteId = viewModel.Contact.InstituteId;

        _context.SaveChanges();
        return RedirectToAction("Index", "Contacts");
      }
    }

    public ActionResult Edit(int id)
    {
      var contact = _context.Contacts.Single(c => c.Id == id);
      if (contact == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var viewModel = new ContactFormViewModel()
      {
        Contact = contact,
        Institutes = _context.Institutes.ToList(),
        Provinces = _context.Provinces.ToList(),
        Countries = _context.Countries.ToList(),
        Departments = _context.Departments.ToList()

      };

      return View("ContactForm", viewModel);
    }

    public ActionResult DeleteInteraction(int id, int iid)
    {
      var interaction = _context.Interactions.SingleOrDefault(i => i.Id == iid);
      if (interaction == null)
        return HttpNotFound();
      _context.Interactions.Remove(interaction);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Details", "Contacts", new { id }); ;
      return Json(new { Url = redirectUrl });
    }

    public ActionResult Delete(int id)
    {
      var contact = _context.Contacts.Single(c => c.Id == id);

      if (contact == null)
        HttpNotFound();
      _context.Contacts.Remove(contact);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}