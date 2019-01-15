using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Clients = _context.Clients.ToList(),
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
                    Clients = _context.Clients.ToList(),
                    InteractionTypes = _context.InteractionTypes.ToList()
                };

                return View("InteractionForm", viewModel);
            }
            if (interaction.Id == 0)
                _context.Interactions.Add(interaction);
            else
            {
                var interactionInDb = _context.Interactions.Single(i => i.Id == interaction.Id);

                interactionInDb.InteractionTypeId = interaction.InteractionTypeId;
                interactionInDb.ClientId = interaction.ClientId;
                interactionInDb.InteractionDate = interaction.InteractionDate;
                interactionInDb.Comment = interaction.Comment;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Interactions");
        }
    }
}