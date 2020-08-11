namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            AddColumn("dbo.Logins", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Logins", "Username", c => c.String());
            AddPrimaryKey("dbo.Logins", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Logins", "Id");
            AddPrimaryKey("dbo.Logins", "Username");
        }
    }
}
