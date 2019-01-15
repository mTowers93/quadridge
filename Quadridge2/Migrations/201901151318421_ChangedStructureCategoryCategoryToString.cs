namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStructureCategoryCategoryToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StructureCategories", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StructureCategories", "Category", c => c.Int(nullable: false));
        }
    }
}
