namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactComments", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactComments", new[] { "ContactId" });
            DropTable("dbo.ContactComments");
        }
    }
}
