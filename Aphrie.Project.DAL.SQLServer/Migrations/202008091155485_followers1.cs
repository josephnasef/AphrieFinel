namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followers1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "Login_Id", "dbo.Logins");
            DropIndex("dbo.Logins", new[] { "Login_Id" });
            CreateTable(
                "dbo.LoginLogins",
                c => new
                    {
                        Login_Id = c.Int(nullable: false),
                        Login_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_Id, t.Login_Id1 })
                .ForeignKey("dbo.Logins", t => t.Login_Id)
                .ForeignKey("dbo.Logins", t => t.Login_Id1)
                .Index(t => t.Login_Id)
                .Index(t => t.Login_Id1);
            
            DropColumn("dbo.Logins", "Login_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Login_Id", c => c.Int());
            DropForeignKey("dbo.LoginLogins", "Login_Id1", "dbo.Logins");
            DropForeignKey("dbo.LoginLogins", "Login_Id", "dbo.Logins");
            DropIndex("dbo.LoginLogins", new[] { "Login_Id1" });
            DropIndex("dbo.LoginLogins", new[] { "Login_Id" });
            DropTable("dbo.LoginLogins");
            CreateIndex("dbo.Logins", "Login_Id");
            AddForeignKey("dbo.Logins", "Login_Id", "dbo.Logins", "Id");
        }
    }
}
