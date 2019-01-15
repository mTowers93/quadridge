namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntityServicesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceEntities",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Entity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Entity_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Entities", t => t.Entity_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Entity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceEntities", "Entity_Id", "dbo.Entities");
            DropForeignKey("dbo.ServiceEntities", "Service_Id", "dbo.Services");
            DropIndex("dbo.ServiceEntities", new[] { "Entity_Id" });
            DropIndex("dbo.ServiceEntities", new[] { "Service_Id" });
            DropTable("dbo.ServiceEntities");
        }
    }
}
