using Aphrie.project.BLL.Mangers;
using Aphrie.Project.DAL.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.project.BLL.Concert
{
    public class UnitOfWork
    {
        private AphrieContext AphrieContext = new AphrieContext();
        public AddFriendManger AddFriendManger{ 
            get
            {
                return new AddFriendManger(AphrieContext);
            } 
        }
        public postManger postManger 
        {
            get
            {
                return new postManger(AphrieContext);
            }
        }
        public UserManger UserManger
        {
            get
            {
                return new UserManger(AphrieContext);
            }
        }
        public void Save ()
        {
            AphrieContext.SaveChanges();
        }
    }
}
