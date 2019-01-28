namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedFieldsFromClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Clients", "FinancialInstitution_Id", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Clients", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Clients", new[] { "ProvinceId" });
            DropIndex("dbo.Clients", new[] { "CountryId" });
            DropIndex("dbo.Clients", new[] { "FinancialInstitution_Id" });
            AddColumn("dbo.Companies", "Client_Id", c => c.Int());
            AddColumn("dbo.Trusts", "Client_Id", c => c.Int());
            CreateIndex("dbo.Companies", "Client_Id");
            CreateIndex("dbo.Trusts", "Client_Id");
            AddForeignKey("dbo.Companies", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Trusts", "Client_Id", "dbo.Clients", "Id");
            DropColumn("dbo.Clients", "Name");
            DropColumn("dbo.Clients", "BankReferralId");
            DropColumn("dbo.Clients", "LawFirmReferralId");
            DropColumn("dbo.Clients", "FirstAddressLine");
            DropColumn("dbo.Clients", "SecondAddressLine");
            DropColumn("dbo.Clients", "Suburb");
            DropColumn("dbo.Clients", "City");
            DropColumn("dbo.Clients", "Zip");
            DropColumn("dbo.Clients", "ProvinceId");
            DropColumn("dbo.Clients", "CountryId");
            DropColumn("dbo.Clients", "FinancialInstitution_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "FinancialInstitution_Id", c => c.Int());
            AddColumn("dbo.Clients", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "ProvinceId", c => c.Int());
            AddColumn("dbo.Clients", "Zip", c => c.String(maxLength: 8));
            AddColumn("dbo.Clients", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clients", "Suburb", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Clients", "SecondAddressLine", c => c.String(maxLength: 255));
            AddColumn("dbo.Clients", "FirstAddressLine", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Clients", "LawFirmReferralId", c => c.Int());
            AddColumn("dbo.Clients", "BankReferralId", c => c.Int());
            AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Trusts", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Companies", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Trusts", new[] { "Client_Id" });
            DropIndex("dbo.Companies", new[] { "Client_Id" });
            DropColumn("dbo.Trusts", "Client_Id");
            DropColumn("dbo.Companies", "Client_Id");
            CreateIndex("dbo.Clients", "FinancialInstitution_Id");
            CreateIndex("dbo.Clients", "CountryId");
            CreateIndex("dbo.Clients", "ProvinceId");
            AddForeignKey("dbo.Clients", "ProvinceId", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Clients", "FinancialInstitution_Id", "dbo.FinancialInstitutions", "Id");
            AddForeignKey("dbo.Clients", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
