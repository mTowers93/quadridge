namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProvinceAndCountryIdToClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Clients", new[] { "Country_Id" });
            RenameColumn(table: "dbo.Clients", name: "Country_Id", newName: "CountryId");
            RenameColumn(table: "dbo.Clients", name: "Province_Id", newName: "ProvinceId");
            RenameIndex(table: "dbo.Clients", name: "IX_Province_Id", newName: "IX_ProvinceId");
            AlterColumn("dbo.Clients", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "CountryId");
            AddForeignKey("dbo.Clients", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropIndex("dbo.Clients", new[] { "CountryId" });
            AlterColumn("dbo.Clients", "CountryId", c => c.Int());
            RenameIndex(table: "dbo.Clients", name: "IX_ProvinceId", newName: "IX_Province_Id");
            RenameColumn(table: "dbo.Clients", name: "ProvinceId", newName: "Province_Id");
            RenameColumn(table: "dbo.Clients", name: "CountryId", newName: "Country_Id");
            CreateIndex("dbo.Clients", "Country_Id");
            AddForeignKey("dbo.Clients", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
