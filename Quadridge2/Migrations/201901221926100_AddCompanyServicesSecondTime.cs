namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyServicesSecondTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyServices",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ServiceId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.CompanyServices", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompanyServices", new[] { "ServiceId" });
            DropIndex("dbo.CompanyServices", new[] { "CompanyId" });
            DropTable("dbo.CompanyServices");
        }
    }
}
