namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interests", "InterestText", c => c.String(nullable: false));
            AddColumn("dbo.Entities", "RegistrationNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entities", "RegistrationNumber");
            DropColumn("dbo.Interests", "InterestText");
        }
    }
}
