namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCompanyService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyServices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.CompanyServices", "Company_Id", "dbo.Companies");
            DropIndex("dbo.CompanyServices", new[] { "Service_Id" });
            DropIndex("dbo.CompanyServices", new[] { "Company_Id" });
            DropTable("dbo.CompanyServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CompanyServices",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Company_Id });
            
            CreateIndex("dbo.CompanyServices", "Company_Id");
            CreateIndex("dbo.CompanyServices", "Service_Id");
            AddForeignKey("dbo.CompanyServices", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyServices", "Service_Id", "dbo.Services", "Id", cascadeDelete: true);
        }
    }
}
