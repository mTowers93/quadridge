namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedEntityValuesToBeNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis");
            DropForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes");
            DropForeignKey("dbo.Entities", "TrustId", "dbo.Trusts");
            DropIndex("dbo.Entities", new[] { "BillingBasisId" });
            DropIndex("dbo.Entities", new[] { "FeeTypeId" });
            DropIndex("dbo.Entities", new[] { "TrustId" });
            AlterColumn("dbo.Entities", "BillingBasisId", c => c.Int());
            AlterColumn("dbo.Entities", "FeeTypeId", c => c.Int());
            AlterColumn("dbo.Entities", "TrustId", c => c.Int());
            CreateIndex("dbo.Entities", "BillingBasisId");
            CreateIndex("dbo.Entities", "FeeTypeId");
            CreateIndex("dbo.Entities", "TrustId");
            AddForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis", "Id");
            AddForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes", "Id");
            AddForeignKey("dbo.Entities", "TrustId", "dbo.Trusts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entities", "TrustId", "dbo.Trusts");
            DropForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes");
            DropForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis");
            DropIndex("dbo.Entities", new[] { "TrustId" });
            DropIndex("dbo.Entities", new[] { "FeeTypeId" });
            DropIndex("dbo.Entities", new[] { "BillingBasisId" });
            AlterColumn("dbo.Entities", "TrustId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entities", "FeeTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entities", "BillingBasisId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entities", "TrustId");
            CreateIndex("dbo.Entities", "FeeTypeId");
            CreateIndex("dbo.Entities", "BillingBasisId");
            AddForeignKey("dbo.Entities", "TrustId", "dbo.Trusts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entities", "FeeTypeId", "dbo.FeeTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entities", "BillingBasisId", "dbo.BillingBasis", "Id", cascadeDelete: true);
        }
    }
}
