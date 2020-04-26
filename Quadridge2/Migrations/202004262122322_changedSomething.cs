namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedSomething : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Structures", "FinancialInstitution_Id", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Structures", "FinancialInstitutionId", "dbo.FinancialInstitutions");
            DropForeignKey("dbo.Structures", "OtherInstitutionId", "dbo.OtherInstitutions");
            DropIndex("dbo.Structures", new[] { "FinancialInstitutionId" });
            DropIndex("dbo.Structures", new[] { "OtherInstitutionId" });
            DropIndex("dbo.Structures", new[] { "FinancialInstitution_Id" });
            AddColumn("dbo.Structures", "InstituteId", c => c.Int());
            CreateIndex("dbo.Structures", "InstituteId");
            AddForeignKey("dbo.Structures", "InstituteId", "dbo.Institutes", "Id");
            DropColumn("dbo.Structures", "FinancialInstitutionId");
            DropColumn("dbo.Structures", "OtherInstitutionId");
            DropColumn("dbo.Structures", "FinancialInstitution_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Structures", "FinancialInstitution_Id", c => c.Int());
            AddColumn("dbo.Structures", "OtherInstitutionId", c => c.Int());
            AddColumn("dbo.Structures", "FinancialInstitutionId", c => c.Int());
            DropForeignKey("dbo.Structures", "InstituteId", "dbo.Institutes");
            DropIndex("dbo.Structures", new[] { "InstituteId" });
            DropColumn("dbo.Structures", "InstituteId");
            CreateIndex("dbo.Structures", "FinancialInstitution_Id");
            CreateIndex("dbo.Structures", "OtherInstitutionId");
            CreateIndex("dbo.Structures", "FinancialInstitutionId");
            AddForeignKey("dbo.Structures", "OtherInstitutionId", "dbo.OtherInstitutions", "Id");
            AddForeignKey("dbo.Structures", "FinancialInstitutionId", "dbo.FinancialInstitutions", "Id");
            AddForeignKey("dbo.Structures", "FinancialInstitution_Id", "dbo.FinancialInstitutions", "Id");
        }
    }
}
