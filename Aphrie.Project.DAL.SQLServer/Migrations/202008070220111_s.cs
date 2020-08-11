namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logins");
            DropPrimaryKey("dbo.Registers");
            AlterColumn("dbo.Logins", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Registers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Logins", "Id");
            AddPrimaryKey("dbo.Registers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Registers");
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Registers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Logins", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Registers", "Id");
            AddPrimaryKey("dbo.Logins", "Id");
        }
    }
}
