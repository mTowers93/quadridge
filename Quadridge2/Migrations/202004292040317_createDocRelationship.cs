namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDocRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AspNetUsers", "UserPhotoId");
            AddForeignKey("dbo.AspNetUsers", "UserPhotoId", "dbo.Documents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserPhotoId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserPhotoId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
        }
    }
}
