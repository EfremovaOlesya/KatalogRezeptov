using Katalog_v_2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_v_2.Models.Interface
{
    interface IUser
    {
        bool Registration(string Login, string Password);

        Boolean Authorization(string Login, string Password);
    }
}
