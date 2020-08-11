namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Isarchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Isarchived");
        }
    }
}
