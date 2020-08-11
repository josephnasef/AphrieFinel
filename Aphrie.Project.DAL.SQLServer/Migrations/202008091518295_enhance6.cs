namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "User_Id", c => c.Int());
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.Posts", "User_Id");
        }
    }
}
