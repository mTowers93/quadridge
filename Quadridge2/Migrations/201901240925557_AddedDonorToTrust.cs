namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDonorToTrust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trusts", "Donor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trusts", "Donor");
        }
    }
}
