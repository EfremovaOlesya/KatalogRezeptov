using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katalog_v_2.Models.Abstract
{
    public abstract class AModel
    {
        public int Id { set; get; }

        public String Name { set; get; }
    }
}