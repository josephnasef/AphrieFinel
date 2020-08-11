namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Imagepath", c => c.String());
            DropColumn("dbo.Posts", "ImageData");
            DropColumn("dbo.Posts", "ImageType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ImageType", c => c.String());
            AddColumn("dbo.Posts", "ImageData", c => c.Binary());
            DropColumn("dbo.Posts", "Imagepath");
        }
    }
}
