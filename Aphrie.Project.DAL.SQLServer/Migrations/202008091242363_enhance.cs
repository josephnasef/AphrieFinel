namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoginLogins", "Login_Id", "dbo.Logins");
            DropForeignKey("dbo.LoginLogins", "Login_Id1", "dbo.Logins");
            DropForeignKey("dbo.Posts", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Posts", new[] { "Login_Id" });
            DropIndex("dbo.LoginLogins", new[] { "Login_Id" });
            DropIndex("dbo.LoginLogins", new[] { "Login_Id1" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Phone = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Users_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Users_Id1 })
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id1)
                .Index(t => t.Users_Id)
                .Index(t => t.Users_Id1);
            
            AddColumn("dbo.Posts", "User_Id", c => c.Int());
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Posts", "Login_Id");
            DropTable("dbo.Logins");
            DropTable("dbo.Registers");
            DropTable("dbo.LoginLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoginLogins",
                c => new
                    {
                        Login_Id = c.Int(nullable: false),
                        Login_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_Id, t.Login_Id1 });
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Phone = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Login_Id", c => c.Int());
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.Posts", "User_Id");
            DropTable("dbo.UsersUsers");
            DropTable("dbo.Users");
            CreateIndex("dbo.LoginLogins", "Login_Id1");
            CreateIndex("dbo.LoginLogins", "Login_Id");
            CreateIndex("dbo.Posts", "Login_Id");
            AddForeignKey("dbo.Posts", "Login_Id", "dbo.Logins", "Id");
            AddForeignKey("dbo.LoginLogins", "Login_Id1", "dbo.Logins", "Id");
            AddForeignKey("dbo.LoginLogins", "Login_Id", "dbo.Logins", "Id");
        }
    }
}
