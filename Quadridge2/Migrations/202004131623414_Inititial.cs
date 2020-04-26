namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inititial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingBasis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Basis = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RegisteredName = c.String(),
                        RegistrationNumber = c.String(nullable: false),
                        DirectorshipStartDate = c.DateTime(nullable: false),
                        FirstBillingDate = c.DateTime(nullable: false),
                        BillingBasisId = c.Int(),
                        FeeTypeId = c.Int(),
                        TrustId = c.Int(),
                        StructureId = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingBasis", t => t.BillingBasisId)
                .ForeignKey("dbo.Structures", t => t.StructureId)
                .ForeignKey("dbo.Trusts", t => t.TrustId)
                .ForeignKey("dbo.FeeTypes", t => t.FeeTypeId)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.BillingBasisId)
                .Index(t => t.FeeTypeId)
                .Index(t => t.TrustId)
                .Index(t => t.StructureId)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.CompanyContacts",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ContactId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        ContactNo = c.String(maxLength: 15),
                        AltContactNo = c.String(maxLength: 15),
                        Birthday = c.DateTime(),
                        FirstAddressLine = c.String(nullable: false),
                        SecondAddressLine = c.String(),
                        Suburb = c.String(nullable: false),
                        City = c.String(),
                        Zip = c.String(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        IsLawFirmContact = c.Boolean(),
                        IsFinancialContact = c.Boolean(),
                        IsStandalone = c.Boolean(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ContactComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancialInstitutionContacts",
                c => new
                    {
                        FinancialInstitutionId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FinancialInstitutionId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.FinancialInstitutions", t => t.FinancialInstitutionId, cascadeDelete: true)
                .Index(t => t.FinancialInstitutionId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.FinancialInstitutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ContactId = c.Int(),
                        ReferralInstitutionId = c.Int(),
                        LawFirmContactId = c.Int(),
                        StructureCategoryId = c.Int(nullable: false),
                        FinancialInstitutionId = c.Int(),
                        OtherInstitutionId = c.Int(),
                        LawFirmId = c.Int(),
                        StatusId = c.Int(nullable: false),
                        FinancialInstitution_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.FinancialInstitutions", t => t.FinancialInstitutionId)
                .ForeignKey("dbo.LawFirms", t => t.LawFirmId)
                .ForeignKey("dbo.OtherInstitutions", t => t.OtherInstitutionId)
                .ForeignKey("dbo.FinancialInstitutions", t => t.ReferralInstitutionId)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.StructureCategories", t => t.StructureCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.FinancialInstitutions", t => t.FinancialInstitution_Id)
                .Index(t => t.ContactId)
                .Index(t => t.ReferralInstitutionId)
                .Index(t => t.StructureCategoryId)
                .Index(t => t.FinancialInstitutionId)
                .Index(t => t.OtherInstitutionId)
                .Index(t => t.LawFirmId)
                .Index(t => t.StatusId)
                .Index(t => t.FinancialInstitution_Id);
            
            CreateTable(
                "dbo.LawFirms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LawFirmContacts",
                c => new
                    {
                        LawFirmId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LawFirmId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.LawFirms", t => t.LawFirmId, cascadeDelete: true)
                .Index(t => t.LawFirmId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.OtherInstitutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherInstitutionContacts",
                c => new
                    {
                        OtherInstitutionId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OtherInstitutionId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.OtherInstitutions", t => t.OtherInstitutionId, cascadeDelete: true)
                .Index(t => t.OtherInstitutionId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StructureCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StructureContacts",
                c => new
                    {
                        StructureId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StructureId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .Index(t => t.StructureId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Trusts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Donor = c.String(nullable: false),
                        StructureId = c.Int(),
                        RegistrationDate = c.DateTime(nullable: false),
                        TrusteeRepresentitive = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Structures", t => t.StructureId)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.StructureId)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.TrustServices",
                c => new
                    {
                        TrustId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrustId, t.ServiceId })
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Trusts", t => t.TrustId, cascadeDelete: true)
                .Index(t => t.TrustId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyServices",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ServiceId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Interactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InteractionTypeId = c.Int(nullable: false),
                        InteractionDate = c.DateTime(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.InteractionTypes", t => t.InteractionTypeId, cascadeDelete: true)
                .Index(t => t.InteractionTypeId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.InteractionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestText = c.String(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StructureComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StructureId = c.Int(nullable: false),
                        CommentString = c.String(nullable: false, maxLength: 512),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .Index(t => t.StructureId);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StructureName = c.String(nullable: false, maxLength: 255),
                        RevenueId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        BankId = c.Int(),
                        StatusId = c.Int(nullable: false),
                        LawFirmId = c.Int(),
                        DirectorshipStartDate = c.DateTime(nullable: false),
                        FirstBillingDate = c.DateTime(nullable: false),
                        BillingBasis = c.String(),
                        ServiceId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinancialInstitutions", t => t.BankId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.LawFirms", t => t.LawFirmId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.StatusId)
                .Index(t => t.LawFirmId)
                .Index(t => t.ServiceId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.DealTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StandaloneContacts",
                c => new
                    {
                        StandAloneId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StandAloneId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Standalones", t => t.StandAloneId, cascadeDelete: true)
                .Index(t => t.StandAloneId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Standalones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        FirstAddressLine = c.String(nullable: false, maxLength: 255),
                        SecondAddressLine = c.String(maxLength: 255),
                        Suburb = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(maxLength: 8),
                        ProvinceId = c.Int(),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StandaloneContacts", "StandAloneId", "dbo.Standalones");
            DropForeignKey("dbo.Standalones", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Standalones", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.StandaloneContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Deals", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Deals", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Deals", "LawFirmId", "dbo.LawFirms");
            DropForeignKey("dbo.Deals", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Deals", "BankId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.StructureComments", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Trusts", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Companies", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Companies", "FeeTypeId", "dbo.FeeTypes");
            DropForeignKey("dbo.Contacts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Interests", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Interactions", "InteractionTypeId", "dbo.InteractionTypes");
            DropForeignKey("dbo.Interactions", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Structures", "FinancialInstitution_Id", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.TrustServices", "TrustId", "dbo.Trusts");
            DropForeignKey("dbo.TrustServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.CompanyServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.CompanyServices", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Trusts", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Companies", "TrustId", "dbo.Trusts");
            DropForeignKey("dbo.StructureContacts", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.StructureContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Structures", "StructureCategoryId", "dbo.StructureCategories");
            DropForeignKey("dbo.Structures", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Structures", "ReferralInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Structures", "OtherInstitutionId", "dbo.OtherInstitutions");
            DropForeignKey("dbo.OtherInstitutionContacts", "OtherInstitutionId", "dbo.OtherInstitutions");
            DropForeignKey("dbo.OtherInstitutionContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Structures", "LawFirmId", "dbo.LawFirms");
            DropForeignKey("dbo.LawFirmContacts", "LawFirmId", "dbo.LawFirms");
            DropForeignKey("dbo.LawFirmContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Structures", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Companies", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.FinancialInstitutionContacts", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.FinancialInstitutionContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Contacts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ContactComments", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.CompanyContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.CompanyContacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "BillingBasisId", "dbo.BillingBasis");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Standalones", new[] { "CountryId" });
            DropIndex("dbo.Standalones", new[] { "ProvinceId" });
            DropIndex("dbo.StandaloneContacts", new[] { "ContactId" });
            DropIndex("dbo.StandaloneContacts", new[] { "StandAloneId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Deals", new[] { "ClientId" });
            DropIndex("dbo.Deals", new[] { "ServiceId" });
            DropIndex("dbo.Deals", new[] { "LawFirmId" });
            DropIndex("dbo.Deals", new[] { "StatusId" });
            DropIndex("dbo.Deals", new[] { "BankId" });
            DropIndex("dbo.StructureComments", new[] { "StructureId" });
            DropIndex("dbo.Interests", new[] { "ContactId" });
            DropIndex("dbo.Interactions", new[] { "ContactId" });
            DropIndex("dbo.Interactions", new[] { "InteractionTypeId" });
            DropIndex("dbo.CompanyServices", new[] { "ServiceId" });
            DropIndex("dbo.CompanyServices", new[] { "CompanyId" });
            DropIndex("dbo.TrustServices", new[] { "ServiceId" });
            DropIndex("dbo.TrustServices", new[] { "TrustId" });
            DropIndex("dbo.Trusts", new[] { "Client_Id" });
            DropIndex("dbo.Trusts", new[] { "StructureId" });
            DropIndex("dbo.StructureContacts", new[] { "ContactId" });
            DropIndex("dbo.StructureContacts", new[] { "StructureId" });
            DropIndex("dbo.OtherInstitutionContacts", new[] { "ContactId" });
            DropIndex("dbo.OtherInstitutionContacts", new[] { "OtherInstitutionId" });
            DropIndex("dbo.LawFirmContacts", new[] { "ContactId" });
            DropIndex("dbo.LawFirmContacts", new[] { "LawFirmId" });
            DropIndex("dbo.Structures", new[] { "FinancialInstitution_Id" });
            DropIndex("dbo.Structures", new[] { "StatusId" });
            DropIndex("dbo.Structures", new[] { "LawFirmId" });
            DropIndex("dbo.Structures", new[] { "OtherInstitutionId" });
            DropIndex("dbo.Structures", new[] { "FinancialInstitutionId" });
            DropIndex("dbo.Structures", new[] { "StructureCategoryId" });
            DropIndex("dbo.Structures", new[] { "ReferralInstitutionId" });
            DropIndex("dbo.Structures", new[] { "ContactId" });
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "ContactId" });
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "FinancialInstitutionId" });
            DropIndex("dbo.ContactComments", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "DepartmentId" });
            DropIndex("dbo.Contacts", new[] { "CountryId" });
            DropIndex("dbo.Contacts", new[] { "ProvinceId" });
            DropIndex("dbo.CompanyContacts", new[] { "ContactId" });
            DropIndex("dbo.CompanyContacts", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "Client_Id" });
            DropIndex("dbo.Companies", new[] { "StructureId" });
            DropIndex("dbo.Companies", new[] { "TrustId" });
            DropIndex("dbo.Companies", new[] { "FeeTypeId" });
            DropIndex("dbo.Companies", new[] { "BillingBasisId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Standalones");
            DropTable("dbo.StandaloneContacts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.DealTypes");
            DropTable("dbo.Deals");
            DropTable("dbo.StructureComments");
            DropTable("dbo.FeeTypes");
            DropTable("dbo.Provinces");
            DropTable("dbo.Interests");
            DropTable("dbo.InteractionTypes");
            DropTable("dbo.Interactions");
            DropTable("dbo.CompanyServices");
            DropTable("dbo.Services");
            DropTable("dbo.TrustServices");
            DropTable("dbo.Trusts");
            DropTable("dbo.StructureContacts");
            DropTable("dbo.StructureCategories");
            DropTable("dbo.Status");
            DropTable("dbo.OtherInstitutionContacts");
            DropTable("dbo.OtherInstitutions");
            DropTable("dbo.LawFirmContacts");
            DropTable("dbo.LawFirms");
            DropTable("dbo.Structures");
            DropTable("dbo.FinancialInstitutions");
            DropTable("dbo.FinancialInstitutionContacts");
            DropTable("dbo.Departments");
            DropTable("dbo.Countries");
            DropTable("dbo.ContactComments");
            DropTable("dbo.Contacts");
            DropTable("dbo.CompanyContacts");
            DropTable("dbo.Companies");
            DropTable("dbo.Clients");
            DropTable("dbo.BillingBasis");
        }
    }
}
