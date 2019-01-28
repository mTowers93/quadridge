namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFinancialContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinancialInstitutionContacts",
                c => new
                    {
                        FinancialInstitutionId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FinancialInstitutionId, t.ContactId })
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.FinancialInstitutions", t => t.FinancialInstitutionId, cascadeDelete: true)
                .Index(t => t.FinancialInstitutionId)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinancialInstitutionContacts", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.FinancialInstitutionContacts", "ContactId", "dbo.Contacts");
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "ContactId" });
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "FinancialInstitutionId" });
            DropTable("dbo.FinancialInstitutionContacts");
        }
    }
}
