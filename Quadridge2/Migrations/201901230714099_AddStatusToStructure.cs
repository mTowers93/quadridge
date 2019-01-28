namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Structures", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Structures", "StatusId");
            AddForeignKey("dbo.Structures", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "StatusId", "dbo.Status");
            DropIndex("dbo.Structures", new[] { "StatusId" });
            DropColumn("dbo.Structures", "StatusId");
        }
    }
}
