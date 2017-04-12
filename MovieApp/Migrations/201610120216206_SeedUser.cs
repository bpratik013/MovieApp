namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'41ee1700-76d1-468d-ac5b-933f9693a388', N'pratikb087@gmail.com', 0, N'AFAx8Tymx5xT4kKzrPm7WWfGHYQEj6GdjRLt+P+oKJiWRoZ+NtSAe949TEcf4Ey/Vg==', N'892d91da-d352-438d-a22d-b270487a23f0', NULL, 0, 0, NULL, 1, 0, N'pratikb087@gmail.com')
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'50812247-149f-4833-8348-0ff3c4324a76', N'pratikb086@gmail.com', 0, N'ABGbZC5XU0DmgG/3wUrxPZ7q1ul6MgGvALaFnfdG00tHBctJsgQzJ1sY8km+8foo0g==', N'e9abf1df-3c53-4d4e-ac99-3eddecac1cee', NULL, 0, 0, NULL, 1, 0, N'pratikb086@gmail.com')
INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'9af4495b-4b71-4a4a-aaf9-4be57a233494', N'admin@gmail.com', 0, N'ANmSaB6y1N1El2Ata4dAs80s9acP3Ld/ybPph1ZIX78J3x4pSAjzSjj0mwaegHZAkg==', N'aa5b8e5e-f26a-4c67-9923-525e6b777bd4', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1ff38f59-0ad8-462a-ab68-5ba6c87784ee', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9af4495b-4b71-4a4a-aaf9-4be57a233494', N'1ff38f59-0ad8-462a-ab68-5ba6c87784ee')

");
        }
        
        public override void Down()
        {
        }
    }
}
