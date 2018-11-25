namespace Quadridge2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0e5f6c7-0f82-4a32-babc-d3b54417b713', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a27cec56-e24e-420c-a247-e96628fd5fc0', N'Employee')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2f6d3e94-0467-4c50-b9a2-89ff77dd9a6a', N'SuperUser')

            ");

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1dcadbc0-dda3-475e-8f5b-1bdf740cbe95', N'info@towersdesign.co.za', 0, N'AKca9CUlq5lVtXVqjiDGgbwxPtH9LSUWGTixUJ0O6298qX4FTwYkrUBlU16hXc7oLA==', N'32217e31-a416-4ab3-8db3-f84173c43b6b', NULL, 0, 0, NULL, 1, 0, N'info@towersdesign.co.za')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3d18739a-e90d-4dc7-811c-538d2389c778', N'employee@quadrige.co.za', 0, N'ANvx6maUP5JXaEcfzkWasRwAGw6YhoVgXtIh+Stxvk9i7xtK3ANP33/F3/UquIUf1Q==', N'a9fcb896-e014-496b-b3ef-d00addd23a58', NULL, 0, 0, NULL, 1, 0, N'employee@quadrige.co.za')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f47b2356-6933-430c-9c5c-21284af9a92c', N'monkeymann21@gmail.com', 0, N'ANaUEZXgl5HvH6CzEXG6UqOI3MiRDECfZ35xUtStk75lAaV4erEUMhht6Ep3xZA07g==', N'0f574463-8e61-423c-9602-eb342ef2766c', NULL, 0, 0, NULL, 1, 0, N'monkeymann21@gmail.com')

            ");

            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f47b2356-6933-430c-9c5c-21284af9a92c', N'2f6d3e94-0467-4c50-b9a2-89ff77dd9a6a')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d18739a-e90d-4dc7-811c-538d2389c778', N'a27cec56-e24e-420c-a247-e96628fd5fc0')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1dcadbc0-dda3-475e-8f5b-1bdf740cbe95', N'b0e5f6c7-0f82-4a32-babc-d3b54417b713')

            ");

            
        }
        
        public override void Down()
        {
        }
    }
}
