namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropTable("dbo.UsersUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        User_Id1 = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        Users_Id = c.Int(),
                        Users_Id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.User_Id, t.User_Id1 });
            
            CreateIndex("dbo.UsersUsers", "Users_Id1");
            CreateIndex("dbo.UsersUsers", "Users_Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users", "Id");
        }
    }
}
