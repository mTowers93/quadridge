namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAddressFromContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Contacts", new[] { "ProvinceId" });
            DropIndex("dbo.Contacts", new[] { "CountryId" });
            DropColumn("dbo.Contacts", "FirstAddressLine");
            DropColumn("dbo.Contacts", "SecondAddressLine");
            DropColumn("dbo.Contacts", "Suburb");
            DropColumn("dbo.Contacts", "City");
            DropColumn("dbo.Contacts", "Zip");
            DropColumn("dbo.Contacts", "ProvinceId");
            DropColumn("dbo.Contacts", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "Zip", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "City", c => c.String());
            AddColumn("dbo.Contacts", "Suburb", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "SecondAddressLine", c => c.String());
            AddColumn("dbo.Contacts", "FirstAddressLine", c => c.String(nullable: false));
            CreateIndex("dbo.Contacts", "CountryId");
            CreateIndex("dbo.Contacts", "ProvinceId");
            AddForeignKey("dbo.Contacts", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
