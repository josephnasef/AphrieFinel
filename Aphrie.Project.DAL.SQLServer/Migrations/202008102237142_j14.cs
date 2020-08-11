namespace Aphrie.Project.DAL.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j14 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddFrinds", newName: "AddFriends");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AddFriends", newName: "AddFrinds");
        }
    }
}
