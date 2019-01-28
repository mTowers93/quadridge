namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointmentDateToTrust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trusts", "AppointmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trusts", "TrusteeRepresentitive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trusts", "TrusteeRepresentitive");
            DropColumn("dbo.Trusts", "AppointmentDate");
        }
    }
}
