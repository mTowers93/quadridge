namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBankOffices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Banks", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Banks", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Banks", new[] { "ProvinceId" });
            DropIndex("dbo.Banks", new[] { "CountryId" });
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.BankId);
            
            DropColumn("dbo.Banks", "FirstAddressLine");
            DropColumn("dbo.Banks", "SecondAddressLine");
            DropColumn("dbo.Banks", "Suburb");
            DropColumn("dbo.Banks", "City");
            DropColumn("dbo.Banks", "Zip");
            DropColumn("dbo.Banks", "ProvinceId");
            DropColumn("dbo.Banks", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Banks", "ProvinceId", c => c.Int());
            AddColumn("dbo.Banks", "Zip", c => c.String(maxLength: 8));
            AddColumn("dbo.Banks", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Banks", "Suburb", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Banks", "SecondAddressLine", c => c.String(maxLength: 255));
            AddColumn("dbo.Banks", "FirstAddressLine", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.BankOffices", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.BankOffices", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.BankOffices", "BankId", "dbo.Banks");
            DropIndex("dbo.BankOffices", new[] { "BankId" });
            DropIndex("dbo.BankOffices", new[] { "CountryId" });
            DropIndex("dbo.BankOffices", new[] { "ProvinceId" });
            DropTable("dbo.BankOffices");
            CreateIndex("dbo.Banks", "CountryId");
            CreateIndex("dbo.Banks", "ProvinceId");
            AddForeignKey("dbo.Banks", "ProvinceId", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Banks", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
