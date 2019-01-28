namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class progressRenamingBank : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FinancialInstitutionContacts", name: "BankId", newName: "FinancialInstitutionId");
            RenameColumn(table: "dbo.Clients", name: "Bank_Id", newName: "FinancialInstitution_Id");
            RenameIndex(table: "dbo.Clients", name: "IX_Bank_Id", newName: "IX_FinancialInstitution_Id");
            RenameIndex(table: "dbo.FinancialInstitutionContacts", name: "IX_BankId", newName: "IX_FinancialInstitutionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FinancialInstitutionContacts", name: "IX_FinancialInstitutionId", newName: "IX_BankId");
            RenameIndex(table: "dbo.Clients", name: "IX_FinancialInstitution_Id", newName: "IX_Bank_Id");
            RenameColumn(table: "dbo.Clients", name: "FinancialInstitution_Id", newName: "Bank_Id");
            RenameColumn(table: "dbo.FinancialInstitutionContacts", name: "FinancialInstitutionId", newName: "BankId");
        }
    }
}
