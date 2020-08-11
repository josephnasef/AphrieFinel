using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.Project.DAL.SQLServer.model
{
    public class AddFriend
    {
        [Key]
        [Column(Order = 1)]
        public int SenderId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public int ReceiverId { get; set; }        

        //Status == true : Friend request accepted
        //Status == false : Friend request not accepted
        public bool Status { get; set; }
       
    }
}
