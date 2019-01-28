using System.Collections.Generic;
using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;

namespace Quadridge2.ViewModels
{
    public class ContactFormViewModel
    {
        public ICollection<FinancialInstitution> FinancialInstitutions { get; set; }
        public ICollection<LawFirm> LawFirms { get; set; }
        public ICollection<Standalone> Standalones { get; set; }
        public ICollection<Province> Provinces { get; set; }
        public ICollection<Country> Countries { get; set; }
        public FinancialInstitutionContact FinancialInstitutionContact { get; set; }
        public LawFirmContact LawFirmContact { get; set; }
        public StandaloneContact StandaloneContact { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public int RelationId { get; set; }
        public bool IsLawFirm { get; set; }
        public bool IsFinancialInstitution { get; set; }
        public bool IsStandalone { get; set; }
    }
}