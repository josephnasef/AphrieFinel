﻿using Aphrie.Project.Bll.Concert;
using Aphrie.Project.DAL.SQLServer.Context;
using Aphrie.Project.DAL.SQLServer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aphrie.project.BLL.Mangers
{
    public class postManger : Repository<Post>
    {
      

        public postManger(AphrieContext aphrieContext):
            base(aphrieContext)
        {
           
        }
    }
}
