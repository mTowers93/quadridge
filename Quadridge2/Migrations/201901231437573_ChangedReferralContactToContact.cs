namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedReferralContactToContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Structures", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.Structures", name: "Contact_Id", newName: "ContactId");
            AlterColumn("dbo.Structures", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Structures", "ContactId");
            AddForeignKey("dbo.Structures", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            DropColumn("dbo.Structures", "ReferralContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Structures", "ReferralContactId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "ContactId" });
            AlterColumn("dbo.Structures", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.Structures", name: "ContactId", newName: "Contact_Id");
            CreateIndex("dbo.Structures", "Contact_Id");
            AddForeignKey("dbo.Structures", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
