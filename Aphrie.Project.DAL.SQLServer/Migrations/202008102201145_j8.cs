namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersUsers", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.UsersUsers", "Sender_Id", "dbo.Users");
            DropIndex("dbo.UsersUsers", new[] { "Receiver_Id" });
            DropIndex("dbo.UsersUsers", new[] { "Sender_Id" });
            DropColumn("dbo.UsersUsers", "Receiver_Id");
            DropColumn("dbo.UsersUsers", "Sender_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersUsers", "Sender_Id", c => c.Int());
            AddColumn("dbo.UsersUsers", "Receiver_Id", c => c.Int());
            CreateIndex("dbo.UsersUsers", "Sender_Id");
            CreateIndex("dbo.UsersUsers", "Receiver_Id");
            AddForeignKey("dbo.UsersUsers", "Sender_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UsersUsers", "Receiver_Id", "dbo.Users", "Id");
        }
    }
}
