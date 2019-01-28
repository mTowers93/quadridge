namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFinancialInstitutionContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinancialInstitutionContacts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.FinancialInstitutionContacts", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "FinancialInstitutionId" });
            DropIndex("dbo.FinancialInstitutionContacts", new[] { "ContactId" });
            DropTable("dbo.FinancialInstitutionContacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FinancialInstitutionContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FinancialInstitutionId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.FinancialInstitutionContacts", "ContactId");
            CreateIndex("dbo.FinancialInstitutionContacts", "FinancialInstitutionId");
            AddForeignKey("dbo.FinancialInstitutionContacts", "FinancialInstitutionId", "dbo.FinancialInstitutions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinancialInstitutionContacts", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
