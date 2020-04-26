namespace Quadridge2.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class populateProvinces : DbMigration
  {
    public override void Up()
    {
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('EC', 'Eastern Cape')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('FS', 'Free State')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('GT', 'Gauteng')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('NL', 'KwaZulu-Natal')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('LP', 'Limpopo')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('MP', 'Mpumalanga')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('NC', 'Northern Cape')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('NW', 'North West')");
      Sql("INSERT INTO Provinces (Code, Name)  VALUES ('WC', 'Western Cape')");
    }

    public override void Down()
    {
    }
  }
}
