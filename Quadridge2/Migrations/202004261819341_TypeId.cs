namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Institutes", "Type_Id", "dbo.InstitutionTypes");
            DropIndex("dbo.Institutes", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Institutes", name: "Type_Id", newName: "TypeId");
            AlterColumn("dbo.Institutes", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Institutes", "TypeId");
            AddForeignKey("dbo.Institutes", "TypeId", "dbo.InstitutionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Institutes", "TypeId", "dbo.InstitutionTypes");
            DropIndex("dbo.Institutes", new[] { "TypeId" });
            AlterColumn("dbo.Institutes", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Institutes", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.Institutes", "Type_Id");
            AddForeignKey("dbo.Institutes", "Type_Id", "dbo.InstitutionTypes", "Id");
        }
    }
}
