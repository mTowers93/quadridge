namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyServices",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Company_Id })
                .ForeignKey("dbo.Companies", t => t.Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyServices", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.CompanyServices", "Service_Id", "dbo.Services");
            DropIndex("dbo.CompanyServices", new[] { "Company_Id" });
            DropIndex("dbo.CompanyServices", new[] { "Service_Id" });
            DropTable("dbo.CompanyServices");
        }
    }
}
