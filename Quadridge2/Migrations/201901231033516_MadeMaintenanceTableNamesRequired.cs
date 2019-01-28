namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeMaintenanceTableNamesRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BillingBasis", "Basis", c => c.String(nullable: false));
            AlterColumn("dbo.StructureCategories", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.FeeTypes", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.InteractionTypes", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InteractionTypes", "Type", c => c.String());
            AlterColumn("dbo.FeeTypes", "Type", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            AlterColumn("dbo.StructureCategories", "Category", c => c.String());
            AlterColumn("dbo.BillingBasis", "Basis", c => c.String());
        }
    }
}
