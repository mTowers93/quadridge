namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsAndAdjustClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clients", "BankReferralId", c => c.Int());
            AddColumn("dbo.Clients", "LawFirmReferralId", c => c.Int());
            AddColumn("dbo.Clients", "Bank_Id", c => c.Int());
            CreateIndex("dbo.Clients", "Bank_Id");
            AddForeignKey("dbo.Clients", "Bank_Id", "dbo.Banks", "Id");
            DropColumn("dbo.Clients", "Firstname");
            DropColumn("dbo.Clients", "Surname");
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Clients", "CellNo");
            DropColumn("dbo.Clients", "BusinessNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "BusinessNo", c => c.String(maxLength: 10));
            AddColumn("dbo.Clients", "CellNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Clients", "Surname", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Clients", "Firstname", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Clients", "Bank_Id", "dbo.Banks");
            DropIndex("dbo.Clients", new[] { "Bank_Id" });
            DropColumn("dbo.Clients", "Bank_Id");
            DropColumn("dbo.Clients", "LawFirmReferralId");
            DropColumn("dbo.Clients", "BankReferralId");
            DropColumn("dbo.Clients", "Name");
        }
    }
}
