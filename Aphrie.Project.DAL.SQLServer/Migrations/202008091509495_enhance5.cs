namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", new[] { "User_Id", "User_Username" }, "dbo.Users");
            DropForeignKey("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" }, "dbo.Users");
            DropForeignKey("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" }, "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_Id", "User_Username" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UsersUsers");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.UsersUsers", new[] { "Users_Id", "Users_Id1" });
            CreateIndex("dbo.Users", "Username", unique: true);
            CreateIndex("dbo.UsersUsers", "Users_Id");
            CreateIndex("dbo.UsersUsers", "Users_Id1");
            AddForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users", "Id");
            DropColumn("dbo.Posts", "User_Id");
            DropColumn("dbo.Posts", "User_Username");
            DropColumn("dbo.UsersUsers", "Users_Username");
            DropColumn("dbo.UsersUsers", "Users_Username1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersUsers", "Users_Username1", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsersUsers", "Users_Username", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Posts", "User_Username", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "User_Id", c => c.Int());
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropPrimaryKey("dbo.UsersUsers");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UsersUsers", new[] { "Users_Id", "Users_Username", "Users_Id1", "Users_Username1" });
            AddPrimaryKey("dbo.Users", new[] { "Id", "Username" });
            CreateIndex("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" });
            CreateIndex("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" });
            CreateIndex("dbo.Posts", new[] { "User_Id", "User_Username" });
            AddForeignKey("dbo.UsersUsers", new[] { "Users_Id1", "Users_Username1" }, "dbo.Users", new[] { "Id", "Username" });
            AddForeignKey("dbo.UsersUsers", new[] { "Users_Id", "Users_Username" }, "dbo.Users", new[] { "Id", "Username" });
            AddForeignKey("dbo.Posts", new[] { "User_Id", "User_Username" }, "dbo.Users", new[] { "Id", "Username" });
        }
    }
}
