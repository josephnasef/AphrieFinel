using Aphrie.Project.DAL.SQLServer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.DAL.SQLServer.model
{
   public class Register: MainMemberOfPersone
    {     
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
