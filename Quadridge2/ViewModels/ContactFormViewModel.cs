using System.Collections.Generic;
using Quadridge2.Models;
using Quadridge2.Models.Contacts;

namespace Quadridge2.ViewModels
{
    public class ContactFormViewModel
    {
        public ICollection<Bank> Banks { get; set; }
        public ICollection<LawFirm> LawFirms { get; set; }
        public ICollection<Standalone> Standalones { get; set; }
        public BankContact BankContact { get; set; }
        public LawFirmContact LawFirmContact { get; set; }
        public StandaloneContact StandaloneContact { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public int RelationId { get; set; }
        public bool IsLawFirm { get; set; }
        public bool IsBank { get; set; }
        public bool IsStandalone { get; set; }
    }
}