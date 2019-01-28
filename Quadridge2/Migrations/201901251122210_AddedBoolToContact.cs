namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsLawFirmContact", c => c.Boolean());
            AddColumn("dbo.Contacts", "IsFinancialContact", c => c.Boolean());
            AddColumn("dbo.Contacts", "IsStandalone", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsStandalone");
            DropColumn("dbo.Contacts", "IsFinancialContact");
            DropColumn("dbo.Contacts", "IsLawFirmContact");
        }
    }
}
