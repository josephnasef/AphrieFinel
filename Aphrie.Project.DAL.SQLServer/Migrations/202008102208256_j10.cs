namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j10 : DbMigration
    {
        public override void Up()
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
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.User_Id, t.User_Id1 })
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id1)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Users_Id)
                .Index(t => t.Users_Id1)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersUsers", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id1", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Sender_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Receiver_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id1" });
            DropIndex("dbo.UsersUsers", new[] { "Users_Id" });
            DropTable("dbo.UsersUsers");
        }
    }
}
