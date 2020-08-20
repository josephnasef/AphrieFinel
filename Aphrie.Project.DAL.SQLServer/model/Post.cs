using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aphrie.Project.DAL.SQLServer.model
{
    public class Post
    {
      

        public int Id { get; set; }
        [UIHint("tinymce_jquery_full"),AllowHtml]
        public string content { get; set; }
        public string creatby { get; set; }
        public DateTime creatdate { get; set; }

        public string Image { get; set; }
        public bool Isarchived { get; set; }

        public int Users_Id { get; set; }
        public virtual Users User { get; set; }

    }
}
