using Katalog_v_2.Models;
using Katalog_v_2.Models.Abstract;
using Katalog_v_2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Katalog_v_2.Service.BDService
{
    public class UserService : IUser
    {
        private Context context;

        public UserService(Context context)
        {
            this.context = context;
        }

        public bool Registration(string Login, string Password)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Login == Login);
            if (element != null)
            {
                return false;
            }
            context.Users.Add(new User
            {
                Login = Login,
                Password = Password,
            });
            context.SaveChanges();
            return true;
        }

        public bool Authorization(string Login, string Password)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Login == Login && rec.Password == Password);
            if (element != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}