using Aphrie.Project.DAL.SQLServer.Abstract;
using Aphrie.Project.DAL.SQLServer.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.DAL.SQLServer.model
{
    public class Users 
    {
       

        [Key,Column(Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(255)]
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "this name  is exist please  enter differant  name ... thank you :) .")]
        [StringLength(450, ErrorMessage = "Please enter username valid name.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }

        public string Phone { get; set; }
        public string Image { get; set; }

        public Users(HashSet<Post> posts/*, HashSet<UsersUsers> followers, HashSet<UsersUsers> person*/)
        {
            this.posts = posts;
            //this.Followers = followers;
            //this.person = person;
        }

        public Users()
        {
            Username = null;
            Password = null;
            Phone = null;
        }


        //public virtual ICollection<UsersUsers> Followers { get; set; }
        //public virtual ICollection<UsersUsers> person { get; set; }
        public virtual ICollection<Post> posts { get; set; }


    }
}
