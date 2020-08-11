namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersUsers",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        Users_Id = c.Int(),
                        Users_Id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId })
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
