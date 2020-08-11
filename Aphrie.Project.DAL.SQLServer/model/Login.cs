using Aphrie.Project.DAL.SQLServer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.DAL.SQLServer.model
{
   public class Login: MainMemberOfPersone
    {
        public Login(HashSet<Login> _followers , HashSet<Login> _person,HashSet<Post> _post)
        {
            Followers = _followers;
            person = _person;
            posts = _post;
        }
        public string Password { get; set; }
        public virtual ICollection<Login> Followers{ get; set; }
        public virtual ICollection<Login> person { get; set; }
        public virtual ICollection<Post> posts { get; set; }



    }
}
