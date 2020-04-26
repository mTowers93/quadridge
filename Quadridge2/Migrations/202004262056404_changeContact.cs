namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "InstituteId", c => c.Int());
            CreateIndex("dbo.Contacts", "InstituteId");
            AddForeignKey("dbo.Contacts", "InstituteId", "dbo.Institutes", "Id");
            DropColumn("dbo.Contacts", "IsLawFirmContact");
            DropColumn("dbo.Contacts", "IsFinancialContact");
            DropColumn("dbo.Contacts", "IsStandalone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IsStandalone", c => c.Boolean());
            AddColumn("dbo.Contacts", "IsFinancialContact", c => c.Boolean());
            AddColumn("dbo.Contacts", "IsLawFirmContact", c => c.Boolean());
            DropForeignKey("dbo.Contacts", "InstituteId", "dbo.Institutes");
            DropIndex("dbo.Contacts", new[] { "InstituteId" });
            DropColumn("dbo.Contacts", "InstituteId");
        }
    }
}
