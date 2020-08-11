using Aphrie.project.BLL.Abstract;
using Aphrie.Project.DAL.SQLServer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.project.BLL.Concert
{
   public class Authentication : IAuthen
    {
        private readonly AphrieContext aphrieContext;

        public Authentication(AphrieContext _aphrieContext)
        {
            this.aphrieContext = _aphrieContext;
        }

        public bool CheackLogin(string Username, string Password)
        {
            return aphrieContext.users.SingleOrDefault(u => u.Username == Username && u.Password == Password) != null;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
