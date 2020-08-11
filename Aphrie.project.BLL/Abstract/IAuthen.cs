using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.project.BLL.Abstract
{
    interface IAuthen
    {
        bool CheackLogin(string Username, string Password);
        bool Logout();
    }
}
