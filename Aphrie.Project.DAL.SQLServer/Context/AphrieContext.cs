namespace Aphrie.Project.DAL.SQLServer.Context
{
    using Aphrie.Project.DAL.SQLServer.model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AphrieContext : DbContext
    {
      
        public AphrieContext()
            : base("name=AphrieContext")
        {
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Post>  post { get; set; }
        public DbSet<AddFriend> followings { get; set; }


    }

}