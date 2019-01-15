namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInteractionTypeAndUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InteractionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Interactions", "InteractionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Interactions", "InteractionTypeId");
            AddForeignKey("dbo.Interactions", "InteractionTypeId", "dbo.InteractionTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Interactions", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interactions", "Type", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Interactions", "InteractionTypeId", "dbo.InteractionTypes");
            DropIndex("dbo.Interactions", new[] { "InteractionTypeId" });
            DropColumn("dbo.Interactions", "InteractionTypeId");
            DropTable("dbo.InteractionTypes");
        }
    }
}
