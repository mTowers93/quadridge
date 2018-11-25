using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string CommentString { get; set; }
    }
}