using Aphrie.project.BLL.Concert;
using Aphrie.Project.DAL.SQLServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            
                Users users = new Users {Username="jojo",Password="1234",Phone="015" } ;
            unitOfWork.UserManger.Add(users);
            Console.ReadKey();
        }
    }
}
