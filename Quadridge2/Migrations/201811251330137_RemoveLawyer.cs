namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLawyer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deals", "LawyerId", "dbo.Lawyers");
            DropIndex("dbo.Deals", new[] { "LawyerId" });
            CreateTable(
                "dbo.LawFirms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
            
            AddColumn("dbo.Deals", "LawFirmId", c => c.Int());
            CreateIndex("dbo.Deals", "LawFirmId");
            AddForeignKey("dbo.Deals", "LawFirmId", "dbo.LawFirms", "Id");
            DropColumn("dbo.Deals", "LawyerId");
            DropTable("dbo.Lawyers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lawyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Firm = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        ContactNo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Deals", "LawyerId", c => c.Int());
            DropForeignKey("dbo.Deals", "LawFirmId", "dbo.LawFirms");
            DropForeignKey("dbo.LawFirms", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.LawFirms", "CountryId", "dbo.Countries");
            DropIndex("dbo.LawFirms", new[] { "CountryId" });
            DropIndex("dbo.LawFirms", new[] { "ProvinceId" });
            DropIndex("dbo.Deals", new[] { "LawFirmId" });
            DropColumn("dbo.Deals", "LawFirmId");
            DropTable("dbo.LawFirms");
            CreateIndex("dbo.Deals", "LawyerId");
            AddForeignKey("dbo.Deals", "LawyerId", "dbo.Lawyers", "Id");
        }
    }
}
