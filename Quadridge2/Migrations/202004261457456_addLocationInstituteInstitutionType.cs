namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLocationInstituteInstitutionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InstitutionTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        firstLine = c.String(),
                        SecondLine = c.String(),
                        Suburb = c.String(),
                        PostalCode = c.String(),
                        ProvinceId = c.Int(),
                        CountryId = c.Int(nullable: false),
                        InstituteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Institutes", t => t.InstituteId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.InstituteId);
            
            CreateTable(
                "dbo.InstitutionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Institutes", "Type_Id", "dbo.InstitutionTypes");
            DropForeignKey("dbo.Locations", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Locations", "InstituteId", "dbo.Institutes");
            DropForeignKey("dbo.Locations", "CountryId", "dbo.Countries");
            DropIndex("dbo.Locations", new[] { "InstituteId" });
            DropIndex("dbo.Locations", new[] { "CountryId" });
            DropIndex("dbo.Locations", new[] { "ProvinceId" });
            DropIndex("dbo.Institutes", new[] { "Type_Id" });
            DropTable("dbo.InstitutionTypes");
            DropTable("dbo.Locations");
            DropTable("dbo.Institutes");
        }
    }
}
