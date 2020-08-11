namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationwithpostsandlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Login_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Login_Id");
            AddForeignKey("dbo.Posts", "Login_Id", "dbo.Logins", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Posts", new[] { "Login_Id" });
            DropColumn("dbo.Posts", "Login_Id");
        }
    }
}
