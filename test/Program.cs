using Aphrie.Project.BLL.Mangers;
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
            LoginManger loginManger = new LoginManger();
            Login my = new Login { Password = "123", Username = "koo" };
            loginManger.Add(my);
            Console.ReadKey();
        }
    }
}
