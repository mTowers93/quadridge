namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingEntityToCompany : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Entities", newName: "Companies");
            DropForeignKey("dbo.EntityServices", "Entity_Id", "dbo.Entities");
            DropForeignKey("dbo.EntityServices", "Service_Id", "dbo.Services");
            DropColumn("dbo.Clients", "CompanyId");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EntityServices",
                c => new
                    {
                        Entity_Id = c.Int(nullable: false),
                        Service_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Entity_Id, t.Service_Id });
            
            AddColumn("dbo.Clients", "CompanyId", c => c.Int());
            CreateIndex("dbo.EntityServices", "Service_Id");
            CreateIndex("dbo.EntityServices", "Entity_Id");
            AddForeignKey("dbo.EntityServices", "Service_Id", "dbo.Services", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EntityServices", "Entity_Id", "dbo.Entities", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Companies", newName: "Entities");
        }
    }
}
