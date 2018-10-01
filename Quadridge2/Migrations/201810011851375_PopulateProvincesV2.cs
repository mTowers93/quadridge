namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProvincesV2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('EC', 'Eastern Cape')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('FS', 'Free State')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('GT', 'Gauteng')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('NL', 'KwaZulu-Natal')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('LP', 'Limpopo')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('MP', 'Mpumalanga')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('NC', 'Northern Cape')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('NW', 'North West')");
            Sql("INSERT INTO Countries (Code, Name)  VALUES ('WC', 'Western Cape')");
        }
        
        public override void Down()
        {
        }
    }
}
