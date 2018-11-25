namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBankClient : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropTable("dbo.BankClients");
        }
    }
}
