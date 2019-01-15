namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedReferralToStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Structures", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Structures", "ContactId");
            AddForeignKey("dbo.Structures", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            DropColumn("dbo.Entities", "ReferralId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "ReferralId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "ContactId" });
            DropColumn("dbo.Structures", "ContactId");
        }
    }
}
