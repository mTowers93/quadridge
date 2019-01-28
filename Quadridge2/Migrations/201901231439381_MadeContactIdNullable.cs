namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeContactIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "ContactId" });
            AlterColumn("dbo.Structures", "ContactId", c => c.Int());
            CreateIndex("dbo.Structures", "ContactId");
            AddForeignKey("dbo.Structures", "ContactId", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "ContactId" });
            AlterColumn("dbo.Structures", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Structures", "ContactId");
            AddForeignKey("dbo.Structures", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
