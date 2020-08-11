using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.DAL.SQLServer.Abstract
{
    public abstract class MainMemberOfPersone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[Display(Name = "Name")]
        //[StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        
        public string Username { get; set; }
    }
}
