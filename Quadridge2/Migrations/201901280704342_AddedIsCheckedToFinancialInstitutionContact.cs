namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsCheckedToFinancialInstitutionContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinancialInstitutionContacts", "IsChecked", c => c.Boolean(nullable: false));
            AddColumn("dbo.CompanyServices", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyServices", "IsChecked");
            DropColumn("dbo.FinancialInstitutionContacts", "IsChecked");
        }
    }
}
