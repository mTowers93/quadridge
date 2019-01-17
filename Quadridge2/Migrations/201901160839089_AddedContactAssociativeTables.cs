namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContactAssociativeTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ServiceEntities", newName: "EntityServices");
            DropForeignKey("dbo.Comments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Companies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Companies", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Contacts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Contacts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Contacts", "EntityId", "dbo.Entities");
            DropForeignKey("dbo.Contacts", "LawfirmId", "dbo.LawFirms");
            DropIndex("dbo.Comments", new[] { "ClientId" });
            DropIndex("dbo.Companies", new[] { "ProvinceId" });
            DropIndex("dbo.Companies", new[] { "CountryId" });
            DropIndex("dbo.Contacts", new[] { "ClientId" });
            DropIndex("dbo.Contacts", new[] { "LawfirmId" });
            DropIndex("dbo.Contacts", new[] { "BankId" });
            DropIndex("dbo.Contacts", new[] { "EntityId" });
            DropPrimaryKey("dbo.EntityServices");
            CreateTable(
                "dbo.BankContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.StructureComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StructureId = c.Int(nullable: false),
                        CommentString = c.String(nullable: false, maxLength: 512),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Structures", t => t.StructureId, cascadeDelete: true)
                .Index(t => t.StructureId);
            
            CreateTable(
                "dbo.LawFirmContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LawFirmId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.LawFirms", t => t.LawFirmId, cascadeDelete: true)
                .Index(t => t.LawFirmId)
                .Index(t => t.ContactId);
            
            AddPrimaryKey("dbo.EntityServices", new[] { "Entity_Id", "Service_Id" });
            DropColumn("dbo.Contacts", "ClientId");
            DropColumn("dbo.Contacts", "LawfirmId");
            DropColumn("dbo.Contacts", "BankId");
            DropColumn("dbo.Contacts", "EntityId");
            DropTable("dbo.Comments");
            DropTable("dbo.Companies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        FirstAddressLine = c.String(nullable: false, maxLength: 255),
                        SecondAddressLine = c.String(maxLength: 255),
                        Suburb = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 100),
                        Zip = c.String(maxLength: 8),
                        ProvinceId = c.Int(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        CommentString = c.String(nullable: false, maxLength: 512),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "EntityId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "BankId", c => c.Int());
            AddColumn("dbo.Contacts", "LawfirmId", c => c.Int());
            AddColumn("dbo.Contacts", "ClientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LawFirmContacts", "LawFirmId", "dbo.LawFirms");
            DropForeignKey("dbo.LawFirmContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.StructureComments", "StructureId", "dbo.Structures");
            DropForeignKey("dbo.BankContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Interests", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.BankContacts", "BankId", "dbo.Banks");
            DropIndex("dbo.LawFirmContacts", new[] { "ContactId" });
            DropIndex("dbo.LawFirmContacts", new[] { "LawFirmId" });
            DropIndex("dbo.StructureComments", new[] { "StructureId" });
            DropIndex("dbo.Interests", new[] { "ContactId" });
            DropIndex("dbo.BankContacts", new[] { "ContactId" });
            DropIndex("dbo.BankContacts", new[] { "BankId" });
            DropPrimaryKey("dbo.EntityServices");
            DropTable("dbo.LawFirmContacts");
            DropTable("dbo.StructureComments");
            DropTable("dbo.Interests");
            DropTable("dbo.BankContacts");
            AddPrimaryKey("dbo.EntityServices", new[] { "Service_Id", "Entity_Id" });
            CreateIndex("dbo.Contacts", "EntityId");
            CreateIndex("dbo.Contacts", "BankId");
            CreateIndex("dbo.Contacts", "LawfirmId");
            CreateIndex("dbo.Contacts", "ClientId");
            CreateIndex("dbo.Companies", "CountryId");
            CreateIndex("dbo.Companies", "ProvinceId");
            CreateIndex("dbo.Comments", "ClientId");
            AddForeignKey("dbo.Contacts", "LawfirmId", "dbo.LawFirms", "Id");
            AddForeignKey("dbo.Contacts", "EntityId", "dbo.Entities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "BankId", "dbo.Banks", "Id");
            AddForeignKey("dbo.Companies", "ProvinceId", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Companies", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.EntityServices", newName: "ServiceEntities");
        }
    }
}
