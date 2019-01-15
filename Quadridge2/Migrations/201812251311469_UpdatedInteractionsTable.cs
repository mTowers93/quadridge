namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedInteractionsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interactions", "InteractionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Interactions", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Interactions", "Comment", c => c.String());
            CreateIndex("dbo.Interactions", "ClientId");
            AddForeignKey("dbo.Interactions", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interactions", "ClientId", "dbo.Clients");
            DropIndex("dbo.Interactions", new[] { "ClientId" });
            DropColumn("dbo.Interactions", "Comment");
            DropColumn("dbo.Interactions", "ClientId");
            DropColumn("dbo.Interactions", "InteractionDate");
        }
    }
}
