namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameBankContactToFinancialContact : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BankContacts", newName: "FinancialInstitutionContacts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FinancialInstitutionContacts", newName: "BankContacts");
        }
    }
}
