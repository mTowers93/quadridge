namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStructureCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StructureCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Structures", "StructureCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Structures", "StructureCategoryId");
            AddForeignKey("dbo.Structures", "StructureCategoryId", "dbo.StructureCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "StructureCategoryId", "dbo.StructureCategories");
            DropIndex("dbo.Structures", new[] { "StructureCategoryId" });
            DropColumn("dbo.Structures", "StructureCategoryId");
            DropTable("dbo.StructureCategories");
        }
    }
}
