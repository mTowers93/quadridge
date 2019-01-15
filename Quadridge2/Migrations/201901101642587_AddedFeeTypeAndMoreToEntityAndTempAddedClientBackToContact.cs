namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeeTypeAndMoreToEntityAndTempAddedClientBackToContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Entities", "FirstBillingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Entities", "BillingBasis", c => c.String());
            AddColumn("dbo.Entities", "FeeType_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "ClientId");
            CreateIndex("dbo.Entities", "FeeType_Id");
            AddForeignKey("dbo.Contacts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entities", "FeeType_Id", "dbo.FeeTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "FeeType_Id", "dbo.FeeTypes");
            DropForeignKey("dbo.Contacts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Entities", new[] { "FeeType_Id" });
            DropIndex("dbo.Contacts", new[] { "ClientId" });
            DropColumn("dbo.Entities", "FeeType_Id");
            DropColumn("dbo.Entities", "BillingBasis");
            DropColumn("dbo.Entities", "FirstBillingDate");
            DropColumn("dbo.Contacts", "ClientId");
            DropTable("dbo.FeeTypes");
        }
    }
}
