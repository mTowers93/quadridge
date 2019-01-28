namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBankOffice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankOffices", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankOffices", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.BankOffices", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.BankOffices", new[] { "ProvinceId" });
            DropIndex("dbo.BankOffices", new[] { "CountryId" });
            DropIndex("dbo.BankOffices", new[] { "BankId" });
            DropTable("dbo.BankOffices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BankOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FirstAddressLine = c.String(nullable: false, maxLength: 255),
                        SecondAddressLine = c.String(maxLength: 255),
                        Suburb = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(maxLength: 8),
                        ProvinceId = c.Int(),
                        CountryId = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BankOffices", "BankId");
            CreateIndex("dbo.BankOffices", "CountryId");
            CreateIndex("dbo.BankOffices", "ProvinceId");
            AddForeignKey("dbo.BankOffices", "ProvinceId", "dbo.Provinces", "Id");
            AddForeignKey("dbo.BankOffices", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BankOffices", "BankId", "dbo.Banks", "Id", cascadeDelete: true);
        }
    }
}
