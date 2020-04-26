namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "City");
        }
    }
}
