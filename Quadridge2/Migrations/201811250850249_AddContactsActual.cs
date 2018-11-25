namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactsActual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        lawfirm = c.Int(),
                        CompanyId = c.Int(),
                        BankId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 100),
                        ContactNo = c.String(nullable: false, maxLength: 15),
                        AltContactNo = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
