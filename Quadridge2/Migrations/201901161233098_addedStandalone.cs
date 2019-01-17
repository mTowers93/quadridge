namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStandalone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StandaloneContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandAloneId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StandaloneContacts", "StandAloneId", "dbo.Standalones");
            DropForeignKey("dbo.Standalones", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Standalones", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.StandaloneContacts", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Standalones", new[] { "CountryId" });
            DropIndex("dbo.Standalones", new[] { "ProvinceId" });
            DropIndex("dbo.StandaloneContacts", new[] { "ContactId" });
            DropIndex("dbo.StandaloneContacts", new[] { "StandAloneId" });
            DropTable("dbo.Standalones");
            DropTable("dbo.StandaloneContacts");
        }
    }
}
