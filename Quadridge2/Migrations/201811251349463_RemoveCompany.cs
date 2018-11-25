namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCompany : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Companies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        AddressLine1 = c.String(nullable: false, maxLength: 255),
                        AddressLine2 = c.String(maxLength: 255),
                        Suburb = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 255),
                        Zip = c.String(maxLength: 8),
                        Province = c.String(maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
