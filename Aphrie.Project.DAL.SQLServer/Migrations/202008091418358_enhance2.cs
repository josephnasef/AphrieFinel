namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropColumn("dbo.Posts", "User_Id");
            DropTable("dbo.Users");
            DropTable("dbo.UsersUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Users_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Users_Id1 });
            
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
            
            AddColumn("dbo.Posts", "User_Id", c => c.Int());
            CreateIndex("dbo.UsersUsers", "Users_Id1");
            CreateIndex("dbo.UsersUsers", "Users_Id");
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users", "Id");
        }
    }
}
