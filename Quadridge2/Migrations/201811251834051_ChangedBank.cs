namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "FirstAddressLine", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Banks", "SecondAddressLine", c => c.String(maxLength: 255));
            AddColumn("dbo.Banks", "Suburb", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Banks", "City", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Banks", "Zip", c => c.String(maxLength: 8));
            AddColumn("dbo.Banks", "ProvinceId", c => c.Int());
            AddColumn("dbo.Banks", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Banks", "ProvinceId");
            CreateIndex("dbo.Banks", "CountryId");
            AddForeignKey("dbo.Banks", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Banks", "ProvinceId", "dbo.Provinces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Banks", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Banks", "CountryId", "dbo.Countries");
            DropIndex("dbo.Banks", new[] { "CountryId" });
            DropIndex("dbo.Banks", new[] { "ProvinceId" });
            DropColumn("dbo.Banks", "CountryId");
            DropColumn("dbo.Banks", "ProvinceId");
            DropColumn("dbo.Banks", "Zip");
            DropColumn("dbo.Banks", "City");
            DropColumn("dbo.Banks", "Suburb");
            DropColumn("dbo.Banks", "SecondAddressLine");
            DropColumn("dbo.Banks", "FirstAddressLine");
        }
    }
}
