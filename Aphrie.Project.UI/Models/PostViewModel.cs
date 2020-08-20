using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aphrie.Project.UI.Models
{
    public class PostViewModel
    {

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string createBy { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }
        public string Image { get; set; }
        public string CreaterImage { get; set; }
        public bool Isarchived { get; set; }




    }
}