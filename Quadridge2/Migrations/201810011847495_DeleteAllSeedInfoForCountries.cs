namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllSeedInfoForCountries : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Countries");
            Sql("DELETE FROM Provinces");
        }
        
        public override void Down()
        {
        }
    }
}
