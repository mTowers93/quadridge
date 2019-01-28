namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStructureContactAndCompanyContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyContacts",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ContactId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.StructureContacts",
                c => new
                    {
                        StructureId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StructureId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .Index(t => t.StructureId)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.StructureContacts", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.StructureContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.CompanyContacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.StructureContacts", new[] { "ContactId" });
            DropIndex("dbo.StructureContacts", new[] { "StructureId" });
            DropIndex("dbo.CompanyContacts", new[] { "ContactId" });
            DropIndex("dbo.CompanyContacts", new[] { "CompanyId" });
            DropTable("dbo.StructureContacts");
            DropTable("dbo.CompanyContacts");
        }
    }
}
