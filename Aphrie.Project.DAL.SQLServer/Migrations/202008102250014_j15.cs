namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j15 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AddFriends");
            AlterColumn("dbo.AddFriends", "SenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.AddFriends", "ReceiverId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AddFriends", new[] { "SenderId", "ReceiverId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AddFriends");
            AlterColumn("dbo.AddFriends", "ReceiverId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AddFriends", "SenderId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AddFriends", new[] { "SenderId", "ReceiverId" });
        }
    }
}
