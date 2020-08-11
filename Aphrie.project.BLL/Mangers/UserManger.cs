using Aphrie.Project.Bll.Concert;
using Aphrie.Project.DAL.SQLServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aphrie.project.BLL.Mangers
{
    public class UserManger : Repository<Users>
    {
        public int GetId()
        {
          return GetAll().SingleOrDefault(u => u.Username == HttpContext.Current.User.Identity.Name).Id;
        }
    }
}
