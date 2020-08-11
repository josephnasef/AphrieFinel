namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropColumn("dbo.UsersUsers", "Users_Id");
            DropColumn("dbo.UsersUsers", "Users_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersUsers", "Users_Id1", c => c.Int());
            AddColumn("dbo.UsersUsers", "Users_Id", c => c.Int());
            CreateIndex("dbo.UsersUsers", "Users_Id1");
            CreateIndex("dbo.UsersUsers", "Users_Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users", "Id");
        }
    }
}
