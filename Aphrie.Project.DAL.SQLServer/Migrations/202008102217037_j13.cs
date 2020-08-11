namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j13 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsersUsers", newName: "AddFrinds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AddFrinds", newName: "UsersUsers");
        }
    }
}
