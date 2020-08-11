namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Users_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Users_Id1 })
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id1)
                .Index(t => t.Users_Id)
                .Index(t => t.Users_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropTable("dbo.UsersUsers");
        }
    }
}
