namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStructureTrustsEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Contacts", new[] { "ClientId" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReferralId = c.Int(nullable: false),
                        TrustId = c.Int(nullable: false),
                        StructureId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Structures", t => t.StructureId)
                .ForeignKey("dbo.Trusts", t => t.TrustId, cascadeDelete: true)
                .Index(t => t.TrustId)
                .Index(t => t.StructureId);
            
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trusts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        StructureId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Structures", t => t.StructureId)
                .Index(t => t.StructureId);
            
            AddColumn("dbo.Contacts", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "EntityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "EntityId");
            AddForeignKey("dbo.Contacts", "EntityId", "dbo.Entities", "Id", cascadeDelete: true);
            DropColumn("dbo.Contacts", "ClientId");
            DropColumn("dbo.Contacts", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "CompanyId", c => c.Int());
            AddColumn("dbo.Contacts", "ClientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contacts", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Entities", "TrustId", "dbo.Trusts");
            DropForeignKey("dbo.Trusts", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.Entities", "StructureId", "dbo.Structures");
            DropIndex("dbo.Trusts", new[] { "StructureId" });
            DropIndex("dbo.Entities", new[] { "StructureId" });
            DropIndex("dbo.Entities", new[] { "TrustId" });
            DropIndex("dbo.Contacts", new[] { "EntityId" });
            DropColumn("dbo.Contacts", "EntityId");
            DropColumn("dbo.Contacts", "Birthday");
            DropTable("dbo.Trusts");
            DropTable("dbo.Structures");
            DropTable("dbo.Entities");
            CreateIndex("dbo.Contacts", "CompanyId");
            CreateIndex("dbo.Contacts", "ClientId");
            AddForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Contacts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
