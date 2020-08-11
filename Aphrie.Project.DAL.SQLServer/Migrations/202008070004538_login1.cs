namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Logins", "Username");
            DropColumn("dbo.Logins", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Logins", "Username", c => c.String());
            AddPrimaryKey("dbo.Logins", "Id");
        }
    }
}
