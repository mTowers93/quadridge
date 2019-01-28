namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBanksToFinancialInstitutions : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Banks", newName: "FinancialInstitutions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FinancialInstitutions", newName: "Banks");
        }
    }
}
