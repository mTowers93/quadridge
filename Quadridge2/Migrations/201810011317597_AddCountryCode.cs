namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "code");
        }
    }
}
