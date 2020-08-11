namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Username", c => c.String());
            AlterColumn("dbo.Registers", "Username", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
