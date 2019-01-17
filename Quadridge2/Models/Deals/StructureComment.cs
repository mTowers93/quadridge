using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Deals
{
    public class StructureComment
    {
        public StructureComment()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }

        public int StructureId { get; set; }

        public Structure Structure { get; set; }

        [Required]
        [MaxLength(512)]
        public string CommentString { get; set; }

        public DateTime Date { get; set; }
    }
}