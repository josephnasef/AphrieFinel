namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropTable("dbo.Followings");
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
                "dbo.Followings",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId });
            
            CreateIndex("dbo.UsersUsers", "Users_Id1");
            CreateIndex("dbo.UsersUsers", "Users_Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users", "Id");
        }
    }
}
