namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContactConrtyToCountry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Contacts", new[] { "Country_Id" });
            RenameColumn(table: "dbo.Contacts", name: "Country_Id", newName: "CountryId");
            AlterColumn("dbo.Contacts", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "CountryId");
            AddForeignKey("dbo.Contacts", "CountryId", "dbo.Countries", "Id", cascadeDelete: false);
            DropColumn("dbo.Contacts", "CoutnryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "CoutnryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contacts", "CountryId", "dbo.Countries");
            DropIndex("dbo.Contacts", new[] { "CountryId" });
            AlterColumn("dbo.Contacts", "CountryId", c => c.Int());
            RenameColumn(table: "dbo.Contacts", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.Contacts", "Country_Id");
            AddForeignKey("dbo.Contacts", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
