using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Comment
    {
        public Comment()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        [Required]
        [MaxLength(512)]
        public string CommentString { get; set; }

        public DateTime Date { get; set; }
    }
}