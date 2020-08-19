using Aphrie.Project.Bll.Concert;
using Aphrie.Project.DAL.SQLServer.Context;
using Aphrie.Project.DAL.SQLServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.project.BLL.Mangers
{
    public class AddFriendManger : Repository<AddFriend>
    {
      
        public AddFriendManger(AphrieContext aphrieContext)
            :base(aphrieContext)
        {
            
        }
        public bool cheackfrienreq(int Rec, int sen)
        {
            bool Result = true;
            var find = GetAll().SingleOrDefault(u => u.ReceiverId == Rec && u.SenderId == sen);
            if (find == null)
            {
                return Result = false;
            }
            else
            {
                return Result;
            }

        }
    }
}
