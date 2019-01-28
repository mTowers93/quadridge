namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOtherInstitutionAndAddressToContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Structures", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Structures", new[] { "ContactId" });
            RenameColumn(table: "dbo.Structures", name: "ContactId", newName: "Contact_Id");
            CreateTable(
                "dbo.OtherInstitutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherInstitutionContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        OtherInstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.OtherInstitutions", t => t.OtherInstitutionId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.OtherInstitutionId);
            
            AddColumn("dbo.Contacts", "FirstAddressLine", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "SecondAddressLine", c => c.String());
            AddColumn("dbo.Contacts", "Suburb", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "City", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "Zip", c => c.String(nullable: false));
            AddColumn("dbo.Contacts", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "CoutnryId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "Country_Id", c => c.Int());
            AddColumn("dbo.Structures", "ReferralContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Structures", "FinancialInstitutionId", c => c.Int());
            AddColumn("dbo.Structures", "OtherInstitutionId", c => c.Int());
            AlterColumn("dbo.Structures", "Contact_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "ProvinceId");
            CreateIndex("dbo.Contacts", "Country_Id");
            CreateIndex("dbo.Structures", "FinancialInstitutionId");
            CreateIndex("dbo.Structures", "OtherInstitutionId");
            CreateIndex("dbo.Structures", "Contact_Id");
            AddForeignKey("dbo.Contacts", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Contacts", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Structures", "FinancialInstitutionId", "dbo.FinancialInstitutions", "Id");
            AddForeignKey("dbo.Structures", "OtherInstitutionId", "dbo.OtherInstitutions", "Id");
            AddForeignKey("dbo.Structures", "Contact_Id", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.OtherInstitutionContacts", "OtherInstitutionId", "dbo.OtherInstitutions");
            DropForeignKey("dbo.OtherInstitutionContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Structures", "OtherInstitutionId", "dbo.OtherInstitutions");
            DropForeignKey("dbo.Structures", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Contacts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Contacts", "Country_Id", "dbo.Countries");
            DropIndex("dbo.OtherInstitutionContacts", new[] { "OtherInstitutionId" });
            DropIndex("dbo.OtherInstitutionContacts", new[] { "ContactId" });
            DropIndex("dbo.Structures", new[] { "Contact_Id" });
            DropIndex("dbo.Structures", new[] { "OtherInstitutionId" });
            DropIndex("dbo.Structures", new[] { "FinancialInstitutionId" });
            DropIndex("dbo.Contacts", new[] { "Country_Id" });
            DropIndex("dbo.Contacts", new[] { "ProvinceId" });
            AlterColumn("dbo.Structures", "Contact_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Structures", "OtherInstitutionId");
            DropColumn("dbo.Structures", "FinancialInstitutionId");
            DropColumn("dbo.Structures", "ReferralContactId");
            DropColumn("dbo.Contacts", "Country_Id");
            DropColumn("dbo.Contacts", "CoutnryId");
            DropColumn("dbo.Contacts", "ProvinceId");
            DropColumn("dbo.Contacts", "Zip");
            DropColumn("dbo.Contacts", "City");
            DropColumn("dbo.Contacts", "Suburb");
            DropColumn("dbo.Contacts", "SecondAddressLine");
            DropColumn("dbo.Contacts", "FirstAddressLine");
            DropTable("dbo.OtherInstitutionContacts");
            DropTable("dbo.OtherInstitutions");
            RenameColumn(table: "dbo.Structures", name: "Contact_Id", newName: "ContactId");
            CreateIndex("dbo.Structures", "ContactId");
            AddForeignKey("dbo.Structures", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
