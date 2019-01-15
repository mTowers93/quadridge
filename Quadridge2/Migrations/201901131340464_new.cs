namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entities", "FeeType_Id", "dbo.FeeTypes");
            DropIndex("dbo.Entities", new[] { "FeeType_Id" });
            RenameColumn(table: "dbo.Entities", name: "FeeType_Id", newName: "FeeTypeId");
            CreateTable(
                "dbo.BillingBasis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Basis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Entities", "BillingBasisId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entities", "FeeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entities", "BillingBasisId");
            CreateIndex("dbo.Entities", "FeeTypeId");
            AddForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Entities", "BillingBasis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "BillingBasis", c => c.String());
            DropForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes");
            DropForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis");
            DropIndex("dbo.Entities", new[] { "FeeTypeId" });
            DropIndex("dbo.Entities", new[] { "BillingBasisId" });
            AlterColumn("dbo.Entities", "FeeTypeId", c => c.Int());
            DropColumn("dbo.Entities", "BillingBasisId");
            DropTable("dbo.BillingBasis");
            RenameColumn(table: "dbo.Entities", name: "FeeTypeId", newName: "FeeType_Id");
            CreateIndex("dbo.Entities", "FeeType_Id");
            AddForeignKey("dbo.Entities", "FeeType_Id", "dbo.FeeTypes", "Id");
        }
    }
}
