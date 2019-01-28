namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrustService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrustServices",
                c => new
                    {
                        TrustId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrustId, t.ServiceId })
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Trusts", t => t.TrustId, cascadeDelete: true)
                .Index(t => t.TrustId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrustServices", "TrustId", "dbo.Trusts");
            DropForeignKey("dbo.TrustServices", "ServiceId", "dbo.Services");
            DropIndex("dbo.TrustServices", new[] { "ServiceId" });
            DropIndex("dbo.TrustServices", new[] { "TrustId" });
            DropTable("dbo.TrustServices");
        }
    }
}
