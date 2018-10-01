namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProvince : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Provinces VALUES ('EC', 'Eastern Cape')");
            Sql("INSERT INTO Provinces VALUES ('FS', 'Free State')");
            Sql("INSERT INTO Provinces VALUES ('GT', 'Gauteng')");
            Sql("INSERT INTO Provinces VALUES ('NL', 'KwaZulu-Natal')");
            Sql("INSERT INTO Provinces VALUES ('LP', 'Limpopo')");
            Sql("INSERT INTO Provinces VALUES ('MP', 'Mpumulanga')");
            Sql("INSERT INTO Provinces VALUES ('NW', 'North West')");
            Sql("INSERT INTO Provinces VALUES ('NC', 'Northern Cape')");
            Sql("INSERT INTO Provinces VALUES ('WC', 'Western Cape')");
        }
        
        public override void Down()
        {
        }
    }
}
