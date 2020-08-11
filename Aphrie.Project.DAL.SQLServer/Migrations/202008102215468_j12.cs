namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Sender_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Receiver_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Sender_Id" });
            DropPrimaryKey("dbo.UsersUsers");
            AddColumn("dbo.UsersUsers", "SenderId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsersUsers", "ReceiverId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UsersUsers", new[] { "SenderId", "ReceiverId" });
            DropColumn("dbo.UsersUsers", "User_Id");
            DropColumn("dbo.UsersUsers", "User_Id1");
            DropColumn("dbo.UsersUsers", "Receiver_Id");
            DropColumn("dbo.UsersUsers", "Sender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersUsers", "Sender_Id", c => c.Int());
            AddColumn("dbo.UsersUsers", "Receiver_Id", c => c.Int());
            AddColumn("dbo.UsersUsers", "User_Id1", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsersUsers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.UsersUsers");
            DropColumn("dbo.UsersUsers", "ReceiverId");
            DropColumn("dbo.UsersUsers", "SenderId");
            AddPrimaryKey("dbo.UsersUsers", new[] { "User_Id", "User_Id1" });
            CreateIndex("dbo.UsersUsers", "Sender_Id");
            CreateIndex("dbo.UsersUsers", "Receiver_Id");
            AddForeignKey("dbo.UsersUsers", "Sender_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Receiver_Id", "dbo.Users", "Id");
        }
    }
}
