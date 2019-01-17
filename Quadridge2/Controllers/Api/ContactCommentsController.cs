using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quadridge2.Dtos;

namespace Quadridge2.Controllers.Api
{
    public class ContactCommentsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactCommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateComment(ContactCommentDto newComment)
        {
            var contact = _context.Contacts.Single(c => c.Id == newComment.contactId);

            if (contact == null)
                return BadRequest("Invalid contact");

            var comment = new ContactComment
            {
                Contact = contact,
                Comment = newComment.comment
            };

            _context.ContactComments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
