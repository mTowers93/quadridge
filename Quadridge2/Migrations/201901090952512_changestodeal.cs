namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestodeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "DirectorshipStartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deals", "DirectorshipStartDate");
        }
    }
}
