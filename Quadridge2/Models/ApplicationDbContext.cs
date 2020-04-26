using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quadridge2.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<BillingBasis> BillingBases { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<StructureComment> Comments { get; set; }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyContact> CompanyContacts { get; set; }
    public DbSet<CompanyService> CompanyServices { get; set; }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactComment> ContactComments { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Deal> Deals { get; set; }
    public DbSet<DealType> DealTypes { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<FeeType> FeeTypes { get; set; }

    public DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
    public DbSet<FinancialInstitutionContact> FinancialInstitutionContacts { get; set; }

    public DbSet<Interaction> Interactions { get; set; }
    public DbSet<InteractionType> InteractionTypes { get; set; }

    public DbSet<Institute> Institutes { get; set; }
    public DbSet<InstitutionType> InstitutionTypes { get; set; }
    public DbSet<Location> Locations { get; set; }

    public DbSet<LawFirm> LawFirms { get; set; }
    public DbSet<LawFirmContact> LawFirmContacts { get; set; }

    public DbSet<OtherInstitution> OtherInstitutions { get; set; }
    public DbSet<OtherInstitutionContact> OtherInstitutionContacts { get; set; }

    public DbSet<Province> Provinces { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<Standalone> Standalones { get; set; }
    public DbSet<StandaloneContact> StandaloneContacts { get; set; }

    public DbSet<Status> Statuses { get; set; }

    public DbSet<Structure> Structures { get; set; }
    public DbSet<StructureCategory> StructureCategories { get; set; }
    public DbSet<StructureContact> StructureContacts { get; set; }

    public DbSet<Trust> Trusts { get; set; }
    public DbSet<TrustService> TrustServices { get; set; }

    public DbSet<User> QUsers { get; set; }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Company>()
    //        .HasMany(s => s.Services).WithMany(c => c.Companies)
    //        .Map(t => t.ToTable("CompanyServices"));
    //}

    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}