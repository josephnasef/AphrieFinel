namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Username", c => c.String());
        }
    }
}
