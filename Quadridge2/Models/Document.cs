using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Document
    {
        public int Id { get; set; }

        public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }

        [DataType(DataType.Upload)]
        HttpPostedFileBase File { get; set; }
    }
}