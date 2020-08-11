namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageData", c => c.Binary());
            AddColumn("dbo.Posts", "ImageType", c => c.String());
            DropColumn("dbo.Posts", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Photo", c => c.String());
            DropColumn("dbo.Posts", "ImageType");
            DropColumn("dbo.Posts", "ImageData");
        }
    }
}
