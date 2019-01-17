﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class LawFirmContact
    {
        public int? Id { get; set; }

        public LawFirm LawFirm { get; set; }
        public int LawFirmId { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}