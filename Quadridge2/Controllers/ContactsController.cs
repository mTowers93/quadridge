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
      contact.Country = _context.Countries.Single(c => c.Id == contact.CountryId);
      contact.Province = _context.Provinces.Single(p => p.Id == contact.ProvinceId);
      var viewModel = new ContactDetailsViewModel()
      {
        Contact = contact,
        InteractionTypes = _context.InteractionTypes.ToList()
      };

      return View(viewModel);
    }

    public ActionResult New()
    {
      var contact = new Contact()
      {
        CountryId = 446
      };
      var viewModel = new ContactFormViewModel
      {
        Contact = contact,
        FinancialInstitutions = _context.FinancialInstitutions.ToList(),
        LawFirms = _context.LawFirms.ToList(),
        Standalones = _context.Standalones.ToList(),
        Provinces = _context.Provinces.ToList(),
        Countries = _context.Countries.ToList(),
        Departments = _context.Departments.ToList(),
        IsFinancialInstitution = false,
        IsLawFirm = false,
        IsStandalone = false

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
        viewModel.LawFirms = _context.LawFirms.ToList();
        viewModel.FinancialInstitutions = _context.FinancialInstitutions.ToList();
        viewModel.Departments = _context.Departments.ToList();
        viewModel.Standalones = _context.Standalones.ToList();
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
          viewModel.LawFirms = _context.LawFirms.ToList();
          viewModel.FinancialInstitutions = _context.FinancialInstitutions.ToList();
          viewModel.Departments = _context.Departments.ToList();
          viewModel.Standalones = _context.Standalones.ToList();
          return View("ContactForm", viewModel);
        }

        _context.Contacts.Add(viewModel.Contact);
        _context.SaveChanges();

        var contactId = viewModel.Contact.Id;
        var contactInDb = _context.Contacts.Single(c => c.Id == contactId);
        if (viewModel.IsFinancialInstitution)
        {
          contactInDb.IsFinancialContact = true;
          contactInDb.IsLawFirmContact = false;
          contactInDb.IsStandalone = false;
          var financialInstitutionContact = new FinancialInstitutionContact()
          {
            FinancialInstitutionId = (int)viewModel.FinancialId,
            FinancialInstitution = _context.FinancialInstitutions.Single(b => b.Id == viewModel.FinancialId),
            ContactId = contactId,
            Contact = viewModel.Contact
          };
          _context.FinancialInstitutionContacts.Add(financialInstitutionContact);
        }
        else if (viewModel.IsLawFirm)
        {
          contactInDb.IsFinancialContact = false;
          contactInDb.IsLawFirmContact = true;
          contactInDb.IsStandalone = false;
          var lawFirmContact = new LawFirmContact()
          {
            LawFirmId = (int)viewModel.LawFirmId,
            LawFirm = _context.LawFirms.Single(l => l.Id == viewModel.LawFirmId),
            ContactId = contactId,
            Contact = viewModel.Contact,

          };
          _context.LawFirmContacts.Add(lawFirmContact);
        }
        else if (viewModel.IsStandalone)
        {
          contactInDb.IsFinancialContact = false;
          contactInDb.IsLawFirmContact = false;
          contactInDb.IsStandalone = true;
          var standaloneContact = new StandaloneContact()
          {
            StandAloneId = (int)viewModel.OtherId,
            Standalone = _context.Standalones.Single(s => s.Id == viewModel.OtherId),
            Contact = viewModel.Contact,
            ContactId = contactId
          };
          _context.StandaloneContacts.Add(standaloneContact);
        }
      }

      else if (viewModel.Contact.Id != 0)
      {
        var contactInDb = _context.Contacts.Single(c => c.Id == viewModel.Contact.Id);

        contactInDb.Firstname = viewModel.Contact.Firstname;
        contactInDb.Surname = viewModel.Contact.Surname;
        contactInDb.Email = viewModel.Contact.Email;
        contactInDb.ContactNo = viewModel.Contact.ContactNo;


        if (!String.IsNullOrWhiteSpace(viewModel.Contact.AltContactNo))
          contactInDb.AltContactNo = viewModel.Contact.AltContactNo;

        contactInDb.FirstAddressLine = viewModel.Contact.FirstAddressLine;
        contactInDb.SecondAddressLine = viewModel.Contact.SecondAddressLine;
        contactInDb.Suburb = viewModel.Contact.Suburb;
        contactInDb.City = viewModel.Contact.City;
        contactInDb.Zip = viewModel.Contact.Zip;
        contactInDb.ProvinceId = viewModel.Contact.ProvinceId;
        contactInDb.CountryId = viewModel.Contact.CountryId;
        contactInDb.Birthday = viewModel.Contact.Birthday;

        if ((bool)contactInDb.IsLawFirmContact)
        {
          var lfcontact = _context.LawFirmContacts.Single(l => l.ContactId == contactInDb.Id);
          if (lfcontact != null)
          {
            if (viewModel.IsLawFirm)
            {
              if (lfcontact.LawFirmId != viewModel.LawFirmId)
                lfcontact.LawFirmId = (int)viewModel.LawFirmId;
            }
            else if (viewModel.IsFinancialInstitution)
            {
              _context.LawFirmContacts.Remove(lfcontact);
              var newFIContact = new FinancialInstitutionContact()
              {
                ContactId = contactInDb.Id,
                FinancialInstitutionId = (int)viewModel.FinancialId
              };
              _context.FinancialInstitutionContacts.Add(newFIContact);
              _context.SaveChanges();
            }
            else if (viewModel.IsStandalone)
            {
              _context.LawFirmContacts.Remove(lfcontact);
              var newSA = new StandaloneContact()
              {
                ContactId = contactInDb.Id,
                StandAloneId = (int)viewModel.OtherId
              };
              _context.StandaloneContacts.Add(newSA);
              _context.SaveChanges();
            }
          }
          else
            return HttpNotFound();
        }
        else if ((bool)contactInDb.IsFinancialContact)
        {
          var ficontact = _context.FinancialInstitutionContacts.Single(l => l.ContactId == contactInDb.Id);
          if (ficontact != null)
          {
            if (viewModel.IsFinancialInstitution)
            {
              if (ficontact.FinancialInstitutionId != viewModel.FinancialId)
                ficontact.FinancialInstitutionId = (int)viewModel.FinancialId;
            }
            else if (viewModel.IsLawFirm)
            {
              _context.FinancialInstitutionContacts.Remove(ficontact);
              var newLF = new LawFirmContact()
              {
                ContactId = viewModel.Contact.Id,
                LawFirmId = (int)viewModel.LawFirmId
              };
              _context.LawFirmContacts.Add(newLF);
              _context.SaveChanges();
            }
            else if (viewModel.IsStandalone)
            {
              _context.FinancialInstitutionContacts.Remove(ficontact);
              var newSA = new StandaloneContact()
              {
                ContactId = viewModel.Contact.Id,
                StandAloneId = (int)viewModel.OtherId
              };
              _context.StandaloneContacts.Add(newSA);
              _context.SaveChanges();
            }
          }
          else
            return HttpNotFound();
        }
        else if ((bool)contactInDb.IsStandalone)
        {
          var saContact = _context.StandaloneContacts.Single(l => l.ContactId == contactInDb.Id);
          if (saContact != null)
          {
            if (viewModel.IsStandalone)
            {
              if (saContact.StandAloneId != viewModel.OtherId)
                saContact.StandAloneId = (int)viewModel.OtherId;
            }
            else if (viewModel.IsLawFirm)
            {
              _context.StandaloneContacts.Remove(saContact);
              var newLF = new LawFirmContact()
              {
                ContactId = viewModel.Contact.Id,
                LawFirmId = (int)viewModel.LawFirmId
              };
              _context.LawFirmContacts.Add(newLF);
              _context.SaveChanges();
            }
            else if (viewModel.IsFinancialInstitution)
            {
              _context.StandaloneContacts.Remove(saContact);
              var newFI = new FinancialInstitutionContact()
              {
                ContactId = viewModel.Contact.Id,
                FinancialInstitutionId = (int)viewModel.FinancialId
              };
              _context.FinancialInstitutionContacts.Add(newFI);
              _context.SaveChanges();
            }
          }
          else
            return HttpNotFound();
        }
      }

      _context.SaveChanges();
      return RedirectToAction("Index", "Contacts");

    }

    public ActionResult Edit(int id)
    {
      var contact = _context.Contacts.Single(c => c.Id == id);
      if (contact == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var viewModel = new ContactFormViewModel()
      {
        Contact = contact,
        FinancialInstitutions = _context.FinancialInstitutions.ToList(),
        LawFirms = _context.LawFirms.ToList(),
        Standalones = _context.Standalones.ToList(),
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