namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enhance1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "creatdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "creatdate");
        }
    }
}
