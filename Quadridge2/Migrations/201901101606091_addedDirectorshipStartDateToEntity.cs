namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDirectorshipStartDateToEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entities", "DirectorshipStartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entities", "DirectorshipStartDate");
        }
    }
}
