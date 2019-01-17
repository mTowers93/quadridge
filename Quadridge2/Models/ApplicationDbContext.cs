using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Deals;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankContact> BankContacts { get; set; }
        public DbSet<BankOffice> BankOffices { get; set; }
        public DbSet<BillingBasis> BillingBases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<StructureComment> Comments { get; set; }
        public DbSet<ContactComment> ContactComments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<FeeType> FeeTypes { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }
        public DbSet<LawFirm> LawFirms { get; set; }
        public DbSet<LawFirmContact> LawFirmContacts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Standalone> Standalones { get; set; }
        public DbSet<StandaloneContact> StandaloneContacts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<StructureCategory> StructureCategories { get; set; }
        public DbSet<Trust> Trusts { get; set; }        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}