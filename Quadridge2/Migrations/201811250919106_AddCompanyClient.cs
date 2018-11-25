namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ReferralBankId = c.Int(),
                        ReferralLawFirmId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyClients");
        }
    }
}
