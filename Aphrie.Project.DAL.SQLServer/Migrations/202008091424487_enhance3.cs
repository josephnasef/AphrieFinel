namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.Username });
            
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Users_Username = c.String(nullable: false, maxLength: 128),
                        Users_Id1 = c.Int(nullable: false),
                        Users_Username1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Users_Username, t.Users_Id1, t.Users_Username1 })
                .ForeignKey("dbo.Users", t => new { t.Users_Id, t.Users_Username })
                .ForeignKey("dbo.Users", t => new { t.Users_Id1, t.Users_Username1 })
                .Index(t => new { t.Users_Id, t.Users_Username })
                .Index(t => new { t.Users_Id1, t.Users_Username1 });
            
            AddColumn("dbo.Posts", "User_Id", c => c.Int());
            AddColumn("dbo.Posts", "User_Username", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", new[] { "User_Id", "User_Username" });
            AddForeignKey("dbo.Posts", new[] { "User_Id", "User_Username" }, "dbo.Users", new[] { "Id", "Username" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", new[] { "User_Id", "User_Username" }, "dbo.Users");
            DropForeignKey("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" }, "dbo.Users");
            DropForeignKey("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" }, "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" });
            DropIndex("dbo.Posts", new[] { "User_Id", "User_Username" });
            DropColumn("dbo.Posts", "User_Username");
            DropColumn("dbo.Posts", "User_Id");
            DropTable("dbo.UsersUsers");
            DropTable("dbo.Users");
        }
    }
}
