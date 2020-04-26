using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class InteractionsController : Controller
    {
        private ApplicationDbContext _context;

        public InteractionsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Interactions
        public ActionResult Index()
        {
            var interactions = _context.Interactions.ToList();
            return View(interactions);
        }

        public ActionResult New()
        {
            var viewModel = new InteractionsFormViewModel
            {
                Contacts = _context.Contacts.ToList(),
                InteractionTypes = _context.InteractionTypes.ToList()
            };
                
            return View("InteractionsForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Interaction interaction)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InteractionsFormViewModel
                {
                    Interaction = interaction,
                    Contacts = _context.Contacts.ToList(),
                    InteractionTypes = _context.InteractionTypes.ToList()
                };

                return View("InteractionsForm", viewModel);
            }
            if (interaction.Id == 0)
                _context.Interactions.Add(interaction);
            else
            {
                var interactionInDb = _context.Interactions.Single(i => i.Id == interaction.Id);

                interactionInDb.InteractionTypeId = interaction.InteractionTypeId;
                interactionInDb.ContactId = interaction.ContactId;
                interactionInDb.InteractionDate = interaction.InteractionDate;
                interactionInDb.Comment = interaction.Comment;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Interactions");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveOnContact(Interaction interaction, int contactId)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InteractionsFormViewModel
                {
                    Interaction = interaction,
                    Contacts = _context.Contacts.ToList(),
                    InteractionTypes = _context.InteractionTypes.ToList()
                };

                return View("InteractionForm", viewModel);
            }
            interaction.ContactId = contactId;
            if (interaction.Id == 0)
                _context.Interactions.Add(interaction);
            else
            {
                var interactionInDb = _context.Interactions.Single(i => i.Id == interaction.Id);

                interactionInDb.InteractionTypeId = interaction.InteractionTypeId;
                interactionInDb.ContactId = interaction.ContactId;
                interactionInDb.InteractionDate = interaction.InteractionDate;
                interactionInDb.Comment = interaction.Comment;
            }

            _context.SaveChanges();

            return RedirectToAction("Details", "Contacts", new { id = contactId });
        }

    public ActionResult Details(int id)
    {
      var interaction = _context.Interactions.SingleOrDefault(c => c.Id == id);
      if (interaction == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var viewModel = new InteractionsFormViewModel
      {
        Interaction = interaction,
        InteractionTypes = _context.InteractionTypes.ToList(),
        Contacts = _context.Contacts.ToList()
      };

      return View("InteractionsForm", viewModel);
    }
  }
}