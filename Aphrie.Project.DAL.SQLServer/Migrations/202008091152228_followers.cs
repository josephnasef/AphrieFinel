namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Login_Id", c => c.Int());
            CreateIndex("dbo.Logins", "Login_Id");
            AddForeignKey("dbo.Logins", "Login_Id", "dbo.Logins", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Logins", new[] { "Login_Id" });
            DropColumn("dbo.Logins", "Login_Id");
        }
    }
}
