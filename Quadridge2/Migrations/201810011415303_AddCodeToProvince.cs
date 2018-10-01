namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeToProvince : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provinces", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Provinces", "Code");
        }
    }
}
