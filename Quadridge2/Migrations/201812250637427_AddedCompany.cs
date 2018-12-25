namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
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
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId);
            
            AddColumn("dbo.Contacts", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "LawfirmId", c => c.Int());
            CreateIndex("dbo.Contacts", "ClientId");
            CreateIndex("dbo.Contacts", "LawfirmId");
            CreateIndex("dbo.Contacts", "CompanyId");
            CreateIndex("dbo.Contacts", "BankId");
            AddForeignKey("dbo.Contacts", "BankId", "dbo.Banks", "Id");
            AddForeignKey("dbo.Contacts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Contacts", "LawfirmId", "dbo.LawFirms", "Id");
            DropColumn("dbo.Contacts", "lawfirm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "lawfirm", c => c.Int());
            DropForeignKey("dbo.Contacts", "LawfirmId", "dbo.LawFirms");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Contacts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contacts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Companies", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Companies", "CountryId", "dbo.Countries");
            DropIndex("dbo.Contacts", new[] { "BankId" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropIndex("dbo.Contacts", new[] { "LawfirmId" });
            DropIndex("dbo.Contacts", new[] { "ClientId" });
            DropIndex("dbo.Companies", new[] { "CountryId" });
            DropIndex("dbo.Companies", new[] { "ProvinceId" });
            DropColumn("dbo.Contacts", "LawfirmId");
            DropColumn("dbo.Contacts", "ClientId");
            DropTable("dbo.Companies");
        }
    }
}
