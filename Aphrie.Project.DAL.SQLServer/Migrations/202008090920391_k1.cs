namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Image", c => c.Binary());
            DropColumn("dbo.Posts", "Imagepath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Imagepath", c => c.String());
            DropColumn("dbo.Posts", "Image");
        }
    }
}
