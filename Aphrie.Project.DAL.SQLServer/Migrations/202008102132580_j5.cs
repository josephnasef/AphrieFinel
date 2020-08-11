namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SenderId, t.ReceiverId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Followings");
        }
    }
}
