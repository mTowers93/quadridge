namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServicesAndUpdatedDeals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Deals", "StructureName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Deals", "FirstBillingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Deals", "BillingBasis", c => c.String());
            AddColumn("dbo.Deals", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Deals", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deals", "ServiceId");
            CreateIndex("dbo.Deals", "ClientId");
            AddForeignKey("dbo.Deals", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Deals", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            DropColumn("dbo.Deals", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deals", "Name", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Deals", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Deals", "ClientId", "dbo.Clients");
            DropIndex("dbo.Deals", new[] { "ClientId" });
            DropIndex("dbo.Deals", new[] { "ServiceId" });
            DropColumn("dbo.Deals", "ClientId");
            DropColumn("dbo.Deals", "ServiceId");
            DropColumn("dbo.Deals", "BillingBasis");
            DropColumn("dbo.Deals", "FirstBillingDate");
            DropColumn("dbo.Deals", "StructureName");
            DropTable("dbo.Services");
        }
    }
}
