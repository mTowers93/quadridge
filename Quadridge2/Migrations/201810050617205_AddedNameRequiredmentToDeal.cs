namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameRequiredmentToDeal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deals", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Deals", "BankId");
            CreateIndex("dbo.Deals", "StatusId");
            CreateIndex("dbo.Deals", "LawyerId");
            AddForeignKey("dbo.Deals", "BankId", "dbo.Banks", "Id");
            AddForeignKey("dbo.Deals", "LawyerId", "dbo.Lawyers", "Id");
            AddForeignKey("dbo.Deals", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Deals", "LawyerId", "dbo.Lawyers");
            DropForeignKey("dbo.Deals", "BankId", "dbo.Banks");
            DropIndex("dbo.Deals", new[] { "LawyerId" });
            DropIndex("dbo.Deals", new[] { "StatusId" });
            DropIndex("dbo.Deals", new[] { "BankId" });
            AlterColumn("dbo.Deals", "Name", c => c.String());
        }
    }
}
