namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedBankAndCompanyClient : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BankClients");
            DropTable("dbo.CompanyClients");
        }
        
        public override void Down()
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
            
            CreateTable(
                "dbo.BankClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        ReferralBankId = c.Int(),
                        ReferralLawFirmId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
