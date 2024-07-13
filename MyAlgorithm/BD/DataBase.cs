using MyAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.BD
{
    internal class DataBase
    {
        private List<User> users = new List<User>
    {
        new User { Login = "qwerty228", Name = "Василий Петрович", IsPremium = true },
        new User { Login = "PRO_1337", Name = "Аркадий", IsPremium =  false},
        new User { Login = "SVEN_KILLER", Name = "Катя", IsPremium = true }
    };

        public User GetUserByLogin(string login)
        {
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }
            return null;
        }
    }

}
